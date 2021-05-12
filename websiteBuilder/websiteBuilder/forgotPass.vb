Imports System.Data.OleDb
Imports System.Net.Mail
Public Class forgotPass

    Dim code As String
    Dim emailDB As String
    Dim salt As String

    Private Sub lbl_loginTitle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_forgotPassTitle.Click

    End Sub

    Private Sub lbl_sendCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_sendCode.Click



        getEmail() 'Get the users email that is linked to their username
        generateCode() 'Generate the 4 digit code


        Dim SmtpServer As New SmtpClient() 'Instantiate new SMTP client
        Dim email As New MailMessage
        SmtpServer.Credentials = New  _
 Net.NetworkCredential("websiteBuilderCode@gmail.com", "G][2/?C62H4HaktN") 'Details of my user
        SmtpServer.EnableSsl = True
        SmtpServer.Port = 587
        SmtpServer.Host = "smtp.gmail.com"
        email = New MailMessage()

        email.From = New MailAddress("websiteBuilderCode@gmail.com")  'Specify who email is from
        email.To.Add(emailDB) 'Specify who email is going to be sent to
        email.Subject = "Reset password for website builder" 'Subject of the email
        email.Body = code 'The body of the email contains the code
        SmtpServer.Send(email)  'Send the email
        MsgBox("Code sent to your email")
    End Sub


    Sub generateCode() 'Make random 4 digit code
        Dim rand As New Random
        For x = 0 To 3
            code += rand.Next(0, 10).ToString
        Next
    End Sub

    Sub getEmail()
        Try
            myConnection.ConnectionString = connectString
            myConnection.Open()
            Dim query As String = "SELECT [Username], [Email] FROM [users] WHERE Username = '" & txt_name.Text & "'"
            Dim command As OleDbCommand = New OleDbCommand(query, myConnection)
            Using readerObj As OleDbDataReader = command.ExecuteReader
                readerObj.Read()
                emailDB = readerObj.Item("Email")    'Gets [username] and [password] from database
            End Using
            command.Dispose()
            myConnection.Close()

        Catch ex As Exception
            MsgBox("Invalid username")
        End Try
    End Sub
    

    Private Sub btn_submit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_submit.Click

        If txt_password.Text <> txt_confirmPass.Text Then
            MsgBox("Passwords do not match")
            Exit Sub
        End If

        If txt_password.Text.Length < 4 Then  'Length check
            MsgBox("Password must be 5 or more characters")
            Exit Sub
        End If


        salt = GenerateSalt() 'Make a salt string
        txt_password.Text += salt 'Append salt to password
        txt_password.Text = GenerateSHA256(txt_password.Text) 'Hash password


        If code = txt_code.Text Then 'If codes match up
            changePass()
        End If
    End Sub

    Sub changePass()  'Go into db and change password
        Try
            myConnection.ConnectionString = connectString
            myConnection.Open()
            Dim query As String = "UPDATE [users] SET [Password] = '" & txt_password.Text & "', [SaltString] = '" & salt & "' " & "WHERE [Username] = '" & txt_name.Text & " '"
            'Changes password to their input where the usernames are the same
            Dim command As OleDbCommand = New OleDbCommand(query, myConnection)
            command.ExecuteNonQuery()
            command.Dispose()
            myConnection.Close()

        Catch ex As Exception
            MsgBox("Error")
            Exit Sub
        End Try

        txt_password.Clear()
        txt_confirmPass.Clear()

        MsgBox("Changed password")
        Me.Hide()
        login.Show()
    End Sub

    Private Sub lbl_register_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_register.Click
        Me.Hide()
        register.Show()
    End Sub

    Private Sub lbl_login_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_login.Click
        Me.Hide()
        login.Show()
    End Sub

    Private Sub forgotPass_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class