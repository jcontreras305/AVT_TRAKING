Imports System.Runtime.InteropServices
Imports System.Data.SqlClient
Imports CrystalDecisions.ReportAppServer

Public Class ReportVacationEmployee
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

    Private Sub chbAllEmployees_CheckedChanged(sender As Object, e As EventArgs) Handles chbAllEmployees.CheckedChanged
        If chbAllEmployees.Checked Then
            cmbEmployee.Enabled = False
        Else
            cmbEmployee.Enabled = True
        End If
    End Sub

    Private Sub cmbYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbYear.SelectedIndexChanged
        chbAllEmployees.Checked = False
    End Sub

    Private Sub ReportVacationEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            conection.conectar()
            Dim cmd As New SqlCommand("select distinct DATEPART(year, dateWorked) as 'year' from  hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode
where wc.name like '%6.4%'", conection.conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            cmbYear.Items.Clear()
            While dr.Read()
                cmbYear.Items.Add(dr("year"))
            End While
            dr.Close()
            llenarComboEmployeeReports(cmbEmployee)
        Catch ex As Exception
            MsgBox(ex.Message())
        Finally
            conection.conectar()
        End Try
    End Sub

    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        Try
            Dim empNum As String = "0"
            Dim flag As Boolean = True
            If cmbYear.SelectedItem IsNot Nothing Or cmbYear.Text.Length = 4 Then
                If chbAllEmployees.Checked = False Then
                    Dim array() As String = If(cmbEmployee.SelectedItem IsNot Nothing, cmbEmployee.SelectedItem.ToString.Split(" "), "")
                    If (array.Length > 1) Then
                        empNum = array(0)
                    Else
                        MessageBox.Show("Please select a Employee", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        flag = False
                    End If
                End If
            Else
                MessageBox.Show("Please select a year. If the combo is empty is probably that do not exist Vacation records.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                flag = False
            End If
            If flag Then
                Dim rtp As New Vacation_Employee
                rtp.SetParameterValue("@year", If(cmbYear.SelectedItem IsNot Nothing, cmbYear.SelectedItem, CStr(System.DateTime.Today.Year)))
                rtp.SetParameterValue("@NoEmployee", empNum)
                rtp.SetParameterValue("@all", If(chbAllEmployees.Checked, True, False))
                rtp.SetParameterValue("@CompanyName", "brock")
                rtp.SetDatabaseLogon(UserDB, Pass, ServerName, DBName)
                crvVacationEmployee.ReportSource = rtp
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub
End Class