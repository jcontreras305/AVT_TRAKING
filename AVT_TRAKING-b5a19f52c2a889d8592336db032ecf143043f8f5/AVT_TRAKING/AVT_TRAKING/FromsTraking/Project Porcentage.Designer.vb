﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Project_Porcentage
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TitleBar = New System.Windows.Forms.Panel()
        Me.btnMaximize = New System.Windows.Forms.PictureBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnUploadExcel = New System.Windows.Forms.Button()
        Me.btnDownloadExcel = New System.Windows.Forms.Button()
        Me.cmbProjectOrder = New System.Windows.Forms.ComboBox()
        Me.cmbJobNo = New System.Windows.Forms.ComboBox()
        Me.cmbClient = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.btnRestore = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.tblProjects = New System.Windows.Forms.DataGridView()
        Me.idAux = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Errors = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClientNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JobNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProjectNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WorkOrder = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Percentage = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmPhase = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmProjectManager = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmEstTotalBilling = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.pgbComplete = New System.Windows.Forms.ProgressBar()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TitleBar.SuspendLayout()
        CType(Me.btnMaximize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnRestore, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.tblProjects, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TitleBar, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 126.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1127, 427)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'TitleBar
        '
        Me.TitleBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.TitleBar.Controls.Add(Me.btnMaximize)
        Me.TitleBar.Controls.Add(Me.btnSave)
        Me.TitleBar.Controls.Add(Me.Label4)
        Me.TitleBar.Controls.Add(Me.Label3)
        Me.TitleBar.Controls.Add(Me.Label1)
        Me.TitleBar.Controls.Add(Me.btnUploadExcel)
        Me.TitleBar.Controls.Add(Me.btnDownloadExcel)
        Me.TitleBar.Controls.Add(Me.cmbProjectOrder)
        Me.TitleBar.Controls.Add(Me.cmbJobNo)
        Me.TitleBar.Controls.Add(Me.cmbClient)
        Me.TitleBar.Controls.Add(Me.Label2)
        Me.TitleBar.Controls.Add(Me.PictureBox4)
        Me.TitleBar.Controls.Add(Me.btnRestore)
        Me.TitleBar.Controls.Add(Me.PictureBox2)
        Me.TitleBar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TitleBar.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TitleBar.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.TitleBar.Location = New System.Drawing.Point(4, 4)
        Me.TitleBar.Margin = New System.Windows.Forms.Padding(4)
        Me.TitleBar.Name = "TitleBar"
        Me.TitleBar.Size = New System.Drawing.Size(1119, 118)
        Me.TitleBar.TabIndex = 0
        '
        'btnMaximize
        '
        Me.btnMaximize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMaximize.Image = Global.AVT_TRAKING.My.Resources.Resources.maximize2
        Me.btnMaximize.Location = New System.Drawing.Point(1081, 0)
        Me.btnMaximize.Margin = New System.Windows.Forms.Padding(4)
        Me.btnMaximize.Name = "btnMaximize"
        Me.btnMaximize.Size = New System.Drawing.Size(35, 38)
        Me.btnMaximize.TabIndex = 1
        Me.btnMaximize.TabStop = False
        '
        'btnSave
        '
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Image = Global.AVT_TRAKING.My.Resources.Resources.save
        Me.btnSave.Location = New System.Drawing.Point(831, 48)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(96, 55)
        Me.btnSave.TabIndex = 25
        Me.btnSave.Text = "Save "
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(249, 48)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(102, 17)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Project Order"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 78)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 17)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Job No."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 48)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 17)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Client"
        '
        'btnUploadExcel
        '
        Me.btnUploadExcel.FlatAppearance.BorderSize = 0
        Me.btnUploadExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUploadExcel.Image = Global.AVT_TRAKING.My.Resources.Resources.excel
        Me.btnUploadExcel.Location = New System.Drawing.Point(692, 41)
        Me.btnUploadExcel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnUploadExcel.Name = "btnUploadExcel"
        Me.btnUploadExcel.Size = New System.Drawing.Size(131, 63)
        Me.btnUploadExcel.TabIndex = 21
        Me.btnUploadExcel.Text = "Update Excel"
        Me.btnUploadExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnUploadExcel.UseVisualStyleBackColor = True
        '
        'btnDownloadExcel
        '
        Me.btnDownloadExcel.FlatAppearance.BorderSize = 0
        Me.btnDownloadExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDownloadExcel.Image = Global.AVT_TRAKING.My.Resources.Resources.excel
        Me.btnDownloadExcel.Location = New System.Drawing.Point(540, 41)
        Me.btnDownloadExcel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDownloadExcel.Name = "btnDownloadExcel"
        Me.btnDownloadExcel.Size = New System.Drawing.Size(144, 63)
        Me.btnDownloadExcel.TabIndex = 20
        Me.btnDownloadExcel.Text = "Download Excel"
        Me.btnDownloadExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDownloadExcel.UseVisualStyleBackColor = True
        '
        'cmbProjectOrder
        '
        Me.cmbProjectOrder.FormattingEnabled = True
        Me.cmbProjectOrder.Location = New System.Drawing.Point(363, 44)
        Me.cmbProjectOrder.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbProjectOrder.Name = "cmbProjectOrder"
        Me.cmbProjectOrder.Size = New System.Drawing.Size(160, 25)
        Me.cmbProjectOrder.TabIndex = 19
        '
        'cmbJobNo
        '
        Me.cmbJobNo.FormattingEnabled = True
        Me.cmbJobNo.Location = New System.Drawing.Point(80, 78)
        Me.cmbJobNo.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbJobNo.Name = "cmbJobNo"
        Me.cmbJobNo.Size = New System.Drawing.Size(160, 25)
        Me.cmbJobNo.TabIndex = 18
        '
        'cmbClient
        '
        Me.cmbClient.FormattingEnabled = True
        Me.cmbClient.Location = New System.Drawing.Point(80, 44)
        Me.cmbClient.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbClient.Name = "cmbClient"
        Me.cmbClient.Size = New System.Drawing.Size(160, 25)
        Me.cmbClient.TabIndex = 17
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 5)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(226, 25)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Porject Percentage"
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.Image = Global.AVT_TRAKING.My.Resources.Resources.minimize2
        Me.PictureBox4.Location = New System.Drawing.Point(1036, 0)
        Me.PictureBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(37, 38)
        Me.PictureBox4.TabIndex = 15
        Me.PictureBox4.TabStop = False
        '
        'btnRestore
        '
        Me.btnRestore.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRestore.Image = Global.AVT_TRAKING.My.Resources.Resources.restore2
        Me.btnRestore.Location = New System.Drawing.Point(1081, 0)
        Me.btnRestore.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRestore.Name = "btnRestore"
        Me.btnRestore.Size = New System.Drawing.Size(33, 30)
        Me.btnRestore.TabIndex = 14
        Me.btnRestore.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = Global.AVT_TRAKING.My.Resources.Resources._exit
        Me.PictureBox2.Location = New System.Drawing.Point(1061, 44)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(53, 38)
        Me.PictureBox2.TabIndex = 13
        Me.PictureBox2.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.tblProjects)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(4, 130)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1119, 256)
        Me.Panel2.TabIndex = 1
        '
        'tblProjects
        '
        Me.tblProjects.AllowUserToAddRows = False
        Me.tblProjects.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblProjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblProjects.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idAux, Me.Errors, Me.ClientNo, Me.JobNo, Me.ProjectNo, Me.WorkOrder, Me.Percentage, Me.clmPhase, Me.clmProjectManager, Me.clmEstTotalBilling})
        Me.tblProjects.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblProjects.Location = New System.Drawing.Point(0, 0)
        Me.tblProjects.Margin = New System.Windows.Forms.Padding(4)
        Me.tblProjects.Name = "tblProjects"
        Me.tblProjects.RowHeadersWidth = 51
        Me.tblProjects.Size = New System.Drawing.Size(1119, 256)
        Me.tblProjects.TabIndex = 0
        '
        'idAux
        '
        Me.idAux.HeaderText = "idAux"
        Me.idAux.MinimumWidth = 6
        Me.idAux.Name = "idAux"
        Me.idAux.Visible = False
        '
        'Errors
        '
        Me.Errors.HeaderText = "Error"
        Me.Errors.MinimumWidth = 6
        Me.Errors.Name = "Errors"
        Me.Errors.Visible = False
        '
        'ClientNo
        '
        Me.ClientNo.HeaderText = "Client No"
        Me.ClientNo.MinimumWidth = 6
        Me.ClientNo.Name = "ClientNo"
        '
        'JobNo
        '
        Me.JobNo.HeaderText = "JobNo"
        Me.JobNo.MinimumWidth = 6
        Me.JobNo.Name = "JobNo"
        '
        'ProjectNo
        '
        Me.ProjectNo.HeaderText = "Project No"
        Me.ProjectNo.MinimumWidth = 6
        Me.ProjectNo.Name = "ProjectNo"
        '
        'WorkOrder
        '
        Me.WorkOrder.HeaderText = "Work Order"
        Me.WorkOrder.MinimumWidth = 6
        Me.WorkOrder.Name = "WorkOrder"
        '
        'Percentage
        '
        Me.Percentage.HeaderText = "Percentage"
        Me.Percentage.MinimumWidth = 6
        Me.Percentage.Name = "Percentage"
        '
        'clmPhase
        '
        Me.clmPhase.HeaderText = "Phase"
        Me.clmPhase.MinimumWidth = 6
        Me.clmPhase.Name = "clmPhase"
        '
        'clmProjectManager
        '
        Me.clmProjectManager.HeaderText = "Project Manager"
        Me.clmProjectManager.MinimumWidth = 6
        Me.clmProjectManager.Name = "clmProjectManager"
        '
        'clmEstTotalBilling
        '
        Me.clmEstTotalBilling.HeaderText = "Est Total Billing"
        Me.clmEstTotalBilling.MinimumWidth = 6
        Me.clmEstTotalBilling.Name = "clmEstTotalBilling"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Panel3.Controls.Add(Me.pgbComplete)
        Me.Panel3.Controls.Add(Me.lblMessage)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel3.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Panel3.Location = New System.Drawing.Point(4, 394)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1119, 29)
        Me.Panel3.TabIndex = 2
        '
        'pgbComplete
        '
        Me.pgbComplete.Dock = System.Windows.Forms.DockStyle.Right
        Me.pgbComplete.Location = New System.Drawing.Point(783, 0)
        Me.pgbComplete.Margin = New System.Windows.Forms.Padding(4)
        Me.pgbComplete.Name = "pgbComplete"
        Me.pgbComplete.Size = New System.Drawing.Size(336, 29)
        Me.pgbComplete.TabIndex = 1
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblMessage.Location = New System.Drawing.Point(0, 0)
        Me.lblMessage.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(74, 17)
        Me.lblMessage.TabIndex = 0
        Me.lblMessage.Text = "Message:"
        '
        'Project_Porcentage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1127, 427)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Project_Porcentage"
        Me.Text = "Project_Porcentage"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TitleBar.ResumeLayout(False)
        Me.TitleBar.PerformLayout()
        CType(Me.btnMaximize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnRestore, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.tblProjects, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TitleBar As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents btnRestore As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents btnMaximize As PictureBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents tblProjects As DataGridView
    Friend WithEvents Panel3 As Panel
    Friend WithEvents pgbComplete As ProgressBar
    Friend WithEvents lblMessage As Label
    Friend WithEvents btnUploadExcel As Button
    Friend WithEvents btnDownloadExcel As Button
    Friend WithEvents cmbProjectOrder As ComboBox
    Friend WithEvents cmbJobNo As ComboBox
    Friend WithEvents cmbClient As ComboBox
    Friend WithEvents btnSave As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents idAux As DataGridViewTextBoxColumn
    Friend WithEvents Errors As DataGridViewTextBoxColumn
    Friend WithEvents ClientNo As DataGridViewTextBoxColumn
    Friend WithEvents JobNo As DataGridViewTextBoxColumn
    Friend WithEvents ProjectNo As DataGridViewTextBoxColumn
    Friend WithEvents WorkOrder As DataGridViewTextBoxColumn
    Friend WithEvents Percentage As DataGridViewTextBoxColumn
    Friend WithEvents clmPhase As DataGridViewTextBoxColumn
    Friend WithEvents clmProjectManager As DataGridViewTextBoxColumn
    Friend WithEvents clmEstTotalBilling As DataGridViewTextBoxColumn
End Class
