﻿Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Imports Microsoft.Office.Core
Imports Microsoft.Office.Interop.Excel
Public Class Midwest
    Dim mtdMW As New midwestmtdMetodos
    Dim listDatesWeekend As List(Of String)
    Dim lastColum As String
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.Close()
    End Sub
    Private Sub btnMinimize_Click(sender As Object, e As EventArgs) Handles btnMinimized.Click
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
    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles TitleBar.MouseMove
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub Midwest_Load(sender As Object, e As EventArgs) Handles Me.Load
        llenarComboClientByUser(cmbClients)
        btnExport.Enabled = False
        btnReport.Enabled = False
        btnSaveMidwest.Enabled = False
    End Sub

    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        Try

            pgbBarraDeEstado.Value = 0
        addColummns()
        pgbBarraDeEstado.Value = 10
        addRows()
        pgbBarraDeEstado.Value = 15
        Dim cl As String() = cmbClients.Items(cmbClients.SelectedIndex).ToString.Split(" ")
        lblMsg.Text = "Message: Obteining the data..."
        pgbBarraDeEstado.Value = 20
            Dim dtHRS As New Data.DataTable
            If mtdMW.selectMidWest(cl(0), cmbYear.Items(cmbYear.SelectedIndex), dtHRS) Then
                If DialogResult.Yes = MessageBox.Show("Do you want to work with the existing midwest information?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) Then
                    'este caso pegaremos los datos que ya se guardaron en la BD 
                    pgbBarraDeEstado.Value = 45
                    lblMsg.Text = "Message: Claculating the data Hrs..."
                    For Each row As Data.DataRow In dtHRS.Rows
                        Dim countCell As Integer = 2
                        Dim columnIndex As Integer = tblMW.Columns(("clmDate" & row.Item(1).ToString())).Index
                        For i = 0 To tblMW.RowCount - 1
                            If i = 6 Then
                                tblMW.Rows(i).Cells(columnIndex).Value = row.Item(countCell) & "%"
                            Else
                                tblMW.Rows(i).Cells(columnIndex).Value = row.Item(countCell).ToString()
                            End If
                            countCell += 1
                        Next
                    Next
                Else
                    'este caso pegaremos el pivot ya que es un caso nuevo de midwest 
                    dtHRS = mtdMW.selectHoursMWByClientID(cl(0), cmbYear.Items(cmbYear.SelectedIndex))
                    pgbBarraDeEstado.Value = 45
                    lblMsg.Text = "Message: Claculating the data Hrs..."
                    For Each clmDT As Data.DataColumn In dtHRS.Columns
                        If clmDT.ColumnName.Contains("-") Or clmDT.ColumnName.Contains("/") Then
                            Dim indexClmTblDW As Integer = existColumn(clmDT.ColumnName) 'este es el numero de la columna de la tabla en el formulario
                            If indexClmTblDW >= 0 Then
                                tblMW.Rows(2).Cells(indexClmTblDW).Value = dtHRS.Rows(0).Item(clmDT.ColumnName)
                            End If
                        End If
                        lastColum = clmDT.ColumnName
                    Next
                End If
            End If
            pgbBarraDeEstado.Value = 70
            calculateAllF()
            calculateAllQ()
            fillZero()
            pgbBarraDeEstado.Value = 100
            btnExport.Enabled = True
            btnSaveMidwest.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function fillZero()
        Try
            For Each row As DataGridViewRow In tblMW.Rows
                For Each cell As DataGridViewCell In row.Cells
                    If cell.Value Is Nothing Then
                        If Not row.Index = 6 Then
                            cell.Value = 0
                        Else
                            cell.Value = "0%"
                        End If
                    End If
                Next
            Next
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function calculateAllQ() As Boolean
        Try

            For Each row As DataGridViewRow In tblMW.Rows
                'MsgBox(row.Index)
                For Each cell As DataGridViewCell In row.Cells '
                    If tblMW.Columns(cell.ColumnIndex).HeaderText.Contains("F") And tblMW.Columns(cell.ColumnIndex).HeaderText.Contains("Q") Then
                        Dim flag As Boolean = True
                        Dim countCell As Integer = 0
                        Dim sum As Decimal = 0
                        Dim average As Decimal = 0
                        Dim countF As Integer = 0
                        Select Case row.Index
                            Case 0, 7, 8
                                While flag = True
                                    countCell += 1
                                    If tblMW.Columns(cell.ColumnIndex - countCell).HeaderText.Contains("F") And Not tblMW.Columns(cell.ColumnIndex - countCell).HeaderText.Contains("Q") Then
                                        sum = sum + row.Cells(cell.ColumnIndex - countCell).Value
                                        countF += 1
                                        'ElseIf tblMW.Columns(cell.ColumnIndex - countCell).HeaderText.Contains("F") And tblMW.Columns(cell.ColumnIndex - countCell).HeaderText.Contains("Q") Then
                                        '    flag = False
                                        '    countCell = countCell - 1
                                    End If
                                    If countF = 3 Then
                                        flag = False
                                        countCell = countCell - 1
                                    End If
                                End While
                                If sum > 0 Then
                                    average = sum / countF
                                    cell.Value = Math.Round(average, 2)
                                Else
                                    cell.Value = 0
                                End If
                            Case 1, 2, 3, 4, 5
                                While flag = True
                                    countCell += 1
                                    If tblMW.Columns(cell.ColumnIndex - countCell).HeaderText.Contains("F") And Not tblMW.Columns(cell.ColumnIndex - countCell).HeaderText.Contains("Q") Then
                                        sum = sum + row.Cells(cell.ColumnIndex - countCell).Value
                                        countF += 1
                                        'ElseIf tblMW.Columns(cell.ColumnIndex - countCell).HeaderText.Contains("F") And tblMW.Columns(cell.ColumnIndex - countCell).HeaderText.Contains("Q") Then
                                        '    flag = False
                                    End If
                                    If countF = 3 Then
                                        flag = False
                                        countCell = countCell - 1
                                    End If
                                End While
                                cell.Value = sum
                            Case 6
                                While flag = True
                                    countCell += 1
                                    If tblMW.Columns(cell.ColumnIndex - countCell).HeaderText.Contains("F") And Not tblMW.Columns(cell.ColumnIndex - countCell).HeaderText.Contains("Q") Then
                                        sum = sum + If(row.Cells(cell.ColumnIndex - countCell).Value Is Nothing, 0, Decimal.Parse(row.Cells(cell.ColumnIndex - countCell).Value.ToString.Replace("%", "")))
                                        countF += 1
                                        'ElseIf tblMW.Columns(cell.ColumnIndex - countCell).HeaderText.Contains("F") And tblMW.Columns(cell.ColumnIndex - countCell).HeaderText.Contains("Q") Then
                                        '    flag = False
                                        '    countCell = countCell - 1
                                    End If
                                    If countF = 3 Then
                                        flag = False
                                        countCell = countCell - 1
                                    End If
                                End While
                                If sum > 0 Then
                                    average = sum / countF
                                    cell.Value = Math.Round(average, 2) & "%"
                                Else
                                    cell.Value = 0
                                End If
                        End Select
                    End If
                Next
            Next
            Return True
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        End Try
    End Function

    Private Function calculateAllF() As Boolean
        Try

            For Each row As DataGridViewRow In tblMW.Rows
                'MsgBox(row.Index)
                For Each cell As DataGridViewCell In row.Cells '
                    If tblMW.Columns(cell.ColumnIndex).HeaderText.Contains("F") And Not tblMW.Columns(cell.ColumnIndex).HeaderText.Contains("Q") Then
                        Dim flag As Boolean = True
                        Dim countCell As Integer = 0
                        Dim sum As Decimal = 0
                        Dim average As Decimal = 0

                        Select Case row.Index
                            Case 0, 7, 8
                                While flag = True
                                    countCell += 1
                                    If tblMW.Columns(cell.ColumnIndex - countCell).HeaderText.Contains("-") Or tblMW.Columns(cell.ColumnIndex - countCell).HeaderText.Contains("/") Then
                                        sum = sum + If(row.Cells(cell.ColumnIndex - countCell).Value Is Nothing, 0, row.Cells(cell.ColumnIndex - countCell).Value)
                                    Else
                                        flag = False
                                        countCell = countCell - 1
                                    End If
                                End While
                                If sum > 0 Then
                                    average = sum / countCell
                                    cell.Value = Math.Round(average, 2)
                                Else
                                    cell.Value = 0
                                End If
                            Case 1, 2, 3, 4, 5
                                While flag = True
                                    countCell += 1
                                    If tblMW.Columns(cell.ColumnIndex - countCell).HeaderText.Contains("-") Or tblMW.Columns(cell.ColumnIndex - countCell).HeaderText.Contains("/") Then
                                        sum = sum + row.Cells(cell.ColumnIndex - countCell).Value
                                    Else
                                        flag = False
                                        countCell += 1
                                    End If
                                End While
                                cell.Value = sum
                            Case 6
                                While flag = True
                                    countCell += 1
                                    If tblMW.Columns(cell.ColumnIndex - countCell).HeaderText.Contains("-") Or tblMW.Columns(cell.ColumnIndex - countCell).HeaderText.Contains("/") Then
                                        sum = sum + Decimal.Parse(row.Cells(cell.ColumnIndex - countCell).Value.ToString.Replace("%", ""))
                                    Else
                                        flag = False
                                        countCell = countCell - 1
                                    End If

                                End While
                                If sum > 0 Then
                                    average = sum / countCell
                                    cell.Value = average & "%"
                                Else
                                    cell.Value = 0
                                End If
                        End Select
                    End If
                Next
            Next
            Return True
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        End Try
    End Function

    Public Function calculateQ() As Boolean
        Try
            For Each row As DataGridViewRow In tblMW.Rows
                For Each cell As DataGridViewCell In row.Cells '
                    If tblMW.Columns(cell.ColumnIndex).HeaderText.Contains("F") And tblMW.Columns(cell.ColumnIndex).HeaderText.Contains("Q") Then
                        Dim flag As Boolean = True
                        Dim countCell As Integer = 0
                        Dim sum As Integer = 0
                        Dim average As Decimal = 0
                        Select Case row.Index
                            Case 0, 7, 8
                                While flag = True
                                    countCell += 1
                                    If tblMW.Columns(cell.ColumnIndex - countCell).HeaderText.Contains("F") And Not tblMW.Columns(cell.ColumnIndex - countCell).HeaderText.Contains("Q") Then
                                        sum = sum + row.Cells(cell.ColumnIndex - countCell).Value
                                    ElseIf tblMW.Columns(cell.ColumnIndex - countCell).HeaderText.Contains("Q") Then
                                        flag = False
                                        countCell = countCell - 1
                                    End If

                                End While
                                If sum > 0 Then
                                    average = sum / countCell
                                    cell.Value = average
                                Else
                                    cell.Value = 0
                                End If
                            Case 1, 2, 3, 4, 5
                                While flag = True
                                    countCell += 1
                                    If tblMW.Columns(cell.ColumnIndex - countCell).HeaderText.Contains("F") And Not tblMW.Columns(cell.ColumnIndex - countCell).HeaderText.Contains("Q") Then
                                        sum = sum + row.Cells(cell.ColumnIndex - countCell).Value
                                    ElseIf tblMW.Columns(cell.ColumnIndex - countCell).HeaderText.Contains("Q") Then
                                        flag = False
                                        countCell += 1
                                    End If
                                End While
                                cell.Value = sum
                            Case 6
                                While flag = True
                                    countCell += 1
                                    If tblMW.Columns(cell.ColumnIndex - countCell).HeaderText.Contains("F") And Not tblMW.Columns(cell.ColumnIndex - countCell).HeaderText.Contains("Q") Then
                                        sum = sum + Decimal.Parse(row.Cells(cell.ColumnIndex - countCell).Value.replase("%", ""))
                                    ElseIf tblMW.Columns(cell.ColumnIndex - countCell).HeaderText.Contains("Q") Then
                                        flag = False
                                        countCell = countCell - 1
                                    End If

                                End While
                                If sum > 0 Then
                                    average = sum / countCell
                                    cell.Value = average & "%"
                                Else
                                    cell.Value = 0
                                End If
                        End Select
                    End If
                Next
            Next
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Private Sub tblMW_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles tblMW.CellValueChanged
        Try
            Dim cell As DataGridViewCell = tblMW.Rows(e.RowIndex).Cells(e.ColumnIndex)
            If cell.ColumnIndex > 1 And Not cell.Value Is Nothing And Not (tblMW.Columns(cell.ColumnIndex).Name.Contains("F") Or tblMW.Columns(cell.ColumnIndex).Name.Contains("Q")) Then
                If Not (CStr(cell.Value) = "0" And CStr(cell.Value) = "0%" And CStr(cell.Value) = "") Then
                    Dim flag As Boolean = True
                    Dim countCell As Integer = 0
                    Dim sum As Integer = 0
                    Dim average As Decimal = 0
                    Select Case cell.RowIndex
                        Case 0

                        Case 1

                        Case 2 'Work Hours (horas trabajadas)
                            tblMW.Rows(3).Cells(cell.ColumnIndex).Value = cell.Value * tblMW.Rows(7).Cells(cell.ColumnIndex).Value 'calculamos REVENUE
                            If tblMW.Rows(2).Cells(cell.ColumnIndex).Value IsNot Nothing And Not tblMW.Rows(2).Cells(cell.ColumnIndex).Value = 0 And Not tblMW.Rows(5).Cells(cell.ColumnIndex).Value = 0 Then
                                tblMW.Rows(8).Cells(cell.ColumnIndex).Value = Math.Round((tblMW.Rows(5).Cells(cell.ColumnIndex).Value / tblMW.Rows(2).Cells(cell.ColumnIndex).Value), 3) 'Calculamos GM/PerHour
                            Else
                                tblMW.Rows(8).Cells(cell.ColumnIndex).Value = 0
                            End If
                        Case 3 'Revenue (Promedio)
                            Dim value As Decimal = 0
                            If tblMW.Rows(3).Cells(cell.ColumnIndex).Value IsNot Nothing And Not tblMW.Rows(3).Cells(cell.ColumnIndex).Value = 0 And Not tblMW.Rows(6).Cells(cell.ColumnIndex).Value Is Nothing Then
                                value = Decimal.Parse(tblMW.Rows(6).Cells(cell.ColumnIndex).Value.ToString.Replace("%", "")) / 100
                                tblMW.Rows(5).Cells(cell.ColumnIndex).Value = Math.Round((tblMW.Rows(3).Cells(cell.ColumnIndex).Value * value), 2) 'Calculamos MARGIN
                                tblMW.Rows(4).Cells(cell.ColumnIndex).Value = Math.Round(tblMW.Rows(3).Cells(cell.ColumnIndex).Value - tblMW.Rows(5).Cells(cell.ColumnIndex).Value, 2) 'calcualmos Expense
                            Else
                                tblMW.Rows(5).Cells(cell.ColumnIndex).Value = value 'Calculamos MARGIN
                                tblMW.Rows(4).Cells(cell.ColumnIndex).Value = value 'calcualmos Expense
                            End If
                        Case 4 'Expeneses (Viaticos) 

                        Case 5 'Margin (Margen)
                            If (tblMW.Rows(3).Cells(cell.ColumnIndex).Value Is Nothing Or (tblMW.Rows(3).Cells(cell.ColumnIndex).Value = 0)) Or tblMW.Rows(5).Cells(cell.ColumnIndex).Value Is Nothing Or (tblMW.Rows(5).Cells(cell.ColumnIndex).Value = 0) Then  'calcualmos Expense
                                tblMW.Rows(4).Cells(cell.ColumnIndex).Value = Math.Round(tblMW.Rows(3).Cells(cell.ColumnIndex).Value - tblMW.Rows(5).Cells(cell.ColumnIndex).Value)
                            Else
                                tblMW.Rows(4).Cells(cell.ColumnIndex).Value = Math.Round(tblMW.Rows(3).Cells(cell.ColumnIndex).Value - tblMW.Rows(5).Cells(cell.ColumnIndex).Value)
                            End If
                            If tblMW.Rows(2).Cells(cell.ColumnIndex).Value IsNot Nothing And Not tblMW.Rows(2).Cells(cell.ColumnIndex).Value = 0 And tblMW.Rows(5).Cells(cell.ColumnIndex).Value IsNot Nothing And Not tblMW.Rows(5).Cells(cell.ColumnIndex).Value = 0 Then 'Calculamos GM/PerHour
                                tblMW.Rows(8).Cells(cell.ColumnIndex).Value = Math.Round((tblMW.Rows(5).Cells(cell.ColumnIndex).Value / tblMW.Rows(2).Cells(cell.ColumnIndex).Value), 3)
                            Else
                                tblMW.Rows(8).Cells(cell.ColumnIndex).Value = 0
                            End If
                        Case 6 'GP%

                        Case 7 'REV/ Per Hour

                        Case 8 'GM/ Per Hour

                    End Select


                End If
            End If
        Catch ex As Exception

        End Try


    End Sub

    ''' <summary>
    ''' Este metodo retorna el columnIndex proximo de la columna F1 or Q1 si no encuentra retorna 0
    ''' </summary>
    ''' <param name="cellIndex"></param>
    ''' <param name="QorF"></param>
    ''' <returns></returns>
    Private Function findNextF1OrQ1(ByVal cellIndex As Integer, ByVal QorF As Char) As Integer
        Try
            Dim clmFind As Boolean = If(QorF = "F", True, False)
            Dim flag As Boolean = True
            Dim count As Integer = 1
            While flag
                If clmFind Then
                    If tblMW.Columns(cellIndex + count).Name.Contains("F") And Not tblMW.Columns(cellIndex + count).Name.Contains("Q") Then
                        flag = False
                    End If
                ElseIf tblMW.Columns(cellIndex + count).Name.Contains("Q") Then
                    flag = False
                End If
                If flag Then
                    count += 1
                End If
            End While
            Return count + cellIndex
        Catch ex As Exception
            Return 0
        End Try

    End Function
    ''' <summary>
    ''' Esta funcion calcula la cellda de Q a la que pertenece la celda afectada.
    ''' </summary>
    ''' <param name="cell">Esta es la celda alterada.</param>
    ''' <returns></returns>
    Private Function calcularQCellChangued(ByVal cell As DataGridViewCell) As Boolean
        Try
            If cell.ColumnIndex > 1 And Not cell.Value Is Nothing Then

                Dim flag As Boolean = True
                Dim countCell As Integer = 0
                Dim sum As Decimal = 0
                Dim average As Decimal = 0
                Dim cllQ As Integer = findNextF1OrQ1(cell.ColumnIndex, "Q")
                Dim countF As Integer = 0

                Select Case cell.RowIndex
                    Case 0, 7, 8
                        While flag = True
                            countCell += 1
                            If tblMW.Columns(cllQ - countCell).HeaderText.Contains("F") And Not tblMW.Columns(cllQ - countCell).HeaderText.Contains("Q") Then
                                sum = sum + If(tblMW.Rows(cell.RowIndex).Cells(cllQ - countCell).Value Is Nothing, 0, tblMW.Rows(cell.RowIndex).Cells(cllQ - countCell).Value)
                                countF += 1
                            End If
                            If countF = 3 Then
                                flag = False
                                countCell = countCell - 1
                            End If
                        End While
                        If sum > 0 Then
                            average = sum / countF
                            tblMW.Rows(cell.RowIndex).Cells(cllQ).Value = Math.Round(average, 2)
                        Else
                            tblMW.Rows(cell.RowIndex).Cells(cllQ).Value = 0
                        End If
                    Case 1, 2, 3, 4, 5
                        While flag = True
                            countCell += 1
                            If tblMW.Columns(cllQ - countCell).HeaderText.Contains("F") And Not tblMW.Columns(cllQ - countCell).HeaderText.Contains("Q") Then
                                sum = sum + If(tblMW.Rows(cell.RowIndex).Cells(cllQ - countCell).Value Is Nothing, 0, tblMW.Rows(cell.RowIndex).Cells(cllQ - countCell).Value)
                            ElseIf tblMW.Columns(cllQ - countCell).HeaderText.Contains("Q") Then
                                flag = False
                                countCell += 1
                            End If
                        End While
                        tblMW.Rows(cell.RowIndex).Cells(cllQ).Value = sum
                    Case 6
                        While flag = True
                            countCell += 1
                            If tblMW.Columns(cllQ - countCell).HeaderText.Contains("F") And Not tblMW.Columns(cllQ - countCell).HeaderText.Contains("Q") Then
                                sum = sum + Decimal.Parse(If(tblMW.Rows(cell.RowIndex).Cells(cllQ - countCell).Value Is Nothing, "0%", tblMW.Rows(cell.RowIndex).Cells(cllQ - countCell).Value).replase("%", ""))
                                countF += 1
                            End If
                            If countF = 3 Then
                                flag = False
                                countCell = countCell - 1
                            End If

                        End While
                        If sum > 0 Then
                            average = sum / countF
                            tblMW.Rows(cell.RowIndex).Cells(cllQ).Value = Math.Round(average, 2) & "%"
                        Else
                            tblMW.Rows(cell.RowIndex).Cells(cllQ).Value = "0%"
                        End If
                End Select

            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function calcularFCellChangued(ByVal cell As DataGridViewCell) As Boolean
        Try
            If cell.ColumnIndex > 1 And Not cell.Value Is Nothing Then
                Dim flag As Boolean = True
                Dim countCell As Integer = 0
                Dim sum As Decimal = 0
                Dim average As Decimal = 0
                Dim cllF As Integer = findNextF1OrQ1(cell.ColumnIndex, "F")

                Select Case cell.RowIndex
                    Case 0, 7, 8
                        While flag = True
                            countCell += 1
                            If tblMW.Columns(cllF - countCell).HeaderText.Contains("-") Or tblMW.Columns(cllF - countCell).HeaderText.Contains("/") Then
                                sum = sum + If(tblMW.Rows(cell.RowIndex).Cells((cllF) - countCell).Value Is Nothing, 0, tblMW.Rows(cell.RowIndex).Cells((cllF) - countCell).Value)
                            Else
                                flag = False
                                countCell = countCell - 1
                            End If

                        End While
                        If sum > 0 Then
                            average = sum / countCell
                            tblMW.Rows(cell.RowIndex).Cells(cllF).Value = Math.Round(average, 2)
                        Else
                            tblMW.Rows(cell.RowIndex).Cells(cllF).Value = 0
                        End If
                    Case 1, 2, 3, 4, 5
                        While flag = True
                            countCell += 1
                            If tblMW.Columns(cllF - countCell).HeaderText.Contains("-") Or tblMW.Columns(cllF - countCell).HeaderText.Contains("/") Then
                                sum = sum + If(tblMW.Rows(cell.RowIndex).Cells(cllF - countCell).Value Is Nothing, 0, tblMW.Rows(cell.RowIndex).Cells(cllF - countCell).Value)
                            Else
                                flag = False
                                countCell += 1
                            End If
                        End While
                        tblMW.Rows(cell.RowIndex).Cells(cllF).Value = sum
                    Case 6
                        While flag = True
                            countCell += 1
                            If tblMW.Columns(cllF - countCell).HeaderText.Contains("-") Or tblMW.Columns(cllF - countCell).HeaderText.Contains("/") Then
                                sum = sum + Decimal.Parse(If(tblMW.Rows(cell.RowIndex).Cells(cllF - countCell).Value Is Nothing, "0%", tblMW.Rows(cell.RowIndex).Cells(cllF - countCell).Value).ToString.Replace("%", ""))
                            Else
                                flag = False
                                countCell = countCell - 1
                            End If

                        End While
                        If sum > 0 Then
                            average = sum / countCell
                            tblMW.Rows(cell.RowIndex).Cells(cllF).Value = Math.Round(average, 2) & "%"
                        Else
                            tblMW.Rows(cell.RowIndex).Cells(cllF).Value = "0%"
                        End If
                End Select
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function existColumn(ByVal headerClm As String) As Integer
        Try
            If tblMW.Columns.Contains("clmDate" + headerClm) Then
                Return tblMW.Columns.IndexOf(tblMW.Columns("clmDate" + headerClm))
            Else
                Return -1
            End If
        Catch ex As Exception
            Return -1
        End Try

    End Function
    Private Function addRows() As Boolean
        Try
            tblMW.Rows.Clear()
            tblMW.Rows.Add(9)
            Dim valuesHeaderRow() As String = {"Headcount Per Week", "Average Hours Per Week", "Work hours", "Revenue ", "Expense", "Margin", "GP%", "Rev/Per Hour", "GM/Per Hour"}
            Dim countRow As Integer = 0
            Dim cl As String = cmbClients.Items(cmbClients.SelectedIndex).ToString.Remove(0, 4)
            For Each row As DataGridViewRow In tblMW.Rows
                row.Cells("clmMetric").Value = valuesHeaderRow(countRow)
                row.Cells("clmSiteCGC").Value = cl
                For Each cell As DataGridViewCell In row.Cells
                    If tblMW.Columns(cell.ColumnIndex).Name.Contains("-") Or tblMW.Columns(cell.ColumnIndex).Name.Contains("/") Then
                        Select Case countRow
                            Case 0
                                cell.Value = sprHCPW.Value
                            Case 1
                                cell.Value = sprAHPW.Value
                            Case 6
                                cell.Value = sprGP.Value & "%"
                            Case 7
                                cell.Value = sprRPH.Value
                        End Select
                    End If
                Next
                countRow += 1
            Next
            Return True
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        End Try
    End Function
    Private Function addColummns() As Boolean
        Try
            If tblMW.Columns IsNot Nothing Then
                tblMW.Columns.Clear()
            End If
            listDatesWeekend = mtdMW.selectFechasWeekend(cmbYear.Items(cmbYear.SelectedIndex))
            tblMW.Columns.Add("clmSiteCGC", "Site CGC")
            tblMW.Columns.Add("clmMetric", "Metric")
            tblMW.Columns("clmSiteCGC").Frozen = True
            tblMW.Columns("clmMetric").Frozen = True

            Dim countQuarter As Integer = 0
            Dim countQuarterNum As Integer = 1
            Dim flagMonth As Boolean = False
            Dim actualMonth As Integer = 0
            Dim monthVal As String()
            Dim columnName As String = ""
            For Each val As String In listDatesWeekend
                monthVal = val.ToString.Split("-")
                If actualMonth = 0 Then
                    actualMonth = monthVal(0)
                    tblMW.Columns.Add("clmDate" + val, val)
                ElseIf CInt(monthVal(0)) = actualMonth Then
                    tblMW.Columns.Add("clmDate" + val, val)
                Else
                    columnName = "clmF1 " + moutnByNumber(monthVal(0))
                    tblMW.Columns.Add(columnName, monthVal(2) + " F1 " + moutnByNumber(monthVal(0)))
                    tblMW.Columns(columnName).DefaultCellStyle.BackColor = Color.LightSkyBlue
                    countQuarter += 1
                    If countQuarter = 3 Then
                        columnName = "clmQ" + CStr(countQuarterNum)
                        tblMW.Columns.Add(columnName, monthVal(2) + " F1 Q" + CStr(countQuarterNum))
                        tblMW.Columns(columnName).DefaultCellStyle.BackColor = Color.DeepSkyBlue
                        countQuarterNum += 1
                        countQuarter = 0
                    End If
                    tblMW.Columns.Add("clmDate" + val, val)
                    actualMonth = monthVal(0)
                End If
            Next
            If monthVal IsNot Nothing Then
                columnName = "clmF1 " + moutnByNumber(13)
                tblMW.Columns.Add(columnName, monthVal(2) + " F1 " + moutnByNumber(13))
                columnName = "clmQ" + CStr(countQuarterNum)
                tblMW.Columns.Add(columnName, monthVal(2) + " F1 Q" + CStr(countQuarterNum))
            End If
            Return True
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        End Try
    End Function
    Public Function moutnByNumber(ByVal number As Integer) As String
        If number > 0 And number <= 13 Then
            Dim month() As String = {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"}
            Return month(number - 2)
        Else
            Return ""
        End If
    End Function
    Private Function cadenaFechas() As String
        Dim FechasString As String = ""
        For Each val As String In listDatesWeekend
            FechasString = FechasString & "[" & val & "],"
        Next
        FechasString = FechasString.Remove(FechasString.Length, 1)
        Return FechasString
    End Function
    Private Sub cmbClients_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClients.SelectedIndexChanged
        Dim cl As String() = cmbClients.Items(cmbClients.SelectedIndex).ToString.Split(" ")
        mtdMW.fillCmdYearHours(cmbYear, cl(0))
        'cmbYear.Items.Add(2025)
    End Sub
    Private Sub tblMW_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles tblMW.CellEndEdit
        Dim cell As DataGridViewCell = tblMW.Rows(e.RowIndex).Cells(e.ColumnIndex)
        If cell.RowIndex = 6 And Not cell.Value.ToString.Contains("%") Then
            cell.Value = cell.Value & "%"
        End If
        calculaColumna(cell)
        calcularFCellChangued(cell)
        calcularQCellChangued(cell)

    End Sub

    Private Sub calculaColumna(ByVal cell As DataGridViewCell)
        Try
            Dim flag As Boolean = True
            Dim countCell As Integer = 0
            Dim sum As Integer = 0
            Dim average As Decimal = 0
            Select Case cell.RowIndex
                Case 0

                Case 1

                Case 2 'Work Hours (horas trabajadas)
                    tblMW.Rows(3).Cells(cell.ColumnIndex).Value = cell.Value * tblMW.Rows(7).Cells(cell.ColumnIndex).Value 'calculamos REVENUE
                    If tblMW.Rows(2).Cells(cell.ColumnIndex).Value IsNot Nothing And Not tblMW.Rows(2).Cells(cell.ColumnIndex).Value = 0 Then
                        tblMW.Rows(8).Cells(cell.ColumnIndex).Value = Math.Round((tblMW.Rows(5).Cells(cell.ColumnIndex).Value / tblMW.Rows(2).Cells(cell.ColumnIndex).Value), 2) 'Calculamos GM/PerHour
                    Else
                        tblMW.Rows(8).Cells(cell.ColumnIndex).Value = 0
                    End If
                Case 3 'Revenue (Promedio)
                    Dim value As Decimal = 0
                    If tblMW.Rows(3).Cells(cell.ColumnIndex).Value IsNot Nothing And Not tblMW.Rows(3).Cells(cell.ColumnIndex).Value = 0 And Not tblMW.Rows(6).Cells(cell.ColumnIndex).Value Is Nothing Then
                        value = Decimal.Parse(tblMW.Rows(6).Cells(cell.ColumnIndex).Value.ToString.Replace("%", "")) / 100
                        tblMW.Rows(5).Cells(cell.ColumnIndex).Value = Math.Round((tblMW.Rows(3).Cells(cell.ColumnIndex).Value * value), 2) 'Calculamos MARGIN
                        tblMW.Rows(4).Cells(cell.ColumnIndex).Value = Math.Round(tblMW.Rows(3).Cells(cell.ColumnIndex).Value - tblMW.Rows(5).Cells(cell.ColumnIndex).Value, 2) 'calcualmos Expense
                    Else
                        tblMW.Rows(5).Cells(cell.ColumnIndex).Value = value 'Calculamos MARGIN
                        tblMW.Rows(4).Cells(cell.ColumnIndex).Value = value 'calcualmos Expense
                    End If
                Case 4 'Expeneses (Viaticos) 

                Case 5 'Margin (Margen)
                    If (tblMW.Rows(3).Cells(cell.ColumnIndex).Value Is Nothing Or (tblMW.Rows(3).Cells(cell.ColumnIndex).Value = 0)) Or tblMW.Rows(5).Cells(cell.ColumnIndex).Value Is Nothing Or (tblMW.Rows(5).Cells(cell.ColumnIndex).Value = 0) Then  'calcualmos Expense
                        tblMW.Rows(4).Cells(cell.ColumnIndex).Value = Math.Round(tblMW.Rows(3).Cells(cell.ColumnIndex).Value - tblMW.Rows(5).Cells(cell.ColumnIndex).Value)
                    Else
                        tblMW.Rows(4).Cells(cell.ColumnIndex).Value = Math.Round(tblMW.Rows(3).Cells(cell.ColumnIndex).Value - tblMW.Rows(5).Cells(cell.ColumnIndex).Value)
                    End If
                    If tblMW.Rows(2).Cells(cell.ColumnIndex).Value IsNot Nothing And Not tblMW.Rows(2).Cells(cell.ColumnIndex).Value = 0 And tblMW.Rows(5).Cells(cell.ColumnIndex).Value IsNot Nothing And Not tblMW.Rows(5).Cells(cell.ColumnIndex).Value = 0 Then 'Calculamos GM/PerHour
                        tblMW.Rows(8).Cells(cell.ColumnIndex).Value = Math.Round((tblMW.Rows(5).Cells(cell.ColumnIndex).Value / tblMW.Rows(2).Cells(cell.ColumnIndex).Value), 3)
                    Else
                        tblMW.Rows(8).Cells(cell.ColumnIndex).Value = 0
                    End If
                Case 6 'GP%
                    Dim value As Decimal = 0
                    If (tblMW.Rows(3).Cells(cell.ColumnIndex).Value IsNot Nothing And Not (tblMW.Rows(3).Cells(cell.ColumnIndex).Value = 0)) And tblMW.Rows(6).Cells(cell.ColumnIndex).Value IsNot Nothing And Not (tblMW.Rows(6).Cells(cell.ColumnIndex).Value = "0%") Then  'calcualmos Expense
                        value = Decimal.Parse(tblMW.Rows(6).Cells(cell.ColumnIndex).Value.ToString.Replace("%", "")) / 100
                        tblMW.Rows(4).Cells(cell.ColumnIndex).Value = Math.Round((tblMW.Rows(3).Cells(cell.ColumnIndex).Value * value), 2)
                    Else
                        tblMW.Rows(4).Cells(cell.ColumnIndex).Value = 0
                    End If
                Case 7 'REV/ Per Hour
                    tblMW.Rows(3).Cells(cell.ColumnIndex).Value = Math.Round(tblMW.Rows(2).Cells(cell.ColumnIndex).Value * tblMW.Rows(7).Cells(cell.ColumnIndex).Value, 2) 'calculamos REVENUE
                Case 8 'GM/ Per Hour

            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try
            Dim dr As DialogResult = MessageBox.Show("Would you like to create a new file select Yes." + vbCrLf + "If you prefer overwrite am existing file select No.", "Message", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If dr = DialogResult.Yes Then
                createExcel(cmbClients.Items(cmbClients.SelectedIndex).ToString.Remove(0, 4) & " " & cmbYear.Items(cmbYear.SelectedIndex))
            ElseIf dr = DialogResult.No Then
                Dim opFile As New OpenFileDialog
                Dim flag As Boolean = False
                While flag = False
                    opFile.ShowDialog()
                    If opFile.CheckFileExists Then
                        If overWriteExcel(opFile.FileName, cmbClients.Items(cmbClients.SelectedIndex).ToString.Remove(0, 4) & " " & cmbYear.Items(cmbYear.SelectedIndex)) Then
                            flag = True
                        End If
                    End If
                End While

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function createExcel(ByVal sheetName As String) As Boolean
        Dim ApExcel = New Microsoft.Office.Interop.Excel.Application
        Dim libro = ApExcel.Workbooks.Add()
        Dim lastRow As Integer = 1
        Dim flagOpen As Boolean = False
        Dim path As String = ""
        lblMsg.Text = "Message: " + "Preparing excel field..."
        Try
            Dim Hoja1 = libro.Worksheets(1)
            Hoja1.Name = sheetName
            Dim count As Integer = 1
            With Hoja1.Range("A1:BR1")
                .Font.Bold = True
                .Font.ColorIndex = 2 'Color de texto
                With .Interior
                    .ColorIndex = 10 'Color de Celda
                End With
                .BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Color.Green) ' Formato de borde de celda
            End With

            Dim countColum As Integer = 1
            For Each colm As DataGridViewColumn In tblMW.Columns
                Hoja1.Cells(1, countColum) = colm.HeaderText.ToString()
                countColum += 1
            Next
            'Hoja1.Range("A:I").EntireColumn.AutoFit
            For Each row As DataGridViewRow In tblMW.Rows
                lastRow += 1
                For Each cell As DataGridViewCell In row.Cells
                    Hoja1.Cells(row.Index + 2, cell.ColumnIndex + 1) = cell.Value
                    lblMsg.Text = "Message: " + "Writing row (" + row.Index.ToString() + ")..."
                Next
            Next
            lblMsg.Text = "Message: " + "Preparing excel to save..."
            Hoja1.Range("A1:BR1").EntireColumn.AutoFit()
            'Hoja1.Range("C2:C" + lastRow).Style.NumberFormat = "0"
            Dim opFile As New SaveFileDialog
            opFile.DefaultExt = "xlsx"
            Dim dateNamefield As Date = Date.Today
            opFile.FileName = "Midwest.xlsx"
            If DialogResult.OK = opFile.ShowDialog() Then
                path = opFile.FileName
                libro.SaveAs(opFile.FileName)
                MsgBox("Successful")
                NAR(Hoja1)
                If DialogResult.Yes = MessageBox.Show("Successful" + vbCrLf + "Would you like to open the excel?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                    flagOpen = True
                End If
            End If
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            libro.Close()
            NAR(libro)
            ApExcel.Quit()
            NAR(ApExcel)
            lblMsg.Text = "Message: "
            If flagOpen Then
                System.Diagnostics.Process.Start(path)
            End If
        End Try

    End Function

    Public Function overWriteExcel(ByVal path As String, ByVal sheetName As String) As Boolean
        Dim ApExcel = New Microsoft.Office.Interop.Excel.Application
        Dim libro = ApExcel.Workbooks.Open(path)
        Dim lastRow As Integer = 1
        Dim flagOpen As Boolean = False
        
        lblMsg.Text = "Message: " + "Preparing excel field..."
        Try
            Dim Hoja1 As Worksheet
            Dim exist As Boolean = False
            For Each hoja As Worksheet In libro.Sheets
                If hoja.Name = sheetName Then
                    ApExcel.DisplayAlerts = False
                    Hoja1 = libro.Worksheets.Add
                    hoja.Delete()
                    Hoja1.Name = sheetName
                    exist = True
                    Exit For
                End If
            Next
            If Not exist Then
                Hoja1 = libro.Worksheets.Add
                Hoja1.Name = sheetName
            End If

            ApExcel.DisplayAlerts = True

            Dim count As Integer = 1
            With Hoja1.Range("A1:BR1")
                .Font.Bold = True
                .Font.ColorIndex = 2 'Color de texto
                With .Interior
                    .ColorIndex = 10 'Color de Celda
                End With
                .BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Color.Green) ' Formato de borde de celda
            End With

            Dim countColum As Integer = 1
            For Each colm As DataGridViewColumn In tblMW.Columns
                Hoja1.Cells(1, countColum) = colm.HeaderText.ToString()
                countColum += 1
            Next
            For Each row As DataGridViewRow In tblMW.Rows
                lastRow += 1
                For Each cell As DataGridViewCell In row.Cells
                    Hoja1.Cells(row.Index + 2, cell.ColumnIndex + 1) = cell.Value
                    lblMsg.Text = "Message: " + "Writing row (" + row.Index.ToString() + ")..."
                Next
            Next
            lblMsg.Text = "Message: " + "Preparing excel to save..."
            Hoja1.Range("A1:BR1").EntireColumn.AutoFit()
            'Hoja1.Range("C2:C" + lastRow).Style.NumberFormat = "0"
            libro.Save()
            MsgBox("Successful")
                NAR(Hoja1)
            If DialogResult.Yes = MessageBox.Show("Successful" + vbCrLf + "Would you like to open the excel?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                flagOpen = True
            End If
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            libro.Close()
            NAR(libro)
            ApExcel.Quit()
            NAR(ApExcel)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(libro)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(ApExcel)
            lblMsg.Text = "Message: "
            If flagOpen Then
                System.Diagnostics.Process.Start(path)
            End If
        End Try
    End Function

    Private Sub tblMW_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles tblMW.CellBeginEdit
        ' Cancelar la edición para la celda en la primera fila y segunda columna
        Select Case e.RowIndex
            Case 2, 3, 4, 5, 8
                e.Cancel = True
        End Select
        If e.ColumnIndex = 1 And e.ColumnIndex = 2 Or (tblMW.Columns(e.ColumnIndex).HeaderText.Contains("F")) Then
            e.Cancel = True
        End If
    End Sub

    Private Sub SaveMidwest_Click(sender As Object, e As EventArgs) Handles btnSaveMidwest.Click
        Try
            Dim cl() As String = cmbClients.Items(cmbClients.SelectedIndex).ToString.Split(" ")
            mtdMW.saveMidwest(tblMW, cl(0), cmbYear.Items(cmbYear.SelectedIndex))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmbYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbYear.SelectedIndexChanged
        If cmbClients.SelectedIndex > -1 Then
            btnReport.Enabled = True
        Else
            btnReport.Enabled = False
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If DialogResult.Yes = MessageBox.Show("If in the process new dates are found, will use to paste the data of 'Head count', 'Average Hours', 'GP% and 'Rev/Per Hour'." & vbCrLf & "Wold you like to continue?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
            pgbBarraDeEstado.Value = 10
            lblMsg.Text = "Message: Finding new hours..."
            Dim dtHRS As Data.DataTable
            Dim cl() As String = cmbClients.Items(cmbClients.SelectedIndex).ToString.Split(" ")
            dtHRS = mtdMW.selectHoursMWByClientID(cl(0), cmbYear.Items(cmbYear.SelectedIndex))
            pgbBarraDeEstado.Value = 45
            lblMsg.Text = "Message: Claculating the data Hrs..."
            For Each clmDT As Data.DataColumn In dtHRS.Columns
                If clmDT.ColumnName.Contains("-") Or clmDT.ColumnName.Contains("/") Then
                    Dim indexClmTblDW As Integer = existColumn(clmDT.ColumnName) 'este es el numero de la columna de la tabla en el formulario
                    If indexClmTblDW >= 0 Then
                        If tblMW.Rows(2).Cells(indexClmTblDW).Value = 0 Then
                            tblMW.Rows(0).Cells(indexClmTblDW).Value = sprHCPW.Value
                            tblMW.Rows(1).Cells(indexClmTblDW).Value = sprAHPW.Value
                            tblMW.Rows(6).Cells(indexClmTblDW).Value = sprGP.Value & "%"
                            tblMW.Rows(7).Cells(indexClmTblDW).Value = sprRPH.Value
                        End If
                        tblMW.Rows(2).Cells(indexClmTblDW).Value = dtHRS.Rows(0).Item(clmDT.ColumnName)
                        calculaColumna(tblMW.Rows(2).Cells(indexClmTblDW))
                    End If
                End If
                lastColum = clmDT.ColumnName
            Next
            pgbBarraDeEstado.Value = 100
            lblMsg.Text = "Message: Finish."
        End If
    End Sub
End Class

Public Class midwestmtdMetodos
    Inherits ConnectioDB
    Private dateWeekendWorked As String = ""
    ''' <summary>
    ''' Este metodo retorna todas las fechas que son Domingo del año.
    ''' </summary>
    ''' <param name="year">Puede seleccionar año o simplemente retornara las fechas del año en curso. </param>
    ''' <returns></returns>
    Public Function selectFechasWeekend(Optional year As String = "") As List(Of String)
        Try
            Dim listDates As New List(Of String)
            conectar()
            Dim cmd As New SqlCommand("WITH FechasCTE AS
(
    SELECT CAST(concat(" + If(year = "", "YEAR(getdate())", year) + ",'01','01')  AS DATE) AS Fecha
    UNION ALL
    SELECT DATEADD(DAY, 1, Fecha)
    FROM FechasCTE
    WHERE Fecha <  CAST(concat(" + If(year = "", "YEAR(getdate())", year) + ",'12','31') AS DATE)
)
SELECT CONVERT(nvarchar, Fecha,110) as 'Fecha'
FROM FechasCTE
WHERE DATENAME(WEEKDAY, Fecha) = 'Sunday'
OPTION (MAXRECURSION 0)", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read()
                listDates.Add(dr("Fecha"))
            End While
            dr.Close()
            Return listDates
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    ''' <summary>
    ''' Este metodo retorna las horas trabajadas en el periodo seleccionado 
    ''' </summary>
    ''' <param name="numberClient">Es necesario para filtrar por cliente.</param>
    ''' <param name="Year">Es necesario para filtrar todas las horas trabajadas.</param>
    ''' <returns></returns>
    Public Function selectHoursMWByClientID(ByVal numberClient As String, ByVal Year As String) As Data.DataTable
        Try
            dateWeekendWorked = selectWeekendWorked(numberClient, Year)
            conectar()
            Dim cmd As New SqlCommand("SELECT Client, " + dateWeekendWorked + "
FROM (
    select 
	cl.companyName as 'Client',
	CONVERT(nvarchar, iif(DATEPART(DW, hw.dateworked)=1, hw.dateworked, DATEADD(DAY,8-DATEPART(DW, hw.dateworked),hw.dateWorked)),110) as 'Weekend',
	sum(hw.hourssT + hoursOT) as 'Total'
from hoursWorked  as hw
inner join task as tk on tk.idAux = hw.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
inner join job  as jb on jb.jobNo = po .jobNo
inner join clients as cl on cl.idClient = jb.idClient
where cl.numberClient = " + numberClient + " and Year(hw.dateWorked) = " + Year + "
group by cl.companyName ,  CONVERT(nvarchar, iif(DATEPART(DW, hw.dateworked)=1, hw.dateworked, DATEADD(DAY,8-DATEPART(DW, hw.dateworked),hw.dateWorked)),110)
) AS SourceTable
PIVOT (
    SUM(Total)
    FOR Weekend IN (" + dateWeekendWorked + ")
) AS PivotTable", conn)
            cmd.CommandTimeout = 250
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New Data.DataTable
                da.Fill(dt)
                Return dt
            Else
                MsgBox("Error in the connection to Data Base check your sever.")
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectar()
        End Try
    End Function
    ''' <summary>
    ''' Este metodo retorna las expenses usadas por el cliente en ese periodo 
    ''' </summary>
    ''' <param name="numberClient">Es necesario para filtrar por cliente.</param>
    ''' <param name="Year">Es necesario para filtrar todas las expenses usadas.</param>
    ''' <returns></returns>
    Public Function selectEXPMWByClientID(ByVal numberClient As String, ByVal Year As String) As Data.DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("SELECT Client, " + dateWeekendWorked + "
FROM (
    select 
	distinct
	cl.companyName as 'Client',
	CONVERT(nvarchar, iif(DATEPART(DW, exu.dateExpense)=1, exu.dateExpense, DATEADD(DAY,8-DATEPART(DW, exu.dateExpense),exu.dateExpense)),110) as 'Weekend',
	sum(exu.amount) as 'TotalEXP'
from expensesUsed as exu
inner join task as tk on tk.idAux = exu.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
inner join job as jb on jb.jobNo = po .jobNo
inner join clients as cl on cl.idClient = jb.idClient
where cl.numberClient = " + numberClient + " and year(exu.dateExpense) = " + Year + "
group by cl.companyName , CONVERT(nvarchar, iif(DATEPART(DW, exu.dateExpense)=1, exu.dateExpense, DATEADD(DAY,8-DATEPART(DW, exu.dateExpense),exu.dateExpense)),110)
) AS SourceTable
PIVOT (
    SUM(TotalEXP)
    FOR Weekend IN (" + dateWeekendWorked + ")
) AS PivotTable", conn)
            cmd.CommandTimeout = 250
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New Data.DataTable
                da.Fill(dt)
                Return dt
            Else
                MsgBox("Error in the connection to Data Base check your sever.")
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectar()
        End Try
    End Function
    ''' <summary>
    ''' Este metodo retorna solo los fines de semana en los que se registraron trabajos
    ''' </summary>
    ''' <param name="numberClient"></param>
    ''' <param name="Year"></param>
    ''' <returns></returns>
    Private Function selectWeekendWorked(ByVal numberClient As String, ByVal Year As String) As String
        Try
            conectar()
            Dim StringFechas As String = ""
            Dim cmd As New SqlCommand("Select Distinct CONVERT(varchar(10), iif(DATEPART(DW, hw.dateworked)=1, hw.dateworked, DATEADD(DAY,8-DATEPART(DW, hw.dateworked),hw.dateWorked)),110)  as 'Weekend' 
From hoursWorked  as hw
inner join task as tk on tk.idAux = hw.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
inner join job as jb on jb.jobNo = po .jobNo
inner join clients as cl on cl.idClient = jb.idClient
where cl.numberClient = " + numberClient + " and hw.dateWorked >= '01-01-" + Year + "'", conn)
            cmd.CommandTimeout = 200
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            While dr.Read()
                StringFechas = StringFechas & "[" & dr("Weekend") & "]" & ","
            End While
            dr.Close()
            StringFechas = StringFechas.Remove(StringFechas.Length - 1)
            Return StringFechas
        Catch ex As Exception
            Return ""
        Finally
            desconectar()
        End Try
    End Function
    ''' <summary>
    ''' Retorna todos los años en los que se tiene registros de trabajos
    ''' </summary>
    ''' <param name="cmb">Es el combo que se llenara con los años. </param>
    ''' <param name="numberClient">Este parametro puede o no ser incluido, de ser asi filtrara por cliente.</param>
    ''' <returns></returns>
    Public Function fillCmdYearHours(ByVal cmb As ComboBox, Optional numberClient As String = "") As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select distinct DATENAME(YEAR,hw.dateWorked) as 'Year' from hoursWorked as hw " + If(numberClient = "", "", "inner join task as tk on tk.idAux = hw.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
inner join job as jb on jb.jobNo = po .jobNo
inner join clients as cl on cl.idClient = jb.idClient
where cl.numberClient = " + numberClient + ""), conn)
            cmd.CommandTimeout = 200
            Dim dr As SqlDataReader = cmd.ExecuteReader
            If cmb.Items IsNot Nothing Then
                cmb.Items.Clear()
            End If
            While dr.Read
                cmb.Items.Add(dr("Year"))
            End While
            dr.Close()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function saveMidwest(ByVal tbl As DataGridView, ByVal numberClient As String, ByVal year As String) As Boolean
        Try
            Dim textDoc As String = ""
            Dim path As String = ""
            Dim falg As Boolean = False
            Dim idClient As String = selectIdClientByNumberClient(numberClient)
            textDoc = "idClient,weekend,HeadcountPerWeek,AverageHoursPerWeek,Workhours,Revenue,Expense,Margin,Revenue,GP,RevPerHour,GMPerHour" & vbCrLf
            For Each column As DataGridViewColumn In tbl.Columns
                If Not column.HeaderText.Contains("F") And column.Index > 1 Then
                    If tbl.Rows(2).Cells(column.Index).Value > 0 Then
                        textDoc = textDoc & idClient & "," & validaFechaParaSQl(column.HeaderText.Replace("-", "/"))
                        For i = 0 To tbl.RowCount - 1
                            textDoc = textDoc & "," & tbl.Rows(i).Cells(column.Index).Value.ToString.Replace("%", "")
                        Next
                        textDoc = textDoc & vbCrLf
                    End If
                End If
            Next
            If ServerName = "localhost" Then
                path = LocalFolderDiretory
            Else
                path = ServerFolderDirectory
            End If
            If Not IO.Directory.Exists(path) Then
                My.Computer.FileSystem.CreateDirectory(path)
            End If
            If IO.Directory.Exists(path & "\midwest.csv") Then
                IO.File.Delete(path & "\midwest.csv")
            End If
            Dim Write As New System.IO.StreamWriter(path & "\midwest.csv")
            Write.WriteLine(textDoc)
            Write.Close()
            conectar()
            Dim cmd As New SqlCommand("delete from midwest where idClient = '" + idClient + "' and YEAR(weekend) = 2025
Bulk INSERT 
	midwest
FROM 
	'" & path & "\midwest.csv" & "'
WITH(
	FIELDTERMINATOR =',',
	ROWTERMINATOR = '\n',
	FIRSTROW = 2,
	MAXERRORS = 1 --NORMALMENTE SE ENCUENTRA EN 10 
)", conn)
            cmd.CommandTimeout = 120
            If cmd.ExecuteNonQuery Then
                falg = True
                MsgBox("Sucessfull: The Process Midwest Insertion is over.")
                Return True
            Else
                falg = False
                MsgBox("Error: The Process Midwest insertion has a problem.")
                Return False
            End If

        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try

    End Function

    ''' <summary>
    ''' Este metodo hace la consulta a la base de datos para guardar el midwest de un cliente, retorna falso si no existe 
    ''' el midwest del periodo seleccionado
    ''' </summary>
    ''' <param name="numberCl">Es el numero de client</param>
    ''' <param name="year">Es para buscar el periodo</param>
    ''' <returns>Retorna True y el dt lleno con la informacion si existe algun record guardado de lo contrario retorna false 
    ''' y la tabla vacia</returns>
    Public Function selectMidWest(ByVal numberCl As String, ByVal year As Integer, ByVal dt As Data.DataTable) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand(" select cl.companyName as 'Client',convert(nvarchar,mw.weekend,110) as 'weekend' , mw.HeadcountPerWeek , mw.AverageHoursPerWeek , mw.Workhours , mw.Revenue , mw.Expense , mw.Margin , mw.GP , mw.RevPerHour , mw.GMPerHour  
 from midwest as mw 
 inner join clients as cl on cl.idClient = mw.idClient
 where cl.numberClient = " + numberCl + " and year (mw.weekend) = " + CStr(year) + "", conn)
            If dt.Columns IsNot Nothing Then
                dt.Clear()
            End If
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function
End Class

