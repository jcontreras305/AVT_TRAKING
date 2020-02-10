Imports System.Data.SqlClient

Public Class MetodosVendor
    Dim conexion As New ConnectioDB


    Private cmb As SqlCommandBuilder
    Public ds As DataSet = New DataSet()
    Public da As SqlDataAdapter
    Public comando As SqlCommand

    Public Sub ConsultaVendor(ByVal sql As String)
        conexion.conectar()
        ds.Tables.Clear()
        da = New SqlDataAdapter(sql, conexion.conn)
        cmb = New SqlCommandBuilder(da)
        da.Fill(ds, "vendor")
    End Sub

    Function InsertarVendor(ByVal sql)
        conexion.conectar()
        comando = New SqlCommand(sql, conexion.conn)

        Dim i As Integer = comando.ExecuteNonQuery()
        If (1 > 0) Then
            Return True
        Else
            Return False
        End If
    End Function

    'METODOS PARA LA INTERFAZ DE TIPOS DE VENDOR
    Public Sub ConsultaVendorTipo(ByVal sql As String)
        conexion.conectar()
        ds.Tables.Clear()
        da = New SqlDataAdapter(sql, conexion.conn)
        cmb = New SqlCommandBuilder(da)
        da.Fill(ds, "tipoVendor")
    End Sub


    Function InsertarTipoVendor(ByVal sql)
        conexion.conectar()
        comando = New SqlCommand(sql, conexion.conn)

        Dim i As String = comando.CommandText
        If (True) Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
