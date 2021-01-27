Imports System.Data
Imports System.Data.SqlClient
Public Class ProjectsClients
    Private Sub ocultarPaneles()
        PnllSetup.Visible = False
    End Sub

    Private Sub WorkCodes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ocultarPaneles()
    End Sub

    Private Sub btnWK_Click(sender As Object, e As EventArgs) Handles btnWK.Click
        Dim wk As New WorkCodes
        wk.ShowDialog()
    End Sub

    Private Sub btnSetup_Click(sender As Object, e As EventArgs) Handles btnSetup.Click
        If PnllSetup.Visible = True Then
            PnllSetup.Visible = False
        Else
            PnllSetup.Visible = True
        End If
    End Sub

    Private Sub btnExpences_Click(sender As Object, e As EventArgs) Handles btnExpences.Click
        Dim a As New Expences
        a.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub btnProyeccts_Click(sender As Object, e As EventArgs) Handles btnProyeccts.Click
        Dim pjc As New ProjectsCosts
        pjc.ShowDialog()
    End Sub

    Private Sub btnEmployees_Click(sender As Object, e As EventArgs) Handles btnEmployees.Click
        Dim hpe As New HoursWeekPeerEmployees
        hpe.ShowDialog()
    End Sub
End Class