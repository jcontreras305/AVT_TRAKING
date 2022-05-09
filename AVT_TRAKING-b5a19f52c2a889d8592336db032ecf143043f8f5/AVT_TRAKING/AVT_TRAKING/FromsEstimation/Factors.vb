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
    Private Sub btnFactorTbl_Click(sender As Object, e As EventArgs) Handles btnSaveFactorTbl.Click
        Select Case selectTable
            Case "ElevationSCF"
                If tblScafElevation.SelectedRows.Count > 0 Then
                    If mtdElevation.saveUpdateElevationSCF(tblScafElevation) Then
                        mtdElevation.selectElevationSCF(tblScafElevation)
                        MsgBox("Successful.")
                    End If
                Else
                    MessageBox.Show("Please Select a row in on the Tabla Scaffold Elevation to Constinue.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If
            Case "ElevationPaint"
                If tblPaintElevation.SelectedRows.Count > 0 Then
                    If mtdElevation.saveUpdateElevationPaint(tblPaintElevation) Then
                        mtdElevation.selectElevationPaint(tblPaintElevation)
                        MsgBox("Successful.")
                    End If
                Else
                    MessageBox.Show("Please Select a row in on the Table Paint Elevation to Constinue.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If
            Case "SCFUnitsRates"
                If tblSCFUnitsRates.SelectedRows.Count > 0 Then
                    If mtdFactor.saveUpdateSCFUnitsRates(tblSCFUnitsRates) Then
                        mtdFactor.selectScafUnitsRates(tblSCFUnitsRates)
                        MsgBox("Successful.")
                    End If
                Else
                    MessageBox.Show("Please Select a row in on the Table Paint Elevation to Constinue.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If
            Case "Enviroment"
                If tblEnviroment.SelectedRows.Count > 0 Then
                    If mtdFactor.saveUpdateEnviroment(tblEnviroment) Then
                        mtdFactor.selectEnviroment(tblEnviroment)
                        MsgBox("Successful.")
                    End If
                Else
                    MessageBox.Show("Please Select a row in on the Table Paint Elevation to Constinue.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
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

    'Private Sub btnExcelScaffoldUnitRates_Click(sender As Object, e As EventArgs) Handles btnExcelScaffoldUnitRates.Click
    '    Try
    '        Dim sheetName = InputBox("Please Write the name of the Sheet to Read.", "Find Excel Sheet", "Sheet 1")
    '        While sheetName <> ""
    '            Dim tbl = leerExcel(lblMessage, pgbProgress, sheetName)
    '            If tbl IsNot Nothing Then
    '                For Each row As Data.DataRow In tbl.Rows()
    '                    tblWorkWeekScheduleLaborRates.Rows.Add("", row.ItemArray(0).ToString(), row.ItemArray(1).ToString(), row.ItemArray(2).ToString(), row.ItemArray(3).ToString(), row.ItemArray(4).ToString(), row.ItemArray(5).ToString(), row.ItemArray(6).ToString(), row.ItemArray(7).ToString(), row.ItemArray(8).ToString())
    '                Next
    '                pgbProgress.Value = 100
    '                lblMessage.Text = "Message: End."
    '                Exit While
    '            Else
    '                sheetName = InputBox("Please Write the name of the Sheet to Read." + "If do not wish to continue, leave the space blank.", "find Excel Sheet", "Sheet 1")
    '            End If
    '        End While
    '    Catch ex As Exception
    '        MsgBox(ex.Message())
    '    End Try
    '    selectTable = "LaborRate"
    'End Sub

End Class