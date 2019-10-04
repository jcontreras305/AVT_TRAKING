Public Class Employees
    Dim mtd As New MetodosEmployees
    Private Sub Employees_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        activarCamposAddress(False)
        activarCamposContacto(False)
        activarCamposPay(False)
        sprPayRate1.DecimalPlaces = 2
        sprPayRate2.DecimalPlaces = 2
        sprPayRate3.DecimalPlaces = 2
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnChooseImage.Click
        Try
            Dim file As New OpenFileDialog
            file.Filter = "Imagenes JPG|*.jpg|Images PNG|*.png"
            If file.ShowDialog = Windows.Forms.DialogResult.OK Then
                imgPhoto.Image = Image.FromFile(file.FileName)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chbAddress_CheckedChanged(sender As Object, e As EventArgs) Handles chbAddress.CheckedChanged
        If chbAddress.Checked Then
            activarCamposAddress(True)
        Else
            activarCamposAddress(False)
        End If
    End Sub

    Private Sub chbContact_CheckedChanged(sender As Object, e As EventArgs) Handles chbContact.CheckedChanged
        If chbContact.Checked Then
            activarCamposContacto(True)
        Else
            activarCamposContacto(False)
        End If
    End Sub

    Private Sub chbPay_CheckedChanged(sender As Object, e As EventArgs) Handles chbPay.CheckedChanged
        If chbPay.Checked Then
            activarCamposPay(True)
        Else
            activarCamposPay(False)
        End If
    End Sub

    Private Function activarCamposAddress(flag As Boolean) As Boolean
        If flag Then
            txtStreat.Enabled = True
            txtProvidence.Enabled = True
            txtPostalCode.Enabled = True
            txtNumber.Enabled = True
            txtCity.Enabled = True
        Else
            txtStreat.Enabled = False
            txtProvidence.Enabled = False
            txtPostalCode.Enabled = False
            txtNumber.Enabled = False
            txtCity.Enabled = False
        End If
        Return True
    End Function

    Private Function activarCamposContacto(flag As Boolean) As Boolean
        If flag Then
            txtPhone1.Enabled = True
            txtPhone2.Enabled = True
            txtEmail.Enabled = True
        Else
            txtPhone1.Enabled = False
            txtPhone2.Enabled = False
            txtEmail.Enabled = False
        End If
        Return True
    End Function

    Private Function activarCamposPay(flag As Boolean) As Boolean
        If flag = True Then
            sprPayRate1.Enabled = True
            sprPayRate2.Enabled = True
            sprPayRate3.Enabled = True
        Else
            sprPayRate1.Enabled = False
            sprPayRate2.Enabled = False
            sprPayRate3.Enabled = False
        End If
        Return True
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim dataEmployes(18) As String
            dataEmployes(0) = txtEmployeeNumber.Text
            dataEmployes(1) = txtFirsName.Text
            dataEmployes(2) = txtLastName.Text
            dataEmployes(3) = txtMiddleName.Text
            dataEmployes(4) = txtSocialNumber.Text
            dataEmployes(5) = txtSapNumber.Text
            If chbState.Checked Then
                dataEmployes(6) = "E"
            Else
                dataEmployes(6) = "D"
            End If
            If chbContact.Checked Then
                dataEmployes(7) = txtPhone1.Text
                dataEmployes(8) = txtPhone2.Text
                dataEmployes(9) = txtEmail.Text
            Else
                dataEmployes(7) = ""
                dataEmployes(8) = ""
                dataEmployes(9) = ""
            End If
            If chbAddress.Checked Then
                dataEmployes(10) = txtStreat.Text
                dataEmployes(11) = txtNumber.Text
                dataEmployes(12) = txtCity.Text
                dataEmployes(13) = txtProvidence.Text
                dataEmployes(14) = txtPostalCode.Text
            Else
                dataEmployes(10) = ""
                dataEmployes(11) = ""
                dataEmployes(12) = ""
                dataEmployes(13) = ""
                dataEmployes(14) = ""
            End If
            If chbPay.Checked Then
                dataEmployes(15) = sprPayRate1.Value
                dataEmployes(16) = sprPayRate2.Value
                dataEmployes(17) = sprPayRate3.Value
            Else
                dataEmployes(15) = "0,00"
                dataEmployes(16) = "0,00"
                dataEmployes(17) = "0,00"
            End If
            mtd.guardarEmpleado(dataEmployes, imageToByte(imgPhoto.Image))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub chbState_CheckedChanged(sender As Object, e As EventArgs) Handles chbState.CheckedChanged
        If chbState.Checked Then
            chbState.Text = "Disable"
        Else
            chbState.Text = "Enable"
        End If
    End Sub

    Private Sub tblEmployees_DoubleClick(sender As Object, e As EventArgs) Handles tblEmployees.DoubleClick
        If MessageBox.Show("Would you like to load the data of this Employee", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = 1 Then

        End If
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Try
            mtd.cargarEmpleados(tblEmployees, txtSearch.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnMenu_Click(sender As Object, e As EventArgs) Handles btnMenu.Click
        Dim a As New MainFrom()
        a.Show()
        Me.Finalize()
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub


End Class
