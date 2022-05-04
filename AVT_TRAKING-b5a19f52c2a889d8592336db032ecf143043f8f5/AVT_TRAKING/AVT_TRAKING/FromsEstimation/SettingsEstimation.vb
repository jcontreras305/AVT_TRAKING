Public Class SettingsEstimation

    Dim mtdClients As New ClientsEST
    Private Sub SettingsEstimation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            btnSave.Enabled = False
            btnDelete.Enabled = False
            If mtdClients.selectClientsEst() Then
                If mtdClients.tablaClientEst.Rows.Count > 0 Then
                    mtdClients.cargarDatosClientEst(mtdClients.tablaClientEst.Rows(0).ItemArray(1))
                    cargarDatos()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
    Private Function llenarTablaPojects() As Boolean
        Try
            tblClientProjects.Rows.Clear()
            For Each row As Data.DataRow In mtdClients.tablaprojects.Rows
                tblClientProjects.Rows.Add(row.ItemArray(0), row.ItemArray(1), row.ItemArray(2), row.ItemArray(3), row.ItemArray(4), row.ItemArray(5))
            Next
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Sub btnSaveClient_Click(sender As Object, e As EventArgs) Handles btnSaveClient.Click
        If mtdClients.saveClient(mtdClients) Then
            MsgBox("Successful")
            mtdClients.selectClientsEst()
        End If
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        mtdClients.Clear()
        cargarDatos()
        btnSave.Enabled = False
        btnDelete.Enabled = False
    End Sub
    Private Sub cargarDatos()
        Try
            txtNumberClient.Text = mtdClients.numberClient.ToString()
            txtCompanyName.Text = mtdClients.companyName
            txtContactName.Text = mtdClients.contactName
            txtBuilddingAddress.Text = mtdClients.avenue
            txtCity.Text = mtdClients.city
            txtNumberAddress.Text = mtdClients.number.ToString()
            txtFaxNum.Text = mtdClients.phone2
            txtPhoneNum.Text = mtdClients.phone1
            txtPlant.Text = mtdClients.plant
            txtPostalCode.Text = mtdClients.postalCode.ToString
            txtProvince.Text = mtdClients.province
            llenarTablaPojects()
            btnSave.Enabled = True
            btnDelete.Enabled = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtNumberClient_TextChanged(sender As Object, e As EventArgs) Handles txtNumberClient.Leave
        mtdClients.numberClient = If(txtNumberClient.Text = "", 0, CInt(txtNumberClient.Text))
    End Sub
    Private Sub txtNumberClient_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumberClient.KeyPress
        If Not IsNumeric(e.KeyChar()) And Not (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) And Not e.KeyChar = vbBack Then
            e.Handled = True
        End If
    End Sub
    Private Sub txtCompanyName_TextChanged(sender As Object, e As EventArgs) Handles txtCompanyName.TextChanged
        mtdClients.companyName = txtCompanyName.Text
    End Sub
    Private Sub txtBuilddingAddress_TextChanged(sender As Object, e As EventArgs) Handles txtBuilddingAddress.TextChanged
        mtdClients.avenue = txtBuilddingAddress.Text
    End Sub
    Private Sub txtCity_TextChanged(sender As Object, e As EventArgs) Handles txtCity.TextChanged
        mtdClients.city = txtCity.Text
    End Sub
    Private Sub txtProvince_TextChanged(sender As Object, e As EventArgs) Handles txtProvince.TextChanged
        mtdClients.province = txtProvince.Text
    End Sub
    Private Sub txtPostalCode_Leave(sender As Object, e As EventArgs) Handles txtPostalCode.Leave
        mtdClients.postalCode = txtPostalCode.Text
    End Sub
    Private Sub txtPostalCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPostalCode.KeyPress
        If Not IsNumeric(e.KeyChar()) And Not (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) And Not e.KeyChar = vbBack Then
            e.Handled = True
        End If
    End Sub
    Private Sub txtContactName_TextChanged(sender As Object, e As EventArgs) Handles txtContactName.TextChanged
        mtdClients.contactName = txtContactName.Text
    End Sub

    Private Sub txtPhoneNum_TextChanged(sender As Object, e As EventArgs) Handles txtPhoneNum.TextChanged
        mtdClients.phone1 = txtPhoneNum.Text
    End Sub
    Private Sub txtPhoneNum_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPhoneNum.KeyPress
        If Not IsNumeric(e.KeyChar()) And Not (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) And Not e.KeyChar = vbBack Then
            e.Handled = True
        End If
    End Sub
    Private Sub txtFaxNum_Leave(sender As Object, e As EventArgs) Handles txtFaxNum.Leave
        mtdClients.phone2 = txtFaxNum.Text
    End Sub
    Private Sub txtFaxNum_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFaxNum.KeyPress
        If Not IsNumeric(e.KeyChar()) And Not (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) And Not e.KeyChar = vbBack Then
            e.Handled = True
        End If
    End Sub
    Private Sub txtPlant_TextChanged(sender As Object, e As EventArgs) Handles txtPlant.TextChanged
        mtdClients.plant = txtPlant.Text
    End Sub
    Private Sub txtNumberAddress_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumberAddress.KeyPress
        If Not IsNumeric(e.KeyChar()) And Not (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) And Not e.KeyChar = vbBack Then
            e.Handled = True
        End If
    End Sub
    Private Sub txtNumberAddress_Leave(sender As Object, e As EventArgs) Handles txtNumberAddress.Leave
        mtdClients.number = CInt(txtNumberAddress.Text)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If tblClientProjects.SelectedRows.Count > 0 Then
                If mtdClients.insertarActualizarProject(mtdClients.idClient, tblClientProjects) Then
                    MsgBox("Successful")
                    mtdClients.cargarDatosClientEst(mtdClients.numberClient.ToString())
                    llenarTablaPojects()
                End If
            Else
                MessageBox.Show("Please select a row.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If tblClientProjects.SelectedRows.Count > 0 Then
                If DialogResult.Yes = MessageBox.Show("Are you Sure to DELETE these Projects?" + vbCrLf + "Is probably that the project has assigned different Estimations.", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) Then
                    If mtdClients.deleteProject(tblClientProjects) Then
                        MsgBox("Successful")
                        mtdClients.cargarDatosClientEst(mtdClients.numberClient.ToString())
                        llenarTablaPojects()
                    End If
                End If
            Else
                MessageBox.Show("Please select a row.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class