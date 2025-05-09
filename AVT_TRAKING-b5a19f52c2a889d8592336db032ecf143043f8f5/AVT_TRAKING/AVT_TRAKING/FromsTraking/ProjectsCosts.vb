﻿Imports System.Runtime.InteropServices
Public Class ProjectsCosts
    Dim mtdJobs As New MetodosJobs
    Dim mtdOthers As New MetodosOthers
    Dim mtdEmpleados As New MetodosEmployees
    Public idCliente, WorkOrder, idAuxWO, task, JobNumber, PO As String
    Dim idsEmployessManager As List(Of String)
    Dim lstProject As List(Of String)
    Public tablasDeTareas As New DataTable 'ESTA TABLA GUARDO TODOS LOS PO CON EL WO Y TASK PARA CORRER ENETRE POYECTOS
    Dim FindElement, Element As String
    Dim pjt As New Project
    Dim pjtNuevo As New Project
    Public flagFindElement As Boolean
    Dim flagBtnNextBackFind As Boolean
    '|requerimientos: cargar datos de cmbs, idCliente obligatorio, cargar desde cero las tablas 
    '|caso 1: entra crear uno nuevo pero ocupo el idCliente para cargar todo
    '|caso 2: entra con un projecto en especifico
    '|caso 3: puedo cambiar adentro el jobNumber con el cmb 
    '|
    Dim _dtpExpenses As New DateTimePicker
    Dim _dtpMaterial As New DateTimePicker

    Dim _rectangulo As New Rectangle

    Private Sub ProjectsCosts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mtdOthers.llenarCmbExpCodes(cmbExpCode) 'lleno el combo de expCOde
        idsEmployessManager = mtdEmpleados.llenarCmbEmpleadosManager(cmbProjectManager) 'lleno el como de empleado Manger y car
        lblWorkOrder.Text = WorkOrder '
        txtWokOrder.Text = WorkOrder
        mtdJobs.llenarComboJob(cmbJobNumber, idCliente)
        'llenarComboJobByUserIDClient(cmbJobNumber, idClient)
        'aqui se consulta y se cargan los datos en la interfaz
        mtdJobs.consultaWO(JobNumber, tablasDeTareas)
        If tablasDeTareas.Rows IsNot Nothing Then
            txtElementsRadar.Text = "1 of " + tablasDeTareas.Rows.Count.ToString()
        End If
        If tablasDeTareas.Rows.Count > 0 Then
            idAuxWO = tablasDeTareas.Rows(0).ItemArray(5)
            JobNumber = tablasDeTareas.Rows(0).ItemArray(0)
            PO = tablasDeTareas.Rows(0).ItemArray(1)
        End If
        If Not cargarDatosProjecto(JobNumber) Then
            If chbComplete.Checked = True Then
                activarCampos(True)
            Else
                activarCampos(False)
            End If
        Else
            activarCampos(False)
        End If
        txtClientName.Enabled = False
        dtpBeginDate.Format = DateTimePickerFormat.Custom
        dtpEndDate.Format = DateTimePickerFormat.Custom
        dtpBeginDate.CustomFormat = "MM/dd/yyyy"
        dtpEndDate.CustomFormat = "MM/dd/yyyy"
        flagAddRecord = False

        tblMaterialProjects.Controls.Add(_dtpMaterial)
        _dtpMaterial.Visible = False
        _dtpMaterial.Format = DateTimePickerFormat.Custom
        _dtpMaterial.CustomFormat = "MM/dd/yyyy"
        AddHandler _dtpMaterial.ValueChanged, AddressOf _dtpMaterialValueChangue

    End Sub

    Private Sub _dtpMaterialValueChangue(sender As Object, e As EventArgs)
        Dim fecha = If(_dtpMaterial.Value.Month < 10, "0" + _dtpMaterial.Value.Month.ToString(), _dtpMaterial.Value.Month.ToString()) + "/" + If(_dtpMaterial.Value.Day < 10, "0" + _dtpMaterial.Value.Day.ToString(), _dtpMaterial.Value.Day.ToString()) + "/" + _dtpMaterial.Value.Year.ToString()
        tblMaterialProjects.CurrentCell.Value = fecha
    End Sub
    Private Sub tblMaterialProject_ColumnWithChangue(sender As Object, e As DataGridViewColumnEventArgs) Handles tblMaterialProjects.ColumnWidthChanged
        _dtpMaterial.Visible = False
    End Sub

    Private Sub tblMaterialProjects_Scroll(sender As Object, e As ScrollEventArgs) Handles tblMaterialProjects.Scroll
        _dtpMaterial.Visible = False
    End Sub

    Private Sub tblMaterialProjects_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles tblMaterialProjects.CellClick
        If e.ColumnIndex <> -1 And e.RowIndex <> -1 Then
            Select Case tblMaterialProjects.Columns(e.ColumnIndex).Name
                Case "Date"
                    Dim fechaAnterior As Date = System.DateTime.Today
                    If tblMaterialProjects.CurrentCell.Value IsNot DBNull.Value Then
                        fechaAnterior = validarFechaParaVB(tblMaterialProjects.CurrentCell.Value)
                    End If
                    _rectangulo = tblMaterialProjects.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True)
                    _dtpMaterial.Size = New Size(_rectangulo.Width, _rectangulo.Height)
                    _dtpMaterial.Location = New Point(_rectangulo.X, _rectangulo.Y)
                    _dtpMaterial.Visible = True
                    _dtpMaterial.CustomFormat = "MM/dd/yyyy"
                    _dtpMaterial.Format = DateTimePickerFormat.Custom
                    _dtpMaterial.Value = fechaAnterior

                Case "Material Code"
                    Try
                        If tblMaterialProjects.CurrentCell.GetType.Name = "DataGridViewTextBoxCell" Then
                            Dim lastValue As String = If(tblMaterialProjects.CurrentCell.Value IsNot DBNull.Value, tblMaterialProjects.CurrentCell.Value, "")
                            Dim cmbMatrial As New DataGridViewComboBoxCell
                            With cmbMatrial
                                lastValue = mtdJobs.llenarComboCellMaterial(cmbMatrial, listIdsMaterial, lastValue)
                            End With
                            tblMaterialProjects.CurrentRow.Cells("Material Code") = cmbMatrial
                            tblMaterialProjects.CurrentRow.Cells("Material Code").Value = lastValue
                        Else
                            tblMaterialProjects.CurrentRow.Cells("Material Code") = tblMaterialProjects.CurrentCell
                        End If
                    Catch ex As Exception

                    End Try
                Case "Work Order"
                    tblMaterialProjects.CurrentRow.Cells("Work Order").Value = lblWorkOrder.Text
            End Select
        End If
    End Sub

    Private Sub DataGridView1_DataError(ByVal sender As Object, ByVal e As DataGridViewDataErrorEventArgs) Handles tblMaterialProjects.DataError
        ' Excepción
        Dim ex As Exception = e.Exception
        If e.Exception.Message <> "El valor de DataGridViewComboBoxCell no es válido." And e.Exception.Message <> "DataGridViewComboBoxCell value is not valid." Then
            MessageBox.Show(ex.Message)
        Else
            e.Cancel = True
        End If
    End Sub

    'Private Sub tblExpencesProjects_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles tblExpencesProjects.CellClick
    '    If e.ColumnIndex <> -1 Then
    '        Select Case tblExpencesProjects.Columns(e.ColumnIndex).Name
    '            Case "Date"
    '                _rectangulo = tblExpencesProjects.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True)
    '                _dtpExpenses.Size = New Size(_rectangulo.Width, _rectangulo.Height)
    '                _dtpExpenses.Location = New Point(_rectangulo.X, _rectangulo.Y)
    '                _dtpExpenses.Visible = True
    '            Case "Expense Code"
    '                Dim cmbTiposExpenses As New DataGridViewComboBoxCell
    '                mtdJobs.llenarComboCellExpCode(cmbTiposExpenses, listIdsExpCodes)
    '                tblExpencesProjects.CurrentRow.Cells("Expense Code") = cmbTiposExpenses
    '        End Select
    '    End If
    'End Sub

    'Private Sub _dtpExpensesTextChangue(sender As Object, e As EventArgs)
    '    tblExpencesProjects.CurrentCell.Value = _dtpExpenses.Value.ToString()
    'End Sub

    'Private Sub tblExpencesProject_ColumnWithChangue(sender As Object, e As DataGridViewColumnEventArgs) Handles tblExpencesProjects.ColumnWidthChanged
    '    _dtpExpenses.Visible = False
    'End Sub

    'Private Sub tblExpencesProjects_Scroll(sender As Object, e As ScrollEventArgs) Handles tblExpencesProjects.Scroll
    '    _dtpExpenses.Visible = False
    'End Sub

    'Dim listIdsExpCodes As New DataTable
    Dim listIdsMaterial As New DataTable

    Private Function cargarDatosProjecto(ByVal jobNum As String) As Boolean
        Dim flag As Boolean = llenarCampos(mtdJobs.cargarDatosProjectOrder(jobNum)) 'aqui puedo tomar los datos de idCliente , WO y PO
        mtdJobs.buscarHorasPorProjecto(tblHoursWorkedProject, idAuxWO, task)
        mtdJobs.buscarExpencesPorProyecto(tblExpencesProjects, idAuxWO, task)
        mtdJobs.buscarMaterialesPorProyecto(tblMaterialProjects, idAuxWO, task)
        cmbJobNumber.SelectedIndex = cmbJobNumber.FindString(jobNum)
        lblWorkOrder.Text = WorkOrder + " " + task
        If flag Then
            If tablasDeTareas.Rows.Count <> 0 Then
                tablasDeTareas.Rows.Clear()
            End If
            mtdJobs.consultaWO(jobNum, tablasDeTareas)
            If tablasDeTareas.Rows IsNot Nothing Then
                txtElementsRadar.Text = "1 of " + tablasDeTareas.Rows.Count.ToString()
            End If
        End If
        calcularValores()
        Return flag
    End Function

    Private Function cargarDatosProjecto(ByVal jobNum As String, ByVal WO As String, ByVal tk As String, Optional idPO As String = "") As Boolean
        Dim flag As Boolean = llenarCampos(mtdJobs.cargarDatosProjectOrder(jobNum, tk, WO, idPO)) 'aqui puedo tomar los datos de idCliente , WO y PO
        mtdJobs.buscarHorasPorProjecto(tblHoursWorkedProject, WO, tk)
        mtdJobs.buscarExpencesPorProyecto(tblExpencesProjects, WO, tk)
        mtdJobs.buscarMaterialesPorProyecto(tblMaterialProjects, WO, tk)
        lblWorkOrder.Text = WorkOrder + " " + task
        If flag Then
            If flagBtnNextBackFind = True Then
                cmbJobNumber.SelectedItem = cmbJobNumber.Items(cmbJobNumber.FindString(jobNum))
                JobNumber = jobNum
                If tablasDeTareas.Rows IsNot Nothing Then
                    txtElementsRadar.Text = "1 of " + tablasDeTareas.Rows.Count.ToString
                End If
            Else
                If tablasDeTareas.Rows.Count <> 0 Then
                    tablasDeTareas.Rows.Clear()
                End If
                mtdJobs.consultaWO(jobNum, tablasDeTareas)
                If tablasDeTareas.Rows IsNot Nothing Then
                    txtElementsRadar.Text = "1 of " + tablasDeTareas.Rows.Count.ToString
                End If
            End If
        End If
        calcularValores()
        Return flag
    End Function

    Private Sub btnNextTask_Click(sender As Object, e As EventArgs) Handles btnNextTask.Click
        Try
            If tablasDeTareas.Rows.Count > 1 Then
                Dim contRow As Integer = tablasDeTareas.Rows.Count
                Dim index As Integer = 0
                For Each row As DataRow In tablasDeTareas.Rows
                    If row.ItemArray(3) = task And row.ItemArray(2) = WorkOrder And row.ItemArray(0) = JobNumber Then
                        Exit For
                    Else
                        index = index + 1
                    End If
                Next
                If index = contRow - 1 Then
                    index = 0
                    flagBtnNextBackFind = True
                    If cargarDatosProjecto(tablasDeTareas.Rows(index).ItemArray(0), tablasDeTareas.Rows(index).ItemArray(5), tablasDeTareas.Rows(index).ItemArray(3), tablasDeTareas.Rows(index).ItemArray(1)) Then
                        If chbComplete.Checked() = False Then
                            activarCampos(True)
                        Else
                            activarCampos(False)
                        End If
                    Else
                        activarCampos(False)
                    End If
                    If tablasDeTareas.Rows IsNot Nothing Then
                        txtElementsRadar.Text = CStr(index + 1) + " of " + tablasDeTareas.Rows.Count.ToString()
                    End If
                    flagBtnNextBackFind = False
                Else
                    index += 1
                    flagBtnNextBackFind = True
                    If cargarDatosProjecto(tablasDeTareas.Rows(index).ItemArray(0), tablasDeTareas.Rows(index).ItemArray(5), tablasDeTareas.Rows(index).ItemArray(3), tablasDeTareas.Rows(index).ItemArray(1)) Then
                        If chbComplete.Checked() = False Then
                            activarCampos(True)
                        Else
                            activarCampos(False)
                        End If
                    Else
                        activarCampos(False)
                    End If
                    If tablasDeTareas.Rows IsNot Nothing Then
                        txtElementsRadar.Text = CStr(index + 1) + " of " + tablasDeTareas.Rows.Count.ToString()
                    End If
                    flagBtnNextBackFind = False
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnAfterTask_Click(sender As Object, e As EventArgs) Handles btnAfterTask.Click
        If tablasDeTareas.Rows.Count > 1 Then
            Dim contRow As Integer = tablasDeTareas.Rows.Count
            Dim index As Integer = 0
            For Each row As DataRow In tablasDeTareas.Rows
                If row.ItemArray(3) = task And row.ItemArray(2) = WorkOrder And row.ItemArray(0) = JobNumber And row.ItemArray(1) = PO Then
                    Exit For
                Else
                    index = index + 1
                End If
            Next
            If index = 0 Then
                index = contRow - 1
                flagBtnNextBackFind = True
                If cargarDatosProjecto(tablasDeTareas.Rows(index).ItemArray(0), tablasDeTareas.Rows(index).ItemArray(5), tablasDeTareas.Rows(index).ItemArray(3), tablasDeTareas.Rows(index).ItemArray(1)) Then
                    If chbComplete.Checked() = False Then
                        activarCampos(True)
                    Else
                        activarCampos(False)
                    End If
                    If tablasDeTareas.Rows IsNot Nothing Then
                        txtElementsRadar.Text = CStr(index + 1) + " of " + tablasDeTareas.Rows.Count.ToString()
                    End If
                    flagBtnNextBackFind = False
                Else
                    activarCampos(False)
                End If
                flagBtnNextBackFind = False
            Else
                index -= 1
                flagBtnNextBackFind = True
                If cargarDatosProjecto(tablasDeTareas.Rows(index).ItemArray(0), tablasDeTareas.Rows(index).ItemArray(5), tablasDeTareas.Rows(index).ItemArray(3), tablasDeTareas.Rows(index).ItemArray(1)) Then
                    If chbComplete.Checked() = False Then
                        activarCampos(True)
                    Else
                        activarCampos(False)
                    End If
                Else
                    activarCampos(False)
                End If
                If tablasDeTareas.Rows IsNot Nothing Then
                    txtElementsRadar.Text = CStr(index + 1) + " of " + tablasDeTareas.Rows.Count.ToString()
                End If
                flagBtnNextBackFind = False
            End If
        End If
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            cargarDatosProjecto(pjt.jobNum, pjt.idAuxWO, pjt.idTask)
            btnCancel.Visible = False
            btnAddRecord.Text = "Add Record"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAddRecord_Click(sender As Object, e As EventArgs) Handles btnAddRecord.Click
        If btnAddRecord.Text = "Add" Then
            btnAddRecord.Text = "Save Record"
            btnCancel.Visible = True
            limpiarCampos()
            activarCampos(True)
            btnChangeJobNo.Enabled = False
            chbComplete.Checked = False
            flagAddRecord = True
            pjtNuevo.clear()
            pjtNuevo.idWorkOrder = txtWokOrder.Text
            pjtNuevo.jobNum = cmbJobNumber.SelectedItem
            dtpBeginDate.Value = pjtNuevo.beginDate
            dtpEndDate.Value = pjtNuevo.endDate
            lblWorkOrder.Text = ""
            pjtNuevo.manager = If(cmbProjectManager.SelectedItem <> Nothing, cmbProjectManager.SelectedItem, "")
            pjtNuevo.expCode = If(cmbExpCode.SelectedItem <> Nothing, cmbExpCode.SelectedItem, "")
        Else
            If mtdJobs.insertarNuevaTarea(pjtNuevo) Then
                MsgBox("Successful")
                btnAddRecord.Text = "Add"
                flagAddRecord = False
                mtdJobs.consultaWO(JobNumber, tablasDeTareas)
                If tablasDeTareas.Rows IsNot Nothing Then
                    txtElementsRadar.Text = "1 of " + tablasDeTareas.Rows.Count.ToString()
                End If
                If Not cargarDatosProjecto(JobNumber) Then
                    activarCampos(False)
                Else
                    If chbComplete.Checked = False Then
                        activarCampos(True)
                    Else
                        activarCampos(False)
                    End If
                End If
                btnChangeJobNo.Enabled = True
            Else
                MsgBox("Error, chek the Data or try again")
                btnAddRecord.Text = "Save"
                flagAddRecord = True
                btnChangeJobNo.Enabled = False
            End If
        End If
    End Sub

    Private Sub btnDeleteProject_Click(sender As Object, e As EventArgs) Handles btnDeleteProject.Click
        Try
            If existRecords(tblHoursWorkedProject) Or existRecords(tblMaterialProjects) Or existRecords(tblExpencesProjects) Then
                MessageBox.Show("Is not Posible to delete Project, The project contain some records try to drop it and then try to Delete.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                If DialogResult.Yes = MessageBox.Show("Are you sure to Delete this Project." & vbCrLf & vbCrLf & "Remember that you can delete any scaffolding or estimates that you may have attached to this project and these will delete to. ", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) Then
                    If mtdJobs.deleteProject(pjt.idAux, pjt.idAuxWO, pjt.idPO, pjt.jobNum.ToString) Then
                        MsgBox("Successful")
                        mtdJobs.consultaWO(JobNumber, tablasDeTareas)
                        If tablasDeTareas.Rows IsNot Nothing Then
                            txtElementsRadar.Text = "1 of " + tablasDeTareas.Rows.Count.ToString()
                        End If
                        If tablasDeTareas.Rows.Count > 0 Then
                            idAuxWO = tablasDeTareas.Rows(0).ItemArray(5)
                            JobNumber = tablasDeTareas.Rows(0).ItemArray(0)
                            PO = tablasDeTareas.Rows(0).ItemArray(1)
                        End If
                        If Not cargarDatosProjecto(JobNumber) Then
                            If chbComplete.Checked = True Then
                                activarCampos(True)
                            Else
                                activarCampos(False)
                            End If
                        Else
                            activarCampos(False)
                        End If
                        'Dim matchs = From row In tablasDeTareas
                        '             Let IdAuxM = row.Field(Of String)("idAux")
                        '             Where IdAuxM = pjt.idAux
                        'If matchs.Any() Then

                        'End If

                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function existRecords(ByVal tbl As DataGridView) As Boolean
        Try
            If tblHoursWorkedProject.Rows IsNot Nothing Then
                If tblHoursWorkedProject.Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function limpiarCampos() As Boolean
        'txtWokOrder.Text = ""
        txtTask.Text = ""
        txtProjectDescription.Text = ""
        txtEquipament.Text = ""
        txtAcountNo.Text = ""
        txtClientPO.Text = ""
        cmbExpCode.SelectedIndex = 0
        cmbProjectManager.Text = ""
        cmbProjectManager.SelectedIndex = If(cmbProjectManager.SelectedIndex = -1, -1, Nothing)
        sprHoursEstimate.Value = 0
        sprTotalBilling.Value = 0
        txtTotalHours.Text = ""
        txtTotalHoursBilling.Text = ""
        txtTotalHoursOT.Text = ""
        txtTotalHoursOTBilling.Text = ""
        txtTotalExpenses.Text = ""
        txtTotalMaterial.Text = ""
        txtLeftSpend.Text = ""
        txtLine.Text = ""
        txtWBS.Text = ""
        txtPostingProject.Text = ""
        txtPhase.Text = ""
        Return True
    End Function
    Private Function llenarCampos(ByVal lstDatosPO As List(Of String)) As Boolean
        If lstDatosPO IsNot Nothing Then
            If lstDatosPO.Count > 0 Then

                txtClientName.Text = lstDatosPO(0)
                txtWokOrder.Text = lstDatosPO(1)
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
                txtLine.Text = lstDatosPO(17)
                txtWBS.Text = lstDatosPO(18)
                txtArea.Text = lstDatosPO(19)
                txtPostingProject.Text = lstDatosPO(20)
                txtPhase.Text = lstDatosPO(21)
                'cmbJobNumber.SelectedIndex = cmbJobNumber.FindString(JobNumber.ToString())
                'AQUI SE CARGARAN LOS DATOS A LA CLASE DE PROJECT 
                pjt.idPO = txtClientPO.Text
                pjt.equipament = txtEquipament.Text
                pjt.manager = cmbProjectManager.Text
                pjt.estimateHour = sprHoursEstimate.Value
                pjt.beginDate = dtpBeginDate.Value
                pjt.endDate = dtpEndDate.Value
                Dim datos() As String = cmbExpCode.Text.Split(" ")
                pjt.expCode = datos(0)
                pjt.accountNum = txtAcountNo.Text
                pjt.estimateHour = CInt(sprHoursEstimate.Value)
                pjt.status = If(chbComplete.Checked, "1", "0")
                pjt.jobNum = JobNumber
                pjt.idTask = task
                pjt.idWorkOrder = WorkOrder
                pjt.idAux = lstDatosPO(14)
                idAuxWO = lstDatosPO(15)
                pjt.idAuxWO = idAuxWO
                pjt.PercentComplete = CInt(lstDatosPO(16))
                sprPercentComplete.Value = pjt.PercentComplete
                pjt.Line = lstDatosPO(17)
                pjt.WBS = lstDatosPO(18)
                pjt.Area = lstDatosPO(19)
                pjt.postingProject = lstDatosPO(20)
                pjt.Phase = lstDatosPO(21)
                pjt.Taxes = lstDatosPO(22)
                Dim tbl As New DataTable
                mtdJobs.consultaJobs(tbl)
                Dim arrayJob() As DataRow = tbl.Select("jobNo =" + pjt.jobNum.ToString)
                'If arrayJob.Length > 0 Then
                '    txtPostingProject.Text = arrayJob(0).ItemArray(1).ToString
                'End If
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function
    Private Sub cmbJobNumber_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbJobNumber.SelectedIndexChanged
        If flagAddRecord Then
            If cmbJobNumber.SelectedItem.ToString() <> "" Then
                pjtNuevo.jobNum = cmbJobNumber.Text
                Dim tbl As New DataTable
                mtdJobs.consultaJobs(tbl)
                Dim arrayJob() As DataRow = tablasDeTareas.Select("jobNo =" + cmbJobNumber.Text)
                If arrayJob.Length > 0 Then
                    txtPostingProject.Text = arrayJob(0).ItemArray(8).ToString
                End If
                If tablasDeTareas.Rows IsNot Nothing Then
                    txtElementsRadar.Text = "1 of " + tablasDeTareas.Rows.Count.ToString()
                End If
            End If
            btnChangeJobNo.Enabled = False
        ElseIf flagBtnNextBackFind = True Then
            JobNumber = cmbJobNumber.SelectedItem
            btnChangeJobNo.Enabled = True
        Else
            JobNumber = cmbJobNumber.SelectedItem
            If cargarDatosProjecto(JobNumber) Then
                If chbComplete.Checked() = False Then
                    activarCampos(True)
                Else
                    activarCampos(False)
                End If
            Else
                activarCampos(False)
            End If
            mtdJobs.consultaWO(JobNumber, tablasDeTareas)
            If tablasDeTareas.Rows IsNot Nothing Then
                txtElementsRadar.Text = "1 of " + tablasDeTareas.Rows.Count.ToString()
            End If
            btnChangeJobNo.Enabled = True
        End If
    End Sub

    Private Sub cmbJobNumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbJobNumber.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Or Asc(e.KeyChar) = Keys.Tab Then
            If flagAddRecord Then
                If cmbJobNumber.SelectedItem.ToString() <> "" Then
                    pjtNuevo.jobNum = cmbJobNumber.Text
                    mtdJobs.consultaWO(pjtNuevo.jobNum, tablasDeTareas)
                End If
            Else
                JobNumber = cmbJobNumber.SelectedItem
                If cargarDatosProjecto(JobNumber) Then
                    If chbComplete.Checked() = False Then
                        activarCampos(True)
                    Else
                        activarCampos(False)
                    End If
                Else
                    activarCampos(False)
                End If
                mtdJobs.consultaWO(JobNumber, tablasDeTareas)
            End If
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
                If pjtNuevo.idTask <> txtTask.Text Then
                    pjtNuevo.idTask = txtTask.Text
                End If
            Else
                txtTask.Text = ""
            End If
        Else
            If validarTask() Then
                Dim cont As Int16 = 0
                For Each row As DataRow In tablasDeTareas.Rows
                    If task = If(row.ItemArray(3) = "", "0", row.ItemArray(3)) And idAuxWO = row.ItemArray(5) Then
                        Exit For
                    Else
                        cont += 1
                    End If
                Next
                If mtdJobs.updateTask(txtTask.Text, pjt.idAux) Then
                    task = If(txtTask.Text = "", Nothing, txtTask.Text)
                    lblWorkOrder.Text = WorkOrder + " " + task
                    pjt.idTask = If(txtTask.Text = "", Nothing, txtTask.Text)
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
        If Asc(e.KeyChar) = Keys.Enter Or Asc(e.KeyChar) = Keys.Tab Then
            If flagAddRecord Then
                If validarTask() Then
                    If pjtNuevo.idTask <> txtTask.Text Then
                        pjtNuevo.idTask = txtTask.Text
                    End If
                Else
                    txtTask.Text = ""
                End If
            Else
                If validarTask() Then
                    Dim cont As Int16 = 0
                    For Each row As DataRow In tablasDeTareas.Rows
                        If task = If(row.ItemArray(3) = "", "0", row.ItemArray(3)) And idAuxWO = row.ItemArray(5) Then
                            Exit For
                        Else
                            cont += 1
                        End If
                    Next
                    If mtdJobs.updateTask(txtTask.Text, pjt.idAux) Then
                        task = If(txtTask.Text = "", Nothing, txtTask.Text)
                        lblWorkOrder.Text = WorkOrder + " " + task
                        pjt.idTask = If(txtTask.Text = "", Nothing, txtTask.Text)
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
        If txtTask.Text.Length >= 1 And txtTask.Text.Length <= 17 Then
            Dim flagTask As Boolean = True
            For Each row As DataRow In tablasDeTareas.Rows
                If txtTask.Text = row.ItemArray(3).ToString And txtWokOrder.Text = row.ItemArray(2) And cmbJobNumber.Text = row.ItemArray(0).ToString() And txtClientPO.Text = row.ItemArray(1).ToString() Then
                    flagTask = False
                    Exit For
                End If
            Next
            Return flagTask
        Else
            If txtTask.Text.Length < 1 Then
                MessageBox.Show("The 'Task' parameter admits a code whose length is greater or equals than 1 character.", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
                Return False
            ElseIf txtTask.Text.Length > 17 Then
                MessageBox.Show("The 'Task' parameter admits a code whose length is less or equals than 17 characters.", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
                Return False
            Else
                Return False
            End If
        End If
    End Function


    '================  WORKORDER =============================================================================================
    '=========================================================================================================================

    Private Sub txtWokOrder_Leave(sender As Object, e As EventArgs) Handles txtWokOrder.Leave
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
                If mtdJobs.updateWorkOrder(txtWokOrder.Text, idAuxWO, pjt.idPO, pjt.jobNum) Then
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
    End Sub

    Private Sub txtWokOrder_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtWokOrder.KeyPress
        If Asc(e.KeyChar()) = Keys.Enter Or Asc(e.KeyChar) = Keys.Tab Then
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
                    If mtdJobs.updateWorkOrder(txtWokOrder.Text, idAuxWO, pjt.idPO, pjt.jobNum) Then
                        lblWorkOrder.Text = txtWokOrder.Text + " " + txtTask.Text
                        WorkOrder = txtWokOrder.Text
                        tablasDeTareas.Clear()
                        pjt.idWorkOrder = WorkOrder
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
            MessageBox.Show("The parameter 'WorkOrder' accept like minimum 4 numers.'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
    End Function


    '================ CLIENT PO ==============================================================================================
    '=========================================================================================================================

    Private Sub txtClientPO_Leave(sender As Object, e As EventArgs) Handles txtClientPO.Leave
        If flagAddRecord Then
            If validarClientPO() Then
                If pjtNuevo.idPO <> txtClientPO.Text Then
                    pjtNuevo.idPO = txtClientPO.Text
                End If
            Else
                txtClientPO.Text = pjtNuevo.idPO
            End If
            FindPOVal()
        Else
            If validarClientPO() Then
                If pjt.idPO <> txtClientPO.Text Then
                    If mtdJobs.updatePO(txtClientPO.Text, pjt.idPO, pjt.jobNum, pjt.idWorkOrder, pjt.idTask, pjt.Line, pjt.WBS) Then
                        mtdJobs.consultaWO(JobNumber, tablasDeTareas)
                        pjt.idPO = txtClientPO.Text
                        FindPOVal()
                    Else
                        txtClientPO.Text = pjt.idPO
                    End If
                Else
                    txtClientPO.Text = pjt.idPO
                End If
            Else
                txtClientPO.Text = pjtNuevo.idPO
            End If
        End If
    End Sub

    Function FindPOVal() As Boolean
        Dim arrayListPo() As DataRow = tablasDeTareas.Select("jobNo= " + cmbJobNumber.Text + " and idPO = " + txtClientPO.Text)
        If arrayListPo.Length > 0 Then
            txtLine.Text = txtClientPO.Text.Substring(txtClientPO.Text.Length - 1, 1)
            txtWBS.Text = arrayListPo(0).ItemArray(7)
            Return True
        Else
            txtLine.Text = ""
            txtWBS.Text = ""
            Return False
        End If
    End Function
    Function validarClientPO() As Boolean
        If flagAddRecord Then
            If txtClientPO.Text.Length >= 5 And soloNumero(txtClientPO.Text) Then
                If mtdJobs.existPO(txtClientPO.Text, cmbJobNumber.SelectedItem) = True Then
                    'If DialogResult.Yes = MessageBox.Show("Are you sure to use this PO.", "important", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) Then
                    FindPOVal()
                    Return True
                    'Else
                    '    Return False
                    'End If
                Else
                    Return True
                End If
            Else
                MessageBox.Show("The 'PO' needs like a minimum 5 numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
        Else
            If txtClientPO.Text.Length >= 5 And soloNumero(txtClientPO.Text) Then
                If mtdJobs.existPO(txtClientPO.Text, pjt.jobNum) = True Then
                    If txtClientPO.Text <> pjt.idPO Then
                        'MessageBox.Show("Are you sure to use this PO.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        FindPOVal()
                        Return True
                    Else
                        Return True
                    End If

                    Return False
                Else
                    Return True
                End If
            Else
                MessageBox.Show("The 'PO' needs like a minimum 5 numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
        End If
    End Function
    Private Sub txtClientPO_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtClientPO.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Or Asc(e.KeyChar) = Keys.Tab Then
            If validarClientPO() Then
                If flagAddRecord Then
                    pjtNuevo.idPO = txtClientPO.Text
                    txtProjectDescription.Focus()
                Else
                    If mtdJobs.updatePO(txtClientPO.Text, pjt.idPO, pjt.jobNum, pjt.idWorkOrder, pjt.idTask, pjt.Line, pjt.WBS) Then
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
        If Asc(e.KeyChar) = Keys.Enter Or Asc(e.KeyChar) = Keys.Tab Then
            If flagAddRecord Then
                If validarEquipament() And pjtNuevo.equipament <> txtEquipament.Text Then
                    pjtNuevo.equipament = txtEquipament.Text
                Else
                    txtEquipament.Text = pjtNuevo.equipament
                End If
            Else
                If validarEquipament() And pjt.equipament <> txtEquipament.Text Then
                    If mtdJobs.updateEquipaMent(txtEquipament.Text, pjt.idAux, pjt.idAuxWO) Then
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
            If validarEquipament() And pjtNuevo.equipament <> txtEquipament.Text Then
                pjtNuevo.equipament = txtEquipament.Text
            Else
                txtEquipament.Text = pjtNuevo.equipament
            End If
        Else
            If validarEquipament() And pjt.equipament <> txtEquipament.Text Then
                If mtdJobs.updateEquipaMent(txtEquipament.Text, pjt.idAux, pjt.idAuxWO) Then
                    pjt.equipament = txtEquipament.Text
                Else
                    txtEquipament.Text = pjt.equipament
                End If
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
                        If mtdJobs.updateManeger(cmbProjectManager.SelectedItem, pjt.idAux, pjt.idAuxWO) Then
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
            If cmbProjectManager.SelectedItem <> "" Or cmbProjectManager.Text <> "" Then
                If cmbProjectManager.SelectedItem = Nothing Then

                    cmbProjectManager.SelectedItem = cmbProjectManager.Items(If(cmbProjectManager.FindString(cmbProjectManager.Text) = -1, Nothing, cmbProjectManager.FindString(cmbProjectManager.Text)))
                    If cmbProjectManager.SelectedItem = Nothing Then
                        Return False
                    Else
                        Return True
                    End If
                Else
                    Return True
                End If
            Else
                Return False
            End If
        End If
    End Function

    Dim flagManger As String 'esta se usa para validar si hizo enter para ingresar
    Private Sub cmbProjectManager_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbProjectManager.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Or Asc(e.KeyChar) = Keys.Tab Then
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

    '================ LINE ===================================================================================================
    '=========================================================================================================================
    Private Sub txtLine_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLine.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Or Asc(e.KeyChar) = Keys.Tab Then
            If flagAddRecord Then
                If txtLine.Text <> pjtNuevo.Line Then
                    pjtNuevo.Line = txtLine.Text
                End If
            Else
                If txtLine.Text <> pjt.Line Then
                    If pjt.jobNum <> Nothing And pjt.idPO <> "" Then
                        If mtdJobs.updateLine(txtLine.Text, pjt.Line, pjt.jobNum, pjt.idPO) Then
                            pjt.Line = txtLine.Text
                        Else
                            txtLine.Text = pjt.Line
                        End If
                    Else
                        txtLine.Text = pjt.Line
                    End If
                End If
            End If
        ElseIf Not Char.IsControl(e.KeyChar) Then
            e.Handled = False
        End If
    End Sub

    Private Sub txtLine_Leave(sender As Object, e As EventArgs) Handles txtLine.Leave
        If flagAddRecord Then
            If txtLine.Text <> pjtNuevo.Line Then
                pjtNuevo.Line = txtLine.Text
            End If
        Else
            If txtLine.Text <> pjt.Line Then
                If pjt.jobNum <> Nothing And pjt.idPO <> "" Then
                    If mtdJobs.updateLine(txtLine.Text, pjt.Line, pjt.jobNum, pjt.idPO) Then
                        pjt.Line = txtLine.Text
                    Else
                        txtLine.Text = pjt.Line
                    End If
                Else
                    txtLine.Text = pjt.Line
                End If
            End If
        End If
    End Sub
    '================ WBS ====================================================================================================
    '=========================================================================================================================

    Private Sub txtArea_Leave(sender As Object, e As EventArgs) Handles txtArea.Leave
        If flagAddRecord Then
            If txtArea.Text <> pjtNuevo.Area Then
                pjtNuevo.Area = txtArea.Text
            End If
        Else
            If txtArea.Text <> pjt.Area Then
                If pjt.jobNum <> Nothing And pjt.idPO <> "" Then
                    If mtdJobs.updateArea(txtArea.Text, pjt.Area, pjt.idAux, pjt.idAuxWO) Then
                        pjt.Area = txtArea.Text
                    Else
                        txtArea.Text = pjt.Area
                    End If
                Else
                    txtArea.Text = pjt.Area
                End If
            End If
        End If
    End Sub

    Private Sub txtArea_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtArea.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Or Asc(e.KeyChar) = Keys.Tab Then
            If flagAddRecord Then
                If txtArea.Text <> pjtNuevo.Area Then
                    pjtNuevo.Area = txtArea.Text
                End If
            Else
                If txtArea.Text <> pjt.Area Then
                    If pjt.jobNum <> Nothing And pjt.idPO <> "" Then
                        If mtdJobs.updateArea(txtArea.Text, pjt.Area, pjt.idAux, pjt.idAuxWO) Then
                            pjt.Area = txtArea.Text
                        Else
                            txtArea.Text = pjt.Area
                        End If
                    Else
                        txtArea.Text = pjt.Area
                    End If
                End If
            End If
        ElseIf Not Char.IsControl(e.KeyChar) Then
            e.Handled = False
        End If
    End Sub

    '================ WBS ====================================================================================================
    '=========================================================================================================================
    Private Sub txtWBS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtWBS.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Or Asc(e.KeyChar) = Keys.Tab Then
            If flagAddRecord Then
                If txtWBS.Text <> pjtNuevo.WBS Then
                    pjtNuevo.WBS = txtWBS.Text
                End If
            Else
                If txtWBS.Text <> pjt.WBS Then
                    If pjt.jobNum <> Nothing And pjt.idPO <> "" Then
                        If mtdJobs.updateWBS(txtWBS.Text, pjt.WBS, pjt.jobNum, pjt.idPO) Then
                            pjt.WBS = txtWBS.Text
                        Else
                            txtWBS.Text = pjt.WBS
                        End If
                    Else
                        txtWBS.Text = pjt.WBS
                    End If
                End If
            End If
        ElseIf Not Char.IsControl(e.KeyChar) Then
            e.Handled = False
        End If
    End Sub

    Private Sub txtWBS_Leave(sender As Object, e As EventArgs) Handles txtWBS.Leave
        If flagAddRecord Then
            If txtWBS.Text <> pjtNuevo.WBS Then
                pjtNuevo.WBS = txtWBS.Text
            End If
        Else
            If txtWBS.Text <> pjt.WBS Then
                If pjt.jobNum <> Nothing And pjt.idPO <> "" Then
                    If mtdJobs.updateWBS(txtWBS.Text, pjt.WBS, pjt.jobNum, pjt.idPO) Then
                        pjt.WBS = txtWBS.Text
                    Else
                        txtWBS.Text = pjt.WBS
                    End If
                Else
                    txtWBS.Text = pjt.WBS
                End If
            End If
        End If
    End Sub


    '================ DESCRIPTION ============================================================================================
    '=========================================================================================================================

    Private Sub txtProjectDescription_Leave(sender As Object, e As EventArgs) Handles txtProjectDescription.Leave
        If flagAddRecord Then
            If validarDescription() And txtProjectDescription.Text <> pjtNuevo.description Then
                pjtNuevo.description = txtProjectDescription.Text
            Else
                txtProjectDescription.Text = pjtNuevo.description
            End If
        Else
            If validarDescription() And txtProjectDescription.Text <> pjt.description Then
                If mtdJobs.updateDescription(txtProjectDescription.Text, pjt.idAux, pjt.idAuxWO) Then
                    pjt.description = txtProjectDescription.Text
                Else
                    txtProjectDescription.Text = pjt.description
                End If
            End If
        End If
    End Sub

    Private Sub txtProjectDescription_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtProjectDescription.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Or Asc(e.KeyChar) = Keys.Tab Then
            If flagAddRecord Then
                If validarDescription() And txtProjectDescription.Text <> pjtNuevo.description Then
                    pjtNuevo.description = txtProjectDescription.Text
                Else
                    txtProjectDescription.Text = pjtNuevo.description
                End If
            Else
                If validarDescription() And txtProjectDescription.Text <> pjt.description Then
                    If mtdJobs.updateDescription(txtProjectDescription.Text, pjt.idAux, pjt.idAuxWO) Then
                        pjt.description = txtProjectDescription.Text
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
            If validarTotalBilling() And sprTotalBilling.Value <> pjtNuevo.totalBilling Then
                pjtNuevo.totalBilling = sprTotalBilling.Value
            Else
                sprTotalBilling.Value = pjtNuevo.totalBilling
            End If
        Else
            If validarTotalBilling() And pjt.totalBilling <> sprTotalBilling.Value Then
                If mtdJobs.updateTotalBilling(sprTotalBilling.Value, pjt.idAux, pjt.idAuxWO) Then
                    pjt.totalBilling = sprTotalBilling.Value
                Else
                    sprTotalBilling.Value = pjt.totalBilling
                End If
            Else
                sprTotalBilling.Value = pjt.totalBilling
            End If
        End If
        calcularValores()
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
        'If Asc(e.KeyChar) = Keys.Enter Or Asc(e.KeyChar) = Keys.Tab Then
        '    If flagAddRecord Then
        '        If validarTotalBilling() Then
        '            pjtNuevo.totalBilling = sprTotalBilling.Value
        '        Else
        '            sprTotalBilling.Value = pjtNuevo.totalBilling
        '        End If
        '    Else
        '        If validarTotalBilling() Then
        '            If mtdJobs.updateTotalBilling(sprTotalBilling.Value, pjt.idAux, pjt.idAuxWO) Then
        '                pjt.totalBilling = sprTotalBilling.Value
        '            Else
        '                sprTotalBilling.Value = pjt.totalBilling
        '            End If
        '        Else
        '            sprTotalBilling.Value = pjt.totalBilling
        '        End If
        '    End If
        'End If
        'calcularValores()
    End Sub

    Private Sub sprTotalBilling_ValueChanged(sender As Object, e As EventArgs) Handles sprTotalBilling.ValueChanged
        'calcularValores()
    End Sub

    '================ HOURS ESTIMATE =========================================================================================
    '=========================================================================================================================
    Private Sub sprHoursEstimate_KeyPress(sender As Object, e As KeyPressEventArgs) Handles sprHoursEstimate.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Or Asc(e.KeyChar) = Keys.Tab Then
            If flagAddRecord Then
                If validarHours() And Not pjtNuevo.estimateHour = sprHoursEstimate.Value Then
                    pjtNuevo.estimateHour = sprHoursEstimate.Value
                Else
                    sprHoursEstimate.Value = pjtNuevo.estimateHour
                End If
            Else
                If validarHours() And Not pjt.estimateHour = sprHoursEstimate.Value Then
                    If mtdJobs.updateHoursEstimate(sprHoursEstimate.Value, pjt.idAux, pjt.idAuxWO) Then
                        pjt.estimateHour = sprHoursEstimate.Value
                    Else
                        sprHoursEstimate.Value = pjt.estimateHour
                    End If
                Else
                    sprHoursEstimate.Value = pjt.estimateHour
                End If
            End If
        End If
        calcularValores()
    End Sub

    Private Function validarHours() As Boolean
        If sprHoursEstimate.Value > 0 Then
            Return True
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
            If validarHours() And Not pjtNuevo.estimateHour = sprHoursEstimate.Value Then
                pjtNuevo.estimateHour = sprHoursEstimate.Value
            Else
                sprHoursEstimate.Value = pjtNuevo.estimateHour
            End If
        Else
            If validarHours() And Not pjt.estimateHour = sprHoursEstimate.Value Then
                If mtdJobs.updateHoursEstimate(sprHoursEstimate.Value, pjt.idAux, pjt.idAuxWO) Then
                    pjt.estimateHour = sprHoursEstimate.Value
                Else
                    sprHoursEstimate.Value = pjt.estimateHour
                End If
            Else
                sprHoursEstimate.Value = pjt.estimateHour
            End If
        End If
        calcularValores()
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
                If mtdJobs.updateBeginDate(dtpBeginDate.Value, pjt.idAux, pjt.idAuxWO) Then
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
        If Asc(e.KeyChar) = Keys.Enter Or Asc(e.KeyChar) = Keys.Tab Then
            If flagAddRecord Then
                If validarBeginDate() Then
                    pjtNuevo.beginDate = dtpBeginDate.Value
                Else
                    dtpBeginDate.Value = pjtNuevo.beginDate
                End If
            Else
                If validarBeginDate() Then
                    If mtdJobs.updateBeginDate(dtpBeginDate.Value, pjt.idAux, pjt.idAuxWO) Then
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
            If pjtNuevo.endDate <> dtpEndDate.Value And validarEndDate() Then
                pjtNuevo.beginDate = dtpEndDate.Value
            Else
                dtpEndDate.Value = pjtNuevo.endDate
            End If
        Else
            If validarEndDate() And Not dtpEndDate.Value.Equals(pjt.endDate) Then
                If mtdJobs.updateEndDate(dtpEndDate.Value, pjt.idAux, pjt.idAuxWO) Then
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
        If Asc(e.KeyChar) = Keys.Enter Or Asc(e.KeyChar) = Keys.Tab Then
            If flagAddRecord Then
                If pjtNuevo.endDate <> dtpEndDate.Value And validarEndDate() Then
                    pjtNuevo.beginDate = dtpEndDate.Value
                Else
                    dtpEndDate.Value = pjtNuevo.endDate
                End If
            Else
                If validarEndDate() And Not dtpEndDate.Value.Equals(pjt.endDate) Then
                    If mtdJobs.updateEndDate(dtpEndDate.Value, pjt.idAux, pjt.idAuxWO) Then
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
                pjtNuevo.expCode = mtdJobs.soloCodigoExpCode(cmbExpCode.SelectedItem)
            Else
                cmbExpCode.SelectedItem = If(pjtNuevo.expCode = "", cmbExpCode.Items(0), pjtNuevo.expCode)
            End If
        Else
            If ValidarExpCode() Then
                If mtdJobs.updateExxpCode(mtdJobs.soloCodigoExpCode(cmbExpCode.SelectedItem), pjt.idAux, pjt.idAuxWO) Then
                    pjt.expCode = mtdJobs.soloCodigoExpCode(cmbExpCode.SelectedItem)
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
                    If mtdJobs.updateAccont(txtAcountNo.Text, pjt.idAux, pjt.idAuxWO) Then
                        pjt.accountNum = txtAcountNo.Text
                    Else
                        txtAcountNo.Text = pjt.accountNum
                    End If
                Else
                    txtAcountNo.Text = pjt.accountNum
                End If
            End If
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If tblMaterialProjects.SelectedRows.Count > 0 Then
            If DialogResult.Yes = MessageBox.Show("Are you sure to delete " + tblMaterialProjects.SelectedRows.Count.ToString() + " materials?" + vbCrLf + "If you accept you can't recober this records.", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) Then
                For Each row As DataGridViewRow In tblMaterialProjects.SelectedRows
                    mtdJobs.deleteMaterial(row.Cells("idMaterialUsed").Value, idAuxWO)
                Next
                mtdJobs.buscarMaterialesPorProyecto(tblMaterialProjects, idAuxWO, task)
                calcularValores()
            End If
        Else
            MessageBox.Show("Plese select a row to continue.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If tblMaterialProjects.SelectedRows.Count > 0 Then
            If DialogResult.Yes = MessageBox.Show("Are you sure to changue " + tblMaterialProjects.SelectedRows.Count.ToString() + " materials in the registers?" + vbCrLf + "If you accept you can't recober the last data.", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) Then
                For Each row As DataGridViewRow In tblMaterialProjects.SelectedRows
                    actualizarMateriales(row.Index)
                Next
            End If
            mtdJobs.buscarMaterialesPorProyecto(tblMaterialProjects, idAuxWO, task)
            calcularValores()
        Else
            MessageBox.Show("Plese select a row to continue.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub txtAccount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAcountNo.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Or Asc(e.KeyChar) = Keys.Tab Then
            If flagAddRecord Then
                If txtAcountNo.Text <> pjtNuevo.accountNum Then
                    If validarAccountNO() Then
                        pjtNuevo.accountNum = txtAcountNo.Text
                    Else
                        txtAcountNo.Text = pjtNuevo.accountNum
                    End If
                End If
            Else
                If txtAcountNo.Text <> pjt.accountNum Then
                    If validarAccountNO() Then
                        If mtdJobs.updateAccont(txtAcountNo.Text, pjt.idAux, pjt.idAuxWO) Then
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

    '================ PHASE ==================================================================================================
    '=========================================================================================================================
    Private Function validarPhase() As Boolean
        If txtPhase.Text.Length = 0 Then
            If DialogResult.Yes = MessageBox.Show("The parameter 'Phase' don't detected enyone value, Do you want to save a 'Null' value?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) Then
                Return True
            Else
                Return False
            End If
        Else
            Return True
        End If
    End Function

    Private Sub txtPhase_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPhase.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Or Asc(e.KeyChar) = Keys.Tab Then
            If flagAddRecord Then
                If txtPhase.Text <> pjtNuevo.Phase Then
                    If validarPhase() Then
                        pjtNuevo.Phase = txtPhase.Text
                    Else
                        txtPhase.Text = pjtNuevo.Phase
                    End If
                End If
            Else
                If txtPhase.Text <> pjt.Phase Then
                    If validarPhase() Then
                        If mtdJobs.updatePhase(txtPhase.Text, pjt.idAux, pjt.idAuxWO) Then
                            pjt.Phase = txtPhase.Text
                        Else
                            txtPhase.Text = pjt.Phase
                        End If
                    Else
                        txtPhase.Text = pjt.Phase
                    End If
                End If
            End If
        ElseIf Not IsNumeric(Asc(e.KeyChar)) Then
            e.Handled = False
        End If
    End Sub

    Private Sub txtPhase_Leave(sender As Object, e As EventArgs) Handles txtPhase.Leave, txtAcountNo.Leave
        If flagAddRecord Then
            If txtPhase.Text <> pjt.Phase Then
                If validarPhase() Then
                    pjtNuevo.Phase = txtPhase.Text
                Else
                    txtAcountNo.Text = pjtNuevo.Phase
                End If
            End If
        Else
            If txtPhase.Text <> pjt.Phase Then
                If validarPhase() Then
                    If mtdJobs.updatePhase(txtPhase.Text, pjt.idAux, pjt.idAuxWO) Then
                        pjt.Phase = txtPhase.Text
                    Else
                        txtPhase.Text = pjt.Phase
                    End If
                Else
                    txtPhase.Text = pjt.Phase
                End If
            End If
        End If
    End Sub
    '================ COMPLETE PORCENT =======================================================================================
    '=========================================================================================================================
    Private Sub sprPorcentComplete_ValueChanged(sender As Object, e As EventArgs) Handles sprPercentComplete.ValueChanged
        If flagAddRecord Then
            pjtNuevo.PercentComplete = If(sprPercentComplete.Value <> Nothing, sprPercentComplete.Value, 0)
        Else
            pjt.PercentComplete = If(sprPercentComplete.Value <> Nothing, sprPercentComplete.Value, 0)
            mtdJobs.updateCompleteProgress(pjt.PercentComplete, pjt.idAux, pjt.idAuxWO)
            calcularValores()
        End If

    End Sub

    Private Sub sprPercentComplete_KeyUp(sender As Object, e As KeyEventArgs) Handles sprPercentComplete.KeyUp
        Try
            If flagAddRecord Then
                pjtNuevo.PercentComplete = If(sprPercentComplete.Value <> Nothing, sprPercentComplete.Value, 0)
            Else
                pjt.PercentComplete = If(sprPercentComplete.Value <> Nothing, sprPercentComplete.Value, 0)
                mtdJobs.updateCompleteProgress(pjt.PercentComplete, pjt.idAux, pjt.idAuxWO)
                calcularValores()
            End If
        Catch ex As Exception

        End Try
    End Sub

    '================ COMPLETE CHECK =========================================================================================
    '=========================================================================================================================


    Private Sub chbComplete_CheckedChanged(sender As Object, e As EventArgs) Handles chbComplete.CheckedChanged
        If Not flagBtnNextBackFind Then
            If chbComplete.Checked Then
                If flagAddRecord Then
                    pjtNuevo.status = "1"
                Else
                    If mtdJobs.updateComplete(If(chbComplete.Checked, True, False), pjt.idAux, pjt.idAuxWO) Then
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
                    If mtdJobs.updateComplete(If(chbComplete.Checked, True, False), pjt.idAux, pjt.idAuxWO) Then
                        activarCampos(False)
                        pjt.status = "0"
                    Else
                        chbComplete.Checked = False
                        pjt.status = "1"
                        activarCampos(True)
                    End If
                End If
            End If
        End If
    End Sub

    '================ posting project ========================================================================================
    '=========================================================================================================================

    Private Sub txtPostingProject_Leave(sender As Object, e As EventArgs) Handles txtPostingProject.Leave
        If flagAddRecord Then
            If validarPostingProject() And pjtNuevo.postingProject <> txtPostingProject.Text Then
                pjtNuevo.postingProject = txtPostingProject.Text
            Else
                txtPostingProject.Text = pjtNuevo.postingProject
            End If
        Else
            If validarEquipament() And pjt.postingProject <> txtPostingProject.Text Then
                If mtdJobs.updatePostingProject(txtPostingProject.Text, pjt.jobNum.ToString) Then
                    pjt.postingProject = txtPostingProject.Text
                Else
                    txtPostingProject.Text = pjt.postingProject
                End If
            End If
        End If
    End Sub
    Private Function validarPostingProject() As Boolean
        If flagAddRecord Then
            If txtPostingProject.Text.Length <= 20 Then
                Return True
            Else
                MessageBox.Show("The parameter 'Posting Project' only permit a maximum of 20 characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
        Else
            If txtEquipament.Text.Length <= 20 Then
                Return True
            Else
                MessageBox.Show("The parameter 'Posting Project' only permit a maximum of 20 characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
        End If
    End Function

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
        btnChangeJobNo.Enabled = activar
        txtLine.Enabled = activar
        txtWBS.Enabled = activar
        txtPhase.Enabled = activar
    End Sub

    Private Sub btnMaximize_Click(sender As Object, e As EventArgs) Handles btnMaximize.Click
        MaximizedBounds = Screen.FromHandle(Me.Handle).WorkingArea
        WindowState = FormWindowState.Maximized
        btnMaximize.Visible = False
        btnRestore.Visible = True
    End Sub

    Private Sub btnRestore_Click(sender As Object, e As EventArgs) Handles btnRestore.Click
        WindowState = FormWindowState.Normal
        btnRestore.Visible = False
        btnMaximize.Visible = True
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.Close()
    End Sub

    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(hWnd As IntPtr, wMsg As Integer, wParam As Integer, lParam As Integer)
    End Sub
    Private Sub Panel4_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel4.MouseMove
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub

    Private Sub cmbJobNumber_Enter(sender As Object, e As EventArgs) Handles cmbJobNumber.Enter, txtClientName.Enter, txtWokOrder.Enter, txtTask.Enter, txtEquipament.Enter, cmbProjectManager.Enter, txtClientPO.Enter, txtProjectDescription.Enter, sprTotalBilling.Enter, dtpBeginDate.Enter, dtpEndDate.Enter, sprHoursEstimate.Enter, cmbExpCode.Enter, txtAcountNo.Enter, sprPercentComplete.Enter, chbComplete.Enter, txtPostingProject.Enter, txtPhase.Enter
        If cmbJobNumber.Focused Then
            FindElement = "Job No"
            Element = cmbJobNumber.Text
        ElseIf txtClientName.Focused Then
            FindElement = "Client Name"
            Element = txtClientName.Text
        ElseIf txtWokOrder.Focused Then
            FindElement = "Work Order"
            Element = txtWokOrder.Text
        ElseIf txtTask.Focused Then
            FindElement = "Task"
            Element = txtTask.Text
        ElseIf txtEquipament.Focused Then
            FindElement = "Equipament"
            Element = txtEquipament.Text
        ElseIf cmbProjectManager.Focused Then
            FindElement = "Project Manager"
            Element = cmbProjectManager.Text
        ElseIf txtClientPO.Focused Then
            FindElement = "Client PO"
            Element = txtClientPO.Text
        ElseIf txtProjectDescription.Focused Then
            FindElement = "Project Description"
            Element = txtProjectDescription.Text
        ElseIf sprTotalBilling.Focused Then
            FindElement = "Est. Total Billing"
            Element = sprTotalBilling.Value.ToString()
        ElseIf dtpBeginDate.Focused Then
            FindElement = "Begin Date"
            Element = dtpBeginDate.Value.ToString()
        ElseIf dtpEndDate.Focused Then
            FindElement = "End Date"
            Element = dtpEndDate.Value.ToString()
        ElseIf sprHoursEstimate.Focused Then
            FindElement = "Hrs Estamate"
            Element = sprHoursEstimate.Value.ToString()
        ElseIf cmbExpCode.Focused Then
            FindElement = "Exp Code"
            Element = cmbExpCode.Text
        ElseIf txtAcountNo.Focused Then
            FindElement = "Account No."
            Element = txtAcountNo.Text
        ElseIf sprPercentComplete.Focused Then
            FindElement = "%Complete"
            Element = sprPercentComplete.Value.ToString()
        ElseIf chbComplete.Focused Then
            FindElement = "Complete"
            Element = If(chbComplete.Checked, "True", "False")
        ElseIf txtLine.Focused Then
            FindElement = "Line"
            Element = txtLine.Text
        ElseIf txtWBS.Focused Then
            FindElement = "WBS"
            Element = txtWBS.Text
        ElseIf txtPostingProject.Focused Then
            FindElement = "postingProject"
            Element = txtPostingProject.Text
        End If
    End Sub

    Private Sub btnUpdateMaterialExcel_Click(sender As Object, e As EventArgs) Handles btnUpdateMaterialExcel.Click
        Dim UpExcel As New EquipmentValidation
        UpExcel.idclient = idCliente
        UpExcel.jobNo = JobNumber.ToString()
        UpExcel.ShowDialog()
        mtdJobs.buscarMaterialesPorProyecto(tblMaterialProjects, idAuxWO, task)
        calcularValores()
    End Sub

    Private Sub btnChangeJobNo_Click(sender As Object, e As EventArgs) Handles btnChangeJobNo.Click
        Dim frmChanguePo As New ChangueProject
        frmChanguePo.JobNo = pjt.jobNum.ToString()
        frmChanguePo.PO = pjt.idPO
        frmChanguePo.WO = pjt.idWorkOrder + "-" + pjt.idTask
        frmChanguePo.idAux = pjt.idAux
        frmChanguePo.IdWO = pjt.idAuxWO
        frmChanguePo.ShowDialog()
        If cmbJobNumber.Items IsNot Nothing Then
            cmbJobNumber.SelectedIndex = 1
        End If
    End Sub

    Private Sub sprHoursEstimate_ValueChanged(sender As Object, e As EventArgs) Handles sprHoursEstimate.ValueChanged

    End Sub

    Private Sub btnMoveHours_Click(sender As Object, e As EventArgs) Handles btnMoveHours.Click
        Dim mvh As New MoveHours
        mvh.ShowDialog()
    End Sub

    Private Sub txtEquipament_TextChanged(sender As Object, e As EventArgs) Handles txtEquipament.TextChanged

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub btnFindProject_Click(sender As Object, e As EventArgs) Handles btnFindProject.Click
        Dim FT As New FindTask
        FT.FindElement = FindElement
        FT.Element = Element
        FT.IdClient = idCliente
        flagFindElement = False
        AddOwnedForm(FT)
        FT.ShowDialog()
        If flagFindElement Then
            Dim index As Integer = 0
            flagBtnNextBackFind = True
            If cargarDatosProjecto(tablasDeTareas.Rows(index).ItemArray(0), tablasDeTareas.Rows(index).ItemArray(5), tablasDeTareas.Rows(index).ItemArray(3), tablasDeTareas.Rows(index).ItemArray(1)) Then
                If chbComplete.Checked() = False Then
                    activarCampos(True)
                Else
                    activarCampos(False)
                End If
            Else
                activarCampos(False)
            End If
        End If
    End Sub

    Private Function calcularValores() As Boolean
        Dim totalCostHoursST As Double = 0.0
        Dim totalCostHoursOT As Double = 0.0
        Dim totalCostHours3 As Double = 0.0
        Dim totalHoursST As Double = 0.0
        Dim totalHoursOT As Double = 0.0
        Dim totalHours3 As Double = 0.0

        Dim totalExpences As Double = 0.0
        Dim totalMaterial As Double = 0.0
        Dim totalTaxes As Double = 0.0
        If tblHoursWorkedProject.Rows.Count > 0 Then

            For Each row As DataGridViewRow In tblHoursWorkedProject.Rows
                totalHoursST += CDbl(row.Cells("Billable Hrs. ST").Value)
                totalHoursOT += CDbl(row.Cells("Billable Hrs. OT").Value)
                totalHours3 += CDbl(row.Cells("Billable Hrs. 3").Value)
                totalCostHoursST += CDbl(row.Cells("Billing Rate").Value) * CDbl(row.Cells("Billable Hrs. ST").Value)
                totalCostHoursOT += CDbl(row.Cells("Billing RateOT").Value) * CDbl(row.Cells("Billable Hrs. OT").Value)
                totalCostHours3 += CDbl(row.Cells("Billing Rate 3").Value) * CDbl(row.Cells("Billable Hrs. 3").Value)
            Next

        End If

        If tblExpencesProjects.Rows.Count > 0 Then
            For Each row1 As DataGridViewRow In tblExpencesProjects.Rows
                totalExpences += CDbl(If(row1.Cells("Amount").Value Is Nothing, "0", row1.Cells("Amount").Value))
            Next
        End If


        If tblMaterialProjects.Rows.Count > 0 Then
            For Each row2 As DataGridViewRow In tblMaterialProjects.Rows()
                totalMaterial += CDbl(If(row2.Cells("Amount").Value Is Nothing, "0", row2.Cells("Amount").Value))
            Next
        End If


        txtTotalHours.Text = totalHoursST.ToString("N")
        txtTotalHoursBilling.Text = "$" + totalCostHoursST.ToString("N")
        txtTotalHoursOT.Text = totalHoursOT.ToString("N")
        txtTotalHoursOTBilling.Text = "$" + totalCostHoursOT.ToString("N")
        txtTotalHours3.Text = totalHours3.ToString("N")
        txtTotalHours3Billing.Text = "$" + totalCostHours3.ToString("N")
        txtTotalExpenses.Text = "$" + totalExpences.ToString("N")
        txtTotalMaterial.Text = "$" + totalMaterial.ToString("N")
        totalTaxes = (totalCostHoursST + totalCostHoursOT + totalCostHours3 + totalExpences + totalMaterial) * If(CDbl(pjt.Taxes) > 0, CDbl(pjt.Taxes) / 100, 0)
        txtTotalTaxes.Text = "$" + (totalTaxes).ToString("N")
        txtProjectBilled.Text = "$" + ((totalCostHoursST + totalCostHoursOT + totalCostHours3 + totalExpences + totalMaterial) + totalTaxes).ToString("N")
        txtLeftSpend.Text = (sprTotalBilling.Value - (totalCostHoursST + totalCostHoursOT + totalCostHours3 + totalExpences + totalMaterial)).ToString("N")
        txtLeftSpend.Text = "$" + txtLeftSpend.Text
        Dim mensaje As String = ""

        If 0 > (sprTotalBilling.Value - (totalCostHoursST + totalCostHoursOT + totalCostHours3 + totalExpences + totalMaterial)) Then
            mensaje = "The total spent was over budget"
        End If

        If sprTotalBilling.Value > 0 Then
            Dim porcentLeft = ((totalCostHoursST + totalCostHoursOT + totalCostHours3 + totalExpences + totalMaterial) * 100) / sprTotalBilling.Value
            lblPorcentBilled.Text = porcentLeft.ToString("N") + "%"
            lblPorcentLeft.Text = (100 - porcentLeft).ToString("N") + "%"
        End If

        If sprHoursEstimate.Value < (totalHoursST + totalHoursOT + totalHours3) Then
            mensaje = If(mensaje.Equals(""), "Total estimated hours were exceded.", ", Total estimated hours were exceded.")
        End If
        Dim THrs As Double = totalHoursST + totalHoursOT + totalHours3
        lblTotalHours.Text = CStr(THrs)
        If sprPercentComplete.Value > 0 And sprPercentComplete.Value < 100 Then
            lblEarned.Text = (sprHoursEstimate.Value * (sprPercentComplete.Value * 0.01))
            If (THrs) > 0 Then
                Dim pfAux = Val(CDec(If(lblEarned.Text = "", "0", lblEarned.Text)) / CDec(If(lblTotalHours.Text = "", "0", lblTotalHours.Text)))
                lblPF.Text = If(pfAux > 1, Format(pfAux, "#.##"), Format(pfAux, "0.##"))
            Else
                lblPF.Text = "0"
            End If
            If (THrs) < sprHoursEstimate.Value And THrs > 0 Then
                Dim pf As Double = Val(CDec(If(lblEarned.Text = "", "0", lblEarned.Text)) / CDec(If(lblTotalHours.Text = "", "0", lblTotalHours.Text)))
                Dim ETC As Double = pf * (sprHoursEstimate.Value - THrs)
                lblETC.Text = Format(ETC, "#.#")
            Else
                Dim ETC As Double
                If THrs > 0 Then
                    ETC = ((THrs) / (sprPercentComplete.Value * 0.01)) - (THrs)
                Else
                    ETC = 0
                End If
                lblETC.Text = Format(ETC, "0.#")
            End If
        ElseIf sprPercentComplete.Value = 100 Then
            lblETC.Text = "0"
            lblEarned.Text = sprHoursEstimate.Value * (sprPercentComplete.Value * 0.01)
            Dim pfAux As Decimal = 0
            If Not (lblTotalHours.Text = "" Or lblTotalHours.Text = "0") Then
                pfAux = Val(CDec(If(lblEarned.Text = "", "0", lblEarned.Text)) / CDec(lblTotalHours.Text))
            End If
            lblPF.Text = If(pfAux >= 1, Format(pfAux, "#.##"), Format(pfAux, "0.##"))
        End If
        If Not mensaje.Equals("") Then
            txtMensaje.Text = mensaje
        Else
            txtMensaje.Text = ""
        End If
        Return 0
    End Function

    Private Sub tblMaterialProjects_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles tblMaterialProjects.CellEndEdit
        If tblMaterialProjects.Rows.Count > 0 Then
            Select Case tblMaterialProjects.Columns(e.ColumnIndex).Name
                Case "Description1"
                    Dim mensaje As String = ""
                    Dim datosMaterial As New List(Of String)
                    If Not tblMaterialProjects.CurrentRow.Cells("idMaterialUsed").Value Is DBNull.Value Then
                        datosMaterial.Add(tblMaterialProjects.CurrentRow.Cells("idMaterialUsed").Value)
                    Else
                        datosMaterial.Add("")
                    End If
                    If Not tblMaterialProjects.CurrentRow.Cells("Date").Value Is DBNull.Value Then
                        datosMaterial.Add(validaFechaParaSQl(tblMaterialProjects.CurrentRow.Cells("Date").Value))
                    Else
                        mensaje = If(mensaje = "", "Please choose a Date.", vbCrLf + "Please choose a Date")
                    End If
                    datosMaterial.Add(pjt.idAux) 'idAuxTask
                    If Not tblMaterialProjects.CurrentRow.Cells("Amount").Value Is DBNull.Value Then
                        If soloNumero(tblMaterialProjects.CurrentRow.Cells("Amount").Value) Then
                            datosMaterial.Add(tblMaterialProjects.CurrentRow.Cells("Amount").Value)
                        Else
                            mensaje = If(mensaje = "", "Check the 'Amount' Cell, it only permit numbers.", vbCrLf + "Check the 'Amount' Cell, it only permit numbers.")
                        End If
                    Else
                        mensaje = If(mensaje = "", "Check the 'Amount' Cell.", vbCrLf + "Check the 'Amount' Cell.")
                    End If
                    If tblMaterialProjects.CurrentRow.Cells("Material Code").Value IsNot DBNull.Value Then
                        For Each row As DataRow In listIdsMaterial.Rows
                            Dim arrayRow() As String = row.ItemArray(1).ToString.Split(" ")
                            Dim arrayMatTbl() As String = tblMaterialProjects.CurrentRow.Cells("Material Code").Value.ToString.Split(" ")
                            If arrayMatTbl(0) = arrayRow(0) Then
                                datosMaterial.Add(row.Item(0))
                                Exit For
                            End If
                        Next
                    Else
                        mensaje = If(mensaje = "", "Check the 'Material Code' Cell.", vbCrLf + "Check the 'Material Code' Cell.")
                    End If
                    If tblMaterialProjects.CurrentRow.Cells("Hours").Value IsNot DBNull.Value Then
                        datosMaterial.Add(tblMaterialProjects.CurrentRow.Cells("Hours").Value)
                    Else
                        datosMaterial.Add("0")
                    End If
                    If tblMaterialProjects.CurrentRow.Cells("Description").Value IsNot DBNull.Value Then
                        datosMaterial.Add(tblMaterialProjects.CurrentRow.Cells("Description").Value)
                    Else
                        datosMaterial.Add("")
                    End If
                    If mensaje <> "" Then
                        MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        If datosMaterial(0) = "" Then 'insert
                            mtdJobs.insertMaterialUsed(datosMaterial)
                            mtdJobs.buscarMaterialesPorProyecto(tblMaterialProjects, idAuxWO, task)
                            calcularValores()
                        Else 'update
                            mtdJobs.updateMaterialUsed(datosMaterial)
                            mtdJobs.buscarMaterialesPorProyecto(tblMaterialProjects, idAuxWO, task)
                            calcularValores()
                        End If
                    End If
            End Select
        End If
    End Sub

    Private Sub actualizarMateriales(ByVal fila As Integer)
        Dim mensaje As String = ""
        Dim datosMaterial As New List(Of String)
        If Not tblMaterialProjects.Rows(fila).Cells("idMaterialUsed").Value Is DBNull.Value Then
            datosMaterial.Add(tblMaterialProjects.Rows(fila).Cells("idMaterialUsed").Value)
        Else
            datosMaterial.Add("")
        End If
        If tblMaterialProjects.Rows(fila).Cells("Date").Value IsNot DBNull.Value Then
            datosMaterial.Add(validaFechaParaSQl(tblMaterialProjects.Rows(fila).Cells("Date").Value))
        Else
            mensaje = If(mensaje = "", "Please choose a Date.", vbCrLf + "Please choose a Date")
        End If
        datosMaterial.Add(pjt.idAux) 'idAuxTask
        If Not tblMaterialProjects.Rows(fila).Cells("Amount").Value Is DBNull.Value Then
            If soloNumero(tblMaterialProjects.Rows(fila).Cells("Amount").Value) Then
                datosMaterial.Add(tblMaterialProjects.Rows(fila).Cells("Amount").Value)
            Else
                mensaje = If(mensaje = "", "Check the 'Amount' Cell, it only permit numbers.", vbCrLf + "Check the 'Amount' Cell, it only permit numbers.")
            End If
        Else
            mensaje = If(mensaje = "", "Check the 'Amount' Cell.", vbCrLf + "Check the 'Amount' Cell.")
        End If
        mtdJobs.llenarTablaMaterialsIds(listIdsMaterial)
        If tblMaterialProjects.Rows(fila).Cells("Material Code").GetType.Name = "DataGridViewComboBoxCell" Then
            If tblMaterialProjects.Rows(fila).Cells("Material Code").Value IsNot DBNull.Value Then
                For Each row As DataRow In listIdsMaterial.Rows
                    Dim arrayRow() As String = row.ItemArray(1).ToString.Split(" ")
                    Dim arrayMatTbl() As String = tblMaterialProjects.Rows(fila).Cells("Material Code").Value.ToString.Split(" ")
                    If arrayMatTbl(0) = arrayRow(0) Or arrayMatTbl(1) = arrayRow(0) Then
                        datosMaterial.Add(row.Item(0))
                        Exit For
                    End If
                Next
            Else
                mensaje = If(mensaje = "", "Check the 'Material Code' Cell.", vbCrLf + "Check the 'Material Code' Cell.")
            End If
        ElseIf tblMaterialProjects.Rows(fila).Cells("Material Code").Value.ToString() IsNot "" Then
            For Each row As DataRow In listIdsMaterial.Rows
                Dim arrayRow() As String = row.ItemArray(1).ToString.Split(" ")
                Dim arrayMatTbl() As String = tblMaterialProjects.Rows(fila).Cells("Material Code").Value.ToString.Split(" ")
                If arrayMatTbl(0) = arrayRow(0) Then
                    datosMaterial.Add(row.Item(0))
                    Exit For
                End If
            Next
        Else
            mensaje = If(mensaje = "", "Check the 'Material Code' Cell.", vbCrLf + "Check the 'Material Code' Cell.")
            datosMaterial.Add("")
        End If

        'If tblMaterialProjects.Rows(fila).Cells("Material Code").Value IsNot DBNull.Value Then
        '    For Each row As DataRow In listIdsMaterial.Rows
        '        If row.Item(1) = tblMaterialProjects.Rows(fila).Cells("Material Code").Value Then
        '            datosMaterial.Add(row.Item(0))
        '            Exit For
        '        End If
        '    Next
        'Else
        '    mensaje = If(mensaje = "", "Check the 'Material Code' Cell.", vbCrLf + "Check the 'Material Code' Cell.")
        'End If
        If tblMaterialProjects.CurrentRow.Cells("Hours").Value IsNot DBNull.Value Then
            datosMaterial.Add(tblMaterialProjects.CurrentRow.Cells("Hours").Value)
        Else
            datosMaterial.Add("0")
        End If

        If tblMaterialProjects.Rows(fila).Cells("Description").Value IsNot DBNull.Value Then
            datosMaterial.Add(tblMaterialProjects.Rows(fila).Cells("Description").Value)
        Else
            datosMaterial.Add("")
        End If
        If mensaje <> "" Then
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If datosMaterial(0) = "" Then 'insert
                mtdJobs.insertMaterialUsed(datosMaterial)
                'mtdJobs.buscarMaterialesPorProyecto(tblMaterialProjects, idAuxWO, task)
                'calcularValores()
            Else 'update
                mtdJobs.updateMaterialUsed(datosMaterial)
                'mtdJobs.buscarMaterialesPorProyecto(tblMaterialProjects, idAuxWO, task)
                'calcularValores()
            End If
        End If
    End Sub
    Dim listRowMaterialCopy As New List(Of String())
    Private Sub tblMaterialProjects_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tblMaterialProjects.KeyPress
        If Asc(e.KeyChar) = 3 Then
            listRowMaterialCopy.Clear()
            For Each row As DataGridViewRow In tblMaterialProjects.SelectedRows
                Dim dataCells() As String = {row.Cells("Date").Value.ToString(), row.Cells("Work Order").Value.ToString(), row.Cells("Amount").Value.ToString(), row.Cells("Material Code").Value.ToString(), row.Cells("Description").Value.ToString()}
                listRowMaterialCopy.Add(dataCells)
            Next
        ElseIf Asc(e.KeyChar) = 22 Then
            If listRowMaterialCopy.Count > 0 Then
                pegarFilas(listRowMaterialCopy, tblMaterialProjects)
                mtdJobs.llenarTablaMaterialsIds(listIdsMaterial)
            End If
        End If
    End Sub
End Class
