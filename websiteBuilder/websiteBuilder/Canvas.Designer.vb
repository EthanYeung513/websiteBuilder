<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Canvas
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
        Me.makePicBoxBtn = New System.Windows.Forms.Button()
        Me.canvasPnl = New System.Windows.Forms.Panel()
        Me.btn_save = New System.Windows.Forms.Button()
        Me.makeParaBtn = New System.Windows.Forms.Button()
        Me.undoBtn = New System.Windows.Forms.Button()
        Me.resizeBtn = New System.Windows.Forms.Button()
        Me.toolboxPnl = New System.Windows.Forms.Panel()
        Me.trashPic = New System.Windows.Forms.PictureBox()
        Me.headSelectorCmb = New System.Windows.Forms.ComboBox()
        Me.makeAnchorButton = New System.Windows.Forms.Button()
        Me.makeHeadingBtn = New System.Windows.Forms.Button()
        Me.colourBtn = New System.Windows.Forms.Button()
        Me.moveBtn = New System.Windows.Forms.Button()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.btn_openBrowser = New System.Windows.Forms.Button()
        Me.lbl_username = New System.Windows.Forms.Label()
        Me.lbl_webName = New System.Windows.Forms.Label()
        Me.lbl_pageName = New System.Windows.Forms.Label()
        Me.lbl_mainMenu = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.toolboxPnl.SuspendLayout()
        CType(Me.trashPic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'makePicBoxBtn
        '
        Me.makePicBoxBtn.Location = New System.Drawing.Point(85, 120)
        Me.makePicBoxBtn.Name = "makePicBoxBtn"
        Me.makePicBoxBtn.Size = New System.Drawing.Size(51, 35)
        Me.makePicBoxBtn.TabIndex = 0
        Me.makePicBoxBtn.Text = "img"
        Me.makePicBoxBtn.UseVisualStyleBackColor = True
        '
        'canvasPnl
        '
        Me.canvasPnl.BackColor = System.Drawing.Color.White
        Me.canvasPnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.canvasPnl.Location = New System.Drawing.Point(295, 66)
        Me.canvasPnl.Name = "canvasPnl"
        Me.canvasPnl.Size = New System.Drawing.Size(1054, 528)
        Me.canvasPnl.TabIndex = 2
        '
        'btn_save
        '
        Me.btn_save.AutoSize = True
        Me.btn_save.BackColor = System.Drawing.Color.LightBlue
        Me.btn_save.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_save.Location = New System.Drawing.Point(1188, 606)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(111, 30)
        Me.btn_save.TabIndex = 3
        Me.btn_save.Text = "Save"
        Me.btn_save.UseVisualStyleBackColor = False
        '
        'makeParaBtn
        '
        Me.makeParaBtn.Location = New System.Drawing.Point(19, 120)
        Me.makeParaBtn.Name = "makeParaBtn"
        Me.makeParaBtn.Size = New System.Drawing.Size(51, 35)
        Me.makeParaBtn.TabIndex = 4
        Me.makeParaBtn.Text = "p"
        Me.makeParaBtn.UseVisualStyleBackColor = True
        '
        'undoBtn
        '
        Me.undoBtn.Location = New System.Drawing.Point(32, 478)
        Me.undoBtn.Name = "undoBtn"
        Me.undoBtn.Size = New System.Drawing.Size(90, 23)
        Me.undoBtn.TabIndex = 0
        Me.undoBtn.Text = "Undo"
        Me.undoBtn.UseVisualStyleBackColor = True
        '
        'resizeBtn
        '
        Me.resizeBtn.BackColor = System.Drawing.Color.OrangeRed
        Me.resizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.resizeBtn.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.resizeBtn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.resizeBtn.Location = New System.Drawing.Point(20, 60)
        Me.resizeBtn.Name = "resizeBtn"
        Me.resizeBtn.Size = New System.Drawing.Size(116, 36)
        Me.resizeBtn.TabIndex = 0
        Me.resizeBtn.Text = "Resize (OFF)"
        Me.resizeBtn.UseVisualStyleBackColor = False
        '
        'toolboxPnl
        '
        Me.toolboxPnl.BackColor = System.Drawing.Color.White
        Me.toolboxPnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.toolboxPnl.Controls.Add(Me.trashPic)
        Me.toolboxPnl.Controls.Add(Me.headSelectorCmb)
        Me.toolboxPnl.Controls.Add(Me.makeAnchorButton)
        Me.toolboxPnl.Controls.Add(Me.makeHeadingBtn)
        Me.toolboxPnl.Controls.Add(Me.colourBtn)
        Me.toolboxPnl.Controls.Add(Me.moveBtn)
        Me.toolboxPnl.Controls.Add(Me.undoBtn)
        Me.toolboxPnl.Controls.Add(Me.makePicBoxBtn)
        Me.toolboxPnl.Controls.Add(Me.makeParaBtn)
        Me.toolboxPnl.Controls.Add(Me.resizeBtn)
        Me.toolboxPnl.Location = New System.Drawing.Point(53, 66)
        Me.toolboxPnl.Name = "toolboxPnl"
        Me.toolboxPnl.Size = New System.Drawing.Size(153, 528)
        Me.toolboxPnl.TabIndex = 0
        '
        'trashPic
        '
        Me.trashPic.Image = Global.websiteBuilder.My.Resources.Resources.trashLogo
        Me.trashPic.InitialImage = Nothing
        Me.trashPic.Location = New System.Drawing.Point(52, 402)
        Me.trashPic.Name = "trashPic"
        Me.trashPic.Size = New System.Drawing.Size(45, 45)
        Me.trashPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.trashPic.TabIndex = 9
        Me.trashPic.TabStop = False
        '
        'headSelectorCmb
        '
        Me.headSelectorCmb.DisplayMember = "h1; h2"
        Me.headSelectorCmb.FormattingEnabled = True
        Me.headSelectorCmb.Items.AddRange(New Object() {"h1", "h2", "h3", "h4", "h5", "h6"})
        Me.headSelectorCmb.Location = New System.Drawing.Point(85, 178)
        Me.headSelectorCmb.Name = "headSelectorCmb"
        Me.headSelectorCmb.Size = New System.Drawing.Size(52, 21)
        Me.headSelectorCmb.TabIndex = 7
        Me.headSelectorCmb.Text = "h1"
        '
        'makeAnchorButton
        '
        Me.makeAnchorButton.Location = New System.Drawing.Point(19, 230)
        Me.makeAnchorButton.Name = "makeAnchorButton"
        Me.makeAnchorButton.Size = New System.Drawing.Size(51, 34)
        Me.makeAnchorButton.TabIndex = 11
        Me.makeAnchorButton.Text = "a"
        Me.makeAnchorButton.UseVisualStyleBackColor = True
        '
        'makeHeadingBtn
        '
        Me.makeHeadingBtn.Location = New System.Drawing.Point(20, 170)
        Me.makeHeadingBtn.Name = "makeHeadingBtn"
        Me.makeHeadingBtn.Size = New System.Drawing.Size(51, 34)
        Me.makeHeadingBtn.TabIndex = 10
        Me.makeHeadingBtn.Text = "h1 - h6"
        Me.makeHeadingBtn.UseVisualStyleBackColor = True
        '
        'colourBtn
        '
        Me.colourBtn.Location = New System.Drawing.Point(85, 226)
        Me.colourBtn.Name = "colourBtn"
        Me.colourBtn.Size = New System.Drawing.Size(52, 38)
        Me.colourBtn.TabIndex = 4
        Me.colourBtn.Text = "bg colour"
        Me.colourBtn.UseVisualStyleBackColor = True
        '
        'moveBtn
        '
        Me.moveBtn.BackColor = System.Drawing.Color.PaleGreen
        Me.moveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.moveBtn.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.moveBtn.Location = New System.Drawing.Point(19, 18)
        Me.moveBtn.Name = "moveBtn"
        Me.moveBtn.Size = New System.Drawing.Size(117, 36)
        Me.moveBtn.TabIndex = 9
        Me.moveBtn.Text = "Move (ON)"
        Me.moveBtn.UseVisualStyleBackColor = False
        '
        'btn_openBrowser
        '
        Me.btn_openBrowser.BackColor = System.Drawing.Color.LightBlue
        Me.btn_openBrowser.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_openBrowser.Location = New System.Drawing.Point(1013, 606)
        Me.btn_openBrowser.Name = "btn_openBrowser"
        Me.btn_openBrowser.Size = New System.Drawing.Size(148, 30)
        Me.btn_openBrowser.TabIndex = 4
        Me.btn_openBrowser.Text = "Open in browser"
        Me.btn_openBrowser.UseVisualStyleBackColor = False
        '
        'lbl_username
        '
        Me.lbl_username.AutoSize = True
        Me.lbl_username.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_username.Location = New System.Drawing.Point(958, 31)
        Me.lbl_username.Name = "lbl_username"
        Me.lbl_username.Size = New System.Drawing.Size(80, 18)
        Me.lbl_username.TabIndex = 5
        Me.lbl_username.Text = "Username"
        '
        'lbl_webName
        '
        Me.lbl_webName.AutoSize = True
        Me.lbl_webName.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_webName.Location = New System.Drawing.Point(1000, 31)
        Me.lbl_webName.Name = "lbl_webName"
        Me.lbl_webName.Size = New System.Drawing.Size(84, 18)
        Me.lbl_webName.TabIndex = 6
        Me.lbl_webName.Text = "Web name"
        '
        'lbl_pageName
        '
        Me.lbl_pageName.AutoSize = True
        Me.lbl_pageName.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_pageName.Location = New System.Drawing.Point(1059, 31)
        Me.lbl_pageName.Name = "lbl_pageName"
        Me.lbl_pageName.Size = New System.Drawing.Size(89, 18)
        Me.lbl_pageName.TabIndex = 7
        Me.lbl_pageName.Text = "Page name"
        '
        'lbl_mainMenu
        '
        Me.lbl_mainMenu.AutoSize = True
        Me.lbl_mainMenu.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mainMenu.ForeColor = System.Drawing.Color.DarkTurquoise
        Me.lbl_mainMenu.Location = New System.Drawing.Point(50, 621)
        Me.lbl_mainMenu.Name = "lbl_mainMenu"
        Me.lbl_mainMenu.Size = New System.Drawing.Size(116, 15)
        Me.lbl_mainMenu.TabIndex = 8
        Me.lbl_mainMenu.Text = "Back to main menu"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1380, 24)
        Me.MenuStrip1.TabIndex = 9
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'Canvas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1380, 670)
        Me.Controls.Add(Me.lbl_mainMenu)
        Me.Controls.Add(Me.lbl_pageName)
        Me.Controls.Add(Me.lbl_webName)
        Me.Controls.Add(Me.lbl_username)
        Me.Controls.Add(Me.btn_openBrowser)
        Me.Controls.Add(Me.toolboxPnl)
        Me.Controls.Add(Me.btn_save)
        Me.Controls.Add(Me.canvasPnl)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Canvas"
        Me.Text = "Canvas"
        Me.toolboxPnl.ResumeLayout(False)
        CType(Me.trashPic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents canvasPnl As System.Windows.Forms.Panel
    Friend WithEvents btn_save As System.Windows.Forms.Button
    Friend WithEvents makeParaBtn As System.Windows.Forms.Button
    Friend WithEvents makePicBoxBtn As System.Windows.Forms.Button
    Friend WithEvents undoBtn As System.Windows.Forms.Button
    Friend WithEvents resizeBtn As System.Windows.Forms.Button
    Friend WithEvents toolboxPnl As System.Windows.Forms.Panel
    Friend WithEvents moveBtn As System.Windows.Forms.Button
    Friend WithEvents colourBtn As System.Windows.Forms.Button
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents btn_openBrowser As System.Windows.Forms.Button
    Friend WithEvents lbl_username As System.Windows.Forms.Label
    Friend WithEvents lbl_webName As System.Windows.Forms.Label
    Friend WithEvents makeAnchorButton As System.Windows.Forms.Button
    Friend WithEvents makeHeadingBtn As System.Windows.Forms.Button
    Friend WithEvents headSelectorCmb As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_pageName As System.Windows.Forms.Label
    Friend WithEvents lbl_mainMenu As System.Windows.Forms.Label
    Friend WithEvents trashPic As System.Windows.Forms.PictureBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip

End Class
