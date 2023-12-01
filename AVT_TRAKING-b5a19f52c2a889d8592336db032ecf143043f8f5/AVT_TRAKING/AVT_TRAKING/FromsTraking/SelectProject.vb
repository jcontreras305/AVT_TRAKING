Imports System.Runtime.InteropServices
Imports System.Data.SqlClient
Public Class SelectProject '
    Dim mtd As New QuerySelectProject
    Dim tblP As DataTable
    Private Sub SelectProject_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.Close()
    End Sub

    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(hWnd As IntPtr, wMsg As Integer, wParam As Integer, lParam As Integer)
    End Sub


End Class

Public Class QuerySelectProject
    Inherits ConnectioDB
    Public Function selectProject(Optional filter As String = "") As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("")
        Catch ex As Exception

        End Try
    End Function
End Class