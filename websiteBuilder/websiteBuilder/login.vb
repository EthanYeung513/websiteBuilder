Imports System.Data.OleDb
Public Class login

    Dim usernameDb As String 'The username from the db
    Dim passwordDb As String 'The password from the db
    Dim saltDb 'The salt string from the db

    Dim usernameInp As String 'Their input
    Dim passwordInp As String


    Private Sub btn_login_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_login.Click

        usernameInp = txt_name.Text 'Their input of the username
        passwordInp = txt_password.Text 'Their input of the password


        If usernameInp.Length = 0 Or passwordInp.Length = 0 Then 'Presence check
            MsgBox("Must enter username and password")
            Exit Sub 'Prevent db search
        End If


        Try
            myConnection.ConnectionString = connectString
            myConnection.Open()
            Dim query As String = "SELECT [UserID], [Username], [Password], [SaltString] FROM [users] WHERE [Username] = '" & usernameInp & "'"
            Dim command As OleDbCommand = New OleDbCommand(query, myConnection)
            Using readerObj As OleDbDataReader = command.ExecuteReader
                readerObj.Read()
                userID = readerObj.Item("UserID")
                usernameDb = readerObj.Item("Username")    'Gets username, salt and password where the usernameInp is the same from database
                passwordDb = readerObj.Item("Password")
                saltDb = readerObj.Item("SaltString")
            End Using
            command.Dispose() 'Dispose to have more memory
            myConnection.Close()

        Catch ex As Exception    'If error, it means username not found
            MsgBox("User not found")
            myConnection.Close()
            Exit Sub
        End Try



        passwordInp += saltDb 'Add the salt to the password
        passwordInp = GenerateSHA256(passwordInp) 'Hash the password

        If usernameDb = usernameInp And passwordDb = passwordInp Then 'If details match up
            username = usernameInp 'Update the global variable username to their sername
            mainMenu.Show() 'Show main menu
            Me.Hide()
            Exit Sub  'Exit this subb
        End If

        MsgBox("Wrong username or password") 'Output that they have wrong input

    End Sub



    Private Sub lbl_register_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_register.Click
        Me.Hide()
        register.Show()
    End Sub

    Private Sub lbl_forgotPass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_forgotPass.Click
        Me.Hide()
        forgotPass.Show()
    End Sub

    Private Sub login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class