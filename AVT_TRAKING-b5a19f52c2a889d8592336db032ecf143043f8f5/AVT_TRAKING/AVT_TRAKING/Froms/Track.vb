Imports Microsoft.Office.Core
Imports Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices
Public Class Track
    Dim mtdHPW As New MetodosHoursPeerWeek
    Dim listDefault As New List(Of String)
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
            txtMessage.Text = "Message: Loading data..."
            pdbPercent.Value = 10
            Dim tblhrs = mtdHPW.selectHorasTrack(dtpBeginDate.Value, dtpEndDate.Value)
            pdbPercent.Value = pdbPercent.Value + 20
            Dim tblPdm = mtdHPW.selectPerdiemTrack(dtpBeginDate.Value, dtpEndDate.Value)
            pdbPercent.Value = pdbPercent.Value + 20
            If tblPdm IsNot Nothing And tblhrs IsNot Nothing Then
                txtMessage.Text = "Message: Reading data..."
                tblTrack.Rows.Clear()
                Dim cont As Integer = 0
                For Each row1 As DataRow In tblhrs.Rows
                    cont += 1
                    txtMessage.Text = "Message: Writing data of hours worked...Row number(" + cont.ToString + " of " + tblhrs.Rows.Count.ToString() + ")."
                    tblTrack.Rows.Add(row1.ItemArray(0).ToString(), listDefault(0), listDefault(1), row1.ItemArray(1).ToString(), listDefault(2), listDefault(3), listDefault(4), row1.ItemArray(2).ToString(), row1.ItemArray(3).ToString(), listDefault(5), listDefault(6), listDefault(7), row1.ItemArray(4).ToString(), row1.ItemArray(5).ToString(), row1.ItemArray(6).ToString(), row1.ItemArray(7).ToString(), listDefault(8), listDefault(9), listDefault(10), listDefault(11), row1.ItemArray(8).ToString(), row1.ItemArray(9).ToString(), row1.ItemArray(10).ToString(), row1.ItemArray(11).ToString(), row1.ItemArray(12).ToString(), row1.ItemArray(13).ToString(), row1.ItemArray(14).ToString(), listDefault(12), listDefault(13), listDefault(14), listDefault(15), listDefault(16), listDefault(17), listDefault(18), listDefault(19), listDefault(20), listDefault(21), listDefault(22), listDefault(23), listDefault(24), listDefault(25), listDefault(26), listDefault(27))
                Next
                pdbPercent.Value = pdbPercent.Value + 30
                cont = 0
                For Each row As DataRow In tblPdm.Rows()
                    cont += 1
                    txtMessage.Text = "Message: Writing data of Perdiem used...Row number(" + cont.ToString + " of " + tblPdm.Rows.Count.ToString() + ")."
                    For Each row2 As DataGridViewRow In tblTrack.Rows()
                        If row2.Cells("Date1").Value = row.ItemArray(0) And row2.Cells("ResourceID").Value = row.ItemArray(1) And row2.Cells("ResourceName").Value = row.ItemArray(2) And row2.Cells("Level1ID").Value = row.ItemArray(3) And row2.Cells("Level2ID").Value = row.ItemArray(4) Then
                            row2.Cells("ExtraCharges").Value = row.ItemArray(5)
                            Exit For
                        End If
                    Next
                Next
                pdbPercent.Value = pdbPercent.Value + 5
            End If
            txtMessage.Text = "Message: End."
            pdbPercent.Value = 100
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
                Dim colums() As String = {tblTrack.Columns(0).HeaderText, tblTrack.Columns(1).HeaderText, tblTrack.Columns(2).HeaderText, tblTrack.Columns(3).HeaderText, tblTrack.Columns(4).HeaderText, tblTrack.Columns(5).HeaderText, tblTrack.Columns(6).HeaderText, tblTrack.Columns(7).HeaderText, tblTrack.Columns(8).HeaderText, tblTrack.Columns(9).HeaderText, tblTrack.Columns(10).HeaderText, tblTrack.Columns(11).HeaderText, tblTrack.Columns(12).HeaderText, tblTrack.Columns(13).HeaderText, tblTrack.Columns(14).HeaderText, tblTrack.Columns(15).HeaderText, tblTrack.Columns(16).HeaderText, tblTrack.Columns(17).HeaderText, tblTrack.Columns(18).HeaderText, tblTrack.Columns(19).HeaderText, tblTrack.Columns(20).HeaderText, tblTrack.Columns(21).HeaderText, tblTrack.Columns(22).HeaderText, tblTrack.Columns(23).HeaderText, tblTrack.Columns(24).HeaderText, tblTrack.Columns(25).HeaderText, tblTrack.Columns(26).HeaderText, tblTrack.Columns(27).HeaderText, tblTrack.Columns(28).HeaderText, tblTrack.Columns(29).HeaderText, tblTrack.Columns(30).HeaderText, tblTrack.Columns(31).HeaderText, tblTrack.Columns(32).HeaderText, tblTrack.Columns(33).HeaderText, tblTrack.Columns(34).HeaderText, tblTrack.Columns(35).HeaderText, tblTrack.Columns(36).HeaderText, tblTrack.Columns(37).HeaderText, tblTrack.Columns(38).HeaderText, tblTrack.Columns(39).HeaderText, tblTrack.Columns(40).HeaderText, tblTrack.Columns(41).HeaderText, tblTrack.Columns(42).HeaderText}
                For i As Int16 = 0 To colums.Length - 1
                    libro.Sheets(1).cells(1, i + 1) = colums(i)
                    libro.Sheets(1).cells(1, i + 1).Interior.Color = RGB(255, 255, 0)
                Next
                txtMessage.Text = "Message: Inserting data..."
                pdbPercent.Value = pdbPercent.Value + 5
                Dim increment = (90 / tblTrack.Rows.Count())
                Dim flagIncrement = If(increment > 1, (90 / tblTrack.Rows.Count()), If(increment < 1 And increment > 0.5, 2, If(increment < 0.5 And increment > 0.25, 3, 4)))
                Dim count As Integer = 2
                Dim countIncrement As Integer = 0
                For Each row As DataGridViewRow In tblTrack.Rows()
                    libro.Sheets(1).cells(count, 1) = row.Cells(0).Value.ToString()
                    libro.Sheets(1).cells(count, 2) = row.Cells(1).Value.ToString()
                    libro.Sheets(1).cells(count, 3) = row.Cells(2).Value.ToString()
                    libro.Sheets(1).cells(count, 4) = row.Cells(3).Value.ToString()
                    libro.Sheets(1).cells(count, 5) = row.Cells(4).Value.ToString()
                    libro.Sheets(1).cells(count, 6) = row.Cells(5).Value.ToString()
                    libro.Sheets(1).cells(count, 7) = row.Cells(6).Value.ToString()
                    libro.Sheets(1).cells(count, 8) = row.Cells(7).Value.ToString()
                    libro.Sheets(1).cells(count, 9) = row.Cells(8).Value.ToString()
                    libro.Sheets(1).cells(count, 10) = row.Cells(9).Value.ToString()
                    libro.Sheets(1).cells(count, 11) = row.Cells(10).Value.ToString()
                    libro.Sheets(1).cells(count, 12) = row.Cells(11).Value.ToString()
                    libro.Sheets(1).cells(count, 13) = row.Cells(12).Value.ToString()
                    libro.Sheets(1).cells(count, 14) = row.Cells(13).Value.ToString()
                    libro.Sheets(1).cells(count, 15) = row.Cells(14).Value.ToString()
                    libro.Sheets(1).cells(count, 16) = row.Cells(15).Value.ToString()
                    libro.Sheets(1).cells(count, 17) = row.Cells(16).Value.ToString()
                    libro.Sheets(1).cells(count, 18) = row.Cells(17).Value.ToString()
                    libro.Sheets(1).cells(count, 19) = row.Cells(18).Value.ToString()
                    libro.Sheets(1).cells(count, 20) = row.Cells(19).Value.ToString()
                    libro.Sheets(1).cells(count, 21) = row.Cells(20).Value.ToString()
                    libro.Sheets(1).cells(count, 22) = row.Cells(21).Value.ToString()
                    libro.Sheets(1).cells(count, 23) = row.Cells(22).Value.ToString()
                    libro.Sheets(1).cells(count, 24) = row.Cells(23).Value.ToString()
                    libro.Sheets(1).cells(count, 25) = row.Cells(24).Value.ToString()
                    libro.Sheets(1).cells(count, 26) = row.Cells(25).Value.ToString()
                    libro.Sheets(1).cells(count, 27) = row.Cells(26).Value.ToString()
                    libro.Sheets(1).cells(count, 28) = row.Cells(27).Value.ToString()
                    libro.Sheets(1).cells(count, 29) = row.Cells(28).Value.ToString()
                    libro.Sheets(1).cells(count, 30) = row.Cells(29).Value.ToString()
                    libro.Sheets(1).cells(count, 31) = row.Cells(30).Value.ToString()
                    libro.Sheets(1).cells(count, 32) = row.Cells(31).Value.ToString()
                    libro.Sheets(1).cells(count, 33) = row.Cells(32).Value.ToString()
                    libro.Sheets(1).cells(count, 34) = row.Cells(33).Value.ToString()
                    libro.Sheets(1).cells(count, 35) = row.Cells(34).Value.ToString()
                    libro.Sheets(1).cells(count, 36) = row.Cells(35).Value.ToString()
                    libro.Sheets(1).cells(count, 37) = row.Cells(36).Value.ToString()
                    libro.Sheets(1).cells(count, 38) = row.Cells(37).Value.ToString()
                    libro.Sheets(1).cells(count, 39) = row.Cells(38).Value.ToString()
                    libro.Sheets(1).cells(count, 40) = row.Cells(39).Value.ToString()
                    libro.Sheets(1).cells(count, 41) = row.Cells(40).Value.ToString()
                    libro.Sheets(1).cells(count, 42) = row.Cells(41).Value.ToString()
                    libro.Sheets(1).cells(count, 43) = row.Cells(42).Value.ToString()
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
        mtdHPW.llenarTablaElementosTrack(tblDefaultElements)
        actulizaeListDefault()
        btnSave.Enabled = False
    End Sub
    Dim selectColumn As String = ""
    Private Sub tblDefaultElements_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles tblDefaultElements.CellMouseDoubleClick
        If btnUpdateCancel.Text = "Update" Then
            btnUpdateCancel.Text = "Cancel"
            selectColumn = tblDefaultElements.CurrentRow.Cells(0).Value.ToString()
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

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If mtdHPW.updateDefaultElement(selectColumn, txtDefaultElement.Text) Then
                lblColumnName.Text = "Column:"
                btnUpdateCancel.Text = "Update"
                txtDefaultElement.Text = ""
                btnSave.Enabled = False
                mtdHPW.llenarTablaElementosTrack(tblDefaultElements)
                actulizaeListDefault()
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Private Sub btnUpdateCancel_Click(sender As Object, e As EventArgs) Handles btnUpdateCancel.Click
        If btnUpdateCancel.Text = "Update" Then
            btnUpdateCancel.Text = "Cancel"
            selectColumn = tblDefaultElements.CurrentRow.Cells(0).Value.ToString()
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

    Private Sub actulizaeListDefault()
        listDefault.Clear()
        For Each row As DataGridViewRow In tblDefaultElements.Rows
            listDefault.Add(row.Cells(1).Value.ToString())
        Next
    End Sub
End Class