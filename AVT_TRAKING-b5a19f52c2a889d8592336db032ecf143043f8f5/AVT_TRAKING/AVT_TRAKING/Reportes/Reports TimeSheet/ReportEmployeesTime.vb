Imports System.Runtime.InteropServices
Imports System.Data.SqlClient

Public Class ReportEmployeesTime
    Dim conection As New ConnectioDB
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

    Private Sub ReportEmployeesTime_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            conection.conectar()
            Dim cmd As New SqlCommand("select CONCAT(numberClient , ' ', companyName) as 'Clients' from clients", conection.conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            While dr.Read
                cmbClient.Items.Add(CStr(dr("Clients")))
            End While
            dr.Close()
            If cmbClient.Items IsNot Nothing Then
                Dim idClient As String() = cmbClient.Items(0).ToString.Split(" ")
                Dim cmd1 As New SqlCommand(" select * from job where idClient = (select idClient from clients where numberClient = " + idClient(0) + ")", conection.conn)
                Dim dr1 As SqlDataReader = cmd1.ExecuteReader()
                While dr1.Read()
                    cmbJobs.Items.Add(CStr(dr1("jobNo")))
                End While
                dr1.Close()
            End If

        Catch ex As Exception
            MsgBox(ex.Message())
        Finally
            conection.desconectar()
        End Try
    End Sub

    Private Sub btnReportE_Click(sender As Object, e As EventArgs) Handles btnReportE.Click
        Try
            If cmbJobs.SelectedItem Is Nothing And chbAllJobs.Checked = False Then
                MessageBox.Show("Please select a Job Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Dim array() As String
                Dim jobNo As String = ""
                If cmbJobs.SelectedItem IsNot Nothing Then
                    array = cmbJobs.SelectedItem.ToString().Split("    ")
                    jobNo = array(0)
                End If
                array = cmbClient.SelectedItem.ToString().Split(" ")
                Dim clNum As String = array(0)
                If clNum <> "" Or clNum IsNot Nothing Then
                    Dim reportTS As New EmployeesTime
                    reportTS.SetParameterValue("@initialDate", validaFechaParaSQl(dtpInitialDate.Value.Date))
                    reportTS.SetParameterValue("@finaldate", validaFechaParaSQl(dtpFinalDate.Value.Date))
                    reportTS.SetParameterValue("@jobNum", If(chbAllJobs.Checked, 0, jobNo))
                    reportTS.SetParameterValue("@numClient", CInt(clNum))
                    reportTS.SetParameterValue("@all", If(chbAllJobs.Checked, 1, 0))
                    reportTS.SetParameterValue("@CompanyName", "brock")
                    crvEmployeesTime.ReportSource = reportTS
                Else
                    MsgBox("Please select a Client.")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Private Sub TitleBar_Paint(sender As Object, e As PaintEventArgs) Handles TitleBar.Paint

    End Sub

    Private Sub cmbClient_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClient.SelectedIndexChanged
        If cmbClient.Items IsNot Nothing Then
            conection.conectar()
            Dim idClient As String() = cmbClient.SelectedItem.ToString.Split(" ")
            Dim cmd1 As New SqlCommand(" select * from job where idClient = (select idClient from clients where numberClient = " + idClient(0) + ")", conection.conn)
            Dim dr1 As SqlDataReader = cmd1.ExecuteReader()
            cmbJobs.Items.Clear()
            cmbJobs.Text = ""
            While dr1.Read()
                cmbJobs.Items.Add(CStr(dr1("jobNo")))
            End While
            dr1.Close()
        End If
    End Sub

    Private Sub chbAllJobs_CheckedChanged(sender As Object, e As EventArgs) Handles chbAllJobs.CheckedChanged
        If chbAllJobs.Checked Then
            cmbJobs.Enabled = False
        Else
            cmbJobs.Enabled = True
        End If
    End Sub
End Class