Public Class Factors
    Dim mtdElevation As New ElevationEstimation
    Dim mtdFactor As New MetodosFactor
    Dim tablaTypeSize As New Data.DataTable
    Dim selectTable As String
    Private Sub Factors_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mtdElevation.selectElevationSCF(tblScafElevation)
        mtdElevation.selectElevationPaint(tblPaintElevation)
        mtdFactor.selectLaborRat(tblWorkWeekScheduleLaborRates)
        'mtdFactor.selectScafUnitsRates(tblSCFUnitsRates)
        'mtdFactor.selectEnviroment(tblEnviroment)
        'mtdFactor.selectInsFitting(tblInsFitting)
        'mtdFactor.selectPntFitting(tblPntFitting)
        'mtdFactor.selectEqPntUnitRate(tblEqPaintUnitRate)
        'mtdFactor.selectPpPntUnitRate(tblPpPaintUnitRate)
        'mtdFactor.selectEqJacketunitRate(tblJacketEq)
        'mtdFactor.selectPpJacketunitRate(tblJacketPp)
        'mtdFactor.selectEqInsUnitRate(tblEqInsUnitRate)
        'mtdFactor.selectPpInsUnitRate(tblPpInsUnitRate)
        'mtdFactor.selectSizesMaterialPiping(tblPipingMaterial)
        'mtdFactor.selectSizesMaterialEquipment(tblEquipmentMaterial)
        'mtdFactor.selectEqIRHC(tblEquipmentIRHC)
        'mtdFactor.selectPpIRHC(tblPipingIRHC)
    End Sub
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnExcelTblElvationFactor_Click(sender As Object, e As EventArgs) Handles btnExcelTblElvationFactor.Click
        Try
            Dim sheetName = InputBox("Please Write the name of the Sheet to Read.", "Find Excel Sheet", "Sheet 1")
            While sheetName <> ""
                Dim tbl = leerExcel(lblMessage, pgbProgress, sheetName)
                If tbl IsNot Nothing Then
                    For Each row As Data.DataRow In tbl.Rows()
                        tblScafElevation.Rows.Add("", row.ItemArray(0).ToString(), row.ItemArray(1).ToString())
                    Next
                    pgbProgress.Value = 100
                    lblMessage.Text = "Message: End."
                    Exit While
                Else
                    sheetName = InputBox("Please Write the name of the Sheet to Read." + "If do not wish to continue, leave the space blank.", "find Excel Sheet", "Sheet 1")
                End If
            End While
        Catch ex As Exception

        End Try
        selectTable = "ElevationSCF"
    End Sub
    Private Sub btnExcelTblElevationPaint_Click(sender As Object, e As EventArgs) Handles btnExcelTblElevationPaint.Click
        Try
            Dim sheetName = InputBox("Please Write the name of the Sheet to Read.", "Find Excel Sheet", "Sheet 1")
            While sheetName <> ""
                Dim tbl = leerExcel(lblMessage, pgbProgress, sheetName)
                If tbl IsNot Nothing Then
                    For Each row As Data.DataRow In tbl.Rows()
                        tblPaintElevation.Rows.Add("", row.ItemArray(0).ToString(), row.ItemArray(1).ToString())
                    Next
                    pgbProgress.Value = 100
                    lblMessage.Text = "Message: End."
                    Exit While
                Else
                    sheetName = InputBox("Please Write the name of the Sheet to Read." + "If do not wish to continue, leave the space blank.", "find Excel Sheet", "Sheet 1")
                End If
            End While
        Catch ex As Exception

        End Try
        selectTable = "ElevationPaint"
    End Sub
    Private Sub tblScafElevation_Enter(sender As Object, e As EventArgs) Handles tblScafElevation.Enter
        selectTable = "ElevationSCF"
    End Sub
    Private Sub tblPaintElevation_Enter(sender As Object, e As EventArgs) Handles tblPaintElevation.Enter
        selectTable = "ElevationPaint"
    End Sub
    Private Sub tblSCFUnitsRates_Enter(sender As Object, e As EventArgs) Handles tblSCFUnitsRates.Enter
        selectTable = "SCFUnitsRates"
    End Sub
    Private Sub tblEnviroment_Enter(sender As Object, e As EventArgs) Handles tblEnviroment.Enter
        selectTable = "Enviroment"
    End Sub
    Private Sub tblInsFitting_Enter(sender As Object, e As EventArgs) Handles tblInsFitting.Enter
        selectTable = "InsFitting"
    End Sub
    Private Sub tblPntFitting_Enter(sender As Object, e As EventArgs) Handles tblPntFitting.Enter
        selectTable = "PntFitting"
    End Sub
    Private Sub tblEqPaintUnitRate_Enter(sender As Object, e As EventArgs) Handles tblEqPaintUnitRate.Enter
        selectTable = "EqPntUnitRate"
    End Sub
    Private Sub tblPpPaintUnitRate_Enter(sender As Object, e As EventArgs) Handles tblPpPaintUnitRate.Enter
        selectTable = "PpPntUnitRate"
    End Sub
    Private Sub tblJacketEq_Enter(sender As Object, e As EventArgs) Handles tblJacketEq.Enter
        selectTable = "eqJacketUnitRate"
    End Sub
    Private Sub tblJacketPp_Enter(sender As Object, e As EventArgs) Handles tblJacketPp.Enter
        selectTable = "ppJacketUnitRate"
    End Sub
    Private Sub tblEqInsUnitRate_Enter(sender As Object, e As EventArgs) Handles tblEqInsUnitRate.Enter
        selectTable = "EquipmentInsUR"
    End Sub
    Private Sub tblPpInsUnitRate_Enter(sender As Object, e As EventArgs) Handles tblPpInsUnitRate.Enter
        selectTable = "PipingInsUR"
    End Sub
    Private Sub tblEquipmentMaterial_Enter(sender As Object, e As EventArgs) Handles tblEquipmentMaterial.Enter
        selectTable = "EquipmentMaterial"
    End Sub
    Private Sub tblPipingMaterial_Enter(sender As Object, e As EventArgs) Handles tblPipingMaterial.Enter
        selectTable = "PipingMaterial"
    End Sub
    Private Sub tblWorkWeekScheduleLaborRates_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles tblWorkWeekScheduleLaborRates.CellEndEdit
        Select Case e.ColumnIndex
            Case 2 To 5
                If tblWorkWeekScheduleLaborRates.CurrentRow.Cells(e.ColumnIndex).Value IsNot Nothing Then
                    If Not soloNumero(tblWorkWeekScheduleLaborRates.CurrentRow.Cells(e.ColumnIndex).Value.ToString()) Then
                        tblWorkWeekScheduleLaborRates.CurrentRow.Cells(e.ColumnIndex).Value = "0"
                    End If
                End If
        End Select
    End Sub
    Private Sub tblOnlyDigitCell_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles tblPpInsUnitRate.CellEndEdit, tblEqInsUnitRate.CellEndEdit, tblPntFitting.CellEndEdit, tblInsFitting.CellEndEdit, tblEnviroment.CellEndEdit, tblSCFUnitsRates.CellEndEdit, tblPaintElevation.CellEndEdit, tblScafElevation.CellEndEdit, tblPpPaintUnitRate.CellEndEdit, tblEqPaintUnitRate.CellEndEdit, tblPipingMaterial.CellEndEdit, tblEquipmentMaterial.CellEndEdit
        Select Case selectTable
            Case "ElevationSCF"
                Select Case e.ColumnIndex
                    Case 1 To 2
                        If tblScafElevation.CurrentRow.Cells(e.ColumnIndex).Value IsNot Nothing Then
                            If Not soloNumero(tblScafElevation.CurrentRow.Cells(e.ColumnIndex).Value.ToString()) Then
                                tblScafElevation.CurrentRow.Cells(e.ColumnIndex).Value = "0"
                            End If
                        End If
                    Case Else
                End Select
            Case "ElevationPaint"
                Select Case e.ColumnIndex
                    Case 1 To 2
                        If tblPaintElevation.CurrentRow.Cells(e.ColumnIndex).Value IsNot Nothing Then
                            If Not soloNumero(tblPaintElevation.CurrentRow.Cells(e.ColumnIndex).Value.ToString()) Then
                                tblPaintElevation.CurrentRow.Cells(e.ColumnIndex).Value = "0"
                            End If
                        End If
                    Case Else
                End Select
            Case "SCFUnitsRates"
                Select Case e.ColumnIndex
                    Case 2 To 9
                        If tblSCFUnitsRates.CurrentRow.Cells(e.ColumnIndex).Value IsNot Nothing Then
                            If Not soloNumero(tblSCFUnitsRates.CurrentRow.Cells(e.ColumnIndex).Value.ToString()) Then
                                tblSCFUnitsRates.CurrentRow.Cells(e.ColumnIndex).Value = "0"
                            End If
                        End If
                    Case Else
                End Select
            Case "Enviroment"
                Select Case e.ColumnIndex
                    Case 2
                        If tblEnviroment.CurrentRow.Cells(e.ColumnIndex).Value IsNot Nothing Then
                            If Not soloNumero(tblEnviroment.CurrentRow.Cells(e.ColumnIndex).Value.ToString()) Then
                                tblEnviroment.CurrentRow.Cells(e.ColumnIndex).Value = "0"
                            End If
                        End If
                    Case Else
                End Select
            Case "InsFitting"
                Select Case e.ColumnIndex
                    Case 2 To 14
                        If tblInsFitting.CurrentRow.Cells(e.ColumnIndex).Value IsNot Nothing Then
                            If Not soloNumero(tblInsFitting.CurrentRow.Cells(e.ColumnIndex).Value.ToString()) Then
                                tblInsFitting.CurrentRow.Cells(e.ColumnIndex).Value = "0"
                            End If
                        End If
                    Case Else
                End Select
            Case "PntFitting"
                Select Case e.ColumnIndex
                    Case 2 To 8
                        If tblPntFitting.CurrentRow.Cells(e.ColumnIndex).Value IsNot Nothing Then
                            If Not soloNumero(tblPntFitting.CurrentRow.Cells(e.ColumnIndex).Value.ToString()) Then
                                tblPntFitting.CurrentRow.Cells(e.ColumnIndex).Value = "0"
                            End If
                        End If
                    Case Else
                End Select
            Case "EqPntUnitRate"
                Select Case e.ColumnIndex
                    Case 4 To 6
                        If tblEqPaintUnitRate.CurrentRow.Cells(e.ColumnIndex).Value IsNot Nothing Then
                            If Not soloNumero(tblEqPaintUnitRate.CurrentRow.Cells(e.ColumnIndex).Value.ToString()) Then
                                tblEqPaintUnitRate.CurrentRow.Cells(e.ColumnIndex).Value = "0"
                            End If
                        End If
                    Case Else
                End Select
            Case "PpPntUnitRate"
                Select Case e.ColumnIndex
                    Case 5 To 8
                        If tblPpPaintUnitRate.CurrentRow.Cells(e.ColumnIndex).Value IsNot Nothing Then
                            If Not soloNumero(tblPpPaintUnitRate.CurrentRow.Cells(e.ColumnIndex).Value.ToString()) Then
                                tblPpPaintUnitRate.CurrentRow.Cells(e.ColumnIndex).Value = "0"
                            End If
                        End If
                    Case Else
                End Select
            Case "eqJacketUnitRate"
                Select Case e.ColumnIndex
                    Case 3 To 5
                        If tblJacketEq.CurrentRow.Cells(e.ColumnIndex).Value IsNot Nothing Then
                            If Not soloNumero(tblJacketEq.CurrentRow.Cells(e.ColumnIndex).Value.ToString()) Then
                                tblJacketEq.CurrentRow.Cells(e.ColumnIndex).Value = "0"
                            End If
                        End If
                    Case Else
                End Select
            Case "ppJacketUnitRate"
                Select Case e.ColumnIndex
                    Case 3 To 5
                        If tblJacketPp.CurrentRow.Cells(e.ColumnIndex).Value IsNot Nothing Then
                            If Not soloNumero(tblJacketPp.CurrentRow.Cells(e.ColumnIndex).Value.ToString()) Then
                                tblJacketPp.CurrentRow.Cells(e.ColumnIndex).Value = "0"
                            End If
                        End If
                    Case Else
                End Select
            Case "EquipmentInsUR"
                Select Case e.ColumnIndex
                    Case 3 To 6
                        If tblEqInsUnitRate.CurrentRow.Cells(e.ColumnIndex).Value IsNot Nothing Then
                            If Not soloNumero(tblEqInsUnitRate.CurrentRow.Cells(e.ColumnIndex).Value.ToString()) Then
                                tblEqInsUnitRate.CurrentRow.Cells(e.ColumnIndex).Value = "0"
                            End If
                        End If
                    Case Else
                End Select
            Case "PipingInsUR"
                Select Case e.ColumnIndex
                    Case 3
                        If tblPpInsUnitRate.CurrentRow.Cells(e.ColumnIndex).Value IsNot Nothing Then
                            If Not soloNumero(tblPpInsUnitRate.CurrentRow.Cells(e.ColumnIndex).Value.ToString()) Then
                                tblPpInsUnitRate.CurrentRow.Cells(e.ColumnIndex).Value = "0"
                            End If
                        End If
                    Case 5 To 8
                        If tblPpInsUnitRate.CurrentRow.Cells(e.ColumnIndex).Value IsNot Nothing Then
                            If Not soloNumero(tblPpInsUnitRate.CurrentRow.Cells(e.ColumnIndex).Value.ToString()) Then
                                tblPpInsUnitRate.CurrentRow.Cells(e.ColumnIndex).Value = "0"
                            End If
                        End If
                    Case Else
                End Select
            Case "EquipmentMaterial"
                Select Case e.ColumnIndex
                    Case 3 To 4
                        If tblEquipmentMaterial.CurrentRow.Cells(e.ColumnIndex).Value IsNot Nothing Then
                            If Not soloNumero(tblEquipmentMaterial.CurrentRow.Cells(e.ColumnIndex).Value.ToString()) Then
                                tblEquipmentMaterial.CurrentRow.Cells(e.ColumnIndex).Value = "0"
                            End If
                        End If
                End Select
            Case "PipingMaterial"
                Select Case e.ColumnIndex
                    Case 3
                        If tblPipingMaterial.CurrentRow.Cells(e.ColumnIndex).Value IsNot Nothing Then
                            If Not soloNumero(tblPipingMaterial.CurrentRow.Cells(e.ColumnIndex).Value.ToString()) Then
                                tblPipingMaterial.CurrentRow.Cells(e.ColumnIndex).Value = "0"
                            End If
                        End If
                    Case 5 To 6
                        If tblPipingMaterial.CurrentRow.Cells(e.ColumnIndex).Value IsNot Nothing Then
                            If Not soloNumero(tblPipingMaterial.CurrentRow.Cells(e.ColumnIndex).Value.ToString()) Then
                                tblPipingMaterial.CurrentRow.Cells(e.ColumnIndex).Value = "0"
                            End If
                        End If
                End Select
        End Select
    End Sub
    Private Sub btnSaveFactorTbl_Click(sender As Object, e As EventArgs) Handles btnSaveFactorTbl.Click
        Select Case selectTable
            Case "ElevationSCF"
                If tblScafElevation.SelectedRows.Count > 0 Then
                    If mtdElevation.saveUpdateElevationSCF(tblScafElevation) Then
                        mtdElevation.selectElevationSCF(tblScafElevation)
                        MsgBox("Successful.")
                    End If
                Else
                    MessageBox.Show("Please Select a row in the Tabla Scaffold Elevation to Constinue.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If
            Case "ElevationPaint"
                If tblPaintElevation.SelectedRows.Count > 0 Then
                    If mtdElevation.saveUpdateElevationPaint(tblPaintElevation) Then
                        mtdElevation.selectElevationPaint(tblPaintElevation)
                        MsgBox("Successful.")
                    End If
                Else
                    MessageBox.Show("Please Select a row in the Table Paint Elevation to Constinue.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If
            Case "SCFUnitsRates"
                If tblSCFUnitsRates.SelectedRows.Count > 0 Then
                    If mtdFactor.saveUpdateSCFUnitsRates(tblSCFUnitsRates) Then
                        mtdFactor.selectScafUnitsRates(tblSCFUnitsRates)
                        MsgBox("Successful.")
                    End If
                Else
                    MessageBox.Show("Please Select a row in the Table Scaffold Units Rates to Constinue.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If
            Case "Enviroment"
                If tblEnviroment.SelectedRows.Count > 0 Then
                    If mtdFactor.saveUpdateEnviroment(tblEnviroment) Then
                        mtdFactor.selectEnviroment(tblEnviroment)
                        MsgBox("Successful.")
                    End If
                Else
                    MessageBox.Show("Please Select a row in the Table Enviroment Factors to Constinue.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If
            Case "InsFitting"
                If tblInsFitting.SelectedRows.Count > 0 Then
                    If mtdFactor.saveUpdateInsFitting(tblInsFitting) Then
                        mtdFactor.selectInsFitting(tblInsFitting)
                        MsgBox("Successful.")
                    End If
                Else
                    MessageBox.Show("Please Select a row in the Table Insulation Fitting Factors to Constinue.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If
            Case "PntFitting"
                If tblPntFitting.SelectedRows.Count > 0 Then
                    If mtdFactor.saveUpdatePntFitting(tblPntFitting) Then
                        mtdFactor.selectPntFitting(tblPntFitting)
                        MsgBox("Successful.")
                    End If
                Else
                    MessageBox.Show("Please Select a row in the Table Paint Fitting Factors to Constinue.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If
            Case "EqPntUnitRate"
                If tblEqPaintUnitRate.SelectedRows.Count > 0 Then
                    If mtdFactor.saveUpdateEqPntUnitRate(tblEqPaintUnitRate) Then
                        mtdFactor.selectEqPntUnitRate(tblEqPaintUnitRate)
                        MsgBox("Successful.")
                    End If
                Else
                    MessageBox.Show("Please Select a row in the Table Equipment Paint Unit Rate to Constinue.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If
            Case "PpPntUnitRate"
                If tblPpPaintUnitRate.SelectedRows.Count > 0 Then
                    If mtdFactor.saveUpdatePpPntUnitRate(tblPpPaintUnitRate) Then
                        mtdFactor.selectPpPntUnitRate(tblPpPaintUnitRate)
                        MsgBox("Successful.")
                    End If
                Else
                    MessageBox.Show("Please Select a row in the Table Equipment Paint Unit Rate to Constinue.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If
            Case "eqJacketUnitRate"
                If tblJacketEq.SelectedRows.Count > 0 Then
                    If mtdFactor.saveUpdateEqJacketUnitRate(tblJacketEq) Then
                        mtdFactor.selectEqJacketunitRate(tblJacketEq)
                        MsgBox("Successful.")
                    End If
                Else
                    MessageBox.Show("Please Select a row in the Table Equipment in Insulation Jackets Unit Rates to Constinue.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If
            Case "ppJacketUnitRate"
                If tblJacketPp.SelectedRows.Count > 0 Then
                    If mtdFactor.saveUpdatePpJacketUnitRate(tblJacketPp) Then
                        mtdFactor.selectPpJacketunitRate(tblJacketPp)
                        MsgBox("Successful.")
                    End If
                Else
                    MessageBox.Show("Please Select a row in the Table Piping in Insulation Jacket Unit Rate to Constinue.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If
            Case "EquipmentInsUR"
                If tblEqInsUnitRate.SelectedRows.Count > 0 Then
                    If mtdFactor.saveUpdateEqInsUnitRate(tblEqInsUnitRate) Then
                        mtdFactor.selectEqInsUnitRate(tblEqInsUnitRate)
                        MsgBox("Successful.")
                    End If
                Else
                    MessageBox.Show("Please Select a row in the Table Equipment Insulation Rate Unit Rates to Constinue.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If
            Case "PipingInsUR"
                If tblPpInsUnitRate.SelectedRows.Count > 0 Then
                    If mtdFactor.saveUpdatePpInsUnitRate(tblPpInsUnitRate) Then
                        mtdFactor.selectPpInsUnitRate(tblPpInsUnitRate)
                        MsgBox("Successful.")
                    End If
                Else
                    MessageBox.Show("Please Select a row in the Table Piping Insulation Rate Unit Rate to Constinue.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If
            Case "PipingMaterial"
                If tblPipingMaterial.SelectedRows.Count > 0 Then
                    If mtdFactor.saveUpdatePipingMaterial(tblPipingMaterial) Then
                        mtdFactor.selectSizesMaterialPiping(tblPipingMaterial)
                        MsgBox("Successful.")
                    End If
                Else
                    MessageBox.Show("Please Select a row in the Table Piping Insulation Rate Unit Rate to Constinue.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If
            Case "EquipmentHC"
                If tblEquipmentIRHC.SelectedRows.Count > 0 Then
                    If mtdFactor.saveUpdateEqIRHC(tblEquipmentIRHC) Then
                        mtdFactor.selectEqIRHC(tblEquipmentIRHC)
                        MsgBox("Successful.")
                    End If
                Else
                    MessageBox.Show("Please Select a row in the Table Equipment IR HC Insulation Rate Unit Rate to Constinue.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If
            Case "PipingIRHC"
                If tblPipingIRHC.SelectedRows.Count > 0 Then
                    If mtdFactor.saveUpdatePpIRHC(tblPipingIRHC) Then
                        mtdFactor.selectPpIRHC(tblPipingIRHC)
                        MsgBox("Successful.")
                    End If
                Else
                    MessageBox.Show("Please Select a row in the Table Piping IR HC Insulation Rate Unit Rate to Constinue.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If
            Case "EquipmentMaterial"
                If tblEquipmentMaterial.SelectedRows.Count > 0 Then
                    If mtdFactor.saveUpdateEqipmentMaterial(tblEquipmentMaterial) Then
                        mtdFactor.selectSizesMaterialEquipment(tblEquipmentMaterial)
                        MsgBox("Successful.")
                    End If
                Else
                    MessageBox.Show("Please Select a row in the Table Piping Insulation Rate Unit Rate to Constinue.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If
        End Select
    End Sub
    Private Sub btnDeleteFactorTbl_Click(sender As Object, e As EventArgs) Handles btnDeleteFactorTbl.Click
        Select Case selectTable
            Case "ElevationSCF"
                If tblScafElevation.SelectedRows.Count > 0 Then
                    If DialogResult.Yes = MessageBox.Show("If you Accept, is likely that you delete an Element that is related to this Records. Are you sure to continue?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) Then
                        If mtdElevation.deleteElevationSCF(tblScafElevation) Then
                            For Each row As DataGridViewRow In tblScafElevation.SelectedRows()
                                tblScafElevation.Rows.Remove(row)
                            Next
                            MsgBox("Successfull")
                        Else
                            MsgBox("Error, check the Data or refresh the Window.")
                        End If
                    End If
                Else
                    MessageBox.Show("Please Select A Row.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If
            Case "ElevationPaint"
                If tblPaintElevation.SelectedRows.Count > 0 Then
                    If DialogResult.Yes = MessageBox.Show("If you Accept, is likely that you delete an Element that is related to this Records. Are you sure to continue?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) Then
                        If mtdElevation.deleteElevationPaint(tblPaintElevation) Then
                            For Each row As DataGridViewRow In tblPaintElevation.SelectedRows()
                                tblPaintElevation.Rows.Remove(row)
                            Next
                            MsgBox("Successfull")
                        Else
                            MsgBox("Error, check the Data or refresh the Window.")
                        End If
                    End If
                Else
                    MessageBox.Show("Please Select A Row.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If
            Case "SCFUnitsRates"
                If tblSCFUnitsRates.SelectedRows.Count > 0 Then
                    If DialogResult.Yes = MessageBox.Show("If you Accept, is likely that you delete an Element that is related to this Records. Are you sure to continue?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) Then
                        If mtdFactor.deleteSCFUnitsRates(tblSCFUnitsRates) Then
                            For Each row As DataGridViewRow In tblSCFUnitsRates.SelectedRows()
                                tblSCFUnitsRates.Rows.Remove(row)
                            Next
                            MsgBox("Successfull")
                        Else
                            MsgBox("Error, check the Data or refresh the Window.")
                        End If
                    End If
                Else
                    MessageBox.Show("Please Select A Row.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If
            Case "Enviroment"
                If tblEnviroment.SelectedRows.Count > 0 Then
                    If DialogResult.Yes = MessageBox.Show("If you Accept, is likely that you delete an Element that is related to this Records. Are you sure to continue?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) Then
                        If mtdFactor.deleteEnviroment(tblEnviroment) Then
                            For Each row As DataGridViewRow In tblEnviroment.SelectedRows()
                                tblEnviroment.Rows.Remove(row)
                            Next
                            MsgBox("Successfull")
                        Else
                            MsgBox("Error, check the Data or refresh the Window.")
                        End If
                    End If
                Else
                    MessageBox.Show("Please Select A Row.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If
            Case "InsFitting"
                If tblInsFitting.SelectedRows.Count > 0 Then
                    If DialogResult.Yes = MessageBox.Show("If you Accept, is likely that you delete an Element that is related to this Records. Are you sure to continue?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) Then
                        If mtdFactor.deleteInsFitting(tblInsFitting) Then
                            For Each row As DataGridViewRow In tblInsFitting.SelectedRows()
                                tblInsFitting.Rows.Remove(row)
                            Next
                            MsgBox("Successfull")
                        Else
                            MsgBox("Error, check the Data or refresh the Window.")
                        End If
                    End If
                Else
                    MessageBox.Show("Please Select A Row.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If
            Case "PntFitting"
                If tblPntFitting.SelectedRows.Count > 0 Then
                    If DialogResult.Yes = MessageBox.Show("If you Accept, is likely that you delete an Element that is related to this Records. Are you sure to continue?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) Then
                        If mtdFactor.deletePntFitting(tblPntFitting) Then
                            For Each row As DataGridViewRow In tblPntFitting.SelectedRows()
                                tblPntFitting.Rows.Remove(row)
                            Next
                            MsgBox("Successfull")
                        Else
                            MsgBox("Error, check the Data or refresh the Window.")
                        End If
                    End If
                Else
                    MessageBox.Show("Please Select A Row.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If
            Case "EqPntUnitRate"
                If tblEqPaintUnitRate.SelectedRows.Count > 0 Then
                    If DialogResult.Yes = MessageBox.Show("If you Accept, is likely that you delete an Element that is related to this Records. Are you sure to continue?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) Then
                        If mtdFactor.deleteEqPntUnitRate(tblEqPaintUnitRate) Then
                            For Each row As DataGridViewRow In tblEqPaintUnitRate.SelectedRows()
                                tblEqPaintUnitRate.Rows.Remove(row)
                            Next
                            MsgBox("Successfull")
                        Else
                            MsgBox("Error, check the Data or refresh the Window.")
                        End If
                    End If
                Else
                    MessageBox.Show("Please Select A Row.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If
            Case "PpPntUnitRate"
                If tblPpPaintUnitRate.SelectedRows.Count > 0 Then
                    If DialogResult.Yes = MessageBox.Show("If you Accept, is likely that you delete an Element that is related to this Records. Are you sure to continue?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) Then
                        If mtdFactor.deletePpPntUnitRate(tblPpPaintUnitRate) Then
                            For Each row As DataGridViewRow In tblPpPaintUnitRate.SelectedRows()
                                tblPpPaintUnitRate.Rows.Remove(row)
                            Next
                            MsgBox("Successfull")
                        Else
                            MsgBox("Error, check the Data or refresh the Window.")
                        End If
                    End If
                Else
                    MessageBox.Show("Please Select A Row.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If
            Case "eqJacketUnitRate"
                If tblJacketEq.SelectedRows.Count > 0 Then
                    If DialogResult.Yes = MessageBox.Show("If you Accept, is likely that you delete an Element that is related to this Records. Are you sure to continue?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) Then
                        If mtdFactor.deleteEqJacketUnitRate(tblJacketEq) Then
                            For Each row As DataGridViewRow In tblJacketEq.SelectedRows()
                                tblJacketEq.Rows.Remove(row)
                            Next
                            MsgBox("Successfull")
                        Else
                            MsgBox("Error, check the Data or refresh the Window.")
                        End If
                    End If
                Else
                    MessageBox.Show("Please Select A Row.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If
            Case "ppJacketUnitRate"
                If tblJacketPp.SelectedRows.Count > 0 Then
                    If DialogResult.Yes = MessageBox.Show("If you Accept, is likely that you delete an Element that is related to this Records. Are you sure to continue?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) Then
                        If mtdFactor.deletePpJacketUnitRate(tblJacketPp) Then
                            For Each row As DataGridViewRow In tblJacketPp.SelectedRows()
                                tblJacketPp.Rows.Remove(row)
                            Next
                            MsgBox("Successfull")
                        Else
                            MsgBox("Error, check the Data or refresh the Window.")
                        End If
                    End If
                Else
                    MessageBox.Show("Please Select A Row.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If
            Case "EquipmentInsUR"
                If tblEqInsUnitRate.SelectedRows.Count > 0 Then
                    If DialogResult.Yes = MessageBox.Show("If you Accept, is likely that you delete an Element that is related to this Records. Are you sure to continue?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) Then
                        If mtdFactor.deleteEqInsUnitRate(tblEqInsUnitRate) Then
                            For Each row As DataGridViewRow In tblEqInsUnitRate.SelectedRows()
                                tblEqInsUnitRate.Rows.Remove(row)
                            Next
                            MsgBox("Successfull")
                        Else
                            MsgBox("Error, check the Data or refresh the Window.")
                        End If
                    End If
                Else
                    MessageBox.Show("Please Select A Row.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If
            Case "PipingInsUR"
                If tblPpInsUnitRate.SelectedRows.Count > 0 Then
                    If DialogResult.Yes = MessageBox.Show("If you Accept, is likely that you delete an Element that is related to this Records. Are you sure to continue?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) Then
                        If mtdFactor.deletePpInsUnitRate(tblPpInsUnitRate) Then
                            For Each row As DataGridViewRow In tblPpInsUnitRate.SelectedRows()
                                tblPpInsUnitRate.Rows.Remove(row)
                            Next
                            MsgBox("Successfull")
                        Else
                            MsgBox("Error, check the Data or refresh the Window.")
                        End If
                    End If
                Else
                    MessageBox.Show("Please Select A Row.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If
            Case "PipingMaterial"
                If tblPipingMaterial.SelectedRows.Count > 0 Then
                    If DialogResult.Yes = MessageBox.Show("If you Accept, is likely that you delete an Element that is related to this Records. Are you sure to continue?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) Then
                        If mtdFactor.deletePipingMaterial(tblPipingMaterial) Then
                            For Each row As DataGridViewRow In tblPipingMaterial.SelectedRows()
                                tblPipingMaterial.Rows.Remove(row)
                            Next
                            MsgBox("Successfull")
                        Else
                            MsgBox("Error, check the Data or refresh the Window.")
                        End If
                    End If
                Else
                    MessageBox.Show("Please Select A Row.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If
            Case "EquipmentHC"
                If tblEquipmentIRHC.SelectedRows.Count > 0 Then
                    If DialogResult.Yes = MessageBox.Show("If you Accept, is likely that you delete an Element that is related to this Records. Are you sure to continue?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) Then
                        If mtdFactor.deleteEqIRHC(tblEquipmentIRHC) Then
                            For Each row As DataGridViewRow In tblEquipmentIRHC.SelectedRows()
                                tblEquipmentIRHC.Rows.Remove(row)
                            Next
                            MsgBox("Successfull")
                        Else
                            MsgBox("Error, check the Data or refresh the Window.")
                        End If
                    End If
                Else
                    MessageBox.Show("Please Select A Row.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If
            Case "PipingIRHC"
                If tblPipingIRHC.SelectedRows.Count > 0 Then
                    If DialogResult.Yes = MessageBox.Show("If you Accept, is likely that you delete an Element that is related to this Records. Are you sure to continue?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) Then
                        If mtdFactor.deletePpIRHC(tblPipingIRHC) Then
                            For Each row As DataGridViewRow In tblPipingIRHC.SelectedRows()
                                tblPipingIRHC.Rows.Remove(row)
                            Next
                            MsgBox("Successfull")
                        Else
                            MsgBox("Error, check the Data or refresh the Window.")
                        End If
                    End If
                Else
                    MessageBox.Show("Please Select A Row.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If
            Case "EquipmentMaterial"
                If tblEquipmentMaterial.SelectedRows.Count > 0 Then
                    If DialogResult.Yes = MessageBox.Show("If you Accept, is likely that you delete an Element that is related to this Records. Are you sure to continue?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) Then
                        If mtdFactor.deleteEquipmentMaterial(tblEquipmentMaterial) Then
                            For Each row As DataGridViewRow In tblEquipmentMaterial.SelectedRows()
                                tblEquipmentMaterial.Rows.Remove(row)
                            Next
                            MsgBox("Successfull")
                        Else
                            MsgBox("Error, check the Data or refresh the Window.")
                        End If
                    End If
                Else
                    MessageBox.Show("Please Select A Row.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If
        End Select
    End Sub
    Private Sub btnSaveWWSLR_Click(sender As Object, e As EventArgs) Handles btnSaveWWSLR.Click
        Try
            If tblWorkWeekScheduleLaborRates.SelectedRows.Count > 0 Then
                If mtdFactor.saveUpdateLaborRate(tblWorkWeekScheduleLaborRates) Then
                    MsgBox("Successful")
                    mtdFactor.selectLaborRat(tblWorkWeekScheduleLaborRates)
                Else
                    MsgBox("Error, try again or refresh the Window")
                End If
            Else
                MessageBox.Show("Please select a row.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btnDropWWSLR_Click(sender As Object, e As EventArgs) Handles btnDropWWSLR.Click
        Try
            If tblWorkWeekScheduleLaborRates.SelectedRows.Count > 0 Then
                If DialogResult.Yes = MessageBox.Show("If you Accept, is likely that you delete an Element that is related to this Records. Are you sure to continue?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) Then
                    If mtdFactor.deleteLaborRate(tblWorkWeekScheduleLaborRates) Then
                        MsgBox("Successful")
                        For Each row As DataGridViewRow In tblWorkWeekScheduleLaborRates.SelectedRows()
                            tblWorkWeekScheduleLaborRates.Rows.Remove(row)
                        Next
                    Else
                        MsgBox("Error, try again or refresh the Window.")
                    End If
                End If
            Else
                MessageBox.Show("Please select a row.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btnExcelScaffoldUnitRates_Click(sender As Object, e As EventArgs) Handles btnExcelScaffoldUnitRates.Click
        Try
            Dim sheetName = InputBox("Please Write the name of the Sheet to Read.", "Find Excel Sheet", "Sheet 1")
            While sheetName <> ""
                Dim tbl = leerExcel(lblMessage, pgbProgress, sheetName)
                If tbl IsNot Nothing Then
                    For Each row As Data.DataRow In tbl.Rows()
                        tblSCFUnitsRates.Rows.Add("", row.ItemArray(0).ToString(), row.ItemArray(1).ToString(), row.ItemArray(2).ToString(), row.ItemArray(3).ToString(), row.ItemArray(4).ToString(), row.ItemArray(5).ToString(), row.ItemArray(6).ToString(), row.ItemArray(7).ToString(), row.ItemArray(8).ToString())
                    Next
                    pgbProgress.Value = 100
                    lblMessage.Text = "Message: End."
                    Exit While
                Else
                    sheetName = InputBox("Please Write the name of the Sheet to Read." + "If do not wish to continue, leave the space blank.", "find Excel Sheet", "Sheet 1")
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
        selectTable = "SCFUnitsRates"
    End Sub
    Private Sub btnExcelSCFEnviroment_Click(sender As Object, e As EventArgs) Handles btnExcelSCFEnviroment.Click
        Try
            Dim sheetName = InputBox("Please Write the name of the Sheet to Read.", "Find Excel Sheet", "Sheet 1")
            While sheetName <> ""
                Dim tbl = leerExcel(lblMessage, pgbProgress, sheetName)
                If tbl IsNot Nothing Then
                    For Each row As Data.DataRow In tbl.Rows()
                        tblEnviroment.Rows.Add("", row.ItemArray(0).ToString(), row.ItemArray(1).ToString())
                    Next
                    pgbProgress.Value = 100
                    lblMessage.Text = "Message: End."
                    Exit While
                Else
                    sheetName = InputBox("Please Write the name of the Sheet to Read." + "If do not wish to continue, leave the space blank.", "find Excel Sheet", "Sheet 1")
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
        selectTable = "Enviroment"
    End Sub
    Private Sub btnExcelInsFitting_Click(sender As Object, e As EventArgs) Handles btnExcelInsFitting.Click
        Try
            Dim sheetName = InputBox("Please Write the name of the Sheet to Read.", "Find Excel Sheet", "Sheet 1")
            While sheetName <> ""
                Dim tbl = leerExcel(lblMessage, pgbProgress, sheetName)
                If tbl IsNot Nothing Then
                    For Each row As Data.DataRow In tbl.Rows()
                        tblInsFitting.Rows.Add("", row.ItemArray(0).ToString(), row.ItemArray(1).ToString(), row.ItemArray(2).ToString(), row.ItemArray(3).ToString(), row.ItemArray(4).ToString(), row.ItemArray(5).ToString(), row.ItemArray(6).ToString(), row.ItemArray(7).ToString(), row.ItemArray(8).ToString(), row.ItemArray(9).ToString(), row.ItemArray(10).ToString(), row.ItemArray(11).ToString(), row.ItemArray(12).ToString(), row.ItemArray(13).ToString())
                    Next
                    pgbProgress.Value = 100
                    lblMessage.Text = "Message: End."
                    Exit While
                Else
                    sheetName = InputBox("Please Write the name of the Sheet to Read." + "If do not wish to continue, leave the space blank.", "find Excel Sheet", "Sheet 1")
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
        selectTable = "InsFitting"
    End Sub
    Private Sub btnExcelPnpFitting_Click(sender As Object, e As EventArgs) Handles btnExcelPnpFitting.Click
        Try
            Dim sheetName = InputBox("Please Write the name of the Sheet to Read.", "Find Excel Sheet", "Sheet 1")
            While sheetName <> ""
                Dim tbl = leerExcel(lblMessage, pgbProgress, sheetName)
                If tbl IsNot Nothing Then
                    For Each row As Data.DataRow In tbl.Rows()
                        tblPntFitting.Rows.Add("", row.ItemArray(0).ToString(), row.ItemArray(1).ToString(), row.ItemArray(2).ToString(), row.ItemArray(3).ToString(), row.ItemArray(4).ToString(), row.ItemArray(5).ToString(), row.ItemArray(6).ToString(), row.ItemArray(7).ToString())
                    Next
                    pgbProgress.Value = 100
                    lblMessage.Text = "Message: End."
                    Exit While
                Else
                    sheetName = InputBox("Please Write the name of the Sheet to Read." + "If do not wish to continue, leave the space blank.", "find Excel Sheet", "Sheet 1")
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
        selectTable = "PntFitting"
    End Sub
    Private Sub btnExcelEqPntUnitRate_Click(sender As Object, e As EventArgs) Handles btnExcelEqPntUnitRate.Click
        Try
            Dim sheetName = InputBox("Please Write the name of the Sheet to Read.", "Find Excel Sheet", "Sheet 1")
            While sheetName <> ""
                Dim tbl = leerExcel(lblMessage, pgbProgress, sheetName)
                If tbl IsNot Nothing Then
                    For Each row As Data.DataRow In tbl.Rows()
                        tblEqPaintUnitRate.Rows.Add("", "", row.ItemArray(0).ToString(), row.ItemArray(1).ToString(), row.ItemArray(2).ToString(), row.ItemArray(3).ToString(), row.ItemArray(4).ToString())
                    Next
                    pgbProgress.Value = 100
                    lblMessage.Text = "Message: End."
                    Exit While
                Else
                    sheetName = InputBox("Please Write the name of the Sheet to Read." + "If do not wish to continue, leave the space blank.", "find Excel Sheet", "Sheet 1")
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
        selectTable = "EqPntUnitRate"
    End Sub
    Private Sub btnExcelPpPntUnitRate_Click(sender As Object, e As EventArgs) Handles btnExcelPpPntUnitRate.Click
        Try
            Dim sheetName = InputBox("Please Write the name of the Sheet to Read.", "Find Excel Sheet", "Sheet 1")
            While sheetName <> ""
                Dim tbl = leerExcel(lblMessage, pgbProgress, sheetName)
                If tbl IsNot Nothing Then
                    For Each row As Data.DataRow In tbl.Rows()
                        tblPpPaintUnitRate.Rows.Add("", "", "", row.ItemArray(0).ToString(), row.ItemArray(1).ToString(), row.ItemArray(2).ToString(), row.ItemArray(3).ToString(), row.ItemArray(4).ToString(), row.ItemArray(5).ToString())
                    Next
                    pgbProgress.Value = 100
                    lblMessage.Text = "Message: End."
                    Exit While
                Else
                    sheetName = InputBox("Please Write the name of the Sheet to Read." + "If do not wish to continue, leave the space blank.", "find Excel Sheet", "Sheet 1")
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
        selectTable = "PpPntUnitRate"
    End Sub
    Private Sub btnExcelJacketEq_Click(sender As Object, e As EventArgs) Handles btnExcelJacketEq.Click
        Try
            Dim sheetName = InputBox("Please Write the name of the Sheet to Read.", "Find Excel Sheet", "Sheet 1")
            While sheetName <> ""
                Dim tbl = leerExcel(lblMessage, pgbProgress, sheetName)
                If tbl IsNot Nothing Then
                    For Each row As Data.DataRow In tbl.Rows()
                        tblJacketEq.Rows.Add("", row.ItemArray(0).ToString(), row.ItemArray(1).ToString(), row.ItemArray(2).ToString(), row.ItemArray(3).ToString(), row.ItemArray(4).ToString())
                    Next
                    pgbProgress.Value = 100
                    lblMessage.Text = "Message: End."
                    Exit While
                Else
                    sheetName = InputBox("Please Write the name of the Sheet to Read." + "If do not wish to continue, leave the space blank.", "find Excel Sheet", "Sheet 1")
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
        selectTable = "eqJacketUnitRate"
    End Sub

    Private Sub btnExcelJacketPp_Click(sender As Object, e As EventArgs) Handles btnExcelJacketPp.Click
        Try
            Dim sheetName = InputBox("Please Write the name of the Sheet to Read.", "Find Excel Sheet", "Sheet 1")
            While sheetName <> ""
                Dim tbl = leerExcel(lblMessage, pgbProgress, sheetName)
                If tbl IsNot Nothing Then
                    For Each row As Data.DataRow In tbl.Rows()
                        tblJacketPp.Rows.Add("", row.ItemArray(0).ToString(), row.ItemArray(1).ToString(), row.ItemArray(2).ToString(), row.ItemArray(3).ToString(), row.ItemArray(4).ToString())
                    Next
                    pgbProgress.Value = 100
                    lblMessage.Text = "Message: End."
                    Exit While
                Else
                    sheetName = InputBox("Please Write the name of the Sheet to Read." + "If do not wish to continue, leave the space blank.", "find Excel Sheet", "Sheet 1")
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
        selectTable = "ppJacketUnitRate"
    End Sub
    Private Sub btnExcelUpdateEqInsUR_Click(sender As Object, e As EventArgs) Handles btnExcelUpdateEqInsUR.Click
        Try
            Dim sheetName = InputBox("Please Write the name of the Sheet to Read.", "Find Excel Sheet", "Sheet 1")
            While sheetName <> ""
                Dim tbl = leerExcel(lblMessage, pgbProgress, sheetName)
                If tbl IsNot Nothing Then
                    For Each row As Data.DataRow In tbl.Rows()
                        tblEqInsUnitRate.Rows.Add("", "", row.ItemArray(0).ToString(), row.ItemArray(1).ToString(), row.ItemArray(2).ToString(), row.ItemArray(3).ToString(), row.ItemArray(4).ToString())
                    Next
                    pgbProgress.Value = 100
                    lblMessage.Text = "Message: End."
                    Exit While
                Else
                    sheetName = InputBox("Please Write the name of the Sheet to Read." + "If do not wish to continue, leave the space blank.", "find Excel Sheet", "Sheet 1")
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
        selectTable = "EquipmentInsUR"
    End Sub
    Private Sub btnExcelUpdatePpInsUR_Click(sender As Object, e As EventArgs) Handles btnExcelUpdatePpInsUR.Click
        Try
            Dim sheetName = InputBox("Please Write the name of the Sheet to Read.", "Find Excel Sheet", "Sheet 1")
            While sheetName <> ""
                Dim tbl = leerExcel(lblMessage, pgbProgress, sheetName)
                If tbl IsNot Nothing Then
                    For Each row As Data.DataRow In tbl.Rows()
                        tblPpInsUnitRate.Rows.Add("", "", "", row.ItemArray(0).ToString(), row.ItemArray(1).ToString(), row.ItemArray(2).ToString(), row.ItemArray(3).ToString(), row.ItemArray(4).ToString(), row.ItemArray(5).ToString())
                    Next
                    pgbProgress.Value = 100
                    lblMessage.Text = "Message: End."
                    Exit While
                Else
                    sheetName = InputBox("Please Write the name of the Sheet to Read." + "If do not wish to continue, leave the space blank.", "find Excel Sheet", "Sheet 1")
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
        selectTable = "PipingInsUR"
    End Sub
    Private Sub btnExcelTblEquipmentMaterial_Click(sender As Object, e As EventArgs) Handles btnExcelTblEquipmentMaterial.Click
        Try
            Dim sheetName = InputBox("Please Write the name of the Sheet to Read.", "Find Excel Sheet", "Sheet 1")
            While sheetName <> ""
                Dim tbl = leerExcel(lblMessage, pgbProgress, sheetName)
                If tbl IsNot Nothing Then
                    For Each row As Data.DataRow In tbl.Rows()
                        tblEquipmentMaterial.Rows.Add("", "", row.ItemArray(0).ToString(), row.ItemArray(1).ToString(), row.ItemArray(2).ToString(), row.ItemArray(3).ToString())
                    Next
                    pgbProgress.Value = 100
                    lblMessage.Text = "Message: End."
                    Exit While
                Else
                    sheetName = InputBox("Please Write the name of the Sheet to Read." + "If do not wish to continue, leave the space blank.", "find Excel Sheet", "Sheet 1")
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
        selectTable = "EquipmentMaterial"
    End Sub
    Private Sub tblEqPaintUnitRate_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles tblEqPaintUnitRate.CellClick
        Select Case e.ColumnIndex
            Case 3 'Option
                Try
                    If tblEqPaintUnitRate.CurrentCell.GetType.Name = "DataGridViewTextBoxCell" Then
                        Dim cmbOption As New DataGridViewComboBoxCell
                        With cmbOption
                            mtdFactor.llenarComboCellPntFitting(cmbOption)
                        End With
                        tblEqPaintUnitRate.CurrentRow.Cells("OptionEq") = cmbOption
                    Else
                        Dim cmbOption1 As DataGridViewComboBoxCell = tblEqPaintUnitRate.CurrentRow.Cells("OptionEq")
                        With cmbOption1
                            mtdFactor.llenarComboCellPntFitting(tblEqPaintUnitRate.CurrentRow.Cells("OptionEq"))
                        End With
                    End If
                Catch ex As Exception

                End Try
        End Select
    End Sub
    Public Sub cmb_SelectedIndexChanguedEq(sender As Object, e As EventArgs)
        Dim cmb As ComboBox = CType(sender, ComboBox)
        Select Case tblEqPaintUnitRate.CurrentCell.ColumnIndex
            Case 3 'Option
                tblEqPaintUnitRate.CurrentCell.Value = cmb.Text
        End Select
    End Sub
    Private Sub tblEqPaintUnitRate_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles tblEqPaintUnitRate.EditingControlShowing
        Dim Index = tblEqPaintUnitRate.CurrentCell.ColumnIndex
        If Index = 3 Then ' Option
            Dim typecell = tblEqPaintUnitRate.CurrentCell.GetType.ToString
            If Not typecell = "System.Windows.Forms.DataGridViewTextBoxCell" Then
                Dim cb As ComboBox = CType(e.Control, ComboBox)
                If e.Control IsNot Nothing Then
                    RemoveHandler cb.SelectedIndexChanged, AddressOf cmb_SelectedIndexChanguedEq
                    AddHandler cb.SelectedIndexChanged, AddressOf cmb_SelectedIndexChanguedEq
                End If
            End If
        End If
    End Sub
    Private Sub tblEqPaintUnitRate_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles tblEqPaintUnitRate.DataError
        If e.ColumnIndex = 3 Then
            e.ThrowException = False
        End If
    End Sub
    Private Sub tblPaintUnitRate_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles tblPpPaintUnitRate.CellClick
        Select Case e.ColumnIndex
            Case 4 'Option
                Try
                    If tblPpPaintUnitRate.CurrentCell.GetType.Name = "DataGridViewTextBoxCell" Then
                        Dim cmbOption As New DataGridViewComboBoxCell
                        With cmbOption
                            mtdFactor.llenarComboCellPntFitting(cmbOption)
                        End With
                        tblPpPaintUnitRate.CurrentRow.Cells("OptionPp") = cmbOption
                    Else
                        Dim cmbOption1 As DataGridViewComboBoxCell = tblPpPaintUnitRate.CurrentRow.Cells("OptionPp")
                        With cmbOption1
                            mtdFactor.llenarComboCellInsFitting(tblEqPaintUnitRate.CurrentRow.Cells("OptionPp"))
                        End With
                    End If
                Catch ex As Exception

                End Try
        End Select
    End Sub
    Public Sub cmb_SelectedIndexChanguedPp(sender As Object, e As EventArgs)
        Dim cmb As ComboBox = CType(sender, ComboBox)
        Select Case tblEqInsUnitRate.CurrentCell.ColumnIndex
            Case 4 'Option
                tblEqInsUnitRate.CurrentCell.Value = cmb.Text
        End Select
    End Sub
    Private Sub tblPpPaintUnitRate_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles tblPpPaintUnitRate.EditingControlShowing
        Dim Index = tblEqPaintUnitRate.CurrentCell.ColumnIndex
        If Index = 4 Then ' Option
            Dim typecell = tblEqPaintUnitRate.CurrentCell.GetType.ToString
            If Not typecell = "System.Windows.Forms.DataGridViewTextBoxCell" Then
                Dim cb As ComboBox = CType(e.Control, ComboBox)
                If e.Control IsNot Nothing Then
                    RemoveHandler cb.SelectedIndexChanged, AddressOf cmb_SelectedIndexChanguedPp
                    AddHandler cb.SelectedIndexChanged, AddressOf cmb_SelectedIndexChanguedPp
                End If
            End If
        End If
    End Sub
    Private Sub tblPpPaintUnitRate_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles tblPpPaintUnitRate.DataError
        If e.ColumnIndex = 4 Then
            e.ThrowException = False
        End If
    End Sub
    '############################################################################################################################################################################################################################################################
    '############################################################################################################################################################################################################################################################
    '############################################################################################################################################################################################################################################################
    Private Sub tblEqInsUnitRate_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles tblEqInsUnitRate.CellClick
        Select Case e.ColumnIndex
            Case 2 ' Type
                Try
                    If tblEqInsUnitRate.CurrentCell.GetType.Name = "DataGridViewTextBoxCell" Then
                        Dim cmbOption As New DataGridViewComboBoxCell
                        With cmbOption
                            mtdFactor.llenarComboCellInsFitting(cmbOption)
                        End With
                        tblEqInsUnitRate.CurrentRow.Cells("typeEQIUR") = cmbOption
                    Else
                        Dim cmbOption1 As DataGridViewComboBoxCell = tblEqInsUnitRate.CurrentRow.Cells("typeEQIUR")
                        With cmbOption1
                            mtdFactor.llenarComboCellInsFitting(tblEqInsUnitRate.CurrentRow.Cells("typeEQIUR"))
                        End With
                    End If
                Catch ex As Exception

                End Try
        End Select
    End Sub
    Public Sub cmb_SelectedIndexChanguedEqInsUR(sender As Object, e As EventArgs)
        Dim cmb As ComboBox = CType(sender, ComboBox)
        Select Case tblEqInsUnitRate.CurrentCell.ColumnIndex
            Case 2 'type
                tblEqInsUnitRate.CurrentCell.Value = cmb.Text
        End Select
    End Sub
    Private Sub tblEqInsUnitRate_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles tblEqInsUnitRate.EditingControlShowing
        Dim Index = tblEqInsUnitRate.CurrentCell.ColumnIndex
        If Index = 2 Then ' type
            Dim typecell = tblEqInsUnitRate.CurrentCell.GetType.ToString
            If Not typecell = "System.Windows.Forms.DataGridViewTextBoxCell" Then
                Dim cb As ComboBox = CType(e.Control, ComboBox)
                If e.Control IsNot Nothing Then
                    RemoveHandler cb.SelectedIndexChanged, AddressOf cmb_SelectedIndexChanguedEqInsUR
                    AddHandler cb.SelectedIndexChanged, AddressOf cmb_SelectedIndexChanguedEqInsUR
                End If
            End If
        End If
    End Sub
    Private Sub tblEqInsUnitRate_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles tblEqInsUnitRate.DataError
        If e.ColumnIndex = 2 Then
            e.ThrowException = False
        End If
    End Sub
    Private Sub tblPpInsUnitRate_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles tblPpInsUnitRate.CellClick
        Try
            Select Case e.ColumnIndex
                Case 4 ' Type
                    Try
                        If tblPpInsUnitRate.CurrentCell.GetType.Name = "DataGridViewTextBoxCell" Then
                            Dim cmbType As New DataGridViewComboBoxCell
                            With cmbType
                                mtdFactor.llenarComboCellInsFitting(cmbType)
                            End With
                            tblPpInsUnitRate.CurrentRow.Cells("typePpIUR") = cmbType
                        Else
                            Dim cmbOption2 As DataGridViewComboBoxCell = tblPpInsUnitRate.CurrentRow.Cells("typePpIUR")
                            With cmbOption2
                                mtdFactor.llenarComboCellInsFitting(tblPpInsUnitRate.CurrentRow.Cells("typePpIUR"))
                            End With
                        End If
                    Catch ex As Exception

                    End Try
            End Select
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub
    Public Sub cmb_SelectedIndexChanguedPpInsUR(sender As Object, e As EventArgs)
        Try
            Dim cmb As ComboBox = CType(sender, ComboBox)
            Select Case tblPpInsUnitRate.CurrentCell.ColumnIndex
                Case 4 'type
                    tblPpInsUnitRate.CurrentCell.Value = cmb.Text
            End Select
        Catch ex As Exception

        End Try
    End Sub
    Private Sub tblPpInsUnitRate_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles tblPpInsUnitRate.EditingControlShowing
        Try
            Dim Index = tblPpInsUnitRate.CurrentCell.ColumnIndex
            If Index = 4 Then ' Type
                Dim typecell = tblPpInsUnitRate.CurrentCell.GetType.ToString
                If Not typecell = "System.Windows.Forms.DataGridViewTextBoxCell" Then
                    Dim cb As ComboBox = CType(e.Control, ComboBox)
                    If e.Control IsNot Nothing Then
                        RemoveHandler cb.SelectedIndexChanged, AddressOf cmb_SelectedIndexChanguedPpInsUR
                        AddHandler cb.SelectedIndexChanged, AddressOf cmb_SelectedIndexChanguedPpInsUR
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Private Sub tblPpInsUnitRate_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles tblPpInsUnitRate.DataError
        If e.ColumnIndex = 4 Then
            e.ThrowException = False
        End If
    End Sub
    '############################################################################################################################################################################################################################################################
    '############################################################################################################################################################################################################################################################
    '############################################################################################################################################################################################################################################################
    Private Sub btnExcelPipingMaterial_Click(sender As Object, e As EventArgs) Handles btnExcelPipingMaterial.Click
        Try
            Dim sheetName = InputBox("Please Write the name of the Sheet to Read.", "Find Excel Sheet", "Sheet 1")
            While sheetName <> ""
                Dim tbl = leerExcel(lblMessage, pgbProgress, sheetName)
                If tbl IsNot Nothing Then
                    For Each row As Data.DataRow In tbl.Rows()
                        tblPipingMaterial.Rows.Add("", "", "", row.ItemArray(0).ToString(), row.ItemArray(1).ToString(), row.ItemArray(2).ToString(), row.ItemArray(3).ToString(), row.ItemArray(4).ToString())
                    Next
                    pgbProgress.Value = 100
                    lblMessage.Text = "Message: End."
                    Exit While
                Else
                    sheetName = InputBox("Please Write the name of the Sheet to Read." + "If do not wish to continue, leave the space blank.", "find Excel Sheet", "Sheet 1")
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
        selectTable = "PipingMaterial"
    End Sub
    Private Sub tblPipingMaterial_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles tblPipingMaterial.CellClick
        Select Case e.ColumnIndex
            Case 4 ' Type
                Try
                    If tblPipingMaterial.CurrentCell.GetType.Name = "DataGridViewTextBoxCell" Then
                        Dim cmbOption As New DataGridViewComboBoxCell
                        With cmbOption
                            mtdFactor.llenarComboCellInsFitting(cmbOption)
                        End With
                        tblPipingMaterial.CurrentRow.Cells("typeMat") = cmbOption
                    Else
                        Dim cmbOption1 As DataGridViewComboBoxCell = tblPipingMaterial.CurrentRow.Cells("typeMat")
                        With cmbOption1
                            mtdFactor.llenarComboCellInsFitting(tblPipingMaterial.CurrentRow.Cells("typeMat"))
                        End With
                    End If
                Catch ex As Exception

                End Try
        End Select
    End Sub
    Public Sub cmb_SelectedIndexChanguedPipingMat(sender As Object, e As EventArgs)
        Try
            Dim cmb As ComboBox = CType(sender, ComboBox)
            Select Case tblPipingMaterial.CurrentCell.ColumnIndex
                Case 4 'type
                    tblPipingMaterial.CurrentCell.Value = cmb.Text
            End Select
        Catch ex As Exception

        End Try
    End Sub
    Private Sub tblPipingMaterial_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles tblPipingMaterial.DataError
        If e.ColumnIndex = 4 Then
            e.ThrowException = False
        End If
    End Sub
    '############################################################################################################################################################################################################################################################
    '############################################################################################################################################################################################################################################################
    '############################################################################################################################################################################################################################################################

    Private Sub btnExcelEquipmentIRHC_Click(sender As Object, e As EventArgs) Handles btnExcelEquipmentIRHC.Click
        Try
            Dim sheetName = InputBox("Please Write the name of the Sheet to Read.", "Find Excel Sheet", "Sheet 1")
            While sheetName <> ""
                Dim tbl = leerExcel(lblMessage, pgbProgress, sheetName)
                If tbl IsNot Nothing Then
                    For Each row As Data.DataRow In tbl.Rows()
                        tblEquipmentIRHC.Rows.Add("", "", row.ItemArray(0).ToString(), row.ItemArray(1).ToString(), row.ItemArray(2).ToString(), row.ItemArray(3).ToString(), row.ItemArray(4).ToString())
                    Next
                    pgbProgress.Value = 100
                    lblMessage.Text = "Message: End."
                    Exit While
                Else
                    sheetName = InputBox("Please Write the name of the Sheet to Read." + "If do not wish to continue, leave the space blank.", "find Excel Sheet", "Sheet 1")
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
        selectTable = "EquipmentHC"
    End Sub

    Private Sub tblPipingIRHC_Enter(sender As Object, e As EventArgs) Handles tblPipingIRHC.Enter
        selectTable = "PipingIRHC"
    End Sub
    '############################################################################################################################################################################################################################################################
    '############################################################################################################################################################################################################################################################
    '############################################################################################################################################################################################################################################################

    Private Sub btnExcelPipingIRHC_Click(sender As Object, e As EventArgs) Handles btnExcelPipingIRHC.Click
        Try
            Dim sheetName = InputBox("Please Write the name of the Sheet to Read.", "Find Excel Sheet", "Sheet 1")
            While sheetName <> ""
                Dim tbl = leerExcel(lblMessage, pgbProgress, sheetName)
                If tbl IsNot Nothing Then
                    For Each row As Data.DataRow In tbl.Rows()
                        tblPipingIRHC.Rows.Add("", "", "", row.ItemArray(0).ToString(), row.ItemArray(1).ToString(), row.ItemArray(2).ToString(), row.ItemArray(3).ToString(), row.ItemArray(4).ToString(), row.ItemArray(5).ToString())
                    Next
                    pgbProgress.Value = 100
                    lblMessage.Text = "Message: End."
                    Exit While
                Else
                    sheetName = InputBox("Please Write the name of the Sheet to Read." + "If do not wish to continue, leave the space blank.", "find Excel Sheet", "Sheet 1")
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
        selectTable = "PipingIRHC"
    End Sub

    Private Sub tblEquipmentIRHC_Enter(sender As Object, e As EventArgs) Handles tblEquipmentIRHC.Enter
        selectTable = "EquipmentHC"
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        Select Case TabControl1.SelectedIndex
            Case 0
                If tblScafElevation.Rows.Count = 1 Then
                    mtdElevation.selectElevationSCF(tblScafElevation)
                End If
                If tblPaintElevation.Rows.Count = 1 Then
                    mtdElevation.selectElevationPaint(tblPaintElevation)
                End If
            Case 1
                If tblSCFUnitsRates.Rows.Count = 1 Then
                    mtdFactor.selectScafUnitsRates(tblSCFUnitsRates)
                End If

            Case 2
                If tblEnviroment.Rows.Count = 1 Then
                    mtdFactor.selectEnviroment(tblEnviroment)
                End If
            Case 3
                If tblEqInsUnitRate.Rows.Count = 1 Then
                    mtdFactor.selectEqInsUnitRate(tblEqInsUnitRate)
                End If
                If tblPpInsUnitRate.Rows.Count = 1 Then
                    mtdFactor.selectPpInsUnitRate(tblPpInsUnitRate)
                End If
            Case 4
                If tblJacketEq.Rows.Count = 1 Then
                    mtdFactor.selectEqJacketunitRate(tblJacketEq)
                End If
                If tblJacketPp.Rows.Count = 1 Then
                    mtdFactor.selectPpJacketunitRate(tblJacketPp)
                End If
            Case 5
                If tblEqPaintUnitRate.Rows.Count = 1 Then
                    mtdFactor.selectEqPntUnitRate(tblEqPaintUnitRate)
                End If
                If tblPpPaintUnitRate.Rows.Count = 1 Then
                    mtdFactor.selectPpPntUnitRate(tblPpPaintUnitRate)
                End If
            Case 6
                If tblInsFitting.Rows.Count = 1 Then
                    mtdFactor.selectInsFitting(tblInsFitting)
                End If
            Case 7
                If tblPntFitting.Rows.Count = 1 Then
                    mtdFactor.selectPntFitting(tblPntFitting)
                End If
            Case 8
                If tblEquipmentIRHC.Rows.Count = 1 Then
                    mtdFactor.selectEqIRHC(tblEquipmentIRHC)
                End If
                If tblPipingIRHC.Rows.Count = 1 Then
                    mtdFactor.selectPpIRHC(tblPipingIRHC)
                End If
            Case 9
                If tblPipingMaterial.Rows.Count = 1 Then
                    mtdFactor.selectSizesMaterialPiping(tblPipingMaterial)
                End If
            Case 10
                If tblEquipmentMaterial.Rows.Count = 1 Then
                    mtdFactor.selectSizesMaterialEquipment(tblEquipmentMaterial)
                End If
        End Select
    End Sub
End Class