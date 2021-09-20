Public Class Login

    Dim mtdLogin As New MetodosLogin
    Dim flag As Boolean = True

    Private Sub btnVer_Click(sender As Object, e As EventArgs)  'Este subproseso es para ver o cultar el contenido del campor de password
        Try
            If flag = True Then ' si flag esta en verdadero entra y desactiva la proteccion 
                txtPassword.UseSystemPasswordChar = False
                flag = False
            Else
                txtPassword.UseSystemPasswordChar = True
                flag = True
                MsgBox("Ten cuidado al desenmascarar la contraseña")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnIniciar_Click(sender As Object, e As EventArgs) Handles btnIniciar.Click
        Try 'verifico que los campos de usuer y password esten llenos
            If (txtUser.Text <> String.Empty And txtUser.Text.Length > 0) And (txtPassword.Text <> String.Empty And txtPassword.Text.Length > 0) Then
                If mtdLogin.StartLogin(txtUser.Text, txtPassword.Text) Then
                    Dim a As New MainFrom
                    a.Show()
                    Me.Visible = False
                Else
                    txtUser.Clear()
                    txtPassword.Clear()
                    txtPassword.UseSystemPasswordChar = True
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        If MessageBox.Show("Desea salir de la aplicacion", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = 1 Then
            Me.Close()
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Try
            If flag = True Then ' si flag esta en verdadero entra y desactiva la proteccion 
                txtPassword.UseSystemPasswordChar = False
                flag = False
            Else
                txtPassword.UseSystemPasswordChar = True
                flag = True
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
