Public Class EstimateReports
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
    Public projectId As String = ""
    Public clientNum As String = ""
    Private Sub EstimateReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarComboClientsEstReports(cmbClient)
        If clientNum <> "" Then
            llenarComboPOClientEst(cmbProject, clientNum)
            cmbClient.SelectedItem = cmbClient.Items(cmbClient.FindString(clientNum))
            If projectId <> "" Then
                cmbProject.SelectedItem = cmbProject.Items(cmbProject.FindString(projectId))
            End If
        End If
    End Sub
    Private Sub cmbClient_Click(sender As Object, e As EventArgs) Handles cmbClient.Click
        If clientNum IsNot Nothing Then
            Dim lastProject As String = cmbProject.Text
            llenarComboPOClientEst(cmbProject, clientNum)
            If cmbProject.FindString(lastProject) > -1 Then
                cmbProject.SelectedItem = cmbProject.Items(cmbProject.FindString(projectId))
            Else
                projectId = ""
                cmbProject.Text = ""
                cmbProject.SelectedItem = Nothing
            End If
        End If
    End Sub
    Private Sub cmbProject_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProject.SelectedIndexChanged
        projectId = cmbProject.SelectedItem.ToString()
    End Sub

    Private Sub btnReports_Click(sender As Object, e As EventArgs) Handles btnReportsSCFBudget.Click
        Dim ventanaReporte As New JobNoSCFBudget
        ventanaReporte.ProjectId = projectId
        ventanaReporte.ClientNum = clientNum
        ventanaReporte.ShowDialog()
    End Sub

    Private Sub btnEquipmentBudged_Click(sender As Object, e As EventArgs) Handles btnEquipmentBudged.Click
        Dim ventanaReporte As New JobNoEquipmentBudget
        ventanaReporte.ProjectId = projectId
        ventanaReporte.ClientNum = clientNum
        ventanaReporte.ShowDialog()
    End Sub

    Private Sub btnPipingBudget_Click(sender As Object, e As EventArgs) Handles btnPipingBudget.Click
        Dim ventanaReporte As New JobNoPipingBudget
        ventanaReporte.ProjectId = projectId
        ventanaReporte.ClientNum = clientNum
        ventanaReporte.ShowDialog()
    End Sub

    Private Sub btnRFIScf_Click(sender As Object, e As EventArgs) Handles btnRFIScf.Click
        Dim rpt As New RFIReports
        rpt.TypeRFI = "Scaffold"
        rpt.projectId = projectId
        rpt.Show()
    End Sub

    Private Sub btnRFIEq_Click(sender As Object, e As EventArgs) Handles btnRFIEq.Click
        Dim rpt As New RFIReports
        rpt.TypeRFI = "Equipment"
        rpt.projectId = projectId
        rpt.Show()
    End Sub

    Private Sub btnRFIPiping_Click(sender As Object, e As EventArgs) Handles btnRFIPiping.Click
        Dim rpt As New RFIReports
        rpt.TypeRFI = "Piping"
        rpt.projectId = projectId
        rpt.Show()
    End Sub
End Class