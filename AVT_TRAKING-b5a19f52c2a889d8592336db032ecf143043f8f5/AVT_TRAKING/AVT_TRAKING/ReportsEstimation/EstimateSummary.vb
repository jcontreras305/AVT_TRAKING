Imports System.Runtime.InteropServices

Public Class EstimateSummary
    Public clientNum As String = ""
    Public Project As String = ""
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

    Private Sub EstimateSumary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarComboClientsEstReports(cmbClient)
        If clientNum <> "" Then
            llenarComboPOClientEst(cmbProject, clientNum)
            cmbClient.SelectedItem = cmbClient.Items(cmbClient.FindString(clientNum))
            If Project <> "" Then
                cmbProject.SelectedItem = cmbProject.Items(cmbProject.FindString(Project))
            End If
        End If
    End Sub
    Private Sub cmbClient_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClient.SelectedIndexChanged
        If clientNum IsNot Nothing Then
            Dim lastProject As String = cmbProject.Text
            llenarComboPOClientEst(cmbProject, clientNum)
            If cmbProject.FindString(lastProject) > -1 Then
                cmbProject.SelectedItem = cmbProject.Items(cmbProject.FindString(Project))
            Else
                Project = ""
                cmbProject.Text = ""
                cmbProject.SelectedItem = Nothing
            End If
        End If
    End Sub
    Private Sub cmbProject_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProject.SelectedIndexChanged
        Project = cmbProject.SelectedItem.ToString()
    End Sub

    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        Try
            If clientNum <> "" Or clientNum IsNot Nothing Then
                If Project <> "" Or Project IsNot Nothing Then
                    Dim reportTs As New EstSummary
                    reportTs.SetParameterValue("@projectId", Project)
                    reportTs.SetParameterValue("@CompanyName", "Brock")
                    crvReport.ReportSource = reportTs
                Else
                    MsgBox("Please select a Project.")
                End If
            Else
                MsgBox("Please select a Client.")
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try

    End Sub
End Class