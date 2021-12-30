Imports System.Runtime.InteropServices
Class EstimationCost
    Dim mtdEstiation As New EstimationSC
    Dim selectTable As String = ""
    Private Sub EstimationCost_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            mtdEstiation.SelectEstCostSC(tblEstimationCostSC)
            mtdEstiation.selectFactorSC(tblFactorSC)
            selectTable = tblFactorSC.Name
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnSaveEstCost_Click(sender As Object, e As EventArgs) Handles btnSaveEstCost.Click
        If selectTable = tblEstimationCostSC.Name Then
            If tblEstimationCostSC.SelectedRows.Count > 0 Then
                mtdEstiation.SaveEstCostSC(tblEstimationCostSC)
            Else
                MsgBox("Please select a row.")
            End If
        ElseIf selectTable = tblFactorSC.Name Then
            If tblFactorSC.SelectedRows.Count > 0 Then
                mtdEstiation.SaveFactorSC(tblFactorSC)
            Else
                MsgBox("Please select a row.")
            End If
        End If

    End Sub

    Private Sub tblEstimationCostSC_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles tblEstimationCostSC.CellEndEdit
        Try
            If e.ColumnIndex >= tblEstimationCostSC.Columns("M3EDCHARGES").Index Then
                If tblEstimationCostSC.Rows(tblEstimationCostSC.CurrentRow.Index).Cells(e.ColumnIndex).Value IsNot Nothing Then
                    Dim value As String = tblEstimationCostSC.Rows(tblEstimationCostSC.CurrentRow.Index).Cells(e.ColumnIndex).Value
                    If Not value.Equals("") Then
                        Dim NewValue = Format(CDec(value), "##,##0.00")
                        tblEstimationCostSC.Rows(tblEstimationCostSC.CurrentRow.Index).Cells(e.ColumnIndex).Value = NewValue
                    End If
                Else
                    tblEstimationCostSC.Rows(tblEstimationCostSC.CurrentRow.Index).Cells(e.ColumnIndex).Value = "0.00"
                End If
            ElseIf e.ColumnIndex = tblEstimationCostSC.Columns("idEstCost").Index Then
                For Each cell As DataGridViewCell In tblEstimationCostSC.Rows(e.RowIndex).Cells
                    If cell.Value Is DBNull.Value Then
                        If cell.ColumnIndex = tblEstimationCostSC.Columns("DECKS").Index Or cell.ColumnIndex = tblEstimationCostSC.Columns("ACHT").Index Or cell.ColumnIndex = tblEstimationCostSC.Columns("BILLINGDAYS").Index Or cell.ColumnIndex = tblEstimationCostSC.Columns("EDDAYS").Index Then
                            cell.Value = "0"
                        ElseIf cell.ColumnIndex = tblEstimationCostSC.Columns("BDRATE").Index Or cell.ColumnIndex = tblEstimationCostSC.Columns("M3").Index Or cell.ColumnIndex = tblEstimationCostSC.Columns("M2").Index Or cell.ColumnIndex = tblEstimationCostSC.Columns("MA3").Index Or cell.ColumnIndex = tblEstimationCostSC.Columns("MA2").Index Then
                            cell.Value = "0.0"
                        ElseIf cell.ColumnIndex = tblEstimationCostSC.Columns("SCTP").Index Then
                            cell.Value = ""
                        ElseIf cell.ColumnIndex >= tblEstimationCostSC.Columns("M3EDCHARGES").Index Then
                            cell.Value = "0.00"
                        End If
                    End If
                Next
            ElseIf e.ColumnIndex < tblEstimationCostSC.Columns("M3EDCHARGES").Index And e.ColumnIndex <> tblEstimationCostSC.Columns("SCTP").Index Then
                Dim value As String = tblEstimationCostSC.Rows(tblEstimationCostSC.CurrentRow.Index).Cells(e.ColumnIndex).Value
                If value = "" Then
                    tblEstimationCostSC.Rows(tblEstimationCostSC.CurrentRow.Index).Cells(e.ColumnIndex).Value = "0"
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnDeleteEstCost_Click(sender As Object, e As EventArgs) Handles btnDeleteEstCost.Click
        If selectTable = tblEstimationCostSC.Name Then
            If tblEstimationCostSC.SelectedRows.Count > 0 Then
                mtdEstiation.deleteScafEstCost(tblEstimationCostSC)
                mtdEstiation.SelectEstCostSC(tblEstimationCostSC)
            Else
                MsgBox("Please select a row.")
            End If
        ElseIf selectTable = tblFactorSC.Name Then
            If tblFactorSC.SelectedRows.Count > 0 Then
                mtdEstiation.deleteFactorSC(tblFactorSC)
                mtdEstiation.selectFactorSC(tblFactorSC)
            Else
                MsgBox("Please select a row.")
            End If
        End If
    End Sub

    Private Sub tblFactorSC_Click(sender As Object, e As EventArgs) Handles tblFactorSC.Click
        selectTable = tblFactorSC.Name
    End Sub

    Private Sub tblEstimationCostSC_Click(sender As Object, e As EventArgs) Handles tblEstimationCostSC.Click
        selectTable = tblEstimationCostSC.Name
    End Sub

    Private Sub tblFactorSC_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles tblFactorSC.CellEndEdit
        If e.ColumnIndex = tblFactorSC.Columns("Type").Index Then
            tblFactorSC.Rows(e.RowIndex).Cells(1).Value = If(tblFactorSC.Rows(e.RowIndex).Cells(1).Value Is DBNull.Value, "0", tblFactorSC.Rows(e.RowIndex).Cells(1).Value)
            tblFactorSC.Rows(e.RowIndex).Cells(2).Value = If(tblFactorSC.Rows(e.RowIndex).Cells(2).Value Is DBNull.Value, "0", tblFactorSC.Rows(e.RowIndex).Cells(2).Value)
        ElseIf e.ColumnIndex = tblFactorSC.Columns("Heigth").Index Then
            tblFactorSC.Rows(e.RowIndex).Cells(0).Value = If(tblFactorSC.Rows(e.RowIndex).Cells(0).Value Is DBNull.Value, "0", tblFactorSC.Rows(e.RowIndex).Cells(0).Value)
            tblFactorSC.Rows(e.RowIndex).Cells(2).Value = If(tblFactorSC.Rows(e.RowIndex).Cells(2).Value Is DBNull.Value, "0", tblFactorSC.Rows(e.RowIndex).Cells(2).Value)
        End If
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


    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class