Imports System.Runtime.InteropServices
Imports System.Data.SqlClient

Public Class WrongHours
    Dim mtd As New wrongHoursMetodos

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
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
    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles TitleBar.MouseMove
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        Dim clientId, jobNo, employeeNum As String
        If Not chbAllClient.Checked Then
            If cmbClients.SelectedIndex >= 0 Then
                If Not chbAllJobs.Checked Then
                    If cmbJob.SelectedIndex >= 0 Then
                        Dim arrayCl() As String = cmbClients.Items(cmbClients.SelectedIndex).ToString.Split(" ")
                        clientId = arrayCl(0)
                        jobNo = cmbJob.Items(cmbJob.SelectedIndex).ToString
                        Dim arrayEmp() As String = cmbEmployees.Items(cmbEmployees.SelectedIndex).ToString.Split(" ")
                        If chbAllEmployees.Checked Then
                            If cmbEmployees.SelectedIndex >= 0 Then
                                ''bucar por todo 
                                employeeNum = arrayEmp(0)
                                If tbcControl.SelectedTab.TabIndex = tbpHours.TabIndex Then
                                    mtd.selectHours(tblHours, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), clientId, cmbFindDate.SelectedIndex, jobNo, employeeNum, True, True, True)
                                Else
                                    'Perdiem
                                    mtd.selectPerdiem(tblPerdiem, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), clientId, cmbFindDate.SelectedIndex, jobNo, employeeNum, True, True, True)
                                End If
                            Else
                                MessageBox.Show("Message", "Please select a Employee or check the option All Employees")
                            End If
                        Else
                            If tbcControl.SelectedTab.TabIndex = tbpHours.TabIndex Then
                                mtd.selectHours(tblHours, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), clientId, cmbFindDate.SelectedIndex, jobNo, "", True, True, False)
                            Else
                                'perdiem
                                mtd.selectPerdiem(tblPerdiem, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), clientId, cmbFindDate.SelectedIndex, jobNo, "", True, True, False)
                            End If
                        End If
                    Else
                        MessageBox.Show("Message", "Please select a Job or check the option All Jobs")
                    End If
                Else
                    ''buscar solo por cliente y fecha
                    Dim arrayCl() As String = cmbClients.Items(cmbClients.SelectedIndex).ToString.Split(" ")
                    clientId = arrayCl(0)
                    If tbcControl.SelectedTab.TabIndex = tbpHours.TabIndex Then
                        mtd.selectHours(tblHours, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), clientId, cmbFindDate.SelectedIndex, 0, "", True, False, False)
                    Else
                        'perdiem
                        mtd.selectPerdiem(tblPerdiem, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), clientId, cmbFindDate.SelectedIndex, 0, "", True, False, False)
                    End If
                End If
            Else
                MessageBox.Show("Message", "Please select a Client or check the option All Clients")
            End If
        Else
            If Not chbAllEmployees.Checked Then
                If cmbEmployees.SelectedIndex >= 0 Then
                    ''bucar por emplerado y dia
                    Dim arrayEmp() As String = cmbEmployees.Items(cmbEmployees.SelectedIndex).ToString.Split(" ")
                    employeeNum = arrayEmp(0)
                    If tbcControl.SelectedTab.TabIndex = tbpHours.TabIndex Then
                        mtd.selectHours(tblHours, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), "", cmbFindDate.SelectedIndex, "", employeeNum, False, False, True)
                    Else
                        'Perdiem
                        mtd.selectPerdiem(tblPerdiem, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), "", cmbFindDate.SelectedIndex, "", employeeNum, False, False, True)
                    End If
                Else
                    MessageBox.Show("Message", "Please select a Employee or check the option All Employees")
                End If
            Else ''buscar solo con fechas y/o empleados
                If tbcControl.SelectedTab.TabIndex = tbpHours.TabIndex Then
                    mtd.selectHours(tblHours, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), "", cmbFindDate.SelectedIndex, "", "", False, False, False)
                Else
                    'perdiem  
                    mtd.selectPerdiem(tblPerdiem, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), "", cmbFindDate.SelectedIndex, "", "", False, False, False)
                End If
            End If
        End If
    End Sub

    Private Sub chbAllJobs_CheckedChanged(sender As Object, e As EventArgs) Handles chbAllJobs.CheckedChanged
        If chbAllJobs.Checked Then
            cmbJob.Enabled = False
        Else
            cmbJob.Enabled = True
            If cmbJob.Items.Count > 0 Then
                cmbJob.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub WrongHours_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarComboClientsReports(cmbClients)
        cmbFindDate.SelectedIndex = 0
        llenarComboEmployeeReports(cmbEmployees)

    End Sub

    Private Sub chbAllClient_CheckedChanged(sender As Object, e As EventArgs) Handles chbAllClient.CheckedChanged
        If chbAllClient.Checked Then
            cmbClients.Enabled = False
            chbAllJobs.Checked = True
        Else
            cmbClients.Enabled = True
            cmbClients.SelectedIndex = 0
        End If
    End Sub

    Private Sub cmbClients_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClients.SelectedIndexChanged
        Dim arrayCl() As String = cmbClients.Items(cmbClients.SelectedIndex).ToString.Split(" ")
        Dim clientId = arrayCl(0)
        llenarComboJobsReports(cmbJob, clientId)
    End Sub

    Private Sub chbAllEmployees_CheckedChanged(sender As Object, e As EventArgs) Handles chbAllEmployees.CheckedChanged
        cmbEmployees.Enabled = Not chbAllEmployees.Checked
        cmbEmployees.SelectedIndex = 0
    End Sub

    Private Sub btnSelectAll_Click(sender As Object, e As EventArgs) Handles btnSelectAll.Click
        Select Case tbcControl.SelectedIndex
            Case 0
                For Each row As DataGridViewRow In tblHours.Rows
                    row.Selected = True
                Next
            Case 1
                For Each row As DataGridViewRow In tblPerdiem.Rows
                    row.Selected = True
                Next
        End Select
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If DialogResult.Yes = MessageBox.Show("Are you sure to delete the records?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                Select Case tbcControl.SelectedIndex
                    Case 0
                        If mtd.deleteHours(tblHours) Then
                            MsgBox("Successful")
                        Else
                            MsgBox("Error please check the Data")
                        End If
                    Case 1
                        If mtd.deletePerdiem(tblPerdiem) Then
                            MsgBox("Successful")
                        Else
                            MsgBox("Error please check the Data")
                        End If
                End Select
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class

Public Class wrongHoursMetodos
    Inherits ConnectioDB

    Public Function selectHours(ByVal tbl As DataGridView, ByVal startDate As Date, ByVal endDate As Date, Optional idClient As String = "", Optional dateOption As Integer = 0, Optional job As String = "", Optional Employee As String = "", Optional allClient As Boolean = False, Optional allJobs As Boolean = False, Optional allEmployee As Boolean = False) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select hw.dateWorked as DateWorked, emp.numberEmploye as 'Emlpoyee No',CONCAT( emp.lastName , ', ' , emp.firstName , ' ',emp.middleName) as Employee,
                jb.jobNo 'JobNo', po.idPO as 'Project' , CONCAT(wo.idWO , '-' ,tk.task) as 'Work',
                wc.name as 'WorkCode' , hw.hoursST , hw.hoursOT , hw.hours3 , hw.schedule 
,hw.idHorsWorked  from hoursWorked as hw 
                inner join task as tk on tk.idAux = hw.idAux 
                inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO	
                inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
                inner join job as jb on jb.jobNo = po.jobNo
                inner join clients as cl on cl.idClient = jb.idClient 
                inner join workCode as wc on wc.idWorkCode  = hw.idWorkCode and wc.jobNo = jb.jobNo
                inner join employees as emp on emp.idEmployee= hw.idEmployee
                where " + If(allClient, " cl.numberClient = " + idClient + If(allJobs, " and jb.jobNo = " + job + " ", ""), "") + If(dateOption = 1, If(allClient, " and ", "") + " hw.dateWorked between '" + validaFechaParaSQl(startDate) + "' and '" + validaFechaParaSQl(endDate) + "'", If(allClient, " and ", "") + " hw.dayInserted between '" + validaFechaParaSQl(startDate) + "' and '" + validaFechaParaSQl(endDate) + "'") + If(allEmployee, " and  emp.numberEmploye = " + Employee, ""), conn)
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                tbl.DataSource = dt
                tbl.Columns(11).Visible = False
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return True
        Finally
            desconectar()
        End Try
    End Function

    Public Function selectPerdiem(ByVal tbl As DataGridView, ByVal startDate As Date, ByVal endDate As Date, Optional idClient As String = "", Optional dateOption As Integer = 0, Optional job As String = "", Optional Employee As String = "", Optional allClient As Boolean = False, Optional allJobs As Boolean = False, Optional allEmployee As Boolean = False) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select exu.description as 'Description',exu.amount as 'Amount $',CONVERT(varchar,exu.dateExpense,101) as 'Date',CONCAT( emp.lastName , ', ' , emp.firstName , ' ',emp.middleName) as Employee,emp.numberEmploye,
jb.jobNo as 'Job No',po.idPO as 'PO',CONCAT(wo.idWO,'-',tk.task) as 'Work',ex.expenseCode as 'Expense Code',(hw.hoursST + hw.hoursOT + hw.hours3) as 'THrs',exu.idExpenseUsed,exu.idHorsWorked
from expensesUsed as exu
inner join hoursWorked as hw on hw.idHorsWorked = exu.idHorsWorked 
inner join expenses as ex on ex.idExpenses = exu.idExpense
inner join employees as emp on emp.idEmployee = exu.idEmployee
inner join task as tk on tk.idAux = exu.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
inner join job as jb on jb.jobNo = po.jobNo
inner join clients as cl on cl.idClient = jb.idClient
where" + If(allClient, " cl.numberClient = " + idClient + If(allJobs, " and jb.jobNo = " + job + " ", ""), "") + If(dateOption = 0, If(allClient, " and ", "") + " exu.dayInserted between '" + validaFechaParaSQl(startDate) + "' and '" + validaFechaParaSQl(endDate) + "'", If(allClient, " and ", "") + " exu.dateExpense between '" + validaFechaParaSQl(startDate) + "' and '" + validaFechaParaSQl(endDate) + "'") + If(allEmployee, " and  emp.numberEmploye = " + Employee, ""), conn)
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                tbl.DataSource = dt
                tbl.Columns(9).Visible = False
                tbl.Columns(10).Visible = False
                tbl.Columns(11).Visible = False
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function deleteHours(ByVal tbl As DataGridView) As Boolean
        Try
            conectar()
            Dim tran As SqlTransaction
            tran = conn.BeginTransaction
            Dim flag As Boolean = True
            For Each row As DataGridViewRow In tbl.SelectedRows
                Dim cmd As New SqlCommand("if (select count( *) from expensesUsed where idHorsWorked = '" + row.Cells(11).Value + "' ) > 0
begin
	delete from expensesUsed where idHorsWorked = '" + row.Cells(11).Value + "'
	delete from hoursWorked where idHorsWorked = '" + row.Cells(11).Value + "'
end
else 
begin
	delete from hoursWorked where idHorsWorked = '" + row.Cells(11).Value + "'
end", conn)
                cmd.Transaction = tran
                If cmd.ExecuteNonQuery Then
                    flag = True
                Else
                    flag = False
                End If
            Next
            If flag Then
                tran.Commit()
                Return True
            Else
                tran.Rollback()
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function deletePerdiem(ByVal tbl As DataGridView) As Boolean
        Dim tran As SqlTransaction
        Try
            conectar()
            tran = conn.BeginTransaction
            Dim flag As Boolean = True
            For Each row As DataGridViewRow In tbl.SelectedRows
                Dim cmd As New SqlCommand("if ( " + row.Cells(9).Value.ToString() + " = 0 ) 
begin 
	if (select COUNT (*) from expensesUsed where idHorsWorked = '" + row.Cells(11).Value + "')> 1 
	begin 
		delete from expensesUsed where idExpenseUsed = '" + row.Cells(10).Value + "'
	end
	else 
	begin 
		delete from expensesUsed where idExpenseUsed = '" + row.Cells(10).Value + "'
		delete from hoursWorked where idHorsWorked = '" + row.Cells(11).Value + "'
	end 
end
else 
begin
	delete from expensesUsed where idExpenseUsed = '" + row.Cells(10).Value + "'
end", conn)
                cmd.Transaction = tran
                If cmd.ExecuteNonQuery Then
                    flag = True
                Else
                    flag = False
                End If
            Next
            If flag Then
                tran.Commit()
                Return True
            Else
                tran.Rollback()
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)

            Return False
        Finally
            desconectar()
            tran.Dispose()
        End Try
    End Function
End Class