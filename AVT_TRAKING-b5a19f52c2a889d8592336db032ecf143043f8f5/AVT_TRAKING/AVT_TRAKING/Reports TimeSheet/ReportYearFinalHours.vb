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
        Try
            Dim clientNum As String = "0"
            Dim jobNo As String = "0"
            Dim flag As Boolean = True
            If Not chbAllClients.Checked And cmbClient.SelectedIndex > -1 Then
                Dim arrayCl() As String = cmbClient.Items(cmbClient.SelectedIndex).ToString.Split(" ")
                clientNum = arrayCl(0)
                If chbAllJobs.Checked = False And cmbJobNo.SelectedIndex > -1 Then
                    clientNum = cmbJobNo.Items(cmbJobNo.SelectedIndex).ToString()
                Else
                    If chbAllJobs.Checked = False And chbAllClients.Checked = False And cmbJobNo.SelectedIndex = -1 Then
                        MessageBox.Show("Please select a JobNo to continue.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        flag = False
                    End If
                End If
            Else
                If Not chbAllClients.Checked Then
                    MessageBox.Show("Please select a Client to continue.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    flag = False
                End If
            End If

            If flag Then
                Dim reportTS As New YearFinalHours
                reportTS.SetParameterValue("@year", If(cmbYear.SelectedItem IsNot Nothing, cmbYear.SelectedItem, CStr(System.DateTime.Today.Year)))
                reportTS.SetParameterValue("@numberClient", clientNum)
                reportTS.SetParameterValue("@jobNo", jobNo)
                reportTS.SetParameterValue("@CompanyName", "brock")
                If connecReport(reportTS) Then
                    crvYearFinalHours.ReportSource = reportTS
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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
            llenarComboClientsReports(cmbClient)
        Catch ex As Exception
        Finally
            conection.desconectar()
        End Try
    End Sub

    Private Sub cmbClient_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClient.SelectedIndexChanged
        Try
            If cmbClient.SelectedIndex > 0 Then
                Dim array() As String = cmbClient.Items(cmbClient.SelectedIndex).ToString().Split(" ")
                llenarComboJobsReports(cmbJobNo, array(0))
                cmbJobNo.SelectedIndex = -1
                cmbJobNo.Text = ""
            Else
                MsgBox("Please select a client.")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub chbAllClients_CheckedChanged(sender As Object, e As EventArgs) Handles chbAllClients.CheckedChanged
        Try
            If chbAllClients.Checked Then
                cmbClient.Enabled = False
                chbAllJobs.Checked = True
                chbAllJobs.Enabled = False
            Else
                cmbClient.Enabled = True
                chbAllJobs.Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chbAllJobs_CheckedChanged(sender As Object, e As EventArgs) Handles chbAllJobs.CheckedChanged
        Try
            If chbAllJobs.Checked Then
                cmbJobNo.Enabled = False
            Else
                cmbJobNo.Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class