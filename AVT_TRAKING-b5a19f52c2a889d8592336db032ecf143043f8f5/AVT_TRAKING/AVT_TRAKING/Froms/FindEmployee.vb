Public Class FindEmployee
    Dim mtdEmployee As New MetodosEmployees
    Dim idEmployee, nombre As String
    Dim imagen As Byte()

    Private Sub FindEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mtdEmployee.bucarEmpleados(tblEmployees, "")
        tblEmployees.Columns("idEmployee").Visible = False
        tblEmployees.Columns("photo").Visible = False
        btnSelect.Enabled = False
    End Sub

    Private Sub btnFindEmployee_Click(sender As Object, e As EventArgs) Handles btnFindEmployee.Click
        mtdEmployee.bucarEmpleados(tblEmployees, txtAsk.Text)
        tblEmployees.Columns("idEmployee").Visible = False
        tblEmployees.Columns("photo").Visible = False
    End Sub

    Private Sub tblFindEmployee_SelectionChangued(sender As Object, e As EventArgs) Handles tblEmployees.SelectionChanged
        If tblEmployees.CurrentRow IsNot Nothing Then
            btnSelect.Enabled = True
            idEmployee = tblEmployees.CurrentRow.Cells("idEmployee").Value
            nombre = tblEmployees.CurrentRow.Cells("Employee Name").Value
            imagen = tblEmployees.CurrentRow.Cells("photo").Value
        Else
            btnSelect.Enabled = False
        End If
    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        Dim hpw As HoursWeekPerEmployees = CType(Owner, HoursWeekPerEmployees)
        hpw.idEmpleado = idEmployee
        hpw.NombreEmpleado = nombre
        hpw.photo = imagen
        Me.Close()
    End Sub


End Class