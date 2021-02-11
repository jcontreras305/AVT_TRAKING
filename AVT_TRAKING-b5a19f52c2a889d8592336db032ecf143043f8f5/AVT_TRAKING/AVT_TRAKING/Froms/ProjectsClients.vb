Imports System.Data
Imports System.Data.SqlClient
Public Class ProjectsClients
    Dim mtdJobs As New MetodosJobs
    Dim mtdClient As New MetodosClients
    Public datosClientesPO As New List(Of String)
    Public idCliente As String
    Public clnfromclnFrom As Boolean = True

    Private Sub ocultarPaneles()
        PnllSetup.Visible = False
    End Sub

    Private Sub WorkCodes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ocultarPaneles()
    End Sub

    Private Sub btnWK_Click(sender As Object, e As EventArgs) Handles btnWK.Click
        Dim wk As New WorkCodes
        wk.ShowDialog()
    End Sub

    Private Sub btnSetup_Click(sender As Object, e As EventArgs) Handles btnSetup.Click
        If PnllSetup.Visible = True Then
            PnllSetup.Visible = False
        Else
            PnllSetup.Visible = True
        End If
    End Sub

    Private Sub btnExpences_Click(sender As Object, e As EventArgs) Handles btnExpences.Click
        Dim a As New Expences
        a.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub btnProyeccts_Click(sender As Object, e As EventArgs) Handles btnProyeccts.Click
        Dim pjc As New ProjectsCosts
        If tblProjectClients.Rows.Count() > 0 Then
            pjc.WorkOrder = tblProjectClients.CurrentRow.Cells(0).Value
        Else
            pjc.WorkOrder = ""
        End If

        pjc.ShowDialog()
    End Sub

    Private Sub btnEmployees_Click(sender As Object, e As EventArgs) Handles btnEmployees.Click
        Dim hpe As New HoursWeekPeerEmployees
        hpe.ShowDialog()
    End Sub

    Private Sub btnAddClient_Click(sender As Object, e As EventArgs) Handles btnAddClient.Click
        Dim idAux = idCliente
        Dim cln As New Clients
        AddOwnedForm(cln)
        cln.btnSelectClient.Visible = True
        cln.ShowDialog()

        If idAux <> idCliente Then
            LimpriarCampos()
        End If
        llenarCampos()
    End Sub

    Private Sub LimpriarCampos()
        txtAddres.Text = ""
        txtCity.Text = ""
        txtCompanyName.Text = ""
        'txtFindClientProyects.Text = ""
        txtFirstName.Text = ""
        txtPC.Text = ""
        txtPhoneNumber.Text = ""
        txtStateProvidence.Text = ""
        txtContractNo.Text = ""
        txtCustomerNo.Text = ""
        txtJobNumber.Text = ""
        cmbCostCode.SelectedIndex = Nothing
        cmbCostDistribution.SelectedIndex = Nothing
        cmbWorkTMLumoSum.SelectedIndex = Nothing
    End Sub


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim listPO As New List(Of String)
            listPO.Add(txtJobNumber.Text)
            listPO.Add(cmbWorkTMLumoSum.Text) ' este valor string
            listPO.Add(cmbCostDistribution.Text) ' string  
            listPO.Add(txtCustomerNo.Text) ' int 
            listPO.Add(txtContractNo.Text) ' int 
            listPO.Add(cmbCostCode.Text) ' int
            mtdJobs.insertarNuevoProyecto(idCliente, listPO)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnFindClintProyects_Click(sender As Object, e As EventArgs) Handles btnFindClintProyects.Click
        Dim idAux = idCliente
        mtdClient.buscarProyectosDeClientePorProyeto(tblProjectClients, txtFindClientProyects.Text)
        If tblProjectClients.Rows.Count() > 0 Then
            idCliente = tblProjectClients.Rows(0).Cells("idClient").Value
            If idAux <> idCliente Then
                LimpriarCampos()
            End If
            datosClientesPO.Clear()
            If idCliente <> Nothing Or idCliente <> "" Then
                mtdClient.bucarClienteDatos(idCliente, datosClientesPO)
                llenarCampos()
            End If
        Else
            idCliente = Nothing
            LimpriarCampos()
        End If
    End Sub

    Private Sub llenarCampos()

        idCliente = datosClientesPO(0)
        txtFirstName.Text = datosClientesPO(1)
        txtCompanyName.Text = datosClientesPO(2)
        txtAddres.Text = datosClientesPO(3)
        txtCity.Text = datosClientesPO(4)
        txtStateProvidence.Text = datosClientesPO(5)
        txtPC.Text = datosClientesPO(6)
        txtPhoneNumber.Text = datosClientesPO(7)

        For Each row As DataGridViewRow In tblProjectClients.Rows
            If row.Cells("Cmp").Value = 0 Then
                row.Cells("Complete").Value = False
            ElseIf row.Cells("Cmp").Value = 1 Then
                row.Cells("Complete").Value = True
            End If
        Next

        'buscar los datos del proyecto 
        If tblProjectClients.Rows.Count() > 0 Then
            cmbWorkTMLumoSum.SelectedIndex = cmbWorkTMLumoSum.FindString(tblProjectClients.Rows(0).Cells("workTMLumpSum").Value)
            cmbCostDistribution.SelectedIndex = cmbCostDistribution.FindString(tblProjectClients.Rows(0).Cells("costDistribution").Value)
            txtCustomerNo.Text = tblProjectClients.Rows(0).Cells("custumerNo").Value
            txtContractNo.Text = tblProjectClients.Rows(0).Cells("contractNo").Value
            cmbCostCode.SelectedIndex = cmbCostCode.FindString(tblProjectClients.Rows(0).Cells("costCode").Value)
            txtJobNumber.Text = tblProjectClients.Rows(0).Cells("JobNo").Value
        End If
    End Sub
End Class