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
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.chbState = New System.Windows.Forms.CheckBox()
        Me.tblEmployees = New System.Windows.Forms.DataGridView()
        Me.Button2 = New System.Windows.Forms.Button()
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
        Me.btnMenu = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.tbpEmployees.SuspendLayout()
        CType(Me.tblEmployees, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpOtherData.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.sprPayRate3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprPayRate2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprPayRate1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tbpEmployees)
        Me.TabControl1.Controls.Add(Me.tbpOtherData)
        Me.TabControl1.Location = New System.Drawing.Point(4, 45)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1192, 580)
        Me.TabControl1.TabIndex = 0
        '
        'tbpEmployees
        '
        Me.tbpEmployees.Controls.Add(Me.txtSearch)
        Me.tbpEmployees.Controls.Add(Me.chbState)
        Me.tbpEmployees.Controls.Add(Me.tblEmployees)
        Me.tbpEmployees.Controls.Add(Me.Button2)
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
        Me.tbpEmployees.Location = New System.Drawing.Point(4, 29)
        Me.tbpEmployees.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tbpEmployees.Name = "tbpEmployees"
        Me.tbpEmployees.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tbpEmployees.Size = New System.Drawing.Size(1184, 547)
        Me.tbpEmployees.TabIndex = 0
        Me.tbpEmployees.Text = "Employee"
        Me.tbpEmployees.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(261, 225)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(322, 26)
        Me.txtSearch.TabIndex = 18
        '
        'chbState
        '
        Me.chbState.AutoSize = True
        Me.chbState.Location = New System.Drawing.Point(522, 120)
        Me.chbState.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chbState.Name = "chbState"
        Me.chbState.Size = New System.Drawing.Size(74, 24)
        Me.chbState.TabIndex = 17
        Me.chbState.Text = "State"
        Me.chbState.UseVisualStyleBackColor = True
        '
        'tblEmployees
        '
        Me.tblEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblEmployees.Location = New System.Drawing.Point(9, 283)
        Me.tblEmployees.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tblEmployees.Name = "tblEmployees"
        Me.tblEmployees.RowHeadersWidth = 62
        Me.tblEmployees.Size = New System.Drawing.Size(1162, 231)
        Me.tblEmployees.TabIndex = 16
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(594, 222)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(112, 35)
        Me.Button2.TabIndex = 15
        Me.Button2.Text = "Search"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(412, 165)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(112, 35)
        Me.btnSave.TabIndex = 14
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnChooseImage
        '
        Me.btnChooseImage.Location = New System.Drawing.Point(825, 222)
        Me.btnChooseImage.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnChooseImage.Name = "btnChooseImage"
        Me.btnChooseImage.Size = New System.Drawing.Size(132, 35)
        Me.btnChooseImage.TabIndex = 13
        Me.btnChooseImage.Text = "Chose Image"
        Me.btnChooseImage.UseVisualStyleBackColor = True
        '
        'imgPhoto
        '
        Me.imgPhoto.BackColor = System.Drawing.Color.Gray
        Me.imgPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imgPhoto.Location = New System.Drawing.Point(795, 9)
        Me.imgPhoto.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.imgPhoto.Name = "imgPhoto"
        Me.imgPhoto.Size = New System.Drawing.Size(179, 202)
        Me.imgPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgPhoto.TabIndex = 12
        Me.imgPhoto.TabStop = False
        '
        'txtSapNumber
        '
        Me.txtSapNumber.Location = New System.Drawing.Point(522, 75)
        Me.txtSapNumber.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtSapNumber.Name = "txtSapNumber"
        Me.txtSapNumber.Size = New System.Drawing.Size(182, 26)
        Me.txtSapNumber.TabIndex = 11
        '
        'txtSocialNumber
        '
        Me.txtSocialNumber.Location = New System.Drawing.Point(522, 29)
        Me.txtSocialNumber.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtSocialNumber.Name = "txtSocialNumber"
        Me.txtSocialNumber.Size = New System.Drawing.Size(182, 26)
        Me.txtSocialNumber.TabIndex = 10
        '
        'txtMiddleName
        '
        Me.txtMiddleName.Location = New System.Drawing.Point(182, 169)
        Me.txtMiddleName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtMiddleName.Name = "txtMiddleName"
        Me.txtMiddleName.Size = New System.Drawing.Size(182, 26)
        Me.txtMiddleName.TabIndex = 9
        '
        'txtLastName
        '
        Me.txtLastName.Location = New System.Drawing.Point(182, 123)
        Me.txtLastName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(182, 26)
        Me.txtLastName.TabIndex = 8
        '
        'txtFirsName
        '
        Me.txtFirsName.Location = New System.Drawing.Point(182, 75)
        Me.txtFirsName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtFirsName.Name = "txtFirsName"
        Me.txtFirsName.Size = New System.Drawing.Size(182, 26)
        Me.txtFirsName.TabIndex = 7
        '
        'txtEmployeeNumber
        '
        Me.txtEmployeeNumber.Location = New System.Drawing.Point(182, 34)
        Me.txtEmployeeNumber.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtEmployeeNumber.Name = "txtEmployeeNumber"
        Me.txtEmployeeNumber.Size = New System.Drawing.Size(182, 26)
        Me.txtEmployeeNumber.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(408, 80)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(101, 20)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "SAP Number"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(408, 34)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 20)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Social Number"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(40, 169)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 20)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Middle Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(40, 128)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Last Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(40, 80)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "First Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(40, 34)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Employe Number"
        '
        'tbpOtherData
        '
        Me.tbpOtherData.Controls.Add(Me.GroupBox3)
        Me.tbpOtherData.Controls.Add(Me.GroupBox2)
        Me.tbpOtherData.Controls.Add(Me.GroupBox1)
        Me.tbpOtherData.Location = New System.Drawing.Point(4, 29)
        Me.tbpOtherData.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tbpOtherData.Name = "tbpOtherData"
        Me.tbpOtherData.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tbpOtherData.Size = New System.Drawing.Size(1184, 532)
        Me.tbpOtherData.TabIndex = 1
        Me.tbpOtherData.Text = "Other Data"
        Me.tbpOtherData.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.sprPayRate3)
        Me.GroupBox3.Controls.Add(Me.sprPayRate2)
        Me.GroupBox3.Controls.Add(Me.sprPayRate1)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.chbPay)
        Me.GroupBox3.Location = New System.Drawing.Point(562, 262)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox3.Size = New System.Drawing.Size(526, 231)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Pay"
        '
        'sprPayRate3
        '
        Me.sprPayRate3.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.sprPayRate3.Location = New System.Drawing.Point(172, 151)
        Me.sprPayRate3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.sprPayRate3.Name = "sprPayRate3"
        Me.sprPayRate3.Size = New System.Drawing.Size(180, 26)
        Me.sprPayRate3.TabIndex = 23
        '
        'sprPayRate2
        '
        Me.sprPayRate2.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.sprPayRate2.Location = New System.Drawing.Point(172, 89)
        Me.sprPayRate2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.sprPayRate2.Name = "sprPayRate2"
        Me.sprPayRate2.Size = New System.Drawing.Size(180, 26)
        Me.sprPayRate2.TabIndex = 22
        '
        'sprPayRate1
        '
        Me.sprPayRate1.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.sprPayRate1.Location = New System.Drawing.Point(172, 34)
        Me.sprPayRate1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.sprPayRate1.Name = "sprPayRate1"
        Me.sprPayRate1.Size = New System.Drawing.Size(180, 26)
        Me.sprPayRate1.TabIndex = 21
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(74, 154)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(87, 20)
        Me.Label15.TabIndex = 20
        Me.Label15.Text = "Pay Rate 3"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(74, 92)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(87, 20)
        Me.Label16.TabIndex = 19
        Me.Label16.Text = "Pay Rate 2"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(74, 37)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(87, 20)
        Me.Label17.TabIndex = 18
        Me.Label17.Text = "Pay Rate 1"
        '
        'chbPay
        '
        Me.chbPay.AutoSize = True
        Me.chbPay.Location = New System.Drawing.Point(393, 29)
        Me.chbPay.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chbPay.Name = "chbPay"
        Me.chbPay.Size = New System.Drawing.Size(85, 24)
        Me.chbPay.TabIndex = 11
        Me.chbPay.Text = "Enable"
        Me.chbPay.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtEmail)
        Me.GroupBox2.Controls.Add(Me.txtPhone2)
        Me.GroupBox2.Controls.Add(Me.txtPhone1)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.chbContact)
        Me.GroupBox2.Location = New System.Drawing.Point(27, 262)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Size = New System.Drawing.Size(526, 231)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Contact"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(160, 148)
        Me.txtEmail.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(202, 26)
        Me.txtEmail.TabIndex = 17
        '
        'txtPhone2
        '
        Me.txtPhone2.Location = New System.Drawing.Point(160, 82)
        Me.txtPhone2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtPhone2.Name = "txtPhone2"
        Me.txtPhone2.Size = New System.Drawing.Size(202, 26)
        Me.txtPhone2.TabIndex = 16
        '
        'txtPhone1
        '
        Me.txtPhone1.Location = New System.Drawing.Point(160, 26)
        Me.txtPhone1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtPhone1.Name = "txtPhone1"
        Me.txtPhone1.Size = New System.Drawing.Size(202, 26)
        Me.txtPhone1.TabIndex = 15
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(81, 148)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(48, 20)
        Me.Label14.TabIndex = 14
        Me.Label14.Text = "Email"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(81, 86)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(68, 20)
        Me.Label13.TabIndex = 13
        Me.Label13.Text = "Phone 2"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(81, 31)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(68, 20)
        Me.Label12.TabIndex = 12
        Me.Label12.Text = "Phone 1"
        '
        'chbContact
        '
        Me.chbContact.AutoSize = True
        Me.chbContact.Location = New System.Drawing.Point(402, 29)
        Me.chbContact.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chbContact.Name = "chbContact"
        Me.chbContact.Size = New System.Drawing.Size(85, 24)
        Me.chbContact.TabIndex = 11
        Me.chbContact.Text = "Enable"
        Me.chbContact.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
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
        Me.GroupBox1.Location = New System.Drawing.Point(27, 29)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(1062, 223)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Address"
        '
        'chbAddress
        '
        Me.chbAddress.AutoSize = True
        Me.chbAddress.Location = New System.Drawing.Point(884, 25)
        Me.chbAddress.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chbAddress.Name = "chbAddress"
        Me.chbAddress.Size = New System.Drawing.Size(85, 24)
        Me.chbAddress.TabIndex = 10
        Me.chbAddress.Text = "Enable"
        Me.chbAddress.UseVisualStyleBackColor = True
        '
        'txtPostalCode
        '
        Me.txtPostalCode.Location = New System.Drawing.Point(574, 78)
        Me.txtPostalCode.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtPostalCode.Name = "txtPostalCode"
        Me.txtPostalCode.Size = New System.Drawing.Size(169, 26)
        Me.txtPostalCode.TabIndex = 9
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(474, 85)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(95, 20)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "Postal Code"
        '
        'txtProvidence
        '
        Me.txtProvidence.Location = New System.Drawing.Point(574, 22)
        Me.txtProvidence.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtProvidence.Name = "txtProvidence"
        Me.txtProvidence.Size = New System.Drawing.Size(169, 26)
        Me.txtProvidence.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(474, 26)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(87, 20)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "Providence"
        '
        'txtCity
        '
        Me.txtCity.Location = New System.Drawing.Point(130, 138)
        Me.txtCity.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(169, 26)
        Me.txtCity.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(76, 143)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(35, 20)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "City"
        '
        'txtNumber
        '
        Me.txtNumber.Location = New System.Drawing.Point(130, 83)
        Me.txtNumber.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtNumber.Name = "txtNumber"
        Me.txtNumber.Size = New System.Drawing.Size(169, 26)
        Me.txtNumber.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(63, 88)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 20)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Number"
        '
        'txtStreat
        '
        Me.txtStreat.Location = New System.Drawing.Point(130, 34)
        Me.txtStreat.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtStreat.Name = "txtStreat"
        Me.txtStreat.Size = New System.Drawing.Size(169, 26)
        Me.txtStreat.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(70, 38)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 20)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Streat"
        '
        'btnMenu
        '
        Me.btnMenu.Location = New System.Drawing.Point(968, 24)
        Me.btnMenu.Name = "btnMenu"
        Me.btnMenu.Size = New System.Drawing.Size(106, 32)
        Me.btnMenu.TabIndex = 1
        Me.btnMenu.Text = "Menu"
        Me.btnMenu.UseVisualStyleBackColor = True
        '
        'Employees
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1200, 639)
        Me.Controls.Add(Me.btnMenu)
        Me.Controls.Add(Me.TabControl1)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "Employees"
        Me.Text = "Employees"
        Me.TabControl1.ResumeLayout(False)
        Me.tbpEmployees.ResumeLayout(False)
        Me.tbpEmployees.PerformLayout()
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
    Friend WithEvents Button2 As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents chbState As CheckBox
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnMenu As Button
End Class
