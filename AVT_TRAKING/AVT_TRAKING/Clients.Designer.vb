<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Clients
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtIdClients = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCompanyName = New System.Windows.Forms.TextBox()
        Me.txtAdress = New System.Windows.Forms.TextBox()
        Me.txtCity = New System.Windows.Forms.TextBox()
        Me.txtStateProvince = New System.Windows.Forms.TextBox()
        Me.txtPostalCode = New System.Windows.Forms.TextBox()
        Me.txtContactFistName = New System.Windows.Forms.TextBox()
        Me.txtContactLastName = New System.Windows.Forms.TextBox()
        Me.txtContactTitle = New System.Windows.Forms.TextBox()
        Me.txtPhoneNumber = New System.Windows.Forms.TextBox()
        Me.txtJobNumber = New System.Windows.Forms.TextBox()
        Me.txtSubJob = New System.Windows.Forms.TextBox()
        Me.txtCostCode = New System.Windows.Forms.TextBox()
        Me.txtWorkLumpsum = New System.Windows.Forms.TextBox()
        Me.btnMenu = New System.Windows.Forms.Button()
        Me.btnSaveClient = New System.Windows.Forms.Button()
        Me.btnQueryClient = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnQueryClient)
        Me.GroupBox1.Controls.Add(Me.btnSaveClient)
        Me.GroupBox1.Controls.Add(Me.txtWorkLumpsum)
        Me.GroupBox1.Controls.Add(Me.txtCostCode)
        Me.GroupBox1.Controls.Add(Me.txtSubJob)
        Me.GroupBox1.Controls.Add(Me.txtJobNumber)
        Me.GroupBox1.Controls.Add(Me.txtPhoneNumber)
        Me.GroupBox1.Controls.Add(Me.txtContactTitle)
        Me.GroupBox1.Controls.Add(Me.txtContactLastName)
        Me.GroupBox1.Controls.Add(Me.txtContactFistName)
        Me.GroupBox1.Controls.Add(Me.txtPostalCode)
        Me.GroupBox1.Controls.Add(Me.txtStateProvince)
        Me.GroupBox1.Controls.Add(Me.txtCity)
        Me.GroupBox1.Controls.Add(Me.txtAdress)
        Me.GroupBox1.Controls.Add(Me.txtCompanyName)
        Me.GroupBox1.Controls.Add(Me.txtIdClients)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 64)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1259, 423)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "New Client"
        '
        'txtIdClients
        '
        Me.txtIdClients.Location = New System.Drawing.Point(95, 59)
        Me.txtIdClients.Name = "txtIdClients"
        Me.txtIdClients.Size = New System.Drawing.Size(138, 26)
        Me.txtIdClients.TabIndex = 14
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(844, 273)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(157, 20)
        Me.Label14.TabIndex = 13
        Me.Label14.Text = "Work TYM Lumpsum"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(844, 201)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(84, 20)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "Cost Code"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(844, 133)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(68, 20)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "Sub Job"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(844, 65)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(95, 20)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "Job Number"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(438, 347)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(115, 20)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Phone Number"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(438, 273)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(98, 20)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Contact Title"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(438, 201)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(146, 20)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Contact Last Name"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(438, 133)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(146, 20)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Contact First Name"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(438, 65)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(95, 20)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Postal Code"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(27, 347)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 20)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "State/Province"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(27, 273)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 20)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "City"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(27, 201)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Address"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(27, 133)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Company Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Client #"
        '
        'txtCompanyName
        '
        Me.txtCompanyName.Location = New System.Drawing.Point(155, 130)
        Me.txtCompanyName.Name = "txtCompanyName"
        Me.txtCompanyName.Size = New System.Drawing.Size(197, 26)
        Me.txtCompanyName.TabIndex = 15
        '
        'txtAdress
        '
        Me.txtAdress.Location = New System.Drawing.Point(101, 195)
        Me.txtAdress.Name = "txtAdress"
        Me.txtAdress.Size = New System.Drawing.Size(164, 26)
        Me.txtAdress.TabIndex = 16
        '
        'txtCity
        '
        Me.txtCity.Location = New System.Drawing.Point(68, 267)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(165, 26)
        Me.txtCity.TabIndex = 17
        '
        'txtStateProvince
        '
        Me.txtStateProvince.Location = New System.Drawing.Point(145, 341)
        Me.txtStateProvince.Name = "txtStateProvince"
        Me.txtStateProvince.Size = New System.Drawing.Size(161, 26)
        Me.txtStateProvince.TabIndex = 18
        '
        'txtPostalCode
        '
        Me.txtPostalCode.Location = New System.Drawing.Point(539, 62)
        Me.txtPostalCode.Name = "txtPostalCode"
        Me.txtPostalCode.Size = New System.Drawing.Size(182, 26)
        Me.txtPostalCode.TabIndex = 19
        '
        'txtContactFistName
        '
        Me.txtContactFistName.Location = New System.Drawing.Point(590, 127)
        Me.txtContactFistName.Name = "txtContactFistName"
        Me.txtContactFistName.Size = New System.Drawing.Size(180, 26)
        Me.txtContactFistName.TabIndex = 20
        '
        'txtContactLastName
        '
        Me.txtContactLastName.Location = New System.Drawing.Point(590, 198)
        Me.txtContactLastName.Name = "txtContactLastName"
        Me.txtContactLastName.Size = New System.Drawing.Size(180, 26)
        Me.txtContactLastName.TabIndex = 21
        '
        'txtContactTitle
        '
        Me.txtContactTitle.Location = New System.Drawing.Point(542, 267)
        Me.txtContactTitle.Name = "txtContactTitle"
        Me.txtContactTitle.Size = New System.Drawing.Size(214, 26)
        Me.txtContactTitle.TabIndex = 22
        '
        'txtPhoneNumber
        '
        Me.txtPhoneNumber.Location = New System.Drawing.Point(559, 344)
        Me.txtPhoneNumber.Name = "txtPhoneNumber"
        Me.txtPhoneNumber.Size = New System.Drawing.Size(172, 26)
        Me.txtPhoneNumber.TabIndex = 23
        '
        'txtJobNumber
        '
        Me.txtJobNumber.Location = New System.Drawing.Point(945, 62)
        Me.txtJobNumber.Name = "txtJobNumber"
        Me.txtJobNumber.Size = New System.Drawing.Size(209, 26)
        Me.txtJobNumber.TabIndex = 24
        '
        'txtSubJob
        '
        Me.txtSubJob.Location = New System.Drawing.Point(918, 130)
        Me.txtSubJob.Name = "txtSubJob"
        Me.txtSubJob.Size = New System.Drawing.Size(210, 26)
        Me.txtSubJob.TabIndex = 25
        '
        'txtCostCode
        '
        Me.txtCostCode.Location = New System.Drawing.Point(934, 195)
        Me.txtCostCode.Name = "txtCostCode"
        Me.txtCostCode.Size = New System.Drawing.Size(205, 26)
        Me.txtCostCode.TabIndex = 26
        '
        'txtWorkLumpsum
        '
        Me.txtWorkLumpsum.Location = New System.Drawing.Point(1007, 270)
        Me.txtWorkLumpsum.Name = "txtWorkLumpsum"
        Me.txtWorkLumpsum.Size = New System.Drawing.Size(215, 26)
        Me.txtWorkLumpsum.TabIndex = 27
        '
        'btnMenu
        '
        Me.btnMenu.Location = New System.Drawing.Point(12, 12)
        Me.btnMenu.Name = "btnMenu"
        Me.btnMenu.Size = New System.Drawing.Size(113, 36)
        Me.btnMenu.TabIndex = 1
        Me.btnMenu.Text = "Menu"
        Me.btnMenu.UseVisualStyleBackColor = True
        '
        'btnSaveClient
        '
        Me.btnSaveClient.Location = New System.Drawing.Point(848, 324)
        Me.btnSaveClient.Name = "btnSaveClient"
        Me.btnSaveClient.Size = New System.Drawing.Size(102, 32)
        Me.btnSaveClient.TabIndex = 28
        Me.btnSaveClient.Text = "Save"
        Me.btnSaveClient.UseVisualStyleBackColor = True
        '
        'btnQueryClient
        '
        Me.btnQueryClient.Location = New System.Drawing.Point(976, 323)
        Me.btnQueryClient.Name = "btnQueryClient"
        Me.btnQueryClient.Size = New System.Drawing.Size(102, 33)
        Me.btnQueryClient.TabIndex = 29
        Me.btnQueryClient.Text = "Query"
        Me.btnQueryClient.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(6, 493)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 62
        Me.DataGridView1.RowTemplate.Height = 28
        Me.DataGridView1.Size = New System.Drawing.Size(1259, 254)
        Me.DataGridView1.TabIndex = 2
        '
        'Clients
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1277, 759)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnMenu)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Clients"
        Me.Text = "Clients"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtIdClients As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtWorkLumpsum As TextBox
    Friend WithEvents txtCostCode As TextBox
    Friend WithEvents txtSubJob As TextBox
    Friend WithEvents txtJobNumber As TextBox
    Friend WithEvents txtPhoneNumber As TextBox
    Friend WithEvents txtContactTitle As TextBox
    Friend WithEvents txtContactLastName As TextBox
    Friend WithEvents txtContactFistName As TextBox
    Friend WithEvents txtPostalCode As TextBox
    Friend WithEvents txtStateProvince As TextBox
    Friend WithEvents txtCity As TextBox
    Friend WithEvents txtAdress As TextBox
    Friend WithEvents txtCompanyName As TextBox
    Friend WithEvents btnQueryClient As Button
    Friend WithEvents btnSaveClient As Button
    Friend WithEvents btnMenu As Button
    Friend WithEvents DataGridView1 As DataGridView
End Class
