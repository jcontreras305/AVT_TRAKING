Imports System.Data.SqlClient
Imports System.IO
Imports System.Text
Public Class ServerConnection
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.Close()
    End Sub

    Private Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        conectar(txtServer.Text, txtUser.Text, txtPass.Text)
    End Sub
    Public Function conectar(ByVal Server As String, ByVal User As String, ByVal pass As String) 'Esta funcion nos permite abrir la conexion de la base de datos 
        Try
            Dim sqlconn As String = ""
            If txtServer.Text = "localhost" Then
                sqlconn = "Data Source=localhost; Initial Catalog=VRT_TRAKING ; Integrated Security=true"
            Else
                sqlconn = "Data Source=" + Server + "; Initial Catalog=VRT_TRAKING ; User Id=" + User + ";Password=" + pass + ";"
            End If
            Dim conn = New SqlConnection(sqlconn)
            conn.Open() 'se abre la conexion

            If conn.State Then 'comprueba si la conexion esta habilitada 
                lblMessage.Text = "Message: The connection is successful."
                'Aqui podemos mandar un mesaje que nos diga si fue o no conectado
                'MsgBox("Conexion abierta")
            Else
                lblMessage.Text = "Message: Is not prosible to connect." 'mesaje de error
            End If
        Catch ex As Exception
            MsgBox(ex.Message) 'Exepcion de al conectar a la base de datos
        End Try
        Return True
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim path = AppDomain.CurrentDomain.BaseDirectory + "conn.txt"
            Dim content As String
            If txtServer.Text = "localhost" Then
                content = "Data Source=localhost; Initial Catalog=VRT_TRAKING ; Integrated Security=true"
            Else
                content = "Data Source=" + txtServer.Text + "; Initial Catalog=VRT_TRAKING ; User Id=" + txtUser.Text + ";Password=" + txtPass.Text + ";"
            End If
            Dim fl As FileStream = File.Create(path)
            Dim info As Byte() = New UTF8Encoding(True).GetBytes(content)
            fl.Write(info, 0, info.Length)
            fl.Close()
        Catch ex As Exception

        End Try
    End Sub
End Class