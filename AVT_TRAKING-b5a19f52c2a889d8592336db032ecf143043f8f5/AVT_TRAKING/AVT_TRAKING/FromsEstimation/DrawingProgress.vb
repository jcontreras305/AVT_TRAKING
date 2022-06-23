Imports System.Runtime.InteropServices

Public Class DrawingProgress
    Dim tblProjects As New Data.DataTable
    Dim tblDrawings As New Data.DataTable
    Dim mtdEstimation As New MetodosEstimating
    Dim mtdProgress As New MetodosProgress
    Dim _dtpWeekend1 As New DateTimePicker
    Dim _dtpWeekend2 As New DateTimePicker
    Dim _rectangulo As New Rectangle
    Dim flagPressCellDate As Boolean
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub DrawingProgress_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tblProjects = mtdEstimation.selectProjectsDrawing
        tblDrawings = mtdEstimation.selectProjectsDrawing
        mtdProgress.selectSCFProgress(tblScaffold, "")
        tblScaffold.Controls.Add(_dtpWeekend1)
        _dtpWeekend1.Visible = False
        _dtpWeekend1.Format = DateTimePickerFormat.Custom
        _dtpWeekend1.CustomFormat = "MM/dd/yyyy"
        AddHandler _dtpWeekend1.ValueChanged, AddressOf _dtpWeekend1_ValuesChangue
        tblEquipment.Controls.Add(_dtpWeekend2)
        _dtpWeekend2.Visible = False
        _dtpWeekend2.Format = DateTimePickerFormat.Custom
        _dtpWeekend2.CustomFormat = "MM/dd/yyyy"
        AddHandler _dtpWeekend2.ValueChanged, AddressOf _dtpWeekend2_ValuesChangue
    End Sub

    Private Sub cmbDrawing_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDrawing.SelectedIndexChanged

    End Sub

    Private Sub tblScaffold_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles tblScaffold.CellClick
        Select Case tblScaffold.CurrentCell.ColumnIndex
            Case 3
                _rectangulo = New Rectangle
                _rectangulo = tblScaffold.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True)
                _dtpWeekend1.Size = New Size(_rectangulo.Width, _rectangulo.Height)
                _dtpWeekend1.Location = New Point(_rectangulo.X, _rectangulo.Y)
                _dtpWeekend1.Visible = True
                _dtpWeekend1.Value = Date.Today()
                _dtpWeekend1.CustomFormat = "MM/dd/yyyy"
                _dtpWeekend1.BringToFront()
        End Select
    End Sub

    Private Sub _dtpWeekend1_ValuesChangue(sender As Object, e As EventArgs)
        Dim fecha = _dtpWeekend1.Value.AddDays(7 - _dtpWeekend1.Value.DayOfWeek)
        tblScaffold.CurrentRow.Cells(3).Value = fecha.ToShortDateString
    End Sub

    Private Sub tblEquipment_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles tblEquipment.CellClick
        Select Case tblEquipment.CurrentCell.ColumnIndex
            Case 3
                _rectangulo = New Rectangle
                _rectangulo = tblEquipment.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True)
                _dtpWeekend2.Size = New Size(_rectangulo.Width, _rectangulo.Height)
                _dtpWeekend2.Location = New Point(_rectangulo.X, _rectangulo.Y)
                _dtpWeekend2.Value = Date.Today()
                _dtpWeekend2.CustomFormat = "MM/dd/yyyy"
                _dtpWeekend2.Visible = True
                _dtpWeekend2.BringToFront()
        End Select
    End Sub

    Private Sub _dtpWeekend2_ValuesChangue(sender As Object, e As EventArgs)
        Dim fecha = _dtpWeekend1.Value.AddDays(7 - _dtpWeekend1.Value.DayOfWeek)
        tblEquipment.CurrentRow.Cells(3).Value = fecha.ToShortDateString
    End Sub
End Class