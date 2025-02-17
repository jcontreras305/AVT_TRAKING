Imports System.Runtime.InteropServices
Imports System.Data.SqlClient

Public Class WrongHours
    Dim mtd As New wrongHoursMetodos

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub btnMinimize_Click(sender As Object, e As EventArgs) Handles btnMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub btnRestore_Click(sender As Object, e As EventArgs) Handles btnRestore.Click
        WindowState = FormWindowState.Normal
        btnRestore.Visible = False
        btnMaximize.Visible = True
    End Sub
    Private Sub btnMaximize_Click(sender As Object, e As EventArgs) Handles btnMaximize.Click
        MaximizedBounds = Screen.FromHandle(Me.Handle).WorkingArea
        WindowState = FormWindowState.Maximized
        btnMaximize.Visible = False
        btnRestore.Visible = True
    End Sub
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(hWnd As IntPtr, wMsg As Integer, wParam As Integer, lParam As Integer)
    End Sub
    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles TitleBar.MouseMove
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        Dim clientId, jobNo, employeeNum As String
        If Not chbAllClient.Checked Then 'look for a client
            If cmbClients.SelectedIndex >= 0 Then 'verify if is selected a client
                If Not chbAllJobs.Checked Then 'look for a job
                    If cmbJob.SelectedIndex >= 0 Then 'virify if is selected a job
                        Dim arrayCl() As String = cmbClients.Items(cmbClients.SelectedIndex).ToString.Split(" ")
                        clientId = arrayCl(0)
                        jobNo = cmbJob.Items(cmbJob.SelectedIndex).ToString
                        If Not chbAllEmployees_Material.Checked Then 'look for a employee
                            If cmbEmployees_Material.SelectedIndex >= 0 Then 'verify if is selected an employee or a Material
                                Dim arrayEmp() As String = cmbEmployees_Material.Items(cmbEmployees_Material.SelectedIndex).ToString.Split(" ")
                                employeeNum = arrayEmp(0)
                                If Not chbAllWO.Checked Then
                                    If txtWO.Text <> "" Then
                                        'look for all 
                                        If tbcControl.SelectedTab.TabIndex = tbpHours.TabIndex Then 'hours
                                            mtd.selectHours(tblHours, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), clientId, cmbFindDate.SelectedIndex, jobNo, employeeNum, txtWO.Text, True, True, True, True)
                                        ElseIf tbcControl.SelectedTab.TabIndex = tbpPerdiem.TabIndex Then 'perdiem
                                            mtd.selectPerdiem(tblPerdiem, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), clientId, cmbFindDate.SelectedIndex, jobNo, employeeNum, txtWO.Text, True, True, True, True)
                                        ElseIf tbcControl.SelectedTab.TabIndex = tbpFakeHours.TabIndex Then 'FakeHours
                                            mtd.selectFakeHours(tblFakeHours, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), clientId, cmbFindDate.SelectedIndex, jobNo, employeeNum, txtWO.Text, True, True, True, True)
                                        Else 'materials
                                            mtd.selectMaterial(tblMaterials, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), clientId, cmbFindDate.SelectedIndex, jobNo, employeeNum, txtWO.Text, True, True, True, True)
                                        End If
                                    Else 'Don't exist a WO to find
                                        MessageBox.Show("Please assig a Work Order to Find or check the option All WO.")
                                    End If
                                Else
                                    'look for all but not look for WO 
                                    If tbcControl.SelectedTab.TabIndex = tbpHours.TabIndex Then 'hours
                                        mtd.selectHours(tblHours, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), clientId, cmbFindDate.SelectedIndex, jobNo, employeeNum, "", True, True, True, False)
                                    ElseIf tbcControl.SelectedTab.TabIndex = tbpPerdiem.TabIndex Then  'perdiem
                                        mtd.selectPerdiem(tblPerdiem, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), clientId, cmbFindDate.SelectedIndex, jobNo, employeeNum, "", True, True, True, False)
                                    ElseIf tbcControl.SelectedTab.TabIndex = tbpFakeHours.TabIndex Then 'fakeHours 
                                        mtd.selectFakeHours(tblFakeHours, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), clientId, cmbFindDate.SelectedIndex, jobNo, employeeNum, "", True, True, True, False)
                                    Else 'Materials
                                        mtd.selectMaterial(tblMaterials, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), clientId, cmbFindDate.SelectedIndex, jobNo, employeeNum, "", True, True, True, False)
                                    End If
                                End If
                            Else
                                If tbcControl.SelectedTab.TabIndex < 3 Then
                                    MessageBox.Show("Message", "Please select a Employee or check the option All Employees")
                                Else
                                    MessageBox.Show("Message", "Please select a Material or check the option All Material")
                                End If
                            End If
                        Else 'without employee
                            If Not chbAllWO.Checked Then
                                If txtWO.Text <> "" Then 'witout employee but with wo,client and job 
                                    If tbcControl.SelectedTab.TabIndex = tbpHours.TabIndex Then 'hours
                                        mtd.selectHours(tblHours, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), clientId, cmbFindDate.SelectedIndex, jobNo, "", txtWO.Text, True, True, False, True)
                                    ElseIf tbcControl.SelectedTab.TabIndex = tbpPerdiem.TabIndex Then 'perdiem
                                        mtd.selectPerdiem(tblPerdiem, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), clientId, cmbFindDate.SelectedIndex, jobNo, "", txtWO.Text, True, True, False, True)
                                    ElseIf tbcControl.SelectedTab.TabIndex = tbpFakeHours.TabIndex Then 'FakeHours
                                        mtd.selectFakeHours(tblFakeHours, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), clientId, cmbFindDate.SelectedIndex, jobNo, "", txtWO.Text, True, True, False, True)
                                    Else 'Material
                                        mtd.selectMaterial(tblMaterials, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), clientId, cmbFindDate.SelectedIndex, jobNo, "", txtWO.Text, True, True, False, True)
                                    End If
                                Else 'without employee and WO but using client and job
                                    MessageBox.Show("Please assig a Work Order to Find or check the option All WO.")
                                End If
                            Else 'without employee and WO but using client and job
                                If tbcControl.SelectedTab.TabIndex = tbpHours.TabIndex Then 'hours
                                    mtd.selectHours(tblHours, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), clientId, cmbFindDate.SelectedIndex, jobNo, "", "", True, True, False, False)
                                ElseIf tbcControl.SelectedTab.TabIndex = tbpPerdiem.TabIndex Then 'perdiem
                                    mtd.selectPerdiem(tblPerdiem, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), clientId, cmbFindDate.SelectedIndex, jobNo, "", "", True, True, False, False)
                                ElseIf tbcControl.SelectedTab.TabIndex = tbpFakeHours.TabIndex Then 'FakeHours
                                    mtd.selectFakeHours(tblFakeHours, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), clientId, cmbFindDate.SelectedIndex, jobNo, "", "", True, True, False, False)
                                Else 'Mateials
                                    mtd.selectMaterial(tblMaterials, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), clientId, cmbFindDate.SelectedIndex, jobNo, "", "", True, True, False, False)
                                End If
                            End If
                        End If
                    Else
                        MessageBox.Show("Message", "Please select a Job or check the option All Jobs.")
                    End If
                Else
                    ''buscar solo por cliente y fecha
                    Dim arrayCl() As String = cmbClients.Items(cmbClients.SelectedIndex).ToString.Split(" ")
                    clientId = arrayCl(0)
                    If Not chbAllEmployees_Material.Checked Then
                        If cmbEmployees_Material.SelectedIndex > 0 Then 'with employee
                            Dim arrayEmp() As String = cmbEmployees_Material.Items(cmbEmployees_Material.SelectedIndex).ToString.Split(" ")
                            employeeNum = arrayEmp(0)
                            If Not chbAllWO.Checked Then
                                If txtWO.Text <> "" Then 'look for client, wo and employee
                                    If tbcControl.SelectedTab.TabIndex = tbpHours.TabIndex Then 'hours
                                        mtd.selectHours(tblHours, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), clientId, cmbFindDate.SelectedIndex, "", employeeNum, txtWO.Text, True, False, True, True)
                                    ElseIf tbcControl.SelectedTab.TabIndex = tbpPerdiem.TabIndex Then 'perdiem
                                        mtd.selectPerdiem(tblPerdiem, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), clientId, cmbFindDate.SelectedIndex, "", employeeNum, txtWO.Text, True, False, True, True)
                                    ElseIf tbcControl.SelectedTab.TabIndex = tbpFakeHours.TabIndex Then 'FakeHours
                                        mtd.selectFakeHours(tblFakeHours, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), clientId, cmbFindDate.SelectedIndex, "", employeeNum, txtWO.Text, True, False, True, True)
                                    Else 'Material
                                        mtd.selectMaterial(tblMaterials, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), clientId, cmbFindDate.SelectedIndex, "", employeeNum, txtWO.Text, True, False, True, True)
                                    End If
                                Else 'only look for client 
                                    MessageBox.Show("Please assig a Work Order to Find or check the option All WO.")
                                End If
                            Else 'only look for client and with employee
                                If tbcControl.SelectedTab.TabIndex = tbpHours.TabIndex Then 'hours
                                    mtd.selectHours(tblHours, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), clientId, cmbFindDate.SelectedIndex, "", employeeNum, "", True, False, True, False)
                                ElseIf tbcControl.SelectedTab.TabIndex = tbpPerdiem.TabIndex Then 'perdiem
                                    mtd.selectPerdiem(tblPerdiem, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), clientId, cmbFindDate.SelectedIndex, "", employeeNum, "", True, False, True, False)
                                ElseIf tbcControl.SelectedTab.TabIndex = tbpFakeHours.TabIndex Then 'FakeHours
                                    mtd.selectFakeHours(tblFakeHours, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), clientId, cmbFindDate.SelectedIndex, "", employeeNum, "", True, False, True, False)
                                Else 'Material
                                    mtd.selectMaterial(tblMaterials, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), clientId, cmbFindDate.SelectedIndex, "", employeeNum, "", True, False, True, False)
                                End If
                            End If
                        Else
                            MessageBox.Show("Please assig a Employee to Find or check the option All Employees.")
                        End If
                    Else 'without employee or Material
                        If Not chbAllWO.Checked Then
                            If txtWO.Text <> "" Then 'look for client and wo 
                                If tbcControl.SelectedTab.TabIndex = tbpHours.TabIndex Then 'hours
                                    mtd.selectHours(tblHours, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), clientId, cmbFindDate.SelectedIndex, "", "", txtWO.Text, True, False, False, True)
                                ElseIf tbcControl.SelectedTab.TabIndex = tbpPerdiem.TabIndex Then 'perdiem
                                    mtd.selectPerdiem(tblPerdiem, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), clientId, cmbFindDate.SelectedIndex, "", "", txtWO.Text, True, False, False, True)
                                ElseIf tbcControl.SelectedTab.TabIndex = tbpFakeHours.TabIndex Then 'FakeHours
                                    mtd.selectFakeHours(tblFakeHours, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), clientId, cmbFindDate.SelectedIndex, "", "", txtWO.Text, True, False, False, True)
                                Else 'Material
                                    mtd.selectMaterial(tblMaterials, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), clientId, cmbFindDate.SelectedIndex, "", "", txtWO.Text, True, False, False, True)
                                End If
                            Else 'only look for client 
                                MessageBox.Show("Please assig a Work Order to Find or check the option All WO.")
                            End If
                        Else 'only look for client 
                            If tbcControl.SelectedTab.TabIndex = tbpHours.TabIndex Then 'hours
                                mtd.selectHours(tblHours, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), clientId, cmbFindDate.SelectedIndex, "", "", "", True, False, False, False)
                            ElseIf tbcControl.SelectedTab.TabIndex = tbpPerdiem.TabIndex Then 'perdiem
                                mtd.selectPerdiem(tblPerdiem, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), clientId, cmbFindDate.SelectedIndex, "", "", "", True, False, False, False)
                            ElseIf tbcControl.SelectedTab.TabIndex = tbpFakeHours.TabIndex Then 'FakeHours
                                mtd.selectFakeHours(tblFakeHours, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), clientId, cmbFindDate.SelectedIndex, "", "", "", True, False, False, False)
                            Else 'Material
                                mtd.selectMaterial(tblMaterials, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), clientId, cmbFindDate.SelectedIndex, "", "", "", True, False, False, False)
                            End If
                        End If
                    End If



                    'If tbcControl.SelectedTab.TabIndex = tbpHours.TabIndex Then
                    '    mtd.selectHours(tblHours, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), clientId, cmbFindDate.SelectedIndex, 0, "", True, False, False)
                    'Else
                    '    'perdiem
                    '    mtd.selectPerdiem(tblPerdiem, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), clientId, cmbFindDate.SelectedIndex, 0, "", True, False, False)
                    'End If
                End If
            Else
                MessageBox.Show("Message", "Please select a Client or check the option All Clients")
            End If
        Else
            If Not chbAllEmployees_Material.Checked Then
                If cmbEmployees_Material.SelectedIndex >= 0 Then
                    ''look for date and employee or Material
                    Dim arrayEmp() As String = cmbEmployees_Material.Items(cmbEmployees_Material.SelectedIndex).ToString.Split(" ")
                    employeeNum = arrayEmp(0)
                    If Not chbAllWO.Checked Then
                        If txtWO.Text <> "" Then
                            If tbcControl.SelectedTab.TabIndex = tbpHours.TabIndex Then
                                mtd.selectHours(tblHours, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), "", cmbFindDate.SelectedIndex, "", employeeNum, txtWO.Text, False, False, True, True)
                            ElseIf tbcControl.SelectedTab.TabIndex = tbpPerdiem.TabIndex Then 'Perdiem
                                mtd.selectPerdiem(tblPerdiem, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), "", cmbFindDate.SelectedIndex, "", employeeNum, txtWO.Text, False, False, True, True)
                            ElseIf tbcControl.SelectedTab.TabIndex = tbpFakeHours.TabIndex Then 'FakeHours
                                mtd.selectFakeHours(tblFakeHours, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), "", cmbFindDate.SelectedIndex, "", employeeNum, txtWO.Text, False, False, True, True)
                            Else 'Material
                                mtd.selectMaterial(tblMaterials, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), "", cmbFindDate.SelectedIndex, "", employeeNum, txtWO.Text, False, False, True, True)
                            End If
                        Else
                            MessageBox.Show("Please assig a Work Order to Find or check the option All WO.")
                        End If
                    Else
                        If tbcControl.SelectedTab.TabIndex = tbpHours.TabIndex Then
                            mtd.selectHours(tblHours, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), "", cmbFindDate.SelectedIndex, "", employeeNum, "", False, False, True, False)
                        ElseIf tbcControl.SelectedTab.TabIndex = tbpPerdiem.TabIndex Then 'Perdiem
                            mtd.selectPerdiem(tblPerdiem, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), "", cmbFindDate.SelectedIndex, "", employeeNum, "", False, False, True, False)
                        ElseIf tbcControl.SelectedTab.TabIndex = tbpFakeHours.TabIndex Then 'FakeHours'
                            mtd.selectFakeHours(tblFakeHours, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), "", cmbFindDate.SelectedIndex, "", employeeNum, "", False, False, True, False)
                        Else
                            mtd.selectMaterial(tblMaterials, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), "", cmbFindDate.SelectedIndex, "", employeeNum, "", False, False, True, False)
                        End If
                    End If
                Else
                    If tbcControl.SelectedTab.TabIndex < 3 Then
                        MessageBox.Show("Message", "Please select a Employee or check the option All Employees")
                    Else
                        MessageBox.Show("Message", "Please select a Material or check the option All Material")
                    End If
                End If
            Else ''buscar solo con fechas 
                If Not chbAllWO.Checked Then
                    If txtWO.Text <> "" Then
                        If tbcControl.SelectedTab.TabIndex = tbpHours.TabIndex Then 'Hours
                            mtd.selectHours(tblHours, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), "", cmbFindDate.SelectedIndex, "", "", txtWO.Text, False, False, False, True)
                        ElseIf tbcControl.SelectedTab.TabIndex = tbpPerdiem.TabIndex Then 'Perdiem
                            mtd.selectPerdiem(tblPerdiem, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), "", cmbFindDate.SelectedIndex, "", "", txtWO.Text, False, False, False, True)
                        ElseIf tbcControl.SelectedTab.TabIndex = tbpFakeHours.TabIndex Then 'Fake Hours
                            mtd.selectFakeHours(tblFakeHours, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), "", cmbFindDate.SelectedIndex, "", "", txtWO.Text, False, False, False, True)
                        Else
                            mtd.selectMaterial(tblMaterials, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), "", cmbFindDate.SelectedIndex, "", "", txtWO.Text, False, False, False, True)
                        End If
                    Else
                        MessageBox.Show("Please assig a Work Order to Find or check the option All WO.")
                    End If
                Else
                    If tbcControl.SelectedTab.TabIndex = tbpHours.TabIndex Then 'hours
                        mtd.selectHours(tblHours, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), "", cmbFindDate.SelectedIndex, "", "", "", False, False, False, False)
                    ElseIf tbcControl.SelectedTab.TabIndex = tbpPerdiem.TabIndex Then 'perdiem  
                        mtd.selectPerdiem(tblPerdiem, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), "", cmbFindDate.SelectedIndex, "", "", "", False, False, False, False)
                    ElseIf tbcControl.SelectedTab.TabIndex = tbpFakeHours.TabIndex Then 'FakeHours
                        mtd.selectFakeHours(tblFakeHours, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), "", cmbFindDate.SelectedIndex, "", "", "", False, False, False, False)
                    Else
                        mtd.selectMaterial(tblMaterials, validaFechaParaSQl(dtpStartDate.Value), validaFechaParaSQl(dtpEndDate.Value), "", cmbFindDate.SelectedIndex, "", "", "", False, False, False, False)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub chbAllJobs_CheckedChanged(sender As Object, e As EventArgs) Handles chbAllJobs.CheckedChanged
        If chbAllJobs.Checked Then
            cmbJob.Enabled = False
            chbAllWO.Checked = True
        Else
            cmbJob.Enabled = True
            If cmbJob.Items.Count > 0 Then
                cmbJob.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub WrongHours_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarComboClientByUser(cmbClients)
        'llenarComboClientsReports(cmbClients)
        cmbFindDate.SelectedIndex = 0
        llenarComboEmployeeReports(cmbEmployees_Material)

    End Sub

    Private Sub chbAllClient_CheckedChanged(sender As Object, e As EventArgs) Handles chbAllClient.CheckedChanged
        If chbAllClient.Checked Then
            cmbClients.Enabled = False
            chbAllJobs.Checked = True
        Else
            cmbClients.Enabled = True
            cmbClients.SelectedIndex = 0
        End If
    End Sub

    Private Sub cmbClients_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClients.SelectedIndexChanged
        Dim arrayCl() As String = cmbClients.Items(cmbClients.SelectedIndex).ToString.Split(" ")
        Dim clientId = arrayCl(0)
        llenarComboJobsReports(cmbJob, clientId)
    End Sub

    Private Sub chbAllEmployees_CheckedChanged(sender As Object, e As EventArgs) Handles chbAllEmployees_Material.CheckedChanged
        cmbEmployees_Material.Enabled = Not chbAllEmployees_Material.Checked
        cmbEmployees_Material.SelectedIndex = 0
    End Sub

    Private Sub btnSelectAll_Click(sender As Object, e As EventArgs) Handles btnSelectAll.Click
        Select Case tbcControl.SelectedIndex
            Case 0
                For Each row As DataGridViewRow In tblHours.Rows
                    row.Selected = True
                Next
            Case 1
                For Each row As DataGridViewRow In tblPerdiem.Rows
                    row.Selected = True
                Next
        End Select
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If DialogResult.Yes = MessageBox.Show("Are you sure to delete the records?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                Select Case tbcControl.SelectedIndex
                    Case 0
                        If mtd.deleteHours(tblHours) Then
                            MsgBox("Successful")
                        Else
                            MsgBox("Error please check the Data")
                        End If
                    Case 1
                        If mtd.deletePerdiem(tblPerdiem) Then
                            MsgBox("Successful")
                        Else
                            MsgBox("Error please check the Data")
                        End If
                    Case 2
                        If mtd.deleteFakeHours(tblFakeHours) Then
                            MsgBox("Successful")
                        Else
                            MsgBox("Error please check the Data")
                        End If
                    Case 3
                        If mtd.deleteMaterial(tblMaterials) Then
                            MsgBox("Successful")
                        Else
                            MsgBox("Error please check the Data")
                        End If
                End Select
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chbAllWO_CheckedChanged(sender As Object, e As EventArgs) Handles chbAllWO.CheckedChanged
        If chbAllWO.Checked Then
            txtWO.Enabled = False
        Else
            txtWO.Enabled = True
        End If
    End Sub

    Private Sub tbcControl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbcControl.SelectedIndexChanged
        If tbcControl.SelectedTab.Name = "tbpMaterials" Then
            lblEmployee.Text = "Material"
            chbAllEmployees_Material.Text = "All Material"
            llenarComboMaterialReports(cmbEmployees_Material)
        Else
            lblEmployee.Text = "Employee"
            chbAllEmployees_Material.Text = "All Employees"
            llenarComboEmployeeReports(cmbEmployees_Material)
        End If
    End Sub
End Class

Public Class wrongHoursMetodos
    Inherits ConnectioDB

    Public Function selectHours(ByVal tbl As DataGridView, ByVal startDate As Date, ByVal endDate As Date, Optional idClient As String = "", Optional dateOption As Integer = 0, Optional job As String = "", Optional Employee As String = "", Optional WO As String = "", Optional allClient As Boolean = False, Optional allJobs As Boolean = False, Optional allEmployee As Boolean = False, Optional allWO As Boolean = False) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select hw.dateWorked as DateWorked, emp.numberEmploye as 'Emlpoyee No',CONCAT( emp.lastName , ', ' , emp.firstName , ' ',emp.middleName) as Employee,
                jb.jobNo 'JobNo', po.idPO as 'Project' , CONCAT(wo.idWO , '-' ,tk.task) as 'Work',
                wc.name as 'WorkCode' , hw.hoursST , hw.hoursOT , hw.hours3 , hw.schedule ,hw.idHorsWorked  from hoursWorked as hw 
                inner join task as tk on tk.idAux = hw.idAux 
                inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO	
                inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
                inner join job as jb on jb.jobNo = po.jobNo
                inner join clients as cl on cl.idClient = jb.idClient 
                inner join workCode as wc on wc.idWorkCode  = hw.idWorkCode and wc.jobNo = jb.jobNo
                inner join employees as emp on emp.idEmployee= hw.idEmployee
                inner join userClientAccess as ua on ua.idClient = cl.idClient
				inner join users as us on us.idUsers = ua.idUsers
                where us.nameUser = '" + userNameMTG + "' and ua.access = 1" + If(allClient, " cl.numberClient = " + idClient + If(allJobs, " and jb.jobNo = " + job, ""), "") + If(dateOption = 1, If(allClient, " and ", "") + " and hw.dateWorked between '" + validaFechaParaSQl(startDate) + "' and '" + validaFechaParaSQl(endDate) + "'", If(allClient, " and ", "") + " hw.dayInserted between '" + validaFechaParaSQl(startDate) + "' and '" + validaFechaParaSQl(endDate) + "'") + If(allEmployee, " and  emp.numberEmploye = " + Employee, "") + If(allWO, " and (CONCAT(wo.idWO , '-' ,tk.task) like '" + WO + "' or CONCAT(wo.idWO , ' ' ,tk.task)like '" + WO + "' ) ", ""), conn)
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                tbl.DataSource = dt
                tbl.Columns(11).Visible = False
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return True
        Finally
            desconectar()
        End Try
    End Function

    Public Function selectMaterial(ByVal tbl As DataGridView, ByVal startDate As Date, ByVal endDate As Date, Optional idClient As String = "", Optional dateOption As Integer = 0, Optional job As String = "", Optional Material As String = "", Optional WO As String = "", Optional allClient As Boolean = False, Optional allJobs As Boolean = False, Optional allMaterial As Boolean = False, Optional allWO As Boolean = False) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select 
mu.idMaterialUsed,
mu.dateMaterial as 'Date Material',
ma.number as 'Material No',
ma.name as 'Material',
CONCAT('$', mu.amount) as 'Amount',
jb.jobNo as 'JobNo',
po.idPO as 'Project', 
CONCAT(wo.idWO , '-',tk.task) as 'Work'
from materialUsed as mu 
left join material as ma on ma.idMaterial = mu.idMaterial
inner join task as tk on tk.idAux = mu.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
inner join job as jb on jb.jobNo = po.jobNo
inner join clients as cl on cl.idClient = jb.idClient
inner join userClientAccess as ua on ua.idClient = cl.idClient
inner join users as us on us.idUsers = ua.idUsers
where us.nameUser = '" + userNameMTG + "' and ua.access = 1 and " + If(allClient, " cl.numberClient = " + idClient + If(allJobs, " and jb.jobNo = " + job, ""), "") + If(dateOption = 1, If(allClient, " and ", "") + " mu.dateMaterial between '" + validaFechaParaSQl(startDate) + "' and '" + validaFechaParaSQl(endDate) + "'", If(allClient, " and ", "") + " mu.dayInserted between '" + validaFechaParaSQl(startDate) + "' and '" + validaFechaParaSQl(endDate) + "'") + If(allMaterial, " and ma.number = " + Material, "") + If(allWO, " and (CONCAT(wo.idWO , '-' ,tk.task) like '" + WO + "' or CONCAT(wo.idWO , ' ' ,tk.task)like '" + WO + "' ) ", ""), conn)
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                tbl.DataSource = dt
                tbl.Columns(0).Visible = False
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function selectFakeHours(ByVal tbl As DataGridView, ByVal startDate As Date, ByVal endDate As Date, Optional idClient As String = "", Optional dateOption As Integer = 0, Optional job As String = "", Optional Employee As String = "", Optional WO As String = "", Optional allClient As Boolean = False, Optional allJobs As Boolean = False, Optional allEmployee As Boolean = False, Optional allWO As Boolean = False) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select 
hw.dateWorked as 'Date Worked',
emp.numberEmploye as 'Employee No',
CONCAT(emp.lastName,', ',emp.firstName, ' ', emp.middleName) as 'Employee',
jb.jobNo as 'JobNo',
po.idPO as 'Project', 
CONCAT(wo.idWO , '-',tk.task) as 'Work',
isnull(wc.name,'') as 'Work Code',
hw.hoursST ,
hw.hoursOT,
hw.hours3,
hw.schedule ,
(select COUNT(*) from expensesUsed as exu where exu.idHorsWorked = hw.idHorsWorked) as 'Expenses Match',
hw.idHorsWorked
from hoursWorked as hw 
left join workCode as wc on wc.idWorkCode = hw.idWorkCode
inner join employees as emp on emp.idEmployee = hw.idEmployee
inner join task as tk on tk.idAux = hw.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
inner join job as jb on jb.jobNo = po.jobNo
inner join clients as cl on cl.idClient = jb.idClient
inner join userClientAccess as ua on ua.idClient = cl.idClient
inner join users as us on us.idUsers = ua.idUsers
where us.nameUser = '" + userNameMTG + "' and ua.access = 1 and  (hw.hoursST + hw.hoursOT + hw.hours3) = 0 " + If(allClient, "and cl.numberClient = " + idClient + If(allJobs, " and jb.jobNo = " + job + If(allWO, " and Concat(wo.idWO , ' ', tk.task) like '" + WO + "' ", "") + " ", If(allWO, " and Concat(wo.idWO , ' ', tk.task) like '" + WO + "' ", "")), "") + If(dateOption = 1, If(allClient, " and ", "") + "and hw.dateWorked between '" + validaFechaParaSQl(startDate) + "' and '" + validaFechaParaSQl(endDate) + "'", If(allClient, " and ", "") + "and hw.dayInserted between '" + validaFechaParaSQl(startDate) + "' and '" + validaFechaParaSQl(endDate) + "'") + If(allEmployee, " and  emp.numberEmploye = " + Employee, ""), conn)
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                tbl.DataSource = dt
                tbl.Columns(12).Visible = False
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function selectPerdiem(ByVal tbl As DataGridView, ByVal startDate As Date, ByVal endDate As Date, Optional idClient As String = "", Optional dateOption As Integer = 0, Optional job As String = "", Optional Employee As String = "", Optional WO As String = "", Optional allClient As Boolean = False, Optional allJobs As Boolean = False, Optional allEmployee As Boolean = False, Optional allWO As Boolean = False) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select exu.description as 'Description',exu.amount as 'Amount $',CONVERT(varchar,exu.dateExpense,101) as 'Date',CONCAT( emp.lastName , ', ' , emp.firstName , ' ',emp.middleName) as Employee,emp.numberEmploye,
jb.jobNo as 'Job No',po.idPO as 'PO',CONCAT(wo.idWO,'-',tk.task) as 'Work',ex.expenseCode as 'Expense Code',(hw.hoursST + hw.hoursOT + hw.hours3) as 'THrs',exu.idExpenseUsed,exu.idHorsWorked
from expensesUsed as exu
inner join hoursWorked as hw on hw.idHorsWorked = exu.idHorsWorked 
inner join expenses as ex on ex.idExpenses = exu.idExpense
inner join employees as emp on emp.idEmployee = exu.idEmployee
inner join task as tk on tk.idAux = exu.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
inner join job as jb on jb.jobNo = po.jobNo
inner join clients as cl on cl.idClient = jb.idClient
inner join userClientAccess as ua on ua.idClient = cl.idClient
inner join users as us on us.idUsers = ua.idUsers
where us.nameUser = '" + userNameMTG + "' and ua.access = 1 and " + If(allClient, " cl.numberClient = " + idClient + If(allJobs, " and jb.jobNo = " + job + If(allWO, " and Concat(wo.idWO , ' ', tk.task) like '" + WO + "' ", "") + " ", If(allWO, " and Concat(wo.idWO , ' ', tk.task) like '" + WO + "' ", "")), "") + If(dateOption = 1, If(allClient, " and ", "") + " hw.dateWorked between '" + validaFechaParaSQl(startDate) + "' and '" + validaFechaParaSQl(endDate) + "'", If(allClient, " and ", "") + " hw.dayInserted between '" + validaFechaParaSQl(startDate) + "' and '" + validaFechaParaSQl(endDate) + "'") + If(allEmployee, " and  emp.numberEmploye = " + Employee, ""), conn)
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                tbl.DataSource = dt
                tbl.Columns(9).Visible = False
                tbl.Columns(10).Visible = False
                tbl.Columns(11).Visible = False
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function deleteHours(ByVal tbl As DataGridView) As Boolean
        Try
            conectar()
            Dim tran As SqlTransaction
            tran = conn.BeginTransaction
            Dim flag As Boolean = True
            For Each row As DataGridViewRow In tbl.SelectedRows
                Dim cmd As New SqlCommand("if (select count( *) from expensesUsed where idHorsWorked = '" + row.Cells(11).Value + "' ) > 0
begin
	delete from expensesUsed where idHorsWorked = '" + row.Cells(11).Value + "'
	delete from hoursWorked where idHorsWorked = '" + row.Cells(11).Value + "'
end
else 
begin
	delete from hoursWorked where idHorsWorked = '" + row.Cells(11).Value + "'
end", conn)
                cmd.Transaction = tran
                If cmd.ExecuteNonQuery Then
                    flag = True
                Else
                    flag = False
                End If
            Next
            If flag Then
                tran.Commit()
                Return True
            Else
                tran.Rollback()
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function deleteMaterial(ByVal tbl As DataGridView) As Boolean
        Dim tran As SqlTransaction
        Try
            conectar()
            tran = conn.BeginTransaction
            Dim flag As Boolean = True
            For Each row As DataGridViewRow In tbl.SelectedRows
                Dim cmd As New SqlCommand("delete from materialUsed where idMaterialUsed = '" + row.Cells(0).Value.ToString() + "'", conn)
                cmd.Transaction = tran
                If cmd.ExecuteNonQuery Then
                    flag = True
                Else
                    flag = False
                End If
            Next
            If flag Then
                tran.Commit()
                Return True
            Else
                tran.Rollback()
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)

            Return False
        Finally
            desconectar()
            tran.Dispose()
        End Try
    End Function
    Public Function deleteFakeHours(ByVal tbl As DataGridView) As Boolean
        Dim tran As SqlTransaction
        Try
            conectar()
            tran = conn.BeginTransaction
            Dim flag As Boolean = True
            For Each row As DataGridViewRow In tbl.SelectedRows
                Dim cmd As New SqlCommand("if ( " + row.Cells(11).Value.ToString() + " = 1 ) 
begin 
	if (select COUNT (*) from expensesUsed where idHorsWorked = '" + row.Cells(12).Value + "')> 1 
	begin
        delete from expensesUsed where idHorsWorked = '" + row.Cells(12).Value + "'
		delete from hoursWorked where idHorsWorked = '" + row.Cells(12).Value + "'
	end
	else 
	begin 
		delete from expensesUsed where idHorsWorked = '" + row.Cells(12).Value + "'
	end 
end
else 
begin
	delete from hoursWorked where idHorsWorked = '" + row.Cells(12).Value + "'
end", conn)
                cmd.Transaction = tran
                If cmd.ExecuteNonQuery Then
                    flag = True
                Else
                    flag = False
                End If
            Next
            If flag Then
                tran.Commit()
                Return True
            Else
                tran.Rollback()
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)

            Return False
        Finally
            desconectar()
            tran.Dispose()
        End Try
    End Function
    Public Function deletePerdiem(ByVal tbl As DataGridView) As Boolean
        Dim tran As SqlTransaction
        Try
            conectar()
            tran = conn.BeginTransaction
            Dim flag As Boolean = True
            For Each row As DataGridViewRow In tbl.SelectedRows
                Dim cmd As New SqlCommand("if ( " + row.Cells(9).Value.ToString() + " = 0 ) 
begin 
	if (select COUNT (*) from expensesUsed where idHorsWorked = '" + row.Cells(11).Value + "')> 1 
	begin 
		delete from expensesUsed where idExpenseUsed = '" + row.Cells(10).Value + "'
	end
	else 
	begin 
		delete from expensesUsed where idExpenseUsed = '" + row.Cells(10).Value + "'
		delete from hoursWorked where idHorsWorked = '" + row.Cells(11).Value + "'
	end 
end
else 
begin
	delete from expensesUsed where idExpenseUsed = '" + row.Cells(10).Value + "'
end", conn)
                cmd.Transaction = tran
                If cmd.ExecuteNonQuery Then
                    flag = True
                Else
                    flag = False
                End If
            Next
            If flag Then
                tran.Commit()
                Return True
            Else
                tran.Rollback()
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)

            Return False
        Finally
            desconectar()
            tran.Dispose()
        End Try
    End Function
End Class