Imports System.Runtime.InteropServices
Public Class MaterialDetails
    Dim idClient As String = ""
    Dim jobNo As String = ""
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.Close()
    End Sub
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
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(hWnd As IntPtr, wMsg As Integer, wParam As Integer, lParam As Integer)
    End Sub

    Private Sub TitleBar_MouseMove(sender As Object, e As MouseEventArgs) Handles TitleBar.MouseMove
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub
    Private Sub MaterialDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarComboClientsReports(cmbClients)
    End Sub

    Private Sub cmbClients_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClients.SelectedIndexChanged
        If cmbClients.SelectedItem <> Nothing Then
            Dim array() As String = cmbClients.SelectedItem.ToString.Split(" ")
            If array.Length > 0 Then
                llenarComboJobsReports(cmbJob, array(0))
                idClient = array(0)
            End If
        End If
    End Sub

    Private Sub chbAllJobs_CheckedChanged(sender As Object, e As EventArgs) Handles chbAllJobs.CheckedChanged
        If chbAllJobs.Checked Then
            cmbJob.Enabled = False
            jobNo = "0"
        Else
            cmbJob.Enabled = True
            jobNo = cmbJob.SelectedItem.ToString()
        End If
    End Sub
    Private Sub cmbJob_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbJob.SelectedIndexChanged
        If cmbJob.SelectedItem IsNot Nothing Then
            Dim array() As String = cmbJob.SelectedItem.ToString.Split("")
            If array.Length > 0 Then
                jobNo = array(0)
            Else
                jobNo = "0"
            End If
        End If
    End Sub
    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        If idClient <> "" Or idClient IsNot Nothing Then
            Dim reportTS As New MaterialReportByPO
            reportTS.SetParameterValue("@StartDate", validaFechaParaSQl(dtpInitialDate.Value.Date))
            reportTS.SetParameterValue("@EndDate", validaFechaParaSQl(dtpFinalDate.Value.Date))
            reportTS.SetParameterValue("@numberClient", idClient)
            reportTS.SetParameterValue("@job", If(cmbJob.SelectedItem IsNot Nothing, cmbJob.SelectedItem, 0))
            reportTS.SetParameterValue("@all", If(chbAllJobs.Checked, 1, 0))
            reportTS.SetParameterValue("@CompanyName", "brock")
            crvMaterialReportByPO.ReportSource = reportTS
        Else
            MsgBox("Please select a Client.")
        End If
    End Sub


End Class