<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class login
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
        Me.lbl_loginTitle = New System.Windows.Forms.Label()
        Me.txt_name = New System.Windows.Forms.TextBox()
        Me.lbl_name = New System.Windows.Forms.Label()
        Me.lbl_password = New System.Windows.Forms.Label()
        Me.txt_password = New System.Windows.Forms.TextBox()
        Me.btn_login = New System.Windows.Forms.Button()
        Me.lbl_register = New System.Windows.Forms.Label()
        Me.lbl_forgotPass = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lbl_loginTitle
        '
        Me.lbl_loginTitle.AutoSize = True
        Me.lbl_loginTitle.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_loginTitle.Location = New System.Drawing.Point(218, 46)
        Me.lbl_loginTitle.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lbl_loginTitle.Name = "lbl_loginTitle"
        Me.lbl_loginTitle.Size = New System.Drawing.Size(104, 37)
        Me.lbl_loginTitle.TabIndex = 0
        Me.lbl_loginTitle.Text = "Login"
        '
        'txt_name
        '
        Me.txt_name.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_name.ForeColor = System.Drawing.SystemColors.InfoText
        Me.txt_name.Location = New System.Drawing.Point(127, 135)
        Me.txt_name.Name = "txt_name"
        Me.txt_name.Size = New System.Drawing.Size(298, 26)
        Me.txt_name.TabIndex = 1
        '
        'lbl_name
        '
        Me.lbl_name.AutoSize = True
        Me.lbl_name.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_name.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_name.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lbl_name.Location = New System.Drawing.Point(124, 106)
        Me.lbl_name.Name = "lbl_name"
        Me.lbl_name.Size = New System.Drawing.Size(80, 18)
        Me.lbl_name.TabIndex = 2
        Me.lbl_name.Text = "Username"
        '
        'lbl_password
        '
        Me.lbl_password.AutoSize = True
        Me.lbl_password.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_password.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_password.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lbl_password.Location = New System.Drawing.Point(126, 180)
        Me.lbl_password.Name = "lbl_password"
        Me.lbl_password.Size = New System.Drawing.Size(78, 18)
        Me.lbl_password.TabIndex = 4
        Me.lbl_password.Text = "Password"
        '
        'txt_password
        '
        Me.txt_password.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_password.Location = New System.Drawing.Point(127, 210)
        Me.txt_password.Name = "txt_password"
        Me.txt_password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_password.Size = New System.Drawing.Size(298, 26)
        Me.txt_password.TabIndex = 3
        '
        'btn_login
        '
        Me.btn_login.BackColor = System.Drawing.Color.LightBlue
        Me.btn_login.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_login.Location = New System.Drawing.Point(127, 282)
        Me.btn_login.Name = "btn_login"
        Me.btn_login.Size = New System.Drawing.Size(298, 45)
        Me.btn_login.TabIndex = 5
        Me.btn_login.Text = "Login"
        Me.btn_login.UseVisualStyleBackColor = False
        '
        'lbl_register
        '
        Me.lbl_register.AutoSize = True
        Me.lbl_register.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_register.ForeColor = System.Drawing.Color.SkyBlue
        Me.lbl_register.Location = New System.Drawing.Point(132, 367)
        Me.lbl_register.Name = "lbl_register"
        Me.lbl_register.Size = New System.Drawing.Size(73, 19)
        Me.lbl_register.TabIndex = 6
        Me.lbl_register.Text = "Register"
        '
        'lbl_forgotPass
        '
        Me.lbl_forgotPass.AutoSize = True
        Me.lbl_forgotPass.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_forgotPass.ForeColor = System.Drawing.Color.SkyBlue
        Me.lbl_forgotPass.Location = New System.Drawing.Point(275, 367)
        Me.lbl_forgotPass.Name = "lbl_forgotPass"
        Me.lbl_forgotPass.Size = New System.Drawing.Size(150, 19)
        Me.lbl_forgotPass.TabIndex = 7
        Me.lbl_forgotPass.Text = "Forgot password?"
        '
        'login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 22.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(551, 477)
        Me.Controls.Add(Me.lbl_forgotPass)
        Me.Controls.Add(Me.lbl_register)
        Me.Controls.Add(Me.btn_login)
        Me.Controls.Add(Me.lbl_password)
        Me.Controls.Add(Me.txt_password)
        Me.Controls.Add(Me.lbl_name)
        Me.Controls.Add(Me.txt_name)
        Me.Controls.Add(Me.lbl_loginTitle)
        Me.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Name = "login"
        Me.Text = "Login"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_loginTitle As System.Windows.Forms.Label
    Friend WithEvents txt_name As System.Windows.Forms.TextBox
    Friend WithEvents lbl_name As System.Windows.Forms.Label
    Friend WithEvents lbl_password As System.Windows.Forms.Label
    Friend WithEvents txt_password As System.Windows.Forms.TextBox
    Friend WithEvents btn_login As System.Windows.Forms.Button
    Friend WithEvents lbl_register As System.Windows.Forms.Label
    Friend WithEvents lbl_forgotPass As System.Windows.Forms.Label
End Class
