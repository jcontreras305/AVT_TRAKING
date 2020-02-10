Imports System.Data
Imports System.Data.SqlClient
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
        Dim agregar As String = "insert into materials values (" + txtIdVendor.Text + ",'" + txtIdRenta.Text + "','" +
            txtNameMaterials.Text + "')"

        If (mate.InsertarMaterials(agregar)) Then
            MessageBox.Show("Datos agregados correctamente")
            MostrarDatos()
        Else
            MessageBox.Show("Error al agregar")
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim dgv As DataGridViewRow = DataGridView1.Rows(e.RowIndex)

        txtIdVendor.Text = dgv.Cells(0).Value.ToString()
        txtIdRenta.Text = dgv.Cells(1).Value.ToString()
        txtNameMaterials.Text = dgv.Cells(2).Value.ToString()




    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFiltro.KeyPress
        Dim conn = New SqlConnection("data source=localhost; initial catalog=VRT_TRAKING; integrated security=true")
        Dim da = New SqlDataAdapter("select * from materials where Vendor like '" + txtFiltro.Text + "%'", conn)
        Dim dt = New DataTable
        da.Fill(dt)

        Me.DataGridView1.DataSource = dt
    End Sub

    'Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
    '   Dim actulizar As String = ("UPDATE materials SET Vendor ='" & Me.txtIdVendor.Text & "', MSize ='" & Me.txtIdRenta.Text & "',MType ='" & Me.txtNameMaterials.Text & "',
    '                  MThickness = '" & Me.txtMthickness.Text & "', MPrize ='" & Me.txtMprize.Text & "',MDesc = '" & Me.txtMdesc.Text & "', Class = '" & Me.txtClass.Text & "',
    '                 ElbowType = '" & Me.txtElbowType.Text & ", ElbowThickness ='" & Me.txtElbowThinckness.Text & "', ElbowPrize = '" & Me.txtElbowPrize.Text & "', 
    '                ElbowDesc = '" & Me.txtElbowDesc.Text & "' WHERE IdMaterials =" & Conversion.Int(Me.txtIdMaterials.Text) & "")

    'If (mate.UpdateMaterial(actulizar)) Then
    '       MessageBox.Show("Datos Actualizados correctamente")
    '      MostrarDatos()
    'Else
    '       MessageBox.Show("Error al Actualizar")
    'End If
    'End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim a As New Login
        a.Show()
        Me.Finalize()
    End Sub

    Private Function recolectar() As String()
        Try
            Dim dataMaterials(1) As String
            dataMaterials(0) = txtNameMaterials.Text

            Return dataMaterials
        Catch ex As Exception
            Return Nothing
        End Try

    End Function




    'AQUÍ INICIAN LOS CODIGOS PARA LA INTERFAZ DE LOS DETALLES DE LOS MATERIALES 
    Private Sub btnSaveDetallesMaterials_Click(sender As Object, e As EventArgs) Handles btnSaveDetallesMaterials.Click
        Dim agregar As String = "insert into DetallesMaterials values (" + txtDMaterial.Text + ",'" + txtRM.Text + "','" +
    txtUM.Text + "','" + txtMSize.Text + "','" + txtMType.Text + "','" + txtMTychness.Text +
    "','" + txtMprice.Text + "','" + txtDescripcion.Text + "','" + txtCantidad.Text + "')"

        If (mate.InsertarDetalleMaterial(agregar)) Then
            MessageBox.Show("Datos agregados correctamente")
            MostrarDetallesMateriales()
        Else
            MessageBox.Show("Error al agregar")
        End If
    End Sub

    Public Sub MostrarDetallesMateriales()
        mate.ConsultaDetallesMaterials("select * from DetallesMaterials")
        Me.DataGridView2.DataSource = mate.ds.Tables("DetallesMaterials")

    End Sub


    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        Dim dgv1 As DataGridViewRow = DataGridView2.Rows(e.RowIndex)

        txtDMaterial.Text = dgv1.Cells(0).Value.ToString()
        txtRM.Text = dgv1.Cells(1).Value.ToString()
        txtUM.Text = dgv1.Cells(2).Value.ToString()
        txtMSize.Text = dgv1.Cells(3).Value.ToString()
        txtMType.Text = dgv1.Cells(4).Value.ToString()
        txtMTychness.Text = dgv1.Cells(5).Value.ToString()
        txtMprice.Text = dgv1.Cells(6).Value.ToString()
        txtDescripcion.Text = dgv1.Cells(7).Value.ToString()
        txtCantidad.Text = dgv1.Cells(8).Value.ToString()
    End Sub

    Private Sub btnQueryDetalleM_Click(sender As Object, e As EventArgs) Handles btnQueryDetalleM.Click
        MostrarDetallesMateriales()
    End Sub
End Class