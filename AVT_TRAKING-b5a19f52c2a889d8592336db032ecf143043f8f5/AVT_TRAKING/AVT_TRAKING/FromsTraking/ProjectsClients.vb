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
    Dim Find As Boolean = False
    Public totalHoursJob As Double

    Private Sub ocultarPaneles()
        PnllSetup.Visible = False
    End Sub

    Private Sub WorkCodes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ocultarPaneles()
        mtdOthers.llenarCmbWokTMLump(cmbWorkTMLumoSum)
    End Sub
    Public Function validAccess(ByVal lUser As Users) As Boolean
        For Each item As Object In pnlButtonsPOCl.Controls
            Dim typeItem As String = item.GetType.ToString()
            If typeItem = "System.Windows.Forms.Button" Then
                item = CType(item, Button)
                Dim nameBtn As String = item.Text.ToString.TrimStart
                nameBtn = nameBtn.TrimEnd
                If lUser.ListAccess.Exists(Function(val) val = nameBtn) Then
                    item.Visible = True
                End If
            ElseIf typeItem = "System.Windows.Forms.Panel" And item.name = "PnllSetup" Then
                If lUser.ListAccess.Exists(Function(val) val = "Setup") Then
                    item.enabled = True
                    btnSetup.Visible = True
                    For Each itemSetup As Object In PnllSetup.Controls
                        itemSetup = CType(itemSetup, Button)
                        Dim nameBtnSetUp As String = itemSetup.text.ToString.TrimStart
                        nameBtnSetUp = nameBtnSetUp.TrimEnd
                        If lUser.ListAccess.Exists(Function(val) val = nameBtnSetUp) Then
                            itemSetup.Visible = True
                        Else
                            itemSetup.visible = False
                        End If
                    Next
                Else
                    btnSetup.Visible = False
                    item.Enabled = False
                End If
            End If
        Next
        Return True
    End Function
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
        If tblProjectClientsAll.SelectedRows.Count() > 0 Then
            pjc.JobNumber = tblProjectClientsAll.SelectedRows(0).Cells("jobNo").Value.ToString
            pjc.idCliente = tblProjectClientsAll.SelectedRows(0).Cells("idClient").Value.ToString
            pjc.PO = tblProjectClientsAll.SelectedRows(0).Cells("clmIdPO").Value.ToString
            If workOrder = "" Or workOrder = Nothing Then
                pjc.WorkOrder = ""
                pjc.idAuxWO = ""
            Else
                pjc.idAuxWO = tblProjectClientsAll.CurrentRow().Cells("idAuxWO").Value
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
        mtdClient.buscarProyectosDeClienteAll(tblProjectClientsAll, idCliente)
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
                    mtdClient.buscarProyectosDeClientePorProyeto(tblProjectClientsAll, idCliente)
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
        Find = True
        mtdClient.buscarProyectosDeClientePorProyetoAll(tblProjectClientsAll, txtFindClientProyects.Text)
        If tblProjectClientsAll.Rows.Count() > 0 Then
            idCliente = tblProjectClientsAll.Rows(0).Cells("idClient").Value
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
        Find = False
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
        If Not Find Then
            mtdClient.buscarProyectosDeClientePorProyetoAll(tblProjectClientsAll, idCliente)
        End If
        'For Each row As DataGridViewRow In tblProjectClients.Rows
        '    If row.Cells("cmp").Value = 0 Then
        '        row.Cells("Complete").Value = False
        '    ElseIf row.Cells("cmp").Value = 1 Then
        '        row.Cells("Complete").Value = True
        '    End If
        'Next

        'buscar los datos del proyecto 

        If tblProjectClientsAll.Rows IsNot Nothing Then
            If tblProjectClientsAll.Rows.Count() > 0 Then
                llenarCampos(tblProjectClientsAll.Rows(0))
            End If
        End If
    End Sub


    Public Sub llenarCampos(ByVal fila As DataGridViewRow)
        'buscar los datos del proyecto 
        If tblProjectClientsAll.Rows IsNot Nothing Then
            If tblProjectClientsAll.Rows.Count > 0 Then
                cmbWorkTMLumoSum.SelectedIndex = If(fila.Cells("workTMLumpSum").Value <> "", cmbWorkTMLumoSum.FindString(fila.Cells("workTMLumpSum").Value), Nothing)
                cmbCostDistribution.SelectedIndex = If(fila.Cells("costDistribution").Value <> "", cmbCostDistribution.FindString(fila.Cells("costDistribution").Value), Nothing)
                cmbCostCode.SelectedIndex = If(fila.Cells("costCode").Value, cmbCostCode.FindString(fila.Cells("costCode").Value), Nothing)
                txtCustomerNo.Text = fila.Cells("custumerNo").Value
                txtContractNo.Text = fila.Cells("contractNo").Value
                txtJobNumber.Text = fila.Cells("jobNo").Value
            End If
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
        'Me.Visible = False
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

    Private Sub btnTrack_Click(sender As Object, e As EventArgs) Handles btnTrack.Click
        Try
            Dim trackU As New Track
            trackU.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnMaterialCodes_Click(sender As Object, e As EventArgs) Handles btnMaterialCodes.Click
        Try
            Dim mat As New Materials
            mat.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnKPI_Click(sender As Object, e As EventArgs) Handles btnKPI.Click
        Try
            Dim kpi As New KPI
            kpi.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnPBI_Click(sender As Object, e As EventArgs) Handles btnPBI.Click
        Try
            Dim pbi As New Power_BI_Queries
            pbi.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbCostCode_Leave(sender As Object, e As EventArgs) Handles cmbCostCode.Leave
        If btnAdd.Text = "Add" Then  'Se supone que no esta agregando si no que esta actualizando o visualizado unicamente
            mtdJobs.actualizarCostCode(cmbCostCode.Text, txtJobNumber.Text)
        End If
    End Sub

    Private Sub tblProjectClientsAll_SelectionChangued(sender As Object, e As EventArgs) Handles tblProjectClientsAll.SelectionChanged
        If tblProjectClientsAll.CurrentRow IsNot Nothing And Find = False Then
            idPO = tblProjectClientsAll.CurrentRow.Cells("clmIdPO").Value
            jobNum = tblProjectClientsAll.CurrentRow.Cells("jobNo").Value
            idCliente = tblProjectClientsAll.CurrentRow.Cells("idClient").Value
            idWOAuxTaxes = tblProjectClientsAll.CurrentRow.Cells("idAuxWO").Value
            separaridWODeidTask(tblProjectClientsAll.CurrentRow.Cells("clmWorkOrder").Value)
            taskTaxes = tblProjectClientsAll.CurrentRow.Cells("idAux").Value
            llenarCampos(tblProjectClientsAll.CurrentRow)
            pcbLogoPC.Image = BytetoImage(tblProjectClientsAll.CurrentRow.Cells("photo").Value)
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
        Try
            If jobNum <> "" Then
                Dim taxes As New Taxes
                AddOwnedForm(taxes)
                taxes.task = task
                taxes.wo = workOrder
                taxes.idTask = taskTaxes
                taxes.idWO = idWOAuxTaxes
                taxes.job = jobNum

                taxes.Show()
            Else
                MessageBox.Show("Please select a Job Number.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception

        End Try
    End Sub

    'Private Function calcularTotalHoursJob(ByVal job As String) As Decimal()
    '    Try
    '        Dim THours As Decimal = 0.0
    '        Dim THoursST As Decimal = 0.0
    '        Dim THoursOT As Decimal = 0.0
    '        Dim mtdTx As New MetodosTaxes
    '        Dim horas = mtdTx.selectTotalHoursCount()

    '        Dim array() As Decimal = {THours, THoursST, THoursOT}
    '        Return array
    '    Catch ex As Exception
    '        Return {0.0, 0.0, 0.0}
    '    End Try
    'End Function
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