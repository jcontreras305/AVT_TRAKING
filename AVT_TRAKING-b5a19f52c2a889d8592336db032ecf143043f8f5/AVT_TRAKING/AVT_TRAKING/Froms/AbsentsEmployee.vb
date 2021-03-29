Public Class Absentsemployee
    Public idEmpleado, numEmployee, firstName, lastName, explanation As String
    Dim mtdEmployees As New MetodosEmployees

    Private Sub Absentsemployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpDate.Format = DateTimePickerFormat.Custom
        dtpDate.Value = System.DateTime.Today
        sprHoras.Value = 0
        sprHoras.DecimalPlaces = 2
        sprHoras.Minimum = 0
        sprHoras.Increment = 0.5
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If sprHoras.Value > 0 Then
            If txtExplanation.Text <> "" Then
                Dim datos As New List(Of String)
                datos.Add(dtpDate.Value().ToString())
                datos.Add(sprHoras.Value.ToString())
                datos.Add(txtExplanation.Text)
                datos.Add(idEmpleado)
                If mtdEmployees.insertAbsents(datos) Then
                    MsgBox("Successful")
                    dtpDate.Value = CDate(System.DateTime.Today)
                    sprHoras.Value = 0
                    txtExplanation.Text = ""
                End If
            Else
                MessageBox.Show("You need to add hours.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("You need to add an explanation.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class