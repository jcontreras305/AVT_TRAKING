Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Text
Public Class ServerConn
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(hWnd As IntPtr, wMsg As Integer, wParam As Integer, lParam As Integer)
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.Close()
    End Sub

    Private Sub btnVerify_Click(sender As Object, e As EventArgs) Handles btnVerify.Click
        Try
            lblMessage.Text = "Message: Connecting..."
            Dim con As New ConnectioDB
            Dim info As String
            If txtServer.Text = "localhost" Then
                info = "Server=" + txtServer.Text + ";Database=VRT_TRAKING;Trusted_Connection=True;"
            Else
                info = "Server=" + txtServer.Text + ";Database=VRT_TRAKING;User Id=" + txtUser.Text + ";Password=" + txtPassword.Text + ";"
            End If
            If con.connectToServer(info) Then
                lblMessage.Text = "Message: The connection is successfull. ✓"
                btnSave.Enabled = True
            Else
                lblMessage.Text = "Message: Unable to connect to the server. X"
                btnSave.Enabled = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim con As New ConnectioDB
            Dim path As String = AppDomain.CurrentDomain.BaseDirectory + "connTemp.txt"
            Dim fs As FileStream
            If Not File.Exists(path) Then
                fs = File.Create(path)
            Else
                File.Delete(path)
                fs = File.Create(path)
            End If
            Dim info As Byte()
            If txtServer.Text = "localhost" Then
                info = New UTF8Encoding(True).GetBytes("Server=" + txtServer.Text + ";Database=VRT_TRAKING;Trusted_Connection=True;")
            Else
                info = New UTF8Encoding(True).GetBytes("Server=" + txtServer.Text + ";Database=VRT_TRAKING;User Id=" + txtUser.Text + ";Password=" + txtPassword.Text + ";")
            End If
            fs.Write(info, 0, info.Length)
            fs.Close()
            lblMessage.Text = "Message: Now the connection is saved."
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtServer_TextChanged(sender As Object, e As EventArgs) Handles txtServer.TextChanged
        btnSave.Enabled = False
    End Sub

    Private Sub txtUser_TextChanged(sender As Object, e As EventArgs) Handles txtUser.TextChanged
        btnSave.Enabled = False
    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged
        btnSave.Enabled = False
    End Sub
End Class