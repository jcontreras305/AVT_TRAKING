Imports System.Runtime.InteropServices
Imports System.Data.SqlClient
Public Class ReportFieldForce
    Dim mtd As New mtdReportFieldForce
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.Close()
    End Sub
    Private Sub btnMinimize_Click(sender As Object, e As EventArgs) Handles btnMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub btnRestore_Click(sender As Object, e As EventArgs) Handles btnRestore.Click
        WindowState = FormWindowState.Normal
        btnRestore.Visible = False
        btnMaximize.Visible = True
    End Sub
    Private Sub btnMaximize_Click(sender As Object, e As EventArgs) Handles btnMaximize.Click
        MaximizedBounds = Screen.FromHandle(Me.Handle).WorkingArea
        WindowState = FormWindowState.Maximized
        btnMaximize.Visible = False
        btnRestore.Visible = True
    End Sub
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(hWnd As IntPtr, wMsg As Integer, wParam As Integer, lParam As Integer)
    End Sub
    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub ReportFieldForce_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarComboClientsReports(cmbClients)
    End Sub

    Private Sub cmbClients_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClients.SelectedIndexChanged
        If cmbClients.SelectedIndex >= 0 Then
            Dim arrayCl() As String = cmbClients.Items(cmbClients.SelectedIndex).ToString.Split(" ")
            If arrayCl.Length > 1 Then
                llenarComboJobsReports(cmbJobs, arrayCl(0))
                cmbJobs.Text = ""
            End If
        End If
    End Sub

    Private Sub chbAllJobs_CheckedChanged(sender As Object, e As EventArgs) Handles chbAllJobs.CheckedChanged
        If chbAllJobs.Checked Then
            cmbJobs.Enabled = False
        Else
            cmbJobs.Enabled = True
        End If
    End Sub

    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        Try
            If cmbClients.SelectedIndex >= 0 Then
                Dim arrayCl() As String = cmbClients.Items(cmbClients.SelectedIndex).ToString.Split(" ")
                If (chbAllJobs.Checked Or cmbJobs.Text <> "") And arrayCl.Length > 0 Then
                    lblMesage.Text = "Message: " + "Searching..."
                    mtd.selectInfo(tblFieldForce, dtpStartDate.Value, dtpEndDate.Value, arrayCl(0), If(chbAllJobs.Checked, "", cmbJobs.Items(cmbJobs.SelectedIndex).ToString()))
                    lblMesage.Text = "Message: " + "End."
                Else
                    MessageBox.Show("Please select a Job Number or select All Jobs", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("Please select Client and Job Number or select the option 'All Jobs'", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnExcelReport_Click(sender As Object, e As EventArgs) Handles btnExcelReport.Click
        Dim flagOpen As Boolean = False
        Dim ruta As String = ""
        Dim ApExcel = New Microsoft.Office.Interop.Excel.Application
        Dim libro = ApExcel.Workbooks.Add()
        lblMesage.Text = "Message: " + "Preparing excel field..."
        Try
            Dim Hoja1 = libro.Worksheets(1)
            Dim count As Integer = 1
            With Hoja1.Range("A1:AA1")
                .Font.Bold = True
                .Font.ColorIndex = 2 'Color de texto
                With .Interior
                    .ColorIndex = 10 'Color de Celda
                End With
                .BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Color.Green) ' Formato de borde de celda
            End With
            Dim countColum As Integer = 1
            For Each colm As DataGridViewColumn In tblFieldForce.Columns
                Hoja1.Cells(1, countColum) = colm.Name.ToString()
                countColum += 1
            Next
            For Each row As DataGridViewRow In tblFieldForce.Rows
                For Each cell As DataGridViewCell In row.Cells
                    Hoja1.Cells(row.Index + 2, cell.ColumnIndex + 1) = cell.Value.ToString()
                    lblMesage.Text = "Message: " + "Writing row (" + row.Index.ToString() + ")..."
                Next
            Next
            lblMesage.Text = "Message: " + "Preparing excel to save..."
            Hoja1.Name = "TS_Upload"
            Dim opFile As New SaveFileDialog
            opFile.DefaultExt = "xlsx"
            Dim dateNamefield As Date = Date.Today
            opFile.FileName = "Field Force TS " + Format(dateNamefield, "MM-dd-yyyy") + ".xlsx"
            If DialogResult.OK = opFile.ShowDialog() Then
                ruta = opFile.FileName
                libro.SaveAs(opFile.FileName)
                MsgBox("Successful")
                NAR(Hoja1)
                If DialogResult.Yes = MessageBox.Show("Successful" + vbCrLf + "Would you like to open the excel?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                    flagOpen = True
                End If
            End If
        Catch ex As Exception
        Finally
            libro.Close()
            NAR(libro)
            ApExcel.Quit()
            NAR(ApExcel)
            lblMesage.Text = "Message: "
            If flagOpen Then
                System.Diagnostics.Process.Start(ruta)
            End If
        End Try
    End Sub
End Class

Public Class mtdReportFieldForce
    Inherits ConnectioDB

    Public Function selectInfo(ByVal tbl As DataGridView, ByVal StartDate As Date, ByVal endDate As Date, ByVal clientNum As String, Optional jobNo As String = "") As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("declare @startDate as date = '" + validaFechaParaSQl(StartDate) + "'
declare @endDate as date = '" + validaFechaParaSQl(endDate) + "'
declare @numclient as int = " + clientNum + "
declare @jobNo as bigint = " + If(jobNo = "", "''", jobNo) + "

select 
(select T3.[Row] from 
		(select ROW_NUMBER() OVER(ORDER BY idWO) as 'Row', *  from 
			(select distinct wo1.idWO from hoursWorked as hw1 
				inner join task as tk1 on tk1.idAux = hw1.idAux
				inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
				inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo 
				inner join job as jb1 on jb1.jobNo = po1.jobNo 
				inner join clients as cl1 on cl1.idClient= jb1.idClient
				where 
				hw1.dateWorked between @startDate and @endDate 
				and cl1.numberClient  = @numclient 
				and jb1.jobNo like iif(@jobNo= '','%', convert(nvarchar,@jobNo))
			) as T2 
		) as T3 where T3.idWO = T1.[Work Order]
	) as 'TS Gruping',
* from (
select 
	DISTINCT
	jb.postingProject as 'Posting Project',
	po.idPO as 'Purchase Order',
	po.Line as 'Line .',
	wo.idWO as 'Work Order',
	tk.task as 'Task',
	'' as 'Sub Task',
	wc.Category as 'Category',
	hw.dateWorked as 'Time Sheet Date',
	hw.schedule as 'Shift',
	po.WBS as 'WBS',
	wc.PayItemType as 'Pay Item Type',
	wc.WorkType as 'Work Type',
	em.numberEmploye as 'Brock ID',
	wc.CostCode as 'Cost Code',
	wc.CustomerPositionID as 'Customer Position ID',
	wc.CustomerJobPositionDescription as 'Customer Job Position Description',
	wc.CBSFullNumber as 'CBS Full Number',
	SUM (hw.hoursST) OVER(PARTITION BY jb.postingProject , po.IdPO , wo.idWO , tk.task, hw.dateWorked,hw.schedule,em.numberEmploye)  as 'Allocation ST',
	SUM (hw.hoursOT) OVER(PARTITION BY jb.postingProject , po.IdPO , wo.idWO , tk.task, hw.dateWorked,hw.schedule,em.numberEmploye)  as 'Allocation OT',
	IIF (SUM (hw.hours3) OVER(PARTITION BY jb.postingProject , po.IdPO , wo.idWO , tk.task, hw.dateWorked,hw.schedule,em.numberEmploye)=0,'',CONCAT('',SUM (hw.hours3) OVER(PARTITION BY jb.postingProject , po.IdPO , wo.idWO , tk.task, hw.dateWorked,hw.schedule,em.numberEmploye))) as 'Allocation DT',
	'' as 'IsSubsistence',
    '' as 'Equipment ID',
	'' as 'Customer Equipment ID',
	'' as 'Customer Equipment Description',
	'' as 'In Use',
	'' as 'Idle'
from hoursWorked as hw 
inner join employees as em on em.idEmployee = hw.idEmployee
inner join task as tk on tk.idAux = hw.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and wo.jobNo = po.jobNo 
inner join job as jb on jb.jobNo = po.jobNo 
inner join clients as cl on cl.idClient= jb.idClient
inner join workCode as wc on wc.idWorkCode = hw.idWorkCode and hw.jobNo = wc.jobNo
where hw.dateWorked between @startDate and @endDate 
	  and cl.numberClient  = @numclient 
	  and jb.jobNo like iif(@jobNo= '','%', convert(nvarchar,@jobNo))
UNION 

select 
	jb.postingProject as 'Posting Project',
	po.idPO as 'Purchase Order',
	po.Line as 'Line .',
	wo.idWO as 'Work Order',
	tk.task as 'Task',
	'' as 'Sub Task',
	'' as 'Category',
	exu.dateExpense as 'Time Sheet Date',
	'Day' as 'Shift',
	po.WBS as 'WBS',
	'' as 'Pay Item Type',
	'' as 'Work Type',
	em.numberEmploye as 'Brock ID',
	'' as 'Cost Code',
	'' as 'Customer Position ID',
	'' as 'Customer Job Position Description',
	'' as 'CBS Full Number'	,
	0 as 'Allocation ST',
	0 as 'Allocation OT',
	'' as 'Allocation DT',
	IIF (exu.amount>0,'TRUE','')  as 'IsSubsistence',
	'' as 'Equipment ID',
	'' as 'Customer Equipment ID',
	'' as 'Customer Equipment Description',
	'' as 'In Use',
	'' as 'Idle'
from expensesUsed as exu
inner join task as tk on exu.idAux = tk.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO 
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo 
inner join job as jb on jb.jobNo = po.jobNo
inner join clients as cl on cl.idClient = jb.idClient
inner join employees as em on em.idEmployee = exu.idEmployee
where exu.dateExpense between @startDate and @endDate 
	  and cl.numberClient  = @numclient 
	  and jb.jobNo like iif(@jobNo= '','%', convert(nvarchar,@jobNo)) 

)as T1
order by [TS Gruping] asc
", conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)
                tbl.DataSource = dt
            End If
            Return True
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function
End Class
