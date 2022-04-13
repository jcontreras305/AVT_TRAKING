Imports System.Runtime.InteropServices
Imports Microsoft.Office.Core
Imports Microsoft.Office.Interop.Excel
Public Class ScaffoldRentalDatails
    Dim mtdOther As New MetodosOthers
    Dim windowStart As String = "SCFRentalDetails"
    Dim reportTs As New SCFRentalDetails
    Dim mtdSc As New MetodosScaffold
    Private Sub ScaffoldRentalDatails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarComboClientsReports(cmbClient)
        btnSend.Enabled = False
        mtdOther.llenarTablaEmailReports(tblEmailsReports, "SCFRentalDetails")
        Dim list() = mtdOther.selectSubjectEmail(windowStart)
        txtSubject.Text = list(0)
        txtBodyEmail.Text = list(1)
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
                reportTs.SetParameterValue("@startDate", validaFechaParaSQl(dtpStartDate.Value.Date))
                reportTs.SetParameterValue("@FinalDate", validaFechaParaSQl(dtpFinalDate.Value.Date))
                reportTs.SetParameterValue("@numberClient", CInt(clNum))
                reportTs.SetParameterValue("@CompanyName", "Brock")
                crvReport.ReportSource = reportTs
                btnSend.Enabled = True
            Else
                MsgBox("Please select a Client.")
                btnSend.Enabled = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            btnSend.Enabled = False
        End Try
    End Sub
    Private Sub tbnAddEmailList_Click(sender As Object, e As EventArgs) Handles tbnAddEmailList.Click
        Try
            If mtdOther.saveUpdateEmailReport(tblEmailsReports, windowStart, True) Then
                mtdOther.llenarTablaEmailReports(tblEmailsReports, windowStart)
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub
    Private Sub btnDropEmailList_Click(sender As Object, e As EventArgs) Handles btnDropEmailList.Click
        Try
            If mtdOther.saveUpdateEmailReport(tblEmailsReports, windowStart, False) Then
                mtdOther.llenarTablaEmailReports(tblEmailsReports, windowStart)
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub
    Private Sub btnSubjectEmail_Click(sender As Object, e As EventArgs) Handles btnSubjectEmail.Click
        Try
            If mtdOther.saveUpdateSubjet(windowStart, txtSubject.Text, txtBodyEmail.Text) Then
                MsgBox("Successful")
            Else
                MsgBox("Error")
                Dim datosEmail = mtdOther.selectSubjectEmail(windowStart)
                txtSubject.Text = datosEmail(0)
                txtBodyEmail.Text = datosEmail(1)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        Try
            Dim ownEmail As String() = mtdOther.selectOwnEmail()
            If ownEmail(0) <> "" Then
                Dim listEmail As New List(Of String)
                For Each row As DataGridViewRow In tblEmailsReports.Rows()
                    If row.Cells(2).Value Then
                        listEmail.Add(row.Cells(0).Value)
                    End If
                Next
                If listEmail.Count > 0 Then
                    Dim reportName As String = "ScaffolRentalDetails" & dtpStartDate.Text.Replace("/", "-") & "TO" & dtpFinalDate.Text.Replace("/", "-") & ".pdf"
                    Dim dar As DialogResult = MessageBox.Show("Would you like to save this report?", "Important", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                    If dar = DialogResult.Yes Then
                        Dim sd As New SaveFileDialog
                        sd.DefaultExt = ".pdf"
                        sd.FileName = reportName
                        If DialogResult.OK = sd.ShowDialog() Then
                            reportTs.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, sd.FileName)
                        End If
                        mtdOther.sendEmail(ownEmail(0), ownEmail(1), txtSubject.Text, txtBodyEmail.Text, listEmail, sd.FileName)
                    ElseIf dar = DialogResult.No Then
                        reportTs.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, "c:\TMP\" + reportName)
                        mtdOther.sendEmail(ownEmail(0), ownEmail(1), txtSubject.Text, txtBodyEmail.Text, listEmail, "c:\TMP\" + reportName)
                        System.IO.File.Delete("c:\TMP\" + reportName)
                    End If
                Else
                    MessageBox.Show("Please, assign the emails to send the Report.")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnDownloadExcel_Click(sender As Object, e As EventArgs) Handles btnDownloadExcel.Click
        Try
            Dim flagOpen As Boolean = False
            If cmbClient.SelectedItem IsNot Nothing Then
                Dim array() As String = cmbClient.SelectedItem.ToString().Split(" ")
                mtdSc.actualizarInvoiceExcel(validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpFinalDate.Value), array(0))
                Cursor = Cursors.WaitCursor
                Dim opFile As New OpenFileDialog
                opFile.DefaultExt = "xlsx|xls"
                opFile.FileName = "InvoicePieces"
                If DialogResult.OK = opFile.ShowDialog() Then
                    Cursor = Cursors.WaitCursor
                    Dim ApExcel = New Microsoft.Office.Interop.Excel.Application

                    Dim libro = ApExcel.Workbooks.Open(opFile.FileName)
                    Try
                        Dim Hoja1 As New Worksheet
                        Dim Hoja2 As New Worksheet
                        Dim sheetNumber1 As Integer = 1
                        Dim flagExist1 As Boolean = False
                        For Each sheet As Worksheet In libro.Worksheets
                            If sheet.Name = "Pieces" Then
                                flagExist1 = True
                                Exit For
                            End If
                            sheetNumber1 += 1
                        Next
                        Dim sheetNumber2 As Integer = 1
                        Dim flagExist2 As Boolean = False
                        For Each sheet As Worksheet In libro.Worksheets
                            If sheet.Name = "SRLs" Then
                                flagExist2 = True
                                Exit For
                            End If
                            sheetNumber2 += 1
                        Next

                        If flagExist1 Then
                            Hoja1 = libro.Worksheets("Pieces")
                            Hoja1.Cells(1, 10) = validaFechaParaSQl(dtpStartDate.Value)
                            Hoja1.Cells(2, 10) = validaFechaParaSQl(dtpFinalDate.Value)
                            Dim nameClient() As String = array(1).Split("|")
                            Hoja1.Cells(4, 11) = "CALCULATED COLUMNS FOR " + nameClient(0) + " REVIEW"
                        Else
                            MessageBox.Show("Sheet Pieces Not Found." + vbCrLf + "The Data was Updated but the excel could not be overwritten.", "Important")
                        End If

                        If flagExist2 Then
                            Hoja2 = libro.Worksheets("SRLs")
                            Hoja2.Cells(1, 10) = validaFechaParaSQl(dtpStartDate.Value)
                            Hoja2.Cells(2, 10) = validaFechaParaSQl(dtpFinalDate.Value)
                        Else
                            MessageBox.Show("Sheet SRLs Not Found." + vbCrLf + "The Data was Updated but the excel could not be overwritten.", "Important")
                        End If
                        libro.Save()
                        If DialogResult.Yes = MessageBox.Show("Successful" + vbCrLf + "Would you like to open the excel?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                            flagOpen = True
                        End If
                        NAR(Hoja1)
                        NAR(Hoja2)
                        'Hoja1 = Nothing
                    Catch ex As Exception
                        MessageBox.Show("Sheet Pieces Not Found." + vbCrLf + "The Data was Updated but the excel could not be overwritten.", "Important")
                    Finally
                        libro.Close()
                        NAR(libro)
                        'libro = Nothing
                        ApExcel.Quit()
                        NAR(ApExcel)
                        'ApExcel = Nothing
                        If flagOpen Then
                            System.Diagnostics.Process.Start(opFile.FileName)
                        End If
                    End Try
                End If
                Cursor = Cursors.Default
            Else
                MessageBox.Show("Please select a Client.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class