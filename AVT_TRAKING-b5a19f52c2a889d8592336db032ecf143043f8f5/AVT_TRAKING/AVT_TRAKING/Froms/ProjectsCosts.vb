Public Class ProjectsCosts
    Dim mtdJobs As New MetodosJobs
    Dim mtdOthers As New MetodosOthers
    Dim mtdEmpleados As New MetodosEmployees
    Public idCliente, WorkOrder, task, JobNumber, PO As String
    Dim idsEmployessManager As List(Of String)
    Dim lstProject As List(Of String)
    Private tablasDeTareas As New DataTable 'ESTA TABLA GUARDO TODOS LOS PO CON EL WO Y TASK PARA CORRER ENETRE POYECTOS

    Dim pjt As New Project
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
        cargarDatosProjecto(JobNumber)
        txtClientName.Enabled = False
    End Sub

    Private Function cargarDatosProjecto(ByVal jobNum As String) As Boolean
        Dim flag As Boolean = llenarCampos(mtdJobs.cargarDatosProjectOrder(jobNum)) 'aqui puedo tomar los datos de idCliente , WO y PO
        mtdJobs.buscarHorasPorProjecto(tblHoursWorkedProject, WorkOrder, task)
        mtdJobs.buscarExpencesPorProyecto(tblExpencesProjects, WorkOrder, task)
        mtdJobs.buscarMaterialesPorProyecto(tblMaterialProjects, WorkOrder, task)
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
        If btnAddRecord.Text = "Add Reccord" Then
            btnAddRecord.Text = "Save Reccord"
            limpiarCampos()
        Else
            btnAddRecord.Text = "Add Reccord"

        End If
    End Sub

    Private Function limpiarCampos() As Boolean
        Me.txtWokOrder.Text = ""
        Me.txtTask.Text = ""
        Me.txtProjectDescription.Text = ""
        Me.txtEquipament.Text = ""
        Me.txtAcountNo.Text = ""
        Me.txtClientPO.Text = ""
        Me.cmbExpCode.SelectedIndex = 0
        Me.cmbJobNumber.Text = ""
        Me.cmbJobNumber.SelectedIndex = Nothing
        Me.cmbProjectManager.Text = ""
        Me.cmbProjectManager.SelectedIndex = Nothing
        Return True
    End Function
    Private Function llenarCampos(ByVal lstDatosPO As List(Of String)) As Boolean
        If lstDatosPO.Count > 0 Then
            txtClientName.Text = lstDatosPO(0)
            txtWokOrder.Text = If(txtWokOrder.Text = "", lstDatosPO(1), txtWokOrder.Text)
            txtTask.Text = lstDatosPO(2)
            WorkOrder = lstDatosPO(1)
            task = lstDatosPO(2)
            txtEquipament.Text = lstDatosPO(3)
            cmbProjectManager.Text = lstDatosPO(4)
            cmbProjectManager.SelectedIndex = cmbProjectManager.FindString(lstDatosPO(4))
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
        JobNumber = cmbJobNumber.Text
        cargarDatosProjecto(JobNumber)
    End Sub



    '==========================================================================================================================================
    '====================== METODOS PARA ACUTALIZAR AL MOMENTO DE PERDER EL FOCO ==============================================================
    '==========================================================================================================================================

    '================ CLIENT PO ==============================================================================================
    '=========================================================================================================================
    Private Sub txtClientPO_GotFocus(sender As Object, e As EventArgs) Handles txtClientPO.GotFocus 'me aseguro de guardar el valor 
        pjt.idPO = CInt(txtClientPO.Text)
    End Sub
    'si el valor no contiene las caracteristicas solo mando mesaje y regreso el valor que estaba de lo contrario lo cambio
    Private Sub txtClientPO_Leave(sender As Object, e As EventArgs) Handles txtClientPO.Leave
        If txtClientPO.Text <> pjt.idPO Then
            validarClientPO()
        End If
    End Sub
    Function validarClientPO() As Boolean
        If txtClientPO.Text.Length >= 8 Then
            If Not mtdJobs.updatePO(txtClientPO.Text, pjt.idPO.ToString(), pjt.jobNum) Then
                MessageBox.Show("Is probably that the PO exist, try with other number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtClientPO.Text = pjt.idPO.ToString
                Return False
            Else
                Return True
            End If
        Else
            MessageBox.Show("The PO needs like a minum 8 numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtClientPO.Text = pjt.idPO.ToString
            Return False
        End If
    End Function
    Private Sub txtClientPO_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtClientPO.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If validarClientPO() Then
                txtProjectDescription.Focus()
            End If
        End If
    End Sub

    '================ EQUIPAMENT ========================================================================================
    '=========================================================================================================================
    Private Sub txtEquipament_KeyUp(sender As Object, e As KeyEventArgs) Handles txtEquipament.KeyUp
        pjt.equipament = txtEquipament.Text
    End Sub

    Private Sub txtEquipament_Leave(sender As Object, e As EventArgs) Handles txtEquipament.Leave
        If txtEquipament.Text <> pjt.equipament Then

        End If
    End Sub

    Private Function validarEquipament() As Boolean
        If txtClientPO.Text.Length > 0 And txtEquipament.Text.Length < 30 Then
            If Not mtdJobs.updatePO(txtClientPO.Text, pjt.idPO.ToString(), pjt.jobNum) Then
                MessageBox.Show("Is probably that the PO exist, try with other number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtClientPO.Text = pjt.idPO.ToString
                Return False
            Else
                Return True
            End If
        Else
            MessageBox.Show("The PO needs like a minum 8 numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtClientPO.Text = pjt.idPO.ToString
            Return False
        End If
    End Function
End Class