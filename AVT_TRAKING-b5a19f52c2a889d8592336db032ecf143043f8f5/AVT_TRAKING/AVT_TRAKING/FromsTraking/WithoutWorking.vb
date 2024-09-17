Imports System.Runtime.InteropServices
Imports System.Data.SqlClient
Public Class WithoutWorking
    Dim mtdPoPercent As New MetodosProjectPorcentage
    Dim mtdJobs As New MetodosJobs
    Dim mtd As New mtdWithoutWorking
    Public clientId As String = ""
    Dim tblPOs As DataTable
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
    End Sub
    Private Sub btnMinimize_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
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
    Private Sub WithoutWorking_Load(sender As Object, e As EventArgs) Handles Me.Load
        llenarComboClientsReports(cmbClient)
    End Sub
    Private Sub cmbClient_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClient.SelectedIndexChanged
        If cmbClient.SelectedItem IsNot Nothing Then
            Dim array() As String = cmbClient.SelectedItem.ToString.Split(" ")
            clientId = array(0)
            llenarComboJobsReports(cmbJobNo, clientId)
            llenarComboPOByClient(cmbProjectOrder, clientId)
        End If
    End Sub
    Private Sub cmbJobNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbJobNo.SelectedIndexChanged
        If cmbJobNo.SelectedItem IsNot Nothing Then
            JobNo = cmbJobNo.Items(cmbJobNo.SelectedIndex)
            llenarComboPOByClient(cmbProjectOrder, clientId, JobNo)
            cmbProjectOrder.Text = ""
        End If
    End Sub

    Private Sub chbAllJobs_CheckedChanged(sender As Object, e As EventArgs) Handles chbAllJobs.CheckedChanged
        If chbAllJobs.Checked Then
            cmbJobNo.Enabled = False
        Else
            cmbJobNo.Enabled = True
        End If
    End Sub

    Private Sub chbAllPO_CheckedChanged_1(sender As Object, e As EventArgs) Handles chbAllPOs.CheckedChanged
        If chbAllPOs.Checked Then
            cmbProjectOrder.Enabled = False
        Else
            cmbProjectOrder.Enabled = True
        End If
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        If chbAllJobs.Checked Then
            If mtd.selectProjectWithoutWorking(tblProjects, clientId, If(cmbShow.SelectedIndex = 0, True, False)) Then
                MsgBox("Successful.")
            End If
        ElseIf cmbJobNo.SelectedIndex > -1 Then
            If Not chbAllPOs.Checked Then
                If cmbProjectOrder.SelectedIndex > -1 Then
                    If mtd.selectProjectWithoutWorking(tblProjects, clientId, If(cmbShow.SelectedIndex = 0, True, False), cmbJobNo.Items(cmbJobNo.SelectedIndex), cmbProjectOrder.Items(cmbProjectOrder.SelectedIndex)) Then
                        MsgBox("Successful.")
                    End If
                Else
                    MsgBox("Please select a Project or select the option All PO.")
                End If
            Else
                If mtd.selectProjectWithoutWorking(tblProjects, clientId, If(cmbShow.SelectedIndex = 0, True, False), cmbJobNo.Items(cmbJobNo.SelectedIndex)) Then
                    MsgBox("Successful.")
                End If
            End If

        Else
            MsgBox("Please select a JobNo or select the option All Jobs.")
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If tblProjects.Rows.Count > 0 Then
                If DialogResult.Yes = MessageBox.Show("The Selected row(s) will be deleted. Are you sure to continue?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) Then
                    If mtdJobs.deleteProject(tblProjects) Then
                        MsgBox("Successful.")
                        For Each row As DataGridViewRow In tblProjects.SelectedRows
                            tblProjects.Rows.Remove(row)
                        Next
                    End If
                End If
            Else
                MessageBox.Show("Please select a row to continue.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class

Public Class mtdWithoutWorking
    Inherits ConnectioDB

    Public Function selectProjectWithoutWorking(ByVal tbl As DataGridView, ByVal numberCl As String, ByVal all As Boolean, Optional jobNo As String = "", Optional PO As String = "") As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("declare @numberCl as integer = " + numberCl + "
select * from (
select 
distinct
T1.[idAux],T1.[idAuxWO],
T1.[Work Order],
T1.[Project Order] as 'idPO',
T1.[JobNo] as 'jobNo',
T1.[Description],
sum( T1.[Total Hours]) over(partition by T1.[IdAux], T1.[Work Order],T1.[Project Order],T1.[JobNo]) as 'Total Hours',
sum( T1.[Perdiem]) over(partition by T1.[IdAux],T1.[Work Order],T1.[Project Order],T1.[JobNo]) as 'Total Perdiem',
sum( T1.[Material]) over (partition by T1.[IdAux],T1.[Work Order],T1.[Project Order],T1.[JobNo]) as 'Total Material',
sum( T1.[QTY Scaffolds]) over(partition by T1.[IdAux],T1.[Work Order],T1.[Project Order],T1.[JobNo]) as 'Total QTY Scaffold' ,
sum( T1.[QTY Scaffolds Estimation]) over(partition by T1.[IdAux],T1.[Work Order],T1.[Project Order],T1.[JobNo]) as 'Total QTY Scaffold Estimation'
from (
select 
DISTINCT
tk.idAux ,wo.[idAuxWO],
concat(wo.idWO , '-' , tk.task) as 'Work Order',
po.idPO as 'Project Order',
jb.jobNo as 'JobNo',
tk.description as 'Description',
sum(ISNULL( hw.hoursST,0)+ ISNULL(hw.hoursOT,0)+ISNULL(hours3,0)) OVER (PARTITION BY jb.jobNo, po.idPO,concat(wo.idWO , '-' , tk.task),tk.idAux ) as 'Total Hours',
0 as  'Perdiem',
0 as 'Material',
0 as 'QTY Scaffolds',
0 as 'QTY Scaffolds Estimation'
from task as tk
left join hoursWorked as hw on hw.idAux = tk.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNO = wo.jobNo
inner join job as jb on jb.jobNo = po.jobNo
inner join clients as cl on cl.idClient = jb.idClient
where cl.numberClient = @numberCl

union all

select
DISTINCT 
tk.idAux ,wo.idAuxWO,
concat(wo.idWO , '-' , tk.task) as 'Work Order',
po.idPO as 'Project Order',
jb.jobNo as 'JobNo',
tk.description as 'Description',
0 as 'Total Hours',
sum(ISNULL( exu.amount,0)) OVER (PARTITION BY jb.jobNo, po.idPO,concat(wo.idWO , '-' , tk.task),tk.idAux ) as  'Perdiem',
0 as 'Material',
0 as 'QTY Scaffolds',
0 as 'QTY Scaffolds Estimation'
from task as tk
left join expensesUsed as exu on exu.idAux = tk.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNO = wo.jobNo
inner join job as jb on jb.jobNo = po.jobNo
inner join clients as cl on cl.idClient = jb.idClient
where cl.numberClient = @numberCl

union all

select
DISTINCT 
tk.idAux ,wo.idAuxWO,
concat(wo.idWO , '-' , tk.task) as 'Work Order',
po.idPO as 'Project Order',
jb.jobNo as 'JobNo',
tk.description as 'Description',
0 as 'Total Hours',
0 as 'Perdiem',
sum(ISNULL( mtu.amount,0)) OVER (PARTITION BY jb.jobNo, po.idPO,concat(wo.idWO , '-' , tk.task),tk.idAux ) as 'Material',
0 as 'QTY Scaffolds',
0 as 'QTY Scaffolds Estimation'
from task as tk
left join materialUsed as mtu on mtu.idAux = tk.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNO = wo.jobNo
inner join job as jb on jb.jobNo = po.jobNo
inner join clients as cl on cl.idClient = jb.idClient
where cl.numberClient = @numberCl

union all

select
distinct
tk.idAux ,wo.idAuxWO,
concat(wo.idWO , '-' , tk.task) as 'Work Order',
po.idPO as 'Project Order',
jb.jobNo as 'JobNo',
tk.description as 'Description',
0 as 'Total Hours',
0 as 'Perdiem',
0 as 'Material',
(select COUNT(tag) from scaffoldTraking as sc1 where sc1.idAux = tk.idAux) as 'QTY Scaffolds',
0 as 'QTY Scaffolds Estimation'
from task as tk
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNO = wo.jobNo
inner join job as jb on jb.jobNo = po.jobNo
inner join clients as cl on cl.idClient = jb.idClient
where cl.numberClient = @numberCl

union all

select
distinct
tk.idAux ,wo.idAuxWO,
concat(wo.idWO , '-' , tk.task) as 'Work Order',
po.idPO as 'Project Order',
jb.jobNo as 'JobNo',
tk.description as 'Description',
0 as 'Total Hours',
0 as 'Perdiem',
0 as 'Material',
0 as 'QTY Scaffold',
(select COUNT(sce1.EstNumber) from scfEstimation as sce1 where sce1.idAux = tk.idAux) as 'QTY Scaffolds Estimation'
from task as tk
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNO = wo.jobNo
inner join job as jb on jb.jobNo = po.jobNo
inner join clients as cl on cl.idClient = jb.idClient
where cl.numberClient = @numberCl
) as T1) as T2  " + If(all, "", "where (T2.[Total Hours] + T2.[Total Perdiem] + T2.[Total Material] + T2.[Total QTY Scaffold]  + T2.[Total QTY Scaffold Estimation] ) = 0 ") + If(jobNo = "", "", If(all, "where ", " and ") + " T2.[jobNo] = " + jobNo) + If(PO = "", "", " and T2.[idPO] = " + PO), conn)
            cmd.CommandTimeout = 250
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)
                tbl.DataSource = dt
                tbl.Columns(0).Visible = False
                tbl.Columns(1).Visible = False
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        End Try
    End Function


End Class