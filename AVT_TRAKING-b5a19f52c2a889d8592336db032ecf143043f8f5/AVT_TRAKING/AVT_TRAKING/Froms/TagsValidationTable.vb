Imports Microsoft.Office.Interop.Excel
Public Class TagsValidationTable
    Dim mtdScaffold As New MetodosScaffold
    Dim tblClassification As New Data.DataTable
    Dim tblTags As New Data.DataTable


    Private Sub btnSubirExcel_Click(sender As Object, e As EventArgs) Handles btnSubirExcel.Click
        Dim ApExcel = New Microsoft.Office.Interop.Excel.Application
        Try
            Dim openFile As New OpenFileDialog
            openFile.DefaultExt = "*.xlsm"
            openFile.FileName = "tScaffolds"
            openFile.ShowDialog()

            Dim libro = ApExcel.Workbooks.Open(openFile.FileName)
            Dim scaffoldSheet As New Worksheet
            Dim flagStatus As Boolean = True
            If DialogResult.OK = MessageBox.Show("The process to read the Excel will be start." + vbCr + "Please vierifi that the name of the scaffold sheet is 'tScaffold'.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Information) Then
                Try
                    scaffoldSheet = libro.Worksheets(1)
                    lblMessage.Text = "Message: Open sheet 'Scaffold'."
                Catch ex As Exception
                    scaffoldSheet = libro.Worksheets("tScaffold")
                    lblMessage.Text = "Message: Open sheet 'tScaffold'."
                End Try
                Dim flagSC = validarSheetScaffold(scaffoldSheet)

            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        Finally
            ApExcel.Quit()
            NAR(ApExcel)
        End Try
    End Sub

    Private Function validarSheetScaffold(ByVal sheet As Worksheet) As Boolean
        Try
            lblMessage.Text = "Message: Reading Scaffold Sheet."
            Dim contSC As Integer = 2
            While sheet.Cells(contSC, 1).Text <> "" Or sheet.Cells(contSC + 1, 1).Text <> ""
                If sheet.Cells(contSC, 1).Text <> "" Then
                    tblTagsScaffold.Rows.Add("", sheet.Cells(contSC, 1).Text, sheet.Cells(contSC, 2).Text, sheet.Cells(contSC, 3).Text, sheet.Cells(contSC, 5).Text, sheet.Cells(contSC, 6).Text, sheet.Cells(contSC, 8).Text, sheet.Cells(contSC, 9).Text, sheet.Cells(contSC, 10).Text, sheet.Cells(contSC, 11).Text, sheet.Cells(contSC, 12).Text, sheet.Cells(contSC, 13).Text, sheet.Cells(contSC, 14).Text, sheet.Cells(contSC, 15).Text, sheet.Cells(contSC, 16).Text, sheet.Cells(contSC, 17).Text, If(sheet.Cells(contSC, 18).Text = "Yes", True, False), If(sheet.Cells(contSC, 19).Text = "Yes", True, False), If(sheet.Cells(contSC, 20).Text = "Yes", True, False), If(sheet.Cells(contSC, 21).Text = "Yes", True, False), If(sheet.Cells(contSC, 22).Text = "Yes", True, False), If(sheet.Cells(contSC, 23).Text = "Yes", True, False), If(sheet.Cells(contSC, 24).Text = "Yes", True, False), If(sheet.Cells(contSC, 25).Text = "Yes", True, False), If(sheet.Cells(contSC, 26).Text = "Yes", True, False), If(sheet.Cells(contSC, 27).Text = "Yes", True, False), If(sheet.Cells(contSC, 28).Text = "Yes", True, False), sheet.Cells(contSC, 30).Text, sheet.Cells(contSC, 31).Text, sheet.Cells(contSC, 32).Text, sheet.Cells(contSC, 33).Text, sheet.Cells(contSC, 34).Text, sheet.Cells(contSC, 35).Text, sheet.Cells(contSC, 36).Text, sheet.Cells(contSC, 37).Text, sheet.Cells(contSC, 38).Text, sheet.Cells(contSC, 39).Text, sheet.Cells(contSC, 40).Text, sheet.Cells(contSC, 41).Text, sheet.Cells(contSC, 42).Text, sheet.Cells(contSC, 43).Text)
                    tblTagsScaffold.Rows(tblTagsScaffold.Rows.Count() - 1).HeaderCell.Value = contSC.ToString()
                End If
                If sheet.Cells(contSC + 1, 1).Text <> "" Then
                    tblTagsScaffold.Rows.Add("", sheet.Cells(contSC + 1, 1).Text, sheet.Cells(contSC + 1, 2).Text, sheet.Cells(contSC + 1, 3).Text, sheet.Cells(contSC + 1, 5).Text, sheet.Cells(contSC + 1, 6).Text, sheet.Cells(contSC + 1, 8).Text, sheet.Cells(contSC + 1, 9).Text, sheet.Cells(contSC + 1, 10).Text, sheet.Cells(contSC + 1, 11).Text, sheet.Cells(contSC + 1, 12).Text, sheet.Cells(contSC + 1, 13).Text, sheet.Cells(contSC + 1, 14).Text, sheet.Cells(contSC + 1, 15).Text, sheet.Cells(contSC + 1, 16).Text, sheet.Cells(contSC + 1, 17).Text, If(sheet.Cells(contSC + 1, 18).Text = "Yes", True, False), If(sheet.Cells(contSC + 1, 19).Text = "Yes", True, False), If(sheet.Cells(contSC + 1, 20).Text = "Yes", True, False), If(sheet.Cells(contSC + 1, 21).Text = "Yes", True, False), If(sheet.Cells(contSC + 1, 22).Text = "Yes", True, False), If(sheet.Cells(contSC + 1, 23).Text = "Yes", True, False), If(sheet.Cells(contSC + 1, 24).Text = "Yes", True, False), If(sheet.Cells(contSC + 1, 25).Text = "Yes", True, False), If(sheet.Cells(contSC + 1, 26).Text = "Yes", True, False), If(sheet.Cells(contSC + 1, 27).Text = "Yes", True, False), If(sheet.Cells(contSC + 1, 28).Text = "Yes", True, False), sheet.Cells(contSC + 1, 30).Text, sheet.Cells(contSC + 1, 31).Text, sheet.Cells(contSC + 1, 32).Text, sheet.Cells(contSC + 1, 33).Text, sheet.Cells(contSC + 1, 34).Text, sheet.Cells(contSC + 1, 35).Text, sheet.Cells(contSC + 1, 36).Text, sheet.Cells(contSC + 1, 37).Text, sheet.Cells(contSC + 1, 38).Text, sheet.Cells(contSC + 1, 39).Text, sheet.Cells(contSC + 1, 40).Text, sheet.Cells(contSC + 1, 41).Text, sheet.Cells(contSC + 1, 42).Text, sheet.Cells(contSC + 1, 43).Text)
                    tblTagsScaffold.Rows(tblTagsScaffold.Rows.Count() - 1).HeaderCell.Value = (contSC + 1).ToString()
                End If
                contSC += 2
            End While

            For Each row As DataGridViewRow In tblTags.Rows()

            Next

            'se tiene que verificar que no existan repetidos o ya insertados

            'mtdScaffold.llenarScaffold(tblTags)
            'Dim listaTag As New List(Of scaffold)
            'Dim listRepetidos As New List(Of Integer)

            'Dim contSC As Integer = 2
            'Dim listTagV As New List(Of String)
            'While sheet.Cells(contSC, 1).Text <> ""
            '    listTagV.Add(sheet.Cells(contSC, 1).Text)
            '    contSC += 1
            'End While
            'Dim cont As Integer
            'Dim fila As Integer = 1
            'For Each rowVD1 As String In listTagV
            '    cont = 0
            '    fila += 1
            '    For Each rowVD2 As String In listTagV
            '        If rowVD1 = rowVD2 Then
            '            cont += 1
            '            If cont > 1 Then
            '                Exit For
            '            End If
            '        End If
            '    Next
            '    If cont > 1 Then
            '        sheet.Cells(fila, 1).style.Interior.Color = Color.Red
            '    End If
            'Next

            ''While sheet.Cells(contSC, 1).Text <> "" And sheet.Cells(contSC + 1, 1).Text <> ""
            '    Dim flag As Boolean = True
            '    For Each row As DataRow In tblScaffoldTags.Rows()
            '        If row.ItemArray(0) IsNot Nothing Then
            '            If sheet.Cells(contSC, 1).Text = row.ItemArray(0) Or sheet.Cells(contSC, 2).Text = row.ItemArray(1) Then
            '                flag = False
            '                Exit For
            '            Else
            '                flag = True
            '            End If
            '        End If
            '    Next
            '    If flag Then
            '        Dim newSC As New scaffold
            '        newSC.tag = sheet.Cells(contSC, 1).Text
            '        newSC.wo = sheet.Cells(contSC, 2).text
            '        listaTag.Add(newSC)
            '    Else
            '        listRepetidos.Add(contSC)
            '    End If
            '    contSC += 1
            'End While
            Return True
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        End Try
    End Function
End Class