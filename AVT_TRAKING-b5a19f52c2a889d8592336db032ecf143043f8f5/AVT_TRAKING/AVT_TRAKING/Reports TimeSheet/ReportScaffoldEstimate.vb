Imports System.Runtime.InteropServices
Imports CrystalDecisions.ReportAppServer

Public Class ReportScaffoldEstimate
    Public mtdEstimation As EstMeters
    Public Unit As String
    Public EstMeters, EstNumber, idClient As String
    Public UnicReport As Boolean
    Private Sub ReportScaffoldEstimate_Load(sender As Object, e As EventArgs) Handles Me.Load
        If UnicReport Then 'Es para mostrar solo un reporte de la ventana de ScfScaffold de lo contrario se mostraran los filtros 
            Label1.Visible = False
            cmbUnit.Visible = False
            chbAllUnit.Visible = False
        Else
            mtdEstimation.selectEstimationProyect(cmbUnit)
            If Unit IsNot "" Then
                For Each item As Object In cmbUnit.Items
                    If item.ToString() = Unit Then
                        cmbUnit.SelectedItem = item
                    End If
                Next
            End If
        End If
    End Sub
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.WindowState = FormWindowState.Minimized
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

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.Close()
    End Sub

    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        Try
            Dim proyect As String
            If UnicReport Then
                Dim array() As String = Unit.ToString.Split(" ")
                proyect = array(0)
                Dim reportSE As New ScaffoldEstimate
                reportSE.SetParameterValue("@ccnum", proyect)
                reportSE.SetParameterValue("@EstNumber", EstNumber)
                reportSE.SetParameterValue("@IdClient", idClient)
                reportSE.SetParameterValue("@all", False)
                reportSE.SetParameterValue("@CompanyName", "brock")
                If connecReport(reportSE) Then
                    crvReportScaffoldEstimate.ReportSource = reportSE
                End If

            Else
                If cmbUnit.SelectedItem IsNot Nothing Then
                    Dim array() As String = cmbUnit.SelectedItem.ToString.Split(" ")
                    proyect = array(0)
                Else
                    proyect = ""
                End If
                If chbAllUnit.Checked Or proyect <> "" Then
                    Dim reportSE As New ScaffoldEstimate
                    reportSE.SetParameterValue("@ccnum", proyect)
                    reportSE.SetParameterValue("@EstNumber", EstNumber)
                    reportSE.SetParameterValue("@IdClient", idClient)
                    reportSE.SetParameterValue("@all", If(chbAllUnit.Checked, True, False))
                    If connecReport(reportSE) Then
                        crvReportScaffoldEstimate.ReportSource = reportSE
                    End If
                Else
                    MsgBox("Please select a Estimation.")
                End If
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub chbAllUnit_CheckedChanged(sender As Object, e As EventArgs) Handles chbAllUnit.CheckedChanged
        If chbAllUnit.Checked Then
            cmbUnit.Enabled = False
        Else
            cmbUnit.Enabled = True
        End If
    End Sub


End Class