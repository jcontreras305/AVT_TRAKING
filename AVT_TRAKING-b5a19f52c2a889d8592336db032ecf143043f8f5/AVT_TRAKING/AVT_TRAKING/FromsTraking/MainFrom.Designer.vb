﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainFrom
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainFrom))
        Me.TitleBar = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.btnReports = New System.Windows.Forms.Button()
        Me.pcbLogoMain = New System.Windows.Forms.PictureBox()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.tbnoOthers = New System.Windows.Forms.Button()
        Me.btnMaterials = New System.Windows.Forms.Button()
        Me.btnWorkCodes = New System.Windows.Forms.Button()
        Me.btnClients = New System.Windows.Forms.Button()
        Me.btnEmployees = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PanelChildForm = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.btnEstimation = New System.Windows.Forms.Button()
        Me.TitleBar.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.pcbLogoMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.PanelChildForm.SuspendLayout()
        Me.SuspendLayout()
        '
        'TitleBar
        '
        Me.TitleBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.TitleBar.Controls.Add(Me.Label1)
        Me.TitleBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.TitleBar.Location = New System.Drawing.Point(0, 0)
        Me.TitleBar.Name = "TitleBar"
        Me.TitleBar.Size = New System.Drawing.Size(1028, 25)
        Me.TitleBar.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Location = New System.Drawing.Point(3, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 18)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "MainFrom"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(86, Byte), Integer))
        Me.Panel2.Controls.Add(Me.btnEstimation)
        Me.Panel2.Controls.Add(Me.Panel11)
        Me.Panel2.Controls.Add(Me.Panel10)
        Me.Panel2.Controls.Add(Me.btnReports)
        Me.Panel2.Controls.Add(Me.pcbLogoMain)
        Me.Panel2.Controls.Add(Me.Panel9)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.Panel8)
        Me.Panel2.Controls.Add(Me.Panel7)
        Me.Panel2.Controls.Add(Me.Panel6)
        Me.Panel2.Controls.Add(Me.Panel5)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.tbnoOthers)
        Me.Panel2.Controls.Add(Me.btnMaterials)
        Me.Panel2.Controls.Add(Me.btnWorkCodes)
        Me.Panel2.Controls.Add(Me.btnClients)
        Me.Panel2.Controls.Add(Me.btnEmployees)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(194, 611)
        Me.Panel2.TabIndex = 6
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.RoyalBlue
        Me.Panel10.Location = New System.Drawing.Point(0, 397)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(198, 5)
        Me.Panel10.TabIndex = 10
        '
        'btnReports
        '
        Me.btnReports.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnReports.FlatAppearance.BorderSize = 0
        Me.btnReports.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue
        Me.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReports.Font = New System.Drawing.Font("Nirmala UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReports.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnReports.Image = Global.AVT_TRAKING.My.Resources.Resources.reportMenu
        Me.btnReports.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReports.Location = New System.Drawing.Point(1, 405)
        Me.btnReports.Margin = New System.Windows.Forms.Padding(2)
        Me.btnReports.Name = "btnReports"
        Me.btnReports.Size = New System.Drawing.Size(192, 45)
        Me.btnReports.TabIndex = 11
        Me.btnReports.Text = "Reports"
        Me.btnReports.UseVisualStyleBackColor = True
        '
        'pcbLogoMain
        '
        Me.pcbLogoMain.Location = New System.Drawing.Point(3, 3)
        Me.pcbLogoMain.Name = "pcbLogoMain"
        Me.pcbLogoMain.Size = New System.Drawing.Size(188, 98)
        Me.pcbLogoMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pcbLogoMain.TabIndex = 10
        Me.pcbLogoMain.TabStop = False
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.RoyalBlue
        Me.Panel9.Location = New System.Drawing.Point(166, 107)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(26, 5)
        Me.Panel9.TabIndex = 7
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.RoyalBlue
        Me.Panel3.Location = New System.Drawing.Point(141, 115)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(52, 5)
        Me.Panel3.TabIndex = 6
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.RoyalBlue
        Me.Panel8.Location = New System.Drawing.Point(3, 352)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(198, 5)
        Me.Panel8.TabIndex = 9
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.RoyalBlue
        Me.Panel7.Location = New System.Drawing.Point(2, 293)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(198, 5)
        Me.Panel7.TabIndex = 8
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.RoyalBlue
        Me.Panel6.Location = New System.Drawing.Point(3, 238)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(198, 5)
        Me.Panel6.TabIndex = 7
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.RoyalBlue
        Me.Panel5.Location = New System.Drawing.Point(1, 178)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(198, 5)
        Me.Panel5.TabIndex = 6
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.RoyalBlue
        Me.Panel4.Location = New System.Drawing.Point(95, 123)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(104, 5)
        Me.Panel4.TabIndex = 5
        '
        'tbnoOthers
        '
        Me.tbnoOthers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbnoOthers.FlatAppearance.BorderSize = 0
        Me.tbnoOthers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue
        Me.tbnoOthers.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.tbnoOthers.Font = New System.Drawing.Font("Nirmala UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbnoOthers.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbnoOthers.Image = Global.AVT_TRAKING.My.Resources.Resources.options
        Me.tbnoOthers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tbnoOthers.Location = New System.Drawing.Point(0, 354)
        Me.tbnoOthers.Margin = New System.Windows.Forms.Padding(2)
        Me.tbnoOthers.Name = "tbnoOthers"
        Me.tbnoOthers.Size = New System.Drawing.Size(192, 45)
        Me.tbnoOthers.TabIndex = 4
        Me.tbnoOthers.Text = "Others"
        Me.tbnoOthers.UseVisualStyleBackColor = True
        '
        'btnMaterials
        '
        Me.btnMaterials.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMaterials.FlatAppearance.BorderSize = 0
        Me.btnMaterials.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue
        Me.btnMaterials.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMaterials.Font = New System.Drawing.Font("Nirmala UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMaterials.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnMaterials.Image = Global.AVT_TRAKING.My.Resources.Resources.materials
        Me.btnMaterials.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMaterials.Location = New System.Drawing.Point(0, 295)
        Me.btnMaterials.Margin = New System.Windows.Forms.Padding(2)
        Me.btnMaterials.Name = "btnMaterials"
        Me.btnMaterials.Size = New System.Drawing.Size(217, 52)
        Me.btnMaterials.TabIndex = 0
        Me.btnMaterials.Text = "Materials"
        Me.btnMaterials.UseVisualStyleBackColor = True
        '
        'btnWorkCodes
        '
        Me.btnWorkCodes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnWorkCodes.FlatAppearance.BorderSize = 0
        Me.btnWorkCodes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue
        Me.btnWorkCodes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnWorkCodes.Font = New System.Drawing.Font("Nirmala UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWorkCodes.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnWorkCodes.Image = Global.AVT_TRAKING.My.Resources.Resources.code
        Me.btnWorkCodes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnWorkCodes.Location = New System.Drawing.Point(2, 238)
        Me.btnWorkCodes.Margin = New System.Windows.Forms.Padding(2)
        Me.btnWorkCodes.Name = "btnWorkCodes"
        Me.btnWorkCodes.Size = New System.Drawing.Size(226, 58)
        Me.btnWorkCodes.TabIndex = 3
        Me.btnWorkCodes.Text = "Work Codes"
        Me.btnWorkCodes.UseVisualStyleBackColor = True
        '
        'btnClients
        '
        Me.btnClients.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnClients.FlatAppearance.BorderSize = 0
        Me.btnClients.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue
        Me.btnClients.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClients.Font = New System.Drawing.Font("Nirmala UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClients.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnClients.Image = Global.AVT_TRAKING.My.Resources.Resources.crm
        Me.btnClients.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClients.Location = New System.Drawing.Point(-1, 180)
        Me.btnClients.Margin = New System.Windows.Forms.Padding(2)
        Me.btnClients.Name = "btnClients"
        Me.btnClients.Size = New System.Drawing.Size(193, 53)
        Me.btnClients.TabIndex = 1
        Me.btnClients.Text = "Clients"
        Me.btnClients.UseVisualStyleBackColor = True
        '
        'btnEmployees
        '
        Me.btnEmployees.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnEmployees.FlatAppearance.BorderSize = 0
        Me.btnEmployees.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue
        Me.btnEmployees.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEmployees.Font = New System.Drawing.Font("Nirmala UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEmployees.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnEmployees.Image = Global.AVT_TRAKING.My.Resources.Resources.employee
        Me.btnEmployees.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEmployees.Location = New System.Drawing.Point(0, 120)
        Me.btnEmployees.Margin = New System.Windows.Forms.Padding(2)
        Me.btnEmployees.Name = "btnEmployees"
        Me.btnEmployees.Size = New System.Drawing.Size(217, 45)
        Me.btnEmployees.TabIndex = 2
        Me.btnEmployees.Text = "Employees"
        Me.btnEmployees.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Location = New System.Drawing.Point(0, 28)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(197, 611)
        Me.Panel1.TabIndex = 5
        '
        'PanelChildForm
        '
        Me.PanelChildForm.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelChildForm.Controls.Add(Me.Button2)
        Me.PanelChildForm.Location = New System.Drawing.Point(197, 28)
        Me.PanelChildForm.Name = "PanelChildForm"
        Me.PanelChildForm.Size = New System.Drawing.Size(831, 608)
        Me.PanelChildForm.TabIndex = 7
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.ForeColor = System.Drawing.Color.Red
        Me.Button2.Image = Global.AVT_TRAKING.My.Resources.Resources._exit
        Me.Button2.Location = New System.Drawing.Point(789, 2)
        Me.Button2.Margin = New System.Windows.Forms.Padding(2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(39, 46)
        Me.Button2.TabIndex = 4
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.RoyalBlue
        Me.Panel11.Location = New System.Drawing.Point(-1, 452)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(198, 5)
        Me.Panel11.TabIndex = 12
        '
        'btnEstimation
        '
        Me.btnEstimation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnEstimation.FlatAppearance.BorderSize = 0
        Me.btnEstimation.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue
        Me.btnEstimation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEstimation.Font = New System.Drawing.Font("Nirmala UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEstimation.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnEstimation.Image = Global.AVT_TRAKING.My.Resources.Resources.catsemployee
        Me.btnEstimation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEstimation.Location = New System.Drawing.Point(0, 459)
        Me.btnEstimation.Margin = New System.Windows.Forms.Padding(2)
        Me.btnEstimation.Name = "btnEstimation"
        Me.btnEstimation.Size = New System.Drawing.Size(192, 45)
        Me.btnEstimation.TabIndex = 13
        Me.btnEstimation.Text = "    Estimation"
        Me.btnEstimation.UseVisualStyleBackColor = True
        '
        'MainFrom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1028, 639)
        Me.Controls.Add(Me.PanelChildForm)
        Me.Controls.Add(Me.TitleBar)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "MainFrom"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TitleBar.ResumeLayout(False)
        Me.TitleBar.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.pcbLogoMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.PanelChildForm.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button2 As Button
    Friend WithEvents TitleBar As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents tbnoOthers As Button
    Friend WithEvents btnMaterials As Button
    Friend WithEvents btnWorkCodes As Button
    Friend WithEvents btnClients As Button
    Friend WithEvents btnEmployees As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PanelChildForm As Panel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Panel3 As Panel
    Public WithEvents pcbLogoMain As PictureBox
    Friend WithEvents Panel10 As Panel
    Friend WithEvents btnReports As Button
    Friend WithEvents btnEstimation As Button
    Friend WithEvents Panel11 As Panel
End Class