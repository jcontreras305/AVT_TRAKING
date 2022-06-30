Public Class ProjectsActuals
    Dim mtdProjectActual As New MetodosProjectsActuals
    Dim tblProjects As Data.DataTable
    Dim idProject As String = ""
    Dim _dtpDate1 As DateTimePicker
    Dim _dtpDate2 As DateTimePicker
    Dim _rectangle As Rectangle
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
            tblHours.CurrentRow.Cells(3).Value = If(fecha.Month < 10, "0" + fecha.Month.ToString(), fecha.Month.ToString()) + "/" + If(fecha.Day < 10, "0" + fecha.Day.ToString(), fecha.Day.ToString()) + "/" + fecha.Year.ToString()
            _dtpDate1.Visible = False
        End If
    End Sub
    Private Sub _dtpDate2_ValuesChangue(sender As Object, e As EventArgs)
        If Not flagPressCellDate Then
            Dim fecha = _dtpDate2.Value.AddDays(7 - _dtpDate2.Value.DayOfWeek)
            tblCost.CurrentRow.Cells(3).Value = If(fecha.Month < 10, "0" + fecha.Month.ToString(), fecha.Month.ToString()) + "/" + If(fecha.Day < 10, "0" + fecha.Day.ToString(), fecha.Day.ToString()) + "/" + fecha.Year.ToString()
            _dtpDate2.Visible = False
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

    Private Sub tblCost_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles tblCost.CellEndEdit
        _dtpDate2.Visible = False
    End Sub

    Private Sub tblHours_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles tblHours.CellEndEdit
        _dtpDate1.Visible = False
    End Sub
End Class