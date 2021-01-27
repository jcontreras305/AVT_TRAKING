Public Class HoursWeekPeerEmployees
    Private Sub btnFindEmployee_Click(sender As Object, e As EventArgs) Handles btnFindEmployee.Click
        Dim fndEmp As New FindEmployee
        fndEmp.ShowDialog()
    End Sub

    Private Sub HoursWeekPeerEmployees_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class