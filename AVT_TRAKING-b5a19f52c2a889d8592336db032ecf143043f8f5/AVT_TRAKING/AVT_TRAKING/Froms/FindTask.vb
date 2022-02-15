Imports System.Runtime.InteropServices
Public Class FindTask
    Public FindElement, Element, IdClient As String
    Dim tblProjects As New DataTable
    Dim tblTask As New DataTable
    Dim mtdJobs As New MetodosJobs
    Dim mtdEmployees As New MetodosEmployees
    Dim mtdScaffold As New MetodosScaffold
    Dim pointElement As New Point(136, 14)
    Private Sub FindTask_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If FindElement IsNot Nothing Then
            cmbFindElement.SelectedItem = cmbFindElement.Items(cmbFindElement.FindString(FindElement))
        Else
            'txtElement.Visible = False
            cmbElement.Visible = False
            sprElement.Visible = False
            mtpElement.Visible = False
        End If
        txtElement.Location = pointElement
        cmbElement.Location = pointElement
        sprElement.Location = pointElement
        mtpElement.Location = pointElement

    End Sub
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs)
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub cmbFindElement_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFindElement.SelectedIndexChanged
        Me.Size = New System.Drawing.Size(478, 144)
        Select Case cmbFindElement.Text
            Case "Job No"
                ocultarElementos(cmbElement)
                mtdJobs.llenarComboJob(cmbElement, IdClient)
                cmbElement.DropDownWidth = 200
            Case "Client"
                ocultarElementos(cmbElement)
                llenarComboClientsReports(cmbElement)
                cmbElement.DropDownWidth = 200
            Case "Work Order"
                ocultarElementos(txtElement)
            Case "Task"
                ocultarElementos(cmbElement)
                tblTask = mtdScaffold.llenarComboWO(cmbElement, IdClient)
                cmbElement.DropDownWidth = 350
            Case "Equipament"
                ocultarElementos(txtElement)
            Case "Project Manager"
                ocultarElementos(cmbElement)
                mtdEmployees.llenarCmbEmpleadosManager(cmbElement)
                cmbElement.DropDownWidth = 200
            Case "Client PO"
                ocultarElementos(cmbElement)
                mtdJobs.llenarComboClientPO(cmbElement, IdClient)
                cmbElement.DropDownWidth = 200
            Case "Project Description"
                ocultarElementos(txtElement)
            Case "Est. Total Billing"
                ocultarElementos(sprElement)
                sprElement.DecimalPlaces = 2
                sprElement.Maximum = 10000000
            Case "Begin Date"
                ocultarElementos(txtElement)
            Case "End Date"
                ocultarElementos(txtElement)
            Case "Hrs Estamate"
                ocultarElementos(sprElement)
                sprElement.DecimalPlaces = 0
                sprElement.Maximum = 10000000
            Case "Exp Code"
                ocultarElementos(cmbElement)
            Case "Account No."
                ocultarElementos(txtElement)
            Case "Complete"
                ocultarElementos(cmbElement)
                cmbElement.Items.Clear()
                cmbElement.Items.Add("Complete")
                cmbElement.Items.Add("Not Complete")
                cmbElement.DropDownWidth = 200
            Case "%Complete"
                ocultarElementos(sprElement)
                sprElement.DecimalPlaces = 0
                sprElement.Maximum = 100
            Case Else
                'txtElement.Visible = False
                cmbElement.Visible = False
                sprElement.Visible = False
                mtpElement.Visible = False
        End Select
    End Sub
    Private Function ocultarElementos(ByVal element As Object) As Boolean
        txtElement.Visible = False
        cmbElement.Visible = False
        sprElement.Visible = False
        mtpElement.Visible = False
        cmbElement.Text = ""
        txtElement.Text = ""
        mtpElement.SelectionStart = System.DateTime.Today
        sprElement.Value = 0
        If element.GetType = txtElement.GetType Then
            txtElement.Visible = True
        ElseIf element.GetType = cmbFindElement.GetType Then
            cmbElement.Visible = True
        ElseIf element.GetType = mtpElement.GetType Then
            mtpElement.Visible = True
        ElseIf element.GetType = sprElement.GetType Then
            sprElement.Visible = True
        End If
        Return True
    End Function
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(hWnd As IntPtr, wMsg As Integer, wParam As Integer, lParam As Integer)
    End Sub

    Private Sub txtElement_DoubleClick(sender As Object, e As EventArgs) Handles txtElement.DoubleClick
        Select Case cmbFindElement.Text
            Case "Begin Date"
                ocultarElementos(mtpElement)
                Me.Size = New System.Drawing.Size(478, 260)
            Case "End Date"
                ocultarElementos(mtpElement)
                Me.Size = New System.Drawing.Size(478, 260)
            Case Else
                Me.Size = New System.Drawing.Size(478, 144)
        End Select
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        Try
            Dim consulta As String = ""
            lblMessage.Text = "Message: "
            Select Case cmbFindElement.Text
                Case "Job No"
                    If soloNumero(cmbElement.Text) Then
                        consulta = " where jb.jobNo = " + cmbElement.Text
                    Else
                        MessageBox.Show("The element contains invalid characters. Check the information.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Select
                    End If
                    mtdJobs.consultaWOFind(consulta, tblProjects, IdClient)
                Case "Client"
                    If cmbElement.Text <> cmbElement.SelectedItem Then
                        Dim array() As String = cmbElement.Text.Split(" ")
                        If array.Length = 2 Then
                            consulta = "(cl.companyName like '%" + array(0) + "%' or CONVERT(nvarchar, cl.numberClient) like '%" + array(0) + "%') or (cl.companyName like '%" + array(2) + "%' or CONVERT(nvarchar, cl.numberClient) like '%" + array(2) + "%')"
                        ElseIf array.Length = 1 Then
                            consulta = "(cl.companyName like '%" + array(0) + "%' or CONVERT(nvarchar, cl.numberClient) like '%" + array(0) + "%')"
                        ElseIf array.Length > 2 Then
                            MessageBox.Show("More than two Elements was found. Check the information" + vbCrLf + "(You should write the 'Work Order' 'space' or '-' and optionally the Task Code)", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Select
                        End If
                    Else
                        Dim array() As String = cmbElement.SelectedItem.Split(" ")
                        If array.Length = 2 Then
                            consulta = "where (cl.companyName like '%" + array(0) + "%' or CONVERT(nvarchar, cl.numberClient) like '%" + array(0) + "%') or (cl.companyName like '%" + array(1) + "%' or CONVERT(nvarchar, cl.numberClient) like '%" + array(1) + "%')"
                        ElseIf array.Length = 1 Then
                            consulta = "where (cl.companyName like '%" + array(0) + "%' or CONVERT(nvarchar, cl.numberClient) like '%" + array(0) + "%')"
                        ElseIf array.Length > 2 Then
                            MessageBox.Show("More than two Elements was found. Check the information" + vbCrLf + "(You should write the 'Work Order' 'space' or '-' and optionally the Task Code)", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Select
                        End If
                    End If
                    mtdJobs.consultaWOFind(consulta, tblProjects, "")
                    If tblProjects.Rows.Count > 0 Then
                        lblMessage.Text = "Message: " + tblProjects.Rows.Count.ToString() + " Projects was found."
                    Else
                        lblMessage.Text = "Message: No one project was found."
                    End If
                Case "Work Order"
                    Dim array() As String = txtElement.Text.Replace("-", " ").Split(" ")
                    If array.Length = 2 Then
                        consulta = "where (wo.idWO like '%" + array(0) + "%' and tk.task like '%" + array(1) + "%')"
                    ElseIf array.Length = 1 Then
                        consulta = "where (wo.idWO like '%" + array(0) + "%')"
                    ElseIf array.Length > 2 Then
                        MessageBox.Show("More than two Elements was found. Check the information" + vbCrLf + "(You should write the 'Work Order' 'space' or '-' and optionally the Task Code)", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Select
                    End If
                    mtdJobs.consultaWOFind(consulta, tblProjects, IdClient)
                    If tblProjects.Rows.Count > 0 Then
                        lblMessage.Text = "Message: " + tblProjects.Rows.Count.ToString() + " Projects was found."
                    End If
                Case "Task"
                    Dim array() As String = {"%"}
                    If cmbElement.SelectedItem = cmbElement.Text Then
                        For Each row As DataRow In tblTask.Rows()
                            Dim datos() = cmbElement.SelectedItem.ToString().Split(" ")
                            If datos(0) = row.ItemArray(0) Then
                                datos(0).ToString.Replace("-", " ").Split(" ")
                                array = datos(0).ToString.Replace("-", " ").Split(" ")
                                Exit For
                            End If
                        Next
                    Else
                        array = cmbElement.Text.Replace("-", " ").Split(" ")
                    End If
                    If array.Length = 2 Then
                        consulta = "where (wo.idWO like '%" + array(0) + "%' and tk.task like '%" + array(1) + "%')"
                    ElseIf array.Length = 1 Then
                        consulta = "where (tk.task like '%" + array(0) + "%')"
                    ElseIf array.Length > 2 Then
                        MessageBox.Show("More than two Elements was found. Check the information" + vbCrLf + "(You should write the 'Work Order' 'space' or '-' and optionally the Task Code)")
                        Exit Select
                    End If
                    mtdJobs.consultaWOFind(consulta, tblProjects, IdClient)
                Case "Equipament"
                    consulta = "where tk.equipament like '%" + txtElement.Text + "%'"
                    mtdJobs.consultaWOFind(consulta, tblProjects, IdClient)
                Case "Project Manager"
                    consulta = "where tk.manager like '%" + cmbElement.Text + "%'"
                    mtdJobs.consultaWOFind(consulta, tblProjects, IdClient)
                Case "Client PO"
                    consulta = "where CONVERT(nvarchar, po.idPO) like '%" + cmbElement.Text + "%'"
                    mtdJobs.consultaWOFind(consulta, tblProjects, IdClient)
                Case "Project Description"
                    consulta = "where tk.description like '%" + txtElement.Text + "%' "
                    mtdJobs.consultaWOFind(consulta, tblProjects, IdClient)
                Case "Est. Total Billing"
                    consulta = "where convert(nvarchar,tk.estTotalBilling) like '%" + sprElement.Value.ToString() + "%'"
                    mtdJobs.consultaWOFind(consulta, tblProjects, IdClient)
                Case "Begin Date"
                    If txtElement.Visible = True Then
                        consulta = "where tk.beginDate between '" + validaFechaParaSQl(txtElement.Text) + "' and '" + validaFechaParaSQl(txtElement.Text) + "'"
                    ElseIf mtpElement.Visible = True Then
                        consulta = "where tk.beginDate between '" + validaFechaParaSQl(mtpElement.SelectionStart.ToShortDateString.ToString()) + "' and '" + validaFechaParaSQl(mtpElement.SelectionEnd.ToShortDateString.ToString()) + "'"
                    End If
                    mtdJobs.consultaWOFind(consulta, tblProjects, IdClient)
                Case "End Date"
                    If txtElement.Visible = True Then
                        consulta = "where tk.endDate between '" + validaFechaParaSQl(txtElement.Text) + "' and '" + validaFechaParaSQl(txtElement.Text) + "'"
                    ElseIf mtpElement.Visible = True Then
                        consulta = "where tk.endDate between '" + validaFechaParaSQl(mtpElement.SelectionStart.ToShortDateString.ToString()) + "' and '" + validaFechaParaSQl(mtpElement.SelectionEnd.ToShortDateString.ToString()) + "'"
                    End If
                    mtdJobs.consultaWOFind(consulta, tblProjects, IdClient)
                Case "Hrs Estamate"
                    consulta = "where tk.estimateHours = " + sprElement.Value.ToString() + ""
                    mtdJobs.consultaWOFind(consulta, tblProjects, IdClient)
                Case "Exp Code"
                    consulta = "where tk.expCode like '%" + cmbElement.Text + "%'"
                    mtdJobs.consultaWOFind(consulta, tblProjects, IdClient)
                Case "Account No."
                    consulta = "where tk.accountNum like '%" + txtElement.Text + "%'"
                    mtdJobs.consultaWOFind(consulta, tblProjects, IdClient)
                Case "Complete"
                    Dim status As Integer = If(cmbElement.SelectedIndex = 0, 1, 0)
                    consulta = "where tk.status = '" + status.ToString() + "'"
                    mtdJobs.consultaWOFind(consulta, tblProjects, IdClient)
                Case "%Complete"
                    consulta = "where tk.percentComplete = " + sprElement.Value.ToString() + ""
                    mtdJobs.consultaWOFind(consulta, tblProjects, IdClient)
            End Select
            If tblProjects.Rows.Count > 0 Then
                lblMessage.Text = "Message: " + tblProjects.Rows.Count.ToString() + " Projects was found."
            Else
                lblMessage.Text = "Message: No one project was found."
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Private Sub TitleBar_MouseMove(sender As Object, e As MouseEventArgs) Handles TitleBar.MouseMove
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Try
            Dim pc As ProjectsCosts = CType(Owner, ProjectsCosts)
            If DialogResult.Yes = MessageBox.Show("Are you sure to update the searching?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                pc.tablasDeTareas = tblProjects
                pc.flagFindElement = True
                Me.Close()
            Else
                pc.flagFindElement = False
                Me.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class