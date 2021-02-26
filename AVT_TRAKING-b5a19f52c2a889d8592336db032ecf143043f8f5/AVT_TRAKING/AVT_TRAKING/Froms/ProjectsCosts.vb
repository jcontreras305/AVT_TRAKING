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
            'activarCampos(True)
            chbComplete.Checked = False
            flagAddRecord = True
            pjtNuevo.clear()
            dtpBeginDate.Value = pjtNuevo.beginDate
            dtpEndDate.Value = pjtNuevo.endDate
            lblWorkOrder.Text = ""

        Else
            btnAddRecord.Text = "Add Record"
        End If
    End Sub

    Private Function limpiarCampos() As Boolean
        txtWokOrder.Text = ""
        txtTask.Text = ""
        txtProjectDescription.Text = ""
        txtEquipament.Text = ""
        txtAcountNo.Text = ""
        txtClientPO.Text = ""
        cmbExpCode.SelectedIndex = 0
        cmbJobNumber.Text = ""
        cmbJobNumber.SelectedIndex = Nothing
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
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub cmbJobNumber_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbJobNumber.SelectedIndexChanged
        If flagAddRecord Then
            If cmbJobNumber.SelectedItem <> "" Then
                pjt.jobNum = cmbJobNumber.Text
            End If
        Else
            JobNumber = cmbJobNumber.SelectedItem
            cargarDatosProjecto(JobNumber)
        End If
    End Sub



    '==========================================================================================================================================
    '====================== METODOS PARA ACUTALIZAR AL MOMENTO DE PERDER EL FOCO ==============================================================
    '==========================================================================================================================================
    Dim flagAddRecord As Boolean

    '================ CLIENT PO ==============================================================================================
    '=========================================================================================================================


    Private Sub txtClientPO_MouseClick(sender As Object, e As MouseEventArgs) Handles txtClientPO.MouseClick
        If flagAddRecord Then
            pjtNuevo.idPO = CInt(txtClientPO.Text)
        Else
            pjt.idPO = CInt(txtClientPO.Text)
        End If

    End Sub

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
            If txtClientPO.Text.Length >= 8 Then
                If Not mtdJobs.existPO(txtClientPO.Text, cmbJobNumber.SelectedItem) Then
                    MessageBox.Show("Is probably that the PO exist, try with other number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                Else
                    Return True
                End If
            Else
                MessageBox.Show("The 'PO' needs like a minum 8 numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
        Else
            If txtClientPO.Text.Length >= 8 Then
                If Not mtdJobs.updatePO(txtClientPO.Text, pjt.idPO.ToString(), pjt.jobNum) Then
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
                    pjtNuevo.idPO = CInt(txtClientPO.Text)
                    txtProjectDescription.Focus()
                Else
                    If mtdJobs.updatePO(txtClientPO.Text, pjt.idPO, pjt.jobNum) Then
                        pjt.idPO = CInt(txtClientPO.Text)
                        txtProjectDescription.Focus()
                    Else
                        txtClientPO.Text = CStr(pjt.idPO)
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
                    If mtdJobs.updateEquipaMent(txtEquipament.Text, pjt.idPO, JobNumber) Then
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
                txtEquipament.Text = pjt.equipament
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
                    If mtdJobs.updateManeger(cmbProjectManager.SelectedItem, pjt.idPO, pjt.jobNum) Then
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
                        If mtdJobs.updateManeger(cmbProjectManager.SelectedItem, pjt.idPO, pjt.jobNum) Then
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
            txtProjectDescription.Text = pjt.description
        End If
    End Sub

    Private Sub txtProjectDescription_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtProjectDescription.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If txtProjectDescription.Text <> pjt.description Then
                If validarDescription() Then
                    pjt.description = txtProjectDescription.Text
                Else
                    txtProjectDescription.Text = pjt.description
                End If
            End If
        End If
    End Sub

    Private Function validarDescription() As Boolean
        If txtProjectDescription.Text.Length <= 100 Then
            If mtdJobs.updateDescription(txtProjectDescription.Text, pjt.idPO, pjt.jobNum) Then
                Return True
            Else
                Return False
            End If
        Else
            MessageBox.Show("The parameter 'Description' only permit an maximium of 100 caracters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtProjectDescription.Text = pjt.description
            Return False
        End If
    End Function

    '================ TOTAL BILLING ==========================================================================================
    '=========================================================================================================================

    Private Sub sprTotalBilling_Leave(sender As Object, e As EventArgs) Handles sprTotalBilling.Leave
        If sprTotalBilling.Value > pjt.totalBilling Or sprTotalBilling.Value < pjt.totalBilling Then
            If validarTotalBilling() Then
                pjt.totalBilling = sprTotalBilling.Value
            Else
                sprTotalBilling.Value = pjt.totalBilling
            End If
        End If
    End Sub

    Private Function validarTotalBilling() As Boolean
        If mtdJobs.updateTotalBilling(sprTotalBilling.Value, pjt.idPO, pjt.jobNum) Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub sprTotalBilling_KeyPress(sender As Object, e As KeyPressEventArgs) Handles sprTotalBilling.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If validarTotalBilling() Then
                pjt.totalBilling = sprTotalBilling.Value
            Else
                sprTotalBilling.Value = pjt.totalBilling
            End If
        End If
    End Sub

    '================ HOURS ESTIMATE =========================================================================================
    '=========================================================================================================================
    Private Sub sprHoursEstimate_KeyPress(sender As Object, e As KeyPressEventArgs) Handles sprHoursEstimate.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If validarHours() Then
                pjt.estimateHour = sprHoursEstimate.Value
            Else
                sprHoursEstimate.Value = pjt.estimateHour
            End If
        End If
    End Sub

    Private Function validarHours() As Boolean
        If sprHoursEstimate.Value > 0 Then
            If flagAddRecord Then
                Return True
            Else
                If mtdJobs.updateHoursEstimate(sprHoursEstimate.Value, pjt.idPO, pjt.jobNum) Then
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
        If sprHoursEstimate.Value < pjt.estimateHour Or sprHoursEstimate.Value > pjt.estimateHour Then
            If validarHours() Then
                pjt.estimateHour = sprHoursEstimate.Value
            Else
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
            If validarBeginDate() Then
                pjt.beginDate = dtpBeginDate.Value
            Else
                dtpBeginDate.Value = pjtNuevo.beginDate
            End If
        Else
            If validarBeginDate() Then
                If mtdJobs.updateBeginDate(dtpBeginDate.Value, pjt.idPO, pjt.jobNum) Then
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
            If validarBeginDate() Then
                If mtdJobs.updateBeginDate(dtpBeginDate.Value, pjt.idPO, pjt.jobNum) Then
                    pjt.beginDate = dtpBeginDate.Value
                Else
                    dtpBeginDate.Value = pjt.beginDate
                End If
            Else
                dtpBeginDate.Value = pjt.beginDate
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
            If validarEndDate() Then
                pjtNuevo.beginDate = dtpEndDate.Value
            Else
                dtpEndDate.Value = pjtNuevo.endDate
            End If
        Else
            If validarEndDate() Then
                If mtdJobs.updateEndDate(dtpEndDate.Value, pjt.idPO, pjt.jobNum) Then
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
                    If mtdJobs.updateEndDate(dtpEndDate.Value, pjt.idPO, pjt.jobNum) Then
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

    '================ ACCOUNT NUM ============================================================================================
    '=========================================================================================================================

    Private Function validarAccountNO() As Boolean
        If soloNumero(txtProjectDescription.Text) Then
            If txtAcountNo.Text.Length = 0 Then
                If DialogResult.Yes = MessageBox.Show("The parameter 'Account' don't detected enyone value, Do you want to save a 'Null' value?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return True
            End If
        Else
            If DialogResult.Yes = MessageBox.Show("The parameter 'Account' only permit numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) Then
                Return False
            Else
                Return False
            End If
        End If
    End Function

    Private Sub txtAcountNo_Leave(sender As Object, e As EventArgs) Handles txtAcountNo.Leave
        If txtAcountNo.Text <> pjt.accountNum Then
            If flagAddRecord Then
                txtAcountNo.Text = pjtNuevo.accountNum
            Else
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
                        pjt.accountNum = txtAcountNo.Text
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
            activarCampos(False)
        Else
            activarCampos(true)
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
End Class