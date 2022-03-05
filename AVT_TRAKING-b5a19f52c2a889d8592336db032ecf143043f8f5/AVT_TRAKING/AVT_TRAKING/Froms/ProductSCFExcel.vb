Imports Microsoft.Office.Core
Imports Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices
Public Class ProductSCFExcel
    Public windowStart As String
    Public numberClient As String
    Public ticketNumber As String
    Dim mtdScaffold As New MetodosScaffold
    Dim tblProductV As New Data.DataTable
    Private Sub ProductSCFExcel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If windowStart = "Incoming" Then
            lblTitle.Text = "Products Incoming"
        ElseIf windowStart = "Outgoing" Then
            lblTitle.Text = "Products Outgoing"
            tblProducts.Columns("QTYMax").Visible = True
        End If
    End Sub
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.Close()
    End Sub
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
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

    Private Sub btnUpdateExcel_Click(sender As Object, e As EventArgs) Handles btnUpdateExcel.Click
        Try
            MessageBox.Show("Please verify that the document have the Columns QTY, IDProduct in the column A and B. Will work in the first WorkSheet", "Important", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            pgbComplete.Value = 5
            lblMessage.Text = "Message: Opening the excel document..."
            Dim openFile As New OpenFileDialog
            openFile.DefaultExt = "*.xlsm"
            If windowStart = "Incoming" Then
                openFile.FileName = "Product Incoming"
            Else
                openFile.FileName = "Product Outgoing"
            End If

            Dim countErrors As Integer = 0
            Dim flagRepeat As Boolean = False
            If DialogResult.OK = openFile.ShowDialog() Then
                lblMessage.Text = "Message: Starting to read the document..."
                Dim ApExcel = New Microsoft.Office.Interop.Excel.Application
                Dim libro = ApExcel.Workbooks.Open(openFile.FileName)
                Dim products As New Worksheet
                Try
                    products = libro.Worksheets(1)
                    lblMessage.Text = "Message: Open sheet '" + libro.Worksheets(1).Name + "'"


                    Dim mensaje As String = ""
                    Dim filasError As String = ""
                    Dim cont As Integer = 2
                    tblProducts.Rows.Clear()
                    Dim Cum As String = ""
                    Dim um As String = ""
                    Dim description As String = ""

                    If mtdScaffold.llenarTablaProductosIcomminOutgoing(tblProductV) Then
                        Dim rowsExcel As Long = nreg(products, CLng(2), CLng(2))
                        Dim increment = (90 / rowsExcel)
                        Dim flagIncrement = If(increment > 1, CInt(90 / rowsExcel), If(increment < 1 And increment > 0.5, 2, If(increment < 0.5 And increment > 0.25, 3, 4)))
                        lblMessage.Text = "Message: Reading Excel..."
                        pgbComplete.Value = pgbComplete.Value + 5
                        Dim countIncrement As Integer = 0
                        While products.Cells(cont, 1).Text <> "" And products.Cells(cont, 2).Text <> ""
                            Dim datos = validarDatos(products.Cells(cont, 2).Text)
                            tblProducts.Rows.Add(products.Cells(cont, 1).Text, products.Cells(cont, 2).Text, datos(0), datos(1), datos(2), If(windowStart = "Incoming", "", datos(4)))
                            If datos(3) = "False" Then
                                tblProducts.Rows(tblProducts.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Red
                                countErrors += 1
                            End If
                            countIncrement += 1
                            If pgbComplete.Value <= 96 Then
                                If flagIncrement = countIncrement Then
                                    pgbComplete.Value = pgbComplete.Value + 1
                                    countIncrement = 0
                                End If
                            End If
                            cont += 1
                        End While
                        flagRepeat = validaRepetidos()
                    End If
                    pgbComplete.Value = 100
                Catch ex As Exception
                    pgbComplete.Value = 0
                Finally
                    lblMessage.Text = "Message: Closing Excel..."
                    NAR(products)
                    libro.Close(False)
                    lblMessage.Text = "Message: End Excel." + If(countErrors > 0, CStr(countErrors) + " Products are not inserted check the Product ID.", "") + If(flagRepeat = True, " Some Products are repeat.", "")
                    NAR(libro)
                    ApExcel.Quit()
                    NAR(ApExcel)
                End Try
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            pgbComplete.Value = 0
        Finally
            pgbComplete.Value = 100
        End Try
    End Sub

    Private Function validarDatos(ByVal idProduct As String) As String()
        Dim flag = False
        Dim datos() As String = {"", "", "", "False", ""}
        For Each row As Data.DataRow In tblProductV.Rows
            If CStr(row.ItemArray(0)) = idProduct Then
                datos = {row.ItemArray(1).ToString(), row.ItemArray(2).ToString, row.ItemArray(3).ToString, CStr(True), CStr(row.ItemArray(4))}
                Exit For
            End If
        Next
        Return datos
    End Function
    Private Function validaRepetidos() As Boolean
        Dim flag = False
        For Each row As DataGridViewRow In tblProducts.Rows()
            For Each row1 As DataGridViewRow In tblProducts.Rows()
                If row.Cells(1).Value = row1.Cells(1).Value And row.Index <> row1.Index Then
                    row1.DefaultCellStyle.BackColor = Color.Yellow
                    flag = True
                End If
            Next
            If windowStart <> "Incoming" And CDbl(If(row.Cells(0).Value = "", 0, row.Cells(0).Value)) > CDbl(If(row.Cells(5).Value = "", 0, row.Cells(5).Value)) Then
                Dim colorcell = row.DefaultCellStyle.BackColor
                If colorcell.IsEmpty Then
                    row.DefaultCellStyle.BackColor = Color.Blue
                End If
                flag = True
            End If
        Next
        Return flag
    End Function

    Private Sub btnUpdateTableSCF_Click(sender As Object, e As EventArgs) Handles btnUpdateTableSCF.Click

        Dim scf As scafoldTarking = CType(Owner, scafoldTarking)
        For Each row As DataGridViewRow In tblProducts.Rows
            If windowStart = "Incoming" Then
                If row.DefaultCellStyle.BackColor.IsEmpty Then
                    scf.tblInComing.Rows.Add(row.Cells(0).Value, row.Cells(1).Value, row.Cells(3).Value, row.Cells(2).Value, row.Cells(4).Value, "")
                End If
            Else
                If row.DefaultCellStyle.BackColor.IsEmpty Then
                    scf.tblOutGoing.Rows.Add(row.Cells(0).Value, row.Cells(1).Value, row.Cells(3).Value, row.Cells(2).Value, row.Cells(4).Value, "", row.Cells(5).Value)
                End If
            End If
        Next
        Me.Close()
    End Sub
End Class