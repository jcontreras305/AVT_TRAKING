Public Class WorkCodes
    Dim mtdJobs As MetodosJobs = New MetodosJobs()
    Dim tablaWC As New DataTable 'esta tabla guarda los WC de cierto grupo

    Private Sub WorkCodes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnAddWorkCode.Enabled = True
        btnCancelWC.Enabled = False
        activarCamposWC(False)
        mtdJobs.selectWC(tblWK)
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
                Dim datos(8) As String
                datos(0) = txtWorkCodeID.Text
                datos(1) = TxtWorkCode.Text
                datos(2) = txtDescription.Text
                datos(3) = sprBillingRate1.Value.ToString("N")
                datos(4) = sprBillingRateOT.Value.ToString("N")
                datos(5) = sprBillingRate3.Value.ToString("N")
                datos(6) = txtEQExq1.Text
                datos(7) = txtEQExq2.Text
                mtdJobs.nuevaWC(datos)
                btnAddWorkCode.Text = "Add"
                btnCancelWC.Visible = False
                btnUpdateWorkCode.Enabled = False
                limpiarcampos()
                activarCamposWC(False)
                mtdJobs.selectWC(tblWK)
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
            Dim datos(7) As String
            datos(0) = txtWorkCodeID.Text
            datos(1) = TxtWorkCode.Text
            datos(2) = txtDescription.Text
            datos(3) = sprBillingRate1.Value.ToString("N")
            datos(4) = sprBillingRateOT.Value.ToString("N")
            datos(5) = sprBillingRate3.Value.ToString("N")
            datos(6) = txtEQExq1.Text
            datos(7) = txtEQExq2.Text
            mtdJobs.acualizarWC(datos)
            btnUpdateWorkCode.Enabled = True
            btnAddWorkCode.Enabled = False
            btnCancelWC.Enabled = True
            mtdJobs.selectWC(tblWK)
        End If
    End Sub

    Private Sub tblWK_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles tblWK.MouseDoubleClick
        activarCamposWC(True)

        txtWorkCodeID.Text = tblWK.CurrentRow.Cells.Item(0).Value.ToString
        TxtWorkCode.Text = tblWK.CurrentRow.Cells.Item(1).Value.ToString
        txtDescription.Text = tblWK.CurrentRow.Cells.Item(2).Value.ToString
        sprBillingRate1.Value = tblWK.CurrentRow.Cells.Item(3).Value
        sprBillingRateOT.Value = tblWK.CurrentRow.Cells.Item(4).Value
        sprBillingRate3.Value = tblWK.CurrentRow.Cells.Item(5).Value
        txtEQExq1.Text = tblWK.CurrentRow.Cells.Item(6).Value.ToString()
        txtEQExq2.Text = tblWK.CurrentRow.Cells.Item(7).Value.ToString()


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
End Class