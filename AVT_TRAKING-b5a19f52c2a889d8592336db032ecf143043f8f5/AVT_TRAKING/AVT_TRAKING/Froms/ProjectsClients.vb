Imports System.Data
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Public Class ProjectsClients
    Dim mtdJobs As New MetodosJobs
    Dim mtdClient As New MetodosClients
    Dim mtdOthers As New MetodosOthers
    Public datosClientesPO As New List(Of String)
    Public idCliente, idPO, jobNum, workOrder, task, taskTaxes, idWOAuxTaxes As String
    Public clnfromclnFrom As Boolean = True

    Private Sub ocultarPaneles()
        PnllSetup.Visible = False
    End Sub

    Private Sub WorkCodes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ocultarPaneles()
        mtdOthers.llenarCmbWokTMLump(cmbWorkTMLumoSum)
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
            pjc.JobNumber = jobNum
            pjc.idCliente = idCliente
            pjc.PO = idPO
            If workOrder = "" Or workOrder = Nothing Then
                pjc.WorkOrder = ""
                pjc.idAuxWO = ""
            Else
                pjc.idAuxWO = tblProjectClients.CurrentRow().Cells("idAuxWO").Value
                pjc.WorkOrder = workOrder
            End If
        Else
            pjc.idAuxWO = ""
            pjc.WorkOrder = ""
            pjc.JobNumber = ""
            pjc.idCliente = ""
        End If
        Me.Visible = False
        pjc.ShowDialog()
        Me.Visible = True
        mtdClient.buscarProyectosDeCliente(tblProjectClients, idCliente)
    End Sub


    Private Sub btnEmployees_Click(sender As Object, e As EventArgs) Handles btnEmployees.Click
        Dim a As New Employees
        a.Show()
    End Sub

    Private Sub btnAddClient_Click(sender As Object, e As EventArgs) Handles btnAddClient.Click
        Dim idAux = idCliente
        Dim cln As New Clients
        AddOwnedForm(cln)
        cln.btnSelectClient.Visible = True
        cln.ShowDialog()
        If idAux <> idCliente Then
            LimpriarCampos()
            llenarCampos()
        End If
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

    Private Sub LimpriarCamposParaAgregar()
        'txtAddres.Text = ""
        'txtCity.Text = ""
        'txtCompanyName.Text = ""
        'txtFindClientProyects.Text = ""
        'txtFirstName.Text = ""
        'txtPC.Text = ""
        'txtPhoneNumber.Text = ""
        'txtStateProvidence.Text = ""
        txtContractNo.Text = ""
        txtCustomerNo.Text = ""
        txtJobNumber.Text = ""
        cmbCostCode.SelectedIndex = Nothing
        cmbCostDistribution.SelectedIndex = Nothing
        cmbWorkTMLumoSum.SelectedIndex = Nothing
    End Sub



    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If btnAdd.Text = "Save" Then
            Try
                idPO = Nothing
                Dim listPO As New List(Of String)
                listPO.Add(txtJobNumber.Text)
                listPO.Add(cmbWorkTMLumoSum.Text) ' este valor string
                listPO.Add(cmbCostDistribution.Text) ' string  
                listPO.Add(txtCustomerNo.Text) ' int 
                listPO.Add(txtContractNo.Text) ' int 
                listPO.Add(cmbCostCode.Text) ' int
                idPO = mtdJobs.insertarNuevoProyecto(idCliente, listPO)
                If idPO <> Nothing Or idPO <> "" Then
                    mtdClient.buscarProyectosDeClientePorProyeto(tblProjectClients, idCliente)
                    btnAdd.Text = "Add"
                Else
                    MessageBox.Show("Sommthig was wrong please try again or check the data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    btnAdd.Text = "Save"
                End If

            Catch ex As Exception

            End Try
        ElseIf btnAdd.Text = "Add" Then
            If Not idCliente <> "" Or idCliente = Nothing Then
                MessageBox.Show("Please choose a client to add new Job.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                LimpriarCamposParaAgregar()
                btnAdd.Text = "Save"
            End If
        End If
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
        mtdClient.buscarProyectosDeClientePorProyeto(tblProjectClients, idCliente)
        For Each row As DataGridViewRow In tblProjectClients.Rows
            If row.Cells("cmp").Value = 0 Then
                row.Cells("Complete").Value = False
            ElseIf row.Cells("cmp").Value = 1 Then
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
            pcbLogoPC.Image = BytetoImage(tblProjectClients.Rows(0).Cells("photo").Value)
        End If
    End Sub


    Public Sub llenarCampos(ByVal fila As DataGridViewRow)
        'buscar los datos del proyecto 
        If tblProjectClients.Rows.Count() > 0 Then
            cmbWorkTMLumoSum.SelectedIndex = If(fila.Cells("workTMLumpSum").Value <> "", cmbWorkTMLumoSum.FindString(fila.Cells("workTMLumpSum").Value), Nothing)
            cmbCostDistribution.SelectedIndex = If(fila.Cells("costDistribution").Value <> "", cmbCostDistribution.FindString(fila.Cells("costDistribution").Value), Nothing)
            cmbCostCode.SelectedIndex = If(fila.Cells("costCode").Value, cmbCostCode.FindString(fila.Cells("costCode").Value), Nothing)
            txtCustomerNo.Text = fila.Cells("custumerNo").Value
            txtContractNo.Text = fila.Cells("contractNo").Value
            txtJobNumber.Text = fila.Cells("JobNo").Value
        End If
    End Sub

    '==============================================================================================================================================
    '======================= ACTUALIZAR LOS CAMPOS AUTOMATICAMENTE DAOS DEL CLIENTE AL QUITAR EL FOCO =============================================
    '==============================================================================================================================================

    Private Sub txtAddres_Leave(sender As Object, e As EventArgs) Handles txtAddres.Leave
        If idCliente <> Nothing And idCliente <> "" Then
            mtdClient.actualizarAddres(txtAddres.Text, idCliente)
        End If
    End Sub

    Private Sub txtCity_Leave(sender As Object, e As EventArgs) Handles txtCity.Leave
        If idCliente <> Nothing And idCliente <> "" Then
            mtdClient.actualizarCity(txtCity.Text, idCliente)
        End If
    End Sub

    Private Sub txtStateProvidence_Leave(sender As Object, e As EventArgs) Handles txtStateProvidence.Leave
        If idCliente <> Nothing And idCliente <> "" Then
            mtdClient.actualizarProvidence(txtStateProvidence.Text, idCliente)
        End If
    End Sub

    Private Sub txtPC_Leave(sender As Object, e As EventArgs) Handles txtPC.Leave
        If idCliente <> Nothing And idCliente <> "" Then
            mtdClient.actualizarPhoneNumber(txtPhoneNumber.Text, idCliente)
        End If
    End Sub
    '================================================================================================================================================
    '===============================  METODOS PARA ACTUALIZAR JOB INMEDITATAMENTE AL PERDER EL FOCO =================================================
    '================================================================================================================================================

    Private Sub cmbCostDistribution_Leave(sender As Object, e As EventArgs) Handles cmbCostDistribution.Leave
        If btnAdd.Text = "Add" Then  'Se supone que no esta agregando si no que esta actualizando o visualizado unicamente
            mtdJobs.actualizarCostDistribution(cmbCostDistribution.Text, txtJobNumber.Text)
        End If
    End Sub

    Private Sub cmbWorkTMLumoSum_Leave(sender As Object, e As EventArgs) Handles cmbWorkTMLumoSum.Leave
        If btnAdd.Text = "Add" Then  'Se supone que no esta agregando si no que esta actualizando o visualizado unicamente
            mtdJobs.actualizarWorkTMLumpSum(cmbWorkTMLumoSum.Text, txtJobNumber.Text)
        End If
    End Sub

    Private Sub txtContractNo_Leave(sender As Object, e As EventArgs) Handles txtContractNo.Leave
        If btnAdd.Text = "Add" Then  'Se supone que no esta agregando si no que esta actualizando o visualizado unicamente
            mtdJobs.actualizarContractNo(txtContractNo.Text, txtJobNumber.Text)
        End If
    End Sub

    Private Sub txtCustomerNo_Leave(sender As Object, e As EventArgs) Handles txtCustomerNo.Leave
        If btnAdd.Text = "Add" Then  'Se supone que no esta agregando si no que esta actualizando o visualizado unicamente
            mtdJobs.actualizarCustumerNo(txtCustomerNo.Text, txtJobNumber.Text)
        End If
    End Sub

    Private Sub btnUploadSchedule_Click(sender As Object, e As EventArgs) Handles btnUploadSchedule.Click
        'OpenFormPanel(Of scafoldTarking)()
        Dim st As New scafoldTarking
        If idCliente <> "" Then
            st.IdCliente = idCliente
            If txtCompanyName.Text <> "" Then
                st.Company = txtCompanyName.Text
            End If
        End If
        Me.Visible = False
        st.ShowDialog()
        Me.Visible = True
    End Sub

    Private Sub btnTimeEnterSheets_Click(sender As Object, e As EventArgs) Handles btnTimeEnterSheets.Click

        Dim hpe As New HoursWeekPerEmployees
        hpe.ShowDialog()
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
        btnMaximize.Visible = False
        btnRestore.Visible = True
    End Sub

    Private Sub btnRestore_Click(sender As Object, e As EventArgs) Handles btnRestore.Click
        WindowState = FormWindowState.Normal
        btnRestore.Visible = False
        btnMaximize.Visible = True
    End Sub

    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel1.Paint

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub cmbCostCode_Leave(sender As Object, e As EventArgs) Handles cmbCostCode.Leave
        If btnAdd.Text = "Add" Then  'Se supone que no esta agregando si no que esta actualizando o visualizado unicamente
            mtdJobs.actualizarCostCode(cmbCostCode.Text, txtJobNumber.Text)
        End If
    End Sub


    Private Sub tblProjectClients_SelectionChanged(sender As Object, e As EventArgs) Handles tblProjectClients.SelectionChanged
        If tblProjectClients.CurrentRow IsNot Nothing Then
            idPO = tblProjectClients.CurrentRow.Cells("idPO").Value
            jobNum = tblProjectClients.CurrentRow.Cells("jobNo").Value
            idCliente = tblProjectClients.CurrentRow.Cells("idClient").Value
            idWOAuxTaxes = tblProjectClients.CurrentRow.Cells("idAuxWO").Value
            separaridWODeidTask(tblProjectClients.CurrentRow.Cells("Work Order").Value)
            taskTaxes = tblProjectClients.CurrentRow.Cells("idAux").Value
            llenarCampos(tblProjectClients.CurrentRow)
            pcbLogoPC.Image = BytetoImage(tblProjectClients.CurrentRow.Cells("photo").Value)
        End If
    End Sub

    Function separaridWODeidTask(ByVal workOrderCompuesta As String) As Boolean
        If workOrderCompuesta <> "" Or workOrderCompuesta <> Nothing Then
            Dim array() As String = workOrderCompuesta.Split(" ")
            workOrder = array(0)
            task = array(1)
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub btnCompanyInformation_Click(sender As Object, e As EventArgs) Handles btnCompanyInformation.Click
        Dim company As New myCompany
        company.ShowDialog()
    End Sub

    Private Sub btnTaxes_Click(sender As Object, e As EventArgs) Handles btnTaxes.Click
        Dim taxes As New Taxes
        AddOwnedForm(taxes)
        taxes.task = task
        taxes.wo = workOrder
        taxes.idTask = taskTaxes
        taxes.idWO = idWOAuxTaxes
        taxes.ShowDialog()
    End Sub

    Private Sub OpenFormPanel(Of Miform As {Form, New})()
        Dim FormPanel As Form
        FormPanel = PanelChildForm.Controls.OfType(Of Miform)().FirstOrDefault()

        If FormPanel Is Nothing Then
            FormPanel = New Miform()
            FormPanel.TopLevel = False

            FormPanel.Dock = DockStyle.Fill

            PanelChildForm.Controls.Add(FormPanel)
            PanelChildForm.Tag = FormPanel
            FormPanel.Show()
            FormPanel.BringToFront()
        Else
            FormPanel.BringToFront()
        End If
    End Sub



End Class