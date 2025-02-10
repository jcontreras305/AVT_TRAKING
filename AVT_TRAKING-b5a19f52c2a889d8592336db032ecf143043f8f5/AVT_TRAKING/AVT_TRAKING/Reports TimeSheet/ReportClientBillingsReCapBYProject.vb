Imports System.Runtime.InteropServices
Imports System.Data.SqlClient
Imports CrystalDecisions.ReportAppServer
Imports System.Net

Public Class ReportClientBillingsReCapBYProject
    Dim conection As New ConnectioDB
    Dim clientId, JobNo, PO As String
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

    Private Sub ReportClientBillingsReCapBYProject_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'llenarComboClientsReports(cmbClients)
        llenarComboClientByUser(cmbClients)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim array() = cmbClients.SelectedItem.ToString().Split("    ")
        Dim idClient As String = array(0)
        If idClient <> "" Or idClient IsNot Nothing Then
            Dim reportTS As New ClientBillingsReCapBYProject
            reportTS.SetParameterValue("@startdate", validaFechaParaSQl(dtpInitialDate.Value.Date))
            reportTS.SetParameterValue("@finaldate", validaFechaParaSQl(dtpFinalDate.Value.Date))
            reportTS.SetParameterValue("@clientnum", idClient)
            reportTS.SetParameterValue("@job", If(cmbJob.SelectedIndex >= 0, cmbJob.Items(cmbJob.SelectedIndex), 0))
            If cmbPO.Items Is Nothing Then
                reportTS.SetParameterValue("@idPO", 0)
            Else
                reportTS.SetParameterValue("@idPO", If(cmbPO.SelectedIndex >= 0, cmbPO.Items(cmbPO.SelectedIndex), 0))
            End If
            reportTS.SetParameterValue("@allJob", If(chbAllJobs.Checked, 1, 0))
            reportTS.SetParameterValue("@allPO", If(chbAllPO.Checked, 1, 0))
            reportTS.SetParameterValue("@CompanyName", "brock")
            If connecReport(reportTS) Then
                crvClientBillingsReCapBYProject.ReportSource = reportTS
            End If
        Else
            MsgBox("Please select a Client.")
        End If
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.Close()
    End Sub

    Private Sub cmbClients_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClients.SelectedIndexChanged
        If cmbClients.SelectedItem IsNot Nothing Then
            Dim array() As String = cmbClients.SelectedItem.ToString.Split(" ")
            clientId = array(0)
            llenarComboJobsReports(cmbJob, clientId)
            llenarComboPOByClient(cmbPO, clientId)
            selectPOByClient(tblPOs, "ClientBillingReCapByProject", clientId)
        End If
    End Sub

    Private Sub btnSelectAll_Click(sender As Object, e As EventArgs) Handles btnSelectAll.Click
        If tblPOs.Rows IsNot Nothing Then
            For Each row As DataGridViewRow In tblPOs.Rows
                row.Cells(3).Value = True
            Next
        Else
            MsgBox("Please select a client to continue.")
        End If
    End Sub

    Private Sub Save_Click(sender As Object, e As EventArgs) Handles Save.Click
        If tblPOs.Rows IsNot Nothing Then
            If tblPOs.Rows.GetRowCount(DataGridViewElementStates.Selected) > 0 Then
                If DialogResult.Yes = MessageBox.Show("Are you sure to make these changues?" + vbCrLf + "The Projects unselected will not appear in these report.", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                    savePOreport(tblPOs, "ClientBillingReCapByProject")
                End If
            Else
                MsgBox("Please select a Row")
            End If
        Else
            MsgBox("Please select a client to continue.")
        End If
    End Sub
    Private Sub chbAllJobs_CheckedChanged(sender As Object, e As EventArgs) Handles chbAllJobs.CheckedChanged
        If chbAllJobs.Checked Then
            cmbJob.Enabled = False
            'chbAllPO.Checked = True
        Else
            cmbJob.Enabled = True
        End If
    End Sub

    Private Sub chbAllPO_CheckedChanged_1(sender As Object, e As EventArgs) Handles chbAllPO.CheckedChanged
        If chbAllPO.Checked Then
            cmbPO.Enabled = False
        Else
            cmbPO.Enabled = True
        End If
    End Sub

    Private Sub cmbJob_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbJob.SelectedIndexChanged
        If cmbJob.SelectedItem IsNot Nothing Then
            JobNo = cmbJob.Items(cmbJob.SelectedIndex)
            llenarComboPOByClient(cmbPO, clientId, JobNo)
            cmbPO.Text = ""
            selectPOByClient(tblPOs, "ClientBillingReCapByProject", clientId, JobNo)
        End If
    End Sub


End Class