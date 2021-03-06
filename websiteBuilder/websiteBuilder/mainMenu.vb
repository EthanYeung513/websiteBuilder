Imports System.Data.OleDb
Public Class mainMenu



    Private Sub btn_new_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_new.Click 'Open the create new website form
        Dim newWebsiteFrm As newWebsite = New newWebsite
        newWebsiteFrm.Show()
    End Sub

    Private Sub btn_exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exit.Click 'Exit the application
        Close()
    End Sub

    Private Sub btn_editExisting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_editExisting.Click 'Open the edit existing form
        Dim editExistingFrm As editExisting = New editExisting
        editExistingFrm.Show()
    End Sub

    Private Sub btn_load_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_loadPrevious.Click 'Load last edited website in the canvas

        If getPreviousWorkedOn() = False Then 'Get information about the previously worked on website and page, will return false if error (caused by no previous website)
            MsgBox("You must create a website before selecting this option")
            Exit Sub
        End If
        Dim canvasFrm As Canvas = New Canvas 'Show the canvas
        canvasFrm.Show()

        folderName = username & "_" & websiteName  'Make folder name using their username and website name

        fileDirectory = My.Application.Info.DirectoryPath & "\" & folderName & "\" 'Get the path

        pageWriter = My.Computer.FileSystem.OpenTextFileWriter(fileDirectory & pageName, True) 'Set writers to write to files
        cssWriter = My.Computer.FileSystem.OpenTextFileWriter(fileDirectory & "style.css", True)

        Me.Dispose() 'Destroy this form
    End Sub


    Function getPreviousWorkedOn() 'Get the details of the last worked on website

        Try 'Get the IDs of the last  worked on 
            myConnection.ConnectionString = connectString
            myConnection.Open()
            Dim query As String = "SELECT [PreviousWebsiteID], [PreviousHtmlID] FROM [users] WHERE [UserID] = " & userID
            Dim command As OleDbCommand = New OleDbCommand(query, myConnection)
            Using readerObj As OleDbDataReader = command.ExecuteReader
                readerObj.Read()
                websiteID = readerObj.Item("PreviousWebsiteID")
                htmlID = readerObj.Item("PreviousHtmlID")    'Gets previous website information
            End Using
            command.Dispose() 'Dispose to have more memory
            myConnection.Close()

        Catch ex As Exception    'If error, it means no previous website loaded before
            myConnection.Close()
            Return False
            Exit Function
        End Try


        Try 'Get the name of the last worked on website
            myConnection.ConnectionString = connectString
            myConnection.Open()
            Dim query As String = "SELECT [WebsiteName] FROM [websites] WHERE [WebsiteID] = " & websiteID
            Dim command As OleDbCommand = New OleDbCommand(query, myConnection)
            Using readerObj As OleDbDataReader = command.ExecuteReader
                readerObj.Read()
                websiteName = readerObj.Item("WebsiteName")
                'Gets previous website information
            End Using
            command.Dispose() 'Dispose to have more memory
            myConnection.Close()

        Catch ex As Exception    'If error, it means no previous website loaded before
            myConnection.Close()
            Return False
            Exit Function
        End Try


        Try 'Get the name of the last worked on page
            myConnection.ConnectionString = connectString
            myConnection.Open()
            Dim query As String = "SELECT [FileName] FROM [html] WHERE [HtmlID] = " & htmlID
            Dim command As OleDbCommand = New OleDbCommand(query, myConnection)
            Using readerObj As OleDbDataReader = command.ExecuteReader
                readerObj.Read()
                pageName = readerObj.Item("FileName") & ".html"
                'Gets previous website information
            End Using
            command.Dispose() 'Dispose to have more memory
            myConnection.Close()

        Catch ex As Exception    'If error, it means no previous website loaded before
            myConnection.Close()
            Return False
            Exit Function
        End Try

        Return True
    End Function


    Public Sub newFolder() 'Setup new folder 
        folderName = username & "_" & websiteName  'Make folder name using their username and website name
        My.Computer.FileSystem.CreateDirectory(folderName) 'Create folder 
        My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\" & folderName & "\assets\") 'Create an assets folder for media such as images
        fileDirectory = My.Application.Info.DirectoryPath & "\" & folderName & "\" 'Get the path

        pageName = "index.html" 'First page will be called index

        pageWriter = My.Computer.FileSystem.OpenTextFileWriter(fileDirectory & pageName, False) 'Create new files to write to 
        cssWriter = My.Computer.FileSystem.OpenTextFileWriter(fileDirectory & "style.css", False)
    End Sub

    Private Sub mainMenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Public Sub getWebsiteID() 'Get the websiteID for the html and css tables
        Try
            myConnection.ConnectionString = connectString
            myConnection.Open()
            Dim query As String = "SELECT [WebsiteID] FROM [websites] WHERE [WebsiteName] = '" & websiteName & "'"
            Dim command As OleDbCommand = New OleDbCommand(query, myConnection)
            Using readerObj As OleDbDataReader = command.ExecuteReader
                readerObj.Read()
                websiteID = readerObj.Item("WebsiteID") 'Gets websiteID  where the website name is the same from database
            End Using
            command.Dispose()
            myConnection.Close()

        Catch ex As Exception    'If error, it means website not found
            MsgBox("Website not found")
            myConnection.Close()

        End Try

    End Sub

    Public Sub getHtmlID() 'Get the websiteID for the html and css tables
        Try
            myConnection.ConnectionString = connectString
            myConnection.Open()
            Dim query As String = "SELECT [htmlID] FROM [html] WHERE [WebsiteID] = " & websiteID & " AND [FileName] = '" & pageName & "'"
            Dim command As OleDbCommand = New OleDbCommand(query, myConnection)
            Using readerObj As OleDbDataReader = command.ExecuteReader
                readerObj.Read()
                htmlID = readerObj.Item("htmlID") 'Gets websiteID  where the website name is the same from database

            End Using
            command.Dispose()
            myConnection.Close()

        Catch ex As Exception    'If error, it means website not found
            MsgBox("Website not found")
            myConnection.Close()

        End Try

    End Sub



    Private Sub lbl_login_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_login.Click
        login.Show()
        Me.Dispose()
    End Sub
End Class