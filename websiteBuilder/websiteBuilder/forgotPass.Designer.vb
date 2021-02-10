<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class forgotPass
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
        Me.lbl_conformPass = New System.Windows.Forms.Label()
        Me.txt_confirmPass = New System.Windows.Forms.TextBox()
        Me.btn_submit = New System.Windows.Forms.Button()
        Me.lbl_password = New System.Windows.Forms.Label()
        Me.txt_password = New System.Windows.Forms.TextBox()
        Me.lbl_name = New System.Windows.Forms.Label()
        Me.txt_name = New System.Windows.Forms.TextBox()
        Me.lbl_forgotPassTitle = New System.Windows.Forms.Label()
        Me.txt_code = New System.Windows.Forms.TextBox()
        Me.lbl_code = New System.Windows.Forms.Label()
        Me.lbl_sendCode = New System.Windows.Forms.Label()
        Me.lbl_login = New System.Windows.Forms.Label()
        Me.lbl_register = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lbl_conformPass
        '
        Me.lbl_conformPass.AutoSize = True
        Me.lbl_conformPass.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_conformPass.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_conformPass.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lbl_conformPass.Location = New System.Drawing.Point(94, 311)
        Me.lbl_conformPass.Name = "lbl_conformPass"
        Me.lbl_conformPass.Size = New System.Drawing.Size(135, 18)
        Me.lbl_conformPass.TabIndex = 27
        Me.lbl_conformPass.Text = "Confirm password"
        '
        'txt_confirmPass
        '
        Me.txt_confirmPass.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_confirmPass.Location = New System.Drawing.Point(97, 341)
        Me.txt_confirmPass.Name = "txt_confirmPass"
        Me.txt_confirmPass.Size = New System.Drawing.Size(298, 26)
        Me.txt_confirmPass.TabIndex = 26
        '
        'btn_submit
        '
        Me.btn_submit.BackColor = System.Drawing.Color.LightBlue
        Me.btn_submit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_submit.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_submit.Location = New System.Drawing.Point(97, 405)
        Me.btn_submit.Name = "btn_submit"
        Me.btn_submit.Size = New System.Drawing.Size(298, 45)
        Me.btn_submit.TabIndex = 25
        Me.btn_submit.Text = "Submit"
        Me.btn_submit.UseVisualStyleBackColor = False
        '
        'lbl_password
        '
        Me.lbl_password.AutoSize = True
        Me.lbl_password.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_password.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_password.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lbl_password.Location = New System.Drawing.Point(96, 229)
        Me.lbl_password.Name = "lbl_password"
        Me.lbl_password.Size = New System.Drawing.Size(78, 18)
        Me.lbl_password.TabIndex = 24
        Me.lbl_password.Text = "Password"
        '
        'txt_password
        '
        Me.txt_password.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_password.Location = New System.Drawing.Point(97, 260)
        Me.txt_password.Name = "txt_password"
        Me.txt_password.Size = New System.Drawing.Size(298, 26)
        Me.txt_password.TabIndex = 23
        '
        'lbl_name
        '
        Me.lbl_name.AutoSize = True
        Me.lbl_name.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_name.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_name.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lbl_name.Location = New System.Drawing.Point(96, 85)
        Me.lbl_name.Name = "lbl_name"
        Me.lbl_name.Size = New System.Drawing.Size(80, 18)
        Me.lbl_name.TabIndex = 22
        Me.lbl_name.Text = "Username"
        '
        'txt_name
        '
        Me.txt_name.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_name.ForeColor = System.Drawing.SystemColors.InfoText
        Me.txt_name.Location = New System.Drawing.Point(99, 114)
        Me.txt_name.Name = "txt_name"
        Me.txt_name.Size = New System.Drawing.Size(298, 26)
        Me.txt_name.TabIndex = 21
        '
        'lbl_forgotPassTitle
        '
        Me.lbl_forgotPassTitle.AutoSize = True
        Me.lbl_forgotPassTitle.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_forgotPassTitle.Location = New System.Drawing.Point(104, 20)
        Me.lbl_forgotPassTitle.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lbl_forgotPassTitle.Name = "lbl_forgotPassTitle"
        Me.lbl_forgotPassTitle.Size = New System.Drawing.Size(291, 37)
        Me.lbl_forgotPassTitle.TabIndex = 30
        Me.lbl_forgotPassTitle.Text = "Change password"
        '
        'txt_code
        '
        Me.txt_code.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_code.ForeColor = System.Drawing.SystemColors.InfoText
        Me.txt_code.Location = New System.Drawing.Point(97, 186)
        Me.txt_code.Name = "txt_code"
        Me.txt_code.Size = New System.Drawing.Size(298, 26)
        Me.txt_code.TabIndex = 28
        '
        'lbl_code
        '
        Me.lbl_code.AutoSize = True
        Me.lbl_code.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_code.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_code.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lbl_code.Location = New System.Drawing.Point(96, 156)
        Me.lbl_code.Name = "lbl_code"
        Me.lbl_code.Size = New System.Drawing.Size(90, 18)
        Me.lbl_code.TabIndex = 29
        Me.lbl_code.Text = "4 digit code"
        '
        'lbl_sendCode
        '
        Me.lbl_sendCode.AutoSize = True
        Me.lbl_sendCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_sendCode.ForeColor = System.Drawing.Color.DeepSkyBlue
        Me.lbl_sendCode.Location = New System.Drawing.Point(401, 193)
        Me.lbl_sendCode.Name = "lbl_sendCode"
        Me.lbl_sendCode.Size = New System.Drawing.Size(65, 14)
        Me.lbl_sendCode.TabIndex = 31
        Me.lbl_sendCode.Text = "Send code"
        '
        'lbl_login
        '
        Me.lbl_login.AutoSize = True
        Me.lbl_login.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_login.ForeColor = System.Drawing.Color.SkyBlue
        Me.lbl_login.Location = New System.Drawing.Point(324, 463)
        Me.lbl_login.Name = "lbl_login"
        Me.lbl_login.Size = New System.Drawing.Size(53, 19)
        Me.lbl_login.TabIndex = 33
        Me.lbl_login.Text = "Login"
        '
        'lbl_register
        '
        Me.lbl_register.AutoSize = True
        Me.lbl_register.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_register.ForeColor = System.Drawing.Color.SkyBlue
        Me.lbl_register.Location = New System.Drawing.Point(102, 463)
        Me.lbl_register.Name = "lbl_register"
        Me.lbl_register.Size = New System.Drawing.Size(73, 19)
        Me.lbl_register.TabIndex = 32
        Me.lbl_register.Text = "Register"
        '
        'forgotPass
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(502, 530)
        Me.Controls.Add(Me.lbl_login)
        Me.Controls.Add(Me.lbl_register)
        Me.Controls.Add(Me.lbl_sendCode)
        Me.Controls.Add(Me.lbl_forgotPassTitle)
        Me.Controls.Add(Me.lbl_code)
        Me.Controls.Add(Me.txt_code)
        Me.Controls.Add(Me.lbl_conformPass)
        Me.Controls.Add(Me.txt_confirmPass)
        Me.Controls.Add(Me.btn_submit)
        Me.Controls.Add(Me.lbl_password)
        Me.Controls.Add(Me.txt_password)
        Me.Controls.Add(Me.lbl_name)
        Me.Controls.Add(Me.txt_name)
        Me.Name = "forgotPass"
        Me.Text = "Forgot password"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_conformPass As System.Windows.Forms.Label
    Friend WithEvents txt_confirmPass As System.Windows.Forms.TextBox
    Friend WithEvents btn_submit As System.Windows.Forms.Button
    Friend WithEvents lbl_password As System.Windows.Forms.Label
    Friend WithEvents txt_password As System.Windows.Forms.TextBox
    Friend WithEvents lbl_name As System.Windows.Forms.Label
    Friend WithEvents txt_name As System.Windows.Forms.TextBox
    Friend WithEvents lbl_forgotPassTitle As System.Windows.Forms.Label
    Friend WithEvents txt_code As System.Windows.Forms.TextBox
    Friend WithEvents lbl_code As System.Windows.Forms.Label
    Friend WithEvents lbl_sendCode As System.Windows.Forms.Label
    Friend WithEvents lbl_login As System.Windows.Forms.Label
    Friend WithEvents lbl_register As System.Windows.Forms.Label
End Class
