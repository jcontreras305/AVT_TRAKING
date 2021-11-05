<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Employees
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tbpEmployees = New System.Windows.Forms.TabPage()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.cmbTypeEmployee = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.chbState = New System.Windows.Forms.CheckBox()
        Me.tblEmployees = New System.Windows.Forms.DataGridView()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnChooseImage = New System.Windows.Forms.Button()
        Me.imgPhoto = New System.Windows.Forms.PictureBox()
        Me.txtSapNumber = New System.Windows.Forms.TextBox()
        Me.txtSocialNumber = New System.Windows.Forms.TextBox()
        Me.txtMiddleName = New System.Windows.Forms.TextBox()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.txtFirsName = New System.Windows.Forms.TextBox()
        Me.txtEmployeeNumber = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbpOtherData = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.sprPayRate3 = New System.Windows.Forms.NumericUpDown()
        Me.sprPayRate2 = New System.Windows.Forms.NumericUpDown()
        Me.sprPayRate1 = New System.Windows.Forms.NumericUpDown()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.chbPay = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtPhone2 = New System.Windows.Forms.TextBox()
        Me.txtPhone1 = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.chbContact = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chbAddress = New System.Windows.Forms.CheckBox()
        Me.txtPostalCode = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtProvidence = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtCity = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtNumber = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtStreat = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TitleBar = New System.Windows.Forms.Panel()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.btnMaximize = New System.Windows.Forms.PictureBox()
        Me.btnMinimized = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.tbpEmployees.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblEmployees, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpOtherData.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.sprPayRate3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprPayRate2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprPayRate1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TitleBar.SuspendLayout()
        CType(Me.btnMaximize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnMinimized, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tbpEmployees)
        Me.TabControl1.Controls.Add(Me.tbpOtherData)
        Me.TabControl1.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(7, 82)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(723, 354)
        Me.TabControl1.TabIndex = 0
        '
        'tbpEmployees
        '
        Me.tbpEmployees.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.tbpEmployees.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tbpEmployees.Controls.Add(Me.PictureBox1)
        Me.tbpEmployees.Controls.Add(Me.cmbTypeEmployee)
        Me.tbpEmployees.Controls.Add(Me.Label19)
        Me.tbpEmployees.Controls.Add(Me.btnCancel)
        Me.tbpEmployees.Controls.Add(Me.btnUpdate)
        Me.tbpEmployees.Controls.Add(Me.Label18)
        Me.tbpEmployees.Controls.Add(Me.txtSearch)
        Me.tbpEmployees.Controls.Add(Me.chbState)
        Me.tbpEmployees.Controls.Add(Me.tblEmployees)
        Me.tbpEmployees.Controls.Add(Me.btnSave)
        Me.tbpEmployees.Controls.Add(Me.btnChooseImage)
        Me.tbpEmployees.Controls.Add(Me.imgPhoto)
        Me.tbpEmployees.Controls.Add(Me.txtSapNumber)
        Me.tbpEmployees.Controls.Add(Me.txtSocialNumber)
        Me.tbpEmployees.Controls.Add(Me.txtMiddleName)
        Me.tbpEmployees.Controls.Add(Me.txtLastName)
        Me.tbpEmployees.Controls.Add(Me.txtFirsName)
        Me.tbpEmployees.Controls.Add(Me.txtEmployeeNumber)
        Me.tbpEmployees.Controls.Add(Me.Label6)
        Me.tbpEmployees.Controls.Add(Me.Label5)
        Me.tbpEmployees.Controls.Add(Me.Label4)
        Me.tbpEmployees.Controls.Add(Me.Label3)
        Me.tbpEmployees.Controls.Add(Me.Label2)
        Me.tbpEmployees.Controls.Add(Me.Label1)
        Me.tbpEmployees.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbpEmployees.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbpEmployees.Location = New System.Drawing.Point(4, 27)
        Me.tbpEmployees.Name = "tbpEmployees"
        Me.tbpEmployees.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpEmployees.Size = New System.Drawing.Size(715, 323)
        Me.tbpEmployees.TabIndex = 0
        Me.tbpEmployees.Text = "Employee"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.AVT_TRAKING.My.Resources.Resources.loupe
        Me.PictureBox1.Location = New System.Drawing.Point(79, 147)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(25, 24)
        Me.PictureBox1.TabIndex = 24
        Me.PictureBox1.TabStop = False
        '
        'cmbTypeEmployee
        '
        Me.cmbTypeEmployee.FormattingEnabled = True
        Me.cmbTypeEmployee.Location = New System.Drawing.Point(385, 80)
        Me.cmbTypeEmployee.Name = "cmbTypeEmployee"
        Me.cmbTypeEmployee.Size = New System.Drawing.Size(121, 24)
        Me.cmbTypeEmployee.TabIndex = 23
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(336, 85)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(43, 16)
        Me.Label19.TabIndex = 22
        Me.Label19.Text = "Type"
        '
        'btnCancel
        '
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = Global.AVT_TRAKING.My.Resources.Resources.cancel
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(455, 144)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(89, 34)
        Me.btnCancel.TabIndex = 21
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.FlatAppearance.BorderSize = 0
        Me.btnUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdate.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.Image = Global.AVT_TRAKING.My.Resources.Resources.update
        Me.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnUpdate.Location = New System.Drawing.Point(445, 115)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(99, 23)
        Me.btnUpdate.TabIndex = 20
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(15, 150)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(58, 16)
        Me.Label18.TabIndex = 19
        Me.Label18.Text = "Search"
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(110, 148)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(216, 23)
        Me.txtSearch.TabIndex = 18
        '
        'chbState
        '
        Me.chbState.AutoSize = True
        Me.chbState.Location = New System.Drawing.Point(275, 110)
        Me.chbState.Name = "chbState"
        Me.chbState.Size = New System.Drawing.Size(66, 20)
        Me.chbState.TabIndex = 17
        Me.chbState.Text = "State"
        Me.chbState.UseVisualStyleBackColor = True
        '
        'tblEmployees
        '
        Me.tblEmployees.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tblEmployees.BackgroundColor = System.Drawing.SystemColors.ControlLight
        Me.tblEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblEmployees.Location = New System.Drawing.Point(6, 184)
        Me.tblEmployees.Name = "tblEmployees"
        Me.tblEmployees.RowHeadersWidth = 62
        Me.tblEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tblEmployees.Size = New System.Drawing.Size(699, 127)
        Me.tblEmployees.TabIndex = 16
        '
        'btnSave
        '
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Image = Global.AVT_TRAKING.My.Resources.Resources.save
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(364, 110)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 28)
        Me.btnSave.TabIndex = 14
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnChooseImage
        '
        Me.btnChooseImage.BackColor = System.Drawing.Color.RoyalBlue
        Me.btnChooseImage.FlatAppearance.BorderSize = 0
        Me.btnChooseImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnChooseImage.Font = New System.Drawing.Font("Broadway", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChooseImage.Location = New System.Drawing.Point(554, 144)
        Me.btnChooseImage.Name = "btnChooseImage"
        Me.btnChooseImage.Size = New System.Drawing.Size(111, 23)
        Me.btnChooseImage.TabIndex = 13
        Me.btnChooseImage.Text = "Chose Image"
        Me.btnChooseImage.UseVisualStyleBackColor = False
        '
        'imgPhoto
        '
        Me.imgPhoto.BackColor = System.Drawing.Color.White
        Me.imgPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imgPhoto.Location = New System.Drawing.Point(550, 6)
        Me.imgPhoto.Name = "imgPhoto"
        Me.imgPhoto.Size = New System.Drawing.Size(120, 132)
        Me.imgPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgPhoto.TabIndex = 12
        Me.imgPhoto.TabStop = False
        '
        'txtSapNumber
        '
        Me.txtSapNumber.Location = New System.Drawing.Point(385, 49)
        Me.txtSapNumber.Name = "txtSapNumber"
        Me.txtSapNumber.Size = New System.Drawing.Size(123, 23)
        Me.txtSapNumber.TabIndex = 11
        '
        'txtSocialNumber
        '
        Me.txtSocialNumber.Location = New System.Drawing.Point(385, 21)
        Me.txtSocialNumber.MaxLength = 14
        Me.txtSocialNumber.Name = "txtSocialNumber"
        Me.txtSocialNumber.Size = New System.Drawing.Size(123, 23)
        Me.txtSocialNumber.TabIndex = 10
        '
        'txtMiddleName
        '
        Me.txtMiddleName.Location = New System.Drawing.Point(131, 110)
        Me.txtMiddleName.Name = "txtMiddleName"
        Me.txtMiddleName.Size = New System.Drawing.Size(123, 23)
        Me.txtMiddleName.TabIndex = 9
        '
        'txtLastName
        '
        Me.txtLastName.Location = New System.Drawing.Point(131, 80)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(123, 23)
        Me.txtLastName.TabIndex = 8
        '
        'txtFirsName
        '
        Me.txtFirsName.Location = New System.Drawing.Point(131, 49)
        Me.txtFirsName.Name = "txtFirsName"
        Me.txtFirsName.Size = New System.Drawing.Size(123, 23)
        Me.txtFirsName.TabIndex = 7
        '
        'txtEmployeeNumber
        '
        Me.txtEmployeeNumber.Location = New System.Drawing.Point(131, 21)
        Me.txtEmployeeNumber.Name = "txtEmployeeNumber"
        Me.txtEmployeeNumber.Size = New System.Drawing.Size(123, 23)
        Me.txtEmployeeNumber.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(285, 52)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(97, 16)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "SAP Number"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(272, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Social Number"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(26, 110)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Middle Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(44, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Last Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(43, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "First Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(0, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(132, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Employe Number"
        '
        'tbpOtherData
        '
        Me.tbpOtherData.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.tbpOtherData.Controls.Add(Me.GroupBox3)
        Me.tbpOtherData.Controls.Add(Me.GroupBox2)
        Me.tbpOtherData.Controls.Add(Me.GroupBox1)
        Me.tbpOtherData.Location = New System.Drawing.Point(4, 27)
        Me.tbpOtherData.Name = "tbpOtherData"
        Me.tbpOtherData.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpOtherData.Size = New System.Drawing.Size(737, 315)
        Me.tbpOtherData.TabIndex = 1
        Me.tbpOtherData.Text = "Other Data"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.GroupBox3.Controls.Add(Me.sprPayRate3)
        Me.GroupBox3.Controls.Add(Me.sprPayRate2)
        Me.GroupBox3.Controls.Add(Me.sprPayRate1)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.chbPay)
        Me.GroupBox3.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox3.Location = New System.Drawing.Point(385, 178)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(334, 126)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Pay"
        '
        'sprPayRate3
        '
        Me.sprPayRate3.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.sprPayRate3.Location = New System.Drawing.Point(115, 98)
        Me.sprPayRate3.Name = "sprPayRate3"
        Me.sprPayRate3.Size = New System.Drawing.Size(120, 26)
        Me.sprPayRate3.TabIndex = 23
        '
        'sprPayRate2
        '
        Me.sprPayRate2.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.sprPayRate2.Location = New System.Drawing.Point(115, 58)
        Me.sprPayRate2.Name = "sprPayRate2"
        Me.sprPayRate2.Size = New System.Drawing.Size(120, 26)
        Me.sprPayRate2.TabIndex = 22
        '
        'sprPayRate1
        '
        Me.sprPayRate1.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.sprPayRate1.Location = New System.Drawing.Point(115, 22)
        Me.sprPayRate1.Name = "sprPayRate1"
        Me.sprPayRate1.Size = New System.Drawing.Size(120, 26)
        Me.sprPayRate1.TabIndex = 21
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(34, 100)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(99, 18)
        Me.Label15.TabIndex = 20
        Me.Label15.Text = "Pay Rate 3"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(34, 60)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(99, 18)
        Me.Label16.TabIndex = 19
        Me.Label16.Text = "Pay Rate 2"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(34, 24)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(99, 18)
        Me.Label17.TabIndex = 18
        Me.Label17.Text = "Pay Rate 1"
        '
        'chbPay
        '
        Me.chbPay.AutoSize = True
        Me.chbPay.Location = New System.Drawing.Point(253, 19)
        Me.chbPay.Name = "chbPay"
        Me.chbPay.Size = New System.Drawing.Size(81, 22)
        Me.chbPay.TabIndex = 11
        Me.chbPay.Text = "Enable"
        Me.chbPay.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.GroupBox2.Controls.Add(Me.txtEmail)
        Me.GroupBox2.Controls.Add(Me.txtPhone2)
        Me.GroupBox2.Controls.Add(Me.txtPhone1)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.chbContact)
        Me.GroupBox2.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox2.Location = New System.Drawing.Point(26, 178)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(351, 126)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Contact"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(107, 96)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(136, 26)
        Me.txtEmail.TabIndex = 17
        '
        'txtPhone2
        '
        Me.txtPhone2.Location = New System.Drawing.Point(107, 53)
        Me.txtPhone2.Name = "txtPhone2"
        Me.txtPhone2.Size = New System.Drawing.Size(136, 26)
        Me.txtPhone2.TabIndex = 16
        '
        'txtPhone1
        '
        Me.txtPhone1.Location = New System.Drawing.Point(107, 17)
        Me.txtPhone1.Name = "txtPhone1"
        Me.txtPhone1.Size = New System.Drawing.Size(136, 26)
        Me.txtPhone1.TabIndex = 15
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(57, 100)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(52, 18)
        Me.Label14.TabIndex = 14
        Me.Label14.Text = "Email"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(50, 56)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(75, 18)
        Me.Label13.TabIndex = 13
        Me.Label13.Text = "Phone 2"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(50, 20)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(75, 18)
        Me.Label12.TabIndex = 12
        Me.Label12.Text = "Phone 1"
        '
        'chbContact
        '
        Me.chbContact.AutoSize = True
        Me.chbContact.Location = New System.Drawing.Point(268, 19)
        Me.chbContact.Name = "chbContact"
        Me.chbContact.Size = New System.Drawing.Size(81, 22)
        Me.chbContact.TabIndex = 11
        Me.chbContact.Text = "Enable"
        Me.chbContact.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.chbAddress)
        Me.GroupBox1.Controls.Add(Me.txtPostalCode)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtProvidence)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtCity)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtNumber)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtStreat)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox1.Location = New System.Drawing.Point(26, 20)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(693, 152)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Address"
        '
        'chbAddress
        '
        Me.chbAddress.AutoSize = True
        Me.chbAddress.Location = New System.Drawing.Point(589, 16)
        Me.chbAddress.Name = "chbAddress"
        Me.chbAddress.Size = New System.Drawing.Size(81, 22)
        Me.chbAddress.TabIndex = 10
        Me.chbAddress.Text = "Enable"
        Me.chbAddress.UseVisualStyleBackColor = True
        '
        'txtPostalCode
        '
        Me.txtPostalCode.Location = New System.Drawing.Point(388, 52)
        Me.txtPostalCode.Name = "txtPostalCode"
        Me.txtPostalCode.Size = New System.Drawing.Size(137, 26)
        Me.txtPostalCode.TabIndex = 9
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(285, 55)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(105, 18)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "Postal Code"
        '
        'txtProvidence
        '
        Me.txtProvidence.Location = New System.Drawing.Point(388, 14)
        Me.txtProvidence.Name = "txtProvidence"
        Me.txtProvidence.Size = New System.Drawing.Size(137, 26)
        Me.txtProvidence.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(292, 17)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(98, 18)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "Providence"
        '
        'txtCity
        '
        Me.txtCity.Location = New System.Drawing.Point(90, 90)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(156, 26)
        Me.txtCity.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(51, 93)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 18)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "City"
        '
        'txtNumber
        '
        Me.txtNumber.Location = New System.Drawing.Point(90, 54)
        Me.txtNumber.Name = "txtNumber"
        Me.txtNumber.Size = New System.Drawing.Size(156, 26)
        Me.txtNumber.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(19, 59)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(73, 18)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Number"
        '
        'txtStreat
        '
        Me.txtStreat.Location = New System.Drawing.Point(90, 22)
        Me.txtStreat.Name = "txtStreat"
        Me.txtStreat.Size = New System.Drawing.Size(156, 26)
        Me.txtStreat.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(32, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 18)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Streat"
        '
        'TitleBar
        '
        Me.TitleBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.TitleBar.Controls.Add(Me.Label20)
        Me.TitleBar.Controls.Add(Me.btnMaximize)
        Me.TitleBar.Controls.Add(Me.btnMinimized)
        Me.TitleBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.TitleBar.Location = New System.Drawing.Point(0, 0)
        Me.TitleBar.Name = "TitleBar"
        Me.TitleBar.Size = New System.Drawing.Size(739, 30)
        Me.TitleBar.TabIndex = 23
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label20.Location = New System.Drawing.Point(4, 4)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(102, 18)
        Me.Label20.TabIndex = 7
        Me.Label20.Text = "Employees"
        '
        'btnMaximize
        '
        Me.btnMaximize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMaximize.Image = Global.AVT_TRAKING.My.Resources.Resources.maximize2
        Me.btnMaximize.Location = New System.Drawing.Point(704, 4)
        Me.btnMaximize.Name = "btnMaximize"
        Me.btnMaximize.Size = New System.Drawing.Size(26, 26)
        Me.btnMaximize.TabIndex = 5
        Me.btnMaximize.TabStop = False
        '
        'btnMinimized
        '
        Me.btnMinimized.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMinimized.Image = Global.AVT_TRAKING.My.Resources.Resources.minimize2
        Me.btnMinimized.Location = New System.Drawing.Point(672, 3)
        Me.btnMinimized.Name = "btnMinimized"
        Me.btnMinimized.Size = New System.Drawing.Size(27, 27)
        Me.btnMinimized.TabIndex = 2
        Me.btnMinimized.TabStop = False
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Image = Global.AVT_TRAKING.My.Resources.Resources._exit
        Me.Button1.Location = New System.Drawing.Point(693, 35)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(37, 42)
        Me.Button1.TabIndex = 22
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Employees
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(739, 430)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.TitleBar)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Employees"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Employees"
        Me.TabControl1.ResumeLayout(False)
        Me.tbpEmployees.ResumeLayout(False)
        Me.tbpEmployees.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tblEmployees, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpOtherData.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.sprPayRate3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprPayRate2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprPayRate1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TitleBar.ResumeLayout(False)
        Me.TitleBar.PerformLayout()
        CType(Me.btnMaximize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnMinimized, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents tbpEmployees As TabPage
    Friend WithEvents tbpOtherData As TabPage
    Friend WithEvents btnChooseImage As Button
    Friend WithEvents imgPhoto As PictureBox
    Friend WithEvents txtSapNumber As TextBox
    Friend WithEvents txtSocialNumber As TextBox
    Friend WithEvents txtMiddleName As TextBox
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents txtFirsName As TextBox
    Friend WithEvents txtEmployeeNumber As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents sprPayRate3 As NumericUpDown
    Friend WithEvents sprPayRate2 As NumericUpDown
    Friend WithEvents sprPayRate1 As NumericUpDown
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents chbPay As CheckBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtPhone2 As TextBox
    Friend WithEvents txtPhone1 As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents chbContact As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents chbAddress As CheckBox
    Friend WithEvents txtPostalCode As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtProvidence As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtCity As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtNumber As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtStreat As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents tblEmployees As DataGridView
    Friend WithEvents btnSave As Button
    Friend WithEvents chbState As CheckBox
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents cmbTypeEmployee As ComboBox
    Friend WithEvents Label19 As Label
    Friend WithEvents TitleBar As Panel
    Friend WithEvents btnMinimized As PictureBox
    Friend WithEvents btnMaximize As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label20 As Label
End Class
