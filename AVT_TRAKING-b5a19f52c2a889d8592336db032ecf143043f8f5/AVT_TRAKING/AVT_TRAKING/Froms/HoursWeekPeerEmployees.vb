﻿Public Class HoursWeekPeerEmployees
    Dim mtdOthers As New MetodosOthers
    Dim mtdHPW As New MetodosHoursPeerWeek
    Dim idsEmployees As New DataTable
    Public idEmpleado, NombreEmpleado As String
    Dim proyectTable As New DataTable
    Dim workCodeTable As New DataTable
    Dim expenseCodeTable As New DataTable
    Public photo As Byte()

    Dim _dtpHoras As New DateTimePicker
    Dim _dtpExpenses As New DateTimePicker
    Dim _dtpSemanal As New DateTimePicker
    Dim _rectangulo As New Rectangle
    Private Sub HoursWeekPeerEmployees_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mtdHPW.llenarEmpleadosCombo(cmbEmpleados, idsEmployees)
        If cmbEmpleados.Items.Count > 0 Then
            cmbEmpleados.SelectedItem = cmbEmpleados.Items(0)
            cargarDatos(cmbEmpleados.SelectedItem)
        Else
            Dim flagEmployees = False
            While flagEmployees = False
                If DialogResult.Yes = MessageBox.Show("Now you are not inserted any Employe or they are Disabled." + vbCrLf + "Would you like to open Employees Window?", "Importan", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) Then
                    Dim empleadoFrom As New Employees
                    empleadoFrom.ShowDialog()
                    mtdHPW.llenarEmpleadosCombo(cmbEmpleados, idsEmployees)
                    If cmbEmpleados.Items.Count > 0 Then
                        cmbEmpleados.SelectedItem = cmbEmpleados.Items(0)
                        cargarDatos(cmbEmpleados.SelectedItem)
                        flagEmployees = True
                    Else
                        flagEmployees = False
                    End If

                Else
                    flagEmployees = True
                End If
            End While
        End If
        txtFindFecha.Text = System.DateTime.Today.ToShortDateString()
        ''dtpFecha.Value = System.DateTime.Today
        'clnFindFecha.Visible = False

        mtdHPW.llenarTablaProyecto(proyectTable)
        mtdHPW.llenarTablaWorkCode(workCodeTable)
        mtdHPW.llenarTablaExpenses(expenseCodeTable)

        tblRecordEmployee.Controls.Add(_dtpHoras)
        _dtpHoras.Visible = False
        _dtpHoras.Format = DateTimePickerFormat.Custom
        _dtpHoras.CustomFormat = "MM/dd/yyyy"
        AddHandler _dtpHoras.ValueChanged, AddressOf _dtpHoras_ValuesChangue

        tblExpenses.Controls.Add(_dtpExpenses)
        _dtpExpenses.Visible = False
        _dtpExpenses.Format = DateTimePickerFormat.Custom
        _dtpExpenses.CustomFormat = "MM/dd/yyyy"
        AddHandler _dtpExpenses.ValueChanged, AddressOf _dtpExpenses_ValuesChangue

        tblHourPeerDay.Controls.Add(_dtpSemanal)
        _dtpSemanal.Visible = False
        _dtpSemanal.Format = DateTimePickerFormat.Custom
        _dtpSemanal.CustomFormat = "MM/dd/yyyy"
        AddHandler _dtpSemanal.ValueChanged, AddressOf _dtpSemanal_ValuesChangue

        flagPressCellDate = False
        flagPressCellDateExpense = False
        flagPreesCellDateSemanal = False
    End Sub



    Private Sub btnEmpleados_Click(sender As Object, e As EventArgs) Handles btnEmpleados.Click
        Dim empleadoFrom As New Employees
        empleadoFrom.ShowDialog()
        mtdHPW.llenarEmpleadosCombo(cmbEmpleados, idsEmployees)
        If cmbEmpleados.Items.Count > 0 Then
            cmbEmpleados.SelectedItem = cmbEmpleados.Items(0)
            cargarDatos(cmbEmpleados.SelectedItem)
        End If
        mtdHPW.llenarTablaProyecto(proyectTable)
        mtdHPW.llenarTablaWorkCode(workCodeTable)
        mtdHPW.llenarTablaExpenses(expenseCodeTable)
    End Sub

    Private Sub _dtpHoras_ValuesChangue(sender As Object, e As EventArgs)
        Dim fecha = If(_dtpHoras.Value.Month < 10, "0" + _dtpHoras.Value.Month.ToString(), _dtpHoras.Value.Month.ToString()) + "/" + If(_dtpHoras.Value.Day < 10, "0" + _dtpHoras.Value.Day.ToString(), _dtpHoras.Value.Day.ToString()) + "/" + _dtpHoras.Value.Year.ToString()
        tblRecordEmployee.CurrentRow.Cells("Date").Value = fecha
    End Sub
    Private Sub _dtpExpenses_ValuesChangue(sender As Object, e As EventArgs)
        Dim fecha = If(_dtpExpenses.Value.Month < 10, "0" + _dtpExpenses.Value.Month.ToString(), _dtpExpenses.Value.Month.ToString()) + "/" + If(_dtpExpenses.Value.Day < 10, "0" + _dtpExpenses.Value.Day.ToString(), _dtpExpenses.Value.Day.ToString()) + "/" + _dtpExpenses.Value.Year.ToString()
        tblExpenses.CurrentRow.Cells("Date").Value = fecha
    End Sub

    Private Sub _dtpSemanal_ValuesChangue(sender As Object, e As EventArgs)
        tblHourPeerDay.CurrentRow.Cells("clmWeekending").Value = _dtpSemanal.Value.ToString()
        Dim hoursST As Double
        Dim hoursOT As Double
        Dim hours3 As Double
        Dim hourTotal As Double
        For Each row As DataGridViewRow In tblRecordEmployee.Rows

            Dim diferencia = Date.Compare(validarFechaParaVB(row.Cells("Date").Value), primerDiaDeLaSemana(_dtpSemanal.Value))
            If diferencia >= 0 Then
                hoursST += row.Cells("Hours ST").Value
                hoursOT += row.Cells("Hours OT").Value
                hours3 += row.Cells("Hours 3").Value
                hourTotal += (row.Cells("Hours ST").Value + row.Cells("Hours OT").Value + row.Cells("Hours 3").Value)

                Select Case CDate(validarFechaParaVB(row.Cells("Date").Value)).DayOfWeek
                    Case DayOfWeek.Monday
                        tblHourPeerDay.Rows(0).Cells("clmMonST").Value = row.Cells("Hours ST").Value
                        tblHourPeerDay.Rows(0).Cells("clmMonOT").Value = row.Cells("Hours OT").Value
                    Case DayOfWeek.Tuesday
                        tblHourPeerDay.Rows(0).Cells("clmTueST").Value = row.Cells("Hours ST").Value
                        tblHourPeerDay.Rows(0).Cells("clmTueOT").Value = row.Cells("Hours OT").Value
                    Case DayOfWeek.Wednesday
                        tblHourPeerDay.Rows(0).Cells("clmWedST").Value = row.Cells("Hours ST").Value
                        tblHourPeerDay.Rows(0).Cells("clmWedOT").Value = row.Cells("Hours OT").Value
                    Case DayOfWeek.Thursday
                        tblHourPeerDay.Rows(0).Cells("clmThuST").Value = row.Cells("Hours ST").Value
                        tblHourPeerDay.Rows(0).Cells("clmThuOT").Value = row.Cells("Hours OT").Value
                    Case DayOfWeek.Friday
                        tblHourPeerDay.Rows(0).Cells("clmFriST").Value = row.Cells("Hours ST").Value
                        tblHourPeerDay.Rows(0).Cells("clmFriOT").Value = row.Cells("Hours OT").Value
                    Case DayOfWeek.Saturday
                        tblHourPeerDay.Rows(0).Cells("clmSatST").Value = row.Cells("Hours ST").Value
                        tblHourPeerDay.Rows(0).Cells("clmSatOT").Value = row.Cells("Hours OT").Value
                    Case DayOfWeek.Sunday
                        tblHourPeerDay.Rows(0).Cells("clmSunST").Value = row.Cells("Hours ST").Value
                        tblHourPeerDay.Rows(0).Cells("clmSunOT").Value = row.Cells("Hours OT").Value
                End Select
            End If
        Next
    End Sub

    Private Sub tblExpenses_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles tblExpenses.CellClick
        If e.ColumnIndex <> -1 And e.RowIndex <> -1 Then
            Select Case tblExpenses.Columns(e.ColumnIndex).Name
                Case "Date"
                    Dim fecha = If(System.DateTime.Today.Month < 10, "0" + System.DateTime.Today.Month.ToString(), System.DateTime.Today.Month.ToString()) + "/" + If(System.DateTime.Today.Day < 10, "0" + System.DateTime.Today.Day.ToString(), System.DateTime.Today.Day.ToString()) + "/" + System.DateTime.Today.Year.ToString()
                    _rectangulo = tblExpenses.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True)
                    _dtpExpenses.Size = New Size(_rectangulo.Width, _rectangulo.Height)
                    _dtpExpenses.Location = New Point(_rectangulo.X, _rectangulo.Y)
                    _dtpExpenses.Value = validarFechaParaVB(If(tblExpenses.CurrentCell.Value Is DBNull.Value, fecha, tblExpenses.CurrentCell.Value))
                    _dtpExpenses.Visible = True
                    flagPressCellDateExpense = True
                    _dtpExpenses.CustomFormat = "MM/dd/yyyy"
                Case "Project"
                    Try
                        If tblExpenses.CurrentCell.GetType.Name = "DataGridViewTextBoxCell" Then
                            Dim cmbProyect As New DataGridViewComboBoxCell
                            With cmbProyect
                                mtdHPW.llenarComboCellProject(cmbProyect, proyectTable)
                            End With
                            tblExpenses.CurrentRow.Cells("Project") = cmbProyect
                        Else
                            tblExpenses.CurrentRow.Cells("Project") = tblExpenses.CurrentCell
                        End If
                    Catch ex As Exception

                    End Try
                Case "Expense Code"
                    Try
                        If tblExpenses.CurrentCell.GetType.Name = "DataGridViewTextBoxCell" Then
                            Dim cmbExpenseCode As New DataGridViewComboBoxCell
                            With cmbExpenseCode
                                mtdHPW.llenarComboCellExpeseCode(cmbExpenseCode, expenseCodeTable)
                            End With
                            tblExpenses.CurrentRow.Cells("Expense Code") = cmbExpenseCode
                        Else
                            tblExpenses.CurrentRow.Cells("Expense Code") = tblExpenses.CurrentCell
                        End If
                    Catch ex As Exception

                    End Try
            End Select
        End If
    End Sub

    Dim flagPressCellDate As Boolean
    Dim flagPressCellDateExpense As Boolean
    Dim flagPreesCellDateSemanal As Boolean

    Private Sub tblHourPeerDay_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles tblHourPeerDay.CellClick
        If e.ColumnIndex <> -1 And e.RowIndex <> -1 Then
            Select Case tblHourPeerDay.Columns(e.ColumnIndex).Name
                Case "clmWeekending"
                    _dtpSemanal.CustomFormat = "MM/dd/yyyy"
                    _rectangulo = tblHourPeerDay.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True)
                    _dtpSemanal.Size = New Size(_rectangulo.Width, _rectangulo.Height)
                    _dtpSemanal.Location = New Point(_rectangulo.X, _rectangulo.Y)
                    _dtpSemanal.Value = If(tblHourPeerDay.CurrentCell.Value IsNot DBNull.Value, CDate(tblHourPeerDay.CurrentCell.Value), System.DateTime.Today.ToShortDateString())
                    _dtpSemanal.Visible = True
                    flagPressCellDate = True
            End Select
        End If
    End Sub
    Dim flagCellClickRecords As Boolean
    Private Sub tblRecordEmployee_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles tblRecordEmployee.CellClick
        If e.ColumnIndex <> -1 And e.RowIndex <> -1 Then
            Select Case tblRecordEmployee.Columns(e.ColumnIndex).Name
                Case "Date"
                    Dim fecha = If(System.DateTime.Today.Month < 10, "0" + System.DateTime.Today.Month.ToString(), System.DateTime.Today.Month.ToString()) + "/" + If(System.DateTime.Today.Day < 10, "0" + System.DateTime.Today.Day.ToString(), System.DateTime.Today.Day.ToString()) + "/" + System.DateTime.Today.Year.ToString()
                    _rectangulo = tblRecordEmployee.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True)
                    _dtpHoras.Size = New Size(_rectangulo.Width, _rectangulo.Height)
                    _dtpHoras.Location = New Point(_rectangulo.X, _rectangulo.Y)
                    _dtpHoras.Visible = True
                    _dtpHoras.Value = validarFechaParaVB(If(tblRecordEmployee.CurrentCell.Value Is DBNull.Value, fecha, tblRecordEmployee.CurrentCell.Value))
                    flagPressCellDate = True
                    flagCellClickRecords = True
                    _dtpHoras.CustomFormat = "MM/dd/yyyy"
                Case "Project"
                    Try
                        If tblRecordEmployee.CurrentCell.GetType.Name = "DataGridViewTextBoxCell" Then
                            Dim cmbProyect As New DataGridViewComboBoxCell
                            With cmbProyect
                                mtdHPW.llenarComboCellProject(cmbProyect, proyectTable)
                            End With
                            tblRecordEmployee.CurrentRow.Cells("Project") = cmbProyect
                        End If
                        flagFilaActual = "ProjectHours"
                        flagCellClickRecords = True
                    Catch ex As Exception

                    End Try
                Case "Work Code"
                    Try
                        If tblRecordEmployee.CurrentCell.GetType.Name = "DataGridViewTextBoxCell" Then
                            Dim cmbWorkCode As New DataGridViewComboBoxCell
                            With cmbWorkCode
                                mtdHPW.llenarComboCellWorkCode(cmbWorkCode, workCodeTable)
                            End With
                            tblRecordEmployee.CurrentRow.Cells("Work Code") = cmbWorkCode
                        End If
                        flagFilaActual = "WorkCode"
                        flagCellClickRecords = True
                    Catch ex As Exception

                    End Try
                Case "Shift"
                    Try
                        If tblRecordEmployee.CurrentCell.GetType.Name = "DataGridViewTextBoxCell" Then
                            Dim cmbShift As New DataGridViewComboBoxCell
                            cmbShift.Items.Add("Day")
                            cmbShift.Items.Add("Nigth")
                            tblRecordEmployee.CurrentRow.Cells("Shift") = cmbShift
                        End If
                        flagFilaActual = "Shift"
                        flagCellClickRecords = True
                    Catch ex As Exception

                    End Try
            End Select
        End If
    End Sub

    Dim flagFilaActual As String


    'evento para los combo declarados en cada celda
    Public Sub cmb_SelectedIndexChangued(sender As Object, e As EventArgs)
        Dim cmb As ComboBox = CType(sender, ComboBox)
        If flagCellClickRecords = True Then
            If tblRecordEmployee.CurrentCell.ColumnIndex = tblRecordEmployee.Columns("Project").Index Then
                For Each row As DataRow In proyectTable.Rows
                    If cmb.Text <> "" Then
                        If cmb.Text = row.ItemArray(1) Then
                            tblRecordEmployee.CurrentRow.Cells("Project Description").Value = row.ItemArray(2)
                            Exit For
                        End If
                    End If
                Next
            ElseIf tblRecordEmployee.CurrentCell.ColumnIndex = tblRecordEmployee.Columns("Work Code").Index Then
                For Each row As DataRow In workCodeTable.Rows
                    If cmb.Text IsNot "" Then
                        If cmb.Text = row.ItemArray(1) Then
                            If tblRecordEmployee.CurrentRow.Cells(0).Value Is DBNull.Value Then
                                tblRecordEmployee.CurrentRow.Cells("Hours ST").Value = "0"
                                tblRecordEmployee.CurrentRow.Cells("Hours OT").Value = "0"
                                tblRecordEmployee.CurrentRow.Cells("Hours 3").Value = "0"
                            End If
                            tblRecordEmployee.CurrentRow.Cells("Clasification").Value = row.ItemArray(2)
                            tblRecordEmployee.CurrentRow.Cells("Billing Rate").Value = row.ItemArray(3)
                            tblRecordEmployee.CurrentRow.Cells("Billing Rate OT").Value = row.ItemArray(4)
                            tblRecordEmployee.CurrentRow.Cells("Billing Rate 3").Value = row.ItemArray(5)
                            Exit For
                        End If
                    End If
                Next
            End If
        End If
        flagCellClickRecords = False
    End Sub

    Private Sub tblExpenses_ColumnWithChangue(sender As Object, e As DataGridViewColumnEventArgs) Handles tblExpenses.ColumnWidthChanged
        _dtpExpenses.Visible = False
    End Sub

    Private Sub tblExpenses_Scroll(sender As Object, e As ScrollEventArgs) Handles tblExpenses.Scroll
        _dtpExpenses.Visible = False
    End Sub


    Private Sub tblRecordEmployee_ColumnWithChangue(sender As Object, e As DataGridViewColumnEventArgs) Handles tblRecordEmployee.ColumnWidthChanged
        _dtpHoras.Visible = False
    End Sub

    Private Sub tblRecordEmployee_Scroll(sender As Object, e As ScrollEventArgs) Handles tblRecordEmployee.Scroll
        _dtpHoras.Visible = False

    End Sub

    Private Sub cmbEmpleados_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbEmpleados.SelectionChangeCommitted, cmbEmpleados.SelectedValueChanged
        If cmbEmpleados.Items.Count > 0 Then
            cargarDatos(cmbEmpleados.SelectedItem)
        End If
    End Sub

    Private Sub btnFindEmployee_Click(sender As Object, e As EventArgs) Handles btnFindEmployee.Click
        If cmbEmpleados.Items.Count > 0 Then
            Dim idAux = idEmpleado
            Dim fndEmp As New FindEmployee
            AddOwnedForm(fndEmp)
            fndEmp.ShowDialog()
            If idAux <> idEmpleado Then
                cmbEmpleados.SelectedItem = NombreEmpleado
                cargarDatos(cmbEmpleados.SelectedItem)
            End If
        End If
    End Sub


    Private Sub cargarDatos(ByVal Employee As String)
        Dim index As Integer = 0
        For Each row As DataRow In idsEmployees.Rows
            If Employee = row.ItemArray(0) Or Employee = row.ItemArray(1) Then
                idEmpleado = row.ItemArray(0)
                Exit For
            End If
            index += 1
        Next
        mtdHPW.buscarHoras(tblRecordEmployee, idsEmployees.Rows(index).ItemArray(0))
        tblRecordEmployee.Columns("Billing Rate").ReadOnly = True
        tblRecordEmployee.Columns("Billing Rate OT").ReadOnly = True
        tblRecordEmployee.Columns("Billing Rate 3").ReadOnly = True
        mtdHPW.bucarExpensesEmpleado(tblExpenses, idsEmployees.Rows(index).ItemArray(0))
        tblHourPeerDay.Rows.Clear()
        tblHourPeerDay.Rows.Add(ultimoDiaDeLaSemana(System.DateTime.Today.ToShortDateString()).ToShortDateString(), idsEmployees.Rows(index).ItemArray(1), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
        pcbPhoto.Image = BytetoImage(idsEmployees.Rows(index).ItemArray(2))
        lblEmployeeNumber.Text = idsEmployees.Rows(index).ItemArray(4)
        lblNombreEmployee.Text = idsEmployees.Rows(index).ItemArray(1)
        NombreEmpleado = idsEmployees.Rows(index).ItemArray(1)
        btnSAP.Text = idsEmployees.Rows(index).ItemArray(3)
        Dim hoursST As Double = 0.0
        Dim hoursOT As Double = 0.0
        Dim hours3 As Double = 0.0
        Dim hourTotal As Double = 0.0
        Dim HoursSTWeek = 0.0
        Dim HoursOTWeek = 0.0
        Dim Hours3Week = 0.0
        For Each row As DataGridViewRow In tblRecordEmployee.Rows
            hoursST += row.Cells("Hours ST").Value
            hoursOT += row.Cells("Hours OT").Value
            hours3 += row.Cells("Hours 3").Value
            hourTotal += (row.Cells("Hours ST").Value + row.Cells("Hours OT").Value + row.Cells("Hours 3").Value)
            Dim diferencia = Date.Compare(validarFechaParaVB(row.Cells("Date").Value), primerDiaDeLaSemana(System.DateTime.Today))
            If diferencia >= 0 Then
                Select Case CDate(validarFechaParaVB(row.Cells("Date").Value)).DayOfWeek
                    Case DayOfWeek.Monday
                        tblHourPeerDay.Rows(0).Cells("clmMonST").Value = CStr(CDbl(tblHourPeerDay.Rows(0).Cells("clmMonST").Value) + CDbl(row.Cells("Hours ST").Value))
                        tblHourPeerDay.Rows(0).Cells("clmMonOT").Value = CStr(CDbl(tblHourPeerDay.Rows(0).Cells("clmMonOT").Value) + CDbl(row.Cells("Hours OT").Value))
                        HoursOTWeek += row.Cells("Hours OT").Value
                        HoursSTWeek += row.Cells("Hours ST").Value
                        Hours3Week += row.Cells("Hours 3").Value
                    Case DayOfWeek.Tuesday
                        tblHourPeerDay.Rows(0).Cells("clmTueST").Value = CStr(CDbl(tblHourPeerDay.Rows(0).Cells("clmTueST").Value) + CDbl(row.Cells("Hours ST").Value))
                        tblHourPeerDay.Rows(0).Cells("clmTueOT").Value = CStr(CDbl(tblHourPeerDay.Rows(0).Cells("clmTueOT").Value) + CDbl(row.Cells("Hours OT").Value))
                        HoursOTWeek += row.Cells("Hours OT").Value
                        HoursSTWeek += row.Cells("Hours ST").Value
                        Hours3Week += row.Cells("Hours 3").Value
                    Case DayOfWeek.Wednesday
                        tblHourPeerDay.Rows(0).Cells("clmWedST").Value = CStr(CDbl(tblHourPeerDay.Rows(0).Cells("clmWedST").Value) + CDbl(row.Cells("Hours ST").Value))
                        tblHourPeerDay.Rows(0).Cells("clmWedOT").Value = CStr(CDbl(tblHourPeerDay.Rows(0).Cells("clmWedOT").Value) + CDbl(row.Cells("Hours OT").Value))
                        HoursOTWeek += row.Cells("Hours OT").Value
                        HoursSTWeek += row.Cells("Hours ST").Value
                        Hours3Week += row.Cells("Hours 3").Value
                    Case DayOfWeek.Thursday
                        tblHourPeerDay.Rows(0).Cells("clmThuST").Value = CStr(CDbl(tblHourPeerDay.Rows(0).Cells("clmThuST").Value) + CDbl(row.Cells("Hours ST").Value))
                        tblHourPeerDay.Rows(0).Cells("clmThuOT").Value = CStr(CDbl(tblHourPeerDay.Rows(0).Cells("clmThuOT").Value) + CDbl(row.Cells("Hours OT").Value))
                        HoursOTWeek += row.Cells("Hours OT").Value
                        HoursSTWeek += row.Cells("Hours ST").Value
                        Hours3Week += row.Cells("Hours 3").Value
                    Case DayOfWeek.Friday
                        tblHourPeerDay.Rows(0).Cells("clmFriST").Value = CStr(CDbl(tblHourPeerDay.Rows(0).Cells("clmFriST").Value) + CDbl(row.Cells("Hours ST").Value))
                        tblHourPeerDay.Rows(0).Cells("clmFriOT").Value = CStr(CDbl(tblHourPeerDay.Rows(0).Cells("clmFriOT").Value) + CDbl(row.Cells("Hours OT").Value))
                        HoursOTWeek += row.Cells("Hours OT").Value
                        HoursSTWeek += row.Cells("Hours ST").Value
                        Hours3Week += row.Cells("Hours 3").Value
                    Case DayOfWeek.Saturday
                        tblHourPeerDay.Rows(0).Cells("clmSatST").Value = CStr(CDbl(tblHourPeerDay.Rows(0).Cells("clmSatST").Value) + CDbl(row.Cells("Hours ST").Value))
                        tblHourPeerDay.Rows(0).Cells("clmSatOT").Value = CStr(CDbl(tblHourPeerDay.Rows(0).Cells("clmSatOT").Value) + CDbl(row.Cells("Hours OT").Value))
                        HoursOTWeek += row.Cells("Hours OT").Value
                        HoursSTWeek += row.Cells("Hours ST").Value
                        Hours3Week += row.Cells("Hours 3").Value
                    Case DayOfWeek.Sunday
                        tblHourPeerDay.Rows(0).Cells("clmSunST").Value = CStr(CDbl(tblHourPeerDay.Rows(0).Cells("clmSunST").Value) + CDbl(row.Cells("Hours ST").Value))
                        tblHourPeerDay.Rows(0).Cells("clmSunOT").Value = CStr(CDbl(tblHourPeerDay.Rows(0).Cells("clmSunOT").Value) + CDbl(row.Cells("Hours OT").Value))
                        HoursOTWeek += row.Cells("Hours OT").Value
                        HoursSTWeek += row.Cells("Hours ST").Value
                        Hours3Week += row.Cells("Hours 3").Value
                End Select
            End If
        Next
        txtTotalST.Text = hoursST
        txtTotalOT.Text = hoursOT
        txtHours3.Text = hours3
        txtTotalHours.Text = hourTotal
        tblHourPeerDay.Rows(0).Cells(2).Value = HoursSTWeek
        tblHourPeerDay.Rows(0).Cells(3).Value = HoursOTWeek
        tblHourPeerDay.Rows(0).Cells(4).Value = Hours3Week
    End Sub
    'evento de la tabla para agregar un evento aun ComboBoxCell
    Private Sub tblRecordEmployee_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles tblRecordEmployee.EditingControlShowing
        Dim Index = tblRecordEmployee.CurrentCell.ColumnIndex
        If Index = 2 Or Index = 4 Or Index = 9 Then
            Dim cb As ComboBox = CType(e.Control, ComboBox)
            If e.Control IsNot Nothing Then
                RemoveHandler cb.SelectedIndexChanged, AddressOf cmb_SelectedIndexChangued
                AddHandler cb.SelectedIndexChanged, AddressOf cmb_SelectedIndexChangued
            End If
        End If
    End Sub

    Private Sub tblExpenses_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles tblExpenses.EditingControlShowing
        If tblExpenses.CurrentCell.ColumnIndex = 2 Then
            Dim cb As ComboBox = CType(e.Control, ComboBox)
            If e.Control IsNot Nothing Then
                RemoveHandler cb.SelectedIndexChanged, AddressOf cmb_SelectedIndexChangued
                AddHandler cb.SelectedIndexChanged, AddressOf cmb_SelectedIndexChangued
            End If
        End If
    End Sub

    Private Sub btnSAP_Click(sender As Object, e As EventArgs) Handles btnSAP.Click
        Dim AbsEmp As New Absentsemployee
        AbsEmp.txtEmployeNumber.Text = btnSAP.Text
        Dim array = NombreEmpleado.Split(" ")
        AbsEmp.txtLastName.Text = array(2)
        AbsEmp.txtFirstName.Text = array(0) + " " + array(1)
        AbsEmp.idEmpleado = idEmpleado
        AbsEmp.ShowDialog()
    End Sub
    Dim listRowCopy As New List(Of Object)
    Dim listRowCopyrecords As New List(Of String())
    Dim listRowCopyExp As New List(Of String())
    Private Sub tblRecordEmployee_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tblRecordEmployee.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If recolectarDatosRecord() Then
                cargarDatos(idEmpleado)
                flagPressCellDate = False
            End If
        ElseIf Asc(e.KeyChar) = 3 Then
            listRowCopyrecords.Clear()
            For Each row As DataGridViewRow In tblRecordEmployee.SelectedRows
                Dim dataCells() As String = {row.Cells("Date").Value.ToString(), row.Cells("Project").Value.ToString(), row.Cells("Project Description").Value.ToString(), row.Cells("Work Code").Value.ToString(), row.Cells("Clasification").Value.ToString(), row.Cells("Hours ST").Value.ToString(), row.Cells("Hours OT").Value.ToString(), row.Cells("Hours 3").Value.ToString(), row.Cells("Shift").Value.ToString(), row.Cells("Billing Rate").Value.ToString(), row.Cells("Billing Rate OT").Value.ToString(), row.Cells("Billing Rate 3").Value.ToString()}
                listRowCopyrecords.Add(dataCells)
            Next
        ElseIf Asc(e.KeyChar) = 22 Then
            pegarFilas(listRowCopyrecords, tblRecordEmployee)
        End If
    End Sub

    Private Sub tblExpenses_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tblExpenses.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If recolectarDatosExpenses() Then
                cargarDatos(idEmpleado)
                flagPressCellDateExpense = False
            End If
        ElseIf Asc(e.KeyChar) = 3 Then
            listRowCopy.Clear()
            For Each row As DataGridViewRow In tblExpenses.SelectedRows
                Dim dataCell() As String = {row.Cells("Date").Value.ToString(), row.Cells("Project").Value.ToString(), row.Cells("Expense Code").Value.ToString(), row.Cells("Amount").Value.ToString(), row.Cells("Description").Value.ToString()}
                listRowCopyExp.Add(dataCell)
            Next
        ElseIf Asc(e.KeyChar) = 22 Then
            pegarFilas(listRowCopyExp, tblExpenses)
        End If
    End Sub

    Public Function recolectarDatosExpenses() As Boolean
        Dim list As New List(Of String)
        Dim mensaje As String = ""
        Dim index = tblExpenses.CurrentRow.Index - 1
        If tblExpenses.Rows(index).Cells("idExpenseUsed").Value IsNot DBNull.Value Then
            list.Add(tblExpenses.Rows(index).Cells("idExpenseUsed").Value)
        Else
            list.Add("")
        End If

        If Not flagPressCellDateExpense Then
            list.Add(tblExpenses.Rows(index).Cells("Date").Value)
        Else
            If tblExpenses.Rows(index).Cells("Date").Value IsNot DBNull.Value Then
                list.Add(validaFechaParaSQl(tblExpenses.Rows(index).Cells("Date").Value))
            Else
                mensaje = If(mensaje = "", "Please choose a Date.", vbCrLf + " Please choose a Date")
            End If
        End If

        If tblExpenses.Rows(index).Cells("Amount").Value IsNot DBNull.Value Then
            list.Add(tblExpenses.Rows(index).Cells("Amount").Value)
        Else
            mensaje = If(mensaje = "", "The 'Amount' will be 0.", vbCrLf + " The 'Amount' will be 0.")
            list.Add("0")
        End If

        If tblExpenses.Rows(index).Cells("Description").Value IsNot DBNull.Value Then
            list.Add(tblExpenses.Rows(index).Cells("Description").Value)
        Else
            mensaje = If(mensaje = "", "The 'Description' will be Noting.", vbCrLf + " The 'Description' will be Noting.")
            list.Add("")
        End If

        If tblExpenses.Rows(index).Cells("Expense Code").Value IsNot DBNull.Value Then
            For Each row As DataRow In expenseCodeTable.Rows
                If row.ItemArray(1) = tblExpenses.Rows(index).Cells("Expense Code").Value Then
                    list.Add(row.ItemArray(0)) 'workCode
                    Exit For
                End If
            Next
        Else
            mensaje = If(mensaje = "", "Please choose a Expense Code.", vbCrLf + " Please choose a Expense Code")
        End If

        If tblExpenses.Rows(index).Cells("Project").Value IsNot DBNull.Value Then
            For Each row As DataRow In proyectTable.Rows
                If row.ItemArray(1) = tblExpenses.Rows(index).Cells("Project").Value Then
                    list.Add(row.ItemArray(0)) '
                    Exit For
                End If
            Next
        Else
            mensaje = If(mensaje = "", "Please choose a Proyect.", vbCrLf + " Please choose a Proyect")
        End If

        list.Add(idEmpleado)

        If mensaje = "" Then
            If list(0) = "" Then
                If DialogResult.OK = MessageBox.Show("If you accept the new expense will be inserted.", "Important", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) Then
                    If mtdHPW.insertExpensesUsed(list) Then
                        Return True
                    Else
                        Return False
                    End If
                Else
                    Return False
                End If
            Else
                If DialogResult.OK = MessageBox.Show("If you accept the expense will be updated.", "Important", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) Then
                    If mtdHPW.updateExpensesUsed(list) Then
                        Return True
                    Else
                        Return False
                    End If
                Else
                    Return False
                End If
            End If
        Else
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

    End Function
    Public Function recolectarDatosExpenses(ByVal index As Integer) As Boolean
        Dim list As New List(Of String)
        Dim mensaje As String = ""
        If tblExpenses.Rows(index).Cells("idExpenseUsed").Value IsNot DBNull.Value Then
            list.Add(tblExpenses.Rows(index).Cells("idExpenseUsed").Value)
        Else
            list.Add("")
        End If

        If Not flagPressCellDateExpense Then
            list.Add(tblExpenses.Rows(index).Cells("Date").Value)
        Else
            If tblExpenses.Rows(index).Cells("Date").Value IsNot DBNull.Value Then
                list.Add(validaFechaParaSQl(tblExpenses.Rows(index).Cells("Date").Value))
            Else
                mensaje = If(mensaje = "", "Please choose a Date.", vbCrLf + " Please choose a Date")
            End If
        End If

        If tblExpenses.Rows(index).Cells("Amount").Value IsNot DBNull.Value Then
            list.Add(tblExpenses.Rows(index).Cells("Amount").Value)
        Else
            mensaje = If(mensaje = "", "The 'Amount' will be 0.", vbCrLf + " The 'Amount' will be 0.")
            list.Add("0")
        End If

        If tblExpenses.Rows(index).Cells("Description").Value IsNot DBNull.Value Then
            list.Add(tblExpenses.Rows(index).Cells("Description").Value)
        Else
            mensaje = If(mensaje = "", "The 'Description' will be Noting.", vbCrLf + " The 'Description' will be Noting.")
            list.Add("")
        End If

        If tblExpenses.Rows(index).Cells("Expense Code").Value IsNot DBNull.Value Then
            For Each row As DataRow In expenseCodeTable.Rows
                If row.ItemArray(1) = tblExpenses.Rows(index).Cells("Expense Code").Value Then
                    list.Add(row.ItemArray(0)) 'workCode
                    Exit For
                End If
            Next
        Else
            mensaje = If(mensaje = "", "Please choose a Expense Code.", vbCrLf + " Please choose a Expense Code")
        End If

        If tblExpenses.Rows(index).Cells("Project").Value IsNot DBNull.Value Then
            For Each row As DataRow In proyectTable.Rows
                If row.ItemArray(1) = tblExpenses.Rows(index).Cells("Project").Value Then
                    list.Add(row.ItemArray(0)) '
                    Exit For
                End If
            Next
        Else
            mensaje = If(mensaje = "", "Please choose a Proyect.", vbCrLf + " Please choose a Proyect")
        End If

        list.Add(idEmpleado)

        If mensaje = "" Then
            If list(0) = "" Then
                If DialogResult.OK = MessageBox.Show("If you accept the new expense will be inserted.", "Important", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) Then
                    If mtdHPW.insertExpensesUsed(list) Then
                        Return True
                    Else
                        Return False
                    End If
                Else
                    Return False
                End If
            Else
                If DialogResult.OK = MessageBox.Show("If you accept the expense will be updated.", "Important", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) Then
                    If mtdHPW.updateExpensesUsed(list) Then
                        Return True
                    Else
                        Return False
                    End If
                Else
                    Return False
                End If
            End If
        Else
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
    End Function
    Private Function recolectarDatosRecord() As Boolean
        Dim list As New List(Of String)
        Dim mensaje As String = ""
        Dim index = tblRecordEmployee.CurrentRow.Index - 1
        If tblRecordEmployee.Rows(index).Cells("idHorsWorked").Value IsNot DBNull.Value Then
            list.Add(tblRecordEmployee.Rows(index).Cells("idHorsWorked").Value)
        Else
            list.Add("")
        End If

        If tblRecordEmployee.Rows(0).Cells("Hours ST").Value IsNot DBNull.Value Then
            list.Add(tblRecordEmployee.Rows(index).Cells("Hours ST").Value)
        Else
            mensaje = If(mensaje = "", "Please assign some Hours.", vbCrLf + " Please assign some Hours")
        End If

        If tblRecordEmployee.Rows(index).Cells("Hours OT").Value IsNot DBNull.Value Then
            list.Add(tblRecordEmployee.Rows(index).Cells("Hours OT").Value)
        Else
            list.Add("0")
        End If

        If tblRecordEmployee.Rows(index).Cells("Hours 3").Value IsNot DBNull.Value Then
            list.Add(tblRecordEmployee.Rows(index).Cells("Hours 3").Value)
        Else
            list.Add("0")
        End If

        If Not flagPressCellDate Then
            list.Add(tblRecordEmployee.Rows(index).Cells("Date").Value)
        Else
            If tblRecordEmployee.Rows(index).Cells("Date").Value IsNot DBNull.Value Then
                list.Add(validaFechaParaSQl(tblRecordEmployee.Rows(index).Cells("Date").Value.ToString()))
            Else
                mensaje = If(mensaje = "", "Please choose a Date.", vbCrLf + " Please choose a Date")
            End If
        End If


        list.Add(idEmpleado)

        If tblRecordEmployee.Rows(index).Cells("Work Code").Value IsNot DBNull.Value Then
            For Each row As DataRow In workCodeTable.Rows
                If row.ItemArray(1) = tblRecordEmployee.Rows(index).Cells("Work Code").Value Then
                    list.Add(row.ItemArray(0)) 'workCode
                    Exit For
                End If
            Next
        Else
            mensaje = If(mensaje = "", "Please choose a Work Code.", vbCrLf + " Please choose a Work Code")
        End If

        If tblRecordEmployee.Rows(index).Cells("Project").Value IsNot DBNull.Value Then
            For Each row As DataRow In proyectTable.Rows
                If row.ItemArray(1) = tblRecordEmployee.Rows(index).Cells("Project").Value Then
                    list.Add(row.ItemArray(0)) '
                    Exit For
                End If
            Next
        Else
            mensaje = If(mensaje = "", "Please choose a Proyect.", vbCrLf + " Please choose a Proyect")
        End If


        If tblRecordEmployee.Rows(index).Cells("Shift").Value IsNot DBNull.Value Then
            list.Add(tblRecordEmployee.Rows(index).Cells("Shift").Value)
        Else
            mensaje = If(mensaje = "", "Please choose a Scheduel in the colum 'Shift'.", vbCrLf + " Please choose a Scheduel in the colum 'Shift'")
        End If

        If mensaje = "" Then
            If list(0) = "" Then
                If DialogResult.OK = MessageBox.Show("If you accept the new record will be inserted.", "Important", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) Then
                    If mtdHPW.InsertarRecord(list) Then
                        Return True
                    Else
                        Return False
                    End If
                Else
                    Return False
                End If
            Else
                If DialogResult.OK = MessageBox.Show("If you accept the record will be updated.", "Important", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) Then
                    If mtdHPW.updateRecord(list) Then
                        Return True
                    Else
                        Return False
                    End If
                Else
                    Return False
                End If
            End If
        Else
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
    End Function
    Private Function recolectarDatosRecord(ByVal index As Integer) As Boolean
        Dim list As New List(Of String)
        Dim mensaje As String = ""
        If tblRecordEmployee.Rows(index).Cells("idHorsWorked").Value IsNot DBNull.Value Then
            list.Add(tblRecordEmployee.Rows(index).Cells("idHorsWorked").Value)
        Else
            list.Add("")
        End If

        If tblRecordEmployee.Rows(0).Cells("Hours ST").Value IsNot DBNull.Value Then
            list.Add(tblRecordEmployee.Rows(index).Cells("Hours ST").Value)
        Else
            mensaje = If(mensaje = "", "Please assign some Hours.", vbCrLf + " Please assign some Hours")
        End If

        If tblRecordEmployee.Rows(index).Cells("Hours OT").Value IsNot DBNull.Value Then
            list.Add(tblRecordEmployee.Rows(index).Cells("Hours OT").Value)
        Else
            list.Add("0")
        End If

        If tblRecordEmployee.Rows(index).Cells("Hours 3").Value IsNot DBNull.Value Then
            list.Add(tblRecordEmployee.Rows(index).Cells("Hours 3").Value)
        Else
            list.Add("0")
        End If

        If Not flagPressCellDate Then
            list.Add(tblRecordEmployee.Rows(index).Cells("Date").Value)
        Else
            If tblRecordEmployee.Rows(index).Cells("Date").Value IsNot DBNull.Value Then
                list.Add(validaFechaParaSQl(tblRecordEmployee.Rows(index).Cells("Date").Value.ToString()))
            Else
                mensaje = If(mensaje = "", "Please choose a Date.", vbCrLf + " Please choose a Date")
            End If
        End If

        list.Add(idEmpleado)

        If tblRecordEmployee.Rows(index).Cells("Work Code").Value IsNot DBNull.Value Then
            For Each row As DataRow In workCodeTable.Rows
                If row.ItemArray(1) = tblRecordEmployee.Rows(index).Cells("Work Code").Value Then
                    list.Add(row.ItemArray(0)) 'workCode
                    Exit For
                End If
            Next
        Else
            mensaje = If(mensaje = "", "Please choose a Work Code.", vbCrLf + " Please choose a Work Code")
        End If

        If tblRecordEmployee.Rows(index).Cells("Project").Value IsNot DBNull.Value Then
            For Each row As DataRow In proyectTable.Rows
                If row.ItemArray(1) = tblRecordEmployee.Rows(index).Cells("Project").Value Then
                    list.Add(row.ItemArray(0)) '
                    Exit For
                End If
            Next
        Else
            mensaje = If(mensaje = "", "Please choose a Proyect.", vbCrLf + " Please choose a Proyect")
        End If


        If tblRecordEmployee.Rows(index).Cells("Shift").Value IsNot DBNull.Value Then
            list.Add(tblRecordEmployee.Rows(index).Cells("Shift").Value)
        Else
            mensaje = If(mensaje = "", "Please choose a Scheduel in the colum 'Shift'.", vbCrLf + " Please choose a Scheduel in the colum 'Shift'")
        End If

        If mensaje = "" Then
            If list(0) = "" Then
                If DialogResult.OK = MessageBox.Show("If you accept the new record will be inserted.", "Important", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) Then
                    If mtdHPW.InsertarRecord(list) Then
                        Return True
                    Else
                        Return False
                    End If
                Else
                    Return False
                End If
            Else
                If DialogResult.OK = MessageBox.Show("If you accept the record will be updated.", "Important", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) Then
                    If mtdHPW.updateRecord(list) Then
                        Return True
                    Else
                        Return False
                    End If
                Else
                    Return False
                End If
            End If
        Else
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
    End Function

    Private Sub btnLatsEmploye_Click(sender As Object, e As EventArgs) Handles btnLatsEmploye.Click
        If cmbEmpleados.Items.Count > 0 Then
            Dim cont As Integer = 0
            For Each row As DataRow In idsEmployees.Rows
                If cmbEmpleados.SelectedItem = row.ItemArray(1) Then
                    If cont = 0 Then
                        cont = idsEmployees.Rows.Count()
                    End If
                    idEmpleado = idsEmployees.Rows(cont - 1).ItemArray(0)
                    Exit For
                Else
                    cont = cont + 1
                End If
            Next
            cmbEmpleados.SelectedItem = idsEmployees.Rows(cont - 1).ItemArray(1)
        End If
    End Sub

    Private Sub btnNextEmploye_Click(sender As Object, e As EventArgs) Handles btnNextEmploye.Click
        If cmbEmpleados.Items.Count > 0 Then
            Dim cont As Integer = 0
            For Each row As DataRow In idsEmployees.Rows
                If cmbEmpleados.SelectedItem = row.ItemArray(1) Then
                    If cont = (idsEmployees.Rows.Count() - 1) Then
                        cont = -1
                    End If
                    idEmpleado = idsEmployees.Rows(cont + 1).ItemArray(0)
                    Exit For
                Else
                    cont = cont + 1
                End If
            Next
            cmbEmpleados.SelectedItem = idsEmployees.Rows(cont + 1).ItemArray(1)
        End If
    End Sub

    Private Sub btnExpenses_Click(sender As Object, e As EventArgs) Handles btnExpenses.Click
        Dim exp As New Expences
        exp.ShowDialog()
        mtdHPW.llenarTablaExpenses(expenseCodeTable)
    End Sub

    Public fechaStart, fechaEnd As Date
    Private Sub txtFindFecha_DoubleClick(sender As Object, e As EventArgs) Handles txtFindFecha.DoubleClick
        Dim auxF1 As Date = fechaStart
        Dim auxF2 As Date = fechaEnd
        Dim selectFecha As New SelectDate
        AddOwnedForm(selectFecha)
        selectFecha.ShowDialog()
        If fechaStart <> auxF1 Or fechaEnd <> auxF2 Then
            mtdHPW.buscarHoras(tblRecordEmployee, idEmpleado, validaFechaParaSQl(fechaStart), validaFechaParaSQl(fechaEnd))
        End If
    End Sub

    Private Sub txtFindFecha_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFindFecha.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Try
                Dim array = txtFindFecha.Text.Split(" ")
                If array.Count = 1 Then
                    Dim fecha1 As Date = validarFechaParaVB(array(0))
                    Dim fecha2 As Date = validarFechaParaVB(array(0))
                    mtdHPW.buscarHoras(tblRecordEmployee, idEmpleado, validaFechaParaSQl(fecha1), validaFechaParaSQl(fecha2))
                ElseIf array.Count = 3 Then
                    Dim fecha1 As Date = validarFechaParaVB(array(0))
                    Dim fecha2 As Date = validarFechaParaVB(array(2))
                    mtdHPW.buscarHoras(tblRecordEmployee, idEmpleado, validaFechaParaSQl(fecha1), validaFechaParaSQl(fecha2))
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub btnProyect_Click(sender As Object, e As EventArgs) Handles btnProyect.Click
        Dim proyectCost As New ProjectsCosts()
        proyectCost.ShowDialog()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If TabControl1.SelectedTab.Text = "Time Worked" Then
            If tblRecordEmployee.SelectedRows.Count > 0 Then
                For Each row As DataGridViewRow In tblRecordEmployee.SelectedRows
                    Dim idTask As String = ""
                    For Each fila As DataRow In proyectTable.Rows
                        If fila.ItemArray(1) = tblRecordEmployee.Rows(row.Index).Cells("Project").Value Then
                            idTask = fila.ItemArray(0)
                            Exit For
                        End If
                    Next
                    mtdHPW.deleteRecordEmployee(row.Cells("idHorsWorked").Value, idTask)
                Next
            End If
            mtdHPW.buscarHoras(tblRecordEmployee, idEmpleado)
            cargarDatos(idEmpleado)
        ElseIf TabControl1.SelectedTab.Text = "Expenses" Then
            If tblExpenses.SelectedRows.Count > 0 Then
                For Each row As DataGridViewRow In tblExpenses.SelectedRows
                    Dim idTask As String = ""
                    For Each fila As DataRow In proyectTable.Rows
                        If fila.ItemArray(1) = tblExpenses.Rows(row.Index).Cells("Project").Value Then
                            idTask = fila.ItemArray(0)
                            Exit For
                        End If
                    Next
                    mtdHPW.deleteExpense(row.Cells("idExpenseUsed").Value, idTask)
                Next
            End If
            mtdHPW.bucarExpensesEmpleado(tblExpenses, idEmpleado)
            cargarDatos(idEmpleado)
        End If
    End Sub
    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        If TabControl1.SelectedTab.Name = "tbpTimeWorked" Then
            Dim listError As New List(Of String)
            For Each row As DataGridViewRow In tblRecordEmployee.SelectedRows
                If Not recolectarDatosRecord(row.Index) Then
                    listError.Add(row.Cells(0).Value.ToString())
                End If
            Next
            If tblRecordEmployee.SelectedRows.Count() > 0 Then
                cargarDatos(idEmpleado)
            Else
                MessageBox.Show("Please chose a ROW.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            If listError.Count > 0 Then
                Dim cont As Integer = 0
                For Each row As DataGridViewRow In tblRecordEmployee.Rows
                    For Each dato As String In listError
                        If dato.Equals(row.Cells(0).Value) Then
                            tblRecordEmployee.Rows(row.Index).DefaultCellStyle.BackColor = Color.Orange
                        End If
                    Next
                Next
            End If
            flagPressCellDate = False
        ElseIf TabControl1.SelectedTab.Name = "tbpExpenses" Then
            Dim listError As New List(Of String)
            For Each row As DataGridViewRow In tblExpenses.SelectedRows
                If Not recolectarDatosExpenses(row.Index) Then
                    listError.Add(row.Cells(0).Value.ToString())
                End If
            Next
            If tblExpenses.SelectedRows.Count() > 0 Then
                cargarDatos(idEmpleado)
            Else
                MessageBox.Show("Please chose a ROW.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            If listError.Count > 0 Then
                For Each row As DataGridViewRow In tblExpenses.Rows
                    For Each dato As String In listError
                        If dato.Equals(row.Cells(0).Value) Then
                            tblExpenses.Rows(row.Index).DefaultCellStyle.BackColor = Color.Orange
                        End If
                    Next
                Next
            End If
            flagPressCellDateExpense = False
        End If
    End Sub

    Private Sub btnTime_Click(sender As Object, e As EventArgs) Handles btnTime.Click
        Dim timeSheet As New TimeSheet
        timeSheet.tablaEmpleadosId = idsEmployees
        timeSheet.tablaProject = proyectTable
        timeSheet.tablaWorkCodes = workCodeTable
        timeSheet.ShowDialog()
        cargarDatos(cmbEmpleados.SelectedItem)
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        cargarDatos(cmbEmpleados.SelectedItem)
    End Sub

End Class