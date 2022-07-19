Public Class RFISacffold
    Dim mtdRFI As New MetodosRFIScaffold
    Dim tblDr As New Data.DataTable
    Dim tblTag As New Data.DataTable
    Dim tblRFIHistory As New Data.DataTable
    Dim idDrawing As String = ""
    Dim idTag As String = ""
    'Dim RFI As New RFIScaffoldClass

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub RFISacffold_Load(sender As Object, e As EventArgs) Handles Me.Load
        tblGeneralScaffold.Rows.Add("", "Old", "")
        tblGeneralScaffold.Rows.Add("", "New", "")
        tblScaffoldInfo.Rows.Add()
        tblScaffoldInfo.Rows.Add()
        tblDr = mtdRFI.selectDrawing(cmbDrawing)
        tblTag = mtdRFI.selectTagDrawing("", cmbTag)
        tblScaffoldInfo.Rows(0).ReadOnly = True
        tblScaffoldInfo.Rows(0).DefaultCellStyle.BackColor = Color.LightGray
        tblGeneralScaffold.Rows(0).ReadOnly = True
        tblGeneralScaffold.Rows(0).DefaultCellStyle.BackColor = Color.LightGray
        tblGeneralScaffold.Rows(1).Cells(1).Style.BackColor = Color.LightGray
        tblGeneralScaffold.DefaultCellStyle.ForeColor = Color.Black
        tblScaffoldInfo.DefaultCellStyle.ForeColor = Color.Black
        btnDelete.Enabled = False
    End Sub

    Private Sub cmbDrawing_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDrawing.SelectedIndexChanged
        Try
            Dim array() As String = cmbDrawing.SelectedItem.ToString.Split("|")
            If array.Length > 0 Then
                If idDrawing <> array(0) Then
                    idDrawing = array(0)
                    idTag = ""
                    tblTag = mtdRFI.selectTagDrawing(idDrawing, cmbTag)
                    tblDr = mtdRFI.selectDrawing() 'solo consultamos la tabla por si cambio el valor 
                    limpiar()
                    'llenamos los campo de job y drawing 
                    Dim rowsList() As Data.DataRow = tblDr.Select("idDrawingNum = '" + idDrawing + "'")
                    If rowsList.Length > 0 Then
                        txtJobNum.Text = rowsList(0).ItemArray(0)
                        txtDescriptionPO.Text = rowsList(0).ItemArray(1)
                        'idDrawing = rowList(0).ItemArray(2)
                        'RFI.idDrawingNum = rowsList(0).ItemArray(2)
                        txtDescriptionDR.Text = rowsList(0).ItemArray(3)
                        txtUnitPO.Text = rowsList(0).ItemArray(4)
                        txtClientNumber.Text = rowsList(0).ItemArray(5)
                    Else
                        MessageBox.Show("Is probably that the drawing was deleted or updated please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub cmbTag_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTag.SelectedIndexChanged
        Try
            If cmbTag.SelectedItem <> "" And idDrawing <> "" Then
                idTag = cmbTag.SelectedItem
                tblTag = mtdRFI.selectTagDrawing(idDrawing)
                tblRFIHistory = mtdRFI.selectRFIScaffold(idTag, idDrawing)
                Dim rowsList() As Data.DataRow = tblTag.Select("tag = '" + idTag + "' and idDrawingNum = '" + idDrawing + "'")
                limpiarTablas()
                limpiarInfExtra()
                llenarTablaHistory()
                If rowsList.Length > 0 Then
                    'dr("tag"), dr("days"), dr("width"), dr("length"), dr("heigth"), dr("build"), dr("idLaborRate"), dr("idSCFUR"), dr("idDrawingNum")
                    'type , daysAct , with , length ,heigth , build

                    tblScaffoldInfo.Rows(0).Cells("Type").Value = rowsList(0).ItemArray(8)
                    tblScaffoldInfo.Rows(0).Cells("DaysActive").Value = rowsList(0).ItemArray(1)
                    tblScaffoldInfo.Rows(0).Cells("width").Value = rowsList(0).ItemArray(2)
                    tblScaffoldInfo.Rows(0).Cells("length").Value = rowsList(0).ItemArray(3)
                    tblScaffoldInfo.Rows(0).Cells("heigth").Value = rowsList(0).ItemArray(4)
                    tblScaffoldInfo.Rows(0).Cells("Build").Value = rowsList(0).ItemArray(5)
                    tblScaffoldInfo.Rows(0).Cells("Decks").Value = rowsList(0).ItemArray(6)

                    tblGeneralScaffold.Rows(0).Cells(0).Value = rowsList(0).ItemArray(7)
                    tblGeneralScaffold.Rows(0).Cells(2).Value = rowsList(0).ItemArray(7)


                Else
                    MessageBox.Show("Is probably that the drawing was deleted or updated please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub llenarTablaHistory()
        If tblRFIHistory IsNot Nothing Then
            If tblRFIHistory.Rows IsNot Nothing Then
                tblHistoryRFIScaffold.Rows.Clear()
                For Each row As Data.DataRow In tblRFIHistory.Rows
                    tblHistoryRFIScaffold.Rows.Add(row.ItemArray(0), row.ItemArray(21), row.ItemArray(23))
                Next
            End If
        End If
    End Sub
    Private Sub limpiar()
        txtJobNum.Text = ""
        txtDescriptionPO.Text = ""
        txtUnitPO.Text = ""
        txtDescriptionDR.Text = ""
        txtClientNumber.Text = ""
        txtNameReq.Text = ""
        txtNameUpdate.Text = ""
        txtTitleReq.Text = ""
        txtTitleUpdate.Text = ""
        txtNote.Text = ""
        txtBasicForNum.Text = ""
        txtCompanyReq.Text = ""
        txtIdRFIScaffold.Text = ""

        tblGeneralScaffold.Rows(0).Cells(2).Value = ""
        tblGeneralScaffold.Rows.Remove(tblGeneralScaffold.Rows(1))
        tblGeneralScaffold.Rows.Add("", "New", "")
        tblGeneralScaffold.Rows(1).Cells(1).Style.BackColor = Color.LightGray

        tblScaffoldInfo.Rows(0).Cells(0).Value = ""
        tblScaffoldInfo.Rows(0).Cells(1).Value = ""
        tblScaffoldInfo.Rows(0).Cells(2).Value = ""
        tblScaffoldInfo.Rows(0).Cells(3).Value = ""
        tblScaffoldInfo.Rows(0).Cells(4).Value = ""
        tblScaffoldInfo.Rows(0).Cells(5).Value = ""
        tblScaffoldInfo.Rows(0).Cells(6).Value = ""

        tblScaffoldInfo.Rows.Remove(tblScaffoldInfo.Rows(1))
        tblScaffoldInfo.Rows.Add()

    End Sub
    Sub limpiarTablas(Optional isNew As Boolean = False)
        If Not isNew Then
            tblGeneralScaffold.Rows(0).Cells(2).Value = ""
        End If
        tblGeneralScaffold.Rows.Remove(tblGeneralScaffold.Rows(1))
        tblGeneralScaffold.Rows.Add("", "New", "")
        tblGeneralScaffold.Rows(1).Cells(1).Style.BackColor = Color.LightGray

        If Not isNew Then
            tblScaffoldInfo.Rows(0).Cells(0).Value = ""
            tblScaffoldInfo.Rows(0).Cells(1).Value = ""
            tblScaffoldInfo.Rows(0).Cells(2).Value = ""
            tblScaffoldInfo.Rows(0).Cells(3).Value = ""
            tblScaffoldInfo.Rows(0).Cells(4).Value = ""
            tblScaffoldInfo.Rows(0).Cells(5).Value = ""
            tblScaffoldInfo.Rows(0).Cells(6).Value = ""
        End If
        tblScaffoldInfo.Rows.Remove(tblScaffoldInfo.Rows(1))
        tblScaffoldInfo.Rows.Add()
    End Sub

    Sub limpiarInfExtra()
        txtNameReq.Text = ""
        txtNameUpdate.Text = ""
        txtTitleReq.Text = ""
        txtTitleUpdate.Text = ""
        txtNote.Text = ""
        txtBasicForNum.Text = ""
        txtCompanyReq.Text = ""
        txtIdRFIScaffold.Text = ""
        dtpDateReq.Value = Today.Date
        dtpDateUpdate.Value = Today.Date
        dtpDateWE.Value = Today.Date
    End Sub
    Private Sub btnAddRFIScaffold_Click(sender As Object, e As EventArgs) Handles btnAddRFIScaffold.Click
        If btnAddRFIScaffold.Text = "New" Then
            If idDrawing <> "" And idTag <> "" Then
                txtIdRFIScaffold.Enabled = True
                btnAddRFIScaffold.Text = "Cancel"
                limpiarTablas(True)
                limpiarInfExtra()
                txtIdRFIScaffold.Text = mtdRFI.selectMaxRFI(idTag, idDrawing).ToString()

                tblTag = mtdRFI.selectTagDrawing(idDrawing)
                Dim rowsList() As Data.DataRow = tblTag.Select(" tag = '" + idTag + "' and idDrawingNum = '" + idDrawing + "'")
                If rowsList.Length > 0 Then
                    tblScaffoldInfo.Rows(0).Cells("Type").Value = rowsList(0).ItemArray(8)
                    tblScaffoldInfo.Rows(0).Cells("DaysActive").Value = rowsList(0).ItemArray(1)
                    tblScaffoldInfo.Rows(0).Cells("width").Value = rowsList(0).ItemArray(2)
                    tblScaffoldInfo.Rows(0).Cells("length").Value = rowsList(0).ItemArray(4)
                    tblScaffoldInfo.Rows(0).Cells("heigth").Value = rowsList(0).ItemArray(3)
                    tblScaffoldInfo.Rows(0).Cells("Build").Value = rowsList(0).ItemArray(5)
                    tblScaffoldInfo.Rows(0).Cells("Decks").Value = rowsList(0).ItemArray(6)

                    tblGeneralScaffold.Rows(0).Cells(0).Value = rowsList(0).ItemArray(7)
                    tblGeneralScaffold.Rows(0).Cells(2).Value = rowsList(0).ItemArray(7)
                End If
            Else
                MessageBox.Show("Please select a Drawing No. or Scaffold Tag project to continue.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            btnAddRFIScaffold.Text = "New"
            txtIdRFIScaffold.Enabled = False
            limpiarTablas(True)
            limpiarInfExtra()
            txtIdRFIScaffold.Text = ""
            If idDrawing <> "" And idTag <> "" Then
                tblTag = mtdRFI.selectTagDrawing(idDrawing)
                Dim rowsList() As Data.DataRow = tblTag.Select(" tag = '" + idTag + "' and idDrawingNum = '" + idDrawing + "'")
                If rowsList.Length > 0 Then
                    tblScaffoldInfo.Rows(0).Cells("Type").Value = rowsList(0).ItemArray(8)
                    tblScaffoldInfo.Rows(0).Cells("DaysActive").Value = rowsList(0).ItemArray(1)
                    tblScaffoldInfo.Rows(0).Cells("width").Value = rowsList(0).ItemArray(2)
                    tblScaffoldInfo.Rows(0).Cells("length").Value = rowsList(0).ItemArray(4)
                    tblScaffoldInfo.Rows(0).Cells("heigth").Value = rowsList(0).ItemArray(3)
                    tblScaffoldInfo.Rows(0).Cells("Build").Value = rowsList(0).ItemArray(5)
                    tblScaffoldInfo.Rows(0).Cells("Decks").Value = rowsList(0).ItemArray(6)

                    tblGeneralScaffold.Rows(0).Cells(0).Value = rowsList(0).ItemArray(7)
                    tblGeneralScaffold.Rows(0).Cells(2).Value = rowsList(0).ItemArray(7)
                End If
            End If

        End If
    End Sub

    Private Sub tblScaffoldInfo_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles tblScaffoldInfo.CellMouseClick
        Try
            If tblScaffoldInfo.CurrentCell.ColumnIndex = 0 And tblScaffoldInfo.CurrentCell.RowIndex = 1 Then
                If tblScaffoldInfo.CurrentCell.GetType.Name = "DataGridViewTextBoxCell" Then
                    Dim cmbLabor As New DataGridViewComboBoxCell
                    With cmbLabor
                        mtdRFI.llenarCellComboBoxSCFUR(cmbLabor, tblScaffoldInfo.CurrentCell.Value)
                    End With
                    tblScaffoldInfo.CurrentRow.Cells("Type") = cmbLabor
                    cmbLabor.DropDownWidth = 200
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub
    Private Sub tblScaffoldInfo_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles tblScaffoldInfo.EditingControlShowing
        Dim Index = tblScaffoldInfo.CurrentCell.ColumnIndex
        If Index = 0 Then
            Dim typecell = tblScaffoldInfo.CurrentCell.GetType.ToString
            If Not typecell = "System.Windows.Forms.DataGridViewTextBoxCell" Then
                Dim cb As ComboBox = CType(e.Control, ComboBox)
                If e.Control IsNot Nothing Then
                    RemoveHandler cb.SelectedIndexChanged, AddressOf cmb_SelectedIndexChanguedInfo
                    AddHandler cb.SelectedIndexChanged, AddressOf cmb_SelectedIndexChanguedInfo
                End If
            End If
        End If
    End Sub
    Public Sub cmb_SelectedIndexChanguedInfo(sender As Object, e As EventArgs)
        Dim cmb As ComboBox = CType(sender, ComboBox)
        Select Case tblScaffoldInfo.CurrentCell.ColumnIndex
            Case 0
                tblScaffoldInfo.CurrentCell.Value = cmb.Text
        End Select
    End Sub
    Public Sub cmb_SelectedIndexChanguedGen(sender As Object, e As EventArgs)
        Dim cmb As ComboBox = CType(sender, ComboBox)
        Select Case tblGeneralScaffold.CurrentCell.ColumnIndex
            Case 1
                tblGeneralScaffold.CurrentCell.Value = cmb.Text
        End Select
    End Sub
    Private Sub tblGeneralScaffold_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles tblGeneralScaffold.CellMouseClick
        Try
            If tblGeneralScaffold.CurrentCell.ColumnIndex = 2 And tblGeneralScaffold.CurrentCell.RowIndex = 1 Then
                If tblGeneralScaffold.CurrentCell.GetType.Name = "DataGridViewTextBoxCell" Then
                    Dim cmbLabor As New DataGridViewComboBoxCell
                    With cmbLabor
                        mtdRFI.llenarCellComboBoxIdLabor(cmbLabor, tblGeneralScaffold.CurrentCell.Value)
                    End With
                    tblGeneralScaffold.CurrentRow.Cells("laborRateNew") = cmbLabor
                    cmbLabor.DropDownWidth = 200
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Private Sub tblGeneralScaffold_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles tblGeneralScaffold.EditingControlShowing
        Dim Index = tblGeneralScaffold.CurrentCell.ColumnIndex
        If Index = 2 Then
            Dim typecell = tblGeneralScaffold.CurrentCell.GetType.ToString
            If Not typecell = "System.Windows.Forms.DataGridViewTextBoxCell" Then
                Dim cb As ComboBox = CType(e.Control, ComboBox)
                If e.Control IsNot Nothing Then
                    RemoveHandler cb.SelectedIndexChanged, AddressOf cmb_SelectedIndexChanguedGen
                    AddHandler cb.SelectedIndexChanged, AddressOf cmb_SelectedIndexChanguedGen
                End If
            End If
        End If
    End Sub
    Private Sub tblScaffoldInfo_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles tblScaffoldInfo.CellEndEdit
        Try
            If (e.ColumnIndex > 0 And e.ColumnIndex <= 6) And e.RowIndex = 1 Then
                If tblScaffoldInfo.Rows(1).Cells(e.ColumnIndex).Value IsNot DBNull.Value And tblScaffoldInfo.Rows(1).Cells(e.ColumnIndex).Value <> "" Then
                    If soloNumero(tblScaffoldInfo.Rows(1).Cells(e.ColumnIndex).Value) Then
                        If Not CDec(tblScaffoldInfo.Rows(1).Cells(e.ColumnIndex).Value) >= 0 Then
                            MessageBox.Show("Please enter a valid number.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            tblScaffoldInfo.Rows(1).Cells(e.ColumnIndex).Value = "0"
                        End If
                    Else
                        MessageBox.Show("Please enter a valid number.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        tblScaffoldInfo.Rows(1).Cells(e.ColumnIndex).Value = "0"
                    End If
                Else
                    tblScaffoldInfo.Rows(1).Cells(e.ColumnIndex).Value = "0"
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Please enter a valid number.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub txtIdRFIScaffold_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIdRFIScaffold.KeyPress
        If Not soloNumero(CStr(e.KeyChar)) Then
            If Not e.KeyChar = vbBack Then
                e.Handled = True
            End If
        ElseIf e.KeyChar.ToString.Contains(".") Or e.KeyChar.ToString.Contains(",") Or e.KeyChar.ToString.Contains("-") Then
            e.Handled = True
        End If
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If idDrawing <> "" And idTag <> "" Then
                If tblHistoryRFIScaffold.SelectedRows.Count = 1 Then
                    Dim idRFIDelete As String = tblHistoryRFIScaffold.SelectedRows(0).Cells(0).Value
                    MessageBox.Show("Are you sure to Delete the RFI: " + idRFIDelete + "?" + vbCrLf + "If the RFI is beetwen of others RFI, the next of this will take the lasted Scaffold RFI information." + vbCrLf + "In the case that the selected RFI be the last one, the Scaffold Estimation will take the lasted Scaffold RFI Information.", "Importatn", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Dim idRFINext = ""
                    If (tblHistoryRFIScaffold.Rows.Count - 1) > tblHistoryRFIScaffold.SelectedRows(0).Index Then
                        idRFINext = tblHistoryRFIScaffold.Rows(tblHistoryRFIScaffold.SelectedRows(0).Index + 1).Cells(0).Value
                    End If
                    If mtdRFI.deleteRFIScaffold(idRFIDelete, idTag, idDrawing, idRFINext) Then
                        If txtIdRFIScaffold.Text = idRFIDelete Then
                            txtIdRFIScaffold.Text = ""
                            txtIdRFIScaffold.Enabled = False
                            limpiarTablas(True)
                            limpiarInfExtra()
                            tblTag = mtdRFI.selectTagDrawing(idDrawing)
                            tblRFIHistory = mtdRFI.selectRFIScaffold(idTag, idDrawing)
                            llenarTablaHistory()
                            Dim rowsList() As Data.DataRow = tblTag.Select(" tag = '" + idTag + "' and idDrawingNum = '" + idDrawing + "'")
                            If rowsList.Length > 0 Then
                                tblScaffoldInfo.Rows(0).Cells("Type").Value = rowsList(0).ItemArray(8)
                                tblScaffoldInfo.Rows(0).Cells("DaysActive").Value = rowsList(0).ItemArray(1)
                                tblScaffoldInfo.Rows(0).Cells("width").Value = rowsList(0).ItemArray(2)
                                tblScaffoldInfo.Rows(0).Cells("length").Value = rowsList(0).ItemArray(4)
                                tblScaffoldInfo.Rows(0).Cells("heigth").Value = rowsList(0).ItemArray(3)
                                tblScaffoldInfo.Rows(0).Cells("Build").Value = rowsList(0).ItemArray(5)
                                tblScaffoldInfo.Rows(0).Cells("Decks").Value = rowsList(0).ItemArray(6)

                                tblGeneralScaffold.Rows(0).Cells(0).Value = rowsList(0).ItemArray(7)
                                tblGeneralScaffold.Rows(0).Cells(2).Value = rowsList(0).ItemArray(7)
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
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If idDrawing <> "" And idTag <> "" Then
                Dim RFI = newRFI()
                If RFI IsNot Nothing Then
                    If mtdRFI.SaveUpdateRFIScaffold(RFI) Then
                        tblRFIHistory = mtdRFI.selectRFIScaffold(idTag, idDrawing)
                        llenarTablaHistory()
                        Dim rowList() As DataRow = tblRFIHistory.Select("idRFI='" + RFI.idRFI + "' and tag = '" + RFI.idTag + "'")
                        If rowList.Length > 0 Then
                            llenarDatosRFI(rowList(0))
                            txtIdRFIScaffold.Enabled = False
                        Else
                            limpiarTablas()
                            limpiarInfExtra()
                            txtIdRFIScaffold.Enabled = False
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
    Private Function newRFI() As RFIScaffoldClass
        Try
            Dim RFI As New RFIScaffoldClass
            If txtIdRFIScaffold.Text <> "" Then
                RFI.idRFI = txtIdRFIScaffold.Text
                RFI.idTag = idTag
                RFI.idDrawingNum = idDrawing
                RFI.lastIdLaborRate = If(tblGeneralScaffold.Rows(0).Cells(2).Value <> "" Or tblGeneralScaffold.Rows(0).Cells(2).Value IsNot Nothing, tblGeneralScaffold.Rows(0).Cells(2).Value, "NULL")
                RFI.lastIdSCFUR = If(tblScaffoldInfo.Rows(0).Cells(0).Value IsNot Nothing Or tblScaffoldInfo.Rows(0).Cells(0).Value <> "", tblScaffoldInfo.Rows(0).Cells(0).Value, "NULL")
                RFI.lastDays = If(tblScaffoldInfo.Rows(0).Cells(1).Value IsNot Nothing Or tblScaffoldInfo.Rows(0).Cells(1).Value.ToString() <> "", tblScaffoldInfo.Rows(0).Cells(1).Value, "0")
                RFI.lastWith = If(tblScaffoldInfo.Rows(0).Cells(2).Value IsNot Nothing Or tblScaffoldInfo.Rows(0).Cells(2).Value.ToString() <> "", tblScaffoldInfo.Rows(0).Cells(2).Value, "0")
                RFI.lastLength = If(tblScaffoldInfo.Rows(0).Cells(3).Value IsNot Nothing Or tblScaffoldInfo.Rows(0).Cells(3).Value.ToString() <> "", tblScaffoldInfo.Rows(0).Cells(3).Value, "0")
                RFI.lastHeigth = If(tblScaffoldInfo.Rows(0).Cells(4).Value IsNot Nothing Or tblScaffoldInfo.Rows(0).Cells(4).Value.ToString() <> "", tblScaffoldInfo.Rows(0).Cells(4).Value, "0")
                RFI.lastBuild = If(tblScaffoldInfo.Rows(0).Cells(5).Value IsNot Nothing Or tblScaffoldInfo.Rows(0).Cells(5).Value.ToString() <> "", tblScaffoldInfo.Rows(0).Cells(5).Value, "0")
                RFI.lastDecks = If(tblScaffoldInfo.Rows(0).Cells(6).Value IsNot Nothing Or tblScaffoldInfo.Rows(0).Cells(6).Value.ToString() <> "", tblScaffoldInfo.Rows(0).Cells(6).Value, "0")

                RFI.newIdLaborRate = If(tblGeneralScaffold.Rows(0).Cells(2).Value <> "" Or tblGeneralScaffold.Rows(0).Cells(2).Value IsNot Nothing, tblGeneralScaffold.Rows(0).Cells(2).Value, RFI.lastIdLaborRate)
                RFI.newIdSCFUR = If(tblScaffoldInfo.Rows(1).Cells(0).Value IsNot Nothing Or tblScaffoldInfo.Rows(1).Cells(0).Value <> "", tblScaffoldInfo.Rows(1).Cells(0).Value, RFI.lastIdSCFUR)
                RFI.newDays = If(tblScaffoldInfo.Rows(1).Cells(1).Value IsNot Nothing, tblScaffoldInfo.Rows(1).Cells(1).Value, RFI.lastDays)
                RFI.newWith = If(tblScaffoldInfo.Rows(1).Cells(2).Value IsNot Nothing, tblScaffoldInfo.Rows(1).Cells(2).Value, RFI.lastWith)
                RFI.newLength = If(tblScaffoldInfo.Rows(1).Cells(3).Value IsNot Nothing, tblScaffoldInfo.Rows(1).Cells(3).Value, RFI.lastLength)
                RFI.newHeigth = If(tblScaffoldInfo.Rows(1).Cells(4).Value IsNot Nothing, tblScaffoldInfo.Rows(1).Cells(4).Value, RFI.lastHeigth)
                RFI.newBuild = If(tblScaffoldInfo.Rows(1).Cells(5).Value IsNot Nothing, tblScaffoldInfo.Rows(1).Cells(5).Value, RFI.lastBuild)
                RFI.newDecks = If(tblScaffoldInfo.Rows(1).Cells(6).Value IsNot Nothing, tblScaffoldInfo.Rows(1).Cells(6).Value, RFI.lastDecks)

                RFI.reqEmployee = txtNameReq.Text
                RFI.reqTitleEmployee = txtTitleReq.Text
                RFI.reqCompany = txtCompanyReq.Text
                RFI.reqDate = dtpDateReq.Value

                RFI.chUpEmployee = txtNameUpdate.Text
                RFI.chUpTitleEmployee = txtTitleUpdate.Text
                RFI.chUpDate = dtpDateUpdate.Value
                RFI.basicFCRlastBuild = txtBasicForNum.Text
                RFI.note = txtNote.Text
                RFI.weDate = dtpDateWE.Value
                Return RFI
            Else
                MessageBox.Show("Please Assign a RFI number to conitnue", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Function llenarDatosRFI(ByVal row As Data.DataRow) As Boolean
        Try
            limpiarTablas()
            limpiarInfExtra()
            txtIdRFIScaffold.Text = row.ItemArray(0)
            'last info
            tblGeneralScaffold.Rows(0).Cells("laborRateNew").Value = row.ItemArray(17)
            tblScaffoldInfo.Rows(0).Cells("Type").Value = row.ItemArray(18)
            tblScaffoldInfo.Rows(0).Cells("DaysActive").Value = row.ItemArray(11)
            tblScaffoldInfo.Rows(0).Cells("width").Value = row.ItemArray(12)
            tblScaffoldInfo.Rows(0).Cells("length").Value = row.ItemArray(14)
            tblScaffoldInfo.Rows(0).Cells("heigth").Value = row.ItemArray(13)
            tblScaffoldInfo.Rows(0).Cells("Build").Value = row.ItemArray(15)
            tblScaffoldInfo.Rows(0).Cells("Decks").Value = row.ItemArray(16)
            'changues 
            tblGeneralScaffold.Rows(1).Cells("laborRateNew").Value = row.ItemArray(9)
            tblScaffoldInfo.Rows(1).Cells("Type").Value = row.ItemArray(10)
            tblScaffoldInfo.Rows(1).Cells("DaysActive").Value = row.ItemArray(3)
            tblScaffoldInfo.Rows(1).Cells("width").Value = row.ItemArray(4)
            tblScaffoldInfo.Rows(1).Cells("length").Value = row.ItemArray(6)
            tblScaffoldInfo.Rows(1).Cells("heigth").Value = row.ItemArray(5)
            tblScaffoldInfo.Rows(1).Cells("Build").Value = row.ItemArray(7)
            tblScaffoldInfo.Rows(1).Cells("Decks").Value = row.ItemArray(8)

            txtNameReq.Text = row.ItemArray(19)
            txtTitleReq.Text = row.ItemArray(20)
            dtpDateReq.Value = validarFechaParaVB(row.ItemArray(21).ToString)
            txtCompanyReq.Text = row.ItemArray(22)
            txtNameUpdate.Text = row.ItemArray(23)
            txtTitleUpdate.Text = row.ItemArray(24)
            dtpDateUpdate.Value = validarFechaParaVB(row.ItemArray(25).ToString)
            txtBasicForNum.Text = row.ItemArray(26)
            dtpDateWE.Value = validarFechaParaVB(row.ItemArray(27).ToString())
            txtNote.Text = row.ItemArray(28)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Private Sub tblHistoryRFIScaffold_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles tblHistoryRFIScaffold.CellDoubleClick
        Dim selectRow As DataGridViewRow = tblHistoryRFIScaffold.Rows(e.RowIndex)
        Dim listRow() As DataRow = tblRFIHistory.Select("idRFI='" + selectRow.Cells("idRFI").Value + "' and tag = '" + idTag + "'")
        If listRow.Length > 0 Then
            btnDelete.Enabled = True
            llenarDatosRFI(listRow(0))
        End If
    End Sub

    Private Sub btnReportRFIScaffold_Click(sender As Object, e As EventArgs) Handles btnReportRFIScaffold.Click
        Dim rpt As New RFIReports
        rpt.TypeRFI = "Scaffold"
        rpt.idDrawingNum = idDrawing
        rpt.idTag = idTag
        rpt.idRFI = txtIdRFIScaffold.Text
        rpt.Show()
    End Sub

    Private Sub txtBasicForNum_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBasicForNum.KeyPress
        If Not (IsNumeric(e.KeyChar) Or e.KeyChar = vbBack Or e.KeyChar = vbLf) Then
            e.Handled = True
        End If
    End Sub

End Class