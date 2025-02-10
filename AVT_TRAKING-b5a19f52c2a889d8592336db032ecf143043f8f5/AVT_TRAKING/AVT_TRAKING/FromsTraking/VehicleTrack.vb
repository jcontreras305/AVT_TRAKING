Imports System.Data.SqlClient
Imports Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices
Public Class VehicleTrack

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

    Public numClient, jobNo, idVehicleTrack As String
    Dim mtdClmTV As New columnsTrackVehicle
    Private Sub VehicleTrack_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarComboClientByUser(cmbClient)
        'llenarComboClientsReports(cmbClient)
        If numClient IsNot Nothing Then
            cmbClient.SelectedIndex = cmbClient.FindString(numClient)
            If jobNo IsNot Nothing Then
                cmbJobs.SelectedIndex = cmbJobs.FindString(jobNo)
            End If
        End If
    End Sub

    Private Sub cmbClient_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClient.SelectedIndexChanged
        If cmbClient.SelectedIndex > -1 Then
            Dim array() As String = cmbClient.SelectedItem.ToString.Split(" ")
            If array.Length > 0 Then
                llenarComboJobsReports(cmbJobs, array(0))
                numClient = array(0)
                mtdClmTV.SelectColumnsByClient(array(0), tblDefaultElements)
            End If
        Else
            MsgBox("Please select a client.")
        End If
    End Sub

    Private Sub cmbJobs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbJobs.SelectedIndexChanged
        If cmbJobs.SelectedIndex > -1 Then
            jobNo = cmbJobs.Items(cmbJobs.SelectedIndex)
        End If
    End Sub
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            Dim dt As DataTable
            pdbPercent.Value = 5
            txtMessage.Text = "Message: "
            If cmbClient IsNot Nothing Then
                If chbAllJobs.Checked Then
                    txtMessage.Text = "Message: " + "Checking the columns settings.."
                    crearcolumnas()
                    pdbPercent.Value = 10
                    txtMessage.Text = "Message: " + "Collecting the information..."
                    dt = mtdClmTV.SelectVehicleTrack(numClient, dtpBeginDate.Value, dtpEndDate.Value)
                    pdbPercent.Value = 30
                Else
                    txtMessage.Text = "Message: " + "Checking the columns settings.."
                    crearcolumnas()
                    pdbPercent.Value = 10
                    txtMessage.Text = "Message: " + "Collecting the information..."
                    If cmbJobs.SelectedIndex > -1 Then
                        dt = mtdClmTV.SelectVehicleTrack(numClient, dtpBeginDate.Value, dtpEndDate.Value, jobNo)
                        pdbPercent.Value = 30
                    Else
                        MsgBox("Please select a JobNo or select All Jobs.")
                        txtMessage.Text = "Message: " + "Please select a JobNo or select All Jobs."
                        pdbPercent.Value = 0
                    End If
                End If
                If dt IsNot Nothing Then
                    Dim increment As Integer = If(dt.Rows.Count < 60, 2, 1)
                    Dim count As Integer = 1

                    For Each row As DataRow In dt.Rows() 'Recorre la consulta hecha para el track
                        txtMessage.Text = "Message: " + "Wrinting row number " + CStr(count)
                        Dim valTrackRow(tblTrack.Columns.Count() - 1) As String 'Guarda todos los valores para las filas de track
                        For index = 0 To tblDefaultElements.Rows.Count() - 1 'Recorre la tabla de valores por defecto 
                            If tblDefaultElements.Rows(index).Cells("Visible").Value = True Then 'se ve la columna es visible de lo contrario no hace nada 
                                If tblDefaultElements.Rows(index).Cells("Query Value").Value <> "" Then 'verifica si tiene un valor de la consulta asignado
                                    Dim clmIndex = dt.Columns.IndexOf(tblDefaultElements.Rows(index).Cells("Query Value").Value) 'pregunto el index de la columna para obtener el datos del query 
                                    valTrackRow(index) = row.ItemArray(clmIndex).ToString() 'asigno el valor del query conforme a la columna que fue asignada 
                                Else 'Toma el valor por defecto que tiene asignado 
                                    valTrackRow(index) = tblDefaultElements.Rows(index).Cells("Default Value").Value.ToString 'solo asigno el valor por defecto
                                End If
                            End If
                        Next
                        tblTrack.Rows.Add(valTrackRow)
                        If pdbPercent.Value <= 95 Then
                            pdbPercent.Value = pdbPercent.Value + increment
                        End If
                        count += 1
                    Next
                    pdbPercent.Value = 100
                End If
            Else
                MsgBox("Please select a Client.")
                pdbPercent.Value = 100
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            pdbPercent.Value = 100
        End Try
    End Sub



    Private Sub chbAllJobs_CheckedChanged(sender As Object, e As EventArgs) Handles chbAllJobs.CheckedChanged
        cmbJobs.Enabled = Not chbAllJobs.Checked
    End Sub

    Private Sub btnUpdateCancelHeaderText_Click(sender As Object, e As EventArgs) Handles btnUpdateCancelHeaderText.Click
        Try
            If btnUpdateCancelHeaderText.Text = "Update" Then
                btnUpdateCancelHeaderText.Text = "Cancel"
                If tblDefaultElements.Rows IsNot Nothing Then
                    If tblDefaultElements.CurrentRow IsNot Nothing Then
                        txtColumnName.Text = tblDefaultElements.CurrentRow.Cells("Column Name").Value
                        txtHeaderText.Text = tblDefaultElements.CurrentRow.Cells("Column Header").Value
                        If tblDefaultElements.CurrentRow.Cells("Query Value").Value <> "" Then
                            cmbQueryValue.SelectedIndex = cmbQueryValue.FindString(tblDefaultElements.CurrentRow.Cells("Query Value").Value)
                        Else
                            cmbQueryValue.SelectedIndex = -1
                        End If
                        txtDefaultElement.Text = tblDefaultElements.CurrentRow.Cells("Default Value").Value
                        chbVisibleHeaderText.Checked = tblDefaultElements.CurrentRow.Cells("Visible").Value
                        idVehicleTrack = tblDefaultElements.CurrentRow.Cells("Column Index").Value
                    End If
                Else
                    MsgBox("Please select a Client.")
                End If
            Else
                btnUpdateCancelHeaderText.Text = "Update"
                limpiarValores()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub limpiarValores()
        txtColumnName.Text = ""
        txtHeaderText.Text = ""
        cmbQueryValue.SelectedIndex = -1
        txtDefaultElement.Text = ""
        chbVisibleHeaderText.Checked = False
    End Sub

    Private Sub btnSaveHeaderText_Click(sender As Object, e As EventArgs) Handles btnSaveHeaderText.Click
        Try

            If txtColumnName.Text <> "" Then
                If txtHeaderText.Text <> "" Then
                    If txtDefaultElement.Text <> "" Or cmbQueryValue.SelectedIndex > -1 Then
                        If numClient IsNot Nothing Then
                            If btnUpdateCancelHeaderText.Text = "Update" Then ''Creara uno nuevo
                                Dim datos() As String = {txtColumnName.Text, txtHeaderText.Text, If(cmbQueryValue.SelectedIndex > -1, "", txtDefaultElement.Text), cmbQueryValue.Text}
                                If mtdClmTV.AddColumn(datos, chbVisibleHeaderText.Checked, numClient) Then
                                    mtdClmTV.SelectColumnsByClient(numClient, tblDefaultElements)
                                    limpiarValores()
                                End If
                            Else ''acutlizara los valores
                                Dim datos() As String = {txtColumnName.Text, txtHeaderText.Text, If(cmbQueryValue.SelectedIndex > -1, "", txtDefaultElement.Text), cmbQueryValue.Text, idVehicleTrack}
                                If mtdClmTV.updateColumn(datos, chbVisibleHeaderText.Checked, numClient) Then
                                    mtdClmTV.SelectColumnsByClient(numClient, tblDefaultElements)
                                    limpiarValores()
                                End If
                            End If
                        Else
                            MsgBox("Please select a Client.")
                        End If
                    Else
                        MsgBox("Please select a Query Value or assing a 'Default Value'.")
                    End If
                Else
                    MsgBox("Please fill the value 'Header Text'.")
                End If
            Else
                MsgBox("Please fill the value 'Column Name'.")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnFindDoc_Click(sender As Object, e As EventArgs) Handles btnFindDoc.Click
        Try
            pdbPercent.Value = 5
            txtMessage.Text = "Message: Meaking new Excel Document."
            Dim ApExcel = New Microsoft.Office.Interop.Excel.Application
            Dim libro = ApExcel.Workbooks.Add()
            libro.Sheets(1).Name = "TrackImport"
            Try
                Dim hoja1 = libro.Worksheets(1)
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
                    hoja1.cells(1, countColumns) = item
                    hoja1.cells(1, countColumns).Interior.Color = RGB(255, 255, 0)
                    countColumns += 1
                Next
                txtMessage.Text = "Message: Inserting data..."
                pdbPercent.Value = pdbPercent.Value + 5
                Dim increment = (90 / tblTrack.Rows.Count())
                Dim flagIncrement = If(increment > 1, (90 / tblTrack.Rows.Count()), If(increment < 1 And increment > 0.5, 2, If(increment < 0.5 And increment > 0.25, 3, 4)))
                Dim count As Integer = 2
                Dim countIncrement As Integer = 0

                For Each row As DataGridViewRow In tblTrack.Rows()
                    For Each cell As DataGridViewCell In row.Cells
                        'If cell.Visible = True Then
                        'Dim arrayTextColmns() = {3, 5, 6, 11, 15, 16, 19, 28}
                        Dim arrayFormatNumber() = {12, 13, 14}
                        'If Array.IndexOf(arrayTextColmns, cell.ColumnIndex) > -1 Then
                        '    hoja1.cells(row.Index + 2, cell.ColumnIndex + 1) = cell.Value.ToString()
                        '    hoja1.cells(row.Index + 2, cell.ColumnIndex + 1).NumberFormat = "@"
                        'Else
                        'If Array.IndexOf(arrayFormatNumber, cell.ColumnIndex) > -1 Then
                        'hoja1.cells(row.Index + 2, cell.ColumnIndex + 1) = cell.Value.ToString()
                        'hoja1.cells(row.Index + 2, cell.ColumnIndex + 1).NumberFormat = "#,##0.00"
                        'Else
                        hoja1.cells(row.Index + 2, cell.ColumnIndex + 1) = cell.Value.ToString()
                        'End If
                        'libro.Sheets(1).cells(count, countVisibleColumn) = row.Cells(contCell).Value.ToString()


                        'End If
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
                If DialogResult.Yes = MessageBox.Show("Would you like to open the file?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                    If System.IO.File.Exists(sd.FileName) Then
                        Process.Start(sd.FileName)
                    End If
                End If
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

    Private Sub cmbQueryValue_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbQueryValue.SelectedIndexChanged
        If cmbQueryValue.SelectedItem = "" Then
            txtDefaultElement.Enabled = True
        Else
            txtDefaultElement.Enabled = False
        End If
    End Sub

    Private Sub crearcolumnas()
        If tblDefaultElements.Rows IsNot Nothing Then
            If tblTrack.Columns IsNot Nothing Then
                tblTrack.Columns.Clear()
            End If
            Dim NoColumns As Integer = 1
            While NoColumns <= tblDefaultElements.Rows.Count
                For Each row As DataGridViewRow In tblDefaultElements.Rows()
                    If NoColumns = row.Cells(0).Value Then
                        If row.Cells(5).Value = True Then
                            tblTrack.Columns.Add(row.Cells(1).Value, row.Cells(2).Value)
                        End If
                        NoColumns += 1
                        Exit For
                    End If
                Next
            End While
        End If
    End Sub
End Class

Public Class columnsTrackVehicle
    Inherits ConnectioDB
    ''Public columns = New String(,) {{"1", "Record ID", "Record ID"}, {"2", "Force or Reject", "Force or Reject"}, {"3", "Date", "Date"}, {"4", "Order Type", "Order Type"}, {"5", "Location ID", "Location ID"}, {"6", "Company Code", "Company Code"}, {"7", "Agreement", "Agreement"}, {"8", "Group", "Group"}, {"9", "Type", "Type"}, {"10", "Equip Unique ID", "Equip Unique ID"}, {"11", "Area", "Area"}, {"12", "Level 1 ID", "Level 1 ID"}, {"13", "Level 2 ID", "Level 2 ID"}, {"14", "Level 3 ID"}, {"15", "Level 4 ID"}, {"16", "Base Hrs", "Base Hrs"}, {"17", "Over Hrs", "Over Hrs"}, {"18", "Idle Hrs", "Idle Hrs"}, {"19", "Other Costs", "Other Costs"}, {"20", "Other Costs Name", "Other Costs Name"}, {"21", "Extra", "Extra"}, {"22", "GL Account", "GL Account"}}
    Public Function SelectColumnsByClient(ByVal clientNum As String, ByVal tblFormatColumns As DataGridView) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("Declare @numberClient as int = " + clientNum + "
Declare @idClient as varchar(36)
if (select COUNT(*) from trackVehicleElement as tve inner join clients as cl on cl.idClient = tve.idClient where cl.numberClient = @numberClient ) > 0
begin 
	select idTrackElement as 'Column Index',columnName as 'Column Name',columnHeader as 'Column Header',queryValue as 'Query Value',defaultValue as 'Default Value',visible as 'Visible',idClient  from trackVehicleElement  as tve where idClient = (select idClient from clients where numberClient = @numberClient)
end
else
begin 
	set @idClient = (select top 1 idClient from clients where numberClient = @numberClient)
	insert into trackVehicleElement values
			(1,'Record ID','Record ID','Record ID','',1,@idClient),
			(2,'Force or Reject','Force or Reject','','F',1,@idClient),
			(3,'Date','Date','Date','',1,@idClient),
			(4,'Order Type','Order Type','','POWO',1,@idClient),
			(5,'Location ID','Location ID','','1',1,@idClient),
			(6,'Company Code','Company Code','','0',1,@idClient),
			(7,'Agreement','Agreement','','0',1,@idClient),
			(8,'Group','Group','','',1,@idClient),
			(9,'Type','Type','','',1,@idClient),
			(10,'Equip Unique ID','Equip Unique ID','Equipment Unit ID','',1,@idClient),
			(11,'Area','Area','Area','',1,@idClient),
			(12,'Level 1 ID','Level 1 ID','Level 1 ID','',1,@idClient),
			(13,'Level 2 ID','Level 2 ID','Level 2 ID','',1,@idClient),
			(14,'Level 3 ID','Level 3 ID','Level 3 ID','',1,@idClient),
			(15,'Level 4 ID','Level 4 ID','','',1,@idClient),
			(16,'Base Hrs','Base Hrs','','1',1,@idClient),
			(17,'Over Hrs','Over Hrs','Over Hrs','',1,@idClient),
			(18,'Idle Hrs','Idle Hrs','','0.00',1,@idClient),
			(19,'Other Costs','Other Costs','','0',1,@idClient),
			(20,'Other Costs Name','Other Costs Name','','',1,@idClient),
			(21,'Extra','Extra','Extra','',1,@idClient),
			(22,'GL Account','GL Account','','',1,@idClient)
	select idTrackElement as 'Column Index',columnName as 'Column Name',columnHeader as 'Column Header',queryValue as 'Query Value',defaultValue as 'Default Value',visible as 'Visible',idClient  from trackVehicleElement as tve where idClient = @idClient
end", conn)
            If cmd.ExecuteNonQuery Then
                Dim dt As New Data.DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                tblFormatColumns.DataSource = dt
                tblFormatColumns.Columns("idClient").Visible = False
                tblFormatColumns.Columns("Column Index").Visible = False
                'tblFormatColumns.Columns("queryValue").Visible = False
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

    Public Function SelectVehicleTrack(ByVal clientNum As String, ByVal StartDate As Date, ByVal EndDate As Date, Optional jobNo As String = "0") As DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("select ROW_NUMBER() OVER(order by (select 1)) as 'Record ID',CONVERT(nvarchar,mtu.dateMaterial,112)as 'Date',mtu.description as 'Equipment Unit ID',tk.Area as 'Area',po.idPO as 'Level 1 ID',wo.idWO as 'Level 2 ID',tk.task as 'Level 3 ID', mtu.hoursST as 'Over Hrs',CONVERT(nvarchar,mtu.dateMaterial,112) as 'Extra' from materialUsed as mtu 
inner join material as mt on mtu.idMaterial = mt.idMaterial
inner join task as tk on tk.idAux = mtu.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo 
inner join job as jb on jb.jobNo = po.jobNo
inner join clients as cl on cl.idClient=jb.idClient
where cl.numberClient =" + clientNum + " and mtu.dateMaterial between '" + validaFechaParaSQl(StartDate) + "' and '" + validaFechaParaSQl(EndDate) + "'" + If(jobNo = "0", "", " and jb.jobNo = " + jobNo), conn)
            If cmd.ExecuteNonQuery Then
                Dim dt As New Data.DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        Finally
            desconectar()
        End Try
    End Function

    Public Function AddColumn(ByVal datos() As String, ByVal visible As Boolean, ByVal numberClient As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("insert into trackVehicleElement values(
			(select MAX(idTrackElement)+1 from trackVehicleElement where idClient = (select idClient from clients where numberClient = 102)),
            '" + datos(0) + "',
            '" + datos(1) + "',
            '" + datos(2) + "',
            '" + datos(3) + "',
            " + If(visible, "1", "0") + ",
            (select top 1 idClient from clients where numberClient = " + numberClient + "))", conn)
            If cmd.ExecuteNonQuery > 0 Then
                MsgBox("Successful.")
                Return True
            Else
                MsgBox("Error.")
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally

            desconectar()
        End Try
    End Function
    Public Function updateColumn(ByVal datos() As String, ByVal visible As Boolean, ByVal numberClient As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("update trackVehicleElement set 
                columnName = '" + datos(0) + "',
                columnHeader = '" + datos(1) + "' , 
                queryValue = '" + datos(2) + "',
                defaultValue = '" + datos(3) + "' ,
                visible = " + If(visible, "1", "0") + " where idTrackElement = " + datos(4) + " and 
                idClient = (select top 1 idClient from clients where numberClient = " + numberClient + ")", conn)
            If cmd.ExecuteNonQuery > 0 Then
                MsgBox("Successful.")
                Return True
            Else
                MsgBox("Error.")
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectar()
        End Try
    End Function
End Class