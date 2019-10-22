Imports System.Data
Imports System.Data.SqlClient
Public Class WorkCodes

    Dim workcode As MetodosWorkCodes = New MetodosWorkCodes()

    Private Sub WorkCodes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub MostrarDatos()
        workcode.ConsultaWorkCodes("select * from WorkCode")
        Me.DataGridView1.DataSource = workcode.ds.Tables("WorkCode")

    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim agregar As String = "insert into WorkCode values (" + txtWorkCodeID.Text + ",'" + txtJobNumber.Text + "','" +
            txtSubJob.Text + "','" + txtCraft.Text + "','" + txtWorkCode.Text + "','" + txtClassification.Text +
            "','" + txtBillingRateST.Text + "','" + txtBillingRateOT.Text + "','" + txtBillingRate3.Text + "','" + txtClassDescription.Text + "')"

        If (workcode.InsertarWorkCodes(agregar)) Then
            MessageBox.Show("Datos agregados correctamente")
            MostrarDatos()
        Else
            MessageBox.Show("Error al agregar")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim a As New MainFrom
        a.Show()
        Me.Finalize()
    End Sub

    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        MostrarDatos()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim dgv As DataGridViewRow = DataGridView1.Rows(e.RowIndex)

        txtWorkCodeID.Text = dgv.Cells(0).Value.ToString()
        txtJobNumber.Text = dgv.Cells(1).Value.ToString()
        txtSubJob.Text = dgv.Cells(2).Value.ToString()
        txtCraft.Text = dgv.Cells(3).Value.ToString()
        txtWorkCode.Text = dgv.Cells(4).Value.ToString()
        txtClassification.Text = dgv.Cells(5).Value.ToString()
        txtBillingRateST.Text = dgv.Cells(6).Value.ToString()
        txtBillingRateOT.Text = dgv.Cells(7).Value.ToString()
        txtBillingRate3.Text = dgv.Cells(8).Value.ToString()
        txtClassDescription.Text = dgv.Cells(9).Value.ToString()

    End Sub

    Private Sub txtFiltro_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFiltro.KeyPress
        Dim conn = New SqlConnection("data source=localhost; initial catalog=VRT_TRAKING; integrated security=true")
        Dim da = New SqlDataAdapter("select * from WorkCode where JobNumber like '" + txtFiltro.Text + "%'", conn)
        Dim dt = New DataTable
        da.Fill(dt)

        Me.DataGridView1.DataSource = dt
    End Sub
End Class