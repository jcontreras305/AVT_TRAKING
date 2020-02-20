Public Class Herramientas
    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    Dim herramineta As MetodosHerramientas = New MetodosHerramientas

    Public Sub MostrarDatos()
        herramineta.ConsultaHerramientas("select * from herramientas")
        Me.DataGridView1.DataSource = herramineta.ds.Tables("herramientas")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim a As New All_Tables
        a.Show()
        Me.Finalize()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnSaveH.Click
        Dim agregar As String = "insert into herramientas values (" + txtVendor.Text + ",'" + txtRentaH.Text + "','" +
    txtNombreH.Text + "')"

        If (herramineta.InsertarHerramienta(agregar)) Then
            MessageBox.Show("Datos agregados correctamente")
            MostrarDatos()
        Else
            MessageBox.Show("Error al agregar")
        End If
    End Sub

    Private Sub btnQueryH_Click(sender As Object, e As EventArgs) Handles btnQueryH.Click
        MostrarDatos()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim agregar As String = "insert into DetallesHerramientas values (" + txtDHerramienta.Text + ",'" + txtRMateriales.Text + "','" +
    txtUnidadM.Text + "','" + txtidPricio.Text + "','" + txtHSize.Text + "','" + txtHType.Text + "','" + txtHTyckness.Text +
     "','" + txtDescripcion.Text + "','" + txtCantidad.Text + "')"

        If (herramineta.InsertarHerramienta(agregar)) Then
            MessageBox.Show("Datos agregados correctamente")
            'MostrarDetallesMateriales()
        Else
            MessageBox.Show("Error al agregar")
        End If

        MostrarDetallesHerramientas()
    End Sub

    Public Sub MostrarDetallesHerramientas()
        herramineta.ConsultaDetallesH("select * from DetallesHerramientas")
        Me.DataGridView2.DataSource = herramineta.ds.Tables("DetallesHerramientas")
    End Sub
    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        MostrarDetallesHerramientas()
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        Dim dgv As DataGridViewRow = DataGridView2.Rows(e.RowIndex)

        txtDHerramienta.Text = dgv.Cells(1).Value.ToString()
        txtRMateriales.Text = dgv.Cells(2).Value.ToString()
        txtUnidadM.Text = dgv.Cells(3).Value.ToString()
        txtidPricio.Text = dgv.Cells(4).Value.ToString()
        txtHSize.Text = dgv.Cells(5).Value.ToString()
        txtHType.Text = dgv.Cells(6).Value.ToString()
        txtHTyckness.Text = dgv.Cells(7).Value.ToString()
        txtDescripcion.Text = dgv.Cells(8).Value.ToString()
        txtCantidad.Text = dgv.Cells(9).Value.ToString()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim dgv As DataGridViewRow = DataGridView1.Rows(e.RowIndex)

        txtVendor.Text = dgv.Cells(1).Value.ToString()
        txtRentaH.Text = dgv.Cells(2).Value.ToString()
        txtNombreH.Text = dgv.Cells(3).Value.ToString()

    End Sub
End Class