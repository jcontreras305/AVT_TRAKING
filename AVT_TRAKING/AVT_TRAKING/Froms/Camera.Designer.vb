<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Camera
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.wcmCamara = New WebCAM.WebCam()
        Me.btnTakePicture = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.pcbImagen = New System.Windows.Forms.PictureBox()
        CType(Me.pcbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'wcmCamara
        '
        Me.wcmCamara.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.wcmCamara.Imagen = Nothing
        Me.wcmCamara.Location = New System.Drawing.Point(1, -1)
        Me.wcmCamara.MilisegundosCaptura = 100
        Me.wcmCamara.Name = "wcmCamara"
        Me.wcmCamara.Size = New System.Drawing.Size(320, 240)
        Me.wcmCamara.TabIndex = 0
        '
        'btnTakePicture
        '
        Me.btnTakePicture.Location = New System.Drawing.Point(123, 244)
        Me.btnTakePicture.Name = "btnTakePicture"
        Me.btnTakePicture.Size = New System.Drawing.Size(75, 23)
        Me.btnTakePicture.TabIndex = 2
        Me.btnTakePicture.Text = "Take"
        Me.btnTakePicture.UseVisualStyleBackColor = True
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.FileName = "Picture.jpg"
        Me.SaveFileDialog1.Filter = "Imagenes JPG|*.jpg|Images PNG|*.png"
        '
        'pcbImagen
        '
        Me.pcbImagen.Location = New System.Drawing.Point(12, 12)
        Me.pcbImagen.Name = "pcbImagen"
        Me.pcbImagen.Size = New System.Drawing.Size(298, 214)
        Me.pcbImagen.TabIndex = 1
        Me.pcbImagen.TabStop = False
        '
        'Camera
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(322, 279)
        Me.Controls.Add(Me.btnTakePicture)
        Me.Controls.Add(Me.pcbImagen)
        Me.Controls.Add(Me.wcmCamara)
        Me.Name = "Camera"
        Me.Text = "Camera"
        CType(Me.pcbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnTakePicture As Button
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Public WithEvents wcmCamara As WebCAM.WebCam
    Public WithEvents pcbImagen As PictureBox
End Class
