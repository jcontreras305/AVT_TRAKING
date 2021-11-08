
Public Class MainFrom
    Private Sub BtnMaterials_Click(sender As Object, e As EventArgs) Handles btnMaterials.Click
        OpenFormPanel(Of Materials)()
        'Dim a As New Materials
        'a.Show()

    End Sub

    Private Sub BtnClients_Click(sender As Object, e As EventArgs) Handles btnClients.Click
        OpenFormPanel(Of Clients)()
        Dim a As New Clients
        a.btnSelectClient.Visible = False
        a.btnSelectClient.Enabled = False
        'a.Show()
    End Sub

    Private Sub btnEmployees_Click(sender As Object, e As EventArgs) Handles btnEmployees.Click
        OpenFormPanel(Of Employees)()
        'Dim a As New Employees
        'a.Show()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnWorkCodes.Click
        OpenFormPanel(Of ProjectsClients)()
        Dim a As New ProjectsClients
        'a.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim a As New Login
        a.Show()
        Me.Close()

    End Sub

    Private Sub tbnoOthers_Click(sender As Object, e As EventArgs) Handles tbnoOthers.Click
        OpenFormPanel(Of Others)()
        Dim a As New Others
        'a.Show()
    End Sub

    Private Sub pnlImage_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs)
        Application.Exit()
    End Sub



    Private Sub MainFrom_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    'open form
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