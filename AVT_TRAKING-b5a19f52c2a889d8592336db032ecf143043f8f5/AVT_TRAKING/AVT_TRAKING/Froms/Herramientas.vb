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

    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        MostrarDatos()
    End Sub

    Private Sub btnQueryH_Click(sender As Object, e As EventArgs) Handles btnQueryH.Click
        MostrarDatos()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim agregar As String = "insert into DetallesMaterials values (" + txtDHerramienta.Text + ",'" + txtRMateriales.Text + "','" +
    txtUnidadM.Text + "','" + txtHSize.Text + "','" + txtHType.Text + "','" + txtHTyckness.Text +
    "','" + txtHPrice.Text + "','" + txtDescripcion.Text + "','" + txtCantidad.Text + "')"

        If (herramineta.InsertarHerramienta(agregar)) Then
            MessageBox.Show("Datos agregados correctamente")
            'MostrarDetallesMateriales()
        Else
            MessageBox.Show("Error al agregar")
        End If
    End Sub

End Class