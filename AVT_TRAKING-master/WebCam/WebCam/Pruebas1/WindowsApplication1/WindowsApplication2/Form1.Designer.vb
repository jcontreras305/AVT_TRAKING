<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.WebCam1 = New WebCAM.WebCam
        Me.ButMuestra = New System.Windows.Forms.Button
        Me.PicResultado = New System.Windows.Forms.PictureBox
        Me.TimMuestreo = New System.Windows.Forms.Timer(Me.components)
        Me.ButDetener = New System.Windows.Forms.Button
        Me.ButConfiguracion = New System.Windows.Forms.Button
        Me.LabDirecto = New System.Windows.Forms.Label
        Me.LabResultado = New System.Windows.Forms.Label
        Me.ButBuscaAzul = New System.Windows.Forms.Button
        Me.TrackBarX = New System.Windows.Forms.TrackBar
        Me.TrackBarY = New System.Windows.Forms.TrackBar
        CType(Me.PicResultado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBarX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBarY, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'WebCam1
        '
        Me.WebCam1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.WebCam1.Imagen = Nothing
        Me.WebCam1.Location = New System.Drawing.Point(12, 25)
        Me.WebCam1.MilisegundosCaptura = 100
        Me.WebCam1.Name = "WebCam1"
        Me.WebCam1.Size = New System.Drawing.Size(320, 240)
        Me.WebCam1.TabIndex = 0
        '
        'ButMuestra
        '
        Me.ButMuestra.Location = New System.Drawing.Point(732, 24)
        Me.ButMuestra.Name = "ButMuestra"
        Me.ButMuestra.Size = New System.Drawing.Size(75, 23)
        Me.ButMuestra.TabIndex = 1
        Me.ButMuestra.Text = "Muestra"
        Me.ButMuestra.UseVisualStyleBackColor = True
        '
        'PicResultado
        '
        Me.PicResultado.ErrorImage = Nothing
        Me.PicResultado.Location = New System.Drawing.Point(396, 24)
        Me.PicResultado.Name = "PicResultado"
        Me.PicResultado.Size = New System.Drawing.Size(330, 250)
        Me.PicResultado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PicResultado.TabIndex = 2
        Me.PicResultado.TabStop = False
        '
        'TimMuestreo
        '
        Me.TimMuestreo.Interval = 200
        '
        'ButDetener
        '
        Me.ButDetener.Location = New System.Drawing.Point(732, 212)
        Me.ButDetener.Name = "ButDetener"
        Me.ButDetener.Size = New System.Drawing.Size(75, 23)
        Me.ButDetener.TabIndex = 8
        Me.ButDetener.Text = "Detener"
        Me.ButDetener.UseVisualStyleBackColor = True
        '
        'ButConfiguracion
        '
        Me.ButConfiguracion.Location = New System.Drawing.Point(732, 241)
        Me.ButConfiguracion.Name = "ButConfiguracion"
        Me.ButConfiguracion.Size = New System.Drawing.Size(86, 23)
        Me.ButConfiguracion.TabIndex = 9
        Me.ButConfiguracion.Text = "Configuración"
        Me.ButConfiguracion.UseVisualStyleBackColor = True
        '
        'LabDirecto
        '
        Me.LabDirecto.AutoSize = True
        Me.LabDirecto.Location = New System.Drawing.Point(9, 9)
        Me.LabDirecto.Name = "LabDirecto"
        Me.LabDirecto.Size = New System.Drawing.Size(88, 13)
        Me.LabDirecto.TabIndex = 10
        Me.LabDirecto.Text = "WebCam Directo"
        '
        'LabResultado
        '
        Me.LabResultado.AutoSize = True
        Me.LabResultado.Location = New System.Drawing.Point(393, 9)
        Me.LabResultado.Name = "LabResultado"
        Me.LabResultado.Size = New System.Drawing.Size(55, 13)
        Me.LabResultado.TabIndex = 11
        Me.LabResultado.Text = "Resultado"
        '
        'ButBuscaAzul
        '
        Me.ButBuscaAzul.Location = New System.Drawing.Point(732, 183)
        Me.ButBuscaAzul.Name = "ButBuscaAzul"
        Me.ButBuscaAzul.Size = New System.Drawing.Size(75, 23)
        Me.ButBuscaAzul.TabIndex = 14
        Me.ButBuscaAzul.Text = "Busca azul"
        Me.ButBuscaAzul.UseVisualStyleBackColor = True
        '
        'TrackBarX
        '
        Me.TrackBarX.Location = New System.Drawing.Point(384, 280)
        Me.TrackBarX.Maximum = 330
        Me.TrackBarX.Name = "TrackBarX"
        Me.TrackBarX.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TrackBarX.Size = New System.Drawing.Size(350, 45)
        Me.TrackBarX.TabIndex = 15
        Me.TrackBarX.TickFrequency = 10
        '
        'TrackBarY
        '
        Me.TrackBarY.Location = New System.Drawing.Point(349, 24)
        Me.TrackBarY.Maximum = 250
        Me.TrackBarY.Name = "TrackBarY"
        Me.TrackBarY.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.TrackBarY.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TrackBarY.Size = New System.Drawing.Size(45, 250)
        Me.TrackBarY.TabIndex = 16
        Me.TrackBarY.TickFrequency = 10
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(822, 313)
        Me.Controls.Add(Me.TrackBarY)
        Me.Controls.Add(Me.TrackBarX)
        Me.Controls.Add(Me.ButBuscaAzul)
        Me.Controls.Add(Me.LabResultado)
        Me.Controls.Add(Me.LabDirecto)
        Me.Controls.Add(Me.ButConfiguracion)
        Me.Controls.Add(Me.ButDetener)
        Me.Controls.Add(Me.PicResultado)
        Me.Controls.Add(Me.ButMuestra)
        Me.Controls.Add(Me.WebCam1)
        Me.Name = "Form1"
        Me.Text = "La visión artificial de Mif"
        CType(Me.PicResultado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBarX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBarY, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents WebCam1 As WebCAM.WebCam
    Friend WithEvents ButMuestra As System.Windows.Forms.Button
    Friend WithEvents PicResultado As System.Windows.Forms.PictureBox
    Friend WithEvents TimMuestreo As System.Windows.Forms.Timer
    Friend WithEvents ButDetener As System.Windows.Forms.Button
    Friend WithEvents ButConfiguracion As System.Windows.Forms.Button
    Friend WithEvents LabDirecto As System.Windows.Forms.Label
    Friend WithEvents LabResultado As System.Windows.Forms.Label
    Friend WithEvents ButBuscaAzul As System.Windows.Forms.Button
    Friend WithEvents TrackBarX As System.Windows.Forms.TrackBar
    Friend WithEvents TrackBarY As System.Windows.Forms.TrackBar

End Class
