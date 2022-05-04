Imports Microsoft.Office.Core
Imports Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices
Public Class PayRoll
    Dim mtdHPW As New MetodosHoursPeerWeek
    Private Sub PayRoll_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mtdHPW.selectWeeks(tblWeeks)
        sprRowStartNBL.Enabled = False
        sprRowStartTSD.Enabled = True
    End Sub
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.Close()
    End Sub
    Private Sub btnAddWeek_Click(sender As Object, e As EventArgs) Handles btnAddWeek.Click
        Try
            If mtdHPW.insertWeek(dtpWeek.Value, sprNumWeek.Value) Then
                MsgBox("Succesfull")
            Else
                MsgBox("Error")
            End If
            mtdHPW.selectWeeks(tblWeeks)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnUpdateWeek_Click(sender As Object, e As EventArgs) Handles btnUpdateWeek.Click
        Try
            If btnUpdateWeek.Text = "Update" Then
                btnUpdateWeek.Text = "Save"
                dtpWeek.Value = validarFechaParaVB(tblWeeks.CurrentRow.Cells("Weekend").Value)
                sprNumWeek.Value = CInt(tblWeeks.CurrentRow.Cells("WeekNum").Value)
            ElseIf btnUpdateWeek.Text = "Save" Then
                If mtdHPW.updateWeek(validarFechaParaVB(tblWeeks.CurrentRow.Cells("Weekend").Value), dtpWeek.Value, sprNumWeek.Value) Then
                    btnUpdateWeek.Text = "Update"
                    mtdHPW.selectWeeks(tblWeeks)
                    MsgBox("Successful")
                Else
                    MsgBox("Error")
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnDeleteWeek_Click(sender As Object, e As EventArgs) Handles btnDeleteWeek.Click
        Try
            If DialogResult.Yes = MessageBox.Show("Are you sure to Delete this date " + tblWeeks.CurrentRow.Cells("Weekend").Value + "?", "Important.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                If mtdHPW.deleteWeek(validarFechaParaVB(tblWeeks.CurrentRow.Cells("Weekend").Value)) Then
                    mtdHPW.selectWeeks(tblWeeks)
                    MsgBox("Successful")
                Else
                    MsgBox("Error")
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub dtpWeek_ValueChanged(sender As Object, e As EventArgs) Handles dtpWeek.ValueChanged
        Try
            Dim date1 = dtpWeek.Value
            Select Case dtpWeek.Value.DayOfWeek
                Case DayOfWeek.Monday
                    dtpWeek.Value = dtpWeek.Value.AddDays(6)
                Case DayOfWeek.Tuesday
                    dtpWeek.Value = dtpWeek.Value.AddDays(5)
                Case DayOfWeek.Wednesday
                    dtpWeek.Value = dtpWeek.Value.AddDays(4)
                Case DayOfWeek.Thursday
                    dtpWeek.Value = dtpWeek.Value.AddDays(3)
                Case DayOfWeek.Friday
                    dtpWeek.Value = dtpWeek.Value.AddDays(2)
                Case DayOfWeek.Saturday
                    dtpWeek.Value = dtpWeek.Value.AddDays(1)
            End Select
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnFindExcelWeeks_Click(sender As Object, e As EventArgs) Handles btnFindExcelWeeks.Click
        Try
            Dim openFile As New OpenFileDialog
            openFile.DefaultExt = "*.xlsm"
            openFile.FileName = "weeks"
            If DialogResult.OK = MessageBox.Show("Please verify that the Excel contain a Sheet with the nane 'weeks' or 'Sheet1' and the excel is not open.", "Important", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) Then
                openFile.ShowDialog()
                Dim ApExcel = New Microsoft.Office.Interop.Excel.Application
                Dim libro = ApExcel.Workbooks.Open(openFile.FileName)
                txtMsgWk.Text = "Message:" + "Open Fiel" + openFile.FileName
                Dim flag As Boolean = False
                Dim case1 As Integer = 0
                For i = 1 To libro.Worksheets.Count
                    If libro.Worksheets(i).Name = "weeks" Then
                        flag = True
                        case1 = 1
                        Exit For
                    ElseIf libro.Worksheets(i).Name = "Sheet1" Then
                        flag = True
                        case1 = 2
                        Exit For
                    End If
                Next
                Dim weeks As New Worksheet
                If flag And case1 = 1 Then
                    weeks = libro.Worksheets("weeks")
                    txtMsgWk.Text = "Message:" + "Open Sheet weeks"
                ElseIf flag And case1 = 2 Then
                    weeks = libro.Worksheets("Sheet1")
                    txtMsgWk.Text = "Message:" + "Open Sheet Sheet1"
                End If

                If flag Then
                    Dim tblwks As New Data.DataTable
                    tblwks.Columns.Add("wk")
                    tblwks.Columns.Add("wknm")
                    Dim contwo As Integer = 2
                    Dim filasError As String = ""
                    txtMsgWk.Text = "Message:" + "Reading information..."
                    While weeks.Cells(contwo, 2).Text <> ""
                        Dim week = weeks.Cells(contwo, 1).Text.ToString()
                        Dim weeknum = CInt(weeks.Cells(contwo, 2).Text.ToString())
                        tblwks.Rows.Add(week, weeknum)
                        contwo += 1
                    End While
                    Dim listerrors As New List(Of String)
                    Dim cont = 1
                    For Each row As Data.DataRow In tblwks.Rows

                        txtMsgWk.Text = "Message:" + "Inserting row " + CStr(cont + 1) + "."
                        If mtdHPW.insertWeek(CDate(row.ItemArray(0)), CInt(row.ItemArray(1))) = False Then
                            listerrors.Add(row.ItemArray(0) + "-" + row.ItemArray(1))
                        End If
                        cont += 1
                    Next
                    If listerrors.Count > 0 Then
                        txtMsgWk.Text = "Message:" + "Exist " + CStr(listerrors.Count) + " error"
                        Dim erros As String = ""
                        For i = 1 To listerrors.Count
                            erros = If(erros = "", listerrors.Item(i), If(i = listerrors.Count, erros + "," + listerrors.Item(i) + ".", erros + "," + listerrors.Item(i)))
                        Next
                        MessageBox.Show("They can not be inserted: " + erros, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        txtMsgWk.Text = "Message:" + "End."
                        MsgBox("Successful")
                    End If
                    mtdHPW.selectWeeks(tblWeeks)
                    NAR(weeks)
                    libro.Close(True)
                    NAR(libro)
                    NAR(ApExcel.Workbooks)
                    ApExcel.Quit()
                    NAR(ApExcel)
                Else
                    MessageBox.Show("Sheet 'weeks' or 'Sheet1' does not exit.")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub
    Private Sub TabControl2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl2.SelectedIndexChanged
        If TabControl2.SelectedTab.Text = "Time Sheet Data" Then
            sprRowStartNBL.Enabled = False
            sprRowStartTSD.Enabled = True
        ElseIf TabControl2.SelectedTab.Text = "NON-BILLABLE" Then
            sprRowStartNBL.Enabled = True
            sprRowStartTSD.Enabled = False
        End If
    End Sub

    Private Sub dtpStartTime_ValueChanged(sender As Object, e As EventArgs) Handles dtpStartTime.ValueChanged
        Try
            Dim date1 = dtpStartTime.Value
            Select Case dtpStartTime.Value.DayOfWeek
                Case DayOfWeek.Tuesday
                    dtpStartTime.Value = dtpStartTime.Value.AddDays(-1)
                Case DayOfWeek.Wednesday
                    dtpStartTime.Value = dtpStartTime.Value.AddDays(-2)
                Case DayOfWeek.Thursday
                    dtpStartTime.Value = dtpStartTime.Value.AddDays(-3)
                Case DayOfWeek.Friday
                    dtpStartTime.Value = dtpStartTime.Value.AddDays(-4)
                Case DayOfWeek.Saturday
                    dtpStartTime.Value = dtpStartTime.Value.AddDays(-5)
                Case DayOfWeek.Sunday
                    dtpStartTime.Value = dtpStartTime.Value.AddDays(-6)
            End Select
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnReFresh_Click(sender As Object, e As EventArgs) Handles btnReFresh.Click
        Try
            mtdHPW.selectPayroll(tblTime, dtpStartTime.Value)
            mtdHPW.selectNONBILLABLE(tblNonBillable, dtpStartTime.Value)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnFindMasterPayroll_Click(sender As Object, e As EventArgs) Handles btnFindMasterPayroll.Click
        Try
            Dim openFile As New OpenFileDialog
            openFile.DefaultExt = "*.xlsm"
            openFile.FileName = "MASTER Payroll"
            openFile.ShowDialog()
            txtSalida.Text = "Message:" + "Open file " + openFile.FileName
            If DialogResult.OK = MessageBox.Show("Please verify that the Sheets name are 'Time Sheet Data', 'NON-BILLABLE', 'EMP MASTER DATA' and the Weekendings has been inserted, if not do the changues.", "Important", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) Then
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
                Dim sheetPR As New Worksheet
                If flag = True Then
                    If case1 = 1 Then
                        sheetPR = libro.Worksheets("Time Sheet Data")
                        txtSalida.Text = "Message:" + "Open sheet 'Time Sheet Data'."
                    Else
                        sheetPR = libro.Worksheets("TimeSheetData")
                        txtSalida.Text = "Message:" + "Open sheet 'TimeSheetData'."
                    End If
                    limpiarSheet(sheetPR, sprRowStartTSD.Value)
                    Dim cont As Integer = 2
                    For Each row As DataGridViewRow In tblTime.Rows()
                        sheetPR.Cells(cont, 1) = row.Cells("StatusCode").Value
                        sheetPR.Cells(cont, 2) = row.Cells("Company").Value
                        sheetPR.Cells(cont, 6) = row.Cells("EmployeeNumber").Value
                        sheetPR.Cells(cont, 7) = row.Cells("WeekNumber").Value
                        sheetPR.Cells(cont, 8) = row.Cells("JobNumber").Value
                        sheetPR.Cells(cont, 9) = row.Cells("SubJobNumber").Value
                        sheetPR.Cells(cont, 10) = row.Cells("CostDistribution").Value
                        sheetPR.Cells(cont, 11) = row.Cells("CostType").Value
                        sheetPR.Cells(cont, 13) = row.Cells("DayWeek").Value
                        sheetPR.Cells(cont, 18) = row.Cells("RegularHours").Value
                        sheetPR.Cells(cont, 19) = row.Cells("OvertimeHours").Value
                        sheetPR.Cells(cont, 20) = row.Cells("OtherHours").Value
                        sheetPR.Cells(cont, 33) = row.Cells("BatchNumber").Value
                        sheetPR.Cells(cont, 35) = row.Cells("CheckType").Value
                        cont += 1
                        txtSalida.Text = "Message:" + "Inserting row " + CStr(cont)
                    Next
                Else
                    MessageBox.Show("The sheet 'Time Sheet Data' is not found.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If

                For i = 1 To libro.Worksheets.Count
                    If libro.Worksheets(i).Name = "NON-BILLABLE" Then
                        flag = True
                        case1 = 1
                        Exit For
                    ElseIf libro.Worksheets(i).Name = "NON BILLABLE" Then
                        flag = True
                        case1 = 2
                        Exit For
                    End If
                Next
                Dim sheetNon As New Worksheet
                If flag = True Then
                    If case1 = 1 Then
                        sheetNon = libro.Worksheets("NON-BILLABLE")
                        txtSalida.Text = "Message:" + "Open sheet 'NON-BILLABLE'."
                    Else
                        sheetNon = libro.Worksheets("NON BILLABLE")
                        txtSalida.Text = "Message:" + "Open sheet 'NON BILLABLE'."
                    End If
                    limpiarSheet(sheetNon, sprRowStartNBL.Value)
                    Dim cont As Integer = 2
                    For Each row As DataGridViewRow In tblNonBillable.Rows()
                        sheetNon.Cells(cont, 1) = row.Cells(0).Value
                        sheetNon.Cells(cont, 2) = row.Cells(1).Value
                        sheetNon.Cells(cont, 3) = row.Cells(2).Value
                        sheetNon.Cells(cont, 4) = row.Cells(3).Value
                        sheetNon.Cells(cont, 5) = row.Cells(4).Value
                        sheetNon.Cells(cont, 6) = row.Cells(5).Value
                        sheetNon.Cells(cont, 7) = row.Cells(6).Value
                        sheetNon.Cells(cont, 8) = row.Cells(7).Value
                        sheetNon.Cells(cont, 9) = row.Cells(8).Value
                        cont += 1
                        txtSalida.Text = "Message:" + "Inserting row " + CStr(cont)
                    Next
                Else
                    MessageBox.Show("The sheet 'NON-BILLABLE' is not found.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
                NAR(sheetPR)
                NAR(sheetNon)
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
End Class