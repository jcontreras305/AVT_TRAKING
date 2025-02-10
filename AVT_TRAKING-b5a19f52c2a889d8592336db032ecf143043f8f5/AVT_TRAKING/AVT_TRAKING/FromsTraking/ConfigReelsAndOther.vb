Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Public Class ConfigReelsAndOther
    Dim mtd As New MetodosReels
    Dim mtdUsers As New MetodosUsers
    Dim listAccess As New List(Of String)
    Dim listClientAcces As New List(Of String)
    Dim NewImage As Boolean = False
    Dim loadindAccess As Boolean = False
    Public closeMainForm As Boolean = False
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
    Private Sub ConfigReelsAndOther_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mtd.selectImgReels(tblImages)
        btnAdd.Enabled = False
        'btnSave.Enabled = False
        pcbImage.SizeMode = PictureBoxSizeMode.Zoom
        fillListView()
        mtdUsers.selectAllUser(tblUsers)
        llenarListClients(chlListClientAccess)
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Try
            Dim openFD As New OpenFileDialog
            If openFD.ShowDialog = DialogResult.OK Then
                pcbImage.Image = Image.FromFile(openFD.FileName)
                Dim arrayImg() As String = openFD.FileName.Split("\")
                txtName.Text = arrayImg(arrayImg.Length - 1)
                NewImage = True
                btnAdd.Enabled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Dim mf As MainFrom = CType(Owner, MainFrom)
        If closeMainForm Then
            MessageBox.Show("Is neccesary to restart.", "System", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            mf.closeMainForm = closeMainForm
        End If
        Me.Close()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If pcbImage.Image IsNot Nothing And NewImage Then
            If txtName.Text <> "" Then
                If mtd.insertImgReels(pcbImage.Image, txtName.Text) Then
                    btnAdd.Enabled = False
                    mtd.selectImgReels(tblImages)
                    pcbImage.Image = Nothing
                    txtName.Text = ""
                End If
            Else
                MessageBox.Show("Please assign a Name to continue.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            MessageBox.Show("Please choose a image to continue.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub tblImages_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles tblImages.CellDoubleClick
        Try
            pcbImage.Image = tblImages.CurrentRow.Cells("ImageReels").Value
            btnAdd.Enabled = False
            NewImage = False
            txtName.Text = tblImages.CurrentRow.Cells("ImageName").Value
            btnSave.Enabled = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If tblImages.SelectedRows.Count > 0 Then
                For Each row As DataGridViewRow In tblImages.SelectedRows()
                    If Not mtd.updateImageReel(row) Then
                        MessageBox.Show("Is not posible to Update the image information with the name: " + row.Cells("ImageName").Value + ".", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Next
                MsgBox("The process to update has finished.")
                mtd.selectImgReels(tblImages)
                pcbImage.Image = Nothing
                txtName.Text = ""
            Else
                MessageBox.Show("Please select a row to continue.")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If tblImages.SelectedRows.Count > 0 Then
                For Each row As DataGridViewRow In tblImages.SelectedRows()
                    If Not mtd.deleteImageReel(row) Then
                        MessageBox.Show("Is not posible to Delete the image information with the name: " + row.Cells("ImageName").Value + ".", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Next
                MsgBox("The process to Delete has finished.")
                mtd.selectImgReels(tblImages)
                pcbImage.Image = Nothing
                txtName.Text = ""
            Else
                MessageBox.Show("Please select a row to continue.")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fillClientAccss(ByVal UserName As String)
        Try

        Catch ex As Exception

        End Try
    End Sub


    Private Sub fillListView()
        If tvwAccess.Nodes IsNot Nothing Then
            tvwAccess.Nodes.Clear()
        End If
        Dim arrayFormAccess() As String = {"Clients", "Employees", "Client Projects", "Material", "Others", "Reports", "Estimation", "Backup", "System"}
        Dim arraySubFormWorkCode() As String = {"Projects", "Time Enter Sheet", "Scaffold Tracking", "Setup", "Material Validation"}
        Dim arraySubFormSetup() As String = {"Expenses", "Company", "Material Code", "Work Code", "PBI"}
        Dim arraySubFormEstimation() As String = {"Setting", "Est. Projects", "Est. Reports"}

        For Each item As String In arrayFormAccess
            tvwAccess.Nodes.Add(item)
        Next
        For Each item As String In arraySubFormWorkCode
            tvwAccess.Nodes(2).Nodes.Add(item)
        Next
        For Each item As String In arraySubFormSetup
            tvwAccess.Nodes(2).Nodes(3).Nodes.Add(item)
        Next
        For Each item As String In arraySubFormEstimation
            tvwAccess.Nodes(6).Nodes.Add(item)
        Next
    End Sub
    Dim idUser As String = ""
    Private Sub tblUsers_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles tblUsers.CellDoubleClick
        Try
            loadindAccess = True
            idUser = tblUsers.CurrentRow.Cells("idUsers").Value
            txtUserName.Text = tblUsers.CurrentRow.Cells("UserName").Value
            txtPassword.Text = tblUsers.CurrentRow.Cells("userPass").Value
            fillListView()
            cargarUserAccess()
            llenarListClients(chlListClientAccess, tblUsers.CurrentRow.Cells("UserName").Value)
            loadindAccess = False
        Catch ex As Exception

        End Try
    End Sub
    Private Sub checkAccess(ByVal Pnode As TreeNode, ByVal access As String)
        If access = Pnode.Text Then
            Pnode.Checked = True
        Else
            For Each node As TreeNode In Pnode.Nodes
                checkAccess(node, access)
            Next
        End If
    End Sub

    Private Sub cargarUserAccess()
        If idUser <> "" Then
            Dim listAccess = mtdUsers.selectAccessUser(idUser)
            For Each access As String In listAccess
                For Each node As TreeNode In tvwAccess.Nodes
                    checkAccess(node, access)
                Next
            Next
        Else
            chlListClientAccess.Items.Clear()
        End If
    End Sub

    Private Sub findSubNodes(ByVal pNode As TreeNode, ByVal list As List(Of String))
        If pNode.Checked Then
            list.Add(pNode.Text)
        End If
        Dim listAux As New List(Of String)
        For Each node As TreeNode In pNode.Nodes
            findSubNodes(node, list)
        Next
    End Sub

    Private Sub btnSaveUser_Click(sender As Object, e As EventArgs) Handles btnSaveUser.Click
        Try
            If txtUserName.Text <> "" Then
                'Dim arrayNodes As New List(Of String)
                loadindAccess = True
                listAccess.Clear()
                listClientAcces.Clear()
                For Each node As TreeNode In tvwAccess.Nodes
                    findSubNodes(node, listAccess)
                Next
                For Each item As String In chlListClientAccess.Items
                    listClientAcces.Add(item)
                Next
                If tblUsers.Rows.Count = 1 And idUser = tblUsers.Rows(0).Cells("idUsers").Value And listAccess.Count < 20 Then
                    MessageBox.Show("Exist only one User and it needs to have total access. Then the user " + tblUsers.Rows(0).Cells("UserName").Value + " will have full access.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    asignUserFullAccess(tblUsers.Rows(0).Cells("idUsers").Value)
                Else
                    If mtdUsers.saveUpdateUser(idUser, txtUserName.Text, txtPassword.Text, listAccess, chlListClientAccess) Then
                        mtdUsers.selectAllUser(tblUsers)
                        txtUserName.Text = ""
                        txtPassword.Text = ""
                        idUser = ""
                        fillListView()
                        closeMainForm = True
                        cargarUserAccess()
                    End If
                End If
                loadindAccess = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnNewUser_Click(sender As Object, e As EventArgs) Handles btnNewUser.Click
        idUser = ""
        txtPassword.Text = ""
        txtUserName.Text = ""
        fillListView()
    End Sub

    Private Sub btnDeleteUser_Click(sender As Object, e As EventArgs) Handles btnDeleteUser.Click
        If tblUsers.Rows.Count >= 2 Then
            If idUser <> "" Then
                If mtdUsers.deleteUsers(idUser) Then
                    idUser = ""
                    mtdUsers.selectAllUser(tblUsers)
                    If tblUsers.Rows.Count = 1 Then
                        txtUserName.Text = ""
                        txtPassword.Text = ""
                        idUser = ""
                        MessageBox.Show("Exist only one User and it needs to have total access. Then the user " + tblUsers.Rows(0).Cells("UserName").Value + " will have full access.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        asignUserFullAccess(tblUsers.Rows(0).Cells("idUsers").Value)
                        closeMainForm = True
                    End If
                End If
            Else
                MessageBox.Show("Please select a User.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            MessageBox.Show("Is not posbile to delete all Users.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub allAccesChangued(ByVal PNode As TreeNode, ByVal turn As Boolean)
        PNode.Checked = turn
        For Each node As TreeNode In PNode.Nodes
            allAccesChangued(node, turn)
        Next
    End Sub

    Private Function asignUserFullAccess(ByVal id As String) As Boolean
        Try
            loadindAccess = True
            For Each node As TreeNode In tvwAccess.Nodes
                allAccesChangued(node, True)
            Next
            listAccess.Clear()
            For Each node As TreeNode In tvwAccess.Nodes
                findSubNodes(node, listAccess)
            Next
            If mtdUsers.saveUpdateUser(id, tblUsers.Rows(0).Cells("UserName").Value, tblUsers.Rows(0).Cells("userPass").Value, listAccess, chlListClientAccess) Then
                mtdUsers.selectAllUser(tblUsers)
                txtUserName.Text = ""
                txtPassword.Text = ""
                idUser = ""
                fillListView()
                cargarUserAccess()
            End If
            loadindAccess = False
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub chbSee_CheckedChanged(sender As Object, e As EventArgs) Handles chbSee.CheckedChanged
        If chbSee.Checked Then
            txtPassword.UseSystemPasswordChar = False
        Else
            txtPassword.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub activeAllParents(ByVal node As TreeNode)
        node.Checked = True
        If node.Parent IsNot Nothing Then
            activeAllParents(node.Parent)
        End If
    End Sub

    Private Sub tvwAccess_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles tvwAccess.AfterCheck
        If Not loadindAccess Then
            If e.Node.Checked = True Then
                If e.Node.Parent IsNot Nothing Then
                    e.Node.Parent.Checked = True
                End If
            End If
        End If
    End Sub

    Private Sub TitleBar_Paint(sender As Object, e As PaintEventArgs) Handles TitleBar.Paint

    End Sub

End Class
Public Class MetodosUsers
    Inherits ConnectioDB
    Public Function selectAllUser(ByVal tbl As DataGridView) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select idUsers, nameUser,passwordUser from users", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            tbl.Rows.Clear()
            While dr.Read
                tbl.Rows.Add(dr("idUsers"), dr("nameUser"), dr("passwordUser"))
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
    Public Function saveUpdateUser(ByVal id As String, ByVal name As String, ByVal pass As String, ByVal arrayAccess As List(Of String), ByVal arrayClientAccess As CheckedListBox) As Boolean
        Dim tran As SqlTransaction
        Try
            conectar()
            Dim flagNotError As Boolean = True
            Dim cmd As New SqlCommand()
            tran = conn.BeginTransaction()
            cmd.Transaction = tran
            Dim newid As Guid = Guid.NewGuid
            If id = "" Then
                cmd.CommandText = "if (select COUNT(*) from users where nameUser = '" + name + "')= 0
begin 
insert into users values ('" + newid.ToString() + "','" + name + "','" + pass + "')
end"
            Else
                cmd.CommandText = "if (select COUNT(*) from users where nameUser = '" + name + "') = 0
begin 
	update users set nameUser = '" + name + "' , passwordUser = '" + pass + "' where idUsers = '" + id + "' 
end
else if (select idUsers from users where nameUser = '" + name + "') = '" + id + "'  
begin
	update users set  passwordUser = '" + pass + "' where idUsers = '" + id + "' 
end"
            End If
            cmd.Connection = conn
            If cmd.ExecuteNonQuery > 0 Then
                If id <> "" Then
                    Dim cmdDeleteAcces As New SqlCommand("delete from userAccess where idUsers = '" + id + "'", conn)
                    cmdDeleteAcces.Transaction = tran
                    cmdDeleteAcces.ExecuteNonQuery()
                Else
                    id = newid.ToString()
                End If
                For Each item As String In arrayAccess
                    Dim cmdAccess As New SqlCommand
                    cmdAccess.CommandText = "insert userAccess values('" + id + "','" + item + "')"
                    cmdAccess.Connection = conn
                    cmdAccess.Transaction = tran
                    If Not cmdAccess.ExecuteNonQuery > 0 Then
                        flagNotError = False
                        Exit For
                    End If
                Next
                If flagNotError Then
                    For Each itemJobAccess As String In arrayClientAccess.Items
                        Dim arraycompanyName() As String = itemJobAccess.Split("-")
                        Dim companyNumber As String = arraycompanyName(0)
                        Dim cmdAccess As New SqlCommand
                        cmdAccess.CommandText = "if (select COUNT(*) from userClientAccess where  idUsers = '" + id + "' and idClient = (select top 1 idClient from clients where numberClient = '" + companyNumber + "')) = 1
begin 
	update userClientAccess set access = " + If(arrayClientAccess.CheckedItems.Contains(itemJobAccess), "1", "0") + " where idUsers = '" + id + "' and idClient = (select top 1 idClient from clients where numberClient = " + companyNumber + ")
end 
else 
begin 
	insert into userClientAccess values ('" + id + "',(select top 1 idClient from clients where numberClient = " + companyNumber + ")," + If(arrayClientAccess.CheckedItems.Contains(itemJobAccess), "1", "0") + ")
end"

                        cmdAccess.Connection = conn
                        cmdAccess.Transaction = tran
                        If Not cmdAccess.ExecuteNonQuery > 0 Then
                            flagNotError = False
                            Exit For
                        End If
                    Next

                End If
                If flagNotError Then
                    tran.Commit()
                    MsgBox("Successful.")
                    Return True
                Else
                    tran.Rollback()
                    Return False
                End If
            Else
                tran.Rollback()
                MsgBox("Error is probaly tha the name user was inserted, please select distict User Name.")
                Return True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function deleteUsers(ByVal idUser As String) As Boolean
        Dim tran As SqlTransaction
        Try
            conectar()
            tran = conn.BeginTransaction
            Dim cmd As New SqlCommand("delete from userAccess where idUsers = '" + idUser + "'", conn)
            cmd.Transaction = tran
            If cmd.ExecuteNonQuery Then
                Dim cmd1 As New SqlCommand("delete from users where idUsers = '" + idUser + "'", conn)
                cmd1.Transaction = tran
                If cmd1.ExecuteNonQuery > 0 Then
                    tran.Commit()
                    MsgBox("Successful.")
                    Return True
                Else
                    tran.Rollback()
                    MsgBox("Error.")
                    Return False
                End If
            Else
                tran.Rollback()
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
    '####################################################################################################################################################################
    '###### METODOS PARA USER ACCESS ####################################################################################################################################
    '####################################################################################################################################################################
    Public Function selectAccessUser(ByVal idUser As String) As List(Of String)
        Try
            conectar()
            Dim cmd As New SqlCommand("select access from userAccess where idUsers = '" + idUser + "'", conn)
            Dim accesList As New List(Of String)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read()
                accesList.Add(dr("access"))
            End While
            dr.Close()
            Return accesList
        Catch ex As Exception
            MsgBox(ex.Message)
            Return New List(Of String)
        Finally
            desconectar()
        End Try
    End Function

End Class
Public Class MetodosReels
    Inherits ConnectioDB

    Public Function selectImgReels(ByVal tbl As DataGridView) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select idImgReel,imgIndex,name,img from imgReels order by imgIndex", conn)
            tbl.Rows.Clear()
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            While dr.Read()
                tbl.Rows.Add(dr("idImgReel"), dr("imgIndex"), dr("name"), BytetoImage(dr("img")))
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

    Public Function selectImgReels() As List(Of Byte())
        Try
            conectar()
            Dim cmd As New SqlCommand("select img from imgReels order by imgIndex asc", conn)
            Dim newImgReels As New List(Of Byte())
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            While dr.Read()
                newImgReels.Add(dr("img"))
            End While
            dr.Close()
            Return newImgReels
        Catch ex As Exception
            MsgBox(ex.Message())
            Return New List(Of Byte())
        Finally
            desconectar()
        End Try
    End Function

    Public Function insertImgReels(ByVal img As Image, ByVal name As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("insert into imgReels values ((select isnull(MAX(imgIndex),0)+1 from imgReels),@name,@img)", conn)
            cmd.Parameters.Add("@name", SqlDbType.VarChar, 100)
            cmd.Parameters("@name").Value = name
            cmd.Parameters.Add("@img", SqlDbType.Image)
            cmd.Parameters("@img").Value = imageToByte(img)
            If cmd.ExecuteNonQuery > 0 Then
                MsgBox("Successful.")
                Return True
            Else
                MsgBox("Error")
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function updateImageReel(ByVal row As DataGridViewRow) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("update imgReels set imgIndex = " + row.Cells("indexImageAux").Value.ToString + " , name = '" + row.Cells("ImageName").Value + "' where idImgReel = " + row.Cells("indexImage").Value.ToString + "", conn)
            If cmd.ExecuteNonQuery > 0 Then
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

    Public Function deleteImageReel(ByVal row As DataGridViewRow) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("delete from imgReels where idImgReel = " + row.Cells("indexImage").Value.ToString() + "", conn)
            If cmd.ExecuteNonQuery > 0 Then
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

End Class

Public Class Users
    Inherits ConnectioDB
    Private _userName, _password, _idUser As String
    Private _listAccess As New List(Of String)
    Public Sub Clear()
        _userName = ""
        _password = ""
        _idUser = ""
        If _listAccess IsNot Nothing Then
            _listAccess.Clear()
        End If
    End Sub

    Public Property UserName As String
        Get
            Return _userName
        End Get
        Set(value As String)
            _userName = value
        End Set
    End Property

    Public Property Password As String
        Get
            Return _password
        End Get
        Set(value As String)
            _password = value
        End Set
    End Property

    Public Property IdUser As String
        Get
            Return _idUser
        End Get
        Set(value As String)
            _idUser = value
        End Set
    End Property

    Public Property ListAccess As List(Of String)
        Get
            Return _listAccess
        End Get
        Set(value As List(Of String))
            _listAccess = value
        End Set
    End Property

    Public Function selectUser(ByVal id As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select us.idUsers, us.nameUser , uac.access from users as us 
inner join userAccess as uac on us.idUsers = uac.idUsers
where us.idUsers = '" + id + "'", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            Clear()
            While dr.Read()
                _idUser = dr("idUser")
                _userName = dr("nameUser")
                _listAccess.Add(dr("access"))
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
    Public Function selectUser(ByVal userName As String, ByVal userPass As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select us.idUsers, us.nameUser , uac.access from users as us 
inner join userAccess as uac on us.idUsers = uac.idUsers
where us.nameUser = '" + userName + "' and us.passwordUser = '" + userPass + "'", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            Clear()
            While dr.Read()
                _idUser = dr("idUsers")
                _userName = dr("nameUser")
                _listAccess.Add(dr("access"))
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

End Class