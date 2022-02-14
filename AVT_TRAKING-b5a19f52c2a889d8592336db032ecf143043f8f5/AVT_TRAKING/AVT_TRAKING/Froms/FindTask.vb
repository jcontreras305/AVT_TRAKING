Public Class FindTask
    Public FindElement, Element, IdClient As String
    Dim tblProjects As New DataTable
    Dim mtdJobs As New MetodosJobs
    Dim mtdEmployees As New MetodosEmployees
    Dim mtdScaffold As New MetodosScaffold
    Dim pointElement As New Point(180, 15)
    Private Sub FindTask_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbFindElement.SelectedItem = cmbFindElement.Items(cmbFindElement.FindString(FindElement))
        txtElement.Location = pointElement
        cmbElement.Location = pointElement
        dtpElement.Location = pointElement
        sprElement.Location = pointElement
    End Sub
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnMaximize_Click(sender As Object, e As EventArgs) Handles btnMaximize.Click
        WindowState = FormWindowState.Normal
        btnRestore.Visible = False
        btnMaximize.Visible = True
    End Sub

    Private Sub cmbFindElement_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFindElement.SelectedIndexChanged
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
                mtdScaffold.llenarComboWO(cmbElement, IdClient)
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
            Case "Begin Date"
                ocultarElementos(dtpElement)
            Case "End Date"
                ocultarElementos(dtpElement)
            Case "Hrs Estamate"
                ocultarElementos(sprElement)
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
        End Select
    End Sub
    Private Function ocultarElementos(ByVal element As Object) As Boolean
        txtElement.Visible = False
        cmbElement.Visible = False
        dtpElement.Visible = False
        sprElement.Visible = False
        cmbElement.Text = ""
        txtElement.Text = ""
        dtpElement.Value = System.DateTime.Today
        sprElement.Value = 0
        If element.GetType = txtElement.GetType Then
            txtElement.Visible = True
        ElseIf element.GetType = cmbFindElement.GetType Then
            cmbElement.Visible = True
        ElseIf element.GetType = dtpElement.GetType Then
            dtpElement.Visible = True
        ElseIf element.GetType = sprElement.GetType Then
            sprElement.Visible = True
        End If
        Return True
    End Function
    Private Sub btnRestore_Click(sender As Object, e As EventArgs)
        MaximizedBounds = Screen.FromHandle(Me.Handle).WorkingArea
        WindowState = FormWindowState.Maximized
        btnMaximize.Visible = False
        btnRestore.Visible = True
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.Close()
    End Sub


End Class