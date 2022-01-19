Public Class PayRoll
    Dim mtdHPW As New MetodosHoursPeerWeek
    Private Sub btnAddWeek_Click(sender As Object, e As EventArgs) Handles btnAddWeek.Click
        Try
            mtdHPW.insertWeek(dtpWeek.Value, sprNumWeek.Value)
            mtdHPW.selectWeeks(tblWeeks)
        Catch ex As Exception

        End Try
    End Sub
End Class