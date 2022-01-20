Imports System.Runtime.InteropServices
Imports System.Data.SqlClient

Public Class ReportEmployeesTime
    Dim conection As New ConnectioDB
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
            Dim cmd As New SqlCommand(" select jobNo from job", conection.conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            While dr.Read()
                cmbEmployees.Items.Add(CStr(dr("jobNo")))
            End While
        Catch ex As Exception
            MsgBox(ex.Message())
        Finally
            conection.desconectar()
        End Try
    End Sub

    Private Sub btnReportE_Click(sender As Object, e As EventArgs) Handles btnReportE.Click
        Dim array() = cmbEmployees.SelectedItem.ToString().Split("    ")
        Dim jobNo As String = array(0)
        If jobNo <> "" Or jobNo IsNot Nothing Then
            Dim reportTS As New EmployeesTime
            reportTS.SetParameterValue("@initialDate", validaFechaParaSQl(dtpInitialDate.Value.Date))
            reportTS.SetParameterValue("@finaldate", validaFechaParaSQl(dtpFinalDate.Value.Date))
            reportTS.SetParameterValue("@jobNum", jobNo)
            crvEmployeesTime.ReportSource = reportTS
        Else
            MsgBox("Please select a JobNo.")
        End If
    End Sub
End Class