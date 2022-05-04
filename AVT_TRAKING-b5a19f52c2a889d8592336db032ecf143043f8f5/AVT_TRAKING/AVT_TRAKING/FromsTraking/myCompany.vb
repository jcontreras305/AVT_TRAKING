Imports System.ComponentModel
Imports System.Runtime.InteropServices
Public Class myCompany
    Dim mtdCompany As New metodosCompany
    Dim loadInfo As Boolean
    Private Sub myCompany_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mtdCompany.cargarDatos()
        loadInfo = True
        txtAddress.Text = mtdCompany.address
        txtCity.Text = mtdCompany.city
        txtCountry.Text = mtdCompany.country
        txtEmail.Text = mtdCompany.email
        txtInvoceDescription.Text = mtdCompany.invoiceDescr
        txtFaxNumber.Text = mtdCompany.faxNumber
        txtNameCompany.Text = mtdCompany.name
        txtNum.Text = mtdCompany.number
        'txtPaymentTerms.Text = mtdCompany.paymentTerms
        txtPhoneNumber.Text = mtdCompany.phoneNumber
        txtPostalCode.Text = mtdCompany.postalCode
        txtStateProvidence.Text = mtdCompany.stateProvidence
        imgPhoto.Image = mtdCompany.img
        loadInfo = False
    End Sub

    Private Sub myCompany_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If validarDatos() Then
            mtdCompany.updateCompany()
        End If
    End Sub

    Private Sub txtNum_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNum.KeyPress
        If Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = Keys.Back Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtNum_TextChanged(sender As Object, e As EventArgs) Handles txtNum.TextChanged
        If loadInfo = False Then
            mtdCompany.number = txtNum.Text
        End If
    End Sub

    Private Sub txtPhoneNumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPhoneNumber.KeyPress
        If Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = Keys.Back Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtPhoneNumber_TextChanged(sender As Object, e As EventArgs) Handles txtPhoneNumber.TextChanged
        If loadInfo = False Then
            mtdCompany.phoneNumber = txtPhoneNumber.Text
        End If
    End Sub

    Private Sub txtFaxNumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFaxNumber.KeyPress
        If Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = Keys.Back Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtFaxNumber_TextChanged(sender As Object, e As EventArgs) Handles txtFaxNumber.TextChanged
        If loadInfo = False Then
            mtdCompany.faxNumber = txtFaxNumber.Text
        End If
    End Sub

    Private Sub txtPostalCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPostalCode.KeyPress, TextBox1.KeyPress
        If Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = Keys.Back Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtPostalCode_TextChanged(sender As Object, e As EventArgs) Handles txtPostalCode.TextChanged, TextBox1.TextChanged
        If loadInfo = False Then
            mtdCompany.postalCode = txtPostalCode.Text
        End If
    End Sub

    Private Sub txtEmail_TextChanged(sender As Object, e As EventArgs) Handles txtEmail.TextChanged
        If loadInfo = False Then
            mtdCompany.email = txtEmail.Text
            If validar_Correo(txtEmail.Text) Then
                lblEmail.Visible = False
            Else
                lblEmail.Visible = True
            End If
        End If
    End Sub

    Private Sub txtAddress_TextChanged(sender As Object, e As EventArgs) Handles txtAddress.TextChanged
        If loadInfo = False Then
            mtdCompany.address = txtAddress.Text
        End If
    End Sub

    Private Sub txtCity_TextChanged(sender As Object, e As EventArgs) Handles txtCity.TextChanged
        If loadInfo = False Then
            mtdCompany.city = txtCity.Text
        End If
    End Sub

    Private Sub txtCountry_TabIndexChanged(sender As Object, e As EventArgs) Handles txtCountry.TabIndexChanged
        If loadInfo = False Then
            mtdCompany.country = txtCountry.Text
        End If
    End Sub

    Private Sub txtInvoceDescription_TextChanged(sender As Object, e As EventArgs) Handles txtInvoceDescription.TextChanged
        If loadInfo = False Then
            mtdCompany.invoiceDescr = txtInvoceDescription.Text
        End If
    End Sub

    Private Sub txtNameCompany_TextChanged(sender As Object, e As EventArgs) Handles txtNameCompany.TextChanged
        If loadInfo = False Then
            mtdCompany.name = txtNameCompany.Text
        End If
    End Sub

    Private Sub txtNameCompany_LostFocus(sender As Object, e As EventArgs) Handles txtNameCompany.LostFocus
        If loadInfo = False Then
            If txtNameCompany.Text.Split(" ").Length > 0 Or txtNameCompany.Text = "" Then
                mtdCompany.city = txtCity.Text
            Else
                txtCity.Text = mtdCompany.city
            End If
        End If
    End Sub
    'Private Sub txtPaymenTerms_TextChanged(sender As Object, e As EventArgs)
    '    If loadInfo = False Then
    '        mtdCompany.paymentTerms = txtPaymentTerms.Text
    '    End If
    'End Sub
    Private Sub txtStateProvidence_TextChanged(sender As Object, e As EventArgs) Handles txtStateProvidence.TextChanged
        If loadInfo = False Then
            mtdCompany.stateProvidence = txtStateProvidence.Text
        End If
    End Sub

    Private Function validarDatos() As Boolean
        Dim mensaje As String = ""
        If txtNameCompany.Text = "" Then
            mensaje = mensaje + If(mensaje = "", "The Copany Name is Null.", vbCrLf + "The Copany Name is Null.")
        End If
        If Not soloNumero(txtNum.Text) Then
            mensaje = mensaje + If(mensaje = "", "The NUMBER from you address it have Caracters no valids.", vbCrLf + "The NUMBER from you address it have Caracters no valids.")
        End If
        If Not soloNumero(txtPostalCode.Text) Then
            mensaje = mensaje + If(mensaje = "", "The Postal Code from you address it have Caracters no valids.", vbCrLf + "The Postal Code from you address it have Caracters no valids.")
        End If
        If Not soloNumero(txtPhoneNumber.Text) Then
            mensaje = mensaje + If(mensaje = "", "The Phone Number from you contact it have Caracters no valids.", vbCrLf + "The Phone Number from you contact it have Caracters no valids.")
        End If
        If mensaje = "" Then
            Return True
        Else
            If DialogResult.Yes = MessageBox.Show(mensaje + vbCrLf + "Whould you like to continue?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) Then
                Return True
            Else
                Return False
            End If
        End If

    End Function

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


    Private Sub btnMaximize_Click(sender As Object, e As EventArgs) Handles btnMaximize.Click
        WindowState = FormWindowState.Maximized
        btnMaximize.Visible = False
        btnRestore.Visible = True
    End Sub

    Private Sub btnRestore_Click(sender As Object, e As EventArgs) Handles btnRestore.Click
        WindowState = FormWindowState.Normal
        btnRestore.Visible = False
        btnMaximize.Visible = True
    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
    End Sub

    Private Sub btnFindImage_Click(sender As Object, e As EventArgs) Handles btnFindImage.Click
        Try
            Dim file As New OpenFileDialog
            file.Filter = "Imagenes JPG|*.jpg|Images PNG|*.png"
            If file.ShowDialog = Windows.Forms.DialogResult.OK Then
                imgPhoto.Image = Image.FromFile(file.FileName)
                mtdCompany.img = Image.FromFile(file.FileName)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class