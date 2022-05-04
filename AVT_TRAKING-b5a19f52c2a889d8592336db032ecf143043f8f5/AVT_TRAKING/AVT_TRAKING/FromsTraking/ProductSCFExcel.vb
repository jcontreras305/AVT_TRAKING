Imports Microsoft.Office.Core
Imports Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices
Public Class ProductSCFExcel
    Public windowStart As String
    Public idClient As String
    Public ticketNumber As String
    Public nameClient As String
    Public jobNo As String
    Dim mtdScaffold As New MetodosScaffold
    Dim tblProductV As New Data.DataTable
    Private Sub ProductSCFExcel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If windowStart = "Incoming" Then
            lblTitle.Text = "Products Incoming"
            lblClient.Visible = False
            cmbJobNo.Visible = False
            Label1.Visible = False
        ElseIf windowStart = "Outgoing" Then
            lblClient.Text = nameClient
            lblTitle.Text = "Products Outgoing"
            tblProducts.Columns("QTYMax").Visible = True
            llenarComboJobsReportsIDclient(cmbJobNo, idClient)
            If cmbJobNo.Items.Count > 0 And jobNo IsNot Nothing Then
                cmbJobNo.SelectedItem = cmbJobNo.Items(cmbJobNo.FindString(jobNo))
            End If
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
    Private Sub btnUpdateExcel_Click(sender As Object, e As EventArgs) Handles btnUpdateExcel.Click
        Try
            Dim flag As Boolean = True
            If cmbJobNo.SelectedItem Is Nothing And windowStart = "Outgoing" Then
                MessageBox.Show("Please select a Job No. to charge the product list abiables to made a OutGoing.")
                flag = False
            ElseIf windowStart = "Incoming" Then
                flag = True
            End If
            If flag Then
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

                        If If(windowStart = "Outgoing", mtdScaffold.llenarTablaProductosIcomminOutgoing(tblProductV, cmbJobNo.SelectedItem.ToString), mtdScaffold.llenarTablaProductosIcomminOutgoing(tblProductV)) Then
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
            Dim colorcell = row.DefaultCellStyle.BackColor
            If windowStart <> "Incoming" And CDbl(If(row.Cells(0).Value = "", 0, row.Cells(0).Value)) > CDbl(If(row.Cells(5).Value = "", 0, row.Cells(5).Value)) Then
                If colorcell.IsEmpty Then
                    row.DefaultCellStyle.BackColor = Color.Blue
                End If
                flag = True
            ElseIf colorcell.IsEmpty Then
                row.DefaultCellStyle.BackColor = Color.White
            End If
        Next
        Return flag
    End Function

    Private Sub btnUpdateTableSCF_Click(sender As Object, e As EventArgs) Handles btnUpdateTableSCF.Click
        Dim scf As scafoldTarking = CType(Owner, scafoldTarking)
        For Each row As DataGridViewRow In tblProducts.Rows
            If windowStart = "Incoming" Then
                If row.DefaultCellStyle.BackColor.IsEmpty Or row.DefaultCellStyle.BackColor = Color.White Then
                    scf.tblInComing.Rows.Add(row.Cells(0).Value, row.Cells(1).Value, row.Cells(3).Value, row.Cells(2).Value, row.Cells(4).Value, "")
                End If
            Else
                If row.DefaultCellStyle.BackColor.IsEmpty Or row.DefaultCellStyle.BackColor = Color.White Then
                    scf.tblOutGoing.Rows.Add(row.Cells(0).Value, row.Cells(1).Value, row.Cells(3).Value, row.Cells(2).Value, row.Cells(4).Value, "", row.Cells(5).Value)
                End If
            End If
        Next
        Me.Close()
    End Sub
    Private Sub tblProducts_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles tblProducts.CellEndEdit
        If windowStart = "Outgoing" Then
            If e.ColumnIndex = 0 Then
                Dim colorcell = tblProducts.CurrentRow.DefaultCellStyle.BackColor
                Dim valCell = tblProducts.CurrentRow.Cells(0).Value
                Dim maxVal = tblProducts.CurrentRow.Cells(5).Value
                If windowStart <> "Incoming" And CDbl(If(valCell = "", 0, valCell)) > CDbl(If(maxVal = "", 0, maxVal)) Then
                    If colorcell.IsEmpty Or colorcell = Color.White Then
                        tblProducts.CurrentRow.DefaultCellStyle.BackColor = Color.Blue
                    End If
                    tblProducts.CurrentRow.Cells(0).Value = ValCellQty
                ElseIf Not colorcell.IsEmpty Then
                    tblProducts.CurrentRow.DefaultCellStyle.BackColor = Color.White
                End If
            End If
        End If
    End Sub
    Dim ValCellQty As String = "0"
    Private Sub tblProducts_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles tblProducts.CellBeginEdit
        If e.ColumnIndex = 0 Then
            ValCellQty = If(tblProducts.CurrentRow.Cells(0).Value IsNot DBNull.Value, tblProducts.CurrentRow.Cells(0).Value, "0")
        End If
    End Sub
End Class