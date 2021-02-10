Imports System.Data.OleDb
Imports System.Text.RegularExpressions
Public Class register


    Dim usernameInp As String
    Dim emailInp As String
    Dim passwordInp As String
    Dim passwordConfirm As String
    Dim salt As String

   
   


    



    Private Sub btn_submit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_submit.Click
        'Assign the textbox texts to variables
        usernameInp = txt_name.Text
        emailInp = txt_email.Text
        passwordInp = txt_password.Text
        passwordConfirm = txt_confirmPass.Text

        If passwordInp <> passwordConfirm Then  'Check if passwords match 
            MsgBox("Password must match")
            Exit Sub
        End If

        If passwordInp.Length < 4 Then  'Length check
            MsgBox("Password must be 5 or more characters")
            Exit Sub
        End If

        Dim emailVal As New Regex("([\w-+]+(?:\.[\w-+]+)*@(?:[\w-]+\.)+[a-zA-Z]{2,7})") 'Validate email with regex
        If emailVal.IsMatch(emailInp) = False Then
            MsgBox("Must enter a valid email")
        End If

        salt = GenerateSalt() 'Make a salt string
        passwordInp += salt 'Append salt to password
        passwordInp = GenerateSHA256(passwordInp) 'Hash password



        Try
            connectString = provider & dataFile
            myConnection.ConnectionString = connectString
            myConnection.Open()
            Dim query As String = "INSERT INTO [users] ([Username], [Password], [SaltString], [Email]) VALUES (" _
                                  & "'" & usernameInp & "'," _
                                  & "'" & passwordInp & "'," _
                                  & "'" & salt & "'," _
                                  & "'" & emailInp & "');"
            Dim command As OleDbCommand = New OleDbCommand(query, myConnection)
            command.ExecuteNonQuery()
            command.Dispose()
            myConnection.Close()
            MsgBox("Account Registered")
            login.Show()
            Me.Dispose() 'Destroy this form

        Catch ex As Exception
            MsgBox(ex.Message)
            myConnection.Close()
            MsgBox("error")
        End Try

    End Sub

    Private Sub lbl_login_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_login.Click
        Me.Hide()
        login.Show()
    End Sub

    Private Sub lbl_forgotPass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_forgotPass.Click
        Me.Hide()
        forgotPass.Show()
    End Sub

    Private Sub register_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class