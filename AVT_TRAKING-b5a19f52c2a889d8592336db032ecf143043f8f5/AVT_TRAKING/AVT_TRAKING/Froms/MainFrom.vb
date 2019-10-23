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
        Dim a As New Employees
        a.Show()
        Me.Finalize()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim a As New WorkCodes
        a.Show()
        Me.Finalize()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim a As New Login
        a.Show()
        Me.Finalize()
    End Sub
End Class