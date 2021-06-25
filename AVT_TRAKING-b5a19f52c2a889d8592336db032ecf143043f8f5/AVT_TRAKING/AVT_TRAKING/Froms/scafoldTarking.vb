Imports Microsoft.Office.Interop.Excel

Public Class scafoldTarking
    Dim tablaEmpleados As New Data.DataTable
    Dim tblProductInComing As New Data.DataTable
    Dim tblTicketInComing As New Data.DataTable
    Dim tblProductOutGoing As New Data.DataTable
    Dim tblTicketOutGoing As New Data.DataTable
    Dim tblArea As New Data.DataTable 'se utiliza para buscar despues de ser seleccionado el combo y encontrar al insertar o actualizar
    Dim tblCat As New Data.DataTable 'se utiliza para buscar despues de ser seleccionado el combo y encontrar al insertar o actualizar
    Dim tblWOTASK As New Data.DataTable 'se utiliza para buscar despues de ser seleccionado el combo y encontrar al insertar o actualizar
    Dim tblSubJob As New Data.DataTable 'se utiliza para buscar despues de ser seleccionado el combo y encontrar al insertar o actualizar
    Dim tblProductScaffoldAux As New Data.DataTable 'se utiliza para buscar despues de ser seleccionado el combo y encontrar al insertar o actualizar
    Dim mtdScaffold As New MetodosScaffold
    Dim selectedTable As String
    Dim tblMaterialStatusAux As New List(Of String)
    Dim tblProductosAux As New Data.DataTable
    Dim tblScaffoldTags As New Data.DataTable
    Dim sc As New scaffold
    Dim loadingData As Boolean
    Private Sub scafoldTarking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'In Coming
        dtpDateInComing.Format = DateTimePickerFormat.Custom
        dtpDateInComing.CustomFormat = "MM/dd/yyyy"
        mtdScaffold.llenarEmpleadosCombo(cmbEmployeesInComing, tablaEmpleados)
        mtdScaffold.llenarJobCombo(cmbJobNumInComing)
        Dim datosIncoming As List(Of String) = mtdScaffold.llenarInComming(tblInComing, tblTicketInComing)
        If datosIncoming.Count <> 0 Then
            txtTicketNumInComing.Text = datosIncoming(0)
            dtpDateInComing.Value = validarFechaParaVB(datosIncoming(1))
            cmbEmployeesInComing.Text = datosIncoming(2)
            txtCommentsInComing.Text = datosIncoming(3)
            cmbJobNumInComing.Text = datosIncoming(4)
            txtTicketNumInComing.Enabled = False
        End If
        'Products
        mtdScaffold.llenarProduct(tblProduct)
        mtdScaffold.llenarProduct(tblProductosAux)
        'Out Going
        mtdScaffold.llenarJobCombo(cmbJobNumOutGoing)
        mtdScaffold.llenarEmpleadosCombo(cmbShippedBY, tablaEmpleados)
        mtdScaffold.llenarEmpleadosCombo(cmbSuperintendent, tablaEmpleados)
        dtpDateOutGoing.Format = DateTimePickerFormat.Custom
        dtpDateOutGoing.CustomFormat = "MM/dd/yyyy"
        Dim datosOutGoing As List(Of String) = mtdScaffold.llenarOutGoing(tblOutGoing, tblTicketOutGoing)
        If datosOutGoing.Count > 0 Then
            txtTicketNumOutGoing.Text = datosOutGoing(0)
            dtpDateOutGoing.Value = validarFechaParaVB(datosOutGoing(1))
            txtCommentOut.Text = datosOutGoing(2)
            cmbShippedBY.Text = datosOutGoing(3)
            cmbSuperintendent.Text = datosOutGoing(4)
            cmbJobNumOutGoing.Text = datosOutGoing(5)
            txtTicketNumOutGoing.Enabled = False
        End If
        'Area/WO/Sub-Job/JobCat
        mtdScaffold.llenarSubJobs(tblSubJobs)
        mtdScaffold.llenarAreas(tblAreas)
        mtdScaffold.llenarWO(tblWO)
        mtdScaffold.llenarJobCat(tblJobCat)
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
        dtpReqCompScaffold.Format = DateTimePickerFormat.Custom
        dtpReqCompScaffold.CustomFormat = "MM/dd/yyyy"
        dtpBldDate.Format = DateTimePickerFormat.Custom
        dtpBldDate.CustomFormat = "MM/dd/yyyy"
        tblArea = mtdScaffold.llenarComboArea(cmbAreaID)
        tblCat = mtdScaffold.llenarComboJobCat(cmbJobCAT)
        tblWOTASK = mtdScaffold.llenarComboWO(cmbWONum)
        tblSubJob = mtdScaffold.llenarComboSubJob(cmbSubJob)
        mtdScaffold.llenarEmpleadosCombo(cmbForemanScaffold, tablaEmpleados)
        mtdScaffold.llenarEmpleadosCombo(cmbErectorScaffold, tablaEmpleados)
        tblScaffoldInformation.Rows.Add("", "", "", "", "", "", "", "")
        Dim cmbProyect As New DataGridViewComboBoxCell
        With cmbProyect
            mtdScaffold.llenarRentaTypeCombo(cmbProyect)
        End With
        tblScaffoldInformation.Rows(0).Cells(0) = cmbProyect
        tblActivityHours.Rows.Add("", "", "", "", "", "", "", "", "")
        tblActivityHours.Rows(0).Cells("clmTotal").ReadOnly = True
        tblActivityHours.Rows(0).Cells("clmTotal").Style.BackColor = Color.Green
        If mtdScaffold.llenarScaffold(tblScaffoldTags) Then
            If tblScaffoldTags.Rows.Count > 0 Then
                cargarDatosScaffold(tblScaffoldTags.Rows(0).ItemArray(0).ToString())
            End If
        End If
        btnDeleteRowScaffoldLeg.Enabled = False
    End Sub

    Private Sub tabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabControl1.SelectedIndexChanged
        Select Case tabControl1.SelectedTab.Text
            Case "In Coming"
                selectedTable = tblInComing.Name()
            Case "Out Going"
                selectedTable = tblOutGoing.Name()
            Case "Costumers & JobsN."
            Case "Products"
            Case "Area/WO/Sub-Job"
            Case "UM/Class/Status"
            Case "Supervisor"
            Case "ScaffoldTraking"
                selectedTable = "tag"
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
            Case tblJobCat.Name
                If mtdScaffold.SaveJobCat(tblJobCat) Then
                    MsgBox("Sucessfull")
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
                    mtdScaffold.llenarProduct(tblProductosAux)
                Else
                    MsgBox("Error at line " + lis(0))
                End If
            Case tblInComing.Name
                Dim list As New List(Of String)
                If cmbJobNumInComing.SelectedItem IsNot Nothing And txtTicketNumInComing.Text <> "" Then
                    list.Add(txtTicketNumInComing.Text)
                    list.Add(validaFechaParaSQl(dtpDateInComing.Value))
                    list.Add(cmbEmployeesInComing.Text)
                    list.Add(txtCommentsInComing.Text)
                    list.Add(cmbJobNumInComing.SelectedItem)
                ElseIf cmbJobNumInComing.SelectedItem Is Nothing Then
                    MessageBox.Show("The Job Number is not selected, Please choose one and try again.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ElseIf txtTicketNumInComing.Text <> "" Then
                    MessageBox.Show("The Ticket Number is not correct.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                If list.Count > 0 Then
                    If mtdScaffold.saveInComing(tblInComing, list, True) Then
                        MsgBox("Successful")
                        mtdScaffold.llenarProduct(tblProduct)
                        mtdScaffold.llenarTicketsIncoming(tblTicketInComing)
                    End If
                End If
            Case tblOutGoing.Name
                Dim list As New List(Of String)
                If cmbJobNumOutGoing.SelectedItem IsNot Nothing And txtTicketNumOutGoing.Text <> "" Then
                    list.Add(txtTicketNumOutGoing.Text)
                    list.Add(validaFechaParaSQl(dtpDateOutGoing.Value))
                    list.Add(txtCommentOut.Text)
                    list.Add(cmbShippedBY.Text)
                    list.Add(cmbSuperintendent.Text)
                    list.Add(cmbJobNumOutGoing.SelectedItem)
                ElseIf cmbJobNumInComing.SelectedItem Is Nothing Then
                    MessageBox.Show("The Job Number is not selected, Please choose one and try again.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ElseIf txtTicketNumInComing.Text <> "" Then
                    MessageBox.Show("The Ticket Number is not correct.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                If list.Count > 0 Then
                    If mtdScaffold.saveOutGoing(tblOutGoing, list, True) Then
                        MsgBox("Successful")
                        mtdScaffold.llenarProduct(tblProduct)
                        mtdScaffold.llenarTicketsOutGoing(tblTicketOutGoing)
                    End If
                End If
            Case "tag"
                If mtdScaffold.saveScaffoldTraking(sc) Then
                    MsgBox("Successfull")
                End If
            Case tblProductosScaffold.Name
                If mtdScaffold.saveScaffoldTraking(sc) Then
                    MsgBox("Successfull")
                End If
            Case tblLeg.Name
                If mtdScaffold.saveScaffoldTraking(sc) Then
                    MsgBox("Successfull")
                End If
        End Select
    End Sub

    Private Sub btnSaveAll_Click(sender As Object, e As EventArgs) Handles btnSaveAll.Click
        Select Case tabControl1.SelectedTab.Text
            Case "In Coming"
                Dim list As New List(Of String)
                If cmbJobNumInComing.SelectedItem IsNot Nothing And txtTicketNumInComing.Text <> "" Then
                    list.Add(txtTicketNumInComing.Text)
                    list.Add(validaFechaParaSQl(dtpDateInComing.Value))
                    list.Add(cmbEmployeesInComing.Text)
                    list.Add(txtCommentOut.Text)
                    list.Add(cmbJobNumInComing.SelectedItem)
                ElseIf cmbJobNumInComing.SelectedItem Is Nothing Then
                    MessageBox.Show("The Job Number is not selected, Please choose one and try again.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ElseIf txtTicketNumInComing.Text <> "" Then
                    MessageBox.Show("The Ticket Number is not correct.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                If list.Count > 0 Then
                    If mtdScaffold.saveInComing(tblInComing, list, True) Then
                        'MsgBox("Successful")
                        mtdScaffold.llenarProduct(tblProduct)
                        mtdScaffold.llenarTicketsIncoming(tblTicketInComing)
                    End If
                End If
            Case "Out Going"
                Dim list As New List(Of String)
                If cmbJobNumOutGoing.SelectedItem IsNot Nothing And txtTicketNumOutGoing.Text <> "" Then
                    list.Add(txtTicketNumOutGoing.Text)
                    list.Add(validaFechaParaSQl(dtpDateOutGoing.Value))
                    list.Add(txtCommentOut.Text)
                    list.Add(cmbShippedBY.Text)
                    list.Add(cmbSuperintendent.Text)
                    list.Add(cmbJobNumOutGoing.SelectedItem)
                ElseIf cmbJobNumInComing.SelectedItem Is Nothing Then
                    MessageBox.Show("The Job Number is not selected, Please choose one and try again.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ElseIf txtTicketNumInComing.Text <> "" Then
                    MessageBox.Show("The Ticket Number is not correct.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                If list.Count > 0 Then
                    If mtdScaffold.saveOutGoing(tblOutGoing, list, True) Then
                        mtdScaffold.llenarProduct(tblProduct)
                        mtdScaffold.llenarTicketsOutGoing(tblTicketOutGoing)
                    End If
                End If
            Case "Costumers & JobsN."
            Case "Products"
                Dim lis = mtdScaffold.saveProducto(tblProduct, True)
                If lis.Count = 0 Or lis IsNot Nothing Then
                    'MsgBox("Products Sucessfull")
                    mtdScaffold.llenarProduct(tblProduct)
                    mtdScaffold.llenarProduct(tblProductosAux)
                Else
                    MsgBox("Error in Product at line  " + lis(0))
                End If
            Case "Area/WO/Sub-Job"
                mtdScaffold.SaveAreas(tblAreas)
                mtdScaffold.SaveSubJobs(tblSubJobs)
                mtdScaffold.SaveJobCat(tblJobCat)
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
                If mtdScaffold.saveScaffoldTraking(sc) Then
                    If mtdScaffold.llenarScaffold(tblProductScaffoldAux) Then
                        For Each row As DataRow In tblProductosAux.Rows()
                            If row.ItemArray(0) = sc.tag Then
                                sc = mtdScaffold.llenarScaffold(tblProductosAux.Rows(0).ItemArray(0))
                            End If
                        Next
                    End If
                End If
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

    Private Sub tblJobCat_Click(sender As Object, e As EventArgs) Handles tblJobCat.Click
        selectedTable = tblJobCat.Name
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

    Private Sub tblInComing_Click(sender As Object, e As EventArgs) Handles tblInComing.Click
        selectedTable = tblInComing.Name
    End Sub

    Private Sub tblOutGoing_Click(sender As Object, e As EventArgs) Handles tblOutGoing.Click
        selectedTable = tblOutGoing.Name
    End Sub

    Private Sub tblLeg_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles tblLeg.CellClick
        selectedTable = tblLeg.Name
        btnDeleteRowScaffoldLeg.Enabled = True
    End Sub
    Private Sub tblLeg_Leave(sender As Object, e As EventArgs) Handles tblLeg.Leave
        If Not btnDeleteRowScaffoldLeg.Focused Then
            btnDeleteRowScaffoldLeg.Enabled = False
        End If

    End Sub
    Private Sub tblProductosScaffold_Leave(sender As Object, e As EventArgs) Handles tblProductosScaffold.Leave
        If Not btnDeleteRowScaffoldLeg.Focused Then
            btnDeleteRowScaffoldLeg.Enabled = False
        End If
    End Sub
    Private Sub tblProductosScaffold_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles tblProductosScaffold.CellClick
        selectedTable = tblProductosScaffold.Name
        btnDeleteRowScaffoldLeg.Enabled = True
        If e.ColumnIndex = 1 Then
            Try
                If tblProductosScaffold.CurrentCell.GetType.Name = "DataGridViewTextBoxCell" Then
                    Dim cmbPd As New DataGridViewComboBoxCell
                    With cmbPd
                        mtdScaffold.llenarCellComboIDProduct(cmbPd, tblProductScaffoldAux)
                    End With
                    If tblProductosScaffold.CurrentRow.Cells(1).Value IsNot Nothing Then
                        For Each row As Data.DataRow In tblProductScaffoldAux.Rows()
                            If row.ItemArray(1) = tblProductosScaffold.CurrentRow.Cells(1).Value Then
                                cmbPd.Value = row.ItemArray(0)
                            End If
                        Next
                    End If
                    tblProductosScaffold.CurrentRow.Cells(1) = cmbPd
                End If
            Catch ex As Exception

            End Try
        End If
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
            Case tblJobCat.Name
                If mtdScaffold.DeleteRowsJobCat(tblJobCat) Then
                    For Each row As DataGridViewRow In tblJobCat.SelectedRows()
                        tblJobCat.Rows.Remove(row)
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
            Case tblProduct.Name
                If DialogResult.Yes = MessageBox.Show("The products are likely to be related to some records and it will NOT be possible to delete them. Would you like to continue?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) Then
                    If (mtdScaffold.DeleteRowsProducto(tblProduct, True)) Then
                        mtdScaffold.llenarProduct(tblProduct)
                        mtdScaffold.llenarProduct(tblProductosAux)
                    End If
                End If
            Case tblInComing.Name
                If DialogResult.Yes = MessageBox.Show("The products are likely to be related to some records and it will NOT be possible to delete them. Would you like to continue?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) Then
                    If mtdScaffold.DeleteInComing(tblInComing) Then
                        For Each row As DataGridViewRow In tblInComing.SelectedRows()
                            tblInComing.Rows.Remove(row)
                        Next
                    End If
                End If
            Case tblOutGoing.Name
                If DialogResult.Yes = MessageBox.Show("The products are likely to be related to some records and it will NOT be possible to delete them. Would you like to continue?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) Then
                    If mtdScaffold.DeleteOutGoing(tblOutGoing) Then
                        For Each row As DataGridViewRow In tblOutGoing.SelectedRows()
                            tblOutGoing.Rows.Remove(row)
                        Next
                    End If
                End If
            Case tblProductosScaffold.Name
            Case tblLeg.Name
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

            Dim hoja = libro.Sheets.Add()
            hoja.Name = "Product"
            Dim colums() As String = {"ID", "Product Name", "UM", "Class", "Cost", "Weight", "Weight Maessure", "Daily Rental Rate", "Weekly Rental Rate", "Monthly Rental Rate", "QTY", "QID"}
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
            Dim flagStatus As Boolean = True
            If DialogResult.Yes = MessageBox.Show("Would you like to check if there is any new 'Material Classification'?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Information) Then
                Try
                    classification = libro.Worksheets("Class")
                    txtSalida.Text = txtSalida.Text + vbCrLf + "Open sheet 'Class'."
                Catch ex As Exception
                    classification = libro.Worksheets("class")
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
                    mtdScaffold.llenarProduct(tblProductosAux)
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
                If row.Cells("Material").Value IsNot Nothing Then
                    If sheet.Cells(contClass, 1).Text = row.Cells("Material").Value.ToString() Or sheet.Cells(contClass, 2).Text = row.Cells("Name").Value.ToString() Then
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

    Public Sub cmb_SelectedIndexChanguedInComming(sender As Object, e As EventArgs)
        Dim cmb As ComboBox = CType(sender, ComboBox)
        Dim flag As Boolean = True
        For Each row As DataGridViewRow In tblInComing.Rows()
            If row.Index <> tblInComing.CurrentCell.RowIndex And row.Index < tblInComing.Rows.Count - 1 Then
                Dim idproducto() = row.Cells(1).Value.ToString().Split("   ")
                Dim idproductoCmb() = cmb.SelectedItem.ToString().Split("   ")
                If idproductoCmb(0).Equals(idproducto(0)) Then
                    flag = False
                    Exit For
                End If
            End If
        Next
        If flag Then
            Dim index As Integer = tblInComing.CurrentCell.RowIndex()
            tblInComing.Rows(index).Cells(1).Value = cmb.SelectedItem.ToString()
            For Each row As DataRow In tblProductInComing.Rows()
                If row.ItemArray(0) = cmb.SelectedItem() Then
                    tblInComing.Rows(index).Cells(2).Value = row.ItemArray(2)
                    tblInComing.Rows(index).Cells(3).Value = row.ItemArray(3)
                    tblInComing.Rows(index).Cells(4).Value = row.ItemArray(4)
                    Exit For
                End If
            Next
        Else
            MessageBox.Show("This Product is the list.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Dim index1 = tblInComing.CurrentCell.RowIndex()
            tblInComing.Rows(index1).Cells(2).Value = ""
            tblInComing.Rows(index1).Cells(3).Value = ""
            tblInComing.Rows(index1).Cells(4).Value = ""
            cmb.Text = ""
        End If
    End Sub

    Public Sub cmb_SelectedIndexChanguedOutGoing(sender As Object, e As EventArgs)
        Dim cmb As ComboBox = CType(sender, ComboBox)
        Dim flag As Boolean = True
        For Each row As DataGridViewRow In tblOutGoing.Rows()
            If row.Index <> tblOutGoing.CurrentCell.RowIndex And row.Index < tblOutGoing.Rows.Count - 1 Then
                Dim idproducto() = row.Cells(1).Value.ToString().Split("   ")
                Dim idproductoCmb() = cmb.SelectedItem.ToString().Split("   ")
                If idproductoCmb(0).Equals(idproducto(0)) Then
                    flag = False
                    Exit For
                End If
            End If
        Next
        If flag Then
            Dim index As Integer = tblOutGoing.CurrentCell.RowIndex()
            tblOutGoing.Rows(index).Cells(1).Value = If(cmb.SelectedItem = Nothing, "", cmb.SelectedItem.ToString())
            For Each row As DataRow In tblProductOutGoing.Rows()
                If row.ItemArray(0) = cmb.SelectedItem() Then
                    tblOutGoing.Rows(index).Cells(2).Value = row.ItemArray(3)
                    tblOutGoing.Rows(index).Cells(3).Value = row.ItemArray(2)
                    tblOutGoing.Rows(index).Cells(4).Value = row.ItemArray(4)
                    tblOutGoing.Rows(index).Cells(6).Value = row.ItemArray(5)
                    If tblOutGoing.Rows(index).Cells(0).Value IsNot Nothing Then
                        If CDbl(tblOutGoing.Rows(index).Cells(0).Value) > CDbl(row.ItemArray(5)) Then
                            MsgBox("The QTY of this product exceeds your Stock." + vbCrLf + "Your Stock is " + CStr(row.ItemArray(5)) + ".")
                        End If
                    End If
                    Exit For
                End If
            Next
        Else
            MessageBox.Show("This Product is the list.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Dim index1 = tblOutGoing.CurrentCell.RowIndex()
            tblOutGoing.Rows(index1).Cells(2).Value = ""
            tblOutGoing.Rows(index1).Cells(3).Value = ""
            tblOutGoing.Rows(index1).Cells(4).Value = ""
            tblOutGoing.Rows(index1).Cells(6).Value = ""
            cmb.Text = ""
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

    Public Sub cmb_selectedIndexChangueScaffoldInformation(sender As Object, e As EventArgs)
        Dim cmb As ComboBox = CType(sender, ComboBox)
        If tblScaffoldInformation.CurrentCell.ColumnIndex = tblScaffoldInformation.Columns("clmType").Index Then
            tblScaffoldInformation.CurrentCell.Value = If(cmb.SelectedItem IsNot Nothing, cmb.SelectedItem, "")
            sc.sciType = If(cmb.SelectedItem IsNot Nothing, cmb.SelectedItem, "")
        End If
    End Sub

    Public Sub cmb_SelectedIndexChanguedProducScaffold(sender As Object, e As EventArgs)
        Try
            Dim cmb As ComboBox = CType(sender, ComboBox)
            If tblProductosScaffold.CurrentCell.ColumnIndex = tblProductosScaffold.Columns("clmID").Index Then
                If tblProductosScaffold.CurrentCell.Value <> cmb.SelectedItem Then
                    Dim flagExist = True
                    For Each row As DataGridViewRow In tblProductosScaffold.Rows()
                        If row.Cells("clmID").Value = cmb.SelectedItem And tblProductosScaffold.CurrentCell.RowIndex <> row.Index Then
                            flagExist = False
                            Exit For
                        End If
                    Next
                    If flagExist Then
                        For Each row As Data.DataRow In tblProductScaffoldAux.Rows()
                            If cmb.SelectedItem = row.ItemArray(0) Then
                                tblProductosScaffold.CurrentRow.Cells("clmProductDescription").Value = CStr(row.ItemArray(4))
                                tblProductosScaffold.CurrentRow.Cells("clmID").Value = CStr(row.ItemArray(1))
                                tblProductosScaffold.CurrentRow.Cells("clmStock").Value = CStr(row.ItemArray(5))
                                cmb.Text = CStr(row.ItemArray(1))
                                If tblProductosScaffold.CurrentRow.Cells("clmQTY").Value > tblProductosScaffold.CurrentRow.Cells("clmStock").Value Then
                                    tblProductosScaffold.CurrentRow.Cells("clmQTY").Value = "0"
                                End If
                                Exit For
                            End If
                        Next
                    Else
                        MessageBox.Show("The selected product is in the Table.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tblScaffoldInformation_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles tblScaffoldInformation.EditingControlShowing
        Dim Index = tblScaffoldInformation.CurrentCell.ColumnIndex
        If Index = 0 Then
            If tblScaffoldInformation.CurrentCell.GetType.Name = "DataGridViewComboBoxCell" Then
                Dim cb As ComboBox = CType(e.Control, ComboBox)
                If e.Control IsNot Nothing Then
                    RemoveHandler cb.SelectedIndexChanged, AddressOf cmb_selectedIndexChangueScaffoldInformation
                    AddHandler cb.SelectedIndexChanged, AddressOf cmb_selectedIndexChangueScaffoldInformation
                End If
            End If
        End If
    End Sub

    Private Sub tblProduct_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles tblProduct.EditingControlShowing
        Dim Index = tblProduct.CurrentCell.ColumnIndex
        If Index = 2 Or Index = 3 Then
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
                    If id = If(row.Cells("ID").Value = Nothing, "", row.Cells("ID").Value.ToString()) And row.Index <> tblProduct.CurrentRow.Index Then
                        tblProduct.CurrentRow.Cells("Product Name").Value = row.Cells("Product Name").Value
                        tblProduct.CurrentRow.Cells("UM").Value = row.Cells("UM").Value
                        tblProduct.CurrentRow.Cells("Class").Value = row.Cells("Class").Value
                        tblProduct.CurrentRow.Cells("Cost").Value = row.Cells("Cost").Value
                        tblProduct.CurrentRow.Cells("Weigth").Value = row.Cells("Weigth").Value
                        tblProduct.CurrentRow.Cells("Weigth Measure").Value = row.Cells("Weigth Measure").Value
                        tblProduct.CurrentRow.Cells("$UM").Value = row.Cells("$UM").Value
                        tblProduct.CurrentRow.Cells("Daily Rental Rate").Value = row.Cells("Daily Rental Rate").Value
                        tblProduct.CurrentRow.Cells("Weekly Rental Rate").Value = row.Cells("Weekly Rental Rate").Value
                        tblProduct.CurrentRow.Cells("Monthly Rental Rate").Value = row.Cells("Monthly Rental Rate").Value
                        tblProduct.CurrentRow.Cells("QTY").Value = row.Cells("QTY").Value
                        tblProduct.CurrentRow.Cells("QID").Value = row.Cells("QID").Value
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
            mtdScaffold.llenarProduct(tblProductosAux)
        End If
    End Sub

    Private Sub txtIDProduct_TextChanged(sender As Object, e As EventArgs) Handles txtIDProduct.TextChanged
        Dim flag = mtdScaffold.llenarProduct(tblProduct, txtIDProduct.Text, True)
        If flag = False Then
            mtdScaffold.llenarProduct(tblProduct)
            mtdScaffold.llenarProduct(tblProductosAux)
        End If
    End Sub

    Private Sub btnSaveRowProduct_Click(sender As Object, e As EventArgs) Handles btnSaveRowProduct.Click
        If tblProduct.SelectedRows().Count > 0 Then
            Dim lis = mtdScaffold.saveProducto(tblProduct, False)
            If lis.Count = 0 Or lis IsNot Nothing Then
                MsgBox("Sucessfull")
                mtdScaffold.llenarProduct(tblProduct)
                mtdScaffold.llenarProduct(tblProductosAux)
            Else
                MsgBox("Error at line " + lis(0))
            End If
        Else
            MsgBox("Please Select A Row.")
        End If
    End Sub

    Private Sub btnDeleteProduct_Click(sender As Object, e As EventArgs) Handles btnDeleteProduct.Click
        If DialogResult.Yes = MessageBox.Show("The products are likely to be related to some records and it will NOT be possible to delete them. Would you like to continue?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) Then
            mtdScaffold.DeleteRowsProducto(tblProduct, False)
        End If
    End Sub

    Private Sub tblInComing_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles tblInComing.CellClick
        If e.ColumnIndex > 0 Then
            Select Case tblInComing.Columns(e.ColumnIndex).Name
                Case "ID"
                    Try
                        If tblInComing.CurrentCell.GetType.Name = "DataGridViewTextBoxCell" Then
                            Dim cmbIdProduct As New DataGridViewComboBoxCell
                            With cmbIdProduct
                                mtdScaffold.llenarCellComboIDProduct(cmbIdProduct, tblProductInComing)
                            End With
                            If tblInComing.CurrentRow.Cells("ID").Value IsNot Nothing Then
                                cmbIdProduct.Value = tblInComing.CurrentRow.Cells("ID").Value
                            End If
                            tblInComing.CurrentRow.Cells("ID") = cmbIdProduct
                        End If
                    Catch ex As Exception

                    End Try
            End Select
        End If
    End Sub

    Private Sub tblInComing_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles tblInComing.EditingControlShowing
        Dim Index = tblInComing.CurrentCell.ColumnIndex
        If Index = 1 Then
            If tblInComing.CurrentCell.GetType.Name = "DataGridViewComboBoxCell" Then
                Dim cb As ComboBox = CType(e.Control, ComboBox)
                If e.Control IsNot Nothing Then
                    RemoveHandler cb.SelectedIndexChanged, AddressOf cmb_SelectedIndexChanguedInComming
                    AddHandler cb.SelectedIndexChanged, AddressOf cmb_SelectedIndexChanguedInComming
                End If
            End If
        End If
    End Sub

    Private Sub tblInComing_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles tblInComing.CellEndEdit
        If e.ColumnIndex = 0 Then
            If Not soloNumero(tblInComing.CurrentCell.Value.ToString()) Then
                tblInComing.CurrentCell.Value = "0"
            ElseIf tblInComing.CurrentCell.Value.ToString() IsNot "" Then
                If CInt(tblInComing.CurrentCell.Value) < 0 Then
                    tblInComing.CurrentCell.Value = CInt(tblInComing.CurrentCell.Value) * -1
                End If
            End If
        End If
    End Sub

    Private Sub txtTicketNumInComing_Leave(sender As Object, e As EventArgs) Handles txtTicketNumInComing.Leave
        If Not soloNumero(txtTicketNumInComing.Text) Then
            txtTicketNumInComing.Text = ""
        End If
    End Sub

    Private Sub btnNewInComing_Click(sender As Object, e As EventArgs) Handles btnNewInComing.Click
        txtTicketNumInComing.Enabled = True
        txtTicketNumInComing.Text = ""
        cmbJobNumInComing.Text = ""
        dtpDateInComing.Value = System.DateTime.Today
        cmbEmployeesInComing.Text = ""
        txtCommentsInComing.Text = ""
        tblInComing.Rows.Clear()
        selectedTable = tblInComing.Name
    End Sub

    Private Sub btnNewInComing_KeyPress(sender As Object, e As KeyPressEventArgs) Handles btnNewInComing.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnDeleteRowInComing_Click(sender As Object, e As EventArgs) Handles btnDeleteRowInComing.Click
        Try
            If tblInComing.SelectedRows.Count > 0 Then
                If mtdScaffold.DeleteInComing(tblInComing) Then
                    For Each row As DataGridViewRow In tblInComing.SelectedRows()
                        tblInComing.Rows.Remove(row)
                    Next
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Private Sub btnSaveRowInComing_Click(sender As Object, e As EventArgs) Handles btnSaveRowInComing.Click
        Try
            If tblInComing.SelectedRows.Count > 0 Then
                Dim list As New List(Of String)
                If cmbJobNumInComing.SelectedItem IsNot Nothing And txtTicketNumInComing.Text <> "" Then
                    list.Add(txtTicketNumInComing.Text)
                    list.Add(validaFechaParaSQl(dtpDateInComing.Value))
                    list.Add(cmbEmployeesInComing.Text)
                    list.Add(txtCommentsInComing.Text)
                    list.Add(cmbJobNumInComing.SelectedItem)
                ElseIf cmbJobNumInComing.SelectedItem Is Nothing Then
                    MessageBox.Show("The Job Number is not selected, Please choose one and try again.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ElseIf txtTicketNumInComing.Text <> "" Then
                    MessageBox.Show("The Ticket Number is not correct.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                If list.Count > 0 Then
                    If mtdScaffold.saveInComing(tblInComing, list, False) Then
                        MsgBox("Successful")
                        mtdScaffold.llenarProduct(tblProduct)
                        mtdScaffold.llenarTicketsIncoming(tblTicketInComing)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try

    End Sub

    Private Sub btnBackInComing_Click(sender As Object, e As EventArgs) Handles btnBackInComing.Click
        If tblTicketInComing.Rows.Count > 1 Then
            Dim cont = 0
            For Each row As DataRow In tblTicketInComing.Rows()
                If txtTicketNumInComing.Text = row.ItemArray(0).ToString() Then
                    If cont > 0 Then
                        cont -= 1
                        txtTicketNumInComing.Text = tblTicketInComing.Rows(cont).ItemArray(0)
                        dtpDateInComing.Value = validarFechaParaVB(tblTicketInComing.Rows(cont).ItemArray(1))
                        cmbEmployeesInComing.Text = tblTicketInComing.Rows(cont).ItemArray(2)
                        txtCommentsInComing.Text = tblTicketInComing.Rows(cont).ItemArray(3)
                        cmbJobNumInComing.Text = tblTicketInComing.Rows(cont).ItemArray(4)
                        txtTicketNumInComing.Enabled = False
                        Exit For
                    Else
                        cont = (tblTicketInComing.Rows.Count - 1)
                        txtTicketNumInComing.Text = tblTicketInComing.Rows(cont).ItemArray(0)
                        dtpDateInComing.Value = validarFechaParaVB(tblTicketInComing.Rows(cont).ItemArray(1))
                        cmbEmployeesInComing.Text = tblTicketInComing.Rows(cont).ItemArray(2)
                        txtCommentsInComing.Text = tblTicketInComing.Rows(cont).ItemArray(3)
                        cmbJobNumInComing.Text = tblTicketInComing.Rows(cont).ItemArray(4)
                        txtTicketNumInComing.Enabled = False
                        Exit For
                    End If
                End If
                cont += 1
            Next
            mtdScaffold.llenarPoductosIncoming(tblInComing, txtTicketNumInComing.Text)
        End If
    End Sub

    Private Sub btnNextInComing_Click(sender As Object, e As EventArgs) Handles btnNextInComing.Click
        If tblTicketInComing.Rows.Count > 1 Then
            Dim cont = 0
            For Each row As DataRow In tblTicketInComing.Rows()
                If txtTicketNumInComing.Text = row.ItemArray(0).ToString() Then
                    If cont < (tblTicketInComing.Rows.Count - 1) Then
                        cont += 1
                        txtTicketNumInComing.Text = tblTicketInComing.Rows(cont).ItemArray(0)
                        dtpDateInComing.Value = validarFechaParaVB(tblTicketInComing.Rows(cont).ItemArray(1))
                        cmbEmployeesInComing.Text = tblTicketInComing.Rows(cont).ItemArray(2)
                        txtCommentsInComing.Text = tblTicketInComing.Rows(cont).ItemArray(3)
                        cmbJobNumInComing.Text = tblTicketInComing.Rows(cont).ItemArray(4)
                        txtTicketNumInComing.Enabled = False
                        Exit For
                    Else
                        cont = 0
                        txtTicketNumInComing.Text = tblTicketInComing.Rows(cont).ItemArray(0)
                        dtpDateInComing.Value = validarFechaParaVB(tblTicketInComing.Rows(cont).ItemArray(1))
                        cmbEmployeesInComing.Text = tblTicketInComing.Rows(cont).ItemArray(2)
                        txtCommentsInComing.Text = tblTicketInComing.Rows(cont).ItemArray(3)
                        cmbJobNumInComing.Text = tblTicketInComing.Rows(cont).ItemArray(4)
                        txtTicketNumInComing.Enabled = False
                        Exit For
                    End If
                End If
                cont += 1
            Next
        End If
        mtdScaffold.llenarPoductosIncoming(tblInComing, txtTicketNumInComing.Text)
    End Sub

    Private Sub cmbJobNumOutGoing_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbJobNumOutGoing.SelectedIndexChanged
        Try
            If cmbJobNumOutGoing.Text <> "" Then
                Dim listDatos = mtdScaffold.custumerJobNum(CStr(cmbJobNumOutGoing.SelectedItem))
                If listDatos.Count = 2 Then
                    txtCustumer.Text = listDatos(0)
                    txtAddresOutGoing.Text = listDatos(1)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Private Sub btnNewOutGoing_Click(sender As Object, e As EventArgs) Handles btnNewOutGoing.Click
        txtTicketNumOutGoing.Enabled = True
        txtTicketNumOutGoing.Text = ""
        tblProductOutGoing.Clear()
        dtpDateOutGoing.Value = System.DateTime.Today()
        cmbJobNumOutGoing.Text = ""
        txtCustumer.Text = ""
        txtAddresOutGoing.Text = ""
        cmbShippedBY.Text = ""
        cmbSuperintendent.Text = ""
        txtCommentOut.Text = ""
    End Sub

    Private Sub tblOutGoing_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles tblOutGoing.CellClick
        If e.ColumnIndex > 0 Then
            Select Case tblOutGoing.Columns(e.ColumnIndex).Name
                Case "IDOut"
                    Try
                        If tblOutGoing.CurrentCell.GetType.Name = "DataGridViewTextBoxCell" Then
                            Dim cmbIdProduct As New DataGridViewComboBoxCell
                            With cmbIdProduct
                                mtdScaffold.llenarCellComboIDProductExistences(cmbIdProduct, tblProductOutGoing)
                            End With
                            If tblOutGoing.CurrentRow.Cells("IDOut").Value IsNot Nothing Then
                                cmbIdProduct.Value = tblOutGoing.CurrentRow.Cells("IDOut").Value
                            End If
                            tblOutGoing.CurrentRow.Cells("IDOut") = cmbIdProduct
                        End If
                    Catch ex As Exception

                    End Try
            End Select
        End If
    End Sub

    Private Sub tblOutGoing_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles tblOutGoing.EditingControlShowing
        Dim Index = tblOutGoing.CurrentCell.ColumnIndex
        If Index = 1 Then
            If tblOutGoing.CurrentCell.GetType.Name = "DataGridViewComboBoxCell" Then
                Dim cb As ComboBox = CType(e.Control, ComboBox)
                If e.Control IsNot Nothing Then
                    RemoveHandler cb.SelectedIndexChanged, AddressOf cmb_SelectedIndexChanguedOutGoing
                    AddHandler cb.SelectedIndexChanged, AddressOf cmb_SelectedIndexChanguedOutGoing
                End If
            End If
        End If
    End Sub

    Private Sub tblOutGoing_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles tblOutGoing.CellEndEdit
        If e.ColumnIndex = 0 Then
            If Not soloNumero(If(tblInComing.CurrentCell.Value IsNot Nothing, tblInComing.CurrentCell.Value.ToString(), "")) Then
                tblInComing.CurrentCell.Value = "0"
            ElseIf tblInComing.CurrentCell.Value.ToString() IsNot "" Then
                If CInt(tblInComing.CurrentCell.Value) < 0 Then
                    tblInComing.CurrentCell.Value = CInt(tblInComing.CurrentCell.Value) * -1
                End If
                If tblOutGoing.Rows(tblOutGoing.CurrentCell.RowIndex).Cells(5).Value IsNot Nothing Then
                    If CDbl(tblOutGoing.Rows(tblOutGoing.CurrentCell.RowIndex).Cells(5).Value) > CDbl(tblOutGoing.CurrentCell.Value) Then
                        MsgBox("The QTY of this product exceeds your stock.")
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub btnSaveRowOutGoing_Click(sender As Object, e As EventArgs) Handles btnSaveRowOutGoing.Click
        Dim list As New List(Of String)
        If cmbJobNumOutGoing.SelectedItem IsNot Nothing And txtTicketNumOutGoing.Text <> "" Then
            list.Add(txtTicketNumOutGoing.Text)
            list.Add(validaFechaParaSQl(dtpDateOutGoing.Value))
            list.Add(txtCommentOut.Text)
            list.Add(cmbShippedBY.Text)
            list.Add(cmbSuperintendent.Text)
            list.Add(cmbJobNumOutGoing.SelectedItem)
        ElseIf cmbJobNumInComing.SelectedItem Is Nothing Then
            MessageBox.Show("The Job Number is not selected, Please choose one and try again.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf txtTicketNumInComing.Text <> "" Then
            MessageBox.Show("The Ticket Number is not correct.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        If list.Count > 0 Then
            If mtdScaffold.saveOutGoing(tblOutGoing, list, False) Then
                MsgBox("Successful")
                mtdScaffold.llenarProduct(tblProduct)
                mtdScaffold.llenarTicketsOutGoing(tblTicketOutGoing)
            End If
        End If
    End Sub

    Private Sub btnDeleteRowOutGoing_Click(sender As Object, e As EventArgs) Handles btnDeleteRowOutGoing.Click
        Try
            If tblOutGoing.SelectedRows.Count() > 0 Then
                If mtdScaffold.DeleteOutGoing(tblOutGoing) Then
                    For Each row As DataGridViewRow In tblOutGoing.SelectedRows()
                        tblOutGoing.Rows.Remove(row)
                    Next
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnBackTicketOutGoing_Click(sender As Object, e As EventArgs) Handles btnBackTicketOutGoing.Click
        If tblTicketOutGoing.Rows.Count > 1 Then
            Dim cont = 0
            For Each row As DataRow In tblTicketOutGoing.Rows()
                If txtTicketNumOutGoing.Text = row.ItemArray(0).ToString() Then
                    If cont > 0 Then
                        cont -= 1
                        txtTicketNumOutGoing.Text = tblTicketOutGoing.Rows(cont).ItemArray(0)
                        dtpDateOutGoing.Value = validarFechaParaVB(tblTicketOutGoing.Rows(cont).ItemArray(1))
                        txtCommentOut.Text = tblTicketOutGoing.Rows(cont).ItemArray(2)
                        cmbShippedBY.Text = tblTicketOutGoing.Rows(cont).ItemArray(3)
                        cmbSuperintendent.Text = tblTicketOutGoing.Rows(cont).ItemArray(4)
                        Dim index = cmbJobNumOutGoing.FindString(CStr(tblTicketOutGoing.Rows(cont).ItemArray(5)))
                        cmbJobNumOutGoing.SelectedItem = cmbJobNumOutGoing.Items(index)
                        txtTicketNumInComing.Enabled = False
                        Exit For
                    Else
                        cont = (tblTicketInComing.Rows.Count - 1)
                        txtTicketNumOutGoing.Text = tblTicketOutGoing.Rows(cont).ItemArray(0)
                        dtpDateOutGoing.Value = validarFechaParaVB(tblTicketOutGoing.Rows(cont).ItemArray(1))
                        txtCommentOut.Text = tblTicketOutGoing.Rows(cont).ItemArray(2)
                        cmbShippedBY.Text = tblTicketOutGoing.Rows(cont).ItemArray(3)
                        cmbSuperintendent.Text = tblTicketOutGoing.Rows(cont).ItemArray(4)
                        Dim index = cmbJobNumOutGoing.FindString(CStr(tblTicketOutGoing.Rows(cont).ItemArray(5)))
                        cmbJobNumOutGoing.SelectedItem = cmbJobNumOutGoing.Items(index)
                        txtTicketNumInComing.Enabled = False
                        Exit For
                    End If
                End If
                cont += 1
            Next
            mtdScaffold.llenarProductosOutGoing(tblOutGoing, txtTicketNumOutGoing.Text)
        End If
    End Sub

    Private Sub btnNextTicketOutGoing_Click(sender As Object, e As EventArgs) Handles btnNextTicketOutGoing.Click
        If tblTicketOutGoing.Rows.Count > 1 Then
            Dim cont = 0
            For Each row As DataRow In tblTicketOutGoing.Rows()
                If txtTicketNumOutGoing.Text = row.ItemArray(0).ToString() Then
                    If cont < (tblTicketOutGoing.Rows.Count - 1) Then
                        cont += 1
                        txtTicketNumOutGoing.Text = tblTicketOutGoing.Rows(cont).ItemArray(0)
                        dtpDateOutGoing.Value = validarFechaParaVB(tblTicketOutGoing.Rows(cont).ItemArray(1))
                        txtCommentOut.Text = tblTicketOutGoing.Rows(cont).ItemArray(2)
                        cmbShippedBY.Text = tblTicketOutGoing.Rows(cont).ItemArray(3)
                        cmbSuperintendent.Text = tblTicketOutGoing.Rows(cont).ItemArray(4)
                        Dim index = cmbJobNumOutGoing.FindString(CStr(tblTicketOutGoing.Rows(cont).ItemArray(5)))
                        cmbJobNumOutGoing.SelectedItem = cmbJobNumOutGoing.Items(index)
                        txtTicketNumInComing.Enabled = False
                        Exit For
                    Else
                        cont = 0
                        txtTicketNumOutGoing.Text = tblTicketOutGoing.Rows(cont).ItemArray(0)
                        dtpDateOutGoing.Value = validarFechaParaVB(tblTicketOutGoing.Rows(cont).ItemArray(1))
                        txtCommentOut.Text = tblTicketOutGoing.Rows(cont).ItemArray(2)
                        cmbShippedBY.Text = tblTicketOutGoing.Rows(cont).ItemArray(3)
                        cmbSuperintendent.Text = tblTicketOutGoing.Rows(cont).ItemArray(4)
                        Dim index = cmbJobNumOutGoing.FindString(CStr(tblTicketOutGoing.Rows(cont).ItemArray(5)))
                        cmbJobNumOutGoing.SelectedItem = cmbJobNumOutGoing.Items(index)
                        txtTicketNumInComing.Enabled = False
                        Exit For
                    End If
                End If
                cont += 1
            Next
        End If
        mtdScaffold.llenarProductosOutGoing(tblOutGoing, txtTicketNumOutGoing.Text)
    End Sub

    Private Sub cmbJobCAT_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbJobCAT.SelectedIndexChanged
        Try
            For Each row As DataRow In tblCat.Rows()
                If cmbJobCAT.SelectedItem = row.ItemArray(0) Then
                    sc.jobcat = row.ItemArray(1)
                    sc.category = row.ItemArray(2)
                    txtCAT.Text = row.ItemArray(2)
                    Exit For
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmbJobCAT_Leave(sender As Object, e As EventArgs) Handles cmbJobCAT.Leave
        Try
            For Each row As DataRow In tblCat.Rows()
                If cmbJobCAT.SelectedItem = row.ItemArray(0) Then
                    sc.jobcat = row.ItemArray(1)
                    sc.category = row.ItemArray(2)
                    txtCAT.Text = row.ItemArray(2)
                    Exit For
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbAreaID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAreaID.SelectedIndexChanged
        Try
            For Each row As DataRow In tblArea.Rows()
                If cmbAreaID.SelectedItem = row.ItemArray(0) Then
                    sc.areaID = row.ItemArray(1)
                    sc.area = row.ItemArray(2)
                    txtArea.Text = row.ItemArray(2)
                    Exit For
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbAreaID_Leave(sender As Object, e As EventArgs) Handles cmbAreaID.Leave
        Try
            For Each row As DataRow In tblArea.Rows()
                If cmbAreaID.SelectedItem = row.ItemArray(0) Then
                    sc.areaID = row.ItemArray(1)
                    sc.area = row.ItemArray(2)
                    cmbAreaID.Text = row.ItemArray(2)
                    Exit For
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbWONum_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbWONum.SelectedIndexChanged
        Try
            If cmbWONum.SelectedItem IsNot Nothing Then
                For Each row As DataRow In tblWOTASK.Rows()
                    Dim datos() = cmbWONum.SelectedItem.ToString().Split(" ")
                    If datos(0) = row.ItemArray(0) Then
                        sc.wo = row.ItemArray(1)
                        sc.task = row.ItemArray(2)
                        sc.job = row.ItemArray(3)
                        sc.descriptionWO = row.ItemArray(4)
                        txtWOInfo.Text = row.ItemArray(4)
                        Exit For
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbWONum_Leave(sender As Object, e As EventArgs) Handles cmbWONum.Leave
        Try
            For Each row As DataRow In tblWOTASK.Rows()
                Dim datos() = cmbWONum.SelectedItem.ToString().Split(" ")
                If datos(0) = row.ItemArray(0) Then
                    cmbWONum.Text = row.ItemArray(0)
                    Exit For
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbSubJob_Leave(sender As Object, e As EventArgs) Handles cmbSubJob.Leave
        Try
            For Each row As DataRow In tblSubJob.Rows()
                If row.ItemArray(0) = cmbSubJob.SelectedItem Then
                    sc.subjob = row.ItemArray(2)
                    sc.idsubJob = row.ItemArray(1)
                    cmbSubJob.Text = row.ItemArray(0)
                    Exit For
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtpBldDate_Leave(sender As Object, e As EventArgs) Handles dtpBldDate.Leave
        dtpReqCompScaffold.Value = dtpBldDate.Value
    End Sub

    Private Sub tblScaffoldInformation_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles tblScaffoldInformation.CellEndEdit
        Try
            If e.ColumnIndex > 0 Then
                If tblScaffoldInformation.Rows(0).Cells(e.ColumnIndex).Value <> "" And soloNumero(tblScaffoldInformation.Rows(0).Cells(e.ColumnIndex).Value.ToString()) Then
                    sc.sciType = If(tblScaffoldInformation.Rows(0).Cells("clmType").Value <> "", CStr(tblScaffoldInformation.Rows(0).Cells("clmType").Value), "")
                    sc.sciWidth = If(tblScaffoldInformation.Rows(0).Cells("clmWidth").Value <> "", CDbl(tblScaffoldInformation.Rows(0).Cells("clmWidth").Value), 0)
                    sc.sciLength = If(tblScaffoldInformation.Rows(0).Cells("clmLength").Value <> "", CDbl(tblScaffoldInformation.Rows(0).Cells("clmLength").Value), 0)
                    sc.sciHeigth = If(tblScaffoldInformation.Rows(0).Cells("clmHeigth").Value <> "", CDbl(tblScaffoldInformation.Rows(0).Cells("clmHeigth").Value), 0)
                    sc.sciDecks = If(tblScaffoldInformation.Rows(0).Cells("clmDecks").Value <> "", CDbl(tblScaffoldInformation.Rows(0).Cells("clmDecks").Value), 0)
                    sc.sciKo = If(tblScaffoldInformation.Rows(0).Cells("clmKOs").Value <> "", CDbl(tblScaffoldInformation.Rows(0).Cells("clmKOs").Value), 0)
                    sc.sciBase = If(tblScaffoldInformation.Rows(0).Cells("clmBase").Value <> "", CDbl(tblScaffoldInformation.Rows(0).Cells("clmBase").Value), 0)
                Else
                    tblScaffoldInformation.Rows(0).Cells(e.ColumnIndex).Value = "0"
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tblActivityHours_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles tblActivityHours.CellEndEdit
        Try
            If e.ColumnIndex <> tblActivityHours.Columns("clmTotal").Index Then
                If tblActivityHours.Rows(0).Cells(e.ColumnIndex).Value <> "" And soloNumero(tblActivityHours.Rows(0).Cells(e.ColumnIndex).Value.ToString()) Then
                    sc.ahrBuild = If(tblActivityHours.Rows(0).Cells("clmBuild").Value <> "", CDbl(tblActivityHours.Rows(0).Cells("clmBuild").Value), 0)
                    sc.ahrMaterial = If(tblActivityHours.Rows(0).Cells("clmMabl").Value <> "", CDbl(tblActivityHours.Rows(0).Cells("clmMabl").Value), 0)
                    sc.ahrTravel = If(tblActivityHours.Rows(0).Cells("clmTravl").Value <> "", CDbl(tblActivityHours.Rows(0).Cells("clmTravl").Value), 0)
                    sc.ahrWeather = If(tblActivityHours.Rows(0).Cells("clmWhtr").Value <> "", CDbl(tblActivityHours.Rows(0).Cells("clmWhtr").Value), 0)
                    sc.ahrAlarm = If(tblActivityHours.Rows(0).Cells("clmAlarm").Value <> "", CDbl(tblActivityHours.Rows(0).Cells("clmAlarm").Value), 0)
                    sc.ahrSafety = If(tblActivityHours.Rows(0).Cells("clmSafty").Value <> "", CDbl(tblActivityHours.Rows(0).Cells("clmSafty").Value), 0)
                    sc.ahrStdBy = If(tblActivityHours.Rows(0).Cells("clmStdBy").Value <> "", CDbl(tblActivityHours.Rows(0).Cells("clmStdBy").Value), 0)
                    sc.ahrOther = If(tblActivityHours.Rows(0).Cells("clmOthh").Value <> "", CDbl(tblActivityHours.Rows(0).Cells("clmOthh").Value), 0)

                Else
                    tblActivityHours.Rows(0).Cells(e.ColumnIndex).Value = "0"
                End If
                Dim totalHours As Double = 0
                For Each cell As DataGridViewCell In tblActivityHours.Rows(0).Cells()
                    If cell.Value.ToString() <> "" And cell.ColumnIndex <> 8 Then
                        totalHours = totalHours + CDbl(cell.Value.ToString())
                    End If
                Next
                tblActivityHours.Rows(0).Cells("clmTotal").Value = CStr(totalHours)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub tblProductosScaffold_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles tblProductosScaffold.EditingControlShowing
        Dim Index = tblProductosScaffold.CurrentCell.ColumnIndex
        If Index = 1 Then
            If tblProductosScaffold.CurrentCell.GetType.Name = "DataGridViewComboBoxCell" Then
                Dim cb As ComboBox = CType(e.Control, ComboBox)
                If e.Control IsNot Nothing Then
                    RemoveHandler cb.SelectedIndexChanged, AddressOf cmb_SelectedIndexChanguedProducScaffold
                    AddHandler cb.SelectedIndexChanged, AddressOf cmb_SelectedIndexChanguedProducScaffold
                End If
            End If
        End If
    End Sub

    Private Sub tblProductosScaffold_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles tblProductosScaffold.CellEndEdit
        Try
            If e.ColumnIndex = tblProductosScaffold.Columns("clmQTY").Index Then
                Dim valor = If(tblProductosScaffold.CurrentRow.Cells(e.ColumnIndex).Value = Nothing, "", tblProductosScaffold.CurrentRow.Cells(e.ColumnIndex).Value.ToString())
                If Not valor <> "" Or Not soloNumero(CStr(valor)) Then
                    tblProductosScaffold.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "0"
                ElseIf CDbl(valor) > CDbl(tblProductosScaffold.CurrentRow.Cells("clmStock").Value) Then
                    tblProductosScaffold.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "0"
                    MessageBox.Show("The 'product quantity' has been exceeded, the current stock is " + CStr(tblProductosScaffold.CurrentRow.Cells("clmStock").Value) + ".", "Important", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
            'Insertar celda por celda en la tabla de productosScaffoldAux
            Dim pd = sc.products
            sc.products.Clear()
            For Each row As DataGridViewRow In tblProductosScaffold.Rows()
                If row.Cells(1).Value <> Nothing Then
                    sc.products.Rows.Add(row.Cells(0).Value, row.Cells(1).Value, If(row.Cells(2).Value = Nothing, "0", row.Cells(2).Value), row.Cells(3).Value, row.Cells(4).Value)
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tblLeg_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles tblLeg.CellEndEdit
        Try
            Dim valor = If(tblLeg.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Nothing, "", tblLeg.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString())
            If Not valor <> "" Or Not soloNumero(valor) Then
                tblLeg.CurrentRow.Cells(e.ColumnIndex).Value = "0"
            End If
            Dim leg = sc.leg
            sc.leg.Clear()
            For Each row As DataGridViewRow In tblLeg.Rows()
                If row.Cells(1).Value <> Nothing Then
                    sc.leg.Rows.Add(row.Cells(0).Value, row.Cells(1).Value, row.Cells(2).Value)
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtTag_Leave(sender As Object, e As EventArgs) Handles txtTag.Leave
        sc.tag = txtTag.Text
    End Sub

    Private Sub cmbSubJob_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSubJob.SelectedIndexChanged
        Try
            For Each row As DataRow In tblSubJob.Rows()
                If cmbSubJob.SelectedItem = row.ItemArray(0) Then
                    sc.subjob = row.ItemArray(2)
                    sc.idsubJob = row.ItemArray(1)
                    cmbSubJob.Text = row.ItemArray(0)
                    Exit For
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtpBldDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpBldDate.ValueChanged
        Try
            sc.dateBild = dtpBldDate.Value
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtpReqCompScaffold_ValueChanged(sender As Object, e As EventArgs) Handles dtpReqCompScaffold.ValueChanged
        Try
            sc.dateRecComp = dtpReqCompScaffold.Value
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtLocation_TextChanged(sender As Object, e As EventArgs) Handles txtLocation.TextChanged
        Try
            sc.location = txtLocation.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtPurpose_TextChanged(sender As Object, e As EventArgs) Handles txtPurpose.TextChanged
        Try
            sc.purpose = txtPurpose.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtNotesAndComments_TextChanged(sender As Object, e As EventArgs) Handles txtNotesAndComments.TextChanged
        Try
            sc.comments = txtNotesAndComments.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub sprDecks_ValueChanged(sender As Object, e As EventArgs) Handles sprDecks.ValueChanged
        Try
            sc.sciExtraDeck = sprDecks.Value
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbContactScaffold_TextChanged(sender As Object, e As EventArgs) Handles cmbContactScaffold.TextChanged
        Try
            sc.contact = cmbContactScaffold.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbForemanScaffold_TextChanged(sender As Object, e As EventArgs) Handles cmbForemanScaffold.TextChanged
        Try
            sc.foreman = cmbForemanScaffold.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbErectorScaffold_TextChanged(sender As Object, e As EventArgs) Handles cmbErectorScaffold.TextChanged
        Try
            sc.erector = cmbErectorScaffold.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chbTrailer_CheckedChanged(sender As Object, e As EventArgs) Handles chbTruck.CheckedChanged, chbTrailer.CheckedChanged, chbRope.CheckedChanged, chbPassed.CheckedChanged, chbForklift.CheckedChanged, chbElevator.CheckedChanged, chbCrane.CheckedChanged
        Try
            If loadingData = False Then
                If chbTruck.Checked Then
                    sc.materialHandeling(0) = True
                Else
                    sc.materialHandeling(0) = False
                End If
                If chbForklift.Checked Then
                    sc.materialHandeling(1) = True
                Else
                    sc.materialHandeling(1) = False
                End If
                If chbTrailer.Checked Then
                    sc.materialHandeling(2) = True
                Else
                    sc.materialHandeling(2) = False
                End If
                If chbCrane.Checked Then
                    sc.materialHandeling(3) = True
                Else
                    sc.materialHandeling(3) = False
                End If
                If chbRope.Checked Then
                    sc.materialHandeling(4) = True
                Else
                    sc.materialHandeling(4) = False
                End If
                If chbPassed.Checked Then
                    sc.materialHandeling(5) = True
                Else
                    sc.materialHandeling(5) = False
                End If
                If chbElevator.Checked Then
                    sc.materialHandeling(6) = True
                Else
                    sc.materialHandeling(6) = False
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub chbCSAP_CheckedChanged(sender As Object, e As EventArgs) Handles chbRolling.CheckedChanged, chbInternal.CheckedChanged, chbHanging.CheckedChanged, chbCSAP.CheckedChanged
        Try
            If loadingData = False Then
                If chbCSAP.Checked Then
                    sc.scfInfo(0) = True
                Else
                    sc.scfInfo(0) = False
                End If
                If chbRolling.Checked Then
                    sc.scfInfo(1) = True
                Else
                    sc.scfInfo(1) = False
                End If
                If chbInternal.Checked Then
                    sc.scfInfo(2) = True
                Else
                    sc.scfInfo(2) = False
                End If
                If chbHanging.Checked Then
                    sc.scfInfo(3) = True
                Else
                    sc.scfInfo(3) = False
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function cargarDatosScaffold(ByVal tag As String) As Boolean
        Try
            loadingData = True
            If tag <> "" Then
                sc = mtdScaffold.llenarScaffold(tag)
            End If
            sc.tag = tag
            txtTag.Text = sc.tag
            cmbJobCAT.SelectedItem = Nothing
            cmbJobCAT.Text = ""
            txtCAT.Text = ""
            For Each row As Data.DataRow In tblCat.Rows()
                If row("id") = sc.jobcat Then
                    cmbJobCAT.SelectedItem = row("cmb")
                    cmbJobCAT.Text = sc.jobcat
                    txtCAT.Text = sc.category
                    Exit For
                End If
            Next
            cmbAreaID.SelectedItem = Nothing
            cmbAreaID.Text = ""
            txtArea.Text = ""
            For Each row As Data.DataRow In tblArea.Rows()
                If row("id") = sc.areaID Then
                    cmbAreaID.SelectedItem = row("cmb")
                    cmbAreaID.Text = sc.areaID
                    txtArea.Text = sc.area
                    Exit For
                End If
            Next
            cmbWONum.SelectedItem = Nothing
            txtWOInfo.Text = ""
            For Each row As Data.DataRow In tblWOTASK.Rows()
                If row("task") = sc.task Then
                    cmbWONum.SelectedItem = row("cmb")
                    txtWOInfo.Text = sc.descriptionWO
                    Exit For
                End If
            Next
            cmbSubJob.SelectedItem = Nothing
            For Each row As Data.DataRow In tblSubJob.Rows
                If row("subJob") = sc.idsubJob Then
                    cmbSubJob.SelectedItem = row("cmb")
                    Exit For
                End If
            Next
            dtpBldDate.Value = sc.dateBild
            txtLocation.Text = sc.location
            txtPurpose.Text = sc.purpose
            txtNotesAndComments.Text = sc.comments
            cmbContactScaffold.SelectedItem = sc.contact
            cmbContactScaffold.Text = sc.contact
            cmbErectorScaffold.SelectedItem = sc.erector
            cmbErectorScaffold.Text = sc.erector
            cmbForemanScaffold.SelectedItem = sc.foreman
            cmbForemanScaffold.Text = sc.foreman
            dtpReqCompScaffold.Value = sc.dateRecComp
            sprDecks.Value = sc.sciExtraDeck
            If sc.idScaffoldinformation <> "" Then
                tblScaffoldInformation.Rows(0).Cells("clmType").Value = sc.sciType
                tblScaffoldInformation.Rows(0).Cells("clmWidth").Value = CStr(sc.sciWidth)
                tblScaffoldInformation.Rows(0).Cells("clmLength").Value = CStr(sc.sciLength)
                tblScaffoldInformation.Rows(0).Cells("clmHeigth").Value = CStr(sc.sciHeigth)
                tblScaffoldInformation.Rows(0).Cells("clmDecks").Value = CStr(sc.sciDecks)
                tblScaffoldInformation.Rows(0).Cells("clmKOs").Value = CStr(sc.sciKo)
                tblScaffoldInformation.Rows(0).Cells("clmBase").Value = CStr(sc.sciBase)
            Else
                'tblScaffoldInformation.Rows(0).Cells("clmType").Value = sc.sciType
                tblScaffoldInformation.Rows(0).Cells("clmWidth").Value = "0"
                tblScaffoldInformation.Rows(0).Cells("clmLength").Value = "0"
                tblScaffoldInformation.Rows(0).Cells("clmHeigth").Value = "0"
                tblScaffoldInformation.Rows(0).Cells("clmDecks").Value = "0"
                tblScaffoldInformation.Rows(0).Cells("clmKOs").Value = "0"
                tblScaffoldInformation.Rows(0).Cells("clmBase").Value = "0"
            End If
            If sc.ahrIdActivityHours <> "" Then
                tblActivityHours.Rows(0).Cells("clmBuild").Value = CStr(sc.ahrBuild)
                tblActivityHours.Rows(0).Cells("clmMabl").Value = CStr(sc.ahrMaterial)
                tblActivityHours.Rows(0).Cells("clmTravl").Value = CStr(sc.ahrTravel)
                tblActivityHours.Rows(0).Cells("clmWhtr").Value = CStr(sc.ahrWeather)
                tblActivityHours.Rows(0).Cells("clmAlarm").Value = CStr(sc.ahrAlarm)
                tblActivityHours.Rows(0).Cells("clmSafty").Value = CStr(sc.ahrSafety)
                tblActivityHours.Rows(0).Cells("clmStdBy").Value = CStr(sc.ahrStdBy)
                tblActivityHours.Rows(0).Cells("clmOthh").Value = CStr(sc.ahrOther)
                tblActivityHours.Rows(0).Cells("clmTotal").Value = CStr(sc.ahrTotal)
            Else
                tblActivityHours.Rows(0).Cells("clmBuild").Value = "0"
                tblActivityHours.Rows(0).Cells("clmMabl").Value = "0"
                tblActivityHours.Rows(0).Cells("clmTravl").Value = "0"
                tblActivityHours.Rows(0).Cells("clmWhtr").Value = "0"
                tblActivityHours.Rows(0).Cells("clmAlarm").Value = "0"
                tblActivityHours.Rows(0).Cells("clmSafty").Value = "0"
                tblActivityHours.Rows(0).Cells("clmStdBy").Value = "0"
                tblActivityHours.Rows(0).Cells("clmOthh").Value = "0"
                tblActivityHours.Rows(0).Cells("clmTotal").Value = "0"
            End If
            If sc.scfInfo.Length > 0 Then
                chbCSAP.Checked = sc.scfInfo(0)
                chbRolling.Checked = sc.scfInfo(1)
                chbInternal.Checked = sc.scfInfo(2)
                chbHanging.Checked = sc.scfInfo(3)
            End If
            If sc.materialHandeling.Length > 0 Then
                chbTruck.Checked = sc.materialHandeling(0)
                chbForklift.Checked = sc.materialHandeling(1)
                chbTrailer.Checked = sc.materialHandeling(2)
                chbCrane.Checked = sc.materialHandeling(3)
                chbRope.Checked = sc.materialHandeling(4)
                chbPassed.Checked = sc.materialHandeling(5)
                chbElevator.Checked = sc.materialHandeling(6)
            End If
            If sc.products.Rows.Count > 0 Then
                tblProductosScaffold.Rows.Clear()
                For Each row As Data.DataRow In sc.products.Rows()
                    tblProductosScaffold.Rows.Add(row("idProductScaffold"), row("idProduct"), row("QTY"), row("description"), row("stock"))
                Next
            Else
                tblProductosScaffold.Rows.Clear()
            End If
            If sc.leg.Rows.Count > 0 Then
                tblLeg.Rows.Clear()
                For Each row As Data.DataRow In sc.leg.Rows()
                    tblLeg.Rows.Add(row("legID"), row("qty"), row("heigth"))
                Next
            Else
                tblLeg.Rows.Clear()
            End If
            loadingData = False
            Return True
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        End Try
    End Function

    Private Sub btnBackTag_Click(sender As Object, e As EventArgs) Handles btnBackTag.Click
        Try
            If tblProductScaffoldAux.Rows IsNot Nothing Then
                If DialogResult.Yes = MessageBox.Show("If you made any changes it will not be saved, are you sure to continue?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) Then
                    Dim count = 1
                    For Each row As Data.DataRow In tblScaffoldTags.Rows()
                        If sc.tag = row("tag") Then
                            Exit For
                        Else
                            count += 1
                        End If
                    Next
                    If count = 1 Then
                        count = tblScaffoldTags.Rows.Count() - 1
                        cargarDatosScaffold(tblScaffoldTags.Rows(count).ItemArray(0))
                    Else
                        If sc.tag = "" Then
                            count -= 1
                        End If
                        cargarDatosScaffold(tblScaffoldTags.Rows(count - 1).ItemArray(0))
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnNextTag_Click(sender As Object, e As EventArgs) Handles btnNextTag.Click
        Try
            If tblProductScaffoldAux.Rows IsNot Nothing Then
                If DialogResult.Yes = MessageBox.Show("If you made any changes it will not be saved, are you sure to continue?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) Then
                    Dim count = 1
                    For Each row As Data.DataRow In tblScaffoldTags.Rows()
                        If sc.tag = row("tag") Then
                            Exit For
                        Else
                            count += 1
                        End If
                    Next
                    If count = tblScaffoldTags.Rows.Count() Then
                        count = 0
                        cargarDatosScaffold(tblScaffoldTags.Rows(count).ItemArray(0))
                    Else
                        If sc.tag = "" Then
                            count -= 1
                        End If
                        cargarDatosScaffold(tblScaffoldTags.Rows(count - 1).ItemArray(0))
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnDeleteRowScaffoldLeg_Click(sender As Object, e As EventArgs) Handles btnDeleteRowScaffoldLeg.Click
        If selectedTable = tblLeg.Name Then
            If DialogResult.Yes = MessageBox.Show("The selected rows will be removed from the 'LEG TABLE'. Are you sure to do it?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) Then
                If mtdScaffold.deleteRowsLeg(tblLeg) Then
                    For Each row As DataGridViewRow In tblLeg.SelectedRows()
                        tblLeg.Rows.Remove(row)
                    Next
                    sc.leg = sc.llenarLeg(sc.tag)
                End If
            End If
        ElseIf selectedTable = tblProductosScaffold.Name Then
            If DialogResult.Yes = MessageBox.Show("The selected rows will be removed from the 'PRODUCTS TABLE'. Are you sure to do it?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) Then
                If mtdScaffold.deleteRowsProductScaffold(tblProductosScaffold) Then
                    For Each row As DataGridViewRow In tblProductosScaffold.SelectedRows()
                        tblProductosScaffold.Rows.Remove(row)
                    Next
                    sc.products = sc.llenarTablaProductTag(sc.tag)
                End If
            End If
        End If
    End Sub

    Private Sub btnNewTag_Click(sender As Object, e As EventArgs) Handles btnNewTag.Click
        If sc.tag <> "" Then
            If DialogResult.Yes = MessageBox.Show("If you made any changes it will not be saved, are you sure to continue?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) Then
                sc.Clear()
                cargarDatosScaffold("")
            End If
        End If
    End Sub
End Class