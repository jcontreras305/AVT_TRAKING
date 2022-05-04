
Imports System.ComponentModel

Public Class MainFrom
    Public imageClientLogin As Image
    Private Sub BtnMaterials_Click(sender As Object, e As EventArgs) Handles btnMaterials.Click
        OpenFormPanel(Of Materials)()
        'Dim a As New Materials
        'a.Show()

    End Sub

    Private Sub BtnClients_Click(sender As Object, e As EventArgs) Handles btnClients.Click
        OpenFormPanel1(Of Clients)()
    End Sub

    Private Sub btnEmployees_Click(sender As Object, e As EventArgs) Handles btnEmployees.Click
        OpenFormPanel(Of Employees)()
        'Dim a As New Employees
        'a.Show()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnWorkCodes.Click
        OpenFormPanel2(Of ProjectsClients)()
        'a.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Dim a As New Login
        'a.Show()
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

    Private Sub OpenFormPanel1(Of miForm As {Clients, New})()
        Dim FormPanel As Form
        FormPanel = PanelChildForm.Controls.OfType(Of miForm)().FirstOrDefault()
        If FormPanel Is Nothing Then
            Dim newFrom = New miForm()
            newFrom.btnSelectClient.Visible = False
            FormPanel = newFrom
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

    Private Sub OpenFormPanel2(Of Miform As {ProjectsClients, New})()
        Dim FormPanel As Form
        FormPanel = PanelChildForm.Controls.OfType(Of Miform)().FirstOrDefault()

        If FormPanel Is Nothing Then
            Dim newPC = New Miform()
            If imageClientLogin IsNot Nothing Then
                newPC.pcbLogoPC.Image = imageClientLogin
            End If
            FormPanel = newPC
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

    Private Sub MainFrom_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Dim a As New Login
        a.Show()
    End Sub

    Private Sub btnReports_Click(sender As Object, e As EventArgs) Handles btnReports.Click
        OpenFormPanel(Of ReportsMenu)()
        'Dim rpm As New ReportsMenu
        'rpm.ShowDialog()
    End Sub

    Private Sub btnEstimation_Click(sender As Object, e As EventArgs) Handles btnEstimation.Click
        OpenFormPanel3(Of MenuEstimation)()
    End Sub

    Private Sub OpenFormPanel3(Of Miform As {MenuEstimation, New})()
        Dim FormPanel As Form
        FormPanel = PanelChildForm.Controls.OfType(Of Miform)().FirstOrDefault()

        If FormPanel Is Nothing Then
            Dim newPC = New Miform()
            FormPanel = newPC
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