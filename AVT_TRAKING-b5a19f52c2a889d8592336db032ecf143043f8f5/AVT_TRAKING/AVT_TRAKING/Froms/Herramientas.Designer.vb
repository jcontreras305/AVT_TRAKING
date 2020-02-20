<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Herramientas
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnQueryH = New System.Windows.Forms.Button()
        Me.btnSaveH = New System.Windows.Forms.Button()
        Me.txtRentaH = New System.Windows.Forms.TextBox()
        Me.txtVendor = New System.Windows.Forms.TextBox()
        Me.txtNombreH = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnQuery = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.txtidPricio = New System.Windows.Forms.TextBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.txtHSize = New System.Windows.Forms.TextBox()
        Me.txtHType = New System.Windows.Forms.TextBox()
        Me.txtHTyckness = New System.Windows.Forms.TextBox()
        Me.txtDHerramienta = New System.Windows.Forms.TextBox()
        Me.txtUnidadM = New System.Windows.Forms.TextBox()
        Me.txtRMateriales = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 63)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1072, 547)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btnQueryH)
        Me.TabPage1.Controls.Add(Me.btnSaveH)
        Me.TabPage1.Controls.Add(Me.txtRentaH)
        Me.TabPage1.Controls.Add(Me.txtVendor)
        Me.TabPage1.Controls.Add(Me.txtNombreH)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.DataGridView1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1064, 514)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Herramientas"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'btnQueryH
        '
        Me.btnQueryH.Location = New System.Drawing.Point(328, 283)
        Me.btnQueryH.Name = "btnQueryH"
        Me.btnQueryH.Size = New System.Drawing.Size(75, 34)
        Me.btnQueryH.TabIndex = 8
        Me.btnQueryH.Text = "Query"
        Me.btnQueryH.UseVisualStyleBackColor = True
        '
        'btnSaveH
        '
        Me.btnSaveH.Location = New System.Drawing.Point(212, 283)
        Me.btnSaveH.Name = "btnSaveH"
        Me.btnSaveH.Size = New System.Drawing.Size(78, 34)
        Me.btnSaveH.TabIndex = 7
        Me.btnSaveH.Text = "Save"
        Me.btnSaveH.UseVisualStyleBackColor = True
        '
        'txtRentaH
        '
        Me.txtRentaH.Location = New System.Drawing.Point(541, 54)
        Me.txtRentaH.Name = "txtRentaH"
        Me.txtRentaH.Size = New System.Drawing.Size(148, 26)
        Me.txtRentaH.TabIndex = 6
        '
        'txtVendor
        '
        Me.txtVendor.Location = New System.Drawing.Point(162, 54)
        Me.txtVendor.Name = "txtVendor"
        Me.txtVendor.Size = New System.Drawing.Size(158, 26)
        Me.txtVendor.TabIndex = 5
        '
        'txtNombreH
        '
        Me.txtNombreH.Location = New System.Drawing.Point(162, 154)
        Me.txtNombreH.Name = "txtNombreH"
        Me.txtNombreH.Size = New System.Drawing.Size(158, 26)
        Me.txtNombreH.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(482, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 20)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Renta"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(91, 160)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Nombre"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(87, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Vendor"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(168, 347)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 62
        Me.DataGridView1.RowTemplate.Height = 28
        Me.DataGridView1.Size = New System.Drawing.Size(689, 150)
        Me.DataGridView1.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.txtSearch)
        Me.TabPage2.Controls.Add(Me.Label13)
        Me.TabPage2.Controls.Add(Me.btnUpdate)
        Me.TabPage2.Controls.Add(Me.btnQuery)
        Me.TabPage2.Controls.Add(Me.btnSave)
        Me.TabPage2.Controls.Add(Me.txtCantidad)
        Me.TabPage2.Controls.Add(Me.txtidPricio)
        Me.TabPage2.Controls.Add(Me.txtDescripcion)
        Me.TabPage2.Controls.Add(Me.txtHSize)
        Me.TabPage2.Controls.Add(Me.txtHType)
        Me.TabPage2.Controls.Add(Me.txtHTyckness)
        Me.TabPage2.Controls.Add(Me.txtDHerramienta)
        Me.TabPage2.Controls.Add(Me.txtUnidadM)
        Me.TabPage2.Controls.Add(Me.txtRMateriales)
        Me.TabPage2.Controls.Add(Me.Label12)
        Me.TabPage2.Controls.Add(Me.Label11)
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.DataGridView2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 29)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1064, 514)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "DetallesHerramientas"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(670, 270)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(176, 26)
        Me.txtSearch.TabIndex = 23
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(604, 276)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(60, 20)
        Me.Label13.TabIndex = 22
        Me.Label13.Text = "Search"
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(368, 263)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 33)
        Me.btnUpdate.TabIndex = 21
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnQuery
        '
        Me.btnQuery.Location = New System.Drawing.Point(276, 263)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(71, 33)
        Me.btnQuery.TabIndex = 20
        Me.btnQuery.Text = "Query"
        Me.btnQuery.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(185, 263)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(63, 33)
        Me.btnSave.TabIndex = 19
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(764, 173)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(149, 26)
        Me.txtCantidad.TabIndex = 18
        '
        'txtidPricio
        '
        Me.txtidPricio.Location = New System.Drawing.Point(437, 18)
        Me.txtidPricio.Name = "txtidPricio"
        Me.txtidPricio.Size = New System.Drawing.Size(138, 26)
        Me.txtidPricio.TabIndex = 17
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(764, 96)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(149, 26)
        Me.txtDescripcion.TabIndex = 16
        '
        'txtHSize
        '
        Me.txtHSize.Location = New System.Drawing.Point(437, 96)
        Me.txtHSize.Name = "txtHSize"
        Me.txtHSize.Size = New System.Drawing.Size(138, 26)
        Me.txtHSize.TabIndex = 15
        '
        'txtHType
        '
        Me.txtHType.Location = New System.Drawing.Point(437, 173)
        Me.txtHType.Name = "txtHType"
        Me.txtHType.Size = New System.Drawing.Size(138, 26)
        Me.txtHType.TabIndex = 14
        '
        'txtHTyckness
        '
        Me.txtHTyckness.Location = New System.Drawing.Point(764, 21)
        Me.txtHTyckness.Name = "txtHTyckness"
        Me.txtHTyckness.Size = New System.Drawing.Size(149, 26)
        Me.txtHTyckness.TabIndex = 13
        '
        'txtDHerramienta
        '
        Me.txtDHerramienta.Location = New System.Drawing.Point(178, 21)
        Me.txtDHerramienta.Name = "txtDHerramienta"
        Me.txtDHerramienta.Size = New System.Drawing.Size(134, 26)
        Me.txtDHerramienta.TabIndex = 12
        '
        'txtUnidadM
        '
        Me.txtUnidadM.Location = New System.Drawing.Point(178, 170)
        Me.txtUnidadM.Name = "txtUnidadM"
        Me.txtUnidadM.Size = New System.Drawing.Size(134, 26)
        Me.txtUnidadM.TabIndex = 11
        '
        'txtRMateriales
        '
        Me.txtRMateriales.Location = New System.Drawing.Point(178, 93)
        Me.txtRMateriales.Name = "txtRMateriales"
        Me.txtRMateriales.Size = New System.Drawing.Size(134, 26)
        Me.txtRMateriales.TabIndex = 10
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(666, 176)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(73, 20)
        Me.Label12.TabIndex = 9
        Me.Label12.Text = "Cantidad"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(666, 99)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(92, 20)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "Descripcion"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(344, 27)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 20)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "Precio"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(666, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(87, 20)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "HTyckness"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(344, 176)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(55, 20)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "HType"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(344, 99)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 20)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "HSize"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(22, 176)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 20)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "UnidadM"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(22, 99)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(150, 20)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "RecursosMateriales"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 20)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Herramienta"
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(3, 358)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowHeadersWidth = 62
        Me.DataGridView2.RowTemplate.Height = 28
        Me.DataGridView2.Size = New System.Drawing.Size(1055, 150)
        Me.DataGridView2.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(16, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(101, 35)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "All Tables"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Herramientas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1096, 622)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "Herramientas"
        Me.Text = "Herramientas"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents btnSaveH As Button
    Friend WithEvents txtRentaH As TextBox
    Friend WithEvents txtVendor As TextBox
    Friend WithEvents txtNombreH As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnQueryH As Button
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnQuery As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents txtCantidad As TextBox
    Friend WithEvents txtidPricio As TextBox
    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents txtHSize As TextBox
    Friend WithEvents txtHType As TextBox
    Friend WithEvents txtHTyckness As TextBox
    Friend WithEvents txtDHerramienta As TextBox
    Friend WithEvents txtUnidadM As TextBox
    Friend WithEvents txtRMateriales As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents DataGridView2 As DataGridView
End Class
