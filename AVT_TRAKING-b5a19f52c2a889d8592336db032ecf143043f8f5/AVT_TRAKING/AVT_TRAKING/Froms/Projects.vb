Imports System.Data
Imports System.Data.SqlClient
Public Class Projects
    Private Sub WorkCodes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnMenu_Click(sender As Object, e As EventArgs) Handles btnMenu.Click
        Dim a As New MainFrom
        a.Show()
        Me.Finalize()
    End Sub

    Private Sub btnWorkCode_Click(sender As Object, e As EventArgs) Handles btnWorkCode.Click
        Dim wk As New WorkCodes
        wk.ShowDialog()
    End Sub


End Class