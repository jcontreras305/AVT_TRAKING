Public Class MainFrom
    Private Sub BtnMaterials_Click(sender As Object, e As EventArgs) Handles btnMaterials.Click
        Dim a As New Materials
        a.Show()

    End Sub

    Private Sub BtnClients_Click(sender As Object, e As EventArgs) Handles btnClients.Click
        Dim a As New Clients
        a.btnSelectClient.Visible = False
        a.btnSelectClient.Enabled = False
        a.Show()
    End Sub

    Private Sub btnEmployees_Click(sender As Object, e As EventArgs) Handles btnEmployees.Click
        Dim a As New Employees
        a.Show()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnWorkCodes.Click
        Dim a As New ProjectsClients
        a.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim a As New Login
        a.Show()
        Me.Close()

    End Sub

End Class