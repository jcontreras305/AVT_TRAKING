Imports System.Text.RegularExpressions
Imports System.Data
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Public Class Clients
    Dim mtd As New MetodosClients
    Dim dataClient = New List(Of String) 'este es para los datos de la tabla 
    Dim IdCliente, IdContacto, IdDireccion As String
    Dim MaxID As Integer


    Private Sub Clients_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblN1.Visible = False
        lblN2.Visible = False
        lblN3.Visible = False
        lblN4.Visible = False
        lblN5.Visible = False
        lblN6.Visible = False
        ActivarCamposContacto(False)
        ActivarCamposDrieccion(False)
        btnUpdate.Enabled = False
        MaxID = mtd.IdMasAlto()
        txtIdClient.Text = MaxID
        txtIdClient.Enabled = False

    End Sub
    Private Sub BtnSaveClient_Click(sender As Object, e As EventArgs) Handles btnSaveClient.Click
        If txtFirstName.TextLength > 0 Then
            Dim data = recolectar()
            mtd.InsertarClients(data, imageToByte(imgPhoto.Image))
            MaxID = mtd.IdMasAlto
            txtIdClient.Text = MaxID
            limpiarcampos()
            mtd.buscarClienteTodos(tblClientes)
        Else
            lblN5.Visible = True
            lblN6.Visible = True
        End If
    End Sub

    Private Function recolectar()
        Try
            Dim datosClientes(17) As String
            datosClientes(0) = IdCliente
            datosClientes(1) = txtIdClient.Text
            datosClientes(2) = txtFirstName.Text
            datosClientes(3) = txtMiddleName.Text
            datosClientes(4) = txtLastName.Text
            datosClientes(5) = txtCompanyName.Text
            If chbStatus.Checked Then
                datosClientes(6) = "E"
            Else
                datosClientes(6) = "D"
            End If
            If chbContact.Checked Then
                datosClientes(7) = IdContacto
                datosClientes(8) = txtPhoneNumber.Text
                datosClientes(9) = txtPhoneNumber2.Text
                If txtEmail.Text <> "" Then
                    If validar_Correo(txtEmail.Text) <> True Then
                        If MessageBox.Show("The Email isn't valid, Would you like to save?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            datosClientes(10) = txtEmail.Text
                        Else
                            datosClientes(10) = ""
                        End If
                    Else
                        datosClientes(10) = txtEmail.Text
                    End If
                Else
                    datosClientes(10) = ""
                End If
            Else
                datosClientes(7) = IdContacto
                datosClientes(8) = ""
                datosClientes(9) = ""
                datosClientes(10) = ""
            End If
            If chbAddress.Checked Then
                datosClientes(11) = IdDireccion
                datosClientes(12) = txtStreat.Text
                datosClientes(13) = txtNumerStreat.Text
                datosClientes(14) = txtCity.Text
                datosClientes(15) = txtProvince.Text
                datosClientes(16) = txtPC.Text
            Else
                datosClientes(11) = IdDireccion
                datosClientes(12) = ""
                datosClientes(13) = "0"
                datosClientes(14) = ""
                datosClientes(15) = ""
                datosClientes(16) = "0"
            End If
            Return datosClientes
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
    Private Function ActivarCamposContacto(flag As Boolean)
        If flag = False Then
            txtPhoneNumber.Enabled = False
            txtPhoneNumber2.Enabled = False
            txtEmail.Enabled = False
            Return False
        ElseIf flag = True Then
            txtPhoneNumber.Enabled = True
            txtPhoneNumber2.Enabled = True
            txtEmail.Enabled = True
            Return True
        End If
    End Function

    Private Function ActivarCamposDrieccion(flag As Boolean)
        If flag Then
            txtStreat.Enabled = True
            txtNumerStreat.Enabled = True
            txtCity.Enabled = True
            txtProvince.Enabled = True
            txtPC.Enabled = True
            Return True
        Else
            txtStreat.Enabled = False
            txtNumerStreat.Enabled = False
            txtCity.Enabled = False
            txtProvince.Enabled = False
            txtPC.Enabled = False
            Return False
        End If
    End Function

    Private Sub chbContact_CheckedChanged(sender As Object, e As EventArgs) Handles chbContact.CheckedChanged
        If chbContact.Checked Then
            ActivarCamposContacto(True)
            lblN1.Visible = True
            lblN2.Visible = True
        Else
            ActivarCamposContacto(False)
            lblN1.Visible = False
            lblN2.Visible = False
        End If
    End Sub

    Private Sub chbAddress_CheckedChanged(sender As Object, e As EventArgs) Handles chbAddress.CheckedChanged
        If chbAddress.Checked Then
            ActivarCamposDrieccion(True)
            lblN3.Visible = True
            lblN4.Visible = True
        Else
            ActivarCamposDrieccion(False)
            lblN3.Visible = False
            lblN4.Visible = False
        End If
    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click
        txtFiltro.Text = txtFiltro2.Text
    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click
        txtFiltro2.Text = txtFiltro.Text
    End Sub



    Private Sub txt_TextChanged(sender As Object, e As EventArgs) Handles txtFiltro.TextChanged
        mtd.buscarCliente(tblClientes, txtFiltro.Text)
    End Sub

    Private Sub txtFiltro2_TextChanged(sender As Object, e As EventArgs) Handles txtFiltro2.TextChanged
        mtd.buscarCliente(tblClientes, txtFiltro.Text)
    End Sub

    Private Sub btnSelectAll_Click(sender As Object, e As EventArgs) Handles btnSelectAll.Click
        mtd.buscarClienteTodos(tblClientes)
    End Sub

    Private Sub btnShowAll1_Click(sender As Object, e As EventArgs) Handles btnShowAll1.Click
        mtd.buscarClienteTodos(tblClientes)
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim result = MessageBox.Show("Are you sure that you want to save the changes done?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            btnSaveClient.Enabled = True
            btnUpdate.Enabled = True
            Dim datos = recolectar()
            Dim aux As New List(Of String)
            For Each a As String In datos
                aux.Add(a)
            Next
            mtd.actualizaCliente(aux, imageToByte(imgPhoto.Image))
            mtd.buscarClienteTodos(tblClientes)
        End If
    End Sub

    Private Sub tblClientes_DoubleClick(sender As Object, e As EventArgs) Handles tblClientes.DoubleClick
        Dim result = MessageBox.Show("Would you like to load the data of this Employee?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            limpiarcampos()
            btnSaveClient.Enabled = False
            btnUpdate.Enabled = True
            obtenerDatosTabla()
            ' datos principales
            txtIdClient.Text = dataClient(1)
            txtFirstName.Text = dataClient(2)
            txtMiddleName.Text = dataClient(3)
            txtLastName.Text = dataClient(4)
            txtCompanyName.Text = dataClient(5)
            If dataClient(6) = "E" Then
                chbStatus.Checked = True
            Else
                chbStatus.Checked = False
            End If
            'datos de contactos
            If dataClient(9) <> "" Or dataClient(8) <> "" Or dataClient(10) <> "" Then
                chbContact.Checked = True
                'ActivarCamposContacto(True)
                txtPhoneNumber.Text = dataClient(8)
                txtPhoneNumber2.Text = dataClient(9)
                txtEmail.Text = dataClient(10)

            Else
                'ActivarCamposContacto(False)
                chbContact.Checked = False
            End If
            'datos de ciudad
            If dataClient(12) <> "" Or dataClient(14) <> "" Then
                chbAddress.Checked = True
                'ActivarCamposDrieccion(True)

                txtStreat.Text = dataClient(12)
                txtNumerStreat.Text = dataClient(13)
                txtCity.Text = dataClient(14)
                txtProvince.Text = dataClient(15)
                txtPC.Text = dataClient(16)

            Else
                'ActivarCamposContacto(False)
                chbAddress.Checked = False
            End If
        End If

    End Sub


    Private Sub obtenerDatosTabla()
        If dataClient.Count > 0 Then
            dataClient.Clear()
        End If

        For Each cell As DataGridViewCell In tblClientes.CurrentRow.Cells
            If Not cell.ColumnIndex = 17 Then
                dataClient.Add(If(cell.Value Is DBNull.Value, "", cell.Value))
            Else
                imgPhoto.Image = If(cell.Value IsNot DBNull.Value, BytetoImage(cell.Value), Nothing)
            End If
        Next
        IdCliente = dataClient(0)
        IdContacto = dataClient(7)
        IdDireccion = dataClient(11)
    End Sub

    Private Sub txtEmail_Leave(sender As Object, e As EventArgs) Handles txtEmail.Leave
        If validar_Correo(txtEmail.Text) <> True Then
            MsgBox("The Email that you insert is invalid,/n
                    a correct way to write it is example12@gmail.com")
            txtEmail.Text = ""
        End If

    End Sub

    Private Sub limpiarcampos()
        chbAddress.Checked = False
        chbContact.Checked = False
        chbStatus.Checked = False
        txtFirstName.Text = ""
        txtMiddleName.Text = ""
        txtLastName.Text = ""
        txtCompanyName.Text = ""
        txtPhoneNumber.Text = ""
        txtPhoneNumber2.Text = ""
        txtEmail.Text = ""
        txtCity.Text = ""
        txtStreat.Text = ""
        txtNumerStreat.Text = ""
        txtProvince.Text = ""
        txtPC.Text = ""
    End Sub

    Private Sub lblN3_Click(sender As Object, e As EventArgs) Handles lblN3.Click

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

    Private Sub btnMaximize_Click(sender As Object, e As EventArgs) Handles btnMaximize.Click
        WindowState = FormWindowState.Maximized

    End Sub



    Private Sub btnMinimized_Click(sender As Object, e As EventArgs) Handles btnMinimized.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnChooseImage_Click(sender As Object, e As EventArgs) Handles btnChooseImage.Click
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

    Private Function validar_Correo(ByVal mail As String) As Boolean
        Return Regex.IsMatch(mail, "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]{2,4}$") '"^[_a-zA-B0-9]+(\._a-zA-B0-9+)*@[a-zA-B0-9-]+(\.[a-zA-B0-9-]+)*(\.[a-z]{2,4})$")
    End Function

    Private Sub btnSelectClient_Click(sender As Object, e As EventArgs) Handles btnSelectClient.Click
        If tblClientes.CurrentRow Is Nothing Then
            MsgBox("Please select a row.")
        Else
            obtenerDatosTabla()
            Dim pc As ProjectsClients = CType(Owner, ProjectsClients)
            pc.datosClientesPO.Clear()
            pc.datosClientesPO.Add(dataClient(0))
            pc.datosClientesPO.Add(dataClient(2) + " " + dataClient(3) + " " + dataClient(4))
            pc.datosClientesPO.Add(dataClient(5))
            pc.datosClientesPO.Add(dataClient(12))
            pc.datosClientesPO.Add(dataClient(14))
            pc.datosClientesPO.Add(dataClient(15))
            pc.datosClientesPO.Add(dataClient(16))
            pc.datosClientesPO.Add(dataClient(8))
            mtd.buscarProyectosDeCliente(pc.tblProjectClients, IdCliente)
            pc.idCliente = IdCliente
            Me.Close()
        End If
    End Sub
End Class