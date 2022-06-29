Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Office.Core
Imports Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices

Public Class Materials

    Public idVedor, idMaterial, idDM, idOrder As String
    Dim dataVendor, listIdVendors As New List(Of String)
    Dim dataMaterial(6) As String
    Dim flagUpdateOrder As Boolean = False
    Public siSeleccionoMaterial As Boolean = False


    Dim mtdMaterial As MetodosMaterials = New MetodosMaterials()
    Dim mtdOther As New MetodosOthers
    Private Sub Materials_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtNumeroMaterial.Enabled = False
        txtNumeroMaterial.Text = mtdMaterial.valueMaxMaterial
        txtNumeroVendedor.Enabled = False
        mtdOther.llenarComboMaterialClass(cmbClassMaterial)
        txtNumeroVendedor.Text = mtdMaterial.valueMaxVendor
        btnUpdateVendor.Enabled = False
        btnUpdateMaterial.Enabled = False
        btnUpdateMareialData.Enabled = False
        btnCancelMaterial.Enabled = False
        btnCancelVendor.Enabled = False
        btnCancelOrder.Enabled = False
        ActivarCamposMaterialData(False)
        llenarTablas()
        dtpFechaOrden.CustomFormat = "MM/dd/yyyy"
        dtpFechaOrden.Format = DateTimePickerFormat.Custom
    End Sub

    Private Sub btnSaveVendor_Click(sender As Object, e As EventArgs) Handles btnSaveVendor.Click
        Try
            Dim dataVendor(3) As String
            dataVendor(0) = txtNumeroVendedor.Text
            dataVendor(1) = txtNombreVendedor.Text
            dataVendor(2) = txtDescripcionVendedor.Text
            dataVendor(3) = If(chbEnableVendor.Checked, "E", "D")
            mtdMaterial.insertarVendor(dataVendor)
            mtdMaterial.selectVedor(tblVendor, "")
            llenarTablas()
            limparCaposVendor()
        Catch ex As Exception
            MsgBox("Something went wrong, check the data and try again")
        End Try
    End Sub

    Private Sub btnUpdateVendor_Click(sender As Object, e As EventArgs) Handles btnUpdateVendor.Click
        Try
            Dim dataVendor(3) As String
            dataVendor(0) = idVedor
            dataVendor(1) = txtNombreVendedor.Text
            dataVendor(2) = txtDescripcionVendedor.Text
            dataVendor(3) = If(chbEnableVendor.Checked, "E", "D")
            mtdMaterial.actializarVendor(dataVendor)
            mtdMaterial.selectVedor(tblVendor, "")
            limparCaposVendor()
            llenarTablas()
            btnUpdateVendor.Enabled = False
            btnCancelVendor.Enabled = False
            btnSaveVendor.Enabled = True
        Catch ex As Exception
            MsgBox("Something went wrong, check the data and try again")
        End Try
    End Sub

    Private Sub limparCaposVendor()
        txtNumeroVendedor.Text = mtdMaterial.valueMaxVendor
        txtNombreVendedor.Text = ""
        txtDescripcionVendedor.Text = ""
        cmbVendedor.SelectedItem = Nothing
        cmbVendedor.Text = ""
        chbEnableVendor.Checked = False
    End Sub

    Private Sub txtSearchVendedor_TextChanged(sender As Object, e As EventArgs) Handles txtSearchVendedor.TextChanged
        mtdMaterial.selectVedor(tblVendor, txtSearchVendedor.Text)
    End Sub

    Private Sub btnSaveMaterial_Click(sender As Object, e As EventArgs) Handles btnSaveMaterial.Click
        Try
            Dim dataMaterial(4) As String
            dataMaterial(0) = txtNameMaterials.Text
            dataMaterial(1) = txtNumeroMaterial.Text
            dataMaterial(2) = listIdVendors(cmbVendedor.FindString(cmbVendedor.Text))
            dataMaterial(3) = If(chbEnableMaterial.Checked, "E", "D")
            If cmbClassMaterial.SelectedItem IsNot Nothing Then
                Dim array() As String = cmbClassMaterial.SelectedItem.ToString.Split(" ")
                dataMaterial(4) = array(0)
            Else
                dataMaterial(4) = ""
            End If
            If mtdMaterial.insertarMaterial(dataMaterial) Then
                MsgBox("Successful")
            End If

        Catch ex As Exception
            MsgBox("Something went wrong, check the data and try again.")
        End Try
        limpiarCamposMaterail()
        mtdMaterial.selectMaterial(tblMaterial, If(txtFiltro.Text = "", "%", txtFiltro.Text))
        btnSaveMaterial.Enabled = True
        btnCancelMaterial.Enabled = False
        btnUpdateMaterial.Enabled = False
    End Sub

    Private Sub btnUpdateMaterial_Click(sender As Object, e As EventArgs) Handles btnUpdateMaterial.Click
        Try
            Dim dataMaterialnuevos(5) As String
            dataMaterialnuevos(0) = txtNameMaterials.Text
            dataMaterialnuevos(1) = txtNumeroMaterial.Text
            dataMaterialnuevos(2) = listIdVendors(cmbVendedor.FindString(cmbVendedor.Text))
            dataMaterialnuevos(3) = If(chbEnableMaterial.Checked, "E", "A")
            dataMaterialnuevos(4) = idMaterial
            If cmbClassMaterial.SelectedItem IsNot Nothing Then
                Dim array() As String = cmbClassMaterial.SelectedItem.ToString.Split(" ")
                dataMaterialnuevos(5) = array(0)
            Else
                dataMaterialnuevos(5) = ""
            End If
            mtdMaterial.actualizarMaterial(dataMaterialnuevos, dataMaterial(1))
            mtdMaterial.selectMaterial(tblMaterial, txtFiltro.Text)
            limpiarCamposMaterail()
            btnUpdateMaterial.Enabled = False
            btnSaveMaterial.Enabled = True
            btnCancelMaterial.Enabled = False
        Catch ex As Exception
            MsgBox("Something went wrong, check the data and try again")
        End Try
    End Sub

    Private Sub BtnMenu_Click(sender As Object, e As EventArgs)
        Dim a As New MainFrom
        a.Show()
        Me.Finalize()
    End Sub

    Private Sub tblMaterial_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles tblMaterial.CellMouseDoubleClick
        Dim cont As Int32 = 0
        For Each cell As DataGridViewCell In tblMaterial.CurrentRow.Cells
            dataMaterial(cont) = cell.Value.ToString
            cont += 1
        Next
        idMaterial = dataMaterial(0)
        txtNameMaterials.Text = dataMaterial(2)
        txtNumeroMaterial.Text = dataMaterial(3)
        chbEnableMaterial.Checked = If(dataMaterial(4).Equals("Enable"), True, False)
        cmbVendedor.SelectedItem = cmbVendedor.Items(cmbVendedor.FindString(dataMaterial(5)))
        cmbVendedor.Text = dataMaterial(5)
        cmbClassMaterial.SelectedItem = cmbClassMaterial.Items(cmbClassMaterial.FindString(dataMaterial(6)))
        cmbClassMaterial.Text = dataMaterial(6)
        btnSaveMaterial.Enabled = False
        btnCancelMaterial.Enabled = True
        btnUpdateMaterial.Enabled = True
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
    End Sub

    Private Sub txtFiltro_KeyUp(sender As Object, e As KeyEventArgs) Handles txtFiltro.KeyUp
        mtdMaterial.selectMaterial(tblMaterial, txtFiltro.Text)
    End Sub

    Private Sub txtDMaterial_MouseClick(sender As Object, e As MouseEventArgs) Handles txtDMaterial.MouseClick
        Dim SM As New SelectMaterial
        Dim listIdsVendor As New List(Of String)
        mtdMaterial.llenarVendorCombo(SM.cmbNombreVendorSM, listIdsVendor)
        mtdMaterial.selectMaterial(SM.tblMaterialSM, "%", "All", False)
        SM.cmbNombreVendorSM.Text = "All"
        AddOwnedForm(SM)
        SM.ShowDialog()
        If siSeleccionoMaterial Then
            btnUpdateMareialData.Enabled = True
            ActivarCamposMaterialData(True)
        End If

    End Sub


    Private Sub ActivarCamposMaterialData(flag As Boolean)
        If flag Then
            txtRM.Enabled = True
            cmbUnidadDeMedida.Enabled = True
            sprTamanio.Enabled = True
            txtTipo.Enabled = True
            sprPrice.Enabled = True
            txtDescripcion.Enabled = True
        Else
            txtRM.Enabled = False
            cmbUnidadDeMedida.Enabled = False
            sprTamanio.Enabled = False
            txtTipo.Enabled = False
            sprPrice.Enabled = False
            txtDescripcion.Enabled = False
        End If
    End Sub


    Private Sub btnUpdateMareialData_Click(sender As Object, e As EventArgs) Handles btnUpdateMareialData.Click
        Try
            Dim listDatosNuevos As New List(Of String)
            listDatosNuevos.Add(idMaterial)
            listDatosNuevos.Add(txtRM.Text)
            listDatosNuevos.Add(cmbUnidadDeMedida.Text)
            listDatosNuevos.Add(sprTamanio.Value)
            listDatosNuevos.Add(txtTipo.Text)
            listDatosNuevos.Add(sprPrice.Value)
            listDatosNuevos.Add(txtDescripcion.Text)
            listDatosNuevos.Add(txtPartNum.Text)
            mtdMaterial.actualizarDatosMaterial(listDatosNuevos)
        Catch ex As Exception
            MsgBox("Something went wrong, check the data and try again")
        End Try

    End Sub

    Private Sub chbOrden_CheckedChanged(sender As Object, e As EventArgs) Handles chbOrden.CheckedChanged
        If chbOrden.Checked Then
            activarCamposOrden(True)
            flagUpdateOrder = False
        Else
            activarCamposOrden(False)
            limpiarCamposOrden()
        End If
    End Sub

    Private Sub activarCamposOrden(flag As Boolean)
        If flag Then
            sprCantidadOrden.Enabled = True
            sprPricioOrden.Enabled = True
            dtpFechaOrden.Enabled = True
            btnOrderSave.Enabled = True
        Else
            sprCantidadOrden.Enabled = False
            sprPricioOrden.Enabled = False
            dtpFechaOrden.Enabled = False
            btnOrderSave.Enabled = False
            lblTotal.Text = "0.00"
        End If
    End Sub

    Private Sub sprPricioOrden_ValueChanged(sender As Object, e As EventArgs) Handles sprPricioOrden.ValueChanged
        Dim total As Double = sprPricioOrden.Value * sprCantidadOrden.Value
        lblTotal.Text = CStr(total.ToString("N"))
    End Sub

    Private Sub sprCantidadOrden_ValueChanged(sender As Object, e As EventArgs) Handles sprCantidadOrden.ValueChanged
        Dim total As Double = sprPricioOrden.Value * sprCantidadOrden.Value
        lblTotal.Text = CStr(total.ToString("N"))
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        mtdMaterial.selectOrdersMaterials(tblMaterialAndOrders, txtSearch.Text)
    End Sub

    Private Sub btnDeleteOrder_Click(sender As Object, e As EventArgs) Handles btnDeleteOrder.Click
        Try
            If tblMaterialAndOrders.SelectedRows.Count = 1 Then
                If MessageBox.Show("Are you sure to delete this order", "Advertence", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = DialogResult.OK Then
                    mtdMaterial.EliminarOrden(tblMaterialAndOrders.CurrentRow.Cells(2).Value, tblMaterialAndOrders.CurrentRow.Cells(7).Value, tblMaterialAndOrders.CurrentRow.Cells(1).Value)
                End If
            End If
        Catch ex As Exception
            MsgBox("Something went wrong, check the data and try again")
        End Try
        mtdMaterial.selectOrdersMaterials(tblMaterialAndOrders, "%")
    End Sub

    Private Sub tblMaterialAndOrders_DoubleClick(sender As Object, e As EventArgs) Handles tblMaterialAndOrders.DoubleClick
        btnUpdateOrder.Enabled = True
        btnDeleteOrder.Enabled = True

    End Sub

    Private Sub btnCancelVendor_Click(sender As Object, e As EventArgs) Handles btnCancelVendor.Click
        limparCaposVendor()
        btnCancelVendor.Enabled = False
        btnUpdateVendor.Enabled = False
        btnSaveVendor.Enabled = True
    End Sub

    Private Sub tblMaterial_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles tblMaterial.MouseDoubleClick

    End Sub

    Private Sub btnCancelMaterial_Click(sender As Object, e As EventArgs) Handles btnCancelMaterial.Click
        limpiarCamposMaterail()
        btnCancelMaterial.Enabled = False
        btnSaveMaterial.Enabled = True
        btnUpdateMaterial.Enabled = False
    End Sub

    Private Sub limpiarCamposMaterail()
        txtNumeroMaterial.Text = mtdMaterial.valueMaxMaterial()
        txtNameMaterials.Text = ""
        cmbClassMaterial.SelectedItem = Nothing
        cmbClassMaterial.Text = ""
        cmbVendedor.SelectedItem = Nothing
        cmbVendedor.Text = ""
    End Sub

    Private Sub btnCancelOrder_Click(sender As Object, e As EventArgs) Handles btnCancelOrder.Click
        limpiarCamposOrden()
        activarCamposOrden(False)
        btnOrderSave.Text = "Add"
    End Sub

    Private Sub limpiarCamposOrden()
        sprCantidadOrden.Value = 0
        sprPricioOrden.Value = 0
        lblTotal.Text = "0.00"
    End Sub


    Private Sub btnUpdateOrder_Click(sender As Object, e As EventArgs) Handles btnUpdateOrder.Click
        If tblMaterialAndOrders.SelectedRows.Count = 1 Then
            btnCancelOrder.Enabled = True
            chbOrden.Checked = True
            sprCantidadOrden.Value = tblMaterialAndOrders.CurrentRow.Cells.Item(7).Value
            sprPricioOrden.Value = tblMaterialAndOrders.CurrentRow.Cells.Item(5).Value
            dtpFechaOrden.Value = tblMaterialAndOrders.CurrentRow.Cells.Item(6).Value
            idMaterial = tblMaterialAndOrders.CurrentRow.Cells.Item(0).Value
            idOrder = tblMaterialAndOrders.CurrentRow.Cells.Item(2).Value
            flagUpdateOrder = True
            btnOrderSave.Text = "Save"
            btnUpdateOrder.Enabled = False
        End If
    End Sub



    Private Sub btnOrderSave_Click(sender As Object, e As EventArgs) Handles btnOrderSave.Click
        Try
            If flagUpdateOrder Then
                Dim date1 As Date = dtpFechaOrden.Value
                Dim fechaFormato As String = date1.Year.ToString() + "-" + date1.Month.ToString() + "-" + date1.Day.ToString
                mtdMaterial.UpdateOrden(idOrder, sprCantidadOrden.Value, sprPricioOrden.Value, fechaFormato, idMaterial)
                mtdMaterial.selectOrdersMaterials(tblMaterialAndOrders, "%")
                btnOrderSave.Text = "Add"
                btnUpdateOrder.Enabled = True
                limpiarCamposOrden()
                activarCamposOrden(False)
            Else
                If sprCantidadOrden.Value > 0.0 Or sprPricioOrden.Value > 0.0 Then
                    Dim dataOrderLits As New List(Of String)
                    dataOrderLits.Add(idMaterial)
                    dataOrderLits.Add(sprCantidadOrden.Value.ToString)
                    dataOrderLits.Add(sprPricioOrden.Value.ToString)
                    Dim date1 As Date = dtpFechaOrden.Value
                    Dim fechaFomato As String = date1.Year.ToString() + "-" + date1.Month.ToString() + "-" + date1.Day.ToString
                    dataOrderLits.Add(fechaFomato)
                    dataOrderLits.Add(idDM)
                    mtdMaterial.nuevaOrden(dataOrderLits)
                Else
                    MsgBox("Error. The sistem not permite a 0,0.")
                End If
            End If
        Catch ex As Exception
            MsgBox("Something went wrong, check the data and try again")
        End Try
    End Sub

    Private Sub tbkVendor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles tblVendor.MouseDoubleClick
        If dataVendor.Count > 0 Then
            dataVendor.Clear()
        End If
        For Each cell As DataGridViewCell In tblVendor.CurrentRow.Cells
            dataVendor.Add(cell.Value.ToString)
        Next
        idVedor = dataVendor(0)
        txtNumeroVendedor.Text = dataVendor(1)
        txtNombreVendedor.Text = dataVendor(2)
        txtDescripcionVendedor.Text = dataVendor(3)
        chbEnableVendor.Checked = If(dataVendor(4).Equals("Enable"), True, False)
        btnSaveVendor.Enabled = False
        btnUpdateVendor.Enabled = True
        btnCancelVendor.Enabled = True
    End Sub


    'Private Sub TabControl1_Selected(sender As Object, e As TabControlEventArgs) Handles TabControl1.Selected
    '    mtdMaterial.llenarVendorCombo(cmbVendedor, listIdVendors)
    '    mtdMaterial.selectMaterial(tblMaterial, "")
    'End Sub


    Private Sub llenarTablas()
        mtdMaterial.selectVedor(tblVendor, "%")
        mtdMaterial.selectMaterial(tblMaterial, "%")
        mtdMaterial.llenarVendorCombo(cmbVendedor, listIdVendors)
        mtdMaterial.selectOrdersMaterials(tblMaterialAndOrders, "%")
    End Sub



    Private Sub btnVendorDownloadExcel_Click(sender As Object, e As EventArgs) Handles btnVendorDownloadExcel.Click
        Try
            Dim ApExcel = New Microsoft.Office.Interop.Excel.Application
            Dim libro = ApExcel.Workbooks.Add
            Dim colums() As String = {"id", "name", "description"}
            For i As Int16 = 0 To colums.Length - 1
                libro.Sheets(1).cells(1, i + 1) = colums(i)
            Next
            Dim sd As New SaveFileDialog
            sd.DefaultExt = "*.xlsx"
            sd.FileName = "VendorList"
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

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub NAR(ByVal o As Object)
        Try
            While (System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0)
            End While
        Catch
        Finally
            o = Nothing
        End Try
    End Sub

    Private Sub btnVendorUploadExcel_Click(sender As Object, e As EventArgs) Handles btnVendorUploadExcel.Click
        Try
            Dim openFile As New OpenFileDialog
            openFile.DefaultExt = "*.xlsx"
            openFile.Filter = "Archivos de Excel (*.xlsx)|*.xlsx"
            openFile.ShowDialog()
            Dim ApExcel = New Microsoft.Office.Interop.Excel.Application

            Dim libro = ApExcel.Workbooks.Open(openFile.FileName)
            txtMensajeProseso.Text = txtMensajeProseso.Text + vbCrLf + "Starting process to open the File " + openFile.FileName
            Dim Hoja1 As New Worksheet
            Try
                Hoja1 = libro.Worksheets("Hoja1")
            Catch ex As Exception
                Hoja1 = libro.Worksheets("Sheet1")
            End Try
            txtMensajeProseso.Text = txtMensajeProseso.Text + vbCrLf + "The file has " + CStr(countFilas(Hoja1)) + " records"
            Dim dato(4) As String
            Dim validar As Boolean = True
            Dim maxnum As Int64 = mtdMaterial.valueMaxVendor()
            Dim cont As Int64 = 0
            For i As Int64 = 2 To countFilas(Hoja1) + 1
                dato(0) = Hoja1.Cells(i, 1).Text
                dato(1) = Hoja1.Cells(i, 2).Text
                dato(2) = Hoja1.Cells(i, 3).Text
                dato(3) = "E"
                If CInt(dato(0)) >= maxnum Then
                    mtdMaterial.insertarVendor(dato, False, validar)
                    If validar = False Then
                        txtMensajeProseso.Text = txtMensajeProseso.Text + vbCrLf + "Error in the line " + i + ""
                    Else
                        cont = cont + 1
                    End If
                Else
                    txtMensajeProseso.Text = txtMensajeProseso.Text + vbCrLf + "Error at line " + CStr(i) + " the ID isn't mayor than the existing IDs "
                End If
            Next
            txtMensajeProseso.Text = txtMensajeProseso.Text + vbCrLf + CStr(cont) + " vendors were inserted"
            txtMensajeProseso.Text = txtMensajeProseso.Text + vbCrLf + "Finish"
            NAR(libro.Sheets(1))
            libro.Close(False)
            NAR(libro)
            ApExcel.Quit()
            NAR(ApExcel)
            txtMensajeProseso.Text = txtMensajeProseso.Text + vbCrLf + "The File is Closed"
            txtNumeroVendedor.Text = mtdMaterial.valueMaxVendor
            mtdMaterial.selectVedor(tblVendor, "%")
        Catch ex As Exception
            MsgBox(ex.Message())
            txtMensajeProseso.Text = txtMensajeProseso.Text + vbCrLf + "Error"
        End Try
    End Sub

    Private Sub btnMaterialDownloadExcel_Click(sender As Object, e As EventArgs) Handles btnMaterialSourceDownloadExcel.Click
        Try
            Dim ApExcel = New Microsoft.Office.Interop.Excel.Application
            Dim libro = ApExcel.Workbooks.Add
            Dim colums() As String = {"id", "name", "resorseMaterial", "unitMeasurement", "description", "type", "price", "size", "idVendor", "Part #"}
            For i As Int64 = 0 To colums.Length - 1
                libro.Sheets(1).cells(1, i + 1) = colums(i)
            Next
            Dim sd As New SaveFileDialog
            sd.DefaultExt = "*.xlsx"
            sd.FileName = "MaterialList"
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

    Private Sub tblMaterial_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles tblMaterial.CellContentClick

    End Sub

    Private Sub btnMaterialUploadExcel_Click(sender As Object, e As EventArgs) Handles btnMaterialSourceUploadExcel.Click
        Try
            Dim openFile As New OpenFileDialog
            openFile.DefaultExt = "*.xlsx"
            openFile.Filter = "Archivos de Excel (*.xlsx)|*.xlsx"
            openFile.ShowDialog()
            Dim ApExcel = New Microsoft.Office.Interop.Excel.Application
            Dim libro = ApExcel.Workbooks.Open(openFile.FileName)
            txtMensajeProseso.Text = txtMensajeProseso.Text + vbCrLf + "Starting process to open the File " + openFile.FileName
            Dim Hoja As New Worksheet
            Try
                Hoja = libro.Worksheets("Hoja1")
            Catch ex As Exception
                Hoja = libro.Worksheets("Sheet1")
            End Try
            txtMensajeProseso.Text = txtMensajeProseso.Text + vbCrLf + "The file has " + (countFilas(Hoja) - 1).ToString + " records"
            Dim dato(3) As String
            Dim listNewDatos As New List(Of String)
            Dim validar As Boolean = True
            Dim maxnum As Int64 = mtdMaterial.valueMaxMaterial()
            Dim cont As Integer = 0
            For i As Int64 = 2 To countFilas(Hoja) + 1
                listNewDatos.Clear()
                dato(0) = Hoja.Cells(i, 1).Text
                dato(1) = Hoja.Cells(i, 2).Text
                dato(2) = "E"
                listNewDatos.Add(Hoja.Cells(i, 3).Text)
                listNewDatos.Add(Hoja.Cells(i, 4).Text)
                listNewDatos.Add(Hoja.Cells(i, 5).Text)
                listNewDatos.Add(Hoja.Cells(i, 6).Text)
                listNewDatos.Add(Hoja.Cells(i, 7).Text)
                listNewDatos.Add(Hoja.Cells(i, 8).Text)
                listNewDatos.Add(Hoja.Cells(i, 9).Text)
                listNewDatos.Add(Hoja.Cells(i, 10).Text)
                If CInt(dato(0)) > maxnum Then
                    mtdMaterial.insertarMaterial(dato, listNewDatos, False, validar)
                    If validar = False Then
                        txtMensajeProseso.Text = txtMensajeProseso.Text + vbCrLf + "Error in the line " + CStr(i) + ".Check the information and try again."
                    Else
                        cont = cont + 1
                    End If
                Else
                    txtMensajeProseso.Text = txtMensajeProseso.Text + vbCrLf + "Error at line " + CStr(i) + " the ID isn't mayor than the existing IDs "
                End If
            Next
            txtMensajeProseso.Text = txtMensajeProseso.Text + vbCrLf + CStr(cont) + " Materials were inserted"
            txtMensajeProseso.Text = txtMensajeProseso.Text + vbCrLf + "Finish"
            NAR(libro.Sheets(1))
            libro.Close(False)
            NAR(libro)
            ApExcel.Quit()
            NAR(ApExcel)
            txtMensajeProseso.Text = txtMensajeProseso.Text + vbCrLf + "The File is Closed"
            txtNumeroMaterial.Text = mtdMaterial.valueMaxMaterial()
            mtdMaterial.selectMaterial(tblMaterial, "%")
        Catch ex As Exception
            MsgBox(ex.Message())
            txtMensajeProseso.Text = txtMensajeProseso.Text + vbCrLf + "Error"
        End Try
    End Sub
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub

    Private Sub chbEnableMaterial_CheckedChanged(sender As Object, e As EventArgs) Handles chbEnableMaterial.CheckedChanged

    End Sub

    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(hWnd As IntPtr, wMsg As Integer, wParam As Integer, lParam As Integer)
    End Sub
    Private Sub TitleBar_MouseMove(sender As Object, e As MouseEventArgs) Handles TitleBar.MouseMove
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub btnDownLoadExcelMaterial_Click(sender As Object, e As EventArgs) Handles btnDownLoadExcelMaterial.Click

        Dim ApExcel = New Microsoft.Office.Interop.Excel.Application
        'Hoja de Material
        Dim libro = ApExcel.Workbooks.Add()
        Try
            Dim Hoja1 = libro.Sheets.Add()
            Dim Hoja2 = libro.Sheets.Add()
            Dim Hoja3 = libro.Sheets.Add()

            Dim count As Integer = 1
            With Hoja1.Range("A1:E1")
                .Font.Bold = True
                .Font.ColorIndex = 1
                With .Interior
                    .ColorIndex = 15
                End With
                .BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Color.Black)
            End With
            Dim columsMaterial() As String = {"ID Material", "Name", "Status", "Vendor", "Class"}
            For i As Int64 = 0 To columsMaterial.Length - 1
                Hoja1.cells(1, i + 1) = columsMaterial(i)
            Next
            Hoja1.Name = "Material"
            'Hoja de Clases
            With Hoja2.Range("A1:B1")
                .Font.Bold = True
                .Font.ColorIndex = 1
                With .Interior
                    .ColorIndex = 15
                End With
                .BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Color.Black)
            End With
            Dim columsClass() As String = {"Code", "Description"}
            For i As Int64 = 0 To columsClass.Length - 1
                Hoja2.cells(1, i + 1) = columsClass(i)
            Next
            Dim tblClass As Data.DataTable = mtdOther.selectMaterialCodes()
            If tblClass.Rows IsNot Nothing Then
                Dim cont As Integer = 2
                For Each row As Data.DataRow In tblClass.Rows()
                    Hoja2.cells(cont, 1) = row.ItemArray(0)
                    Hoja2.cells(cont, 2) = row.ItemArray(1)
                    cont += 1
                Next
            End If
            Hoja2.Name = "Material Class"

            'Hoja de Vendor

            With Hoja3.Range("A1:B1")
                .Font.Bold = True
                .Font.ColorIndex = 1
                With .Interior
                    .ColorIndex = 15
                End With
                .BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Color.Black)
            End With
            Dim columsVendor() As String = {"# Vendor", "Name"}
            For i As Int64 = 0 To columsVendor.Length - 1
                Hoja3.cells(1, i + 1) = columsVendor(i)
            Next
            Dim tblVendor As Data.DataTable = mtdMaterial.selectVendor()
            If tblVendor.Rows IsNot Nothing Then
                Dim cont As Integer = 2
                For Each row As Data.DataRow In tblVendor.Rows()
                    Hoja3.cells(cont, 1) = row.ItemArray(0)
                    Hoja3.cells(cont, 2) = row.ItemArray(1)
                    cont += 1
                Next
            End If
            Hoja3.name = "Vendor"
            Dim sd As New SaveFileDialog
            sd.DefaultExt = "*.xlsx"
            sd.FileName = "MaterialList"
            sd.Filter = "Archivos de Excel (*.xlsx)|*.xlsx"
            sd.ShowDialog()
            libro.SaveAs(sd.FileName)
            NAR(Hoja1)
            NAR(Hoja2)
            NAR(Hoja3)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            libro.Close()
            NAR(libro)
            ApExcel.Quit()
            NAR(ApExcel)
        End Try
    End Sub
    Private Sub btnUploadMaterial_Click(sender As Object, e As EventArgs) Handles btnUploadMaterial.Click
        Try
            Dim sheetName = "Material"
            While sheetName <> ""
                Dim lblMessage As New System.Windows.Forms.Label
                lblMessage.Visible = False
                Dim pgbProgress As New System.Windows.Forms.ProgressBar
                pgbProgress.Visible = False
                Dim tbl = leerExcel(lblMessage, pgbProgress, sheetName)
                If tbl IsNot Nothing Then
                    Dim tblVendorIds As Data.DataTable = mtdMaterial.selectVendor()
                    Dim tblClassIds As Data.DataTable = mtdOther.selectMaterialCodes()
                    Dim tblNewMaterial As New Data.DataTable
                    tblNewMaterial.Columns.Add("ID")
                    tblNewMaterial.Columns.Add("Name")
                    tblNewMaterial.Columns.Add("Status")
                    tblNewMaterial.Columns.Add("IdVendor")
                    tblNewMaterial.Columns.Add("idClass")
                    For Each row As Data.DataRow In tbl.Rows()
                        Dim listRowVendor() As Data.DataRow = tblVendorIds.Select("ID ='" + row.ItemArray(3).ToString() + "' or Name = '" + row.ItemArray(3).ToString() + "'")
                        Dim NewIDVendor As String = "NULL"
                        If listRowVendor.Length > 0 Then
                            NewIDVendor = listRowVendor(0).ItemArray(2)
                        End If
                        Dim listRowClass() As Data.DataRow = tblClassIds.Select("code = '" + row.ItemArray(4).ToString() + "' or description = '" + row.ItemArray(4).ToString() + "'")
                        Dim newidClass As String = "NULL"
                        If listRowClass.Length > 0 Then
                            newidClass = listRowClass(0).ItemArray(0)
                        End If
                        tblNewMaterial.Rows.Add(row.ItemArray(1).ToString(), row.ItemArray(0).ToString(), NewIDVendor, If(row.ItemArray(2).ToString() = "Yes" Or row.ItemArray(2).ToString() = "YES", "E", "D"), newidClass)
                    Next
                    For Each row As Data.DataRow In tblNewMaterial.Rows
                        Dim datos() As String = {row.ItemArray(0), row.ItemArray(1), row.ItemArray(2), row.ItemArray(3), row.ItemArray(4)}
                        If Not mtdMaterial.insertarMaterial(datos) Then
                            If DialogResult.No = MessageBox.Show("Would you like to continue?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) Then
                                Exit For
                            End If
                        End If
                    Next
                    llenarTablas()
                    pgbProgress.Value = 100
                    lblMessage.Text = "Message: End."
                    Exit While
                Else
                    sheetName = InputBox("Please Write the name of the Sheet to Read." + "If do not wish to continue, leave the space blank.", "find Excel Sheet", "Sheet 1")
                End If
            End While
        Catch ex As Exception

        End Try
    End Sub
End Class