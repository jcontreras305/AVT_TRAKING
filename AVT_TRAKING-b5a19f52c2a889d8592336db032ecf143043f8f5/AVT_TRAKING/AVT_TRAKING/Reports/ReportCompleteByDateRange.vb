Imports System.Runtime.InteropServices
Imports System.Data.SqlClient


Public Class ReportCompleteByDateRange
    Dim conection As New ConnectioDB
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.Close()
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

    Private Sub ReportCompleteByDateRange_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            conection.conectar()
            Dim cmd As New SqlCommand("select numberClient , companyName as 'Name' from clients ", conection.conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()

            While dr.Read()
                cmbClients.Items.Add(CStr(dr("numberClient")) + "   " + dr("Name"))
            End While
            dr.Close()

            If cmbClients.SelectedItem IsNot Nothing Then
                Dim arraycl() As String = cmbClients.SelectedItem.ToString.Split(" ")
                Dim cmd2 As New SqlCommand("select jb.jobNo from job as jb inner join clients as cl on jb.idClient=cl.idClient where cl.numberClient=" + arraycl(0) + "", conection.conn)
                Dim dr2 As SqlDataReader = cmd2.ExecuteReader()
                cmbJobs.Items.Clear()
                While dr2.Read()
                    cmbJobs.Items.Add(dr2("jobNo"))
                End While
                dr2.Close()
            End If

        Catch ex As Exception
            MsgBox(ex.Message())
        Finally
            conection.desconectar()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim array() = cmbClients.SelectedItem.ToString().Split("    ")
            Dim idClient As String = array(0)
            If idClient <> "" Or idClient IsNot Nothing Then
                Dim reportTS As New CompleteByDateRange
                reportTS.SetParameterValue("@clientnum", idClient)
                reportTS.SetParameterValue("@jobNum", If(chbAllJobs.Checked, 0, cmbJobs.SelectedItem))
                reportTS.SetParameterValue("@all", If(chbAllJobs.Checked, True, False))
                crvCompleteByDateRange.ReportSource = reportTS
            Else
                MsgBox("Please select a Client.")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub chbAllJobs_CheckedChanged(sender As Object, e As EventArgs) Handles chbAllJobs.CheckedChanged
        If chbAllJobs.Checked Then
            cmbJobs.Enabled = False
        Else
            cmbJobs.Enabled = True

        End If
    End Sub

    Private Sub cmbClients_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClients.SelectedIndexChanged
        Try
            If cmbClients.SelectedItem IsNot Nothing Then
                conection.conectar()
                Dim arraycl() As String = cmbClients.SelectedItem.ToString.Split(" ")
                Dim cmd2 As New SqlCommand("select jb.jobNo from job as jb inner join clients as cl on jb.idClient=cl.idClient where cl.numberClient=" + arraycl(0) + "", conection.conn)
                Dim dr2 As SqlDataReader = cmd2.ExecuteReader()
                cmbJobs.Items.Clear()
                While dr2.Read()
                    cmbJobs.Items.Add(dr2("jobNo"))
                End While
                dr2.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conection.desconectar()
        End Try
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class