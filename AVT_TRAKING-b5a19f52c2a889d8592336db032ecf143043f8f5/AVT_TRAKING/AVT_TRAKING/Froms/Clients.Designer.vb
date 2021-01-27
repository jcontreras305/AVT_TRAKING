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
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnSaveClient = New System.Windows.Forms.Button()
        Me.txtCompanyName = New System.Windows.Forms.TextBox()
        Me.txtIdClient = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tblClientes = New System.Windows.Forms.DataGridView()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        CType(Me.tblClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(349, 88)
        Me.btnUpdate.Margin = New System.Windows.Forms.Padding(2)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(68, 21)
        Me.btnUpdate.TabIndex = 9
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnSaveClient
        '
        Me.btnSaveClient.Location = New System.Drawing.Point(236, 88)
        Me.btnSaveClient.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSaveClient.Name = "btnSaveClient"
        Me.btnSaveClient.Size = New System.Drawing.Size(68, 21)
        Me.btnSaveClient.TabIndex = 8
        Me.btnSaveClient.Text = "Save"
        Me.btnSaveClient.UseVisualStyleBackColor = True
        '
        'txtCompanyName
        '
        Me.txtCompanyName.Location = New System.Drawing.Point(330, 13)
        Me.txtCompanyName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCompanyName.Name = "txtCompanyName"
        Me.txtCompanyName.Size = New System.Drawing.Size(111, 20)
        Me.txtCompanyName.TabIndex = 6
        '
        'txtIdClient
        '
        Me.txtIdClient.Location = New System.Drawing.Point(97, 14)
        Me.txtIdClient.Margin = New System.Windows.Forms.Padding(2)
        Me.txtIdClient.Name = "txtIdClient"
        Me.txtIdClient.Size = New System.Drawing.Size(111, 20)
        Me.txtIdClient.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(233, 21)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Company Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 18)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
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
        Me.TabControl1.Location = New System.Drawing.Point(2, 2)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(717, 269)
        Me.TabControl1.TabIndex = 11
        '
        'TabPage1
        '
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
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(2)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(2)
        Me.TabPage1.Size = New System.Drawing.Size(709, 243)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Clients"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'btnShowAll1
        '
        Me.btnShowAll1.Location = New System.Drawing.Point(255, 193)
        Me.btnShowAll1.Name = "btnShowAll1"
        Me.btnShowAll1.Size = New System.Drawing.Size(75, 23)
        Me.btnShowAll1.TabIndex = 11
        Me.btnShowAll1.Text = "Show All"
        Me.btnShowAll1.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(36, 199)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 13)
        Me.Label6.TabIndex = 49
        Me.Label6.Text = "Search"
        '
        'txtFiltro
        '
        Me.txtFiltro.Location = New System.Drawing.Point(82, 196)
        Me.txtFiltro.Margin = New System.Windows.Forms.Padding(2)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(148, 20)
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
        Me.chbStatus.Size = New System.Drawing.Size(59, 17)
        Me.chbStatus.TabIndex = 7
        Me.chbStatus.Text = "Enable"
        Me.chbStatus.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(272, 58)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(37, 13)
        Me.Label11.TabIndex = 40
        Me.Label11.Text = "Status"
        '
        'txtLastName
        '
        Me.txtLastName.Location = New System.Drawing.Point(97, 127)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(100, 20)
        Me.txtLastName.TabIndex = 5
        '
        'txtMiddleName
        '
        Me.txtMiddleName.Location = New System.Drawing.Point(97, 92)
        Me.txtMiddleName.Name = "txtMiddleName"
        Me.txtMiddleName.Size = New System.Drawing.Size(100, 20)
        Me.txtMiddleName.TabIndex = 4
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(14, 127)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(58, 13)
        Me.Label12.TabIndex = 37
        Me.Label12.Text = "Last Name"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(5, 96)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 13)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "Middle Name"
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(97, 53)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(100, 20)
        Me.txtFirstName.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 56)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 13)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "First Name"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.btnSelectAll)
        Me.TabPage2.Controls.Add(Me.Label18)
        Me.TabPage2.Controls.Add(Me.txtFiltro2)
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(2)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(2)
        Me.TabPage2.Size = New System.Drawing.Size(709, 243)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Contact Information"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'btnSelectAll
        '
        Me.btnSelectAll.Location = New System.Drawing.Point(266, 196)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(75, 23)
        Me.btnSelectAll.TabIndex = 22
        Me.btnSelectAll.Text = "Show All"
        Me.btnSelectAll.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(41, 199)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(41, 13)
        Me.Label18.TabIndex = 39
        Me.Label18.Text = "Search"
        '
        'txtFiltro2
        '
        Me.txtFiltro2.Location = New System.Drawing.Point(87, 196)
        Me.txtFiltro2.Margin = New System.Windows.Forms.Padding(2)
        Me.txtFiltro2.Name = "txtFiltro2"
        Me.txtFiltro2.Size = New System.Drawing.Size(148, 20)
        Me.txtFiltro2.TabIndex = 21
        '
        'GroupBox2
        '
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
        Me.GroupBox2.Location = New System.Drawing.Point(390, 25)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(295, 196)
        Me.GroupBox2.TabIndex = 37
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Address"
        '
        'lblN4
        '
        Me.lblN4.AutoSize = True
        Me.lblN4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblN4.ForeColor = System.Drawing.Color.Red
        Me.lblN4.Location = New System.Drawing.Point(204, 71)
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
        Me.lblN3.Location = New System.Drawing.Point(204, 21)
        Me.lblN3.Name = "lblN3"
        Me.lblN3.Size = New System.Drawing.Size(14, 18)
        Me.lblN3.TabIndex = 46
        Me.lblN3.Text = "*"
        '
        'chbAddress
        '
        Me.chbAddress.AutoSize = True
        Me.chbAddress.Location = New System.Drawing.Point(227, 16)
        Me.chbAddress.Name = "chbAddress"
        Me.chbAddress.Size = New System.Drawing.Size(59, 17)
        Me.chbAddress.TabIndex = 15
        Me.chbAddress.Text = "Enable"
        Me.chbAddress.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(8, 125)
        Me.Label14.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(64, 13)
        Me.Label14.TabIndex = 42
        Me.Label14.Text = "Postal Code"
        '
        'txtPC
        '
        Me.txtPC.Location = New System.Drawing.Point(82, 123)
        Me.txtPC.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPC.Name = "txtPC"
        Me.txtPC.Size = New System.Drawing.Size(118, 20)
        Me.txtPC.TabIndex = 20
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(15, 47)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 13)
        Me.Label9.TabIndex = 40
        Me.Label9.Text = "Number"
        '
        'txtNumerStreat
        '
        Me.txtNumerStreat.Location = New System.Drawing.Point(81, 44)
        Me.txtNumerStreat.Margin = New System.Windows.Forms.Padding(2)
        Me.txtNumerStreat.Name = "txtNumerStreat"
        Me.txtNumerStreat.Size = New System.Drawing.Size(118, 20)
        Me.txtNumerStreat.TabIndex = 17
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 76)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 13)
        Me.Label4.TabIndex = 38
        Me.Label4.Text = "City"
        '
        'txtCity
        '
        Me.txtCity.Location = New System.Drawing.Point(81, 71)
        Me.txtCity.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(118, 20)
        Me.txtCity.TabIndex = 18
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 21)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "Streat"
        '
        'txtStreat
        '
        Me.txtStreat.Location = New System.Drawing.Point(81, 18)
        Me.txtStreat.Margin = New System.Windows.Forms.Padding(2)
        Me.txtStreat.Name = "txtStreat"
        Me.txtStreat.Size = New System.Drawing.Size(118, 20)
        Me.txtStreat.TabIndex = 16
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 99)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "Province"
        '
        'txtProvince
        '
        Me.txtProvince.Location = New System.Drawing.Point(81, 97)
        Me.txtProvince.Margin = New System.Windows.Forms.Padding(2)
        Me.txtProvince.Name = "txtProvince"
        Me.txtProvince.Size = New System.Drawing.Size(118, 20)
        Me.txtProvince.TabIndex = 19
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblN2)
        Me.GroupBox1.Controls.Add(Me.lblN1)
        Me.GroupBox1.Controls.Add(Me.chbContact)
        Me.GroupBox1.Controls.Add(Me.txtPhoneNumber2)
        Me.GroupBox1.Controls.Add(Me.lblPN2)
        Me.GroupBox1.Controls.Add(Me.lblEmail)
        Me.GroupBox1.Controls.Add(Me.txtEmail)
        Me.GroupBox1.Controls.Add(Me.txtPhoneNumber)
        Me.GroupBox1.Controls.Add(Me.lblPN1)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 25)
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
        Me.lblN2.Location = New System.Drawing.Point(308, 86)
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
        Me.lblN1.Location = New System.Drawing.Point(234, 25)
        Me.lblN1.Name = "lblN1"
        Me.lblN1.Size = New System.Drawing.Size(14, 18)
        Me.lblN1.TabIndex = 45
        Me.lblN1.Text = "*"
        '
        'chbContact
        '
        Me.chbContact.AutoSize = True
        Me.chbContact.Location = New System.Drawing.Point(271, 16)
        Me.chbContact.Name = "chbContact"
        Me.chbContact.Size = New System.Drawing.Size(59, 17)
        Me.chbContact.TabIndex = 12
        Me.chbContact.Text = "Enable"
        Me.chbContact.UseVisualStyleBackColor = True
        '
        'txtPhoneNumber2
        '
        Me.txtPhoneNumber2.Location = New System.Drawing.Point(106, 54)
        Me.txtPhoneNumber2.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPhoneNumber2.MaxLength = 10
        Me.txtPhoneNumber2.Name = "txtPhoneNumber2"
        Me.txtPhoneNumber2.Size = New System.Drawing.Size(124, 20)
        Me.txtPhoneNumber2.TabIndex = 13
        '
        'lblPN2
        '
        Me.lblPN2.AutoSize = True
        Me.lblPN2.Location = New System.Drawing.Point(17, 58)
        Me.lblPN2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblPN2.Name = "lblPN2"
        Me.lblPN2.Size = New System.Drawing.Size(87, 13)
        Me.lblPN2.TabIndex = 42
        Me.lblPN2.Text = "Phone Number 2"
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Location = New System.Drawing.Point(17, 91)
        Me.lblEmail.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(32, 13)
        Me.lblEmail.TabIndex = 39
        Me.lblEmail.Text = "Email"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(105, 84)
        Me.txtEmail.Margin = New System.Windows.Forms.Padding(2)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(198, 20)
        Me.txtEmail.TabIndex = 14
        '
        'txtPhoneNumber
        '
        Me.txtPhoneNumber.Location = New System.Drawing.Point(105, 21)
        Me.txtPhoneNumber.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPhoneNumber.MaxLength = 10
        Me.txtPhoneNumber.Name = "txtPhoneNumber"
        Me.txtPhoneNumber.Size = New System.Drawing.Size(124, 20)
        Me.txtPhoneNumber.TabIndex = 12
        '
        'lblPN1
        '
        Me.lblPN1.AutoSize = True
        Me.lblPN1.Location = New System.Drawing.Point(16, 25)
        Me.lblPN1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblPN1.Name = "lblPN1"
        Me.lblPN1.Size = New System.Drawing.Size(81, 13)
        Me.lblPN1.TabIndex = 36
        Me.lblPN1.Text = "Phone Number "
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.ForeColor = System.Drawing.Color.Red
        Me.Button1.Location = New System.Drawing.Point(672, 11)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(50, 23)
        Me.Button1.TabIndex = 22
        Me.Button1.Text = "Exit"
        Me.Button1.UseVisualStyleBackColor = True
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
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(733, 55)
        Me.Panel2.TabIndex = 23
        '
        'Panel3
        '
        Me.Panel3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Panel3.Controls.Add(Me.TabControl1)
        Me.Panel3.Location = New System.Drawing.Point(3, 56)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(727, 268)
        Me.Panel3.TabIndex = 24
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
        'Clients
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(733, 516)
        Me.Controls.Add(Me.Panel1)
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
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
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
End Class
