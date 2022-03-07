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
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel4, 0, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(805, 445)
        Me.TableLayoutPanel1.TabIndex = 0
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
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(799, 74)
        Me.Panel1.TabIndex = 0
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.Image = Global.AVT_TRAKING.My.Resources.Resources.minimize2
        Me.PictureBox3.Location = New System.Drawing.Point(738, 3)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(27, 29)
        Me.PictureBox3.TabIndex = 15
        Me.PictureBox3.TabStop = False
        '
        'btnRestore
        '
        Me.btnRestore.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRestore.Image = Global.AVT_TRAKING.My.Resources.Resources.restore2
        Me.btnRestore.Location = New System.Drawing.Point(768, 0)
        Me.btnRestore.Name = "btnRestore"
        Me.btnRestore.Size = New System.Drawing.Size(26, 29)
        Me.btnRestore.TabIndex = 13
        Me.btnRestore.TabStop = False
        '
        'btnMaximize
        '
        Me.btnMaximize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMaximize.Image = Global.AVT_TRAKING.My.Resources.Resources.maximize2
        Me.btnMaximize.Location = New System.Drawing.Point(768, 3)
        Me.btnMaximize.Name = "btnMaximize"
        Me.btnMaximize.Size = New System.Drawing.Size(31, 29)
        Me.btnMaximize.TabIndex = 12
        Me.btnMaximize.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.Image = Global.AVT_TRAKING.My.Resources.Resources._exit
        Me.PictureBox4.Location = New System.Drawing.Point(761, 40)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(37, 29)
        Me.PictureBox4.TabIndex = 14
        Me.PictureBox4.TabStop = False
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblTitle.Location = New System.Drawing.Point(18, 14)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(285, 18)
        Me.lblTitle.TabIndex = 16
        Me.lblTitle.Text = "Product Inconming or OutGoing"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Panel2.Controls.Add(Me.tblProducts)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 143)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(799, 250)
        Me.Panel2.TabIndex = 1
        '
        'tblProducts
        '
        Me.tblProducts.AllowUserToAddRows = False
        Me.tblProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblProducts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.QTY, Me.ProductID, Me.CostUM, Me.UM, Me.ProductDescription, Me.QTYMax})
        Me.tblProducts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblProducts.Location = New System.Drawing.Point(0, 0)
        Me.tblProducts.Name = "tblProducts"
        Me.tblProducts.Size = New System.Drawing.Size(799, 250)
        Me.tblProducts.TabIndex = 0
        '
        'QTY
        '
        Me.QTY.HeaderText = "QTY"
        Me.QTY.Name = "QTY"
        '
        'ProductID
        '
        Me.ProductID.HeaderText = "Product ID"
        Me.ProductID.Name = "ProductID"
        '
        'CostUM
        '
        Me.CostUM.HeaderText = "$/UM"
        Me.CostUM.Name = "CostUM"
        '
        'UM
        '
        Me.UM.HeaderText = "UM"
        Me.UM.Name = "UM"
        '
        'ProductDescription
        '
        Me.ProductDescription.HeaderText = "Product Description"
        Me.ProductDescription.Name = "ProductDescription"
        '
        'QTYMax
        '
        Me.QTYMax.HeaderText = "QTYMax"
        Me.QTYMax.Name = "QTYMax"
        Me.QTYMax.Visible = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Panel3.Controls.Add(Me.btnUpdateTableSCF)
        Me.Panel3.Controls.Add(Me.btnUpdateExcel)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 83)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(799, 54)
        Me.Panel3.TabIndex = 2
        '
        'btnUpdateTableSCF
        '
        Me.btnUpdateTableSCF.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUpdateTableSCF.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.btnUpdateTableSCF.FlatAppearance.BorderSize = 0
        Me.btnUpdateTableSCF.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.btnUpdateTableSCF.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdateTableSCF.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdateTableSCF.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnUpdateTableSCF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnUpdateTableSCF.Location = New System.Drawing.Point(691, 10)
        Me.btnUpdateTableSCF.Name = "btnUpdateTableSCF"
        Me.btnUpdateTableSCF.Size = New System.Drawing.Size(88, 32)
        Me.btnUpdateTableSCF.TabIndex = 21
        Me.btnUpdateTableSCF.Text = "Update"
        Me.btnUpdateTableSCF.UseVisualStyleBackColor = False
        '
        'btnUpdateExcel
        '
        Me.btnUpdateExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUpdateExcel.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.btnUpdateExcel.FlatAppearance.BorderSize = 0
        Me.btnUpdateExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.btnUpdateExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdateExcel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdateExcel.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnUpdateExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnUpdateExcel.Location = New System.Drawing.Point(573, 10)
        Me.btnUpdateExcel.Name = "btnUpdateExcel"
        Me.btnUpdateExcel.Size = New System.Drawing.Size(93, 32)
        Me.btnUpdateExcel.TabIndex = 20
        Me.btnUpdateExcel.Text = "..."
        Me.btnUpdateExcel.UseVisualStyleBackColor = False
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Panel4.Controls.Add(Me.lblMessage)
        Me.Panel4.Controls.Add(Me.pgbComplete)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 399)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(799, 43)
        Me.Panel4.TabIndex = 3
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblMessage.Location = New System.Drawing.Point(9, 11)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(53, 13)
        Me.lblMessage.TabIndex = 4
        Me.lblMessage.Text = "Message:"
        '
        'pgbComplete
        '
        Me.pgbComplete.Location = New System.Drawing.Point(561, 11)
        Me.pgbComplete.Name = "pgbComplete"
        Me.pgbComplete.Size = New System.Drawing.Size(229, 23)
        Me.pgbComplete.TabIndex = 3
        '
        'ProductSCFExcel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(805, 445)
        Me.Controls.Add(Me.TableLayoutPanel1)
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
    Friend WithEvents QTY As DataGridViewTextBoxColumn
    Friend WithEvents ProductID As DataGridViewTextBoxColumn
    Friend WithEvents CostUM As DataGridViewTextBoxColumn
    Friend WithEvents UM As DataGridViewTextBoxColumn
    Friend WithEvents ProductDescription As DataGridViewTextBoxColumn
    Friend WithEvents QTYMax As DataGridViewTextBoxColumn
End Class
