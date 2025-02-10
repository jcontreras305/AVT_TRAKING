Imports System.Net
Imports System.Runtime.InteropServices
Public Class ScaffoldProductIncoming
    Public Incoming As Boolean = True
    Dim mtdScf As New MetodosScaffold

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.Close()
    End Sub
    Private Sub btnMinimize_Click(sender As Object, e As EventArgs) Handles btnMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub btnRestore_Click(sender As Object, e As EventArgs) Handles btnRestore.Click
        WindowState = FormWindowState.Normal
        btnRestore.Visible = False
        btnMaximize.Visible = True
    End Sub
    Private Sub btnMaximize_Click(sender As Object, e As EventArgs) Handles btnMaximize.Click
        MaximizedBounds = Screen.FromHandle(Me.Handle).WorkingArea
        WindowState = FormWindowState.Maximized
        btnMaximize.Visible = False
        btnRestore.Visible = True
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

    Private Sub ScaffoldProductIncoming_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Incoming Then
            lblTitle.Text = "Report Scaffold Product Incoming"
        Else
            lblTitle.Text = "Report Scaffold Product Outgoing"
        End If
        'llenarComboClientsReports(cmbClients)
        llenarComboClientByUser(cmbClients)
        cmbJobNo.Enabled = False
        cmbTickets.Enabled = False
    End Sub

    Private Sub cmbClients_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClients.SelectedIndexChanged
        If cmbClients.SelectedIndex > -1 Then
            cmbJobNo.Enabled = True
            Dim array() As String = cmbClients.Items(cmbClients.SelectedIndex).ToString.Split(" ")
            llenarComboJobsReports(cmbJobNo, array(0))
            cmbJobNo.SelectedIndex = -1
            cmbJobNo.Text = ""
            cmbTickets.SelectedIndex = -1
            cmbTickets.Text = ""
        Else
            cmbClients.Enabled = False
        End If
    End Sub

    Private Sub cmbJobNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbJobNo.SelectedIndexChanged
        If cmbJobNo.SelectedIndex > -1 Then
            cmbTickets.Enabled = True
            If Incoming Then
                mtdScf.llenarComboIncommingTicket(cmbTickets, cmbJobNo.Items(cmbJobNo.SelectedIndex))
            Else
                mtdScf.llenarComboOutGoingTicket(cmbTickets, cmbJobNo.Items(cmbJobNo.SelectedIndex))
            End If
            cmbTickets.SelectedIndex = -1
            cmbTickets.Text = ""
        Else
            cmbTickets.Enabled = False
            chbAll.Checked = False
        End If
    End Sub

    Private Sub chbAll_CheckedChanged(sender As Object, e As EventArgs) Handles chbAll.CheckedChanged
        If chbAll.Checked Then
            cmbTickets.Enabled = False
        Else
            cmbTickets.Enabled = True
        End If
    End Sub

    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        Try
            Dim array() As String
            Dim jobNo As String = ""
            array = cmbClients.SelectedItem.ToString().Split(" ")
            Dim clNum As String = array(0)
            If clNum <> "" Or clNum IsNot Nothing Then
                If cmbJobNo.SelectedIndex > -1 Then
                    If cmbTickets.SelectedIndex > -1 Or chbAll.Checked Then
                        If Incoming Then
                            Dim reportTs As New ScfProductComing
                            Dim jb As Long = cmbJobNo.Items(cmbJobNo.SelectedIndex)
                            reportTs.SetParameterValue("@jobNo", jb)
                            reportTs.SetParameterValue("@ticket", If(chbAll.Checked, "", cmbTickets.Items(cmbTickets.SelectedIndex).ToString()))
                            reportTs.SetParameterValue("@all", If(chbAll.Checked, 1, 0))
                            reportTs.SetParameterValue("@CompanyName", "Brock")
                            If connecReport(reportTs) Then
                                crvReport.ReportSource = reportTs
                            End If
                        Else
                            Dim reportTs As New ScfProductOutgoing
                            Dim jb As Long = cmbJobNo.Items(cmbJobNo.SelectedIndex)
                            reportTs.SetParameterValue("@jobNo", jb)
                            reportTs.SetParameterValue("@ticket", If(chbAll.Checked, "", cmbTickets.Items(cmbTickets.SelectedIndex).ToString()))
                            reportTs.SetParameterValue("@all", If(chbAll.Checked, 1, 0))
                            reportTs.SetParameterValue("@CompanyName", "Brock")
                            If connecReport(reportTs) Then
                                crvReport.ReportSource = reportTs
                            End If
                        End If
                    Else
                        MsgBox("Please specify if you want to see just one Ticket or all of them.")
                    End If
                Else
                    MsgBox("Please choose one Job No to continue.")
                End If
            Else
                MsgBox("Please select a Client.")
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub
End Class