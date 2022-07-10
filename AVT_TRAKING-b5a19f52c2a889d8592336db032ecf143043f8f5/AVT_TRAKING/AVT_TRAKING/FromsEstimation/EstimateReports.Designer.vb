<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EstimateReports
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cmbClient = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbProject = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnPipingBudget = New System.Windows.Forms.Button()
        Me.btnEquipmentBudged = New System.Windows.Forms.Button()
        Me.btnReportsSCFBudget = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnRFIPiping = New System.Windows.Forms.Button()
        Me.btnRFIEq = New System.Windows.Forms.Button()
        Me.btnRFIScf = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
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
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(756, 560)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btnSalir)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(750, 62)
        Me.Panel1.TabIndex = 0
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.FlatAppearance.BorderSize = 0
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.ForeColor = System.Drawing.Color.White
        Me.btnSalir.Image = Global.AVT_TRAKING.My.Resources.Resources._exit
        Me.btnSalir.Location = New System.Drawing.Point(706, 14)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(39, 34)
        Me.btnSalir.TabIndex = 37
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Location = New System.Drawing.Point(9, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 18)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "Reports"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.cmbClient)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.cmbProject)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 71)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(750, 39)
        Me.Panel2.TabIndex = 1
        '
        'cmbClient
        '
        Me.cmbClient.FormattingEnabled = True
        Me.cmbClient.Location = New System.Drawing.Point(60, 10)
        Me.cmbClient.Name = "cmbClient"
        Me.cmbClient.Size = New System.Drawing.Size(109, 21)
        Me.cmbClient.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label3.Location = New System.Drawing.Point(9, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Client:"
        '
        'cmbProject
        '
        Me.cmbProject.FormattingEnabled = True
        Me.cmbProject.Location = New System.Drawing.Point(251, 10)
        Me.cmbProject.Name = "cmbProject"
        Me.cmbProject.Size = New System.Drawing.Size(140, 21)
        Me.cmbProject.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label2.Location = New System.Drawing.Point(175, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Project ID:"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 190.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 156.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Panel4, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel3, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 116)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(750, 441)
        Me.TableLayoutPanel2.TabIndex = 2
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnPipingBudget)
        Me.Panel3.Controls.Add(Me.btnEquipmentBudged)
        Me.Panel3.Controls.Add(Me.btnReportsSCFBudget)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(184, 435)
        Me.Panel3.TabIndex = 8
        '
        'btnPipingBudget
        '
        Me.btnPipingBudget.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnPipingBudget.FlatAppearance.BorderSize = 0
        Me.btnPipingBudget.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.btnPipingBudget.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPipingBudget.Font = New System.Drawing.Font("Nirmala UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPipingBudget.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnPipingBudget.Image = Global.AVT_TRAKING.My.Resources.Resources.report
        Me.btnPipingBudget.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPipingBudget.Location = New System.Drawing.Point(0, 120)
        Me.btnPipingBudget.Name = "btnPipingBudget"
        Me.btnPipingBudget.Size = New System.Drawing.Size(184, 60)
        Me.btnPipingBudget.TabIndex = 39
        Me.btnPipingBudget.Text = "Job No. Pipe Budget"
        Me.btnPipingBudget.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPipingBudget.UseVisualStyleBackColor = True
        '
        'btnEquipmentBudged
        '
        Me.btnEquipmentBudged.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnEquipmentBudged.FlatAppearance.BorderSize = 0
        Me.btnEquipmentBudged.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.btnEquipmentBudged.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEquipmentBudged.Font = New System.Drawing.Font("Nirmala UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEquipmentBudged.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnEquipmentBudged.Image = Global.AVT_TRAKING.My.Resources.Resources.report
        Me.btnEquipmentBudged.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEquipmentBudged.Location = New System.Drawing.Point(0, 60)
        Me.btnEquipmentBudged.Name = "btnEquipmentBudged"
        Me.btnEquipmentBudged.Size = New System.Drawing.Size(184, 60)
        Me.btnEquipmentBudged.TabIndex = 38
        Me.btnEquipmentBudged.Text = "Job No. Eq. Budget"
        Me.btnEquipmentBudged.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEquipmentBudged.UseVisualStyleBackColor = True
        '
        'btnReportsSCFBudget
        '
        Me.btnReportsSCFBudget.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnReportsSCFBudget.FlatAppearance.BorderSize = 0
        Me.btnReportsSCFBudget.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.btnReportsSCFBudget.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReportsSCFBudget.Font = New System.Drawing.Font("Nirmala UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReportsSCFBudget.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnReportsSCFBudget.Image = Global.AVT_TRAKING.My.Resources.Resources.report
        Me.btnReportsSCFBudget.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReportsSCFBudget.Location = New System.Drawing.Point(0, 0)
        Me.btnReportsSCFBudget.Name = "btnReportsSCFBudget"
        Me.btnReportsSCFBudget.Size = New System.Drawing.Size(184, 60)
        Me.btnReportsSCFBudget.TabIndex = 7
        Me.btnReportsSCFBudget.Text = "Job No. SCF Budget"
        Me.btnReportsSCFBudget.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnReportsSCFBudget.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnRFIPiping)
        Me.Panel4.Controls.Add(Me.btnRFIEq)
        Me.Panel4.Controls.Add(Me.btnRFIScf)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(193, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(150, 435)
        Me.Panel4.TabIndex = 9
        '
        'btnRFIPiping
        '
        Me.btnRFIPiping.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnRFIPiping.FlatAppearance.BorderSize = 0
        Me.btnRFIPiping.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.btnRFIPiping.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRFIPiping.Font = New System.Drawing.Font("Nirmala UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRFIPiping.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnRFIPiping.Image = Global.AVT_TRAKING.My.Resources.Resources.report
        Me.btnRFIPiping.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRFIPiping.Location = New System.Drawing.Point(0, 120)
        Me.btnRFIPiping.Name = "btnRFIPiping"
        Me.btnRFIPiping.Size = New System.Drawing.Size(150, 60)
        Me.btnRFIPiping.TabIndex = 39
        Me.btnRFIPiping.Text = "RFI Piping"
        Me.btnRFIPiping.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRFIPiping.UseVisualStyleBackColor = True
        '
        'btnRFIEq
        '
        Me.btnRFIEq.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnRFIEq.FlatAppearance.BorderSize = 0
        Me.btnRFIEq.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.btnRFIEq.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRFIEq.Font = New System.Drawing.Font("Nirmala UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRFIEq.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnRFIEq.Image = Global.AVT_TRAKING.My.Resources.Resources.report
        Me.btnRFIEq.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRFIEq.Location = New System.Drawing.Point(0, 60)
        Me.btnRFIEq.Name = "btnRFIEq"
        Me.btnRFIEq.Size = New System.Drawing.Size(150, 60)
        Me.btnRFIEq.TabIndex = 38
        Me.btnRFIEq.Text = "RFI Equipment"
        Me.btnRFIEq.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRFIEq.UseVisualStyleBackColor = True
        '
        'btnRFIScf
        '
        Me.btnRFIScf.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnRFIScf.FlatAppearance.BorderSize = 0
        Me.btnRFIScf.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.btnRFIScf.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRFIScf.Font = New System.Drawing.Font("Nirmala UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRFIScf.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnRFIScf.Image = Global.AVT_TRAKING.My.Resources.Resources.report
        Me.btnRFIScf.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRFIScf.Location = New System.Drawing.Point(0, 0)
        Me.btnRFIScf.Name = "btnRFIScf"
        Me.btnRFIScf.Size = New System.Drawing.Size(150, 60)
        Me.btnRFIScf.TabIndex = 7
        Me.btnRFIScf.Text = "RFI Scaffold"
        Me.btnRFIScf.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRFIScf.UseVisualStyleBackColor = True
        '
        'EstimateReports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(756, 560)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "EstimateReports"
        Me.Text = "EstimateReports"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnSalir As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents cmbProject As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnPipingBudget As Button
    Friend WithEvents btnEquipmentBudged As Button
    Friend WithEvents btnReportsSCFBudget As Button
    Friend WithEvents cmbClient As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents btnRFIPiping As Button
    Friend WithEvents btnRFIEq As Button
    Friend WithEvents btnRFIScf As Button
End Class
