Imports System.Runtime.InteropServices
Imports CrystalDecisions.ReportAppServer
Public Class ReportAllJob
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

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If cmbClients.SelectedItem IsNot Nothing Then
            Dim array() As String = cmbClients.SelectedItem.ToString.Split(" ")
            Dim idclient As String = array(0)
            Dim reportTS As New AllJobs
            reportTS.SetParameterValue("@startdate", validaFechaParaSQl(dtpInitialDate.Value.Date))
            reportTS.SetParameterValue("@finaldate", validaFechaParaSQl(dtpFinalDate.Value.Date))
            reportTS.SetParameterValue("@clientnum", idclient)
            reportTS.SetParameterValue("@CompanyName", "brock")
            reportTS.SetParameterValue("@excludeIdpo", If(chbExclude.Checked, 1, 0))
            reportTS.SetParameterValue("@exclude", If(chbExclude.Checked, txtPOExclude.Text, "0"))
            reportTS.SetDatabaseLogon(UserDB, Pass, ServerName, DBName)
            crvAllJobs.ReportSource = reportTS
        Else
            MsgBox("Please select a Client.")
        End If
    End Sub

    Private Sub ReportAllJob_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarComboClientsReports(cmbClients)
        txtPOExclude.Enabled = False
    End Sub

    Private Sub chbExclude_CheckedChanged(sender As Object, e As EventArgs) Handles chbExclude.CheckedChanged
        If chbExclude.Checked Then
            txtPOExclude.Enabled = True
        Else
            txtPOExclude.Enabled = False
        End If
    End Sub
End Class