Imports System.Runtime.InteropServices
Imports System.Data.SqlClient
Public Class ReporteEmployees
    Dim con As New ConnectioDB
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.Close()
    End Sub

    Private Sub btnMaximize_Click(sender As Object, e As EventArgs) Handles btnMaximize.Click
        MaximizedBounds = Screen.FromHandle(Me.Handle).WorkingArea
        WindowState = FormWindowState.Maximized
        btnMaximize.Visible = False
        btnRestore.Visible = True
    End Sub

    Private Sub btnRestore_Click(sender As Object, e As EventArgs) Handles btnRestore.Click
        WindowState = FormWindowState.Normal
        btnRestore.Visible = False
        btnMaximize.Visible = True
    End Sub
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(hWnd As IntPtr, wMsg As Integer, wParam As Integer, lParam As Integer)
    End Sub


    Private Sub TitleBar_MouseMove(sender As Object, e As MouseEventArgs) Handles TitleBar.MouseMove
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If cmbClient.Items IsNot Nothing Or cmbClient.Text <> "" Then
                Dim idcl As String = ""
                Dim array() As String = cmbClient.SelectedItem.ToString.Split(" ")
                idcl = array(0)
                If idcl = "" Then
                    MsgBox("Client not found.")
                Else
                    Dim reportTS As New ReportE
                    reportTS.SetParameterValue("@IntialDate", validaFechaParaSQl(dtpInitialDate.Value.Date))
                    reportTS.SetParameterValue("@FinalDate", validaFechaParaSQl(dtpFinalDate.Value.Date))
                    reportTS.SetParameterValue("@numclient", idcl)
                    reportTS.SetParameterValue("@job", If(cmbJobs.SelectedItem IsNot Nothing, CInt(cmbJobs.SelectedItem), 0))
                    reportTS.SetParameterValue("@all", If(chbAllJobs.Checked, 1, 0))
                    If connecReport(reportTS) Then
                        crvTimeSheetEmployee.ReportSource = reportTS
                    End If

                End If
            Else
                MsgBox("Please select a client.")
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Private Sub ReporteEmployees_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'llenarComboClientsReports(cmbClient)
        llenarComboClientByUser(cmbClient)
    End Sub

    Private Sub cmbClient_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClient.SelectedIndexChanged
        If cmbClient.SelectedItem IsNot Nothing Then
            Dim arra() As String = cmbClient.SelectedItem.ToString.Split(" ")
            llenarComboJobsReports(cmbJobs, arra(0))
        End If
    End Sub

    Private Sub chbAllJobs_CheckedChanged(sender As Object, e As EventArgs) Handles chbAllJobs.CheckedChanged
        If chbAllJobs.Checked = True Then
            cmbJobs.Enabled = False
        Else
            cmbJobs.Enabled = True
        End If
    End Sub
End Class