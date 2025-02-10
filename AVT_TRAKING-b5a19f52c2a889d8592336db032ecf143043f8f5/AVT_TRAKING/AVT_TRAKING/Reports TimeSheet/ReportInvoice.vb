Imports System.Runtime.InteropServices
Imports System.Data.SqlClient
Imports CrystalDecisions.ReportAppServer
Public Class ReportInvoice
    Dim mtdInvoice As New MetodosInvoice
    Dim loadInfo As Boolean = True
    Private Sub ReportInvoice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'llenarComboClientsReports(cmbClient)
        'llenarComboClientsReports(cmbClientFilter)
        llenarComboClientByUser(cmbClient)
        llenarComboClientByUser(cmbClientFilter)

        loadInfo = True
        mtdInvoice.llenarTableAllInvoicePO(tblInvoices)
        loadInfo = False
        If cmbClient.Text <> "" Then
            Dim array() As String = cmbClient.Text.ToString.Split(" ")
            llenarComboPOByClient(cmbPO, array(0))
            cmbPO.Enabled = True
        Else
            cmbPO.Enabled = False
            chbAllPO.Checked = True
        End If
        If cmbClientFilter.Text <> "" Then
            Dim array() As String = cmbClientFilter.Text.ToString.Split(" ")
            llenarComboPOByClient(cmbPOFilter, array(0))
            cmbPOFilter.Enabled = True
        Else
            cmbPOFilter.Enabled = False
            chbAllPOFilter.Checked = True
        End If
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
    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub
    Private Sub cmbClient_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClient.SelectedIndexChanged
        Try
            Dim array() As String = If(cmbClient.SelectedItem IsNot Nothing, cmbClient.SelectedItem.ToString().Split(" "), "")
            llenarComboPOByClient(cmbPO, array(0))
            cmbPO.Enabled = True
            chbAllPO.Checked = False
        Catch ex As Exception
        End Try
    End Sub
    Private Sub cmbClientFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClientFilter.SelectedIndexChanged
        Try
            Dim array() As String = If(cmbClientFilter.SelectedItem IsNot Nothing, cmbClientFilter.SelectedItem.ToString().Split(" "), "")
            llenarComboPOByClient(cmbPOFilter, array(0))
            cmbPOFilter.Enabled = True
            chbAllPOFilter.Checked = False
        Catch ex As Exception
        End Try
    End Sub
    Private Sub chbAllPO_CheckedChanged(sender As Object, e As EventArgs) Handles chbAllPO.CheckedChanged
        If chbAllPO.Checked Then
            cmbPO.Enabled = False
        Else
            cmbPO.Enabled = True
        End If
        llenarTabla()
    End Sub
    Private Sub chbAllPOFilter_CheckedChanged(sender As Object, e As EventArgs) Handles chbAllPOFilter.CheckedChanged
        If chbAllPOFilter.Checked Then
            cmbPOFilter.Enabled = False
        Else
            cmbPOFilter.Enabled = True
        End If
        llenarTablaInvoices()
    End Sub
    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        Try
            If tblInvoiceCodes.Rows.Count > 0 Then
                Dim flag As Boolean = True
                flag = validarInvoice()
                If flag = False Then
                    flag = MessageBox.Show("Some Projects in the range of dates choosed was inserted. Are you sure to continue?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes
                End If
                If flag Then
                    Dim array() = cmbClient.SelectedItem.ToString().Split(" ")
                    Dim idClient As String = array(0)
                    If mtdInvoice.actualizarInvoicePO(tblInvoiceCodes, array(0), validaFechaParaSQl(dtpStartDate.Value.Date), validaFechaParaSQl(dtpEndDate.Value.Date)) Then
                        If idClient <> "" Or idClient IsNot Nothing Then
                            Dim reportInvoice As New InvoiceProjectOrder
                            reportInvoice.SetParameterValue("@numberClient", idClient)
                            reportInvoice.SetParameterValue("@startDate", validaFechaParaSQl(dtpStartDate.Value.Date))
                            reportInvoice.SetParameterValue("@FinalDate", validaFechaParaSQl(dtpEndDate.Value.Date))
                            reportInvoice.SetParameterValue("@idPO", If(cmbPO.SelectedItem IsNot Nothing, cmbPO.SelectedItem, "0"))
                            reportInvoice.SetParameterValue("@all", If(chbAllPO.Checked, 1, 0))
                            reportInvoice.SetParameterValue("@CompanyName", "Brock")
                            If connecReport(reportInvoice) Then
                                crvIvoice.ReportSource = reportInvoice
                            End If

                        Else
                            MsgBox("Please select a Client.")
                        End If
                    End If
                End If
            Else
                MessageBox.Show("Did not found any 'PO' to make an Invoice, try to change other 'PO' or range of Dates.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub
    Private Sub cmbPO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPO.SelectedIndexChanged
        llenarTabla()
    End Sub
    Private Sub dtpEndDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpStartDate.ValueChanged, dtpEndDate.ValueChanged
        llenarTabla()
    End Sub
    Private Sub llenarTabla()
        Try
            If cmbClient.Text <> "" Then
                Dim array() As String = cmbClient.SelectedItem.ToString.Split(" ")
                mtdInvoice.llenarTableInvoicePO(array(0), validaFechaParaSQl(dtpStartDate.Value.Date), validaFechaParaSQl(dtpEndDate.Value.Date), cmbPO.Text, chbAllPO.Checked, tblInvoiceCodes)
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub
    Private Sub llenarTablaInvoices()
        Try
            If cmbClientFilter.Text <> "" Then
                Dim array() As String = cmbClientFilter.SelectedItem.ToString.Split(" ")
                loadInfo = True
                mtdInvoice.llenarTableAllInvoicePO(tblInvoices, cmbPO.Text, array(0))
                loadInfo = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub
    Private Sub tblInvoiceCodes_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles tblInvoiceCodes.CellEndEdit
        Try
            If e.ColumnIndex = 1 Then
                If Not mtdInvoice.existInvoice(tblInvoiceCodes.Rows(e.RowIndex).Cells(0).Value.ToString(), tblInvoiceCodes.Rows(e.RowIndex).Cells(1).Value.ToString(), validaFechaParaSQl(dtpStartDate.Value.Date()), validaFechaParaSQl(dtpEndDate.Value.Date())) Then
                    MessageBox.Show("Please assign a different invoice, it was used with this PO.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSaveInvoiceNumbers_Click(sender As Object, e As EventArgs) Handles btnSaveInvoiceNumbers.Click
        If tblInvoiceCodes.Rows.Count > 0 Then
            If cmbClient.SelectedItem IsNot Nothing Then
                If DialogResult.Yes = MessageBox.Show("Are you sure to Save the list of Invoice?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information) Then
                    Dim array() As String = cmbClient.SelectedItem.ToString.Split(" ")
                    If mtdInvoice.guardarInvoicePO(tblInvoiceCodes, dtpStartDate.Value, dtpEndDate.Value, array(0)) Then
                        MsgBox("Successful")
                    End If
                End If
            Else
                MessageBox.Show("Please select a Client to Continue.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("Is not one element to insert.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Function validarInvoice() As Boolean
        Try
            Dim flag As Boolean = True
            For Each row As DataGridViewRow In tblInvoiceCodes.Rows
                If Not mtdInvoice.existInvoice(row.Cells(0).Value.ToString(), row.Cells(1).Value.ToString(), validaFechaParaSQl(dtpStartDate.Value.Date()), validaFechaParaSQl(dtpEndDate.Value.Date())) Then
                    flag = False
                    Exit For
                End If
            Next
            Return flag
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Private Sub btnRefreshInvoice_Click(sender As Object, e As EventArgs) Handles btnRefreshInvoice.Click
        loadInfo = True
        mtdInvoice.llenarTableAllInvoicePO(tblInvoices)
        loadInfo = False
    End Sub

    Private Sub btnDeleteInvoce_Click(sender As Object, e As EventArgs) Handles btnDeleteInvoce.Click
        Try
            If tblInvoices.SelectedRows.Count > 0 Then
                If DialogResult.Yes = MessageBox.Show("Are you sure to delete the Invoice", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                    If mtdInvoice.deleteInvoice(tblInvoices) Then
                        cmbClientFilter.Text = ""
                        cmbPOFilter.Text = ""
                        cmbPOFilter.Enabled = False
                        loadInfo = True
                        mtdInvoice.llenarTableAllInvoicePO(tblInvoices)
                        loadInfo = False
                    End If
                End If
            Else
                MessageBox.Show("Please selet a row to conitnue", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Private Sub tblInvoices_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles tblInvoices.CellEndEdit
        If e.ColumnIndex = tblInvoices.Columns("clmStatus").Index Then
            If tblInvoices.CurrentRow.Cells("clmStatus").Value <> tblInvoices.CurrentRow.Cells("clmStatusAux").Value Then
                If DialogResult.Yes = MessageBox.Show("If you accept, declare that the inovice has " + If(tblInvoices.CurrentRow.Cells("clmStatus").Value, "", "not") + " been paid.", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                    If mtdInvoice.updateStatusInvoice(tblInvoices.CurrentRow, tblInvoices.CurrentRow.Cells("clmStatus").Value) Then
                        tblInvoices.CurrentRow.Cells("clmStatusAux").Value = tblInvoices.CurrentRow.Cells("clmStatus").Value
                    Else
                        tblInvoices.CurrentRow.Cells("clmStatus").Value = tblInvoices.CurrentRow.Cells("clmStatusAux").Value
                    End If
                Else
                    tblInvoices.CurrentRow.Cells("clmStatus").Value = tblInvoices.CurrentRow.Cells("clmStatusAuc").Value
                End If
            End If
        End If
    End Sub

    Private Sub tblInvoices_SelectionChanged(sender As Object, e As EventArgs) Handles tblInvoices.SelectionChanged
        If tblInvoices.Columns IsNot Nothing Then
            Dim auxDate As String = CStr(tblInvoices.SelectedRows(0).Cells("clmInvoiceDate").Value)
            Dim arrayDate() As String = auxDate.Split("/")
            Dim dateRow As Date = New Date(arrayDate(2), arrayDate(0), arrayDate(1))
            loadInfo = False
            dtpInvoiceDate.Value = dateRow
            loadInfo = True
        End If

    End Sub

    Private Sub dtpInvoiceDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpInvoiceDate.ValueChanged
        If loadInfo Then
            If tblInvoices.SelectedRows.Count > 0 Then
                If DialogResult.Yes = MessageBox.Show("Are you sure to Update the InvoiceDate?", "Mesaage", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                    If mtdInvoice.UpdateInvoiceDate(tblInvoices, dtpInvoiceDate.Value) Then
                        For Each row1 As DataGridViewRow In tblInvoices.SelectedRows
                            row1.Cells("clmInvoiceDate").Value = dtpInvoiceDate.Value.ToString("MM/dd/yyyy")
                        Next
                    End If
                End If
            Else
                MsgBox("Please select a row.")
            End If
        End If
    End Sub
End Class

Public Class MetodosInvoice
    Inherits ConnectioDB
    Public Function llenarTableAllInvoicePO(ByVal tbl As DataGridView, Optional ByVal idPO As String = "", Optional ByVal clientNumber As String = "") As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("
select inv.invoice,inv.idPO,cl.companyName,CONVERT(nvarchar, inv.startDate,101)as 'startDate',CONVERT(nvarchar, inv.FinalDate,101) as 'finalDate' ,CONVERT(nvarchar, inv.invoiceDate,101) as 'invoiceDate',inv.[status]
from invoice as inv
inner join clients as cl on cl.idClient = inv.idClient 
" + If(idPO <> "", "where inv.idPO = " + idPO, "") + " " + If(clientNumber <> "", If(idPO = "", " Where ", "") + " cl.numberClient =" + clientNumber, "") + "
order by inv.invoice", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            tbl.Rows.Clear()
            While dr.Read()
                tbl.Rows.Add(dr("invoice"), dr("idPO"), dr("invoice"), dr("idPO"), dr("companyName"), dr("startDate"), dr("finalDate"), dr("invoiceDate"), dr("status"), dr("status"))
            End While
            dr.Close()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function llenarTableInvoicePO(ByVal clientNumber As String, ByVal startDate As String, ByVal endDate As String, ByVal idPO As String, ByVal all As Boolean, ByVal tbl As DataGridView) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("declare @initialDate as date = '" + startDate + "'
declare @finalDate as date = '" + endDate + "' 
declare @numberClient as int = " & clientNumber & "
select distinct t1.idPO ,ISNULL((select top 1 invoice from invoice as inv where (inv.startDate between @initialDate and @finalDate or inv.FinalDate between @initialDate and @finalDate) and inv.idPO = t1.idPO),'') as 'Invoice' from(
select distinct po.idPO  from hoursWorked as hw 
inner join task as tk on tk.idAux = hw.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO 
inner join projectOrder as po on po.idPO = wo.idPO and wo.jobNo = po.jobNo
inner join job as jb on po.jobNo = jb.jobNo
inner join clients as cl on cl.idClient = jb.idClient
where hw.dateWorked between @initialDate and @finalDate and cl.numberClient = @numberClient " + If(all, "", If(idPO <> "", " and po.idPO = " + idPO, "")) + "
union all
select distinct po.idPO  from expensesUsed as exu
inner join task as tk on tk.idAux = exu.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO 
inner join projectOrder as po on po.idPO = wo.idPO and wo.jobNo = po.jobNo
inner join job as jb on po.jobNo = jb.jobNo
inner join clients as cl on cl.idClient = jb.idClient
where exu.dateExpense between @initialDate and @finalDate  and cl.numberClient = @numberClient  " + If(all, "", If(idPO <> "", " and po.idPO = " + idPO, "")) + "
union all
select distinct po.idPO  from materialUsed as mu 
inner join task as tk on tk.idAux = mu.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO 
inner join projectOrder as po on po.idPO = wo.idPO and wo.jobNo = po.jobNo
inner join job as jb on po.jobNo = jb.jobNo
inner join clients as cl on cl.idClient = jb.idClient
where mu.dateMaterial between @initialDate and @finalDate  and cl.numberClient = @numberClient " + If(all, "", If(idPO <> "", " and po.idPO = " + idPO, "")) + ")as t1   
order by t1.idPO asc", conn)
            cmd.CommandTimeout = 350
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            tbl.Rows.Clear()
            While dr.Read()
                tbl.Rows.Add(dr("idPO"), dr("Invoice"))
            End While
            dr.Close()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function existInvoice(ByVal idpo As String, ByVal invoice As String, ByVal startDate As String, ByVal finalDate As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("
if (select COUNT(*) from invoice where idPO = " + idpo + " and invoice = '" + invoice + "')> 0
begin
	if  (select COUNT(*) from invoice where idPO = " + idpo + " and invoice = '" + invoice + "' and startDate = '" + startDate + "' and FinalDate = '" + finalDate + "' )>0
	begin 
		select 0 as 'QTY' -- si existe pero no es con esa fecha (se permite)
	end
	else
	begin 
		select 1 as 'QTY'--  si existe con esa fecha (no se permite)
	end 
end
else
begin 
	select 0 as 'QTY' -- no existe
end", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            Dim count As Integer = 0
            While dr.Read()
                count = dr("QTY")
                Exit While
            End While
            dr.Close()
            Return If(count = 0, True, False)
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function actualizarInvoicePO(ByVal tbl As DataGridView, ByVal clientNumber As String, ByVal startDate As String, ByVal Finaldate As String) As Boolean
        conectar()
        Dim tran As SqlTransaction
        tran = conn.BeginTransaction
        Try
            Dim flag As Boolean = True
            Dim cmdDeleteInv As New SqlCommand("delete from tempInvoice", conn)
            cmdDeleteInv.Transaction = tran
            cmdDeleteInv.ExecuteNonQuery()
            For Each row As DataGridViewRow In tbl.Rows()
                Dim cmd As New SqlCommand("
	                insert into tempInvoice values ('" + row.Cells(1).Value.ToString() + "'," + row.Cells(0).Value.ToString() + ",(select top 1 idClient from clients where numberClient = " + clientNumber + "),'" + startDate + "','" + Finaldate + "')", conn)
                cmd.Transaction = tran
                cmd.CommandTimeout = 200
                If cmd.ExecuteNonQuery > 0 Then
                    flag = True
                Else
                    tran.Rollback()
                    flag = False
                    Exit For
                End If
            Next
            If flag Then
                tran.Commit()
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            tran.Rollback()
            Return False
        End Try
    End Function
    Public Function guardarInvoicePO(ByVal tbl As DataGridView, ByVal startDate As Date, ByVal endDate As Date, ByVal clientNum As String) As Boolean
        conectar()
        Dim tran As SqlTransaction
        tran = conn.BeginTransaction
        Try
            Dim flag As Boolean = True
            Dim invoceFail As String = ""
            For Each row As DataGridViewRow In tbl.Rows
                Dim cmd As New SqlCommand("if (select COUNT(*) from invoice where invoice ='" + row.Cells("Invoice").Value.ToString + "' and idPO = " + row.Cells("PO").Value.ToString + ")=0
begin 
	insert into invoice values ('" + row.Cells("Invoice").Value.ToString + "'," + row.Cells("PO").Value.ToString + ",(select idClient from clients where numberClient = " + clientNum + "),'" + validaFechaParaSQl(startDate) + "','" + validaFechaParaSQl(endDate) + "','" + validaFechaParaSQl(Date.Today) + "',0)
end
else if(select COUNT(*) from invoice where invoice = '" + row.Cells("Invoice").Value.ToString + "' and idPO = " + row.Cells("PO").Value.ToString + ")=1
begin
	update invoice set startDate = '" + validaFechaParaSQl(startDate) + "', FinalDate = '" + validaFechaParaSQl(endDate) + "' where invoice = '" + row.Cells("Invoice").Value.ToString + "' and idPO = " + row.Cells("PO").Value.ToString + "
end", conn)
                cmd.Transaction = tran
                If cmd.ExecuteNonQuery > 0 Then
                    flag = True
                Else
                    tran.Rollback()
                    flag = False
                End If
            Next
            If flag Then
                tran.Commit()
                Return True
            Else
                tran.Rollback()
                MessageBox.Show("Error at moment to insert invoice " + invoceFail + ".", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            tran.Rollback()
            Return False
        End Try
    End Function
    Public Function deleteInvoice(ByVal tbl As DataGridView) As Boolean
        Try
            conectar()
            Dim tran As SqlTransaction
            tran = conn.BeginTransaction
            Dim flag As Boolean = True
            For Each row As DataGridViewRow In tbl.SelectedRows
                Dim cmd As New SqlCommand("delete from invoice where invoice = " + row.Cells("clmInvoiceAux").Value.ToString() + " and idPO = " + row.Cells("clmPOAux").Value.ToString() + "", conn)
                cmd.Transaction = tran
                If cmd.ExecuteNonQuery > 0 Then
                    flag = True
                Else
                    flag = False
                    Exit For
                End If
            Next
            If flag Then
                tran.Commit()
                MsgBox("Successful")
                Return True
            Else
                tran.Rollback()
                MsgBox("Is not posible to detele the Invoices try after refresh the table.")
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function updateStatusInvoice(ByVal row As DataGridViewRow, ByVal status As Boolean) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("update invoice set [status]= " + If(status, "1", "0") + " where invoice = '" + row.Cells("clmInvoice").Value.ToString() + "' and idPO = " + row.Cells("clmPO").Value.ToString() + "", conn)
            If cmd.ExecuteNonQuery > 0 Then
                MsgBox("Successful.")
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function UpdateInvoiceDate(ByVal tbl As DataGridView, ByVal newDate As Date) As Boolean
        Try
            conectar()
            Dim tran As SqlTransaction = conn.BeginTransaction
            Dim flag As Boolean = True
            For Each row As DataGridViewRow In tbl.SelectedRows
                Dim cmd As New SqlCommand("update invoice set invoiceDate = '" + validaFechaParaSQl(newDate) + "' where invoice = '" + row.Cells("clmInvoiceAux").Value + "' and idPO = " + row.Cells("clmPOAux").Value.ToString() + " and idClient =(select idClient from clients where companyName = '" + row.Cells("clmClient").Value + "') ", conn)
                cmd.Transaction = tran
                If cmd.ExecuteNonQuery > 0 Then
                    flag = True
                Else
                    flag = False
                    Exit For
                End If

            Next
            If flag Then

                tran.Commit()
                MsgBox("Successful.")
                Return True
            Else
                tran.Rollback()
                Return False
            End If
        Catch ex As Exception
            Return False
            MsgBox(ex.Message())
        Finally
            desconectar()
        End Try
    End Function
End Class
