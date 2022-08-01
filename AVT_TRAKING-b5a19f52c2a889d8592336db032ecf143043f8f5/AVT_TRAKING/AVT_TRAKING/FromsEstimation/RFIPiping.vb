Public Class RFIPiping
    Dim idDrawingNum As String = ""
    Dim idTagPp As String = ""
    Dim mtdRFIPiping As New MetodosRFIPiping
    Dim tbltagPp As New Data.DataTable
    Dim tblDr As New Data.DataTable
    Dim tblRFIPipingHistory As New Data.DataTable
    Dim tblSystemOption As New Data.DataTable
    Dim tblTypeThick As New Data.DataTable
    Private Sub RFIPiping_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        startRowsTable()

        tblDr = mtdRFIPiping.selectDrawing(cmbDrawing)
        tbltagPp = mtdRFIPiping.selectTagDrawing("", cmbTag)
        tblSystemOption = mtdRFIPiping.selectPpPntUnitRate()
        tblTypeThick = mtdRFIPiping.selectPpInsUnitRate
    End Sub
    Private Sub startRowsTable()
        For index = 1 To 2
            tblGeneral.Rows.Add()
            tblPaint.Rows.Add()
            tblInsulation.Rows.Add()
        Next
        tblMaterialDescription.Rows.Add("Paint", "Old")
        tblMaterialDescription.Rows.Add("", "New")
        tblMaterialDescription.Rows.Add("Removal", "Old")
        tblMaterialDescription.Rows.Add("", "New")
        tblMaterialDescription.Rows.Add("Install", "Old")
        tblMaterialDescription.Rows.Add("", "New")
        tblGeneral.Rows(0).Cells(0).Value = "Old"
        tblGeneral.Rows(1).Cells(0).Value = "New"
        tblMaterialDescription.Rows(0).DefaultCellStyle.BackColor = Color.LightBlue
        tblMaterialDescription.Rows(2).DefaultCellStyle.BackColor = Color.Yellow
        tblMaterialDescription.Rows(4).DefaultCellStyle.BackColor = Color.DarkOrange

        doInvalidCellsMaterialDescription()

        tblGeneral.Rows(0).DefaultCellStyle.BackColor = Color.LightGray
        tblPaint.Rows(0).DefaultCellStyle.BackColor = Color.LightGray
        tblInsulation.Rows(0).DefaultCellStyle.BackColor = Color.LightGray
        tblMaterialDescription.Rows(0).ReadOnly = True
        tblMaterialDescription.Rows(2).ReadOnly = True
        tblMaterialDescription.Rows(4).ReadOnly = True
        tblGeneral.Rows(0).ReadOnly = True
        tblPaint.Rows(0).ReadOnly = True
        tblInsulation.Rows(0).ReadOnly = True
        tblGeneral.DefaultCellStyle.ForeColor = Color.Black
        tblPaint.DefaultCellStyle.ForeColor = Color.Black
        tblInsulation.DefaultCellStyle.ForeColor = Color.Black
        tblMaterialDescription.DefaultCellStyle.ForeColor = Color.Black
    End Sub
    Private Sub doInvalidCellsMaterialDescription()
        Dim invalidCell() As Integer = {6, 8, 9, 14, 15}
        Dim invalidColorCell As Color = Color.FromArgb(83, 93, 102)
        For index = 0 To 1
            For Each cell As DataGridViewCell In tblMaterialDescription.Rows(index).Cells
                If invalidCell.ToList().Contains(cell.ColumnIndex) Then
                    tblMaterialDescription.Rows(index).Cells(cell.ColumnIndex).Style.BackColor = invalidColorCell
                    tblMaterialDescription.Rows(index).Cells(cell.ColumnIndex).ReadOnly = True
                End If
            Next
        Next
        invalidCell = {4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15}
        For index = 2 To 3
            For Each cell As DataGridViewCell In tblMaterialDescription.Rows(index).Cells
                If invalidCell.ToList().Contains(cell.ColumnIndex) Then
                    tblMaterialDescription.Rows(index).Cells(cell.ColumnIndex).Style.BackColor = invalidColorCell
                    tblMaterialDescription.Rows(index).Cells(cell.ColumnIndex).ReadOnly = True
                End If
            Next
        Next
        tblMaterialDescription.Rows(1).Cells(0).Style.BackColor = invalidColorCell
        tblMaterialDescription.Rows(3).Cells(0).Style.BackColor = invalidColorCell
        tblMaterialDescription.Rows(5).Cells(0).Style.BackColor = invalidColorCell
        tblMaterialDescription.Rows(1).Cells(0).ReadOnly = True
        tblMaterialDescription.Rows(3).Cells(0).ReadOnly = True
        tblMaterialDescription.Rows(5).Cells(0).ReadOnly = True
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub tblGeneral_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles tblGeneral.CellEndEdit
        If e.ColumnIndex > 0 Then
            validaCeldaSoloNumero(tblGeneral, e.ColumnIndex)
        End If
    End Sub
    Private Sub tblInsulation_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles tblInsulation.CellEndEdit
        Select Case e.ColumnIndex
            Case 0
                If tblInsulation.Rows(1).Cells(1).Value IsNot Nothing And tblTypeThick.Rows IsNot Nothing Then
                    If tblInsulation.Rows(1).Cells(1).Value <> "" Then
                        Dim listRows() As Data.DataRow = tblTypeThick.Select("type = '" + tblInsulation.Rows(1).Cells(0).Value.ToString() + "' and thick = '" + tblInsulation.Rows(1).Cells(1).Value.ToString() + "'")
                        If listRows.Length = 0 Then
                            MessageBox.Show("Do not exist this Material Type with the Thick selected try to choose a different thick.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            listRows = tblTypeThick.Select("type = '" + tblInsulation.Rows(1).Cells(0).Value.ToString() + "'")
                            If listRows.Length > 0 Then
                                tblInsulation.Rows(1).Cells(1).Value = listRows(0).ItemArray(2)
                            Else
                                tblInsulation.Rows(1).Cells(0).Value = "0"
                            End If
                        End If
                    ElseIf tblInsulation.Rows(1).Cells(0).Value <> "" Then
                        Dim listRows() As Data.DataRow = tblTypeThick.Select("type = '" + tblInsulation.Rows(1).Cells(0).Value.ToString() + "' and thick = '" + tblInsulation.Rows(0).Cells(1).Value.ToString() + "'")
                        If listRows.Length = 0 Then
                            MessageBox.Show("Do not exist this Material Type with the Thick selected try to choose a different thick.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            listRows = tblTypeThick.Select("type = '" + tblInsulation.Rows(1).Cells(0).Value.ToString() + "'")
                            If listRows.Length > 0 Then
                                tblInsulation.Rows(1).Cells(1).Value = listRows(0).ItemArray(2)
                            Else
                                tblInsulation.Rows(1).Cells(0).Value = "0"
                            End If
                        End If
                    End If
                End If
            Case 1
                validaCeldaSoloNumero(tblInsulation, e.ColumnIndex)
                If tblInsulation.Rows(1).Cells(0).Value IsNot Nothing And tblTypeThick.Rows IsNot Nothing Then
                    If tblInsulation.Rows(1).Cells(0).Value <> "" Then
                        Dim listRows() As Data.DataRow = tblTypeThick.Select("type = '" + tblInsulation.Rows(1).Cells(0).Value.ToString() + "' and thick = '" + tblInsulation.Rows(1).Cells(1).Value.ToString() + "'")
                        If listRows.Length = 0 Then
                            MessageBox.Show("Do not exist this Material Type with the Thick selected try to choose a different thick.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            tblInsulation.Rows(1).Cells(1).Value = "0"
                        End If
                    ElseIf tblInsulation.Rows(0).Cells(0).Value <> "" Then
                        Dim listRows() As Data.DataRow = tblTypeThick.Select("type = '" + tblInsulation.Rows(0).Cells(0).Value.ToString() + "' and thick = '" + tblInsulation.Rows(0).Cells(1).Value.ToString() + "'")
                        If listRows.Length = 0 Then
                            MessageBox.Show("Do not exist this Material Type with the Thick selected try to choose a different thick.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            tblInsulation.Rows(1).Cells(1).Value = "0"
                        End If
                    End If
                End If
        End Select
    End Sub
    Private Sub tblMaterialDescription_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles tblMaterialDescription.CellEndEdit
        If e.ColumnIndex > 2 Then
            validaCeldaSoloNumero(tblMaterialDescription, e.ColumnIndex, e.RowIndex)
        End If
    End Sub
    Private Sub validaCeldaSoloNumero(ByVal tbl As DataGridView, ByVal columnIndex As Integer, Optional rowIndex As Integer = 1)
        Try
            If tbl.Rows(rowIndex).Cells(columnIndex).Value IsNot DBNull.Value And tbl.Rows(rowIndex).Cells(columnIndex).Value <> "" Then
                If soloNumero(tbl.Rows(rowIndex).Cells(columnIndex).Value) Then
                    If Not CDec(tbl.Rows(rowIndex).Cells(columnIndex).Value) >= 0 Then
                        MessageBox.Show("Please enter a valid number.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        tbl.Rows(rowIndex).Cells(columnIndex).Value = "0"
                    End If
                Else
                    MessageBox.Show("Please enter a valid number.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    tbl.Rows(rowIndex).Cells(columnIndex).Value = "0"
                End If
            Else
                tbl.Rows(rowIndex).Cells(columnIndex).Value = "0"
            End If
        Catch ex As Exception
            MessageBox.Show("Please enter a valid number.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Private Sub limpiarTablas(ByVal isNew As Boolean)
        If isNew Then
            For Each cell As DataGridViewCell In tblGeneral.Rows(0).Cells
                If cell.ColumnIndex = 0 Then
                    cell.Value = "Old"
                Else
                    cell.Value = ""
                End If
            Next
            For Each cell As DataGridViewCell In tblPaint.Rows(0).Cells
                cell.Value = ""
            Next
            For Each cell As DataGridViewCell In tblInsulation.Rows(0).Cells
                cell.Value = ""
            Next
        End If

        tblGeneral.Rows.Remove(tblGeneral.Rows(1))
        tblGeneral.Rows.Add("New")
        tblPaint.Rows.Remove(tblPaint.Rows(1))
        tblPaint.Rows.Add("", "")
        tblInsulation.Rows.Remove(tblInsulation.Rows(1))
        tblInsulation.Rows.Add("", "", "")

        tblMaterialDescription.Rows.Remove(tblMaterialDescription.Rows(5))
        tblMaterialDescription.Rows.Remove(tblMaterialDescription.Rows(3))
        tblMaterialDescription.Rows.Remove(tblMaterialDescription.Rows(1))

        tblMaterialDescription.Rows.Insert(1, {"", "New"})
        tblMaterialDescription.Rows.Insert(3, {"", "New"})
        tblMaterialDescription.Rows.Insert(5, {"", "New"})
        doInvalidCellsMaterialDescription()
    End Sub

    Private Sub limpiarInfoExtra()
        txtNameReq.Text = ""
        txtNameUpdate.Text = ""
        txtTitleReq.Text = ""
        txtTitleUpdate.Text = ""
        txtNote.Text = ""
        txtBasicForNum.Text = ""
        txtCompanyReq.Text = ""
        txtIdRFIPiping.Text = ""
        dtpDateReq.Value = Today.Date
        dtpDateUpdate.Value = Today.Date
        dtpDateWE.Value = Today.Date
    End Sub

    Private Sub cmbDrawing_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDrawing.SelectedIndexChanged
        Try
            If cmbDrawing.SelectedItem IsNot Nothing Then
                Dim array() As String = cmbDrawing.SelectedItem.ToString.Split("|")
                If array.Length > 0 Then
                    If idDrawingNum <> array(0) Then
                        idDrawingNum = array(0)
                        idTagPp = ""
                        tbltagPp = mtdRFIPiping.selectTagDrawing(idDrawingNum, cmbTag)
                        tblDr = mtdRFIPiping.selectDrawing() 'consultamos la tabla por si cambio algun valor 
                        limpiarTablas(False)
                        limpiarInfoExtra()
                        'llenamos los campo de job y drawing en la parte de arriba 
                        Dim rowsList() As Data.DataRow = tblDr.Select("idDrawingNum = '" + idDrawingNum + "'")
                        If rowsList.Length > 0 Then
                            txtJobNum.Text = rowsList(0).ItemArray(0)
                            txtDescriptionPO.Text = rowsList(0).ItemArray(1)
                            txtDescriptionDR.Text = rowsList(0).ItemArray(3)
                            txtUnitPO.Text = rowsList(0).ItemArray(4)
                            txtClientNumber.Text = rowsList(0).ItemArray(5)
                        Else
                            MessageBox.Show("Is probably that the drawing was deleted or updated please try again or close this Window.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmbTag_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTag.SelectedIndexChanged
        Try
            If cmbTag.SelectedItem IsNot Nothing And idDrawingNum <> "" Then
                idTagPp = cmbTag.SelectedItem.ToString()
                tbltagPp = mtdRFIPiping.selectTagDrawing(idDrawingNum)
                tblRFIPipingHistory = mtdRFIPiping.selectRFIPiping(idTagPp, idDrawingNum)
                Dim rowsList() As Data.DataRow = tbltagPp.Select("idTag = '" + idTagPp + "' and idDrawingNum = '" + idDrawingNum + "'")
                limpiarTablas(True)
                limpiarInfoExtra()
                llenarTablaHistory()
                If rowsList.Length > 0 Then
                    tblGeneral.Rows(0).Cells(1).Value = rowsList(0).ItemArray(1)
                    tblGeneral.Rows(0).Cells(2).Value = rowsList(0).ItemArray(2)

                    tblPaint.Rows(0).Cells(0).Value = rowsList(0).ItemArray(3).ToString()
                    tblPaint.Rows(0).Cells(1).Value = rowsList(0).ItemArray(4).ToString()

                    tblInsulation.Rows(0).Cells(0).Value = rowsList(0).ItemArray(5).ToString()
                    tblInsulation.Rows(0).Cells(1).Value = rowsList(0).ItemArray(6).ToString()
                    tblInsulation.Rows(0).Cells(2).Value = rowsList(0).ItemArray(7).ToString()

                    tblMaterialDescription.Rows(0).Cells(2).Value = rowsList(0).ItemArray(8).ToString()
                    tblMaterialDescription.Rows(0).Cells(3).Value = rowsList(0).ItemArray(9).ToString()
                    tblMaterialDescription.Rows(0).Cells(4).Value = rowsList(0).ItemArray(10).ToString()
                    tblMaterialDescription.Rows(0).Cells(5).Value = rowsList(0).ItemArray(11).ToString()
                    tblMaterialDescription.Rows(0).Cells(7).Value = rowsList(0).ItemArray(12).ToString()
                    tblMaterialDescription.Rows(0).Cells(10).Value = rowsList(0).ItemArray(13).ToString()
                    tblMaterialDescription.Rows(0).Cells(11).Value = rowsList(0).ItemArray(14).ToString()
                    tblMaterialDescription.Rows(0).Cells(12).Value = rowsList(0).ItemArray(15).ToString()
                    tblMaterialDescription.Rows(0).Cells(13).Value = rowsList(0).ItemArray(16).ToString()

                    tblMaterialDescription.Rows(2).Cells(2).Value = rowsList(0).ItemArray(17).ToString()
                    tblMaterialDescription.Rows(2).Cells(3).Value = rowsList(0).ItemArray(18).ToString()

                    tblMaterialDescription.Rows(4).Cells(2).Value = rowsList(0).ItemArray(19).ToString()
                    tblMaterialDescription.Rows(4).Cells(3).Value = rowsList(0).ItemArray(20).ToString()
                    tblMaterialDescription.Rows(4).Cells(4).Value = rowsList(0).ItemArray(21).ToString()
                    tblMaterialDescription.Rows(4).Cells(5).Value = rowsList(0).ItemArray(22).ToString()
                    tblMaterialDescription.Rows(4).Cells(6).Value = rowsList(0).ItemArray(23).ToString()
                    tblMaterialDescription.Rows(4).Cells(7).Value = rowsList(0).ItemArray(24).ToString()
                    tblMaterialDescription.Rows(4).Cells(8).Value = rowsList(0).ItemArray(25).ToString()
                    tblMaterialDescription.Rows(4).Cells(9).Value = rowsList(0).ItemArray(26).ToString()
                    tblMaterialDescription.Rows(4).Cells(10).Value = rowsList(0).ItemArray(27).ToString()
                    tblMaterialDescription.Rows(4).Cells(11).Value = rowsList(0).ItemArray(28).ToString()
                    tblMaterialDescription.Rows(4).Cells(12).Value = rowsList(0).ItemArray(29).ToString()
                    tblMaterialDescription.Rows(4).Cells(13).Value = rowsList(0).ItemArray(30).ToString()
                    tblMaterialDescription.Rows(4).Cells(14).Value = rowsList(0).ItemArray(31).ToString()
                    tblMaterialDescription.Rows(4).Cells(15).Value = rowsList(0).ItemArray(32).ToString()

                Else
                    MessageBox.Show("Is probably that the drawing was deleted or updated please try again or close this window.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub llenarTablaHistory()
        If tblRFIPipingHistory IsNot Nothing Then
            If tblRFIPipingHistory.Rows IsNot Nothing Then
                tblHistoryRFIPiping.Rows.Clear()
                For Each row As Data.DataRow In tblRFIPipingHistory.Rows
                    tblHistoryRFIPiping.Rows.Add(row.ItemArray(0), row.ItemArray(21), row.ItemArray(23))
                Next
            End If
        End If
    End Sub

    Private Sub tblGeneral_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles tblGeneral.CellMouseClick
        Try
            If tblGeneral.CurrentCell.RowIndex = 1 Then
                Select Case tblGeneral.CurrentCell.ColumnIndex
                    Case 2 'Height
                        If tblGeneral.CurrentCell.GetType.Name = "DataGridViewTextBoxCell" Then
                            Dim cmbHeigth As New DataGridViewComboBoxCell
                            With cmbHeigth
                                mtdRFIPiping.llenarComboElvPaint(cmbHeigth, If(tblGeneral.CurrentCell.Value IsNot Nothing, tblGeneral.CurrentCell.Value, ""))
                                .DropDownWidth = If(tblGeneral.CurrentCell.Size.Width < 50, 50, tblGeneral.CurrentCell.Size.Width)
                            End With
                            tblGeneral.CurrentRow.Cells("HeigthPp") = cmbHeigth
                        End If
                End Select
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tblGeneral_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles tblGeneral.EditingControlShowing
        Dim Index = tblGeneral.CurrentCell.ColumnIndex
        If Index = 2 Then
            Dim typecell = tblGeneral.CurrentCell.GetType.ToString
            If Not typecell = "System.Windows.Forms.DataGridViewTextBoxCell" Then
                Dim cb As ComboBox = CType(e.Control, ComboBox)
                If e.Control IsNot Nothing Then
                    RemoveHandler cb.SelectedIndexChanged, AddressOf cmb_SelectedIndexChanguedHeigth
                    AddHandler cb.SelectedIndexChanged, AddressOf cmb_SelectedIndexChanguedHeigth
                End If
            End If
        End If
    End Sub
    Public Sub cmb_SelectedIndexChanguedHeigth(sender As Object, e As EventArgs)
        Try
            Dim cmb As ComboBox = CType(sender, ComboBox)
            Select Case tblGeneral.CurrentCell.ColumnIndex
                Case 2
                    tblGeneral.CurrentCell.Value = cmb.Text
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tblPaint_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles tblPaint.CellMouseClick
        Try
            If tblPaint.CurrentCell.RowIndex = 1 Then
                Select Case tblPaint.CurrentCell.ColumnIndex
                    Case 0 'System   
                        If tblPaint.CurrentCell.GetType.Name = "DataGridViewTextBoxCell" Then
                            Dim cmbSystem As New DataGridViewComboBoxCell
                            With cmbSystem
                                llenarCmbSystemOption(cmbSystem, 0, If(tblPaint.CurrentCell.Value IsNot Nothing, tblPaint.CurrentCell.Value, ""))
                                .DropDownWidth = If(tblPaint.CurrentCell.Size.Width < 50, 50, tblPaint.CurrentCell.Size.Width)
                            End With
                            tblPaint.CurrentRow.Cells("SystemPp") = cmbSystem
                            'ElseIf tblPaint.CurrentCell.GetType.Name = "DataGridViewComboBoxCell" Then
                            '    If tblPaint.Rows(1).Cells(1).GetType.Name = "DataGridViewTextBoxCell" Then
                            '        llenarCmbSystemOption(tblPaint.Rows(1).Cells(1), 1, tblPaint.Rows(1).Cells(1).Value, tblPaint.Rows(1).Cells(0).Value)
                            '    End If
                        End If
                    Case 1 'Optionn   
                        If tblPaint.CurrentCell.GetType.Name = "DataGridViewTextBoxCell" Then
                            Dim SystemSelected As String = ""
                            If tblPaint.Rows(1).Cells("SystemPp").Value IsNot Nothing Then
                                If tblPaint.Rows(1).Cells("SystemPp").Value <> "" Then
                                    SystemSelected = tblPaint.Rows(1).Cells("SystemPp").Value
                                Else
                                    If tblPaint.Rows(0).Cells("SystemPp").Value IsNot Nothing Then
                                        If tblPaint.Rows(0).Cells("SystemPp").Value <> "" Then
                                            SystemSelected = tblPaint.Rows(0).Cells("SystemPp").Value
                                        End If
                                    End If
                                End If
                            Else
                                If tblPaint.Rows(0).Cells("SystemPp").Value IsNot Nothing Then
                                    If tblPaint.Rows(0).Cells("SystemPp").Value <> "" Then
                                        SystemSelected = tblPaint.Rows(1).Cells("SystemPp").Value
                                    End If
                                End If
                            End If
                            Dim cmbOption As New DataGridViewComboBoxCell
                            With cmbOption
                                llenarCmbSystemOption(cmbOption, 1, If(tblPaint.CurrentCell.Value IsNot Nothing, tblPaint.CurrentCell.Value, ""), SystemSelected)
                                .DropDownWidth = If(tblPaint.CurrentCell.Size.Width < 50, 50, tblPaint.CurrentCell.Size.Width)
                            End With
                            tblPaint.CurrentRow.Cells("optionPp") = cmbOption
                        End If
                End Select
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub llenarCmbSystemOption(ByVal cmb As DataGridViewComboBoxCell, ByVal columnIndex As Integer, Optional cellValue As String = "", Optional system As String = "")
        Try
            If tblSystemOption.Rows IsNot Nothing Then
                Dim listAux As New List(Of String)
                Dim flag As Boolean = False
                cmb.Items.Clear()
                For Each row As Data.DataRow In tblSystemOption.Rows
                    If Not listAux.Contains(row.ItemArray(columnIndex)) And (If(system <> "", If(system = row.ItemArray(0), True, False), True)) Then
                        cmb.Items.Add(row.ItemArray(columnIndex))
                        listAux.Add(row.ItemArray(columnIndex))
                        If cellValue = row.ItemArray(columnIndex) Then
                            flag = True
                        End If
                    End If
                Next
                If flag Then
                    cmb.Value = cellValue
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub tblPaint_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles tblPaint.EditingControlShowing
        Dim Index = tblPaint.CurrentCell.ColumnIndex
        If Index = 0 Or Index = 1 Then
            Dim typecell = tblPaint.CurrentCell.GetType.ToString
            If Not typecell = "System.Windows.Forms.DataGridViewTextBoxCell" Then
                Dim cb As ComboBox = CType(e.Control, ComboBox)
                If e.Control IsNot Nothing Then
                    RemoveHandler cb.SelectedIndexChanged, AddressOf cmb_SelectedIndexChanguedPaint
                    AddHandler cb.SelectedIndexChanged, AddressOf cmb_SelectedIndexChanguedPaint
                End If
            End If
        End If
    End Sub
    Public Sub cmb_SelectedIndexChanguedPaint(sender As Object, e As EventArgs)
        Try
            Dim cmb As ComboBox = CType(sender, ComboBox)
            Select Case tblPaint.CurrentCell.ColumnIndex
                Case 0
                    tblPaint.CurrentCell.Value = cmb.Text
                    If tblPaint.Rows(1).Cells(1).GetType.Name = "DataGridViewComboBoxCell" Then
                        llenarCmbSystemOption(tblPaint.Rows(1).Cells(1), 1, tblPaint.Rows(1).Cells(1).Value, tblPaint.Rows(1).Cells(0).Value)
                    End If
                Case 1
                    tblPaint.CurrentCell.Value = cmb.Text
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tblPaint_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles tblPaint.DataError, tblInsulation.DataError, tblGeneral.DataError, tblMaterialDescription.DataError
        Dim ex As Exception = e.Exception
        If e.Exception.Message = "El valor de DataGridViewComboBoxCell no es válido." Or e.Exception.Message = "DataGridViewComboBoxCell value is not valid." Then
            e.Cancel = True
        Else
            MessageBox.Show(ex.Message)
        End If
    End Sub

    Private Sub tblInsulation_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles tblInsulation.CellMouseClick
        Try
            If tblInsulation.CurrentCell.RowIndex = 1 Then
                Select Case tblInsulation.CurrentCell.ColumnIndex
                    Case 0 'Type
                        If tblInsulation.CurrentCell.GetType.Name = "DataGridViewTextBoxCell" Then
                            Dim cmbType As New DataGridViewComboBoxCell
                            With cmbType
                                llenarCmbTypeThick(cmbType, 1, If(tblInsulation.CurrentCell.Value IsNot Nothing, If(tblInsulation.CurrentCell.Value <> "", tblInsulation.CurrentCell.Value, ""), ""))
                                .DropDownWidth = If(tblInsulation.CurrentCell.Size.Width < 50, 50, tblInsulation.CurrentCell.Size.Width)
                            End With
                            tblInsulation.CurrentRow.Cells("typePp") = cmbType
                        End If
                    Case 2 'Jacket
                        If tblInsulation.CurrentCell.GetType.Name = "DataGridViewTextBoxCell" Then
                            Dim cmbType As New DataGridViewComboBoxCell
                            With cmbType
                                mtdRFIPiping.llenarComboJacket(cmbType, If(tblInsulation.CurrentCell.Value IsNot Nothing, tblInsulation.CurrentCell.Value, ""))
                                .DropDownWidth = 160
                            End With
                            tblInsulation.CurrentRow.Cells("jacketPp") = cmbType
                        End If
                End Select
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub llenarCmbTypeThick(ByVal cmb As DataGridViewComboBoxCell, ByVal columnIndex As Integer, Optional cellValue As String = "", Optional type As String = "")
        Try
            If tblTypeThick.Rows IsNot Nothing Then
                Dim listAux As New List(Of String)
                Dim flag As Boolean = False
                cmb.Items.Clear()
                For Each row As Data.DataRow In tblTypeThick.Rows
                    If Not listAux.Contains(row.ItemArray(columnIndex)) And (If(type <> "", If(type = row.ItemArray(1), True, False), True)) Then
                        cmb.Items.Add(row.ItemArray(columnIndex))
                        listAux.Add(row.ItemArray(columnIndex))
                        If cellValue = row.ItemArray(columnIndex) Then
                            flag = True
                        End If
                    End If
                Next
                If flag Then
                    cmb.Value = cellValue
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub cmb_SelectedIndexChanguedInsulation(sender As Object, e As EventArgs)
        Try
            Dim cmb As ComboBox = CType(sender, ComboBox)
            Select Case tblInsulation.CurrentCell.ColumnIndex
                Case 0
                    tblInsulation.CurrentCell.Value = cmb.Text
                    If tblInsulation.Rows(1).Cells(2).GetType.Name = "DataGridViewComboBoxCell" Then
                        llenarCmbTypeThick(tblInsulation.Rows(1).Cells(2), 2, tblInsulation.Rows(1).Cells(2).Value, tblInsulation.Rows(1).Cells(0).Value)
                    End If
                Case 2
                    tblInsulation.CurrentCell.Value = cmb.Text
            End Select
        Catch ex As Exception

        End Try
    End Sub
    Private Sub tblInsulation_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles tblInsulation.EditingControlShowing
        Dim Index = tblInsulation.CurrentCell.ColumnIndex
        If Index = 0 Or Index = 2 Then
            Dim typecell = tblInsulation.CurrentCell.GetType.ToString
            If Not typecell = "System.Windows.Forms.DataGridViewTextBoxCell" Then
                Dim cb As ComboBox = CType(e.Control, ComboBox)
                If e.Control IsNot Nothing Then
                    RemoveHandler cb.SelectedIndexChanged, AddressOf cmb_SelectedIndexChanguedInsulation
                    AddHandler cb.SelectedIndexChanged, AddressOf cmb_SelectedIndexChanguedInsulation
                End If
            End If
        End If
    End Sub
    Private Sub tblMaterialDescription_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles tblMaterialDescription.CellMouseClick
        Try
            If tblMaterialDescription.CurrentCell.RowIndex = 1 Or tblMaterialDescription.CurrentCell.RowIndex = 3 Or tblMaterialDescription.CurrentCell.RowIndex = 5 Then
                Select Case tblMaterialDescription.CurrentCell.ColumnIndex
                    Case 2 'LaborRate
                        If tblMaterialDescription.CurrentCell.GetType.Name = "DataGridViewTextBoxCell" Then
                            Dim cmbType As New DataGridViewComboBoxCell
                            With cmbType
                                mtdRFIPiping.llenarComboLaporRate(cmbType, If(tblMaterialDescription.CurrentCell.Value IsNot Nothing, tblMaterialDescription.CurrentCell.Value, ""))
                                .DropDownWidth = If(tblMaterialDescription.CurrentCell.Size.Width < 70, 70, tblMaterialDescription.CurrentCell.Size.Width)
                            End With
                            tblMaterialDescription.CurrentRow.Cells("workWeekPp") = cmbType
                        End If
                End Select
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub cmb_SelectedIndexChanguedMaterialDescription(sender As Object, e As EventArgs)
        Try
            Dim cmb As ComboBox = CType(sender, ComboBox)
            Select Case tblMaterialDescription.CurrentCell.ColumnIndex
                Case 2
                    tblMaterialDescription.CurrentCell.Value = cmb.Text
            End Select
        Catch ex As Exception

        End Try
    End Sub
    Private Sub tblMaterialDescription_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles tblMaterialDescription.EditingControlShowing
        Dim Index = tblMaterialDescription.CurrentCell.ColumnIndex
        If Index = 2 Then
            Dim typecell = tblMaterialDescription.CurrentCell.GetType.ToString
            If Not typecell = "System.Windows.Forms.DataGridViewTextBoxCell" Then
                Dim cb As ComboBox = CType(e.Control, ComboBox)
                If e.Control IsNot Nothing Then
                    RemoveHandler cb.SelectedIndexChanged, AddressOf cmb_SelectedIndexChanguedMaterialDescription
                    AddHandler cb.SelectedIndexChanged, AddressOf cmb_SelectedIndexChanguedMaterialDescription
                End If
            End If
        End If
    End Sub

    Private Sub btnAddRFIEquipment_Click_1(sender As Object, e As EventArgs) Handles btnAddRFIEquipment.Click
        If btnAddRFIEquipment.Text = "New" Then
            If idDrawingNum <> "" And idTagPp <> "" Then
                txtIdRFIPiping.Enabled = True
                btnAddRFIEquipment.Text = "Cancel"
                limpiarTablas(True)
                limpiarInfoExtra()
                txtIdRFIPiping.Text = mtdRFIPiping.selectMaxRFIPp(idTagPp, idDrawingNum).ToString()

                tbltagPp = mtdRFIPiping.selectTagDrawing(idDrawingNum)
                Dim rowsList() As Data.DataRow = tbltagPp.Select(" IdTag = '" + idTagPp + "' and idDrawingNum = '" + idDrawingNum + "'")
                If rowsList.Length > 0 Then
                    'idTag, description, elevation, wwPaint, system, option, sqrFtPnt, wwRemove, remove, sqrFtRmv, wwInstall, type, thick, jacket, sqrFtII, bevel, cutout, idDrawingNum
                    tblGeneral.Rows(0).Cells(1).Value = rowsList(0).ItemArray(1)
                    tblGeneral.Rows(0).Cells(2).Value = rowsList(0).ItemArray(2)

                    tblPaint.Rows(0).Cells(0).Value = rowsList(0).ItemArray(3).ToString()
                    tblPaint.Rows(0).Cells(1).Value = rowsList(0).ItemArray(4).ToString()

                    tblInsulation.Rows(0).Cells(0).Value = rowsList(0).ItemArray(5).ToString()
                    tblInsulation.Rows(0).Cells(1).Value = rowsList(0).ItemArray(6).ToString()
                    tblInsulation.Rows(0).Cells(2).Value = rowsList(0).ItemArray(7).ToString()

                    tblMaterialDescription.Rows(0).Cells(2).Value = rowsList(0).ItemArray(8).ToString()
                    tblMaterialDescription.Rows(0).Cells(3).Value = rowsList(0).ItemArray(9).ToString()
                    tblMaterialDescription.Rows(0).Cells(4).Value = rowsList(0).ItemArray(10).ToString()
                    tblMaterialDescription.Rows(0).Cells(5).Value = rowsList(0).ItemArray(11).ToString()
                    tblMaterialDescription.Rows(0).Cells(7).Value = rowsList(0).ItemArray(12).ToString()
                    tblMaterialDescription.Rows(0).Cells(10).Value = rowsList(0).ItemArray(13).ToString()
                    tblMaterialDescription.Rows(0).Cells(11).Value = rowsList(0).ItemArray(14).ToString()
                    tblMaterialDescription.Rows(0).Cells(12).Value = rowsList(0).ItemArray(15).ToString()
                    tblMaterialDescription.Rows(0).Cells(13).Value = rowsList(0).ItemArray(16).ToString()

                    tblMaterialDescription.Rows(2).Cells(2).Value = rowsList(0).ItemArray(17).ToString()
                    tblMaterialDescription.Rows(2).Cells(3).Value = rowsList(0).ItemArray(18).ToString()

                    tblMaterialDescription.Rows(4).Cells(2).Value = rowsList(0).ItemArray(19).ToString()
                    tblMaterialDescription.Rows(4).Cells(3).Value = rowsList(0).ItemArray(20).ToString()
                    tblMaterialDescription.Rows(4).Cells(4).Value = rowsList(0).ItemArray(21).ToString()
                    tblMaterialDescription.Rows(4).Cells(5).Value = rowsList(0).ItemArray(22).ToString()
                    tblMaterialDescription.Rows(4).Cells(6).Value = rowsList(0).ItemArray(23).ToString()
                    tblMaterialDescription.Rows(4).Cells(7).Value = rowsList(0).ItemArray(24).ToString()
                    tblMaterialDescription.Rows(4).Cells(8).Value = rowsList(0).ItemArray(25).ToString()
                    tblMaterialDescription.Rows(4).Cells(9).Value = rowsList(0).ItemArray(26).ToString()
                    tblMaterialDescription.Rows(4).Cells(10).Value = rowsList(0).ItemArray(27).ToString()
                    tblMaterialDescription.Rows(4).Cells(11).Value = rowsList(0).ItemArray(28).ToString()
                    tblMaterialDescription.Rows(4).Cells(12).Value = rowsList(0).ItemArray(29).ToString()
                    tblMaterialDescription.Rows(4).Cells(13).Value = rowsList(0).ItemArray(30).ToString()
                    tblMaterialDescription.Rows(4).Cells(14).Value = rowsList(0).ItemArray(31).ToString()
                    tblMaterialDescription.Rows(4).Cells(15).Value = rowsList(0).ItemArray(32).ToString()
                End If
            Else
                MessageBox.Show("Please select a Drawing No. or Scaffold Tag project to continue.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            btnAddRFIEquipment.Text = "New"
            limpiarTablas(True)
            limpiarInfoExtra()
            txtIdRFIPiping.Text = ""
            txtIdRFIPiping.Enabled = False
            If idDrawingNum <> "" And idTagPp <> "" Then
                tbltagPp = mtdRFIPiping.selectTagDrawing(idDrawingNum)
                Dim rowsList() As Data.DataRow = tbltagPp.Select(" idTag = '" + idTagPp + "' and idDrawingNum = '" + idDrawingNum + "'")
                If rowsList.Length > 0 Then
                    'idTag, description, elevation, wwPaint, system, option, sqrFtPnt, wwRemove, remove, sqrFtRmv, wwInstall, type, thick, jacket, sqrFtII, bevel, cutout, idDrawingNum
                    tblGeneral.Rows(0).Cells(1).Value = rowsList(0).ItemArray(1)
                    tblGeneral.Rows(0).Cells(2).Value = rowsList(0).ItemArray(2)

                    tblPaint.Rows(0).Cells(0).Value = rowsList(0).ItemArray(3).ToString()
                    tblPaint.Rows(0).Cells(1).Value = rowsList(0).ItemArray(4).ToString()

                    tblInsulation.Rows(0).Cells(0).Value = rowsList(0).ItemArray(5).ToString()
                    tblInsulation.Rows(0).Cells(1).Value = rowsList(0).ItemArray(6).ToString()
                    tblInsulation.Rows(0).Cells(2).Value = rowsList(0).ItemArray(7).ToString()

                    tblMaterialDescription.Rows(0).Cells(2).Value = rowsList(0).ItemArray(8).ToString()
                    tblMaterialDescription.Rows(0).Cells(3).Value = rowsList(0).ItemArray(9).ToString()
                    tblMaterialDescription.Rows(0).Cells(4).Value = rowsList(0).ItemArray(10).ToString()
                    tblMaterialDescription.Rows(0).Cells(5).Value = rowsList(0).ItemArray(11).ToString()
                    tblMaterialDescription.Rows(0).Cells(7).Value = rowsList(0).ItemArray(12).ToString()
                    tblMaterialDescription.Rows(0).Cells(10).Value = rowsList(0).ItemArray(13).ToString()
                    tblMaterialDescription.Rows(0).Cells(11).Value = rowsList(0).ItemArray(14).ToString()
                    tblMaterialDescription.Rows(0).Cells(12).Value = rowsList(0).ItemArray(15).ToString()
                    tblMaterialDescription.Rows(0).Cells(13).Value = rowsList(0).ItemArray(16).ToString()

                    tblMaterialDescription.Rows(2).Cells(2).Value = rowsList(0).ItemArray(17).ToString()
                    tblMaterialDescription.Rows(2).Cells(3).Value = rowsList(0).ItemArray(18).ToString()

                    tblMaterialDescription.Rows(4).Cells(2).Value = rowsList(0).ItemArray(19).ToString()
                    tblMaterialDescription.Rows(4).Cells(3).Value = rowsList(0).ItemArray(20).ToString()
                    tblMaterialDescription.Rows(4).Cells(4).Value = rowsList(0).ItemArray(21).ToString()
                    tblMaterialDescription.Rows(4).Cells(5).Value = rowsList(0).ItemArray(22).ToString()
                    tblMaterialDescription.Rows(4).Cells(6).Value = rowsList(0).ItemArray(23).ToString()
                    tblMaterialDescription.Rows(4).Cells(7).Value = rowsList(0).ItemArray(24).ToString()
                    tblMaterialDescription.Rows(4).Cells(8).Value = rowsList(0).ItemArray(25).ToString()
                    tblMaterialDescription.Rows(4).Cells(9).Value = rowsList(0).ItemArray(26).ToString()
                    tblMaterialDescription.Rows(4).Cells(10).Value = rowsList(0).ItemArray(27).ToString()
                    tblMaterialDescription.Rows(4).Cells(11).Value = rowsList(0).ItemArray(28).ToString()
                    tblMaterialDescription.Rows(4).Cells(12).Value = rowsList(0).ItemArray(29).ToString()
                    tblMaterialDescription.Rows(4).Cells(13).Value = rowsList(0).ItemArray(30).ToString()
                    tblMaterialDescription.Rows(4).Cells(14).Value = rowsList(0).ItemArray(31).ToString()
                    tblMaterialDescription.Rows(4).Cells(15).Value = rowsList(0).ItemArray(32).ToString()
                End If
            End If
        End If
    End Sub
    Public Function newRFI() As RFIPPClass
        Dim rfiPp As New RFIPPClass
        If txtIdRFIPiping.Text <> "" Then
            rfiPp.Tag = idTagPp
            rfiPp.IdDrawingNum = idDrawingNum
            rfiPp.IdRFIPp = txtIdRFIPiping.Text

            rfiPp.OldSize = If(tblGeneral.Rows(0).Cells("SizePp").Value IsNot Nothing, If(tblGeneral.Rows(0).Cells("SizePp").Value <> "", CDec(tblGeneral.Rows(0).Cells("SizePp").Value), 0), 0)
            rfiPp.NewSize = If(tblGeneral.Rows(1).Cells("SizePp").Value IsNot Nothing, If(tblGeneral.Rows(1).Cells("SizePp").Value <> "", CDec(tblGeneral.Rows(1).Cells("SizePp").Value), rfiPp.OldSize), rfiPp.OldSize)
            rfiPp.OldElevation = If(tblGeneral.Rows(0).Cells("HeigthPp").Value IsNot Nothing, If(tblGeneral.Rows(0).Cells("HeigthPp").Value <> "", CDec(tblGeneral.Rows(0).Cells("HeigthPp").Value), 0), 0)
            rfiPp.NewElevation = If(tblGeneral.Rows(1).Cells("HeigthPp").Value IsNot Nothing, If(tblGeneral.Rows(1).Cells("HeigthPp").Value <> "", CDec(tblGeneral.Rows(1).Cells("HeigthPp").Value), rfiPp.OldElevation), rfiPp.OldElevation)

            rfiPp.OldSystem = If(tblPaint.Rows(0).Cells("SystemPp").Value IsNot Nothing, If(tblPaint.Rows(0).Cells("SystemPp").Value <> "", tblPaint.Rows(0).Cells("SystemPp").Value, "NULL"), "NULL")
            rfiPp.NewSystem = If(tblPaint.Rows(1).Cells("SystemPp").Value IsNot Nothing, If(tblPaint.Rows(1).Cells("SystemPp").Value <> "", tblPaint.Rows(1).Cells("SystemPp").Value, rfiPp.OldSystem), rfiPp.OldSystem)
            rfiPp.OldOption = If(tblPaint.Rows(0).Cells("optionPp").Value IsNot Nothing, If(tblPaint.Rows(0).Cells("optionPp").Value <> "", tblPaint.Rows(0).Cells("optionPp").Value, "NULL"), "NULL")
            rfiPp.NewOption = If(tblPaint.Rows(1).Cells("optionPp").Value IsNot Nothing, If(tblPaint.Rows(1).Cells("optionPp").Value <> "", tblPaint.Rows(1).Cells("optionPp").Value, rfiPp.OldOption), rfiPp.OldOption)

            rfiPp.OldType = If(tblInsulation.Rows(0).Cells("typePp").Value IsNot Nothing, If(tblInsulation.Rows(0).Cells("typePp").Value <> "", tblInsulation.Rows(0).Cells("typePp").Value, "NULL"), "NULL")
            rfiPp.NewType = If(tblInsulation.Rows(1).Cells("typePp").Value IsNot Nothing, If(tblInsulation.Rows(1).Cells("typePp").Value <> "", tblInsulation.Rows(1).Cells("typePp").Value, rfiPp.OldType), rfiPp.OldType)
            rfiPp.OldThick = If(tblInsulation.Rows(0).Cells("thickPp").Value IsNot Nothing, If(tblInsulation.Rows(0).Cells("thickPp").Value <> "", CDec(tblInsulation.Rows(0).Cells("thickPp").Value), 0), 0)
            rfiPp.NewThick = If(tblInsulation.Rows(1).Cells("thickPp").Value IsNot Nothing, If(tblInsulation.Rows(1).Cells("thickPp").Value <> "", CDec(tblInsulation.Rows(1).Cells("thickPp").Value), rfiPp.OldThick), rfiPp.OldThick)
            rfiPp.OldIdJacket = If(tblInsulation.Rows(0).Cells("jacketPp").Value IsNot Nothing, If(tblInsulation.Rows(0).Cells("jacketPp").Value <> "", tblInsulation.Rows(0).Cells("jacketPp").Value, "NULL"), "NULL")
            rfiPp.NewIdJacket = If(tblInsulation.Rows(1).Cells("jacketPp").Value IsNot Nothing, If(tblInsulation.Rows(1).Cells("jacketPp").Value <> "", tblInsulation.Rows(1).Cells("jacketPp").Value, rfiPp.OldIdJacket), rfiPp.OldIdJacket)

            rfiPp.OldIdLaborRatePnt = If(tblMaterialDescription.Rows(0).Cells("workWeekPp").Value IsNot Nothing, If(tblMaterialDescription.Rows(0).Cells("workWeekPp").Value <> "", tblMaterialDescription.Rows(0).Cells("workWeekPp").Value, "NULL"), "NULL")
            rfiPp.NewIdLaborRatePnt = If(tblMaterialDescription.Rows(1).Cells("workWeekPp").Value IsNot Nothing, If(tblMaterialDescription.Rows(1).Cells("workWeekPp").Value <> "", tblMaterialDescription.Rows(1).Cells("workWeekPp").Value, rfiPp.OldIdLaborRatePnt), rfiPp.OldIdLaborRatePnt)
            rfiPp.OldLFtPnt = If(tblMaterialDescription.Rows(0).Cells("LFtPp").Value IsNot Nothing, If(tblMaterialDescription.Rows(0).Cells("LFtPp").Value <> "", CInt(tblMaterialDescription.Rows(0).Cells("LFtPp").Value), 0), 0)
            rfiPp.NewLFtPnt = If(tblMaterialDescription.Rows(1).Cells("LFtPp").Value IsNot Nothing, If(tblMaterialDescription.Rows(1).Cells("LFtPp").Value <> "", CInt(tblMaterialDescription.Rows(1).Cells("LFtPp").Value), rfiPp.OldLFtPnt), rfiPp.OldLFtPnt)
            rfiPp.OldP90Pnt = If(tblMaterialDescription.Rows(0).Cells("Pp90").Value IsNot Nothing, If(tblMaterialDescription.Rows(0).Cells("Pp90").Value <> "", CInt(tblMaterialDescription.Rows(0).Cells("Pp90").Value), 0), 0)
            rfiPp.NewP90Pnt = If(tblMaterialDescription.Rows(1).Cells("Pp90").Value IsNot Nothing, If(tblMaterialDescription.Rows(1).Cells("Pp90").Value <> "", CInt(tblMaterialDescription.Rows(1).Cells("Pp90").Value), rfiPp.OldP90Pnt), rfiPp.OldP90Pnt)
            rfiPp.OldP45Pnt = If(tblMaterialDescription.Rows(0).Cells("Pp45").Value IsNot Nothing, If(tblMaterialDescription.Rows(0).Cells("Pp45").Value <> "", CInt(tblMaterialDescription.Rows(0).Cells("Pp45").Value), 0), 0)
            rfiPp.NewP45Pnt = If(tblMaterialDescription.Rows(1).Cells("Pp45").Value IsNot Nothing, If(tblMaterialDescription.Rows(1).Cells("Pp45").Value <> "", CInt(tblMaterialDescription.Rows(1).Cells("Pp45").Value), rfiPp.OldP45Pnt), rfiPp.OldP45Pnt)
            rfiPp.OldPTeePnt = If(tblMaterialDescription.Rows(0).Cells("teePp").Value IsNot Nothing, If(tblMaterialDescription.Rows(0).Cells("teePp").Value <> "", CInt(tblMaterialDescription.Rows(0).Cells("teePp").Value), 0), 0)
            rfiPp.NewPTeePnt = If(tblMaterialDescription.Rows(1).Cells("teePp").Value IsNot Nothing, If(tblMaterialDescription.Rows(1).Cells("teePp").Value <> "", CInt(tblMaterialDescription.Rows(1).Cells("teePp").Value), rfiPp.OldPTeePnt), rfiPp.OldPTeePnt)
            rfiPp.OldPPairPnt = If(tblMaterialDescription.Rows(0).Cells("pairPp").Value IsNot Nothing, If(tblMaterialDescription.Rows(0).Cells("pairPp").Value <> "", CInt(tblMaterialDescription.Rows(0).Cells("pairPp").Value), 0), 0)
            rfiPp.NewPPairPnt = If(tblMaterialDescription.Rows(1).Cells("pairPp").Value IsNot Nothing, If(tblMaterialDescription.Rows(1).Cells("pairPp").Value <> "", CInt(tblMaterialDescription.Rows(1).Cells("pairPp").Value), rfiPp.OldPPairPnt), rfiPp.OldPPairPnt)
            rfiPp.OldPVlvPnt = If(tblMaterialDescription.Rows(0).Cells("valvePp").Value IsNot Nothing, If(tblMaterialDescription.Rows(0).Cells("valvePp").Value <> "", CInt(tblMaterialDescription.Rows(0).Cells("valvePp").Value), 0), 0)
            rfiPp.NewPVlvPnt = If(tblMaterialDescription.Rows(1).Cells("valvePp").Value IsNot Nothing, If(tblMaterialDescription.Rows(1).Cells("valvePp").Value <> "", CInt(tblMaterialDescription.Rows(1).Cells("valvePp").Value), rfiPp.OldPVlvPnt), rfiPp.OldPVlvPnt)
            rfiPp.OldPControlPnt = If(tblMaterialDescription.Rows(0).Cells("controlPp").Value IsNot Nothing, If(tblMaterialDescription.Rows(0).Cells("controlPp").Value <> "", CInt(tblMaterialDescription.Rows(0).Cells("controlPp").Value), 0), 0)
            rfiPp.NewPControlPnt = If(tblMaterialDescription.Rows(1).Cells("controlPp").Value IsNot Nothing, If(tblMaterialDescription.Rows(1).Cells("controlPp").Value <> "", CInt(tblMaterialDescription.Rows(1).Cells("controlPp").Value), rfiPp.OldPControlPnt), rfiPp.OldPControlPnt)
            rfiPp.OldPWeldPnt = If(tblMaterialDescription.Rows(0).Cells("weldPp").Value IsNot Nothing, If(tblMaterialDescription.Rows(0).Cells("weldPp").Value <> "", CInt(tblMaterialDescription.Rows(0).Cells("weldPp").Value), 0), 0)
            rfiPp.NewPWeldPnt = If(tblMaterialDescription.Rows(1).Cells("weldPp").Value IsNot Nothing, If(tblMaterialDescription.Rows(1).Cells("weldPp").Value <> "", CInt(tblMaterialDescription.Rows(1).Cells("weldPp").Value), rfiPp.OldPWeldPnt), rfiPp.OldPWeldPnt)

            rfiPp.OldIdLaborRateRmv = If(tblMaterialDescription.Rows(2).Cells("workWeekPp").Value IsNot Nothing, If(tblMaterialDescription.Rows(2).Cells("workWeekPp").Value <> "", tblMaterialDescription.Rows(2).Cells("workWeekPp").Value, "NULL"), "NULL")
            rfiPp.NewIdLaborRateRmv = If(tblMaterialDescription.Rows(3).Cells("workWeekPp").Value IsNot Nothing, If(tblMaterialDescription.Rows(3).Cells("workWeekPp").Value <> "", tblMaterialDescription.Rows(3).Cells("workWeekPp").Value, rfiPp.OldIdLaborRateRmv), rfiPp.OldIdLaborRateRmv)
            rfiPp.OldLFtRmv = If(tblMaterialDescription.Rows(2).Cells("LFtPp").Value IsNot Nothing, If(tblMaterialDescription.Rows(2).Cells("LFtPp").Value <> "", CInt(tblMaterialDescription.Rows(2).Cells("LFtPp").Value), 0), 0)
            rfiPp.NewLFtRmv = If(tblMaterialDescription.Rows(3).Cells("LFtPp").Value IsNot Nothing, If(tblMaterialDescription.Rows(3).Cells("LFtPp").Value <> "", CInt(tblMaterialDescription.Rows(3).Cells("LFtPp").Value), rfiPp.OldLFtRmv), rfiPp.OldLFtRmv)

            rfiPp.OldIdLaborRateII = If(tblMaterialDescription.Rows(4).Cells("workWeekPp").Value IsNot Nothing, If(tblMaterialDescription.Rows(4).Cells("workWeekPp").Value <> "", tblMaterialDescription.Rows(4).Cells("workWeekPp").Value, "NULL"), "NULL")
            rfiPp.NewIdLaborRateII = If(tblMaterialDescription.Rows(5).Cells("workWeekPp").Value IsNot Nothing, If(tblMaterialDescription.Rows(5).Cells("workWeekPp").Value <> "", tblMaterialDescription.Rows(5).Cells("workWeekPp").Value, rfiPp.OldIdLaborRateII), rfiPp.OldIdLaborRateII)
            rfiPp.OldLFtII = If(tblMaterialDescription.Rows(4).Cells("LFtPp").Value IsNot Nothing, If(tblMaterialDescription.Rows(4).Cells("LFtPp").Value <> "", CInt(tblMaterialDescription.Rows(4).Cells("LFtPp").Value), 0), 0)
            rfiPp.NewLFtII = If(tblMaterialDescription.Rows(5).Cells("LFtPp").Value IsNot Nothing, If(tblMaterialDescription.Rows(5).Cells("LFtPp").Value <> "", CInt(tblMaterialDescription.Rows(5).Cells("LFtPp").Value), rfiPp.OldLFtII), rfiPp.OldLFtII)
            rfiPp.OldP90II = If(tblMaterialDescription.Rows(4).Cells("Pp90").Value IsNot Nothing, If(tblMaterialDescription.Rows(4).Cells("Pp90").Value <> "", CInt(tblMaterialDescription.Rows(4).Cells("Pp90").Value), 0), 0)
            rfiPp.NewP90II = If(tblMaterialDescription.Rows(5).Cells("Pp90").Value IsNot Nothing, If(tblMaterialDescription.Rows(5).Cells("Pp90").Value <> "", CInt(tblMaterialDescription.Rows(5).Cells("Pp90").Value), rfiPp.OldP90II), rfiPp.OldP90II)
            rfiPp.OldP45II = If(tblMaterialDescription.Rows(4).Cells("Pp45").Value IsNot Nothing, If(tblMaterialDescription.Rows(4).Cells("Pp45").Value <> "", CInt(tblMaterialDescription.Rows(4).Cells("Pp45").Value), 0), 0)
            rfiPp.NewP45II = If(tblMaterialDescription.Rows(5).Cells("Pp45").Value IsNot Nothing, If(tblMaterialDescription.Rows(5).Cells("Pp45").Value <> "", CInt(tblMaterialDescription.Rows(5).Cells("Pp45").Value), rfiPp.OldP45II), rfiPp.OldP45II)
            rfiPp.OldPBendII = If(tblMaterialDescription.Rows(4).Cells("bendPp").Value IsNot Nothing, If(tblMaterialDescription.Rows(4).Cells("bendPp").Value <> "", CInt(tblMaterialDescription.Rows(4).Cells("bendPp").Value), 0), 0)
            rfiPp.NewPBendII = If(tblMaterialDescription.Rows(5).Cells("bendPp").Value IsNot Nothing, If(tblMaterialDescription.Rows(5).Cells("bendPp").Value <> "", CInt(tblMaterialDescription.Rows(5).Cells("bendPp").Value), rfiPp.OldPBendII), rfiPp.OldPBendII)
            rfiPp.OldPTeeII = If(tblMaterialDescription.Rows(4).Cells("teePp").Value IsNot Nothing, If(tblMaterialDescription.Rows(4).Cells("teePp").Value <> "", CInt(tblMaterialDescription.Rows(4).Cells("teePp").Value), 0), 0)
            rfiPp.NewPTeeII = If(tblMaterialDescription.Rows(5).Cells("teePp").Value IsNot Nothing, If(tblMaterialDescription.Rows(5).Cells("teePp").Value <> "", CInt(tblMaterialDescription.Rows(5).Cells("teePp").Value), rfiPp.OldPTeeII), rfiPp.OldPTeeII)
            rfiPp.OldPReducII = If(tblMaterialDescription.Rows(4).Cells("ReducPp").Value IsNot Nothing, If(tblMaterialDescription.Rows(4).Cells("ReducPp").Value <> "", CInt(tblMaterialDescription.Rows(4).Cells("ReducPp").Value), 0), 0)
            rfiPp.NewPReducII = If(tblMaterialDescription.Rows(5).Cells("ReducPp").Value IsNot Nothing, If(tblMaterialDescription.Rows(5).Cells("ReducPp").Value <> "", CInt(tblMaterialDescription.Rows(5).Cells("ReducPp").Value), rfiPp.OldPReducII), rfiPp.OldPReducII)
            rfiPp.OldPCapsII = If(tblMaterialDescription.Rows(4).Cells("capPp").Value IsNot Nothing, If(tblMaterialDescription.Rows(4).Cells("capPp").Value <> "", CInt(tblMaterialDescription.Rows(4).Cells("capPp").Value), 0), 0)
            rfiPp.NewPCapsII = If(tblMaterialDescription.Rows(5).Cells("capPp").Value IsNot Nothing, If(tblMaterialDescription.Rows(5).Cells("capPp").Value <> "", CInt(tblMaterialDescription.Rows(5).Cells("capPp").Value), rfiPp.OldPCapsII), rfiPp.OldPCapsII)
            rfiPp.OldPPairII = If(tblMaterialDescription.Rows(4).Cells("pairPp").Value IsNot Nothing, If(tblMaterialDescription.Rows(4).Cells("pairPp").Value <> "", CInt(tblMaterialDescription.Rows(4).Cells("pairPp").Value), 0), 0)
            rfiPp.NewPPairII = If(tblMaterialDescription.Rows(5).Cells("pairPp").Value IsNot Nothing, If(tblMaterialDescription.Rows(5).Cells("pairPp").Value <> "", CInt(tblMaterialDescription.Rows(5).Cells("pairPp").Value), rfiPp.OldPPairII), rfiPp.OldPPairII)
            rfiPp.OldPVlvII = If(tblMaterialDescription.Rows(4).Cells("valvePp").Value IsNot Nothing, If(tblMaterialDescription.Rows(4).Cells("valvePp").Value <> "", CInt(tblMaterialDescription.Rows(4).Cells("valvePp").Value), 0), 0)
            rfiPp.NewPVlvII = If(tblMaterialDescription.Rows(5).Cells("valvePp").Value IsNot Nothing, If(tblMaterialDescription.Rows(5).Cells("valvePp").Value <> "", CInt(tblMaterialDescription.Rows(5).Cells("valvePp").Value), rfiPp.OldPVlvII), rfiPp.OldPVlvII)
            rfiPp.OldPControlII = If(tblMaterialDescription.Rows(4).Cells("controlPp").Value IsNot Nothing, If(tblMaterialDescription.Rows(4).Cells("controlPp").Value <> "", CInt(tblMaterialDescription.Rows(4).Cells("controlPp").Value), 0), 0)
            rfiPp.NewPControlII = If(tblMaterialDescription.Rows(5).Cells("controlPp").Value IsNot Nothing, If(tblMaterialDescription.Rows(5).Cells("controlPp").Value <> "", CInt(tblMaterialDescription.Rows(5).Cells("controlPp").Value), rfiPp.OldPControlII), rfiPp.OldPControlII)
            rfiPp.OldPWeldII = If(tblMaterialDescription.Rows(4).Cells("weldPp").Value IsNot Nothing, If(tblMaterialDescription.Rows(4).Cells("weldPp").Value <> "", CInt(tblMaterialDescription.Rows(4).Cells("weldPp").Value), 0), 0)
            rfiPp.NewPWeldII = If(tblMaterialDescription.Rows(5).Cells("weldPp").Value IsNot Nothing, If(tblMaterialDescription.Rows(5).Cells("weldPp").Value <> "", CInt(tblMaterialDescription.Rows(5).Cells("weldPp").Value), rfiPp.OldPWeldII), rfiPp.OldPWeldII)
            rfiPp.OldPCutOutII = If(tblMaterialDescription.Rows(4).Cells("cutOutPp").Value IsNot Nothing, If(tblMaterialDescription.Rows(4).Cells("cutOutPp").Value <> "", CInt(tblMaterialDescription.Rows(4).Cells("cutOutPp").Value), 0), 0)
            rfiPp.NewPCutOutII = If(tblMaterialDescription.Rows(5).Cells("cutOutPp").Value IsNot Nothing, If(tblMaterialDescription.Rows(5).Cells("cutOutPp").Value <> "", CInt(tblMaterialDescription.Rows(5).Cells("cutOutPp").Value), rfiPp.OldPCutOutII), rfiPp.OldPCutOutII)
            rfiPp.OldPsupportII = If(tblMaterialDescription.Rows(4).Cells("supportPp").Value IsNot Nothing, If(tblMaterialDescription.Rows(4).Cells("supportPp").Value <> "", CInt(tblMaterialDescription.Rows(4).Cells("supportPp").Value), 0), 0)
            rfiPp.NewPsupportII = If(tblMaterialDescription.Rows(5).Cells("supportPp").Value IsNot Nothing, If(tblMaterialDescription.Rows(5).Cells("supportPp").Value <> "", CInt(tblMaterialDescription.Rows(5).Cells("supportPp").Value), rfiPp.OldPsupportII), rfiPp.OldPsupportII)

            rfiPp.ReqEmployee = txtNameReq.Text
            rfiPp.ReqTitleEmployee = txtTitleReq.Text
            rfiPp.ReqCompany = txtCompanyReq.Text
            rfiPp.ReqDate = dtpDateReq.Value
            rfiPp.ChUpEmployee = txtNameUpdate.Text
            rfiPp.ChUpTitleEmployee = txtTitleUpdate.Text
            rfiPp.ChUpDate = dtpDateUpdate.Value
            rfiPp.WeDate = dtpDateWE.Value
            rfiPp.BasicFCR = txtBasicForNum.Text
            rfiPp.Note = txtNote.Text
        End If
        Return rfiPp
    End Function
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If idDrawingNum <> "" And idTagPp <> "" Then
                Dim RFI = newRFI()
                If RFI IsNot Nothing Then
                    If mtdRFIPiping.SaveUpdateRFIPiping(RFI) Then
                        tblRFIPipingHistory = mtdRFIPiping.selectRFIPiping(idTagPp, idDrawingNum)
                        llenarTablaHistory()
                        Dim rowList() As DataRow = tblRFIPipingHistory.Select("idRFIPp='" + RFI.IdRFIPp + "' and idTag = '" + RFI.Tag.ToString() + "'")
                        If rowList.Length > 0 Then
                            llenarDatosRFI(rowList(0))
                            txtIdRFIPiping.Enabled = False
                        Else
                            limpiarTablas(False)
                            limpiarInfoExtra()
                            txtIdRFIPiping.Enabled = False
                        End If
                    Else

                    End If
                End If
            Else
                MessageBox.Show("Please Selet a Scaffold Tag to continue.", "Importatn", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Function llenarDatosRFI(ByVal row As Data.DataRow) As Boolean
        Try
            limpiarTablas(False)
            limpiarInfoExtra()
            txtIdRFIPiping.Text = row.ItemArray(0)

            tblGeneral.Rows(0).Cells("SizePp").Value = row.ItemArray(3).ToString()
            tblGeneral.Rows(0).Cells("HeigthPp").Value = row.ItemArray(4).ToString()

            tblPaint.Rows(0).Cells("SystemPp").Value = row.ItemArray(5).ToString()
            tblPaint.Rows(0).Cells("optionPp").Value = row.ItemArray(6).ToString()

            tblInsulation.Rows(0).Cells("typePp").Value = row.ItemArray(7).ToString()
            tblInsulation.Rows(0).Cells("thickPp").Value = row.ItemArray(8).ToString()
            tblInsulation.Rows(0).Cells("jacketPp").Value = row.ItemArray(9).ToString()

            tblGeneral.Rows(1).Cells("SizePp").Value = row.ItemArray(35).ToString()
            tblGeneral.Rows(1).Cells("HeigthPp").Value = row.ItemArray(36).ToString()

            tblPaint.Rows(1).Cells("SystemPp").Value = row.ItemArray(37).ToString()
            tblPaint.Rows(1).Cells("optionPp").Value = row.ItemArray(38).ToString()

            tblInsulation.Rows(1).Cells("typePp").Value = row.ItemArray(39).ToString()
            tblInsulation.Rows(1).Cells("thickPp").Value = row.ItemArray(40).ToString()
            tblInsulation.Rows(1).Cells("jacketPp").Value = row.ItemArray(41).ToString()

            tblMaterialDescription.Rows(0).Cells("workWeekPp").Value = row.ItemArray(10).ToString()
            tblMaterialDescription.Rows(0).Cells("LFtPp").Value = row.ItemArray(11).ToString()
            tblMaterialDescription.Rows(0).Cells("Pp90").Value = row.ItemArray(12).ToString()
            tblMaterialDescription.Rows(0).Cells("Pp45").Value = row.ItemArray(13).ToString()
            tblMaterialDescription.Rows(0).Cells("bendPp").Value = ""
            tblMaterialDescription.Rows(0).Cells("teePp").Value = row.ItemArray(14).ToString()
            tblMaterialDescription.Rows(0).Cells("ReducPp").Value = ""
            tblMaterialDescription.Rows(0).Cells("capPp").Value = ""
            tblMaterialDescription.Rows(0).Cells("pairPp").Value = row.ItemArray(15).ToString()
            tblMaterialDescription.Rows(0).Cells("valvePp").Value = row.ItemArray(16).ToString()
            tblMaterialDescription.Rows(0).Cells("controlPp").Value = row.ItemArray(17).ToString()
            tblMaterialDescription.Rows(0).Cells("weldPp").Value = row.ItemArray(18).ToString()
            tblMaterialDescription.Rows(0).Cells("cutOutPp").Value = ""
            tblMaterialDescription.Rows(0).Cells("supportPp").Value = ""

            tblMaterialDescription.Rows(1).Cells("workWeekPp").Value = row.ItemArray(42).ToString()
            tblMaterialDescription.Rows(1).Cells("LFtPp").Value = row.ItemArray(43).ToString()
            tblMaterialDescription.Rows(1).Cells("Pp90").Value = row.ItemArray(44).ToString()
            tblMaterialDescription.Rows(1).Cells("Pp45").Value = row.ItemArray(45).ToString()
            tblMaterialDescription.Rows(1).Cells("bendPp").Value = ""
            tblMaterialDescription.Rows(1).Cells("teePp").Value = row.ItemArray(46).ToString()
            tblMaterialDescription.Rows(1).Cells("ReducPp").Value = ""
            tblMaterialDescription.Rows(1).Cells("capPp").Value = ""
            tblMaterialDescription.Rows(1).Cells("pairPp").Value = row.ItemArray(47).ToString()
            tblMaterialDescription.Rows(1).Cells("valvePp").Value = row.ItemArray(48).ToString()
            tblMaterialDescription.Rows(1).Cells("controlPp").Value = row.ItemArray(49).ToString()
            tblMaterialDescription.Rows(1).Cells("weldPp").Value = row.ItemArray(50).ToString()
            tblMaterialDescription.Rows(1).Cells("cutOutPp").Value = ""
            tblMaterialDescription.Rows(1).Cells("supportPp").Value = ""

            tblMaterialDescription.Rows(2).Cells("workWeekPp").Value = row.ItemArray(19).ToString()
            tblMaterialDescription.Rows(2).Cells("LFtPp").Value = row.ItemArray(20).ToString()
            tblMaterialDescription.Rows(2).Cells("Pp90").Value = ""
            tblMaterialDescription.Rows(2).Cells("Pp45").Value = ""
            tblMaterialDescription.Rows(2).Cells("bendPp").Value = ""
            tblMaterialDescription.Rows(2).Cells("teePp").Value = ""
            tblMaterialDescription.Rows(2).Cells("ReducPp").Value = ""
            tblMaterialDescription.Rows(2).Cells("capPp").Value = ""
            tblMaterialDescription.Rows(2).Cells("pairPp").Value = ""
            tblMaterialDescription.Rows(2).Cells("valvePp").Value = ""
            tblMaterialDescription.Rows(2).Cells("controlPp").Value = ""
            tblMaterialDescription.Rows(2).Cells("weldPp").Value = ""
            tblMaterialDescription.Rows(2).Cells("cutOutPp").Value = ""
            tblMaterialDescription.Rows(2).Cells("supportPp").Value = ""

            tblMaterialDescription.Rows(3).Cells("workWeekPp").Value = row.ItemArray(51).ToString()
            tblMaterialDescription.Rows(3).Cells("LFtPp").Value = row.ItemArray(52).ToString()
            tblMaterialDescription.Rows(3).Cells("Pp90").Value = ""
            tblMaterialDescription.Rows(3).Cells("Pp45").Value = ""
            tblMaterialDescription.Rows(3).Cells("bendPp").Value = ""
            tblMaterialDescription.Rows(3).Cells("teePp").Value = ""
            tblMaterialDescription.Rows(3).Cells("ReducPp").Value = ""
            tblMaterialDescription.Rows(3).Cells("capPp").Value = ""
            tblMaterialDescription.Rows(3).Cells("pairPp").Value = ""
            tblMaterialDescription.Rows(3).Cells("valvePp").Value = ""
            tblMaterialDescription.Rows(3).Cells("controlPp").Value = ""
            tblMaterialDescription.Rows(3).Cells("weldPp").Value = ""
            tblMaterialDescription.Rows(3).Cells("cutOutPp").Value = ""
            tblMaterialDescription.Rows(3).Cells("supportPp").Value = ""
            '21->34
            tblMaterialDescription.Rows(4).Cells("workWeekPp").Value = row.ItemArray(21).ToString()
            tblMaterialDescription.Rows(4).Cells("LFtPp").Value = row.ItemArray(22).ToString()
            tblMaterialDescription.Rows(4).Cells("Pp90").Value = row.ItemArray(23).ToString()
            tblMaterialDescription.Rows(4).Cells("Pp45").Value = row.ItemArray(24).ToString()
            tblMaterialDescription.Rows(4).Cells("bendPp").Value = row.ItemArray(25).ToString()
            tblMaterialDescription.Rows(4).Cells("teePp").Value = row.ItemArray(26).ToString()
            tblMaterialDescription.Rows(4).Cells("ReducPp").Value = row.ItemArray(27).ToString()
            tblMaterialDescription.Rows(4).Cells("capPp").Value = row.ItemArray(28).ToString()
            tblMaterialDescription.Rows(4).Cells("pairPp").Value = row.ItemArray(29).ToString()
            tblMaterialDescription.Rows(4).Cells("valvePp").Value = row.ItemArray(30).ToString()
            tblMaterialDescription.Rows(4).Cells("controlPp").Value = row.ItemArray(31).ToString()
            tblMaterialDescription.Rows(4).Cells("weldPp").Value = row.ItemArray(32).ToString()
            tblMaterialDescription.Rows(4).Cells("cutOutPp").Value = row.ItemArray(33).ToString()
            tblMaterialDescription.Rows(4).Cells("supportPp").Value = row.ItemArray(34).ToString()
            '53->67
            tblMaterialDescription.Rows(5).Cells("workWeekPp").Value = row.ItemArray(53).ToString()
            tblMaterialDescription.Rows(5).Cells("LFtPp").Value = row.ItemArray(54).ToString()
            tblMaterialDescription.Rows(5).Cells("Pp90").Value = row.ItemArray(55).ToString()
            tblMaterialDescription.Rows(5).Cells("Pp45").Value = row.ItemArray(56).ToString()
            tblMaterialDescription.Rows(5).Cells("bendPp").Value = row.ItemArray(57).ToString()
            tblMaterialDescription.Rows(5).Cells("teePp").Value = row.ItemArray(58).ToString()
            tblMaterialDescription.Rows(5).Cells("ReducPp").Value = row.ItemArray(59).ToString()
            tblMaterialDescription.Rows(5).Cells("capPp").Value = row.ItemArray(60).ToString()
            tblMaterialDescription.Rows(5).Cells("pairPp").Value = row.ItemArray(61).ToString()
            tblMaterialDescription.Rows(5).Cells("valvePp").Value = row.ItemArray(62).ToString()
            tblMaterialDescription.Rows(5).Cells("controlPp").Value = row.ItemArray(63).ToString()
            tblMaterialDescription.Rows(5).Cells("weldPp").Value = row.ItemArray(64).ToString()
            tblMaterialDescription.Rows(5).Cells("cutOutPp").Value = row.ItemArray(65).ToString()
            tblMaterialDescription.Rows(5).Cells("supportPp").Value = row.ItemArray(66).ToString()
            '67->76
            txtNameReq.Text = row.ItemArray(67)
            txtTitleReq.Text = row.ItemArray(68)
            dtpDateReq.Value = validarFechaParaVB(row.ItemArray(69).ToString)
            txtCompanyReq.Text = row.ItemArray(70)
            txtNameUpdate.Text = row.ItemArray(71)
            txtTitleUpdate.Text = row.ItemArray(72)
            dtpDateUpdate.Value = validarFechaParaVB(row.ItemArray(73).ToString)
            txtBasicForNum.Text = row.ItemArray(74)
            dtpDateWE.Value = validarFechaParaVB(row.ItemArray(75).ToString())
            txtNote.Text = row.ItemArray(76)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub tblHistoryRFIPiping_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles tblHistoryRFIPiping.CellDoubleClick
        Dim selectRow As DataGridViewRow = tblHistoryRFIPiping.Rows(e.RowIndex)
        Dim listRow() As DataRow = tblRFIPipingHistory.Select("idRFIPp='" + selectRow.Cells("idRFI").Value + "' and idTag = '" + idTagPp + "'")
        If listRow.Length > 0 Then
            btnDelete.Enabled = True
            llenarDatosRFI(listRow(0))
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If idDrawingNum <> "" And idTagPp <> "" Then
                If tblHistoryRFIPiping.SelectedRows.Count = 1 Then
                    Dim idRFIDelete As String = tblHistoryRFIPiping.SelectedRows(0).Cells(0).Value
                    MessageBox.Show("Are you sure to Delete the RFI: " + idRFIDelete + "?" + vbCrLf + "If the RFI is beetwen of others RFI, the next of this will take the lasted Equipment RFI information." + vbCrLf + "In the case that the selected RFI be the last one, the Equipment Estimation will take the lasted Equipment RFI Information.", "Importatn", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Dim idRFINext = ""
                    If (tblHistoryRFIPiping.Rows.Count - 1) > tblHistoryRFIPiping.SelectedRows(0).Index Then
                        idRFINext = tblHistoryRFIPiping.Rows(tblHistoryRFIPiping.SelectedRows(0).Index + 1).Cells(0).Value
                    End If
                    If mtdRFIPiping.deleteRFIPiping(idRFIDelete, idTagPp, idDrawingNum, idRFINext) Then
                        If txtIdRFIPiping.Text = idRFIDelete Then
                            txtIdRFIPiping.Text = ""
                            txtIdRFIPiping.Enabled = False
                            limpiarTablas(True)
                            limpiarInfoExtra()
                            tbltagPp = mtdRFIPiping.selectTagDrawing(idDrawingNum)
                            tblRFIPipingHistory = mtdRFIPiping.selectRFIPiping(idTagPp, idDrawingNum)
                            llenarTablaHistory()
                            Dim rowsList() As Data.DataRow = tbltagPp.Select(" idTag = '" + idTagPp + "' and idDrawingNum = '" + idDrawingNum + "'")
                            If rowsList.Length > 0 Then

                            End If
                        End If
                    End If
                Else
                    MessageBox.Show("Please selet Only one row on the History RFI Scafdold to delete.", "Importatn", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
                btnDelete.Enabled = False
            Else
                MessageBox.Show("Please Selet a Scaffold Tag to continue.", "Importatn", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Private Sub btnReportRFIScaffold_Click(sender As Object, e As EventArgs) Handles btnReportRFIScaffold.Click
        Dim rpt As New RFIReports
        rpt.TypeRFI = "Piping"
        rpt.idDrawingNum = idDrawingNum
        rpt.idTag = idTagPp
        rpt.idRFI = txtIdRFIPiping.Text
        rpt.Show()
    End Sub
End Class
Public Class RFIPPClass
    Private _idRFIPp As String
    Private _tag As Integer
    Private _idDrawingNum As String
    Private _oldSize As Decimal
    Private _oldElevation As Integer
    Private _oldSystem As String
    Private _oldOption As String
    Private _oldType As String
    Private _oldThick As Decimal
    Private _oldIdJacket As String
    Private _oldIdLaborRatePnt As String
    Private _oldLFtPnt As Decimal
    Private _oldP90Pnt As Integer
    Private _oldP45Pnt As Integer
    Private _oldPTeePnt As Integer
    Private _oldPPairPnt As Integer
    Private _oldPVlvPnt As Integer
    Private _oldPControlPnt As Integer
    Private _oldPWeldPnt As Integer
    Private _oldIdLaborRateII As String
    Private _oldLFtII As Decimal
    Private _oldIdLaborRateRmv As String
    Private _oldLFtRmv As Decimal
    Private _oldP90II As Integer
    Private _oldP45II As Integer
    Private _oldPBendII As Integer
    Private _oldPTeeII As Integer
    Private _oldPReducII As Integer
    Private _oldPCapsII As Integer
    Private _oldPPairII As Integer
    Private _oldPVlvII As Integer
    Private _oldPControlII As Integer
    Private _oldPWeldII As Integer
    Private _oldPCutOutII As Integer
    Private _oldPsupportII As Integer

    Private _newSize As Decimal
    Private _newElevation As Integer
    Private _newSystem As String
    Private _newOption As String
    Private _newType As String
    Private _newThick As Decimal
    Private _newIdJacket As String
    Private _newIdLaborRatePnt As String
    Private _newLFtPnt As Decimal
    Private _newP90Pnt As Integer
    Private _newP45Pnt As Integer
    Private _newPTeePnt As Integer
    Private _newPPairPnt As Integer
    Private _newPVlvPnt As Integer
    Private _newPControlPnt As Integer
    Private _newPWeldPnt As Integer
    Private _newIdLaborRateII As String
    Private _newLFtII As Decimal
    Private _newIdLaborRateRmv As String
    Private _newLFtRmv As Decimal
    Private _newP90II As Integer
    Private _newP45II As Integer
    Private _newPBendII As Integer
    Private _newPTeeII As Integer
    Private _newPReducII As Integer
    Private _newPCapsII As Integer
    Private _newPPairII As Integer
    Private _newPVlvII As Integer
    Private _newPControlII As Integer
    Private _newPWeldII As Integer
    Private _newPCutOutII As Integer
    Private _newPsupportII As Integer

    Private _reqEmployee As String
    Private _reqTitleEmployee As String
    Private _reqCompany As String
    Private _chUpEmployee As String
    Private _chUpTitleEmployee As String
    Private _note As String
    Private _basicFCR As Decimal
    Private _reqDate As Date
    Private _chUpDate As Date
    Private _weDate As Date

    Public Property OldPsupportII As Integer
        Get
            If _oldPsupportII = Nothing Then
                _oldPsupportII = 0
            End If
            Return _oldPsupportII
        End Get
        Set(value As Integer)
            _oldPsupportII = value
        End Set
    End Property
    Public Property IdRFIPp As String
        Get
            If _idRFIPp = Nothing Then
                _idRFIPp = ""
            End If
            Return _idRFIPp
        End Get
        Set(value As String)
            _idRFIPp = value
        End Set
    End Property
    Public Property Tag As Integer
        Get
            If _tag = Nothing Then
                _tag = ""
            End If
            Return _tag
        End Get
        Set(value As Integer)
            _tag = value
        End Set
    End Property
    Public Property IdDrawingNum As String
        Get
            If _idDrawingNum = Nothing Then
                _idDrawingNum = ""
            End If
            Return _idDrawingNum
        End Get
        Set(value As String)
            _idDrawingNum = value
        End Set
    End Property
    Public Property NewSize As Decimal
        Get
            If _newSize = Nothing Then
                _newSize = 0
            End If
            Return _newSize
        End Get
        Set(value As Decimal)
            _newSize = value
        End Set
    End Property
    Public Property NewElevation As Integer
        Get
            If _newElevation = Nothing Then
                _newElevation = 0
            End If
            Return _newElevation
        End Get
        Set(value As Integer)
            _newElevation = value
        End Set
    End Property
    Public Property NewSystem As String
        Get
            If _newSystem = Nothing Then
                _newSystem = ""
            End If
            Return _newSystem
        End Get
        Set(value As String)
            _newSystem = value
        End Set
    End Property
    Public Property NewOption As String
        Get
            If _newOption = Nothing Then
                _newOption = ""
            End If
            Return _newOption
        End Get
        Set(value As String)
            _newOption = value
        End Set
    End Property
    Public Property NewType As String
        Get
            If _newType = Nothing Then
                _newType = ""
            End If
            Return _newType
        End Get
        Set(value As String)
            _newType = value
        End Set
    End Property
    Public Property NewThick As Decimal
        Get
            If _newThick = Nothing Then
                _newThick = 0
            End If
            Return _newThick
        End Get
        Set(value As Decimal)
            _newThick = value
        End Set
    End Property
    Public Property NewIdJacket As String
        Get
            If _newIdJacket = Nothing Then
                _newIdJacket = ""
            End If
            Return _newIdJacket
        End Get
        Set(value As String)
            _newIdJacket = value
        End Set
    End Property
    Public Property NewIdLaborRatePnt As String
        Get
            If _newIdLaborRatePnt = Nothing Then
                _newIdLaborRatePnt = ""
            End If
            Return _newIdLaborRatePnt
        End Get
        Set(value As String)
            _newIdLaborRatePnt = value
        End Set
    End Property
    Public Property NewLFtPnt As Decimal
        Get
            If _newLFtPnt = Nothing Then
                _newLFtPnt = 0
            End If
            Return _newLFtPnt
        End Get
        Set(value As Decimal)
            _newLFtPnt = value
        End Set
    End Property
    Public Property NewP90Pnt As Integer
        Get
            If _newP90Pnt = Nothing Then
                _newP90Pnt = 0
            End If
            Return _newP90Pnt
        End Get
        Set(value As Integer)
            _newP90Pnt = value
        End Set
    End Property
    Public Property NewP45Pnt As Integer
        Get
            If _newP45Pnt = Nothing Then
                _newP45Pnt = 0
            End If
            Return _newP45Pnt
        End Get
        Set(value As Integer)
            _newP45Pnt = value
        End Set
    End Property
    Public Property NewPTeePnt As Integer
        Get
            If _newPTeePnt = Nothing Then
                _newPTeePnt = 0
            End If
            Return _newPTeePnt
        End Get
        Set(value As Integer)
            _newPTeePnt = value
        End Set
    End Property
    Public Property NewPPairPnt As Integer
        Get
            If _newPPairPnt = Nothing Then
                _newPPairPnt = 0
            End If
            Return _newPPairPnt
        End Get
        Set(value As Integer)
            _newPPairPnt = value
        End Set
    End Property
    Public Property NewPVlvPnt As Integer
        Get
            If _newPVlvPnt = Nothing Then
                _newPVlvPnt = 0
            End If
            Return _newPVlvPnt
        End Get
        Set(value As Integer)
            _newPVlvPnt = value
        End Set
    End Property
    Public Property NewPControlPnt As Integer
        Get
            If _newPControlPnt = Nothing Then
                _newPControlPnt = 0
            End If
            Return _newPControlPnt
        End Get
        Set(value As Integer)
            _newPControlPnt = value
        End Set
    End Property
    Public Property NewPWeldPnt As Integer
        Get
            If _newPWeldPnt = Nothing Then
                _newPWeldPnt = 0
            End If
            Return _newPWeldPnt
        End Get
        Set(value As Integer)
            _newPWeldPnt = value
        End Set
    End Property
    Public Property NewIdLaborRateII As String
        Get
            If _newIdLaborRateII = Nothing Then
                _newIdLaborRateII = ""
            End If
            Return _newIdLaborRateII
        End Get
        Set(value As String)
            _newIdLaborRateII = value
        End Set
    End Property
    Public Property NewLFtII As Decimal
        Get
            If _newLFtII = Nothing Then
                _newLFtII = 0
            End If
            Return _newLFtII
        End Get
        Set(value As Decimal)
            _newLFtII = value
        End Set
    End Property
    Public Property NewIdLaborRateRmv As String
        Get
            If _newIdLaborRateRmv = Nothing Then
                _newIdLaborRateRmv = ""
            End If
            Return _newIdLaborRateRmv
        End Get
        Set(value As String)
            _newIdLaborRateRmv = value
        End Set
    End Property
    Public Property NewLFtRmv As Decimal
        Get
            If _newLFtRmv = Nothing Then
                _newLFtRmv = 0
            End If
            Return _newLFtRmv
        End Get
        Set(value As Decimal)
            _newLFtRmv = value
        End Set
    End Property
    Public Property NewP90II As Integer
        Get
            If _newP90II = Nothing Then
                _newP90II = 0
            End If
            Return _newP90II
        End Get
        Set(value As Integer)
            _newP90II = value
        End Set
    End Property
    Public Property NewP45II As Integer
        Get
            If _newP45II = Nothing Then
                _newP45II = 0
            End If
            Return _newP45II
        End Get
        Set(value As Integer)
            _newP45II = value
        End Set
    End Property
    Public Property NewPBendII As Integer
        Get
            If _newPBendII = Nothing Then
                _newPBendII = 0
            End If
            Return _newPBendII
        End Get
        Set(value As Integer)
            _newPBendII = value
        End Set
    End Property
    Public Property NewPTeeII As Integer
        Get
            If _newPTeeII = Nothing Then
                _newPTeeII = 0
            End If
            Return _newPTeeII
        End Get
        Set(value As Integer)
            _newPTeeII = value
        End Set
    End Property
    Public Property NewPReducII As Integer
        Get
            If _newPReducII = Nothing Then
                _newPReducII = 0
            End If
            Return _newPReducII
        End Get
        Set(value As Integer)
            _newPReducII = value
        End Set
    End Property
    Public Property NewPCapsII As Integer
        Get
            If _newPCapsII = Nothing Then
                _newPCapsII = 0
            End If
            Return _newPCapsII
        End Get
        Set(value As Integer)
            _newPCapsII = value
        End Set
    End Property
    Public Property NewPPairII As Integer
        Get
            If _newPPairII = Nothing Then
                _newPPairII = 0
            End If
            Return _newPPairII
        End Get
        Set(value As Integer)
            _newPPairII = value
        End Set
    End Property
    Public Property NewPVlvII As Integer
        Get
            If _newPVlvII = Nothing Then
                _newPVlvII = 0
            End If
            Return _newPVlvII
        End Get
        Set(value As Integer)
            _newPVlvII = value
        End Set
    End Property
    Public Property NewPControlII As Integer
        Get
            If _newPControlII = Nothing Then
                _newPControlII = 0
            End If
            Return _newPControlII
        End Get
        Set(value As Integer)
            _newPControlII = value
        End Set
    End Property
    Public Property NewPWeldII As Integer
        Get
            If _newPWeldII = Nothing Then
                _newPWeldII = 0
            End If
            Return _newPWeldII
        End Get
        Set(value As Integer)
            _newPWeldII = value
        End Set
    End Property
    Public Property NewPCutOutII As Integer
        Get
            If _newPCutOutII = Nothing Then
                _newPCutOutII = 0
            End If
            Return _newPCutOutII
        End Get
        Set(value As Integer)
            _newPCutOutII = value
        End Set
    End Property
    Public Property NewPsupportII As Integer
        Get
            If _newPsupportII = Nothing Then
                _newPsupportII = 0
            End If
            Return _newPsupportII
        End Get
        Set(value As Integer)
            _newPsupportII = value
        End Set
    End Property
    Public Property OldSize As Decimal
        Get
            If _oldSize = Nothing Then
                _oldSize = 0
            End If
            Return _oldSize
        End Get
        Set(value As Decimal)
            _oldSize = value
        End Set
    End Property
    Public Property OldElevation As Integer
        Get
            If _oldElevation = Nothing Then
                _oldElevation = 0
            End If
            Return _oldElevation
        End Get
        Set(value As Integer)
            _oldElevation = value
        End Set
    End Property
    Public Property OldSystem As String
        Get
            If _oldSystem = Nothing Then
                _oldSystem = ""
            End If
            Return _oldSystem
        End Get
        Set(value As String)
            _oldSystem = value
        End Set
    End Property
    Public Property OldOption As String
        Get
            If _oldOption = Nothing Then
                _oldOption = ""
            End If
            Return _oldOption
        End Get
        Set(value As String)
            _oldOption = value
        End Set
    End Property
    Public Property OldType As String
        Get
            If _oldType = Nothing Then
                _oldType = ""
            End If
            Return _oldType
        End Get
        Set(value As String)
            _oldType = value
        End Set
    End Property
    Public Property OldThick As Decimal
        Get
            If _oldThick = Nothing Then
                _oldThick = 0
            End If
            Return _oldThick
        End Get
        Set(value As Decimal)
            _oldThick = value
        End Set
    End Property
    Public Property OldIdJacket As String
        Get
            If _oldIdJacket = Nothing Then
                _oldIdJacket = ""
            End If
            Return _oldIdJacket
        End Get
        Set(value As String)
            _oldIdJacket = value
        End Set
    End Property
    Public Property OldIdLaborRatePnt As String
        Get
            If _oldIdLaborRatePnt = Nothing Then
                _oldIdLaborRatePnt = ""
            End If
            Return _oldIdLaborRatePnt
        End Get
        Set(value As String)
            _oldIdLaborRatePnt = value
        End Set
    End Property
    Public Property OldLFtPnt As Decimal
        Get
            If _oldLFtPnt = Nothing Then
                _oldLFtPnt = 0
            End If
            Return _oldLFtPnt
        End Get
        Set(value As Decimal)
            _oldLFtPnt = value
        End Set
    End Property
    Public Property OldP90Pnt As Integer
        Get
            If _oldP90Pnt = Nothing Then
                _oldP90Pnt = 0
            End If
            Return _oldP90Pnt
        End Get
        Set(value As Integer)
            _oldP90Pnt = value
        End Set
    End Property
    Public Property OldP45Pnt As Integer
        Get
            If _oldP45Pnt = Nothing Then
                _oldP45Pnt = 0
            End If
            Return _oldP45Pnt
        End Get
        Set(value As Integer)
            _oldP45Pnt = value
        End Set
    End Property
    Public Property OldPTeePnt As Integer
        Get
            If _oldPTeePnt = Nothing Then
                _oldPTeePnt = 0
            End If
            Return _oldPTeePnt
        End Get
        Set(value As Integer)
            _oldPTeePnt = value
        End Set
    End Property
    Public Property OldPPairPnt As Integer
        Get
            If _oldPPairPnt = Nothing Then
                _oldPPairPnt = 0
            End If
            Return _oldPPairPnt
        End Get
        Set(value As Integer)
            _oldPPairPnt = value
        End Set
    End Property
    Public Property OldPVlvPnt As Integer
        Get
            If _oldPVlvPnt = Nothing Then
                _oldPVlvPnt = 0
            End If
            Return _oldPVlvPnt
        End Get
        Set(value As Integer)
            _oldPVlvPnt = value
        End Set
    End Property
    Public Property OldPControlPnt As Integer
        Get
            If _oldPControlPnt = Nothing Then
                _oldPControlPnt = 0
            End If
            Return _oldPControlPnt
        End Get
        Set(value As Integer)
            _oldPControlPnt = value
        End Set
    End Property
    Public Property OldPWeldPnt As Integer
        Get
            If _oldPWeldPnt = Nothing Then
                _oldPWeldPnt = 0
            End If
            Return _oldPWeldPnt
        End Get
        Set(value As Integer)
            _oldPWeldPnt = value
        End Set
    End Property
    Public Property OldIdLaborRateII As String
        Get
            If _oldIdLaborRateII = Nothing Then
                _oldIdLaborRateII = ""
            End If
            Return _oldIdLaborRateII
        End Get
        Set(value As String)
            _oldIdLaborRateII = value
        End Set
    End Property
    Public Property OldLFtII As Decimal
        Get
            If _oldLFtII = Nothing Then
                _oldLFtII = 0
            End If
            Return _oldLFtII
        End Get
        Set(value As Decimal)
            _oldLFtII = value
        End Set
    End Property
    Public Property OldIdLaborRateRmv As String
        Get
            If _oldIdLaborRateRmv = Nothing Then
                _oldIdLaborRateRmv = ""
            End If
            Return _oldIdLaborRateRmv
        End Get
        Set(value As String)
            _oldIdLaborRateRmv = value
        End Set
    End Property
    Public Property OldLFtRmv As Decimal
        Get
            If _oldLFtRmv = Nothing Then
                _oldLFtRmv = 0
            End If
            Return _oldLFtRmv
        End Get
        Set(value As Decimal)
            _oldLFtRmv = value
        End Set
    End Property
    Public Property OldP90II As Integer
        Get
            If _oldP90II = Nothing Then
                _oldP90II = 0
            End If
            Return _oldP90II
        End Get
        Set(value As Integer)
            _oldP90II = value
        End Set
    End Property
    Public Property OldP45II As Integer
        Get
            If _oldP45II = Nothing Then
                _oldP45II = 0
            End If
            Return _oldP45II
        End Get
        Set(value As Integer)
            _oldP45II = value
        End Set
    End Property
    Public Property OldPBendII As Integer
        Get
            If _oldPBendII = Nothing Then
                _oldPBendII = 0
            End If
            Return _oldPBendII
        End Get
        Set(value As Integer)
            _oldPBendII = value
        End Set
    End Property
    Public Property OldPTeeII As Integer
        Get
            If _oldPTeeII = Nothing Then
                _oldPTeeII = 0
            End If
            Return _oldPTeeII
        End Get
        Set(value As Integer)
            _oldPTeeII = value
        End Set
    End Property
    Public Property OldPReducII As Integer
        Get
            If _oldPReducII = Nothing Then
                _oldPReducII = 0
            End If
            Return _oldPReducII
        End Get
        Set(value As Integer)
            _oldPReducII = value
        End Set
    End Property
    Public Property OldPCapsII As Integer
        Get
            If _oldPCapsII = Nothing Then
                _oldPCapsII = 0
            End If
            Return _oldPCapsII
        End Get
        Set(value As Integer)
            _oldPCapsII = value
        End Set
    End Property
    Public Property OldPPairII As Integer
        Get
            If _oldPPairII = Nothing Then
                _oldPPairII = 0
            End If
            Return _oldPPairII
        End Get
        Set(value As Integer)
            _oldPPairII = value
        End Set
    End Property
    Public Property OldPVlvII As Integer
        Get
            If _oldPVlvII = Nothing Then
                _oldPVlvII = 0
            End If
            Return _oldPVlvII
        End Get
        Set(value As Integer)
            _oldPVlvII = value
        End Set
    End Property
    Public Property OldPControlII As Integer
        Get
            If _oldPControlII = Nothing Then
                _oldPControlII = 0
            End If
            Return _oldPControlII
        End Get
        Set(value As Integer)
            _oldPControlII = value
        End Set
    End Property
    Public Property OldPWeldII As Integer
        Get
            If _oldPWeldII = Nothing Then
                _oldPWeldII = 0
            End If
            Return _oldPWeldII
        End Get
        Set(value As Integer)
            _oldPWeldII = value
        End Set
    End Property
    Public Property OldPCutOutII As Integer
        Get
            If _oldPCutOutII = Nothing Then
                _oldPCutOutII = 0
            End If
            Return _oldPCutOutII
        End Get
        Set(value As Integer)
            _oldPCutOutII = value
        End Set
    End Property
    Public Property ReqEmployee As String
        Get
            If _reqEmployee = Nothing Then
                _reqEmployee = ""
            End If
            Return _reqEmployee
        End Get
        Set(value As String)
            _reqEmployee = value
        End Set
    End Property
    Public Property ReqTitleEmployee As String
        Get
            If _reqTitleEmployee = Nothing Then
                _reqTitleEmployee = ""
            End If
            Return _reqTitleEmployee
        End Get
        Set(value As String)
            _reqTitleEmployee = value
        End Set
    End Property
    Public Property ReqCompany As String
        Get
            If _reqCompany = Nothing Then
                _reqCompany = ""
            End If
            Return _reqCompany
        End Get
        Set(value As String)
            _reqCompany = value
        End Set
    End Property
    Public Property ChUpEmployee As String
        Get
            If _chUpEmployee = Nothing Then
                _chUpEmployee = ""
            End If
            Return _chUpEmployee
        End Get
        Set(value As String)
            _chUpEmployee = value
        End Set
    End Property
    Public Property ChUpTitleEmployee As String
        Get
            If _chUpTitleEmployee = Nothing Then
                _chUpTitleEmployee = ""
            End If
            Return _chUpTitleEmployee
        End Get
        Set(value As String)
            _chUpTitleEmployee = value
        End Set
    End Property
    Public Property Note As String
        Get
            If _note = Nothing Then
                _note = ""
            End If
            Return _note
        End Get
        Set(value As String)
            _note = value
        End Set
    End Property
    Public Property BasicFCR As Decimal
        Get
            If _basicFCR = Nothing Then
                _basicFCR = 0
            End If
            Return _basicFCR
        End Get
        Set(value As Decimal)
            _basicFCR = value
        End Set
    End Property
    Public Property ReqDate As Date
        Get
            If _reqDate = Nothing Then
                _reqDate = Date.Today
            End If
            Return _reqDate
        End Get
        Set(value As Date)
            _reqDate = value
        End Set
    End Property
    Public Property ChUpDate As Date
        Get
            If _chUpDate = Nothing Then
                _chUpDate = Date.Today
            End If
            Return _chUpDate
        End Get
        Set(value As Date)
            _chUpDate = value
        End Set
    End Property
    Public Property WeDate As Date
        Get
            If _weDate = Nothing Then
                _weDate = Date.Today
            End If
            Return _weDate
        End Get
        Set(value As Date)
            _weDate = value
        End Set
    End Property
End Class