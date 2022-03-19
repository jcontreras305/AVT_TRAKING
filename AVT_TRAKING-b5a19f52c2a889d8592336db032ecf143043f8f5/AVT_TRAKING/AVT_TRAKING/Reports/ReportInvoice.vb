Imports System.Runtime.InteropServices
Public Class ReportInvoice
    Private Sub ReportInvoice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarComboClientsReports(cmbClient)
        If cmbClient.Text <> "" Then
            Dim array() As String = cmbClient.Text.ToString.Split(" ")
            llenarComoboPOByClient(cmbPO, array(0))
            cmbPO.Enabled = True
        Else
            cmbPO.Enabled = False
            chbAllPO.Checked = True
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
    Private Sub cmbClient_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClient.SelectedIndexChanged
        Try
            Dim array() As String = If(cmbClient.SelectedItem IsNot Nothing, cmbClient.SelectedItem.ToString().Split(" "), "")
            llenarComoboPOByClient(cmbPO, array(0))
            cmbPO.Enabled = True
            chbAllPO.Checked = False
        Catch ex As Exception
        End Try
    End Sub
    Private Sub chbAllPO_CheckedChanged(sender As Object, e As EventArgs) Handles chbAllPO.CheckedChanged
        If chbAllPO.Checked Then
            cmbPO.Enabled = False
        Else
            cmbPO.Enabled = True
        End If
        llenarTabla()
    End Sub
    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        Try
            If tblInvoiceCodes.Rows.Count > 0 And validarInvoice() Then
                Dim array() = cmbClient.SelectedItem.ToString().Split(" ")
                Dim idClient As String = array(0)
                If actualizarInvoicePO(tblInvoiceCodes, array(0), validaFechaParaSQl(dtpStartDate.Value.Date), validaFechaParaSQl(dtpEndDate.Value.Date)) Then
                    If idClient <> "" Or idClient IsNot Nothing Then
                        Dim reportInvoice As New POInvoice
                        reportInvoice.SetParameterValue("@numberClient", idClient)
                        reportInvoice.SetParameterValue("@startDate", validaFechaParaSQl(dtpStartDate.Value.Date))
                        reportInvoice.SetParameterValue("@FinalDate", validaFechaParaSQl(dtpEndDate.Value.Date))
                        reportInvoice.SetParameterValue("@idPO", If(cmbPO.SelectedItem IsNot Nothing, cmbPO.SelectedItem, "0"))
                        reportInvoice.SetParameterValue("@all", If(chbAllPO.Checked, 1, 0))
                        reportInvoice.SetParameterValue("@CompanyName", "Brock")
                        crvIvoice.ReportSource = reportInvoice
                    Else
                        MsgBox("Please select a Client.")
                    End If
                End If
            Else
                MessageBox.Show(If(tblInvoiceCodes.Rows.Count = 0, "Did not found any 'PO' to make an Invoice, try to change other 'PO' or range of Dates.", "Error,Exist a inconsistency in table Invoice, try to verify that the Invoices are not repeated."), "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub
    Private Sub cmbPO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPO.SelectedIndexChanged
        llenarTabla()
    End Sub
    Private Sub dtpEndDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpStartDate.ValueChanged, dtpEndDate.ValueChanged
        llenarTabla()
    End Sub
    Private Sub llenarTabla()
        Try
            If cmbClient.Text <> "" Then
                Dim array() As String = cmbClient.SelectedItem.ToString.Split(" ")
                llenarTableInvoicePO(array(0), validaFechaParaSQl(dtpStartDate.Value.Date), validaFechaParaSQl(dtpEndDate.Value.Date), cmbPO.Text, chbAllPO.Checked, tblInvoiceCodes)
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub
    Private Sub tblInvoiceCodes_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles tblInvoiceCodes.CellEndEdit
        Try
            If e.ColumnIndex = 1 Then
                If Not existInvoice(tblInvoiceCodes.Rows(e.RowIndex).Cells(0).Value.ToString(), tblInvoiceCodes.Rows(e.RowIndex).Cells(1).Value.ToString(), validaFechaParaSQl(dtpStartDate.Value.Date()), validaFechaParaSQl(dtpEndDate.Value.Date())) Then
                    MessageBox.Show("Please assign a different invoice, it was used with this PO.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSaveInvoiceNumbers_Click(sender As Object, e As EventArgs) Handles btnSaveInvoiceNumbers.Click
        If validarInvoice() Then
            guardarInvoicePO()
        End If
    End Sub
    Private Function validarInvoice() As Boolean
        Try
            Dim flag As Boolean = True
            For Each row As DataGridViewRow In tblInvoiceCodes.Rows
                If Not existInvoice(row.Cells(0).Value.ToString(), row.Cells(1).Value.ToString(), validaFechaParaSQl(dtpStartDate.Value.Date()), validaFechaParaSQl(dtpEndDate.Value.Date())) Then
                    flag = False
                    Exit For
                End If
            Next
            Return flag
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
End Class