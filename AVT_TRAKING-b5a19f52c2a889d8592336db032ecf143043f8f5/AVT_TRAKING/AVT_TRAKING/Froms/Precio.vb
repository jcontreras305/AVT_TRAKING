Imports System.Data.SqlClient

Public Class Precio

    Dim conexion As New ConnectioDB

    Private cmb As SqlCommandBuilder
    Public ds As DataSet = New DataSet()
    Public da As SqlDataAdapter
    Public comando As SqlCommand

    'Metodo para hacer conexión a la tabla precio y obtener la infromación 
    Public Sub ConsultaHerramientas(ByVal sql As String)
        conexion.conectar()
        ds.Tables.Clear()
        da = New SqlDataAdapter(sql, conexion.conn)
        cmb = New SqlCommandBuilder(da)
        da.Fill(ds, "precio")
    End Sub

    Public Sub MostrarDatos()
        ConsultaHerramientas("select * from precio")
        Me.DataGridView1.DataSource = ds.Tables("precio")
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim a As New All_Tables
        a.Show()
        Me.Finalize()
    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        MostrarDatos()
    End Sub

    Function InsertarPrecio(ByVal sql)
        conexion.conectar()
        comando = New SqlCommand(sql, conexion.conn)

        Dim i As Integer = comando.ExecuteNonQuery()
        If (1 > 0) Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim agregar As String = "insert into precio values (" + txtPCompra.Text + ",'" + txtPRenta.Text + "','" +
    txtPventa.Text + "')"

        If (InsertarPrecio(agregar)) Then
            MessageBox.Show("Datos agregados correctamente")
            MostrarDatos()
        Else
            MessageBox.Show("Error al agregar")
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim dgv As DataGridViewRow = DataGridView1.Rows(e.RowIndex)

        txtPCompra.Text = dgv.Cells(0).Value.ToString()
        txtPRenta.Text = dgv.Cells(1).Value.ToString()
        txtPventa.Text = dgv.Cells(2).Value.ToString()



    End Sub
End Class