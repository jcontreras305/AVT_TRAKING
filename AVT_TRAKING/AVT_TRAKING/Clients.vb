Public Class Clients

    Dim client As MetodosClients = New MetodosClients()

    Public Sub MostrarDatos()
        client.ConsultaClients("select * from clients")
        Me.DataGridView1.DataSource = client.ds.Tables("clients")

    End Sub

    Private Sub BtnSaveClient_Click(sender As Object, e As EventArgs) Handles btnSaveClient.Click
        Dim agregar As String = "insert into clients values (" + txtIdClients.Text + ",'" + txtCompanyName.Text + "','" +
            txtAdress.Text + "','" + txtCity.Text + "','" + txtStateProvince.Text + "','" + txtPostalCode.Text + "','" + txtContactFistName.Text + "','" + txtContactLastName.Text + "',
            '" + txtContactTitle.Text + "','" + txtPhoneNumber.Text + "','" + txtJobNumber.Text + "','" + txtSubJob.Text + "','" + txtCostCode.Text + "','" + txtWorkLumpsum.Text + "')"

        If (client.InsertarClients(agregar)) Then
            MessageBox.Show("Datos agregados correctamente")
            MostrarDatos()
        Else
            MessageBox.Show("Error al agregar")
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim dgv As DataGridViewRow = DataGridView1.Rows(e.RowIndex)

        txtIdClients.Text = dgv.Cells(0).Value.ToString()
        txtCompanyName.Text = dgv.Cells(1).Value.ToString()
        txtAdress.Text = dgv.Cells(2).Value.ToString()
        txtCity.Text = dgv.Cells(3).Value.ToString()
        txtStateProvince.Text = dgv.Cells(4).Value.ToString()
        txtPostalCode.Text = dgv.Cells(5).Value.ToString()
        txtContactFistName.Text = dgv.Cells(6).Value.ToString()
        txtContactLastName.Text = dgv.Cells(7).Value.ToString()
        txtContactTitle.Text = dgv.Cells(8).Value.ToString()
        txtPhoneNumber.Text = dgv.Cells(9).Value.ToString()
        txtJobNumber.Text = dgv.Cells(10).Value.ToString()
        txtSubJob.Text = dgv.Cells(11).Value.ToString()
        txtCostCode.Text = dgv.Cells(12).Value.ToString()
        txtWorkLumpsum.Text = dgv.Cells(13).Value.ToString()


    End Sub

    Private Sub BtnMenu_Click(sender As Object, e As EventArgs) Handles btnMenu.Click
        Dim a As New MainFrom
        a.Show()
        Me.Finalize()
    End Sub

    Private Sub BtnQueryClient_Click(sender As Object, e As EventArgs) Handles btnQueryClient.Click
        MostrarDatos()
    End Sub
End Class