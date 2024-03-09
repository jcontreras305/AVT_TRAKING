Imports System.Runtime.InteropServices
Imports System.Data.SqlClient
Public Class MoveHours
    Dim idClSender = ""
    Dim idPOGetter = ""
    Dim idPOSender = ""
    Dim idJobNoGetter = ""
    Dim idJobNoSender = ""
    Dim idWOGetter = ""
    Dim idWOSender = ""
    Dim idEmployee = ""
    Dim IdAuxGetter = ""
    Dim IdAuxSeter = ""
    Dim mtdMoveHrs As New MetodosMoveHours
    Dim tblProject As DataTable
    Private Sub btnMaximize_Click(sender As Object, e As EventArgs) Handles btnMaximize.Click
        MaximizedBounds = Screen.FromHandle(Me.Handle).WorkingArea
        WindowState = FormWindowState.Maximized
        btnMaximize.Visible = False
        btnRestore.Visible = True
    End Sub

    Private Sub btnRestore_Click(sender As Object, e As EventArgs) Handles btnRestore.Click
        WindowState = FormWindowState.Normal
        btnRestore.Visible = False
        btnMaximize.Visible = True
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles pcbMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles pcbClose.Click
        Me.Close()
    End Sub

    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(hWnd As IntPtr, wMsg As Integer, wParam As Integer, lParam As Integer)
    End Sub
    Private Sub MoveHours_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarComboClientsReports(cmbClientSender)
        llenarComboEmployeeReports(cmbEmployee, True)
        btnMove.Enabled = False
    End Sub

    Private Sub cmbClientSender_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClientSender.SelectedIndexChanged
        If cmbClientSender.SelectedIndex > -1 Then
            Dim array() As String = cmbClientSender.Items(cmbClientSender.SelectedIndex).ToString.Split(" ")
            If array.Length > 0 Then
                idClSender = array(0)
                llenarComboJobsReports(cmbJobSender, idClSender)
                llenarComboJobsReports(cmbJobGetter, idClSender)

                tblProject = mtdMoveHrs.selectProjects(idClSender)
            End If
            cmbJobSender.Text = ""
            idJobNoSender = ""
            cmbPOSender.Items.Clear()
            cmbPOSender.Text = ""
            idPOSender = ""
            cmbWOSender.Items.Clear()
            cmbWOSender.Text = ""
            idWOSender = ""
            cmbJobGetter.Text = ""
            idJobNoGetter = ""
            cmbPOGetter.Items.Clear()
            cmbPOGetter.Text = ""
            idPOGetter = ""
            cmbWOGetter.Items.Clear()
            cmbWOGetter.Text = ""
            idWOGetter = ""
        End If
    End Sub

    Private Sub cmbJobSender_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbJobSender.SelectedIndexChanged
        If cmbJobSender.SelectedIndex > -1 Then
            idJobNoSender = cmbJobSender.Items(cmbJobSender.SelectedIndex)
            llenarComboPOByClient(cmbPOSender, idClSender, idJobNoSender)
            'cmbPOSender.Items.Clear()
            cmbWOSender.Items.Clear()
            idWOSender = ""
        Else
            MsgBox("Please select a JobNo to continue.")
        End If
    End Sub

    Private Sub cmbJobGetter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbJobGetter.SelectedIndexChanged
        If cmbJobGetter.SelectedIndex > -1 Then
            idJobNoGetter = cmbJobGetter.Items(cmbJobGetter.SelectedIndex)
            llenarComboPOByClient(cmbPOGetter, idClSender, idJobNoGetter)
            'cmbPOGetter.Items.Clear()
            cmbWOGetter.Items.Clear()
            idWOGetter = ""
        Else
            MsgBox("Please select a JobNo to continue.")
        End If
    End Sub

    Private Sub cmbPOSender_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPOSender.SelectedIndexChanged
        If cmbPOSender.SelectedIndex > -1 Then
            idPOSender = cmbPOSender.Items(cmbPOSender.SelectedIndex)
            llenarComboWOByClient(cmbWOSender, idClSender, idJobNoSender, idPOSender)
            'cmbWOSender.Items.Clear()
        Else
            MsgBox("Please select a PO to continue.")
        End If
    End Sub

    Private Sub cmbPOGetter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPOGetter.SelectedIndexChanged
        If cmbPOGetter.SelectedIndex > -1 Then
            idPOGetter = cmbPOGetter.Items(cmbPOGetter.SelectedIndex)
            llenarComboWOByClient(cmbWOGetter, idClSender, idJobNoGetter, idPOGetter)
        Else
            MsgBox("Please select a PO to continue.")
        End If
    End Sub

    Private Sub cmbWOGetter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbWOGetter.SelectedIndexChanged
        If cmbWOGetter.SelectedIndex > -1 Then
            idWOGetter = cmbWOGetter.Items(cmbWOGetter.SelectedIndex)
            btnMove.Enabled = True
        Else
            idWOGetter = ""
            btnMove.Enabled = False
        End If
    End Sub

    Private Sub cmbWOSender_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbWOSender.SelectedIndexChanged
        If cmbWOSender.SelectedIndex > -1 Then
            idWOSender = cmbWOSender.Items(cmbWOSender.SelectedIndex)
        Else
            idWOSender = ""
        End If
    End Sub

    Private Sub chbAllEmployee_CheckedChanged(sender As Object, e As EventArgs) Handles chbAllEmployees.CheckedChanged
        If chbAllEmployees.Checked Then
            cmbEmployee.Enabled = False
            idEmployee = ""
        Else
            cmbEmployee.Enabled = True
        End If
    End Sub

    Private Sub cmbEmployee_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEmployee.SelectedIndexChanged
        If cmbEmployee.Enabled = True Then
            Dim array() As String = cmbEmployee.Items(cmbEmployee.SelectedIndex).ToString.Split(" ")
            If array.Length > 0 Then
                idEmployee = array(0)
            End If
        End If
    End Sub
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        Select Case tbcMain.SelectedIndex
            Case 0
                If idEmployee <> "" Or chbAllEmployees.Checked = True Then
                    If idClSender <> "" Or cmbClientSender.SelectedIndex > -1 Then
                        lblMessage.Text = "Message: " + "Looking for the Client hours ..."
                        If mtdMoveHrs.selectHours(tblHours, dtpStartDate.Value, dtpEndDate.Value, idClSender, idJobNoSender, idPOSender, idWOSender, If(chbAllEmployees.Checked, "", idEmployee)) Then
                            MsgBox("Successful")
                        Else
                            MsgBox("Error")
                        End If
                    Else
                        MsgBox("Please select a Client or Project into the Sender Area.")
                    End If
                Else
                    MsgBox("Please select a Employee or select All Employees.")
                End If
                activeButtonMove(tblHours)
            Case 1
                If idClSender <> "" Or cmbClientSender.SelectedIndex > -1 Then
                    lblMessage.Text = "Message: " + "Looking for the Material..."
                    If mtdMoveHrs.selectMaterials(tblMaterial, dtpStartDate.Value, dtpEndDate.Value, idClSender, idJobNoSender, idPOSender, idWOSender) Then
                        MsgBox("Successful")
                    Else
                        MsgBox("Error")
                    End If
                Else
                    MsgBox("Please select a Client or Project into the Sender Area.")
                End If
                activeButtonMove(tblMaterial)
            Case 2
                If idClSender <> "" Or cmbClientSender.SelectedIndex > -1 Then
                    lblMessage.Text = "Message: " + "Looking for the Expenses ..."
                    If mtdMoveHrs.selectPerdiem(tblPerdiem, dtpStartDate.Value, dtpEndDate.Value, idClSender, idJobNoSender, idPOSender, idWOSender, If(chbAllEmployees.Checked, "", idEmployee)) Then
                        MsgBox("Successful")
                    Else
                        MsgBox("Error")
                    End If
                Else
                    MsgBox("Please select a Client or Project into the Sender Area.")
                End If
                activeButtonMove(tblPerdiem)
                lblMessage.Text = "Message: " + "End"
        End Select
    End Sub

    Private Sub activeButtonMove(ByVal tbl As DataGridView)
        If tbl.Rows IsNot Nothing Then
            If tbl.Rows.Count > 0 Then
                btnMove.Enabled = True
            Else
                btnMove.Enabled = False
            End If
        Else
            btnMove.Enabled = False
        End If
    End Sub

    Private Sub btnMove_Click(sender As Object, e As EventArgs) Handles btnMove.Click
        If idWOGetter <> "" Then
            Select Case tbcMain.SelectedIndex
                Case 0
                    If tblHours.Rows IsNot Nothing Then
                        If tblHours.SelectedRows.Count > 0 Then
                            Dim arrayRow() As DataRow = tblProject.Select("numberClient = " + idClSender.ToString + " and jobNo = " + idJobNoGetter.ToString + " and idPO = " + idPOGetter.ToString + " and  Project = '" + idWOGetter + "'")
                            If arrayRow.Length > 0 Then
                                If mtdMoveHrs.moveHours(tblHours, arrayRow(0).ItemArray(6), lblMessage) Then
                                    MsgBox("Successful")
                                Else
                                    MsgBox("Error")
                                End If

                            Else
                                MsgBox("Is not posible to send the records to this project.")
                            End If
                        Else
                            MsgBox("Please select a Row to continue.")
                        End If
                    Else
                        MsgBox("Plese select a row to continue.")
                    End If
                Case 1
                    If tblMaterial.Rows IsNot Nothing Then
                        If tblMaterial.SelectedRows.Count > 0 Then
                            Dim arrayRow() As DataRow = tblProject.Select("numberClient = " + idClSender.ToString + " and jobNo = " + idJobNoGetter.ToString + " and idPO = " + idPOGetter.ToString + " and  Project = '" + idWOGetter + "'")
                            If arrayRow.Length > 0 Then
                                If mtdMoveHrs.moveMaterial(tblMaterial, arrayRow(0).ItemArray(6), lblMessage) Then
                                    MsgBox("Successful")
                                Else
                                    MsgBox("Error")
                                End If
                            Else
                                MsgBox("Is not posible to send the records to this project.")
                            End If
                        Else
                            MsgBox("Please select a Row to continue.")
                        End If
                    Else
                        MsgBox("Plese select a row to continue.")
                    End If
                Case 2
                    If tblPerdiem.Rows IsNot Nothing Then
                        If tblPerdiem.SelectedRows.Count > 0 Then
                            Dim arrayRow() As DataRow = tblProject.Select("numberClient = " + idClSender.ToString + " and jobNo = " + idJobNoGetter.ToString + " and idPO = " + idPOGetter.ToString + " and  Project = '" + idWOGetter + "'")
                            If arrayRow.Length > 0 Then
                                If mtdMoveHrs.movePerdiem(tblPerdiem, arrayRow(0).ItemArray(6), lblMessage) Then
                                    MsgBox("Successful")
                                Else
                                    MsgBox("Error")
                                End If
                            Else
                                MsgBox("Is not posible to send the records to this project.")
                            End If
                        Else
                            MsgBox("Please select a Row to continue.")
                        End If
                    Else
                        MsgBox("Plese select a row to continue.")
                    End If
            End Select
        Else
            MsgBox("Please Fill the Gruop Area of Getter.")
        End If
        lblMessage.Text = "Message: " + "End."
    End Sub

    Private Sub tbcMain_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbcMain.SelectedIndexChanged
        Select Case tbcMain.SelectedIndex
            Case 0
                chbAllEmployees.Enabled = True
                cmbEmployee.Enabled = True
                activeButtonMove(tblHours)
            Case 1
                chbAllEmployees.Enabled = False
                cmbEmployee.Enabled = False
                activeButtonMove(tblMaterial)
            Case 2
                chbAllEmployees.Enabled = True
                cmbEmployee.Enabled = True
                activeButtonMove(tblPerdiem)
        End Select
    End Sub
End Class

Public Class MetodosMoveHours
    Inherits ConnectioDB

    Public Function selectHours(ByVal tblHours As DataGridView, ByVal StartDate As Date, ByVal EndDate As Date, ByVal numClient As String, Optional jobNO As String = "", Optional PO As String = "", Optional WO As String = "", Optional emp As String = "") As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select hw.idHorsWorked, emp.numberEmploye as 'Employee No',CONCAT(emp.lastName , ' ',emp.firstName , ' ',emp.middleName)as 'Employee',
hw.hoursST as 'Hours ST', hw.hoursOT as 'Hours OT',hw.hours3 as 'Hours XT', wc.name as 'Work Code',
jb.jobNo, po.idPO as 'Project Order',CONCAT( wo.idWO,'-',tk.task)as 'WO' from hoursWorked as hw 
left join employees as emp on emp.idEmployee = hw.idEmployee
inner join task as tk on tk.idAux = hw.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO 
inner join projectOrder as po on po.idPO = wo.idPO and wo.jobNo = po.jobNo 
inner join job as jb on jb.jobNo = po .jobNo 
inner join clients as cl on cl.idClient = jb.idClient 
left join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = jb.jobNo
where hw.dateWorked between '" + validaFechaParaSQl(StartDate) + "' and '" + validaFechaParaSQl(EndDate) + "' and cl.numberClient = " + numClient + If(jobNO = "", "", " and jb.jobNo = " + jobNO) + If(PO = "", "", " and po.idPO = " + PO) + If(WO = "", "", " and CONCAT( wo.idWO,'-',tk.task) = '" + WO + "'") + If(emp = "", "", "and emp.numberEmploye=" + emp) + " 
order by jb.jobNo , po.idPO, CONCAT(emp.lastName , ' ',emp.firstName , ' ',emp.middleName) desc", conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)
                tblHours.DataSource = dt
                tblHours.Columns("idHorsWorked").Visible = False
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

    Public Function selectMaterials(ByVal tblMaterial As DataGridView, ByVal StartDate As Date, ByVal EndDate As Date, ByVal numClient As String, Optional jobNO As String = "", Optional PO As String = "", Optional WO As String = "") As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select mtu.idMaterialUsed ,mtu.description as 'Description', mt.name as 'Material' , mtu.amount  as 'Amount', 
jb.jobNo, po.idPO as 'Project Order',CONCAT( wo.idWO,'-',tk.task)as 'WO' from materialUsed as mtu 
inner join material as mt on mt.idMaterial = mtu.idMaterial 
inner join task as tk on tk.idAux = mtu.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO 
inner join projectOrder as po on po.idPO = wo.idPO and wo.jobNo = po.jobNo 
inner join job as jb on jb.jobNo = po .jobNo 
inner join clients as cl on cl.idClient = jb.idClient 
where mtu.dateMaterial between '" + validaFechaParaSQl(StartDate) + "' and '" + validaFechaParaSQl(EndDate) + "' and cl.numberClient = " + numClient + If(jobNO = "", "", " and jb.jobNo = " + jobNO) + If(PO = "", "", " and po.idPO = " + PO) + If(WO = "", "", " and CONCAT( wo.idWO,'-',tk.task) = '" + WO + "'") + " 
order by jb.jobNo , po.idPO  desc", conn)

            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)
                tblMaterial.DataSource = dt
                tblMaterial.Columns("idMaterialUsed").Visible = False
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

    Public Function selectPerdiem(ByVal tblPerdiem As DataGridView, ByVal StartDate As Date, ByVal EndDate As Date, ByVal numClient As String, Optional jobNO As String = "", Optional PO As String = "", Optional WO As String = "", Optional emp As String = "") As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select exu.idExpenseUsed ,emp.idEmployee, emp.numberEmploye as 'Employee No',CONCAT(emp.lastName , ' ',emp.firstName , ' ',emp.middleName)as 'Employee',
exu.amount as 'Amount',exu.dateExpense as 'Date', exu.description as 'Description' ,
jb.jobNo, po.idPO as 'Project Order',CONCAT( wo.idWO,'-',tk.task)as 'WO' 
from expensesUsed as exu 
left join employees as emp on emp.idEmployee = exu.idEmployee
inner join expenses as xp on xp.idExpenses = exu.idExpense
inner join task as tk on tk.idAux = exu.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO 
inner join projectOrder as po on po.idPO = wo.idPO and wo.jobNo = po.jobNo 
inner join job as jb on jb.jobNo = po .jobNo 
inner join clients as cl on cl.idClient = jb.idClient 
where exu.dateExpense between '" + validaFechaParaSQl(StartDate) + "' and '" + validaFechaParaSQl(EndDate) + "' and cl.numberClient = " + numClient + If(jobNO = "", "", " and jb.jobNo = " + jobNO) + If(PO = "", "", " and po.idPO = " + PO) + If(WO = "", "", " and CONCAT( wo.idWO,'-',tk.task) = '" + WO + "'") + If(emp = "", "", "and emp.numberEmploye=" + emp) + " 
order by jb.jobNo , po.idPO,CONCAT(emp.lastName , ' ',emp.firstName , ' ',emp.middleName)  desc", conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)
                tblPerdiem.DataSource = dt
                tblPerdiem.Columns("idExpenseUsed").Visible = False
                tblPerdiem.Columns("idEmployee").Visible = False
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

    Public Function moveHours(ByVal tblHours As DataGridView, ByVal idAuxGetter As String, ByVal lblMessage As Label) As Boolean
        Try
            conectar()
            Dim tran As SqlTransaction
            tran = conn.BeginTransaction
            Dim flag As Boolean = True
            Dim count As Integer = 1
            For Each row As DataGridViewRow In tblHours.SelectedRows
                lblMessage.Text = "Message: " + "Moving the selected row number (" + count.ToString() + ")"
                count += 1
                Dim cmd As New SqlCommand("if(select count(*) from hoursWorked where idHorsWorked = '" + row.Cells("idHorsWorked").Value + "')>0
begin
	if(select COUNT(*) from expensesUsed where idHorsWorked = '" + row.Cells("idHorsWorked").Value + "') > 0
	begin 
		update hoursWorked set idAux = '" + idAuxGetter + "' where idHorsWorked = '" + row.Cells("idHorsWorked").Value + "'
		update expensesUsed set idAux = '" + idAuxGetter + "' where idHorsWorked = '" + row.Cells("idHorsWorked").Value + "'
	end 
	else
	begin
		update hoursWorked set idAux = '" + idAuxGetter + "' where idHorsWorked = '" + row.Cells("idHorsWorked").Value + "'
	end
end ", conn)
                cmd.Transaction = tran
                If Not cmd.ExecuteNonQuery > 0 Then
                    flag = False
                    Exit For
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
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function moveMaterial(ByVal tblMaterial As DataGridView, ByVal idAuxGetter As String, ByVal lblMessage As Label) As Boolean
        Try
            conectar()
            Dim tran As SqlTransaction
            tran = conn.BeginTransaction
            Dim flag As Boolean = True
            Dim count As Integer = 1
            For Each row As DataGridViewRow In tblMaterial.SelectedRows
                lblMessage.Text = "Message: " + "Moving the selected row number (" + count.ToString() + ")"
                count += 1
                Dim cmd As New SqlCommand("update materialUsed set idAux = '" + idAuxGetter + "' where idMaterialUsed  = '" + row.Cells("idMaterialUsed").Value + "'", conn)
                cmd.Transaction = tran
                If Not cmd.ExecuteNonQuery > 0 Then
                    flag = False
                    Exit For
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
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function movePerdiem(ByVal tblPerdiem As DataGridView, ByVal idAuxGetter As String, ByVal lblMessage As Label) As Boolean
        Try
            conectar()
            Dim tran As SqlTransaction
            tran = conn.BeginTransaction
            Dim flag As Boolean = True
            Dim count As Integer = 1
            For Each row As DataGridViewRow In tblPerdiem.SelectedRows
                lblMessage.Text = "Message: " + "Moving the selected row number (" + count.ToString() + ")"
                count += 1
                Dim cmd As New SqlCommand("declare @newId1 as varchar(36)
if (select Count(*) from expensesUsed where idExpenseUsed = '" + row.Cells("idExpenseUsed").Value + "')>0
begin 
	if (select COUNT(*) from hoursWorked where idAux = '" + idAuxGetter + "' and dateWorked = '" + validaFechaParaSQl(row.Cells("Date").Value) + "' and idEmployee = '" + row.Cells("idEmployee").Value + "')=1 
	begin
		update expensesUsed set idAux = '" + idAuxGetter + "',idHorsWorked = (select  idHorsWorked from hoursWorked where idAux = '" + idAuxGetter + "' and dateWorked = '" + validaFechaParaSQl(row.Cells("Date").Value) + "' and idEmployee = '" + row.Cells("idEmployee").Value + "')   where idExpenseUsed = '" + row.Cells("idExpenseUsed").Value + "'
	end
	else
	begin 
		set @newId1 = NEWID()
		insert into hoursWorked values(@newId1 , 0,0,0,'" + validaFechaParaSQl(row.Cells("Date").Value) + "','" + row.Cells("idEmployee").Value.ToString() + "',null,'" + idAuxGetter + "','DAY'," + row.Cells("JobNo").Value.ToString() + ",'" + validaFechaParaSQl(row.Cells("Date").Value) + "')
		update expensesUsed set idAux = '" + idAuxGetter + "', idHorsWorked = @newId1  where idExpenseUsed = '" + row.Cells("idExpenseUsed").Value + "'
	end
end ", conn)
                cmd.Transaction = tran
                If Not cmd.ExecuteNonQuery > 0 Then
                    flag = False
                    Exit For
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
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function selectProjects(ByVal cl As String, Optional job As String = "", Optional po As String = "", Optional wo As String = "") As DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("
select cl.idClient, cl.numberClient , jb.jobNo , po.idPO ,wo.idAuxWO, wo.idWO ,tk.idAux , tk.task , CONCAT(idWO, '-' , tk.task )as 'Project' from task as tk 
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO 
inner join projectOrder as po on po.idPO = wo.idPO and wo.jobNo = po.jobNo 
inner join job as jb on jb.jobNo = po .jobNo 
inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient = " + If(cl = "", "", cl) + If(job = "", "", " and jb.jobNo = " + job) + If(po = "", "", " and po.idPO = " + po) + If(wo = "", "", " and CONCAT(idWO, '-' , tk.task ) like '%" + wo + "%'"), conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)

                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        Finally
            desconectar()
        End Try
    End Function
End Class