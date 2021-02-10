Imports System.Data.OleDb

Public Class newWebsite




    Private Sub btn_submit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_submit.Click

        websiteName = txt_webName.Text 'Change this variable to their input
        pageName = "index"

        If txt_webName.Text = "" Then  'Presence check
            MessageBox.Show("Must enter a website name")
            Exit Sub 'Don't continue with this sub
        End If



        insertWebsite() 'Insert website name and userID into the database

        mainMenu.getWebsiteID() 'Gets the website iD

        If insertHtmlAndCss() = False Then ' Insert file into db   Return false if theres an error
            MessageBox.Show("Error inserting into database")
            Exit Sub
        End If

        mainMenu.getHtmlID() 'Get the htmlID so that it can be put into the previousHtmlID

        mainMenu.newFolder() 'Create a new folder which holds the website's content
        Canvas.writeTemplate() 'Write html and css template
        mainMenu.Hide()

        Canvas.Show()
        Me.Dispose()
    End Sub


    Function insertWebsite() 'Insert the website into the database
        Try
            connectString = provider & dataFile
            myConnection.ConnectionString = connectString
            myConnection.Open()
            Dim query As String = "INSERT INTO [websites] ([UserID], [WebsiteName]) VALUES (" _
                                  & "'" & userID & "'," _
                                  & "'" & websiteName & "');"
            Dim command As OleDbCommand = New OleDbCommand(query, myConnection)
            command.ExecuteNonQuery()
            command.Dispose()
            myConnection.Close()
            MsgBox("Website generated")
            Return True

        Catch ex As Exception  'If error, return false
            MsgBox(ex.Message)
            myConnection.Close()
            MsgBox("error")
            Return False
            Exit Function
        End Try
    End Function 'Insert the website into the database




    Function insertHtmlAndCss()

        Try 'Inserting html
            connectString = provider & dataFile
            myConnection.ConnectionString = connectString
            myConnection.Open()
            Dim query As String = "INSERT INTO [html] ([WebsiteID], [Filename]) VALUES (" _
                                  & "'" & websiteID & "'," _
                                  & "'" & pageName & "');"     'Filename is index because it's the first page 
            Dim command As OleDbCommand = New OleDbCommand(query, myConnection)
            command.ExecuteNonQuery()
            command.Dispose()
            myConnection.Close()

        Catch ex As Exception  'If error, return false
            MsgBox(ex.Message)
            myConnection.Close()
            MsgBox("Page failed to insert")
            Return False
            Exit Function
        End Try

        Try 'Inserting css
            connectString = provider & dataFile
            myConnection.ConnectionString = connectString
            myConnection.Open()
            Dim query = "INSERT INTO [css] ([WebsiteID], [Filename]) VALUES (" _
                                  & "'" & websiteID & "'," _
                                  & "'" & "style" & "');"
            Dim command As OleDbCommand = New OleDbCommand(query, myConnection)
            command.ExecuteNonQuery()
            command.Dispose()
            myConnection.Close()
        Catch ex As Exception  'If error, return false
            MsgBox(ex.Message)
            myConnection.Close()
            MsgBox("css failed to insert")
            Return False
            Exit Function
        End Try

        Return True
    End Function


    Private Sub lbl_mainMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_mainMenu.Click
        mainMenu.Show()
        Me.Hide()
    End Sub

    Private Sub newWebsite_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class