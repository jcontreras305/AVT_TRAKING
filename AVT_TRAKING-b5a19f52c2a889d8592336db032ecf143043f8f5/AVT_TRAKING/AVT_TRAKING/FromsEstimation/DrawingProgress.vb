Imports System.Runtime.InteropServices

Public Class DrawingProgress
    Dim tblProjects As New Data.DataTable
    Dim tblDrawings As New Data.DataTable
    Dim tblScaffoldDR As New Data.DataTable
    Dim tblEquipmentDR As New Data.DataTable
    Dim tblPipiingDR As New Data.DataTable
    Dim mtdEstimation As New MetodosEstimating
    Dim mtdProgress As New MetodosProgress
    Dim _dtpWeekend1 As New DateTimePicker
    Dim _dtpWeekend2 As New DateTimePicker
    Dim _dtpWeekend3 As New DateTimePicker
    Dim _rectangulo As New Rectangle
    Dim flagPressCellDate As Boolean
    Dim idDrawing As String = ""
    Dim idProject As String = ""
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub DrawingProgress_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tblProjects = mtdProgress.selectProjects(cmbJobNo)
        tblDrawings = mtdProgress.selectProjectsDrawing("", cmbDrawing)
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

        tblPiping.Controls.Add(_dtpWeekend3)
        _dtpWeekend3.Visible = False
        _dtpWeekend3.Format = DateTimePickerFormat.Custom
        _dtpWeekend3.CustomFormat = "MM/dd/yyyy"
        AddHandler _dtpWeekend3.ValueChanged, AddressOf _dtpWeekend3_ValuesChangue
    End Sub

    Private Sub cmbJobNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbJobNo.SelectedIndexChanged
        Dim arrayPO() As String = cmbJobNo.SelectedItem.ToString.Split("|")
        tblDrawings = mtdProgress.selectProjectsDrawing(arrayPO(0), cmbDrawing)
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
    Private Sub cmbDrawing_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDrawing.SelectedIndexChanged
        Dim arrayDR() As String = cmbDrawing.SelectedItem.ToString.Split("|")
        idDrawing = arrayDR(0)
        limpiarTablas()
        Dim rowslist() As Data.DataRow = tblDrawings.Select("idDrawingNum = '" + idDrawing + "'")
        If rowslist.Length > 0 Then
            txtDescriptionDR.Text = rowslist(0).ItemArray(3)
            mtdProgress.selectSCFProgress(tblScaffold, idDrawing)
        Else
            txtDescriptionDR.Text = ""
        End If
    End Sub
    Private Sub tblScaffold_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles tblScaffold.CellClick
        Select Case tblScaffold.CurrentCell.ColumnIndex
            Case 3
                _rectangulo = New Rectangle
                _rectangulo = tblScaffold.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True)
                _dtpWeekend1.Size = New Size(_rectangulo.Width, _rectangulo.Height)
                _dtpWeekend1.Location = New Point(_rectangulo.X, _rectangulo.Y)
                _dtpWeekend1.Visible = True
                '_dtpWeekend1.Value = Date.Today()
                _dtpWeekend1.CustomFormat = "MM/dd/yyyy"
                _dtpWeekend1.BringToFront()
                If tblScaffold.CurrentCell.Value IsNot Nothing And tblScaffold.CurrentCell.Value IsNot DBNull.Value Then
                    flagPressCellDate = True
                    Dim arrayfechaCell() As String = tblScaffold.CurrentCell.Value.ToString.Split("/")
                    Dim fechaCell As Date = New Date(CInt(arrayfechaCell(2)), CInt(arrayfechaCell(0)), CInt(arrayfechaCell(1)))
                    _dtpWeekend1.Value = fechaCell.AddDays(If((7 - fechaCell.DayOfWeek) = 7, 0, (7 - fechaCell.DayOfWeek)))
                    flagPressCellDate = False
                Else
                    flagPressCellDate = True
                    _dtpWeekend1.Value = Date.Today.AddDays(If((7 - Date.Today.DayOfWeek) = 7, 0, (7 - Date.Today.DayOfWeek)))
                    flagPressCellDate = False
                End If
            Case 2
                Try
                    If tblScaffold.CurrentCell.GetType.Name = "DataGridViewTextBoxCell" Then
                        If idDrawing <> "" Then
                            Dim cellValue As String = If(tblScaffold.CurrentCell.Value Is Nothing Or tblScaffold.CurrentCell.Value Is DBNull.Value, "", tblScaffold.CurrentCell.Value.ToString())
                            Dim cmbProyect As New DataGridViewComboBoxCell
                            With cmbProyect
                                mtdProgress.llenarComboCellScaffold(cmbProyect, idDrawing)
                            End With
                            tblScaffold.CurrentRow.Cells("Tag") = cmbProyect
                            For Each item As String In cmbProyect.Items
                                If item = cellValue Then
                                    cmbProyect.Value = item
                                End If
                            Next
                        Else
                            tblScaffold.CurrentRow.Cells("Tag") = tblScaffold.CurrentCell
                        End If
                    End If
                Catch ex As Exception

                End Try
        End Select
    End Sub
    Private Sub _dtpWeekend1_ValuesChangue(sender As Object, e As EventArgs)
        If Not flagPressCellDate Then
            Dim fecha = _dtpWeekend1.Value.AddDays(7 - _dtpWeekend1.Value.DayOfWeek)
            tblScaffold.CurrentRow.Cells(3).Value = If(fecha.Month < 10, "0" + fecha.Month.ToString(), fecha.Month.ToString()) + "/" + If(fecha.Day < 10, "0" + fecha.Day.ToString(), fecha.Day.ToString()) + "/" + fecha.Year.ToString()
            _dtpWeekend1.Visible = False
        End If
    End Sub
    Private Sub tblEquipment_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles tblEquipment.CellClick
        Select Case tblEquipment.CurrentCell.ColumnIndex
            Case 3
                _rectangulo = New Rectangle
                _rectangulo = tblEquipment.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True)
                _dtpWeekend2.Size = New Size(_rectangulo.Width, _rectangulo.Height)
                _dtpWeekend2.Location = New Point(_rectangulo.X, _rectangulo.Y)
                '_dtpWeekend2.Value = Date.Today()
                _dtpWeekend2.CustomFormat = "MM/dd/yyyy"
                _dtpWeekend2.Visible = True
                _dtpWeekend2.BringToFront()
                If tblEquipment.CurrentCell.Value IsNot Nothing And tblEquipment.CurrentCell.Value IsNot DBNull.Value Then
                    flagPressCellDate = True
                    Dim arrayfechaCell() As String = tblEquipment.CurrentCell.Value.ToString.Split("/")
                    Dim fechaCell As Date = New Date(CInt(arrayfechaCell(2)), CInt(arrayfechaCell(0)), CInt(arrayfechaCell(1)))
                    _dtpWeekend2.Value = fechaCell.AddDays(If((7 - fechaCell.DayOfWeek) = 7, 0, (7 - fechaCell.DayOfWeek)))
                    flagPressCellDate = False
                Else
                    flagPressCellDate = True
                    _dtpWeekend2.Value = Date.Today.AddDays(If((7 - Date.Today.DayOfWeek) = 7, 0, (7 - Date.Today.DayOfWeek)))
                    flagPressCellDate = False
                End If
            Case 2
                Try
                    If tblEquipment.CurrentCell.GetType.Name = "DataGridViewTextBoxCell" Then
                        If idDrawing <> "" Then
                            Dim cellValue As String = If(tblEquipment.CurrentCell.Value Is Nothing Or tblEquipment.CurrentCell.Value Is DBNull.Value, "", tblEquipment.CurrentCell.Value.ToString())
                            Dim cmbProyect As New DataGridViewComboBoxCell
                            With cmbProyect
                                mtdProgress.llenarComboCellEquipment(cmbProyect, idDrawing)
                            End With
                            tblEquipment.CurrentRow.Cells("EquipmentId") = cmbProyect
                            For Each item As String In cmbProyect.Items
                                If item = cellValue Then
                                    cmbProyect.Value = item
                                End If
                            Next
                        End If
                    Else
                        tblEquipment.CurrentRow.Cells("EquipmentId") = tblEquipment.CurrentCell
                    End If
                Catch ex As Exception

                End Try
        End Select
    End Sub
    Private Sub _dtpWeekend2_ValuesChangue(sender As Object, e As EventArgs)
        If Not flagPressCellDate Then
            Dim fecha = _dtpWeekend2.Value.AddDays(7 - _dtpWeekend2.Value.DayOfWeek)
            tblEquipment.CurrentRow.Cells(3).Value = If(fecha.Month < 10, "0" + fecha.Month.ToString(), fecha.Month.ToString()) + "/" + If(fecha.Day < 10, "0" + fecha.Day.ToString(), fecha.Day.ToString()) + "/" + fecha.Year.ToString()
            _dtpWeekend2.Visible = False
        End If
    End Sub
    Private Sub tblPriping_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles tblPiping.CellClick
        Select Case tblPiping.CurrentCell.ColumnIndex
            Case 3
                _rectangulo = New Rectangle
                _rectangulo = tblPiping.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True)
                _dtpWeekend3.Size = New Size(_rectangulo.Width, _rectangulo.Height)
                _dtpWeekend3.Location = New Point(_rectangulo.X, _rectangulo.Y)
                _dtpWeekend3.CustomFormat = "MM/dd/yyyy"
                _dtpWeekend3.Visible = True
                _dtpWeekend3.BringToFront()
                If tblPiping.CurrentCell.Value IsNot Nothing And tblPiping.CurrentCell.Value IsNot DBNull.Value Then
                    flagPressCellDate = True
                    Dim arrayfechaCell() As String = tblPiping.CurrentCell.Value.ToString.Split("/")
                    Dim fechaCell As Date = New Date(CInt(arrayfechaCell(2)), CInt(arrayfechaCell(0)), CInt(arrayfechaCell(1)))
                    _dtpWeekend3.Value = fechaCell.AddDays(If((7 - fechaCell.DayOfWeek) = 7, 0, (7 - fechaCell.DayOfWeek)))
                    flagPressCellDate = False
                Else
                    flagPressCellDate = True
                    _dtpWeekend3.Value = Date.Today.AddDays(If((7 - Date.Today.DayOfWeek) = 7, 0, (7 - Date.Today.DayOfWeek)))
                    flagPressCellDate = False
                End If
            Case 2
                Try
                    If tblPiping.CurrentCell.GetType.Name = "DataGridViewTextBoxCell" Then
                        If idDrawing <> "" Then
                            Dim cellValue As String = If(tblPiping.CurrentCell.Value Is Nothing Or tblPiping.CurrentCell.Value Is DBNull.Value, "", tblPiping.CurrentCell.Value.ToString())
                            Dim cmbProyect As New DataGridViewComboBoxCell
                            With cmbProyect
                                mtdProgress.llenarComboCellPiping(cmbProyect, idDrawing)
                            End With
                            tblPiping.CurrentRow.Cells("PipingId") = cmbProyect
                            For Each item As String In cmbProyect.Items
                                If item = cellValue Then
                                    cmbProyect.Value = item
                                End If
                            Next
                        End If
                    Else
                        tblPiping.CurrentRow.Cells("PipingId") = tblPiping.CurrentCell
                    End If
                Catch ex As Exception

                End Try

        End Select
    End Sub
    Private Sub _dtpWeekend3_ValuesChangue(sender As Object, e As EventArgs)
        If Not flagPressCellDate Then
            Dim fecha = _dtpWeekend3.Value.AddDays(7 - _dtpWeekend3.Value.DayOfWeek)
            tblPiping.CurrentRow.Cells(3).Value = If(fecha.Month < 10, "0" + fecha.Month.ToString(), fecha.Month.ToString()) + "/" + If(fecha.Day < 10, "0" + fecha.Day.ToString(), fecha.Day.ToString()) + "/" + fecha.Year.ToString()
            _dtpWeekend3.Visible = False
        End If
    End Sub
    Private Sub tblPiping_Scroll(sender As Object, e As ScrollEventArgs) Handles tblPiping.Scroll
        _dtpWeekend3.Visible = False
    End Sub
    Private Sub tblEquipment_Scroll(sender As Object, e As ScrollEventArgs) Handles tblEquipment.Scroll
        _dtpWeekend2.Visible = False
    End Sub
    Private Sub tblScaffold_Scroll(sender As Object, e As ScrollEventArgs) Handles tblScaffold.Scroll
        _dtpWeekend1.Visible = False
    End Sub
    Public Sub cmb_SelectedIndexChangued_SCF(sender As Object, e As EventArgs)
        If flagPressCellDate Then
            Dim cmb As ComboBox = CType(sender, ComboBox)
            tblScaffold.CurrentCell.Value = cmb.Text
        End If
    End Sub
    Private Sub tblScaffold_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles tblScaffold.EditingControlShowing
        Dim Index = tblScaffold.CurrentCell.ColumnIndex
        If Index = 2 Then
            Dim typecell = tblScaffold.CurrentCell.GetType.ToString
            If Not typecell = "System.Windows.Forms.DataGridViewTextBoxCell" Then
                Dim cb As ComboBox = CType(e.Control, ComboBox)
                If e.Control IsNot Nothing Then
                    RemoveHandler cb.SelectedIndexChanged, AddressOf cmb_SelectedIndexChangued_SCF
                    AddHandler cb.SelectedIndexChanged, AddressOf cmb_SelectedIndexChangued_SCF
                End If
            End If
        End If
    End Sub
    Public Sub cmb_SelectedIndexChangued_Eq(sender As Object, e As EventArgs)
        If flagPressCellDate Then
            Dim cmb As ComboBox = CType(sender, ComboBox)
            tblEquipment.CurrentCell.Value = cmb.Text
        End If
    End Sub
    Private Sub tblEquipment_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles tblEquipment.EditingControlShowing
        Dim Index = tblEquipment.CurrentCell.ColumnIndex
        If Index = 2 Then
            Dim typecell = tblEquipment.CurrentCell.GetType.ToString
            If Not typecell = "System.Windows.Forms.DataGridViewTextBoxCell" Then
                Dim cb As ComboBox = CType(e.Control, ComboBox)
                If e.Control IsNot Nothing Then
                    RemoveHandler cb.SelectedIndexChanged, AddressOf cmb_SelectedIndexChangued_Eq
                    AddHandler cb.SelectedIndexChanged, AddressOf cmb_SelectedIndexChangued_Eq
                End If
            End If
        End If
    End Sub
    Public Sub cmb_SelectedIndexChangued_Pp(sender As Object, e As EventArgs)
        If flagPressCellDate Then
            Dim cmb As ComboBox = CType(sender, ComboBox)
            tblEquipment.CurrentCell.Value = cmb.Text
        End If
    End Sub
    Private Sub tblPiping_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles tblPiping.EditingControlShowing
        Dim Index = tblPiping.CurrentCell.ColumnIndex
        If Index = 2 Then
            Dim typecell = tblPiping.CurrentCell.GetType.ToString
            If Not typecell = "System.Windows.Forms.DataGridViewTextBoxCell" Then
                Dim cb As ComboBox = CType(e.Control, ComboBox)
                If e.Control IsNot Nothing Then
                    RemoveHandler cb.SelectedIndexChanged, AddressOf cmb_SelectedIndexChangued_Pp
                    AddHandler cb.SelectedIndexChanged, AddressOf cmb_SelectedIndexChangued_Pp
                End If
            End If
        End If
    End Sub
    Private Sub tblScaffold_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles tblScaffold.CellEndEdit
        Select Case tblScaffold.CurrentCell.ColumnIndex
            Case 4 To 5
                If tblScaffold.CurrentCell.Value = "" Then
                    tblScaffold.CurrentCell.Value = "0"
                ElseIf soloNumero(tblScaffold.CurrentCell.Value) Then
                    If CInt(tblScaffold.CurrentCell.Value) <= 100 And CInt(tblScaffold.CurrentCell.Value) >= 0 Then
                        tblScaffold.CurrentCell.Value = CStr(CInt(tblScaffold.CurrentCell.Value))
                    Else
                        MessageBox.Show("Plase writte a valid number.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        tblScaffold.CurrentCell.Value = "0"
                    End If
                End If
                If Not validaPorcentaje(tblScaffold, tblScaffold.CurrentCell.ColumnIndex, tblScaffold.Rows(tblScaffold.CurrentCell.RowIndex).Cells(2).Value) Then
                    MessageBox.Show("The percent inserted exceeded 100%, please check the values.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    tblScaffold.CurrentCell.Value = "0"
                End If
        End Select
    End Sub
    Private Sub tblEquipment_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles tblEquipment.CellEndEdit
        Select Case tblEquipment.CurrentCell.ColumnIndex
            Case 4 To 6
                If tblEquipment.CurrentCell.Value = "" Then
                    tblEquipment.CurrentCell.Value = "0"
                ElseIf soloNumero(tblEquipment.CurrentCell.Value) Then
                    If CInt(tblEquipment.CurrentCell.Value) <= 100 And CInt(tblEquipment.CurrentCell.Value) >= 0 Then
                        tblEquipment.CurrentCell.Value = CStr(CInt(tblEquipment.CurrentCell.Value))
                    Else
                        MessageBox.Show("Plase writte a valid number.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        tblEquipment.CurrentCell.Value = "0"
                    End If
                End If
                If Not validaPorcentaje(tblEquipment, tblEquipment.CurrentCell.ColumnIndex, tblEquipment.Rows(tblEquipment.CurrentCell.RowIndex).Cells(2).Value) Then
                    MessageBox.Show("The percent inserted exceeded 100%, please check the values.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    tblEquipment.CurrentCell.Value = "0"
                End If
        End Select
    End Sub
    Private Sub tblPiping_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles tblPiping.CellEndEdit
        Select Case tblPiping.CurrentCell.ColumnIndex
            Case 4 To 6
                If tblPiping.CurrentCell.Value = "" Then
                    tblPiping.CurrentCell.Value = "0"
                ElseIf soloNumero(tblPiping.CurrentCell.Value) Then
                    If CInt(tblPiping.CurrentCell.Value) <= 100 And CInt(tblPiping.CurrentCell.Value) >= 0 Then
                        tblPiping.CurrentCell.Value = CStr(CInt(tblPiping.CurrentCell.Value))
                    Else
                        MessageBox.Show("Plase writte a valid number.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        tblPiping.CurrentCell.Value = "0"
                    End If
                End If
                If Not validaPorcentaje(tblPiping, tblPiping.CurrentCell.ColumnIndex, tblPiping.Rows(tblPiping.CurrentCell.RowIndex).Cells(2).Value) Then
                    MessageBox.Show("The percent inserted exceeded 100%, please check the values.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    tblPiping.CurrentCell.Value = "0"
                End If
        End Select
    End Sub
    Private Sub limpiarTablas()
        tblScaffold.Rows.Clear()
        tblEquipment.Rows.Clear()
        tblPiping.Rows.Clear()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Select Case TabControl1.SelectedIndex
            Case 0
                If tblScaffold.SelectedRows.Count > 0 Then
                    If mtdProgress.saveUpdateSCFProgress(tblScaffold) Then
                        mtdProgress.selectSCFProgress(tblScaffold, idDrawing)
                    End If
                Else
                    MessageBox.Show("Please select a Row to Continue.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Case 1
                If tblEquipment.SelectedRows.Count > 0 Then
                    If mtdProgress.saveUpdateEqProgress(tblEquipment) Then
                        mtdProgress.selectEquipmentProgress(tblEquipment, idDrawing)
                    End If
                Else
                    MessageBox.Show("Please select a Row to Continue.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Case 2
                If tblPiping.SelectedRows.Count > 0 Then
                    If mtdProgress.saveUpdatePpProgress(tblPiping) Then
                        mtdProgress.selectPpProgress(tblPiping, idDrawing)
                    End If
                Else
                    MessageBox.Show("Please select a Row to Continue.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
        End Select
    End Sub

    Private Function validaPorcentaje(ByVal tbl As DataGridView, ByVal columnIndex As Integer, ByVal tag As String) As Boolean
        Try
            Dim totalPercent As Integer = 0
            Dim flag As Boolean = True
            For Each row As DataGridViewRow In tbl.Rows()
                If row.Cells(2).Value IsNot Nothing And row.Cells(2).Value = tag Then
                    totalPercent += CInt(If(row.Cells(columnIndex).Value Is Nothing, "0", row.Cells(columnIndex).Value))
                    If totalPercent > 100 Then
                        flag = False
                        Exit For
                    Else
                        flag = True
                    End If
                End If
            Next
            Return flag
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Select Case TabControl1.SelectedIndex
            Case 0
                If tblScaffold.SelectedRows.Count > 0 Then
                    If mtdProgress.deleteSCFProgress(tblScaffold) Then
                        For Each row In tblScaffold.SelectedRows
                            tblScaffold.Rows.Remove(row)
                        Next
                    End If
                Else
                    MessageBox.Show("Please select a Row to Continue.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Case 1
                If tblEquipment.SelectedRows.Count > 0 Then
                    If mtdProgress.deleteEquipmentProgress(tblEquipment) Then
                        For Each row In tblEquipment.SelectedRows
                            tblEquipment.Rows.Remove(row)
                        Next
                    End If
                Else
                    MessageBox.Show("Please select a Row to Continue.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Case 2
                If tblPiping.SelectedRows.Count > 0 Then
                    If mtdProgress.deletePipingProgress(tblPiping) Then
                        For Each row In tblPiping.SelectedRows
                            tblPiping.Rows.Remove(row)
                        Next
                    End If
                Else
                    MessageBox.Show("Please select a Row to Continue.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
        End Select
    End Sub
End Class