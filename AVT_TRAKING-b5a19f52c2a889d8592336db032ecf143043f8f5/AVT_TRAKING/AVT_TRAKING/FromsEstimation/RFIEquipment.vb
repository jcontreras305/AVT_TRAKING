Public Class RFIEquipment
    Dim tblDr As New Data.DataTable
    Dim tblTagEq As New Data.DataTable
    Dim tblTypeThick As New Data.DataTable
    Dim idDrawingNum As String = ""
    Dim idTagEq As String = ""
    Dim idRFIEq As String = ""
    Dim tblRFIEquipmentHistory As New Data.DataTable
    Dim mtdRFIEquipment As New MetodosRFIEquipment
    Private Sub RFIEquipment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tblGeneralEquipment.Rows.Add()
        tblGeneralEquipment.Rows.Add()
        tblGeneralEquipment.Rows(0).Cells(0).Value = ("Old")
        tblGeneralEquipment.Rows(1).Cells(0).Value = ("New")
        tblGeneralEquipment.Rows(0).DefaultCellStyle.BackColor = Color.LightGray
        tblGeneralEquipment.Rows(0).ReadOnly = True
        tblGeneralEquipment.Rows(1).Cells(0).Style.BackColor = Color.LightGray
        tblPaintEq.Rows.Add()
        tblPaintEq.Rows.Add()
        tblPaintEq.Rows(0).DefaultCellStyle.BackColor = Color.LightGray
        tblPaintEq.Rows(0).ReadOnly = True
        tblInsRemoval.Rows.Add()
        tblInsRemoval.Rows.Add()
        tblInsRemoval.Rows(0).DefaultCellStyle.BackColor = Color.LightGray
        tblInsRemoval.Rows(0).ReadOnly = True
        tblInsInsulation.Rows.Add()
        tblInsInsulation.Rows.Add()
        tblInsInsulation.Rows(0).DefaultCellStyle.BackColor = Color.LightGray
        tblInsInsulation.Rows(0).ReadOnly = True
        tblGeneralEquipment.DefaultCellStyle.ForeColor = Color.Black
        tblPaintEq.DefaultCellStyle.ForeColor = Color.Black
        tblInsInsulation.DefaultCellStyle.ForeColor = Color.Black
        tblInsRemoval.DefaultCellStyle.ForeColor = Color.Black

        tblDr = mtdRFIEquipment.selectDrawing(cmbDrawing)
        tblTagEq = mtdRFIEquipment.selectTagDrawing("", cmbTag)
        btnDelete.Enabled = False
    End Sub
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub cmbDrawing_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDrawing.SelectedIndexChanged
        Try
            Dim array() As String = cmbDrawing.SelectedItem.ToString.Split("|")
            If array.Length > 0 Then
                If idDrawingNum <> array(0) Then
                    idDrawingNum = array(0)
                    idTagEq = ""
                    tblTagEq = mtdRFIEquipment.selectTagDrawing(idDrawingNum, cmbTag)
                    tblDr = mtdRFIEquipment.selectDrawing() 'consultamos la tabla por si cambio algun valor 
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
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmbTag_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTag.SelectedIndexChanged
        Try
            If cmbTag.SelectedItem IsNot Nothing And idDrawingNum <> "" Then
                idTagEq = cmbTag.SelectedItem.ToString()
                tblTagEq = mtdRFIEquipment.selectTagDrawing(idDrawingNum)
                tblRFIEquipmentHistory = mtdRFIEquipment.selectRFIEquipment(idTagEq, idDrawingNum)
                Dim rowsList() As Data.DataRow = tblTagEq.Select("idTag = '" + idTagEq + "' and idDrawingNum = '" + idDrawingNum + "'")
                limpiarTablas(True)
                limpiarInfoExtra()
                llenarTablaHistory()
                If rowsList.Length > 0 Then
                    '{"idTag", "description", 0<->1
                    '"elevation", 2
                    '"wwPaint", "system", "option", "sqrFtPnt", 3<->6
                    '"wwRemove", "remove", "sqrFtRmv", 7<->9
                    '"wwInstall", "type", "thick", "jacket", "sqrFtII", "bevel", "cutout", 10<->16
                    '"idDrawingNum" 17
                    'txtIdRFIEquipment.Text = rowsList(0).ItemArray(0)

                    tblGeneralEquipment.Rows(0).Cells(1).Value = rowsList(0).ItemArray(2)
                    'tblGeneralEquipment.Rows(1).Cells(1).Value = rowsList(0).ItemArray(18)

                    tblPaintEq.Rows(0).Cells(0).Value = rowsList(0).ItemArray(3).ToString()
                    tblPaintEq.Rows(0).Cells(1).Value = rowsList(0).ItemArray(4).ToString()
                    tblPaintEq.Rows(0).Cells(2).Value = rowsList(0).ItemArray(5).ToString()
                    tblPaintEq.Rows(0).Cells(3).Value = rowsList(0).ItemArray(6).ToString()
                    'tblPaintEq.Rows(1).Cells(0).Value = rowsList(0).ItemArray(19).ToString()
                    'tblPaintEq.Rows(1).Cells(1).Value = rowsList(0).ItemArray(20).ToString()
                    'tblPaintEq.Rows(1).Cells(2).Value = rowsList(0).ItemArray(21).ToString()
                    'tblPaintEq.Rows(1).Cells(3).Value = rowsList(0).ItemArray(22).ToString()

                    tblInsRemoval.Rows(0).Cells(0).Value = rowsList(0).ItemArray(7).ToString()
                    tblInsRemoval.Rows(0).Cells(1).Value = If(rowsList(0).ItemArray(8) = "True", True, False)
                    tblInsRemoval.Rows(0).Cells(2).Value = rowsList(0).ItemArray(9).ToString()
                    'tblInsRemoval.Rows(1).Cells(0).Value = rowsList(0).ItemArray(23).ToString()
                    'tblInsRemoval.Rows(1).Cells(1).Value = rowsList(0).ItemArray(24).ToString()
                    'tblInsRemoval.Rows(1).Cells(2).Value = rowsList(0).ItemArray(25).ToString()

                    tblInsInsulation.Rows(0).Cells(0).Value = rowsList(0).ItemArray(10).ToString()
                    tblInsInsulation.Rows(0).Cells(1).Value = rowsList(0).ItemArray(11).ToString()
                    tblInsInsulation.Rows(0).Cells(2).Value = rowsList(0).ItemArray(12).ToString()
                    tblInsInsulation.Rows(0).Cells(3).Value = rowsList(0).ItemArray(13).ToString()
                    tblInsInsulation.Rows(0).Cells(4).Value = rowsList(0).ItemArray(14).ToString()
                    tblInsInsulation.Rows(0).Cells(5).Value = rowsList(0).ItemArray(15).ToString()
                    tblInsInsulation.Rows(0).Cells(6).Value = rowsList(0).ItemArray(16).ToString()
                    'tblInsInsulation.Rows(1).Cells(0).Value = rowsList(0).ItemArray(26).ToString()
                    'tblInsInsulation.Rows(1).Cells(1).Value = rowsList(0).ItemArray(27).ToString()
                    'tblInsInsulation.Rows(1).Cells(2).Value = rowsList(0).ItemArray(28).ToString()
                    'tblInsInsulation.Rows(1).Cells(3).Value = rowsList(0).ItemArray(29).ToString()
                    'tblInsInsulation.Rows(1).Cells(4).Value = rowsList(0).ItemArray(30).ToString()
                    'tblInsInsulation.Rows(1).Cells(5).Value = rowsList(0).ItemArray(31).ToString()
                    'tblInsInsulation.Rows(1).Cells(6).Value = rowsList(0).ItemArray(32).ToString()

                Else
                    MessageBox.Show("Is probably that the drawing was deleted or updated please try again or close this window.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub tblGeneralEquipment_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles tblGeneralEquipment.CellEndEdit
        If e.ColumnIndex = 1 And e.RowIndex = 1 Then
            validaCeldaSoloNumero(tblGeneralEquipment, e.ColumnIndex)
        End If
    End Sub

    Private Sub tblPaintEq_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles tblPaintEq.CellEndEdit
        If e.ColumnIndex = 3 And e.RowIndex = 1 Then
            validaCeldaSoloNumero(tblPaintEq, e.ColumnIndex)
        End If
    End Sub

    Private Sub tblInsRemoval_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles tblInsRemoval.CellEndEdit
        If e.ColumnIndex = 2 And e.RowIndex = 1 Then
            validaCeldaSoloNumero(tblInsRemoval, e.ColumnIndex)
        End If
    End Sub

    Private Sub tblInsInsulation_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles tblInsInsulation.CellEndEdit
        If ((e.ColumnIndex = 2) Or (e.ColumnIndex >= 4 And e.ColumnIndex <= 6)) And e.RowIndex = 1 Then
            validaCeldaSoloNumero(tblInsInsulation, e.ColumnIndex)
            If e.ColumnIndex = 2 And tblInsInsulation.Rows(1).Cells("typeII").Value IsNot Nothing Then
                If tblInsInsulation.Rows(1).Cells("typeII").Value <> "" Then
                    tblTypeThick = mtdRFIEquipment.llenarCmbCellEqInsUnitRate()
                    Dim arrayList() As Data.DataRow = tblTypeThick.Select("type = '" + tblInsInsulation.Rows(1).Cells("typeII").Value.ToString() + "' and thick = '" + tblInsInsulation.Rows(1).Cells("thickII").Value.ToString() + "' ")
                    If Not arrayList.Length > 0 Then
                        tblInsInsulation.Rows(1).Cells("thickII").Value = "0"
                        MessageBox.Show("The Thick of this Material was not regitrated, please assign a valid thick or Add the thick on the table Equipment Insulation Unit Rate.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub validaCeldaSoloNumero(ByVal tbl As DataGridView, ByVal columnIndex As Integer)
        Try
            If tbl.Rows(1).Cells(columnIndex).Value IsNot DBNull.Value And tbl.Rows(1).Cells(columnIndex).Value <> "" Then
                If soloNumero(tbl.Rows(1).Cells(columnIndex).Value) Then
                    If Not CDec(tbl.Rows(1).Cells(columnIndex).Value) >= 0 Then
                        MessageBox.Show("Please enter a valid number.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        tbl.Rows(1).Cells(columnIndex).Value = "0"
                    End If
                Else
                    MessageBox.Show("Please enter a valid number.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    tbl.Rows(1).Cells(columnIndex).Value = "0"
                End If
            Else
                tbl.Rows(1).Cells(columnIndex).Value = "0"
            End If
        Catch ex As Exception
            MessageBox.Show("Please enter a valid number.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Private Sub limpiarTablas(ByVal isNew As Boolean)
        If isNew Then
            tblGeneralEquipment.Rows(0).Cells(1).Value = ""
            For index = 0 To tblPaintEq.Columns.Count - 1
                tblPaintEq.Rows(0).Cells(index).Value = ""
            Next
            For index = 0 To tblInsRemoval.Columns.Count - 1
                tblInsRemoval.Rows(0).Cells(index).Value = ""
            Next
            For index = 0 To tblInsInsulation.Columns.Count - 1
                tblInsInsulation.Rows(0).Cells(index).Value = ""
            Next
        End If
        tblGeneralEquipment.Rows.RemoveAt(1)
        tblGeneralEquipment.Rows.Add("New", "")
        tblGeneralEquipment.Rows(1).Cells(0).Style.BackColor = Color.LightGray

        tblPaintEq.Rows.RemoveAt(1)
        tblPaintEq.Rows.Add("", "", "", "0")

        tblInsRemoval.Rows.RemoveAt(1)
        tblInsRemoval.Rows.Add("", False, "0")

        tblInsInsulation.Rows.RemoveAt(1)
        tblInsInsulation.Rows.Add("", "", "0", "", "0", "0", "0")
    End Sub

    Private Sub limpiarInfoExtra()
        txtNameReq.Text = ""
        txtNameUpdate.Text = ""
        txtTitleReq.Text = ""
        txtTitleUpdate.Text = ""
        txtNote.Text = ""
        txtBasicForNum.Text = ""
        txtCompanyReq.Text = ""
        txtIdRFIEquipment.Text = ""
        dtpDateReq.Value = Today.Date
        dtpDateUpdate.Value = Today.Date
        dtpDateWE.Value = Today.Date
    End Sub
    Private Sub llenarTablaHistory()
        If tblRFIEquipmentHistory IsNot Nothing Then
            If tblRFIEquipmentHistory.Rows IsNot Nothing Then
                tblHistoryRFIEquipment.Rows.Clear()
                For Each row As Data.DataRow In tblRFIEquipmentHistory.Rows
                    tblHistoryRFIEquipment.Rows.Add(row.ItemArray(0), row.ItemArray(21), row.ItemArray(23))
                Next
            End If
        End If
    End Sub

    Private Sub tblPaintEq_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles tblPaintEq.CellMouseClick
        Try
            If tblPaintEq.CurrentCell.RowIndex = 1 Then
                Select Case tblPaintEq.CurrentCell.ColumnIndex
                    Case 0 'Labor
                        If tblPaintEq.CurrentCell.GetType.Name = "DataGridViewTextBoxCell" Then
                            Dim cmbWwPaint As New DataGridViewComboBoxCell
                            With cmbWwPaint
                                mtdRFIEquipment.llenarCmbCellLabor(cmbWwPaint)
                                .DropDownWidth = 150
                            End With
                            If tblPaintEq.CurrentCell.Value IsNot Nothing Then
                                Dim flagCmb As Boolean = False
                                For Each item As String In cmbWwPaint.Items
                                    If item = tblPaintEq.CurrentCell.Value Then
                                        flagCmb = True
                                        Exit For
                                    End If
                                Next
                                If flagCmb Then
                                    cmbWwPaint.Value = tblPaintEq.CurrentCell.Value
                                End If
                            End If
                            tblPaintEq.CurrentRow.Cells("idLaborRatePnt") = cmbWwPaint
                        End If
                    Case 1 'System 
                        If tblPaintEq.CurrentCell.GetType.Name = "DataGridViewTextBoxCell" Then
                            Dim cmbSystem As New DataGridViewComboBoxCell
                            With cmbSystem
                                mtdRFIEquipment.llenarCmbCellSystemPaint(cmbSystem)
                                .DropDownWidth = 150
                            End With
                            If tblPaintEq.CurrentCell.Value IsNot Nothing Then
                                Dim flagCmb As Boolean = False
                                For Each item As String In cmbSystem.Items
                                    If item = tblPaintEq.CurrentCell.Value Then
                                        flagCmb = True
                                        Exit For
                                    End If
                                Next
                                If flagCmb Then
                                    cmbSystem.Value = tblPaintEq.CurrentCell.Value
                                End If
                            End If
                            tblPaintEq.CurrentRow.Cells("systemPnt") = cmbSystem
                        End If
                    Case 2 'Option
                        If tblPaintEq.CurrentCell.GetType.Name = "DataGridViewTextBoxCell" Then
                            Dim cmbOption As New DataGridViewComboBoxCell
                            With cmbOption
                                mtdRFIEquipment.llenarCmbCellPaintOption(cmbOption, If(tblPaintEq.Rows(1).Cells("systemPnt").Value IsNot Nothing, tblPaintEq.Rows(1).Cells("systemPnt").Value, If(tblPaintEq.Rows(0).Cells("systemPnt").Value IsNot Nothing, tblPaintEq.Rows(0).Cells("systemPnt").Value, "")))
                                .DropDownWidth = 150
                            End With
                            If tblPaintEq.CurrentCell.Value IsNot Nothing Then
                                Dim flagCmb As Boolean = False
                                For Each item As String In cmbOption.Items
                                    If item = tblPaintEq.CurrentCell.Value Then
                                        flagCmb = True
                                        Exit For
                                    End If
                                Next
                                If flagCmb Then
                                    cmbOption.Value = tblPaintEq.CurrentCell.Value
                                Else
                                    tblPaintEq.CurrentCell.Value = ""
                                End If
                            End If
                            tblPaintEq.CurrentRow.Cells("optionPnt") = cmbOption
                        End If
                End Select
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub
    Private Sub tblPaintEq_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles tblPaintEq.EditingControlShowing
        Dim Index = tblPaintEq.CurrentCell.ColumnIndex
        If Index >= 0 And Index <= 2 Then
            Dim typecell = tblPaintEq.CurrentCell.GetType.ToString
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
            Select Case tblPaintEq.CurrentCell.ColumnIndex
                Case 0
                    tblPaintEq.CurrentCell.Value = cmb.Text
                Case 1
                    If cmb.Text <> tblPaintEq.CurrentCell.Value Then
                        tblPaintEq.CurrentCell.Value = cmb.Text
                        If tblPaintEq.CurrentRow.Cells("optionPnt").Value IsNot Nothing Then
                            If tblPaintEq.CurrentRow.Cells("optionPnt").Value <> "" Then
                                Dim cmbOp As DataGridViewComboBoxCell
                                If tblPaintEq.CurrentRow.Cells("optionPnt").GetType.Name = "DataGridViewTextBoxCell" Then
                                    cmbOp = New DataGridViewComboBoxCell
                                Else
                                    cmbOp = tblPaintEq.Rows(1).Cells(2)
                                End If
                                mtdRFIEquipment.llenarCmbCellPaintOption(cmbOp, cmb.Text)
                                If tblPaintEq.Rows(1).Cells(2).Value IsNot Nothing Then
                                    Dim flagCmb As Boolean = False
                                    For Each item As String In cmbOp.Items
                                        If item = tblPaintEq.CurrentRow.Cells("optionPnt").Value Then
                                            flagCmb = True
                                            Exit For
                                        End If
                                    Next
                                    If flagCmb Then
                                        cmbOp.Value = tblPaintEq.CurrentRow.Cells("optionPnt").Value
                                    Else
                                        tblPaintEq.CurrentRow.Cells("optionPnt").Value = ""
                                    End If
                                End If
                                If tblPaintEq.CurrentCell.GetType.Name = "DataGridViewTextBoxCell" Then
                                    tblPaintEq.CurrentRow.Cells("optionPnt") = cmbOp
                                End If
                            End If
                        End If
                    End If
                Case 2
                    tblPaintEq.CurrentCell.Value = cmb.Text
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tblInsRemoval_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles tblInsRemoval.CellMouseClick
        Try
            Select Case tblInsRemoval.CurrentCell.ColumnIndex
                Case 0
                    If tblInsRemoval.CurrentCell.ColumnIndex = 0 And tblInsRemoval.CurrentCell.RowIndex = 1 Then
                        If tblInsRemoval.CurrentCell.GetType.Name = "DataGridViewTextBoxCell" Then
                            Dim cmbLabor As New DataGridViewComboBoxCell
                            With cmbLabor
                                mtdRFIEquipment.llenarCmbCellLabor(cmbLabor)
                                cmbLabor.DropDownWidth = 200
                            End With
                            If tblInsRemoval.CurrentCell.Value IsNot Nothing Then
                                Dim flagCmb As Boolean = False
                                For Each item As String In cmbLabor.Items
                                    If item = tblInsRemoval.CurrentCell.Value Then
                                        flagCmb = True
                                        Exit For
                                    End If
                                Next
                                If flagCmb Then
                                    cmbLabor.Value = tblPaintEq.CurrentCell.Value
                                Else
                                    tblInsRemoval.CurrentCell.Value = ""
                                End If
                            End If
                            tblInsRemoval.CurrentRow.Cells("idLaborRateRmv") = cmbLabor
                        End If
                    End If
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tblInsRemovalEQ_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles tblInsRemoval.EditingControlShowing
        Dim Index = tblInsRemoval.CurrentCell.ColumnIndex
        If Index = 0 And Index = 2 Then
            Dim typecell = tblInsRemoval.CurrentCell.GetType.ToString
            If Not typecell = "System.Windows.Forms.DataGridViewTextBoxCell" Then
                Dim cb As ComboBox = CType(e.Control, ComboBox)
                If e.Control IsNot Nothing Then
                    RemoveHandler cb.SelectedIndexChanged, AddressOf cmb_SelectedIndexChanguedRmv
                    AddHandler cb.SelectedIndexChanged, AddressOf cmb_SelectedIndexChanguedRmv
                End If
            End If
        End If
    End Sub
    Public Sub cmb_SelectedIndexChanguedRmv(sender As Object, e As EventArgs)
        Dim cmb As ComboBox = CType(sender, ComboBox)
        Select Case tblInsRemoval.CurrentCell.ColumnIndex
            Case 0
                tblInsRemoval.CurrentCell.Value = cmb.Text
        End Select
    End Sub

    Private Sub tblInsInsulation_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles tblInsInsulation.CellMouseClick
        Try
            If tblInsInsulation.CurrentCell.RowIndex = 1 Then
                Select Case tblInsInsulation.CurrentCell.ColumnIndex
                    Case 0
                        If tblInsInsulation.CurrentCell.GetType.Name = "DataGridViewTextBoxCell" Then
                            Dim cmbLabor As New DataGridViewComboBoxCell
                            With cmbLabor
                                mtdRFIEquipment.llenarCmbCellLabor(cmbLabor)
                                cmbLabor.DropDownWidth = 200
                            End With
                            If tblInsInsulation.CurrentCell.Value IsNot Nothing Then
                                Dim flagCmb As Boolean = False
                                For Each item As String In cmbLabor.Items
                                    If item = tblInsInsulation.CurrentCell.Value Then
                                        flagCmb = True
                                        Exit For
                                    End If
                                Next
                                If flagCmb Then
                                    cmbLabor.Value = tblPaintEq.CurrentCell.Value
                                Else
                                    tblInsInsulation.CurrentCell.Value = ""
                                End If
                            End If
                            tblInsInsulation.CurrentRow.Cells("idLaborRateII") = cmbLabor
                        End If
                    Case 1
                        If tblInsInsulation.CurrentCell.GetType.Name = "DataGridViewTextBoxCell" Then
                            Dim cmbType As New DataGridViewComboBoxCell
                            With cmbType
                                tblTypeThick = mtdRFIEquipment.llenarCmbCellEqInsUnitRate(cmbType)
                                cmbType.DropDownWidth = 200
                            End With
                            If tblInsInsulation.CurrentCell.Value IsNot Nothing Then
                                Dim flagCmb As Boolean = False
                                For Each item As String In cmbType.Items
                                    If item = tblInsInsulation.CurrentCell.Value Then
                                        flagCmb = True
                                        Exit For
                                    End If
                                Next
                                If flagCmb Then
                                    cmbType.Value = tblPaintEq.CurrentCell.Value
                                Else
                                    tblInsInsulation.CurrentCell.Value = ""
                                End If
                            End If
                            tblInsInsulation.CurrentRow.Cells("typeII") = cmbType
                        End If
                    Case 3
                        If tblInsInsulation.CurrentCell.GetType.Name = "DataGridViewTextBoxCell" Then
                            Dim cmbJacket As New DataGridViewComboBoxCell
                            With cmbJacket
                                mtdRFIEquipment.llenarCmbCellEqJacket(cmbJacket)
                                cmbJacket.DropDownWidth = 200
                            End With
                            If tblInsInsulation.CurrentCell.Value IsNot Nothing Then
                                Dim flagCmb As Boolean = False
                                For Each item As String In cmbJacket.Items
                                    If item = tblInsInsulation.CurrentCell.Value Then
                                        flagCmb = True
                                        Exit For
                                    End If
                                Next
                                If flagCmb Then
                                    cmbJacket.Value = tblInsInsulation.CurrentCell.Value
                                Else
                                    tblInsInsulation.CurrentCell.Value = ""
                                End If
                            End If
                            tblInsInsulation.CurrentRow.Cells("jacketII") = cmbJacket
                        End If
                End Select
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tblInsInsulation_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles tblInsInsulation.EditingControlShowing
        Dim Index = tblInsInsulation.CurrentCell.ColumnIndex
        If Index = 0 Or Index = 1 Or Index = 3 Then
            Dim typecell = tblInsInsulation.CurrentCell.GetType.ToString
            If Not typecell = "System.Windows.Forms.DataGridViewTextBoxCell" Then
                Dim cb As ComboBox = CType(e.Control, ComboBox)
                If e.Control IsNot Nothing Then
                    RemoveHandler cb.SelectedIndexChanged, AddressOf cmb_SelectedIndexChanguedII
                    AddHandler cb.SelectedIndexChanged, AddressOf cmb_SelectedIndexChanguedII
                End If
            End If
        End If
    End Sub
    Public Sub cmb_SelectedIndexChanguedII(sender As Object, e As EventArgs)
        Dim cmb As ComboBox = CType(sender, ComboBox)
        Select Case tblInsInsulation.CurrentCell.ColumnIndex
            Case 0
                tblInsInsulation.CurrentCell.Value = cmb.Text
            Case 1
                tblInsInsulation.CurrentCell.Value = cmb.Text
                If tblInsInsulation.Rows(1).Cells("thickII").Value IsNot Nothing Then
                    If tblInsInsulation.Rows(1).Cells(2).Value <> "" And tblInsInsulation.Rows(1).Cells(2).Value <> "0" Then
                        Dim rowsList() As Data.DataRow = tblTypeThick.Select("thick = '" + tblInsInsulation.Rows(1).Cells(2).Value.ToString() + "' and type = '" + cmb.Text + "'")
                        If rowsList.Length = 0 Then
                            tblInsInsulation.Rows(1).Cells("thickII").Value = "0"
                            MessageBox.Show("The Thick of this Material was not regitrated, please assign a valid thick or Add the thick on the table Equipment Insulation Unit Rate.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If
                End If
            Case 3
                tblInsInsulation.CurrentCell.Value = cmb.Text
        End Select
    End Sub

    Private Sub btnAddRFIEquipment_Click(sender As Object, e As EventArgs) Handles btnAddRFIEquipment.Click
        If btnAddRFIEquipment.Text = "New" Then
            If idDrawingNum <> "" And idTagEq <> "" Then
                txtIdRFIEquipment.Enabled = True
                btnAddRFIEquipment.Text = "Cancel"
                limpiarTablas(True)
                limpiarInfoExtra()
                txtIdRFIEquipment.Text = mtdRFIEquipment.selectMaxRFIEq(idTagEq, idDrawingNum).ToString()

                tblTagEq = mtdRFIEquipment.selectTagDrawing(idDrawingNum)
                Dim rowsList() As Data.DataRow = tblTagEq.Select(" IdTag = '" + idTagEq + "' and idDrawingNum = '" + idDrawingNum + "'")
                If rowsList.Length > 0 Then
                    'idTag, description, elevation, wwPaint, system, option, sqrFtPnt, wwRemove, remove, sqrFtRmv, wwInstall, type, thick, jacket, sqrFtII, bevel, cutout, idDrawingNum
                    tblGeneralEquipment.Rows(0).Cells("HeigthEq").Value = rowsList(0).ItemArray(2)

                    tblPaintEq.Rows(0).Cells("idLaborRatePnt").Value = rowsList(0).ItemArray(3)
                    tblPaintEq.Rows(0).Cells("systemPnt").Value = rowsList(0).ItemArray(4)
                    tblPaintEq.Rows(0).Cells("optionPnt").Value = rowsList(0).ItemArray(5)
                    tblPaintEq.Rows(0).Cells("sqftPnt").Value = rowsList(0).ItemArray(6)

                    tblInsRemoval.Rows(0).Cells("idLaborRateRmv").Value = rowsList(0).ItemArray(7)
                    tblInsRemoval.Rows(0).Cells("RemoveEq").Value = If(rowsList(0).ItemArray(8) = "True", True, False)
                    tblInsRemoval.Rows(0).Cells("SqftEqRmv").Value = rowsList(0).ItemArray(9)

                    tblInsInsulation.Rows(0).Cells("idLaborRateII").Value = rowsList(0).ItemArray(10)
                    tblInsInsulation.Rows(0).Cells("typeII").Value = rowsList(0).ItemArray(11)
                    tblInsInsulation.Rows(0).Cells("thickII").Value = rowsList(0).ItemArray(12)
                    tblInsInsulation.Rows(0).Cells("jacketII").Value = rowsList(0).ItemArray(13)
                    tblInsInsulation.Rows(0).Cells("sqftII").Value = rowsList(0).ItemArray(14)
                    tblInsInsulation.Rows(0).Cells("bevelII").Value = rowsList(0).ItemArray(15)
                    tblInsInsulation.Rows(0).Cells("cutOutII").Value = rowsList(0).ItemArray(16)
                End If
            Else
                MessageBox.Show("Please select a Drawing No. or Scaffold Tag project to continue.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            btnAddRFIEquipment.Text = "New"
            limpiarTablas(True)
            limpiarInfoExtra()
            txtIdRFIEquipment.Text = ""
            txtIdRFIEquipment.Enabled = False
            If idDrawingNum <> "" And idTagEq <> "" Then
                tblTagEq = mtdRFIEquipment.selectTagDrawing(idDrawingNum)
                Dim rowsList() As Data.DataRow = tblTagEq.Select(" idTag = '" + idTagEq + "' and idDrawingNum = '" + idDrawingNum + "'")
                If rowsList.Length > 0 Then
                    'idTag, description, elevation, wwPaint, system, option, sqrFtPnt, wwRemove, remove, sqrFtRmv, wwInstall, type, thick, jacket, sqrFtII, bevel, cutout, idDrawingNum
                    tblGeneralEquipment.Rows(0).Cells("HeigthEq").Value = rowsList(0).ItemArray(2)

                    tblPaintEq.Rows(0).Cells("idLaborRatePnt").Value = rowsList(0).ItemArray(3)
                    tblPaintEq.Rows(0).Cells("systemPnt").Value = rowsList(0).ItemArray(4)
                    tblPaintEq.Rows(0).Cells("optionPnt").Value = rowsList(0).ItemArray(5)
                    tblPaintEq.Rows(0).Cells("sqftPnt").Value = rowsList(0).ItemArray(6)

                    tblInsRemoval.Rows(0).Cells("idLaborRateRmv").Value = rowsList(0).ItemArray(7)
                    tblInsRemoval.Rows(0).Cells("RemoveEq").Value = If(rowsList(0).ItemArray(8) = "True", True, False)
                    tblInsRemoval.Rows(0).Cells("SqftEqRmv").Value = rowsList(0).ItemArray(9)

                    tblInsInsulation.Rows(0).Cells("idLaborRateII").Value = rowsList(0).ItemArray(10)
                    tblInsInsulation.Rows(0).Cells("typeII").Value = rowsList(0).ItemArray(11)
                    tblInsInsulation.Rows(0).Cells("thickII").Value = rowsList(0).ItemArray(12)
                    tblInsInsulation.Rows(0).Cells("jacketII").Value = rowsList(0).ItemArray(13)
                    tblInsInsulation.Rows(0).Cells("sqftII").Value = rowsList(0).ItemArray(14)
                    tblInsInsulation.Rows(0).Cells("bevelII").Value = rowsList(0).ItemArray(15)
                    tblInsInsulation.Rows(0).Cells("cutOutII").Value = rowsList(0).ItemArray(16)
                End If
            End If
        End If
    End Sub

    Public Function newRFI() As RFIEqClass
        Dim rfiEq As New RFIEqClass
        If txtIdRFIEquipment.Text <> "" Then
            rfiEq.IdTag = idTagEq
            rfiEq.IdDrawingNum = idDrawingNum
            rfiEq.IdRFIEq = txtIdRFIEquipment.Text

            rfiEq.OldElevation = If(tblGeneralEquipment.Rows(0).Cells("HeigthEq").Value IsNot Nothing, If(tblGeneralEquipment.Rows(0).Cells("HeigthEq").Value <> "", CDec(tblGeneralEquipment.Rows(0).Cells("HeigthEq").Value), 0), 0)
            rfiEq.NewElevation = If(tblGeneralEquipment.Rows(1).Cells("HeigthEq").Value IsNot Nothing, If(tblGeneralEquipment.Rows(1).Cells("HeigthEq").Value <> "", CDec(tblGeneralEquipment.Rows(1).Cells("HeigthEq").Value), 0), 0)

            rfiEq.OldWwPaint = If(tblPaintEq.Rows(0).Cells("idLaborRatePnt").Value IsNot Nothing, If(tblPaintEq.Rows(0).Cells("idLaborRatePnt").Value <> "", tblPaintEq.Rows(0).Cells("idLaborRatePnt").Value, "NULL"), "NULL")
            rfiEq.NewWwPaint = If(tblPaintEq.Rows(1).Cells("idLaborRatePnt").Value IsNot Nothing, If(tblPaintEq.Rows(1).Cells("idLaborRatePnt").Value <> "", tblPaintEq.Rows(1).Cells("idLaborRatePnt").Value, rfiEq.OldWwPaint), rfiEq.OldWwPaint)
            rfiEq.OldSystem = If(tblPaintEq.Rows(0).Cells("systemPnt").Value IsNot Nothing, If(tblPaintEq.Rows(0).Cells("systemPnt").Value <> "", tblPaintEq.Rows(0).Cells("systemPnt").Value, "NULL"), "NULL")
            rfiEq.NewSystem = If(tblPaintEq.Rows(1).Cells("systemPnt").Value IsNot Nothing, If(tblPaintEq.Rows(1).Cells("systemPnt").Value <> "", tblPaintEq.Rows(1).Cells("systemPnt").Value, rfiEq.OldSystem), rfiEq.OldSystem)
            rfiEq.OldOption = If(tblPaintEq.Rows(0).Cells("optionPnt").Value IsNot Nothing, If(tblPaintEq.Rows(0).Cells("optionPnt").Value <> "", tblPaintEq.Rows(0).Cells("optionPnt").Value, "NULL"), "NULL")
            rfiEq.NewOption = If(tblPaintEq.Rows(1).Cells("optionPnt").Value IsNot Nothing, If(tblPaintEq.Rows(1).Cells("optionPnt").Value <> "", tblPaintEq.Rows(1).Cells("optionPnt").Value, rfiEq.OldOption), rfiEq.OldOption)
            rfiEq.OldSqrFtPnt = If(tblPaintEq.Rows(0).Cells("sqftPnt").Value IsNot Nothing, If(tblPaintEq.Rows(0).Cells("sqftPnt").Value <> "", CDec(tblPaintEq.Rows(0).Cells("sqftPnt").Value), 0), 0)
            rfiEq.NewSqrFtPnt = If(tblPaintEq.Rows(1).Cells("sqftPnt").Value IsNot Nothing, If(tblPaintEq.Rows(1).Cells("sqftPnt").Value <> "", CDec(tblPaintEq.Rows(1).Cells("sqftPnt").Value), rfiEq.OldSqrFtPnt), rfiEq.OldSqrFtPnt)

            rfiEq.OldWwRemove = If(tblInsRemoval.Rows(0).Cells("idLaborRateRmv").Value IsNot Nothing, If(tblInsRemoval.Rows(0).Cells("idLaborRateRmv").Value <> "", tblInsRemoval.Rows(0).Cells("idLaborRateRmv").Value, "NULL"), "NULL")
            rfiEq.NewWwRemove = If(tblInsRemoval.Rows(1).Cells("idLaborRateRmv").Value IsNot Nothing, If(tblInsRemoval.Rows(1).Cells("idLaborRateRmv").Value <> "", tblInsRemoval.Rows(1).Cells("idLaborRateRmv").Value, rfiEq.OldWwRemove), rfiEq.OldWwRemove)
            rfiEq.OldRemove = If(tblInsRemoval.Rows(0).Cells("RemoveEq").Value IsNot Nothing, tblInsRemoval.Rows(0).Cells("RemoveEq").Value, False)
            rfiEq.NewRemove = If(tblInsRemoval.Rows(1).Cells("RemoveEq").Value IsNot Nothing, tblInsRemoval.Rows(1).Cells("RemoveEq").Value, False)
            rfiEq.OldSqrFtRmv = If(tblInsRemoval.Rows(0).Cells("SqftEqRmv").Value IsNot Nothing, If(tblInsRemoval.Rows(0).Cells("SqftEqRmv").Value <> "", CDec(tblInsRemoval.Rows(0).Cells("SqftEqRmv").Value), 0), 0)
            rfiEq.NewSqrFtRmv = If(tblInsRemoval.Rows(1).Cells("SqftEqRmv").Value IsNot Nothing, If(tblInsRemoval.Rows(1).Cells("SqftEqRmv").Value <> "", CDec(tblInsRemoval.Rows(1).Cells("SqftEqRmv").Value), rfiEq.OldSqrFtRmv), rfiEq.OldSqrFtRmv)

            rfiEq.OldWwInstall = If(tblInsInsulation.Rows(0).Cells("idLaborRateII").Value IsNot Nothing, If(tblInsInsulation.Rows(0).Cells("idLaborRateII").Value <> "", tblInsInsulation.Rows(0).Cells("idLaborRateII").Value, "NULL"), "NULL")
            rfiEq.NewWwInstall = If(tblInsInsulation.Rows(1).Cells("idLaborRateII").Value IsNot Nothing, If(tblInsInsulation.Rows(1).Cells("idLaborRateII").Value <> "", tblInsInsulation.Rows(1).Cells("idLaborRateII").Value, rfiEq.OldWwInstall), rfiEq.OldWwInstall)
            rfiEq.OldType = If(tblInsInsulation.Rows(0).Cells("typeII").Value IsNot Nothing, If(tblInsInsulation.Rows(0).Cells("typeII").Value <> "", tblInsInsulation.Rows(0).Cells("typeII").Value, "NULL"), "NULL")
            rfiEq.NewType = If(tblInsInsulation.Rows(1).Cells("typeII").Value IsNot Nothing, If(tblInsInsulation.Rows(1).Cells("typeII").Value <> "", tblInsInsulation.Rows(1).Cells("typeII").Value, rfiEq.OldType), rfiEq.OldType)
            rfiEq.OldThick = If(tblInsInsulation.Rows(0).Cells("thickII").Value IsNot Nothing, If(tblInsInsulation.Rows(0).Cells("thickII").Value <> "", CDec(tblInsInsulation.Rows(0).Cells("thickII").Value), 0), 0)
            rfiEq.NewThick = If(tblInsInsulation.Rows(1).Cells("thickII").Value IsNot Nothing, If(tblInsInsulation.Rows(1).Cells("thickII").Value <> "" And CDec(tblInsInsulation.Rows(1).Cells("thickII").Value) <> 0, tblInsInsulation.Rows(1).Cells("thickII").Value, rfiEq.OldThick), rfiEq.OldThick)
            rfiEq.OldJacket = If(tblInsInsulation.Rows(0).Cells("jacketII").Value IsNot Nothing, If(tblInsInsulation.Rows(0).Cells("jacketII").Value <> "", tblInsInsulation.Rows(0).Cells("jacketII").Value, "NULL"), "NULL")
            rfiEq.NewJacket = If(tblInsInsulation.Rows(1).Cells("jacketII").Value IsNot Nothing, If(tblInsInsulation.Rows(1).Cells("jacketII").Value <> "", tblInsInsulation.Rows(1).Cells("jacketII").Value, rfiEq.OldJacket), rfiEq.OldJacket)
            rfiEq.OldSqrFtII = If(tblInsInsulation.Rows(0).Cells("sqftII").Value IsNot Nothing, If(tblInsInsulation.Rows(0).Cells("sqftII").Value <> "", CDec(tblInsInsulation.Rows(0).Cells("sqftII").Value), 0), 0)
            rfiEq.NewSqrFtII = If(tblInsInsulation.Rows(1).Cells("sqftII").Value IsNot Nothing, If(tblInsInsulation.Rows(1).Cells("sqftII").Value <> "", CDec(tblInsInsulation.Rows(1).Cells("sqftII").Value), rfiEq.OldSqrFtII), rfiEq.OldSqrFtII)
            rfiEq.OldBevel = If(tblInsInsulation.Rows(0).Cells("bevelII").Value IsNot Nothing, If(tblInsInsulation.Rows(0).Cells("bevelII").Value <> "", CDec(tblInsInsulation.Rows(0).Cells("bevelII").Value), 0), 0)
            rfiEq.NewBevel = If(tblInsInsulation.Rows(1).Cells("bevelII").Value IsNot Nothing, If(tblInsInsulation.Rows(1).Cells("bevelII").Value <> "", CDec(tblInsInsulation.Rows(1).Cells("bevelII").Value), rfiEq.OldBevel), rfiEq.OldBevel)
            rfiEq.OldCutOut = If(tblInsInsulation.Rows(0).Cells("cutOutII").Value IsNot Nothing, If(tblInsInsulation.Rows(0).Cells("cutOutII").Value <> "", CDec(tblInsInsulation.Rows(0).Cells("cutOutII").Value), 0), 0)
            rfiEq.NewCutOut = If(tblInsInsulation.Rows(1).Cells("cutOutII").Value IsNot Nothing, If(tblInsInsulation.Rows(1).Cells("cutOutII").Value <> "", CDec(tblInsInsulation.Rows(1).Cells("cutOutII").Value), rfiEq.OldCutOut), rfiEq.OldCutOut)

            rfiEq.ReqEmployee = txtNameReq.Text
            rfiEq.ReqTitleEmployee = txtTitleReq.Text
            rfiEq.ReqCompany = txtCompanyReq.Text
            rfiEq.ReqDate = dtpDateReq.Value
            rfiEq.ChUpEmployee = txtNameUpdate.Text
            rfiEq.ChUpTitleEmployee = txtTitleUpdate.Text
            rfiEq.ChUpDate = dtpDateUpdate.Value
            rfiEq.WeDate = dtpDateWE.Value
            rfiEq.BasicFCR = txtBasicForNum.Text
            rfiEq.Note = txtNote.Text
        End If
        Return rfiEq
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If idDrawingNum <> "" And idTagEq <> "" Then
                Dim RFI = newRFI()
                If RFI IsNot Nothing Then
                    If mtdRFIEquipment.saveUpdateRFIEq(RFI) Then
                        tblRFIEquipmentHistory = mtdRFIEquipment.selectRFIEquipment(idTagEq, idDrawingNum)
                        llenarTablaHistory()
                        Dim rowList() As DataRow = tblRFIEquipmentHistory.Select("idRFIEq='" + RFI.IdRFIEq + "' and idTag = " + RFI.IdTag + "")
                        If rowList.Length > 0 Then
                            llenarDatosRFI(rowList(0))
                            txtIdRFIEquipment.Enabled = False
                        Else
                            limpiarTablas(False)
                            limpiarInfoExtra()
                            txtIdRFIEquipment.Enabled = False
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
            txtIdRFIEquipment.Text = row.ItemArray(0)

            'Select Case idRFIEq, tag As 'idTag',idDrawingNum , 0<->2
            'newElevation , newWwPaint, newSystem, newOption, newSqrFtPnt, 3<->7
            'newWwRemove, newRemove, newSqrFtRmv, 8<->10
            'newWwInstall, newType, newThick, newJacket, newSqrFtII, newBevel, newCutOut, 11<->17
            tblGeneralEquipment.Rows(1).Cells("HeigthEq").Value = row.ItemArray(3).ToString()
            tblPaintEq.Rows(1).Cells("idLaborRatePnt").Value = row.ItemArray(4)
            tblPaintEq.Rows(1).Cells("systemPnt").Value = row.ItemArray(5)
            tblPaintEq.Rows(1).Cells("optionPnt").Value = row.ItemArray(6)
            tblPaintEq.Rows(1).Cells("sqftPnt").Value = row.ItemArray(7).ToString()

            tblInsRemoval.Rows(1).Cells("idLaborRateRmv").Value = row.ItemArray(8)
            tblInsRemoval.Rows(1).Cells("RemoveEq").Value = row.ItemArray(9)
            tblInsRemoval.Rows(1).Cells("SqftEqRmv").Value = row.ItemArray(10).ToString()

            tblInsInsulation.Rows(1).Cells("idLaborRateII").Value = row.ItemArray(11)
            tblInsInsulation.Rows(1).Cells("typeII").Value = row.ItemArray(12)
            tblInsInsulation.Rows(1).Cells("thickII").Value = row.ItemArray(13).ToString()
            tblInsInsulation.Rows(1).Cells("jacketII").Value = row.ItemArray(14)
            tblInsInsulation.Rows(1).Cells("sqftII").Value = row.ItemArray(15).ToString()
            tblInsInsulation.Rows(1).Cells("bevelII").Value = row.ItemArray(16).ToString()
            tblInsInsulation.Rows(1).Cells("cutOutII").Value = row.ItemArray(17).ToString()


            'oldElevation, oldWwPaint, oldSystem, oldOption, oldSqrFtPnt, 18<->22 
            'oldWwRemove, oldRemove, oldSqrFtRmv,  23 <-> 25
            'oldWwInstall, oldType, oldThick, oldJacket, oldSqrFtII, oldBevel, oldCutOut, 26 <-> 32

            tblGeneralEquipment.Rows(0).Cells("HeigthEq").Value = row.ItemArray(18).ToString()
            tblPaintEq.Rows(0).Cells("idLaborRatePnt").Value = row.ItemArray(19)
            tblPaintEq.Rows(0).Cells("systemPnt").Value = row.ItemArray(20)
            tblPaintEq.Rows(0).Cells("optionPnt").Value = row.ItemArray(21)
            tblPaintEq.Rows(0).Cells("sqftPnt").Value = row.ItemArray(22).ToString()

            tblInsRemoval.Rows(0).Cells("idLaborRateRmv").Value = row.ItemArray(23)
            tblInsRemoval.Rows(0).Cells("RemoveEq").Value = row.ItemArray(24)
            tblInsRemoval.Rows(0).Cells("SqftEqRmv").Value = row.ItemArray(25).ToString()

            tblInsInsulation.Rows(0).Cells("idLaborRateII").Value = row.ItemArray(26)
            tblInsInsulation.Rows(0).Cells("typeII").Value = row.ItemArray(27)
            tblInsInsulation.Rows(0).Cells("thickII").Value = row.ItemArray(28).ToString()
            tblInsInsulation.Rows(0).Cells("jacketII").Value = row.ItemArray(29)
            tblInsInsulation.Rows(0).Cells("sqftII").Value = row.ItemArray(30).ToString()
            tblInsInsulation.Rows(0).Cells("bevelII").Value = row.ItemArray(31).ToString()
            tblInsInsulation.Rows(0).Cells("cutOutII").Value = row.ItemArray(32).ToString()
            'reqEmployee, reqTitleEmployee, Convert(nvarchar, reqDate, 101) as 'reqDate',reqCompany, 33 <-> 36
            'chUpEmployee, chUpTitleEmployee, Convert(nvarchar, chUpDate, 101) as 'chUpDate', 37 <-> 39
            'basicFCR, Convert(nvarchar, weDate, 101) as 'weDate',note 40 <-> 42
            'General Info and Paint
            txtNameReq.Text = row.ItemArray(33)
            txtTitleReq.Text = row.ItemArray(34)
            dtpDateReq.Value = validarFechaParaVB(row.ItemArray(35).ToString)
            txtCompanyReq.Text = row.ItemArray(36)
            txtNameUpdate.Text = row.ItemArray(37)
            txtTitleUpdate.Text = row.ItemArray(38)
            dtpDateUpdate.Value = validarFechaParaVB(row.ItemArray(39).ToString)
            txtBasicForNum.Text = row.ItemArray(40)
            dtpDateWE.Value = validarFechaParaVB(row.ItemArray(41).ToString())
            txtNote.Text = row.ItemArray(42)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
    Private Sub txtBasicForNum_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBasicForNum.KeyPress
        If Not (IsNumeric(e.KeyChar) Or e.KeyChar = vbBack Or e.KeyChar = vbLf) Then
            e.Handled = True
        End If
    End Sub

    Private Sub tblHistoryRFIEquipment_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles tblHistoryRFIEquipment.CellDoubleClick
        Dim selectRow As DataGridViewRow = tblHistoryRFIEquipment.Rows(e.RowIndex)
        Dim listRow() As DataRow = tblRFIEquipmentHistory.Select("idRFIEq='" + selectRow.Cells("idRFI").Value + "' and idTag = '" + idTagEq + "'")
        If listRow.Length > 0 Then
            btnDelete.Enabled = True
            llenarDatosRFI(listRow(0))
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If idDrawingNum <> "" And idTagEq <> "" Then
                If tblHistoryRFIEquipment.SelectedRows.Count = 1 Then
                    Dim idRFIDelete As String = tblHistoryRFIEquipment.SelectedRows(0).Cells(0).Value
                    MessageBox.Show("Are you sure to Delete the RFI: " + idRFIDelete + "?" + vbCrLf + "If the RFI is beetwen of others RFI, the next of this will take the lasted Equipment RFI information." + vbCrLf + "In the case that the selected RFI be the last one, the Equipment Estimation will take the lasted Equipment RFI Information.", "Importatn", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Dim idRFINext = ""
                    If (tblHistoryRFIEquipment.Rows.Count - 1) > tblHistoryRFIEquipment.SelectedRows(0).Index Then
                        idRFINext = tblHistoryRFIEquipment.Rows(tblHistoryRFIEquipment.SelectedRows(0).Index + 1).Cells(0).Value
                    End If
                    If mtdRFIEquipment.deleteRFIEquipment(idRFIDelete, idTagEq, idDrawingNum, idRFINext) Then
                        If txtIdRFIEquipment.Text = idRFIDelete Then
                            txtIdRFIEquipment.Text = ""
                            txtIdRFIEquipment.Enabled = False
                            limpiarTablas(True)
                            limpiarInfoExtra()
                            tblTagEq = mtdRFIEquipment.selectTagDrawing(idDrawingNum)
                            tblRFIEquipmentHistory = mtdRFIEquipment.selectRFIEquipment(idTagEq, idDrawingNum)
                            llenarTablaHistory()
                            Dim rowsList() As Data.DataRow = tblTagEq.Select(" idTag = '" + idTagEq + "' and idDrawingNum = '" + idDrawingNum + "'")
                            If rowsList.Length > 0 Then
                                tblGeneralEquipment.Rows(0).Cells("HeigthEq").Value = rowsList(0).ItemArray(2)

                                tblPaintEq.Rows(0).Cells("idLaborRatePnt").Value = rowsList(0).ItemArray(3)
                                tblPaintEq.Rows(0).Cells("systemPnt").Value = rowsList(0).ItemArray(4)
                                tblPaintEq.Rows(0).Cells("optionPnt").Value = rowsList(0).ItemArray(5)
                                tblPaintEq.Rows(0).Cells("sqftPnt").Value = rowsList(0).ItemArray(6)

                                tblInsRemoval.Rows(0).Cells("idLaborRateRmv").Value = rowsList(0).ItemArray(7)
                                tblInsRemoval.Rows(0).Cells("RemoveEq").Value = If(rowsList(0).ItemArray(8) = "True", True, False)
                                tblInsRemoval.Rows(0).Cells("SqftEqRmv").Value = rowsList(0).ItemArray(9)

                                tblInsInsulation.Rows(0).Cells("idLaborRateII").Value = rowsList(0).ItemArray(10)
                                tblInsInsulation.Rows(0).Cells("typeII").Value = rowsList(0).ItemArray(11)
                                tblInsInsulation.Rows(0).Cells("thickII").Value = rowsList(0).ItemArray(12)
                                tblInsInsulation.Rows(0).Cells("jacketII").Value = rowsList(0).ItemArray(13)
                                tblInsInsulation.Rows(0).Cells("sqftII").Value = rowsList(0).ItemArray(14)
                                tblInsInsulation.Rows(0).Cells("bevelII").Value = rowsList(0).ItemArray(15)
                                tblInsInsulation.Rows(0).Cells("cutOutII").Value = rowsList(0).ItemArray(16)
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
        rpt.TypeRFI = "Equipment"
        rpt.idDrawingNum = idDrawingNum
        rpt.idTag = idTagEq
        rpt.idRFI = txtIdRFIEquipment.Text
        rpt.Show()
    End Sub

    Private Sub btnNextDrawingN_Click(sender As Object, e As EventArgs) Handles btnNextDrawingN.Click
        Try
            Dim tblPos As Data.DataTable = mtdRFIEquipment.selectRFIPo()
            Dim nextIdDrawingNum As String = ""
            Dim nextTag As String = ""
            Dim nextRFI As String = ""
            Dim count As Integer = 0
            Dim flag As Boolean = False
            If tblPos.Rows IsNot Nothing Then
                For Each row As Data.DataRow In tblPos.Rows
                    If If(idDrawingNum <> "", If(idDrawingNum = row.ItemArray(2), True, False), True) And If(idTagEq <> "", If(idTagEq = row.ItemArray(3), True, False), True) And If(idRFIEq <> "", If(idRFIEq = row.ItemArray(4), True, False), True) Then
                        flag = True
                        Exit For
                    End If
                    count += 1
                Next
                If flag Then
                    If count = tblPos.Rows.Count - 1 Then 'es el ultimo (ir al primero)
                        count = 0
                    Else
                        count = count + 1
                    End If
                    nextIdDrawingNum = tblPos.Rows(count).ItemArray(2)
                    nextTag = tblPos.Rows(count).ItemArray(3)
                    nextRFI = tblPos.Rows(count).ItemArray(4)
                    llenarDatos(nextRFI, nextTag, nextIdDrawingNum)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Private Sub btnAfterDrawing_Click(sender As Object, e As EventArgs) Handles btnAfterDrawing.Click
        Try
            Dim tblPos As Data.DataTable = mtdRFIEquipment.selectRFIPo()
            Dim nextIdDrawingNum As String = ""
            Dim nextTag As String = ""
            Dim nextRFI As String = ""
            Dim count As Integer = 0
            Dim flag As Boolean = False
            If tblPos.Rows IsNot Nothing Then
                For Each row As Data.DataRow In tblPos.Rows
                    If If(idDrawingNum <> "", If(idDrawingNum = row.ItemArray(2), True, False), True) And If(idTagEq <> "", If(idTagEq = row.ItemArray(3), True, False), True) And If(idRFIEq <> "", If(idRFIEq = row.ItemArray(4), True, False), True) Then
                        flag = True
                        Exit For
                    End If
                    count += 1
                Next
                If flag Then
                    If count = 0 Then 'es el primero (ir al ultimo)
                        count = tblPos.Rows.Count - 1
                    Else
                        count = count - 1
                    End If
                    nextIdDrawingNum = tblPos.Rows(count).ItemArray(2)
                    nextTag = tblPos.Rows(count).ItemArray(3)
                    nextRFI = tblPos.Rows(count).ItemArray(4)
                    llenarDatos(nextRFI, nextTag, nextIdDrawingNum)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub
    Private Sub llenarDatos(ByVal idRFI As String, ByVal idTag As String, ByVal idDrawing As String)
        Try
            Dim countIndex As Integer = -1
            Dim flag As Boolean = False
            For Each item As String In cmbDrawing.Items
                countIndex += 1
                Dim array() As String = item.ToString.Split("|")
                If idDrawing = array(0) Then
                    flag = True
                    Exit For
                End If
            Next
            If countIndex >= 0 And flag Then
                cmbDrawing.SelectedIndex = countIndex
                countIndex = -1
                flag = False
                For Each item As String In cmbTag.Items
                    countIndex += 1
                    Dim array() As String = item.ToString.Split("|")
                    If idTag = array(0) Then
                        flag = True
                        Exit For
                    End If
                Next
                If countIndex >= 0 And flag Then
                    cmbTag.SelectedIndex = countIndex
                    countIndex = -1
                    flag = False
                    For Each row As DataGridViewRow In tblHistoryRFIEquipment.Rows
                        countIndex += 1
                        If idRFI = row.Cells("idRFI").Value Then
                            flag = True
                            Exit For
                        End If
                    Next
                    If countIndex >= 0 And flag Then
                        Dim listRow() As DataRow = tblRFIEquipmentHistory.Select("idRFIEq='" + tblHistoryRFIEquipment.Rows(countIndex).Cells("idRFI").Value + "' and idTag = '" + idTag + "'")
                        If listRow.Length > 0 Then
                            btnDelete.Enabled = True
                            llenarDatosRFI(listRow(0))
                        End If
                    End If
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub
End Class

Public Class RFIEqClass
    Private _idRFIEq As String
    Private _idTag As String
    Private _idDrawingNum As String
    Private _newElevation As Decimal
    Private _newWwPaint As String
    Private _newSystem As String
    Private _newOption As String
    Private _newSqrFtPnt As Decimal
    Private _newWwRemove As String
    Private _newRemove As Boolean
    Private _newSqrFtRmv As Decimal
    Private _newWwInstall As String
    Private _newType As String
    Private _newThick As Decimal
    Private _newJacket As String
    Private _newSqrFtII As Decimal
    Private _newBevel As Integer
    Private _newCutOut As Integer
    Private _oldElevation As Decimal
    Private _oldWwPaint As String
    Private _oldSystem As String
    Private _oldOption As String
    Private _oldSqrFtPnt As Decimal
    Private _oldWwRemove As String
    Private _oldRemove As Boolean
    Private _oldSqrFtRmv As Decimal
    Private _oldWwInstall As String
    Private _oldType As String
    Private _oldThick As Decimal
    Private _oldJacket As String
    Private _oldSqrFtII As Decimal
    Private _oldBevel As Integer
    Private _oldCutOut As Integer

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
    Public Property BasicFCR As String
        Get
            If _basicFCR = Nothing Then
                _basicFCR = ""
            End If
            Return _basicFCR
        End Get
        Set(value As String)
            _basicFCR = value
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
    Public Property OldCutOut As Integer
        Get
            If OldCutOut = Nothing Then
                OldCutOut = 0
            End If
            Return _oldCutOut
        End Get
        Set(value As Integer)
            _oldCutOut = value
        End Set
    End Property
    Public Property OldBevel As Integer
        Get
            If _oldBevel = Nothing Then
                _oldBevel = 0
            End If
            Return _oldBevel
        End Get
        Set(value As Integer)
            _oldBevel = value
        End Set
    End Property
    Public Property OldSqrFtII As Decimal
        Get
            If _oldSqrFtII = Nothing Then
                _oldSqrFtII = 0
            End If
            Return _oldSqrFtII
        End Get
        Set(value As Decimal)
            _oldSqrFtII = value
        End Set
    End Property
    Public Property OldJacket As String
        Get
            If _oldJacket = Nothing Then
                _oldJacket = ""
            End If
            Return _oldJacket
        End Get
        Set(value As String)
            _oldJacket = value
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
    Public Property OldWwInstall As String
        Get
            If _oldWwInstall = Nothing Then
                _oldWwInstall = ""
            End If
            Return _oldWwInstall
        End Get
        Set(value As String)
            _oldWwInstall = value
        End Set
    End Property
    Public Property OldSqrFtRmv As Decimal
        Get
            If _oldSqrFtRmv = Nothing Then
                _oldSqrFtRmv = 0
            End If
            Return _oldSqrFtRmv
        End Get
        Set(value As Decimal)
            _oldSqrFtRmv = value
        End Set
    End Property
    Public Property OldRemove As Boolean
        Get
            If _oldRemove = Nothing Then
                _oldRemove = False
            End If
            Return _oldRemove
        End Get
        Set(value As Boolean)
            _oldRemove = value
        End Set
    End Property
    Public Property OldWwRemove As String
        Get
            If _oldWwRemove = Nothing Then
                _oldWwRemove = ""
            End If
            Return _oldWwRemove
        End Get
        Set(value As String)
            _oldWwRemove = value
        End Set
    End Property
    Public Property OldSqrFtPnt As Decimal
        Get
            If _oldSqrFtPnt = Nothing Then
                _oldSqrFtPnt = 0
            End If
            Return _oldSqrFtPnt
        End Get
        Set(value As Decimal)
            _oldSqrFtPnt = value
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
    Public Property OldWwPaint As String
        Get
            If _oldWwPaint = Nothing Then
                _oldWwPaint = ""
            End If
            Return _oldWwPaint
        End Get
        Set(value As String)
            _oldWwPaint = value
        End Set
    End Property
    Public Property OldElevation As Decimal
        Get
            If _oldElevation = Nothing Then
                _oldElevation = 1
            End If
            Return _oldElevation
        End Get
        Set(value As Decimal)
            _oldElevation = value
        End Set
    End Property
    Public Property NewCutOut As Integer
        Get
            If _newCutOut = Nothing Then
                _newCutOut = 0
            End If
            Return _newCutOut
        End Get
        Set(value As Integer)
            _newCutOut = value
        End Set
    End Property
    Public Property NewBevel As Integer
        Get
            If _newBevel = Nothing Then
                _newBevel = 0
            End If
            Return _newBevel
        End Get
        Set(value As Integer)
            _newBevel = value
        End Set
    End Property
    Public Property NewSqrFtII As Decimal
        Get
            If _newSqrFtII = Nothing Then
                _newSqrFtII = 0
            End If
            Return _newSqrFtII
        End Get
        Set(value As Decimal)
            _newSqrFtII = value
        End Set
    End Property
    Public Property NewJacket As String
        Get
            If _newJacket = Nothing Then
                _newJacket = ""
            End If
            Return _newJacket
        End Get
        Set(value As String)
            _newJacket = value
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
    Public Property NewSqrFtRmv As Decimal
        Get
            If _newSqrFtRmv = Nothing Then
                _newSqrFtRmv = 0
            End If
            Return _newSqrFtRmv
        End Get
        Set(value As Decimal)
            _newSqrFtRmv = value
        End Set
    End Property
    Public Property NewWwInstall As String
        Get
            If _newWwInstall = Nothing Then
                _newWwInstall = ""
            End If
            Return _newWwInstall
        End Get
        Set(value As String)
            _newWwInstall = value
        End Set
    End Property
    Public Property NewRemove As Boolean
        Get
            If _newRemove = Nothing Then
                _newRemove = False
            End If
            Return _newRemove
        End Get
        Set(value As Boolean)
            _newRemove = value
        End Set
    End Property
    Public Property NewWwRemove As String
        Get
            If _newWwRemove = Nothing Then
                _newWwRemove = ""
            End If
            Return _newWwRemove
        End Get
        Set(value As String)
            _newWwRemove = value
        End Set
    End Property
    Public Property NewSqrFtPnt As Decimal
        Get
            If _newSqrFtPnt = Nothing Then
                _newSqrFtPnt = 0
            End If
            Return _newSqrFtPnt
        End Get
        Set(value As Decimal)
            _newSqrFtPnt = value
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
    Public Property NewWwPaint As String
        Get
            If _newWwPaint = Nothing Then
                _newWwPaint = ""
            End If
            Return _newWwPaint
        End Get
        Set(value As String)
            _newWwPaint = value
        End Set
    End Property
    Public Property NewElevation As Decimal
        Get
            If _newElevation = Nothing Then
                _newElevation = 0
            End If
            Return _newElevation
        End Get
        Set(value As Decimal)
            _newElevation = value
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
    Public Property IdTag As String
        Get
            If _idTag = Nothing Then
                _idTag = ""
            End If
            Return _idTag
        End Get
        Set(value As String)
            _idTag = value
        End Set
    End Property
    Public Property IdRFIEq As String
        Get
            If _idRFIEq = Nothing Then
                _idRFIEq = ""
            End If
            Return _idRFIEq
        End Get
        Set(value As String)
            _idRFIEq = value
        End Set
    End Property
End Class
