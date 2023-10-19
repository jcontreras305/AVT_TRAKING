Imports System.Runtime.InteropServices
Public Class WorkCodes
    Dim mtdJobs As MetodosJobs = New MetodosJobs()
    Dim tablaWC As New DataTable 'esta tabla guarda los WC de cierto grupo

    Private Sub WorkCodes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarComboClientsReports(cmbClient)
        btnAddWorkCode.Enabled = True
        btnCancelWC.Enabled = False
        activarCamposWC(False)
        'mtdJobs.selectWC(tblWK)
    End Sub


    Private Sub btnAddWorkCode_Click(sender As Object, e As EventArgs) Handles btnAddWorkCode.Click
        If btnAddWorkCode.Text = "Add" Then
            activarCamposWC(True)
            limpiarcampos()
            If tblWK.Rows.Count = 0 Then
                mtdJobs.selectWC(tblWK)
            End If
            Dim numMax As Integer = metodosGlobales.selecValorMaxColum(tblWK, 0) + 1
            txtWorkCodeID.Text = CStr(numMax)
            btnCancelWC.Enabled = True
            btnAddWorkCode.Text = "Save"
        Else
            If CInt(txtWorkCodeID.Text) <= metodosGlobales.selecValorMaxColum(tblWK, 0) Or TxtWorkCode.Text Is "" Or sprBillingRate1.Value < 0 Or sprBillingRateOT.Value < 0 Then
                MsgBox("Please choose a valid ID to continue or check the data.")
            Else
                Dim datos(17) As String
                datos(0) = txtWorkCodeID.Text
                datos(1) = TxtWorkCode.Text
                datos(2) = txtDescription.Text
                datos(3) = sprBillingRate1.Value.ToString("N")
                datos(4) = sprBillingRateOT.Value.ToString("N")
                datos(5) = sprBillingRate3.Value.ToString("N")
                datos(6) = txtEQExq1.Text
                datos(7) = txtEQExq2.Text
                datos(9) = txtCategory.Text
                datos(10) = txtPayItemType.Text
                datos(11) = txtWorkType.Text
                datos(12) = txtCostCode.Text
                datos(13) = txtCustomerPositionID.Text
                datos(14) = txtCustomerJobPositionDescription.Text
                datos(15) = txtCBSFullNumber.Text
                datos(16) = txtSkillType.Text
                If cmbJob.SelectedIndex > -1 Then
                    datos(8) = cmbJob.Items(cmbJob.SelectedIndex).ToString
                    mtdJobs.nuevaWC(datos)
                    btnAddWorkCode.Text = "Add"
                    btnCancelWC.Visible = False
                    btnUpdateWorkCode.Enabled = False
                    limpiarcampos()
                    activarCamposWC(False)
                    mtdJobs.selectWC(tblWK, cmbJob.Items(cmbJob.SelectedIndex).ToString)
                Else
                    MessageBox.Show("Please select a Job to continue.")
                End If
            End If
        End If
    End Sub


    Private Function activarCamposWC(flag As Boolean)

        txtWorkCodeID.Enabled = flag
        TxtWorkCode.Enabled = flag
        txtEQExq1.Enabled = flag
        txtEQExq2.Enabled = flag
        txtDescription.Enabled = flag
        sprBillingRate3.Value = 0
        sprBillingRate1.Value = 0
        sprBillingRateOT.Value = 0
        sprBillingRate1.Enabled = flag
        sprBillingRateOT.Enabled = flag
        sprBillingRate3.Enabled = flag
        txtCategory.Enabled = flag
        txtCategory.Enabled = flag
        txtPayItemType.Enabled = flag
        txtWorkType.Enabled = flag
        txtCostCode.Enabled = flag
        txtCustomerPositionID.Enabled = flag
        txtCustomerJobPositionDescription.Enabled = flag
        txtCBSFullNumber.Enabled = flag
        txtSkillType.Enabled = flag
        Return True
    End Function

    Sub limpiarcampos()
        Dim numMax As Int32 = metodosGlobales.selecValorMaxColum(tblWK, 0) + 1
        txtWorkCodeID.Text = CStr(numMax)
        TxtWorkCode.Text = ""
        txtEQExq1.Text = ""
        txtEQExq2.Text = ""
        txtDescription.Text = ""
        sprBillingRate1.Value = 0
        sprBillingRateOT.Value = 0
        sprBillingRate3.Value = 0
        txtCategory.Text = ""
        txtPayItemType.Text = ""
        txtWorkType.Text = ""
        txtCostCode.Text = ""
        txtCustomerPositionID.Text = ""
        txtCustomerJobPositionDescription.Text = ""
        txtCBSFullNumber.Text = ""
        txtSkillType.Text = ""
    End Sub

    Private Sub tbnUpdateWorkCode_Click(sender As Object, e As EventArgs) Handles btnUpdateWorkCode.Click
        If MessageBox.Show("Are you sure to Update the WorkCode", "Advertence", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = DialogResult.OK Then
            Dim datos(16) As String
            datos(0) = txtWorkCodeID.Text
            datos(1) = TxtWorkCode.Text
            datos(2) = txtDescription.Text
            datos(3) = sprBillingRate1.Value.ToString("N")
            datos(4) = sprBillingRateOT.Value.ToString("N")
            datos(5) = sprBillingRate3.Value.ToString("N")
            datos(6) = txtEQExq1.Text
            datos(7) = txtEQExq2.Text
            datos(9) = txtCategory.Text
            datos(10) = txtPayItemType.Text
            datos(11) = txtWorkType.Text
            datos(12) = txtCostCode.Text
            datos(13) = txtCustomerPositionID.Text
            datos(14) = txtCustomerJobPositionDescription.Text
            datos(15) = txtCBSFullNumber.Text
            datos(16) = txtSkillType.Text
            If cmbJob.SelectedIndex > -1 Then
                datos(8) = cmbJob.Items(cmbJob.SelectedIndex).ToString
                mtdJobs.acualizarWC(datos)
                btnUpdateWorkCode.Enabled = True
                btnAddWorkCode.Enabled = False
                btnCancelWC.Enabled = True
                mtdJobs.selectWC(tblWK, cmbJob.Items(cmbJob.SelectedIndex).ToString)
            End If
        End If
    End Sub

    Private Sub tblWK_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles tblWK.MouseDoubleClick
        activarCamposWC(True)

        txtWorkCodeID.Text = tblWK.CurrentRow.Cells.Item(0).Value.ToString
        TxtWorkCode.Text = tblWK.CurrentRow.Cells.Item(2).Value.ToString
        txtDescription.Text = tblWK.CurrentRow.Cells.Item(3).Value.ToString
        sprBillingRate1.Value = tblWK.CurrentRow.Cells.Item(4).Value
        sprBillingRateOT.Value = tblWK.CurrentRow.Cells.Item(5).Value
        sprBillingRate3.Value = tblWK.CurrentRow.Cells.Item(6).Value
        txtEQExq1.Text = tblWK.CurrentRow.Cells.Item(7).Value.ToString()
        txtEQExq2.Text = tblWK.CurrentRow.Cells.Item(8).Value.ToString()
        txtCategory.Text = tblWK.CurrentRow.Cells.Item(9).Value.ToString()
        txtPayItemType.Text = tblWK.CurrentRow.Cells.Item(10).Value.ToString()
        txtWorkType.Text = tblWK.CurrentRow.Cells.Item(11).Value.ToString()
        txtCostCode.Text = tblWK.CurrentRow.Cells.Item(12).Value.ToString()
        txtCustomerPositionID.Text = tblWK.CurrentRow.Cells.Item(13).Value.ToString()
        txtCustomerJobPositionDescription.Text = tblWK.CurrentRow.Cells.Item(14).Value.ToString()
        txtCBSFullNumber.Text = tblWK.CurrentRow.Cells.Item(15).Value.ToString()
        txtSkillType.Text = tblWK.CurrentRow.Cells.Item(16).Value.ToString()

        btnAddWorkCode.Enabled = False
        btnCancelWC.Enabled = True
        btnUpdateWorkCode.Enabled = True
    End Sub

    Private Sub btnCancelWC_Click(sender As Object, e As EventArgs) Handles btnCancelWC.Click
        If MessageBox.Show("Are you sure to cancel ?, If you accept the changes they will be lost.", "Advertence", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = DialogResult.OK Then
            limpiarcampos()
            activarCamposWC(False)
            btnAddWorkCode.Enabled = True
            btnCancelWC.Enabled = False
            btnUpdateWorkCode.Enabled = False
        End If

    End Sub

    Private Sub btnFindWK_Click(sender As Object, e As EventArgs) Handles btnFindWK.Click
        mtdJobs.buscarWC(txtBucar.Text, tblWK)
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

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.Close()
    End Sub

    Private Sub cmbClient_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClient.SelectedIndexChanged
        If cmbClient.SelectedIndex > -1 Then
            Dim array() As String = cmbClient.Items(cmbClient.SelectedIndex).ToString.Split(" ")
            llenarComboJobsReports(cmbJob, array(0))
        End If
    End Sub

    Private Sub cmbJob_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbJob.SelectedIndexChanged
        Try
            If cmbJob.SelectedIndex > -1 Then
                mtdJobs.selectWC(tblWK, cmbJob.Items(cmbJob.SelectedIndex).ToString)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        If cmbJob.SelectedIndex > -1 Then
            Dim lbl As New Label
            Dim pgs As New ProgressBar
            Dim flag As Boolean = False
            Dim tbl As New DataTable
            Dim hoja As String = "Workcodes"
            While flag = False
                tbl = leerExcel(lbl, pgs, hoja)
                If tbl IsNot Nothing Then
                    flag = True
                    Exit While
                Else
                    hoja = InputBox("Please type the sheet name to continue or leave the field blank.", "Message")
                    If hoja = "" Then
                        flag = False
                        Exit While
                    End If
                End If
            End While
            If flag Then
                If tbl.Rows.Count > 0 Then
                    If DialogResult.Yes = MessageBox.Show("In the excel exist " + tbl.Rows.Count.ToString + " Work Codes, Would you like to start the process to insert?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                        mtdJobs.insertWorkCodeTable(tbl, cmbJob.Items(cmbJob.SelectedIndex).ToString)
                    End If
                End If
            End If
        Else
            MessageBox.Show("Please select a JobNo to continue.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnDownloadExcel_Click(sender As Object, e As EventArgs) Handles btnDownloadExcel.Click
        Try
            Dim sd As New SaveFileDialog
            sd.DefaultExt = "*.xlsx"
            sd.FileName = "Workcodes.xlsx"
            sd.Filter = "Archivos de Excel (*.xlsx)|*.xlsx"
            If DialogResult.OK = sd.ShowDialog() Then
                Dim ApExcel = New Microsoft.Office.Interop.Excel.Application
                Dim libro = ApExcel.Workbooks.Add
                Dim colums() As String = {"idWorkCode", "Name", "Description", "Billing Rate ST", "Billing Rate OT", "Billing Rate 3", "EQExp1", "EQExp2", "Job No", "Category", "Pay Item Type", "Work Type", "Cost Code", "Customer Position ID", "Customer Job Position Description", "CBS Full Number", "Skill Type"}
                For i As Int16 = 0 To colums.Length - 1
                    libro.Sheets(1).cells(1, i + 1) = colums(i)
                Next
                With libro.Sheets(1).Range("A1:O1")
                    .Font.Bold = True
                    .Font.ColorIndex = 1
                    With .Interior
                        .ColorIndex = 15
                    End With
                    .BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Color.Black)
                End With
                libro.Sheets(1).Name = "Workcodes"
                libro.SaveAs(sd.FileName)
                NAR(libro.Sheets(1))
                libro.Close(False)
                NAR(libro)
                ApExcel.Quit()
                NAR(ApExcel)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtCostCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCostCode.KeyPress
        If Not (Char.IsNumber(e.KeyChar) Or Asc(e.KeyChar) = 46 Or e.KeyChar = vbBack) Then
            e.Handled = True
        ElseIf Asc(e.KeyChar) = 46 Then
            If txtCostCode.Text.Count(Function(c As Char) c = ".") = 4 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtCBSFullNumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCBSFullNumber.KeyPress
        If Not (Char.IsNumber(e.KeyChar) Or Asc(e.KeyChar) = 46 Or e.KeyChar = vbBack) Then
            e.Handled = True
        ElseIf Asc(e.KeyChar) = 46 Then
            If txtCBSFullNumber.Text.Count(Function(c As Char) c = ".") = 3 Then
                e.Handled = True
            End If
        End If
    End Sub

End Class