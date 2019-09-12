Public Class Login

    Dim mtdLogin As New MetodosLogin
    Dim flag As Boolean = True

    Private Sub btnVer_Click(sender As Object, e As EventArgs) Handles btnVer.Click
        Try
            If flag = True Then
                txtPassword.UseSystemPasswordChar = False
                flag = False
            Else
                txtPassword.UseSystemPasswordChar = True
                flag = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnIniciar_Click(sender As Object, e As EventArgs) Handles btnIniciar.Click
        Try 'verifico que los campos de usuer y password esten llenos
            If (txtUser.Text <> String.Empty And txtUser.Text.Length > 0) And (txtPassword.Text <> String.Empty And txtPassword.Text.Length > 0) Then
                If mtdLogin.StartLogin(txtUser.Text, txtPassword.Text) Then
                    MainFrom.Show()
                Else
                    txtUser.Clear()
                    txtPassword.Clear()
                    txtPassword.UseSystemPasswordChar = True
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
