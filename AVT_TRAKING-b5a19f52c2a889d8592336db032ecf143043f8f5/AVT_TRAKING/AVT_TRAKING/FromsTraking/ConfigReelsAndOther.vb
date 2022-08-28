Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Public Class ConfigReelsAndOther
    Dim mtd As New MetodosReels
    Dim NewImage As Boolean = False
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