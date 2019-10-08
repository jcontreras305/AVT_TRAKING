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
        Me.wbcCamara = New WebCAM.WebCam()
        Me.btnTake = New System.Windows.Forms.Button()
        Me.pbxImage = New System.Windows.Forms.PictureBox()
        CType(Me.pbxImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'wbcCamara
        '
        Me.wbcCamara.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.wbcCamara.Imagen = Nothing
        Me.wbcCamara.Location = New System.Drawing.Point(12, 4)
        Me.wbcCamara.MilisegundosCaptura = 100
        Me.wbcCamara.Name = "wbcCamara"
        Me.wbcCamara.Size = New System.Drawing.Size(334, 236)
        Me.wbcCamara.TabIndex = 0
        '
        'btnTake
        '
        Me.btnTake.Location = New System.Drawing.Point(105, 249)
        Me.btnTake.Name = "btnTake"
        Me.btnTake.Size = New System.Drawing.Size(164, 23)
        Me.btnTake.TabIndex = 2
        Me.btnTake.Text = "Shot"
        Me.btnTake.UseVisualStyleBackColor = True
        '
        'pbxImage
        '
        Me.pbxImage.Location = New System.Drawing.Point(24, 13)
        Me.pbxImage.Name = "pbxImage"
        Me.pbxImage.Size = New System.Drawing.Size(310, 216)
        Me.pbxImage.TabIndex = 1
        Me.pbxImage.TabStop = False
        '
        'Camera
        '
        Me.ClientSize = New System.Drawing.Size(358, 284)
        Me.Controls.Add(Me.btnTake)
        Me.Controls.Add(Me.pbxImage)
        Me.Controls.Add(Me.wbcCamara)
        Me.Name = "Camera"
        CType(Me.pbxImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnTakePicture As Button
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Public WithEvents wcmCamara As WebCAM.WebCam
    Public WithEvents pcbImagen As PictureBox
    Friend WithEvents wbcCamara As WebCAM.WebCam
    Friend WithEvents pbxImage As PictureBox
    Friend WithEvents btnTake As Button
End Class
