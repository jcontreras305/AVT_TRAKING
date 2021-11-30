Public Class ReportsMenu
    Private Sub btnTimeSheet_Click(sender As Object, e As EventArgs) Handles btnTimeSheet.Click
        Dim tse As New ReporteEmployees
        tse.ShowDialog()
    End Sub
End Class