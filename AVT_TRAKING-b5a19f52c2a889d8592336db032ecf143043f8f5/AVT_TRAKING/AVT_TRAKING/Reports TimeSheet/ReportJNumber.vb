Imports System.Runtime.InteropServices
Imports System.Data.SqlClient

Public Class ReportJNumber
    Dim conection As New ConnectioDB
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.Close()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.WindowState = FormWindowState.Minimized
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim array() = cmbClients.SelectedItem.ToString().Split("    ")
        Dim idClient As String = array(0)
        If idClient <> "" Or idClient IsNot Nothing Then
            Dim reportTS As New ReportByJobNo
            reportTS.SetParameterValue("@startdate", validaFechaParaSQl(dtpInitialDate.Value.Date))
            reportTS.SetParameterValue("@finaldate", validaFechaParaSQl(dtpFinalDate.Value.Date))
            reportTS.SetParameterValue("@clientnum", idClient)
            reportTS.SetParameterValue("@job", If(cmbJob.SelectedItem IsNot Nothing, cmbJob.SelectedItem, 0))
            reportTS.SetParameterValue("@all", If(chbAllJobs.Checked, 1, 0))
            reportTS.SetParameterValue("@CompanyName", "brock")
            If connecReport(reportTS) Then
                crvByJobNumber.ReportSource = reportTS
            End If

        Else
            MsgBox("Please select a Client.")
        End If
    End Sub

    Private Sub ReportJNumber_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarComboClientsReports(cmbClients)
    End Sub

    Private Sub TitleBar_Paint(sender As Object, e As PaintEventArgs) Handles TitleBar.Paint

    End Sub

    Private Sub cmbClients_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClients.SelectedIndexChanged
        If cmbClients.SelectedItem IsNot Nothing Then
            Dim array() As String = cmbClients.SelectedItem.ToString.Split(" ")
            llenarComboJobsReports(cmbJob, array(0))
        End If
    End Sub

    Private Sub chbAllJobs_CheckedChanged(sender As Object, e As EventArgs) Handles chbAllJobs.CheckedChanged
        If chbAllJobs.Checked Then
            cmbJob.Enabled = False
        Else
            cmbJob.Enabled = True
        End If
    End Sub
End Class