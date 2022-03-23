Imports System.Runtime.InteropServices
Imports System.Data.SqlClient

Public Class ReportYearFinalHours
    Dim conection As New ConnectioDB

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.Close()
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim reportTS As New YearFinalHours
        reportTS.SetParameterValue("@year", If(cmbYear.SelectedItem IsNot Nothing, cmbYear.SelectedItem, CStr(System.DateTime.Today.Year)))
        crvYearFinalHours.ReportSource = reportTS
    End Sub

    Private Sub ReportYearFinalHours_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            conection.conectar()
            Dim cmd As New SqlCommand("select distinct DATENAME(YEAR,hw.dateWorked) as 'Year' from hoursWorked as hw", conection.conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            If cmbYear.Items IsNot Nothing Then
                cmbYear.Items.Clear()
            End If
            While dr.Read
                cmbYear.Items.Add(dr("Year"))
            End While
            dr.Close()
        Catch ex As Exception
        Finally
            conection.desconectar()
        End Try
    End Sub
End Class