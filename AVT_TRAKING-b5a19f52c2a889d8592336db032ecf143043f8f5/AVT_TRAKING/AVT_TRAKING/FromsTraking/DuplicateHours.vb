Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Public Class DuplicateHours
    Dim mtdMHPW As New MetodosHoursPeerWeek
    Public idEmpleado As String
    Public tblRecordsCopy As DataTable
    Dim con As New ConnectioDB
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
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
    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles TitleBar.MouseMove
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub DuplicateHours_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mtdMHPW.selectEmpleadosWithout(tblEmpleados, idEmpleado)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        pgbProcces.Value = 5
        lblMessage.Text = "Message: " + "Starting process insertion..."
        If tblEmpleados.SelectedRows.Count > 0 Then
            Dim tran As SqlTransaction
            con.conectar()
            tran = con.conn.BeginTransaction
            Dim flag As Boolean = False
            pgbProcces.Value = 5
            lblMessage.Text = "Message: " + "Inserting info..."
            Dim rowInserting As Integer = 0
            For Each rowEmpleado As DataGridViewRow In tblEmpleados.SelectedRows
                rowInserting = rowEmpleado.Index
                For Each row As DataRow In tblRecordsCopy.Rows
                    Dim listDatos As New List(Of String)
                    listDatos.Add("") 'idHourWorked (Es solo si es un update)
                    listDatos.Add(row.ItemArray(3)) 'hrst
                    listDatos.Add(row.ItemArray(4)) 'hrot
                    listDatos.Add(row.ItemArray(5)) 'hrex
                    listDatos.Add(validaFechaParaSQl(row.ItemArray(2))) 'date
                    listDatos.Add(rowEmpleado.Cells("clmId").Value) 'idEmpleado
                    listDatos.Add(row.ItemArray(1)) 'idWorkCode
                    listDatos.Add(row.ItemArray(7)) 'jobNo
                    listDatos.Add(row.ItemArray(0)) 'idTask
                    listDatos.Add(row.ItemArray(6)) 'shift
                    If mtdMHPW.InsertarRecord(listDatos, tran) Then
                        flag = True
                    Else
                        If DialogResult.Yes = MessageBox.Show("A record can be inserted would you like to continue?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) Then
                            flag = False
                            Exit For
                        End If
                    End If
                Next
                If Not flag Then
                    Exit For
                Else
                    If pgbProcces.Value <= 90 Then
                        pgbProcces.Value = pgbProcces.Value + 4
                    End If
                End If
            Next
            pgbProcces.Value = 95
            If flag Then
                tran.Commit()
                pgbProcces.Value = 100
                MsgBox("Successful")
                lblMessage.Text = "Message: Finish."
            Else
                tran.Rollback()
                lblMessage.Text = "Message: Error at row " + rowInserting.ToString + "."
                MessageBox.Show("The Emplyee " + tblEmpleados.Rows(rowInserting).Cells(2).Value + " is likely exced the hours of the day, otherwise, the project or the work code can not be found.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            con.desconectar()
        Else
            MessageBox.Show("Please select the Employee to paste the records.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class