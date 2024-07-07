Imports System.Runtime.InteropServices
Public Class JobNoPipingBudget
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
    Public ProjectId As String = ""
    Public ClientNum As String = ""
    Dim mtdEstimate As New MetodosEstimating
    Private Sub JobNoPipingBudget_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarComboPOClientEst(cmbProject, ClientNum)
        cmbProject.SelectedItem = cmbProject.Items(cmbProject.FindString(ProjectId))
        If ProjectId <> "" Then
            mtdEstimate.updateCostEstPiping(ProjectId)
            cargarReporte(ProjectId)
        End If
    End Sub
    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        If ProjectId <> "" Then
            mtdEstimate.updateCostEstPiping(ProjectId)
            cargarReporte(ProjectId)
        Else
            MessageBox.Show("Please select a Project.", "Impotant", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub
    Private Function cargarReporte(ByVal projectId As String) As Boolean
        Try
            If projectId <> "" Or projectId IsNot Nothing Then
                Dim reportTs As New JobNoPipingBudgetReport
                reportTs.SetParameterValue("@projectId", projectId)
                reportTs.SetParameterValue("@CompanyName", "Brock")
                If connecReport(reportTs) Then
                    crvReport.ReportSource = reportTs
                End If
            Else
                MessageBox.Show("Please select a Project.", "Impotant", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If
            Return True
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        End Try
    End Function

    Private Sub cmbProject_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProject.SelectedIndexChanged
        ProjectId = cmbProject.SelectedItem.ToString()
    End Sub
End Class