Public Class MenuEstimation
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub MenuEstimation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pnlProyects.Visible = False
        pnlSetting.Visible = False
    End Sub

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        If pnlSetting.Visible Then
            pnlSetting.Visible = False
            pnlProyects.Visible = False
        Else
            pnlSetting.Visible = True
            pnlProyects.Visible = False
        End If
    End Sub

    Private Sub btnProjects_Click(sender As Object, e As EventArgs) Handles btnProjects.Click
        If pnlProyects.Visible Then
            pnlSetting.Visible = False
            pnlProyects.Visible = False
        Else
            pnlSetting.Visible = False
            pnlProyects.Visible = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        OpenFormPanel1(Of SettingsEstimation)()
    End Sub
    Private Sub OpenFormPanel1(Of Miform As {SettingsEstimation, New})()
        Dim FormPanel As Form
        FormPanel = PanelViewFrom.Controls.OfType(Of Miform)().FirstOrDefault()

        If FormPanel Is Nothing Then
            Dim newPC = New Miform()
            FormPanel = newPC
            FormPanel.TopLevel = False
            FormPanel.Dock = DockStyle.Fill

            PanelViewFrom.Controls.Add(FormPanel)
            PanelViewFrom.Tag = FormPanel
            FormPanel.Show()
            FormPanel.BringToFront()
        Else
            FormPanel.BringToFront()
        End If
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        OpenFormPanel2(Of Factors)()
    End Sub
    Private Sub OpenFormPanel2(Of Miform As {Factors, New})()
        Dim FormPanel As Form
        FormPanel = PanelViewFrom.Controls.OfType(Of Miform)().FirstOrDefault()

        If FormPanel Is Nothing Then
            Dim newPC = New Miform()
            FormPanel = newPC
            FormPanel.TopLevel = False
            FormPanel.Dock = DockStyle.Fill

            PanelViewFrom.Controls.Add(FormPanel)
            PanelViewFrom.Tag = FormPanel
            FormPanel.Show()
            FormPanel.BringToFront()
        Else
            FormPanel.BringToFront()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        OpenFormPanel3(Of Estimating)()
    End Sub
    Private Sub OpenFormPanel3(Of Miform As {Estimating, New})()
        Dim FormPanel As Form
        FormPanel = PanelViewFrom.Controls.OfType(Of Miform)().FirstOrDefault()

        If FormPanel Is Nothing Then
            Dim newPC = New Miform()
            FormPanel = newPC
            FormPanel.TopLevel = False
            FormPanel.Dock = DockStyle.Fill
            PanelViewFrom.Controls.Add(FormPanel)
            PanelViewFrom.Tag = FormPanel
            FormPanel.Show()
            FormPanel.BringToFront()
        Else
            FormPanel.BringToFront()
        End If
    End Sub

    Private Sub btnReports_Click(sender As Object, e As EventArgs) Handles btnReports.Click
        OpenFormPanel4(Of EstimateReports)()
    End Sub
    Private Sub OpenFormPanel4(Of Miform As {EstimateReports, New})()
        Dim FormPanel As Form
        FormPanel = PanelViewFrom.Controls.OfType(Of Miform)().FirstOrDefault()
        If FormPanel Is Nothing Then
            Dim newPC = New Miform()
            FormPanel = newPC
            FormPanel.TopLevel = False
            FormPanel.Dock = DockStyle.Fill
            PanelViewFrom.Controls.Add(FormPanel)
            PanelViewFrom.Tag = FormPanel
            FormPanel.Show()
            FormPanel.BringToFront()
        Else
            FormPanel.BringToFront()
        End If
    End Sub
End Class