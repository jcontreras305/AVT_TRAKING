Imports Microsoft.Office.Interop.Excel

Public Class scafoldTarking
    Dim tablaEmpleados As New Data.DataTable
    Dim mtdScaffold As New MetodosScaffold
    Dim selectedTable As String
    Dim tblMaterialStatusAux As New List(Of String)
    Dim tblProductos As New Data.DataTable
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

    Private Sub btnSaveTable_Click(sender As Object, e As EventArgs) Handles btnSaveTable.Click
        Select Case selectedTable
            Case tblAreas.Name
                If mtdScaffold.SaveAreas(tblAreas) Then
                    MsgBox("Sucessfull")
                End If
            Case tblSubJobs.Name
                If mtdScaffold.SaveSubJobs(tblSubJobs) Then
                    MsgBox("Sucessfull")
                End If
            Case tblMaterialStatus.Name
                If mtdScaffold.SaveMaterialStatus(tblMaterialStatus) Then
                    tblMaterialStatusAux.Clear()
                    For Each row As DataGridViewRow In tblMaterialStatus.Rows()
                        If row.Cells(0).Value IsNot Nothing Then
                            tblMaterialStatusAux.Add(row.Cells(0).Value.ToString())
                        End If
                    Next
                End If
            Case tblClassification.Name
                If mtdScaffold.SaveClassification(tblClassification) Then
                    MsgBox("Sucessfull")
                End If
            Case tblUnitMeassurement.Name
                If mtdScaffold.SaveUnitMeassurement(tblUnitMeassurement) Then
                    MsgBox("Sucessfull")
                End If
            Case tblRentTable.Name
                If mtdScaffold.SaveRentalTable(tblRentTable) Then
                    MsgBox("Sucessfull")
                End If
            Case tblProduct.Name
                Dim lis = mtdScaffold.saveProducto(tblProduct, True)
                If lis.Count = 0 Or lis IsNot Nothing Then
                    MsgBox("Sucessfull")
                    mtdScaffold.llenarProduct(tblProduct)
                Else
                    MsgBox("Error at line " + lis(0))
                End If
        End Select
    End Sub

    Private Sub btnSaveAll_Click(sender As Object, e As EventArgs) Handles btnSaveAll.Click
        Select Case tabControl1.SelectedTab.Text
            Case "In Coming"
            Case "Out Going"
            Case "Costumers & JobsN."
            Case "Products"
                Dim lis = mtdScaffold.saveProducto(tblProduct, True)
                If lis.Count = 0 Or lis IsNot Nothing Then
                    MsgBox("Sucessfull")
                    mtdScaffold.llenarProduct(tblProduct)
                Else
                    MsgBox("Error in Product at line  " + lis(0))
                End If
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

    Private Sub tblProduct_Click(sender As Object, e As EventArgs) Handles tblProduct.Click
        selectedTable = tblProduct.Name
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
        Dim ApExcel = New Microsoft.Office.Interop.Excel.Application
        Try

            Dim cont = 1

            Dim libro = ApExcel.Workbooks.Add
            Dim hoja = libro.Sheets.Add()

            Dim colums3() As String = {"STATUS"}
            cont = 1
            Dim hoja4 = libro.Sheets.Add()
            hoja4.Name = "status"
            hoja4.cells(cont, 1) = colums3(0)
            hoja4.cells(cont, 1).Interior.Color = RGB(255, 255, 0)
            For Each row As DataGridViewRow In tblMaterialStatus.Rows
                If row.Cells(0).Value() IsNot Nothing Then
                    cont += 1
                    hoja4.cells(cont, 1) = row.Cells(0).Value.ToString()
                End If
            Next

            Dim colums2() As String = {"CLASS", "NAME"}
            cont = 1
            Dim hoja3 = libro.Sheets.Add()
            hoja3.Name = "Class"
            hoja3.cells(cont, 1) = colums2(0)
            hoja3.cells(cont, 1).Interior.Color = RGB(255, 255, 0)
            hoja3.cells(cont, 2) = colums2(1)
            hoja3.cells(cont, 2).Interior.Color = RGB(255, 255, 0)
            For Each row As DataGridViewRow In tblClassification.Rows
                If row.Cells(0).Value() IsNot Nothing Then
                    cont += 1
                    hoja3.cells(cont, 1) = row.Cells(0).Value.ToString()
                    hoja3.cells(cont, 2) = row.Cells(1).Value.ToString()
                End If
            Next
            cont = 1
            Dim colums1() As String = {"UM", "NAME"}
            Dim hoja2 = libro.Sheets.Add()
            hoja2.Name = "Units Meassurement"
            hoja2.cells(cont, 1) = colums1(0)
            hoja2.cells(cont, 1).Interior.Color = RGB(255, 255, 0)
            hoja2.cells(cont, 2) = colums1(1)
            hoja2.cells(cont, 2).Interior.Color = RGB(255, 255, 0)
            For Each row As DataGridViewRow In tblUnitMeassurement.Rows
                If row.Cells(0).Value() IsNot Nothing Then
                    cont += 1
                    hoja2.cells(cont, 1) = row.Cells(0).Value.ToString()
                    hoja2.cells(cont, 2) = row.Cells(1).Value.ToString()
                End If
            Next

            hoja.Name = "Product"
            Dim colums() As String = {"ID", "Product Name", "UM", "Class", "Cost", "Weight", "Weight Maessure", "Daily Rental Rate", "Weekly Rental Rate", "Monthly Rental Rate", "QTY", "QID", "Status"}
            For i As Int16 = 0 To colums.Length - 1
                hoja.cells(1, i + 1) = colums(i)
                hoja.cells(1, i + 1).Interior.Color = RGB(255, 255, 0)
            Next

            Dim sd As New SaveFileDialog
            sd.DefaultExt = "*.xlsx"
            sd.FileName = "ProductUploadExcel"
            sd.Filter = "Archivos de Excel (*.xlsx)|*.xlsx"
            sd.ShowDialog()

            libro.SaveAs(sd.FileName)
            NAR(hoja)
            NAR(hoja2)
            NAR(hoja3)
            NAR(hoja4)
            NAR(libro)
        Catch ex As Exception
            MsgBox(ex.Message())
        Finally
            ApExcel.Quit()
            NAR(ApExcel)
        End Try
    End Sub

    Private Sub btnUploadProducts_Click(sender As Object, e As EventArgs) Handles btnUploadProducts.Click
        Dim ApExcel = New Microsoft.Office.Interop.Excel.Application
        Try
            Dim openFile As New OpenFileDialog
            openFile.DefaultExt = "*.xlsm"
            openFile.FileName = "ProyectosUploadExcel"
            openFile.ShowDialog()

            Dim libro = ApExcel.Workbooks.Open(openFile.FileName)
            Dim productos As New Worksheet
            Dim unidades As New Worksheet
            Dim classification As New Worksheet
            Dim status As New Worksheet
            Dim flagStatus As Boolean = True
            If DialogResult.Yes = MessageBox.Show("Would you like to check if there is any new 'Material Status'?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Information) Then
                Try
                    status = libro.Worksheets("status")
                    txtSalida.Text = txtSalida.Text + vbCrLf + "Open sheet 'status.'"
                Catch ex As Exception
                    status = libro.Worksheets("Status")
                    txtSalida.Text = txtSalida.Text + vbCrLf + "Open sheet 'Status.'"
                End Try
                flagStatus = validarSheetStatus(status)
                mtdScaffold.llenarMaterialStatus(tblMaterialStatus)
                tblMaterialStatusAux.Clear()
                For Each row As DataGridViewRow In tblMaterialStatus.Rows()
                    If row.Cells(0).Value IsNot Nothing Then
                        tblMaterialStatusAux.Add(row.Cells(0).Value.ToString())
                    End If
                Next
            End If
            If DialogResult.Yes = MessageBox.Show("Would you like to check if there is any new 'Material Classification'?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Information) Then
                Try
                    classification = libro.Worksheets("Class")
                    txtSalida.Text = txtSalida.Text + vbCrLf + "Open sheet 'Class'."
                Catch ex As Exception
                    status = libro.Worksheets("class")
                    txtSalida.Text = txtSalida.Text + vbCrLf + "Open sheet 'class'."
                End Try
                Dim flagClass = validarSheetClassification(classification)
                If flagClass Then
                    mtdScaffold.llenarClassification(tblClassification)
                End If
            End If
            If DialogResult.Yes = MessageBox.Show("Would you like to check if there is any new 'Units Meassurement'?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Information) Then
                Try
                    unidades = libro.Worksheets("Units Meassurement")
                    txtSalida.Text = txtSalida.Text + vbCrLf + "Open sheet 'Units Meassurement'."
                Catch ex As Exception
                    unidades = libro.Worksheets("Units")
                    txtSalida.Text = txtSalida.Text + vbCrLf + "Open sheet 'Units'."
                End Try
                Dim flagUnit = validarSheetUnits(unidades)
                If flagUnit Then
                    mtdScaffold.llenarUnitMeassurements(tblUnitMeassurement)
                End If
            End If
            If DialogResult.OK = MessageBox.Show("The insert the products it will being, Are you sure to continue?", "Important", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) Then
                Try
                    productos = libro.Worksheets("Product")
                    txtSalida.Text = txtSalida.Text + vbCrLf + "Open Sheet 'Product'"
                Catch ex As Exception
                    productos = libro.Worksheets("product")
                    txtSalida.Text = txtSalida.Text + vbCrLf + "Open Sheet 'product'"
                End Try
                Dim flagProduct = validarSheetProducts(productos)
                If flagProduct Then
                    mtdScaffold.llenarProduct(tblProduct)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        Finally
            ApExcel.Quit()
            NAR(ApExcel)
        End Try
    End Sub

    Private Function validarSheetStatus(ByVal status As Worksheet) As Boolean
        Dim contStatus = 2
        Dim listAuxStatus As New List(Of String)
        txtSalida.Text = txtSalida.Text + vbCrLf + "Reading Data."
        While status.Cells(contStatus, 1).Text <> ""
            Dim flag As Boolean = True
            For Each datoA As String In tblMaterialStatusAux
                If status.Cells(contStatus, 1).Text = datoA Then
                    flag = False
                    Exit For
                Else
                    flag = True
                End If
            Next
            If flag Then
                listAuxStatus.Add(status.Cells(contStatus, 1).Text)
            End If
            contStatus += 1
        End While
        txtSalida.Text = txtSalida.Text + vbCrLf + "The 'Material Status' insertion process is Started."
        If listAuxStatus.Count > 0 Then
            If DialogResult.Yes = MessageBox.Show("There are " + listAuxStatus.Count().ToString() + " new 'Materials Status' Would you like to insert them?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                Dim fila = mtdScaffold.SaveMaterialStatus(listAuxStatus)
                If fila > 0 Then
                    txtSalida.Text = txtSalida.Text + vbCrLf + "Error '" + fila + "'."
                    Return False
                Else
                    txtSalida.Text = txtSalida.Text + vbCrLf + "The 'Material Status' insertion process is complete."
                    Return True
                End If
            Else
                Return True
            End If
        Else
            Return True
        End If
    End Function

    Private Function validarSheetClassification(ByVal sheet As Worksheet) As Boolean
        Dim contClass = 2
        Dim listAuxClass As New Data.DataTable
        listAuxClass.Columns.Add("Class")
        listAuxClass.Columns.Add("Name")
        Dim GridClass = tblClassification
        mtdScaffold.llenarClassification(GridClass)
        txtSalida.Text = txtSalida.Text + vbCrLf + "Reading Data."
        While sheet.Cells(contClass, 1).Text <> ""
            Dim flag As Boolean = True
            For Each row As DataGridViewRow In GridClass.Rows()
                If row.Cells("Class").Value IsNot Nothing Then
                    If sheet.Cells(contClass, 1).Text = row.Cells("Class").Value.ToString() Or sheet.Cells(contClass, 2).Text = row.Cells("Name").Value.ToString() Then
                        flag = False
                        Exit For
                    Else
                        flag = True
                    End If
                End If
            Next
            If flag Then
                listAuxClass.Rows.Add(sheet.Cells(contClass, 1).Text, sheet.Cells(contClass, 2).Text)
            End If
            contClass += 1
        End While
        txtSalida.Text = txtSalida.Text + vbCrLf + "The 'Material Classification' insertion process is Started."
        If listAuxClass.Rows.Count() > 0 Then
            If DialogResult.Yes = MessageBox.Show("There are " + listAuxClass.Rows.Count().ToString() + " new 'Materials Classification' Would you like to insert them?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                Dim fila = mtdScaffold.SaveClassification(listAuxClass)
                If fila > 0 Then
                    txtSalida.Text = txtSalida.Text + vbCrLf + "Error '" + fila + "'."
                    Return False
                Else
                    txtSalida.Text = txtSalida.Text + vbCrLf + "The 'Material Classification' insertion process is complete."
                    Return True
                End If
            Else
                Return True
            End If
        Else
            Return True
        End If
    End Function

    Private Function validarSheetUnits(ByVal sheet As Worksheet) As Boolean
        Dim contClass = 2
        Dim listAuxUnits As New Data.DataTable
        listAuxUnits.Columns.Add("Unit")
        listAuxUnits.Columns.Add("Name")
        Dim GridUnits = tblClassification
        mtdScaffold.llenarUnitMeassurements(GridUnits)
        txtSalida.Text = txtSalida.Text + vbCrLf + "Reading Data."
        While sheet.Cells(contClass, 1).Text <> ""
            Dim flag As Boolean = True
            For Each row As DataGridViewRow In GridUnits.Rows()
                If row.Cells("Unit").Value IsNot Nothing Then
                    If sheet.Cells(contClass, 1).Text = row.Cells("Unit").Value.ToString() Or sheet.Cells(contClass, 2).Text = row.Cells("Name").Value.ToString() Then
                        flag = False
                        Exit For
                    Else
                        flag = True
                    End If
                End If
            Next
            If flag Then
                listAuxUnits.Rows.Add(sheet.Cells(contClass, 1).Text, sheet.Cells(contClass, 2).Text)
            End If
            contClass += 1
        End While
        txtSalida.Text = txtSalida.Text + vbCrLf + "The 'Units Meassurement' insertion process is Started."
        If listAuxUnits.Rows.Count() > 0 Then
            If DialogResult.Yes = MessageBox.Show("There are " + listAuxUnits.Rows.Count().ToString() + " new 'Units Meassurement' Would you like to insert them?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                Dim fila = mtdScaffold.SaveUnitMeassurement(listAuxUnits)
                If fila > 0 Then
                    txtSalida.Text = txtSalida.Text + vbCrLf + "Error '" + fila + "'."
                    Return False
                Else
                    txtSalida.Text = txtSalida.Text + vbCrLf + "The 'Units Meassurement' insertion process is complete."
                    Return True
                End If
            Else
                Return True
            End If
        Else
            Return True
        End If
    End Function

    Private Function validarSheetProducts(ByVal sheet As Worksheet) As Boolean
        Dim contProduct = 2
        Dim listAuxPruduct As New Data.DataTable
        listAuxPruduct.Columns.Add("ID")
        listAuxPruduct.Columns.Add("Product Name")
        listAuxPruduct.Columns.Add("UM")
        listAuxPruduct.Columns.Add("Class")
        listAuxPruduct.Columns.Add("Cost")
        listAuxPruduct.Columns.Add("Weight")
        listAuxPruduct.Columns.Add("Weight Mesure")
        listAuxPruduct.Columns.Add("$UM")
        listAuxPruduct.Columns.Add("Daily Rental Rate")
        listAuxPruduct.Columns.Add("Weekly Rental Rate")
        listAuxPruduct.Columns.Add("Mountly Rental Rate")
        listAuxPruduct.Columns.Add("QTY")
        listAuxPruduct.Columns.Add("QID")
        Dim GridProduct = tblProduct
        mtdScaffold.llenarProduct(GridProduct)
        txtSalida.Text = txtSalida.Text + vbCrLf + "Reading Data."
        While sheet.Cells(contProduct, 1).Text <> ""
            Dim flag As Boolean = True
            For Each row As DataGridViewRow In GridProduct.Rows()
                If row.Cells("ID").Value IsNot Nothing Then
                    If sheet.Cells(contProduct, 1).Text = row.Cells("ID").Value.ToString() Or sheet.Cells(contProduct, 2).Text = row.Cells("Product Name").Value.ToString() Then
                        flag = False
                        Exit For
                    Else
                        flag = True
                    End If
                End If
            Next
            If flag Then
                listAuxPruduct.Rows.Add(sheet.Cells(contProduct, 1).Text, sheet.Cells(contProduct, 2).Text, sheet.Cells(contProduct, 3).Text, sheet.Cells(contProduct, 4).Text, sheet.Cells(contProduct, 5).Text, sheet.Cells(contProduct, 6).Text, sheet.Cells(contProduct, 7).Text, sheet.Cells(contProduct, 8).Text, sheet.Cells(contProduct, 9).Text, sheet.Cells(contProduct, 10).Text, sheet.Cells(contProduct, 11).Text, sheet.Cells(contProduct, 12).Text, sheet.Cells(contProduct, 13).Text)
            End If
            contProduct += 1
        End While
        txtSalida.Text = txtSalida.Text + vbCrLf + "The 'Products' insertion process is Started."
        If DialogResult.Yes = MessageBox.Show(listAuxPruduct.Rows.Count.ToString() + " new 'Products' were found, Would you like to insert them?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
            Dim fila = mtdScaffold.saveProduct(listAuxPruduct)
            If fila.Count() > 0 Then
                Dim filasString As String = ""
                For Each dato As Integer In fila
                    filasString = filasString & ", " & dato.ToString()
                Next
                txtSalida.Text = txtSalida.Text + vbCrLf + "Error '" + filasString + "'."
                Return False
            Else
                txtSalida.Text = txtSalida.Text + vbCrLf + "The 'Product' insertion process is complete."
                Return True
            End If
        Else
            Return True
        End If
        Return True
    End Function

    Private Sub tblProduct_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles tblProduct.CellClick
        If e.ColumnIndex >= 0 Then
            Select Case tblProduct.Columns(e.ColumnIndex).Name
                Case "UM"
                    Try
                        If tblProduct.CurrentCell.GetType.Name = "DataGridViewTextBoxCell" Then
                            Dim cmbUM As New DataGridViewComboBoxCell
                            With cmbUM
                                mtdScaffold.llenarCellComboUM(cmbUM)
                            End With
                            If tblProduct.CurrentRow.Cells("UM").Value.ToString() <> "" Then
                                cmbUM.Value = tblProduct.CurrentRow.Cells("UM").Value
                            End If
                            tblProduct.CurrentRow.Cells("UM") = cmbUM
                        End If
                    Catch ex As Exception

                    End Try
                Case "Class"
                    Try
                        If tblProduct.CurrentCell.GetType.Name = "DataGridViewTextBoxCell" Then
                            Dim cmbClass As New DataGridViewComboBoxCell
                            With cmbClass
                                mtdScaffold.llenarCellComboClass(cmbClass)
                            End With

                            If tblProduct.CurrentRow.Cells("Class").Value.ToString() <> "" Then
                                cmbClass.Value = tblProduct.CurrentRow.Cells("Class").Value
                            End If
                            tblProduct.CurrentRow.Cells("Class") = cmbClass
                        End If
                    Catch ex As Exception

                    End Try
                Case "Status"
                    Try
                        If tblProduct.CurrentCell.GetType.Name = "DataGridViewTextBoxCell" Then
                            Dim cmbStatus As New DataGridViewComboBoxCell
                            With cmbStatus
                                If tblProduct.CurrentRow.Cells("idExitenciaProduct").Value IsNot DBNull.Value Then
                                    mtdScaffold.llenarCellComboStatus(cmbStatus, tblProduct.CurrentRow.Cells(0).Value)
                                Else
                                    mtdScaffold.llenarCellComboStatus(cmbStatus, "")
                                End If
                            End With
                            If tblProduct.CurrentRow.Cells("Status").Value.ToString() <> "" Then
                                cmbStatus.Value = tblProduct.CurrentRow.Cells("Status").Value
                            End If
                            tblProduct.CurrentRow.Cells("Status") = cmbStatus
                        End If
                    Catch ex As Exception

                    End Try
            End Select
        End If
    End Sub

    Public Sub cmb_SelectedIndexChangued(sender As Object, e As EventArgs)
        Dim cmb As ComboBox = CType(sender, ComboBox)
        If tblProduct.CurrentCell.ColumnIndex = tblProduct.Columns("UM").Index Then
            If tblProduct.CurrentCell.Value <> cmb.SelectedItem Then
                tblProduct.CurrentCell.Value = If(cmb.SelectedItem IsNot Nothing, cmb.SelectedItem, "")
            End If
        ElseIf tblProduct.CurrentCell.ColumnIndex = tblProduct.Columns("Class").Index Then
            If tblProduct.CurrentCell.Value <> cmb.SelectedItem Then
                tblProduct.CurrentCell.Value = If(cmb.SelectedItem IsNot Nothing, cmb.SelectedItem, "")
            End If
        ElseIf tblProduct.CurrentCell.ColumnIndex = tblProduct.Columns("Status").Index Then
            If tblProduct.CurrentCell.Value.ToString() <> cmb.SelectedItem Then
                tblProduct.CurrentCell.Value = If(cmb.SelectedItem IsNot Nothing, cmb.SelectedItem, "")
                Dim list = mtdScaffold.BuscarExistenciasPorStatus(tblProduct.CurrentRow.Cells(0).Value.ToString(), If(cmb.SelectedItem IsNot "", cmb.SelectedItem, ""))
                tblProduct.CurrentRow.Cells("QTY").Value = list(2)
                tblProduct.CurrentRow.Cells("idExitenciaProduct").Value = list(0)
            End If
        End If
    End Sub

    Private Sub tblProduct_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles tblProduct.EditingControlShowing
        Dim Index = tblProduct.CurrentCell.ColumnIndex
        If Index = 2 Or Index = 3 Or Index = 13 Then
            If tblProduct.CurrentCell.GetType.Name = "DataGridViewComboBoxCell" Then
                Dim cb As ComboBox = CType(e.Control, ComboBox)
                If e.Control IsNot Nothing Then
                    RemoveHandler cb.SelectedIndexChanged, AddressOf cmb_SelectedIndexChangued
                    AddHandler cb.SelectedIndexChanged, AddressOf cmb_SelectedIndexChangued
                End If
            End If
        End If
    End Sub

    Private Sub tblProduct_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles tblProduct.CellEndEdit
        If e.ColumnIndex = 0 Then
            Dim id = tblProduct.CurrentCell.Value.ToString()
            If id <> "" Then
                For Each row As DataGridViewRow In tblProduct.Rows()
                    If id = row.Cells("ID").Value.ToString() Then
                        tblProduct.CurrentRow.Cells("Product Name").Value = row.Cells("Product Name").Value
                        tblProduct.CurrentRow.Cells("UM").Value = row.Cells("UM").Value
                        tblProduct.CurrentRow.Cells("Class").Value = row.Cells("Class").Value
                        tblProduct.CurrentRow.Cells("Cost").Value = row.Cells("Cost").Value
                        tblProduct.CurrentRow.Cells("Weight").Value = row.Cells("Weight").Value
                        tblProduct.CurrentRow.Cells("Weight Measure").Value = row.Cells("Weight Measure").Value
                        tblProduct.CurrentRow.Cells("$UM").Value = row.Cells("$UM").Value
                        tblProduct.CurrentRow.Cells("Daily Rental Rate").Value = row.Cells("Daily Rental Rate").Value
                        tblProduct.CurrentRow.Cells("Weekly Rental Rate").Value = row.Cells("Weekly Rental Rate").Value
                        tblProduct.CurrentRow.Cells("Monthly Rental Rate").Value = row.Cells("Monthly Rental Rate").Value
                        tblProduct.CurrentRow.Cells("QTY").Value = row.Cells("QTY").Value
                        tblProduct.CurrentRow.Cells("QID").Value = row.Cells("QID").Value
                        tblProduct.CurrentRow.Cells("Status").Value = ""
                        Exit For
                    End If
                Next
            End If

        End If
    End Sub

    Private Sub txtCategory_TextChanged(sender As Object, e As EventArgs) Handles txtCategory.TextChanged
        Dim flag = mtdScaffold.llenarProduct(tblProduct, txtCategory.Text, False)
        If flag = False Then
            mtdScaffold.llenarProduct(tblProduct)
        End If
    End Sub

    Private Sub txtIDProduct_TextChanged(sender As Object, e As EventArgs) Handles txtIDProduct.TextChanged
        Dim flag = mtdScaffold.llenarProduct(tblProduct, txtIDProduct.Text, True)
        If flag = False Then
            mtdScaffold.llenarProduct(tblProduct)
        End If
    End Sub

    Private Sub btnSaveRowProduct_Click(sender As Object, e As EventArgs) Handles btnSaveRowProduct.Click
        If tblProduct.SelectedRows().Count > 0 Then
            Dim lis = mtdScaffold.saveProducto(tblProduct, True)
            If lis.Count = 0 Or lis IsNot Nothing Then
                MsgBox("Sucessfull")
                mtdScaffold.llenarProduct(tblProduct)
            Else
                MsgBox("Error at line " + lis(0))
            End If
        Else
            MsgBox("Please Select A Row.")
        End If
    End Sub


End Class