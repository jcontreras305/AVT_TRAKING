Public Class Camera
    Public foto As Image

    Private Sub Camera_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            pbxImage.Visible = False
            wbcCamara.Start()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnTakePicture_Click(sender As Object, e As EventArgs) Handles btnTakePicture.Click

    End Sub

    Private Sub btnTake_Click(sender As Object, e As EventArgs) Handles btnTake.Click
        pbxImage.Visible = True
        pbxImage.Image = wbcCamara.Imagen
        wbcCamara.Visible = False
        Dim result = MessageBox.Show("Are you sure to save this picture?", "Advertence", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            wbcCamara.Stop()
            foto = wbcCamara.Imagen
            Dim saveFile As New SaveFileDialog
            saveFile.ShowDialog()
            Dim ruta As String = saveFile.FileName
            foto.Save(ruta)
            Dim empl As Employees = CType(Owner, Employees)
            empl.imgPhoto.Image = Image.FromFile(ruta)
            Me.Close()
        End If
    End Sub
End Class