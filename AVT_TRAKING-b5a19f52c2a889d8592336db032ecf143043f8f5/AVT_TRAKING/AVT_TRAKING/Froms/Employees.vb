
Public Class Employees
    Dim mtd As New MetodosEmployees
    Dim emplyeeDataList As New List(Of String)
    Public idEmployee, idAddress, idContacto, idPay As String

    Private Sub Employees_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        activarCamposAddress(False)
        activarCamposContacto(False)
        activarCamposPay(False)
        sprPayRate1.DecimalPlaces = 2
        sprPayRate2.DecimalPlaces = 2
        sprPayRate3.DecimalPlaces = 2
        btnUpdate.Enabled = False
        btnSave.Enabled = True
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
            chbAddress.Checked = True
            txtStreat.Enabled = True
            txtProvidence.Enabled = True
            txtPostalCode.Enabled = True
            txtNumber.Enabled = True
            txtCity.Enabled = True
        Else
            chbAddress.Checked = False
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
            chbContact.Checked = True
            txtPhone1.Enabled = True
            txtPhone2.Enabled = True
            txtEmail.Enabled = True
        Else
            chbContact.Checked = False
            txtPhone1.Enabled = False
            txtPhone2.Enabled = False
            txtEmail.Enabled = False
        End If
        Return True
    End Function

    Private Function activarCamposPay(flag As Boolean) As Boolean
        If flag = True Then
            chbPay.Checked = True
            sprPayRate1.Enabled = True
            sprPayRate2.Enabled = True
            sprPayRate3.Enabled = True
        Else
            chbPay.Checked = False
            sprPayRate1.Enabled = False
            sprPayRate2.Enabled = False
            sprPayRate3.Enabled = False
        End If
        Return True
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim datos = recolectar()
            mtd.guardarEmpleado(datos, imageToByte(imgPhoto.Image))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            Dim result = MessageBox.Show("Are you sure that you want to change the user's data?", "Adventence", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            If result = DialogResult.OK Then
                Dim listNewData = recolectar()
                mtd.actualizar_Employee(listNewData, idEmployee, idAddress, idContacto, idPay, imageToByte(imgPhoto.Image))
                mtd.cargarEmpleados(tblEmployees, "%")
            End If
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

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Dim result = MessageBox.Show("Are you sure to cancel the chaged made?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            If result = DialogResult.OK Then
                limpiarCampos()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tblEmployees_DoubleClick(sender As Object, e As EventArgs) Handles tblEmployees.DoubleClick
        Dim result = MessageBox.Show("Would you like to load the data of this Employee", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            btnSave.Enabled = False
            btnUpdate.Enabled = True
            emplyeeDataList.Clear()
            For Each cell As DataGridViewCell In tblEmployees.CurrentRow.Cells
                emplyeeDataList.Add(cell.Value)
            Next
            Dim arrayImage As Byte() = mtd.cargar_Imagen_De_Employee(emplyeeDataList(1), emplyeeDataList(0))
            imgPhoto.Image = BytetoImage(arrayImage)
            Dim arrayDatos As List(Of String) = mtd.datosEmpleado(emplyeeDataList(1), emplyeeDataList(0))
            idEmployee = arrayDatos(0)
            txtEmployeeNumber.Text = arrayDatos(1)
            txtFirsName.Text = arrayDatos(2)
            txtLastName.Text = arrayDatos(3)
            txtMiddleName.Text = arrayDatos(4)
            txtSocialNumber.Text = arrayDatos(5)
            txtSapNumber.Text = arrayDatos(6)
            idAddress = arrayDatos(7)
            idContacto = arrayDatos(8)
            idPay = arrayDatos(9)
            If arrayDatos(10) = "E" Then
                chbState.Checked = True
            Else
                chbState.Checked = False
            End If
            If arrayDatos(12) <> "" Or arrayDatos(13) <> "" Or arrayDatos(14) <> "" Then
                activarCamposAddress(True)
                txtStreat.Text = arrayDatos(12)
                txtNumber.Text = arrayDatos(13)
                txtCity.Text = arrayDatos(14)
                txtProvidence.Text = arrayDatos(15)
                txtPostalCode.Text = arrayDatos(16)
            Else
                activarCamposAddress(False)
            End If
            If arrayDatos(18) <> "" Then
                activarCamposContacto(True)
                txtPhone1.Text = arrayDatos(18)
                txtPhone2.Text = arrayDatos(19)
                txtEmail.Text = arrayDatos(20)
            Else
                activarCamposContacto(False)
            End If
            If arrayDatos(22) <> "" Or arrayDatos(22) <> "" Or arrayDatos(22) <> "" Then
                activarCamposPay(True)
                sprPayRate1.Value = arrayDatos(22)
                sprPayRate2.Value = arrayDatos(23)
                sprPayRate3.Value = arrayDatos(24)
            Else
                activarCamposPay(False)
            End If

        End If
    End Sub

    Private Sub btnMenu_Click(sender As Object, e As EventArgs)
        Dim a As New MainFrom
        a.Show()
        Me.Finalize()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Try
            mtd.cargarEmpleados(tblEmployees, txtSearch.Text)
        Catch ex As Exception

        End Try
    End Sub



    Private Function recolectar() As String()
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
                dataEmployes(11) = "0"
                dataEmployes(12) = ""
                dataEmployes(13) = ""
                dataEmployes(14) = "0"
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

            Return dataEmployes
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function limpiarCampos() As Boolean
        txtEmployeeNumber.Text = ""
        txtFirsName.Text = ""
        txtLastName.Text = ""
        txtMiddleName.Text = ""
        txtSocialNumber.Text = ""
        txtSapNumber.Text = ""
        chbState.Checked = False
        txtCity.Text = ""
        txtStreat.Text = ""
        txtPostalCode.Text = ""
        txtProvidence.Text = ""
        txtNumber.Text = ""
        txtPhone1.Text = ""
        txtPhone2.Text = ""
        txtEmail.Text = ""
        sprPayRate1.Value = 0
        sprPayRate2.Value = 0
        sprPayRate3.Value = 0
        imgPhoto.ImageLocation = "C:\Users\ASUS\Source\Repos\AVT_TRAKING\AVT_TRAKING\AVT_TRAKING\Images\user.png"
        activarCamposAddress(False)
        activarCamposContacto(False)
        activarCamposPay(False)
        Return True
    End Function

End Class
