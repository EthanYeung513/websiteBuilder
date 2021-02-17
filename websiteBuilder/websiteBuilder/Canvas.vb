﻿Imports System.IO
Imports System.Data.OleDb
Public Class Canvas
    Dim dragging As Boolean = False  'Enabled if mouse is dragging on object
    Dim allowAdd As Boolean = True  'Boolean which signals if user can add more objects


    Dim allModes As New Stack(Of Boolean)  'Only allow user to toggle a mode if all modes are off stack
    Dim resizeMode As Boolean = False 'If true, allow user to change size
    Dim moveMode As Boolean = True 'If true , allow user to move objects


    Public prevPos As Point   'Position before moving
    Public nextPos As Point   'Position where mouse is while dragging

    Dim WithEvents createdObj As New Control

    Dim onCanvas As New List(Of Object) 'Holds objects which are on the canvas


    'These variables are used to provide the objects with unique names
    Dim picCounter As Integer   'Counter for amount of picboxes
    Dim paraCounter As Integer  'Counter for amount of paragrahs 
    Dim headingCounter As Integer 'Counter for amount of headings
    Dim anchorCounter As Integer  'Counter for amount of anchors



    Dim totalCounter As Integer = -1 'Counter for all objects created by user
    Dim objectStack As New Stack 'Holds all objects, allowing user to remove objects at top of stack via undo function

    Dim backgroundColour As Color 'The colour of the background

    Dim x = 220    'Coords of the object, will add so location wont be the same
    Dim y = 45




    Private Enum EdgeEnum  'This means edgeNum can be either of these values
        None
        Right
        Left
        Top
        Bottom
    End Enum

    Private crntEdge As EdgeEnum = EdgeEnum.None 'Current edge 

    Private mWidth As Integer = 4




    Private Sub canvas_Show(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown  'On load

        setLastWorkedOn() 'Update the previous website worked on so it can be loaded

        getCurrentCounters() 'Set the counters 

        Me.KeyPreview = True 'Allow program to capture key down

        setBgColour() 'set the background colour on load, to what is present in css
        loadObjects() 'Load all objects from previous edits onto the form


        lbl_username.Text = username & " > "  'Change the label text to show the info of the website
        lbl_webName.Text = websiteName & " > "
        lbl_pageName.Text = pageName

        allModes.Push(moveMode)  'Push movemode to stack because on default, its on 
    End Sub



    Public Sub writeTemplate()  'Writes the HTML and CSS template for new files
        'Writes HTML
        pageWriter.WriteLine("<!DOCTYPE html>") 'Specifies it's a HTML5 document
        pageWriter.WriteLine("<HTML>") 'Shows it's a html file
        pageWriter.WriteLine("<Head>") 'Contains information  about the html file
        pageWriter.WriteLine("<meta charset='utf-8'>") 'Set character set to utf-8
        pageWriter.WriteLine("<link rel='stylesheet' href='style.css'>")  'Link external CSS
        pageWriter.WriteLine("</Head>") 'Close head tag
        pageWriter.WriteLine("<Body>")


        'Writes CSS
        cssWriter.WriteLine("body{") '
        cssWriter.WriteLine("font-family: 'Roboto', arial, sans-serif, serif;")
        cssWriter.WriteLine("background-color: #ffffff;")
        cssWriter.WriteLine("}")


        'body{
        'font-family: 'Roboto', arial, sans-serif, serif;
        'background-color: #ffffff;
        '}

        pageWriter.Close()
        cssWriter.Close()
    End Sub


    Sub setLastWorkedOn() 'Update the previous website worked on so it can be loaded
        Try
            myConnection.ConnectionString = connectString
            myConnection.Open()
            Dim query As String = "UPDATE [users] SET [PreviousWebsiteID] = " & websiteID & ", [PreviousHtmlID] = " & htmlID & " WHERE [Username] = '" & username & " '"
            'Changes ID's to the last used
            Dim command As OleDbCommand = New OleDbCommand(query, myConnection)
            command.ExecuteNonQuery()
            command.Dispose()
            myConnection.Close()

        Catch ex As Exception
            MsgBox("Error")
            Exit Sub
        End Try
    End Sub

    Sub setBgColour() 'set the background colour on load, to what is present in css
        Dim cssContents = readAllCSS() 'Load all css contents

        Dim colourCode As String = ""  'Hexcode found in css

        Dim length = cssContents.Count() - 1  'Get the amount of lines in css file
        For i = 0 To length  'Go through the css lines
            If cssContents(i).contains("background-color:") Then  'If there's a background colour
                Dim tempLine = cssContents(i)
                For j = 17 To Len(tempLine) - 2 'Get the hexcode
                    colourCode += tempLine(j) 'Add to hexcode string
                Next
                Exit For

            End If
        Next

        Dim bgColour As Color = ColorTranslator.FromHtml(colourCode) 'Translate hexcode to color that vb.net knows
        canvasPnl.BackColor = bgColour 'Change background colour
    End Sub

    'Code for the mouse

    Private Sub MyMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles createdObj.MouseDown  'If mouse down 
        prevPos = sender.PointToScreen(New Point(e.X, e.Y))   'Get the x and yCoords
        dragging = True   'User is dragging
    End Sub
    Private Sub MyMouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles createdObj.MouseMove 'If mouse is over control
        sender.Cursor = Cursors.Default  'Set cursor to default look

        If dragging = True And moveMode = True Then 'Move mode
            nextPos = sender.PointToScreen(New Point(e.X, e.Y))   'Get x and y coords
            sender.Left += (nextPos.X - prevPos.X)    'Change location by getting the difference of next and previous positions
            sender.Top += (nextPos.Y - prevPos.Y)
            prevPos = nextPos   'Update previous position to current position


        ElseIf resizeMode = True Then 'If resize mode is on
            If dragging = True And crntEdge <> EdgeEnum.None And resizeMode = True Then
                sender.SuspendLayout()   'Turns off layout logic for the object
                Select Case crntEdge   'Select case which chooses which edge to change size 
                    Case EdgeEnum.Left   'If cursor is on the left
                        sender.SetBounds(sender.Left + e.X, sender.Top, _
                sender.Width - e.X, sender.Height) 'Change size
                    Case EdgeEnum.Right   'If cursor is on the right
                        sender.SetBounds(sender.Left, sender.Top, _
                sender.Width - (sender.Width - e.X), sender.Height) 'Change size
                    Case EdgeEnum.Top  'If cursor is on the top
                        sender.SetBounds(sender.Left, sender.Top + e.Y, _
                sender.Width, sender.Height - e.Y)
                    Case EdgeEnum.Bottom  'If cursor is on the bottom 
                        sender.SetBounds(sender.Left, sender.Top, _
                sender.Width, sender.Height - (sender.Height - e.Y))
                End Select
                sender.ResumeLayout() 'Turns on layout logic for the object
            Else
                Select Case True  'Will detect if cursor is on the left, right, top, bottom, or none.
                    Case e.X <= mWidth 'left edge
                        sender.Cursor = Cursors.VSplit 'Change cursor to vertical splitter
                        crntEdge = EdgeEnum.Left  'Set current edge to left 
                    Case e.X > sender.Width - (mWidth + 1) 'right edge
                        sender.Cursor = Cursors.VSplit
                        crntEdge = EdgeEnum.Right 'Set current edge to right
                    Case e.Y <= mWidth 'top edge
                        sender.Cursor = Cursors.HSplit 'Change cursor to horizontal splitter
                        crntEdge = EdgeEnum.Top 'Set current edge to top
                    Case e.Y > sender.Height - (mWidth + 1) 'bottom edge
                        sender.Cursor = Cursors.HSplit
                        crntEdge = EdgeEnum.Bottom
                    Case Else 'no edge
                        sender.Cursor = Cursors.Default 'Change cursor to default
                        crntEdge = EdgeEnum.None
                End Select
            End If
        End If
    End Sub
    Private Sub MyMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles createdObj.MouseUp  'If mouse lets go 
        dragging = False 'Set to false 
        If moveMode = True Then 'When they let go on movemode
            If removeObject(sender) = True Then 'Check if obj on trashcan, if it is, delete. Return true if deleted
                Exit Sub 'Dont continue with sub
            End If
            writeToHtml(sender) 'Write object to html if on panel


        ElseIf resizeMode = True Then 'If resized and on canvas, change the css and db size
            dbChangeObjInfo(sender, "Size") 'Change size in db

            If onCanvas.Contains(sender) = True Then
                cssChangeSize(sender) 'Change size in css if on panel

            End If
        End If


    End Sub

    Private Sub MyMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles createdObj.Click 'If mouse click 

    End Sub

    Private Sub MyTextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles createdObj.TextChanged 'If text changed on canvas
        If onCanvas.Contains(sender) Then 'If panel contains the object
            htmlTextChange(sender) 'Change the text in html
        End If

        dbChangeObjInfo(sender, "Text") 'Change the text in db
    End Sub


    'Code for spawning

    Private Sub makePicBoxBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles makePicBoxBtn.Click 'When click button, make a picBox
        If allowAdd = True Then
            picCounter += 1 'Increment amount of picbox counter
            totalCounter += 1 'Increment total amount of objects

            Dim tempPic As New PictureBox   'Instantiates new picture box

            tempPic.Name = "Pic" + picCounter.ToString  'Makes name the photo plus the current picbox counter
            tempPic.SizeMode = PictureBoxSizeMode.StretchImage 'Make picturebox resize to whatever the image is

            Dim picError As Boolean = True  'If picError stays true, then there's an error 
            While picError = True  'Keep attempting to choose a pic until no error
                Try  'If there's an error it won't crash

                    Dim imageSelector As OpenFileDialog = New OpenFileDialog
                    imageSelector.ShowDialog()
                    Dim tempFileLocation = imageSelector.FileName '

                    tempPic.Load(tempFileLocation) 'Set the pic to what they choose
                    imageSelector.Dispose()

                    picError = False
                Catch ex As Exception
                    Exit Sub 'Exit creating the image
                End Try
            End While
            checkUiOverflow()
            configureObjects(tempPic, True, x, y, 50, 50)

        End If

    End Sub

    Private Sub makeParaBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles makeParaBtn.Click  'Makes paragraph elemtent
        If allowAdd = True Then
            paraCounter += 1  'Increment amount of para counter
            totalCounter += 1 'Increment total amount of objects

            Dim tempPara As New RichTextBox  'Instantiates new paragraph

            tempPara.Name = "Para" + paraCounter.ToString  'Makes name the photo plus the current picbox counter

            tempPara.AutoSize = True

            checkUiOverflow()  'Check if objects goes outside of panel
            configureObjects(tempPara, True, x, y, 50, 50)  'Adds functionality

        End If

    End Sub

    Private Sub makeHeadingBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles makeHeadingBtn.Click 'Makes heading(1-6) elemtent
        If allowAdd = True Then
            headingCounter += 1  'Increment amount of heading ccounter
            totalCounter += 1 'Increment total amount of objects

            Dim tempHeading As New RichTextBox  'Instantiates new textbox
            Dim headingType As String = headSelectorCmb.Text
            tempHeading.Name = "Heading" & headingCounter.ToString & "-" & headingType 'Makes name the heading counter and the heading size they chose

            'Change the font size depending the heading type
            Dim i As Integer = 1  'Used to loop to the headingType
            Dim fontSize = 22 'H1 size will = 22, and decrement by each heading 
            headingType = headingType(1)
            While headingType <> i  'Loop until heading type is the same as i
                fontSize -= 3 'Decrement font
                i += 1
            End While
            tempHeading.Font = New Font(tempHeading.Font.FontFamily, fontSize) 'Change font size


            tempHeading.Multiline = True

            checkUiOverflow()  'Check if objects goes outside of panel
            configureObjects(tempHeading, True, x, y, 50, 50)  'Adds functionality

        End If
    End Sub


    Private Sub makeAnchorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles makeAnchorButton.Click
        If allowAdd = True Then
            anchorCounter += 1  'Increment amount of anchors counter
            totalCounter += 1 'Increment total amount of objects

            Dim tempAnchor As New RichTextBox  'Instantiates new textbox

            tempAnchor.Name = "Anchor" & anchorCounter.ToString   'Makes name the heading counter and the heading size they chose

            tempAnchor.Multiline = True

            checkUiOverflow()  'Check if objects goes outside of panel
            configureObjects(tempAnchor, True, x, y, 50, 50)  'Adds functionality

        End If
    End Sub

    Private Sub configureObjects(ByVal moveableObj As Control, ByVal newObj As Boolean, ByVal locX As Integer, ByVal locY As Integer, ByVal sizeX As Integer, ByVal sizeY As Integer)  'Add handlers and adding object to the stack

        moveableObj.AutoSize = False
        moveableObj.Width = sizeX
        moveableObj.Height = sizeY
        moveableObj.Top = locY     'Set location
        moveableObj.Left = locX

        moveableObj.BackColor = canvasPnl.BackColor 'Change the background of obj to match the panel back


        AddHandler moveableObj.MouseDown, AddressOf Me.MyMouseDown  'Adds action to the objects
        AddHandler moveableObj.MouseMove, AddressOf Me.MyMouseMove
        AddHandler moveableObj.MouseUp, AddressOf Me.MyMouseUp
        AddHandler moveableObj.MouseClick, AddressOf Me.MyMouseClick

        AddHandler moveableObj.TextChanged, AddressOf Me.MyTextChanged 'calls sub when text changed

        y += 60  'Change coords of next new object





        Me.Controls.Add(moveableObj)
        moveableObj.BringToFront()

        objectStack.Push(moveableObj)   'Add object to stack

        If newObj = True Then 'Only do these when the object is new and not loaded from db
            dbWriteObj(moveableObj) 'Write the obj to database if not in db already

            dbUpdateCounters() 'Update counters in the db
        End If
    End Sub
    Private Sub checkUiOverflow()  'If going over panel, stop them from creating more
        If y > 520 Then
            MessageBox.Show("Please undo an object before creating another")
            allowAdd = False  'Don't allow them to add more objects
        End If
    End Sub

    Private Sub undoObject() 'Removes last obj in

        Dim objType As String = objectStack(0).Name() 'Get name of obj on top of stack
        objectStack(0).Dispose()    'Destroy the obj on top of stack
        objectStack.Pop() 'Delete the obj of top of the stack
        y -= 60
        allowAdd = True  'Allow user to add more objects

        If objType.Contains("Para") Then  'If the obj was a paragraph, decrement counter of paraCounter
            paraCounter -= 1
        ElseIf objType.Contains("Pic") Then 'If the obj was a picBox, decrement counter of picCounter
            picCounter -= 1
        ElseIf objType.Contains("Heading") Then 'If the obj was a heading, decrement counter of headingCounter
            headingCounter -= 1
        ElseIf objType.Contains("Anchor") Then 'If the obj was a anchor, decrement counter of anchorCounter
            anchorCounter -= 1
        End If
        totalCounter -= 1  'Decrement total amount of objects counter

    End Sub



    Private Sub undoBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles undoBtn.Click 'Clicks the undo button
        Try 'Will create stack underflow if trying to delete no objects
            removeObjFromFiles(objectStack(0).Name) 'Delete from files
            dbRemoveObj(objectStack(0).Name) 'Delete from db

            undoObject() 'Delete object from the panel

            dbUpdateCounters() ''Update counters in the db
        Catch
            MessageBox.Show("Cannot undo no objects")
        End Try
    End Sub

    Private Sub Canvas_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If ((e.KeyCode = Keys.Z) AndAlso e.Control) Then
            Try 'Will create stack underflow if trying to delete no objects
                removeObjFromFiles(objectStack(0).Name) 'Delete from files
                dbRemoveObj(objectStack(0).Name) 'Delete from db

                undoObject() 'Delete object from the panel

                dbUpdateCounters() ''Update counters in the db
            Catch
                MessageBox.Show("Cannot undo no objects")
            End Try
        End If
    End Sub


    Function removeObject(ByRef currentObj) 'Check if on the trash can and then if it is, delete it. Return true if deleted obj
        Dim objectName As String = currentObj.Name 'Set the name of the object


        If currentObj.Location.X >= trashPic.Location.X And currentObj.Location.Y >= trashPic.Location.Y Then 'If object on trashcan
            If onCanvas.Contains(currentObj) Then 'If its on the onCanvas list
                onCanvas.Remove(currentObj)   'Remove it
                removeObjFromFiles(objectName) 'Delete from files
            End If

            dbRemoveObj(objectName) 'Delete from db 


            'Remake stack, because you can't remove by index 
            Dim tempList As New List(Of Object) 'Make a list
            While objectStack.Count <> 0 'While theres not nothing in stack
                Dim tempObjName = objectStack.Peek().Name
                If tempObjName <> objectName Then 'If the object on stack is not the object that's being deleted
                    tempList.Add(objectStack.Peek()) 'Add the top of stack to 

                End If

                Try
                    objectStack.Pop() 'Delete that obj off stack
                Catch
                End Try
            End While

            tempList.Reverse()  'Reverse list because first in first out for stack
            For Each obj In tempList 'Go through every object in templist
                objectStack.Push(obj) 'Add in the obj

            Next
            y -= 60 'Change the coords that next obj will spawn
            currentObj.Dispose() 'Destroy obj


            'Increment counters. Even tho its deleting, in order to have unique names, it must go up.
            'It would not work if decrementing because if we had para1 and para2, and we deleted para1, the next object would 
            'Have a counter = 2, which would cause an issue 

            If objectName.Contains("Para") Then  'If the obj was a paragraph, increment counter of paraCounter
                paraCounter += 1
            ElseIf objectName.Contains("Pic") Then 'If the obj was a picBox, increment  counter of picCounter
                picCounter += 1
            ElseIf objectName.Contains("Heading") Then 'If the obj was a heading, increment  counter of headingCounter
                headingCounter += 1
            ElseIf objectName.Contains("Anchor") Then 'If the obj was a anchor, increment  counter of anchorCounter
                anchorCounter += 1
            End If
            totalCounter -= 1

            dbUpdateCounters() ''Update counters in the db

            Return True
        End If
        Return False

    End Function




  
    Private Sub resizeBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles resizeBtn.Click 'Allows users to toggle resize mode 
        If resizeMode = True Then   'If resize mode is on, turn it off 
            allModes.Pop()
            resizeBtn.Text = "Resize (OFF)"  'Change the text off button to signal off
            resizeBtn.BackColor = Color.OrangeRed 'Change the back colour
            resizeMode = False
        ElseIf resizeMode = False And allModes.Count = 0 Then 'If its off and no other modes are on, turn it on.
            allModes.Push(resizeMode)   'Add the resizeMode bool to stack 
            resizeBtn.Text = "Resize (ON)"
            resizeBtn.BackColor = Color.PaleGreen 'Change the back colour
            resizeMode = True
        ElseIf resizeMode = False And allModes.Count = 1 Then  'If mode is off, but another mode is on, make all other modes off and enable this
            allModesOff()
            resizeMode = True  'Turn this mode on
            resizeBtn.Text = "Resize (ON)"
            resizeBtn.BackColor = Color.PaleGreen 'Change the back colour
            allModes.Push(resizeMode)   'Add the resizeMode bool to stack 
        End If
    End Sub


    Private Sub allModesOff() 'Turn all modes off
        resizeMode = False
        resizeBtn.Text = "Resize (OFF)" 'Change the text
        resizeBtn.BackColor = Color.OrangeRed 'Change the back colour

        moveMode = False
        moveBtn.Text = "Move (OFF)"
        moveBtn.BackColor = Color.OrangeRed
        allModes.Pop() 'Pop off mode that is on off stack
    End Sub

    Private Sub moveBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles moveBtn.Click  'Allows user to move objects 
        If moveMode = True Then   'If resize mode is on
            allModes.Pop()
            moveBtn.Text = "Move (OFF)"  'Change the text off button to signal off
            moveBtn.BackColor = Color.OrangeRed 'Change the back colour
            moveMode = False
        ElseIf moveMode = False And allModes.Count = 0 Then 'If movemode is off and no other modes are on
            allModes.Push(moveMode)  'Add mode to stack
            moveBtn.Text = "Move (ON)"
            moveBtn.BackColor = Color.PaleGreen 'Change the back colour
            moveMode = True
        ElseIf moveMode = False And allModes.Count = 1 Then  'If mode is off, but another mode is on, make all other modes off and enable this
            allModesOff()
            moveMode = True
            moveBtn.Text = "Move (ON)"
            moveBtn.BackColor = Color.PaleGreen 'Change the back colour
            allModes.Push(moveMode)  'Add mode to stack
        End If

    End Sub

    Sub writeToHtml(ByVal currentObj) 'Called when the user stops dragging

        Dim objectName As String = currentObj.Name 'Set the name of the object

        Dim locX As Integer = currentObj.Location.X  'Get coords of the current object that just moved
        Dim locY As Integer = currentObj.Location.Y

        Dim newLocX As Integer = (locX - 280) * 1.9 'Set up the location and size so it appears the same on the page (used for css)
        Dim newLocY As Integer = (locY - 50) * 1.9
        Dim newSizeX = currentObj.Width * 1.6
        Dim newSizeY = currentObj.Height * 1.6


        If locX >= canvasPnl.Location.X And locY >= canvasPnl.Location.Y Then   'Check if object is in panel2, if it is, write to text file
            If onCanvas.Contains(currentObj) = False Then 'If the object is not already on canvas, write to text html
                onCanvas.Add(currentObj)  'Add currentObj to onCanvas 

                pageWriter.Close() 'Close writers for use
                cssWriter.Close()

                pageWriter = My.Computer.FileSystem.OpenTextFileWriter(fileDirectory & pageName, True)
                cssWriter = My.Computer.FileSystem.OpenTextFileWriter(fileDirectory & "style.css", True)




                If objectName.Contains("Pic") Then  'If it's a picturebox
                    Dim picLocation As String = currentObj.ImageLocation  'Get the file location 

                    pageWriter.WriteLine("<img src='" & picLocation & "' class ='" & objectName & "' " & "alt='test'>") 'write an image


                ElseIf objectName.Contains("Para") Then 'If paragraph element
                    pageWriter.WriteLine("<p class='" & objectName & "'>" & currentObj.Text & "</p>") 'Write the html


                ElseIf objectName.Contains("Heading") Then 'If heading element
                    Dim headingType As String = objectName(objectName.Length - 1) 'Get last character, which is the type of heading (1 - 6)
                    pageWriter.WriteLine("<h" & headingType & " class='" & objectName & "'>" & currentObj.Text & "</h" & headingType & ">")

                End If

                writeToCss(objectName, newSizeX, newSizeY, newLocX, newLocY) 'Write the class


            Else 'Else, that it is on the panel but its already been written in html, it means position has been changed. 
                cssChangePosition(objectName, newLocX, newLocY) 'Change pos in css
                dbChangeObjInfo(currentObj, "Location") 'Change position in db

            End If
        Else 'Else, the object is not in the canvas panel, remove the object from html and css
            onCanvas.Remove(currentObj) 'Remove object from the list
            dbChangeObjInfo(currentObj, "Location") 'Change position in db, because it is still on the form
            removeObjFromFiles(objectName) 'Remove from html and css

        End If
        closeAllFiles()
    End Sub

    Sub writeToCss(ByVal objectName, ByVal sizeX, ByVal sizeY, ByVal locX, ByVal locY) 'Writing the classes

        cssWriter.WriteLine("." & objectName & "{")  'Writing css class, these are the generic properties each obj will have
        cssWriter.WriteLine("left: " & locX & "px;")
        cssWriter.WriteLine("top: " & locY & "px;")
        cssWriter.WriteLine("width:" & sizeX & "px;")
        cssWriter.WriteLine("height:" & sizeY & "px;")
        cssWriter.WriteLine("position: absolute;")

        If objectName.Contains("Pic") Then  'If it's a picturebox


        ElseIf objectName.Contains("Para") Then 'If paragraph element
            cssWriter.WriteLine("font-size: " & "15px;")

        End If

        cssWriter.WriteLine("}")
    End Sub



    Sub cssChangeSize(ByVal currentObj) 'Changes size in css, called when they resize an object thats in the panel canvas
        Dim cssContents = readAllCSS() 'The list of all css contents
        Dim objectName = currentObj.Name

        Dim sizeX = currentObj.Width 'Get the new dimensions
        Dim sizeY = currentObj.Height


        For i = 0 To cssContents.count() - 1 'Go through css list
            If cssContents(i).contains(objectName) Then 'If its the object
                For j = i To cssContents.count() - 1 'Search for the location properties in css 
                    If cssContents(j).contains("width:") Then 'If it has seen a width property
                        cssContents(j) = "width:" & sizeX & "px;" 'Change dimensions
                        cssContents(j + 1) = "height:" & sizeY & "px;"
                        Exit For 'Stop looping because its removed in css
                        Exit For 'Exit both loops
                    End If
                Next
            End If

        Next
        writeAllCss(cssContents) 'Write all back into file
    End Sub


    Sub cssChangePosition(ByVal objectName, ByRef locX, ByVal locY) 'Change position on canvas in css, called when moved while on canvas
        Dim cssContents = readAllCSS() 'The list of all css contents

        For i = 0 To cssContents.count() - 1 'Go through css list
            If cssContents(i).contains(objectName) Then 'If its the object
                For j = i To cssContents.count() - 1 'Search for the location properties in css 
                    If cssContents(j).contains("left:") Then 'If it has seen a left property
                        cssContents(j) = "left: " & locX & "px;" 'Change location
                        cssContents(j + 1) = "top: " & locY & "px;"
                        Exit For 'Stop looping because its removed in css
                        Exit For 'Exit both loops
                    End If
                Next
            End If
        Next
        writeAllCss(cssContents) 'Write all back into file
    End Sub



    Sub removeObjFromFiles(ByVal objectName) 'This sub will remove the object from the file
        Dim htmlContents = readAllHTML() 'The list of all html contents
        Dim cssContents = readAllCSS() 'The list of all css contents

        For i = 0 To htmlContents.count() - 1 'Go through html list
            If htmlContents(i).contains(objectName) Then 'If its the object
                htmlContents.removeAt(i) 'Remove it 
                Exit For 'Stop looping because its removed in html
            End If

        Next

        For i = 0 To cssContents.count() - 1 'Go through css list
            If cssContents(i).contains(objectName) Then 'If its the object
                While cssContents(i) <> "}" 'Remove til end of class
                    cssContents.removeAt(i) 'remove line
                End While

                cssContents.removeAt(i) 'remove extra "}" because it stops when detected
                Exit For 'Stop looping because its removed in css
            End If

        Next

        writeAllHtml(htmlContents) 'Write the contents into the files using the list contents
        writeAllCss(cssContents)
    End Sub


    Sub htmlTextChange(ByVal obj) 'Called when they change text while in html
        Dim htmlContents = readAllHTML() 'Load all html contents into page
        Dim objectText = obj.Text
        Dim objectName = obj.Name

        For i = 0 To htmlContents.count() - 1 'Go through html list
            If htmlContents(i).contains(objectName) Then 'If its the object
                If objectName.Contains("Para") Then 'If its a paragraph
                    htmlContents(i) = "<p class='" & objectName & "'>" & objectText & "</p>"
                ElseIf objectName.Contains("Heading") Then 'If its a heading
                    Dim headingType As String = objectName(objectName.Length - 1) 'Get last character, which is the type of heading (1 - 6)
                    htmlContents(i) = "<h" & headingType & " class='" & objectName & "'>" & objectText & "</h" & headingType & ">"

                End If
                Exit For 'Stop looping because text changed in html
            End If
        Next

        writeAllHtml(htmlContents) 'Write changes into html

    End Sub

    Private Sub btn_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click
        pageWriter.Close()


        cssWriter.Close()


        'page.Close()
        'page.Dispose()




    End Sub

    Private Sub checkForObject()  'checks if object that was in canvas is removed, then remove it in HTML

    End Sub



    Private Sub colourBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles colourBtn.Click 'Change colour of canvas

        ColorDialog1.ShowDialog()  'Opens up a menu to select a colour
        canvasPnl.BackColor = Me.ColorDialog1.Color  'Changes canvas colour to colour selected

        Dim colourChosen = Me.ColorDialog1.Color.ToArgb.ToString("X6")  'Converts argb integer to Hex 
        Dim hexCode As String = ""  'holds the hexcode of colour chosen which CSS will use

        For i = 2 To 7  'Start from 2 to ignore the alpha part of the original hexcode
            hexCode += colourChosen(i)
        Next

        Dim cssContents = readAllCSS()  'Get all css lines in file into an array 
        Dim length = cssContents.Count() - 1  'Get the amount of lines in css file
        For i = 0 To length  'Go through the css lines
            If cssContents(i).contains("background-color:") Then  'If there's a background colour
                cssContents(i) = "background-color:#" & hexCode & ";"  'replace the background colour to the one chosen
                Exit For
            End If
        Next

        For Each obj In objectStack 'Change the bg of each object to the back colour of the canvas panel
            obj.BackColor = canvasPnl.BackColor
        Next


        writeAllCss(cssContents)
    End Sub



    Sub writeAllHtml(ByVal htmlContents)
        closeAllFiles()
        pageWriter = My.Computer.FileSystem.OpenTextFileWriter(fileDirectory & pageName, False) 'Open writer, while also overwriting 

        For Each line In htmlContents  'Rewrite everything back into css, including the change
            pageWriter.WriteLine(line)
        Next

        pageWriter.Close()
    End Sub


    Sub writeAllCss(ByVal cssContents)
        closeAllFiles()
        cssWriter = My.Computer.FileSystem.OpenTextFileWriter(fileDirectory & "style.css", False) 'Open writer, while also overwriting 

        For Each line In cssContents  'Rewrite everything back into css, including the change
            cssWriter.WriteLine(line)
        Next

        cssWriter.Close()
    End Sub





    Private Function readAllHTML() 'Read everyline of HTML and put it into an array

        Try 'Try statement because closing writer will cause an error if not already open
            pageWriter.Close() 'Close the writer so it can read
            pageReader = My.Computer.FileSystem.OpenTextFileReader(fileDirectory & pageName)
        Catch ex As Exception

        End Try


        Dim allHtmlText As New List(Of String)    'Reading til the end of the textfile 
        While Not pageReader.EndOfStream()
            allHtmlText.Add(pageReader.ReadLine())     'Read line from textfile
        End While
        pageReader.Close()
        Return allHtmlText

    End Function


    Private Function readAllCSS() 'Read everyline of HTML and put it into an array

        cssWriter.Close() 'Close the writer so it can read
        cssReader = My.Computer.FileSystem.OpenTextFileReader(fileDirectory & "style.css")

        Dim allCssText As New List(Of String)    'Reading til the end of the textfile 
        While Not cssReader.EndOfStream()
            allCssText.Add(cssReader.ReadLine())     'Read line from textfile
        End While

        cssReader.Close()
        Return allCssText

    End Function

    Private Sub btn_openBrowser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_openBrowser.Click
        Process.Start(fileDirectory & pageName)
    End Sub



    Private Sub lbl_mainMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_mainMenu.Click 'Shows the main menu
        mainMenu.Show()
        closeAllFiles() 'Close all files so no  errors when opening back again

        Me.Dispose()
    End Sub

    Sub closeAllFiles() 'Close all files

        Try
            pageWriter.Close()
            cssWriter.Close()

            pageReader.Close()
            cssReader.Close()
        Catch
        End Try
    End Sub





    Sub dbWriteObj(ByVal obj) 'Writing the object to database so it can be shown on load later. Called if not already on db
        Dim objectName As String = obj.Name
        Dim locX = obj.Location.X
        Dim locY = obj.Location.Y
        Dim sizeX = obj.Height
        Dim sizeY = obj.Width
        Dim fileLoc As String
        Dim textInp As String
        Dim fontSize As Integer

        Try
            connectString = provider & dataFile
            myConnection.ConnectionString = connectString
            myConnection.Open()
            Dim query As String


            If objectName.Contains("Pic") Then 'If its a image 
                fileLoc = obj.ImageLocation 'Set the file location
                query = "INSERT INTO [objects] ([HtmlID], [ObjName], [LocationX], [LocationY], [SizeX], [SizeY], [FileLocation]) VALUES (" _
                                      & "'" & htmlID & "'," _
                                      & "'" & objectName & "'," _
                                      & "'" & locX & "'," _
                                      & "'" & locY & "'," _
                                      & "'" & sizeX & "'," _
                                      & "'" & sizeY & "'," _
                                      & "'" & fileLoc & "');"
            ElseIf objectName.Contains("Para") Or objectName.Contains("Heading") Then 'If its a paragraph or heading 
                textInp = obj.Text 'Set the text
                fontSize = obj.Font.Size
                query = "INSERT INTO [objects] ([HtmlID], [ObjName], [LocationX], [LocationY], [SizeX], [SizeY], [TextInput], [FontSize]) VALUES (" _
                                 & "'" & htmlID & "'," _
                                 & "'" & objectName & "'," _
                                 & "'" & locX & "'," _
                                 & "'" & locY & "'," _
                                 & "'" & sizeX & "'," _
                                 & "'" & sizeY & "'," _
                                 & "'" & textInp & "'," _
                                 & "'" & fontSize & "');"
            End If


            Dim command As OleDbCommand = New OleDbCommand(query, myConnection)
            command.ExecuteNonQuery() 'Insert the obj into the database
            command.Dispose()
            myConnection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
            myConnection.Close()
            MsgBox("error")
        End Try
    End Sub


    Function getObjID(ByVal ObjectName) 'Get the obj id 
        Dim objID

        Try
            myConnection.ConnectionString = connectString
            myConnection.Open()
            Dim query As String = "SELECT [ObjectID] FROM [objects] WHERE [HtmlID] = " & htmlID & " AND [ObjName] = '" & ObjectName & "'"
            Dim command As OleDbCommand = New OleDbCommand(query, myConnection)
            Using readerObj As OleDbDataReader = command.ExecuteReader
                readerObj.Read()
                objID = readerObj.Item("ObjectID") 'Gets websiteID  where the website name is the same from database

            End Using
            command.Dispose()
            myConnection.Close()

        Catch ex As Exception    'If error, it means object not found
            MsgBox("Object not found")
            myConnection.Close()

        End Try
        Return objID 'Return the ID
    End Function



    Sub dbChangeObjInfo(ByVal obj, ByVal type) 'Change the information in db such as size,position or text
        Dim objName = obj.Name 'Set name
        Dim objID = getObjID(objName) 'Set objectID

        Try
            myConnection.ConnectionString = connectString
            myConnection.Open()
            Dim query As String
            If type = "Location" Then 'If changing location
                query = "UPDATE [objects] SET [LocationX] = " & obj.Location.X & ", [LocationY] = " & obj.Location.Y & " WHERE [ObjectID] = " & objID
            ElseIf type = "Size" Then 'If changing size
                query = "UPDATE [objects] SET [SizeX] = " & obj.Width & ", [SizeY] = " & obj.Height & " WHERE [ObjectID] = " & objID
            ElseIf type = "Text" Then 'If changing text
                query = "UPDATE [objects] SET [TextInput] = '" & obj.Text & "' WHERE [ObjectID] = " & objID
            End If

            'Changes size or position
            Dim command As OleDbCommand = New OleDbCommand(query, myConnection)
            command.ExecuteNonQuery()
            command.Dispose()
            myConnection.Close()

        Catch ex As Exception
            MsgBox("Error")
            Exit Sub
        End Try
    End Sub

    Sub dbRemoveObj(ByVal objectName) 'Remove obj from db
        Dim objID = getObjID(objectName) 'Set objectID
        Try
            connectString = provider & dataFile
            myConnection.ConnectionString = connectString
            myConnection.Open()
            Dim query As String = "DELETE FROM [objects] WHERE [ObjectID] = " & objID
            Dim command As OleDbCommand = New OleDbCommand(query, myConnection) 'Delete whre obj = the same
            command.ExecuteNonQuery()
            command.Dispose()
            myConnection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            myConnection.Close()
            MsgBox("error")
        End Try
    End Sub

    Sub getCurrentCounters() 'Get the counters from db
        Try
            myConnection.ConnectionString = connectString
            myConnection.Open()
            Dim query As String = "SELECT [ImageCount], [ParagraphCount], [HeadingCount], [AnchorCount] FROM [html] WHERE [HtmlID] = " & htmlID
            Dim command As OleDbCommand = New OleDbCommand(query, myConnection) 'Get counters from table html
            Using readerObj As OleDbDataReader = command.ExecuteReader
                readerObj.Read()
                picCounter = readerObj.Item("ImageCount") 'Set counters
                paraCounter = readerObj.Item("ParagraphCount")
                headingCounter = readerObj.Item("HeadingCount")
                anchorCounter = readerObj.Item("AnchorCount")
            End Using
            command.Dispose()
            myConnection.Close()

        Catch ex As Exception    'If error, it means page not found
            MsgBox("Page not found")
            myConnection.Close()

        End Try
    End Sub


    Sub dbUpdateCounters() 'If object entered/deleted, change the counters in the  database

        Try
            myConnection.ConnectionString = connectString
            myConnection.Open()
            Dim query As String = "UPDATE [html] SET [ImageCount] = " & picCounter & ", [ParagraphCount] = " & paraCounter & ", [HeadingCount] = " & headingCounter & ", [AnchorCount] = " & anchorCounter & " WHERE [HtmlID] = " & htmlID

            'Changes size or position
            Dim command As OleDbCommand = New OleDbCommand(query, myConnection)
            command.ExecuteNonQuery()
            command.Dispose()
            myConnection.Close()

        Catch ex As Exception
            MsgBox("Error")
            Exit Sub
        End Try
    End Sub


    Sub loadObjects() 'Load all objects from objects table 
        Dim objCounter = -1 'Current obj from db

        Dim objStorage As New Dictionary(Of Integer, dbObj) 'Create dictionary which will hold the objects, which is used because variables are created dynamically 

        Try
            myConnection.ConnectionString = connectString
            myConnection.Open()

            Dim dt As New DataTable 'Holds the info about all objects
            Dim ds As New DataSet
            ds.Tables.Add(dt) 'Add the table to dataset
            Dim query As New OleDbDataAdapter

            query = New OleDbDataAdapter("SELECT * from objects WHERE [HtmlID] = " & htmlID, myConnection) 'Get all objs from table objects
            query.Fill(dt) 'Fill the dt with this info

            Dim objectArray = dt.Select() 'the objectArray will have the dataset info

            For i = 0 To objectArray.Length - 1 'Go through every object

                Dim dbObj As dbObj = New dbObj 'Instantiate new obj
                objCounter += 1 'Increment amount of objects
                objStorage.Add(objCounter, dbObj) 'Add obj and current counter into dictionary

                For j = 2 To 9 'Go through the attributes. Start from 2 to ignore ID's

                    Select Case j 'Set the attributes
                        Case 2
                            objStorage(objCounter).objName = (objectArray(i).ItemArray(j)).ToString 'Converting to string because of its data type
                        Case 3
                            objStorage(objCounter).locX = objectArray(i).ItemArray(j)
                        Case 4
                            objStorage(objCounter).locY = objectArray(i).ItemArray(j)
                        Case 5
                            objStorage(objCounter).sizeX = objectArray(i).ItemArray(j)
                        Case 6
                            objStorage(objCounter).sizeY = objectArray(i).ItemArray(j)
                        Case 7
                            objStorage(objCounter).fileLoc = (objectArray(i).ItemArray(j)).ToString
                        Case 8
                            objStorage(objCounter).text = (objectArray(i).ItemArray(j)).ToString
                        Case 9
                            objStorage(objCounter).fontSize = objectArray(i).ItemArray(j)
                    End Select
                Next

            Next
            myConnection.Close()

        Catch ex As Exception    'If error, it means object not found
            myConnection.Close()
        End Try

        recreateObj(objStorage) 'Pass in the obj dictionary to recreate the objects on canvas

    End Sub

    Sub recreateObj(ByVal objStorage) 'Recreate the object
        Dim amountOfOjbs As Integer = objStorage.Count - 1
        Dim objName As String

        Dim locX As Integer
        Dim locY As Integer
        Dim sizeX As Integer
        Dim sizeY As Integer
        Dim fileLoc As String
        Dim text As String
        Dim fontSize As Integer

        For i = 0 To amountOfOjbs 'Go through every object in dictionary

            objName = objStorage(i).objName
            locX = objStorage(i).locX
            locY = objStorage(i).locY
            sizeX = objStorage(i).sizeX
            sizeY = objStorage(i).sizeY
            fileLoc = objStorage(i).fileLoc
            text = objStorage(i).Text
            fontSize = objStorage(i).fontSize

            If objName.Contains("Pic") Then
                Dim tempPic As New PictureBox   'Instantiates new picture box

                tempPic.Name = objName 'Set name
                tempPic.SizeMode = PictureBoxSizeMode.StretchImage 'Make picturebox resize to whatever the image is

                tempPic.Load(fileLoc) 'Show image

                configureObjects(tempPic, False, locX, locY, sizeX, sizeY) 'Add attributes and handlers

            ElseIf objName.Contains("Para") Then
                Dim tempPara As New RichTextBox  'Instantiates new paragraph
                tempPara.Name = objName 'Set name
                tempPara.Text = text 'Set text in textbox
                tempPara.Font = New Font(tempPara.Font.FontFamily, fontSize) 'Change font size
                configureObjects(tempPara, False, locX, locY, sizeX, sizeY) 'Add attributes and handlers

            ElseIf objName.Contains("Heading") Then
                Dim tempHeading As New RichTextBox  'Instantiates new paragraph
                tempHeading.Name = objName 'Set name
                tempHeading.Font = New Font(tempHeading.Font.FontFamily, fontSize) 'Change font size
                tempHeading.Text = text 'Set text in textbox

                configureObjects(tempHeading, False, locX, locY, sizeX, sizeY) 'Add attributes and handlers
            End If

            If locX >= canvasPnl.Location.X And locY >= canvasPnl.Location.Y Then 'If object is on the canvas panel
                onCanvas.Add(objectStack(0)) 'Add the latest added onto the canvas panel list

            End If
        Next

    End Sub


 

End Class


