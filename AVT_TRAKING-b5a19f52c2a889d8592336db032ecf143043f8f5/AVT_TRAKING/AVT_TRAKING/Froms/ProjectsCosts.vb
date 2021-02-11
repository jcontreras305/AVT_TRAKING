Public Class ProjectsCosts
    Dim mtdJobs As New MetodosJobs
    Public idCliente, WorkOrder, JobNumber As String

    Private Sub ProjectsCosts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblWorkOrder.Text = WorkOrder

        mtdJobs.llenarComboJob(cmbJobNumber, idCliente)



        cmbJobNumber.SelectedIndex = cmbJobNumber.FindString(JobNumber)

        If WorkOrder <> Nothing Then
            mtdJobs.buscarHorasPorProjecto(tblHoursWorkedProject, WorkOrder)
            mtdJobs.buscarExpencesPorProyecto(tblExpencesProjects, WorkOrder)
            mtdJobs.buscarMaterialesPorProyecto(tblMaterialProjects, WorkOrder)
        Else

        End If

    End Sub


    Private Sub LimpiarCampos()

    End Sub
End Class