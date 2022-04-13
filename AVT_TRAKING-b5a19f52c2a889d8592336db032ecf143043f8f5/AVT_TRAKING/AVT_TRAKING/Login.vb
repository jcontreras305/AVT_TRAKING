Imports System.Runtime.InteropServices

Public Class Login

    Dim mtdLogin As New MetodosLogin
    Dim mtdOther As New MetodosOthers
    Dim mtdCompany As New metodosCompany
    Dim flag As Boolean = True
    Dim listImg As List(Of Byte())
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            listImg = mtdOther.llenarComboImage(cmbImagenes)
            mtdCompany.cargarDatos()
            If listImg IsNot Nothing And listImg.Count > 0 Then
                cmbImagenes.SelectedIndex = 0
                cmbImagenes.SelectedItem = cmbImagenes.Items(0)
            End If
        Catch ex As Exception

        End Try
    End Sub

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
                    Try
                        If mtdCompany.img IsNot Nothing Then
                            a.pcbLogoMain.Image = mtdCompany.img
                        End If
                        If listImg IsNot Nothing And listImg.Count > 0 Then
                            Dim arrayByte As Byte() = listImg(cmbImagenes.SelectedIndex)
                            a.imageClientLogin = BytetoImage(arrayByte)
                        End If
                    Catch ex As Exception
                    End Try
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

    Private Sub btnExit_Click(sender As Object, e As EventArgs)
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

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Application.Exit()
    End Sub

    Private Sub btnMinimize_Click(sender As Object, e As EventArgs) Handles btnMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(hWnd As IntPtr, wMsg As Integer, wParam As Integer, lParam As Integer)
    End Sub

    Private Sub TitleBar_MouseMove(sender As Object, e As MouseEventArgs) Handles TitleBar.MouseMove
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub Login_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub btnIniciar_Paint(sender As Object, e As PaintEventArgs) Handles btnIniciar.Paint
        Dim buttonPath As Drawing2D.GraphicsPath = New Drawing2D.GraphicsPath()
        Dim myRectangule As Rectangle = btnIniciar.ClientRectangle
        myRectangule.Inflate(0, 30)
        buttonPath.AddEllipse(myRectangule)
        btnIniciar.Region = New Region(buttonPath)

    End Sub
    Private Sub btnMaximize_Click(sender As Object, e As EventArgs)
        Me.WindowState = FormWindowState.Maximized
    End Sub
End Class
