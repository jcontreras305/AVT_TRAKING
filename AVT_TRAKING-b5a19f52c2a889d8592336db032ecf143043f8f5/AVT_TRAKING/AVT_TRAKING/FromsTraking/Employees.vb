Imports System.Runtime.InteropServices
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Core
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
        mtd.llenarCmbType(cmbTypeEmployee)
        cmbTypeEmployee.SelectedIndex = 1
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
            chbPay.Checked = flag
            sprPayRate1.Enabled = flag
            sprPayRate2.Enabled = flag
            sprPayRate3.Enabled = flag
            btnNewPay.Enabled = flag
        Else
            chbPay.Checked = flag
            sprPayRate1.Enabled = flag
            sprPayRate2.Enabled = flag
            sprPayRate3.Enabled = flag
            btnNewPay.Enabled = flag
        End If
        Return True
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim datos = recolectar()
            If mtd.guardarEmpleado(datos, imageToByte(imgPhoto.Image)) Then
                MsgBox("Successful.")
            Else
                MsgBox("Error.")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            Dim result = MessageBox.Show("Are you sure that you want to change the user's data?", "Adventence", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            If result = DialogResult.OK Then
                Dim listNewData = recolectar()
                mtd.actualizar_Employee(listNewData, idEmployee, idAddress, idContacto, imageToByte(imgPhoto.Image))
                mtd.cargarEmpleados(tblEmployees, "%")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Private Sub chbState_CheckedChanged(sender As Object, e As EventArgs) Handles chbState.CheckedChanged
    '    If chbState.Checked Then
    '        chbState.Text = "Disable"
    '    Else
    '        chbState.Text = "Enable"
    '    End If
    'End Sub

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

            If arrayDatos(9) = "E" Then
                chbState.Checked = True
            Else
                chbState.Checked = False
            End If
            cmbTypeEmployee.SelectedIndex = cmbTypeEmployee.FindString(arrayDatos(10))
            chbPerdiem.Checked = If(arrayDatos(11) = "True", True, False)
            If arrayDatos(13) <> "" Or arrayDatos(14) <> "0" Or arrayDatos(15) <> "" Then
                activarCamposAddress(True)
                txtStreat.Text = arrayDatos(13)
                txtNumber.Text = arrayDatos(14)
                txtCity.Text = arrayDatos(15)
                txtProvidence.Text = arrayDatos(16)
                txtPostalCode.Text = arrayDatos(17)
            Else
                activarCamposAddress(False)
            End If
            If arrayDatos(19) <> "" Then
                activarCamposContacto(True)
                txtPhone1.Text = arrayDatos(19)
                txtPhone2.Text = arrayDatos(20)
                txtEmail.Text = arrayDatos(21)
            Else
                activarCamposContacto(False)
            End If

            idPay = arrayDatos(22)
            If arrayDatos(23) <> "" Or arrayDatos(24) <> "" Or arrayDatos(25) <> "" Then
                activarCamposPay(True)
                sprPayRate1.Value = arrayDatos(23)
                sprPayRate2.Value = arrayDatos(24)
                sprPayRate3.Value = arrayDatos(25)
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

    Private Sub btnClose_Click(sender As Object, e As EventArgs)
        Application.Exit()
    End Sub

    Private Sub btnMinimized_Click(sender As Object, e As EventArgs) Handles btnMinimized.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnMaximize_Click(sender As Object, e As EventArgs) Handles btnMaximize.Click
        Me.WindowState = FormWindowState.Maximized

    End Sub



    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Try
            mtd.cargarEmpleados(tblEmployees, txtSearch.Text)
        Catch ex As Exception

        End Try
    End Sub
    Private Function recolectar() As String()
        Try
            Dim dataEmployes(19) As String
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

            dataEmployes(18) = cmbTypeEmployee.Text
            dataEmployes(19) = If(chbPerdiem.Checked, "1", "0")
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
        chbPerdiem.Checked = False
        imgPhoto.ImageLocation = "C:\Users\ASUS\Source\Repos\AVT_TRAKING\AVT_TRAKING\AVT_TRAKING\Images\user.png"
        'cmbTypeEmployee.SelectedItem = cmbTypeEmployee.FindString(cmbTypeEmployee.Items(0))
        activarCamposAddress(False)
        activarCamposContacto(False)
        activarCamposPay(False)
        Return True
    End Function

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Panel20_Paint(sender As Object, e As PaintEventArgs) Handles Panel20.Paint

    End Sub

    Private Sub btnNewPay_Click(sender As Object, e As EventArgs) Handles btnNewPay.Click
        If btnNewPay.Text = "New Pay" Then
            btnNewPay.Text = "Save Pay"
            sprPayRate1.Value = 0.0
            sprPayRate2.Value = 0.0
            sprPayRate3.Value = 0.0
        Else
            If (mtd.insertNewPayRateEmployee(idEmployee, sprPayRate1.Value, sprPayRate2.Value, sprPayRate3.Value)) Then
                MsgBox("The new pay Rate was update.")
                btnNewPay.Text = "New Pay"
                mtd.cargarEmpleados(tblEmployees, "%")
            End If
        End If
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

    Private Sub tblEmployeesExcel_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles tblEmployeesExcel.CellClick
        If e.ColumnIndex = tblEmployeesExcel.Columns("Photo").Index Then
            If DialogResult.Yes = MessageBox.Show("Would you like to select a picture from your documents?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                Dim opf As New OpenFileDialog
                opf.DefaultExt = "*.jpg|*.png"
                opf.Filter = "Archivos de Excel (*.png)|*.png|(*.jpg)|*.jpg"
                opf.ShowDialog()
                tblEmployeesExcel.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = opf.FileName
            End If
        ElseIf e.ColumnIndex = tblEmployeesExcel.Columns("TypeEmployee").Index Then
            Try
                If tblEmployeesExcel.CurrentCell.GetType.Name = "DataGridViewTextBoxCell" Then
                    Dim cmbTypeEmployee As New DataGridViewComboBoxCell
                    With cmbTypeEmployee
                        mtd.llenarCmbTypeEmployee(cmbTypeEmployee)
                    End With
                    tblEmployeesExcel.CurrentRow.Cells("TypeEmployee") = cmbTypeEmployee
                Else
                    tblEmployeesExcel.CurrentRow.Cells("TypeEmployee") = tblEmployeesExcel.CurrentCell
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub
    Private Sub tblEmployeesExcel_DataError(ByVal sender As Object, ByVal e As DataGridViewDataErrorEventArgs) Handles tblEmployeesExcel.DataError
        ' Excepción
        Dim ex As Exception = e.Exception
        If e.Exception.Message <> "El valor de DataGridViewComboBoxCell no es válido." Then
            MessageBox.Show(ex.Message)
        Else
            e.Cancel = True
        End If
    End Sub
    Private Sub btnDownloadExcel_Click(sender As Object, e As EventArgs) Handles btnDownloadExcel.Click
        Try
            Dim ApExcel = New Microsoft.Office.Interop.Excel.Application
            Dim libro = ApExcel.Workbooks.Add
            Dim colums() As String = {"Number", "FirstName", "LastName", "MiddleName", "SocialNumber", "SAPNumber", "Photo", "Estatus", "TypeEmployee"}
            For i As Int16 = 0 To colums.Length - 1
                libro.Sheets(1).cells(1, i + 1) = colums(i)
            Next
            With libro.Sheets(1).Range("A1:I1")
                .Font.Bold = True
                .Font.ColorIndex = 1
                With .Interior
                    .ColorIndex = 15
                End With
                .BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Color.Black)
            End With
            Dim sd As New SaveFileDialog
            sd.DefaultExt = "*.xlsx"
            sd.FileName = "EmployeeList"
            sd.Filter = "Archivos de Excel (*.xlsx)|*.xlsx"
            sd.ShowDialog()
            libro.SaveAs(sd.FileName)
            NAR(libro.Sheets(1))
            libro.Close(False)
            NAR(libro)
            ApExcel.Quit()
            NAR(ApExcel)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btnUploadExcel_Click(sender As Object, e As EventArgs) Handles btnUploadExcel.Click
        Try
            txtMensajeProseso.Text = ""
            Dim openFile As New OpenFileDialog
            openFile.DefaultExt = "*.xlsx"
            openFile.Filter = "Archivos de Excel (*.xlsx)|*.xlsx"
            openFile.ShowDialog()
            Dim ApExcel = New Microsoft.Office.Interop.Excel.Application

            Dim libro = ApExcel.Workbooks.Open(openFile.FileName)
            txtMensajeProseso.Text = txtMensajeProseso.Text + vbCrLf + "Starting process to open the File " + openFile.FileName
            Dim Hoja1 As New Microsoft.Office.Interop.Excel.Worksheet
            Try
                Hoja1 = libro.Worksheets("Hoja1")
            Catch ex As Exception
                Hoja1 = libro.Worksheets("Sheet1")
            End Try
            txtMensajeProseso.Text = txtMensajeProseso.Text + vbCrLf + "The file has " + CStr(countFilas(Hoja1)) + " records"
            Dim dato(8) As String
            Dim cont As Int64 = 0
            tblEmployeesExcel.Rows.Clear()
            For i As Int64 = 2 To countFilas(Hoja1) + 1
                dato(0) = Hoja1.Cells(i, 1).Text
                dato(1) = Hoja1.Cells(i, 2).Text
                dato(2) = Hoja1.Cells(i, 3).Text
                dato(3) = Hoja1.Cells(i, 4).Text
                dato(4) = Hoja1.Cells(i, 5).Text
                dato(5) = Hoja1.Cells(i, 6).Text
                dato(6) = Hoja1.Cells(i, 7).Text
                dato(7) = Hoja1.Cells(i, 8).Text
                dato(8) = Hoja1.Cells(i, 9).Text
                If ExistIdEmployee(dato(0)) = False Then
                    Dim newID = System.Guid.NewGuid.ToString()
                    tblEmployeesExcel.Rows.Add(newID, dato(0), dato(1), dato(2), dato(3), dato(4), dato(5), dato(6), If(dato(7) = "TRUE" Or dato(7) = "YES", True, False), dato(8))
                Else
                    txtMensajeProseso.Text = txtMensajeProseso.Text + vbCrLf + " The ID " + dato(0) + " is Inserted."
                End If
            Next
            txtMensajeProseso.Text = txtMensajeProseso.Text + vbCrLf + "Finish"
            NAR(libro.Sheets(1))
            libro.Close(False)
            NAR(libro)
            ApExcel.Quit()
            NAR(ApExcel)
            txtMensajeProseso.Text = txtMensajeProseso.Text + vbCrLf + "The File is Closed"
        Catch ex As Exception
            MsgBox(ex.Message())
            txtMensajeProseso.Text = txtMensajeProseso.Text + vbCrLf + "Error"
        End Try
    End Sub

    Private Sub btnDeleteEmployee_Click(sender As Object, e As EventArgs) Handles btnDeleteEmployee.Click
        Try
            If tblEmployees.SelectedRows.Count > 0 Then
                mtd.eliminarEmpleyee(tblEmployees)
            Else
                MessageBox.Show("Please select a row.")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Function ExistIdEmployee(ByVal idEmployee As String) As Boolean
        Dim tblIdEmployees As Data.DataTable = mtd.selectEmployeeIDd
        Dim flag As Boolean = False
        If tblEmployees IsNot Nothing And tblEmployees.Rows.Count > 0 Then
            For Each Row As Data.DataRow In tblIdEmployees.Rows()
                If Row.ItemArray(0) = idEmployee Then
                    flag = True
                    Exit For
                End If
            Next
        End If
        Return flag
    End Function
    Private Sub btnSaveEmployeeExcel_Click(sender As Object, e As EventArgs) Handles btnSaveEmployeeExcel.Click
        Try
            txtMensajeProseso.Text = "Starting process to insert Employees." + vbCrLf + "Inserting Employee Number"
            Dim msg As String = txtMensajeProseso.Text
            For Each row As DataGridViewRow In tblEmployeesExcel.Rows()
                If Not row.IsNewRow Then
                    Dim datos() = recolectarInsertExcel(row.Index)
                    Dim img As Image
                    If row.Cells("Photo").Value <> "" Then
                        txtMensajeProseso.Text = msg + row.Cells("Number").Value
                        img = Image.FromFile(row.Cells("Photo").Value)
                    Else
                        txtMensajeProseso.Text = msg + row.Cells("Number").Value
                        img = DirectCast(My.Resources.user, Image)
                    End If
                    If mtd.guardarEmpleado(datos, imageToByte(img)) = False Then
                        row.DefaultCellStyle.BackColor = Color.Red
                    End If
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Private Function recolectarInsertExcel(ByVal rowIndex As Integer) As String()
        Try
            Dim dataEmployes(19) As String
            dataEmployes(0) = tblEmployeesExcel.Rows(rowIndex).Cells("Number").Value
            dataEmployes(1) = tblEmployeesExcel.Rows(rowIndex).Cells("FirstName").Value
            dataEmployes(2) = tblEmployeesExcel.Rows(rowIndex).Cells("LastName").Value
            dataEmployes(3) = tblEmployeesExcel.Rows(rowIndex).Cells("MiddleName").Value
            dataEmployes(4) = tblEmployeesExcel.Rows(rowIndex).Cells("SocialNumber").Value
            dataEmployes(5) = tblEmployeesExcel.Rows(rowIndex).Cells("SapNumber").Value
            If tblEmployeesExcel.Rows(rowIndex).Cells("Status").Value = True Then
                dataEmployes(6) = "E"
            Else
                dataEmployes(6) = "D"
            End If

            dataEmployes(7) = ""
            dataEmployes(8) = ""
            dataEmployes(9) = ""

            dataEmployes(10) = ""
            dataEmployes(11) = "0"
            dataEmployes(12) = ""
            dataEmployes(13) = ""
            dataEmployes(14) = "0"

            dataEmployes(15) = "0,00"
            dataEmployes(16) = "0,00"
            dataEmployes(17) = "0,00"

            dataEmployes(18) = tblEmployeesExcel.Rows(rowIndex).Cells("TypeEmployee").Value

            dataEmployes(19) = "0"

            Return dataEmployes
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
