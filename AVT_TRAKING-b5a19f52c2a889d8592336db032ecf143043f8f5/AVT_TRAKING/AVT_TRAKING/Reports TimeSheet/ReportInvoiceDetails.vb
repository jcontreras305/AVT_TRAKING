Imports System.Runtime.InteropServices
Public Class ReportInvoiceDetails
    Private Sub ReportInvoiceDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'llenarComboClientsReports(cmbClient)
        llenarComboClientByUser(cmbClient)
    End Sub
    Private Sub cmbClient_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClient.SelectedIndexChanged
        Try
            Dim clientNum As String() = cmbClient.SelectedItem.ToString.Split(" ")
            llenarComboPOByClient(cmbPO, clientNum(0))
        Catch ex As Exception

        End Try
    End Sub
    Private Sub chbAllPO_CheckedChanged(sender As Object, e As EventArgs) Handles chbAllPO.CheckedChanged
        If chbAllPO.Checked Then
            cmbPO.Enabled = False
        Else
            cmbPO.Enabled = True
        End If
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
            Dim idpo As String = cmbPO.SelectedItem()
            Dim clNum As String = array(0)
            If clNum <> "" Or clNum IsNot Nothing Then
                If idpo IsNot Nothing Or chbAllPO.Checked = True Then
                    Dim reportTs As New InvoiceProjectOrderDetails
                    reportTs.SetParameterValue("@numberClient", CInt(clNum))
                    reportTs.SetParameterValue("@startDate", validaFechaParaSQl(dtpStartDate.Value.Date))
                    reportTs.SetParameterValue("@FinalDate", validaFechaParaSQl(dtpEndDate.Value.Date))
                    reportTs.SetParameterValue("@idPO", If(chbAllPO.Checked, "0", idpo))
                    reportTs.SetParameterValue("@all", If(chbAllPO.Checked, "1", "0"))
                    reportTs.SetParameterValue("@CompanyName", "Brock")
                    If connecReport(reportTs) Then
                        crvIvoice.ReportSource = reportTs
                    End If
                Else
                    MsgBox("Please select a PO.")
                End If
            Else
                MsgBox("Please select a Client.")
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub
End Class