<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Employees
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tbpEmployees = New System.Windows.Forms.TabPage()
        Me.tbpOtherData = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.imgPhoto = New System.Windows.Forms.PictureBox()
        Me.btnChooseImage = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.tbpEmployees.SuspendLayout()
        CType(Me.imgPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tbpEmployees)
        Me.TabControl1.Controls.Add(Me.tbpOtherData)
        Me.TabControl1.Location = New System.Drawing.Point(3, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(795, 367)
        Me.TabControl1.TabIndex = 0
        '
        'tbpEmployees
        '
        Me.tbpEmployees.Controls.Add(Me.Button2)
        Me.tbpEmployees.Controls.Add(Me.btnChooseImage)
        Me.tbpEmployees.Controls.Add(Me.imgPhoto)
        Me.tbpEmployees.Controls.Add(Me.TextBox6)
        Me.tbpEmployees.Controls.Add(Me.TextBox5)
        Me.tbpEmployees.Controls.Add(Me.TextBox4)
        Me.tbpEmployees.Controls.Add(Me.TextBox3)
        Me.tbpEmployees.Controls.Add(Me.TextBox2)
        Me.tbpEmployees.Controls.Add(Me.TextBox1)
        Me.tbpEmployees.Controls.Add(Me.Label6)
        Me.tbpEmployees.Controls.Add(Me.Label5)
        Me.tbpEmployees.Controls.Add(Me.Label4)
        Me.tbpEmployees.Controls.Add(Me.Label3)
        Me.tbpEmployees.Controls.Add(Me.Label2)
        Me.tbpEmployees.Controls.Add(Me.Label1)
        Me.tbpEmployees.Location = New System.Drawing.Point(4, 22)
        Me.tbpEmployees.Name = "tbpEmployees"
        Me.tbpEmployees.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpEmployees.Size = New System.Drawing.Size(787, 341)
        Me.tbpEmployees.TabIndex = 0
        Me.tbpEmployees.Text = "Employee"
        Me.tbpEmployees.UseVisualStyleBackColor = True
        '
        'tbpOtherData
        '
        Me.tbpOtherData.Location = New System.Drawing.Point(4, 22)
        Me.tbpOtherData.Name = "tbpOtherData"
        Me.tbpOtherData.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpOtherData.Size = New System.Drawing.Size(787, 341)
        Me.tbpOtherData.TabIndex = 1
        Me.tbpOtherData.Text = "Other Data"
        Me.tbpOtherData.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Employe Number"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(27, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "First Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(27, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Last Name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(27, 110)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Middle Name"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(272, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Social Number"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(272, 52)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "SAP Number"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(121, 22)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(123, 20)
        Me.TextBox1.TabIndex = 6
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(121, 49)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(123, 20)
        Me.TextBox2.TabIndex = 7
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(121, 80)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(123, 20)
        Me.TextBox3.TabIndex = 8
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(121, 110)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(123, 20)
        Me.TextBox4.TabIndex = 9
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(348, 19)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(123, 20)
        Me.TextBox5.TabIndex = 10
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(348, 49)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(123, 20)
        Me.TextBox6.TabIndex = 11
        '
        'imgPhoto
        '
        Me.imgPhoto.Location = New System.Drawing.Point(530, 6)
        Me.imgPhoto.Name = "imgPhoto"
        Me.imgPhoto.Size = New System.Drawing.Size(120, 132)
        Me.imgPhoto.TabIndex = 12
        Me.imgPhoto.TabStop = False
        '
        'btnChooseImage
        '
        Me.btnChooseImage.Location = New System.Drawing.Point(550, 144)
        Me.btnChooseImage.Name = "btnChooseImage"
        Me.btnChooseImage.Size = New System.Drawing.Size(88, 23)
        Me.btnChooseImage.TabIndex = 13
        Me.btnChooseImage.Text = "Chose Image"
        Me.btnChooseImage.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(668, 6)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 14
        Me.Button2.Text = "Camera"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Employees
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 380)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "Employees"
        Me.Text = "Employees"
        Me.TabControl1.ResumeLayout(False)
        Me.tbpEmployees.ResumeLayout(False)
        Me.tbpEmployees.PerformLayout()
        CType(Me.imgPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents tbpEmployees As TabPage
    Friend WithEvents tbpOtherData As TabPage
    Friend WithEvents Button2 As Button
    Friend WithEvents btnChooseImage As Button
    Friend WithEvents imgPhoto As PictureBox
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
