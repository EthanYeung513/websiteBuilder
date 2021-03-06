Imports System.Data.OleDb
Public Class editExisting

    Private Sub btn_create_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_create.Click
        pageName = txt_newPage.Text
        If pageName.Length = 0 Or websiteName.Length = 0 Then
            MessageBox.Show("Input required for website and new page name")
            Exit Sub
        End If

        Try
            mainMenu.getWebsiteID() 'Get ID's so it can be used in the setLastWorkedOn() sub in the canvas class


            insertHtml()
            mainMenu.getHtmlID()
            pageName = pageName & ".html"

            folderName = username & "_" & websiteName  'Make folder name using their username and website name
            fileDirectory = My.Application.Info.DirectoryPath & "\" & folderName & "\" 'Get the path

            pageWriter = My.Computer.FileSystem.OpenTextFileWriter(fileDirectory & pageName, False) 'Setup writers of the new page
            cssWriter = My.Computer.FileSystem.OpenTextFileWriter(fileDirectory & "style.css", True)


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
                                  & "'" & pageName & "');"
            'Inserting 0's into the counter
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



    Private Sub btn_load_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_load.Click 'Load a existing page
        pageName = "" 'Reset page name
        Dim tempRecordDisplay
        Try 'Use a try catch incase they click but dont select
            tempRecordDisplay = lst_selectPage.SelectedItem.ToString 'Get the selected item
        Catch
            Exit Sub
        End Try


        Dim tempHtmlID As String = ""

        For Each character In tempRecordDisplay 'Go through item string
            If character = " " Then 'If its a space, then stop because it has retrieved the pageid 
                Exit For
            End If
            tempHtmlID += character
        Next
        htmlID = Int(tempHtmlID)


        tempRecordDisplay = StrReverse(tempRecordDisplay) 'Reverse string 
        For Each character In tempRecordDisplay 'Go through string to get the name
            If character = " " Then 'If there's a |, stop because page name found
                Exit For
            End If
            pageName += character 'Add character to page name
        Next

        pageName = StrReverse(pageName) 'Reverse again to get the original website name
        pageName = pageName & ".html" 'Get the page name


        Try

            folderName = username & "_" & websiteName  'Make folder name using their username and website name

            fileDirectory = My.Application.Info.DirectoryPath & "\" & folderName & "\" 'Get the path

            pageWriter = My.Computer.FileSystem.OpenTextFileWriter(fileDirectory & pageName, True) 'Set writers to write to files
            cssWriter = My.Computer.FileSystem.OpenTextFileWriter(fileDirectory & "style.css", True)



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

    Private Sub editExisting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load 'When form is shown
        showAllWebsites() 'Show websites associated with user
    End Sub



    Sub showAllWebsites()
        Try
            myConnection.ConnectionString = connectString
            myConnection.Open()

            Dim dt As New DataTable 'Holds the info about all objects
            Dim ds As New DataSet
            ds.Tables.Add(dt) 'Add the table to dataset
            Dim query As New OleDbDataAdapter

            query = New OleDbDataAdapter("SELECT * from websites WHERE [UserID] = " & userID, myConnection) 'Get all objs from table objects
            query.Fill(dt) 'Fill the dt with this info

            Dim websiteArray = dt.Select() 'the objectArray will have the dataset info

            Dim recordDisplay As String = "" 'string that is added to the list
            For i = 0 To websiteArray.Length - 1 'Go through every website
                recordDisplay += websiteArray(i)(0).ToString & " | "
                recordDisplay += websiteArray(i)(1).ToString & " | "
                recordDisplay += websiteArray(i)(2).ToString
                lst_selectWebsite.Items.Add(recordDisplay) 'Add website to listbox
                recordDisplay = "" 'Reset string 
            Next
            myConnection.Close()

        Catch ex As Exception    'If error, it means object not found
            myConnection.Close()
        End Try
    End Sub





    Sub showAllPages() 'Show pages associated with the website
        lst_selectPage.Items.Clear() 'Remove every item so it doesnt display every page more than once
        Try
            myConnection.ConnectionString = connectString
            myConnection.Open()

            Dim dt As New DataTable 'Holds the info about all objects   
            Dim ds As New DataSet
            ds.Tables.Add(dt) 'Add the table to dataset
            Dim query As New OleDbDataAdapter

            query = New OleDbDataAdapter("SELECT * from html WHERE [WebsiteID] = " & websiteID, myConnection) 'Get all objs from table objects
            query.Fill(dt) 'Fill the dt with this info

            Dim pageArray = dt.Select() 'the objectArray will have the dataset info

            Dim recordDisplay As String = "" 'string that is added to the list
            For i = 0 To pageArray.Length - 1 'Go through every website
                recordDisplay += pageArray(i)(0).ToString & " | "
                recordDisplay += pageArray(i)(1).ToString & " | "
                recordDisplay += pageArray(i)(2).ToString
                lst_selectPage.Items.Add(recordDisplay) 'Add website to listbox
                recordDisplay = "" 'Reset string 
            Next

            myConnection.Close()

        Catch ex As Exception    'If error, it means object not found
            myConnection.Close()
        End Try
    End Sub

    Private Sub lst_selectPage_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lst_selectPage.SelectedIndexChanged

    End Sub

    Private Sub lst_selectWebsite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lst_selectWebsite.Click 'When a website is selected
        Dim tempRecordDisplay
        Try 'Use a try catch incase they click but dont select
            tempRecordDisplay = lst_selectWebsite.SelectedItem.ToString 'Get the selected item
        Catch
            Exit Sub 'Don't continue with the sub
        End Try
        Dim tempWebsiteID As String = ""
        For Each character In tempRecordDisplay 'Go through item string
            If character = " " Then 'If its a space, then stop because it has retrieved the websiteid 
                Exit For
            End If
            tempWebsiteID += character
        Next

        websiteID = Int(tempWebsiteID) 'Set websiteID

        websiteName = "" 'Reset website name

        tempRecordDisplay = StrReverse(tempRecordDisplay) 'Reverse string 
        For Each character In tempRecordDisplay 'Go through string to get the name
            If character = " " Then 'If there's a space, stop because website name found
                Exit For
            End If
            websiteName += character 'Add character to website name
        Next

        websiteName = StrReverse(websiteName).Trim 'Reverse again to get the original website name


        showAllPages() 'Show all related pages in listbox
    End Sub
End Class