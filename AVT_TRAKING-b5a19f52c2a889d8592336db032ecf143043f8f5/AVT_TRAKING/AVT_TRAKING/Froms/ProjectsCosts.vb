Public Class ProjectsCosts
    Dim mtdJobs As New MetodosJobs
    Dim mtdOthers As New MetodosOthers
    Dim mtdEmpleados As New MetodosEmployees
    Public idCliente, WorkOrder, task, JobNumber, PO As String
    Dim idsEmployessManager As List(Of String)
    Dim lstProject As List(Of String)
    Private tablasDeTareas As New DataTable 'ESTA TABLA GUARDO TODOS LOS PO CON EL WO Y TASK PARA CORRER ENETRE POYECTOS

    Dim pjt As New Project
    Dim pjtNuevo As New Project
    '|requerimientos: cargar datos de cmbs, idCliente obligatorio, cargar desde cero las tablas 
    '|caso 1: entra crear uno nuevo pero ocupo el idCliente para cargar todo
    '|caso 2: entra con un projecto en especifico
    '|caso 3: puedo cambiar adentro el jobNumber con el cmb 
    '|
    Private Sub ProjectsCosts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mtdOthers.llenarCmbExpCodes(cmbExpCode) 'lleno el combo de expCOde
        idsEmployessManager = mtdEmpleados.llenarCmbEmpleadosManager(cmbProjectManager) 'lleno el como de empleado Manger y car
        lblWorkOrder.Text = WorkOrder '
        txtWokOrder.Text = WorkOrder
        mtdJobs.llenarComboJob(cmbJobNumber, idCliente)
        'aqui se consulta y se cargan los datos en la interfaz
        mtdJobs.consultaWO(JobNumber, tablasDeTareas)
        If Not cargarDatosProjecto(JobNumber) Then
            activarCampos(False)
        End If
        txtClientName.Enabled = False
        dtpBeginDate.CustomFormat = "MM/dd/yyyy"
        dtpEndDate.CustomFormat = "MM/dd/yyyy"
        flagAddRecord = False
    End Sub

    Private Function cargarDatosProjecto(ByVal jobNum As String) As Boolean
        Dim flag As Boolean = llenarCampos(mtdJobs.cargarDatosProjectOrder(jobNum)) 'aqui puedo tomar los datos de idCliente , WO y PO
        mtdJobs.buscarHorasPorProjecto(tblHoursWorkedProject, WorkOrder, task)
        mtdJobs.buscarExpencesPorProyecto(tblExpencesProjects, WorkOrder, task)
        mtdJobs.buscarMaterialesPorProyecto(tblMaterialProjects, WorkOrder, task)
        cmbJobNumber.SelectedIndex = cmbJobNumber.FindString(jobNum)
        lblWorkOrder.Text = WorkOrder + " " + task
        If flag Then
            If tablasDeTareas.Rows.Count <> 0 Then
                tablasDeTareas.Rows.Clear()
            End If
            mtdJobs.consultaWO(jobNum, tablasDeTareas)
        End If
        Return flag
    End Function

    Private Function cargarDatosProjecto(ByVal jobNum As String, ByVal WO As String, ByVal tk As String) As Boolean
        Dim flag As Boolean = llenarCampos(mtdJobs.cargarDatosProjectOrder(jobNum, tk)) 'aqui puedo tomar los datos de idCliente , WO y PO
        mtdJobs.buscarHorasPorProjecto(tblHoursWorkedProject, WO, tk)
        mtdJobs.buscarExpencesPorProyecto(tblExpencesProjects, WO, tk)
        mtdJobs.buscarMaterialesPorProyecto(tblMaterialProjects, WO, tk)
        lblWorkOrder.Text = WorkOrder + " " + task
        If flag Then
            If tablasDeTareas.Rows.Count <> 0 Then
                tablasDeTareas.Rows.Clear()
            End If
            mtdJobs.consultaWO(jobNum, tablasDeTareas)
        End If
        Return flag
    End Function

    Private Sub btnNextTask_Click(sender As Object, e As EventArgs) Handles btnNextTask.Click
        If tablasDeTareas.Rows.Count > 1 Then
            Dim contRow As Integer = tablasDeTareas.Rows.Count
            Dim index As Integer = 0
            For Each row As DataRow In tablasDeTareas.Rows
                If row.ItemArray(3) <> task Then
                    index = index + 1
                Else
                    Exit For
                End If
            Next
            If index = contRow - 1 Then
                index = 0
                cargarDatosProjecto(tablasDeTareas.Rows(index).ItemArray(0), tablasDeTareas.Rows(index).ItemArray(2), tablasDeTareas.Rows(index).ItemArray(3))
            Else
                index += 1
                cargarDatosProjecto(tablasDeTareas.Rows(index).ItemArray(0), tablasDeTareas.Rows(index).ItemArray(2), tablasDeTareas.Rows(index).ItemArray(3))
            End If
        End If
    End Sub

    Private Sub btnAfterTask_Click(sender As Object, e As EventArgs) Handles btnAfterTask.Click
        If tablasDeTareas.Rows.Count > 1 Then
            Dim contRow As Integer = tablasDeTareas.Rows.Count
            Dim index As Integer = 0
            For Each row As DataRow In tablasDeTareas.Rows
                If row.ItemArray(3) <> task Then
                    index = index + 1
                Else
                    Exit For
                End If
            Next
            If index = 0 Then
                index = contRow - 1
                cargarDatosProjecto(tablasDeTareas.Rows(index).ItemArray(0), tablasDeTareas.Rows(index).ItemArray(2), tablasDeTareas.Rows(index).ItemArray(3))

            Else
                index -= 1
                cargarDatosProjecto(tablasDeTareas.Rows(index).ItemArray(0), tablasDeTareas.Rows(index).ItemArray(2), tablasDeTareas.Rows(index).ItemArray(3))
            End If
        End If
    End Sub

    Private Sub btnAddRecord_Click(sender As Object, e As EventArgs) Handles btnAddRecord.Click
        If btnAddRecord.Text = "Add Record" Then
            btnAddRecord.Text = "Save Record"
            limpiarCampos()
            activarCampos(True)
            chbComplete.Checked = False
            flagAddRecord = True
            pjtNuevo.clear()
            pjtNuevo.idWorkOrder = txtWokOrder.Text
            pjtNuevo.jobNum = cmbJobNumber.SelectedItem
            dtpBeginDate.Value = pjtNuevo.beginDate
            dtpEndDate.Value = pjtNuevo.endDate
            lblWorkOrder.Text = ""
        Else
            If mtdJobs.insertarNuevaTarea(pjtNuevo) Then
                MsgBox("Successful")
                btnAddRecord.Text = "Add Record"
                flagAddRecord = False
                mtdJobs.consultaWO(JobNumber, tablasDeTareas)
                If Not cargarDatosProjecto(JobNumber) Then
                    activarCampos(False)
                End If
            Else
                MsgBox("Error, chek the Data or try again")
                btnAddRecord.Text = "Save Record"
                flagAddRecord = True
            End If
        End If
    End Sub

    Private Function limpiarCampos() As Boolean
        'txtWokOrder.Text = ""
        txtTask.Text = ""
        txtProjectDescription.Text = ""
        txtEquipament.Text = ""
        txtAcountNo.Text = ""
        txtClientPO.Text = ""
        cmbExpCode.SelectedIndex = 0
        cmbProjectManager.Text = ""
        cmbProjectManager.SelectedIndex = Nothing
        sprHoursEstimate.Value = 0
        sprTotalBilling.Value = 0
        Return True
    End Function
    Private Function llenarCampos(ByVal lstDatosPO As List(Of String)) As Boolean
        If lstDatosPO.Count > 0 And Not lstDatosPO Is Nothing Then
            txtClientName.Text = lstDatosPO(0)
            txtWokOrder.Text = If(txtWokOrder.Text = "", lstDatosPO(1), txtWokOrder.Text)
            txtTask.Text = lstDatosPO(2)
            WorkOrder = lstDatosPO(1)
            task = lstDatosPO(2)
            txtEquipament.Text = lstDatosPO(3)
            cmbProjectManager.Text = lstDatosPO(4)
            If lstDatosPO(4) <> "" Then
                cmbProjectManager.SelectedIndex = cmbProjectManager.FindString(lstDatosPO(4))
            Else
                cmbProjectManager.SelectedIndex = -1
            End If
            txtClientPO.Text = lstDatosPO(5)
            PO = lstDatosPO(5)
            txtProjectDescription.Text = lstDatosPO(6)
            sprTotalBilling.Value = lstDatosPO(7)
            dtpBeginDate.Value = lstDatosPO(8)
            dtpEndDate.Value = lstDatosPO(9)

            sprHoursEstimate.Value = lstDatosPO(10)
            'cmbExpCode.Text = lstDatosPO(10)
            cmbExpCode.SelectedIndex = cmbExpCode.FindString(lstDatosPO(11))
            txtAcountNo.Text = lstDatosPO(12)

            If lstDatosPO(13) = "1" Then
                chbComplete.Checked = True
            Else
                chbComplete.Checked = False
            End If
            'cmbJobNumber.SelectedIndex = cmbJobNumber.FindString(JobNumber.ToString())
            'AQUI SE CARGARAN LOS DATOS A LA CLASE DE PROJECT 
            pjt.idPO = txtClientPO.Text
            pjt.equipament = txtEquipament.Text
            pjt.manager = cmbProjectManager.Text
            pjt.estimateHour = sprHoursEstimate.Value
            pjt.beginDate = dtpBeginDate.Value
            pjt.endDate = dtpBeginDate.Value
            Dim datos() As String = cmbExpCode.Text.Split(" ")
            pjt.expCode = datos(0)
            pjt.accountNum = txtAcountNo.Text
            pjt.estimateHour = CInt(sprHoursEstimate.Value)
            pjt.status = If(chbComplete.Checked, "1", "0")
            pjt.jobNum = JobNumber
            pjt.idTask = If(task = "", 0, CInt(task))
            pjt.idWorkOrder = WorkOrder
            pjt.idAux = lstDatosPO(14)
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub cmbJobNumber_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbJobNumber.SelectedIndexChanged
        If flagAddRecord Then
            If cmbJobNumber.SelectedItem.ToString() <> "" Then
                pjtNuevo.jobNum = cmbJobNumber.Text
                mtdJobs.consultaWO(pjtNuevo.jobNum, tablasDeTareas)
            End If
        Else
            JobNumber = cmbJobNumber.SelectedItem
            cargarDatosProjecto(JobNumber)
            mtdJobs.consultaWO(JobNumber, tablasDeTareas)
        End If
    End Sub



    '==========================================================================================================================================
    '====================== METODOS PARA ACUTALIZAR AL MOMENTO DE PERDER EL FOCO ==============================================================
    '==========================================================================================================================================
    Dim flagAddRecord As Boolean
    '================ COMPLETE WORKoRDER =====================================================================================
    '=========================================================================================================================
    Private Sub txtTask_Leave(sender As Object, e As EventArgs) Handles txtTask.Leave
        If flagAddRecord Then
            If validarTask() Then
                If pjtNuevo.idTask <> CInt(txtTask.Text) Then
                    pjtNuevo.idTask = CInt(txtTask.Text)
                End If
            Else
                    txtTask.Text = ""
            End If
        Else
            If validarTask() Then
                Dim cont As Int16 = 0
                For Each row As DataRow In tablasDeTareas.Rows
                    If task = row.ItemArray(3) And WorkOrder = row.ItemArray(2) Then
                        Exit For
                    Else
                        cont += 1
                    End If
                Next
                If mtdJobs.updateTask(txtTask.Text, pjt.idAux) Then
                    task = CInt(txtTask.Text)
                    lblWorkOrder.Text = WorkOrder + " " + task
                    mtdJobs.consultaWO(JobNumber, tablasDeTareas)
                Else
                    txtTask.Text = pjt.idTask
                End If
            Else
                txtTask.Text = pjt.idTask
            End If
        End If
    End Sub

    Private Sub txtTask_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTask.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If flagAddRecord Then
                If validarTask() Then
                    pjtNuevo.idTask = CInt(txtTask.Text)
                Else
                    txtTask.Text = ""
                End If
            Else
                If validarTask() Then
                    Dim cont As Int16 = 0
                    For Each row As DataRow In tablasDeTareas.Rows
                        If task = row.ItemArray(3) And WorkOrder = row.ItemArray(2) Then
                            Exit For
                        Else
                            cont += 1
                        End If
                    Next
                    If mtdJobs.updateTask(txtTask.Text, pjt.idAux) Then
                        task = CInt(txtTask.Text)
                        lblWorkOrder.Text = WorkOrder + " " + task
                        mtdJobs.consultaWO(JobNumber, tablasDeTareas)
                    Else
                        txtTask.Text = pjt.idTask
                    End If
                Else
                    txtTask.Text = pjt.idTask
                End If
            End If
        ElseIf Not IsNumeric(Asc(e.KeyChar)) Then
            e.Handled = False
        End If
    End Sub

    Public Function validarTask() As Boolean
        If txtTask.Text.Length >= 4 And txtTask.Text.Length <= 6 Then
            If soloNumero(txtTask.Text) Then
                Dim flagTask As Boolean = True
                For Each row As DataRow In tablasDeTareas.Rows
                    If txtTask.Text = row.ItemArray(3).ToString Then
                        flagTask = False
                    End If
                Next
                Return flagTask
            Else
                Return False
            End If
        ElseIf txtTask.Text = "" Then
            Return True
        Else
            If txtTask.Text.Length < 4 Then
                MessageBox.Show("The parameter 'Task' only admit numbers that have 4 to 6 digits.", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
                Return False
            ElseIf txtTask.Text.Length > 6 Then
                MessageBox.Show("The parameter 'Task' only admit numbers that have 4 to 6 digits.", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
                Return False
            ElseIf Not soloNumero(txtTask.Text) Then
                MessageBox.Show("The parameter 'Task' only admit digits.", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
                Return False
            Else
                Return False
            End If
        End If
    End Function


    '================ COMPLETE WORKoRDER =====================================================================================
    '=========================================================================================================================

    Private Sub txtWokOrder_Leave(sender As Object, e As EventArgs) Handles txtWokOrder.Leave
        If flagAddRecord Then
            If txtWokOrder.Text <> pjtNuevo.idWorkOrder Then
                txtWokOrder.Text = pjtNuevo.idWorkOrder
            End If
        Else
            If txtWokOrder.Text <> WorkOrder Then
                txtWokOrder.Text = WorkOrder
            End If
        End If
    End Sub

    Private Sub txtWokOrder_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtWokOrder.KeyPress
        If Asc(e.KeyChar()) = Keys.Enter Then
            If flagAddRecord Then
                If validarWO() Then
                    pjtNuevo.idWorkOrder = txtWokOrder.Text
                    lblWorkOrder.Text = txtWokOrder.Text + " " + txtTask.Text
                Else
                    txtWokOrder.Text = pjtNuevo.idWorkOrder
                    lblWorkOrder.Text = txtWokOrder.Text + " " + txtTask.Text
                End If
            Else
                If validarWO() Then
                    If mtdJobs.updateWorkOrder(txtWokOrder.Text, WorkOrder, pjt.idPO, pjt.jobNum) Then
                        lblWorkOrder.Text = txtWokOrder.Text + " " + txtTask.Text
                        WorkOrder = txtWokOrder.Text
                        tablasDeTareas.Clear()
                        mtdJobs.consultaWO(JobNumber, tablasDeTareas)
                    Else
                        txtWokOrder.Text = WorkOrder
                        lblWorkOrder.Text = txtWokOrder.Text + " " + txtTask.Text
                    End If
                End If
            End If
        ElseIf Not IsNumeric(Asc(e.KeyChar)) Then
            e.Handled = False
        End If
    End Sub

    Private Function validarWO() As Boolean
        If txtWokOrder.Text.Length >= 4 Then
            If soloNumero(txtWokOrder.Text) Then
                Return True
            Else
                MessageBox.Show("The parameter 'WorkOrder' only accept numers.'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        Else
            MessageBox.Show("The parameter 'WorkOrder' accept like minium 4 numers.'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
    End Function


    '================ CLIENT PO ==============================================================================================
    '=========================================================================================================================

    Private Sub txtClientPO_Leave(sender As Object, e As EventArgs) Handles txtClientPO.Leave
        If flagAddRecord Then
            If txtClientPO.Text <> pjtNuevo.idPO Then
                txtClientPO.Text = pjtNuevo.idPO
            End If
        Else
            If txtClientPO.Text <> pjt.idPO Then
                txtClientPO.Text = pjt.idPO
            End If
        End If
    End Sub
    Function validarClientPO() As Boolean
        If flagAddRecord Then
            If txtClientPO.Text.Length >= 5 And soloNumero(txtClientPO.Text) Then
                If mtdJobs.existPO(txtClientPO.Text, cmbJobNumber.SelectedItem) = True Then
                    If DialogResult.Yes = MessageBox.Show("Are you sure to use this PO.", "important", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) Then
                        Return True
                    Else
                        Return False
                    End If
                Else
                    Return True
                End If
            Else
                MessageBox.Show("The 'PO' needs like a minum 5 numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
        Else
            If txtClientPO.Text.Length >= 5 And soloNumero(txtClientPO.Text) Then
                If mtdJobs.existPO(txtClientPO.Text, pjt.jobNum) = True Then
                    MessageBox.Show("Is probably that the PO exist, try with other number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                Else
                    Return True
                End If
            Else
                MessageBox.Show("The 'PO' needs like a minum 8 numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
        End If
    End Function
    Private Sub txtClientPO_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtClientPO.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If validarClientPO() Then
                If flagAddRecord Then
                    pjtNuevo.idPO = txtClientPO.Text
                    txtProjectDescription.Focus()
                Else
                    If mtdJobs.updatePO(txtClientPO.Text, pjt.idPO, pjt.jobNum) Then
                        pjt.idPO = txtClientPO.Text
                    Else
                        txtClientPO.Text = pjt.idPO
                    End If
                End If
            Else
                If flagAddRecord Then
                    txtClientPO.Text = pjtNuevo.idPO
                Else
                    txtClientPO.Text = pjt.idPO
                End If
            End If
        End If
    End Sub

    '================ EQUIPAMENT =============================================================================================
    '=========================================================================================================================
    Private Sub txtEquipament_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEquipament.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If flagAddRecord Then
                If validarEquipament() Then
                    pjtNuevo.equipament = txtEquipament.Text
                Else
                    txtEquipament.Text = pjtNuevo.equipament
                End If
            Else
                If validarEquipament() Then
                    If mtdJobs.updateEquipaMent(txtEquipament.Text, pjt.idAux, pjt.idWorkOrder) Then
                        pjt.equipament = txtEquipament.Text
                    Else
                        txtEquipament.Text = pjt.equipament
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub txtEquipament_Leave(sender As Object, e As EventArgs) Handles txtEquipament.Leave
        If flagAddRecord Then
            If txtEquipament.Text <> pjtNuevo.equipament Then
                txtEquipament.Text = pjtNuevo.equipament
            End If
        Else
            If txtEquipament.Text <> pjt.equipament Then
                txtEquipament.Text = pjt.equipament
            End If
        End If
    End Sub

    Private Function validarEquipament() As Boolean
        If flagAddRecord Then
            If txtEquipament.Text.Length <= 30 Then
                Return True
            Else
                MessageBox.Show("The parameter 'equipment' only permit a maximum of 30 characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
        Else
            If txtEquipament.Text.Length <= 30 Then
                Return True
            Else
                MessageBox.Show("The parameter 'equipment' only permit a maximum of 30 characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
        End If
    End Function

    '================ MANAGER ================================================================================================
    '=========================================================================================================================

    Private Sub cmbProjectManager_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbProjectManager.SelectionChangeCommitted
        If flagAddRecord Then
            If cmbProjectManager.SelectedItem <> pjtNuevo.manager Then
                pjtNuevo.manager = cmbProjectManager.SelectedItem
            End If
        Else
            If cmbProjectManager.SelectedItem <> pjt.manager Then
                If flagAddRecord Then
                    flagManger = "Selection"
                    If validarManager() Then
                        pjtNuevo.manager = cmbProjectManager.SelectedItem
                    Else
                        cmbProjectManager.SelectedIndex = cmbProjectManager.FindString(pjt.manager)
                        cmbProjectManager.Text = pjt.manager
                    End If
                Else
                    flagManger = "Selection"
                    If validarManager() Then
                        If mtdJobs.updateManeger(cmbProjectManager.SelectedItem, pjt.idAux, pjt.idWorkOrder) Then
                            pjt.manager = cmbProjectManager.SelectedItem
                        Else
                            cmbProjectManager.SelectedIndex = cmbProjectManager.FindString(pjt.manager)
                            cmbProjectManager.Text = pjt.manager
                        End If
                    Else
                        cmbProjectManager.SelectedIndex = cmbProjectManager.FindString(pjt.manager)
                        cmbProjectManager.Text = pjt.manager
                    End If
                End If
            End If
        End If '

    End Sub

    Private Function validarManager() As Boolean
        If flagManger = "Enter" And cmbProjectManager.Text = "" Then
            If DialogResult.Yes = MessageBox.Show("Are you sure to save None like a Manager?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                Return True
            Else
                Return False
            End If
        Else
            If cmbProjectManager.SelectedItem <> "" Then
                Return True
            Else
                Return False
            End If
        End If
    End Function

    Dim flagManger As String 'esta se usa para validar si hizo enter para ingresar
    Private Sub cmbProjectManager_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbProjectManager.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If flagAddRecord Then
                If cmbProjectManager.Text <> pjtNuevo.manager Then
                    flagManger = "Enter"
                    If validarManager() Then
                        pjtNuevo.manager = If(cmbProjectManager.SelectedItem = Nothing, "", cmbProjectManager.SelectedItem)
                    Else
                        cmbProjectManager.SelectedIndex = cmbProjectManager.FindString(pjtNuevo.manager)
                        cmbProjectManager.Text = pjtNuevo.manager
                    End If
                End If
            Else
                If cmbProjectManager.Text <> pjt.manager Then
                    flagManger = "Enter"
                    If validarManager() Then
                        If mtdJobs.updateManeger(cmbProjectManager.SelectedItem, pjt.idAux, pjt.idWorkOrder) Then
                            pjt.manager = If(cmbProjectManager.SelectedItem = Nothing, "", cmbProjectManager.SelectedItem)
                        Else
                            cmbProjectManager.SelectedIndex = cmbProjectManager.FindString(pjt.manager)
                            cmbProjectManager.Text = pjt.manager
                        End If
                    Else
                        cmbProjectManager.SelectedIndex = cmbProjectManager.FindString(pjt.manager)
                        cmbProjectManager.Text = pjt.manager
                    End If
                End If
            End If
        End If
    End Sub

    '================ DESCRIPTION ============================================================================================
    '=========================================================================================================================

    Private Sub txtProjectDescription_Leave(sender As Object, e As EventArgs) Handles txtProjectDescription.Leave
        If txtProjectDescription.Text <> pjt.description Then
            If validarDescription() Then
                If flagAddRecord Then
                    pjtNuevo.description = txtProjectDescription.Text
                Else
                    If mtdJobs.updateDescription(txtProjectDescription.Text, pjt.idAux, pjt.idWorkOrder) Then
                        pjt.description = txtProjectDescription.Text
                    Else
                        txtProjectDescription.Text = pjt.description
                    End If
                End If
            Else
                If flagAddRecord Then
                    txtProjectDescription.Text = pjtNuevo.description
                Else
                    txtProjectDescription.Text = pjt.description
                End If
            End If
        End If
    End Sub

    Private Sub txtProjectDescription_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtProjectDescription.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If txtProjectDescription.Text <> pjt.description Then
                If validarDescription() Then
                    If flagAddRecord Then
                        pjtNuevo.description = txtProjectDescription.Text
                    Else
                        pjt.description = txtProjectDescription.Text
                    End If
                Else
                    If flagAddRecord Then
                        txtProjectDescription.Text = pjtNuevo.description
                    Else
                        txtProjectDescription.Text = pjt.description
                    End If
                End If
            End If
        End If
    End Sub

    Private Function validarDescription() As Boolean
        If txtProjectDescription.Text.Length <= 100 Then
            Return True
        Else
            MessageBox.Show("The parameter 'Description' only permit an maximium of 100 caracters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
    End Function

    '================ TOTAL BILLING ==========================================================================================
    '=========================================================================================================================

    Private Sub sprTotalBilling_Leave(sender As Object, e As EventArgs) Handles sprTotalBilling.Leave
        If flagAddRecord Then
            If sprTotalBilling.Value <> pjtNuevo.totalBilling Then
                sprTotalBilling.Value = pjtNuevo.totalBilling
            End If
        Else
            If sprTotalBilling.Value <> pjt.totalBilling Then
                sprTotalBilling.Value = pjt.totalBilling
            End If
        End If
    End Sub

    Private Function validarTotalBilling() As Boolean
        If sprTotalBilling.Value > 0 Then
            Return True
        Else
            If DialogResult.Yes = MessageBox.Show("Do you want to assign 0.00 Dollar's?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) Then
                Return True
            Else
                Return False
            End If
        End If
    End Function

    Private Sub sprTotalBilling_KeyPress(sender As Object, e As KeyPressEventArgs) Handles sprTotalBilling.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If flagAddRecord Then
                If validarTotalBilling() Then
                    pjtNuevo.totalBilling = sprTotalBilling.Value
                Else
                    sprTotalBilling.Value = pjtNuevo.totalBilling
                End If
            Else
                If validarTotalBilling() Then
                    If mtdJobs.updateTotalBilling(sprTotalBilling.Value, pjt.idAux, pjt.idWorkOrder) Then
                        pjt.totalBilling = sprTotalBilling.Value
                    Else
                        sprTotalBilling.Value = pjt.totalBilling
                    End If
                Else
                    sprTotalBilling.Value = pjt.totalBilling
                End If
            End If
        End If
    End Sub

    '================ HOURS ESTIMATE =========================================================================================
    '=========================================================================================================================
    Private Sub sprHoursEstimate_KeyPress(sender As Object, e As KeyPressEventArgs) Handles sprHoursEstimate.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If flagAddRecord Then
                If validarHours() Then
                    pjtNuevo.estimateHour = sprHoursEstimate.Value
                Else
                    sprHoursEstimate.Value = pjtNuevo.estimateHour
                End If
            Else
                If validarHours() Then
                    pjt.estimateHour = sprHoursEstimate.Value
                Else
                    sprHoursEstimate.Value = pjt.estimateHour
                End If
            End If
        End If
    End Sub

    Private Function validarHours() As Boolean
        If sprHoursEstimate.Value > 0 Then
            If flagAddRecord Then
                Return True
            Else
                If mtdJobs.updateHoursEstimate(sprHoursEstimate.Value, pjt.idAux, pjt.idWorkOrder) Then
                    Return True
                Else
                    Return False
                End If
            End If
        Else
            If DialogResult.Yes = MessageBox.Show("Do you like to assign 0.0 hours stimate?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) Then
                Return False
            Else
                Return False
            End If
        End If
    End Function

    Private Sub sprHoursEstimate_Leave(sender As Object, e As EventArgs) Handles sprHoursEstimate.Leave
        If flagAddRecord Then
            If sprHoursEstimate.Value <> pjtNuevo.estimateHour Then
                sprHoursEstimate.Value = pjtNuevo.estimateHour
            End If
        Else
            If sprHoursEstimate.Value <> pjt.estimateHour Then
                sprHoursEstimate.Value = pjt.estimateHour
            End If
        End If
    End Sub

    '================ BEGIN DATE =============================================================================================
    '=========================================================================================================================

    Private Function validarBeginDate() As Boolean
        Dim fechaActual As Date = System.DateTime.Today
        If dtpBeginDate.Value >= fechaActual Then
            Return True
        Else
            If DialogResult.Yes = MessageBox.Show("The selected date is before the current date, Are you sure to contienue?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) Then
                Return True
            Else
                Return False
            End If
        End If
    End Function

    Private Sub dtpBeginDate_Leave(sender As Object, e As EventArgs) Handles dtpBeginDate.Leave
        If flagAddRecord Then
            If pjtNuevo.beginDate <> dtpBeginDate.Value Then
                If validarBeginDate() Then
                    pjt.beginDate = dtpBeginDate.Value
                Else
                    dtpBeginDate.Value = pjtNuevo.beginDate
                End If
            End If
        Else
            If validarBeginDate() Then
                If mtdJobs.updateBeginDate(dtpBeginDate.Value, pjt.idAux, pjt.idWorkOrder) Then
                    pjt.beginDate = dtpBeginDate.Value
                Else
                    dtpBeginDate.Value = pjt.beginDate
                End If
            Else
                dtpBeginDate.Value = pjt.beginDate
            End If
        End If
    End Sub

    Private Sub dtpBeginDate_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtpBeginDate.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If flagAddRecord Then
                If validarBeginDate() Then
                    pjtNuevo.beginDate = dtpBeginDate.Value
                Else
                    dtpBeginDate.Value = pjtNuevo.beginDate
                End If
            Else
                If validarBeginDate() Then
                    If mtdJobs.updateBeginDate(dtpBeginDate.Value, pjt.idAux, pjt.idWorkOrder) Then
                        pjt.beginDate = dtpBeginDate.Value
                    Else
                        dtpBeginDate.Value = pjt.beginDate
                    End If
                Else
                    dtpBeginDate.Value = pjt.beginDate
                End If
            End If

        End If
    End Sub


    '================ END DATE ===============================================================================================
    '=========================================================================================================================

    Private Function validarEndDate() As Boolean
        Dim fechaActual As Date = System.DateTime.Today
        If dtpEndDate.Value > If(flagAddRecord, pjtNuevo.beginDate, pjt.beginDate) Then
            Return True
        Else
            If DialogResult.Yes = MessageBox.Show("The selected date is before the 'Begin Date', Are you sure to contienue?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) Then
                Return True
            Else
                Return False
            End If
        End If
    End Function

    Private Sub dtpEndDate_Leave(sender As Object, e As EventArgs) Handles dtpEndDate.Leave
        If flagAddRecord Then
            If pjtNuevo.endDate <> dtpEndDate.Value Then
                If validarEndDate() Then
                    pjtNuevo.beginDate = dtpEndDate.Value
                Else
                    dtpEndDate.Value = pjtNuevo.endDate
                End If
            End If
        Else
            If validarEndDate() Then
                If mtdJobs.updateEndDate(dtpEndDate.Value, pjt.idAux, pjt.idWorkOrder) Then
                    pjt.beginDate = dtpEndDate.Value
                Else
                    dtpEndDate.Value = pjt.endDate
                End If
            Else
                dtpEndDate.Value = pjt.endDate
            End If
        End If
    End Sub

    Private Sub dtpEndDate_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtpEndDate.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If flagAddRecord Then
                If validarEndDate() Then
                    pjtNuevo.endDate = dtpEndDate.Value
                Else
                    dtpEndDate.Value = pjtNuevo.endDate
                End If
            Else
                If validarEndDate() Then
                    If mtdJobs.updateEndDate(dtpEndDate.Value, pjt.idAux, pjt.idWorkOrder) Then
                        pjt.endDate = dtpEndDate.Value
                    Else
                        dtpEndDate.Value = pjt.endDate
                    End If
                Else
                    dtpEndDate.Value = pjt.endDate
                End If
            End If
        End If
    End Sub


    '================ Exp Code ===============================================================================================
    '=========================================================================================================================

    Private Sub cmbExpCode_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbExpCode.SelectionChangeCommitted
        If flagAddRecord Then
            If ValidarExpCode() Then
                pjtNuevo.expCode = cmbExpCode.SelectedItem
            Else
                cmbExpCode.SelectedItem = If(pjtNuevo.expCode = "", cmbExpCode.Items(0), pjtNuevo.expCode)
            End If
        Else
            If ValidarExpCode() Then
                If mtdJobs.updateExxpCode(cmbExpCode.SelectedItem, pjt.idAux, pjt.idWorkOrder) Then

                    pjt.expCode = cmbExpCode.SelectedItem
                Else
                    cmbExpCode.SelectedItem = pjt.expCode
                End If
            Else
                cmbExpCode.SelectedItem = pjt.expCode
            End If
        End If
    End Sub
    Private Function ValidarExpCode() As Boolean
        If cmbExpCode.SelectedItem <> "" Then
            Return True
        Else
            Return False
        End If
    End Function

    '================ ACCOUNT NUM ============================================================================================
    '=========================================================================================================================

    Private Function validarAccountNO() As Boolean
        If txtAcountNo.Text.Length = 0 Then
            If DialogResult.Yes = MessageBox.Show("The parameter 'Account' don't detected enyone value, Do you want to save a 'Null' value?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) Then
                Return True
            Else
                Return False
            End If
        Else
            Return True
        End If
    End Function

    Private Sub txtAcountNo_Leave(sender As Object, e As EventArgs) Handles txtAcountNo.Leave
        If flagAddRecord Then
            If txtAcountNo.Text <> pjtNuevo.accountNum Then
                txtAcountNo.Text = pjtNuevo.accountNum
            End If
        Else
            If txtAcountNo.Text <> pjt.accountNum Then
                txtAcountNo.Text = pjt.accountNum
            End If
        End If
    End Sub

    Private Sub txtAccount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAcountNo.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If flagAddRecord Then
                If txtAcountNo.Text <> pjt.accountNum Then
                    If validarAccountNO() Then
                        pjtNuevo.accountNum = txtAcountNo.Text
                    Else
                        txtAcountNo.Text = pjtNuevo.accountNum
                    End If
                End If
            Else
                If txtAcountNo.Text <> pjt.accountNum Then
                    If validarAccountNO() Then
                        If mtdJobs.updateAccont(txtAcountNo.Text, pjt.idAux, pjt.idWorkOrder) Then
                            pjt.accountNum = txtAcountNo.Text
                        Else
                            txtAcountNo.Text = pjt.accountNum
                        End If
                    Else
                        txtAcountNo.Text = pjt.accountNum
                    End If
                End If
            End If
        ElseIf Not IsNumeric(Asc(e.KeyChar)) Then
            e.Handled = False
        End If
    End Sub

    '================ COMPLETE CHECK =========================================================================================
    '=========================================================================================================================


    Private Sub chbComplete_CheckedChanged(sender As Object, e As EventArgs) Handles chbComplete.CheckedChanged
        If chbComplete.Checked Then
            If flagAddRecord Then
                pjtNuevo.status = "1"
            Else
                If mtdJobs.updateComplete(If(chbComplete.Checked, True, False), pjt.idAux, pjt.idWorkOrder) Then
                    activarCampos(True)
                    pjt.status = "1"
                Else
                    chbComplete.Checked = False
                    pjt.status = "0"
                    activarCampos(True)
                End If
            End If
        Else
            If flagAddRecord Then
                pjtNuevo.status = "0"
            Else
                If mtdJobs.updateComplete(If(chbComplete.Checked, True, False), pjt.idAux, pjt.idWorkOrder) Then
                    activarCampos(False)
                    pjt.status = "0"
                Else
                    chbComplete.Checked = False
                    pjt.status = "1"
                    activarCampos(True)
                End If
            End If
        End If
    End Sub

    Private Sub activarCampos(ByVal activar As Boolean)
        txtWokOrder.Enabled = activar
        txtTask.Enabled = activar
        txtEquipament.Enabled = activar
        txtClientPO.Enabled = activar
        txtProjectDescription.Enabled = activar
        txtAcountNo.Enabled = activar
        cmbProjectManager.Enabled = activar
        cmbExpCode.Enabled = activar
        sprTotalBilling.Enabled = activar
        sprHoursEstimate.Enabled = activar
        dtpBeginDate.Enabled = activar
        dtpEndDate.Enabled = activar
        tblExpencesProjects.Enabled = activar
        tblMaterialProjects.Enabled = activar
        tblHoursWorkedProject.Enabled = activar
    End Sub


    Private Function calcularValores() As Boolean

        Return 0
    End Function

End Class