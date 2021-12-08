Imports System.Runtime.InteropServices
Public Class ReportsMenu
    Private Sub btnTimeSheet_Click(sender As Object, e As EventArgs) Handles btnTimeSheet.Click
        Dim tse As New ReporteEmployees
        tse.ShowDialog()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.WindowState = FormWindowState.Minimized
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

    Private Sub btnActAverage_Click(sender As Object, e As EventArgs) Handles btnActAverage.Click
        Dim tse As New ReportActiveAverageE
        tse.ShowDialog()
    End Sub

    Private Sub btnClientBilling_Click(sender As Object, e As EventArgs) Handles btnClientBilling.Click
        Dim tse As New ReportClientBillingProject
        tse.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim tse As New ReportCatsEmployeePorject
        tse.ShowDialog()
    End Sub
End Class