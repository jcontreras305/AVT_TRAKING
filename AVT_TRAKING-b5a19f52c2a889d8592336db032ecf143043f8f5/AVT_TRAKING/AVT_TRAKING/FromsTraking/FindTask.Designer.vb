<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FindTask
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
        Me.Label28 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cmbElement = New System.Windows.Forms.ComboBox()
        Me.sprElement = New System.Windows.Forms.NumericUpDown()
        Me.mtpElement = New System.Windows.Forms.MonthCalendar()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.txtElement = New System.Windows.Forms.TextBox()
        Me.cmbFindElement = New System.Windows.Forms.ComboBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TitleBar.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.sprElement, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TitleBar, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(637, 177)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TitleBar
        '
        Me.TitleBar.Controls.Add(Me.Label28)
        Me.TitleBar.Controls.Add(Me.PictureBox3)
        Me.TitleBar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TitleBar.Location = New System.Drawing.Point(5, 5)
        Me.TitleBar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TitleBar.Name = "TitleBar"
        Me.TitleBar.Size = New System.Drawing.Size(627, 55)
        Me.TitleBar.TabIndex = 0
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label28.Location = New System.Drawing.Point(12, 11)
        Me.Label28.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(148, 25)
        Me.Label28.TabIndex = 45
        Me.Label28.Text = "Find Project"
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.Image = Global.AVT_TRAKING.My.Resources.Resources._exit
        Me.PictureBox3.Location = New System.Drawing.Point(577, 11)
        Me.PictureBox3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(45, 38)
        Me.PictureBox3.TabIndex = 43
        Me.PictureBox3.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Panel2.Controls.Add(Me.cmbElement)
        Me.Panel2.Controls.Add(Me.sprElement)
        Me.Panel2.Controls.Add(Me.mtpElement)
        Me.Panel2.Controls.Add(Me.lblMessage)
        Me.Panel2.Controls.Add(Me.btnFind)
        Me.Panel2.Controls.Add(Me.txtElement)
        Me.Panel2.Controls.Add(Me.cmbFindElement)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(5, 69)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(627, 103)
        Me.Panel2.TabIndex = 1
        '
        'cmbElement
        '
        Me.cmbElement.DropDownWidth = 200
        Me.cmbElement.FormattingEnabled = True
        Me.cmbElement.Location = New System.Drawing.Point(140, 54)
        Me.cmbElement.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbElement.MaxDropDownItems = 10
        Me.cmbElement.Name = "cmbElement"
        Me.cmbElement.Size = New System.Drawing.Size(329, 24)
        Me.cmbElement.TabIndex = 6
        '
        'sprElement
        '
        Me.sprElement.Location = New System.Drawing.Point(207, 52)
        Me.sprElement.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.sprElement.Name = "sprElement"
        Me.sprElement.Size = New System.Drawing.Size(331, 22)
        Me.sprElement.TabIndex = 5
        '
        'mtpElement
        '
        Me.mtpElement.Location = New System.Drawing.Point(303, 48)
        Me.mtpElement.Margin = New System.Windows.Forms.Padding(12, 11, 12, 11)
        Me.mtpElement.Name = "mtpElement"
        Me.mtpElement.TabIndex = 7
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblMessage.Location = New System.Drawing.Point(12, 54)
        Me.lblMessage.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(69, 17)
        Me.lblMessage.TabIndex = 3
        Me.lblMessage.Text = "Message:"
        '
        'btnFind
        '
        Me.btnFind.FlatAppearance.BorderSize = 0
        Me.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFind.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnFind.Image = Global.AVT_TRAKING.My.Resources.Resources.loupe
        Me.btnFind.Location = New System.Drawing.Point(520, 14)
        Me.btnFind.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(96, 42)
        Me.btnFind.TabIndex = 2
        Me.btnFind.Text = "Find"
        Me.btnFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnFind.UseVisualStyleBackColor = True
        '
        'txtElement
        '
        Me.txtElement.Location = New System.Drawing.Point(181, 17)
        Me.txtElement.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtElement.Name = "txtElement"
        Me.txtElement.Size = New System.Drawing.Size(329, 22)
        Me.txtElement.TabIndex = 1
        '
        'cmbFindElement
        '
        Me.cmbFindElement.FormattingEnabled = True
        Me.cmbFindElement.Items.AddRange(New Object() {"Job No", "Client", "Work Order", "Task", "Equipament", "Project Manager", "Client PO", "Project Description", "Est. Total Billing", "Begin Date", "End Date", "Hrs Estamate", "Exp Code", "Account No.", "Complete", "%Complete", "postingProject"})
        Me.cmbFindElement.Location = New System.Drawing.Point(16, 17)
        Me.cmbFindElement.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbFindElement.Name = "cmbFindElement"
        Me.cmbFindElement.Size = New System.Drawing.Size(156, 24)
        Me.cmbFindElement.TabIndex = 0
        '
        'FindTask
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(637, 177)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FindTask"
        Me.Text = "FindTask"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TitleBar.ResumeLayout(False)
        Me.TitleBar.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.sprElement, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TitleBar As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnFind As Button
    Friend WithEvents txtElement As TextBox
    Friend WithEvents cmbFindElement As ComboBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents lblMessage As Label
    Friend WithEvents sprElement As NumericUpDown
    Friend WithEvents cmbElement As ComboBox
    Friend WithEvents mtpElement As MonthCalendar
    Friend WithEvents Label28 As Label
End Class
