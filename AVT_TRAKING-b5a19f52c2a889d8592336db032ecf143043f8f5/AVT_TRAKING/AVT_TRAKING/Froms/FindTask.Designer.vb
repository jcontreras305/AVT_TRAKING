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
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.btnMaximize = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.btnRestore = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cmbElement = New System.Windows.Forms.ComboBox()
        Me.sprElement = New System.Windows.Forms.NumericUpDown()
        Me.dtpElement = New System.Windows.Forms.DateTimePicker()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.txtElement = New System.Windows.Forms.TextBox()
        Me.cmbFindElement = New System.Windows.Forms.ComboBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.btnMaximize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnRestore, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.sprElement, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(478, 144)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label28)
        Me.Panel1.Controls.Add(Me.btnMaximize)
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.btnRestore)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(472, 58)
        Me.Panel1.TabIndex = 0
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label28.Location = New System.Drawing.Point(9, 24)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(113, 18)
        Me.Label28.TabIndex = 45
        Me.Label28.Text = "Find Project"
        '
        'btnMaximize
        '
        Me.btnMaximize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMaximize.Image = Global.AVT_TRAKING.My.Resources.Resources.maximize2
        Me.btnMaximize.Location = New System.Drawing.Point(445, -1)
        Me.btnMaximize.Name = "btnMaximize"
        Me.btnMaximize.Size = New System.Drawing.Size(23, 25)
        Me.btnMaximize.TabIndex = 44
        Me.btnMaximize.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.Image = Global.AVT_TRAKING.My.Resources.Resources._exit
        Me.PictureBox3.Location = New System.Drawing.Point(435, 24)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(34, 31)
        Me.PictureBox3.TabIndex = 43
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = Global.AVT_TRAKING.My.Resources.Resources.minimize2
        Me.PictureBox2.Location = New System.Drawing.Point(413, -3)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(26, 27)
        Me.PictureBox2.TabIndex = 42
        Me.PictureBox2.TabStop = False
        '
        'btnRestore
        '
        Me.btnRestore.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRestore.Image = Global.AVT_TRAKING.My.Resources.Resources.restore2
        Me.btnRestore.Location = New System.Drawing.Point(446, -3)
        Me.btnRestore.Name = "btnRestore"
        Me.btnRestore.Size = New System.Drawing.Size(23, 27)
        Me.btnRestore.TabIndex = 41
        Me.btnRestore.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Panel2.Controls.Add(Me.cmbElement)
        Me.Panel2.Controls.Add(Me.sprElement)
        Me.Panel2.Controls.Add(Me.dtpElement)
        Me.Panel2.Controls.Add(Me.lblMessage)
        Me.Panel2.Controls.Add(Me.btnFind)
        Me.Panel2.Controls.Add(Me.txtElement)
        Me.Panel2.Controls.Add(Me.cmbFindElement)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 67)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(472, 74)
        Me.Panel2.TabIndex = 1
        '
        'cmbElement
        '
        Me.cmbElement.DropDownWidth = 200
        Me.cmbElement.FormattingEnabled = True
        Me.cmbElement.Location = New System.Drawing.Point(219, 40)
        Me.cmbElement.MaxDropDownItems = 10
        Me.cmbElement.Name = "cmbElement"
        Me.cmbElement.Size = New System.Drawing.Size(157, 21)
        Me.cmbElement.TabIndex = 6
        '
        'sprElement
        '
        Me.sprElement.Location = New System.Drawing.Point(318, 40)
        Me.sprElement.Name = "sprElement"
        Me.sprElement.Size = New System.Drawing.Size(157, 20)
        Me.sprElement.TabIndex = 5
        '
        'dtpElement
        '
        Me.dtpElement.CustomFormat = "MM/dd/yyyy"
        Me.dtpElement.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpElement.Location = New System.Drawing.Point(135, 40)
        Me.dtpElement.Name = "dtpElement"
        Me.dtpElement.Size = New System.Drawing.Size(157, 20)
        Me.dtpElement.TabIndex = 4
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblMessage.Location = New System.Drawing.Point(9, 44)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(53, 13)
        Me.lblMessage.TabIndex = 3
        Me.lblMessage.Text = "Message:"
        '
        'btnFind
        '
        Me.btnFind.Location = New System.Drawing.Point(354, 15)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(72, 22)
        Me.btnFind.TabIndex = 2
        Me.btnFind.Text = "Find"
        Me.btnFind.UseVisualStyleBackColor = True
        '
        'txtElement
        '
        Me.txtElement.Location = New System.Drawing.Point(180, 15)
        Me.txtElement.Name = "txtElement"
        Me.txtElement.Size = New System.Drawing.Size(157, 20)
        Me.txtElement.TabIndex = 1
        '
        'cmbFindElement
        '
        Me.cmbFindElement.FormattingEnabled = True
        Me.cmbFindElement.Items.AddRange(New Object() {"Job No", "Client", "Work Order", "Task", "Equipament", "Project Manager", "Client PO", "Project Description", "Est. Total Billing", "Begin Date", "End Date", "Hrs Estamate", "Exp Code", "Account No.", "Complete", "%Complete"})
        Me.cmbFindElement.Location = New System.Drawing.Point(56, 14)
        Me.cmbFindElement.Name = "cmbFindElement"
        Me.cmbFindElement.Size = New System.Drawing.Size(118, 21)
        Me.cmbFindElement.TabIndex = 0
        '
        'FindTask
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(478, 144)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FindTask"
        Me.Text = "FindTask"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.btnMaximize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnRestore, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.sprElement, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnFind As Button
    Friend WithEvents txtElement As TextBox
    Friend WithEvents cmbFindElement As ComboBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents btnRestore As PictureBox
    Friend WithEvents btnMaximize As PictureBox
    Friend WithEvents Label28 As Label
    Friend WithEvents lblMessage As Label
    Friend WithEvents sprElement As NumericUpDown
    Friend WithEvents dtpElement As DateTimePicker
    Friend WithEvents cmbElement As ComboBox
End Class
