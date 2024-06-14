Imports System.Runtime.InteropServices
Public Class ScaffoldMaterialInventory
    Private Sub ScaffoldMaterialInventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarComboClientsReports(cmbClients)
    End Sub
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.Close()
    End Sub
    Private Sub btnMinimize_Click(sender As Object, e As EventArgs) Handles btnMinimaize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub btnRestore_Click(sender As Object, e As EventArgs) Handles btnMinimaize.Click
        WindowState = FormWindowState.Normal
        btnMinimaize.Visible = False
        btnMaximize.Visible = True
    End Sub
    Private Sub btnMaximize_Click(sender As Object, e As EventArgs) Handles btnMaximize.Click
        MaximizedBounds = Screen.FromHandle(Me.Handle).WorkingArea
        WindowState = FormWindowState.Maximized
        btnMaximize.Visible = False
        btnMinimaize.Visible = True
    End Sub
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(hWnd As IntPtr, wMsg As Integer, wParam As Integer, lParam As Integer)
    End Sub
    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim array() As String
            If cmbClients.SelectedItem IsNot Nothing Then
                array = cmbClients.SelectedItem.ToString().Split(" ")
            Else
                array = {"0"}
            End If

            Dim clNum As String = array(0)
            If clNum <> "0" Or chbAll.Checked Then
                Dim reportTs As New SCFMaterialInventory
                reportTs.SetParameterValue("@numberClient", CInt(clNum))
                reportTs.SetParameterValue("@all", If(chbAll.Checked, 1, 0))
                reportTs.SetParameterValue("@CompanyName", "Brock")
                crvReport.ReportSource = reportTs
            Else
                MsgBox("Please select a Client.")
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Private Sub chbAll_CheckedChanged(sender As Object, e As EventArgs) Handles chbAll.CheckedChanged
        If chbAll.Checked Then
            cmbClients.Enabled = False
        Else
            cmbClients.Enabled = True
        End If
    End Sub
End Class