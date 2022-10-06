<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainFrom
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainFrom))
        Me.TitleBar = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlButtons = New System.Windows.Forms.Panel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Panel15 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.btnEstimation = New System.Windows.Forms.Button()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.btnReports = New System.Windows.Forms.Button()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.tbnoOthers = New System.Windows.Forms.Button()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.btnMaterials = New System.Windows.Forms.Button()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.btnWorkCodes = New System.Windows.Forms.Button()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.btnEmployees = New System.Windows.Forms.Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btnClients = New System.Windows.Forms.Button()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.pcbLogoMain = New System.Windows.Forms.PictureBox()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.PanelChildForm = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TitleBar.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.pnlButtons.SuspendLayout()
        CType(Me.pcbLogoMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel16.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.PanelChildForm.SuspendLayout()
        Me.SuspendLayout()
        '
        'TitleBar
        '
        Me.TitleBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.TitleBar.Controls.Add(Me.Label1)
        Me.TitleBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.TitleBar.Location = New System.Drawing.Point(0, 0)
        Me.TitleBar.Name = "TitleBar"
        Me.TitleBar.Size = New System.Drawing.Size(1028, 25)
        Me.TitleBar.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Location = New System.Drawing.Point(10, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 18)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Main Menu"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(86, Byte), Integer))
        Me.Panel2.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(194, 632)
        Me.Panel2.TabIndex = 6
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.pnlButtons, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.pcbLogoMain, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel16, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 98.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(194, 632)
        Me.TableLayoutPanel2.TabIndex = 11
        '
        'pnlButtons
        '
        Me.pnlButtons.AutoScroll = True
        Me.pnlButtons.Controls.Add(Me.Button3)
        Me.pnlButtons.Controls.Add(Me.Panel15)
        Me.pnlButtons.Controls.Add(Me.Button1)
        Me.pnlButtons.Controls.Add(Me.Panel14)
        Me.pnlButtons.Controls.Add(Me.btnEstimation)
        Me.pnlButtons.Controls.Add(Me.Panel13)
        Me.pnlButtons.Controls.Add(Me.btnReports)
        Me.pnlButtons.Controls.Add(Me.Panel11)
        Me.pnlButtons.Controls.Add(Me.tbnoOthers)
        Me.pnlButtons.Controls.Add(Me.Panel8)
        Me.pnlButtons.Controls.Add(Me.btnMaterials)
        Me.pnlButtons.Controls.Add(Me.Panel7)
        Me.pnlButtons.Controls.Add(Me.btnWorkCodes)
        Me.pnlButtons.Controls.Add(Me.Panel6)
        Me.pnlButtons.Controls.Add(Me.btnEmployees)
        Me.pnlButtons.Controls.Add(Me.Panel5)
        Me.pnlButtons.Controls.Add(Me.btnClients)
        Me.pnlButtons.Controls.Add(Me.Panel10)
        Me.pnlButtons.Location = New System.Drawing.Point(3, 138)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Size = New System.Drawing.Size(188, 491)
        Me.pnlButtons.TabIndex = 11
        '
        'Button3
        '
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Nirmala UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button3.Image = Global.AVT_TRAKING.My.Resources.Resources.setup
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(0, 433)
        Me.Button3.Margin = New System.Windows.Forms.Padding(2)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(188, 45)
        Me.Button3.TabIndex = 18
        Me.Button3.Text = "System"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Panel15
        '
        Me.Panel15.BackColor = System.Drawing.Color.RoyalBlue
        Me.Panel15.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel15.Location = New System.Drawing.Point(0, 428)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Size = New System.Drawing.Size(188, 5)
        Me.Panel15.TabIndex = 17
        '
        'Button1
        '
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Nirmala UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button1.Image = Global.AVT_TRAKING.My.Resources.Resources.time
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(0, 383)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(188, 45)
        Me.Button1.TabIndex = 16
        Me.Button1.Text = " Backup"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Panel14
        '
        Me.Panel14.BackColor = System.Drawing.Color.RoyalBlue
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel14.Location = New System.Drawing.Point(0, 378)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(188, 5)
        Me.Panel14.TabIndex = 15
        '
        'btnEstimation
        '
        Me.btnEstimation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnEstimation.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnEstimation.FlatAppearance.BorderSize = 0
        Me.btnEstimation.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue
        Me.btnEstimation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEstimation.Font = New System.Drawing.Font("Nirmala UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEstimation.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnEstimation.Image = Global.AVT_TRAKING.My.Resources.Resources.catsemployee
        Me.btnEstimation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEstimation.Location = New System.Drawing.Point(0, 333)
        Me.btnEstimation.Margin = New System.Windows.Forms.Padding(2)
        Me.btnEstimation.Name = "btnEstimation"
        Me.btnEstimation.Size = New System.Drawing.Size(188, 45)
        Me.btnEstimation.TabIndex = 14
        Me.btnEstimation.Text = "    Estimation"
        Me.btnEstimation.UseVisualStyleBackColor = True
        '
        'Panel13
        '
        Me.Panel13.BackColor = System.Drawing.Color.RoyalBlue
        Me.Panel13.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel13.Location = New System.Drawing.Point(0, 328)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(188, 5)
        Me.Panel13.TabIndex = 13
        '
        'btnReports
        '
        Me.btnReports.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnReports.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnReports.FlatAppearance.BorderSize = 0
        Me.btnReports.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue
        Me.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReports.Font = New System.Drawing.Font("Nirmala UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReports.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnReports.Image = Global.AVT_TRAKING.My.Resources.Resources.reportMenu
        Me.btnReports.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReports.Location = New System.Drawing.Point(0, 283)
        Me.btnReports.Margin = New System.Windows.Forms.Padding(2)
        Me.btnReports.Name = "btnReports"
        Me.btnReports.Size = New System.Drawing.Size(188, 45)
        Me.btnReports.TabIndex = 12
        Me.btnReports.Text = "   Reports"
        Me.btnReports.UseVisualStyleBackColor = True
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.RoyalBlue
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel11.Location = New System.Drawing.Point(0, 278)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(188, 5)
        Me.Panel11.TabIndex = 11
        '
        'tbnoOthers
        '
        Me.tbnoOthers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbnoOthers.Dock = System.Windows.Forms.DockStyle.Top
        Me.tbnoOthers.FlatAppearance.BorderSize = 0
        Me.tbnoOthers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue
        Me.tbnoOthers.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.tbnoOthers.Font = New System.Drawing.Font("Nirmala UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbnoOthers.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbnoOthers.Image = Global.AVT_TRAKING.My.Resources.Resources.options
        Me.tbnoOthers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tbnoOthers.Location = New System.Drawing.Point(0, 233)
        Me.tbnoOthers.Margin = New System.Windows.Forms.Padding(2)
        Me.tbnoOthers.Name = "tbnoOthers"
        Me.tbnoOthers.Size = New System.Drawing.Size(188, 45)
        Me.tbnoOthers.TabIndex = 10
        Me.tbnoOthers.Text = "Others"
        Me.tbnoOthers.UseVisualStyleBackColor = True
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.RoyalBlue
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel8.Location = New System.Drawing.Point(0, 228)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(188, 5)
        Me.Panel8.TabIndex = 9
        '
        'btnMaterials
        '
        Me.btnMaterials.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMaterials.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnMaterials.FlatAppearance.BorderSize = 0
        Me.btnMaterials.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue
        Me.btnMaterials.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMaterials.Font = New System.Drawing.Font("Nirmala UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMaterials.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnMaterials.Image = Global.AVT_TRAKING.My.Resources.Resources.materials
        Me.btnMaterials.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMaterials.Location = New System.Drawing.Point(0, 176)
        Me.btnMaterials.Margin = New System.Windows.Forms.Padding(2)
        Me.btnMaterials.Name = "btnMaterials"
        Me.btnMaterials.Size = New System.Drawing.Size(188, 52)
        Me.btnMaterials.TabIndex = 8
        Me.btnMaterials.Text = "   Material"
        Me.btnMaterials.UseVisualStyleBackColor = True
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.RoyalBlue
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 171)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(188, 5)
        Me.Panel7.TabIndex = 7
        '
        'btnWorkCodes
        '
        Me.btnWorkCodes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnWorkCodes.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnWorkCodes.FlatAppearance.BorderSize = 0
        Me.btnWorkCodes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue
        Me.btnWorkCodes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnWorkCodes.Font = New System.Drawing.Font("Nirmala UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWorkCodes.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnWorkCodes.Image = Global.AVT_TRAKING.My.Resources.Resources.code
        Me.btnWorkCodes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnWorkCodes.Location = New System.Drawing.Point(0, 113)
        Me.btnWorkCodes.Margin = New System.Windows.Forms.Padding(2)
        Me.btnWorkCodes.Name = "btnWorkCodes"
        Me.btnWorkCodes.Size = New System.Drawing.Size(188, 58)
        Me.btnWorkCodes.TabIndex = 6
        Me.btnWorkCodes.Text = "       Client Projects"
        Me.btnWorkCodes.UseVisualStyleBackColor = True
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.RoyalBlue
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 108)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(188, 5)
        Me.Panel6.TabIndex = 5
        '
        'btnEmployees
        '
        Me.btnEmployees.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnEmployees.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnEmployees.FlatAppearance.BorderSize = 0
        Me.btnEmployees.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue
        Me.btnEmployees.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEmployees.Font = New System.Drawing.Font("Nirmala UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEmployees.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnEmployees.Image = Global.AVT_TRAKING.My.Resources.Resources.employee
        Me.btnEmployees.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEmployees.Location = New System.Drawing.Point(0, 63)
        Me.btnEmployees.Margin = New System.Windows.Forms.Padding(2)
        Me.btnEmployees.Name = "btnEmployees"
        Me.btnEmployees.Size = New System.Drawing.Size(188, 45)
        Me.btnEmployees.TabIndex = 4
        Me.btnEmployees.Text = "Employees"
        Me.btnEmployees.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.RoyalBlue
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 58)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(188, 5)
        Me.Panel5.TabIndex = 3
        '
        'btnClients
        '
        Me.btnClients.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnClients.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnClients.FlatAppearance.BorderSize = 0
        Me.btnClients.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue
        Me.btnClients.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClients.Font = New System.Drawing.Font("Nirmala UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClients.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnClients.Image = Global.AVT_TRAKING.My.Resources.Resources.crm
        Me.btnClients.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClients.Location = New System.Drawing.Point(0, 5)
        Me.btnClients.Margin = New System.Windows.Forms.Padding(2)
        Me.btnClients.Name = "btnClients"
        Me.btnClients.Size = New System.Drawing.Size(188, 53)
        Me.btnClients.TabIndex = 2
        Me.btnClients.Text = "Clients"
        Me.btnClients.UseVisualStyleBackColor = True
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.RoyalBlue
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel10.Location = New System.Drawing.Point(0, 0)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(188, 5)
        Me.Panel10.TabIndex = 1
        '
        'pcbLogoMain
        '
        Me.pcbLogoMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pcbLogoMain.Location = New System.Drawing.Point(3, 3)
        Me.pcbLogoMain.Name = "pcbLogoMain"
        Me.pcbLogoMain.Size = New System.Drawing.Size(188, 92)
        Me.pcbLogoMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pcbLogoMain.TabIndex = 10
        Me.pcbLogoMain.TabStop = False
        '
        'Panel16
        '
        Me.Panel16.Controls.Add(Me.Panel4)
        Me.Panel16.Controls.Add(Me.Panel9)
        Me.Panel16.Controls.Add(Me.Panel3)
        Me.Panel16.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel16.Location = New System.Drawing.Point(3, 101)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(188, 31)
        Me.Panel16.TabIndex = 11
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.RoyalBlue
        Me.Panel4.Location = New System.Drawing.Point(87, 23)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(104, 5)
        Me.Panel4.TabIndex = 5
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.RoyalBlue
        Me.Panel9.Location = New System.Drawing.Point(165, 3)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(26, 5)
        Me.Panel9.TabIndex = 7
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.RoyalBlue
        Me.Panel3.Location = New System.Drawing.Point(136, 12)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(52, 5)
        Me.Panel3.TabIndex = 6
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Controls.Add(Me.TitleBar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1028, 663)
        Me.Panel1.TabIndex = 5
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(86, Byte), Integer))
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.PanelChildForm, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 25)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1028, 638)
        Me.TableLayoutPanel1.TabIndex = 11
        '
        'PanelChildForm
        '
        Me.PanelChildForm.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.PanelChildForm.Controls.Add(Me.Button2)
        Me.PanelChildForm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelChildForm.Location = New System.Drawing.Point(203, 3)
        Me.PanelChildForm.Name = "PanelChildForm"
        Me.PanelChildForm.Size = New System.Drawing.Size(822, 632)
        Me.PanelChildForm.TabIndex = 7
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.ForeColor = System.Drawing.Color.Red
        Me.Button2.Image = Global.AVT_TRAKING.My.Resources.Resources._exit
        Me.Button2.Location = New System.Drawing.Point(780, 2)
        Me.Button2.Margin = New System.Windows.Forms.Padding(2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(39, 46)
        Me.Button2.TabIndex = 4
        Me.Button2.UseVisualStyleBackColor = True
        '
        'MainFrom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1028, 663)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "MainFrom"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TitleBar.ResumeLayout(False)
        Me.TitleBar.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.pnlButtons.ResumeLayout(False)
        CType(Me.pcbLogoMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel16.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.PanelChildForm.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button2 As Button
    Friend WithEvents TitleBar As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents tbnoOthers As Button
    Friend WithEvents btnMaterials As Button
    Friend WithEvents btnWorkCodes As Button
    Friend WithEvents btnClients As Button
    Friend WithEvents btnEmployees As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PanelChildForm As Panel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Panel3 As Panel
    Public WithEvents pcbLogoMain As PictureBox
    Friend WithEvents Panel10 As Panel
    Friend WithEvents btnReports As Button
    Friend WithEvents btnEstimation As Button
    Friend WithEvents pnlButtons As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel14 As Panel
    Friend WithEvents Panel13 As Panel
    Friend WithEvents Panel11 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel15 As Panel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Panel16 As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Button3 As Button
End Class
