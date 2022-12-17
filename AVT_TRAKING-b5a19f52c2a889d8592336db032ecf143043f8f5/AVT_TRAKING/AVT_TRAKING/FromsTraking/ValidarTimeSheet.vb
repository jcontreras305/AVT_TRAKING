Imports System.Runtime.InteropServices
Public Class ValidarTimeSheet
    Dim mtdHPW As New MetodosHoursPeerWeek
    Dim mtdSacf As New MetodosScaffold
    Dim tblProjects As New DataTable
    Dim tblEmployees As New DataTable
    Dim tblWorkCodes As New DataTable
    Public Errors As New DataTable
    Dim selectColum As Integer
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

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub PictureBox4_Click_1(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Dim ts As TimeSheet = CType(Owner, TimeSheet)
        ts.flagErrorContinue = False
        Me.Close()
    End Sub
    Private Sub ValidarTimeSheet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpDate.Visible = False
        cmbData.Visible = False
        txtData.Visible = True
        txtData.Enabled = False
        Dim pnt As New Point(58, 13)
        dtpDate.Location = pnt
        txtData.Location = pnt
        cmbData.Location = pnt
        tblProjects = mtdHPW.llenarTablaProjects()
        mtdHPW.llenarTablaWorkCode(tblWorkCodes)
        tblEmployees = mtdHPW.llenarTablaEmpleado()
        llenarTableError()
        If existError() Then
            btnSave.Enabled = True
        Else
            btnSave.Enabled = False
        End If
    End Sub
    Private Function llenarTableError() As Boolean
        Try
            For Each row As DataRow In Errors.Rows
                Dim errorDescription As String = ""
                'Dim newid As Guid = Guid.NewGuid()
                Dim rowEmployee() As DataRow = tblEmployees.Select("numberEmploye = '" + row.ItemArray(1) + "'")
                Dim employeeNum As String = ""
                Dim employeeName As String = ""
                Dim idEmployee As String = ""
                If rowEmployee.Length > 0 Then
                    employeeNum = rowEmployee(0).ItemArray(0)
                    employeeName = rowEmployee(0).ItemArray(1)
                    idEmployee = rowEmployee(0).ItemArray(2)
                Else
                    errorDescription = "Error: The Employee was not found"
                End If
                Dim dateCell As String = ""
                If row.ItemArray(2) <> "" Then
                    Dim dateTemp As Date = CDate(row.ItemArray(2))
                    dateCell = dateTemp.Month.ToString + "/" + dateTemp.Day.ToString + "/" + dateTemp.Year.ToString()
                End If
                Dim rowsWO() As DataRow = tblProjects.Select("worknum = '" + row.ItemArray(3) + "' and idPO = '" + row.ItemArray(4) + "'")
                Dim jobNo As String = ""
                Dim idWorkCode As String = ""
                Dim workCodeName As String = ""
                Dim idTask As String = ""
                If rowsWO.Length = 1 Then
                    jobNo = rowsWO(0).ItemArray(5)
                ElseIf rowsWO.Length > 1 Then
                    errorDescription = If(errorDescription = "", "Error: Exist similar projects", errorDescription + ", Exist similar projects")
                Else
                    errorDescription = If(errorDescription = "", "Error: The project was not inserted", errorDescription + ", The project was not inserted")
                End If
                Dim rowsWC() As DataRow = tblWorkCodes.Select("name = '" + row.ItemArray(5) + "'" + If(jobNo = "", "", " and jobNo = '" + jobNo + "'"))
                If rowsWC.Length > 0 And Not jobNo = "" Then
                    idWorkCode = rowsWC(0).ItemArray(0).ToString()
                ElseIf rowsWC.Length > 0 And jobNo = "" Then
                    errorDescription = If(errorDescription = "", "Error: The Work Code is not especificated", errorDescription + ", The Work Code is not especificated")
                ElseIf rowsWC.Length = 0 Then
                    errorDescription = If(errorDescription = "", "Error: The Work Code not exist", errorDescription + ", The Work Code not exist")
                End If
                tblData.Rows.Add("", errorDescription + ".", row.ItemArray(1).ToString, row.ItemArray(0), dateCell, If(rowsWO.Length > 0, rowsWO(0).ItemArray(0), ""), row.ItemArray(4), workCodeName, row.ItemArray(6), row.ItemArray(7), row.ItemArray(8), row.ItemArray(9))
            Next
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim queryStringInsert As String = ""
        For Each row As DataGridViewRow In tblData.Rows
            If Not row.IsNewRow Then
                Dim newidRecord As Guid = Guid.NewGuid()
                Dim hst = If(row.Cells("HoursST").Value = "", "0", row.Cells("HoursST").Value)
                Dim hot = If(row.Cells("HoursOT").Value = "", "0", row.Cells("HoursOT").Value)
                Dim dateRecord As String = validaFechaParaSQl(row.Cells("dateWorked").Value)
                Dim schedule As String = If(row.Cells("Shift").Value = "DAYS", "DAYS", "NIGHT")
                queryStringInsert += newidRecord.ToString() & "," & hst & "," & hot & "," & "0" & "," & dateRecord & "," & CStr(row.Cells("idEmployee").Value) & "," & CStr(row.Cells("idWorkCode").Value) & "," & row.Cells("idTask").Value & "," & schedule & "," & row.Cells("JobNo").Value.ToString() & vbCrLf
            End If
        Next
        Dim ts As TimeSheet = CType(Owner, TimeSheet)
        ts.flagErrorContinue = True
        ts.correctionString = queryStringInsert
        Me.Close()
    End Sub
    Private Function queryStringInsert() As String
        Dim query As String = ""
        For Each row As DataGridViewRow In tblData.Rows

        Next
        Return query
    End Function

    Private Sub tblData_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles tblData.CellMouseClick
        Select Case tblData.CurrentCell.ColumnIndex
            Case 2 To 3
                dtpDate.Visible = False
                txtData.Visible = False
                cmbData.Visible = True
                cmbData.Items.Clear()
                cmbData.DropDownWidth = 150
                cmbData.Text = ""
                mtdHPW.llenarEmpleadosCombo(cmbData, tblEmployees)
                'cmbData.Text = ""
            Case 4
                dtpDate.Visible = True
                txtData.Visible = False
                cmbData.Visible = False
                If tblData.CurrentCell.Value IsNot DBNull.Value Then
                    Dim val() As String = tblData.CurrentCell.Value.ToString.Split("/")
                    If val.Length >= 3 Then
                        Dim fecha As Date = New Date(val(2), val(0), val(1))
                        dtpDate.Value = fecha
                    Else
                        dtpDate.Value = Today.Date
                    End If
                End If
            Case 5
                dtpDate.Visible = False
                txtData.Visible = False
                cmbData.Visible = True
                cmbData.DropDownWidth = 220
                cmbData.Text = ""
                If tblData.CurrentCell.Value IsNot DBNull.Value Then
                    mtdHPW.llenarComboProject(cmbData, tblData.CurrentCell.Value)

                End If
            Case 7
                dtpDate.Visible = False
                txtData.Visible = False
                cmbData.Visible = True
                cmbData.Items.Clear()
                cmbData.DropDownWidth = 150
                cmbData.Text = ""
                If tblData.CurrentRow.Cells("JobNo").Value IsNot DBNull.Value Then
                    If tblData.CurrentRow.Cells("JobNo").Value = "" Then
                        MessageBox.Show("Please Select a Work Order.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        mtdHPW.llenarComboWorkCode(cmbData, tblData.CurrentRow.Cells("JobNo").Value, tblData.CurrentRow.Cells("Code").Value)
                    End If
                End If
            Case 8 To 9
                dtpDate.Visible = False
                txtData.Visible = True
                cmbData.Visible = False
                txtData.Enabled = True
                txtData.Text = If(tblData.CurrentCell.Value IsNot DBNull.Value, tblData.CurrentCell.Value, "0")
            Case 10
                dtpDate.Visible = False
                txtData.Visible = False
                cmbData.Visible = True
                cmbData.Items.Clear()
                cmbData.Items.Add("DAYS")
                cmbData.Items.Add("NIGTHS")
                If tblData.CurrentCell.Value IsNot DBNull.Value Then
                    If tblData.CurrentCell.Value = "DAYS" Then
                        cmbData.Text = "DAYS"
                    ElseIf tblData.CurrentCell.Value = "NIGTH" Then
                        cmbData.Text = "NIGTH"
                    Else
                        cmbData.Text = ""
                    End If
                End If
            Case 11
                dtpDate.Visible = False
                txtData.Visible = True
                cmbData.Visible = False
                txtData.Text = If(tblData.CurrentCell.Value IsNot DBNull.Value, tblData.CurrentCell.Value, "0")
        End Select
        selectColum = tblData.CurrentCell.ColumnIndex
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dim ts As TimeSheet = CType(Owner, TimeSheet)
        ts.flagErrorContinue = True
        ts.correctionString = queryStringInsert()
        Me.Close()
    End Sub

    Private Sub cmbData_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbData.SelectedIndexChanged
        Try
            Select Case selectColum
                Case 2 To 3 'employee name and num
                    Dim rows() As DataRow = tblEmployees.Select("name = '" + cmbData.Items(cmbData.SelectedIndex) + "'")
                    If rows.Length = 1 Then
                        tblData.CurrentRow.Cells("EmployeeNum").Value = rows(0).ItemArray(0).ToString
                        tblData.CurrentRow.Cells("EmployeeName").Value = rows(0).ItemArray(1).ToString
                        tblData.CurrentRow.Cells("idEmployee").Value = rows(0).ItemArray(2).ToString
                    Else
                        tblData.CurrentRow.Cells("EmployeeNum").Value = ""
                        tblData.CurrentRow.Cells("EmployeeName").Value = ""
                        tblData.CurrentRow.Cells("idEmployee").Value = ""
                    End If
                Case 5 'work order
                    Dim arrayWO() As String = cmbData.Items(cmbData.SelectedIndex).ToString.Split(" ")
                    Dim arrayWO2 As New List(Of String)
                    Dim cont As Integer = 0
                    For Each item As String In arrayWO
                        If item <> "" Then
                            arrayWO2.Add(item)
                            cont += 1
                        End If
                    Next
                    If arrayWO2.Count = 3 Then

                        Dim rowsWO() As DataRow = tblProjects.Select("worknum = '" + arrayWO2(0) + "' and idPO = '" + arrayWO2(1) + "' and jobNo = '" + arrayWO2(2) + "'")
                        If rowsWO.Length = 1 Then
                            tblData.CurrentRow.Cells("WorkOrder").Value = arrayWO2(0)
                            tblData.CurrentRow.Cells("PO").Value = arrayWO2(1)
                            tblData.CurrentRow.Cells("JobNo").Value = arrayWO2(2)
                            tblData.CurrentRow.Cells("idTask").Value = rowsWO(0).ItemArray(2)
                        End If
                    Else
                        tblData.CurrentRow.Cells("WorkOrder").Value = ""
                        tblData.CurrentRow.Cells("PO").Value = ""
                        tblData.CurrentRow.Cells("JobNo").Value = ""
                        tblData.CurrentRow.Cells("idTask").Value = ""
                    End If
                Case 7 'work code
                    Dim rowsWC() As DataRow = tblWorkCodes.Select("name = '" + cmbData.Items(cmbData.SelectedIndex) + "' and jobNo = '" + tblData.CurrentRow.Cells("jobNo").Value.ToString + "'")
                    If rowsWC.Length = 1 Then
                        tblData.CurrentRow.Cells("Code").Value = rowsWC(0).ItemArray(1)
                        tblData.CurrentRow.Cells("idWorkCode").Value = rowsWC(0).ItemArray(0).ToString()
                    Else
                        tblData.CurrentRow.Cells("Code").Value = ""
                        tblData.CurrentRow.Cells("idWorkCode").Value = ""
                    End If
                Case 10 'schedule
                    tblData.CurrentRow.Cells("Shift").Value = cmbData.Items(cmbData.SelectedIndex)
            End Select
            validaRow(tblData.CurrentRow.Index)
            If existError() Then
                btnSave.Enabled = True
            Else
                btnSave.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtpDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpDate.ValueChanged
        Try
            tblData.CurrentRow.Cells("DateWorked").Value = CStr(dtpDate.Value.Month) + "/" + CStr(dtpDate.Value.Day) + "/" + CStr(dtpDate.Value.Year)
            validaRow(tblData.CurrentRow.Index)
            If existError() Then
                btnSave.Enabled = True
            Else
                btnSave.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtData_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtData.KeyPress
        Select Case selectColum
            Case 8 To 9
                If Not (IsNumeric(e.KeyChar) Or e.KeyChar = vbBack) Then
                    If e.KeyChar = vbCr Then
                        If txtData.Text = "" Then
                            tblData.CurrentCell.Value = "0"
                            tblData.CurrentCell = tblData.CurrentRow.Cells(tblData.CurrentCell.ColumnIndex + 1)
                        Else
                            If CDbl(txtData.Text) <= 8 And CDbl(txtData.Text) >= 0 Then
                                tblData.CurrentCell.Value = txtData.Text.ToString()
                                tblData.CurrentCell = tblData.CurrentRow.Cells(tblData.CurrentCell.ColumnIndex + 1)
                            Else
                                tblData.CurrentCell.Value = "0"
                                tblData.CurrentCell = tblData.CurrentRow.Cells(tblData.CurrentCell.ColumnIndex + 1)
                            End If
                        End If


                    Else
                            e.Handled = True
                    End If
                End If
            Case 11
                If e.KeyChar = vbCr Then
                    tblData.CurrentCell.Value = txtData.Text.ToString()
                    tblData.CurrentCell = tblData.CurrentRow.Cells(tblData.CurrentCell.ColumnIndex + 1)
                End If
        End Select
    End Sub

    Private Function validaRow(ByVal rowIndex As Integer) As Boolean
        Try
            Dim mesageError As String = ""
            Dim rowEmp() As DataRow = tblEmployees.Select("name = '" + tblData.Rows(rowIndex).Cells("EmployeeName").Value.ToString + "'")
            If rowEmp.Length = 0 Then
                mesageError = "Error: The Employee was not found"
            End If
            Dim rowWO() As DataRow = tblProjects.Select("worknum = '" + tblData.Rows(rowIndex).Cells("WorkOrder").Value.ToString + "' and idPO = '" + If(tblData.Rows(rowIndex).Cells("PO").Value Is Nothing, "", tblData.Rows(rowIndex).Cells("PO").Value.ToString) + "' and jobNo = '" + If(tblData.Rows(rowIndex).Cells("JobNo").Value Is Nothing, "", tblData.Rows(rowIndex).Cells("JobNo").Value.ToString) + "'")
            If rowWO.Length = 0 Then
                mesageError = If(mesageError = "", "Error: The project was not inserted", mesageError + ", The project was not inserted")
            End If
            Dim rowWC() As DataRow = tblWorkCodes.Select("name = '" + tblData.Rows(rowIndex).Cells("Code").Value + "' and JobNo = '" + If(tblData.Rows(rowIndex).Cells("JobNo").Value Is Nothing, "", tblData.Rows(rowIndex).Cells("JobNo").Value) + "'")
            If rowWC.Length = 0 Then
                mesageError = If(mesageError = "", "Error: The Work Code is not especificated", mesageError + ", The Work Code is not especificated")
            End If
            If tblData.CurrentRow.Cells("DateWorked").Value = "" Then
                mesageError = If(mesageError = "", "Error: The date is not valid", mesageError + ", The date is not valid")
            End If
            If mesageError <> "" Then
                tblData.Rows(rowIndex).DefaultCellStyle.BackColor = Color.Yellow
                tblData.Rows(rowIndex).Cells("Message").Value = mesageError
                Return False
            Else
                tblData.Rows(rowIndex).DefaultCellStyle.BackColor = Color.White
                tblData.Rows(rowIndex).Cells("Message").Value = ""
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function existError() As Boolean
        Dim flag As Boolean = True
        For Each row As DataGridViewRow In tblData.Rows
            If row.Cells("Message").Value <> "" Then
                flag = False
                Exit For
            End If
        Next
        Return flag
    End Function
End Class