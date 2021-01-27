Public Class FindEmployee
    Dim mtdEmployee As New MetodosEmployees


    Private Sub FindEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mtdEmployee.bucarEmpleados(tblFindEmployee, "")
    End Sub

    Private Sub btnFindEmployee_Click(sender As Object, e As EventArgs) Handles btnFindEmployee.Click
        mtdEmployee.bucarEmpleados(tblFindEmployee, txtAsk.Text)
    End Sub
End Class