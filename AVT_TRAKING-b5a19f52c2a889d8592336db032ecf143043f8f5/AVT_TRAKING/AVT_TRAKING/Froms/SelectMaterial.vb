Public Class SelectMaterial
    Dim mtd As New MetodosMaterials
    Private Sub SelectMaterial_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dim mt As Materials = CType(Owner, Materials)
        mt.siSeleccionoMaterial = False
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim mt As Materials = CType(Owner, Materials)
        mt.txtDMaterial.Text = tblMaterialSM.CurrentRow.Cells(2).Value.ToString()
        mt.txtRM.Text = tblMaterialSM.CurrentRow.Cells(4).Value.ToString()
        mt.cmbUnidadDeMedida.Text = tblMaterialSM.CurrentRow.Cells(5).Value.ToString()
        mt.cmbUnidadDeMedida.SelectedItem = mt.cmbUnidadDeMedida.FindString(tblMaterialSM.CurrentRow.Cells(5).Value.ToString())
        mt.txtDescripcion.Text = tblMaterialSM.CurrentRow.Cells(6).Value.ToString()
        mt.txtTipo.Text = tblMaterialSM.CurrentRow.Cells(7).Value.ToString()
        mt.sprPrice.Value = tblMaterialSM.CurrentRow.Cells(8).Value.ToString()
        mt.sprPrice.Value = tblMaterialSM.CurrentRow.Cells(9).Value.ToString()
        mt.idMaterial = tblMaterialSM.CurrentRow.Cells(10).Value.ToString()
        mt.idDM = tblMaterialSM.CurrentRow.Cells(0).Value.ToString()
        mt.siSeleccionoMaterial = True
        Me.Close()
    End Sub

    Private Sub txtNameMaterialSM_TextChanged(sender As Object, e As EventArgs) Handles txtNameMaterialSM.TextChanged
        mtd.selectMaterial(tblMaterialSM, txtNameMaterialSM.Text)
    End Sub

    Private Sub tblMaterialSM_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles tblMaterialSM.MouseDoubleClick
        Dim mt As Materials = CType(Owner, Materials)
        mt.txtDMaterial.Text = tblMaterialSM.CurrentRow.Cells(2).Value.ToString()
        mt.txtRM.Text = tblMaterialSM.CurrentRow.Cells(4).Value.ToString()
        mt.cmbUnidadDeMedida.Text = tblMaterialSM.CurrentRow.Cells(5).Value.ToString()
        mt.cmbUnidadDeMedida.SelectedItem = mt.cmbUnidadDeMedida.FindString(tblMaterialSM.CurrentRow.Cells(5).Value.ToString())
        mt.txtDescripcion.Text = tblMaterialSM.CurrentRow.Cells(6).Value.ToString()
        mt.txtTipo.Text = tblMaterialSM.CurrentRow.Cells(7).Value.ToString()
        mt.sprPrice.Value = tblMaterialSM.CurrentRow.Cells(8).Value.ToString()
        mt.sprPrice.Value = tblMaterialSM.CurrentRow.Cells(9).Value.ToString()
        mt.idMaterial = tblMaterialSM.CurrentRow.Cells(10).Value.ToString()
        mt.idDM = tblMaterialSM.CurrentRow.Cells(0).Value.ToString()
        mt.siSeleccionoMaterial = True
        Me.Close()
    End Sub
End Class