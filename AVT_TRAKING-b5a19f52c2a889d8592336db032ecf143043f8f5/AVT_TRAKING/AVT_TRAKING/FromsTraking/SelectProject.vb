Imports System.Runtime.InteropServices
Imports System.Data.SqlClient
Public Class SelectProject '
    Dim mtdQSP As New QuerySelectProject
    Dim tblP As DataTable
    Public clientName, ClientNum, jobNo, PO, idAux, idWO, ProjecNum, ProjectDescription As String
    Private Sub SelectProject_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chbAll_CheckedChanged(chbAll, New EventArgs)
        llenarComboClientsReports(cmbClients)
        If ProjectFind.idAux IsNot Nothing Then
            txtFilterForAll.Text = ProjectFind.Project
        End If
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnMaximize_Click(sender As Object, e As EventArgs) Handles btnMaximize.Click
        WindowState = FormWindowState.Maximized
        btnMaximize.Visible = False
        btnRestore.Visible = True
    End Sub

    Private Sub btnRestore_Click(sender As Object, e As EventArgs) Handles btnRestore.Click
        WindowState = FormWindowState.Normal
        btnRestore.Visible = False
        btnMaximize.Visible = True
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.Close()
    End Sub

    Private Sub chbAll_CheckedChanged(sender As Object, e As EventArgs) Handles chbAll.CheckedChanged
        If chbAll.Checked Then
            txtFilterForAll.Enabled = False
            cmbClients.Enabled = True
            cmbJobs.Enabled = True
            cmbProjects.Enabled = True
        Else
            txtFilterForAll.Enabled = True
            cmbClients.Enabled = False
            cmbJobs.Enabled = False
            cmbProjects.Enabled = False
        End If
    End Sub

    Private Sub btnSelectProject_Click(sender As Object, e As EventArgs) Handles btnSelectProject.Click
        If tblProject.SelectedRows.Count = 1 Then
            idAux = tblProject.SelectedRows(0).Cells("task").Value
            idWO = tblProject.SelectedRows(0).Cells("idAuxWO").Value
            ProjecNum = tblProject.SelectedRows(0).Cells("project").Value
            PO = tblProject.SelectedRows(0).Cells("idPO").Value
            jobNo = tblProject.SelectedRows(0).Cells("jobNo").Value
            clientName = tblProject.SelectedRows(0).Cells("companyName").Value
            ProjectDescription = tblProject.SelectedRows(0).Cells("description").Value
            ProjectFind.idAux = idAux
            ProjectFind.idAuxWO = idWO
            ProjectFind.Project = ProjecNum
            ProjectFind.PO = PO
            ProjectFind.JobNo = jobNo
            ProjectFind.clientName = clientName
            ProjectFind.ProjectDescription = ProjectDescription
            Me.Close()
        Else
            MsgBox("Please select only one Row.")
        End If
    End Sub

    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(hWnd As IntPtr, wMsg As Integer, wParam As Integer, lParam As Integer)
    End Sub

    Private Sub txtFilterForAll_TextChanged(sender As Object, e As EventArgs) Handles txtFilterForAll.TextChanged
        If txtFilterForAll.Text = "" Then
            mtdQSP.selectProject(tblProject, "'%'")
        Else
            If txtFilterForAll.Text.Contains("-") Then
                mtdQSP.selectProject(tblProject, "'" + txtFilterForAll.Text + "'")
            Else
                mtdQSP.selectProject(tblProject, txtFilterForAll.Text)
            End If
        End If
    End Sub

    Private Sub cmbClients_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClients.SelectedIndexChanged
        If cmbClients.SelectedIndex >= Nothing Then
            Dim array1() As String = Split(cmbClients.Items(cmbClients.SelectedIndex), " ")
            ClientNum = array1(0)
            Dim array2() As String = Split(array1(1), "|")
            clientName = array2(0)
            mtdQSP.selectProject(tblProject, "'" + clientName + "'")
            llenarComboJobsReports(cmbJobs, ClientNum)
            cmbJobs.Text = ""
            cmbProjects.Items.Clear()
            cmbProjects.Text = ""
        Else
            mtdQSP.selectProject(tblProject, "'%'")
        End If
    End Sub

    Private Sub cmbJobs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbJobs.SelectedIndexChanged
        If cmbJobs.SelectedIndex >= 0 Then
            mtdQSP.selectProject(tblProject, "'" + clientName + "'", cmbJobs.Items(cmbJobs.SelectedIndex).ToString)
            jobNo = cmbJobs.Items(cmbJobs.SelectedIndex).ToString()
            cmbProjects.Text = ""
            cmbProjects.Items.Clear()
            llenarComboPOByClient(cmbProjects, ClientNum, jobNo)
        Else
            mtdQSP.selectProject(tblProject, "'%'")
        End If
    End Sub

    Private Sub cmbProjects_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProjects.SelectedIndexChanged
        If cmbProjects.SelectedIndex >= 0 Then
            jobNo = cmbJobs.Items(cmbJobs.SelectedIndex).ToString()
            PO = cmbProjects.Items(cmbProjects.SelectedIndex).ToString()
            mtdQSP.selectProject(tblProject, "'" + clientName + "'", jobNo, PO)
        Else
            mtdQSP.selectProject(tblProject, "'%'")
        End If
    End Sub
End Class

Public Class QuerySelectProject
    Inherits ConnectioDB
    Public Function selectProject(ByVal tbl As DataGridView, Optional clientName As String = "", Optional jobNo As String = "", Optional po As String = "") As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select tk.idAux as 'task',cl.companyName, CONCAT(wo.idWO,'-',tk.task) as 'project' , tk.description, po.idPO, jb.jobNo, wo.idAuxWO,wo.idWO,tk.task from workOrder as wo 
inner join task as tk on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
inner join job as jb on jb.jobNo = po.jobNo
inner join clients as cl on cl.idClient = jb.idClient 
where
" + If(clientName <> "", "cl.companyName like CONCAT('%'," + clientName + ",'%') ", "") + If(jobNo <> "", If(clientName <> "", " and ", "") + "jb.jobNo  like CONCAT('%'," + jobNo + ",'%')", "") + If(po <> "", If(clientName <> "" And jobNo <> "", " and ", "") + "po.idPO like CONCAT('%'," + po + ",'%')", "") + "
order by cl.[companyName]", conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)
                tbl.DataSource = dt
                tbl.Columns(0).Visible = False
                tbl.Columns(6).Visible = False
                tbl.Columns(7).Visible = False
                tbl.Columns(8).Visible = False
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
            MsgBox(ex.Message)
        Finally
            desconectar()
        End Try
    End Function
    Public Function selectProject(ByVal tbl As DataGridView, Optional filter As String = "") As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select tk.idAux as 'task',cl.companyName, CONCAT(wo.idWO,'-',tk.task) as 'project' , tk.description, po.idPO, jb.jobNo, wo.idAuxWO,wo.idWO,tk.task from workOrder as wo 
inner join task as tk on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
inner join job as jb on jb.jobNo = po.jobNo
inner join clients as cl on cl.idClient = jb.idClient 
where
CONCAT(wo.idWO,'-',tk.task) like CONCAT('%'," + filter + ",'%') or 
po.idPO like CONCAT('%'," + filter + ",'%')  or 
jb.jobNo  like CONCAT('%'," + filter + ",'%') or
cl.companyName like CONCAT('%'," + filter + ",'%') 
order by cl.[companyName]", conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)
                tbl.DataSource = dt
                tbl.Columns(0).Visible = False
                tbl.Columns(6).Visible = False
                tbl.Columns(7).Visible = False
                tbl.Columns(8).Visible = False
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectar()
        End Try
    End Function

End Class