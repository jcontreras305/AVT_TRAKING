Imports System.Runtime.InteropServices
Public Class ScaffoldProductReport
    Public tagNum As String
    Public ModNum As String
    Public WindowStart As String
    Private scf, modi, dis As Boolean '
    Dim mtdOther As New MetodosOthers
    Private Sub ScaffoldProduct_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblTag.Text = "Tag No: " + tagNum
        lblMod.Visible = False
        If WindowStart = "scf" Then
            scf = True
            modi = False
            dis = False
        ElseIf WindowStart = "mod" Then
            lblMod.Text = "Mod No: " + ModNum
            lblMod.Visible = True
            scf = False
            modi = True
            dis = False
        ElseIf WindowStart = "dis" Then
            scf = False
            modi = False
            dis = True
        End If
        mtdOther.llenarTablaEmailReports(tblEmailsReports, WindowStart)
        Dim datosReport = mtdOther.selectSubjectEmail(WindowStart)
        txtSubject.Text = datosReport(0)
        txtBodyEmail.Text = datosReport(1)
        btnSend.Enabled = False
    End Sub
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
    Private Sub tbnAddEmailList_Click(sender As Object, e As EventArgs) Handles tbnAddEmailList.Click
        Try
            If mtdOther.saveUpdateEmailReport(tblEmailsReports, WindowStart, True) Then
                mtdOther.llenarTablaEmailReports(tblEmailsReports, WindowStart)
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub
    Private Sub btnDropEmailList_Click(sender As Object, e As EventArgs) Handles btnDropEmailList.Click
        Try
            If mtdOther.saveUpdateEmailReport(tblEmailsReports, WindowStart, False) Then
                mtdOther.llenarTablaEmailReports(tblEmailsReports, WindowStart)
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Private Sub tblEmailsReports_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles tblEmailsReports.CellEndEdit
        'Try
        '    If mtdOther.saveUpdateEmailReport(tblEmailsReports.CurrentRow, WindowStart) Then
        '        mtdOther.llenarTablaEmailReports(tblEmailsReports, WindowStart)
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message())
        'End Try
    End Sub
    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        Dim ownEmail As String() = mtdOther.selectOwnEmail()
        If ownEmail(0) <> "" Then
            Dim listEmail As New List(Of String)
            For Each row As DataGridViewRow In tblEmailsReports.Rows()
                If row.Cells(2).Value Then
                    listEmail.Add(row.Cells(0).Value)
                End If
            Next
            If listEmail.Count > 0 Then
                Dim dar As DialogResult = MessageBox.Show("Would you like to save this report?", "Important", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                If dar = DialogResult.Yes Then
                    Dim sd As New SaveFileDialog
                    sd.DefaultExt = ".pdf"
                    sd.FileName = "ScaffoldProduct" + tagNum + If(ModNum <> "", "_" + ModNum, "")
                    If DialogResult.OK = sd.ShowDialog() Then
                        reportTs.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, sd.FileName)
                    End If
                    mtdOther.sendEmail(ownEmail(0), ownEmail(1), txtSubject.Text, txtBodyEmail.Text, listEmail, sd.FileName)
                ElseIf dar = DialogResult.No Then
                    reportTs.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, "c:\TMP\" + tagNum + If(ModNum <> "", "_" + ModNum, "") + ".pdf")
                    mtdOther.sendEmail(ownEmail(0), ownEmail(1), txtSubject.Text, txtBodyEmail.Text, listEmail, "c:\TMP\" + tagNum + If(ModNum <> "", "_" + ModNum, "") + ".pdf")
                    System.IO.File.Delete("c:\TMP\" + tagNum + If(ModNum <> "", "_" + ModNum, "") + ".pdf")
                End If
            Else
                MessageBox.Show("Please, assign the emails to send the Report.")
            End If
        End If
    End Sub

    Private Sub btnSubjectEmail_Click(sender As Object, e As EventArgs) Handles btnSubjectEmail.Click
        Try
            If mtdOther.saveUpdateSubjet(WindowStart, txtSubject.Text, txtBodyEmail.Text) Then
                MsgBox("Successful")
            Else
                MsgBox("Error")
                Dim datosEmail = mtdOther.selectSubjectEmail(WindowStart)
                txtSubject.Text = datosEmail(0)
                txtBodyEmail.Text = datosEmail(1)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Dim reportTs As New SCFProduct
    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        Try
            reportTs.SetParameterValue("@tagID", tagNum)
            reportTs.SetParameterValue("@modID", ModNum)
            reportTs.SetParameterValue("@scf", If(scf, 1, 0))
            reportTs.SetParameterValue("@mod", If(modi, 1, 0))
            reportTs.SetParameterValue("@dis", If(dis, 1, 0))
            reportTs.SetParameterValue("@CompanyName", "Brock")
            crvReport.ReportSource = reportTs
            btnSend.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message())
            btnSend.Enabled = False
        End Try
    End Sub

End Class