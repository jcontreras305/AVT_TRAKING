<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RowEqDrawing
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
        Me.lytMain = New System.Windows.Forms.TableLayoutPanel()
        Me.txtIdEquipment = New System.Windows.Forms.TextBox()
        Me.btnRow = New System.Windows.Forms.Button()
        Me.lytLaborRates = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.txtBevel = New System.Windows.Forms.TextBox()
        Me.txtSqrFtII = New System.Windows.Forms.TextBox()
        Me.txtCutout = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.txtSqrFtPnt = New System.Windows.Forms.TextBox()
        Me.chbACM = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.txtSqrFtRmv = New System.Windows.Forms.TextBox()
        Me.txtThick = New System.Windows.Forms.TextBox()
        Me.txtEqDescription = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chbRemIns = New System.Windows.Forms.CheckBox()
        Me.cmbLaborRateII = New AVT_TRAKING.MyComboBox()
        Me.cmbLaborRatePnt = New AVT_TRAKING.MyComboBox()
        Me.cmbLaborRateRmv = New AVT_TRAKING.MyComboBox()
        Me.cmbJkt = New AVT_TRAKING.MyComboBox()
        Me.cmbInstType = New AVT_TRAKING.MyComboBox()
        Me.cmbPaintOption = New AVT_TRAKING.MyComboBox()
        Me.cmbSystem = New AVT_TRAKING.MyComboBox()
        Me.cmbHeight = New AVT_TRAKING.MyComboBox()
        Me.lytMain.SuspendLayout()
        Me.lytLaborRates.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lytMain
        '
        Me.lytMain.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.lytMain.ColumnCount = 11
        Me.lytMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.lytMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.737182!))
        Me.lytMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.17276!))
        Me.lytMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.70303!))
        Me.lytMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.40269!))
        Me.lytMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.15315!))
        Me.lytMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.58087!))
        Me.lytMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.246875!))
        Me.lytMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.71951!))
        Me.lytMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.283928!))
        Me.lytMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 332.0!))
        Me.lytMain.Controls.Add(Me.txtIdEquipment, 1, 0)
        Me.lytMain.Controls.Add(Me.btnRow, 0, 0)
        Me.lytMain.Controls.Add(Me.lytLaborRates, 10, 0)
        Me.lytMain.Controls.Add(Me.txtThick, 7, 0)
        Me.lytMain.Controls.Add(Me.cmbJkt, 8, 0)
        Me.lytMain.Controls.Add(Me.cmbInstType, 6, 0)
        Me.lytMain.Controls.Add(Me.cmbPaintOption, 5, 0)
        Me.lytMain.Controls.Add(Me.cmbSystem, 4, 0)
        Me.lytMain.Controls.Add(Me.cmbHeight, 3, 0)
        Me.lytMain.Controls.Add(Me.txtEqDescription, 2, 0)
        Me.lytMain.Controls.Add(Me.Panel1, 9, 0)
        Me.lytMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lytMain.Location = New System.Drawing.Point(0, 0)
        Me.lytMain.Name = "lytMain"
        Me.lytMain.RowCount = 1
        Me.lytMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.lytMain.Size = New System.Drawing.Size(934, 135)
        Me.lytMain.TabIndex = 0
        '
        'txtIdEquipment
        '
        Me.txtIdEquipment.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtIdEquipment.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtIdEquipment.Location = New System.Drawing.Point(27, 4)
        Me.txtIdEquipment.Multiline = True
        Me.txtIdEquipment.Name = "txtIdEquipment"
        Me.txtIdEquipment.Size = New System.Drawing.Size(37, 127)
        Me.txtIdEquipment.TabIndex = 2
        Me.txtIdEquipment.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnRow
        '
        Me.btnRow.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnRow.FlatAppearance.BorderSize = 0
        Me.btnRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRow.Location = New System.Drawing.Point(2, 2)
        Me.btnRow.Margin = New System.Windows.Forms.Padding(1)
        Me.btnRow.Name = "btnRow"
        Me.btnRow.Size = New System.Drawing.Size(20, 131)
        Me.btnRow.TabIndex = 1
        Me.btnRow.Text = ">"
        Me.btnRow.UseVisualStyleBackColor = True
        '
        'lytLaborRates
        '
        Me.lytLaborRates.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset
        Me.lytLaborRates.ColumnCount = 1
        Me.lytLaborRates.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.lytLaborRates.Controls.Add(Me.GroupBox3, 0, 2)
        Me.lytLaborRates.Controls.Add(Me.GroupBox2, 0, 1)
        Me.lytLaborRates.Controls.Add(Me.GroupBox1, 0, 0)
        Me.lytLaborRates.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lytLaborRates.Location = New System.Drawing.Point(600, 4)
        Me.lytLaborRates.Name = "lytLaborRates"
        Me.lytLaborRates.RowCount = 3
        Me.lytLaborRates.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.lytLaborRates.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.lytLaborRates.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.lytLaborRates.Size = New System.Drawing.Size(330, 127)
        Me.lytLaborRates.TabIndex = 11
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TableLayoutPanel5)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.25!)
        Me.GroupBox3.Location = New System.Drawing.Point(5, 87)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(1)
        Me.GroupBox3.Size = New System.Drawing.Size(320, 35)
        Me.GroupBox3.TabIndex = 19
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Insulation Instalation"
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 4
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.txtBevel, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.txtSqrFtII, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.txtCutout, 1, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.cmbLaborRateII, 0, 0)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(1, 11)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 1
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(318, 23)
        Me.TableLayoutPanel5.TabIndex = 20
        '
        'txtBevel
        '
        Me.txtBevel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBevel.Location = New System.Drawing.Point(161, 3)
        Me.txtBevel.Multiline = True
        Me.txtBevel.Name = "txtBevel"
        Me.txtBevel.Size = New System.Drawing.Size(73, 17)
        Me.txtBevel.TabIndex = 23
        Me.txtBevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtSqrFtII
        '
        Me.txtSqrFtII.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSqrFtII.Location = New System.Drawing.Point(82, 3)
        Me.txtSqrFtII.Multiline = True
        Me.txtSqrFtII.Name = "txtSqrFtII"
        Me.txtSqrFtII.Size = New System.Drawing.Size(73, 17)
        Me.txtSqrFtII.TabIndex = 22
        Me.txtSqrFtII.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCutout
        '
        Me.txtCutout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCutout.Location = New System.Drawing.Point(240, 3)
        Me.txtCutout.Multiline = True
        Me.txtCutout.Name = "txtCutout"
        Me.txtCutout.Size = New System.Drawing.Size(75, 17)
        Me.txtCutout.TabIndex = 24
        Me.txtCutout.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TableLayoutPanel4)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.25!)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 46)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Size = New System.Drawing.Size(320, 33)
        Me.GroupBox2.TabIndex = 15
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Paint"
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 4
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.txtSqrFtPnt, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.cmbLaborRatePnt, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.chbACM, 3, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(2, 12)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(316, 19)
        Me.TableLayoutPanel4.TabIndex = 16
        '
        'txtSqrFtPnt
        '
        Me.txtSqrFtPnt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSqrFtPnt.Location = New System.Drawing.Point(82, 3)
        Me.txtSqrFtPnt.Multiline = True
        Me.txtSqrFtPnt.Name = "txtSqrFtPnt"
        Me.txtSqrFtPnt.Size = New System.Drawing.Size(73, 13)
        Me.txtSqrFtPnt.TabIndex = 18
        Me.txtSqrFtPnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chbACM
        '
        Me.chbACM.AutoSize = True
        Me.chbACM.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chbACM.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbACM.Location = New System.Drawing.Point(240, 3)
        Me.chbACM.Name = "chbACM"
        Me.chbACM.Size = New System.Drawing.Size(73, 13)
        Me.chbACM.TabIndex = 15
        Me.chbACM.Text = "ACM"
        Me.chbACM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chbACM.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel3)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.25!)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(1)
        Me.GroupBox1.Size = New System.Drawing.Size(320, 33)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Insulation Removal"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 4
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.txtSqrFtRmv, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.cmbLaborRateRmv, 0, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(1, 11)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(318, 21)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'txtSqrFtRmv
        '
        Me.txtSqrFtRmv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSqrFtRmv.Location = New System.Drawing.Point(82, 3)
        Me.txtSqrFtRmv.Multiline = True
        Me.txtSqrFtRmv.Name = "txtSqrFtRmv"
        Me.txtSqrFtRmv.Size = New System.Drawing.Size(73, 15)
        Me.txtSqrFtRmv.TabIndex = 14
        Me.txtSqrFtRmv.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtThick
        '
        Me.txtThick.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtThick.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtThick.Location = New System.Drawing.Point(432, 4)
        Me.txtThick.Multiline = True
        Me.txtThick.Name = "txtThick"
        Me.txtThick.Size = New System.Drawing.Size(46, 127)
        Me.txtThick.TabIndex = 8
        Me.txtThick.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtEqDescription
        '
        Me.txtEqDescription.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtEqDescription.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtEqDescription.Location = New System.Drawing.Point(71, 4)
        Me.txtEqDescription.Multiline = True
        Me.txtEqDescription.Name = "txtEqDescription"
        Me.txtEqDescription.Size = New System.Drawing.Size(91, 127)
        Me.txtEqDescription.TabIndex = 3
        Me.txtEqDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.chbRemIns)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(569, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(24, 127)
        Me.Panel1.TabIndex = 9
        '
        'chbRemIns
        '
        Me.chbRemIns.AutoSize = True
        Me.chbRemIns.Location = New System.Drawing.Point(1, 56)
        Me.chbRemIns.Name = "chbRemIns"
        Me.chbRemIns.Size = New System.Drawing.Size(15, 14)
        Me.chbRemIns.TabIndex = 10
        Me.chbRemIns.UseVisualStyleBackColor = True
        '
        'cmbLaborRateII
        '
        Me.cmbLaborRateII.ArrowColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbLaborRateII.ArrowPersonalized = False
        Me.cmbLaborRateII.ArrowStyle = AVT_TRAKING.MyComboBox.enumArrowStyle.Arrow3D
        Me.cmbLaborRateII.BorderColor = System.Drawing.SystemColors.AppWorkspace
        Me.cmbLaborRateII.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbLaborRateII.DropDownWidth = 120
        Me.cmbLaborRateII.FormattingEnabled = True
        Me.cmbLaborRateII.Location = New System.Drawing.Point(3, 3)
        Me.cmbLaborRateII.Name = "cmbLaborRateII"
        Me.cmbLaborRateII.Size = New System.Drawing.Size(73, 21)
        Me.cmbLaborRateII.SizeHeight = 21
        Me.cmbLaborRateII.TabIndex = 21
        '
        'cmbLaborRatePnt
        '
        Me.cmbLaborRatePnt.ArrowColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbLaborRatePnt.ArrowPersonalized = False
        Me.cmbLaborRatePnt.ArrowStyle = AVT_TRAKING.MyComboBox.enumArrowStyle.Arrow3D
        Me.cmbLaborRatePnt.BorderColor = System.Drawing.SystemColors.AppWorkspace
        Me.cmbLaborRatePnt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbLaborRatePnt.DropDownWidth = 120
        Me.cmbLaborRatePnt.FormattingEnabled = True
        Me.cmbLaborRatePnt.Location = New System.Drawing.Point(3, 3)
        Me.cmbLaborRatePnt.Name = "cmbLaborRatePnt"
        Me.cmbLaborRatePnt.Size = New System.Drawing.Size(73, 21)
        Me.cmbLaborRatePnt.SizeHeight = 21
        Me.cmbLaborRatePnt.TabIndex = 17
        '
        'cmbLaborRateRmv
        '
        Me.cmbLaborRateRmv.ArrowColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbLaborRateRmv.ArrowPersonalized = False
        Me.cmbLaborRateRmv.ArrowStyle = AVT_TRAKING.MyComboBox.enumArrowStyle.Arrow3D
        Me.cmbLaborRateRmv.BorderColor = System.Drawing.SystemColors.AppWorkspace
        Me.cmbLaborRateRmv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbLaborRateRmv.DropDownWidth = 120
        Me.cmbLaborRateRmv.FormattingEnabled = True
        Me.cmbLaborRateRmv.Location = New System.Drawing.Point(3, 3)
        Me.cmbLaborRateRmv.Name = "cmbLaborRateRmv"
        Me.cmbLaborRateRmv.Size = New System.Drawing.Size(73, 21)
        Me.cmbLaborRateRmv.SizeHeight = 21
        Me.cmbLaborRateRmv.TabIndex = 13
        '
        'cmbJkt
        '
        Me.cmbJkt.ArrowColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbJkt.ArrowPersonalized = False
        Me.cmbJkt.ArrowStyle = AVT_TRAKING.MyComboBox.enumArrowStyle.Arrow3D
        Me.cmbJkt.BorderColor = System.Drawing.SystemColors.ControlLightLight
        Me.cmbJkt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbJkt.DropDownWidth = 220
        Me.cmbJkt.FormattingEnabled = True
        Me.cmbJkt.Location = New System.Drawing.Point(485, 4)
        Me.cmbJkt.Name = "cmbJkt"
        Me.cmbJkt.Size = New System.Drawing.Size(77, 21)
        Me.cmbJkt.SizeHeight = 21
        Me.cmbJkt.TabIndex = 9
        '
        'cmbInstType
        '
        Me.cmbInstType.ArrowColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbInstType.ArrowPersonalized = False
        Me.cmbInstType.ArrowStyle = AVT_TRAKING.MyComboBox.enumArrowStyle.Arrow3D
        Me.cmbInstType.BorderColor = System.Drawing.SystemColors.ControlLightLight
        Me.cmbInstType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbInstType.DropDownWidth = 120
        Me.cmbInstType.FormattingEnabled = True
        Me.cmbInstType.Location = New System.Drawing.Point(354, 4)
        Me.cmbInstType.Name = "cmbInstType"
        Me.cmbInstType.Size = New System.Drawing.Size(71, 21)
        Me.cmbInstType.SizeHeight = 21
        Me.cmbInstType.TabIndex = 7
        '
        'cmbPaintOption
        '
        Me.cmbPaintOption.ArrowColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbPaintOption.ArrowPersonalized = False
        Me.cmbPaintOption.ArrowStyle = AVT_TRAKING.MyComboBox.enumArrowStyle.Arrow3D
        Me.cmbPaintOption.BorderColor = System.Drawing.SystemColors.ControlLightLight
        Me.cmbPaintOption.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbPaintOption.DropDownWidth = 120
        Me.cmbPaintOption.FormattingEnabled = True
        Me.cmbPaintOption.Location = New System.Drawing.Point(296, 4)
        Me.cmbPaintOption.Name = "cmbPaintOption"
        Me.cmbPaintOption.Size = New System.Drawing.Size(51, 21)
        Me.cmbPaintOption.SizeHeight = 21
        Me.cmbPaintOption.TabIndex = 6
        '
        'cmbSystem
        '
        Me.cmbSystem.ArrowColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbSystem.ArrowPersonalized = False
        Me.cmbSystem.ArrowStyle = AVT_TRAKING.MyComboBox.enumArrowStyle.Arrow3D
        Me.cmbSystem.BorderColor = System.Drawing.SystemColors.ControlLightLight
        Me.cmbSystem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbSystem.DropDownWidth = 120
        Me.cmbSystem.FormattingEnabled = True
        Me.cmbSystem.Location = New System.Drawing.Point(236, 4)
        Me.cmbSystem.Name = "cmbSystem"
        Me.cmbSystem.Size = New System.Drawing.Size(53, 21)
        Me.cmbSystem.SizeHeight = 21
        Me.cmbSystem.TabIndex = 5
        '
        'cmbHeight
        '
        Me.cmbHeight.ArrowColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmbHeight.ArrowPersonalized = False
        Me.cmbHeight.ArrowStyle = AVT_TRAKING.MyComboBox.enumArrowStyle.Arrow3D
        Me.cmbHeight.BorderColor = System.Drawing.SystemColors.ControlLightLight
        Me.cmbHeight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbHeight.FormattingEnabled = True
        Me.cmbHeight.Location = New System.Drawing.Point(169, 4)
        Me.cmbHeight.Name = "cmbHeight"
        Me.cmbHeight.Size = New System.Drawing.Size(60, 21)
        Me.cmbHeight.SizeHeight = 21
        Me.cmbHeight.TabIndex = 4
        '
        'RowEqDrawing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(934, 135)
        Me.Controls.Add(Me.lytMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MinimumSize = New System.Drawing.Size(815, 130)
        Me.Name = "RowEqDrawing"
        Me.Text = "RowEqDrawing"
        Me.lytMain.ResumeLayout(False)
        Me.lytMain.PerformLayout()
        Me.lytLaborRates.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel5.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lytMain As TableLayoutPanel
    Friend WithEvents txtEqDescription As TextBox
    Friend WithEvents cmbHeight As MyComboBox
    Friend WithEvents txtIdEquipment As TextBox
    Friend WithEvents lytLaborRates As TableLayoutPanel
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents TableLayoutPanel5 As TableLayoutPanel
    Friend WithEvents txtBevel As TextBox
    Friend WithEvents txtSqrFtII As TextBox
    Friend WithEvents txtCutout As TextBox
    Friend WithEvents cmbLaborRateII As MyComboBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents txtSqrFtPnt As TextBox
    Friend WithEvents cmbLaborRatePnt As MyComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents txtSqrFtRmv As TextBox
    Friend WithEvents cmbLaborRateRmv As MyComboBox
    Friend WithEvents cmbJkt As MyComboBox
    Friend WithEvents txtThick As TextBox
    Friend WithEvents cmbInstType As MyComboBox
    Friend WithEvents cmbPaintOption As MyComboBox
    Friend WithEvents cmbSystem As MyComboBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents chbRemIns As CheckBox
    Friend WithEvents chbACM As CheckBox
    Friend WithEvents btnRow As Button
End Class
