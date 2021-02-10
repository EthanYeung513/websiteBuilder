<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class newWebsite
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
        Me.lbl_newTitle = New System.Windows.Forms.Label()
        Me.lbl_name = New System.Windows.Forms.Label()
        Me.txt_webName = New System.Windows.Forms.TextBox()
        Me.btn_submit = New System.Windows.Forms.Button()
        Me.lbl_mainMenu = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lbl_newTitle
        '
        Me.lbl_newTitle.AutoSize = True
        Me.lbl_newTitle.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_newTitle.Location = New System.Drawing.Point(73, 27)
        Me.lbl_newTitle.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lbl_newTitle.Name = "lbl_newTitle"
        Me.lbl_newTitle.Size = New System.Drawing.Size(317, 37)
        Me.lbl_newTitle.TabIndex = 2
        Me.lbl_newTitle.Text = "Create new website"
        '
        'lbl_name
        '
        Me.lbl_name.AutoSize = True
        Me.lbl_name.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_name.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_name.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lbl_name.Location = New System.Drawing.Point(77, 111)
        Me.lbl_name.Name = "lbl_name"
        Me.lbl_name.Size = New System.Drawing.Size(109, 18)
        Me.lbl_name.TabIndex = 12
        Me.lbl_name.Text = "Website name"
        '
        'txt_webName
        '
        Me.txt_webName.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_webName.ForeColor = System.Drawing.SystemColors.InfoText
        Me.txt_webName.Location = New System.Drawing.Point(80, 140)
        Me.txt_webName.Name = "txt_webName"
        Me.txt_webName.Size = New System.Drawing.Size(298, 26)
        Me.txt_webName.TabIndex = 11
        '
        'btn_submit
        '
        Me.btn_submit.BackColor = System.Drawing.Color.LightBlue
        Me.btn_submit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_submit.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_submit.Location = New System.Drawing.Point(80, 211)
        Me.btn_submit.Name = "btn_submit"
        Me.btn_submit.Size = New System.Drawing.Size(298, 45)
        Me.btn_submit.TabIndex = 17
        Me.btn_submit.Text = "Submit"
        Me.btn_submit.UseVisualStyleBackColor = False
        '
        'lbl_mainMenu
        '
        Me.lbl_mainMenu.AutoSize = True
        Me.lbl_mainMenu.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mainMenu.ForeColor = System.Drawing.Color.SkyBlue
        Me.lbl_mainMenu.Location = New System.Drawing.Point(293, 304)
        Me.lbl_mainMenu.Name = "lbl_mainMenu"
        Me.lbl_mainMenu.Size = New System.Drawing.Size(155, 19)
        Me.lbl_mainMenu.TabIndex = 18
        Me.lbl_mainMenu.Text = "Back to main menu"
        '
        'newWebsite
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(460, 343)
        Me.Controls.Add(Me.lbl_mainMenu)
        Me.Controls.Add(Me.btn_submit)
        Me.Controls.Add(Me.lbl_name)
        Me.Controls.Add(Me.txt_webName)
        Me.Controls.Add(Me.lbl_newTitle)
        Me.Name = "newWebsite"
        Me.Text = "Create new website"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_newTitle As System.Windows.Forms.Label
    Friend WithEvents lbl_name As System.Windows.Forms.Label
    Friend WithEvents txt_webName As System.Windows.Forms.TextBox
    Friend WithEvents btn_submit As System.Windows.Forms.Button
    Friend WithEvents lbl_mainMenu As System.Windows.Forms.Label
End Class
