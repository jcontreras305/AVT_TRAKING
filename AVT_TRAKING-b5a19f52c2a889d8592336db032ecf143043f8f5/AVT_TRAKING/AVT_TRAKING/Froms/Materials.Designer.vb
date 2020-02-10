<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Materials
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btnMenu = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.txtUM = New System.Windows.Forms.TextBox()
        Me.txtRM = New System.Windows.Forms.TextBox()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.btnQueryDetalleM = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBox16 = New System.Windows.Forms.TextBox()
        Me.txtMprice = New System.Windows.Forms.TextBox()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.txtMTychness = New System.Windows.Forms.TextBox()
        Me.txtMType = New System.Windows.Forms.TextBox()
        Me.txtMSize = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSaveDetallesMaterials = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.txtIdVendor = New System.Windows.Forms.TextBox()
        Me.txtIdRenta = New System.Windows.Forms.TextBox()
        Me.txtNameMaterials = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnQuery = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.txtDMaterial = New System.Windows.Forms.TextBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(185, 374)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 62
        Me.DataGridView1.RowTemplate.Height = 28
        Me.DataGridView1.Size = New System.Drawing.Size(710, 205)
        Me.DataGridView1.TabIndex = 1
        '
        'btnMenu
        '
        Me.btnMenu.Location = New System.Drawing.Point(23, 12)
        Me.btnMenu.Name = "btnMenu"
        Me.btnMenu.Size = New System.Drawing.Size(101, 32)
        Me.btnMenu.TabIndex = 2
        Me.btnMenu.Text = "Menu"
        Me.btnMenu.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.ForeColor = System.Drawing.Color.Red
        Me.Button5.Location = New System.Drawing.Point(1090, 12)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(72, 32)
        Me.Button5.TabIndex = 4
        Me.Button5.Text = "Exit"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.txtDMaterial)
        Me.TabPage2.Controls.Add(Me.txtUM)
        Me.TabPage2.Controls.Add(Me.txtRM)
        Me.TabPage2.Controls.Add(Me.DataGridView2)
        Me.TabPage2.Controls.Add(Me.Button7)
        Me.TabPage2.Controls.Add(Me.btnQueryDetalleM)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.TextBox16)
        Me.TabPage2.Controls.Add(Me.txtMprice)
        Me.TabPage2.Controls.Add(Me.txtCantidad)
        Me.TabPage2.Controls.Add(Me.txtDescripcion)
        Me.TabPage2.Controls.Add(Me.txtMTychness)
        Me.TabPage2.Controls.Add(Me.txtMType)
        Me.TabPage2.Controls.Add(Me.txtMSize)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.btnSaveDetallesMaterials)
        Me.TabPage2.Controls.Add(Me.Label19)
        Me.TabPage2.Controls.Add(Me.Label18)
        Me.TabPage2.Controls.Add(Me.Label17)
        Me.TabPage2.Controls.Add(Me.Label16)
        Me.TabPage2.Controls.Add(Me.Label15)
        Me.TabPage2.Controls.Add(Me.Label14)
        Me.TabPage2.Location = New System.Drawing.Point(4, 29)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1146, 613)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Detalles Materials"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'txtUM
        '
        Me.txtUM.Location = New System.Drawing.Point(186, 189)
        Me.txtUM.Name = "txtUM"
        Me.txtUM.Size = New System.Drawing.Size(132, 26)
        Me.txtUM.TabIndex = 26
        '
        'txtRM
        '
        Me.txtRM.Location = New System.Drawing.Point(186, 112)
        Me.txtRM.Name = "txtRM"
        Me.txtRM.Size = New System.Drawing.Size(132, 26)
        Me.txtRM.TabIndex = 25
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(31, 375)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowHeadersWidth = 62
        Me.DataGridView2.RowTemplate.Height = 28
        Me.DataGridView2.Size = New System.Drawing.Size(1023, 232)
        Me.DataGridView2.TabIndex = 23
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(538, 281)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(79, 37)
        Me.Button7.TabIndex = 22
        Me.Button7.Text = "Update"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'btnQueryDetalleM
        '
        Me.btnQueryDetalleM.Location = New System.Drawing.Point(422, 281)
        Me.btnQueryDetalleM.Name = "btnQueryDetalleM"
        Me.btnQueryDetalleM.Size = New System.Drawing.Size(80, 37)
        Me.btnQueryDetalleM.TabIndex = 21
        Me.btnQueryDetalleM.Text = "Query"
        Me.btnQueryDetalleM.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(776, 337)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 20)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Search"
        '
        'TextBox16
        '
        Me.TextBox16.Location = New System.Drawing.Point(874, 331)
        Me.TextBox16.Name = "TextBox16"
        Me.TextBox16.Size = New System.Drawing.Size(180, 26)
        Me.TextBox16.TabIndex = 19
        '
        'txtMprice
        '
        Me.txtMprice.Location = New System.Drawing.Point(874, 40)
        Me.txtMprice.Name = "txtMprice"
        Me.txtMprice.Size = New System.Drawing.Size(180, 26)
        Me.txtMprice.TabIndex = 18
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(874, 186)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(180, 26)
        Me.txtCantidad.TabIndex = 17
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(874, 109)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(180, 26)
        Me.txtDescripcion.TabIndex = 16
        '
        'txtMTychness
        '
        Me.txtMTychness.Location = New System.Drawing.Point(524, 189)
        Me.txtMTychness.Name = "txtMTychness"
        Me.txtMTychness.Size = New System.Drawing.Size(181, 26)
        Me.txtMTychness.TabIndex = 11
        '
        'txtMType
        '
        Me.txtMType.Location = New System.Drawing.Point(524, 112)
        Me.txtMType.Name = "txtMType"
        Me.txtMType.Size = New System.Drawing.Size(181, 26)
        Me.txtMType.TabIndex = 10
        '
        'txtMSize
        '
        Me.txtMSize.Location = New System.Drawing.Point(524, 37)
        Me.txtMSize.Name = "txtMSize"
        Me.txtMSize.Size = New System.Drawing.Size(181, 26)
        Me.txtMSize.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(776, 192)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 20)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Cantidad"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(776, 115)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 20)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Descripcion"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(776, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 20)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Mprice"
        '
        'btnSaveDetallesMaterials
        '
        Me.btnSaveDetallesMaterials.Location = New System.Drawing.Point(305, 281)
        Me.btnSaveDetallesMaterials.Name = "btnSaveDetallesMaterials"
        Me.btnSaveDetallesMaterials.Size = New System.Drawing.Size(67, 37)
        Me.btnSaveDetallesMaterials.TabIndex = 12
        Me.btnSaveDetallesMaterials.Text = "Save"
        Me.btnSaveDetallesMaterials.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(430, 192)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(88, 20)
        Me.Label19.TabIndex = 8
        Me.Label19.Text = "MTyckness"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(430, 115)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(56, 20)
        Me.Label18.TabIndex = 7
        Me.Label18.Text = "MType"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(430, 43)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(53, 20)
        Me.Label17.TabIndex = 6
        Me.Label17.Text = "MSize"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(27, 192)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(116, 20)
        Me.Label16.TabIndex = 4
        Me.Label16.Text = "Unidad Medida"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(27, 115)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(145, 20)
        Me.Label15.TabIndex = 2
        Me.Label15.Text = "Recursos Materials"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(27, 43)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(65, 20)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Material"
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Button3)
        Me.TabPage1.Controls.Add(Me.txtFiltro)
        Me.TabPage1.Controls.Add(Me.txtIdVendor)
        Me.TabPage1.Controls.Add(Me.DataGridView1)
        Me.TabPage1.Controls.Add(Me.txtIdRenta)
        Me.TabPage1.Controls.Add(Me.txtNameMaterials)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.btnQuery)
        Me.TabPage1.Controls.Add(Me.btnSave)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1146, 613)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Materials"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(546, 286)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(83, 40)
        Me.Button3.TabIndex = 28
        Me.Button3.Text = "Update"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'txtFiltro
        '
        Me.txtFiltro.Location = New System.Drawing.Point(726, 318)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(214, 26)
        Me.txtFiltro.TabIndex = 27
        '
        'txtIdVendor
        '
        Me.txtIdVendor.Location = New System.Drawing.Point(198, 140)
        Me.txtIdVendor.Name = "txtIdVendor"
        Me.txtIdVendor.Size = New System.Drawing.Size(167, 26)
        Me.txtIdVendor.TabIndex = 13
        '
        'txtIdRenta
        '
        Me.txtIdRenta.Location = New System.Drawing.Point(580, 50)
        Me.txtIdRenta.Name = "txtIdRenta"
        Me.txtIdRenta.Size = New System.Drawing.Size(167, 26)
        Me.txtIdRenta.TabIndex = 14
        '
        'txtNameMaterials
        '
        Me.txtNameMaterials.Location = New System.Drawing.Point(198, 47)
        Me.txtNameMaterials.Name = "txtNameMaterials"
        Me.txtNameMaterials.Size = New System.Drawing.Size(167, 26)
        Me.txtNameMaterials.TabIndex = 15
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(946, 318)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(60, 20)
        Me.Label13.TabIndex = 26
        Me.Label13.Text = "Search"
        '
        'btnQuery
        '
        Me.btnQuery.Location = New System.Drawing.Point(441, 286)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(85, 40)
        Me.btnQuery.TabIndex = 25
        Me.btnQuery.Text = "Query"
        Me.btnQuery.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(330, 286)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(81, 40)
        Me.btnSave.TabIndex = 24
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(99, 146)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "IdVendor"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(492, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "IdRenta"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(99, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 20)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Name"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(8, 50)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1154, 646)
        Me.TabControl1.TabIndex = 3
        '
        'txtDMaterial
        '
        Me.txtDMaterial.Location = New System.Drawing.Point(186, 40)
        Me.txtDMaterial.Name = "txtDMaterial"
        Me.txtDMaterial.Size = New System.Drawing.Size(132, 26)
        Me.txtDMaterial.TabIndex = 27
        '
        'Materials
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1174, 708)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnMenu)
        Me.Name = "Materials"
        Me.Text = "Materials"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents btnMenu As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Button7 As Button
    Friend WithEvents btnQueryDetalleM As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents TextBox16 As TextBox
    Friend WithEvents txtMprice As TextBox
    Friend WithEvents txtCantidad As TextBox
    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents txtMTychness As TextBox
    Friend WithEvents txtMType As TextBox
    Friend WithEvents txtMSize As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnSaveDetallesMaterials As Button
    Friend WithEvents Label19 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Button3 As Button
    Friend WithEvents txtFiltro As TextBox
    Friend WithEvents txtIdVendor As TextBox
    Friend WithEvents txtIdRenta As TextBox
    Friend WithEvents txtNameMaterials As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents btnQuery As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents txtUM As TextBox
    Friend WithEvents txtRM As TextBox
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents txtDMaterial As TextBox
End Class
