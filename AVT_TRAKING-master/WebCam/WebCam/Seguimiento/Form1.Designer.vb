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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Button1 = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button6 = New System.Windows.Forms.Button
        Me.TrackBarX = New System.Windows.Forms.TrackBar
        Me.TrackBarY = New System.Windows.Forms.TrackBar
        Me.TraTolerancia = New System.Windows.Forms.TrackBar
        Me.LabTolerancia = New System.Windows.Forms.Label
        Me.LabDireccion = New System.Windows.Forms.Label
        Me.RadDireDch = New System.Windows.Forms.RadioButton
        Me.RadDireIzq = New System.Windows.Forms.RadioButton
        Me.RadAbajo = New System.Windows.Forms.RadioButton
        Me.RadArriba = New System.Windows.Forms.RadioButton
        Me.LabAltura = New System.Windows.Forms.Label
        Me.WebCam = New WebCAM.WebCam
        Me.TraLimYSup = New System.Windows.Forms.TrackBar
        Me.TraLimYInf = New System.Windows.Forms.TrackBar
        Me.TraLimXIzq = New System.Windows.Forms.TrackBar
        Me.TraLimXDch = New System.Windows.Forms.TrackBar
        Me.TraResolucion = New System.Windows.Forms.TrackBar
        Me.LabResolucion = New System.Windows.Forms.Label
        Me.ButContrastes = New System.Windows.Forms.Button
        Me.TimContrastes = New System.Windows.Forms.Timer(Me.components)
        Me.LabHash = New System.Windows.Forms.Label
        Me.ButHuh = New System.Windows.Forms.Button
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBarX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBarY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TraTolerancia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TraLimYSup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TraLimYInf, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TraLimXIzq, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TraLimXDch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TraResolucion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(514, 392)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Réplica 1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.ErrorImage = Nothing
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(433, 24)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(330, 250)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 200
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(514, 363)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 8
        Me.Button4.Text = "Detener"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(595, 363)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(86, 23)
        Me.Button5.TabIndex = 9
        Me.Button5.Text = "Configuración"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "WebCam Directo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(430, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Seguimiento"
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(433, 363)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 23)
        Me.Button6.TabIndex = 14
        Me.Button6.Text = "Busca azul"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'TrackBarX
        '
        Me.TrackBarX.Location = New System.Drawing.Point(421, 280)
        Me.TrackBarX.Maximum = 330
        Me.TrackBarX.Name = "TrackBarX"
        Me.TrackBarX.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TrackBarX.Size = New System.Drawing.Size(350, 45)
        Me.TrackBarX.TabIndex = 15
        Me.TrackBarX.TickFrequency = 10
        '
        'TrackBarY
        '
        Me.TrackBarY.Location = New System.Drawing.Point(386, 24)
        Me.TrackBarY.Maximum = 250
        Me.TrackBarY.Name = "TrackBarY"
        Me.TrackBarY.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.TrackBarY.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TrackBarY.Size = New System.Drawing.Size(45, 250)
        Me.TrackBarY.TabIndex = 16
        Me.TrackBarY.TickFrequency = 10
        '
        'TraTolerancia
        '
        Me.TraTolerancia.Location = New System.Drawing.Point(67, 267)
        Me.TraTolerancia.Maximum = 130
        Me.TraTolerancia.Name = "TraTolerancia"
        Me.TraTolerancia.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TraTolerancia.Size = New System.Drawing.Size(268, 45)
        Me.TraTolerancia.TabIndex = 17
        Me.TraTolerancia.TickFrequency = 5
        Me.TraTolerancia.Value = 5
        '
        'LabTolerancia
        '
        Me.LabTolerancia.AutoSize = True
        Me.LabTolerancia.Location = New System.Drawing.Point(12, 267)
        Me.LabTolerancia.Name = "LabTolerancia"
        Me.LabTolerancia.Size = New System.Drawing.Size(57, 13)
        Me.LabTolerancia.TabIndex = 18
        Me.LabTolerancia.Text = "Tolerancia"
        '
        'LabDireccion
        '
        Me.LabDireccion.AutoSize = True
        Me.LabDireccion.Location = New System.Drawing.Point(12, 353)
        Me.LabDireccion.Name = "LabDireccion"
        Me.LabDireccion.Size = New System.Drawing.Size(52, 13)
        Me.LabDireccion.TabIndex = 19
        Me.LabDireccion.Text = "Dirección"
        '
        'RadDireDch
        '
        Me.RadDireDch.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.RadDireDch.AutoCheck = False
        Me.RadDireDch.AutoSize = True
        Me.RadDireDch.Location = New System.Drawing.Point(71, 353)
        Me.RadDireDch.Name = "RadDireDch"
        Me.RadDireDch.Size = New System.Drawing.Size(66, 17)
        Me.RadDireDch.TabIndex = 20
        Me.RadDireDch.TabStop = True
        Me.RadDireDch.Text = "Derecha"
        Me.RadDireDch.UseVisualStyleBackColor = True
        '
        'RadDireIzq
        '
        Me.RadDireIzq.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.RadDireIzq.AutoCheck = False
        Me.RadDireIzq.AutoSize = True
        Me.RadDireIzq.Location = New System.Drawing.Point(143, 353)
        Me.RadDireIzq.Name = "RadDireIzq"
        Me.RadDireIzq.Size = New System.Drawing.Size(68, 17)
        Me.RadDireIzq.TabIndex = 21
        Me.RadDireIzq.TabStop = True
        Me.RadDireIzq.Text = "Izquierda"
        Me.RadDireIzq.UseVisualStyleBackColor = True
        '
        'RadAbajo
        '
        Me.RadAbajo.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.RadAbajo.AutoCheck = False
        Me.RadAbajo.AutoSize = True
        Me.RadAbajo.Location = New System.Drawing.Point(143, 373)
        Me.RadAbajo.Name = "RadAbajo"
        Me.RadAbajo.Size = New System.Drawing.Size(52, 17)
        Me.RadAbajo.TabIndex = 24
        Me.RadAbajo.TabStop = True
        Me.RadAbajo.Text = "Abajo"
        Me.RadAbajo.UseVisualStyleBackColor = True
        '
        'RadArriba
        '
        Me.RadArriba.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.RadArriba.AutoCheck = False
        Me.RadArriba.AutoSize = True
        Me.RadArriba.Location = New System.Drawing.Point(71, 373)
        Me.RadArriba.Name = "RadArriba"
        Me.RadArriba.Size = New System.Drawing.Size(52, 17)
        Me.RadArriba.TabIndex = 23
        Me.RadArriba.TabStop = True
        Me.RadArriba.Text = "Arriba"
        Me.RadArriba.UseVisualStyleBackColor = True
        '
        'LabAltura
        '
        Me.LabAltura.AutoSize = True
        Me.LabAltura.Location = New System.Drawing.Point(12, 373)
        Me.LabAltura.Name = "LabAltura"
        Me.LabAltura.Size = New System.Drawing.Size(34, 13)
        Me.LabAltura.TabIndex = 22
        Me.LabAltura.Text = "Altura"
        '
        'WebCam
        '
        Me.WebCam.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.WebCam.Imagen = Nothing
        Me.WebCam.Location = New System.Drawing.Point(15, 24)
        Me.WebCam.MilisegundosCaptura = 100
        Me.WebCam.Name = "WebCam"
        Me.WebCam.Size = New System.Drawing.Size(320, 240)
        Me.WebCam.TabIndex = 25
        '
        'TraLimYSup
        '
        Me.TraLimYSup.Location = New System.Drawing.Point(341, 24)
        Me.TraLimYSup.Maximum = 25
        Me.TraLimYSup.Name = "TraLimYSup"
        Me.TraLimYSup.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.TraLimYSup.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TraLimYSup.Size = New System.Drawing.Size(45, 125)
        Me.TraLimYSup.TabIndex = 26
        Me.TraLimYSup.Value = 14
        '
        'TraLimYInf
        '
        Me.TraLimYInf.Location = New System.Drawing.Point(341, 149)
        Me.TraLimYInf.Maximum = 25
        Me.TraLimYInf.Name = "TraLimYInf"
        Me.TraLimYInf.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.TraLimYInf.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TraLimYInf.Size = New System.Drawing.Size(45, 125)
        Me.TraLimYInf.TabIndex = 27
        Me.TraLimYInf.Value = 10
        '
        'TraLimXIzq
        '
        Me.TraLimXIzq.Location = New System.Drawing.Point(421, 316)
        Me.TraLimXIzq.Maximum = 33
        Me.TraLimXIzq.Name = "TraLimXIzq"
        Me.TraLimXIzq.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TraLimXIzq.Size = New System.Drawing.Size(175, 45)
        Me.TraLimXIzq.TabIndex = 28
        Me.TraLimXIzq.Value = 14
        '
        'TraLimXDch
        '
        Me.TraLimXDch.Location = New System.Drawing.Point(588, 316)
        Me.TraLimXDch.Maximum = 33
        Me.TraLimXDch.Name = "TraLimXDch"
        Me.TraLimXDch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TraLimXDch.Size = New System.Drawing.Size(175, 45)
        Me.TraLimXDch.TabIndex = 29
        Me.TraLimXDch.Value = 18
        '
        'TraResolucion
        '
        Me.TraResolucion.Location = New System.Drawing.Point(67, 306)
        Me.TraResolucion.Minimum = 1
        Me.TraResolucion.Name = "TraResolucion"
        Me.TraResolucion.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TraResolucion.Size = New System.Drawing.Size(268, 45)
        Me.TraResolucion.TabIndex = 30
        Me.TraResolucion.Value = 10
        '
        'LabResolucion
        '
        Me.LabResolucion.AutoSize = True
        Me.LabResolucion.Location = New System.Drawing.Point(12, 306)
        Me.LabResolucion.Name = "LabResolucion"
        Me.LabResolucion.Size = New System.Drawing.Size(60, 13)
        Me.LabResolucion.TabIndex = 31
        Me.LabResolucion.Text = "Resolución"
        '
        'ButContrastes
        '
        Me.ButContrastes.Location = New System.Drawing.Point(433, 392)
        Me.ButContrastes.Name = "ButContrastes"
        Me.ButContrastes.Size = New System.Drawing.Size(75, 23)
        Me.ButContrastes.TabIndex = 32
        Me.ButContrastes.Text = "Contrastes"
        Me.ButContrastes.UseVisualStyleBackColor = True
        '
        'TimContrastes
        '
        Me.TimContrastes.Interval = 200
        '
        'LabHash
        '
        Me.LabHash.AutoSize = True
        Me.LabHash.Location = New System.Drawing.Point(319, 368)
        Me.LabHash.Name = "LabHash"
        Me.LabHash.Size = New System.Drawing.Size(39, 13)
        Me.LabHash.TabIndex = 33
        Me.LabHash.Text = "Label3"
        '
        'ButHuh
        '
        Me.ButHuh.Location = New System.Drawing.Point(595, 392)
        Me.ButHuh.Name = "ButHuh"
        Me.ButHuh.Size = New System.Drawing.Size(86, 23)
        Me.ButHuh.TabIndex = 34
        Me.ButHuh.Text = "Huh"
        Me.ButHuh.UseVisualStyleBackColor = True
        '
        'Timer2
        '
        Me.Timer2.Interval = 1000
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(769, 419)
        Me.Controls.Add(Me.ButHuh)
        Me.Controls.Add(Me.LabHash)
        Me.Controls.Add(Me.ButContrastes)
        Me.Controls.Add(Me.LabResolucion)
        Me.Controls.Add(Me.TraResolucion)
        Me.Controls.Add(Me.TraLimXDch)
        Me.Controls.Add(Me.TraLimXIzq)
        Me.Controls.Add(Me.TraLimYInf)
        Me.Controls.Add(Me.TraLimYSup)
        Me.Controls.Add(Me.WebCam)
        Me.Controls.Add(Me.RadAbajo)
        Me.Controls.Add(Me.RadArriba)
        Me.Controls.Add(Me.LabAltura)
        Me.Controls.Add(Me.RadDireIzq)
        Me.Controls.Add(Me.RadDireDch)
        Me.Controls.Add(Me.LabDireccion)
        Me.Controls.Add(Me.LabTolerancia)
        Me.Controls.Add(Me.TraTolerancia)
        Me.Controls.Add(Me.TrackBarY)
        Me.Controls.Add(Me.TrackBarX)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBarX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBarY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TraTolerancia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TraLimYSup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TraLimYInf, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TraLimXIzq, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TraLimXDch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TraResolucion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents WebCam1 As WebCAM.WebCam
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents TrackBarX As System.Windows.Forms.TrackBar
    Friend WithEvents TrackBarY As System.Windows.Forms.TrackBar
    Friend WithEvents TraTolerancia As System.Windows.Forms.TrackBar
    Friend WithEvents LabTolerancia As System.Windows.Forms.Label
    Friend WithEvents LabDireccion As System.Windows.Forms.Label
    Friend WithEvents LabAltura As System.Windows.Forms.Label
    Friend WithEvents WebCam As WebCAM.WebCam
    Friend WithEvents RadDireDch As System.Windows.Forms.RadioButton
    Friend WithEvents RadDireIzq As System.Windows.Forms.RadioButton
    Friend WithEvents RadAbajo As System.Windows.Forms.RadioButton
    Friend WithEvents RadArriba As System.Windows.Forms.RadioButton
    Friend WithEvents TraLimYSup As System.Windows.Forms.TrackBar
    Friend WithEvents TraLimYInf As System.Windows.Forms.TrackBar
    Friend WithEvents TraLimXIzq As System.Windows.Forms.TrackBar
    Friend WithEvents TraLimXDch As System.Windows.Forms.TrackBar
    Friend WithEvents TraResolucion As System.Windows.Forms.TrackBar
    Friend WithEvents LabResolucion As System.Windows.Forms.Label
    Friend WithEvents ButContrastes As System.Windows.Forms.Button
    Friend WithEvents TimContrastes As System.Windows.Forms.Timer
    Friend WithEvents LabHash As System.Windows.Forms.Label
    Friend WithEvents ButHuh As System.Windows.Forms.Button
    Friend WithEvents Timer2 As System.Windows.Forms.Timer

End Class
