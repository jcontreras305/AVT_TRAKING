Imports System.Data
Imports System.Data.SqlClient
Public Class Materials







    Public idVedor, idMaterial, idDM, idOrder As String
    Dim dataVendor, listIdVendors As New List(Of String)
    Dim dataMaterial(5) As String
    Dim flagUpdateOrder As Boolean = False

    Dim mtdMaterial As MetodosMaterials = New MetodosMaterials()
    Private Sub Materials_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtNumeroMaterial.Enabled = False
        txtNumeroMaterial.Text = mtdMaterial.valueMaxMaterial
        txtNumeroVendedor.Enabled = False
        txtNumeroVendedor.Text = mtdMaterial.valueMaxVendor

    End Sub

    Private Sub btnSaveVendor_Click(sender As Object, e As EventArgs) Handles btnSaveVendor.Click
        Dim dataVendor(3) As String
        dataVendor(0) = txtNumeroVendedor.Text
        dataVendor(1) = txtNombreVendedor.Text
        dataVendor(2) = txtDescripcionVendedor.Text
        dataVendor(3) = If(chbEnableVendor.Checked, "E", "D")
        mtdMaterial.insertarVendor(dataVendor)
        mtdMaterial.selectVedor(tbkVendor, "")
    End Sub


    Private Sub btnUpdateVendor_Click(sender As Object, e As EventArgs) Handles btnUpdateVendor.Click
        Dim dataVendor(3) As String
        dataVendor(0) = idVedor
        dataVendor(1) = txtNombreVendedor.Text
        dataVendor(2) = txtDescripcionVendedor.Text
        dataVendor(3) = If(chbEnableVendor.Checked, "E", "D")
        mtdMaterial.actializarVendor(dataVendor)
        mtdMaterial.selectVedor(tbkVendor, "")
    End Sub

    Private Sub txtSearchVendedor_TextChanged(sender As Object, e As EventArgs) Handles txtSearchVendedor.TextChanged
        mtdMaterial.selectVedor(tbkVendor, txtSearchVendedor.Text)
    End Sub

    Private Sub btnSaveMaterial_Click(sender As Object, e As EventArgs) Handles btnSaveMaterial.Click
        Dim dataMaterial(3) As String
        dataMaterial(0) = txtNameMaterials.Text
        dataMaterial(1) = txtNumeroMaterial.Text
        dataMaterial(2) = listIdVendors(cmbVendedor.FindString(cmbVendedor.Text))
        dataMaterial(3) = If(chbEnableMaterial.Checked, "E", "D")
        mtdMaterial.insertarMaterial(dataMaterial)
    End Sub

    Private Sub btnUpdateMaterial_Click(sender As Object, e As EventArgs) Handles btnUpdateMaterial.Click
        Dim dataMaterialnuevos(4) As String
        dataMaterialnuevos(0) = txtNameMaterials.Text
        dataMaterialnuevos(1) = txtNumeroMaterial.Text
        dataMaterialnuevos(2) = listIdVendors(cmbVendedor.FindString(cmbVendedor.Text))
        dataMaterialnuevos(3) = If(chbEnableMaterial.Checked, "E", "A")
        dataMaterialnuevos(4) = idMaterial
        mtdMaterial.actualizarMaterial(dataMaterialnuevos, dataMaterial(1))
        mtdMaterial.selectMaterial(tblMaterial, txtFiltro.Text)
    End Sub

    Private Sub BtnMenu_Click(sender As Object, e As EventArgs) Handles btnMenu.Click
        Dim a As New MainFrom
        a.Show()
        Me.Finalize()
    End Sub

    Private Sub tblMaterial_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles tblMaterial.CellMouseDoubleClick
        Dim cont As Int32 = 0
        For Each cell As DataGridViewCell In tblMaterial.CurrentRow.Cells
            dataMaterial(cont) = cell.Value.ToString
            cont += 1
        Next
        idMaterial = dataMaterial(0)
        txtNameMaterials.Text = dataMaterial(2)
        txtNumeroMaterial.Text = dataMaterial(3)
        chbEnableMaterial.Checked = If(dataMaterial(4).Equals("Enable"), True, False)
        cmbVendedor.Text = dataMaterial(5)
        cmbVendedor.SelectedIndex = cmbVendedor.FindString(dataMaterial(5))
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim a As New Login
        a.Show()
        Me.Finalize()
    End Sub

    Private Sub txtFiltro_KeyUp(sender As Object, e As KeyEventArgs) Handles txtFiltro.KeyUp
        mtdMaterial.selectMaterial(tblMaterial, txtFiltro.Text)
    End Sub

    Private Sub txtDMaterial_MouseClick(sender As Object, e As MouseEventArgs) Handles txtDMaterial.MouseClick
        Dim SM As New SelectMaterial
        Dim listIdsVendor As New List(Of String)
        mtdMaterial.llenarVendorCombo(SM.cmbNombreVendorSM, listIdsVendor)
        mtdMaterial.selectMaterial(SM.tblMaterialSM, "%", "All", False)
        SM.cmbNombreVendorSM.Text = "All"
        AddOwnedForm(SM)
        SM.ShowDialog()
    End Sub

    Private Sub btnUpdateMareialData_Click(sender As Object, e As EventArgs) Handles btnUpdateMareialData.Click
        Dim listDatosNuevos As New List(Of String)
        listDatosNuevos.Add(idMaterial)
        listDatosNuevos.Add(txtRM.Text)
        listDatosNuevos.Add(cmbUnidadDeMedida.Text)
        listDatosNuevos.Add(sprTamanio.Value)
        listDatosNuevos.Add(txtTipo.Text)
        listDatosNuevos.Add(sprPrice.Value)
        listDatosNuevos.Add(txtDescripcion.Text)
        mtdMaterial.actualizarDatosMaterial(listDatosNuevos)
    End Sub

    Private Sub chbOrden_CheckedChanged(sender As Object, e As EventArgs) Handles chbOrden.CheckedChanged
        If chbOrden.Checked Then
            sprCantidadOrden.Enabled = True
            sprPricioOrden.Enabled = True
            dtpFechaOrden.Enabled = True
            btnOrderSave.Enabled = True
            flagUpdateOrder = False
        Else
            sprCantidadOrden.Enabled = False
            sprPricioOrden.Enabled = False
            dtpFechaOrden.Enabled = False
            btnOrderSave.Enabled = False
        End If
    End Sub

    Private Sub sprPricioOrden_ValueChanged(sender As Object, e As EventArgs) Handles sprPricioOrden.ValueChanged
        Dim total As Double = sprPricioOrden.Value * sprCantidadOrden.Value
        lblTotal.Text = CStr(total.ToString("N"))
    End Sub

    Private Sub sprCantidadOrden_ValueChanged(sender As Object, e As EventArgs) Handles sprCantidadOrden.ValueChanged
        Dim total As Double = sprPricioOrden.Value * sprCantidadOrden.Value
        lblTotal.Text = CStr(total.ToString("N"))
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        mtdMaterial.selectOrdersMaterials(tblMaterialAndOrders, txtSearch.Text)
    End Sub

    Private Sub btnDeleteOrder_Click(sender As Object, e As EventArgs) Handles btnDeleteOrder.Click
        If tblMaterialAndOrders.SelectedRows.Count = 1 Then
            If MessageBox.Show("Are you sure to delete this order", "Advertence", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.OK Then
                mtdMaterial.EliminarOrden(tblMaterialAndOrders.CurrentRow.Cells(2).Value)
            End If
        End If
    End Sub

    Private Sub btnUpdateOrder_Click(sender As Object, e As EventArgs) Handles btnUpdateOrder.Click
        If tblMaterialAndOrders.SelectedRows.Count = 1 Then
            chbOrden.Checked = True
            sprCantidadOrden.Value = tblMaterialAndOrders.CurrentRow.Cells.Item(7).Value
            sprPricioOrden.Value = tblMaterialAndOrders.CurrentRow.Cells.Item(5).Value
            dtpFechaOrden.Value = tblMaterialAndOrders.CurrentRow.Cells.Item(6).Value
            idMaterial = tblMaterialAndOrders.CurrentRow.Cells.Item(0).Value
            idOrder = tblMaterialAndOrders.CurrentRow.Cells.Item(2).Value
            flagUpdateOrder = True
        End If
    End Sub

    Private Sub btnOrderSave_Click(sender As Object, e As EventArgs) Handles btnOrderSave.Click
        If flagUpdateOrder Then
            Dim date1 As Date = dtpFechaOrden.Value
            Dim fechaFormato As String = date1.Year.ToString() + "-" + date1.Month.ToString() + "-" + date1.Day.ToString
            mtdMaterial.UpdateOrden(idOrder, sprCantidadOrden.Value, sprPricioOrden.Value, fechaFormato, idMaterial)
            mtdMaterial.selectOrdersMaterials(tblMaterialAndOrders, "%")
        Else
            If sprCantidadOrden.Value > 0.0 Or sprPricioOrden.Value > 0.0 Then
                Dim dataOrderLits As New List(Of String)
                dataOrderLits.Add(idMaterial)
                dataOrderLits.Add(sprCantidadOrden.Value.ToString)
                dataOrderLits.Add(sprPricioOrden.Value.ToString)
                Dim date1 As Date = dtpFechaOrden.Value
                Dim fechaFomato As String = date1.Year.ToString() + "-" + date1.Month.ToString() + "-" + date1.Day.ToString
                dataOrderLits.Add(fechaFomato)
                dataOrderLits.Add(idDM)
                mtdMaterial.nuevaOrden(dataOrderLits)
            Else
                MsgBox("Error. The sistem not permite a 0,0.")
            End If
        End If

    End Sub

    Private Sub tbkVendor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles tbkVendor.MouseDoubleClick
        If dataVendor.Count > 0 Then
            dataVendor.Clear()
        End If
        For Each cell As DataGridViewCell In tbkVendor.CurrentRow.Cells
            dataVendor.Add(cell.Value.ToString)
        Next
        idVedor = dataVendor(0)
        txtNumeroVendedor.Text = dataVendor(1)
        txtNombreVendedor.Text = dataVendor(2)
        txtDescripcionVendedor.Text = dataVendor(3)
        chbEnableVendor.Checked = If(dataVendor(4).Equals("Enable"), True, False)

    End Sub

    Private Sub TabControl1_Selected(sender As Object, e As TabControlEventArgs) Handles TabControl1.Selected
        mtdMaterial.llenarVendorCombo(cmbVendedor, listIdVendors)
        mtdMaterial.selectMaterial(tblMaterial, "")
    End Sub




End Class