<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mainMenu
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
        Me.lbl_mmTitle = New System.Windows.Forms.Label()
        Me.btn_new = New System.Windows.Forms.Button()
        Me.btn_loadPrevious = New System.Windows.Forms.Button()
        Me.btn_exit = New System.Windows.Forms.Button()
        Me.btn_editExisting = New System.Windows.Forms.Button()
        Me.lbl_login = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lbl_mmTitle
        '
        Me.lbl_mmTitle.AutoSize = True
        Me.lbl_mmTitle.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mmTitle.Location = New System.Drawing.Point(179, 43)
        Me.lbl_mmTitle.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lbl_mmTitle.Name = "lbl_mmTitle"
        Me.lbl_mmTitle.Size = New System.Drawing.Size(258, 37)
        Me.lbl_mmTitle.TabIndex = 1
        Me.lbl_mmTitle.Text = "Website builder"
        '
        'btn_new
        '
        Me.btn_new.BackColor = System.Drawing.Color.Azure
        Me.btn_new.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_new.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_new.Location = New System.Drawing.Point(139, 197)
        Me.btn_new.Name = "btn_new"
        Me.btn_new.Size = New System.Drawing.Size(325, 62)
        Me.btn_new.TabIndex = 6
        Me.btn_new.Text = "Create new website"
        Me.btn_new.UseVisualStyleBackColor = False
        '
        'btn_loadPrevious
        '
        Me.btn_loadPrevious.BackColor = System.Drawing.Color.Azure
        Me.btn_loadPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_loadPrevious.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_loadPrevious.Location = New System.Drawing.Point(139, 119)
        Me.btn_loadPrevious.Name = "btn_loadPrevious"
        Me.btn_loadPrevious.Size = New System.Drawing.Size(325, 62)
        Me.btn_loadPrevious.TabIndex = 7
        Me.btn_loadPrevious.Text = "Resume editing"
        Me.btn_loadPrevious.UseVisualStyleBackColor = False
        '
        'btn_exit
        '
        Me.btn_exit.BackColor = System.Drawing.Color.LightGray
        Me.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_exit.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_exit.Location = New System.Drawing.Point(139, 390)
        Me.btn_exit.Name = "btn_exit"
        Me.btn_exit.Size = New System.Drawing.Size(325, 54)
        Me.btn_exit.TabIndex = 8
        Me.btn_exit.Text = "Exit"
        Me.btn_exit.UseVisualStyleBackColor = False
        '
        'btn_editExisting
        '
        Me.btn_editExisting.BackColor = System.Drawing.Color.Azure
        Me.btn_editExisting.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_editExisting.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_editExisting.Location = New System.Drawing.Point(139, 276)
        Me.btn_editExisting.Name = "btn_editExisting"
        Me.btn_editExisting.Size = New System.Drawing.Size(325, 62)
        Me.btn_editExisting.TabIndex = 9
        Me.btn_editExisting.Text = "Edit existing website"
        Me.btn_editExisting.UseVisualStyleBackColor = False
        '
        'lbl_login
        '
        Me.lbl_login.AutoSize = True
        Me.lbl_login.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_login.ForeColor = System.Drawing.Color.SkyBlue
        Me.lbl_login.Location = New System.Drawing.Point(490, 494)
        Me.lbl_login.Name = "lbl_login"
        Me.lbl_login.Size = New System.Drawing.Size(109, 19)
        Me.lbl_login.TabIndex = 23
        Me.lbl_login.Text = "Back to login"
        '
        'mainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(627, 550)
        Me.Controls.Add(Me.lbl_login)
        Me.Controls.Add(Me.btn_editExisting)
        Me.Controls.Add(Me.btn_exit)
        Me.Controls.Add(Me.btn_loadPrevious)
        Me.Controls.Add(Me.btn_new)
        Me.Controls.Add(Me.lbl_mmTitle)
        Me.Name = "mainMenu"
        Me.Text = "Main menu"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_mmTitle As System.Windows.Forms.Label
    Friend WithEvents btn_new As System.Windows.Forms.Button
    Friend WithEvents btn_loadPrevious As System.Windows.Forms.Button
    Friend WithEvents btn_exit As System.Windows.Forms.Button
    Friend WithEvents btn_editExisting As System.Windows.Forms.Button
    Friend WithEvents lbl_login As System.Windows.Forms.Label
End Class
