Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Public Class ChangueProject
    Dim con As New ConnectioDB
    Dim mtdHPW As New MetodosHoursPeerWeek
    Dim mtdJob As New MetodosJobs
    Dim tblProject As New DataTable
    Dim newJobNo As String = ""
    Public JobNo As String = ""
    Public PO As String = ""
    Public WO As String = ""
    Public idAux As String = ""
    Public IdWO As String = ""

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
    Private Sub ChangueProject_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblProject.Text = WO
        lblPO.Text = PO
        lblJobNo.Text = JobNo
        llenarComboClientsReports(cmbClients)
        mtdHPW.llenarTablaProyecto(tblProject)
    End Sub

    Private Sub cmbClients_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClients.SelectedIndexChanged
        If cmbClients.SelectedIndex > -1 Then
            Dim array() As String = cmbClients.Items(cmbClients.SelectedIndex).ToString.Split(" ")
            llenarComboJobsReports(cmbJobs, array(0))
            If cmbJobs.FindString(JobNo) > -1 Then
                cmbJobs.Items.RemoveAt(cmbJobs.FindString(JobNo))
            End If
        End If
    End Sub

    Private Sub cmbJobs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbJobs.SelectedIndexChanged
        Try
            newJobNo = cmbJobs.Items(cmbJobs.SelectedIndex).ToString
            Dim arrayRows() As DataRow = tblProject.Select("project = '" + WO + "' and idPO = " + PO + " and jobNo = " + newJobNo + "")
            If arrayRows.Length > 0 Then
                MessageBox.Show("The Project is already assigned to this Job No.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnChangue.Enabled = False
            Else
                btnChangue.Enabled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Private Sub btnChangue_Click(sender As Object, e As EventArgs) Handles btnChangue.Click
        con.conectar()
        Dim tran As SqlTransaction
        tran = con.conn.BeginTransaction
        Try
            Dim cmdHrsWC As New SqlCommand("select distinct hw.idWorkCode,wc.name,hw.jobNo from hoursWorked  as hw 
                inner join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = hw.jobNo
                where idAux = '" + idAux + "'", con.conn)
            cmdHrsWC.CommandTimeout = 120
            cmdHrsWC.Transaction = tran
            If cmdHrsWC.ExecuteNonQuery Then 'consulto las horas que se van a cambiar para verificar si es necesario agregar los workCodes en el new JobNo
                Dim da As New SqlDataAdapter(cmdHrsWC)
                Dim dtHrsWC As New DataTable
                da.Fill(dtHrsWC)
                If dtHrsWC.Rows.Count > 0 Then 'si existen horas por cambiar
                    Dim cmdWCJob As New SqlCommand("select idWorkCode , name , jobNo from workCode where jobNo = " + newJobNo + "", con.conn)
                    cmdWCJob.Transaction = tran
                    If cmdWCJob.ExecuteNonQuery Then
                        Dim da2 As New SqlDataAdapter(cmdWCJob)
                        Dim dtWCJob As New DataTable
                        da2.Fill(dtWCJob)
                        Dim listNewWc As New List(Of String())
                        Dim flagError As Boolean = False
                        For Each rowHrs As DataRow In dtHrsWC.Rows
                            Dim arrayWC() As DataRow = dtWCJob.Select("idWorkCode = " + rowHrs.ItemArray(0).ToString + "")
                            If arrayWC.Length = 0 Then
                                'Dim datos() As String = {rowHrs.ItemArray(0).ToString(), rowHrs.ItemArray(1).ToString(), "", "0.00", "0.00", "0.00", "", "", rowHrs.ItemArray(2).ToString()}
                                Dim datos() As String = {rowHrs.ItemArray(0).ToString(), rowHrs.ItemArray(1).ToString(), "", "0.00", "0.00", "0.00", "", "", newJobNo, "", "", "", "", "", "", "", ""}
                                If mtdJob.nuevaWC(datos, False) Then
                                    listNewWc.Add({rowHrs.ItemArray(0).ToString(), rowHrs.ItemArray(2).ToString()})
                                Else
                                    flagError = True
                                    Exit For
                                End If
                            End If
                        Next
                        If flagError Then
                            For Each element As String() In listNewWc
                                Dim cmdDeleteWC As New SqlCommand("delete from workCode where idWorkCode = " + element(0) + " and jobNo = " + element(1) + "", con.conn)
                                cmdDeleteWC.Transaction = tran
                                cmdDeleteWC.ExecuteNonQuery()
                            Next
                        Else
                            Dim cmdUpdateHW As New SqlCommand("update hoursWorked set jobNo = " + newJobNo + "where idAux = '" + idAux + "'", con.conn)
                            cmdUpdateHW.Transaction = tran
                            If cmdUpdateHW.ExecuteNonQuery() Then
                                Dim cmdUpdateProject As New SqlCommand("if not exists(select * from projectOrder where jobNo = " + newJobNo + " and idPO = " + PO + " )
begin 
	insert into projectOrder values (" + PO + " ," + newJobNo + ",'','')
	update workOrder set idPO =" + PO + " , jobNo = " + newJobNo + " where idWO = '" + IdWO + "'
end
else if exists(select * from projectOrder where jobNo = " + newJobNo + " and idPO = " + PO + " )
begin 
	update workOrder set idPO =" + PO + " , jobNo = " + newJobNo + " where idAuxWO = '" + IdWO + "'
end", con.conn)
                                cmdUpdateProject.Transaction = tran
                                If cmdUpdateProject.ExecuteNonQuery > 0 Then
                                    tran.Commit()
                                    MsgBox("Successful.")
                                Else
                                    tran.Rollback()
                                    MsgBox("Error: It was not possible to make the change.")
                                End If
                            Else
                                tran.Rollback()
                                MsgBox("Error: The error was while copying the records. It was not possible to make the change.")
                            End If
                        End If
                    End If
                Else
                    Dim cmdUpdateProject As New SqlCommand("if not exists(select * from projectOrder where jobNo = " + newJobNo + " and idPO = " + PO + " )
begin 
	insert into projectOrder values (" + PO + " ," + newJobNo + ",'','')
	update workOrder set idPO =" + PO + " , jobNo = " + newJobNo + " where idWO = '" + IdWO + "'
end
else if exists(select * from projectOrder where jobNo = " + newJobNo + " and idPO = " + PO + " )
begin 
	update workOrder set idPO =" + PO + " , jobNo = " + newJobNo + " where idAuxWO = '" + IdWO + "'
end", con.conn)
                    cmdUpdateProject.Transaction = tran
                    If cmdUpdateProject.ExecuteNonQuery > 0 Then
                        tran.Commit()
                        MsgBox("Successful.")
                    Else
                        tran.Rollback()
                        MsgBox("Error: It was not possible to make the change.")
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            tran.Rollback()
        Finally
            con.desconectar()
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

End Class