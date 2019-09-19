Imports System.Data.SqlClient

Public Class MetodosLogin

    Inherits ConnectioDB 'el inherit nos permite entre clases llamar las funcion y atributos publicos de otra calse como si fuese 1

    'Dim con As New ConnectioDB ' tambien podemos hacer una instacia de una clase pero es diferente la forma de llamar las funciones o atributos

    Public Function StartLogin(user As String, password As String) As Boolean
        Try
            conectar() 'esto es con el inherit 
            'con.conectar() 'esto es con la instancia a la clase
            Dim cmd As New SqlCommand("select * from users where nameUser = '" + user + "' and passwordUser = '" + password + "'", conn)
            If cmd.ExecuteNonQuery Then
                Dim dataTable As New DataTable ' es para tener una tabla igual como la que se muestra en las consultas en la DB
                Dim dataAdapter As New SqlDataAdapter(cmd)
                dataAdapter.Fill(dataTable)
                If dataTable.Rows.Count >= 1 Then 'si encontro por lo menos 1 usuario da la bien benida y retorna true
                    MsgBox("Welcome")
                    Return True
                Else ' si se pudo ejecutar pero no encontro como minimo 1 usuario regresa false
                    Return False
                End If
            Else 'Si no se pudo ejecutar regresa falso
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
End Class
