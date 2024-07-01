Imports System.Runtime.InteropServices

Public Class ReportActiveAverageE

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



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim idClient As String
            If cmbClients.SelectedIndex > -1 Then
                Dim array() = cmbClients.SelectedItem.ToString().Split(" ")
                idClient = array(0)
            Else
                idClient = "0"
            End If
            If (idClient <> "" Or idClient IsNot Nothing) Or chbAll.Checked Then
                Dim reportAE As New ActiveAv
                reportAE.SetParameterValue("@StartDate", validaFechaParaSQl(dtpInitialDate.Value.Date))
                reportAE.SetParameterValue("@EndDate", validaFechaParaSQl(dtpFinalDate.Value.Date))
                reportAE.SetParameterValue("@ClientName", If(chbAll.Checked, 0, CInt(idClient)))
                reportAE.SetParameterValue("@all", If(chbAll.Checked, 1, 0))
                reportAE.SetParameterValue("@CompanyName", "brock")
                If Not UserDB = "True" Then
                    reportAE.SetDatabaseLogon(UserDB, Pass, ServerName, DBName)
                Else
                    reportAE.SetDatabaseLogon("", "", ServerName, DBName)
                End If
                crvActiveAverageE.ReportSource = reportAE
            Else
                MsgBox("Please select a Client.")
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Private Sub ReportActiveAverageE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarComboClientsReports(cmbClients)
    End Sub

    Private Sub chbAll_CheckedChanged(sender As Object, e As EventArgs) Handles chbAll.CheckedChanged
        cmbClients.Enabled = If(chbAll.Checked, False, True)
    End Sub
End Class