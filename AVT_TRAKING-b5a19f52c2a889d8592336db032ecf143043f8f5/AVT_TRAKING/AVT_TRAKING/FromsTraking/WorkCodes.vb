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
                Dim datos(9) As String
                datos(0) = txtWorkCodeID.Text
                datos(1) = TxtWorkCode.Text
                datos(2) = txtDescription.Text
                datos(3) = sprBillingRate1.Value.ToString("N")
                datos(4) = sprBillingRateOT.Value.ToString("N")
                datos(5) = sprBillingRate3.Value.ToString("N")
                datos(6) = txtEQExq1.Text
                datos(7) = txtEQExq2.Text
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
        If flag Then
            txtWorkCodeID.Enabled = True
            TxtWorkCode.Enabled = True
            txtEQExq1.Enabled = True
            txtEQExq2.Enabled = True
            txtDescription.Enabled = True
            sprBillingRate3.Value = 0
            sprBillingRate1.Value = 0
            sprBillingRateOT.Value = 0
            sprBillingRate1.Enabled = True
            sprBillingRateOT.Enabled = True
            sprBillingRate3.Enabled = True
        Else
            txtWorkCodeID.Enabled = False
            TxtWorkCode.Enabled = False
            txtEQExq1.Enabled = False
            txtEQExq2.Enabled = False
            txtDescription.Enabled = False
            sprBillingRate1.Value = 0
            sprBillingRateOT.Value = 0
            sprBillingRate3.Value = 0
            sprBillingRate1.Enabled = False
            sprBillingRateOT.Enabled = False
            sprBillingRate3.Enabled = False
        End If
        Return True
    End Function



    Function limpiarcampos()
        Dim numMax As Int32 = metodosGlobales.selecValorMaxColum(tblWK, 0) + 1
        txtWorkCodeID.Text = CStr(numMax)
        TxtWorkCode.Text = ""
        txtEQExq1.Text = ""
        txtEQExq2.Text = ""
        txtDescription.Text = ""
        sprBillingRate1.Value = 0
        sprBillingRateOT.Value = 0
        sprBillingRate3.Value = 0
    End Function


    Private Sub tbnUpdateWorkCode_Click(sender As Object, e As EventArgs) Handles btnUpdateWorkCode.Click
        If MessageBox.Show("Are you sure to Update the WorkCode", "Advertence", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = DialogResult.OK Then
            Dim datos(8) As String
            datos(0) = txtWorkCodeID.Text
            datos(1) = TxtWorkCode.Text
            datos(2) = txtDescription.Text
            datos(3) = sprBillingRate1.Value.ToString("N")
            datos(4) = sprBillingRateOT.Value.ToString("N")
            datos(5) = sprBillingRate3.Value.ToString("N")
            datos(6) = txtEQExq1.Text
            datos(7) = txtEQExq2.Text
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
                Dim colums() As String = {"idWorkCode", "Name", "Description", "Billing Rate ST", "Billing Rate OT", "Billing Rate 3", "EQExp1", "EQExp2", "Job No"}
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
End Class