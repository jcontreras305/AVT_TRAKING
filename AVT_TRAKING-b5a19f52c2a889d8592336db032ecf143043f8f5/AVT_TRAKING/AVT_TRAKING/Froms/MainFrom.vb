Public Class MainFrom
    Private Sub BtnMaterials_Click(sender As Object, e As EventArgs) Handles btnMaterials.Click
        Dim a As New Materials
        a.Show()
        Me.Finalize()
    End Sub

    Private Sub BtnClients_Click(sender As Object, e As EventArgs) Handles btnClients.Click
        Dim a As New Clients
        a.Show()
        Me.Finalize()
    End Sub

    Private Sub btnEmployees_Click(sender As Object, e As EventArgs) Handles btnEmployees.Click
        Employees.Show()
        Me.Finalize()
    End Sub
End Class