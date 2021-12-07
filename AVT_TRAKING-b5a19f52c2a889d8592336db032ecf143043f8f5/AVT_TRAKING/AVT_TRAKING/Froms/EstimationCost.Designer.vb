<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EstimationCost
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
        Me.tblEstimationCostSC = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnDeleteEstCost = New System.Windows.Forms.Button()
        Me.btnSaveEstCost = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.PictureBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.tblFactorSC = New System.Windows.Forms.DataGridView()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.tblEstimationCostSC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.tblFactorSC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(861, 352)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'tblEstimationCostSC
        '
        Me.tblEstimationCostSC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblEstimationCostSC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblEstimationCostSC.Location = New System.Drawing.Point(200, 3)
        Me.tblEstimationCostSC.Name = "tblEstimationCostSC"
        Me.tblEstimationCostSC.Size = New System.Drawing.Size(652, 260)
        Me.tblEstimationCostSC.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btnExit)
        Me.Panel1.Controls.Add(Me.btnDeleteEstCost)
        Me.Panel1.Controls.Add(Me.btnSaveEstCost)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(855, 74)
        Me.Panel1.TabIndex = 1
        '
        'btnDeleteEstCost
        '
        Me.btnDeleteEstCost.Location = New System.Drawing.Point(120, 20)
        Me.btnDeleteEstCost.Name = "btnDeleteEstCost"
        Me.btnDeleteEstCost.Size = New System.Drawing.Size(75, 34)
        Me.btnDeleteEstCost.TabIndex = 1
        Me.btnDeleteEstCost.Text = "Delete"
        Me.btnDeleteEstCost.UseVisualStyleBackColor = True
        '
        'btnSaveEstCost
        '
        Me.btnSaveEstCost.Location = New System.Drawing.Point(18, 20)
        Me.btnSaveEstCost.Name = "btnSaveEstCost"
        Me.btnSaveEstCost.Size = New System.Drawing.Size(75, 34)
        Me.btnSaveEstCost.TabIndex = 0
        Me.btnSaveEstCost.Text = "Save"
        Me.btnSaveEstCost.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.Image = Global.AVT_TRAKING.My.Resources.Resources.exit2
        Me.btnExit.Location = New System.Drawing.Point(796, 20)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(34, 34)
        Me.btnExit.TabIndex = 5
        Me.btnExit.TabStop = False
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.04786!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76.95214!))
        Me.TableLayoutPanel2.Controls.Add(Me.tblEstimationCostSC, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.tblFactorSC, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 83)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(855, 266)
        Me.TableLayoutPanel2.TabIndex = 2
        '
        'tblFactorSC
        '
        Me.tblFactorSC.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblFactorSC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblFactorSC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblFactorSC.Location = New System.Drawing.Point(3, 3)
        Me.tblFactorSC.Name = "tblFactorSC"
        Me.tblFactorSC.Size = New System.Drawing.Size(191, 260)
        Me.tblFactorSC.TabIndex = 1
        '
        'EstimationCost
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(861, 352)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "EstimationCost"
        Me.Text = "EstimationCost"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.tblEstimationCostSC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.tblFactorSC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents tblEstimationCostSC As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnDeleteEstCost As Button
    Friend WithEvents btnSaveEstCost As Button
    Friend WithEvents btnExit As PictureBox
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents tblFactorSC As DataGridView
End Class
