Imports System.Net

Public Class ReportDateExcel

    Public startDate = False, finalDate = False, clients = False, jobs = False, cancel = False
    Public windowStart As String
    Dim listData As New List(Of String)

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Select Case windowStart
            Case "UnderFourty"
                Dim rpm As ReportsMenu = CType(Owner, ReportsMenu)
                rpm.datos = datosReturn()
                rpm.cancelProcess = False
                Me.Close()
            Case "MounthHours"
                If cmbClients.SelectedItem IsNot Nothing And (cmbJobs.SelectedItem IsNot Nothing Or chbAllJobs.Checked) Then
                    Dim rpm As ReportsMenu = CType(Owner, ReportsMenu)
                    rpm.datos = datosReturn()
                    rpm.cancelProcess = False
                    Me.Close()
                Else
                    MessageBox.Show("The 'Client or Job' was not specificated.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If

        End Select
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Select Case windowStart
            Case "UnderFourty"
                Dim rpm As ReportsMenu = CType(Owner, ReportsMenu)
                rpm.datos = Nothing
                rpm.cancelProcess = True
                Me.Close()
            Case "MounthHours"
                Dim rpm As ReportsMenu = CType(Owner, ReportsMenu)
                rpm.datos = Nothing
                rpm.cancelProcess = True
                Me.Close()
        End Select
    End Sub
    Private Sub cmbClients_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClients.SelectedIndexChanged
        Try
            Dim array() As String = cmbClients.SelectedItem.ToString.Split(" ")
            llenarComboJobsReports(cmbJobs, array(0))
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub
    Private Sub ReportDateExcel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFinalDate.Visible = finalDate
        Label1.Visible = startDate
        dtpStartDate.Visible = startDate
        Label2.Visible = finalDate
        cmbClients.Visible = clients
        Label3.Visible = clients
        'llenarComboClientsReports(cmbClients)
        llenarComboClientByUser(cmbClients)
        cmbJobs.Visible = jobs
        Label4.Visible = jobs
        If jobs Then
            chbAllJobs.Visible = True
        Else
            chbAllJobs.Visible = False
        End If
    End Sub
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Select Case windowStart
            Case "UnderFourty"
                Dim rpm As ReportsMenu = CType(Owner, ReportsMenu)
                rpm.datos = Nothing
                rpm.cancelProcess = True
        End Select
        Me.Close()
    End Sub
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Function datosReturn() As List(Of String)
        Try
            Dim listDatos As New List(Of String)
            If dtpStartDate.Visible Then
                listDatos.Add(validaFechaParaSQl(dtpStartDate.Value))
            End If
            If dtpFinalDate.Visible Then
                listDatos.Add(validaFechaParaSQl(dtpFinalDate.Value))
            End If
            If cmbClients.Visible And cmbClients.SelectedItem IsNot Nothing Then
                Dim array() As String = cmbClients.SelectedItem.ToString.Split(" ")
                listDatos.Add(array(0))
            End If
            If cmbJobs.Visible And cmbJobs.SelectedItem IsNot Nothing Then
                Dim array() As String = cmbJobs.SelectedItem.ToString.Split(" ")
                listDatos.Add(array(0))
            ElseIf cmbJobs.Visible And chbAllJobs.Checked Then
                listDatos.Add("")
            End If
            If chbAllJobs.Visible And chbAllJobs.Checked Then
                listDatos.Add("1")
            ElseIf chbAllJobs.Visible And Not chbAllJobs.Checked Then
                listDatos.Add("0")
            End If
            Return listDatos
        Catch ex As Exception
            MsgBox(ex.Message())
            Return New List(Of String)
        End Try
    End Function
End Class