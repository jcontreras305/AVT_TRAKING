<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportHoursPerWeek
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportHoursPerWeek))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.crvHoursPerWeek = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TitleBar = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.btnRestore = New System.Windows.Forms.PictureBox()
        Me.btnMaximize = New System.Windows.Forms.PictureBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.TitleBar.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnRestore, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnMaximize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(686, 451)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.crvHoursPerWeek)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 113)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(680, 335)
        Me.Panel3.TabIndex = 2
        '
        'crvHoursPerWeek
        '
        Me.crvHoursPerWeek.ActiveViewIndex = -1
        Me.crvHoursPerWeek.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvHoursPerWeek.Cursor = System.Windows.Forms.Cursors.Default
        Me.crvHoursPerWeek.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crvHoursPerWeek.Location = New System.Drawing.Point(0, 0)
        Me.crvHoursPerWeek.Name = "crvHoursPerWeek"
        Me.crvHoursPerWeek.Size = New System.Drawing.Size(680, 335)
        Me.crvHoursPerWeek.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.dtpDate)
        Me.Panel2.Controls.Add(Me.PictureBox4)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 43)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(680, 64)
        Me.Panel2.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button1.Image = Global.AVT_TRAKING.My.Resources.Resources.reportshow
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(210, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(83, 33)
        Me.Button1.TabIndex = 14
        Me.Button1.Text = "Report"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Location = New System.Drawing.Point(9, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 14)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Date:"
        '
        'dtpDate
        '
        Me.dtpDate.CustomFormat = "yyyy/MM/dd"
        Me.dtpDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate.Location = New System.Drawing.Point(57, 3)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(127, 21)
        Me.dtpDate.TabIndex = 10
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.Image = Global.AVT_TRAKING.My.Resources.Resources._exit
        Me.PictureBox4.Location = New System.Drawing.Point(640, 3)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(37, 29)
        Me.PictureBox4.TabIndex = 9
        Me.PictureBox4.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.Panel1.Controls.Add(Me.TitleBar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(680, 34)
        Me.Panel1.TabIndex = 0
        '
        'TitleBar
        '
        Me.TitleBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.TitleBar.Controls.Add(Me.Label3)
        Me.TitleBar.Controls.Add(Me.PictureBox1)
        Me.TitleBar.Controls.Add(Me.PictureBox3)
        Me.TitleBar.Controls.Add(Me.btnRestore)
        Me.TitleBar.Controls.Add(Me.btnMaximize)
        Me.TitleBar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TitleBar.Location = New System.Drawing.Point(0, 0)
        Me.TitleBar.Name = "TitleBar"
        Me.TitleBar.Size = New System.Drawing.Size(680, 34)
        Me.TitleBar.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label3.Location = New System.Drawing.Point(40, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(217, 18)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Report Hours Per Week"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.AVT_TRAKING.My.Resources.Resources.report
        Me.PictureBox1.Location = New System.Drawing.Point(6, 2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(28, 28)
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.Image = Global.AVT_TRAKING.My.Resources.Resources.minimize2
        Me.PictureBox3.Location = New System.Drawing.Point(613, 5)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(27, 29)
        Me.PictureBox3.TabIndex = 9
        Me.PictureBox3.TabStop = False
        '
        'btnRestore
        '
        Me.btnRestore.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRestore.Image = Global.AVT_TRAKING.My.Resources.Resources.restore2
        Me.btnRestore.Location = New System.Drawing.Point(645, 0)
        Me.btnRestore.Name = "btnRestore"
        Me.btnRestore.Size = New System.Drawing.Size(26, 29)
        Me.btnRestore.TabIndex = 8
        Me.btnRestore.TabStop = False
        '
        'btnMaximize
        '
        Me.btnMaximize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMaximize.Image = Global.AVT_TRAKING.My.Resources.Resources.maximize2
        Me.btnMaximize.Location = New System.Drawing.Point(646, 2)
        Me.btnMaximize.Name = "btnMaximize"
        Me.btnMaximize.Size = New System.Drawing.Size(31, 29)
        Me.btnMaximize.TabIndex = 7
        Me.btnMaximize.TabStop = False
        '
        'ReportHoursPerWeek
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(686, 451)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ReportHoursPerWeek"
        Me.Text = "ReportHoursPerWeek"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.TitleBar.ResumeLayout(False)
        Me.TitleBar.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnRestore, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnMaximize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents crvHoursPerWeek As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpDate As DateTimePicker
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TitleBar As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents btnRestore As PictureBox
    Friend WithEvents btnMaximize As PictureBox
End Class
