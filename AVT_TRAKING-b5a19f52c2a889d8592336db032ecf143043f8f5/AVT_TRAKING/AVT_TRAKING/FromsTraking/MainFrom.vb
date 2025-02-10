
Imports System.ComponentModel

Public Class MainFrom
    Public imageClientLogin As Image
    Public loginUser As Users
    Public closeMainForm As Boolean = False
    Public arrayButtons() As String = {"Clients", "Employees", "Work Codes", "Material", "Others", "Reports", "Estimation", "Backup", "System"}
    Private Sub MainFrom_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Function validAccess(ByVal lUser As Users) As Boolean
        Dim showNextPanel As Boolean = False
        For Each item As Object In pnlButtons.Controls
            Dim typeItem As String = item.GetType.ToString()
            If typeItem = "System.Windows.Forms.Button" Then
                item = CType(item, Button)
                Dim nameBtn As String = item.Text.ToString.TrimStart
                nameBtn = nameBtn.TrimEnd
                If lUser.ListAccess.Exists(Function(val) val = nameBtn) Then
                    item.Visible = True
                    showNextPanel = True
                Else
                    item.Visible = False
                    showNextPanel = False
                End If
            ElseIf typeItem = "System.Windows.Forms.Panel" Then
                item.visible = showNextPanel
            End If
        Next
        Return True
    End Function

    Private Sub BtnMaterials_Click(sender As Object, e As EventArgs) Handles btnMaterials.Click
        OpenFormPanel(Of Materials)()
    End Sub

    Private Sub BtnClients_Click(sender As Object, e As EventArgs) Handles btnClients.Click
        OpenFormPanel1(Of Clients)()
    End Sub

    Private Sub btnEmployees_Click(sender As Object, e As EventArgs) Handles btnEmployees.Click
        OpenFormPanel(Of Employees)()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnWorkCodes.Click
        OpenFormPanel2(Of ProjectsClients)()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub tbnoOthers_Click(sender As Object, e As EventArgs) Handles tbnoOthers.Click
        OpenFormPanel(Of Others)()
        Dim a As New Others
    End Sub

    Private Sub pnlImage_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs)
        Application.Exit()
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
                newPC.validAccess(loginUser)
            End If
            'llenarComboClientsReports(newPC.cmbClient)
            llenarComboClientByUser(newPC.cmbClient)
            If newPC.cmbClient.Items IsNot Nothing Then
                Dim index = newPC.cmbClient.FindString(Client.NumberClient)
                newPC.cmbClient.SelectedIndex = index
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
            newPC.validAccess(loginUser)
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

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim backup As New Backup
        backup.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim other As New ConfigReelsAndOther
        AddOwnedForm(other)
        other.ShowDialog()
        If closeMainForm Then
            Me.Close()
        End If
    End Sub
End Class