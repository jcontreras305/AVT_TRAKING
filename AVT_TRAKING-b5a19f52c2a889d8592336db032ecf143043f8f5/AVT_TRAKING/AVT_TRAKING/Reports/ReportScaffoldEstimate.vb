﻿Imports System.Runtime.InteropServices

Public Class ReportScaffoldEstimate
    Public mtdEstimation As EstMeters
    Private Sub ReportScaffoldEstimate_Load(sender As Object, e As EventArgs) Handles Me.Load
        mtdEstimation.selectEstimation(cmbEstimations)
        If mtdEstimation.EstNumber IsNot "" Then
            For Each item As Object In cmbEstimations.Items
                If item.ToString() = mtdEstimation.EstNumber Then
                    cmbEstimations.SelectedItem = item
                End If
            Next
        End If
    End Sub
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub btnMaximize_Click(sender As Object, e As EventArgs) Handles btnMaximize.Click
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
        Dim estimacion As String
        If cmbEstimations.SelectedItem Is Nothing Then
            estimacion = "%"
        Else
            estimacion = cmbEstimations.SelectedItem.ToString()
        End If
        If estimacion IsNot Nothing Then
            Dim reportSE As New ScaffoldEstimate
            reportSE.SetParameterValue("@EstNumber", estimacion)
            crvReportScaffoldEstimate.ReportSource = reportSE
        Else
            MsgBox("Please select a Estimation.")
        End If
    End Sub
End Class