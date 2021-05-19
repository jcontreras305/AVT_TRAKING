Public Class scafoldTarking
    Dim tablaEmpleados As New DataTable
    Dim mtdScaffold As New MetodosScaffold
    Dim selectedTable As String
    Dim tblMaterialStatusAux As New List(Of String)
    Private Sub scafoldTarking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'In Coming
        dtpDateInComing.Format = DateTimePickerFormat.Custom
        dtpDateInComing.CustomFormat = "MM/dd/yyyy"
        mtdScaffold.llenarEmpleadosCombo(cmbEmployeesInComing, tablaEmpleados)
        mtdScaffold.llenarJobCombo(cmbJobNumInComing)
        'Products
        mtdScaffold.llenarProduct(tblProduct)
        'Out Going
        mtdScaffold.llenarJobCombo(cmbJobNumOutGoing)
        mtdScaffold.llenarEmpleadosCombo(cmbShippedBY, tablaEmpleados)
        dtpDateOutGoing.Format = DateTimePickerFormat.Custom
        dtpDateOutGoing.CustomFormat = "MM/dd/yyyy"
        'Area/WO/Sub-Job
        mtdScaffold.llenarSubJobs(tblSubJobs)
        mtdScaffold.llenarAreas(tblAreas)
        mtdScaffold.llenarWO(tblWO)
        'UM/Class/Status
        mtdScaffold.llenarClassification(tblClassification)
        mtdScaffold.llenarMaterialStatus(tblMaterialStatus)
        For Each row As DataGridViewRow In tblMaterialStatus.Rows()
            If row.Cells(0).Value IsNot Nothing Then
                tblMaterialStatusAux.Add(row.Cells(0).Value.ToString())
            End If
        Next
        mtdScaffold.llenarRental(tblRentTable)
        mtdScaffold.llenarUnitMeassurements(tblUnitMeassurement)
        'Supervisor
        mtdScaffold.llenarSupervisor(tblSupervisor)
        'ScaffoldTraking
        tblScaffoldInformation.Rows.Add("", "", "", "", "", "", "", "")
        Dim cmbProyect As New DataGridViewComboBoxCell
        With cmbProyect
            mtdScaffold.llenarRentaTypeCombo(cmbProyect)
        End With
        tblScaffoldInformation.Rows(0).Cells(0) = cmbProyect
        tblActivityHours.Rows.Add("", "", "", "", "", "", "", "", "")

    End Sub

    Private Sub tabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabControl1.SelectedIndexChanged
        Select Case tabControl1.SelectedTab.Text
            Case "In Coming"
            Case "Out Going"
            Case "Costumers & JobsN."
            Case "Products"
            Case "Area/WO/Sub-Job"
            Case "UM/Class/Status"
            Case "Supervisor"
            Case "ScaffoldTraking"
            Case "Modification"
            Case "Estimating"
        End Select
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Select Case tabControl1.SelectedTab.Text
            Case "In Coming"
            Case "Out Going"
            Case "Costumers & JobsN."
            Case "Products"
            Case "Area/WO/Sub-Job"
                mtdScaffold.SaveAreas(tblAreas)
                mtdScaffold.SaveSubJobs(tblSubJobs)
            Case "UM/Class/Status"
                If mtdScaffold.SaveMaterialStatus(tblMaterialStatus) Then
                    tblMaterialStatusAux.Clear()
                    For Each row As DataGridViewRow In tblMaterialStatus.Rows
                        If row.Cells(0).Value IsNot Nothing Then
                            tblMaterialStatusAux.Add(row.Cells(0).Value.ToString())
                        End If
                    Next
                Else
                    mtdScaffold.llenarMaterialStatus(tblMaterialStatus)
                End If
                mtdScaffold.SaveClassification(tblClassification)
                mtdScaffold.SaveUnitMeassurement(tblUnitMeassurement)
                mtdScaffold.SaveRentalTable(tblRentTable)
            Case "Supervisor"
            Case "ScaffoldTraking"
            Case "Modification"
            Case "Estimating"
        End Select
    End Sub

    Private Sub tblAreas_Click(sender As Object, e As EventArgs) Handles tblAreas.Click
        selectedTable = tblAreas.Name
    End Sub
    Private Sub tblSubJobs_Click(sender As Object, e As EventArgs) Handles tblSubJobs.Click
        selectedTable = tblSubJobs.Name
    End Sub
    Private Sub tblWO_Click(sender As Object, e As EventArgs) Handles tblWO.Click
        selectedTable = tblWO.Name
    End Sub
    Private Sub tblMaterialStatus_Click(sender As Object, e As EventArgs) Handles tblMaterialStatus.Click
        selectedTable = tblMaterialStatus.Name
    End Sub

    Private Sub tblClassification_Click(sender As Object, e As EventArgs) Handles tblClassification.Click
        selectedTable = tblClassification.Name
    End Sub

    Private Sub tblUnitMeassurement_Click(sender As Object, e As EventArgs) Handles tblUnitMeassurement.Click
        selectedTable = tblUnitMeassurement.Name
    End Sub

    Private Sub tblRentTable_Click(sender As Object, e As EventArgs) Handles tblRentTable.Click
        selectedTable = tblRentTable.Name
    End Sub

    Private Sub btnDeleteRows_Click(sender As Object, e As EventArgs) Handles btnDeleteRows.Click
        Select Case selectedTable
            Case tblAreas.Name
                If mtdScaffold.DeleteRowsAreas(tblAreas) Then
                    For Each row As DataGridViewRow In tblAreas.SelectedRows()
                        tblAreas.Rows.Remove(row)
                    Next
                End If
            Case tblSubJobs.Name
                If mtdScaffold.DeleteRowsSubJobs(tblSubJobs) Then
                    For Each row As DataGridViewRow In tblSubJobs.SelectedRows()
                        tblSubJobs.Rows.Remove(row)
                    Next
                End If
            Case tblMaterialStatus.Name
                If mtdScaffold.DeleteRowsMaterialStatus(tblMaterialStatus) Then
                    For Each row As DataGridViewRow In tblMaterialStatus.SelectedRows
                        tblMaterialStatus.Rows.Remove(row)
                    Next
                    tblMaterialStatusAux.Clear()
                    For Each row As DataGridViewRow In tblMaterialStatus.Rows()
                        If row.Cells(0).Value IsNot Nothing Then
                            tblMaterialStatusAux.Add(row.Cells(0).Value.ToString())
                        End If
                    Next
                End If
            Case tblClassification.Name
                If mtdScaffold.DeleteRowsClassification(tblClassification) Then
                    For Each row As DataGridViewRow In tblClassification.SelectedRows()
                        tblClassification.Rows.Remove(row)
                    Next
                End If
            Case tblUnitMeassurement.Name
                If mtdScaffold.DeleteRowsUnitMeassurements(tblUnitMeassurement) Then
                    For Each row As DataGridViewRow In tblUnitMeassurement.SelectedRows()
                        tblUnitMeassurement.Rows.Remove(row)
                    Next
                End If
            Case tblRentTable.Name
                If mtdScaffold.DeleteRowsRentalTable(tblRentTable) Then
                    For Each row As DataGridViewRow In tblRentTable.SelectedRows()
                        tblRentTable.Rows.Remove(row)
                    Next
                End If
        End Select
    End Sub

    Private Sub tblMaterialStatus_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles tblMaterialStatus.CellEndEdit
        Dim index = e.RowIndex
        Try
            If (tblMaterialStatus.Rows.Count() - 1) = If(tblMaterialStatusAux Is Nothing, 0, tblMaterialStatusAux.Count()) Then
                If mtdScaffold.updateMaterialStatus(tblMaterialStatus.Rows(index).Cells(0).Value.ToString(), tblMaterialStatusAux.Item(index)) Then
                    tblMaterialStatusAux.Clear()
                    For Each row As DataGridViewRow In tblMaterialStatus.Rows()
                        If row.Cells(0).Value IsNot Nothing Then
                            tblMaterialStatusAux.Add(row.Cells(0).Value.ToString())
                        End If
                    Next
                Else
                    Dim cont As Integer = 0
                    For Each element As String In tblMaterialStatusAux
                        tblMaterialStatus.Rows(cont).Cells(0).Value = element
                    Next
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tblRentTable_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles tblRentTable.CellEndEdit
        If e.ColumnIndex = 1 Or e.ColumnIndex = 3 Or e.ColumnIndex = 4 Or e.ColumnIndex = 6 Then
            Dim val As Decimal
            Dim esCorrecto As Boolean = Decimal.TryParse(tblRentTable.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString, val)

            If (esCorrecto) Then
                tblRentTable.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = String.Format(Globalization.CultureInfo.InvariantCulture, "{0:N2}", val)
            Else
                tblRentTable.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = ""
            End If
        End If
    End Sub

    Private Sub btnDownloadExcel_Click(sender As Object, e As EventArgs) Handles btnDownloadExcel.Click
        Try
            'Dim ApExcel = New Microsoft.Office.Interop.Excel.Application
            'Dim libro1 = ApExcel.Workbooks
            'Dim hoja = libro.Add
            'hoja.Name = "Products"
            'Dim colums() As String = {"ID", "NAME", "EXISTENCES", "WEIGTH", "PWMESS", "PRICE", "DAILY RENTAL RATE", "WEEKLY RENTAL RATE", "MONTHLY RENTAL RATE", "QID", "UM", "CLASS", "STATUS"}
            'For i As Int16 = 0 To colums.Length - 1
            '    hoja.Sheets(1).cells(1, i + 1) = colums(i)
            'Next
            'Dim colums1() As String = {"UM", "NAME"}
            'Dim cont = 1
            'libro.Worksheets.Add()
            'libro.Sheets(2).cells(cont, 1) = colums(0)
            'libro.Sheets(2).cells(cont, 2) = colums(2)
            'For Each row As DataGridViewRow In tblUnitMeassurement.Rows
            '    If row.Cells(0).Value() IsNot Nothing Then
            '        cont += 1
            '        libro.Sheets(2).cells(cont, 1) = row.Cells(0).Value.ToString()
            '        libro.Sheets(2).cells(cont, 2) = row.Cells(1).Value.ToString()
            '    End If
            'Next

            'Dim colums2() As String = {"CLASS", "NAME"}
            'cont = 0
            'libro.Sheets(3).cells(cont, 1) = colums(0)
            'libro.Sheets(3).cells(cont, 2) = colums(2)
            'For Each row As DataGridViewRow In tblClassification.Rows
            '    If row.Cells(0).Value() IsNot Nothing Then
            '        cont += 1
            '        libro.Sheets(2).cells(cont, 1) = row.Cells(0).Value.ToString()
            '        libro.Sheets(2).cells(cont, 2) = row.Cells(1).Value.ToString()
            '    End If
            'Next

            'Dim colums3() As String = {"STATUS"}
            'cont = 0
            'libro.Sheets(4).cells(cont, 1) = colums(0)
            'For Each row As DataGridViewRow In tblMaterialStatus.Rows
            '    If row.Cells(0).Value() IsNot Nothing Then
            '        cont += 1
            '        libro.Sheets(2).cells(cont, 1) = row.Cells(0).Value.ToString()
            '    End If
            'Next
            'Dim sd As New SaveFileDialog
            'sd.DefaultExt = "*.xlsx"
            'sd.FileName = "ProductUploadExcel"
            'sd.Filter = "Archivos de Excel (*.xlsx)|*.xlsx"
            'sd.ShowDialog()
            'libro.SaveAs(sd.FileName)
            'NAR(libro.Sheets(1))
            'libro.Close(False)
            'NAR(libro)
            'ApExcel.Quit()
            'NAR(ApExcel)
        Catch ex As Exception
            MsgBox(ex.Message())
        Finally

        End Try

    End Sub
End Class