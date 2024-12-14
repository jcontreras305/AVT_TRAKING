Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Imports System.Windows
Imports CrystalDecisions.ReportAppServer

Public Class ScaffoldDismantle
    Public windowOpened As String = "Scaffold"
    Dim dtScDm As DataTable
    Public idClient As String = "Lima Refining Company"
    Public jobNumber As String = "2428180010"
    Public idtag As String = "00088"
    Public numberClient As String = "109"
    Dim mtd As New ScaffioldDismantleMetods
    Dim mtdOther As New MetodosOthers
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
    Private Sub tbnAddEmailList_Click(sender As Object, e As EventArgs) Handles tbnAddEmailList.Click
        Try
            If mtdOther.saveUpdateEmailReport(tblEmailsReports, "dis", True) Then
                mtdOther.llenarTablaEmailReports(tblEmailsReports, "dis")
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub
    Private Sub btnDropEmailList_Click(sender As Object, e As EventArgs) Handles btnDropEmailList.Click
        Try
            If mtdOther.saveUpdateEmailReport(tblEmailsReports, "dis", False) Then
                mtdOther.llenarTablaEmailReports(tblEmailsReports, "dis")
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub
    Private Sub ScaffoldDismantle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblTitle.Text = "Scaffold Product " & If(windowOpened = "Scaffold", "Scaffold", If(windowOpened = "Modification", "Modification", "Dismantle"))
        llenarComboJobsReports(cmbJobNo, numberClient)
        llenarComboTagByJobNoReportsIDclient(cmbTag, numberClient, If(jobNumber = "", "", jobNumber), False, windowOpened)
        If jobNumber <> "" Then
            cmbJobNo.SelectedItem = cmbJobNo.Items(cmbJobNo.FindString(jobNumber))
            If idtag <> "" Then
                cmbTag.SelectedItem = cmbTag.Items(cmbTag.FindString(idtag))
            End If
        End If
        lblClient.Text = idClient
        If idClient <> "" Or JobNo <> "" Or idtag <> "" Then
            dtScDm = mtd.selectScaffolds(tblDismantles, idClient, windowOpened, JobNo, idtag)
            'tblDismantles.DataSource = dtScDm
        Else
            MsgBox("Not exist a client or dismantles.")
        End If

        mtdOther.llenarTablaEmailReports(tblEmailsReports, If(windowOpened = "Scaffold", "scf", If(windowOpened = "Dismantle", "dis", "mod")))
        Dim datosReport = mtdOther.selectSubjectEmail(If(windowOpened = "Scaffold", "scf", If(windowOpened = "Dismantle", "dis", "mod")))
        txtSubject.Text = datosReport(0)
        txtBodyEmail.Text = datosReport(1)
        btnSend.Enabled = False
    End Sub

    Private Sub cmbJobNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbJobNo.SelectedIndexChanged
        Try
            JobNo = cmbJobNo.Items(cmbJobNo.SelectedIndex)
            idtag = ""
            llenarComboTagByJobNoReportsIDclient(cmbTag, numberClient, JobNo, False, windowOpened)
            dtScDm = mtd.selectScaffolds(tblDismantles, idClient, windowOpened, JobNo, "")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmbTag_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTag.SelectedIndexChanged
        Try
            idtag = cmbTag.Items(cmbTag.SelectedIndex)
            dtScDm = mtd.selectScaffolds(tblDismantles, idClient, windowOpened, JobNo, idtag)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub chbAllJobs_CheckedChanged(sender As Object, e As EventArgs) Handles chbAllJobs.CheckedChanged
        If (chbAllJobs.Checked) Then
            dtScDm = mtd.selectScaffolds(tblDismantles, idClient, windowOpened, "", "")
            cmbJobNo.Enabled = False
            cmbTag.Enabled = False
            chbAllTag.Checked = True
        Else
            dtScDm = mtd.selectScaffolds(tblDismantles, idClient, windowOpened, "", "")
            cmbJobNo.Enabled = False
            cmbTag.Enabled = True
        End If

    End Sub

    Private Sub chbAllTag_CheckedChanged(sender As Object, e As EventArgs) Handles chbAllTag.CheckedChanged
        If chbAllTag.Checked Then
            dtScDm = mtd.selectScaffolds(tblDismantles, idClient, windowOpened, If(chbAllJobs.Checked, "", JobNo), "")
            cmbTag.Enabled = False
            cmbTag.Text = ""
        Else
            cmbTag.Enabled = True
        End If
    End Sub

    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        Try
            If tblDismantles.SelectedRows() IsNot Nothing And IsSelectARow() Then
                Dim tagAux = tblDismantles.SelectedRows(0).Cells(1).Value
                scfProduct1.SetParameterValue("@tagID", tagAux)
                scfProduct1.SetParameterValue("@modID", "")
                scfProduct1.SetParameterValue("@scf", If(windowOpened = "Scaffold", 1, 0))
                scfProduct1.SetParameterValue("@mod", If(windowOpened = "Modification", 1, 0))
                scfProduct1.SetParameterValue("@dis", If(windowOpened = "Dismantle", 1, 0))
                scfProduct1.SetParameterValue("@CompanyName", "Brock")
                If connecReport(scfProduct1) Then
                    crvReport.ReportSource = scfProduct1
                End If
            Else
                MsgBox("Please Select a project to load the report.")
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Private Function IsSelectARow() As Boolean
        Try
            Dim flag As Boolean = False
            For Each row As DataGridViewRow In tblDismantles.Rows
                If row.Cells(0).Value = True Then
                    flag = True
                    Exit For
                End If
            Next
            Return flag
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        Try
            If IsSelectARow() Then
                If DialogResult.Yes = MessageBox.Show("If you accept will create the PDF of the rows checked... ", "Important", MessageBoxButton.YesNo, MessageBoxImage.Question) Then
                    Dim lst As New List(Of String)
                    lblMessage.Text = "Message:" & "Reading tags selected..."
                    For Each row As DataGridViewRow In tblDismantles.Rows

                        If row.Cells("clmSend").Value = True Then
                            lst.Add(row.Cells("clmTag").Value)
                        End If
                    Next
                    Dim path As String = ""
                    If mtd.saveTagList(lst) Then ''ya se guardaron los tag a consultar
                        MessageBox.Show("Please select a Path to seve the Files?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        Dim fbd As New FolderBrowserDialog
                        If fbd.ShowDialog() = DialogResult.OK Then
                            path = fbd.SelectedPath
                        End If
                        Dim flagEmail As DialogResult = MessageBox.Show("Would you like to send the Report after to be download?", "Important", MessageBoxButton.YesNo, MessageBoxImage.Question)
                        Dim listEmail As New List(Of String)
                        Dim ownEmail As String() = mtdOther.selectOwnEmail()
                        If flagEmail = DialogResult.Yes Then
                            If ownEmail(0) <> "" Then
                                For Each row As DataGridViewRow In tblEmailsReports.Rows()
                                    If row.Cells(2).Value Then
                                        listEmail.Add(row.Cells(0).Value)
                                    End If
                                Next
                            Else
                                MsgBox("You did not assig you own Email.")
                                flagEmail = DialogResult.No
                            End If
                        End If

                        For Each item As String In lst
                            lblMessage.Text = "Message:" & " Working in the report of tag :" & item
                            scfProduct1.SetParameterValue("@tagID", item)
                            scfProduct1.SetParameterValue("@modID", "")
                            scfProduct1.SetParameterValue("@scf", If(windowOpened = "Scaffold", 1, 0))
                            scfProduct1.SetParameterValue("@mod", If(windowOpened = "Modification", 1, 0))
                            scfProduct1.SetParameterValue("@dis", If(windowOpened = "Dismantle", 1, 0))
                            scfProduct1.SetParameterValue("@CompanyName", "Brock")
                            If connecReport(scfProduct1) Then
                                'crvReport.ReportSource = scfProduct1
                            End If
                            Dim TotalPath As String = path & "\" & windowOpened & "Product" & item & ".pdf"
                            scfProduct1.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, TotalPath)
                            If listEmail.Count > 0 And flagEmail Then
                                lblMessage.Text = "Message:" & " Sending Email of report of tag :" & item
                                mtdOther.sendEmail(ownEmail(0), ownEmail(1), txtSubject.Text, txtBodyEmail.Text, listEmail, TotalPath)
                            End If
                        Next
                        lblMessage.Text = "Message:" & " End."
                        MsgBox("Successful.")
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Private Sub SelectAll_Click(sender As Object, e As EventArgs) Handles SelectAll.Click
        For Each row As DataGridViewRow In tblDismantles.Rows
            row.Cells(0).Value = True
        Next
        If IsSelectARow() Then
            btnSend.Enabled = True
        End If
    End Sub

    Private Sub tblDismantles_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles tblDismantles.CellValueChanged
        If IsSelectARow() Then
            btnSend.Enabled = True
        Else
            btnSend.Enabled = False
        End If
    End Sub
End Class

Public Class ScaffioldDismantleMetods
    Inherits ConnectioDB
    Dim tbl As New DataTable

    Public Function selectScaffolds(ByVal tblDismantle As DataGridView, ByVal ClientName As String, Optional jobNo As String = "", Optional idTag As String = "") As DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("select sc.status , ds.tag as 'Tag',CONVERT(NVARCHAR,ds.dismantleDate,101) as 'Dismantle Date',CONVERT(NVARCHAR, sc.buildDate,101) as 'Build Date', jb.jobNo as 'JobNo' , CONCAT(wo.idWO , '-',tk.task)as 'WorkOrder', cl.companyName as 'Client',sc.contact  as 'Contact' from dismantle  as ds
inner join scaffoldTraking as sc on sc.tag = ds.tag 
inner join task  as tk on tk.idAux = sc.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO 
inner join projectOrder as po on po.idPO= wo.idPO and po.jobNo = wo.jobNo 
inner join job as jb on jb.jobNo = po.jobNo 
inner join clients as cl on cl.idClient = jb.idClient
where cl.companyName = '" + ClientName + "' " + If(jobNo = "", "", " and jb.jobNo = " + jobNo) + If(idTag = "", "", " and ds.tag = " + idTag), conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            If tbl.Rows IsNot Nothing Then
                tbl.Rows.Clear()
            End If
            If tbl.Columns.Count = 0 Then
                creaColumnas()
            End If
            tblDismantle.Rows.Clear()
            While dr.Read()
                tbl.Rows.Add(False, dr("Tag"), dr("Dismantle Date"), dr("Build Date"), dr("JobNo"), dr("WorkOrder"), dr("Client"), dr("Contact"))
                tblDismantle.Rows.Add(False, dr("Tag"), dr("Dismantle Date"), dr("Build Date"), dr("JobNo"), dr("WorkOrder"), dr("Client"), dr("Contact"))
            End While
            dr.Close()
            Return tbl
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
    Public Function selectScaffolds(ByVal tblDismantle As DataGridView, ByVal ClientName As String, ByVal winOpened As String, Optional jobNo As String = "", Optional idTag As String = "") As DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand
            cmd.Connection = conn
            Select Case winOpened
                Case "Scaffold"
                    cmd.CommandText = "select sc.status , sc.tag as 'Tag', ISNULL(CONVERT(nvarchar, ds.dismantleDate,101),'') as 'Dismantle Date', CONVERT(nvarchar, sc.buildDate,101) as 'Build Date', jb.jobNo as 'JobNo' , CONCAT(wo.idWO , '-',tk.task)as 'WorkOrder', cl.companyName as 'Client',sc.contact  as 'Contact'
from scaffoldTraking as sc 
left join dismantle as ds on ds.tag = sc.tag 
inner join task  as tk on tk.idAux = sc.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO 
inner join projectOrder as po on po.idPO= wo.idPO and po.jobNo = wo.jobNo 
inner join job as jb on jb.jobNo = po.jobNo 
inner join clients as cl on cl.idClient = jb.idClient
where cl.companyName = '" + ClientName + "' " + If(jobNo = "", "", " and jb.jobNo = " + jobNo) + If(idTag = "", "", " and sc.tag = " + idTag)
                Case "Dismantle"
                    cmd.CommandText = "select sc.status , ds.tag as 'Tag',ds.dismantleDate as 'Dismantle Date', sc.buildDate as 'Build Date', jb.jobNo as 'JobNo' , CONCAT(wo.idWO , '-',tk.task)as 'WorkOrder', cl.companyName as 'Client',sc.contact  as 'Contact' from dismantle  as ds
inner join scaffoldTraking as sc on sc.tag = ds.tag 
inner join task  as tk on tk.idAux = sc.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO 
inner join projectOrder as po on po.idPO= wo.idPO and po.jobNo = wo.jobNo 
inner join job as jb on jb.jobNo = po.jobNo 
inner join clients as cl on cl.idClient = jb.idClient
where cl.companyName = '" + ClientName + "' " + If(jobNo = "", "", " and jb.jobNo = " + jobNo) + If(idTag = "", "", " and ds.tag = " + idTag)
                Case Else

            End Select
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            If tbl.Rows IsNot Nothing Then
                tbl.Rows.Clear()
            End If
            If tbl.Columns.Count = 0 Then
                creaColumnas()
            End If
            tblDismantle.Rows.Clear()
            While dr.Read()
                tbl.Rows.Add(False, dr("Tag"), dr("Dismantle Date"), dr("Build Date"), dr("JobNo"), dr("WorkOrder"), dr("Client"), dr("Contact"))
                tblDismantle.Rows.Add(False, dr("Tag"), dr("Dismantle Date"), dr("Build Date"), dr("JobNo"), dr("WorkOrder"), dr("Client"), dr("Contact"))
            End While
            dr.Close()
            Return tbl
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function saveTagList(ByVal lst As List(Of String)) As Boolean
        Try
            conectar()
            Dim cmd1 As New SqlCommand("delete from RPTDismantleProduct", conn)
            If cmd1.ExecuteNonQuery() >= 0 Then
                Dim cmd2 As New SqlCommand("insert into RPTDismantleProduct values ('@item')", conn)
                For Each item As String In lst
                    cmd2.CommandText = cmd2.CommandText.Replace("@item", item)
                    cmd2.ExecuteNonQuery()
                Next
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

    End Function

    Sub creaColumnas()
        tbl.Columns.Add("Send")
        tbl.Columns.Add("Tag")
        tbl.Columns.Add("Dismantle Date")
        tbl.Columns.Add("Buil Date")
        tbl.Columns.Add("JobNo")
        tbl.Columns.Add("WorkOrder")
        tbl.Columns.Add("Client")
        tbl.Columns.Add("Contact")
    End Sub
End Class