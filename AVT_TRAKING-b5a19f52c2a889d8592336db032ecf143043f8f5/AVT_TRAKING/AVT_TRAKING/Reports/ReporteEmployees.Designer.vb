<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReporteEmployees
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReporteEmployees))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.crvTimeSheetEmployee = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.cmbClient = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFinalDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpInitialDate = New System.Windows.Forms.DateTimePicker()
        Me.TitleBar = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.btnRestore = New System.Windows.Forms.PictureBox()
        Me.btnMaximize = New System.Windows.Forms.PictureBox()
        Me.cmbJobs = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chbAllJobs = New System.Windows.Forms.CheckBox()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TitleBar.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnRestore, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnMaximize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(750, 548)
        Me.Panel1.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel4, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TitleBar, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 79.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(750, 548)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.crvTimeSheetEmployee)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 122)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(744, 423)
        Me.Panel4.TabIndex = 2
        '
        'crvTimeSheetEmployee
        '
        Me.crvTimeSheetEmployee.ActiveViewIndex = -1
        Me.crvTimeSheetEmployee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvTimeSheetEmployee.Cursor = System.Windows.Forms.Cursors.Default
        Me.crvTimeSheetEmployee.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crvTimeSheetEmployee.Location = New System.Drawing.Point(0, 0)
        Me.crvTimeSheetEmployee.Name = "crvTimeSheetEmployee"
        Me.crvTimeSheetEmployee.Size = New System.Drawing.Size(744, 423)
        Me.crvTimeSheetEmployee.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.chbAllJobs)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.cmbJobs)
        Me.Panel3.Controls.Add(Me.cmbClient)
        Me.Panel3.Controls.Add(Me.Button1)
        Me.Panel3.Controls.Add(Me.PictureBox4)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.dtpFinalDate)
        Me.Panel3.Controls.Add(Me.dtpInitialDate)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 43)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(744, 73)
        Me.Panel3.TabIndex = 1
        '
        'cmbClient
        '
        Me.cmbClient.FormattingEnabled = True
        Me.cmbClient.Location = New System.Drawing.Point(245, 3)
        Me.cmbClient.Name = "cmbClient"
        Me.cmbClient.Size = New System.Drawing.Size(121, 21)
        Me.cmbClient.TabIndex = 9
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
        Me.Button1.Location = New System.Drawing.Point(454, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(81, 33)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Report"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.Image = Global.AVT_TRAKING.My.Resources.Resources._exit
        Me.PictureBox4.Location = New System.Drawing.Point(704, 3)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(37, 29)
        Me.PictureBox4.TabIndex = 7
        Me.PictureBox4.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label2.Location = New System.Drawing.Point(9, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 14)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Final Date"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Location = New System.Drawing.Point(9, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 14)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Initial Date"
        '
        'dtpFinalDate
        '
        Me.dtpFinalDate.CustomFormat = "yyyy/MM/dd"
        Me.dtpFinalDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFinalDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFinalDate.Location = New System.Drawing.Point(91, 34)
        Me.dtpFinalDate.Name = "dtpFinalDate"
        Me.dtpFinalDate.Size = New System.Drawing.Size(99, 21)
        Me.dtpFinalDate.TabIndex = 1
        '
        'dtpInitialDate
        '
        Me.dtpInitialDate.CustomFormat = "yyyy/MM/dd"
        Me.dtpInitialDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpInitialDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpInitialDate.Location = New System.Drawing.Point(91, 3)
        Me.dtpInitialDate.Name = "dtpInitialDate"
        Me.dtpInitialDate.Size = New System.Drawing.Size(99, 21)
        Me.dtpInitialDate.TabIndex = 0
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
        Me.TitleBar.Location = New System.Drawing.Point(3, 3)
        Me.TitleBar.Name = "TitleBar"
        Me.TitleBar.Size = New System.Drawing.Size(744, 34)
        Me.TitleBar.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label3.Location = New System.Drawing.Point(44, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(159, 18)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Report Employee"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.AVT_TRAKING.My.Resources.Resources.report
        Me.PictureBox1.Location = New System.Drawing.Point(10, 2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(28, 28)
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.Image = Global.AVT_TRAKING.My.Resources.Resources.minimize2
        Me.PictureBox3.Location = New System.Drawing.Point(677, 3)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(27, 29)
        Me.PictureBox3.TabIndex = 6
        Me.PictureBox3.TabStop = False
        '
        'btnRestore
        '
        Me.btnRestore.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRestore.Image = Global.AVT_TRAKING.My.Resources.Resources.restore2
        Me.btnRestore.Location = New System.Drawing.Point(709, 2)
        Me.btnRestore.Name = "btnRestore"
        Me.btnRestore.Size = New System.Drawing.Size(26, 29)
        Me.btnRestore.TabIndex = 5
        Me.btnRestore.TabStop = False
        '
        'btnMaximize
        '
        Me.btnMaximize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMaximize.Image = Global.AVT_TRAKING.My.Resources.Resources.maximize2
        Me.btnMaximize.Location = New System.Drawing.Point(710, 3)
        Me.btnMaximize.Name = "btnMaximize"
        Me.btnMaximize.Size = New System.Drawing.Size(31, 29)
        Me.btnMaximize.TabIndex = 4
        Me.btnMaximize.TabStop = False
        '
        'cmbJobs
        '
        Me.cmbJobs.FormattingEnabled = True
        Me.cmbJobs.Location = New System.Drawing.Point(247, 34)
        Me.cmbJobs.Name = "cmbJobs"
        Me.cmbJobs.Size = New System.Drawing.Size(121, 21)
        Me.cmbJobs.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label4.Location = New System.Drawing.Point(196, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 14)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Client"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label5.Location = New System.Drawing.Point(196, 36)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(28, 14)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Job"
        '
        'chbAllJobs
        '
        Me.chbAllJobs.AutoSize = True
        Me.chbAllJobs.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.chbAllJobs.Location = New System.Drawing.Point(375, 35)
        Me.chbAllJobs.Name = "chbAllJobs"
        Me.chbAllJobs.Size = New System.Drawing.Size(62, 17)
        Me.chbAllJobs.TabIndex = 13
        Me.chbAllJobs.Text = "All Jobs"
        Me.chbAllJobs.UseVisualStyleBackColor = True
        '
        'ReporteEmployees
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(750, 548)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ReporteEmployees"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ReporteEmployees"
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TitleBar.ResumeLayout(False)
        Me.TitleBar.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnRestore, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnMaximize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents TitleBar As Panel
    Friend WithEvents crvTimeSheetEmployee As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpFinalDate As DateTimePicker
    Friend WithEvents dtpInitialDate As DateTimePicker
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents btnRestore As PictureBox
    Friend WithEvents btnMaximize As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents cmbClient As ComboBox
    Friend WithEvents chbAllJobs As CheckBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbJobs As ComboBox
End Class
