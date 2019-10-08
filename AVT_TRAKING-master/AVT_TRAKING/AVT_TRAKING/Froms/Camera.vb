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
    'ESTE CODIGO ES PARA TOMAR LA FOTO Y ENVIARLA A LA INTERFAZ QUE HAYA REALIZADO SU LLAMADAS
    Private Sub btnTake_Click(sender As Object, e As EventArgs) Handles btnTake.Click
        pbxImage.Visible = True
        pbxImage.Image = wbcCamara.Imagen
        wbcCamara.Visible = False
        Dim result = MessageBox.Show("Are you sure to save this picture?", "Advertence", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            wbcCamara.Stop()
            foto = wbcCamara.Imagen
            Dim saveFile As New SaveFileDialog 'ABRIREMOS EL BUSCADOR DE ARCHIVOS PARA GUARDAR LA IMAGEN DE FORMA FISICA
            saveFile.ShowDialog() ' MOSTRAMOS EL BUCADOR DE WINDOWS
            Dim ruta As String = saveFile.FileName ' GUARDAMOS LA IMAGEN Y SU RUTA EN LA VARIABLE ruta
            foto.Save(ruta) ' LA VARIABLE DE TIPO IMAGE foto LE ASIGNAMOS LA RUTA PARA QUE OBTENGA LA RUTA DE LA PC
            Dim empl As Employees = CType(Owner, Employees) ' AQUI INDICAMOS QUE EL FROM DE EMPLOYEES SERA DE TIPO JEFE POR LO QUE TAMBIEN TENDREMOS Y PODREMOS VER LOS OBEJTOS DE ESTE FROM
            empl.imgPhoto.Image = Image.FromFile(ruta) ' ASIGNAMOS LA IMAGEN AL IMAGEBOX DE EMPLOYEES
            Me.Close() 'CERRAMOS EL FROM DE CAMERA
        End If
    End Sub
End Class