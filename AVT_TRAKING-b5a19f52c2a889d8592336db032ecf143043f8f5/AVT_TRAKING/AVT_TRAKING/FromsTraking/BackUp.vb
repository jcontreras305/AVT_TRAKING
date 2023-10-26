Imports System.Runtime.InteropServices
Imports System.Data.SqlClient
Imports System.IO
Public Class Backup
    Dim SaveFD As New SaveFileDialog
    Dim OpenFD As New OpenFileDialog
    Dim mtd As New metodosBackUp
    Private Sub Backup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtIndications.Text = "If you want to choose a new folder to save the backup, you need to do the following steps:
1.First you need to create the folder in the path where you wnat to save the Backup.For example: ('C\Users\Backup').

2.Later you need the services running and get the services user name of SQLServer,
2.1 Press the key Windows + R and type 'services.msc' to open a new window, in this window 
you need to find the service 'SQL Server (SQLEXPRESS)' do a doble click on this service. 
2.2 The window that opened is the properties of the service, select the tab with the name 'Login', it is necessary to check option number two 'This account', the password is automatic it is not necessary to change it.
2.3 Copy the name of the service it could be change but is like 'NT Service\MSSQL$SQLEXPRESS' in a future it will be used. 
2.4 Acept the chage and the window will be close. 
2.5 Now do a Rigth Click on the same service and select the option 'Restart' And Close the Services Widow.  

3 Now is necesary to give the SQLServer account full permision for changue Folder content.
3.1 Right Click on the folder and select properties.
3.2 Select the Security tab in the Window that opened. 
3.3 Locate the Button 'Edit' then click on the 'Add' Button.
3.4 Now is neccesary to paste the SQL Server Account Name (NT Service\MSSQL$SQLEXPRESS), later click on 'Check Names' Botton, the name will be update like 'MSSQL$SQLEXPRESS', just accept to exit.
3.5 At moment is visible the user for SQL Server on the 'Groups Or users names', in the Permissions section Check the 'Full control' on the column 

4 Finally apply the change."
    End Sub
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.Close()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.WindowState = FormWindowState.Minimized
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
    Private Sub btnPathBackup_Click(sender As Object, e As EventArgs) Handles btnPathBackup.Click
        Try
            SaveFD.Filter = "SQL Backup Files|*.bak"
            SaveFD.FileName = "VRT-TRAKING-" & Today.Date.ToString("MM-dd-yyyy") & ""
            If SaveFD.ShowDialog = DialogResult.OK Then
                txtPathBackup.Text = SaveFD.FileName
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnPathRestore_Click(sender As Object, e As EventArgs) Handles btnPathRestore.Click
        Try
            OpenFD.Filter = "SQL Backup Files|*.bak"
            If OpenFD.ShowDialog = DialogResult.OK Then
                txtPathRestore.Text = OpenFD.FileName
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnBackup_Click(sender As Object, e As EventArgs) Handles btnBackup.Click
        If txtPathBackup.Text <> "" Then
            mtd.makeBackup(txtPathBackup.Text, txtMessage)
        Else
            MessageBox.Show("Please choose a path.")
        End If
    End Sub

    Private Sub btnRestore_Click(sender As Object, e As EventArgs) Handles btnRestore.Click
        If txtPathRestore.Text <> "" Then
            mtd.updateBackUp(txtPathRestore.Text, txtMessage)
        Else
            MessageBox.Show("Please select a .bak File to perform a restore.")
        End If
    End Sub
End Class

Public Class metodosBackUp
    Inherits ConnectioDB

    Public Function makeBackup(ByVal path As String, ByRef txtMessage As TextBox) As Boolean
        Try
            connectToServer()
            txtMessage.Text = txtMessage.Text & vbCrLf & "Verifing tha the paht is Correct..."
            Dim drAux() As String = path.Split("\")
            Dim pathAux As String = ""
            For i = 0 To drAux.Length - 2
                pathAux = pathAux & drAux(i) & "\"
            Next
            If Directory.Exists(pathAux) Then
                Dim command As String = "BACKUP DATABASE [VRT_TRAKING]
TO DISK = '" & path & "' 
	WITH FORMAT,
	MEDIANAME = 'SQLServerBackups', 
		NAME = N'VRT_TRAKING-Full Database Backup'"
                Dim cmd As SqlCommand = New SqlCommand(command, conn)
                If cmd.ExecuteNonQuery() Then
                    txtMessage.Text = txtMessage.Text & vbCrLf & " The Backup is done."
                End If
            Else
                txtMessage.Text = txtMessage.Text & vbCrLf & " The specified Rute does not exist."
            End If
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            txtMessage.Text = txtMessage.Text & vbCrLf & ex.Message
            Return False

        Finally
            desconectar()
        End Try
    End Function

    Public Function updateBackUp(ByVal path As String, ByVal txtMessage As TextBox) As Boolean
        Try
            connectToServer()
            txtMessage.Text = txtMessage.Text & vbCrLf & "Verifing tha the paht is Correct..."
            Dim drAux() As String = path.Split("\")
            Dim pathAux As String = ""
            For i = 0 To drAux.Length - 2
                pathAux = pathAux & drAux(i) & "\"
            Next
            If Directory.Exists(pathAux) Then
                txtMessage.Text = txtMessage.Text & vbCrLf & "Puting offline the VRT_TRAKING Data Base."
                Dim cmd As New SqlCommand("alter database [VRT_TRAKING] set offline with rollback immediate", conn)

                If cmd.ExecuteNonQuery() Then
                    txtMessage.Text = txtMessage.Text & vbCrLf & "Inserting the Backup..."
                    Dim command As String = "RESTORE DATABASE [VRT_TRAKING] FROM  DISK = '" & path & "' WITH REPLACE"
                    Dim cmd1 As SqlCommand = New SqlCommand(command, conn)
                    If cmd1.ExecuteNonQuery() Then
                        MsgBox("The Data Base was Restored.")
                        txtMessage.Text = txtMessage.Text & vbCrLf & "Enabling the VRT_TRAKING Data Base."
                        Dim cmd3 As New SqlCommand("alter database [PapaSC] set online", conn)
                        cmd3.ExecuteNonQuery()
                        Return True
                    Else
                        txtMessage.Text = txtMessage.Text & vbCrLf & "Was not posible to load the BackUp."
                        Return False
                    End If
                Else
                    Return False
                End If
            Else
                txtMessage.Text = txtMessage.Text & vbCrLf & " The specified Rute does not exist."
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            txtMessage.Text = txtMessage.Text & vbCrLf & ex.Message()
            Return False
        Finally
            desconectar()
        End Try
    End Function
End Class