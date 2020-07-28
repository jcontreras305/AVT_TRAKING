Public Class Vendor

    Dim vendor As MetodosVendor = New MetodosVendor

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim a As New All_Tables
        a.Show()
        Me.Finalize()
    End Sub

    Public Sub MostrarDatos()
        vendor.ConsultaVendor("select * from vendor")
        Me.DataGridView2.DataSource = vendor.ds.Tables("vendor")
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim agregar As String = "insert into vendor values (" + txtTvendor.Text + ",'" + txtNombre.Text + "','" +
    txtDescripcion.Text + "')"

        If (vendor.InsertarVendor(agregar)) Then
            MessageBox.Show("Datos agregados correctamente")
            MostrarDatos()
        Else
            MessageBox.Show("Error al agregar")
        End If
    End Sub

    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        MostrarDatos()

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

        Dim dgv As DataGridViewRow = DataGridView2.Rows(e.RowIndex)

        txtTvendor.Text = dgv.Cells(0).Value.ToString()
        txtNombre.Text = dgv.Cells(1).Value.ToString()
        txtDescripcion.Text = dgv.Cells(2).Value.ToString()
    End Sub


    'CODIGO PARA LA INTERFAZ DE TIPOS DE VENDOR

    Public Sub MostrarDatosTipoVendor()
        vendor.ConsultaVendorTipo("select * from tipoVendor")
        Me.DataGridView1.DataSource = vendor.ds.Tables("tipoVendor")
    End Sub


    Private Sub btnSaveTV_Click(sender As Object, e As EventArgs) Handles btnSaveTV.Click
        Dim agregar As String = "insert into tipoVendor values (" + txtTipoVendor.Text + ",'" + txtDescripcionV.Text + "','" + "')"

        If (vendor.InsertarTipoVendor(agregar)) Then
            MessageBox.Show("Datos agregados correctamente")
            MostrarDatos()
        Else
            MessageBox.Show("Error al agregar")
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim dgv As DataGridViewRow = DataGridView1.Rows(e.RowIndex)

        txtTipoVendor.Text = dgv.Cells(0).Value.ToString()
        txtDescripcionV.Text = dgv.Cells(1).Value.ToString()
        'txtStatus.Text = dgv.Cells(2).Value.ToString()
    End Sub

    Private Sub btnQueryTV_Click(sender As Object, e As EventArgs) Handles btnQueryTV.Click
        MostrarDatosTipoVendor()
    End Sub
End Class