﻿Imports System.Runtime.InteropServices
Imports System.Data.SqlClient
Imports CrystalDecisions.ReportAppServer
Public Class ReportCatsEmployeePorject
    Dim conection As New ConnectioDB
    Private Sub ReportCatsEmployeePorject_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            conection.conectar()
            Dim cmd As New SqlCommand(" select numberEmploye , CONCAT(lastName,', ',firstName,' ',middleName) as 'Name' from employees ", conection.conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            While dr.Read()
                cmbEmployees.Items.Add(CStr(dr("numberEmploye")) + "   " + dr("Name"))
            End While
        Catch ex As Exception
            MsgBox(ex.Message())
        Finally
            conection.desconectar()
        End Try
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

    Private Sub btnReportE_Click(sender As Object, e As EventArgs) Handles btnReportE.Click
        If chkAllEmployees.Checked Then
            Dim reportTS As New CatsEmployeebyProject
            reportTS.SetParameterValue("@startdate", validaFechaParaSQl(dtpInitialDate.Value.Date))
            reportTS.SetParameterValue("@finaldate", validaFechaParaSQl(dtpFinalDate.Value.Date))
            reportTS.SetParameterValue("@employeenumber", DBNull.Value)
            reportTS.SetParameterValue("@all", 1)
            reportTS.SetParameterValue("@CompanyName", "brock")
            If connecReport(reportTS) Then
                crvCatsEmployeebyProject.ReportSource = reportTS
            End If
        ElseIf cmbEmployees.SelectedItem IsNot Nothing Then
            Dim array() = cmbEmployees.SelectedItem.ToString().Split("    ")
            Dim idEmploye As String = array(0)
            If idEmploye <> "" Or idEmploye IsNot Nothing Then
                Dim reportTS As New CatsEmployeebyProject
                reportTS.SetParameterValue("@startdate", validaFechaParaSQl(dtpInitialDate.Value.Date))
                reportTS.SetParameterValue("@finaldate", validaFechaParaSQl(dtpFinalDate.Value.Date))
                reportTS.SetParameterValue("@employeenumber", idEmploye)
                reportTS.SetParameterValue("@all", 0)
                If connecReport(reportTS) Then
                    crvCatsEmployeebyProject.ReportSource = reportTS
                End If
            Else
                MsgBox("Please choose a Employee.")
            End If
        Else
            MsgBox("Please choose a Employee.")
        End If

    End Sub


End Class