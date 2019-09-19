Public Class Materials


    Dim mate As MetodosMaterials = New MetodosMaterials()
    Private Sub Materials_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub MostrarDatos()
        mate.ConsultaMaterials("select * from materials")
        Me.DataGridView1.DataSource = mate.ds.Tables("materials")

    End Sub

    Private Sub BtnMenu_Click(sender As Object, e As EventArgs) Handles btnMenu.Click
        Dim a As New MainFrom
        a.Show()
        Me.Finalize()
    End Sub

    Private Sub BtnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        MostrarDatos()

    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim agregar As String = "insert into materials values (" + txtIdMaterials.Text + ",'" + txtVendor.Text + "','" +
            txtMsize.Text + "','" + txtMtype.Text + "','" + txtMthickness.Text + "','" + txtMprize.Text + "','" + txtMdesc.Text + "','" + txtClass.Text + "',
            '" + txtElbowType.Text + "','" + txtElbowThinckness.Text + "','" + txtElbowPrize.Text + "','" + txtElbowDesc.Text + "')"

        If (mate.InsertarMaterials(agregar)) Then
            MessageBox.Show("Datos agregados correctamente")
            MostrarDatos()
        Else
            MessageBox.Show("Error al agregar")
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim dgv As DataGridViewRow = DataGridView1.Rows(e.RowIndex)

        txtIdMaterials.Text = dgv.Cells(0).Value.ToString()
        txtVendor.Text = dgv.Cells(1).Value.ToString()
        txtMsize.Text = dgv.Cells(2).Value.ToString()
        txtMtype.Text = dgv.Cells(3).Value.ToString()
        txtMthickness.Text = dgv.Cells(4).Value.ToString()
        txtMprize.Text = dgv.Cells(5).Value.ToString()
        txtMdesc.Text = dgv.Cells(6).Value.ToString()
        txtClass.Text = dgv.Cells(7).Value.ToString()
        txtElbowType.Text = dgv.Cells(8).Value.ToString()
        txtElbowThinckness.Text = dgv.Cells(9).Value.ToString()
        txtElbowPrize.Text = dgv.Cells(10).Value.ToString()
        txtElbowDesc.Text = dgv.Cells(11).Value.ToString()

    End Sub
End Class