Imports System.Data.SqlClient 'Esta es la clase que nos permite ser cliente que solicita el servicio de base de datos
Imports System.IO
Public Class ConnectioDB
    Public sqlConn As String = ""
    'Public DirectoryServer As String = "\\Desktop-s806jiq"
    'Public DirectoryFolderServer As String = "\\Desktop-s806jiq\tmp\"
    Public conn As SqlConnection 'conn es un atributo de esta clase que podra se llamada de otras clases y obtener la conexion de la BD
    ''' <summary>
    ''' Esta funcion permite conectar al servidor con la base de datos "VRT_TRAKING"
    ''' </summary>
    ''' <returns></returns>
    Public Function conectar() As Boolean 'Esta funcion nos permite abrir la conexion de la base de datos 
        Try
            If sqlConn = "" Then
                If readFileConn() Then
                    'conn = New SqlConnection("Data Source=" + ds.Server.Rows(0).ItemArray(0) + "; Initial Catalog=VRT_TRAKING ; User Id=" + ds.Server.Rows(0).ItemArray(1) + ";Password=" + ds.Server.Rows(0).ItemArray(2) + ";")
                    conn = New SqlConnection(sqlConn)
                    conn.Open()
                    If conn.State Then 'comprueba si la conexion esta habilitada 
                        'Aqui podemos mandar un mesaje que nos diga si fue o no conectado
                        'MsgBox("Conexion abierta")
                        Return True
                    Else
                        MsgBox("Error: Unable to connect to the server.") 'mesaje de error
                        Return False
                    End If
                Else
                    Return False
                End If
            Else
                conn = New SqlConnection(sqlConn)
                conn.Open()
                If conn.State Then 'comprueba si la conexion esta habilitada 
                    'Aqui podemos mandar un mesaje que nos diga si fue o no conectado
                    'MsgBox("Conexion abierta")
                    Return True
                Else
                    MsgBox("La Conexion a la base de datos no se pudo realizar") 'mesaje de error
                    Return False
                End If
            End If

            'conn = New SqlConnection("Data Source=localhost; Initial Catalog=VRT_TRAKING ; Integrated Security=true")
            'conn.Open() 'se abre la conexion
            'If conn.State Then 'comprueba si la conexion esta habilitada 
            '    'Aqui podemos mandar un mesaje que nos diga si fue o no conectado
            '    'MsgBox("Conexion abierta")
            'Else
            '    MsgBox("La Conexion a la base de datos no se pudo realizar") 'mesaje de error
            'End If
        Catch ex As Exception
            MsgBox(ex.Message) 'Exepcion de al conectar a la base de datos
            Return False
        End Try
    End Function
    ''' <summary>
    ''' Esta funcion permite conectar y verificar si existe la conexion con el servidor especificado
    ''' </summary>
    ''' <returns></returns>
    Public Function connectToServer(ByVal connectionInfo As String) As Boolean 'Esta funcion nos permite abrir la conexion de la base de datos 
        Try
            conn = New SqlConnection(connectionInfo)
            conn.Open() 'se abre la conexion
            If conn.State Then 'comprueba si la conexion esta habilitada 
                conn.Close()
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message) 'Exepcion de al conectar a la base de datos
            Return False
        End Try
    End Function
    ''' <summary>
    ''' Esta funcion permite conectar y verificar si existe la conexion con el servidor especificado
    ''' </summary>
    ''' <returns></returns>
    Public Function connectToServer() As Boolean 'Esta funcion nos permite abrir la conexion de la base de datos 
        Try
            If readFileConn() Then
                Dim connectioninfo As String = ""
                Dim array As String() = sqlConn.Split(";")
                If array.Length = 3 Then
                    connectioninfo = array(0) + ";" + "Database=master;" + array(2)
                ElseIf array.Length >= 4 Then
                    connectioninfo = array(0) + ";" + "Database=master;" + array(2) + ";" + array(3)
                End If
                conn = New SqlConnection(connectioninfo)
                conn.Open() 'se abre la conexion
                If conn.State Then 'comprueba si la conexion esta habilitada 
                    findServer(connectioninfo)
                    Return True
                Else
                    Return False
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message) 'Exepcion de al conectar a la base de datos
            Return False
        End Try
    End Function
    ''' <summary>
    ''' Esta funcion desconecta la coneccion actual
    ''' </summary>
    ''' <returns></returns>
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

    Private Function readFileConn() As Boolean
        Try
            'If File.Exists(AppDomain.CurrentDomain.BaseDirectory + "connTemp.txt") Then
            '    Dim read As TextReader = New StreamReader(AppDomain.CurrentDomain.BaseDirectory + "connTemp.txt"
            If File.Exists(LocalFolderDiretory + "connTemp.txt") Then
                Dim read As TextReader = New StreamReader(LocalFolderDiretory + "connTemp.txt")
                sqlConn = read.ReadLine
                findServer(sqlConn)
                read.Close()
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class
