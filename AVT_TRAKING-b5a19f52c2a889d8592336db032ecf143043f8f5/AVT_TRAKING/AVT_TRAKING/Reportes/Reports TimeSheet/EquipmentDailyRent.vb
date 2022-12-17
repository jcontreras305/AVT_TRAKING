Imports System.Runtime.InteropServices
Public Class DailyEquipmentRent
    Private Sub EquipmentDailyRent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarComboClientsReports(cmbClient)
    End Sub
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
    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        Try
            Dim array() As String
            array = cmbClient.SelectedItem.ToString().Split(" ")
            Dim clNum As String = array(0)
            If clNum <> "" Or clNum IsNot Nothing Then
                Dim reportTs As New EquipmentDailyTimeSheet
                reportTs.SetParameterValue("@startDate", validaFechaParaSQl(dtpStartDate.Value.Date))
                reportTs.SetParameterValue("@FinalDate", validaFechaParaSQl(dtpFinalDate.Value.Date))
                reportTs.SetParameterValue("@numberClient", CInt(clNum))
                reportTs.SetParameterValue("@CompanyName", "Brock")
                crvReport.ReportSource = reportTs
            Else
                MsgBox("Please select a Client.")
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try

    End Sub
End Class