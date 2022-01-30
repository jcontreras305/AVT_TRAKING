<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ReportsMenu
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
        Me.TitleBar = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnRestore = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.btnMaximize = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnClientBilling = New System.Windows.Forms.Button()
        Me.btnActAverage = New System.Windows.Forms.Button()
        Me.btnTimeSheet = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.TitleBar.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnRestore, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnMaximize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TitleBar
        '
        Me.TitleBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.TitleBar.Controls.Add(Me.PictureBox1)
        Me.TitleBar.Controls.Add(Me.Label1)
        Me.TitleBar.Controls.Add(Me.btnRestore)
        Me.TitleBar.Controls.Add(Me.PictureBox2)
        Me.TitleBar.Controls.Add(Me.btnMaximize)
        Me.TitleBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.TitleBar.Location = New System.Drawing.Point(0, 0)
        Me.TitleBar.Name = "TitleBar"
        Me.TitleBar.Size = New System.Drawing.Size(800, 57)
        Me.TitleBar.TabIndex = 1
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.AVT_TRAKING.My.Resources.Resources.repormen
        Me.PictureBox1.Location = New System.Drawing.Point(240, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(49, 44)
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Location = New System.Drawing.Point(295, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 23)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Reports"
        '
        'btnRestore
        '
        Me.btnRestore.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRestore.Image = Global.AVT_TRAKING.My.Resources.Resources.restore2
        Me.btnRestore.Location = New System.Drawing.Point(760, 6)
        Me.btnRestore.Name = "btnRestore"
        Me.btnRestore.Size = New System.Drawing.Size(24, 23)
        Me.btnRestore.TabIndex = 2
        Me.btnRestore.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = Global.AVT_TRAKING.My.Resources.Resources.minimize2
        Me.PictureBox2.Location = New System.Drawing.Point(730, 6)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(24, 26)
        Me.PictureBox2.TabIndex = 1
        Me.PictureBox2.TabStop = False
        '
        'btnMaximize
        '
        Me.btnMaximize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMaximize.Image = Global.AVT_TRAKING.My.Resources.Resources.maximize2
        Me.btnMaximize.Location = New System.Drawing.Point(760, 6)
        Me.btnMaximize.Name = "btnMaximize"
        Me.btnMaximize.Size = New System.Drawing.Size(28, 31)
        Me.btnMaximize.TabIndex = 0
        Me.btnMaximize.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Button4)
        Me.Panel2.Controls.Add(Me.Button3)
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.btnClientBilling)
        Me.Panel2.Controls.Add(Me.btnActAverage)
        Me.Panel2.Controls.Add(Me.btnTimeSheet)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 57)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(206, 393)
        Me.Panel2.TabIndex = 2
        '
        'Button4
        '
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button4.Image = Global.AVT_TRAKING.My.Resources.Resources.ComplteByRange
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.Location = New System.Drawing.Point(3, 289)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(200, 42)
        Me.Button4.TabIndex = 6
        Me.Button4.Text = "Comp By Date Range"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button3.Image = Global.AVT_TRAKING.My.Resources.Resources.ReCap
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(0, 241)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(203, 42)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "Client Billings Re-Cap"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button2.Image = Global.AVT_TRAKING.My.Resources.Resources.scaffoldestimate
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(6, 339)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(200, 42)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Scaffold Estimate"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button1.Image = Global.AVT_TRAKING.My.Resources.Resources.catsemployee
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(0, 183)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(200, 42)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Cats Employee"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnClientBilling
        '
        Me.btnClientBilling.FlatAppearance.BorderSize = 0
        Me.btnClientBilling.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.btnClientBilling.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClientBilling.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClientBilling.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnClientBilling.Image = Global.AVT_TRAKING.My.Resources.Resources.billing
        Me.btnClientBilling.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClientBilling.Location = New System.Drawing.Point(3, 124)
        Me.btnClientBilling.Name = "btnClientBilling"
        Me.btnClientBilling.Size = New System.Drawing.Size(200, 42)
        Me.btnClientBilling.TabIndex = 2
        Me.btnClientBilling.Text = "Client Billings"
        Me.btnClientBilling.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClientBilling.UseVisualStyleBackColor = True
        '
        'btnActAverage
        '
        Me.btnActAverage.FlatAppearance.BorderSize = 0
        Me.btnActAverage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.btnActAverage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnActAverage.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActAverage.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnActAverage.Image = Global.AVT_TRAKING.My.Resources.Resources.average
        Me.btnActAverage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnActAverage.Location = New System.Drawing.Point(0, 65)
        Me.btnActAverage.Name = "btnActAverage"
        Me.btnActAverage.Size = New System.Drawing.Size(200, 42)
        Me.btnActAverage.TabIndex = 1
        Me.btnActAverage.Text = "Active Average"
        Me.btnActAverage.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnActAverage.UseVisualStyleBackColor = True
        '
        'btnTimeSheet
        '
        Me.btnTimeSheet.FlatAppearance.BorderSize = 0
        Me.btnTimeSheet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.btnTimeSheet.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTimeSheet.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTimeSheet.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnTimeSheet.Image = Global.AVT_TRAKING.My.Resources.Resources.timesheetreport
        Me.btnTimeSheet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTimeSheet.Location = New System.Drawing.Point(3, 6)
        Me.btnTimeSheet.Name = "btnTimeSheet"
        Me.btnTimeSheet.Size = New System.Drawing.Size(200, 42)
        Me.btnTimeSheet.TabIndex = 0
        Me.btnTimeSheet.Text = "Time Sheet"
        Me.btnTimeSheet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTimeSheet.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Panel1)
        Me.Panel3.Controls.Add(Me.PictureBox4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(206, 57)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(594, 393)
        Me.Panel3.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Button11)
        Me.Panel1.Controls.Add(Me.Button10)
        Me.Panel1.Controls.Add(Me.Button9)
        Me.Panel1.Controls.Add(Me.Button8)
        Me.Panel1.Controls.Add(Me.Button7)
        Me.Panel1.Controls.Add(Me.Button6)
        Me.Panel1.Controls.Add(Me.Button5)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(206, 393)
        Me.Panel1.TabIndex = 4
        '
        'Button10
        '
        Me.Button10.FlatAppearance.BorderSize = 0
        Me.Button10.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button10.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button10.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button10.Image = Global.AVT_TRAKING.My.Resources.Resources.billing
        Me.Button10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button10.Location = New System.Drawing.Point(6, 271)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(200, 42)
        Me.Button10.TabIndex = 12
        Me.Button10.Text = "Year Final Hours"
        Me.Button10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.FlatAppearance.BorderSize = 0
        Me.Button9.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button9.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button9.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button9.Image = Global.AVT_TRAKING.My.Resources.Resources.billing
        Me.Button9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button9.Location = New System.Drawing.Point(3, 223)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(200, 42)
        Me.Button9.TabIndex = 11
        Me.Button9.Text = "Hours Per Week"
        Me.Button9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.FlatAppearance.BorderSize = 0
        Me.Button8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button8.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button8.Image = Global.AVT_TRAKING.My.Resources.Resources.billing
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button8.Location = New System.Drawing.Point(3, 175)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(200, 42)
        Me.Button8.TabIndex = 10
        Me.Button8.Text = "All Jobs"
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.FlatAppearance.BorderSize = 0
        Me.Button7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button7.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button7.Image = Global.AVT_TRAKING.My.Resources.Resources.byjobnumt
        Me.Button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button7.Location = New System.Drawing.Point(6, 124)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(200, 42)
        Me.Button7.TabIndex = 9
        Me.Button7.Text = "By Job Number"
        Me.Button7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.FlatAppearance.BorderSize = 0
        Me.Button6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button6.Image = Global.AVT_TRAKING.My.Resources.Resources.scaffoldestimate
        Me.Button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button6.Location = New System.Drawing.Point(6, 65)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(200, 42)
        Me.Button6.TabIndex = 8
        Me.Button6.Text = "Employees Time"
        Me.Button6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.FlatAppearance.BorderSize = 0
        Me.Button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button5.Image = Global.AVT_TRAKING.My.Resources.Resources.scaffoldestimate
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button5.Location = New System.Drawing.Point(3, 6)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(200, 42)
        Me.Button5.TabIndex = 7
        Me.Button5.Text = "Employee Per Diem"
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button5.UseVisualStyleBackColor = True
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.Image = Global.AVT_TRAKING.My.Resources.Resources._exit
        Me.PictureBox4.Location = New System.Drawing.Point(554, 6)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(37, 34)
        Me.PictureBox4.TabIndex = 3
        Me.PictureBox4.TabStop = False
        '
        'Button11
        '
        Me.Button11.FlatAppearance.BorderSize = 0
        Me.Button11.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button11.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button11.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button11.Image = Global.AVT_TRAKING.My.Resources.Resources.billing
        Me.Button11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button11.Location = New System.Drawing.Point(6, 319)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(200, 42)
        Me.Button11.TabIndex = 13
        Me.Button11.Text = "WO Not Complete"
        Me.Button11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button11.UseVisualStyleBackColor = True
        '
        'ReportsMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.TitleBar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ReportsMenu"
        Me.Text = "ReportsMenu"
        Me.TitleBar.ResumeLayout(False)
        Me.TitleBar.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnRestore, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnMaximize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnTimeSheet As Button
    Friend WithEvents TitleBar As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnRestore As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents btnMaximize As PictureBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnActAverage As Button
    Friend WithEvents btnClientBilling As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents Button9 As Button
    Friend WithEvents Button10 As Button
    Friend WithEvents Button11 As Button
End Class
