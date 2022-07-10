Imports System.Collections.Generic.List(Of Date)

Public Class ProjectsActuals
    Dim mtdProjectActual As New MetodosProjectsActuals
    Dim tblProjects As Data.DataTable
    Dim idProject As String = ""
    Dim _dtpDate1 As New DateTimePicker
    Dim _dtpDate2 As New DateTimePicker
    Dim _rectangle As New Rectangle
    Dim flagPressCellDate As Boolean = False
    Private Sub ProjectsActuals_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtClientNumber.Enabled = False
        txtDescriptionPO.Enabled = False
        txtUnitPO.Enabled = False
        tblProjects = mtdProjectActual.selectProjects(cmbJobNo)

        _dtpDate1.Visible = False
        _dtpDate1.Format = DateTimePickerFormat.Custom
        _dtpDate1.CustomFormat = "MM/dd/yyyy"
        AddHandler _dtpDate1.ValueChanged, AddressOf _dtpDate1_ValuesChangue
        tblHours.Controls.Add(_dtpDate1)
        _dtpDate2.Visible = False
        _dtpDate2.Format = DateTimePickerFormat.Custom
        _dtpDate2.CustomFormat = "MM/dd/yyyy"
        AddHandler _dtpDate2.ValueChanged, AddressOf _dtpDate2_ValuesChangue
        tblCost.Controls.Add(_dtpDate2)
    End Sub
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
    Private Sub cmbJobNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbJobNo.SelectedIndexChanged
        Dim arrayPO() As String = cmbJobNo.SelectedItem.ToString.Split("|")
        idProject = arrayPO(0)
        limpiarTablas()
        Dim rowslist() As Data.DataRow = tblProjects.Select("projectId = '" + idProject + "'")
        If rowslist.Length > 0 Then
            txtClientNumber.Text = rowslist(0).ItemArray(1)
            txtUnitPO.Text = rowslist(0).ItemArray(2)
            txtDescriptionPO.Text = rowslist(0).ItemArray(3)
            mtdProjectActual.SelectHoursProject(tblHours, idProject)
            For index = 3 To 6
                calcularTotalToDate(tblHours, tblHours.Rows(0), index, False)
            Next
            mtdProjectActual.SelectCostProject(tblCost, idProject)
            For index = 3 To 6
                calcularTotalToDate(tblCost, tblCost.Rows(0), index, True)
            Next
        Else
            txtDescriptionPO.Text = ""
            txtUnitPO.Text = ""
            txtClientNumber.Text = ""
        End If
    End Sub
    Private Sub limpiarTablas()
        tblCost.Rows.Clear()
        tblHours.Rows.Clear()
    End Sub
    Private Sub _dtpDate1_ValuesChangue(sender As Object, e As EventArgs)
        If Not flagPressCellDate Then
            Dim fecha = _dtpDate1.Value.AddDays(7 - _dtpDate1.Value.DayOfWeek)
            tblHours.CurrentRow.Cells(2).Value = If(fecha.Month < 10, "0" + fecha.Month.ToString(), fecha.Month.ToString()) + "/" + If(fecha.Day < 10, "0" + fecha.Day.ToString(), fecha.Day.ToString()) + "/" + fecha.Year.ToString()
            If Not isARepeatRow(tblHours, tblHours.CurrentRow) Then
                For index = 3 To 6
                    calcularTotalToDate(tblHours, tblHours.CurrentRow, index)
                    _dtpDate1.Visible = False
                Next
            Else
                MessageBox.Show("The Date Selected was used, please choose a diffrent Date.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub
    Private Sub _dtpDate2_ValuesChangue(sender As Object, e As EventArgs)
        If Not flagPressCellDate Then
            Dim fecha = _dtpDate2.Value.AddDays(7 - _dtpDate2.Value.DayOfWeek)
            tblCost.CurrentRow.Cells(2).Value = If(fecha.Month < 10, "0" + fecha.Month.ToString(), fecha.Month.ToString()) + "/" + If(fecha.Day < 10, "0" + fecha.Day.ToString(), fecha.Day.ToString()) + "/" + fecha.Year.ToString()
            If Not isARepeatRow(tblCost, tblCost.CurrentRow) Then
                For index = 3 To 6
                    calcularTotalToDate(tblCost, tblCost.CurrentRow, index, True)
                    _dtpDate2.Visible = False
                Next
            Else
                MessageBox.Show("The Date Selected was used, please choose a diffrent Date.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub

    Private Sub tblHours_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles tblHours.CellClick
        If e.ColumnIndex = 2 Then
            _rectangle = New Rectangle
            _rectangle = tblHours.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True)
            _dtpDate1.Size = New Size(_rectangle.Width, _rectangle.Height)
            _dtpDate1.Location = New Point(_rectangle.X, _rectangle.Y)
            _dtpDate1.CustomFormat = "MM/dd/yyyy"
            _dtpDate1.Visible = True
            _dtpDate1.BringToFront()
            If tblHours.CurrentCell.Value IsNot Nothing And tblHours.CurrentCell.Value IsNot DBNull.Value Then
                flagPressCellDate = True
                Dim arrayfechaCell() As String = tblHours.CurrentCell.Value.ToString.Split("/")
                Dim fechaCell As Date = New Date(CInt(arrayfechaCell(2)), CInt(arrayfechaCell(0)), CInt(arrayfechaCell(1)))
                _dtpDate1.Value = fechaCell.AddDays(If((7 - fechaCell.DayOfWeek) = 7, 0, (7 - fechaCell.DayOfWeek)))
                flagPressCellDate = False
            Else
                flagPressCellDate = True
                _dtpDate1.Value = Date.Today.AddDays(If((7 - Date.Today.DayOfWeek) = 7, 0, (7 - Date.Today.DayOfWeek)))
                flagPressCellDate = False
            End If
        End If
    End Sub

    Private Sub tblCost_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles tblCost.CellClick
        If e.ColumnIndex = 2 Then
            _rectangle = New Rectangle
            _rectangle = tblCost.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True)
            _dtpDate2.Size = New Size(_rectangle.Width, _rectangle.Height)
            _dtpDate2.Location = New Point(_rectangle.X, _rectangle.Y)
            _dtpDate2.CustomFormat = "MM/dd/yyyy"
            _dtpDate2.Visible = True
            _dtpDate2.BringToFront()
            If tblCost.CurrentCell.Value IsNot Nothing And tblCost.CurrentCell.Value IsNot DBNull.Value Then
                flagPressCellDate = True
                Dim arrayfechaCell() As String = tblCost.CurrentCell.Value.ToString.Split("/")
                Dim fechaCell As Date = New Date(CInt(arrayfechaCell(2)), CInt(arrayfechaCell(0)), CInt(arrayfechaCell(1)))
                _dtpDate2.Value = fechaCell.AddDays(If((7 - fechaCell.DayOfWeek) = 7, 0, (7 - fechaCell.DayOfWeek)))
                flagPressCellDate = False
            Else
                flagPressCellDate = True
                _dtpDate2.Value = Date.Today.AddDays(If((7 - Date.Today.DayOfWeek) = 7, 0, (7 - Date.Today.DayOfWeek)))
                flagPressCellDate = False
            End If
        End If
    End Sub
    Private Sub tblCost_Scroll(sender As Object, e As ScrollEventArgs) Handles tblCost.Scroll
        _dtpDate2.Visible = False
    End Sub

    Private Sub tblHours_Scroll(sender As Object, e As ScrollEventArgs) Handles tblHours.Scroll
        _dtpDate1.Visible = False
    End Sub

    Private Sub tblCost_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles tblCost.CellEndEdit
        _dtpDate2.Visible = False
        Select Case tblCost.CurrentCell.ColumnIndex
            Case 3 To 6
                If tblCost.CurrentCell.Value = "" Then
                    tblCost.CurrentCell.Value = "0"
                ElseIf soloNumero(tblCost.CurrentCell.Value) Then
                    If CInt(tblCost.CurrentCell.Value) >= 0 Then
                        tblCost.CurrentCell.Value = If(CInt(tblCost.CurrentCell.Value) = 0, "0.00", Math.Round(CDec(tblCost.CurrentCell.Value), 2, MidpointRounding.ToEven).ToString("#,###.00"))
                    Else
                        MessageBox.Show("Plase writte a valid number.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        tblCost.CurrentCell.Value = "0.00"
                    End If
                    calcularTotalToDate(tblCost, tblCost.Rows(e.RowIndex), e.ColumnIndex, True)
                End If
            Case 2
                For index = 3 To 6
                    calcularTotalToDate(tblCost, tblCost.Rows(e.RowIndex), index, True)
                Next
        End Select
    End Sub

    Private Sub tblHours_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles tblHours.CellEndEdit
        _dtpDate1.Visible = False
        Select Case tblHours.CurrentCell.ColumnIndex
            Case 3 To 6
                If tblHours.CurrentCell.Value = "" Then
                    tblHours.CurrentCell.Value = "0"
                ElseIf soloNumero(tblHours.CurrentCell.Value) Then
                    If CInt(tblHours.CurrentCell.Value) >= 0 Then
                        tblHours.CurrentCell.Value = If(CInt(tblHours.CurrentCell.Value) = 0, "0.0", Math.Round(CDec(tblHours.CurrentCell.Value), 1, MidpointRounding.ToEven).ToString("#,###.0"))
                    Else
                        MessageBox.Show("Plase writte a valid number.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        tblHours.CurrentCell.Value = "0.0"
                    End If
                    calcularTotalToDate(tblHours, tblHours.Rows(e.RowIndex), e.ColumnIndex)
                End If
        End Select
    End Sub
    Public Function calcularTotalToDate(ByVal tbl As DataGridView, ByVal row As DataGridViewRow, ByVal columnIndex As Integer, Optional money As Boolean = False) As Boolean
        Try
            If row.Cells(2).Value IsNot Nothing And row.Cells(2).Value IsNot DBNull.Value Then
                Dim dateUpdate As Date = validarFechaParaVB(row.Cells(2).Value)
                Dim total As Decimal = 0.0
                Dim dt As New Data.DataTable
                dt.Columns.Add("rowIndex")
                dt.Columns.Add("weekend")
                dt.Columns.Add("tick")
                dt.Columns.Add("totalToDate")
                Dim Count As Integer = 0
                For Each row1 As DataGridViewRow In tbl.Rows
                    If row1.Cells(2).Value IsNot Nothing And row1.Cells(2).Value IsNot DBNull.Value Then
                        dt.Rows.Add(Count, validarFechaParaVB(row1.Cells(2).Value), validarFechaParaVB(row1.Cells(2).Value).Ticks, 0)
                    End If
                    Count += 1
                Next
                dt.DefaultView.Sort = "tick ASC"
                Dim dtAux = dt.DefaultView.ToTable
                For Each rowTbl As DataGridViewRow In tbl.Rows
                    If rowTbl.Cells(2).Value IsNot Nothing And rowTbl.Cells(2).Value IsNot DBNull.Value Then
                        For Each rowDtAux As Data.DataRow In dtAux.Rows
                            Dim result = Date.Compare(validarFechaParaVB(rowTbl.Cells(2).Value), rowDtAux.ItemArray(1))
                            If result > -1 Then
                                total = total + CDec(tbl.Rows(rowDtAux.ItemArray(0)).Cells(columnIndex).Value)
                            End If
                        Next
                        If money Then
                            rowTbl.Cells(columnIndex + 4).Value = If(total = 0, "0.00", Math.Round(total, 2, MidpointRounding.ToEven).ToString("#,###.00"))
                        Else
                            rowTbl.Cells(columnIndex + 4).Value = If(total = 0, "0.0", Math.Round(total, 1, MidpointRounding.ToEven).ToString("#,###.0"))
                        End If
                    End If
                    total = 0.0
                Next
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function isARepeatRow(ByVal tbl As DataGridView, ByVal rowCompare As DataGridViewRow) As Boolean
        Try
            Dim flag As Boolean = False
            Dim count As Integer = 0
            For Each row As DataGridViewRow In tbl.Rows
                If row.Cells(2).Value IsNot Nothing And row.Cells(2).Value IsNot DBNull.Value Then
                    If row.Cells(2).Value = rowCompare.Cells(2).Value Then
                        count += 1
                    End If
                    If count > 1 Then
                        flag = True
                        Exit For
                    End If
                End If
            Next
            Return flag
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Select Case TabControl1.SelectedIndex
                Case 0
                    If tblHours.SelectedRows.Count > 0 And idProject <> "" Then
                        If mtdProjectActual.SaveUpdateHoursProject(tblHours, idProject) Then
                            mtdProjectActual.SelectHoursProject(tblHours, idProject)
                            For index = 3 To 6
                                calcularTotalToDate(tblHours, tblHours.Rows(0), index, False)
                            Next
                        End If
                    Else
                        MessageBox.Show("Please select a row to Continue.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                Case 1
                    If tblCost.SelectedRows.Count > 0 And idProject <> "" Then
                        If mtdProjectActual.SaveUpdateCostProject(tblCost, idProject) Then
                            mtdProjectActual.SelectCostProject(tblCost, idProject)
                            For index = 3 To 6
                                calcularTotalToDate(tblCost, tblCost.Rows(0), index, False)
                            Next
                        End If
                    Else
                        MessageBox.Show("Please select a row to Continue Or Select a Project.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            Select Case TabControl1.SelectedIndex
                Case 0
                    If tblHours.SelectedRows.Count > 0 And idProject <> "" Then
                        If DialogResult.Yes = MessageBox.Show("Are you sure to delete the rows selected?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                            If mtdProjectActual.deleteHoursProject(tblHours) Then
                                For Each row As DataGridViewRow In tblHours.SelectedRows
                                    tblHours.Rows.Remove(row)
                                Next
                                For index = 3 To 6
                                    calcularTotalToDate(tblHours, tblHours.CurrentRow, index)
                                    _dtpDate1.Visible = False
                                Next
                            End If
                        End If
                    Else
                        MessageBox.Show("Please select a row to Continue.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                Case 1
                    If tblCost.SelectedRows.Count > 0 And idProject <> "" Then
                        If DialogResult.Yes = MessageBox.Show("Are you sure to delete the rows selected?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                            If mtdProjectActual.deleteCostProject(tblCost) Then
                                For Each row As DataGridViewRow In tblCost.SelectedRows
                                    tblCost.Rows.Remove(row)
                                Next
                                For index = 3 To 6
                                    calcularTotalToDate(tblCost, tblCost.CurrentRow, index)
                                    _dtpDate1.Visible = False
                                Next
                            End If
                        End If
                    Else
                        MessageBox.Show("Please select a row to Continue Or Select a Project.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub
End Class