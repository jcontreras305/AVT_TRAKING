<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Clients
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
        Me.txtCompanyName = New System.Windows.Forms.TextBox()
        Me.txtIdClient = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tblClientes = New System.Windows.Forms.DataGridView()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnSelectClient = New System.Windows.Forms.Button()
        Me.btnShowAll1 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.lblN6 = New System.Windows.Forms.Label()
        Me.lblN5 = New System.Windows.Forms.Label()
        Me.chbStatus = New System.Windows.Forms.CheckBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.txtMiddleName = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnSaveClient = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.btnSelectAll = New System.Windows.Forms.Button()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtFiltro2 = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblN4 = New System.Windows.Forms.Label()
        Me.lblN3 = New System.Windows.Forms.Label()
        Me.chbAddress = New System.Windows.Forms.CheckBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtPC = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtNumerStreat = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCity = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtStreat = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtProvince = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblN2 = New System.Windows.Forms.Label()
        Me.lblN1 = New System.Windows.Forms.Label()
        Me.chbContact = New System.Windows.Forms.CheckBox()
        Me.txtPhoneNumber2 = New System.Windows.Forms.TextBox()
        Me.lblPN2 = New System.Windows.Forms.Label()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtPhoneNumber = New System.Windows.Forms.TextBox()
        Me.lblPN1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TitleBar = New System.Windows.Forms.Panel()
        Me.btnMinimized = New System.Windows.Forms.PictureBox()
        Me.btnMaximize = New System.Windows.Forms.PictureBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.tblClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TitleBar.SuspendLayout()
        CType(Me.btnMinimized, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnMaximize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtCompanyName
        '
        Me.txtCompanyName.Location = New System.Drawing.Point(360, 21)
        Me.txtCompanyName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCompanyName.Name = "txtCompanyName"
        Me.txtCompanyName.Size = New System.Drawing.Size(111, 23)
        Me.txtCompanyName.TabIndex = 6
        '
        'txtIdClient
        '
        Me.txtIdClient.Location = New System.Drawing.Point(98, 14)
        Me.txtIdClient.Margin = New System.Windows.Forms.Padding(2)
        Me.txtIdClient.Name = "txtIdClient"
        Me.txtIdClient.Size = New System.Drawing.Size(111, 23)
        Me.txtIdClient.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(233, 21)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(123, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Company Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 18)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Client #"
        '
        'tblClientes
        '
        Me.tblClientes.AllowUserToAddRows = False
        Me.tblClientes.AllowUserToDeleteRows = False
        Me.tblClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblClientes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblClientes.Location = New System.Drawing.Point(0, 0)
        Me.tblClientes.Margin = New System.Windows.Forms.Padding(2)
        Me.tblClientes.Name = "tblClientes"
        Me.tblClientes.ReadOnly = True
        Me.tblClientes.RowHeadersWidth = 62
        Me.tblClientes.RowTemplate.Height = 28
        Me.tblClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tblClientes.Size = New System.Drawing.Size(724, 188)
        Me.tblClientes.TabIndex = 10
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(8, 2)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(717, 253)
        Me.TabControl1.TabIndex = 11
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.btnSelectClient)
        Me.TabPage1.Controls.Add(Me.btnShowAll1)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.txtFiltro)
        Me.TabPage1.Controls.Add(Me.lblN6)
        Me.TabPage1.Controls.Add(Me.lblN5)
        Me.TabPage1.Controls.Add(Me.chbStatus)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.txtLastName)
        Me.TabPage1.Controls.Add(Me.txtMiddleName)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.txtFirstName)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.btnUpdate)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.btnSaveClient)
        Me.TabPage1.Controls.Add(Me.txtIdClient)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.txtCompanyName)
        Me.TabPage1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.TabPage1.Location = New System.Drawing.Point(4, 27)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(2)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(2)
        Me.TabPage1.Size = New System.Drawing.Size(709, 222)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Clients"
        '
        'btnSelectClient
        '
        Me.btnSelectClient.FlatAppearance.BorderSize = 0
        Me.btnSelectClient.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btnSelectClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSelectClient.Image = Global.AVT_TRAKING.My.Resources.Resources.click
        Me.btnSelectClient.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSelectClient.Location = New System.Drawing.Point(573, 5)
        Me.btnSelectClient.Name = "btnSelectClient"
        Me.btnSelectClient.Size = New System.Drawing.Size(131, 29)
        Me.btnSelectClient.TabIndex = 50
        Me.btnSelectClient.Text = "Select Client"
        Me.btnSelectClient.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSelectClient.UseVisualStyleBackColor = True
        '
        'btnShowAll1
        '
        Me.btnShowAll1.FlatAppearance.BorderSize = 0
        Me.btnShowAll1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btnShowAll1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShowAll1.ForeColor = System.Drawing.SystemColors.Control
        Me.btnShowAll1.Image = Global.AVT_TRAKING.My.Resources.Resources.loupe
        Me.btnShowAll1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnShowAll1.Location = New System.Drawing.Point(236, 197)
        Me.btnShowAll1.Name = "btnShowAll1"
        Me.btnShowAll1.Size = New System.Drawing.Size(101, 23)
        Me.btnShowAll1.TabIndex = 11
        Me.btnShowAll1.Text = "Show All"
        Me.btnShowAll1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnShowAll1.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 200)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 16)
        Me.Label6.TabIndex = 49
        Me.Label6.Text = "Search"
        '
        'txtFiltro
        '
        Me.txtFiltro.Location = New System.Drawing.Point(77, 197)
        Me.txtFiltro.Margin = New System.Windows.Forms.Padding(2)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(148, 23)
        Me.txtFiltro.TabIndex = 10
        '
        'lblN6
        '
        Me.lblN6.AutoSize = True
        Me.lblN6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblN6.ForeColor = System.Drawing.Color.Red
        Me.lblN6.Location = New System.Drawing.Point(203, 56)
        Me.lblN6.Name = "lblN6"
        Me.lblN6.Size = New System.Drawing.Size(14, 18)
        Me.lblN6.TabIndex = 47
        Me.lblN6.Text = "*"
        '
        'lblN5
        '
        Me.lblN5.AutoSize = True
        Me.lblN5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblN5.ForeColor = System.Drawing.Color.Red
        Me.lblN5.Location = New System.Drawing.Point(213, 15)
        Me.lblN5.Name = "lblN5"
        Me.lblN5.Size = New System.Drawing.Size(14, 18)
        Me.lblN5.TabIndex = 46
        Me.lblN5.Text = "*"
        '
        'chbStatus
        '
        Me.chbStatus.AutoSize = True
        Me.chbStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.chbStatus.Location = New System.Drawing.Point(330, 56)
        Me.chbStatus.Name = "chbStatus"
        Me.chbStatus.Size = New System.Drawing.Size(76, 20)
        Me.chbStatus.TabIndex = 7
        Me.chbStatus.Text = "Enable"
        Me.chbStatus.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(272, 58)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(55, 16)
        Me.Label11.TabIndex = 40
        Me.Label11.Text = "Status"
        '
        'txtLastName
        '
        Me.txtLastName.Location = New System.Drawing.Point(98, 127)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(100, 23)
        Me.txtLastName.TabIndex = 5
        '
        'txtMiddleName
        '
        Me.txtMiddleName.Location = New System.Drawing.Point(98, 92)
        Me.txtMiddleName.Name = "txtMiddleName"
        Me.txtMiddleName.Size = New System.Drawing.Size(100, 23)
        Me.txtMiddleName.TabIndex = 4
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(14, 127)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(85, 16)
        Me.Label12.TabIndex = 37
        Me.Label12.Text = "Last Name"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(0, 96)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(101, 16)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "Middle Name"
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(98, 53)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(100, 23)
        Me.txtFirstName.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(11, 56)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(87, 16)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "First Name"
        '
        'btnUpdate
        '
        Me.btnUpdate.FlatAppearance.BorderSize = 0
        Me.btnUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdate.Image = Global.AVT_TRAKING.My.Resources.Resources.update
        Me.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnUpdate.Location = New System.Drawing.Point(315, 88)
        Me.btnUpdate.Margin = New System.Windows.Forms.Padding(2)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(91, 29)
        Me.btnUpdate.TabIndex = 9
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnSaveClient
        '
        Me.btnSaveClient.FlatAppearance.BorderSize = 0
        Me.btnSaveClient.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btnSaveClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveClient.Image = Global.AVT_TRAKING.My.Resources.Resources.save
        Me.btnSaveClient.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSaveClient.Location = New System.Drawing.Point(236, 88)
        Me.btnSaveClient.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSaveClient.Name = "btnSaveClient"
        Me.btnSaveClient.Size = New System.Drawing.Size(78, 27)
        Me.btnSaveClient.TabIndex = 8
        Me.btnSaveClient.Text = "Save"
        Me.btnSaveClient.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSaveClient.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.btnSelectAll)
        Me.TabPage2.Controls.Add(Me.Label18)
        Me.TabPage2.Controls.Add(Me.txtFiltro2)
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TabPage2.Location = New System.Drawing.Point(4, 27)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(2)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(2)
        Me.TabPage2.Size = New System.Drawing.Size(709, 222)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Contact Information"
        '
        'btnSelectAll
        '
        Me.btnSelectAll.FlatAppearance.BorderSize = 0
        Me.btnSelectAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSelectAll.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnSelectAll.Image = Global.AVT_TRAKING.My.Resources.Resources.loupe
        Me.btnSelectAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSelectAll.Location = New System.Drawing.Point(266, 196)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(75, 23)
        Me.btnSelectAll.TabIndex = 22
        Me.btnSelectAll.Text = "Show All"
        Me.btnSelectAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSelectAll.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label18.Location = New System.Drawing.Point(24, 199)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(58, 16)
        Me.Label18.TabIndex = 39
        Me.Label18.Text = "Search"
        '
        'txtFiltro2
        '
        Me.txtFiltro2.Location = New System.Drawing.Point(87, 196)
        Me.txtFiltro2.Margin = New System.Windows.Forms.Padding(2)
        Me.txtFiltro2.Name = "txtFiltro2"
        Me.txtFiltro2.Size = New System.Drawing.Size(148, 23)
        Me.txtFiltro2.TabIndex = 21
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.GroupBox2.Controls.Add(Me.lblN4)
        Me.GroupBox2.Controls.Add(Me.lblN3)
        Me.GroupBox2.Controls.Add(Me.chbAddress)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.txtPC)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txtNumerStreat)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtCity)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtStreat)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtProvince)
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox2.Location = New System.Drawing.Point(384, 25)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(320, 196)
        Me.GroupBox2.TabIndex = 37
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Address"
        '
        'lblN4
        '
        Me.lblN4.AutoSize = True
        Me.lblN4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblN4.ForeColor = System.Drawing.Color.Red
        Me.lblN4.Location = New System.Drawing.Point(216, 74)
        Me.lblN4.Name = "lblN4"
        Me.lblN4.Size = New System.Drawing.Size(14, 18)
        Me.lblN4.TabIndex = 47
        Me.lblN4.Text = "*"
        '
        'lblN3
        '
        Me.lblN3.AutoSize = True
        Me.lblN3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblN3.ForeColor = System.Drawing.Color.Red
        Me.lblN3.Location = New System.Drawing.Point(216, 19)
        Me.lblN3.Name = "lblN3"
        Me.lblN3.Size = New System.Drawing.Size(14, 18)
        Me.lblN3.TabIndex = 46
        Me.lblN3.Text = "*"
        '
        'chbAddress
        '
        Me.chbAddress.AutoSize = True
        Me.chbAddress.Location = New System.Drawing.Point(236, 16)
        Me.chbAddress.Name = "chbAddress"
        Me.chbAddress.Size = New System.Drawing.Size(76, 20)
        Me.chbAddress.TabIndex = 15
        Me.chbAddress.Text = "Enable"
        Me.chbAddress.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(-3, 125)
        Me.Label14.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(94, 16)
        Me.Label14.TabIndex = 42
        Me.Label14.Text = "Postal Code"
        '
        'txtPC
        '
        Me.txtPC.Location = New System.Drawing.Point(93, 123)
        Me.txtPC.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPC.Name = "txtPC"
        Me.txtPC.Size = New System.Drawing.Size(118, 23)
        Me.txtPC.TabIndex = 20
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(28, 47)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 16)
        Me.Label9.TabIndex = 40
        Me.Label9.Text = "Number"
        '
        'txtNumerStreat
        '
        Me.txtNumerStreat.Location = New System.Drawing.Point(93, 44)
        Me.txtNumerStreat.Margin = New System.Windows.Forms.Padding(2)
        Me.txtNumerStreat.Name = "txtNumerStreat"
        Me.txtNumerStreat.Size = New System.Drawing.Size(118, 23)
        Me.txtNumerStreat.TabIndex = 17
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(56, 76)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 16)
        Me.Label4.TabIndex = 38
        Me.Label4.Text = "City"
        '
        'txtCity
        '
        Me.txtCity.Location = New System.Drawing.Point(93, 71)
        Me.txtCity.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(118, 23)
        Me.txtCity.TabIndex = 18
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(40, 21)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 16)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "Streat"
        '
        'txtStreat
        '
        Me.txtStreat.Location = New System.Drawing.Point(93, 18)
        Me.txtStreat.Margin = New System.Windows.Forms.Padding(2)
        Me.txtStreat.Name = "txtStreat"
        Me.txtStreat.Size = New System.Drawing.Size(118, 23)
        Me.txtStreat.TabIndex = 16
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(20, 99)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 16)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "Province"
        '
        'txtProvince
        '
        Me.txtProvince.Location = New System.Drawing.Point(93, 97)
        Me.txtProvince.Margin = New System.Windows.Forms.Padding(2)
        Me.txtProvince.Name = "txtProvince"
        Me.txtProvince.Size = New System.Drawing.Size(118, 23)
        Me.txtProvince.TabIndex = 19
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.lblN2)
        Me.GroupBox1.Controls.Add(Me.lblN1)
        Me.GroupBox1.Controls.Add(Me.chbContact)
        Me.GroupBox1.Controls.Add(Me.txtPhoneNumber2)
        Me.GroupBox1.Controls.Add(Me.lblPN2)
        Me.GroupBox1.Controls.Add(Me.lblEmail)
        Me.GroupBox1.Controls.Add(Me.txtEmail)
        Me.GroupBox1.Controls.Add(Me.txtPhoneNumber)
        Me.GroupBox1.Controls.Add(Me.lblPN1)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox1.Location = New System.Drawing.Point(18, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(337, 143)
        Me.GroupBox1.TabIndex = 36
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Contact"
        '
        'lblN2
        '
        Me.lblN2.AutoSize = True
        Me.lblN2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblN2.ForeColor = System.Drawing.Color.Red
        Me.lblN2.Location = New System.Drawing.Point(317, 93)
        Me.lblN2.Name = "lblN2"
        Me.lblN2.Size = New System.Drawing.Size(14, 18)
        Me.lblN2.TabIndex = 46
        Me.lblN2.Text = "*"
        '
        'lblN1
        '
        Me.lblN1.AutoSize = True
        Me.lblN1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblN1.ForeColor = System.Drawing.Color.Red
        Me.lblN1.Location = New System.Drawing.Point(239, 25)
        Me.lblN1.Name = "lblN1"
        Me.lblN1.Size = New System.Drawing.Size(14, 18)
        Me.lblN1.TabIndex = 45
        Me.lblN1.Text = "*"
        '
        'chbContact
        '
        Me.chbContact.AutoSize = True
        Me.chbContact.Location = New System.Drawing.Point(259, 16)
        Me.chbContact.Name = "chbContact"
        Me.chbContact.Size = New System.Drawing.Size(76, 20)
        Me.chbContact.TabIndex = 12
        Me.chbContact.Text = "Enable"
        Me.chbContact.UseVisualStyleBackColor = True
        '
        'txtPhoneNumber2
        '
        Me.txtPhoneNumber2.Location = New System.Drawing.Point(115, 55)
        Me.txtPhoneNumber2.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPhoneNumber2.MaxLength = 10
        Me.txtPhoneNumber2.Name = "txtPhoneNumber2"
        Me.txtPhoneNumber2.Size = New System.Drawing.Size(124, 23)
        Me.txtPhoneNumber2.TabIndex = 13
        '
        'lblPN2
        '
        Me.lblPN2.AutoSize = True
        Me.lblPN2.Location = New System.Drawing.Point(1, 58)
        Me.lblPN2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblPN2.Name = "lblPN2"
        Me.lblPN2.Size = New System.Drawing.Size(127, 16)
        Me.lblPN2.TabIndex = 42
        Me.lblPN2.Text = "Phone Number 2"
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Location = New System.Drawing.Point(64, 91)
        Me.lblEmail.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(48, 16)
        Me.lblEmail.TabIndex = 39
        Me.lblEmail.Text = "Email"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(115, 88)
        Me.txtEmail.Margin = New System.Windows.Forms.Padding(2)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(198, 23)
        Me.txtEmail.TabIndex = 14
        '
        'txtPhoneNumber
        '
        Me.txtPhoneNumber.Location = New System.Drawing.Point(115, 21)
        Me.txtPhoneNumber.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPhoneNumber.MaxLength = 10
        Me.txtPhoneNumber.Name = "txtPhoneNumber"
        Me.txtPhoneNumber.Size = New System.Drawing.Size(124, 23)
        Me.txtPhoneNumber.TabIndex = 12
        '
        'lblPN1
        '
        Me.lblPN1.AutoSize = True
        Me.lblPN1.Location = New System.Drawing.Point(1, 25)
        Me.lblPN1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblPN1.Name = "lblPN1"
        Me.lblPN1.Size = New System.Drawing.Size(118, 16)
        Me.lblPN1.TabIndex = 36
        Me.lblPN1.Text = "Phone Number "
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(733, 516)
        Me.Panel1.TabIndex = 23
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Panel4.Controls.Add(Me.tblClientes)
        Me.Panel4.Location = New System.Drawing.Point(6, 328)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(724, 188)
        Me.Panel4.TabIndex = 25
        '
        'Panel3
        '
        Me.Panel3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.Panel3.Controls.Add(Me.TabControl1)
        Me.Panel3.Location = New System.Drawing.Point(3, 69)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(727, 254)
        Me.Panel3.TabIndex = 24
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TitleBar)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(733, 75)
        Me.Panel2.TabIndex = 23
        '
        'TitleBar
        '
        Me.TitleBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TitleBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.TitleBar.Controls.Add(Me.btnMinimized)
        Me.TitleBar.Controls.Add(Me.btnMaximize)
        Me.TitleBar.Controls.Add(Me.Label10)
        Me.TitleBar.Location = New System.Drawing.Point(0, 0)
        Me.TitleBar.Name = "TitleBar"
        Me.TitleBar.Size = New System.Drawing.Size(733, 28)
        Me.TitleBar.TabIndex = 23
        '
        'btnMinimized
        '
        Me.btnMinimized.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMinimized.Image = Global.AVT_TRAKING.My.Resources.Resources.minimize2
        Me.btnMinimized.Location = New System.Drawing.Point(664, 1)
        Me.btnMinimized.Name = "btnMinimized"
        Me.btnMinimized.Size = New System.Drawing.Size(25, 24)
        Me.btnMinimized.TabIndex = 3
        Me.btnMinimized.TabStop = False
        '
        'btnMaximize
        '
        Me.btnMaximize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMaximize.Image = Global.AVT_TRAKING.My.Resources.Resources.maximize2
        Me.btnMaximize.Location = New System.Drawing.Point(695, 3)
        Me.btnMaximize.Name = "btnMaximize"
        Me.btnMaximize.Size = New System.Drawing.Size(29, 28)
        Me.btnMaximize.TabIndex = 1
        Me.btnMaximize.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label10.Location = New System.Drawing.Point(3, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(66, 18)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Clients"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.Color.Red
        Me.Button1.Image = Global.AVT_TRAKING.My.Resources.Resources._exit
        Me.Button1.Location = New System.Drawing.Point(678, 33)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(50, 31)
        Me.Button1.TabIndex = 22
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Clients
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(733, 516)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Clients"
        Me.Text = "Clients"
        CType(Me.tblClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.TitleBar.ResumeLayout(False)
        Me.TitleBar.PerformLayout()
        CType(Me.btnMinimized, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnMaximize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtIdClient As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtCompanyName As TextBox
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnSaveClient As Button
    Friend WithEvents tblClientes As DataGridView
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Button1 As Button
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents txtMiddleName As TextBox
    Friend WithEvents chbStatus As CheckBox
    Friend WithEvents Label11 As Label
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtCity As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtStreat As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtProvince As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtPhoneNumber2 As TextBox
    Friend WithEvents lblPN2 As Label
    Friend WithEvents lblEmail As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtPhoneNumber As TextBox
    Friend WithEvents lblPN1 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtNumerStreat As TextBox
    Friend WithEvents chbAddress As CheckBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtPC As TextBox
    Friend WithEvents chbContact As CheckBox
    Friend WithEvents txtFiltro2 As TextBox
    Friend WithEvents lblN4 As Label
    Friend WithEvents lblN3 As Label
    Friend WithEvents lblN2 As Label
    Friend WithEvents lblN1 As Label
    Friend WithEvents lblN6 As Label
    Friend WithEvents lblN5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtFiltro As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents btnShowAll1 As Button
    Friend WithEvents btnSelectAll As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel2 As Panel
    Public WithEvents btnSelectClient As Button
    Friend WithEvents TitleBar As Panel
    Friend WithEvents Label10 As Label
    Friend WithEvents btnMaximize As PictureBox
    Friend WithEvents btnMinimized As PictureBox
End Class
