Public Class Employees
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnChooseImage.Click
        Try
            Dim file As New OpenFileDialog
            file.Filter = "Imagenes JPG|*.jpg|Images PNG|*.png"
            If file.ShowDialog = Windows.Forms.DialogResult.OK Then
                imgPhoto.Image = Image.FromFile(file.FileName)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class