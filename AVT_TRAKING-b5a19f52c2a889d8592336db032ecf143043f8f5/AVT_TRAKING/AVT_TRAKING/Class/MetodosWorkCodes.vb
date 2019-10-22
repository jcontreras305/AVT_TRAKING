Imports System.Data.SqlClient

Public Class MetodosWorkCodes

    Dim conexion As New ConnectioDB
    Private cmb As SqlCommandBuilder
    Public ds As DataSet = New DataSet()
    Public da As SqlDataAdapter
    Public comando As SqlCommand

    Public Sub ConsultaWorkCodes(ByVal sql As String)
        conexion.conectar()
        ds.Tables.Clear()
        da = New SqlDataAdapter(sql, conexion.conn)
        cmb = New SqlCommandBuilder(da)
        da.Fill(ds, "WorkCode")
    End Sub

    Function InsertarWorkCodes(ByVal sql)
        conexion.conectar()
        comando = New SqlCommand(sql, conexion.conn)

        Dim i As Integer = comando.ExecuteNonQuery()
        If (1 > 0) Then
            Return True
        Else
            Return False
        End If
    End Function


End Class
