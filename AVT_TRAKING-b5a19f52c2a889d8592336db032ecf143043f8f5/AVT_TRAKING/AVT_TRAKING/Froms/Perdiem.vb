Imports Microsoft.Office.Core
Imports Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices
Public Class Perdiem
    Dim mtdHPW As New MetodosHoursPeerWeek
    Private Sub Perdiem_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub dtpStartDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpStartDate.ValueChanged
        Try
            Dim fecha As Date = dtpStartDate.Value
            Select Case dtpStartDate.Value.DayOfWeek
                Case DayOfWeek.Tuesday
                    dtpStartDate.Value = dtpStartDate.Value.AddDays(-1)
                Case DayOfWeek.Wednesday
                    dtpStartDate.Value = dtpStartDate.Value.AddDays(-2)
                Case DayOfWeek.Thursday
                    dtpStartDate.Value = dtpStartDate.Value.AddDays(-3)
                Case DayOfWeek.Friday
                    dtpStartDate.Value = dtpStartDate.Value.AddDays(-4)
                Case DayOfWeek.Saturday
                    dtpStartDate.Value = dtpStartDate.Value.AddDays(-5)
                Case DayOfWeek.Sunday
                    dtpStartDate.Value = dtpStartDate.Value.AddDays(-6)
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnRefreshPerdiem_Click(sender As Object, e As EventArgs) Handles btnRefreshPerdiem.Click
        Try
            mtdHPW.selectPerdiem(tblPerDiem, dtpStartDate.Value)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnFindExcel_Click(sender As Object, e As EventArgs) Handles btnFindExcel.Click
        Try
            Dim openFile As New OpenFileDialog
            openFile.DefaultExt = "*.xlsm"
            openFile.FileName = "MASTER Per-Diem"
            openFile.ShowDialog()
            txtSalida.Text = "Message:" + "Open file " + openFile.FileName
            If DialogResult.OK = MessageBox.Show("Please verify that the Sheets name are 'Time Sheet Data', 'EMP MASTER DATA' and the Weekendings has been inserted, if not do the changues.", "Important", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) Then
                Dim ApExcel = New Microsoft.Office.Interop.Excel.Application
                Dim libro = ApExcel.Workbooks.Open(openFile.FileName)
                Dim flag As Boolean = False
                Dim case1 As Integer = 0
                For i = 1 To libro.Worksheets.Count
                    If libro.Worksheets(i).Name = "Time Sheet Data" Then
                        flag = True
                        case1 = 1
                        Exit For
                    ElseIf libro.Worksheets(i).Name = "TimeSheetData" Then
                        flag = True
                        case1 = 2
                        Exit For
                    End If
                Next
                Dim sheetPD As New Worksheet
                If flag = True Then
                    If case1 = 1 Then
                        sheetPD = libro.Worksheets("Time Sheet Data")
                        txtSalida.Text = "Message:" + "Open sheet 'Time Sheet Data'."
                    Else
                        sheetPD = libro.Worksheets("TimeSheetData")
                        txtSalida.Text = "Message:" + "Open sheet 'TimeSheetData'."
                    End If
                    limpiarSheet(sheetPD, sprExcelRow.Value)
                    Dim cont As Integer = 2
                    For Each row As DataGridViewRow In tblPerDiem.Rows()
                        sheetPD.Cells(cont, 1) = row.Cells("StatusCode").Value
                        sheetPD.Cells(cont, 2) = row.Cells("Company").Value
                        sheetPD.Cells(cont, 6) = row.Cells("EmployeeNumber").Value
                        sheetPD.Cells(cont, 7) = row.Cells("WeekNumber").Value
                        sheetPD.Cells(cont, 8) = row.Cells("JobNumber").Value
                        sheetPD.Cells(cont, 9) = row.Cells("SubJobNumber").Value
                        sheetPD.Cells(cont, 10) = row.Cells("CostDistribution").Value
                        sheetPD.Cells(cont, 11) = row.Cells("CostType").Value
                        sheetPD.Cells(cont, 13) = row.Cells("DayOfWeek1").Value
                        sheetPD.Cells(cont, 18) = row.Cells("RegularHours").Value
                        sheetPD.Cells(cont, 19) = row.Cells("OvertimeHours").Value
                        sheetPD.Cells(cont, 20) = row.Cells("OtherHours").Value
                        sheetPD.Cells(cont, 21) = row.Cells("OtherHoursType").Value
                        sheetPD.Cells(cont, 25) = row.Cells("AdjustmentType").Value
                        sheetPD.Cells(cont, 26) = row.Cells("AdjustmentAmount").Value
                        sheetPD.Cells(cont, 27) = row.Cells("DeductionNumber").Value
                        sheetPD.Cells(cont, 33) = row.Cells("BatchNumber").Value
                        sheetPD.Cells(cont, 35) = row.Cells("CheckType").Value
                        cont += 1
                        txtSalida.Text = "Message:" + "Inserting row " + CStr(cont)
                    Next
                Else
                    MessageBox.Show("The sheet 'Time Sheet Data' is not found.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If

                For i = 1 To libro.Worksheets.Count
                    If libro.Worksheets(i).Name = "EMP MASTER DATA" Then
                        flag = True
                        case1 = 1
                        Exit For
                    ElseIf libro.Worksheets(i).Name = "EMP-MASTER-DATA" Then
                        flag = True
                        case1 = 2
                        Exit For
                    End If
                Next
                Dim sheetEmp As New Worksheet
                If flag = True Then
                    If case1 = 1 Then
                        sheetEmp = libro.Worksheets("EMP MASTER DATA")
                        txtSalida.Text = "Message:" + "Open sheet 'EMP MASTER DATA'."
                    Else
                        sheetEmp = libro.Worksheets("EMP-MASTER-DATA")
                        txtSalida.Text = "Message:" + "Open sheet 'EMP-MASTER-DATA'."
                    End If
                    limpiarSheet(sheetEmp, 2)
                    Dim mtdEmployees As New MetodosEmployees
                    Dim tblEmp = mtdEmployees.selectActiveEmployees()
                    Dim cont As Integer = 2
                    For Each row As DataRow In tblEmp.Rows()
                        sheetEmp.Cells(cont, 1) = row.Item(0)
                        sheetEmp.Cells(cont, 2) = row.Item(1)
                        sheetEmp.Cells(cont, 3) = row.Item(2)
                        cont += 1
                        txtSalida.Text = "Message:" + "Inserting row " + CStr(cont)
                    Next
                Else
                    MessageBox.Show("The sheet 'EMP MASTER DATA' is not found.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If

                txtSalida.Text = "Saving file."
                libro.Save()
                NAR(sheetPD)
                NAR(sheetEmp)
                libro.Close(True)
                NAR(libro)
                NAR(ApExcel.Workbooks)
                ApExcel.Quit()
                NAR(ApExcel)
                txtSalida.Text = "Message:" + "Sleeping..."
                txtSalida.Text = "Message:" + "End Excel."
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.Close()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
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

End Class