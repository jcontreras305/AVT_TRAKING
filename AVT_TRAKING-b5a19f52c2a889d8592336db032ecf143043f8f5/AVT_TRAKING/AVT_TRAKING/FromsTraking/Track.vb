Imports Microsoft.Office.Core
Imports Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices
Public Class Track
    Dim mtdHPW As New MetodosHoursPeerWeek
    Dim listDefault As New List(Of String)
    Dim listHeaderT As New List(Of String)
    Dim listHeaderV As New List(Of Boolean)
    Dim numberClient As String
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.Close()
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

    Private Sub tbnFindDocument_Click(sender As Object, e As EventArgs)
        Dim opn As New OpenFileDialog

    End Sub

    Private Sub btnFindExcel_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            If cmbClient.SelectedItem IsNot Nothing Then
                If cmbJobs.SelectedItem IsNot Nothing Or chbAllJobs.Checked Then
                    txtMessage.Text = "Message: Loading data..."
                    pdbPercent.Value = 10
                    Dim array() As String = cmbClient.SelectedItem.ToString().Split(" ")
                    Dim tblhrs = mtdHPW.selectHorasTrack(dtpBeginDate.Value, dtpEndDate.Value, array(0), If(chbAllJobs.Checked, "", cmbJobs.SelectedItem.ToString()))
                    pdbPercent.Value = pdbPercent.Value + 20
                    Dim tblPdm = mtdHPW.selectPerdiemTrack(dtpBeginDate.Value, dtpEndDate.Value, array(0), If(chbAllJobs.Checked, "", cmbJobs.SelectedItem.ToString()))
                    pdbPercent.Value = pdbPercent.Value + 20
                    If tblPdm IsNot Nothing And tblhrs IsNot Nothing Then
                        txtMessage.Text = "Message: Reading data..."
                        tblTrack.Rows.Clear()
                        Dim cont As Integer = 0
                        For Each row1 As DataRow In tblhrs.Rows
                            cont += 1
                            txtMessage.Text = "Message: Writing data of hours worked...Row number(" + cont.ToString + " of " + tblhrs.Rows.Count.ToString() + ")."
                            '                  RECORD ID                  , FORCE OR REJECT, SOURCE       ,       DATE                  , ORDER TYPE    , LOCATION ID   , COMPANY CODE  ,        ROSOURSE ID          ,     RESOURSE NAME           ,     AREA      ,  GROUP NAME   ,  AGREEMENT    ,          SKILL TYPE         ,               SHIFT         ,          LEVEL 1 ID         , LEVEL 2 ID    ,   LEVEL 3 ID  ,  LEVEL 4 ID    ,        HOURS TOTAL           , HRS TOTAL ACTCODE ,         S/T  (HRS)          ,   S/T  HRS ACTI CODE        ,           O/T HRS            ,           O/T HRS ACT CODE   ,            D/T HRS             ,         D/T HRS ACT CODE     ,        EXTRA CHANGUES      ,EXT CHARG ACT CODE,      EXTRA    ,    EXTRA 1     ,    EXTRA 2     ,     ADD TIME   ,      PAY TYPE  ,      R4        ,        R5      ,       R6       ,     GL ACCOUNT ,   ST ADDRESS   ,    OT ADDRESS  ,  DT ADDRESS    ,   R4 ADDRESS   ,  R5 ADDRESS    ,  R6 ADDRESS                                                                                                                                              
                            'tblTrack.Rows.Add(row1.ItemArray(0).ToString(), listDefault(0), listDefault(1), row1.ItemArray(1).ToString(), listDefault(2), listDefault(3), listDefault(4), row1.ItemArray(2).ToString(), row1.ItemArray(3).ToString(), listDefault(5), listDefault(6), listDefault(7), row1.ItemArray(4).ToString(), row1.ItemArray(5).ToString(), row1.ItemArray(6).ToString(), listDefault(8), listDefault(9), listDefault(10), row1.ItemArray(14).ToString(), row1.ItemArray(15), row1.ItemArray(8).ToString(), row1.ItemArray(9).ToString(), row1.ItemArray(10).ToString(), row1.ItemArray(11).ToString(), row1.ItemArray(12).ToString(), row1.ItemArray(13).ToString(), row1.ItemArray(16).ToString(), listDefault(13), listDefault(14), listDefault(15), listDefault(16), listDefault(17), listDefault(18), listDefault(19), listDefault(20), listDefault(21), listDefault(22), listDefault(23), listDefault(24), listDefault(25), listDefault(26), listDefault(27), listDefault(28))
                            '                  RECORD ID                  , FORCE OR REJECT, SOURCE       ,       DATE                  , ORDER TYPE    , LOCATION ID   , COMPANY CODE  ,        ROSOURSE ID          ,     RESOURSE NAME           ,     AREA      ,  GROUP NAME   ,  AGREEMENT    ,          SKILL TYPE         ,               SHIFT         ,          LEVEL 1 ID         ,           LEVEL 2 ID        ,          LEVEL 3 ID         ,  LEVEL 4 ID   ,        HOURS TOTAL           , HRS TOTAL ACTCODE ,         S/T  (HRS)          ,   S/T  HRS ACTI CODE        ,           O/T HRS            ,           O/T HRS ACT CODE   ,            D/T HRS             ,         D/T HRS ACT CODE    ,        EXTRA CHANGUES      ,EXT CHARG ACT CODE,      EXTRA    ,    EXTRA 1     ,    EXTRA 2     ,     ADD TIME   ,      PAY TYPE  ,      R4        ,        R5      ,       R6       ,     GL ACCOUNT ,   ST ADDRESS   ,    OT ADDRESS  ,  DT ADDRESS    ,   R4 ADDRESS   ,  R5 ADDRESS    ,  R6 ADDRESS                                                                                                                                              
                            tblTrack.Rows.Add(row1.ItemArray(0).ToString(), listDefault(0), listDefault(1), row1.ItemArray(1).ToString(), listDefault(2), listDefault(3), listDefault(4), row1.ItemArray(2).ToString(), row1.ItemArray(3).ToString(), listDefault(5), listDefault(6), listDefault(7), row1.ItemArray(4).ToString(), row1.ItemArray(5).ToString(), row1.ItemArray(6).ToString(), row1.ItemArray(7).ToString(), row1.ItemArray(8).ToString(), listDefault(8), row1.ItemArray(15).ToString(), row1.ItemArray(16), row1.ItemArray(9).ToString(), row1.ItemArray(10).ToString(), row1.ItemArray(11).ToString(), row1.ItemArray(12).ToString(), row1.ItemArray(13).ToString(), row1.ItemArray(14).ToString(), row1.ItemArray(17).ToString(), listDefault(11), listDefault(12), listDefault(13), listDefault(14), listDefault(15), listDefault(16), listDefault(17), listDefault(18), listDefault(19), listDefault(20), listDefault(21), listDefault(22), listDefault(23), listDefault(24), listDefault(25), listDefault(26))
                        Next
                        pdbPercent.Value = pdbPercent.Value + 30
                        'cont = 0
                        'For Each row As DataRow In tblPdm.Rows()
                        '    cont += 1
                        '    txtMessage.Text = "Message: Writing data of Perdiem used...Row number(" + cont.ToString + " of " + tblPdm.Rows.Count.ToString() + ")."
                        '    For Each row2 As DataGridViewRow In tblTrack.Rows()
                        '        If row2.Cells("Date1").Value = row.ItemArray(0) And row2.Cells("ResourceID").Value = row.ItemArray(1) And row2.Cells("ResourceName").Value = row.ItemArray(2) And row2.Cells("Level1ID").Value = row.ItemArray(3) Then
                        '            row2.Cells("ExtraCharges").Value = row.ItemArray(5)
                        '            Exit For
                        '        End If
                        '    Next
                        'Next
                        pdbPercent.Value = pdbPercent.Value + 5
                    End If
                    actulizaColumnasTblTrack()
                    txtMessage.Text = "Message: End."
                    pdbPercent.Value = 100
                Else
                    MessageBox.Show("Please select a Job Number to continue or select All Jobs", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Else
                MessageBox.Show("Please select a Client to continue or select All Jobs", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            pdbPercent.Value = 0
        End Try
    End Sub

    Private Sub btnFindDoc_Click(sender As Object, e As EventArgs) Handles btnFindDoc.Click
        Try
            pdbPercent.Value = 5
            txtMessage.Text = "Message: Meaking new Excel Document."
            Dim ApExcel = New Microsoft.Office.Interop.Excel.Application
            Dim libro = ApExcel.Workbooks.Add()
            libro.Sheets(1).Name = "Track"
            Try

                txtMessage.Text = "Message: Inserting columns headres..."
                Dim listColumnsV As New List(Of String)
                For Each columnT As DataGridViewColumn In tblTrack.Columns
                    If columnT.Visible = True Then
                        listColumnsV.Add(columnT.HeaderText)
                    End If
                Next
                'Dim colums() As String = {tblTrack.Columns(0).HeaderText, tblTrack.Columns(1).HeaderText, tblTrack.Columns(2).HeaderText, tblTrack.Columns(3).HeaderText, tblTrack.Columns(4).HeaderText, tblTrack.Columns(5).HeaderText, tblTrack.Columns(6).HeaderText, tblTrack.Columns(7).HeaderText, tblTrack.Columns(8).HeaderText, tblTrack.Columns(9).HeaderText, tblTrack.Columns(10).HeaderText, tblTrack.Columns(11).HeaderText, tblTrack.Columns(12).HeaderText, tblTrack.Columns(13).HeaderText, tblTrack.Columns(14).HeaderText, tblTrack.Columns(15).HeaderText, tblTrack.Columns(16).HeaderText, tblTrack.Columns(17).HeaderText, tblTrack.Columns(18).HeaderText, tblTrack.Columns(19).HeaderText, tblTrack.Columns(20).HeaderText, tblTrack.Columns(21).HeaderText, tblTrack.Columns(22).HeaderText, tblTrack.Columns(23).HeaderText, tblTrack.Columns(24).HeaderText, tblTrack.Columns(25).HeaderText, tblTrack.Columns(26).HeaderText, tblTrack.Columns(27).HeaderText, tblTrack.Columns(28).HeaderText, tblTrack.Columns(29).HeaderText, tblTrack.Columns(30).HeaderText, tblTrack.Columns(31).HeaderText, tblTrack.Columns(32).HeaderText, tblTrack.Columns(33).HeaderText, tblTrack.Columns(34).HeaderText, tblTrack.Columns(35).HeaderText, tblTrack.Columns(36).HeaderText, tblTrack.Columns(37).HeaderText, tblTrack.Columns(38).HeaderText, tblTrack.Columns(39).HeaderText, tblTrack.Columns(40).HeaderText, tblTrack.Columns(41).HeaderText, tblTrack.Columns(42).HeaderText}
                Dim countColumns As Integer = 1
                For Each item As String In listColumnsV
                    libro.Sheets(1).cells(1, countColumns) = item
                    libro.Sheets(1).cells(1, countColumns).Interior.Color = RGB(255, 255, 0)
                    countColumns += 1
                Next
                txtMessage.Text = "Message: Inserting data..."
                pdbPercent.Value = pdbPercent.Value + 5
                Dim increment = (90 / tblTrack.Rows.Count())
                Dim flagIncrement = If(increment > 1, (90 / tblTrack.Rows.Count()), If(increment < 1 And increment > 0.5, 2, If(increment < 0.5 And increment > 0.25, 3, 4)))
                Dim count As Integer = 2
                Dim countIncrement As Integer = 0

                For Each row As DataGridViewRow In tblTrack.Rows()
                    Dim contCell As Integer = 0
                    Dim countVisibleColumn As Integer = 1
                    For Each cell As DataGridViewCell In row.Cells
                        If cell.Visible = True Then
                            libro.Sheets(1).cells(count, countVisibleColumn) = row.Cells(contCell).Value.ToString()
                            countVisibleColumn += 1
                        End If
                        contCell += 1
                    Next
                    count += 1
                    countIncrement += 1
                    txtMessage.Text = "Message: Inserting data...Row number (" + count.ToString() + ")."
                    If pdbPercent.Value <= 96 Then
                        If flagIncrement = countIncrement Then
                            pdbPercent.Value = pdbPercent.Value + 1
                            countIncrement = 0
                        End If
                    End If
                Next
                Dim sd As New SaveFileDialog
                sd.DefaultExt = "*.xlsx"
                sd.FileName = "Track" + System.DateTime.Today.Month.ToString() + "-" + System.DateTime.Today.Day.ToString()
                sd.Filter = "Archivos de Excel (*.xlsx)|*.xlsx"
                If DialogResult.OK = sd.ShowDialog() Then
                    txtMessage.Text = "Message: Saving file."
                    libro.SaveAs(sd.FileName)
                End If
                pdbPercent.Value = 100
            Catch ex As Exception
                MsgBox(ex.Message())
                pdbPercent.Value = 0
                txtMessage.Text = "Message: End."
            Finally
                txtMessage.Text = "Message: Sleeping..."
                NAR(libro.Sheets(1))
                libro.Close(False)
                NAR(libro)
                ApExcel.Quit()
                NAR(ApExcel)
                pdbPercent.Value = 0
                txtMessage.Text = "Message: Complete."
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
            pdbPercent.Value = 0
        End Try
    End Sub

    Private Sub Track_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarComboClientsReports(cmbClient)
        If cmbClient.SelectedItem IsNot Nothing Then
            Dim array() As String = cmbClient.SelectedItem.ToString.Split(" ")
            mtdHPW.llenarTablaDefaultElemtTrack(tblDefaultElements, array(0))
        End If
        actualizarListDefault()
        btnSave.Enabled = False
        btnSaveHeaderText.Enabled = False
        llenarComboClientsReports(cmbClient)
    End Sub
    Dim selectColumnTblDeault As String = ""
    Private Sub tblDefaultElements_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles tblDefaultElements.CellMouseDoubleClick
        btnUpdateCancel.Text = "Cancel"
        selectColumnTblDeault = tblDefaultElements.CurrentRow.Cells(0).Value.ToString()
        lblColumnName.Text = "Column:" + tblDefaultElements.CurrentRow.Cells(0).Value.ToString()
        txtDefaultElement.Text = tblDefaultElements.CurrentRow.Cells(1).Value.ToString()
        btnSave.Enabled = True
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If mtdHPW.updateDefaultElement(selectColumnTblDeault, txtDefaultElement.Text, numberClient) Then
                lblColumnName.Text = "Column:"
                btnUpdateCancel.Text = "Update"
                txtDefaultElement.Text = ""
                btnSave.Enabled = False

                mtdHPW.llenarTablaDefaultElemtTrack(tblDefaultElements, numberClient)
                actualizarListDefault()
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Private Sub btnUpdateCancel_Click(sender As Object, e As EventArgs) Handles btnUpdateCancel.Click
        If btnUpdateCancel.Text = "Update" Then
            btnUpdateCancel.Text = "Cancel"
            selectColumnTblDeault = tblDefaultElements.CurrentRow.Cells(0).Value.ToString()
            lblColumnName.Text = "Column:" + tblDefaultElements.CurrentRow.Cells(0).Value.ToString()
            txtDefaultElement.Text = tblDefaultElements.CurrentRow.Cells(1).Value.ToString()
            btnSave.Enabled = True
        ElseIf btnUpdateCancel.Text = "Cancel" Then
            btnUpdateCancel.Text = "Update"
            lblColumnName.Text = "Column:"
            txtDefaultElement.Text = ""
            btnSave.Enabled = False
        End If
    End Sub

    Private Sub actualizarListDefault()
        listDefault.Clear()
        For Each row As DataGridViewRow In tblDefaultElements.Rows
            listDefault.Add(row.Cells(1).Value.ToString())
        Next
    End Sub
    Private Sub actualizarListHeader()
        listHeaderT.Clear()
        listHeaderV.Clear()
        For Each row As DataGridViewRow In tblFormatColumns.Rows
            listHeaderV.Add(row.Cells(1).Value.ToString())
            listHeaderT.Add(row.Cells(2).Value.ToString())
        Next
    End Sub

    Dim selectColumnTblHeader As String = ""
    Private Sub tblFormatColumns_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles tblFormatColumns.CellMouseDoubleClick
        btnUpdateCancelHeaderText.Text = "Update"
        btnSaveHeaderText.Enabled = True
        btnUpdateCancelHeaderText.Text = "Cancel"
        selectColumnTblHeader = tblFormatColumns.CurrentRow.Cells(0).Value.ToString()
        lblColumnNameHeader.Text = "Column: " + tblFormatColumns.CurrentRow.Cells(0).Value.ToString()
        If tblFormatColumns.CurrentRow.Cells(1).Value = True Then
            chbVisibleHeaderText.Checked = True
        Else
            chbVisibleHeaderText.Checked = False
        End If
        txtHeaderText.Text = tblFormatColumns.CurrentRow.Cells(2).Value.ToString()
    End Sub
    Private Sub btnUpdateCancelHeaderText_Click(sender As Object, e As EventArgs) Handles btnUpdateCancelHeaderText.Click
        If btnUpdateCancelHeaderText.Text = "Cancel" Then
            btnUpdateCancelHeaderText.Text = "Update"
            lblColumnNameHeader.Text = "Column:"
            txtHeaderText.Text = ""
            chbVisibleHeaderText.Checked = False
        ElseIf btnUpdateCancel.Text = "Update" Then
            btnUpdateCancelHeaderText.Text = "Cancel"
            selectColumnTblHeader = tblFormatColumns.CurrentRow.Cells(0).Value.ToString()
            lblColumnNameHeader.Text = "Column:" + tblFormatColumns.CurrentRow.Cells(0).Value.ToString()
            chbVisibleHeaderText.Checked = tblFormatColumns.CurrentRow.Cells(1).Value
            txtHeaderText.Text = tblFormatColumns.CurrentRow.Cells(2).Value.ToString()
            btnSaveHeaderText.Enabled = True
        End If
    End Sub
    Private Sub btnSaveHeaderText_Click(sender As Object, e As EventArgs) Handles btnSaveHeaderText.Click
        Try
            If mtdHPW.updateHeaderColumn(selectColumnTblHeader, txtHeaderText.Text, If(chbVisibleHeaderText.Checked, "1", "0"), numberClient) Then
                lblColumnNameHeader.Text = "Column:"
                btnUpdateCancelHeaderText.Text = "Update"
                txtHeaderText.Text = ""
                btnSaveHeaderText.Enabled = False
                chbVisibleHeaderText.Checked = False
                mtdHPW.llenarTablaFormatColumns(tblFormatColumns, numberClient)
                actualizarListHeader()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
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

    Private Sub cmbClient_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClient.SelectedIndexChanged
        Try
            Dim mtdJ As New MetodosJobs
            Dim array() As String = cmbClient.SelectedItem.ToString.Split(" ")
            mtdJ.llenarComboJob(cmbJobs, CInt(array(0)))
            cmbJobs.Text = ""
            If cmbClient.SelectedItem IsNot Nothing Then
                Dim array1() As String = cmbClient.SelectedItem.ToString.Split(" ")
                numberClient = array1(0)
                mtdHPW.llenarTablaDefaultElemtTrack(tblDefaultElements, array1(0))
                mtdHPW.llenarTablaFormatColumns(tblFormatColumns, array1(0))
                actualizarListDefault()
                actualizarListHeader()
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Private Sub chbAllJobs_CheckedChanged(sender As Object, e As EventArgs) Handles chbAllJobs.CheckedChanged
        If chbAllJobs.Checked Then
            cmbJobs.Enabled = False
        Else
            cmbJobs.Enabled = True
        End If
    End Sub

    Private Sub TitleBar_Paint(sender As Object, e As PaintEventArgs) Handles TitleBar.Paint

    End Sub

    Private Sub actulizaColumnasTblTrack()
        For Each rowF As DataGridViewRow In tblFormatColumns.Rows()
            If rowF.Cells(1).Value = True Then
                tblTrack.Columns(rowF.Index).Visible = True
                tblTrack.Columns(rowF.Index).HeaderText = rowF.Cells(2).Value
            Else
                tblTrack.Columns(rowF.Index).Visible = False
                tblTrack.Columns(rowF.Index).HeaderText = rowF.Cells(2).Value
            End If
        Next
    End Sub

    Private Sub txtDefaultElement_KeyPress(sender As Object, e As KeyEventArgs) Handles txtDefaultElement.KeyDown
        If (e.KeyValue = 13) Then
            Try
                If mtdHPW.updateDefaultElement(selectColumnTblDeault, txtDefaultElement.Text, numberClient) Then
                    lblColumnName.Text = "Column:"
                    btnUpdateCancel.Text = "Update"
                    txtDefaultElement.Text = ""
                    btnSave.Enabled = False

                    mtdHPW.llenarTablaDefaultElemtTrack(tblDefaultElements, numberClient)
                    actualizarListDefault()
                End If
            Catch ex As Exception
                MsgBox(ex.Message())
            End Try
        End If
    End Sub
End Class