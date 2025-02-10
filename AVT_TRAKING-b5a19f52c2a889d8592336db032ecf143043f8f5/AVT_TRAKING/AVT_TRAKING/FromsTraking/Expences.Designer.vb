<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Expences
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
    'No lo modifique connSQL el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Expences))
        Me.TitleBar = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnRestore = New System.Windows.Forms.PictureBox()
        Me.btnMaximize = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.tblExpenses = New System.Windows.Forms.DataGridView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnUbdate = New System.Windows.Forms.Button()
        Me.txtExpenceCode = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.txtFind = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtSkillType = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtCBSFulNumber = New System.Windows.Forms.TextBox()
        Me.txtCustumerPositionJobDescription = New System.Windows.Forms.TextBox()
        Me.txtCustomerPositionID = New System.Windows.Forms.TextBox()
        Me.txtCostCode = New System.Windows.Forms.TextBox()
        Me.txtWorkType = New System.Windows.Forms.TextBox()
        Me.txtPayItemType = New System.Windows.Forms.TextBox()
        Me.txtCategory = New System.Windows.Forms.TextBox()
        Me.cmbExpense = New System.Windows.Forms.ComboBox()
        Me.cmbJobNo = New System.Windows.Forms.ComboBox()
        Me.cmbClient = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.btnAddExpJob = New System.Windows.Forms.Button()
        Me.btnCancelExpJob = New System.Windows.Forms.Button()
        Me.btnUpdateExpJob = New System.Windows.Forms.Button()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.tblExpensesJobs = New System.Windows.Forms.DataGridView()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.btnFindExpenseJob = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.cmbFindExpJob = New System.Windows.Forms.ComboBox()
        Me.btnExcelDownload = New System.Windows.Forms.Button()
        Me.btnExcelUpdate = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TitleBar.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnRestore, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnMaximize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.tblExpenses, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        CType(Me.tblExpensesJobs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel10.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.SuspendLayout()
        '
        'TitleBar
        '
        Me.TitleBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.TitleBar.Controls.Add(Me.Label3)
        Me.TitleBar.Controls.Add(Me.PictureBox1)
        Me.TitleBar.Controls.Add(Me.btnRestore)
        Me.TitleBar.Controls.Add(Me.btnMaximize)
        Me.TitleBar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TitleBar.Location = New System.Drawing.Point(4, 4)
        Me.TitleBar.Margin = New System.Windows.Forms.Padding(4)
        Me.TitleBar.Name = "TitleBar"
        Me.TitleBar.Size = New System.Drawing.Size(832, 51)
        Me.TitleBar.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label3.Location = New System.Drawing.Point(4, 4)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(117, 25)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Expenses"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = Global.AVT_TRAKING.My.Resources.Resources.minimize2
        Me.PictureBox1.Location = New System.Drawing.Point(752, 12)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(36, 27)
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'btnRestore
        '
        Me.btnRestore.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRestore.Image = Global.AVT_TRAKING.My.Resources.Resources.restore2
        Me.btnRestore.Location = New System.Drawing.Point(796, 11)
        Me.btnRestore.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRestore.Name = "btnRestore"
        Me.btnRestore.Size = New System.Drawing.Size(36, 32)
        Me.btnRestore.TabIndex = 3
        Me.btnRestore.TabStop = False
        '
        'btnMaximize
        '
        Me.btnMaximize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMaximize.Image = Global.AVT_TRAKING.My.Resources.Resources.maximize2
        Me.btnMaximize.Location = New System.Drawing.Point(796, 11)
        Me.btnMaximize.Margin = New System.Windows.Forms.Padding(4)
        Me.btnMaximize.Name = "btnMaximize"
        Me.btnMaximize.Size = New System.Drawing.Size(32, 28)
        Me.btnMaximize.TabIndex = 2
        Me.btnMaximize.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Panel2.Controls.Add(Me.TabControl1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(4, 123)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(832, 441)
        Me.Panel2.TabIndex = 3
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(832, 441)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.TableLayoutPanel2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 26)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabPage1.Size = New System.Drawing.Size(824, 411)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Expenses"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 375.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Panel4, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel3, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 2)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(818, 407)
        Me.TableLayoutPanel2.TabIndex = 13
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.tblExpenses)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(379, 4)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(435, 399)
        Me.Panel4.TabIndex = 1
        '
        'tblExpenses
        '
        Me.tblExpenses.AllowUserToAddRows = False
        Me.tblExpenses.AllowUserToDeleteRows = False
        Me.tblExpenses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblExpenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblExpenses.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblExpenses.Location = New System.Drawing.Point(0, 0)
        Me.tblExpenses.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tblExpenses.Name = "tblExpenses"
        Me.tblExpenses.ReadOnly = True
        Me.tblExpenses.RowHeadersWidth = 62
        Me.tblExpenses.RowTemplate.Height = 28
        Me.tblExpenses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tblExpenses.Size = New System.Drawing.Size(435, 399)
        Me.tblExpenses.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.TableLayoutPanel3)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(4, 4)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(367, 399)
        Me.Panel3.TabIndex = 0
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.GroupBox1, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Panel5, 0, 1)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(367, 399)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnCancel)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.btnUbdate)
        Me.GroupBox1.Controls.Add(Me.txtExpenceCode)
        Me.GroupBox1.Controls.Add(Me.btnSave)
        Me.GroupBox1.Controls.Add(Me.txtDescription)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox1.Location = New System.Drawing.Point(4, 4)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(359, 331)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Data"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Expense Code"
        '
        'btnCancel
        '
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = Global.AVT_TRAKING.My.Resources.Resources.close2
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(243, 102)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(111, 31)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Description "
        '
        'btnUbdate
        '
        Me.btnUbdate.FlatAppearance.BorderSize = 0
        Me.btnUbdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.btnUbdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUbdate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUbdate.Image = Global.AVT_TRAKING.My.Resources.Resources.update
        Me.btnUbdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnUbdate.Location = New System.Drawing.Point(108, 102)
        Me.btnUbdate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnUbdate.Name = "btnUbdate"
        Me.btnUbdate.Size = New System.Drawing.Size(123, 31)
        Me.btnUbdate.TabIndex = 8
        Me.btnUbdate.Text = "Update"
        Me.btnUbdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnUbdate.UseVisualStyleBackColor = True
        '
        'txtExpenceCode
        '
        Me.txtExpenceCode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtExpenceCode.Location = New System.Drawing.Point(127, 16)
        Me.txtExpenceCode.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtExpenceCode.MaxLength = 36
        Me.txtExpenceCode.Name = "txtExpenceCode"
        Me.txtExpenceCode.Size = New System.Drawing.Size(200, 24)
        Me.txtExpenceCode.TabIndex = 4
        '
        'btnSave
        '
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Image = Global.AVT_TRAKING.My.Resources.Resources.add
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(7, 102)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(96, 31)
        Me.btnSave.TabIndex = 7
        Me.btnSave.Text = "Add"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'txtDescription
        '
        Me.txtDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescription.Location = New System.Drawing.Point(127, 46)
        Me.txtDescription.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtDescription.MaxLength = 36
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(200, 24)
        Me.txtDescription.TabIndex = 5
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.btnFind)
        Me.Panel5.Controls.Add(Me.txtFind)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(4, 343)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(359, 52)
        Me.Panel5.TabIndex = 11
        '
        'btnFind
        '
        Me.btnFind.FlatAppearance.BorderSize = 0
        Me.btnFind.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFind.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFind.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnFind.Image = Global.AVT_TRAKING.My.Resources.Resources.loupe
        Me.btnFind.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFind.Location = New System.Drawing.Point(221, 9)
        Me.btnFind.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(52, 34)
        Me.btnFind.TabIndex = 12
        Me.btnFind.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFind.UseVisualStyleBackColor = True
        '
        'txtFind
        '
        Me.txtFind.Location = New System.Drawing.Point(40, 15)
        Me.txtFind.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFind.Name = "txtFind"
        Me.txtFind.Size = New System.Drawing.Size(173, 24)
        Me.txtFind.TabIndex = 11
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.Panel6)
        Me.TabPage2.Location = New System.Drawing.Point(4, 26)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(824, 411)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Expenses by Job"
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.TableLayoutPanel4)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(824, 411)
        Me.Panel6.TabIndex = 0
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 394.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.Panel7, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Panel8, 1, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(824, 411)
        Me.TableLayoutPanel4.TabIndex = 0
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.TableLayoutPanel5)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(3, 3)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(388, 405)
        Me.Panel7.TabIndex = 0
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 1
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.GroupBox2, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Panel9, 0, 1)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel5.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 2
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(388, 405)
        Me.TableLayoutPanel5.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtSkillType)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.txtCBSFulNumber)
        Me.GroupBox2.Controls.Add(Me.txtCustumerPositionJobDescription)
        Me.GroupBox2.Controls.Add(Me.txtCustomerPositionID)
        Me.GroupBox2.Controls.Add(Me.txtCostCode)
        Me.GroupBox2.Controls.Add(Me.txtWorkType)
        Me.GroupBox2.Controls.Add(Me.txtPayItemType)
        Me.GroupBox2.Controls.Add(Me.txtCategory)
        Me.GroupBox2.Controls.Add(Me.cmbExpense)
        Me.GroupBox2.Controls.Add(Me.cmbJobNo)
        Me.GroupBox2.Controls.Add(Me.cmbClient)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox2.Location = New System.Drawing.Point(4, 4)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(380, 337)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Data"
        '
        'txtSkillType
        '
        Me.txtSkillType.Location = New System.Drawing.Point(108, 253)
        Me.txtSkillType.MaxLength = 100
        Me.txtSkillType.Multiline = True
        Me.txtSkillType.Name = "txtSkillType"
        Me.txtSkillType.Size = New System.Drawing.Size(252, 68)
        Me.txtSkillType.TabIndex = 22
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.Label14.Location = New System.Drawing.Point(9, 253)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(73, 17)
        Me.Label14.TabIndex = 21
        Me.Label14.Text = "Skill Type"
        '
        'txtCBSFulNumber
        '
        Me.txtCBSFulNumber.Location = New System.Drawing.Point(157, 223)
        Me.txtCBSFulNumber.MaxLength = 30
        Me.txtCBSFulNumber.Name = "txtCBSFulNumber"
        Me.txtCBSFulNumber.Size = New System.Drawing.Size(203, 24)
        Me.txtCBSFulNumber.TabIndex = 20
        '
        'txtCustumerPositionJobDescription
        '
        Me.txtCustumerPositionJobDescription.Location = New System.Drawing.Point(127, 194)
        Me.txtCustumerPositionJobDescription.MaxLength = 30
        Me.txtCustumerPositionJobDescription.Name = "txtCustumerPositionJobDescription"
        Me.txtCustumerPositionJobDescription.Size = New System.Drawing.Size(233, 24)
        Me.txtCustumerPositionJobDescription.TabIndex = 19
        '
        'txtCustomerPositionID
        '
        Me.txtCustomerPositionID.Location = New System.Drawing.Point(108, 165)
        Me.txtCustomerPositionID.MaxLength = 30
        Me.txtCustomerPositionID.Name = "txtCustomerPositionID"
        Me.txtCustomerPositionID.Size = New System.Drawing.Size(252, 24)
        Me.txtCustomerPositionID.TabIndex = 18
        '
        'txtCostCode
        '
        Me.txtCostCode.Location = New System.Drawing.Point(108, 136)
        Me.txtCostCode.MaxLength = 30
        Me.txtCostCode.Name = "txtCostCode"
        Me.txtCostCode.Size = New System.Drawing.Size(252, 24)
        Me.txtCostCode.TabIndex = 17
        '
        'txtWorkType
        '
        Me.txtWorkType.Location = New System.Drawing.Point(108, 107)
        Me.txtWorkType.MaxLength = 30
        Me.txtWorkType.Name = "txtWorkType"
        Me.txtWorkType.Size = New System.Drawing.Size(252, 24)
        Me.txtWorkType.TabIndex = 16
        '
        'txtPayItemType
        '
        Me.txtPayItemType.Location = New System.Drawing.Point(127, 78)
        Me.txtPayItemType.MaxLength = 30
        Me.txtPayItemType.Name = "txtPayItemType"
        Me.txtPayItemType.Size = New System.Drawing.Size(233, 24)
        Me.txtPayItemType.TabIndex = 15
        '
        'txtCategory
        '
        Me.txtCategory.Location = New System.Drawing.Point(280, 48)
        Me.txtCategory.MaxLength = 12
        Me.txtCategory.Name = "txtCategory"
        Me.txtCategory.Size = New System.Drawing.Size(90, 24)
        Me.txtCategory.TabIndex = 14
        '
        'cmbExpense
        '
        Me.cmbExpense.FormattingEnabled = True
        Me.cmbExpense.Location = New System.Drawing.Point(81, 48)
        Me.cmbExpense.Name = "cmbExpense"
        Me.cmbExpense.Size = New System.Drawing.Size(115, 25)
        Me.cmbExpense.TabIndex = 13
        '
        'cmbJobNo
        '
        Me.cmbJobNo.FormattingEnabled = True
        Me.cmbJobNo.Location = New System.Drawing.Point(259, 19)
        Me.cmbJobNo.Name = "cmbJobNo"
        Me.cmbJobNo.Size = New System.Drawing.Size(111, 25)
        Me.cmbJobNo.TabIndex = 12
        '
        'cmbClient
        '
        Me.cmbClient.FormattingEnabled = True
        Me.cmbClient.Location = New System.Drawing.Point(81, 19)
        Me.cmbClient.Name = "cmbClient"
        Me.cmbClient.Size = New System.Drawing.Size(115, 25)
        Me.cmbClient.TabIndex = 11
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.Label13.Location = New System.Drawing.Point(9, 227)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(126, 17)
        Me.Label13.TabIndex = 10
        Me.Label13.Text = "CBS Full Number"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.Label12.Location = New System.Drawing.Point(8, 197)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(99, 17)
        Me.Label12.TabIndex = 9
        Me.Label12.Text = "Cust. P. J. D."
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.Label11.Location = New System.Drawing.Point(8, 169)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(83, 17)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "Cust. P. ID"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.Label10.Location = New System.Drawing.Point(7, 139)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(82, 17)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "Cost Code"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.Label9.Location = New System.Drawing.Point(6, 109)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(83, 17)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Work Type"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.Label8.Location = New System.Drawing.Point(7, 81)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(107, 17)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Pay Item Type"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.Label7.Location = New System.Drawing.Point(202, 52)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 17)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Category"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.Label6.Location = New System.Drawing.Point(6, 52)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 17)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Expense"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.Label4.Location = New System.Drawing.Point(202, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 17)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "JobNo"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.Label5.Location = New System.Drawing.Point(22, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 17)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Client "
        '
        'Panel9
        '
        Me.Panel9.Controls.Add(Me.btnAddExpJob)
        Me.Panel9.Controls.Add(Me.btnCancelExpJob)
        Me.Panel9.Controls.Add(Me.btnUpdateExpJob)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel9.Location = New System.Drawing.Point(4, 349)
        Me.Panel9.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(380, 52)
        Me.Panel9.TabIndex = 11
        '
        'btnAddExpJob
        '
        Me.btnAddExpJob.FlatAppearance.BorderSize = 0
        Me.btnAddExpJob.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.btnAddExpJob.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddExpJob.Font = New System.Drawing.Font("Verdana", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddExpJob.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnAddExpJob.Image = Global.AVT_TRAKING.My.Resources.Resources.add
        Me.btnAddExpJob.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAddExpJob.Location = New System.Drawing.Point(11, 11)
        Me.btnAddExpJob.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAddExpJob.Name = "btnAddExpJob"
        Me.btnAddExpJob.Size = New System.Drawing.Size(96, 31)
        Me.btnAddExpJob.TabIndex = 7
        Me.btnAddExpJob.Text = "Add"
        Me.btnAddExpJob.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAddExpJob.UseVisualStyleBackColor = True
        '
        'btnCancelExpJob
        '
        Me.btnCancelExpJob.FlatAppearance.BorderSize = 0
        Me.btnCancelExpJob.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.btnCancelExpJob.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelExpJob.Font = New System.Drawing.Font("Verdana", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelExpJob.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnCancelExpJob.Image = Global.AVT_TRAKING.My.Resources.Resources.close2
        Me.btnCancelExpJob.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelExpJob.Location = New System.Drawing.Point(249, 11)
        Me.btnCancelExpJob.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCancelExpJob.Name = "btnCancelExpJob"
        Me.btnCancelExpJob.Size = New System.Drawing.Size(111, 31)
        Me.btnCancelExpJob.TabIndex = 9
        Me.btnCancelExpJob.Text = "Cancel"
        Me.btnCancelExpJob.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelExpJob.UseVisualStyleBackColor = True
        '
        'btnUpdateExpJob
        '
        Me.btnUpdateExpJob.FlatAppearance.BorderSize = 0
        Me.btnUpdateExpJob.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.btnUpdateExpJob.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdateExpJob.Font = New System.Drawing.Font("Verdana", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdateExpJob.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnUpdateExpJob.Image = Global.AVT_TRAKING.My.Resources.Resources.update
        Me.btnUpdateExpJob.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnUpdateExpJob.Location = New System.Drawing.Point(112, 11)
        Me.btnUpdateExpJob.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnUpdateExpJob.Name = "btnUpdateExpJob"
        Me.btnUpdateExpJob.Size = New System.Drawing.Size(123, 31)
        Me.btnUpdateExpJob.TabIndex = 8
        Me.btnUpdateExpJob.Text = "Update"
        Me.btnUpdateExpJob.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnUpdateExpJob.UseVisualStyleBackColor = True
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.TableLayoutPanel6)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel8.Location = New System.Drawing.Point(397, 3)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(424, 405)
        Me.Panel8.TabIndex = 1
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.ColumnCount = 1
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.tblExpensesJobs, 0, 1)
        Me.TableLayoutPanel6.Controls.Add(Me.Panel10, 0, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.Panel11, 0, 2)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 3
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(424, 405)
        Me.TableLayoutPanel6.TabIndex = 1
        '
        'tblExpensesJobs
        '
        Me.tblExpensesJobs.AllowUserToAddRows = False
        Me.tblExpensesJobs.AllowUserToDeleteRows = False
        Me.tblExpensesJobs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblExpensesJobs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblExpensesJobs.Location = New System.Drawing.Point(3, 54)
        Me.tblExpensesJobs.Name = "tblExpensesJobs"
        Me.tblExpensesJobs.ReadOnly = True
        Me.tblExpensesJobs.RowHeadersWidth = 51
        Me.tblExpensesJobs.RowTemplate.Height = 24
        Me.tblExpensesJobs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tblExpensesJobs.Size = New System.Drawing.Size(418, 288)
        Me.tblExpensesJobs.TabIndex = 0
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.cmbFindExpJob)
        Me.Panel10.Controls.Add(Me.btnFindExpenseJob)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel10.Location = New System.Drawing.Point(3, 3)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(418, 45)
        Me.Panel10.TabIndex = 1
        '
        'btnFindExpenseJob
        '
        Me.btnFindExpenseJob.FlatAppearance.BorderSize = 0
        Me.btnFindExpenseJob.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.btnFindExpenseJob.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindExpenseJob.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindExpenseJob.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnFindExpenseJob.Image = Global.AVT_TRAKING.My.Resources.Resources.loupe
        Me.btnFindExpenseJob.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFindExpenseJob.Location = New System.Drawing.Point(184, 7)
        Me.btnFindExpenseJob.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnFindExpenseJob.Name = "btnFindExpenseJob"
        Me.btnFindExpenseJob.Size = New System.Drawing.Size(52, 34)
        Me.btnFindExpenseJob.TabIndex = 12
        Me.btnFindExpenseJob.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFindExpenseJob.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = Global.AVT_TRAKING.My.Resources.Resources._exit
        Me.PictureBox2.Location = New System.Drawing.Point(782, 4)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(47, 41)
        Me.PictureBox2.TabIndex = 2
        Me.PictureBox2.TabStop = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TitleBar, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 59.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(840, 568)
        Me.TableLayoutPanel1.TabIndex = 4
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(4, 63)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(832, 52)
        Me.Panel1.TabIndex = 3
        '
        'btnDelete
        '
        Me.btnDelete.FlatAppearance.BorderSize = 0
        Me.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Verdana", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnDelete.Image = Global.AVT_TRAKING.My.Resources.Resources.delete
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.Location = New System.Drawing.Point(-6, 12)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(111, 31)
        Me.btnDelete.TabIndex = 10
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'Panel11
        '
        Me.Panel11.Controls.Add(Me.btnExcelUpdate)
        Me.Panel11.Controls.Add(Me.btnExcelDownload)
        Me.Panel11.Controls.Add(Me.btnDelete)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel11.Location = New System.Drawing.Point(3, 348)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(418, 54)
        Me.Panel11.TabIndex = 2
        '
        'cmbFindExpJob
        '
        Me.cmbFindExpJob.FormattingEnabled = True
        Me.cmbFindExpJob.Location = New System.Drawing.Point(4, 13)
        Me.cmbFindExpJob.Name = "cmbFindExpJob"
        Me.cmbFindExpJob.Size = New System.Drawing.Size(174, 25)
        Me.cmbFindExpJob.TabIndex = 13
        '
        'btnExcelDownload
        '
        Me.btnExcelDownload.FlatAppearance.BorderSize = 0
        Me.btnExcelDownload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.btnExcelDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExcelDownload.Font = New System.Drawing.Font("Verdana", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcelDownload.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnExcelDownload.Image = CType(resources.GetObject("btnExcelDownload.Image"), System.Drawing.Image)
        Me.btnExcelDownload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcelDownload.Location = New System.Drawing.Point(123, 12)
        Me.btnExcelDownload.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnExcelDownload.Name = "btnExcelDownload"
        Me.btnExcelDownload.Size = New System.Drawing.Size(111, 40)
        Me.btnExcelDownload.TabIndex = 11
        Me.btnExcelDownload.Text = "Upload"
        Me.btnExcelDownload.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcelDownload.UseVisualStyleBackColor = True
        '
        'btnExcelUpdate
        '
        Me.btnExcelUpdate.FlatAppearance.BorderSize = 0
        Me.btnExcelUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.btnExcelUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExcelUpdate.Font = New System.Drawing.Font("Verdana", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcelUpdate.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnExcelUpdate.Image = CType(resources.GetObject("btnExcelUpdate.Image"), System.Drawing.Image)
        Me.btnExcelUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcelUpdate.Location = New System.Drawing.Point(248, 12)
        Me.btnExcelUpdate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnExcelUpdate.Name = "btnExcelUpdate"
        Me.btnExcelUpdate.Size = New System.Drawing.Size(117, 40)
        Me.btnExcelUpdate.TabIndex = 12
        Me.btnExcelUpdate.Text = "Download"
        Me.btnExcelUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcelUpdate.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label15.Location = New System.Drawing.Point(9, 17)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(0, 17)
        Me.Label15.TabIndex = 3
        '
        'Expences
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(840, 568)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "Expences"
        Me.Text = "Expences"
        Me.TitleBar.ResumeLayout(False)
        Me.TitleBar.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnRestore, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnMaximize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        CType(Me.tblExpenses, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel9.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.TableLayoutPanel6.ResumeLayout(False)
        CType(Me.tblExpensesJobs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel10.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel11.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TitleBar As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnUbdate As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents txtExpenceCode As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents tblExpenses As DataGridView
    Friend WithEvents btnFind As Button
    Friend WithEvents txtFind As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnRestore As PictureBox
    Friend WithEvents btnMaximize As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Panel6 As Panel
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents TableLayoutPanel5 As TableLayoutPanel
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btnCancelExpJob As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents btnUpdateExpJob As Button
    Friend WithEvents btnAddExpJob As Button
    Friend WithEvents btnFindExpenseJob As Button
    Friend WithEvents Panel8 As Panel
    Friend WithEvents TableLayoutPanel6 As TableLayoutPanel
    Friend WithEvents tblExpensesJobs As DataGridView
    Friend WithEvents Panel10 As Panel
    Friend WithEvents cmbClient As ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel9 As Panel
    Friend WithEvents cmbExpense As ComboBox
    Friend WithEvents cmbJobNo As ComboBox
    Friend WithEvents txtCBSFulNumber As TextBox
    Friend WithEvents txtCustumerPositionJobDescription As TextBox
    Friend WithEvents txtCustomerPositionID As TextBox
    Friend WithEvents txtCostCode As TextBox
    Friend WithEvents txtWorkType As TextBox
    Friend WithEvents txtPayItemType As TextBox
    Friend WithEvents txtCategory As TextBox
    Friend WithEvents txtSkillType As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Panel11 As Panel
    Friend WithEvents btnDelete As Button
    Friend WithEvents cmbFindExpJob As ComboBox
    Friend WithEvents btnExcelUpdate As Button
    Friend WithEvents btnExcelDownload As Button
    Friend WithEvents Label15 As Label
End Class
