<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Estimating
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnFindProject = New System.Windows.Forms.Button()
        Me.btnNextProject = New System.Windows.Forms.Button()
        Me.btnAfterProjects = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.txtUnit = New System.Windows.Forms.TextBox()
        Me.cmbProjects = New System.Windows.Forms.ComboBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnFindDrawingN = New System.Windows.Forms.Button()
        Me.btnNextDrawingN = New System.Windows.Forms.Button()
        Me.btnAfterDrawing = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDescriptionDrawing = New System.Windows.Forms.TextBox()
        Me.txtDrawingNum = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.tblSCFDrawing = New System.Windows.Forms.DataGridView()
        Me.TagId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tag = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LaborRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TypeSC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Enviroment = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Location = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DaysUp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Width = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Length = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Heigth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Decks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Build = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.tblSCFDrawing, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TabControl1, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel4, 0, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(954, 481)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.02532!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.97468!))
        Me.TableLayoutPanel3.Controls.Add(Me.Panel2, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Panel3, 1, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 71)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(948, 94)
        Me.TableLayoutPanel3.TabIndex = 33
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnFindProject)
        Me.Panel2.Controls.Add(Me.btnNextProject)
        Me.Panel2.Controls.Add(Me.btnAfterProjects)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.txtDescription)
        Me.Panel2.Controls.Add(Me.txtUnit)
        Me.Panel2.Controls.Add(Me.cmbProjects)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(345, 88)
        Me.Panel2.TabIndex = 0
        '
        'btnFindProject
        '
        Me.btnFindProject.FlatAppearance.BorderSize = 0
        Me.btnFindProject.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.btnFindProject.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindProject.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindProject.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnFindProject.Image = Global.AVT_TRAKING.My.Resources.Resources.loupe
        Me.btnFindProject.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFindProject.Location = New System.Drawing.Point(279, 0)
        Me.btnFindProject.Name = "btnFindProject"
        Me.btnFindProject.Size = New System.Drawing.Size(36, 32)
        Me.btnFindProject.TabIndex = 32
        Me.btnFindProject.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFindProject.UseVisualStyleBackColor = True
        '
        'btnNextProject
        '
        Me.btnNextProject.FlatAppearance.BorderSize = 0
        Me.btnNextProject.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.btnNextProject.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNextProject.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNextProject.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnNextProject.Image = Global.AVT_TRAKING.My.Resources.Resources._next
        Me.btnNextProject.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNextProject.Location = New System.Drawing.Point(245, 2)
        Me.btnNextProject.Name = "btnNextProject"
        Me.btnNextProject.Size = New System.Drawing.Size(36, 28)
        Me.btnNextProject.TabIndex = 31
        Me.btnNextProject.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNextProject.UseVisualStyleBackColor = True
        '
        'btnAfterProjects
        '
        Me.btnAfterProjects.FlatAppearance.BorderSize = 0
        Me.btnAfterProjects.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.btnAfterProjects.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAfterProjects.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAfterProjects.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnAfterProjects.Image = Global.AVT_TRAKING.My.Resources.Resources.after1
        Me.btnAfterProjects.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAfterProjects.Location = New System.Drawing.Point(201, 3)
        Me.btnAfterProjects.Name = "btnAfterProjects"
        Me.btnAfterProjects.Size = New System.Drawing.Size(36, 28)
        Me.btnAfterProjects.TabIndex = 30
        Me.btnAfterProjects.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAfterProjects.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label4.Location = New System.Drawing.Point(8, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Description"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label3.Location = New System.Drawing.Point(40, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Unit"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label2.Location = New System.Drawing.Point(12, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Project ID"
        '
        'txtDescription
        '
        Me.txtDescription.Enabled = False
        Me.txtDescription.Location = New System.Drawing.Point(74, 57)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(178, 20)
        Me.txtDescription.TabIndex = 2
        '
        'txtUnit
        '
        Me.txtUnit.Enabled = False
        Me.txtUnit.Location = New System.Drawing.Point(74, 31)
        Me.txtUnit.Name = "txtUnit"
        Me.txtUnit.Size = New System.Drawing.Size(121, 20)
        Me.txtUnit.TabIndex = 1
        '
        'cmbProjects
        '
        Me.cmbProjects.DropDownWidth = 180
        Me.cmbProjects.FormattingEnabled = True
        Me.cmbProjects.Location = New System.Drawing.Point(74, 4)
        Me.cmbProjects.Name = "cmbProjects"
        Me.cmbProjects.Size = New System.Drawing.Size(121, 21)
        Me.cmbProjects.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnCancel)
        Me.Panel3.Controls.Add(Me.btnNew)
        Me.Panel3.Controls.Add(Me.btnFindDrawingN)
        Me.Panel3.Controls.Add(Me.btnNextDrawingN)
        Me.Panel3.Controls.Add(Me.btnAfterDrawing)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.txtDescriptionDrawing)
        Me.Panel3.Controls.Add(Me.txtDrawingNum)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(354, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(591, 88)
        Me.Panel3.TabIndex = 1
        '
        'btnNew
        '
        Me.btnNew.FlatAppearance.BorderSize = 0
        Me.btnNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnNew.Image = Global.AVT_TRAKING.My.Resources.Resources._new
        Me.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNew.Location = New System.Drawing.Point(324, -1)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(36, 32)
        Me.btnNew.TabIndex = 36
        Me.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnFindDrawingN
        '
        Me.btnFindDrawingN.FlatAppearance.BorderSize = 0
        Me.btnFindDrawingN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.btnFindDrawingN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindDrawingN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindDrawingN.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnFindDrawingN.Image = Global.AVT_TRAKING.My.Resources.Resources.loupe
        Me.btnFindDrawingN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFindDrawingN.Location = New System.Drawing.Point(282, -2)
        Me.btnFindDrawingN.Name = "btnFindDrawingN"
        Me.btnFindDrawingN.Size = New System.Drawing.Size(36, 32)
        Me.btnFindDrawingN.TabIndex = 35
        Me.btnFindDrawingN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFindDrawingN.UseVisualStyleBackColor = True
        '
        'btnNextDrawingN
        '
        Me.btnNextDrawingN.FlatAppearance.BorderSize = 0
        Me.btnNextDrawingN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.btnNextDrawingN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNextDrawingN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNextDrawingN.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnNextDrawingN.Image = Global.AVT_TRAKING.My.Resources.Resources._next
        Me.btnNextDrawingN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNextDrawingN.Location = New System.Drawing.Point(244, 0)
        Me.btnNextDrawingN.Name = "btnNextDrawingN"
        Me.btnNextDrawingN.Size = New System.Drawing.Size(36, 28)
        Me.btnNextDrawingN.TabIndex = 34
        Me.btnNextDrawingN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNextDrawingN.UseVisualStyleBackColor = True
        '
        'btnAfterDrawing
        '
        Me.btnAfterDrawing.FlatAppearance.BorderSize = 0
        Me.btnAfterDrawing.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.btnAfterDrawing.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAfterDrawing.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAfterDrawing.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnAfterDrawing.Image = Global.AVT_TRAKING.My.Resources.Resources.after1
        Me.btnAfterDrawing.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAfterDrawing.Location = New System.Drawing.Point(200, 1)
        Me.btnAfterDrawing.Name = "btnAfterDrawing"
        Me.btnAfterDrawing.Size = New System.Drawing.Size(36, 28)
        Me.btnAfterDrawing.TabIndex = 33
        Me.btnAfterDrawing.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAfterDrawing.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label6.Location = New System.Drawing.Point(2, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 13)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Drawing N."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label5.Location = New System.Drawing.Point(0, 34)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Description"
        '
        'txtDescriptionDrawing
        '
        Me.txtDescriptionDrawing.Location = New System.Drawing.Point(63, 31)
        Me.txtDescriptionDrawing.Name = "txtDescriptionDrawing"
        Me.txtDescriptionDrawing.Size = New System.Drawing.Size(264, 20)
        Me.txtDescriptionDrawing.TabIndex = 1
        '
        'txtDrawingNum
        '
        Me.txtDrawingNum.Location = New System.Drawing.Point(63, 5)
        Me.txtDrawingNum.Name = "txtDrawingNum"
        Me.txtDrawingNum.Size = New System.Drawing.Size(112, 20)
        Me.txtDrawingNum.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btnSalir)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(948, 62)
        Me.Panel1.TabIndex = 0
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.FlatAppearance.BorderSize = 0
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.ForeColor = System.Drawing.Color.White
        Me.btnSalir.Image = Global.AVT_TRAKING.My.Resources.Resources._exit
        Me.btnSalir.Location = New System.Drawing.Point(903, 5)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(43, 55)
        Me.btnSalir.TabIndex = 35
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Location = New System.Drawing.Point(9, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 18)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Estimating"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(3, 171)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(948, 251)
        Me.TabControl1.TabIndex = 34
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.tblSCFDrawing)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(940, 225)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "SCAFFOLD"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'tblSCFDrawing
        '
        Me.tblSCFDrawing.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblSCFDrawing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblSCFDrawing.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TagId, Me.Tag, Me.LaborRate, Me.TypeSC, Me.Enviroment, Me.Location, Me.DaysUp, Me.Width, Me.Length, Me.Heigth, Me.Decks, Me.Build})
        Me.tblSCFDrawing.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblSCFDrawing.Location = New System.Drawing.Point(3, 3)
        Me.tblSCFDrawing.Name = "tblSCFDrawing"
        Me.tblSCFDrawing.Size = New System.Drawing.Size(934, 219)
        Me.tblSCFDrawing.TabIndex = 0
        '
        'TagId
        '
        Me.TagId.HeaderText = "TagId"
        Me.TagId.Name = "TagId"
        Me.TagId.Visible = False
        '
        'Tag
        '
        Me.Tag.HeaderText = "Tag"
        Me.Tag.Name = "Tag"
        '
        'LaborRate
        '
        Me.LaborRate.HeaderText = "Labor Rate"
        Me.LaborRate.Name = "LaborRate"
        '
        'TypeSC
        '
        Me.TypeSC.HeaderText = "Type"
        Me.TypeSC.Name = "TypeSC"
        '
        'Enviroment
        '
        Me.Enviroment.HeaderText = "Enviroment"
        Me.Enviroment.Name = "Enviroment"
        '
        'Location
        '
        Me.Location.HeaderText = "Location"
        Me.Location.Name = "Location"
        '
        'DaysUp
        '
        Me.DaysUp.HeaderText = "Days Up"
        Me.DaysUp.Name = "DaysUp"
        '
        'Width
        '
        Me.Width.HeaderText = "Width"
        Me.Width.Name = "Width"
        '
        'Length
        '
        Me.Length.HeaderText = "Length"
        Me.Length.Name = "Length"
        '
        'Heigth
        '
        Me.Heigth.HeaderText = "Heigth"
        Me.Heigth.Name = "Heigth"
        '
        'Decks
        '
        Me.Decks.HeaderText = "Decks"
        Me.Decks.Name = "Decks"
        '
        'Build
        '
        Me.Build.HeaderText = "Build"
        Me.Build.Name = "Build"
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(940, 225)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "EQUIPMENT"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(940, 225)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "PIPING"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnDelete)
        Me.Panel4.Controls.Add(Me.btnSave)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 428)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(948, 50)
        Me.Panel4.TabIndex = 35
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.FlatAppearance.BorderSize = 0
        Me.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnDelete.Image = Global.AVT_TRAKING.My.Resources.Resources.delete
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.Location = New System.Drawing.Point(854, 6)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(90, 35)
        Me.btnDelete.TabIndex = 32
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnSave.Image = Global.AVT_TRAKING.My.Resources.Resources.save
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(758, 6)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(90, 35)
        Me.btnSave.TabIndex = 31
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnCancel.Image = Global.AVT_TRAKING.My.Resources.Resources.close2
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(331, 29)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(86, 34)
        Me.btnCancel.TabIndex = 37
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.UseVisualStyleBackColor = True
        Me.btnCancel.Visible = False
        '
        'Estimating
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(954, 481)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Estimating"
        Me.Text = "Estimating"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.tblSCFDrawing, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnSalir As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents txtUnit As TextBox
    Friend WithEvents cmbProjects As ComboBox
    Friend WithEvents btnFindProject As Button
    Friend WithEvents btnNextProject As Button
    Friend WithEvents btnAfterProjects As Button
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnNew As Button
    Friend WithEvents btnFindDrawingN As Button
    Friend WithEvents btnNextDrawingN As Button
    Friend WithEvents btnAfterDrawing As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtDescriptionDrawing As TextBox
    Friend WithEvents txtDrawingNum As TextBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents tblSCFDrawing As DataGridView
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents Panel4 As Panel
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents TagId As DataGridViewTextBoxColumn
    Friend WithEvents Tag As DataGridViewTextBoxColumn
    Friend WithEvents LaborRate As DataGridViewTextBoxColumn
    Friend WithEvents TypeSC As DataGridViewTextBoxColumn
    Friend WithEvents Enviroment As DataGridViewTextBoxColumn
    Friend WithEvents Location As DataGridViewTextBoxColumn
    Friend WithEvents DaysUp As DataGridViewTextBoxColumn
    Friend WithEvents Width As DataGridViewTextBoxColumn
    Friend WithEvents Length As DataGridViewTextBoxColumn
    Friend WithEvents Heigth As DataGridViewTextBoxColumn
    Friend WithEvents Decks As DataGridViewTextBoxColumn
    Friend WithEvents Build As DataGridViewTextBoxColumn
    Friend WithEvents btnCancel As Button
End Class
