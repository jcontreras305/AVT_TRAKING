Public Class MenuEstimation
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub MenuEstimation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pnlSetting.Visible = False
        pnlProjects.Visible = False
    End Sub

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        If pnlSetting.Visible Then
            pnlSetting.Visible = False
            pnlProjects.Visible = False
        Else
            pnlSetting.Visible = True
            pnlProjects.Visible = False
        End If
    End Sub

    Private Sub btnProjects_Click(sender As Object, e As EventArgs) Handles btnProjects.Click
        If pnlProjects.Visible Then
            pnlSetting.Visible = False
            pnlProjects.Visible = False
        Else
            pnlSetting.Visible = False
            pnlProjects.Visible = True
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
    Private Sub btnDrawingProgress_Click(sender As Object, e As EventArgs) Handles btnDrawingProgress.Click
        OpenFormPanel5(Of DrawingProgress)()
    End Sub
    Private Sub OpenFormPanel5(Of Miform As {DrawingProgress, New})()
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
    Private Sub btnProjectActuals_Click(sender As Object, e As EventArgs) Handles btnProjectActuals.Click
        OpenFormPanel6(Of ProjectsActuals)()
    End Sub
    Private Sub OpenFormPanel6(Of Miform As {ProjectsActuals, New})()
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
    Private Sub btnScaffolRFI_Click(sender As Object, e As EventArgs) Handles btnScaffolRFI.Click
        OpenFormPanel7(Of RFISacffold)()
    End Sub
    Private Sub OpenFormPanel7(Of Miform As {RFISacffold, New})()
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

    Private Sub btnEuipmentRFI_Click(sender As Object, e As EventArgs) Handles btnEuipmentRFI.Click
        OpenFormPanel8(Of RFIEquipment)()
    End Sub
    Private Sub OpenFormPanel8(Of Miform As {RFIEquipment, New})()
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