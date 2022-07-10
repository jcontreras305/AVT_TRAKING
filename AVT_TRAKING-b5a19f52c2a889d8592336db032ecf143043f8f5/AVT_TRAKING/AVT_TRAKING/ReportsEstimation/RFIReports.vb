Imports System.Runtime.InteropServices
Public Class RFIReports
    Dim mtdRFISCF As New MetodosRFIScaffold
    'Dim mtdRFIEquip  As New MetodosRFIEquipment
    'Dim mtdRFIPiping  As New MetodosRFIPiping
    Public TypeRFI As String = "RFI"
    Public projectId As String = ""
    Public idDrawingNum As String = ""
    Public idTag As String = ""
    Public idRFI As String = ""
    Dim tblRFISCF As New Data.DataTable
    Dim flagLoad As Boolean = True
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
    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub
    Private Sub RFIReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblTittleForm.Text = TypeRFI
        If projectId = "" Then
            mtdRFISCF.selectDrawing(cmbDrawing)
        Else
            mtdRFISCF.selectDrawing(cmbDrawing, projectId)
        End If
        If idDrawingNum <> "" Then
            cmbDrawing.SelectedItem = cmbDrawing.Items(cmbDrawing.FindString(idDrawingNum))
            Select Case TypeRFI
                Case "Scaffold"
                    lblTag.Text = "Scaffold Tag."
                    mtdRFISCF.selectTagDrawing(idDrawingNum, cmbTag)
                    If idTag <> "" Then
                        cmbTag.SelectedItem = cmbTag.Items(cmbTag.FindString(idTag))
                        tblRFISCF = mtdRFISCF.selectRFI(idTag, cmbRFI)
                        If idRFI <> "" Then
                            cmbRFI.SelectedItem = cmbRFI.Items(cmbRFI.FindString(idRFI))
                        End If
                    End If
                Case "Equipemnt"
                    lblTag.Text = "Equipment Tag."


                Case "Piping"
                    lblTag.Text = "Piping Tag."
            End Select
            flagLoad = False
        End If
    End Sub

    Private Sub cmbDrawing_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDrawing.SelectedIndexChanged
        Try
            If flagLoad = True Then
                If cmbDrawing.SelectedItem IsNot Nothing Then
                    Select Case TypeRFI
                        Case "Scaffold"
                            Dim array() As String = cmbDrawing.SelectedItem.ToString.Split("|")
                            idDrawingNum = array(0)
                            mtdRFISCF.selectTagDrawing(idDrawingNum, cmbTag)
                            idTag = ""
                            cmbRFI.Items.Clear()
                            idRFI = ""
                        Case "Equipemnt"
                            lblTag.Text = "Equipment Tag."


                        Case "Piping"
                            lblTag.Text = "Piping Tag."
                    End Select
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbTag_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTag.SelectedIndexChanged
        Try
            If flagLoad = True Then
                If cmbTag.SelectedItem IsNot Nothing Then
                    Select Case TypeRFI
                        Case "Scaffold"
                            Dim array() As String = cmbTag.SelectedItem.ToString.Split("|")
                            idTag = array(0)
                            mtdRFISCF.selectRFI(idTag, cmbRFI)
                            idRFI = ""
                        Case "Equipemnt"
                            lblTag.Text = "Equipment Tag."


                        Case "Piping"
                            lblTag.Text = "Piping Tag."
                    End Select
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbRFI_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRFI.SelectedIndexChanged
        Try
            If flagLoad = True Then
                If cmbDrawing.SelectedItem IsNot Nothing Then
                    Select Case TypeRFI
                        Case "Scaffold"
                            Dim array() As String = cmbRFI.SelectedItem.ToString.Split("|")
                            idRFI = array(0)
                        Case "Equipemnt"
                            lblTag.Text = "Equipment Tag."
                        Case "Piping"
                            lblTag.Text = "Piping Tag."
                    End Select
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        Try
            If idDrawingNum <> "" And idTag <> "" And idRFI <> "" Then
                Select Case TypeRFI
                    Case "Scaffold"
                        Dim reportTs As New RFIReportSCF
                        reportTs.SetParameterValue("@idRFI", idRFI)
                        reportTs.SetParameterValue("@tag", idTag)
                        reportTs.SetParameterValue("@idDrawingNum", idDrawingNum)
                        'reportTs.SetParameterValue("@CompanyName", "Brock")
                        crvReport.ReportSource = reportTs
                    Case ""
                    Case ""
                End Select


            Else
                MessageBox.Show("Please especifi the de Scaffold RFI.", "Impotant", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub
End Class