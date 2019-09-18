Imports System.Data.SqlClient 'Esta es la clase que nos permite ser cliente que solicita el servicio de base de datos

Public Class ConnectioDB

    Public conn As SqlConnection 'conn es un atributo de esta clase que podra se llamada de otras clases y obtener la conexion de la BD

    Public Function conectar() 'Esta funcion nos permite abrir la conexion de la base de datos 
        Try
            conn = New SqlConnection("data source=localhost; initial catalog=VRT_TRAKING; integrated security=true")
            conn.Open() 'se abre la conexion
            If conn.State Then 'comprueba si la conexion esta habilitada 
                'Aqui podemos mandar un mesaje que nos diga si fue o no conectado
                MsgBox("Conexion abierta")
            Else
                MsgBox("La Conexion a la base de datos no se pudo realizar") 'mesaje de error
            End If

        Catch ex As Exception
            MsgBox(ex.Message) 'Exepcion de al conectar a la base de datos
        End Try
        Return True
    End Function

    Public Function desconectar() 'Esta funcion cierra la conexion (es por seguridad no tenerla siempres abierta solo en los casos necesarios)
        Try
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return False
    End Function

End Class
