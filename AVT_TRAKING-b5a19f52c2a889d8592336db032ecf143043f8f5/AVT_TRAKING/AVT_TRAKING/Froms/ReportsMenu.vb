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
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim tse As New ReportClientBillingsReCapBYProject
        tse.ShowDialog()
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim tse As New ReportCompleteByDateRange
        tse.ShowDialog()
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim tse As New ReportEmployeePerDiem
        tse.ShowDialog()
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim tse As New ReportEmployeesTime
        tse.ShowDialog()
    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim tse As New ReportJNumber
        tse.ShowDialog()
    End Sub
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim tse As New ReportAllJob
        tse.ShowDialog()
    End Sub
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim tse As New ReportHoursPerWeek
        tse.ShowDialog()
    End Sub
    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim tse As New ReportYearFinalHours
        tse.ShowDialog()
    End Sub
    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Dim tse As New ReportWONotComplete
        tse.ShowDialog()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim tse As New ReportTimeSheetsPO
        tse.ShowDialog()
    End Sub
    Private Sub btnVacationE_Click(sender As Object, e As EventArgs) Handles btnVacationE.Click
        Dim tse As New ReportVacationEmployee
        tse.ShowDialog()
    End Sub
    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Dim tse As New ReportInvoice
        tse.ShowDialog()
    End Sub
    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        Dim tse As New ReportInvoiceDetails
        tse.ShowDialog()
    End Sub
    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        Dim tse As New ScaffoldHistoryByJobNo
        tse.ShowDialog()
    End Sub
    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        Dim tse As New ScaffoldHistoryByJobAndWO
        tse.ShowDialog()
    End Sub
    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        Dim tse As New ScaffoldHistoryByJobAndUnit
        tse.ShowDialog()
    End Sub
    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Dim tse As New ScaffoldHistoryDismantled
        tse.ShowDialog()
    End Sub
    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Dim tse As New ScaffoldHisoryByJob
        tse.ShowDialog()
    End Sub
    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        Dim tse As New ScaffoldRentalDatails
        tse.ShowDialog()
    End Sub
End Class