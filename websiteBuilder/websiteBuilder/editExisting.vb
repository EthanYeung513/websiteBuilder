Imports System.Data.OleDb
Public Class editExisting

    Private Sub btn_create_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_create.Click

        websiteName = txt_webName.Text  'Get the website name   
        pageName = txt_newPage.Text & ".html"  'Get the name of the new page

        If websiteName.Length = 0 Or pageName.Length = 0 Then
            MessageBox.Show("Input required for website and new page name")
            Exit Sub
        End If

        Try
            folderName = username & "_" & websiteName  'Make folder name using their username and website name
            fileDirectory = My.Application.Info.DirectoryPath & "\" & folderName & "\" 'Get the path

            pageWriter = My.Computer.FileSystem.OpenTextFileWriter(fileDirectory & pageName, False) 'Setup writers of the new page
            cssWriter = My.Computer.FileSystem.OpenTextFileWriter(fileDirectory & "style.css", False)

            pageName = txt_newPage.Text

            mainMenu.getWebsiteID() 'Get ID's so it can be used in the setLastWorkedOn() sub in the canvas class
            mainMenu.getHtmlID()

            insertHtml()

            Canvas.writeTemplate() 'Write html and css template

            Canvas.Show()
            Me.Dispose()
        Catch ex As Exception
            MsgBox("Website does not exist")
            Exit Sub
        End Try

    End Sub


    Sub insertHtml()
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

            Exit Sub
        End Try

    End Sub



    Private Sub btn_load_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_load.Click
        websiteName = txt_webName.Text 'Get the website name
        pageName = txt_load.Text & ".html" 'Get the page name


        If websiteName.Length = 0 Or pageName.Length = 0 Then
            MessageBox.Show("Input required for website and load page name")
            Exit Sub
        End If

        Try
            folderName = username & "_" & websiteName  'Make folder name using their username and website name
            fileDirectory = My.Application.Info.DirectoryPath & "\" & folderName & "\" 'Get the path

            pageWriter = My.Computer.FileSystem.OpenTextFileWriter(fileDirectory & pageName, True) 'Setup writers of the new page
            cssWriter = My.Computer.FileSystem.OpenTextFileWriter(fileDirectory & "style.css", True)

            mainMenu.getWebsiteID() 'Get ID's so it can be used in the setLastWorkedOn() sub in the canvas class
            pageName = txt_load.Text 'Gets rid of .html
            mainMenu.getHtmlID()

        Catch ex As Exception
            MessageBox.Show("Website or page does not exist")
            Exit Sub
        End Try

        Canvas.Show()
        Me.Dispose()

    End Sub

    Private Sub lbl_mainMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_mainMenu.Click
        mainMenu.Show()
        Me.Dispose()
    End Sub

    Private Sub editExisting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class