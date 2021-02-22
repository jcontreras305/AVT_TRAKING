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
            mtdJobs.consultaWO(jobNum, tablasDeTareas)
        End If
        Return flag
    End Function

    Private Function cargarDatosProjecto(ByVal jobNum As String, ByVal WO As String, ByVal tk As String) As Boolean
        Dim flag As Boolean = llenarCampos(mtdJobs.cargarDatosProjectOrder(jobNum)) 'aqui puedo tomar los datos de idCliente , WO y PO
        mtdJobs.buscarHorasPorProjecto(tblHoursWorkedProject, WO, tk)
        mtdJobs.buscarExpencesPorProyecto(tblExpencesProjects, WO, tk)
        mtdJobs.buscarMaterialesPorProyecto(tblMaterialProjects, WO, tk)
        lblWorkOrder.Text = WorkOrder + " " + task
        If flag Then
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
            If index = contRow Then
                index = 0
                cargarDatosProjecto(tablasDeTareas.Rows(index).Item(0), tablasDeTareas.Rows(index).Item(2), tablasDeTareas.Rows(index).Item(3))
            Else
                index += 1
                cargarDatosProjecto(tablasDeTareas.Rows(index).ItemArray(0), tablasDeTareas.Rows(index).ItemArray(2), tablasDeTareas.Rows(index).ItemArray(3))
            End If
        End If
    End Sub

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

    Private Sub txtClientPO_Leave(sender As Object, e As EventArgs) Handles txtClientPO.Leave
        If txtClientPO.Text.Length >= 8 Then
            mtdJobs.updatePO(txtClientPO.Text, pjt.idPO.ToString())
        Else
            MessageBox.Show("The PO needs like a minum 8 numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub
    Private Sub txtClientPO_GotFocus(sender As Object, e As EventArgs) Handles txtClientPO.GotFocus
        pjt.idPO = CInt(txtClientPO.Text)
    End Sub




End Class