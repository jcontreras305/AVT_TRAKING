﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportScaffoldEstimate
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportScaffoldEstimate))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TitleBar = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.btnRestore = New System.Windows.Forms.PictureBox()
        Me.btnMaximize = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chbAllUnit = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnReport = New System.Windows.Forms.Button()
        Me.cmbUnit = New System.Windows.Forms.ComboBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.crvReportScaffoldEstimate = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TitleBar.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnRestore, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnMaximize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TitleBar, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.crvReportScaffoldEstimate, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(915, 603)
        Me.TableLayoutPanel1.TabIndex = 0
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
        Me.TitleBar.Location = New System.Drawing.Point(4, 4)
        Me.TitleBar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TitleBar.Name = "TitleBar"
        Me.TitleBar.Size = New System.Drawing.Size(907, 41)
        Me.TitleBar.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label3.Location = New System.Drawing.Point(53, 7)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(290, 25)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Report Scaffold Estimate"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.AVT_TRAKING.My.Resources.Resources.report
        Me.PictureBox1.Location = New System.Drawing.Point(8, 2)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(37, 34)
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.Image = Global.AVT_TRAKING.My.Resources.Resources.minimize2
        Me.PictureBox3.Location = New System.Drawing.Point(817, 6)
        Me.PictureBox3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(36, 36)
        Me.PictureBox3.TabIndex = 9
        Me.PictureBox3.TabStop = False
        '
        'btnRestore
        '
        Me.btnRestore.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRestore.Image = Global.AVT_TRAKING.My.Resources.Resources.restore2
        Me.btnRestore.Location = New System.Drawing.Point(860, 0)
        Me.btnRestore.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnRestore.Name = "btnRestore"
        Me.btnRestore.Size = New System.Drawing.Size(35, 36)
        Me.btnRestore.TabIndex = 8
        Me.btnRestore.TabStop = False
        '
        'btnMaximize
        '
        Me.btnMaximize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMaximize.Image = Global.AVT_TRAKING.My.Resources.Resources.maximize2
        Me.btnMaximize.Location = New System.Drawing.Point(861, 2)
        Me.btnMaximize.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnMaximize.Name = "btnMaximize"
        Me.btnMaximize.Size = New System.Drawing.Size(41, 36)
        Me.btnMaximize.TabIndex = 7
        Me.btnMaximize.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Panel1.Controls.Add(Me.chbAllUnit)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.btnReport)
        Me.Panel1.Controls.Add(Me.cmbUnit)
        Me.Panel1.Controls.Add(Me.PictureBox4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(4, 53)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(907, 68)
        Me.Panel1.TabIndex = 4
        '
        'chbAllUnit
        '
        Me.chbAllUnit.AutoSize = True
        Me.chbAllUnit.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.chbAllUnit.Location = New System.Drawing.Point(247, 18)
        Me.chbAllUnit.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chbAllUnit.Name = "chbAllUnit"
        Me.chbAllUnit.Size = New System.Drawing.Size(47, 20)
        Me.chbAllUnit.TabIndex = 14
        Me.chbAllUnit.Text = "All "
        Me.chbAllUnit.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label1.Location = New System.Drawing.Point(12, 17)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 16)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Unit"
        '
        'btnReport
        '
        Me.btnReport.FlatAppearance.BorderSize = 0
        Me.btnReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReport.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReport.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnReport.Image = Global.AVT_TRAKING.My.Resources.Resources.reportshow
        Me.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReport.Location = New System.Drawing.Point(349, 7)
        Me.btnReport.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnReport.Name = "btnReport"
        Me.btnReport.Size = New System.Drawing.Size(111, 41)
        Me.btnReport.TabIndex = 12
        Me.btnReport.Text = "Report"
        Me.btnReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnReport.UseVisualStyleBackColor = True
        '
        'cmbUnit
        '
        Me.cmbUnit.FormattingEnabled = True
        Me.cmbUnit.Location = New System.Drawing.Point(61, 14)
        Me.cmbUnit.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbUnit.Name = "cmbUnit"
        Me.cmbUnit.Size = New System.Drawing.Size(175, 24)
        Me.cmbUnit.TabIndex = 11
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.Image = Global.AVT_TRAKING.My.Resources.Resources._exit
        Me.PictureBox4.Location = New System.Drawing.Point(853, 4)
        Me.PictureBox4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(49, 36)
        Me.PictureBox4.TabIndex = 10
        Me.PictureBox4.TabStop = False
        '
        'crvReportScaffoldEstimate
        '
        Me.crvReportScaffoldEstimate.ActiveViewIndex = -1
        Me.crvReportScaffoldEstimate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvReportScaffoldEstimate.Cursor = System.Windows.Forms.Cursors.Default
        Me.crvReportScaffoldEstimate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crvReportScaffoldEstimate.Location = New System.Drawing.Point(4, 129)
        Me.crvReportScaffoldEstimate.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.crvReportScaffoldEstimate.Name = "crvReportScaffoldEstimate"
        Me.crvReportScaffoldEstimate.Size = New System.Drawing.Size(907, 470)
        Me.crvReportScaffoldEstimate.TabIndex = 5
        Me.crvReportScaffoldEstimate.ToolPanelWidth = 267
        '
        'ReportScaffoldEstimate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(915, 603)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "ReportScaffoldEstimate"
        Me.Text = "ScaffoldEstimate"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TitleBar.ResumeLayout(False)
        Me.TitleBar.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnRestore, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnMaximize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TitleBar As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents btnRestore As PictureBox
    Friend WithEvents btnMaximize As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents crvReportScaffoldEstimate As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents cmbUnit As ComboBox
    Friend WithEvents btnReport As Button
    Friend WithEvents chbAllUnit As CheckBox
    Friend WithEvents Label1 As Label
End Class
