﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class editExisting
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lbl_loadTitle = New System.Windows.Forms.Label()
        Me.lbl_website = New System.Windows.Forms.Label()
        Me.lbl_newPage = New System.Windows.Forms.Label()
        Me.txt_webName = New System.Windows.Forms.TextBox()
        Me.txt_newPage = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_load = New System.Windows.Forms.TextBox()
        Me.lbl_loadName = New System.Windows.Forms.Label()
        Me.btn_create = New System.Windows.Forms.Button()
        Me.btn_load = New System.Windows.Forms.Button()
        Me.lbl_mainMenu = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lbl_loadTitle
        '
        Me.lbl_loadTitle.AutoSize = True
        Me.lbl_loadTitle.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_loadTitle.Location = New System.Drawing.Point(191, 28)
        Me.lbl_loadTitle.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lbl_loadTitle.Name = "lbl_loadTitle"
        Me.lbl_loadTitle.Size = New System.Drawing.Size(338, 37)
        Me.lbl_loadTitle.TabIndex = 3
        Me.lbl_loadTitle.Text = "Edit existing website"
        '
        'lbl_website
        '
        Me.lbl_website.AutoSize = True
        Me.lbl_website.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_website.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_website.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lbl_website.Location = New System.Drawing.Point(296, 95)
        Me.lbl_website.Name = "lbl_website"
        Me.lbl_website.Size = New System.Drawing.Size(109, 18)
        Me.lbl_website.TabIndex = 11
        Me.lbl_website.Text = "Website name"
        '
        'lbl_newPage
        '
        Me.lbl_newPage.AutoSize = True
        Me.lbl_newPage.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_newPage.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_newPage.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lbl_newPage.Location = New System.Drawing.Point(174, 204)
        Me.lbl_newPage.Name = "lbl_newPage"
        Me.lbl_newPage.Size = New System.Drawing.Size(122, 18)
        Me.lbl_newPage.TabIndex = 13
        Me.lbl_newPage.Text = "New page name"
        '
        'txt_webName
        '
        Me.txt_webName.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_webName.ForeColor = System.Drawing.SystemColors.InfoText
        Me.txt_webName.Location = New System.Drawing.Point(217, 140)
        Me.txt_webName.Name = "txt_webName"
        Me.txt_webName.Size = New System.Drawing.Size(272, 26)
        Me.txt_webName.TabIndex = 15
        '
        'txt_newPage
        '
        Me.txt_newPage.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_newPage.ForeColor = System.Drawing.SystemColors.InfoText
        Me.txt_newPage.Location = New System.Drawing.Point(149, 250)
        Me.txt_newPage.Name = "txt_newPage"
        Me.txt_newPage.Size = New System.Drawing.Size(179, 26)
        Me.txt_newPage.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label2.Location = New System.Drawing.Point(311, 204)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 18)
        Me.Label2.TabIndex = 17
        '
        'txt_load
        '
        Me.txt_load.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_load.ForeColor = System.Drawing.SystemColors.InfoText
        Me.txt_load.Location = New System.Drawing.Point(394, 250)
        Me.txt_load.Name = "txt_load"
        Me.txt_load.Size = New System.Drawing.Size(179, 26)
        Me.txt_load.TabIndex = 19
        '
        'lbl_loadName
        '
        Me.lbl_loadName.AutoSize = True
        Me.lbl_loadName.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_loadName.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_loadName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lbl_loadName.Location = New System.Drawing.Point(402, 204)
        Me.lbl_loadName.Name = "lbl_loadName"
        Me.lbl_loadName.Size = New System.Drawing.Size(140, 18)
        Me.lbl_loadName.TabIndex = 18
        Me.lbl_loadName.Text = "Page name to load"
        '
        'btn_create
        '
        Me.btn_create.BackColor = System.Drawing.Color.LightBlue
        Me.btn_create.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_create.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_create.Location = New System.Drawing.Point(149, 314)
        Me.btn_create.Name = "btn_create"
        Me.btn_create.Size = New System.Drawing.Size(179, 44)
        Me.btn_create.TabIndex = 20
        Me.btn_create.Text = "Create page"
        Me.btn_create.UseVisualStyleBackColor = False
        '
        'btn_load
        '
        Me.btn_load.BackColor = System.Drawing.Color.LightBlue
        Me.btn_load.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_load.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_load.Location = New System.Drawing.Point(394, 314)
        Me.btn_load.Name = "btn_load"
        Me.btn_load.Size = New System.Drawing.Size(178, 44)
        Me.btn_load.TabIndex = 21
        Me.btn_load.Text = "Load page"
        Me.btn_load.UseVisualStyleBackColor = False
        '
        'lbl_mainMenu
        '
        Me.lbl_mainMenu.AutoSize = True
        Me.lbl_mainMenu.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mainMenu.ForeColor = System.Drawing.Color.SkyBlue
        Me.lbl_mainMenu.Location = New System.Drawing.Point(523, 425)
        Me.lbl_mainMenu.Name = "lbl_mainMenu"
        Me.lbl_mainMenu.Size = New System.Drawing.Size(155, 19)
        Me.lbl_mainMenu.TabIndex = 22
        Me.lbl_mainMenu.Text = "Back to main menu"
        '
        'editExisting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(719, 474)
        Me.Controls.Add(Me.lbl_mainMenu)
        Me.Controls.Add(Me.btn_load)
        Me.Controls.Add(Me.btn_create)
        Me.Controls.Add(Me.txt_load)
        Me.Controls.Add(Me.lbl_loadName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_newPage)
        Me.Controls.Add(Me.txt_webName)
        Me.Controls.Add(Me.lbl_newPage)
        Me.Controls.Add(Me.lbl_website)
        Me.Controls.Add(Me.lbl_loadTitle)
        Me.Name = "editExisting"
        Me.Text = "loadWebsite"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_loadTitle As System.Windows.Forms.Label
    Friend WithEvents lbl_website As System.Windows.Forms.Label
    Friend WithEvents lbl_newPage As System.Windows.Forms.Label
    Friend WithEvents txt_webName As System.Windows.Forms.TextBox
    Friend WithEvents txt_newPage As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_load As System.Windows.Forms.TextBox
    Friend WithEvents lbl_loadName As System.Windows.Forms.Label
    Friend WithEvents btn_create As System.Windows.Forms.Button
    Friend WithEvents btn_load As System.Windows.Forms.Button
    Friend WithEvents lbl_mainMenu As System.Windows.Forms.Label
End Class
