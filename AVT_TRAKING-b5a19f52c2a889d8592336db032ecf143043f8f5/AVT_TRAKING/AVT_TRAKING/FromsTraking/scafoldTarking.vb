Imports Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices
Public Class scafoldTarking
    Public IdCliente, Company As String

    Dim tablaEmpleados As New Data.DataTable
    Dim tblProductInComing As New Data.DataTable
    Dim tblTicketInComing As New Data.DataTable
    Dim tblProductOutGoing As New Data.DataTable
    Dim tblProductJob As New Data.DataTable
    Dim tblTicketOutGoing As New Data.DataTable
    Dim tblArea As New Data.DataTable 'se utiliza para buscar despues de ser seleccionado el combo y encontrar al insertar o actualizar
    Dim tblCat As New Data.DataTable 'se utiliza para buscar despues de ser seleccionado el combo y encontrar al insertar o actualizar
    Dim tblWOTASK As New Data.DataTable 'se utiliza para buscar despues de ser seleccionado el combo y encontrar al insertar o actualizar
    Dim tblSubJob As New Data.DataTable 'se utiliza para buscar despues de ser seleccionado el combo y encontrar al insertar o actualizar
    Dim tblProductScaffoldAux As New Data.DataTable 'se utiliza para buscar despues de ser seleccionado el combo y encontrar al insertar o actualizar
    Dim mtdScaffold As New MetodosScaffold
    Dim mtdEstimation As New EstimationSC
    Dim selectedTable As String
    Dim tblMaterialStatusAux As New List(Of String)
    Dim tblProductosAux As New Data.DataTable
    Dim tblScaffoldTags As New Data.DataTable
    Dim tblModification As New Data.DataTable
    Dim tblDismantle As New Data.DataTable
    Dim tblEstimation As New Data.DataTable
    Dim tblCostumers As New Data.DataTable
    Dim sc As New scaffold
    Dim md As New ModificationSC
    Dim ds As New dismantle
    Dim estMeter As New EstMeters
    Dim loadingData As Boolean 'Estas variables las utilizo para que los datos no activen los events de los elementos en la interfaz
    Dim loadingDataModification As Boolean
    Dim loadingDataDismentle As Boolean
    Dim cmbProyect As New DataGridViewComboBoxCell
    Dim cmbProyect1 As New DataGridViewComboBoxCell
    Private Sub scafoldTarking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarDatosByClient(IdCliente, Company)
    End Sub
    Private Function llenarComboTag(ByVal cmb As ComboBox, ByVal tblTags As Data.DataTable) As Integer
        If tblTags.Rows.Count > 0 Then
            If cmb.Items IsNot Nothing Then
                cmb.Items.Clear()
            End If
            For Each row As DataRow In tblTags.Rows()
                If row.ItemArray(6).ToString() = "f" Then
                    cmb.Items.Add(row.ItemArray(0).ToString())
                End If
            Next
        End If
        Return If(cmb.Items IsNot Nothing, cmb.Items.Count(), 0)
    End Function
    'Private Sub tabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabControl1.SelectedIndexChanged
    '    Select Case tabControl1.SelectedTab.Text
    '        Case "In Coming"
    '            selectedTable = tblInComing.Name()
    '        Case "Out Going"
    '            selectedTable = tblOutGoing.Name()
    '        Case "Costumers & JobsN."
    '        Case "Products"
    '        Case "Area/WO/Sub-Job"
    '        Case "UM/Class/Status"
    '        Case "Supervisor"
    '        Case "ScaffoldTraking"
    '            selectedTable = "tag"
    '        Case "Modification"
    '            selectedTable = "Mod"
    '        Case "Dismantle"
    '            selectedTable = "Dis"
    '        Case "Estimating"
    '            selectedTable = "Est"
    '    End Select
    'End Sub
    Private Sub MyTabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MyTabControl1.SelectedIndexChanged
        Select Case MyTabControl1.SelectedTab.Text
            Case "In Coming"
                selectedTable = tblInComing.Name()
            Case "Out Going"
                selectedTable = tblOutGoing.Name()
            Case "Costumers & JobsN."
            Case "Products"
            Case "Area/WO/Sub-Job"
            Case "UM/Class/Status"
            Case "Supervisor"
            Case "ScaffoldTracking"
                selectedTable = "tag"
            Case "Modification"
                selectedTable = "Mod"
            Case "Dismantle"
                selectedTable = "Dis"
            Case "Estimating"
                selectedTable = "Est"
        End Select
    End Sub
    Private Sub btnSaveTable_Click(sender As Object, e As EventArgs) Handles btnSaveTable.Click
        Select Case selectedTable
            Case tblAreas.Name
                If mtdScaffold.SaveAreas(tblAreas) Then
                    tblArea = mtdScaffold.llenarComboArea(cmbAreaID, If(IdCliente <> "", IdCliente, ""))
                    MsgBox("Sucessfull")
                End If
            Case tblSubJobs.Name
                If mtdScaffold.SaveSubJobs(tblSubJobs) Then
                    tblSubJob = mtdScaffold.llenarComboSubJob(cmbSubJob, If(IdCliente <> "", IdCliente, ""))
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
                    tblCat = mtdScaffold.llenarComboJobCat(cmbJobCAT, If(IdCliente <> "", IdCliente, ""))
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
                    Dim valcmb = If(cmbProyect.Value <> "", cmbProyect.Value, "")
                    Dim valcmb1 = If(cmbProyect.Value <> "", cmbProyect.Value, "")
                    mtdScaffold.llenarRentaTypeCombo(cmbProyect)
                    mtdScaffold.llenarRentaTypeCombo(cmbProyect1)
                    cmbProyect.Value = valcmb
                    cmbProyect.Value = valcmb1
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
                    cargarDatosScaffold(sc.tag)
                    mtdScaffold.llenarProduct(tblProduct)
                    mtdScaffold.llenarProduct(tblProductosAux)
                    mtdScaffold.llenarScaffold(tblScaffoldTags, If(lblCompanyName.Text = "Client: All", "", IdCliente))
                    If tblScaffoldTags.Rows.Count() > 0 Then
                        Dim tagSelected = cmbTagScaffold.Text
                        cmbTagScaffold.Items.Clear()
                        If tblScaffoldTags.Rows.Count > 0 Then
                            llenarComboTag(cmbTagDismantle, tblScaffoldTags)
                            mtdScaffold.llenarComboTagModificaion(cmbTagScaffold, IdCliente)
                        End If
                        loadingDataModification = True
                        Dim indexCmb = cmbTagScaffold.FindString(tagSelected)
                        cmbTagScaffold.SelectedItem = cmbTagScaffold.Items(If(indexCmb >= 0, indexCmb, 0))
                        cmbTagScaffold.Text = tagSelected
                    End If
                    MsgBox("Successfull")
                End If
            Case tblProductosScaffold.Name
                If mtdScaffold.saveScaffoldTraking(sc) Then
                    cargarDatosScaffold(sc.tag)
                    mtdScaffold.llenarProduct(tblProduct)
                    mtdScaffold.llenarProduct(tblProductosAux)
                    If cmbTagScaffold.Text <> "" And tblScaffoldTags.Rows.Count() > 0 Then
                        Dim tagSelected = cmbTagScaffold.Text
                        cmbTagScaffold.Items.Clear()
                        For Each row As Data.DataRow In tblScaffoldTags.Rows()
                            cmbTagScaffold.Items.Add(row.ItemArray(0))
                        Next
                        loadingDataModification = True
                        Dim indexCmb = cmbTagScaffold.FindString(tagSelected)
                        cmbTagScaffold.SelectedItem = cmbTagScaffold.Items(If(indexCmb > 0, indexCmb, 0))
                        cmbTagScaffold.Text = tagSelected
                    End If
                    MsgBox("Successfull")
                End If
            Case tblLeg.Name
                If mtdScaffold.saveScaffoldTraking(sc) Then
                    cargarDatosScaffold(sc.tag)
                    mtdScaffold.llenarProduct(tblProduct)
                    mtdScaffold.llenarProduct(tblProductosAux)
                    If cmbTagScaffold.Text <> "" And tblScaffoldTags.Rows.Count() > 0 Then
                        Dim tagSelected = cmbTagScaffold.Text
                        cmbTagScaffold.Items.Clear()
                        For Each row As Data.DataRow In tblScaffoldTags.Rows()
                            cmbTagScaffold.Items.Add(row.ItemArray(0))
                        Next
                        'cmbTagScaffold.SelectedItem = cmbTagScaffold.Items(cmbTagScaffold.FindString(tagSelected))
                        'cmbTagScaffold.Text = tagSelected
                    End If
                    MsgBox("Successfull")
                End If
            Case "Mod"
                If mtdScaffold.saveModification(md) Then
                    md = mtdScaffold.llenarModificationData(md.ModAux, md.tag)
                    cargarDatosModification(md.ModAux)
                    mtdScaffold.llenarProduct(tblProduct)
                    mtdScaffold.llenarProduct(tblProductosAux)
                End If
            Case tblModificationProductMS.Name
                If mtdScaffold.saveModification(md) Then
                    md = mtdScaffold.llenarModificationData(md.ModAux, md.tag)
                    cargarDatosModification(md.ModAux)
                    mtdScaffold.llenarProduct(tblProduct)
                    mtdScaffold.llenarProduct(tblProductosAux)
                End If
            Case "Dis"
                If mtdScaffold.saveDismantle(ds, False) Then
                    mtdScaffold.llenarScaffold(tblScaffoldTags, If(lblCompanyName.Text = "Client: All", "", IdCliente))
                    llenarComboTag(cmbTagDismantle, tblScaffoldTags)
                    cargarDatosDismantle(ds.tag)
                    mtdScaffold.llenarProduct(tblProductosAux)
                    If ds.tag = sc.tag Then
                        mtdScaffold.llenarScaffold(sc.tag)
                        cargarDatosScaffold(sc.tag)
                    End If
                    If ds.tag = md.tag Then
                        md = mtdScaffold.llenarModificationData(md.ModAux, md.tag)
                        cargarDatosModification(md.ModAux)
                    End If
                    mtdScaffold.llenarProduct(tblProduct)
                    mtdScaffold.llenarProduct(tblProductosAux)
                End If
            Case "Est"
                If IdClientEstmation Is Nothing Then
                    selectClient()
                    mtdEstimation.idClient = IdClientEstmation
                End If
                If mtdEstimation.saveEstimation(estMeter) Then
                    btnNewEst.Text = "New"
                    'txtControlNumber.Enabled = False
                    mtdEstimation.llenartablaEstimacion(tblEstimation, IdCliente)
                End If
        End Select
    End Sub

    Private Sub btnSaveAll_Click(sender As Object, e As EventArgs) Handles btnSaveAll.Click
        Select Case MyTabControl1.SelectedTab.Text
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
                Dim valcmb = If(cmbProyect.Value <> "", cmbProyect.Value, "")
                Dim valcmb1 = If(cmbProyect.Value <> "", cmbProyect.Value, "")
                mtdScaffold.llenarRentaTypeCombo(cmbProyect)
                mtdScaffold.llenarRentaTypeCombo(cmbProyect1)
                cmbProyect.Value = valcmb
                cmbProyect.Value = valcmb1
            Case "Supervisor"
            Case "ScaffoldTraking"
                If mtdScaffold.saveScaffoldTraking(sc) Then
                    cargarDatosScaffold(sc.tag)
                    mtdScaffold.llenarProduct(tblProduct)
                    mtdScaffold.llenarProduct(tblProductosAux)
                    mtdScaffold.llenarScaffold(tblScaffoldTags, If(lblCompanyName.Text = "Client: All", "", IdCliente))
                    If tblScaffoldTags.Rows.Count() > 0 Then
                        Dim tagSelected = cmbTagScaffold.Text
                        cmbTagScaffold.Items.Clear()
                        If tblScaffoldTags.Rows.Count > 0 Then
                            llenarComboTag(cmbTagDismantle, tblScaffoldTags)
                            mtdScaffold.llenarComboTagModificaion(cmbTagScaffold, IdCliente)
                        End If
                        'cmbTagScaffold.SelectedItem = cmbTagScaffold.Items(cmbTagScaffold.FindString(tagSelected))
                        'cmbTagScaffold.Text = tagSelected
                    End If
                End If
            Case "Modification"
                If mtdScaffold.saveModification(md) Then
                    If mtdScaffold.llenarModification(tblModification, IdCliente) Then
                        For Each row As DataRow In tblModification.Rows
                            If row.ItemArray(0) = md.ModID Then
                                md = mtdScaffold.llenarModificationData(row.ItemArray(0), row.ItemArray(5))
                                cargarDatosModification(md.ModAux)
                            End If
                        Next
                    End If
                End If
            Case "Dis"
                If mtdScaffold.saveDismantle(ds, False) Then
                    If cargarDatosDismantle(ds.tag) Then
                        mtdScaffold.llenarProduct(tblProductosAux)
                    End If
                End If
            Case "Est"
                If mtdEstimation.saveEstimation(estMeter) Then
                    btnNewEst.Text = "New"
                    'txtControlNumber.Enabled = False
                    mtdEstimation.llenartablaEstimacion(tblEstimation, IdCliente)
                End If
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
                If cmbWONum.SelectedItem IsNot Nothing Then
                    If tblProductosScaffold.CurrentCell.GetType.Name = "DataGridViewTextBoxCell" Then
                        Dim cmbPd As New DataGridViewComboBoxCell
                        With cmbPd
                            Dim array() As String = cmbWONum.SelectedItem.ToString.Split(" ")
                            mtdScaffold.llenarCellComboIdProductExistByJobNNo(cmbPd, array(1), tblProductScaffoldAux) 'llenarCellComboIdProductExistByJobNNo
                            cmbPd.DropDownWidth = 280
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
                Else
                    MessageBox.Show("Please select a project to charge the list of products that you can asing.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub
    Private Sub tblScaffoldInformationSM_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles tblScaffoldInformationSM.CellClick
        selectedTable = "Mod"
    End Sub
    Private Sub tblActivityHoursSM_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles tblActivityHoursSM.CellClick
        selectedTable = "Mod"
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
                    If mtdScaffold.DeleteOutGoing(tblOutGoing, cmbJobNumOutGoing.SelectedItem) Then
                        For Each row As DataGridViewRow In tblOutGoing.SelectedRows()
                            tblOutGoing.Rows.Remove(row)
                        Next
                    End If
                End If
            Case "tag"
                If DialogResult.Yes = MessageBox.Show("The Scaffold will be Deleted with all of records added (Modifications, Products, Dismantle,etc). Would you like to continue?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) Then
                    If mtdScaffold.deleteScaffold(sc) Then
                        MessageBox.Show("Successful", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        mtdScaffold.llenarScaffold(tblScaffoldTags, IdCliente)
                        If tblScaffoldTags.Rows.Count > 0 Then
                            mtdScaffold.llenarProduct(tblProduct)
                            mtdScaffold.llenarProduct(tblProductosAux)
                            mtdScaffold.llenarScaffold(tblScaffoldTags, IdCliente)
                            mtdScaffold.llenarModification(tblModification, IdCliente)
                            If cmbTagScaffold.Text <> "" And tblScaffoldTags.Rows.Count() > 0 Then
                                Dim tagSelected = cmbTagScaffold.Text
                                cmbTagScaffold.Items.Clear()
                                mtdScaffold.llenarComboTagModificaion(cmbTagScaffold, IdCliente)
                                If cmbTagScaffold.FindString(tagSelected) = -1 Then
                                    cmbTagScaffold.SelectedItem = Nothing
                                    cmbTagScaffold.Text = ""
                                    md.Clear()
                                    cargarDatosDismantle("")
                                Else
                                    cmbTagScaffold.SelectedItem = cmbTagScaffold.Items(cmbTagScaffold.FindString(tagSelected))
                                    cmbTagScaffold.Text = tagSelected
                                End If
                            End If
                            sc = mtdScaffold.llenarScaffold(tblScaffoldTags.Rows(0).ItemArray(0).ToString())
                            cargarDatosScaffold(sc.tag)
                        End If
                    Else
                        MessageBox.Show("Error, try to close the window.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        If tblScaffoldTags.Rows.Count > 0 Then
                            sc = mtdScaffold.llenarScaffold(tblScaffoldTags.Rows(0).ItemArray(0).ToString())
                            cargarDatosScaffold(sc.tag)
                        Else
                            sc.Clear()
                            cargarDatosScaffold(sc.tag)
                        End If
                    End If
                End If
            Case tblProductosScaffold.Name
                If DialogResult.Yes = MessageBox.Show("The Scaffold will be Deleted with all of records added (Modifications, Products, Dismantle,etc). Would you like to continue?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) Then
                    If mtdScaffold.deleteScaffold(sc) Then
                        MessageBox.Show("Successful", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        mtdScaffold.llenarProduct(tblProduct)
                        mtdScaffold.llenarProduct(tblProductosAux)
                        mtdScaffold.llenarScaffold(tblScaffoldTags, IdCliente)
                        If cmbTagScaffold.Text <> "" And tblScaffoldTags.Rows.Count() > 0 Then
                            Dim tagSelected = cmbTagScaffold.Text
                            cmbTagScaffold.Items.Clear()
                            For Each row As Data.DataRow In tblScaffoldTags.Rows()
                                cmbTagScaffold.Items.Add(row.ItemArray(0))
                            Next
                            cmbTagScaffold.SelectedItem = cmbTagScaffold.Items(cmbTagScaffold.FindString(tagSelected))
                            cmbTagScaffold.Text = tagSelected
                        End If
                        mtdScaffold.llenarScaffold(tblScaffoldTags, IdCliente)
                        If tblScaffoldTags.Rows.Count > 0 Then
                            sc = mtdScaffold.llenarScaffold(tblScaffoldTags.Rows(0).ItemArray(0).ToString())
                            cargarDatosScaffold(sc.tag)
                        End If
                    Else
                        MessageBox.Show("Error, try to close the window.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        sc = mtdScaffold.llenarScaffold(tblScaffoldTags.Rows(0).ItemArray(0).ToString())
                        cargarDatosScaffold(sc.tag)
                    End If
                End If
            Case "Mod"
                If DialogResult.Yes = MessageBox.Show("The 'Modification Records' will be deleted. Would you like to continue?", "Important ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) Then
                    If (mtdScaffold.deleteModificaion(md.tag, md.ModAux)) Then
                        If mtdScaffold.llenarModification(tblModification, IdCliente) Then
                            If tblModification.Rows.Count > 0 Then
                                md = mtdScaffold.llenarModificationData(tblModification.Rows(0).ItemArray(0), tblModification.Rows(0).ItemArray(5))
                                If md.ModAux <> "" Then
                                    cargarDatosModification(md.ModAux)
                                End If
                            Else
                                md.Clear()
                                cargarDatosModification("")
                            End If
                        End If
                        mtdScaffold.llenarProduct(tblProduct)
                        mtdScaffold.llenarProduct(tblProductosAux)
                    End If
                End If
            Case tblModificationProductMS.Name
                If DialogResult.Yes = MessageBox.Show("The 'Modification Records' will be deleted. Would you like to continue?", "Important ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) Then
                    If (mtdScaffold.deleteModificaion(md.tag, md.ModAux)) Then
                        If mtdScaffold.llenarModification(tblModification, IdCliente) Then
                            If tblModification.Rows.Count > 0 Then
                                md.Clear()
                                md = mtdScaffold.llenarModificationData(tblModification.Rows(0).ItemArray(0), tblModification.Rows(0).ItemArray(5))
                                If md.ModAux <> "" Then
                                    cargarDatosModification(md.ModAux)
                                End If
                            Else
                                md.Clear()
                                cargarDatosModification("")
                            End If
                        End If
                        mtdScaffold.llenarProduct(tblProduct)
                        mtdScaffold.llenarProduct(tblProductosAux)
                    End If
                End If
            Case "Dis"

            Case "Est"
                If mtdEstimation.ccnum <> "" And DialogResult.OK = MessageBox.Show("The Estimation will be delete, Are you sure to continue?", "Important", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) Then
                    If mtdEstimation.deleteEstimation(mtdEstimation.idEstnumber) Then
                        mtdEstimation.llenartablaEstimacion(tblEstimation, IdCliente)
                        If tblEstimation.Rows.Count > 0 Then
                            mtdEstimation.cargarDatosEstimation(tblEstimation.Rows(0).ItemArray(0))
                            cargarDatosEstimation(tblEstimation.Rows(0).ItemArray(0))
                            'txtControlNumber.Enabled = False
                        Else
                            'txtControlNumber.Enabled = True
                            limpiarCamposEstimation()
                        End If
                    End If
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
    Private Sub btnRefreshTblProduct_Click(sender As Object, e As EventArgs) Handles btnRefreshTblProduct.Click
        mtdScaffold.llenarProduct(tblProduct)
        mtdScaffold.llenarProduct(tblProductosAux)
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
            Dim colums() As String = {"ID", "Product Name", "UM", "Class", "Cost", "Weight", "Weight Maessure", "Daily Rental Rate", "Weekly Rental Rate", "Monthly Rental Rate", "QTY", "QID", "PLF", "PSQF"}
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
        listAuxPruduct.Columns.Add("PLF")
        listAuxPruduct.Columns.Add("PSQF")
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
                listAuxPruduct.Rows.Add(sheet.Cells(contProduct, 1).Text, sheet.Cells(contProduct, 2).Text, sheet.Cells(contProduct, 3).Text, sheet.Cells(contProduct, 4).Text, sheet.Cells(contProduct, 5).Text, sheet.Cells(contProduct, 6).Text, sheet.Cells(contProduct, 7).Text, sheet.Cells(contProduct, 8).Text, sheet.Cells(contProduct, 9).Text, sheet.Cells(contProduct, 10).Text, sheet.Cells(contProduct, 11).Text, sheet.Cells(contProduct, 12).Text, sheet.Cells(contProduct, 13).Text, sheet.Cells(contProduct, 14).Text, sheet.Cells(contProduct, 15).Text)
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
                If row.Cells(1).Value IsNot Nothing Then
                    Dim idproducto() = row.Cells(1).Value.ToString().Split("   ")
                    Dim idproductoCmb() = cmb.SelectedItem.ToString().Split("   ")
                    If idproductoCmb(0).Equals(idproducto(0)) Then
                        flag = False
                        Exit For
                    End If
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
        If cmb.SelectedItem IsNot Nothing Then

            For Each row As DataGridViewRow In tblOutGoing.Rows() 'validamos que no se repita el producto
                If row.Index <> tblOutGoing.CurrentCell.RowIndex And row.Index < tblOutGoing.Rows.Count - 1 Then
                    Dim idproducto() = row.Cells(1).Value.ToString().Split("   ")
                    Dim idproductoCmb() = cmb.SelectedItem.ToString().Split("   ")
                    If idproductoCmb(0).Equals(idproducto(0)) Then
                        flag = False
                        Exit For
                    End If
                End If
            Next
            If flag Then 'si no existe repetidos entra
                Dim index As Integer = tblOutGoing.CurrentCell.RowIndex()
                tblOutGoing.Rows(index).Cells(1).Value = If(cmb.SelectedItem Is Nothing, "", cmb.SelectedItem.ToString())
                For Each row As DataRow In tblProductJob.Rows()
                    If row.ItemArray(0) = cmb.SelectedItem() Then 'si encuentra el nombre y el idproducto asigna los valores
                        tblOutGoing.Rows(index).Cells(2).Value = row.ItemArray(3)
                        tblOutGoing.Rows(index).Cells(3).Value = row.ItemArray(2)
                        tblOutGoing.Rows(index).Cells(4).Value = row.ItemArray(4)
                        tblOutGoing.Rows(index).Cells(6).Value = row.ItemArray(5)
                        If tblOutGoing.Rows(index).Cells(0).Value IsNot Nothing Then
                            If CDbl(tblOutGoing.Rows(index).Cells(0).Value) > CDbl(row.ItemArray(5)) Then
                                MsgBox("The QTY of this product exceeds your Stock." + vbCrLf + "Your Stock is " + CStr(row.ItemArray(5)) + ".")
                                tblOutGoing.Rows(index).Cells(0).Value = row.ItemArray(5)
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
        End If
    End Sub

    Public Sub cmb_SelectedIndexChangued(sender As Object, e As EventArgs)
        Dim cmb As ComboBox = CType(sender, ComboBox)
        If tblProduct.CurrentCell.ColumnIndex = tblProduct.Columns("UM").Index Then
            If If(tblProduct.CurrentCell.Value Is DBNull.Value, "", tblProduct.CurrentCell.Value) <> cmb.SelectedItem Then
                tblProduct.CurrentCell.Value = If(cmb.SelectedItem IsNot Nothing, cmb.SelectedItem, "")
            End If
        ElseIf tblProduct.CurrentCell.ColumnIndex = tblProduct.Columns("Class").Index Then
            If If(tblProduct.CurrentCell.Value Is DBNull.Value, "", tblProduct.CurrentCell.Value) <> cmb.SelectedItem Then
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
    Public Sub cmb_SelectedIndexChangueProductScaffoldMD(sender As Object, e As EventArgs)
        Try
            Dim cmb As ComboBox = CType(sender, ComboBox)
            If tblModificationProductMS.CurrentCell.ColumnIndex = tblModificationProductMS.Columns("clmIDProductM").Index Then
                If tblModificationProductMS.CurrentCell.Value <> cmb.SelectedItem Then
                    Dim flagExist = True
                    md.productsAdds.Clear()
                    For Each row As DataGridViewRow In tblModificationProductMS.Rows()
                        Dim array = cmb.SelectedItem.ToString.Split(" ")
                        Dim idProductoCmbSelected = array(0)
                        array = If(row.Cells("clmIDProductM").Value = Nothing, {""}, row.Cells("clmIDProductM").Value.ToString.Split(" "))
                        Dim idProductoTbl = array(0)
                        If idProductoCmbSelected = idProductoTbl And tblModificationProductMS.CurrentCell.RowIndex <> row.Index Then
                            flagExist = False
                            Exit For
                        End If
                    Next
                    If flagExist Then
                        For Each row As Data.DataRow In tblProductScaffoldAux.Rows()
                            If cmb.SelectedItem = row.ItemArray(0) Then
                                tblModificationProductMS.CurrentRow.Cells("clmDescriptionM").Value = CStr(row.ItemArray(4))
                                tblModificationProductMS.CurrentRow.Cells("clmIDProductM").Value = CStr(row.ItemArray(1))
                                tblModificationProductMS.CurrentRow.Cells("clmStockProductM").Value = CStr(row.ItemArray(5))
                                cmb.Text = CStr(row.ItemArray(1))
                                If tblModificationProductMS.CurrentRow.Cells("clmQTYM").Value > tblModificationProductMS.CurrentRow.Cells("clmStockProductM").Value Then
                                    tblModificationProductMS.CurrentRow.Cells("clmQTYM").Value = "0"
                                End If
                                Dim plf = ValidarFilasLeg(tblLegMS, tblScaffoldTotalProductMS, False)
                                lblPLFM.Text = plf(0)
                                lblPSQFM.Text = plf(1)
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

    Public Sub cmb_SelectedIndexChanguedProducScaffold(sender As Object, e As EventArgs)
        Try
            Dim cmb As ComboBox = CType(sender, ComboBox)
            If tblProductosScaffold.CurrentCell.ColumnIndex = tblProductosScaffold.Columns("clmID").Index Then
                If tblProductosScaffold.CurrentCell.Value <> cmb.SelectedItem Then
                    Dim flagExist = True
                    For Each row As DataRow In sc.products.Rows() 'validamos que no exita ese product en la lista 
                        Dim array = cmb.SelectedItem.ToString.Split(" ")
                        Dim idProductoCmbSelected = array(0)
                        array = If(row.ItemArray(1) = Nothing, {""}, row.ItemArray(1).ToString.Split(" "))
                        Dim idProductoTbl = array(0)
                        If idProductoCmbSelected = idProductoTbl Then
                            flagExist = False
                            Exit For
                        End If
                    Next

                    'For Each row As DataGridViewRow In tblProductosScaffold.Rows()
                    '    Dim array = cmb.SelectedItem.ToString.Split(" ")
                    '    Dim idProductoCmbSelected = array(0)
                    '    array = If(row.Cells("clmID").Value = Nothing, {""}, row.Cells("clmID").Value.ToString.Split(" "))
                    '    Dim idProductoTbl = array(0)
                    '    If idProductoCmbSelected = idProductoTbl And tblProductosScaffold.CurrentCell.RowIndex <> row.Index Then
                    '        flagExist = False
                    '        Exit For
                    '    End If
                    'Next
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
                                Dim plf = ValidarFilasLeg(tblLeg, tblProductosScaffold, True)
                                lblPLF.Text = plf(0)
                                lblPSQF.Text = plf(1)
                                Exit For
                            End If
                        Next
                    Else
                        MessageBox.Show("The selected product is in the Table." + vbCrLf + "If you can't see the product:" + vbCrLf + "The product row was probably removed, but the record was not Delete." + vbCrLf + "Try to refresh the table.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function ValidarFilasLeg(ByVal tblLeg As DataGridView, ByVal tblPd As DataGridView, ByVal Scaffold As Boolean) As String()
        tblLeg.Rows.Clear()
        Dim PlfPsqf() As String = {"0", "0"}
        Dim clmIdPD As Integer = 0
        If Scaffold Then
            clmIdPD = 1
        Else
            clmIdPD = 0
        End If
        For Each row As DataGridViewRow In tblPd.Rows()
            If row.Cells(clmIdPD).Value IsNot Nothing Then
                For Each row1 As Data.DataRow In tblProductosAux.Rows() 'tabla que guarda todos los productos
                    Dim array = row.Cells(clmIdPD).Value.ToString.Split(" ")
                    Dim idPD = array(0)
                    If row1.ItemArray(0).ToString() = idPD Then
                        Dim heigth = If(row1.ItemArray(12) <> 0, row1.ItemArray(12).ToString(), row1.ItemArray(13).ToString())
                        If heigth <> "0" Then
                            tblLeg.Rows.Add("", row.Cells(clmIdPD + 1).Value, heigth, row1.ItemArray(0), row1.ItemArray(12).ToString(), row1.ItemArray(13).ToString())
                            If row1.ItemArray(12) <> 0 Then
                                PlfPsqf(0) = CDbl(PlfPsqf(0)) + (CDbl(row1.ItemArray(12).ToString()) * CDbl(row.Cells(clmIdPD + 1).Value))
                            Else
                                PlfPsqf(1) = CDbl(PlfPsqf(1)) + CDbl(row1.ItemArray(13).ToString())
                            End If
                        End If
                        Exit For
                    End If
                Next
            End If
        Next
        Return PlfPsqf
    End Function
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
        If e.ColumnIndex <> 1 And e.ColumnIndex <> 2 And e.ColumnIndex <> 3 And e.ColumnIndex <> 11 Then
            If Not soloNumero(tblProduct.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()) Then
                MsgBox("Please use only Numbers.")
                tblProduct.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = ""
            End If
            If e.ColumnIndex = 0 Then
                Dim id = tblProduct.CurrentCell.Value.ToString()
                If id <> "" Then
                    For Each row As DataGridViewRow In tblProduct.Rows()
                        If id = If(row.Cells("ID").Value = Nothing, "", row.Cells("ID").Value.ToString()) And row.Index <> tblProduct.CurrentRow.Index Then
                            tblProduct.CurrentRow.Cells("Product Name").Value = row.Cells("Product Name").Value
                            tblProduct.CurrentRow.Cells("UM").Value = row.Cells("UM").Value
                            tblProduct.CurrentRow.Cells("Class").Value = row.Cells("Class").Value
                            tblProduct.CurrentRow.Cells("Weigth").Value = row.Cells("Weigth").Value
                            tblProduct.CurrentRow.Cells("Weigth Measure").Value = row.Cells("Weigth Measure").Value
                            tblProduct.CurrentRow.Cells("$UM").Value = row.Cells("$UM").Value
                            tblProduct.CurrentRow.Cells("Daily Rental Rate").Value = row.Cells("Daily Rental Rate").Value
                            tblProduct.CurrentRow.Cells("Weekly Rental Rate").Value = row.Cells("Weekly Rental Rate").Value
                            tblProduct.CurrentRow.Cells("Monthly Rental Rate").Value = row.Cells("Monthly Rental Rate").Value
                            tblProduct.CurrentRow.Cells("QTY").Value = row.Cells("QTY").Value
                            tblProduct.CurrentRow.Cells("QID").Value = row.Cells("QID").Value
                            tblProduct.CurrentRow.Cells("PLF").Value = row.Cells("PLF").Value
                            tblProduct.CurrentRow.Cells("PSQF").Value = row.Cells("PSQF").Value
                            Exit For
                        End If
                    Next
                End If
            End If
        End If

    End Sub
    Private Sub txtFindProducJobNo_TextChanged(sender As Object, e As EventArgs) Handles txtFindProducJobNo.TextChanged
        If cmbJobProduct.SelectedItem IsNot Nothing Then
            Dim query As String = txtFindProducJobNo.Text.Replace("'", "''")
            Dim flag = mtdScaffold.llenarProductByJob(tblProductByJobNo, query, cmbJobProduct.SelectedItem.ToString())
            If flag = False Then
                mtdScaffold.llenarTablaProductosByJobNo(tblProductByJobNo)
            End If
            tblProductByJobNo.ReadOnly = True
        Else
            MsgBox("Please select a Job No.")
        End If
    End Sub
    Private Sub cmbProductUtilization_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProductUtilization.SelectedIndexChanged
        Try
            If cmbProductUtilization.SelectedItem IsNot Nothing Then
                Dim jobNoUtilization As String = "All"
                If cmbJobNoUtilization.SelectedIndex > -1 Then
                    jobNoUtilization = cmbJobNoUtilization.Items(cmbJobNoUtilization.SelectedIndex)
                End If
                Dim idProduct() As String = cmbProductUtilization.SelectedItem.ToString.Split(" ")
                mtdScaffold.cargarDatosProductUtlization(tblBuildsMaterial, tblModificationMaterial, tblDismantleMaterial, tblInBoundMaterial, tblOutBoundMaterial, idProduct(0), If(jobNoUtilization = "All", "", jobNoUtilization))
            Else
                MessageBox.Show("Please choose a product to continue", "Important", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbJobNoUtilization_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbJobNoUtilization.SelectedIndexChanged
        Try
            If cmbProductUtilization.SelectedItem IsNot Nothing Then
                Dim jobNoUtilization As String = "All"
                If cmbJobNoUtilization.SelectedIndex > -1 Then
                    jobNoUtilization = cmbJobNoUtilization.Items(cmbJobNoUtilization.SelectedIndex)
                End If
                Dim idProduct() As String = cmbProductUtilization.SelectedItem.ToString.Split(" ")
                mtdScaffold.cargarDatosProductUtlization(tblBuildsMaterial, tblModificationMaterial, tblDismantleMaterial, tblInBoundMaterial, tblOutBoundMaterial, idProduct(0), If(jobNoUtilization = "All", "", jobNoUtilization))
            Else
                MessageBox.Show("Please choose a product to continue", "Important", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception

        End Try
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
    Private Sub TabControl2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl2.SelectedIndexChanged
        If TabControl2.SelectedTab.Text = "Inventory By Job No." Or TabControl2.SelectedTab.Text = "Utilization" Then
            btnSaveRowProduct.Enabled = False
            btnDeleteProduct.Enabled = False
            btnUploadProducts.Enabled = False
            btnDownloadExcel.Enabled = False
        Else
            btnSaveRowProduct.Enabled = True
            btnDeleteProduct.Enabled = True
            btnUploadProducts.Enabled = True
            btnDownloadExcel.Enabled = True
        End If
    End Sub
    Private Sub cmbJobProduct_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbJobProduct.SelectedIndexChanged
        Try
            If cmbJobProduct.SelectedItem IsNot Nothing Then
                mtdScaffold.llenarTablaProductosByJobNo(tblProductByJobNo, cmbJobProduct.SelectedItem.ToString())
            Else
                mtdScaffold.llenarTablaProductosByJobNo(tblProductByJobNo)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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
                                cmbIdProduct.DropDownWidth = 240
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

    Private Sub tblInComing_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles tblInComing.DataError
        e.Cancel = True
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
            If tblInComing.CurrentCell.Value IsNot Nothing Then
                If Not soloNumero(tblInComing.CurrentCell.Value.ToString()) Then
                    tblInComing.CurrentCell.Value = "0"
                ElseIf tblInComing.CurrentCell.Value.ToString() IsNot "" Then
                    If CInt(tblInComing.CurrentCell.Value) < 0 Then
                        tblInComing.CurrentCell.Value = CInt(tblInComing.CurrentCell.Value) * -1
                    End If
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
    Private Sub btnUpdateExcelInConming_Click(sender As Object, e As EventArgs) Handles btnUpdateExcelInConming.Click
        Try
            Dim pdscfe As New ProductSCFExcel
            AddOwnedForm(pdscfe)
            pdscfe.windowStart = "Incoming"
            pdscfe.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnUpdateExcelOutgoing_Click(sender As Object, e As EventArgs) Handles btnUpdateExcelOutgoing.Click
        Try
            Dim pdscfe As New ProductSCFExcel
            AddOwnedForm(pdscfe)
            pdscfe.idClient = IdCliente
            pdscfe.nameClient = lblCompanyName.Text
            If cmbJobNumOutGoing.Text <> "" Then
                pdscfe.jobNo = cmbJobNumOutGoing.Text
            End If
            pdscfe.windowStart = "Outgoing"
            pdscfe.ShowDialog()
        Catch ex As Exception

        End Try
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
                    If cmbJobNumOutGoing.Text IsNot Nothing Then
                        Try
                            If tblOutGoing.CurrentCell.GetType.Name = "DataGridViewTextBoxCell" Then
                                Dim cmbIdProduct As New DataGridViewComboBoxCell
                                With cmbIdProduct
                                    cmbIdProduct.DropDownWidth = 280
                                    mtdScaffold.llenarCellComboIdProductExistByJobNNo(cmbIdProduct, cmbJobNumOutGoing.Text, tblProductJob)
                                End With
                                If tblOutGoing.CurrentRow.Cells("IDOut").Value IsNot Nothing Then
                                    cmbIdProduct.Value = tblOutGoing.CurrentRow.Cells("IDOut").Value
                                End If
                                tblOutGoing.CurrentRow.Cells("IDOut") = cmbIdProduct
                            End If
                        Catch ex As Exception

                        End Try
                    Else
                        MessageBox.Show("Please select a Job No to charge the list of the products you can retrun.","Messague",MessageBoxButtons.OK,MessageBoxIcon.Warning)
                    End If
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
            If Not soloNumero(If(tblOutGoing.CurrentCell.Value IsNot Nothing, tblOutGoing.CurrentCell.Value.ToString(), "")) Then
                tblOutGoing.CurrentCell.Value = "0"
            ElseIf tblOutGoing.CurrentCell.Value IsNot Nothing Then
                If CInt(tblOutGoing.CurrentCell.Value) < 0 Then
                    tblOutGoing.CurrentCell.Value = CInt(tblOutGoing.CurrentCell.Value) * -1
                End If
                If tblOutGoing.Rows(tblOutGoing.CurrentCell.RowIndex).Cells(6).Value IsNot Nothing Then
                    If CDbl(tblOutGoing.Rows(tblOutGoing.CurrentCell.RowIndex).Cells(6).Value) < CDbl(tblOutGoing.CurrentCell.Value) Then
                        MsgBox("The QTY of this product exceeds your stock by this Job No.")
                        tblOutGoing.CurrentCell.Value = CDbl(tblOutGoing.Rows(tblOutGoing.CurrentCell.RowIndex).Cells(6).Value)
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
                If mtdScaffold.DeleteOutGoing(tblOutGoing, cmbJobNumOutGoing.SelectedItem) Then
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
                    If Not loadingData Then
                        sc.days = row.ItemArray(3)
                        sprDays.Value = CDec(row.ItemArray(3))
                    End If
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
                    If Not loadingData Then
                        sc.days = row.ItemArray(3)
                        sprDays.Value = row.ItemArray(3)
                    End If
                    Exit For
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub sprDays_ValueChanged(sender As Object, e As EventArgs) Handles sprDays.ValueChanged
        Try
            If Not loadingData Then
                sc.days = CInt(sprDays.Value)
            End If
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
                    If datos(0) = row.ItemArray(0) And datos(1) = row.ItemArray(3) Then
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
                If cmbWONum.SelectedItem IsNot Nothing Then
                    Dim datos() = cmbWONum.SelectedItem.ToString().Split(" ")
                    If datos(0) = row.ItemArray(0) Then
                        cmbWONum.Text = row.ItemArray(0)
                        Exit For
                    End If
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
                    If e.ColumnIndex = tblScaffoldInformation.Rows(0).Cells("clmDecks").ColumnIndex Then
                        Dim deck = CDbl(tblScaffoldInformation.Rows(0).Cells("clmDecks").Value)
                        If deck > 1 Then
                            sprDecks.Value = deck - 1
                            sc.sciExtraDeck = deck - 1
                        Else
                            sprDecks.Value = 0
                            sc.sciExtraDeck = 0
                        End If
                    End If
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
                Dim Nqty = CDbl(tblProductosScaffold.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) 'Nueva Cantidad
                Dim Tqty = 0.0 'Cantidad total Stock mas la ya insertada
                Dim Lqty = 0.0 'Cantidad ya insertada
                Dim idPd = tblProductosScaffold.Rows(e.RowIndex).Cells(e.ColumnIndex - 1).Value
                Dim flagExist = False
                If idPd <> "" Or idPd IsNot Nothing Then
                    Dim array() = idPd.ToString().Split("   ")
                    idPd = array(0)
                    For Each row As Data.DataRow In sc.products.Rows()
                        If row.ItemArray(1) = idPd Then 'busco si el producto esta en la lista ya insertada en DB
                            Tqty = CDbl(row.ItemArray(2)) + CDbl(row.ItemArray(4))
                            Lqty = CDbl(row.ItemArray(2))
                            flagExist = True
                            Exit For
                        End If
                    Next
                    If flagExist Then
                        If Not Nqty <= Tqty Then
                            MessageBox.Show("The inserted value exceeded the Stock." + vbCrLf + "The Stock is the '" + tblProductosScaffold.Rows(e.RowIndex).Cells("clmStock").Value + "' Units.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            tblProductosScaffold.Rows(e.RowIndex).Cells("clmQTY").Value = Lqty
                        End If
                    Else
                        If Not Nqty <= CDbl(tblProductosScaffold.Rows(e.RowIndex).Cells("clmStock").Value) Then
                            MessageBox.Show("The inserted value exceeded the Stock." + vbCrLf + "The is the " + tblProductosScaffold.Rows(e.RowIndex).Cells("clmStock").Value + " Units.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            tblProductosScaffold.Rows(e.RowIndex).Cells("clmQTY").Value = "0"
                        End If
                    End If
                End If
                Dim plf = ValidarFilasLeg(tblLeg, tblProductosScaffold, True)
                lblPLF.Text = plf(0)
                lblPSQF.Text = plf(1)
                sc.llenarTablaProduct(tblProductosScaffold)
                calcularTagQTY(tblProductosScaffold, lblTagQTY, 2)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Function calcularTagQTY(ByVal tbl As DataGridView, ByVal lbl As System.Windows.Forms.Label, ByVal columnindex As Integer) As Boolean
        Try
            Dim cont As Double = 0
            For Each row As DataGridViewRow In tbl.Rows()
                If row.Cells(columnindex).Value IsNot Nothing Then
                    cont += CDec(row.Cells(columnindex).Value)
                End If
            Next
            lbl.Text = "Tag QTY:" + CStr(cont)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        End Try
    End Function
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
    Private Sub txtLatitude_TextChanged(sender As Object, e As EventArgs) Handles txtLatitude.TextChanged
        Try
            sc.latitude = txtLatitude.Text
        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtLongitude_TextChanged(sender As Object, e As EventArgs) Handles txtLongitude.TextChanged
        Try
            sc.longitude = txtLongitude.Text
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

    Private Function ActivarCamposSC(ByVal status As Boolean) As Boolean
        Try
            txtTag.ReadOnly = status
            cmbJobCAT.Enabled = If(status, False, True)
            txtCAT.ReadOnly = status

            sprDays.ReadOnly = status

            cmbAreaID.Enabled = If(status, False, True)
            txtArea.ReadOnly = status
            cmbAreaID.Enabled = If(status, False, True)
            txtArea.ReadOnly = status

            cmbWONum.Enabled = If(status, False, True)
            txtWOInfo.ReadOnly = status

            cmbSubJob.Enabled = If(status, False, True)

            dtpBldDate.Enabled = If(status, False, True)
            txtLocation.ReadOnly = status
            txtPurpose.ReadOnly = status
            txtNotesAndComments.ReadOnly = status
            txtLongitude.ReadOnly = status
            txtLatitude.ReadOnly = status
            cmbContactScaffold.Enabled = If(status, False, True)

            cmbErectorScaffold.Enabled = If(status, False, True)

            cmbForemanScaffold.Enabled = If(status, False, True)

            dtpReqCompScaffold.Enabled = If(status, False, True)
            sprDecks.ReadOnly = status

            tblScaffoldInformation.ReadOnly = status

            tblActivityHours.ReadOnly = status

            chbCSAP.Enabled = If(status, False, True)
            chbRolling.Enabled = If(status, False, True)
            chbInternal.Enabled = If(status, False, True)
            chbHanging.Enabled = If(status, False, True)


            chbTruck.Enabled = If(status, False, True)
            chbForklift.Enabled = If(status, False, True)
            chbTrailer.Enabled = If(status, False, True)
            chbCrane.Enabled = If(status, False, True)
            chbRope.Enabled = If(status, False, True)
            chbPassed.Enabled = If(status, False, True)
            chbElevator.Enabled = If(status, False, True)
            tblProductosScaffold.ReadOnly = status
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
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
            sprDays.Value = CDec(sc.days)
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
                    cmbWONum.SelectedItem = cmbWONum.Items(cmbWONum.FindString(row("cmb")))
                    cmbWONum.Text = row.ItemArray(0)
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
            txtLongitude.Text = sc.longitude.ToString()
            txtLatitude.Text = sc.latitude.ToString()
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

            sc.llenarTablaProductTag(sc.tag)
            If sc.products.Rows.Count > 0 Then
                tblProductosScaffold.Rows.Clear()
                For Each row As Data.DataRow In sc.products.Rows()
                    tblProductosScaffold.Rows.Add(row("idProductScaffold"), row("idProduct"), row("QTY"), row("description"), row("stock"))
                Next
                calcularTagQTY(tblProductosScaffold, lblTagQTY, 2)
            Else
                tblProductosScaffold.Rows.Clear()
            End If
            sc.llenarProductTotalScaffold(sc.tag)
            Dim plf = ValidarFilasLeg(tblLeg, tblProductosScaffold, True)
            lblPLF.Text = plf(0)
            lblPSQF.Text = plf(1)
            ActivarCamposSC(sc.status)
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
                'If DialogResult.Yes = MessageBox.Show("If you made any changes it will not be saved, are you sure to continue?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) Then
                mtdScaffold.llenarScaffold(tblScaffoldTags, If(lblCompanyName.Text = "Client: All", "", IdCliente))
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
                    cargarDatosScaffold(tblScaffoldTags.Rows(count - 2).ItemArray(0))
                End If
                'End If
            End If
            selectedTable = "tag"
        Catch ex As Exception

        End Try
    End Sub
    Public tagFind As String = ""
    Private Sub btnFindTagScaffold_Click(sender As Object, e As EventArgs) Handles btnFindTagScaffold.Click
        Try
            Dim FindSC As New FindTagScaffold
            AddOwnedForm(FindSC)
            FindSC.idclient = If(lblCompanyName.Text = "Client: All", "ALL", IdCliente)
            FindSC.OpenWindow = "Sccaffold"
            FindSC.ShowDialog()
            If tagFind <> "" Then
                cargarDatosScaffold(tagFind)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnNextTag_Click(sender As Object, e As EventArgs) Handles btnNextTag.Click
        Try
            If tblProductScaffoldAux.Rows IsNot Nothing Then
                'If DialogResult.Yes = MessageBox.Show("If you made any changes it will not be saved, are you sure to continue?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) Then
                mtdScaffold.llenarScaffold(tblScaffoldTags, If(lblCompanyName.Text = "Client: All", "", IdCliente))
                Dim count = 0
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
                    ElseIf (count + 1) = tblScaffoldTags.Rows.Count() Then
                        cargarDatosScaffold(tblScaffoldTags.Rows(0).ItemArray(0))
                    Else
                        cargarDatosScaffold(tblScaffoldTags.Rows(count + 1).ItemArray(0))
                    End If
                    'If tblScaffoldTags.Rows.Count < count Then
                    '    cargarDatosScaffold(tblScaffoldTags.Rows(count).ItemArray(0))
                    'Else
                    '    cargarDatosScaffold(tblScaffoldTags.Rows(count - 1).ItemArray(0))
                    'End If

                End If
                'End If
            End If
            selectedTable = "tag"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnDeleteRowScaffoldLeg_Click(sender As Object, e As EventArgs) Handles btnDeleteRowScaffoldLeg.Click
        If DialogResult.Yes = MessageBox.Show("The selected rows will be removed from the 'PRODUCTS TABLE'. Are you sure to do it?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) Then

            If mtdScaffold.deleteRowsProductScaffold(tblProductosScaffold, sc.tag, sc.job) Then
                For Each row As DataGridViewRow In tblProductosScaffold.SelectedRows()
                    If Not row.IsNewRow Then
                        tblProductosScaffold.Rows.Remove(row)
                    End If
                Next
                sc.llenarTablaProductTag(sc.tag)
                sc.llenarProductTotalScaffold(sc.tag)
                ValidarFilasLeg(tblLeg, tblProductosScaffold, True)
                mtdScaffold.llenarProduct(tblProductosAux)
            Else
                MessageBox.Show("Probably one of the selected row wasn't saved before to delete ", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                sc.llenarTablaProductTag(sc.tag)
                If sc.products.Rows.Count > 0 Then
                    tblProductosScaffold.Rows.Clear()
                    For Each row As Data.DataRow In sc.products.Rows()
                        tblProductosScaffold.Rows.Add(row("idProductScaffold"), row("idProduct"), row("QTY"), row("description"), row("stock"))
                    Next
                Else
                    tblProductosScaffold.Rows.Clear()
                End If
                sc.products = sc.llenarTablaProduct(tblProductosScaffold)
                sc.llenarProductTotalScaffold(sc.tag)
                Dim plf = ValidarFilasLeg(tblLeg, tblProductosScaffold, True)
                lblPLF.Text = plf(0)
                lblPSQF.Text = plf(1)
                mtdScaffold.llenarProduct(tblProductosAux)
            End If
        End If
    End Sub

    Private Sub btnNewTag_Click(sender As Object, e As EventArgs) Handles btnNewTag.Click
        If sc.tag <> "" Then
            If DialogResult.Yes = MessageBox.Show("If you made any changes it will not be saved, are you sure to continue?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) Then
                sc.Clear()
                cargarDatosScaffold("")
                selectedTable = "tag"
            End If
        End If
    End Sub

    Private Function activarCamposModificacion(ByVal status As Boolean) As Boolean
        Try
            txtModificationID.ReadOnly = status
            cmbTagScaffold.Enabled = If(status, False, True)

            cmbReqCompany.Enabled = If(status, False, True)
            cmbRequestBY.Enabled = If(status, False, True)
            cmbForemanModification.Enabled = If(status, False, True)
            cmbErectorModification.Enabled = If(status, False, True)
            txtCommentsModification.ReadOnly = status
            dtpModificationDate.Enabled = If(status, False, True)

            tblScaffoldInformationSM.ReadOnly = status

            tblActivityHoursSM.ReadOnly = status

            chbTruckMS.Enabled = If(status, False, True)
            chbForkliftM.Enabled = If(status, False, True)
            chbTrailerM.Enabled = If(status, False, True)
            chbCraneM.Enabled = If(status, False, True)
            chbRopeM.Enabled = If(status, False, True)
            chbPassedM.Enabled = If(status, False, True)
            chbElevtrM.Enabled = If(status, False, True)

            tblScaffoldTotalProductMS.ReadOnly = status

            tblModificationProductMS.ReadOnly = status
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function cargarDatosModification(ByVal modAux As String) As Boolean
        Try
            If md.ModAux <> modAux Then
                md.ModAux = modAux
            End If
            loadingDataModification = True
            txtModificationID.Text = md.ModID
            txtModificationID.Enabled = If(md.ModID = "", True, False)
            cmbTagScaffold.SelectedItem = md.tag
            cmbTagScaffold.Text = md.tag
            If md.tag = "" Then
                txtWOModification.Text = ""
                cmbTagScaffold.Enabled = True
            Else
                cmbTagScaffold.Enabled = False
                mtdScaffold.llenarScaffold(tblScaffoldTags, IdCliente)
                For Each row As DataRow In tblScaffoldTags.Rows()
                    If cmbTagScaffold.SelectedItem = row.ItemArray(0) Then
                        txtWOModification.Text = row.ItemArray(5)
                    End If
                Next
            End If
            cmbReqCompany.SelectedItem = md.reqCompany
            cmbReqCompany.Text = md.reqCompany
            cmbRequestBY.SelectedItem = md.requestBy
            cmbRequestBY.Text = md.requestBy
            cmbForemanModification.SelectedItem = md.foreman
            cmbForemanModification.Text = md.foreman
            cmbErectorModification.SelectedItem = md.erector
            cmbErectorModification.Text = md.erector
            txtCommentsModification.Text = md.comments
            dtpModificationDate.Value = md.ModDate

            If md.idScaffoldinformation <> "" Then
                tblScaffoldInformationSM.Rows(0).Cells("Type").Value = md.sciType
                tblScaffoldInformationSM.Rows(0).Cells("Width").Value = CStr(md.sciWidth)
                tblScaffoldInformationSM.Rows(0).Cells("Length").Value = CStr(md.sciLength)
                tblScaffoldInformationSM.Rows(0).Cells("Heigth").Value = CStr(md.sciHeigth)
                tblScaffoldInformationSM.Rows(0).Cells("Decks").Value = CStr(md.sciDecks)
                tblScaffoldInformationSM.Rows(0).Cells("KOs").Value = CStr(md.sciKo)
                tblScaffoldInformationSM.Rows(0).Cells("Base").Value = CStr(md.sciBase)
            Else
                'tblScaffoldInformation.Rows(0).Cells("clmType").Value = sc.sciType
                tblScaffoldInformationSM.Rows(0).Cells("Width").Value = "0"
                tblScaffoldInformationSM.Rows(0).Cells("Length").Value = "0"
                tblScaffoldInformationSM.Rows(0).Cells("Heigth").Value = "0"
                tblScaffoldInformationSM.Rows(0).Cells("Decks").Value = "0"
                tblScaffoldInformationSM.Rows(0).Cells("KOs").Value = "0"
                tblScaffoldInformationSM.Rows(0).Cells("Base").Value = "0"
            End If
            If md.ahrIdActivityHours <> "" Then
                tblActivityHoursSM.Rows(0).Cells("Build").Value = CStr(md.ahrBuild)
                tblActivityHoursSM.Rows(0).Cells("Martl").Value = CStr(md.ahrMaterial)
                tblActivityHoursSM.Rows(0).Cells("Travl").Value = CStr(md.ahrTravel)
                tblActivityHoursSM.Rows(0).Cells("Wthr").Value = CStr(md.ahrWeather)
                tblActivityHoursSM.Rows(0).Cells("Alarm").Value = CStr(md.ahrAlarm)
                tblActivityHoursSM.Rows(0).Cells("Safty").Value = CStr(md.ahrSafety)
                tblActivityHoursSM.Rows(0).Cells("StdBy").Value = CStr(md.ahrStdBy)
                tblActivityHoursSM.Rows(0).Cells("Other").Value = CStr(md.ahrOther)
                tblActivityHoursSM.Rows(0).Cells("ToHrs").Value = CStr(md.ahrTotal)
            Else
                tblActivityHoursSM.Rows(0).Cells("Build").Value = "0"
                tblActivityHoursSM.Rows(0).Cells("Martl").Value = "0"
                tblActivityHoursSM.Rows(0).Cells("Travl").Value = "0"
                tblActivityHoursSM.Rows(0).Cells("Wthr").Value = "0"
                tblActivityHoursSM.Rows(0).Cells("Alarm").Value = "0"
                tblActivityHoursSM.Rows(0).Cells("Safty").Value = "0"
                tblActivityHoursSM.Rows(0).Cells("StdBy").Value = "0"
                tblActivityHoursSM.Rows(0).Cells("Other").Value = "0"
                tblActivityHoursSM.Rows(0).Cells("ToHrs").Value = "0"
            End If
            If md.idMaterialHandeling <> "" And md.materialHandeling.Length > 0 Then
                chbTruckMS.Checked = md.materialHandeling(0)
                chbForkliftM.Checked = md.materialHandeling(1)
                chbTrailerM.Checked = md.materialHandeling(2)
                chbCraneM.Checked = md.materialHandeling(3)
                chbRopeM.Checked = md.materialHandeling(4)
                chbPassedM.Checked = md.materialHandeling(5)
                chbElevtrM.Checked = md.materialHandeling(6)
            Else
                chbTruckMS.Checked = False
                chbForkliftM.Checked = False
                chbTrailerM.Checked = False
                chbCraneM.Checked = False
                chbRopeM.Checked = False
                chbPassedM.Checked = False
                chbElevtrM.Checked = False
            End If
            tblScaffoldTotalProductMS.Rows.Clear()
            md.llenarTablaProductTag(md.tag)
            For Each row As DataRow In md.productsSC.Rows()
                tblScaffoldTotalProductMS.Rows.Add(row.ItemArray(2), row.ItemArray(1))
            Next
            lblTotalQTYProductMS.Text = totalProductScaffoldQTY(tblScaffoldTotalProductMS, 1)
            Dim plf = ValidarFilasLeg(tblLegMS, tblScaffoldTotalProductMS, False)
            lblPLFM.Text = plf(0)
            lblPSQFM.Text = plf(1)
            tblModificationProductMS.Rows.Clear()
            md.llenarTablaProductMod(md.ModAux, md.tag)
            For Each row As DataRow In md.productsAdds.Rows()
                tblModificationProductMS.Rows.Add(row.ItemArray(0), row.ItemArray(1), row.ItemArray(2), row.ItemArray(3), row.ItemArray(4))
            Next
            activarCamposModificacion(md.status)
            loadingDataModification = False
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub cmbTagScaffold_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbTagScaffold.SelectedValueChanged
        If loadingDataModification = False Then
            For Each row As DataRow In tblScaffoldTags.Rows()
                If cmbTagScaffold.SelectedItem = row.ItemArray(0) Then
                    If txtModificationID.Text <> "" Then
                        For Each row1 As Data.DataRow In tblModification.Rows
                            If txtModificationID.Text = row1.ItemArray(1) And cmbTagScaffold.SelectedItem = row1.ItemArray(5) Then
                                If DialogResult.Yes = MessageBox.Show("Now this Mod ID is inserted. Would you like to generate a new one?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error) Then
                                    txtModificationID.Text = mtdScaffold.selectMaxModId(cmbTagScaffold.SelectedItem)
                                Else
                                    txtModificationID.Text = ""
                                End If
                            End If
                        Next
                    End If
                    txtWOModification.Text = row.ItemArray(5)
                    md.tag = cmbTagScaffold.SelectedItem
                    md.llenarTablaProductTag(md.tag)
                    tblScaffoldTotalProductMS.Rows.Clear()
                    For Each row1 As DataRow In md.productsSC.Rows()
                        tblScaffoldTotalProductMS.Rows.Add(row1.ItemArray(2), row1.ItemArray(1))
                    Next
                    Dim scAux As New scaffold
                    scAux = mtdScaffold.llenarScaffold(md.tag)
                    tblScaffoldInformationSM.ReadOnly = False
                    tblScaffoldInformationSM.Rows.Clear()
                    tblScaffoldInformationSM.Rows().Add(scAux.sciType, sc.sciWidth, sc.sciLength, sc.sciHeigth, sc.sciDecks, sc.sciKo, sc.sciBase, sc.sciExtraDeck)
                    md.idScaffoldinformation = scAux.idScaffoldinformation
                    md.sciType = scAux.sciType
                    md.sciWidth = scAux.sciWidth
                    md.sciLength = scAux.sciHeigth
                    md.sciDecks = scAux.sciDecks
                    md.sciKo = scAux.sciKo
                    md.sciBase = scAux.sciBase
                    md.sciExtraDeck = scAux.sciExtraDeck
                    tblScaffoldInformationSM.ReadOnly = True
                End If
            Next
            selectedTable = "Mod"
        End If
    End Sub

    Private Sub txtModificationID_TextChanged(sender As Object, e As EventArgs) Handles txtModificationID.TextChanged
        If loadingDataModification = False Then
            If cmbTagScaffold.Text <> "" Then
                For Each row As Data.DataRow In tblModification.Rows
                    If txtModificationID.Text = row.ItemArray(1) And cmbTagScaffold.SelectedItem = row.ItemArray(5) Then
                        If DialogResult.Yes = MessageBox.Show("Now this Mod ID is inserted. Would you like to generate a new one?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error) Then
                            txtModificationID.Text = mtdScaffold.selectMaxModId(cmbTagScaffold.SelectedItem)
                        Else
                            txtModificationID.Text = ""
                        End If
                    End If
                Next
            End If
        End If
        md.ModID = txtModificationID.Text
        selectedTable = "Mod"
    End Sub

    Private Sub cmbReqCompany_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbReqCompany.TextChanged, cmbReqCompany.SelectedIndexChanged
        If cmbReqCompany.SelectedItem <> Nothing Then
            md.reqCompany = cmbReqCompany.SelectedItem
        Else
            md.reqCompany = cmbReqCompany.Text
        End If
        selectedTable = "Mod"
    End Sub

    Private Sub cmbRequestBY_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbRequestBY.TextChanged, cmbRequestBY.SelectedValueChanged
        If cmbRequestBY.SelectedItem <> Nothing Then
            md.requestBy = cmbRequestBY.SelectedItem
        Else
            md.requestBy = cmbRequestBY.Text
        End If
        selectedTable = "Mod"
    End Sub

    Private Sub cmbForemanModification_TextChanged(sender As Object, e As EventArgs) Handles cmbForemanModification.TextChanged, cmbForemanModification.SelectedValueChanged
        If cmbForemanModification.SelectedItem <> Nothing Then
            md.foreman = cmbForemanModification.SelectedItem
        Else
            md.foreman = cmbForemanModification.Text
        End If
        selectedTable = "Mod"
    End Sub

    Private Sub cmbErectorModification_TextChanged(sender As Object, e As EventArgs) Handles cmbErectorModification.TextChanged, cmbErectorModification.SelectedValueChanged
        If cmbErectorModification.SelectedItem <> Nothing Then
            md.erector = cmbErectorModification.SelectedItem
        Else
            md.erector = cmbErectorModification.Text
        End If
        selectedTable = "Mod"
    End Sub

    Private Sub txtCommentsModification_TextChanged(sender As Object, e As EventArgs) Handles txtCommentsModification.TextChanged
        md.comments = txtCommentsModification.Text
        selectedTable = "Mod"
    End Sub

    Private Sub chbTruckMS_CheckedChanged(sender As Object, e As EventArgs) Handles chbTruckMS.CheckedChanged, chbTrailerM.CheckedChanged, chbRopeM.CheckedChanged, chbPassedM.CheckedChanged, chbForkliftM.CheckedChanged, chbElevtrM.CheckedChanged, chbCraneM.CheckedChanged
        Try
            If loadingDataModification = False Then
                selectedTable = "Mod"
                If chbTruckMS.Checked Then
                    md.materialHandeling(0) = True
                Else
                    md.materialHandeling(0) = False
                End If
                If chbTrailerM.Checked Then
                    md.materialHandeling(1) = True
                Else
                    md.materialHandeling(1) = False
                End If
                If chbRopeM.Checked Then
                    md.materialHandeling(2) = True
                Else
                    md.materialHandeling(2) = False
                End If
                If chbPassedM.Checked Then
                    md.materialHandeling(3) = True
                Else
                    md.materialHandeling(3) = False
                End If
                If chbForkliftM.Checked Then
                    md.materialHandeling(4) = True
                Else
                    md.materialHandeling(4) = False
                End If
                If chbElevtrM.Checked Then
                    md.materialHandeling(5) = True
                Else
                    md.materialHandeling(5) = False
                End If
                If chbCraneM.Checked Then
                    md.materialHandeling(6) = True
                Else
                    md.materialHandeling(6) = False
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tblScaffoldInformationSM_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles tblScaffoldInformationSM.CellEndEdit
        Try
            If e.ColumnIndex > 0 Then
                If tblScaffoldInformationSM.Rows(0).Cells(e.ColumnIndex).Value <> "" And soloNumero(tblScaffoldInformationSM.Rows(0).Cells(e.ColumnIndex).Value.ToString()) Then
                    md.sciType = If(tblScaffoldInformationSM.Rows(0).Cells("Type").Value <> "", CStr(tblScaffoldInformationSM.Rows(0).Cells("Type").Value), "")
                    md.sciWidth = If(tblScaffoldInformationSM.Rows(0).Cells("Width").Value <> "", CDbl(tblScaffoldInformationSM.Rows(0).Cells("Width").Value), 0)
                    md.sciLength = If(tblScaffoldInformationSM.Rows(0).Cells("Length").Value <> "", CDbl(tblScaffoldInformationSM.Rows(0).Cells("Length").Value), 0)
                    md.sciHeigth = If(tblScaffoldInformationSM.Rows(0).Cells("Heigth").Value <> "", CDbl(tblScaffoldInformationSM.Rows(0).Cells("Heigth").Value), 0)
                    md.sciDecks = If(tblScaffoldInformationSM.Rows(0).Cells("Decks").Value <> "", CDbl(tblScaffoldInformationSM.Rows(0).Cells("Decks").Value), 0)
                    md.sciKo = If(tblScaffoldInformationSM.Rows(0).Cells("KOs").Value <> "", CDbl(tblScaffoldInformationSM.Rows(0).Cells("KOs").Value), 0)
                    md.sciBase = If(tblScaffoldInformationSM.Rows(0).Cells("Base").Value <> "", CDbl(tblScaffoldInformationSM.Rows(0).Cells("Base").Value), 0)
                Else
                    tblScaffoldInformationSM.Rows(0).Cells(e.ColumnIndex).Value = "0"
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Private Sub tblActivityHoursSM_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles tblActivityHoursSM.CellEndEdit
        Try
            If e.ColumnIndex <> tblActivityHoursSM.Columns("ToHrs").Index Then
                If tblActivityHoursSM.Rows(0).Cells(e.ColumnIndex).Value <> "" And soloNumero(tblActivityHoursSM.Rows(0).Cells(e.ColumnIndex).Value.ToString()) Then
                    md.ahrBuild = If(tblActivityHoursSM.Rows(0).Cells("Build").Value <> "", CDbl(tblActivityHoursSM.Rows(0).Cells("Build").Value), 0)
                    md.ahrMaterial = If(tblActivityHoursSM.Rows(0).Cells("Martl").Value <> "", CDbl(tblActivityHoursSM.Rows(0).Cells("Martl").Value), 0)
                    md.ahrTravel = If(tblActivityHoursSM.Rows(0).Cells("Travl").Value <> "", CDbl(tblActivityHoursSM.Rows(0).Cells("Travl").Value), 0)
                    md.ahrWeather = If(tblActivityHoursSM.Rows(0).Cells("Wthr").Value <> "", CDbl(tblActivityHoursSM.Rows(0).Cells("Wthr").Value), 0)
                    md.ahrAlarm = If(tblActivityHoursSM.Rows(0).Cells("Alarm").Value <> "", CDbl(tblActivityHoursSM.Rows(0).Cells("Alarm").Value), 0)
                    md.ahrSafety = If(tblActivityHoursSM.Rows(0).Cells("Safty").Value <> "", CDbl(tblActivityHoursSM.Rows(0).Cells("Safty").Value), 0)
                    md.ahrStdBy = If(tblActivityHoursSM.Rows(0).Cells("StdBy").Value <> "", CDbl(tblActivityHoursSM.Rows(0).Cells("StdBy").Value), 0)
                    md.ahrOther = If(tblActivityHoursSM.Rows(0).Cells("Other").Value <> "", CDbl(tblActivityHoursSM.Rows(0).Cells("Other").Value), 0)
                    md.ahrTotal = If(tblActivityHoursSM.Rows(0).Cells("ToHrs").Value <> "", CDbl(tblActivityHoursSM.Rows(0).Cells("ToHrs").Value), 0)
                Else
                    tblActivityHoursSM.Rows(0).Cells(e.ColumnIndex).Value = "0"
                End If
                Dim totalHours As Double = 0
                For Each cell As DataGridViewCell In tblActivityHoursSM.Rows(0).Cells()
                    If cell.Value.ToString() <> "" And cell.ColumnIndex < 8 Then
                        totalHours = totalHours + CDbl(cell.Value.ToString())
                    End If
                Next
                tblActivityHoursSM.Rows(0).Cells("ToHrs").Value = CStr(totalHours)
                md.ahrTotal = totalHours
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub tblModificationProductMS_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles tblModificationProductMS.CellClick
        selectedTable = tblModificationProductMS.Name
        If e.ColumnIndex = 1 Then
            Try
                If tblModificationProductMS.CurrentCell.GetType.Name = "DataGridViewTextBoxCell" Then
                    If cmbTagScaffold.SelectedIndex > -1 Then

                        Dim cmbPd As New DataGridViewComboBoxCell
                        With cmbPd
                            mtdScaffold.llenarCellComboIDProduct(cmbPd, tblProductScaffoldAux, mtdScaffold.selectJobBytag(cmbTagScaffold.Items(cmbTagScaffold.SelectedIndex)))
                            cmbPd.DropDownWidth = 260
                        End With
                        If tblModificationProductMS.CurrentRow.Cells(1).Value IsNot Nothing Then
                            For Each row As Data.DataRow In tblProductScaffoldAux.Rows()
                                If row.ItemArray(1) = tblModificationProductMS.CurrentRow.Cells(1).Value Then
                                    cmbPd.Value = row.ItemArray(0)
                                End If
                            Next
                        End If
                        tblModificationProductMS.CurrentRow.Cells(1) = cmbPd
                    Else
                        MessageBox.Show("Please select a tag.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub
    Private Sub tblModificationProductMS_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles tblModificationProductMS.EditingControlShowing
        Dim Index = tblModificationProductMS.CurrentCell.ColumnIndex
        If Index = 1 Then
            If tblModificationProductMS.CurrentCell.GetType.Name = "DataGridViewComboBoxCell" Then
                Dim cb As ComboBox = CType(e.Control, ComboBox)
                If e.Control IsNot Nothing Then
                    RemoveHandler cb.SelectedIndexChanged, AddressOf cmb_SelectedIndexChangueProductScaffoldMD
                    AddHandler cb.SelectedIndexChanged, AddressOf cmb_SelectedIndexChangueProductScaffoldMD
                End If
            End If
        End If
    End Sub

    Private Sub btnNewModification_Click(sender As Object, e As EventArgs) Handles btnNewModification.Click
        md.Clear()
        cargarDatosModification("")

    End Sub
    Private Sub tblModificationProductMS_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles tblModificationProductMS.CellEndEdit
        If e.ColumnIndex = 2 Then
            Dim qty = If(tblModificationProductMS.Rows(e.RowIndex).Cells("clmQTYM").Value IsNot Nothing, tblModificationProductMS.Rows(e.RowIndex).Cells("clmQTYM").Value, 0.0)
            Dim stock = If(tblModificationProductMS.Rows(e.RowIndex).Cells("clmStockProductM").Value IsNot Nothing, tblModificationProductMS.Rows(e.RowIndex).Cells("clmStockProductM").Value, "")
            Dim newMP = If(tblModificationProductMS.Rows(e.RowIndex).Cells("idProductM").Value IsNot Nothing Or tblModificationProductMS.Rows(e.RowIndex).Cells("idProductM").Value <> "", False, True)
            If stock <> "" Then
                Dim lastQty = "0"
                Dim array() = tblModificationProductMS.Rows(e.RowIndex).Cells(1).Value.ToString.Split(" ")
                Dim idPD = array(0)
                For Each row As DataRow In md.productsAdds.Rows()
                    If idPD = row.ItemArray(1) Then
                        lastQty = row.ItemArray(2)
                        stock = CDbl(stock) + If(CDbl(row.ItemArray(2) = ""), 0, row.ItemArray(2))
                        Exit For
                    End If
                Next
                If qty IsNot Nothing And soloNumero(qty.ToString()) Then
                    If CDbl(qty) > 0 Then 'validar que no exeda el stock
                        If CDbl(qty) > stock Then
                            MessageBox.Show("You only have " + stock.ToString + " in sotck.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            tblModificationProductMS.Rows(e.RowIndex).Cells("clmQTYM").Value = lastQty
                        End If
                    ElseIf CDbl(qty) < 0 Then 'validar que no exeda la cantidad ya insertada
                        Dim MaxValueDelete As Double = 0.0
                        Dim isInserted As Boolean = False
                        For Each rowT As DataGridViewRow In tblScaffoldTotalProductMS.Rows()
                            If idPD = rowT.Cells(0).Value Then
                                MaxValueDelete = rowT.Cells(1).Value
                                isInserted = True
                                Exit For
                            End If
                        Next
                        If isInserted Then 'tiene que se menor al valor total del product total scaffold

                            If newMP Then
                                If MaxValueDelete < (CDbl(qty) * -1) Then
                                    MessageBox.Show("It probably exceeds the quantity on the Scaffold Product List.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    tblModificationProductMS.Rows(e.RowIndex).Cells("clmQTYM").Value = lastQty
                                End If
                            Else
                                If (MaxValueDelete + If(CDbl(lastQty) < 0, CDbl(lastQty) * -1, CDbl(lastQty))) < (CDbl(qty) * -1) Then
                                    MessageBox.Show("It probably exceeds the quantity on the Scaffold Product List.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    tblModificationProductMS.Rows(e.RowIndex).Cells("clmQTYM").Value = lastQty
                                End If
                            End If
                            'If (MaxValueDelete + If(CDbl(lastQty) < 0, CDbl(lastQty) * -1, CDbl(lastQty))) <= (CDbl(qty) * -1) Then
                            '    MessageBox.Show("It probably exceeds the quantity on the Scaffold Product List.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            '    tblModificationProductMS.Rows(e.RowIndex).Cells("clmQTYM").Value = lastQty
                            'End If
                        Else 'No puede ser negativo
                            MessageBox.Show("The quantity it can be negatitive.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            tblModificationProductMS.Rows(e.RowIndex).Cells("clmQTYM").Value = lastQty
                        End If
                    End If
                End If
                md.productsAdds.Clear()
                For Each row As DataGridViewRow In tblModificationProductMS.Rows()
                    If row.Cells(1).Value IsNot Nothing Or row.Cells(2).Value IsNot Nothing Then
                        Dim array1() = row.Cells("clmIDProductM").Value.ToString.Split("   ")
                        Dim idPDAdd = array1(0)
                        md.productsAdds.Rows.Add(If(row.Cells("idProductM").Value Is Nothing, "", idPDAdd), If(row.Cells("clmIDProductM").Value Is Nothing, "", row.Cells("clmIDProductM").Value), If(row.Cells("clmQTYM").Value Is Nothing, "", row.Cells("clmQTYM").Value), If(row.Cells("clmDescriptionM").Value Is Nothing, "", row.Cells("clmDescriptionM").Value), If(row.Cells("clmStockProductM").Value Is Nothing, "", row.Cells("clmStockProductM").Value))
                    End If
                Next
            Else
                MessageBox.Show("First choose a product to try to compare the product stock.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Information)
                tblModificationProductMS.Rows.Remove(tblModificationProductMS.Rows(e.RowIndex))
            End If
        ElseIf e.ColumnIndex = 1 Then
            md.productsAdds.Clear()
            For Each row As DataGridViewRow In tblModificationProductMS.Rows()
                If row.Cells(1).Value IsNot Nothing Or row.Cells(2).Value IsNot Nothing Then
                    Dim array1() = row.Cells("clmIDProductM").Value.ToString.Split("   ")
                    Dim idPDAdd = array1(0)
                    md.productsAdds.Rows.Add(If(row.Cells("idProductM").Value Is Nothing, "", row.Cells("idProductM").Value), If(row.Cells("clmIDProductM").Value Is Nothing, "", idPDAdd), If(row.Cells("clmQTYM").Value Is Nothing, "", row.Cells("clmQTYM").Value), If(row.Cells("clmDescriptionM").Value Is Nothing, "", row.Cells("clmDescriptionM").Value), If(row.Cells("clmStockProductM").Value Is Nothing, "", row.Cells("clmStockProductM").Value))
                End If
            Next
        End If
    End Sub

    Private Sub btnRefreshProduct_Click(sender As Object, e As EventArgs) Handles btnRefreshProduct.Click
        cargarDatosScaffold(sc.tag)
    End Sub

    Private Function totalProductScaffoldQTY(ByVal tabla As DataGridView, ByVal indexColumbQTY As Integer) As String
        Dim total As Double = 0.0
        For Each row As DataGridViewRow In tabla.Rows()
            If row.Cells(indexColumbQTY).Value IsNot Nothing Or row.Cells(indexColumbQTY).Value <> "" Then
                total = total + CDbl(row.Cells(indexColumbQTY).Value)
            End If
        Next
        Return total.ToString()
    End Function

    Private Sub btnDeleteRowM_Click(sender As Object, e As EventArgs) Handles btnDeleteRowM.Click
        Try
            If mtdScaffold.deleteRowsProductModification(tblModificationProductMS, md.tag, md.ModAux) Then
                For Each row As DataGridViewRow In tblModificationProductMS.SelectedRows()
                    tblModificationProductMS.Rows.Remove(row)
                Next
                md.llenarTablaProductMod(md.ModID, md.tag)
                tblScaffoldTotalProductMS.Rows.Clear()
                md.llenarTablaProductTag(md.tag)
                For Each row As DataRow In md.productsSC.Rows()
                    tblScaffoldTotalProductMS.Rows.Add(row.ItemArray(2), row.ItemArray(1))
                Next
                Dim plf = ValidarFilasLeg(tblLegMS, tblScaffoldTotalProductMS, False)
                lblPLFM.Text = plf(0)
                lblPSQFM.Text = plf(1)
                mtdScaffold.llenarProduct(tblProductosAux)
            Else
                MessageBox.Show("Probably one of the selected row wasn't saved before to delete ", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                md.llenarTablaProductMod(md.ModID, md.tag)
                If md.productsAdds.Rows.Count > 0 Then
                    tblModificationProductMS.Rows.Clear()
                    For Each row As Data.DataRow In md.productsAdds.Rows()
                        tblModificationProductMS.Rows.Add(row("idModification"), row("idProduct"), row("QTY"), row("description"), row("stock"))
                    Next
                Else
                    tblModificationProductMS.Rows.Clear()
                End If
                md.llenarTablaProductTag(md.tag)
                For Each row As DataRow In md.productsSC.Rows()
                    tblScaffoldTotalProductMS.Rows.Add(row.ItemArray(2), row.ItemArray(1))
                Next
                Dim plf = ValidarFilasLeg(tblLegMS, tblScaffoldTotalProductMS, False)
                lblPLFM.Text = plf(0)
                lblPSQFM.Text = plf(1)
                mtdScaffold.llenarProduct(tblProductosAux)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnRefreshTPSM_Click(sender As Object, e As EventArgs) Handles btnRefreshTPSM.Click
        tblScaffoldInformationSM.Rows(0).SetValues("", "", "", "", "", "", "", "")
        Dim cmbProyect1 As New DataGridViewComboBoxCell
        With cmbProyect1
            mtdScaffold.llenarRentaTypeCombo(cmbProyect1)
        End With
        tblScaffoldInformationSM.Rows(0).Cells(0) = cmbProyect1
        tblActivityHoursSM.Rows(0).SetValues("", "", "", "", "", "", "", "", "")
        tblActivityHoursSM.Rows(0).Cells("ToHrs").ReadOnly = True
        tblActivityHoursSM.Rows(0).Cells("ToHrs").Style.BackColor = Color.Green
        mtdScaffold.llenarScaffold(tblScaffoldTags, IdCliente)
        If tblScaffoldTags.Rows.Count > 0 Then
            cmbTagScaffold.Items.Clear()
            For Each row As DataRow In tblScaffoldTags.Rows()
                cmbTagScaffold.Items.Add(row.ItemArray(0).ToString())
            Next
        End If
        mtdScaffold.llenarEmpleadosCombo(cmbForemanModification, tablaEmpleados)
        mtdScaffold.llenarEmpleadosCombo(cmbErectorModification, tablaEmpleados)
        mtdScaffold.llenarComboReqCompany(cmbReqCompany)
        mtdScaffold.llenarComboRequestBy(cmbRequestBY)
        If mtdScaffold.llenarModification(tblModification, IdCliente) Then
            If tblModification.Rows.Count > 0 Then
                md = mtdScaffold.llenarModificationData(md.ModAux, md.tag)
                If md.ModAux <> "" Then
                    cargarDatosModification(md.ModAux)
                Else
                    md = mtdScaffold.llenarModificationData(tblModification.Rows(0).ItemArray(0), tblModification.Rows(0).ItemArray(5))
                    If md.ModAux <> "" Then
                        cargarDatosModification(md.ModAux)
                    End If
                End If
            Else
                md.Clear()
            End If
        End If
    End Sub

    Private Function cargarDatosDismantle(ByVal tag As String) As Boolean
        loadingDataDismentle = True
        If tag = "" Then
            clearDismantle()
            loadingDataDismentle = False
            Return True
        Else
            ds = mtdScaffold.llenarDismantleData(tag)
            If ds.idDismantle <> "" Then
                btnReportDismantled.Enabled = True
            Else
                btnReportDismantled.Enabled = False
            End If
            Dim scAux = mtdScaffold.llenarScaffold(tag)
            Dim dateAux As New Date(scAux.dateBild.Year, scAux.dateBild.Month, scAux.dateBild.Day)
            ds.scStartDate = dateAux

            If ds.tag <> "" Then
                Dim indexCmb = cmbTagDismantle.FindString(ds.tag)
                If indexCmb = -1 Then
                    cmbTagDismantle.Items.Add(ds.tag)
                End If
                cmbTagDismantle.SelectedItem = cmbTagDismantle.Items(cmbTagDismantle.FindString(ds.tag))
            End If
            If ds.wo = "" Then
                For Each rowTag As DataRow In tblScaffoldTags.Rows
                    If ds.tag = rowTag.ItemArray(0) Then
                        ds.wo = rowTag.ItemArray(5)
                        txtWODismantle.Text = rowTag.ItemArray(5)
                        Exit For
                    End If
                Next
            Else
                txtWODismantle.Text = ds.wo
            End If
            txtCommentDismantle.Text = ds.comments
            mtdScaffold.llenarComboRequestBy(cmbRequestByDismantle)
            If cmbRequestByDismantle.FindString(ds.requestBy) > -1 Then
                cmbRequestByDismantle.Text = ds.requestBy
                cmbRequestByDismantle.SelectedItem = cmbRequestByDismantle.Items(cmbRequestByDismantle.FindString(ds.requestBy))
            Else
                cmbRequestByDismantle.Text = ds.requestBy
            End If

            mtdScaffold.llenarComboReqCompany(cmbReqCompanyDismantle)
            If cmbReqCompanyDismantle.FindString(ds.reqCompany) > -1 Then
                cmbReqCompanyDismantle.Text = ds.reqCompany
                cmbReqCompanyDismantle.SelectedItem = cmbReqCompanyDismantle.Items(cmbReqCompanyDismantle.FindString(ds.reqCompany))
            Else
                cmbReqCompanyDismantle.Text = ds.reqCompany
            End If
            mtdScaffold.llenarEmpleadosCombo(cmbForemanDismantle, tablaEmpleados)
            If cmbForemanDismantle.FindString(ds.foreman) > -1 Then
                cmbForemanDismantle.Text = ds.foreman
                cmbForemanDismantle.SelectedItem = cmbForemanDismantle.Items(cmbForemanDismantle.FindString(ds.foreman))
                If ds.foreman = "" Then
                    cmbForemanDismantle.SelectedItem = Nothing
                End If
            Else
                cmbForemanDismantle.Text = ds.foreman
                If ds.foreman = "" Then
                    cmbForemanDismantle.SelectedValue = Nothing
                End If
            End If
            mtdScaffold.llenarEmpleadosCombo(cmbErectorDismantle, tablaEmpleados)
            If cmbErectorDismantle.FindString(ds.erector) > -1 Then
                cmbErectorDismantle.Text = ds.erector
                cmbErectorDismantle.SelectedItem = cmbErectorDismantle.Items(cmbErectorDismantle.FindString(ds.erector))
                If ds.erector = "" Then
                    cmbErectorDismantle.SelectedItem = Nothing
                End If
            Else
                cmbErectorDismantle.Text = ds.erector
                If ds.erector = "" Then
                    cmbErectorDismantle.SelectedValue = Nothing
                End If
            End If
            dtpRentStop.Value = ds.stopDismantle
            dtpDismantleDate.Value = ds.dismantleDate

            If ds.stopDismantle <> Nothing Then
                Dim diferencia As Long = DateAndTime.DateDiff(DateInterval.Day, ds.scStartDate, ds.stopDismantle)
                txtDaysActive.Text = CStr(If(diferencia = 0, 1, diferencia))
            End If

            chbTruckDS.Checked = ds.materialHandeling(0)
            chbForkliftDS.Checked = ds.materialHandeling(1)
            chbTrailerDS.Checked = ds.materialHandeling(2)
            chbCraneDS.Checked = ds.materialHandeling(3)
            chbRopeDS.Checked = ds.materialHandeling(4)
            chbPassedDS.Checked = ds.materialHandeling(5)
            chbElevatorDS.Checked = ds.materialHandeling(6)

            tblActivityHoursDismantle.Rows(0).SetValues(If(ds.ahrIdActivityHours IsNot Nothing, ds.ahrIdActivityHours, "0"), If(ds.ahrDismantle <> Nothing, ds.ahrDismantle, "0"), If(ds.ahrMaterial <> Nothing, ds.ahrMaterial, "0"), If(ds.ahrTravel <> Nothing, ds.ahrTravel, "0"), If(ds.ahrWeather <> Nothing, ds.ahrWeather, "0"), If(ds.ahrAlarm <> Nothing, ds.ahrAlarm, "0"), If(ds.ahrSafety <> Nothing, ds.ahrSafety, "0"), If(ds.ahrStdBy <> Nothing, ds.ahrStdBy, "0"), If(ds.ahrOther <> Nothing, ds.ahrOther, "0"), If(ds.ahrTotal <> Nothing, ds.ahrTotal, "0"))
            tblTotalScaffoldProductDS.Rows.Clear()
            For Each row As DataRow In ds.prodcutsSC.Rows
                tblTotalScaffoldProductDS.Rows.Add(row("idProduct"), row("QTY"))
            Next
            tblDismantleProduct.Rows.Clear()
            For Each row As DataRow In ds.productsDS.Rows()
                tblDismantleProduct.Rows.Add(row("idProduct"), row("QTY"), row("Name"))
            Next
            loadingDataDismentle = False
        End If
        Return True
    End Function

    Private Sub clearDismantle()
        txtTag.Text = ""
        txtWODismantle.Text = ""
        txtCommentDismantle.Text = ""
        cmbRequestByDismantle.Text = ""
        cmbReqCompanyDismantle.SelectedValue = Nothing
        cmbReqCompanyDismantle.Text = ""
        cmbReqCompanyDismantle.SelectedValue = Nothing
        cmbForemanDismantle.Text = ""
        cmbForemanDismantle.SelectedValue = Nothing
        dtpRentStop.Value = System.DateTime.Today
        dtpDismantleDate.Value = System.DateTime.Today
        chbCraneDS.Checked = False
        chbElevatorDS.Checked = False
        chbForkliftDS.Checked = False
        chbPassedDS.Checked = False
        chbRopeDS.Checked = False
        chbTrailerDS.Checked = False
        chbTruckDS.Checked = False
        tblActivityHoursDismantle.Rows(0).SetValues("", "", "", "", "", "", "", "", "")
        tblTotalScaffoldProductDS.Rows.Clear()
        tblDismantleProduct.Rows.Clear()
    End Sub

    Private Sub tblActivityHoursDismantle_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles tblActivityHoursDismantle.CellEndEdit
        tblScaffoldTags.Rows.Clear()
        Try
            If e.ColumnIndex <> tblActivityHoursDismantle.Columns("clmTotalHD").Index Then
                If Not (tblActivityHoursDismantle.Rows(0).Cells(e.ColumnIndex).Value <> "" And soloNumero(tblActivityHoursDismantle.Rows(0).Cells(e.ColumnIndex).Value.ToString())) Then
                    tblActivityHoursDismantle.Rows(0).Cells(e.ColumnIndex).Value = "0"
                End If
                Dim totalHours As Double = 0
                For Each cell As DataGridViewCell In tblActivityHoursDismantle.Rows(0).Cells()
                    If cell.Value.ToString() <> "" And cell.ColumnIndex < 9 And cell.ColumnIndex > 0 Then
                        totalHours = totalHours + CDbl(cell.Value.ToString())
                    End If
                Next
                tblActivityHoursDismantle.Rows(0).Cells("clmTotalHD").Value = CStr(totalHours)
                ds.ahrDismantle = tblActivityHoursDismantle.Rows(0).Cells("clmDismentleD").Value()
                ds.ahrMaterial = tblActivityHoursDismantle.Rows(0).Cells("clmMablD").Value()
                ds.ahrTravel = tblActivityHoursDismantle.Rows(0).Cells("clmTravlD").Value()
                ds.ahrWeather = tblActivityHoursDismantle.Rows(0).Cells("clmWthrD").Value()
                ds.ahrAlarm = tblActivityHoursDismantle.Rows(0).Cells("clmAlarmD").Value()
                ds.ahrSafety = tblActivityHoursDismantle.Rows(0).Cells("clmSaftyD").Value()
                ds.ahrStdBy = tblActivityHoursDismantle.Rows(0).Cells("clmStdByD").Value()
                ds.ahrOther = tblActivityHoursDismantle.Rows(0).Cells("clmOthHD").Value()
                ds.ahrTotal = tblActivityHoursDismantle.Rows(0).Cells("clmTotalHD").Value()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnNextDismantle_Click(sender As Object, e As EventArgs) Handles btnNextDismantle.Click
        tblScaffoldTags.Rows.Clear()
        If mtdScaffold.llenarScaffold(tblScaffoldTags, If(lblCompanyName.Text = "Client: All", "", IdCliente)) Then
            If ds.tag = "" Then
                cargarDatosDismantle(tblScaffoldTags.Rows(0).ItemArray(0))
            Else
                Dim cont As Integer = 1
                For Each rowTag As DataRow In tblScaffoldTags.Rows
                    If ds.tag = rowTag.ItemArray(0) Then
                        If cont = tblScaffoldTags.Rows.Count() Then 'es la ultima fila 
                            cargarDatosDismantle(tblScaffoldTags.Rows(0).ItemArray(0))
                            Exit For
                        Else 'no es la ultima fila
                            cargarDatosDismantle(tblScaffoldTags.Rows(cont).ItemArray(0))
                            Exit For
                        End If
                    End If
                    cont += 1
                Next
            End If
        End If
    End Sub

    Private Sub btnBackDS_Click(sender As Object, e As EventArgs) Handles btnBackDS.Click
        tblScaffoldTags.Rows.Clear()
        If mtdScaffold.llenarScaffold(tblScaffoldTags, IdCliente) Then
            If ds.tag = "" Then
                cargarDatosDismantle(tblScaffoldTags.Rows(0).ItemArray(0))
            Else
                Dim cont As Integer = 1
                For Each rowTag As DataRow In tblScaffoldTags.Rows
                    If ds.tag = rowTag.ItemArray(0) Then
                        If cont = 1 Then 'es la primerfila
                            Dim ultimafila = (tblScaffoldTags.Rows.Count - 1)
                            cargarDatosDismantle(tblScaffoldTags.Rows(ultimafila).ItemArray(0))
                            Exit For
                        Else 'no es la ultima fila
                            cargarDatosDismantle(tblScaffoldTags.Rows(cont - 2).ItemArray(0))
                            Exit For
                        End If
                    End If
                    cont += 1
                Next
            End If
        End If
    End Sub
    Private Sub cmbTagDismantle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTagDismantle.SelectedIndexChanged
        If Not loadingDataDismentle Then
            Dim cont As Integer = 0
            For Each rowTag As DataRow In tblScaffoldTags.Rows
                If cmbTagDismantle.SelectedItem = rowTag.ItemArray(0) Then
                    cargarDatosDismantle(tblScaffoldTags.Rows(cont).ItemArray(0))
                    Exit For
                End If
                cont += 1
            Next
        End If
    End Sub
    Private Sub cmbTagDismantle_TextChanged(sender As Object, e As EventArgs) Handles cmbTagDismantle.TextChanged
        If Not loadingDataDismentle Then
            Dim cont As Integer = 0
            For Each rowTag As DataRow In tblScaffoldTags.Rows
                If cmbTagDismantle.Text = rowTag.ItemArray(0) Then
                    cargarDatosDismantle(tblScaffoldTags.Rows(cont).ItemArray(0))
                    Exit For
                End If
                cont += 1
            Next
        End If
    End Sub
    Private Sub txtCommentDismantle_TextChanged(sender As Object, e As EventArgs) Handles txtCommentDismantle.TextChanged
        If Not loadingDataDismentle Then
            ds.comments = txtCommentDismantle.Text
        End If
    End Sub
    Private Sub cmbReqCompanyDismantle_TextChanged(sender As Object, e As EventArgs) Handles cmbReqCompanyDismantle.TextChanged
        If Not loadingDataDismentle Then
            ds.reqCompany = cmbReqCompanyDismantle.Text
        End If
    End Sub

    Private Sub cmbForemanDismantle_TextChanged(sender As Object, e As EventArgs) Handles cmbForemanDismantle.TextChanged, cmbForemanDismantle.SelectedValueChanged
        If Not loadingDataDismentle Then
            ds.foreman = cmbForemanDismantle.Text
        End If
    End Sub

    Private Sub cmbErectorDismantle_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbErectorDismantle.SelectedValueChanged, cmbErectorDismantle.TextChanged
        If Not loadingDataDismentle Then
            ds.erector = cmbErectorDismantle.Text
        End If
    End Sub

    Private Sub cmbRequestByDismantle_TextChanged(sender As Object, e As EventArgs) Handles cmbRequestByDismantle.TextChanged
        If Not loadingDataDismentle Then
            ds.requestBy = cmbRequestByDismantle.Text
        End If
    End Sub

    Private Sub dtpRentStop_ValueChanged(sender As Object, e As EventArgs) Handles dtpRentStop.ValueChanged
        If loadingDataDismentle = False Then
            If ds.scStartDate <> Nothing Then
                If ds.scStartDate <= dtpRentStop.Value Then
                    Dim diferencia As Long = DateAndTime.DateDiff(DateInterval.Day, ds.scStartDate, dtpRentStop.Value)
                    txtDaysActive.Text = CStr(If(diferencia = 0, 1, diferencia))
                    ds.stopDismantle = dtpRentStop.Value
                    If ds.stopDismantle > ds.dismantleDate Then
                        dtpDismantleDate.Value = ds.stopDismantle
                        ds.dismantleDate = ds.stopDismantle
                    End If
                Else
                    MessageBox.Show("The selected Date is before than the Scaffold Start Date.  " + vbCrLf + "Start Date: " + validaFechaParaSQl(ds.scStartDate) + ".", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    dtpRentStop.Value = ds.stopDismantle
                End If
            End If
        End If
    End Sub

    Private Sub dtpDismantleDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpDismantleDate.ValueChanged
        If loadingDataDismentle = False Then
            If ds.stopDismantle <= dtpDismantleDate.Value Then
                ds.dismantleDate = dtpDismantleDate.Value
            Else
                MessageBox.Show("You cannot exceed the Dismantling date.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                dtpDismantleDate.Value = ds.dismantleDate
            End If
        End If
    End Sub

    Private Sub chbTruckDS_CheckedChanged(sender As Object, e As EventArgs) Handles chbTruckDS.CheckedChanged, chbTrailerDS.CheckedChanged, chbRopeDS.CheckedChanged, chbPassedDS.CheckedChanged, chbForkliftDS.CheckedChanged, chbElevatorDS.CheckedChanged, chbCraneDS.CheckedChanged
        If loadingDataDismentle = False Then
            ds.materialHandeling(0) = chbTruckDS.Checked()
            ds.materialHandeling(1) = chbForkliftDS.Checked()
            ds.materialHandeling(2) = chbTrailerDS.Checked()
            ds.materialHandeling(3) = chbCraneDS.Checked()
            ds.materialHandeling(4) = chbRopeDS.Checked()
            ds.materialHandeling(5) = chbPassedDS.Checked()
            ds.materialHandeling(6) = chbElevatorDS.Checked()
        End If
    End Sub
    Private Sub btnBackModification_Click(sender As Object, e As EventArgs) Handles btnBackModification.Click
        Try
            If mtdScaffold.llenarModification(tblModification, IdCliente) Then
                If tblModification.Rows.Count > 0 Then
                    Dim cont As Integer = 0
                    For Each rowMod As DataRow In tblModification.Rows
                        If md.ModID = rowMod.ItemArray(1) And md.tag And rowMod.ItemArray(5) Then
                            If cont = 0 Then 'es la primer fila 
                                Dim ultimafila = tblModification.Rows().Count()
                                md = mtdScaffold.llenarModificationData(tblModification.Rows(ultimafila - 1).ItemArray(0), tblModification.Rows(ultimafila - 1).ItemArray(5))
                                If md.ModID <> "" Then
                                    cargarDatosModification(md.ModAux)
                                End If
                                Exit For
                            Else 'no es la ultima fila
                                md = mtdScaffold.llenarModificationData(tblModification.Rows(cont - 1).ItemArray(0), tblModification.Rows(cont - 1).ItemArray(5))
                                cargarDatosModification(md.ModAux)
                                Exit For
                            End If
                        End If
                        cont += 1
                    Next
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnNextModification_Click(sender As Object, e As EventArgs) Handles btnNextModification.Click
        Try
            If mtdScaffold.llenarModification(tblModification, IdCliente) Then
                If tblModification.Rows.Count > 0 Then
                    Dim cont As Integer = 0
                    For Each rowMod As DataRow In tblModification.Rows
                        If md.ModID = rowMod.ItemArray(1) And md.tag = rowMod.ItemArray(5) Then
                            If cont = tblModification.Rows.Count() - 1 Then 'es la ultima fila 
                                md = mtdScaffold.llenarModificationData(tblModification.Rows(0).ItemArray(0), tblModification.Rows(0).ItemArray(5))
                                If md.ModID <> "" Then
                                    cargarDatosModification(md.ModAux)
                                End If
                                Exit For
                            Else 'no es la ultima fila
                                md = mtdScaffold.llenarModificationData(tblModification.Rows(cont + 1).ItemArray(0), tblModification.Rows(cont + 1).ItemArray(5))
                                cargarDatosModification(md.ModAux)
                                Exit For
                            End If
                        ElseIf md.ModID = "" Then
                            md = mtdScaffold.llenarModificationData(tblModification.Rows(0).ItemArray(0), tblModification.Rows(0).ItemArray(5))
                            cargarDatosModification(md.ModAux)
                        End If
                        cont += 1
                    Next
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnExcelScaffold_Click(sender As Object, e As EventArgs) Handles btnExcelScaffold.Click
        Dim tvt As New TagsValidationTable
        If IdCliente <> "" Then
            tvt.IdCliente = IdCliente
        Else
            tvt.IdCliente = ""
        End If
        tvt.ShowDialog()
        mtdScaffold.llenarScaffold(tblScaffoldTags, IdCliente)
    End Sub

    Private Sub tblScaffoldInformation_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles tblScaffoldInformation.DataError, tblProductosScaffold.DataError, tblScaffoldInformationSM.DataError, tblModificationProductMS.DataError, tblOutGoing.DataError
        e.Cancel = True
    End Sub

    Private Sub btnUploadExcelModification_Click(sender As Object, e As EventArgs) Handles btnUploadExcelModification.Click
        Dim mvt As New ModificationValidationTable
        If lblCompanyName.Text <> "Client: All" Then
            mvt.IdCliente = IdCliente
        Else
            mvt.IdCliente = ""
        End If
        mvt.ShowDialog()
        mtdScaffold.llenarModification(tblModification, IdCliente)
    End Sub
    Private Sub btnUploadExcelDismantle_Click(sender As Object, e As EventArgs) Handles btnUploadExcelDismantle.Click
        Dim dvt As New DismantleValidationTable
        dvt.ShowDialog()
        mtdScaffold.llenarScaffold(tblScaffoldTags, IdCliente)
        cargarDatosDismantle(ds.tag)
    End Sub

    Private Sub btnMaximize_Click(sender As Object, e As EventArgs) Handles btnMaximize.Click
        MaximizedBounds = Screen.FromHandle(Me.Handle).WorkingArea
        WindowState = FormWindowState.Maximized
        btnMaximize.Visible = False
        btnRestore.Visible = True
    End Sub

    Private Sub btnRestore_Click(sender As Object, e As EventArgs) Handles btnRestore.Click
        WindowState = FormWindowState.Normal
        btnRestore.Visible = False
        btnMaximize.Visible = True
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()

    End Sub

    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(hWnd As IntPtr, wMsg As Integer, wParam As Integer, lParam As Integer)
    End Sub

    Private Sub TitleBar_MouseMove(sender As Object, e As MouseEventArgs) Handles TitleBar.MouseMove
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub btnEstimationCostSC_Click(sender As Object, e As EventArgs) Handles btnEstimationCostSC.Click
        Try
            Dim EstCostSC As New EstimationCost
            EstCostSC.ShowDialog()
            Dim TypeScf = cmbScaffolType.Text
            Dim ScfCost = CmbScaffoldCost.Text
            mtdEstimation.llenarComboTypeScfCost(cmbScaffolType)
            mtdEstimation.llenarComboScfEstCost(CmbScaffoldCost)
            If TypeScf <> "" Then
                cmbScaffolType.SelectedItem = cmbScaffolType.Items(cmbScaffolType.FindString(TypeScf))
            End If
            If ScfCost <> "" Then
                CmbScaffoldCost.SelectedItem = CmbScaffoldCost.Items(CmbScaffoldCost.FindString(ScfCost))
            End If
        Catch ex As Exception

        End Try
    End Sub
    'redimensionar interfaz
    Dim loadingEst = False
    'Private Sub cmbScaffolType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbScaffolType.SelectedIndexChanged
    '    If Not loadingEst = True And cmbScaffolType.SelectedIndex > 0 Then
    '        Dim array() As String = cmbScaffolType.SelectedItem.ToString().Split("   ")
    '        estMeter.idTypeScf = array(0)
    '        mtdEstimation.factor = estMeter.selectFactor(mtdEstimation.TOTALHEIGTH)
    '        estMeter.FACTOR = estMeter.selectFactor(mtdEstimation.TOTALHEIGTH)
    '        estMeter.refreshValues(mtdEstimation)
    '    End If
    'End Sub
    Private Sub cmbScaffolType_SelectedValueChanged_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbScaffolType.SelectedValueChanged, cmbScaffolType.SelectedIndexChanged
        If loadingEst = False Then
            If cmbScaffolType.Text IsNot "" And cmbScaffolType.SelectedIndex > 0 Then
                Dim array() = cmbScaffolType.Text.ToString.Split("  ")
                mtdEstimation.scfTypeId = array(0)
                estMeter.idTypeScf = array(0)
                mtdEstimation.factor = estMeter.selectFactor(mtdEstimation.TOTALHEIGTH)
                estMeter.FACTOR = estMeter.selectFactor(mtdEstimation.TOTALHEIGTH)
                estMeter.refreshValues(mtdEstimation)
            End If
        End If
    End Sub

    'Private Sub cmbProjectNameEst_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbProjectNameEst.SelectedValueChanged
    '    If loadingData = False Then
    '        If cmbProjectNameEst.Text IsNot "" Then
    '            If mtdEstimation.idAux <> "" Then
    '                For Each row As Data.DataRow In tblWOTASK.Rows
    '                    If row.ItemArray(2) = mtdEstimation.idAux Then
    '                        cmbProjectNameEst.SelectedItem = cmbProjectNameEst.Items(cmbProjectNameEst.FindString(row.ItemArray(0)))
    '                        txtLocationEst.Text = row.ItemArray(4)
    '                        Exit For
    '                    End If
    '                Next
    '            End If
    '        End If
    '    End If
    'End Sub
    Private Sub txtUnitEst_TextChanged(sender As Object, e As EventArgs) Handles txtUnitEst.TextChanged
        If loadingEst = False Then
            mtdEstimation.unit = txtUnitEst.Text
        End If
    End Sub

    Private Sub cmbProjectNameEst_TextChanged_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbProjectNameEst.TextChanged, cmbProjectNameEst.SelectedValueChanged
        If loadingEst = False Then
            Try
                If cmbProjectNameEst.SelectedItem IsNot Nothing And cmbProjectNameEst.Text IsNot "" Then
                    For Each row As DataRow In tblWOTASK.Rows()
                        Dim datos() = cmbProjectNameEst.SelectedItem.ToString().Split(" ")
                        If datos(0) = row.ItemArray(0) Then
                            mtdEstimation.idAux = row.ItemArray(2)
                            txtLocationEst.Text = row.ItemArray(4)
                            mtdEstimation.location = row.ItemArray(4)
                            Exit For
                        End If
                    Next
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub txtLocationEst_TextChanged(sender As Object, e As EventArgs) Handles txtLocationEst.TextChanged
        If loadingEst = False Then
            mtdEstimation.location = txtLocationEst.Text
        End If
    End Sub

    Private Sub sprOperationalDays_ValueChanged(sender As Object, e As EventArgs) Handles sprOperationalDays.ValueChanged
        If loadingEst = False Then
            mtdEstimation.daysActive = sprOperationalDays.Value
            mtdEstimation.factor = estMeter.selectFactor(mtdEstimation.TOTALHEIGTH)
            estMeter.FACTOR = estMeter.selectFactor(mtdEstimation.TOTALHEIGTH)
            estMeter.refreshValues(mtdEstimation)
        End If
    End Sub

    Private Sub sprHeigthEst_ValueChanged(sender As Object, e As EventArgs) Handles sprWidthEst.ValueChanged, sprLengthEst.ValueChanged, sprHeigthEst.ValueChanged, sprElevatorEst.ValueChanged, sprDecksEst.ValueChanged, sprGroudHeigthEst.ValueChanged
        If loadingEst = False Then
            mtdEstimation.heigth = CDbl(sprHeigthEst.Value)
            mtdEstimation.length = CDbl(sprLengthEst.Value)
            mtdEstimation.width = CDbl(sprWidthEst.Value)
            mtdEstimation.descks = CInt(sprDecksEst.Value)
            mtdEstimation.groundheigth = CInt(sprGroudHeigthEst.Value)
            mtdEstimation.elevation = CInt(sprElevatorEst.Value)
            mtdEstimation.factor = estMeter.selectFactor(mtdEstimation.TOTALHEIGTH)
            estMeter.FACTOR = estMeter.selectFactor(mtdEstimation.TOTALHEIGTH)
            estMeter.refreshValues(mtdEstimation)
        End If
    End Sub
    Public Function cargarDatosEstimation(ByVal ControlNumEst As String) As Boolean
        Try
            loadingEst = True
            If mtdEstimation.idEstnumber = "" Then
                'txtControlNumber.Enabled = True
                clearDismantle()
                loadingDataDismentle = False
                Return True
            Else
                mtdEstimation.cargarDatosEstimation(ControlNumEst)
                estMeter = mtdEstimation.selectEstMeters(ControlNumEst, mtdEstimation.idEstMeters)
                estMeter.EstimationSC = mtdEstimation
                cmbCCNUM.SelectedItem = cmbCCNUM.Items(cmbCCNUM.FindString(mtdEstimation.ccnum + " " + mtdEstimation.unit))
                'txtControlNumber.Enabled = False
                If mtdEstimation.scfTypeId > -1 Then
                    For Each item As String In cmbScaffolType.Items
                        Dim array() As String = item.Split("    ")
                        If array(0) = CStr(mtdEstimation.scfTypeId) Then
                            cmbScaffolType.SelectedItem = cmbScaffolType.Items(cmbScaffolType.FindString(item))
                            Exit For
                        End If
                    Next
                Else
                    cmbScaffolType.SelectedItem = cmbScaffolType.Items(0)
                End If
                If mtdEstimation.IdEstCost > -1 Then
                    For Each item As String In CmbScaffoldCost.Items
                        Dim arra() As String = item.Split(" ")
                        If arra(0) = CStr(mtdEstimation.IdEstCost) Then
                            CmbScaffoldCost.SelectedItem = CmbScaffoldCost.Items(CmbScaffoldCost.FindString(item))
                            Exit For
                        End If
                    Next
                Else
                    CmbScaffoldCost.SelectedItem = CmbScaffoldCost.Items(0)
                End If
                If mtdEstimation.idAux <> "" Then
                    For Each row As Data.DataRow In tblWOTASK.Rows
                        If row.ItemArray(2) = mtdEstimation.idAux Then
                            cmbProjectNameEst.SelectedItem = cmbProjectNameEst.Items(cmbProjectNameEst.FindString(row.ItemArray(0)))
                            txtLocationEst.Text = row.ItemArray(4)
                            Exit For
                        End If
                    Next
                Else
                    cmbProjectNameEst.SelectedItem = Nothing
                    cmbProjectNameEst.SelectedIndex = -1
                    'cmbProjectNameEst.Text= ""

                End If
                txtUnitEst.Text = mtdEstimation.unit
                txtLocationEst.Text = mtdEstimation.location
                sprOperationalDays.Value = mtdEstimation.daysActive
                sprHeigthEst.Value = mtdEstimation.heigth
                sprLengthEst.Value = mtdEstimation.length
                sprWidthEst.Value = mtdEstimation.width
                sprDecksEst.Value = mtdEstimation.descks
                sprGroudHeigthEst.Value = mtdEstimation.groundheigth
                sprElevatorEst.Value = mtdEstimation.elevation
                IdClientEstmation = mtdEstimation.idClient
                loadingEst = False
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Dim IdClientEstmation As String = Nothing
    Private Sub selectClient()
        Dim idc As String = ""
        Dim mtdCl As New MetodosClients
        Dim tblCl = mtdCl.ConsultaClients()
        If tblCl IsNot Nothing Or tblCl.Rows.Count > 0 Then
            Dim txtInPutBox As String = "Exit " + tblCl.Rows.Count().ToString() + " Clients Please write the Client Number to asign a Client. If you do not to asign a client Write NULL."
            For Each row As Data.DataRow In tblCl.Rows()
                txtInPutBox = txtInPutBox + vbCrLf + row.ItemArray(1) + "-" + row.ItemArray(2)
            Next
            Dim flag As Boolean = False
            While flag = False
                idc = InputBox(txtInPutBox, "Select Client", "NULL", 400, 400)
                If Not idc = "NULL" Then
                    For Each row As Data.DataRow In tblCl.Rows()
                        If idc = row.ItemArray(1) Then
                            flag = True
                            IdClientEstmation = row.ItemArray(0)
                            Exit For
                        Else
                            flag = False
                        End If
                    Next
                    If flag = False Then
                        MsgBox("Client Number Not Found.")
                    End If
                Else
                    flag = True
                End If
            End While
        End If
    End Sub
    Public Sub limpiarCamposEstimation()
        loadingEst = True
        If lblCompanyName.Text = "Client: All" Then
            IdClientEstmation = Nothing

        End If
        If IdClientEstmation = Nothing Then
            selectClient()
        Else
            IdClientEstmation = mtdEstimation.idClient
        End If
        cmbCCNUM.SelectedItem = cmbCCNUM.Items(0)
        cmbScaffolType.SelectedItem = cmbScaffolType.Items(0)
        mtdScaffold.llenarComboWO(cmbProjectNameEst, IdCliente)
        txtUnitEst.Text = ""
        cmbProjectNameEst.SelectedItem = cmbProjectNameEst.Items(0)
        CmbScaffoldCost.SelectedItem = CmbScaffoldCost.Items(0)
        txtLocationEst.Text = ""
        sprOperationalDays.Value = 0
        sprHeigthEst.Value = 0
        sprLengthEst.Value = 0
        sprWidthEst.Value = 0
        sprDecksEst.Value = 0
        sprGroudHeigthEst.Value = 0
        sprElevatorEst.Value = 0
        mtdEstimation.Clear()
        mtdEstimation.idClient = IdClientEstmation
        estMeter.Clear()
        loadingEst = False
    End Sub
    Private Sub btnNewEst_Click(sender As Object, e As EventArgs) Handles btnNewEst.Click
        If btnNewEst.Text = "New" Then
            limpiarCamposEstimation()
            mtdScaffold.llenarComboWO(cmbProjectNameEst, IdCliente)
            mtdEstimation.llenarComboTypeScfCost(cmbScaffolType)
            mtdEstimation.llenarComboScfEstCost(CmbScaffoldCost)
            mtdEstimation.llenarComboControlNumber(cmbCCNUM)
            btnNewEst.Text = "Cancel"
        ElseIf btnNewEst.Text = "Cancel" Then
            limpiarCamposEstimation()
            mtdScaffold.llenarComboWO(cmbProjectNameEst, IdCliente)
            mtdEstimation.llenarComboTypeScfCost(cmbScaffolType)
            mtdEstimation.llenarComboScfEstCost(CmbScaffoldCost)
            mtdEstimation.llenarComboControlNumber(cmbCCNUM)
            If mtdEstimation.llenartablaEstimacion(tblEstimation, IdCliente) Then
                If tblEstimation.Rows.Count > 0 Then
                    If mtdEstimation.cargarDatosEstimation(tblEstimation.Rows(0).ItemArray(0)) Then
                        cargarDatosEstimation(tblEstimation.Rows(0).ItemArray(0))
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub btnBackEst_Click(sender As Object, e As EventArgs) Handles btnBackEst.Click
        Try
            If tblEstimation.Rows.Count > 0 Then
                Dim count As Integer = 0
                For Each row As Data.DataRow In tblEstimation.Rows
                    If row.ItemArray(0) = mtdEstimation.idEstnumber Then
                        If count = 0 Then 'si es el primero ve al ultimo
                            Dim rowMax = tblEstimation.Rows.Count() - 1
                            mtdEstimation.cargarDatosEstimation(tblEstimation.Rows(rowMax).ItemArray(0))
                            cargarDatosEstimation(mtdEstimation.idEstnumber)
                            Exit For
                        Else 'de lo contrario solo ve uno atras
                            mtdEstimation.cargarDatosEstimation(tblEstimation.Rows(count - 1).ItemArray(0))
                            cargarDatosEstimation(mtdEstimation.idEstnumber)
                            Exit For
                        End If
                    Else
                        count += 1
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnNextEst_Click(sender As Object, e As EventArgs) Handles btnNextEst.Click
        Try
            If tblEstimation.Rows.Count > 0 Then
                Dim count As Integer = 0
                For Each row As Data.DataRow In tblEstimation.Rows
                    If row.ItemArray(0) = mtdEstimation.idEstnumber Then
                        If count = tblEstimation.Rows.Count - 1 Then 'si es el ultimo? ve al primero
                            mtdEstimation.cargarDatosEstimation(tblEstimation.Rows(0).ItemArray(0))
                            cargarDatosEstimation(mtdEstimation.idEstnumber)
                            Exit For
                        Else 'de lo contrario solo ve uno adelate
                            mtdEstimation.cargarDatosEstimation(tblEstimation.Rows(count + 1).ItemArray(0))
                            cargarDatosEstimation(mtdEstimation.idEstnumber)
                            Exit For
                        End If
                    Else
                        count += 1
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CmbScaffoldCost_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbScaffoldCost.SelectedValueChanged
        If loadingEst = False And CmbScaffoldCost.SelectedIndex > 0 Then
            If CmbScaffoldCost.Text IsNot "" Then
                Dim array() = CmbScaffoldCost.Text.ToString.Split("  ")
                mtdEstimation.IdEstCost = array(0)
                estMeter.idEstCost = array(0)
                mtdEstimation.factor = estMeter.selectFactor(mtdEstimation.TOTALHEIGTH)
                estMeter.FACTOR = estMeter.selectFactor(mtdEstimation.TOTALHEIGTH)
                estMeter.refreshValues(mtdEstimation)
            End If
        End If
    End Sub
    'Private Sub CmbScaffoldCost_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbScaffoldCost.SelectedIndexChanged
    '    If Not loadingEst = True And CmbScaffoldCost.SelectedIndex > 0 Then
    '        Dim array() As String = CmbScaffoldCost.SelectedItem.ToString().Split("   ")
    '        estMeter.idEstCost = array(0)
    '        mtdEstimation.factor = estMeter.selectFactor(mtdEstimation.TOTALHEIGTH)
    '        estMeter.FACTOR = estMeter.selectFactor(mtdEstimation.TOTALHEIGTH)
    '        estMeter.refreshValues(mtdEstimation)
    '    End If
    'End Sub
    Private Sub sprHeigthEst_Leave(sender As Object, e As EventArgs) Handles sprHeigthEst.Leave
        If Not loadingEst = True Then
            If cmbScaffolType.SelectedIndex > 0 Then
                Dim array() As String = cmbScaffolType.SelectedItem.ToString().Split("   ")
                estMeter.idTypeScf = array(0)
                Dim array1() As String = CmbScaffoldCost.SelectedItem.ToString().Split("   ")
                estMeter.idEstCost = array1(0)
            End If
            mtdEstimation.factor = estMeter.selectFactor(mtdEstimation.TOTALHEIGTH)
            estMeter.FACTOR = estMeter.selectFactor(mtdEstimation.TOTALHEIGTH)
            estMeter.refreshValues(mtdEstimation)
        End If
    End Sub
    Private Sub btnReportEstimationSC_Click(sender As Object, e As EventArgs) Handles btnReportEstimationSC.Click
        Dim rse As New ReportScaffoldEstimate
        rse.mtdEstimation = estMeter
        rse.UnicReport = True
        rse.idClient = IdCliente
        rse.EstNumber = mtdEstimation.idEstnumber()
        rse.Unit = cmbCCNUM.SelectedItem.ToString()
        rse.ShowDialog()
    End Sub
    Private Sub cmbProjectNameEst_MouseHover(sender As Object, e As EventArgs) Handles cmbProjectNameEst.MouseHover
        Dim tt As New ToolTip
        Try
            tt.SetToolTip(Me.cmbProjectNameEst, Me.cmbProjectNameEst.Items(Me.cmbProjectNameEst.SelectedIndex))
        Catch ex As Exception
        End Try
    End Sub
    Private Sub cmbCCNUM_Leave(sender As Object, e As EventArgs) Handles cmbCCNUM.Leave
        If Not loadingEst = True Then
            Try
                Dim array() As String = cmbCCNUM.Text.ToString().Split(" ")
                Dim newUnit As Boolean = True
                For Each item As Object In cmbCCNUM.Items
                    Dim array1() As String = item.ToString().Split(" ")
                    If cmbCCNUM.Text = item.ToString() Then
                        newUnit = False
                        Exit For
                    ElseIf cmbCCNUM.Text = array1(0) Then
                        newUnit = False
                        Exit For
                    End If
                Next
                If array.Length > 1 Then
                    If newUnit Then
                        MessageBox.Show("The unit '" + array(1) + "' do not exist, it will be inserted like a new Unit with the CCNUM '" + array(0) + "'", "Important", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        cmbCCNUM.Items.Add(cmbCCNUM.Text)
                    End If
                    txtUnitEst.Text = array(1)
                    mtdEstimation.ccnum = array(0)
                    mtdEstimation.unit = array(1)
                ElseIf array.Length = 1 Then
                    If newUnit Then
                        MessageBox.Show("If you want to add new Unit Please write the Unit, space and the name of the Unit.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                    txtUnitEst.Text = ""
                    mtdEstimation.unit = ""
                    mtdEstimation.ccnum = ""
                    cmbCCNUM.Text = ""
                    cmbCCNUM.SelectedItem = Nothing
                ElseIf cmbCCNUM.Text <> "" Then
                    mtdEstimation.ccnum = cmbCCNUM.Text
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub
    Private Sub cmbCCNUM_MouseHover(sender As Object, e As EventArgs) Handles cmbCCNUM.MouseHover
        Dim tt As New ToolTip
        Try
            tt.SetToolTip(Me.cmbCCNUM, "If you want to add new Unit Please write th Unit, space and the name of the Unit.")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub cmbCCNUM_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCCNUM.SelectedIndexChanged
        Try
            If cmbCCNUM.SelectedItem IsNot Nothing Then
                Dim array() As String = cmbCCNUM.SelectedItem.ToString().Split(" ")
                If array.Length > 1 Then
                    txtUnitEst.Text = array(1)
                    mtdEstimation.ccnum = array(0)
                    mtdEstimation.unit = array(1)
                ElseIf array.Length = 1 Then
                    txtUnitEst.Text = ""
                    mtdEstimation.unit = ""
                    mtdEstimation.ccnum = array(0)
                ElseIf cmbCCNUM.Text <> "" Then
                    mtdEstimation.ccnum = cmbCCNUM.Text
                End If
            Else
                MsgBox("Plase select a Control Number Or Write a New one 'CCNUM', Space and the Area Name.")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub tblAreas_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles tblAreas.CellMouseDoubleClick
        If tblAreas.CurrentCell.ColumnIndex = tblAreas.Columns("Client").Index Then
            Try
                If tblAreas.CurrentCell.GetType.Name = "DataGridViewTextBoxCell" Then
                    Dim cmbAreaCell As New DataGridViewComboBoxCell
                    With cmbAreaCell
                        mtdScaffold.llenarClientsComboBoxCell(cmbAreaCell)
                        cmbAreaCell.DropDownWidth = 240
                    End With
                    If tblAreas.CurrentRow.Cells(3).Value IsNot Nothing Then
                        For Each row As String In cmbAreaCell.Items
                            Dim array() As String = row.Split(" ")
                            If array(0) = tblAreas.CurrentRow.Cells(3).Value Then
                                cmbAreaCell.Value = row
                            End If
                        Next
                    End If
                    tblAreas.CurrentRow.Cells(3) = cmbAreaCell
                    tblAreas.CurrentCell = tblAreas.Rows(tblAreas.CurrentCell.RowIndex).Cells(2)
                    tblAreas.CurrentCell = tblAreas.Rows(tblAreas.CurrentCell.RowIndex).Cells(3)
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub
    Private Sub tblAreas_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles tblAreas.EditingControlShowing
        Dim Index = tblAreas.CurrentCell.ColumnIndex
        FlagSelectTablaAreaJobcatSubjob = "Area"
        If Index = 3 Then
            If tblAreas.CurrentCell.GetType.Name = "DataGridViewComboBoxCell" Then
                Dim cb As ComboBox = CType(e.Control, ComboBox)
                If e.Control IsNot Nothing Then
                    RemoveHandler cb.SelectedIndexChanged, AddressOf cmb_SelectedIndexChanguedClients
                    AddHandler cb.SelectedIndexChanged, AddressOf cmb_SelectedIndexChanguedClients
                End If
            End If
        End If
    End Sub
    Dim FlagSelectTablaAreaJobcatSubjob As String
    Private Sub tblSubJobs_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles tblSubJobs.CellClick
        FlagSelectTablaAreaJobcatSubjob = "SubJob"
    End Sub
    Private Sub tblJobCat_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles tblJobCat.CellClick
        FlagSelectTablaAreaJobcatSubjob = "JobCat"
    End Sub
    Private Sub tblAreas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles tblAreas.CellClick
        FlagSelectTablaAreaJobcatSubjob = "Area"
    End Sub
    Public Sub cmb_SelectedIndexChanguedClients(sender As Object, e As EventArgs)
        Try
            Dim cmb As ComboBox = CType(sender, ComboBox)
            If cmb.SelectedItem IsNot Nothing Then
                If FlagSelectTablaAreaJobcatSubjob = "Area" Then
                    If tblAreas.CurrentCell.Value <> cmb.SelectedItem.ToString() Then
                        tblAreas.CurrentCell.Value = cmb.SelectedItem.ToString()
                    End If
                ElseIf FlagSelectTablaAreaJobcatSubjob = "SubJob" Then
                    If tblSubJobs.CurrentCell.Value <> cmb.SelectedItem.ToString() Then
                        tblSubJobs.CurrentCell.Value = cmb.SelectedItem.ToString()
                    End If
                ElseIf FlagSelectTablaAreaJobcatSubjob = "JobCat" Then
                    If tblJobCat.CurrentCell.Value <> cmb.SelectedItem.ToString() Then
                        tblJobCat.CurrentCell.Value = cmb.SelectedItem.ToString()
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub tblJobCat_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles tblJobCat.CellMouseDoubleClick
        If tblJobCat.CurrentCell.ColumnIndex = tblJobCat.Columns("Client").Index Then
            Try
                If tblJobCat.CurrentCell.GetType.Name = "DataGridViewTextBoxCell" Then
                    Dim cmbJobCatCell As New DataGridViewComboBoxCell
                    With cmbJobCatCell
                        mtdScaffold.llenarClientsComboBoxCell(cmbJobCatCell)
                        cmbJobCatCell.DropDownWidth = 240
                    End With
                    If tblJobCat.CurrentRow.Cells(3).Value IsNot Nothing Then
                        For Each row As String In cmbJobCatCell.Items
                            Dim array() As String = row.Split(" ")
                            If array(0) = tblJobCat.CurrentRow.Cells(3).Value Then
                                cmbJobCatCell.Value = row
                            End If
                        Next
                    End If
                    tblJobCat.CurrentRow.Cells(3) = cmbJobCatCell
                    tblJobCat.CurrentCell = tblJobCat.Rows(tblJobCat.CurrentCell.RowIndex).Cells(2)
                    tblJobCat.CurrentCell = tblJobCat.Rows(tblJobCat.CurrentCell.RowIndex).Cells(3)
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub
    Private Sub tblJobCat_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles tblJobCat.DataError, tblSubJobs.DataError, tblAreas.DataError
        e.Cancel = True
    End Sub
    Private Sub tblJobcat_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles tblJobCat.EditingControlShowing
        Dim Index = tblAreas.CurrentCell.ColumnIndex
        FlagSelectTablaAreaJobcatSubjob = "JobCat"
        If Index = 3 Then
            If tblAreas.CurrentCell.GetType.Name = "DataGridViewComboBoxCell" Then
                Dim cb As ComboBox = CType(e.Control, ComboBox)
                If e.Control IsNot Nothing Then
                    RemoveHandler cb.SelectedIndexChanged, AddressOf cmb_SelectedIndexChanguedClients
                    AddHandler cb.SelectedIndexChanged, AddressOf cmb_SelectedIndexChanguedClients
                End If
            End If
        End If
    End Sub
    Private Sub tblSubJobs_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles tblSubJobs.CellMouseDoubleClick
        If tblSubJobs.CurrentCell.ColumnIndex = tblSubJobs.Columns("Client").Index Then
            Try
                If tblSubJobs.CurrentCell.GetType.Name = "DataGridViewTextBoxCell" Then
                    Dim cmbSubJobCell As New DataGridViewComboBoxCell
                    With cmbSubJobCell
                        mtdScaffold.llenarClientsComboBoxCell(cmbSubJobCell)
                        cmbSubJobCell.DropDownWidth = 240
                    End With
                    If tblSubJobs.CurrentRow.Cells(3).Value IsNot Nothing Then
                        For Each row As String In cmbSubJobCell.Items
                            Dim array() As String = row.Split(" ")
                            If array(0) = tblSubJobs.CurrentRow.Cells(3).Value Then
                                cmbSubJobCell.Value = row
                            End If
                        Next
                    End If
                    tblSubJobs.CurrentRow.Cells(3) = cmbSubJobCell
                    tblSubJobs.CurrentCell = tblSubJobs.Rows(tblSubJobs.CurrentCell.RowIndex).Cells(2)
                    tblSubJobs.CurrentCell = tblSubJobs.Rows(tblSubJobs.CurrentCell.RowIndex).Cells(3)
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub
    Private Sub tblSubJobs_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles tblSubJobs.EditingControlShowing
        Dim Index = tblSubJobs.CurrentCell.ColumnIndex
        FlagSelectTablaAreaJobcatSubjob = "SubJob"
        If Index = 3 Then
            If tblSubJobs.CurrentCell.GetType.Name = "DataGridViewComboBoxCell" Then
                Dim cb As ComboBox = CType(e.Control, ComboBox)
                If e.Control IsNot Nothing Then
                    RemoveHandler cb.SelectedIndexChanged, AddressOf cmb_SelectedIndexChanguedClients
                    AddHandler cb.SelectedIndexChanged, AddressOf cmb_SelectedIndexChanguedClients
                End If
            End If
        End If
    End Sub
    Private Sub TitleBar_Paint(sender As Object, e As PaintEventArgs) Handles TitleBar.Paint

    End Sub
    Private Sub btnFindDismantle_Click(sender As Object, e As EventArgs) Handles btnFindDismantle.Click
        Try
            Dim FindSC As New FindTagScaffold
            AddOwnedForm(FindSC)
            FindSC.idclient = If(lblCompanyName.Text = "Client: All", "ALL", IdCliente)
            FindSC.OpenWindow = "Dismantle"
            FindSC.ShowDialog()
            If tagFind <> "" Then
                llenarComboTag(cmbTagDismantle, tblScaffoldTags)
                cargarDatosDismantle(tagFind)
            End If
        Catch ex As Exception

        End Try
    End Sub
    '########################################################################################################################################################################
    '############################## COSTUMERS AND JOBS ######################################################################################################################
    '########################################################################################################################################################################
    Dim idClientAuxCostumer As String = ""
    Private Sub btnNextCostumer_Click(sender As Object, e As EventArgs) Handles btnNextCostumer.Click
        If tblCostumers.Rows.Count > 0 Then
            Dim cont As Integer = 0
            For Each row As Data.DataRow In tblCostumers.Rows
                If row.ItemArray(1) = txtCompanyID.Text And row.ItemArray(2) = txtCompanyName.Text Then
                    Exit For
                Else
                    cont += 1
                End If
            Next
            If cont = tblCostumers.Rows.Count - 1 Then
                cont = 0
                cargarDatosCostumer(tblCostumers.Rows(cont))
            Else
                cargarDatosCostumer(tblCostumers.Rows(cont + 1))
            End If
        End If
    End Sub
    Private Sub btnBackCostumer_Click(sender As Object, e As EventArgs) Handles btnBackCostumer.Click
        If tblCostumers.Rows.Count > 0 Then
            Dim cont As Integer = 0
            For Each row As Data.DataRow In tblCostumers.Rows
                If row.ItemArray(1) = txtCompanyID.Text And row.ItemArray(2) = txtCompanyName.Text Then
                    Exit For
                Else
                    cont += 1
                End If
            Next
            If cont = 0 Then
                cont = tblCostumers.Rows.Count - 1
                cargarDatosCostumer(tblCostumers.Rows(cont))
            Else
                cargarDatosCostumer(tblCostumers.Rows(cont - 1))
            End If
        End If
    End Sub
    Private Sub cargarDatosCostumer(ByVal row As Data.DataRow)
        Try
            If Not idClientAuxCostumer.Equals(row.ItemArray(0)) Then
                idClientAuxCostumer = row.ItemArray(0)
                txtCompanyID.Text = CStr(row.ItemArray(1))
                txtCompanyName.Text = row.ItemArray(2)
                txtBillingAddres.Text = row.ItemArray(3)
                txtContactName.Text = row.ItemArray(4)
                txtCity.Text = row.ItemArray(5)
                txtProvidence.Text = row.ItemArray(6)
                txtPostalCode.Text = CStr(row.ItemArray(7))
                txtPN1.Text = row.ItemArray(8)
                txtPN2.Text = row.ItemArray(9)
                txtEmail.Text = row.ItemArray(10)
                mtdScaffold.selectScaffoldProjectCostumer(row.ItemArray(0), tblCostumersJobs)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnReloadCostumer_Click(sender As Object, e As EventArgs) Handles btnReloadCostumer.Click
        If idClientAuxCostumer <> "" Then
            cargarDatosByClient(idClientAuxCostumer, txtCompanyName.Text)
        End If
    End Sub

    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        Try
            If sc.tag <> "" Then
                Dim frp As New ScaffoldProductReport
                frp.WindowStart = "scf"
                frp.tagNum = sc.tag
                frp.ShowDialog()
            Else
                MsgBox("Please select a Sacaffold.")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnReportModification_Click(sender As Object, e As EventArgs) Handles btnReportModification.Click
        Try
            If md.tag <> "" And md.ModID <> "" Then
                Dim frp As New ScaffoldProductReport
                frp.WindowStart = "mod"
                frp.tagNum = md.tag
                frp.ModNum = md.ModID
                frp.ShowDialog()
            Else
                MsgBox("Please select a Sacaffold.")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnReportDismantled_Click(sender As Object, e As EventArgs) Handles btnReportDismantled.Click
        Try
            If ds.tag <> "" And ds.idDismantle <> "" Then
                Dim frp As New ScaffoldProductReport
                frp.WindowStart = "dis"
                frp.tagNum = ds.tag
                frp.ShowDialog()
            Else
                MsgBox("Please select a Sacaffold.")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub tblModificationMaterial_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles tblModificationMaterial.CellContentClick

    End Sub



    Public Function cargarDatosByClient(ByVal idClientF As String, ByVal companyNameF As String) As Boolean
        Try
            IdCliente = idClientF
            Company = companyNameF
            If IdCliente <> "" Then
                lblCompanyName.Text = "Client: " + Company
            Else
                lblCompanyName.Text = "Client: All"
            End If
            'In Coming
            dtpDateInComing.Format = DateTimePickerFormat.Custom
            dtpDateInComing.CustomFormat = "MM/dd/yyyy"
            mtdScaffold.llenarEmpleadosCombo(cmbEmployeesInComing, tablaEmpleados)
            If IdCliente <> "" Then
                mtdScaffold.llenarJobCombo(cmbJobNumInComing, IdCliente)
            Else
                mtdScaffold.llenarJobCombo(cmbJobNumInComing)
            End If

            Dim datosIncoming As List(Of String) = mtdScaffold.llenarInComming(tblInComing, tblTicketInComing, IdCliente)
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
            llenarComboJobsReportsIDclient(cmbJobProduct, IdCliente)
            llenarComboJobsReportsIDclient(cmbJobNoUtilization, IdCliente, True)
            If cmbJobProduct.Items IsNot Nothing Then
                cmbJobProduct.SelectedItem = cmbJobProduct.Items(0)
                mtdScaffold.llenarTablaProductosByJobNo(tblProductByJobNo, cmbJobProduct.Items(0).ToString())
            Else
                mtdScaffold.llenarTablaProductosByJobNo(tblProductByJobNo)
            End If
            mtdScaffold.llenarComboProductUtilization(cmbProductUtilization)
            'mtdScaffold.llenar
            'Out Going
            mtdScaffold.llenarJobCombo(cmbJobNumOutGoing, IdCliente)
            'ClonarCombo(cmbShippedBY, cmbEmployeesInComing)
            mtdScaffold.llenarEmpleadosCombo(cmbShippedBY, tablaEmpleados)
            mtdScaffold.llenarEmpleadosCombo(cmbSuperintendent, tablaEmpleados)
            dtpDateOutGoing.Format = DateTimePickerFormat.Custom
            dtpDateOutGoing.CustomFormat = "MM/dd/yyyy"
            Dim datosOutGoing As List(Of String) = mtdScaffold.llenarOutGoing(tblOutGoing, tblTicketOutGoing, IdCliente)
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
            mtdScaffold.llenarSubJobs(tblSubJobs, If(IdCliente <> "", IdCliente, ""))
            mtdScaffold.llenarAreas(tblAreas, If(IdCliente <> "", IdCliente, ""))
            mtdScaffold.llenarWO(tblWO, IdCliente)
            mtdScaffold.llenarJobCat(tblJobCat, If(IdCliente <> "", IdCliente, ""))
            tblAreas.Columns("Client2").Visible = False
            tblSubJobs.Columns("Client2").Visible = False
            tblJobCat.Columns("Client2").Visible = False
            If Not lblCompanyName.Text = "Client: All" Then
                tblAreas.Columns("Client").Visible = False
                tblSubJobs.Columns("Client").Visible = False
                tblJobCat.Columns("Client").Visible = False
            End If
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
            tblArea = mtdScaffold.llenarComboArea(cmbAreaID, If(IdCliente <> "", IdCliente, ""))
            tblCat = mtdScaffold.llenarComboJobCat(cmbJobCAT, If(IdCliente <> "", IdCliente, ""))
            tblWOTASK = mtdScaffold.llenarComboWO(cmbWONum, IdCliente)
            tblSubJob = mtdScaffold.llenarComboSubJob(cmbSubJob, If(IdCliente <> "", IdCliente, ""))
            mtdScaffold.llenarEmpleadosCombo(cmbForemanScaffold, tablaEmpleados)
            mtdScaffold.llenarEmpleadosCombo(cmbErectorScaffold, tablaEmpleados)
            If tblScaffoldInformation.Rows.Count = 0 Then
                tblScaffoldInformation.Rows.Add("", "", "", "", "", "", "", "")
            Else
                tblScaffoldInformation.Rows.Clear()
                tblScaffoldInformation.Rows.Add("", "", "", "", "", "", "", "")
            End If
            cmbProyect = New DataGridViewComboBoxCell
            cmbProyect1 = New DataGridViewComboBoxCell
            With cmbProyect
                mtdScaffold.llenarRentaTypeCombo(cmbProyect)
            End With
            tblScaffoldInformation.Rows(0).Cells(0) = cmbProyect
            tblActivityHours.Rows.Add("", "", "", "", "", "", "", "", "")
            tblActivityHours.Rows(0).Cells("clmTotal").ReadOnly = True
            tblActivityHours.Rows(0).Cells("clmTotal").Style.BackColor = Color.Green
            If mtdScaffold.llenarScaffold(tblScaffoldTags, If(lblCompanyName.Text = "Client: All", "", IdCliente)) Then
                If tblScaffoldTags.Rows.Count > 0 Then
                    cargarDatosScaffold(tblScaffoldTags.Rows(0).ItemArray(0).ToString())
                End If
            End If
            btnDeleteRowScaffoldLeg.Enabled = False
            'Modification
            dtpModificationDate.Format = DateTimePickerFormat.Custom
            dtpModificationDate.CustomFormat = "MM/dd/yyyy"
            If tblScaffoldInformationSM.Rows.Count = 0 Then
                tblScaffoldInformationSM.Rows.Add("", "", "", "", "", "", "", "")
            Else
                tblScaffoldInformationSM.Rows.Clear()
                tblScaffoldInformationSM.Rows.Add("", "", "", "", "", "", "", "")
            End If

            With cmbProyect1
                mtdScaffold.llenarRentaTypeCombo(cmbProyect1)
            End With
            tblScaffoldInformationSM.Rows(0).Cells(0) = cmbProyect1
            tblActivityHoursSM.Rows.Add("", "", "", "", "", "", "", "", "")
            tblActivityHoursSM.Rows(0).Cells("ToHrs").ReadOnly = True
            tblActivityHoursSM.Rows(0).Cells("ToHrs").Style.BackColor = Color.Green
            mtdScaffold.llenarComboTagModificaion(cmbTagScaffold, IdCliente)
            mtdScaffold.llenarEmpleadosCombo(cmbForemanModification, tablaEmpleados)
            mtdScaffold.llenarEmpleadosCombo(cmbErectorModification, tablaEmpleados)
            mtdScaffold.llenarComboReqCompany(cmbReqCompany)
            mtdScaffold.llenarComboRequestBy(cmbRequestBY)
            If mtdScaffold.llenarModification(tblModification, IdCliente) Then
                If tblModification.Rows.Count > 0 Then
                    md = mtdScaffold.llenarModificationData(tblModification.Rows(0).ItemArray(0), tblModification.Rows(0).ItemArray(5))
                    If md.ModAux <> "" Then
                        cargarDatosModification(md.ModAux)
                    End If
                Else
                    md.Clear()
                End If
            End If
            'Dismantle
            tblActivityHoursDismantle.Rows.Add("", "", "", "", "", "", "", "", "")
            tblActivityHoursDismantle.Rows(0).Cells("clmTotalHD").ReadOnly = True
            tblActivityHoursDismantle.Rows(0).Cells("clmTotalHD").Style.BackColor = Color.Green
            llenarComboTag(cmbTagDismantle, tblScaffoldTags)
            If tblScaffoldTags.Rows.Count() > 0 Then
                cargarDatosDismantle(tblScaffoldTags.Rows(0).ItemArray(0))
            End If
            If tblScaffoldTags.Rows.Count > 0 Then
                llenarComboTag(cmbTagDismantle, tblScaffoldTags)
            End If
            'Estimation
            mtdScaffold.llenarComboWO(cmbProjectNameEst, IdCliente)
            mtdEstimation.llenarComboTypeScfCost(cmbScaffolType)
            mtdEstimation.llenarComboScfEstCost(CmbScaffoldCost)
            mtdEstimation.llenarComboControlNumber(cmbCCNUM)
            If mtdEstimation.llenartablaEstimacion(tblEstimation, IdCliente) Then
                If tblEstimation.Rows.Count > 0 Then
                    If mtdEstimation.cargarDatosEstimation(tblEstimation.Rows(0).ItemArray(0)) Then
                        cargarDatosEstimation(tblEstimation.Rows(0).ItemArray(0))
                    End If
                End If
            End If
            'Costumer
            tblCostumers = mtdScaffold.selectCostumerInfo()
            If tblCostumers.Rows.Count() > 0 Then
                If IdCliente <> "" Then
                    Dim flag As Boolean = False
                    For Each row As DataRow In tblCostumers.Rows
                        If row.ItemArray(0) = IdCliente Then
                            cargarDatosCostumer(row)
                            flag = True
                            Exit For
                        End If
                    Next
                    If flag = False Then
                        cargarDatosCostumer(tblCostumers.Rows(0))
                    End If
                Else
                    cargarDatosCostumer(tblCostumers.Rows(0))
                End If
            End If
            Return True
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        End Try
    End Function

    Private Function ClonarCombo(ByVal cmbClone As ComboBox, ByVal cmbOriginal As ComboBox) As Boolean
        Try
            If cmbOriginal.Items IsNot Nothing Then
                cmbClone.DataSource = cmbOriginal.DataSource
                cmbClone.DisplayMember = cmbOriginal.DisplayMember
                cmbClone.ValueMember = cmbOriginal.ValueMember
                Return True
            Else
                For Each row As Data.DataRow In tablaEmpleados.Rows
                    cmbClone.Items.Add(row.ItemArray(1))
                Next
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub txtLatitude_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLatitude.KeyPress
        If Not (IsNumeric(e.KeyChar()) Or Asc(e.KeyChar) = Asc(Keys.Enter) Or Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 45) Then
            If Not (e.KeyChar = ChrW(22) Or e.KeyChar = ChrW(3)) Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtLongitude_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLongitude.KeyPress
        If Not (IsNumeric(e.KeyChar()) Or Asc(e.KeyChar) = Asc(Keys.Enter) Or Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 45) Then
            If Not (e.KeyChar = ChrW(22) Or e.KeyChar = ChrW(3)) Then
                e.Handled = True
            End If
        End If
    End Sub
End Class