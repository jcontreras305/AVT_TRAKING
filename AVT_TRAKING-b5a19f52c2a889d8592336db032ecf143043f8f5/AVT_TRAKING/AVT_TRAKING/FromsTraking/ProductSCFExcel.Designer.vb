<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductSCFExcel
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.btnRestore = New System.Windows.Forms.PictureBox()
        Me.btnMaximize = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.tblProducts = New System.Windows.Forms.DataGridView()
        Me.QTY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProductID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CostUM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProductDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QTYMax = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbJobNo = New System.Windows.Forms.ComboBox()
        Me.lblClient = New System.Windows.Forms.Label()
        Me.btnUpdateTableSCF = New System.Windows.Forms.Button()
        Me.btnUpdateExcel = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.pgbComplete = New System.Windows.Forms.ProgressBar()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnRestore, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnMaximize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.tblProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel4, 0, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 98.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 74.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1073, 548)
        Me.TableLayoutPanel1.TabIndex = 0
        Me.TableLayoutPanel1.UseWaitCursor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Controls.Add(Me.btnRestore)
        Me.Panel1.Controls.Add(Me.btnMaximize)
        Me.Panel1.Controls.Add(Me.PictureBox4)
        Me.Panel1.Controls.Add(Me.lblTitle)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(6, 6)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1061, 90)
        Me.Panel1.TabIndex = 0
        Me.Panel1.UseWaitCursor = True
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.Image = Global.AVT_TRAKING.My.Resources.Resources.minimize2
        Me.PictureBox3.Location = New System.Drawing.Point(980, 4)
        Me.PictureBox3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(36, 36)
        Me.PictureBox3.TabIndex = 15
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.UseWaitCursor = True
        '
        'btnRestore
        '
        Me.btnRestore.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRestore.Image = Global.AVT_TRAKING.My.Resources.Resources.restore2
        Me.btnRestore.Location = New System.Drawing.Point(1020, 0)
        Me.btnRestore.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnRestore.Name = "btnRestore"
        Me.btnRestore.Size = New System.Drawing.Size(35, 36)
        Me.btnRestore.TabIndex = 13
        Me.btnRestore.TabStop = False
        Me.btnRestore.UseWaitCursor = True
        '
        'btnMaximize
        '
        Me.btnMaximize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMaximize.Image = Global.AVT_TRAKING.My.Resources.Resources.maximize2
        Me.btnMaximize.Location = New System.Drawing.Point(1020, 4)
        Me.btnMaximize.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnMaximize.Name = "btnMaximize"
        Me.btnMaximize.Size = New System.Drawing.Size(41, 36)
        Me.btnMaximize.TabIndex = 12
        Me.btnMaximize.TabStop = False
        Me.btnMaximize.UseWaitCursor = True
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.Image = Global.AVT_TRAKING.My.Resources.Resources._exit
        Me.PictureBox4.Location = New System.Drawing.Point(1010, 49)
        Me.PictureBox4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(49, 36)
        Me.PictureBox4.TabIndex = 14
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.UseWaitCursor = True
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblTitle.Location = New System.Drawing.Point(24, 17)
        Me.lblTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(371, 25)
        Me.lblTitle.TabIndex = 16
        Me.lblTitle.Text = "Product Inconming or OutGoing"
        Me.lblTitle.UseWaitCursor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Panel2.Controls.Add(Me.tblProducts)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(6, 182)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1061, 298)
        Me.Panel2.TabIndex = 1
        Me.Panel2.UseWaitCursor = True
        '
        'tblProducts
        '
        Me.tblProducts.AllowUserToAddRows = False
        Me.tblProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblProducts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.QTY, Me.ProductID, Me.CostUM, Me.UM, Me.ProductDescription, Me.QTYMax})
        Me.tblProducts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblProducts.Location = New System.Drawing.Point(0, 0)
        Me.tblProducts.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tblProducts.Name = "tblProducts"
        Me.tblProducts.RowHeadersWidth = 51
        Me.tblProducts.Size = New System.Drawing.Size(1061, 298)
        Me.tblProducts.TabIndex = 0
        Me.tblProducts.UseWaitCursor = True
        '
        'QTY
        '
        Me.QTY.HeaderText = "QTY"
        Me.QTY.MinimumWidth = 6
        Me.QTY.Name = "QTY"
        '
        'ProductID
        '
        Me.ProductID.HeaderText = "Product ID"
        Me.ProductID.MinimumWidth = 6
        Me.ProductID.Name = "ProductID"
        Me.ProductID.ReadOnly = True
        '
        'CostUM
        '
        Me.CostUM.HeaderText = "$/UM"
        Me.CostUM.MinimumWidth = 6
        Me.CostUM.Name = "CostUM"
        Me.CostUM.ReadOnly = True
        '
        'UM
        '
        Me.UM.HeaderText = "UM"
        Me.UM.MinimumWidth = 6
        Me.UM.Name = "UM"
        Me.UM.ReadOnly = True
        '
        'ProductDescription
        '
        Me.ProductDescription.HeaderText = "Product Description"
        Me.ProductDescription.MinimumWidth = 6
        Me.ProductDescription.Name = "ProductDescription"
        Me.ProductDescription.ReadOnly = True
        '
        'QTYMax
        '
        Me.QTYMax.HeaderText = "QTYMax"
        Me.QTYMax.MinimumWidth = 6
        Me.QTYMax.Name = "QTYMax"
        Me.QTYMax.ReadOnly = True
        Me.QTYMax.Visible = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.cmbJobNo)
        Me.Panel3.Controls.Add(Me.lblClient)
        Me.Panel3.Controls.Add(Me.btnUpdateTableSCF)
        Me.Panel3.Controls.Add(Me.btnUpdateExcel)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(6, 106)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1061, 66)
        Me.Panel3.TabIndex = 2
        Me.Panel3.UseWaitCursor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Location = New System.Drawing.Point(31, 41)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 17)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Job No:"
        Me.Label1.UseWaitCursor = True
        '
        'cmbJobNo
        '
        Me.cmbJobNo.FormattingEnabled = True
        Me.cmbJobNo.Location = New System.Drawing.Point(105, 37)
        Me.cmbJobNo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbJobNo.Name = "cmbJobNo"
        Me.cmbJobNo.Size = New System.Drawing.Size(201, 24)
        Me.cmbJobNo.TabIndex = 23
        Me.cmbJobNo.UseWaitCursor = True
        '
        'lblClient
        '
        Me.lblClient.AutoSize = True
        Me.lblClient.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClient.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblClient.Location = New System.Drawing.Point(24, 12)
        Me.lblClient.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblClient.Name = "lblClient"
        Me.lblClient.Size = New System.Drawing.Size(71, 20)
        Me.lblClient.TabIndex = 22
        Me.lblClient.Text = "Client:"
        Me.lblClient.UseWaitCursor = True
        '
        'btnUpdateTableSCF
        '
        Me.btnUpdateTableSCF.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUpdateTableSCF.FlatAppearance.BorderSize = 0
        Me.btnUpdateTableSCF.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.btnUpdateTableSCF.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdateTableSCF.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdateTableSCF.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnUpdateTableSCF.Image = Global.AVT_TRAKING.My.Resources.Resources.save1
        Me.btnUpdateTableSCF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnUpdateTableSCF.Location = New System.Drawing.Point(928, 15)
        Me.btnUpdateTableSCF.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnUpdateTableSCF.Name = "btnUpdateTableSCF"
        Me.btnUpdateTableSCF.Size = New System.Drawing.Size(105, 39)
        Me.btnUpdateTableSCF.TabIndex = 21
        Me.btnUpdateTableSCF.Text = "Save"
        Me.btnUpdateTableSCF.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnUpdateTableSCF.UseVisualStyleBackColor = False
        Me.btnUpdateTableSCF.UseWaitCursor = True
        '
        'btnUpdateExcel
        '
        Me.btnUpdateExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUpdateExcel.FlatAppearance.BorderSize = 0
        Me.btnUpdateExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.btnUpdateExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdateExcel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdateExcel.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnUpdateExcel.Image = Global.AVT_TRAKING.My.Resources.Resources.excel
        Me.btnUpdateExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnUpdateExcel.Location = New System.Drawing.Point(789, 15)
        Me.btnUpdateExcel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnUpdateExcel.Name = "btnUpdateExcel"
        Me.btnUpdateExcel.Size = New System.Drawing.Size(108, 44)
        Me.btnUpdateExcel.TabIndex = 20
        Me.btnUpdateExcel.Text = "Find"
        Me.btnUpdateExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnUpdateExcel.UseVisualStyleBackColor = False
        Me.btnUpdateExcel.UseWaitCursor = True
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Panel4.Controls.Add(Me.lblMessage)
        Me.Panel4.Controls.Add(Me.pgbComplete)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(6, 490)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1061, 52)
        Me.Panel4.TabIndex = 3
        Me.Panel4.UseWaitCursor = True
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblMessage.Location = New System.Drawing.Point(12, 14)
        Me.lblMessage.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(69, 17)
        Me.lblMessage.TabIndex = 4
        Me.lblMessage.Text = "Message:"
        Me.lblMessage.UseWaitCursor = True
        '
        'pgbComplete
        '
        Me.pgbComplete.Location = New System.Drawing.Point(748, 14)
        Me.pgbComplete.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pgbComplete.Name = "pgbComplete"
        Me.pgbComplete.Size = New System.Drawing.Size(305, 28)
        Me.pgbComplete.TabIndex = 3
        Me.pgbComplete.UseWaitCursor = True
        '
        'ProductSCFExcel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1073, 548)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "ProductSCFExcel"
        Me.Text = "ProductSCExcel"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnRestore, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnMaximize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.tblProducts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents btnRestore As PictureBox
    Friend WithEvents btnMaximize As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents lblTitle As Label
    Friend WithEvents btnUpdateExcel As Button
    Friend WithEvents tblProducts As DataGridView
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents lblMessage As Label
    Friend WithEvents pgbComplete As ProgressBar
    Friend WithEvents btnUpdateTableSCF As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbJobNo As ComboBox
    Friend WithEvents lblClient As Label
    Friend WithEvents QTY As DataGridViewTextBoxColumn
    Friend WithEvents ProductID As DataGridViewTextBoxColumn
    Friend WithEvents CostUM As DataGridViewTextBoxColumn
    Friend WithEvents UM As DataGridViewTextBoxColumn
    Friend WithEvents ProductDescription As DataGridViewTextBoxColumn
    Friend WithEvents QTYMax As DataGridViewTextBoxColumn
End Class
