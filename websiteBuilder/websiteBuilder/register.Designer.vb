<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class register
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
        Me.lbl_forgotPass = New System.Windows.Forms.Label()
        Me.lbl_login = New System.Windows.Forms.Label()
        Me.lbl_password = New System.Windows.Forms.Label()
        Me.txt_password = New System.Windows.Forms.TextBox()
        Me.lbl_name = New System.Windows.Forms.Label()
        Me.txt_name = New System.Windows.Forms.TextBox()
        Me.lbl_registerTitle = New System.Windows.Forms.Label()
        Me.btn_submit = New System.Windows.Forms.Button()
        Me.lbl_conformPass = New System.Windows.Forms.Label()
        Me.txt_confirmPass = New System.Windows.Forms.TextBox()
        Me.lbl_email = New System.Windows.Forms.Label()
        Me.txt_email = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'lbl_forgotPass
        '
        Me.lbl_forgotPass.AutoSize = True
        Me.lbl_forgotPass.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_forgotPass.ForeColor = System.Drawing.Color.SkyBlue
        Me.lbl_forgotPass.Location = New System.Drawing.Point(261, 477)
        Me.lbl_forgotPass.Name = "lbl_forgotPass"
        Me.lbl_forgotPass.Size = New System.Drawing.Size(150, 19)
        Me.lbl_forgotPass.TabIndex = 15
        Me.lbl_forgotPass.Text = "Forgot password?"
        '
        'lbl_login
        '
        Me.lbl_login.AutoSize = True
        Me.lbl_login.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_login.ForeColor = System.Drawing.Color.SkyBlue
        Me.lbl_login.Location = New System.Drawing.Point(111, 477)
        Me.lbl_login.Name = "lbl_login"
        Me.lbl_login.Size = New System.Drawing.Size(53, 19)
        Me.lbl_login.TabIndex = 14
        Me.lbl_login.Text = "Login"
        '
        'lbl_password
        '
        Me.lbl_password.AutoSize = True
        Me.lbl_password.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_password.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_password.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lbl_password.Location = New System.Drawing.Point(112, 239)
        Me.lbl_password.Name = "lbl_password"
        Me.lbl_password.Size = New System.Drawing.Size(78, 18)
        Me.lbl_password.TabIndex = 12
        Me.lbl_password.Text = "Password"
        '
        'txt_password
        '
        Me.txt_password.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_password.Location = New System.Drawing.Point(113, 270)
        Me.txt_password.Name = "txt_password"
        Me.txt_password.Size = New System.Drawing.Size(298, 26)
        Me.txt_password.TabIndex = 11
        '
        'lbl_name
        '
        Me.lbl_name.AutoSize = True
        Me.lbl_name.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_name.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_name.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lbl_name.Location = New System.Drawing.Point(112, 95)
        Me.lbl_name.Name = "lbl_name"
        Me.lbl_name.Size = New System.Drawing.Size(80, 18)
        Me.lbl_name.TabIndex = 10
        Me.lbl_name.Text = "Username"
        '
        'txt_name
        '
        Me.txt_name.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_name.ForeColor = System.Drawing.SystemColors.InfoText
        Me.txt_name.Location = New System.Drawing.Point(115, 124)
        Me.txt_name.Name = "txt_name"
        Me.txt_name.Size = New System.Drawing.Size(298, 26)
        Me.txt_name.TabIndex = 9
        '
        'lbl_registerTitle
        '
        Me.lbl_registerTitle.AutoSize = True
        Me.lbl_registerTitle.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_registerTitle.Location = New System.Drawing.Point(189, 28)
        Me.lbl_registerTitle.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lbl_registerTitle.Name = "lbl_registerTitle"
        Me.lbl_registerTitle.Size = New System.Drawing.Size(146, 37)
        Me.lbl_registerTitle.TabIndex = 8
        Me.lbl_registerTitle.Text = "Register"
        '
        'btn_submit
        '
        Me.btn_submit.BackColor = System.Drawing.Color.LightBlue
        Me.btn_submit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_submit.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_submit.Location = New System.Drawing.Point(115, 404)
        Me.btn_submit.Name = "btn_submit"
        Me.btn_submit.Size = New System.Drawing.Size(298, 45)
        Me.btn_submit.TabIndex = 16
        Me.btn_submit.Text = "Submit"
        Me.btn_submit.UseVisualStyleBackColor = False
        '
        'lbl_conformPass
        '
        Me.lbl_conformPass.AutoSize = True
        Me.lbl_conformPass.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_conformPass.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_conformPass.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lbl_conformPass.Location = New System.Drawing.Point(110, 321)
        Me.lbl_conformPass.Name = "lbl_conformPass"
        Me.lbl_conformPass.Size = New System.Drawing.Size(135, 18)
        Me.lbl_conformPass.TabIndex = 18
        Me.lbl_conformPass.Text = "Confirm password"
        '
        'txt_confirmPass
        '
        Me.txt_confirmPass.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_confirmPass.Location = New System.Drawing.Point(113, 351)
        Me.txt_confirmPass.Name = "txt_confirmPass"
        Me.txt_confirmPass.Size = New System.Drawing.Size(298, 26)
        Me.txt_confirmPass.TabIndex = 17
        '
        'lbl_email
        '
        Me.lbl_email.AutoSize = True
        Me.lbl_email.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_email.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_email.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lbl_email.Location = New System.Drawing.Point(112, 166)
        Me.lbl_email.Name = "lbl_email"
        Me.lbl_email.Size = New System.Drawing.Size(48, 18)
        Me.lbl_email.TabIndex = 20
        Me.lbl_email.Text = "Email"
        '
        'txt_email
        '
        Me.txt_email.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_email.ForeColor = System.Drawing.SystemColors.InfoText
        Me.txt_email.Location = New System.Drawing.Point(113, 196)
        Me.txt_email.Name = "txt_email"
        Me.txt_email.Size = New System.Drawing.Size(298, 26)
        Me.txt_email.TabIndex = 19
        '
        'register
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(525, 541)
        Me.Controls.Add(Me.lbl_email)
        Me.Controls.Add(Me.txt_email)
        Me.Controls.Add(Me.lbl_conformPass)
        Me.Controls.Add(Me.txt_confirmPass)
        Me.Controls.Add(Me.btn_submit)
        Me.Controls.Add(Me.lbl_forgotPass)
        Me.Controls.Add(Me.lbl_login)
        Me.Controls.Add(Me.lbl_password)
        Me.Controls.Add(Me.txt_password)
        Me.Controls.Add(Me.lbl_name)
        Me.Controls.Add(Me.txt_name)
        Me.Controls.Add(Me.lbl_registerTitle)
        Me.Name = "register"
        Me.Text = "Register"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_forgotPass As System.Windows.Forms.Label
    Friend WithEvents lbl_login As System.Windows.Forms.Label
    Friend WithEvents lbl_password As System.Windows.Forms.Label
    Friend WithEvents txt_password As System.Windows.Forms.TextBox
    Friend WithEvents lbl_name As System.Windows.Forms.Label
    Friend WithEvents txt_name As System.Windows.Forms.TextBox
    Friend WithEvents lbl_registerTitle As System.Windows.Forms.Label
    Friend WithEvents btn_submit As System.Windows.Forms.Button
    Friend WithEvents lbl_conformPass As System.Windows.Forms.Label
    Friend WithEvents txt_confirmPass As System.Windows.Forms.TextBox
    Friend WithEvents lbl_email As System.Windows.Forms.Label
    Friend WithEvents txt_email As System.Windows.Forms.TextBox
End Class
