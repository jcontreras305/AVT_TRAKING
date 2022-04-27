Imports System.Runtime.InteropServices
Imports Microsoft.Office.Core
Imports Microsoft.Office.Interop.Excel
Public Class ScaffoldActive
    Dim mtd As New MetodosScaffold
    Private Sub ScaffoldActive_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarComboClientsReports(cmbClients)
    End Sub
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.Close()
    End Sub
    Private Sub btnMinimize_Click(sender As Object, e As EventArgs) Handles btnMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub btnRestore_Click(sender As Object, e As EventArgs) Handles btnRestore.Click
        WindowState = FormWindowState.Normal
        btnMinimize.Visible = False
        btnMaximize.Visible = True
    End Sub
    Private Sub btnMaximize_Click(sender As Object, e As EventArgs) Handles btnMaximize.Click
        MaximizedBounds = Screen.FromHandle(Me.Handle).WorkingArea
        WindowState = FormWindowState.Maximized
        btnMaximize.Visible = False
        btnMinimize.Visible = True
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
            If cmbClients.SelectedItem IsNot Nothing Then
                Dim array() As String
                array = cmbClients.SelectedItem.ToString().Split(" ")
                Dim clNum As String = array(0)
                If clNum <> "" Or clNum IsNot Nothing Then
                    Dim reportTs As New SCFActive
                    reportTs.SetParameterValue("@numberClient", CInt(clNum))
                    reportTs.SetParameterValue("@CompanyName", "Brock")
                    crvReport.ReportSource = reportTs
                    mtd.llenarTablaActiveScaffold(tblScaffoldActive, clNum)
                Else
                    MsgBox("Please select a Client.")
                End If
            Else
                MsgBox("Please select a Client.")
            End If

        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Private Sub btnDownloadExcel_Click(sender As Object, e As EventArgs) Handles btnDownloadExcel.Click
        Try
            Dim flagOpen As Boolean = False
            Dim ruta As String = ""
            If tblScaffoldActive.Rows IsNot Nothing Then
                lblMessage.Text = "Message: " + "Meking a new Excel..."
                Cursor = Cursors.WaitCursor
                Dim ApExcel = New Microsoft.Office.Interop.Excel.Application
                Dim libro = ApExcel.Workbooks.Add()

                Try
                    lblMessage.Text = "Message: " + "Meaking a new Sheet..."
                    Dim Hoja1 = libro.Worksheets(1)
                    Dim count As Integer = 1
                    With Hoja1.Range("A1:H1")
                        .Font.Bold = True
                        .Font.ColorIndex = 1
                        With .Interior
                            .ColorIndex = 15
                        End With
                        .BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Color.Black)
                    End With
                    lblMessage.Text = "Message: " + "Writing data..."
                    For Each colm As DataGridViewColumn In tblScaffoldActive.Columns
                        Hoja1.Cells(count, (colm.Index + 1)) = colm.HeaderText.ToString()
                        lblMessage.Text = "Message: Row (" + CStr(count) + ")"
                    Next
                    count += 1
                    For Each row As DataGridViewRow In tblScaffoldActive.Rows
                        Hoja1.Cells(count, 1) = row.Cells("LaborWoNetwork").Value.ToString()
                        Hoja1.Cells(count, 2) = row.Cells("Type").Value.ToString()
                        Hoja1.Cells(count, 3) = row.Cells("Tag").Value.ToString()
                        Hoja1.Cells(count, 4) = row.Cells("Pieces").Value.ToString()
                        Hoja1.Cells(count, 5) = row.Cells("Unit").Value.ToString()
                        Hoja1.Cells(count, 6) = row.Cells("Location").Value.ToString()
                        Hoja1.Cells(count, 7) = row.Cells("DateUp").Value.ToString()
                        Hoja1.Cells(count, 8) = row.Cells("ACTIVEDAYS").Value.ToString()
                        count += 1
                        lblMessage.Text = "Message: Row (" + CStr(count) + ")"
                    Next
                    Hoja1.Name = "Active Scaffold"
                    lblMessage.Text = "Message: " + "Saving process..."
                    Dim opFile As New SaveFileDialog
                    opFile.DefaultExt = "xlsx"
                    opFile.FileName = "Active Scaffolds"
                    If DialogResult.OK = opFile.ShowDialog() Then
                        ruta = opFile.FileName
                        libro.SaveAs(opFile.FileName)
                        MsgBox("Successful")
                        NAR(Hoja1)
                        If DialogResult.Yes = MessageBox.Show("Successful" + vbCrLf + "Would you like to open the excel?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                            flagOpen = True
                        End If
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message())
                Finally
                    libro.Close()
                    NAR(libro)
                    ApExcel.Quit()
                    NAR(ApExcel)
                    If flagOpen Then
                        System.Diagnostics.Process.Start(ruta)
                    End If
                End Try
                Cursor = Cursors.Default
            Else
                MessageBox.Show("Please select a Client.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
        lblMessage.Text = "Message: End."
    End Sub
End Class