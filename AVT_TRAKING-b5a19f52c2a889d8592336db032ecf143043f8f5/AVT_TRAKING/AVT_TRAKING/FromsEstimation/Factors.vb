Public Class Factors
    Dim mtdElevation As New ElevationEstimation
    Dim mtdFactor As New MetodosFactor
    Dim selectTable As String
    Private Sub Factors_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mtdElevation.selectElevationSCF(tblScafElevation)
        mtdElevation.selectElevationPaint(tblPaintElevation)
        mtdFactor.selectLaborRat(tblWorkWeekScheduleLaborRates)
        mtdFactor.selectScafUnitsRates(tblSCFUnitsRates)
        mtdFactor.selectEnviroment(tblEnviroment)
        mtdFactor.selectInsFitting(tblInsFitting)
        mtdFactor.selectPntFitting(tblPntFitting)
        mtdFactor.selectEqPntUnitRate(tblEqPaintUnitRate)
        mtdFactor.selectPpPntUnitRate(tblPpPaintUnitRate)
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
    Private Sub tblOnlyDigitCell_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles tblPntFitting.CellEndEdit, tblInsFitting.CellEndEdit, tblEnviroment.CellEndEdit, tblSCFUnitsRates.CellEndEdit, tblPaintElevation.CellEndEdit, tblScafElevation.CellEndEdit, tblPpPaintUnitRate.CellEndEdit, tblEqPaintUnitRate.CellEndEdit
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
        End Select

    End Sub
    Private Sub btnFactorTbl_Click(sender As Object, e As EventArgs) Handles btnSaveFactorTbl.Click
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
                            mtdFactor.llenarComboCellPntFitting(tblEqPaintUnitRate.CurrentRow.Cells("OptionPp"))
                        End With
                    End If
                Catch ex As Exception

                End Try
        End Select
    End Sub
    Public Sub cmb_SelectedIndexChanguedPp(sender As Object, e As EventArgs)
        Dim cmb As ComboBox = CType(sender, ComboBox)
        Select Case tblEqPaintUnitRate.CurrentCell.ColumnIndex
            Case 4 'Option
                tblEqPaintUnitRate.CurrentCell.Value = cmb.Text
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
End Class