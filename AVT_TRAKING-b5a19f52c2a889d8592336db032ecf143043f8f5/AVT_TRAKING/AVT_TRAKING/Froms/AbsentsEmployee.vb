Imports System.Runtime.InteropServices
Public Class Absentsemployee
    Public idEmpleado, numEmployee, firstName, lastName, explanation As String



    Dim mtdEmployees As New MetodosEmployees

    Private Sub Absentsemployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpDate.Format = DateTimePickerFormat.Custom
        dtpDate.Value = System.DateTime.Today
        sprHoras.Value = 0
        sprHoras.DecimalPlaces = 2
        sprHoras.Minimum = 0
        sprHoras.Increment = 0.5
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If sprHoras.Value > 0 Then
            If txtExplanation.Text <> "" Then
                Dim datos As New List(Of String)
                datos.Add(dtpDate.Value().ToString())
                datos.Add(sprHoras.Value.ToString())
                datos.Add(txtExplanation.Text)
                datos.Add(idEmpleado)
                If mtdEmployees.insertAbsents(datos) Then
                    MsgBox("Successful")
                    dtpDate.Value = CDate(System.DateTime.Today)
                    sprHoras.Value = 0
                    txtExplanation.Text = ""
                End If
            Else
                MessageBox.Show("You need to add hours.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("You need to add an explanation.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub


    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.Close()
    End Sub

    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(hWnd As IntPtr, wMsg As Integer, wParam As Integer, lParam As Integer)
    End Sub


    Private Sub TitleBar_MouseMove(sender As Object, e As MouseEventArgs) Handles TitleBar.MouseMove
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
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
End Class