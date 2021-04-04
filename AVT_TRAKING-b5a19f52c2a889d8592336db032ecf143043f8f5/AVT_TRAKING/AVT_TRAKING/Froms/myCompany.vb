Imports System.ComponentModel

Public Class myCompany
    Dim mtdCompany As New metodosCompany
    Private Sub myCompany_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mtdCompany.cargarDatos()
        txtAddress.Text = mtdCompany.address
        txtCity.Text = mtdCompany.city
        txtCountry.Text = mtdCompany.country
        txtEmail.Text = mtdCompany.email
        txtInvoceDescription.Text = mtdCompany.invoiceDescr
        txtFaxNumber.Text = mtdCompany.faxNumber
        txtNameCompany.Text = mtdCompany.name
        txtNum.Text = mtdCompany.number
        txtPaymenTerms.Text = mtdCompany.paymentTerms
        txtPhoneNumber.Text = mtdCompany.phoneNumber
        txtPostalCode.Text = mtdCompany.postalCode
        txtStateProvidence.Text = mtdCompany.stateProvidence
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
        mtdCompany.number = txtNum.Text
    End Sub

    Private Sub txtPhoneNumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPhoneNumber.KeyPress
        If Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = Keys.Back Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtPhoneNumber_TextChanged(sender As Object, e As EventArgs) Handles txtPhoneNumber.TextChanged
        mtdCompany.phoneNumber = txtPhoneNumber.Text
    End Sub

    Private Sub txtFaxNumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFaxNumber.KeyPress
        If Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = Keys.Back Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtFaxNumber_TextChanged(sender As Object, e As EventArgs) Handles txtFaxNumber.TextChanged
        mtdCompany.faxNumber = txtFaxNumber.Text
    End Sub

    Private Sub txtPostalCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPostalCode.KeyPress
        If Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = Keys.Back Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtPostalCode_TextChanged(sender As Object, e As EventArgs) Handles txtPostalCode.TextChanged
        mtdCompany.postalCode = txtPostalCode.Text
    End Sub

    Private Sub txtEmail_TextChanged(sender As Object, e As EventArgs) Handles txtEmail.TextChanged
        mtdCompany.email = txtEmail.Text
        If validar_Correo(txtEmail.Text) Then
            lblEmail.Visible = False
        Else
            lblEmail.Visible = True
        End If
    End Sub

    Private Sub txtAddress_TextChanged(sender As Object, e As EventArgs) Handles txtAddress.TextChanged
        mtdCompany.address = txtAddress.Text
    End Sub

    Private Sub txtCity_TextChanged(sender As Object, e As EventArgs) Handles txtCity.TextChanged
        mtdCompany.city = txtCity.Text
    End Sub

    Private Sub txtCountry_TabIndexChanged(sender As Object, e As EventArgs) Handles txtCountry.TabIndexChanged
        mtdCompany.country = txtCountry.Text
    End Sub

    Private Sub txtInvoceDescription_TextChanged(sender As Object, e As EventArgs) Handles txtInvoceDescription.TextChanged
        mtdCompany.invoiceDescr = txtInvoceDescription.Text
    End Sub

    Private Sub txtNameCompany_TextChanged(sender As Object, e As EventArgs) Handles txtNameCompany.TextChanged
        mtdCompany.name = txtNameCompany.Text
    End Sub

    Private Sub txtNameCompany_LostFocus(sender As Object, e As EventArgs) Handles txtNameCompany.LostFocus
        If txtNameCompany.Text.Split(" ").Length > 0 Or txtNameCompany.Text = "" Then
            mtdCompany.city = txtCity.Text
        Else
            txtCity.Text = mtdCompany.city
        End If
    End Sub

    Private Sub txtPaymenTerms_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPaymenTerms.KeyPress
        mtdCompany.paymentTerms = txtPaymenTerms.Text
    End Sub

    Private Sub txtStateProvidence_TextChanged(sender As Object, e As EventArgs) Handles txtStateProvidence.TextChanged
        mtdCompany.stateProvidence = txtStateProvidence.Text
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
End Class