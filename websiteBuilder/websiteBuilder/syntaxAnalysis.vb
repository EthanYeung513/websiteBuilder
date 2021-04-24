Imports System.IO
Public Module syntaxAnalysis


    'HTML RELATED 
    Dim listOfHtml As New List(Of String) 'Hold html contents
    Dim StackofHtml As New Stack

    Dim htmlErrorCount As Integer = 0 'Holds the number of errors encounted

    'Dim openingList As Array = {"<html>", "<head>", "<title>", "<body>"}
    'Dim closingList As Array = {"</html>", "</head>", "</title>", "</body>"}

    Dim oneTimeTags As Array = {{"<html>", 1}, {"<head>", 1}, {"<title>", 1}, {"<body>", 1}} 'Tags that must only appear once. The 2d part of the tags is the counter.
    'If it equals 1, then there's no instance of it. Else, it has been placed in the file.

    Dim openingOnlyTags As Array = {"img", "link", "meta", "!DOCTYPE"} 'Tags that only don't need another closing tag. e.g, <meta charset='utf-8>
    Dim multiLineopenCloseTags As New Dictionary(Of String, String) 'Opening is key, closing is value, for tags than span multiple lines. e.g, html tag
    Dim oneLineOpenCloseTags As New Dictionary(Of String, String) 'Holds tags that span one line. e.g.title is <title>example.html</title>

    Dim htmlParsed As Boolean = False 'Used to signal if html has already been passed this session. If it is true, then dont add to dictionary


    'CSS RELATED 

    Dim cssBodyTags As New List(Of String) 'Holds tags that are used for html elements in the body. e.g. body{ }, p{ }
    Dim StackofCss As New Stack
    Dim listOfCss As New List(Of String) 'Hold css contents
    Dim cssDeclerations As New List(Of String) 'Hold declerations

    Dim cssErrorCount As Integer = 0

    Dim cssParsed As Boolean = False 'Used to signal if css has already been passed this session. If it is true, then dont add to list






    Public Sub Main()






    End Sub

    Public Sub parseHtml()

        Try
            pageWriter.Close()
            pageReader.Close()
        Catch
        End Try

        pageReader = My.Computer.FileSystem.OpenTextFileReader(fileDirectory & pageName)

        If htmlParsed = False Then 'If not already parsed
            fillHtmlValues() 'Add values into the dictionaries
        Else 'Already parsed
            oneTimeTags = {{"<html>", 1}, {"<head>", 1}, {"<title>", 1}, {"<body>", 1}} 'Tags that must only appear once. The 2d part of the tags is the counter.
        End If

        listOfHtml.Clear() 'Empty html list 
        StackofHtml.Clear()
        readAllHtml()


        Dim lengthOf = listOfHtml.Count() - 1

        Dim tempLine = "" 'Line that is currently being read

        For i = 0 To lengthOf 'Go from html opening tag
            tempLine = listOfHtml(i)
            If multiLineopenCloseTags.ContainsKey(tempLine) Then 'If it is a opening and is a multi line tag
                parseMultiLineOpeningTag(tempLine) 'Parse the opening tag 

            ElseIf multiLineopenCloseTags.ContainsValue(tempLine) Then 'If it has closing tag 
                parseMultiLineClosingTag(tempLine, i) 'Parse the closing tag

                'ElseIf tempLine.Contains(openingOnlyTags Then 'If 
                '    Console.WriteLine("found")
            Else 'It is a one line html tag, which has both a seperate closing and opening tag
                Dim getLineInfo = retrieveOneLineTag(tempLine) 'Return the opening, closing, and content of a one line tag in a list. 
                If getLineInfo(2) = tempLine Then 'This means it is a one tag element
                    parseOneTag(tempLine, i)
                Else
                    parseOneLineTag(getLineInfo, i) 'Parse the one line tag that has seperate closing and opening tag

                End If
            End If

        Next


        If StackofHtml.Count <> 0 Or htmlErrorCount <> 0 Then 'If stack not empty
            MsgBox(Str(htmlErrorCount + StackofHtml.Count) & " ERROR(s) detected")
            For Each i In StackofHtml
                MsgBox(i & " needs to be closed off")
            Next
        Else

            MsgBox("No errors detected")
        End If

        htmlParsed = True 'Signal that html is parsed
    End Sub

    Sub parseOneTag(ByVal tempLine, ByVal currentLineIndex) ''Tags that only don't need another closing tag. e.g, <meta charset='utf-8>
        Dim position = Len(tempLine) - 1
        Dim tag As String = "" 'The tag in the tempLine string
        If tempLine(0) <> "<" Or tempLine(position) <> ">" Then 'If it doesnt have a opening or closing tag at the start or bottom
            htmlErrorCount += 1

            MsgBox("Error at line" & currentLineIndex & " , '<' or '>' missing")

        End If

        position = 1
        Try
            Do 'Get the tag
                tag += tempLine(position) 'Add to the tag string the current position
                position += 1
            Loop Until tempLine(position) = " "
        Catch
            MsgBox("Error at line" & currentLineIndex & " , '<' or '>' missing")
        End Try
        Dim found As Boolean = False
        For Each item In openingOnlyTags
            If item = tag Then 'If the tag is the same
                found = True 'Set boolean to true
                Exit For
            End If
        Next

        If found = False Then
            htmlErrorCount += 1

            MsgBox("Error at line" & currentLineIndex & " tag is not identified.")

        End If

    End Sub

    Sub parseMultiLineOpeningTag(ByVal tempLine)
        Dim duplicateTag As Boolean = False 'If a tag that should be used once appears twice, set to false 

        For j = 0 To 3
            If oneTimeTags(j, 0) = tempLine And oneTimeTags(j, 1) = 1 Then 'If its a one time tag and its not already been placed
                oneTimeTags(j, 1) = 0 'Set row of tag to 0 to signify its been placed
                Exit For
            ElseIf oneTimeTags(j, 0) = tempLine And oneTimeTags(j, 1) = 0 Then 'If this tag has already been placed
                oneTimeTags(j, 1) -= 1 'Signal how many extra instances of this tag are

                MsgBox("Error, tag " & tempLine & "can only be placed once.")

                duplicateTag = True 'Signal dupplication error
                Exit For
            End If
        Next
        If duplicateTag = False Then 'If no duplication error 
            StackofHtml.Push(tempLine) 'Push to stack
        End If
    End Sub


    Sub parseMultiLineClosingTag(ByVal tempLine, ByVal currentLineIndex)

        Try
            If multiLineopenCloseTags(StackofHtml.Peek) = tempLine Then 'If the closing tag on the top of the stsack is the same type of tag as the one here
                StackofHtml.Pop() 'Pop of stack because valid closing tag
            Else

                MsgBox("Error: opening or closing tag missing for " & multiLineopenCloseTags(StackofHtml.Peek) & " tag.")
                StackofHtml.Pop() 'Pop of stack because it will affect other closing tags if not popped
                StackofHtml.Pop()
                htmlErrorCount += 1 'Increment error count
            End If
        Catch ex As Exception
            MsgBox("Error at line" & currentLineIndex & " opening or closing tag missing")
            StackofHtml.Pop() 'Pop of stack because it will affect other closing tags if not popped
            htmlErrorCount += 1 'Increment error count
        End Try


    End Sub

    Sub parseOneLineTag(ByVal lineInfo, ByVal currentLineIndex)

        If oneLineOpenCloseTags.ContainsKey(lineInfo(0)) Then 'If dictionary contains the opening tag
            StackofHtml.Push(lineInfo(0)) 'Push opening tag onto the stack
            If oneLineOpenCloseTags(StackofHtml.Peek) = lineInfo(2) Then 'If the closing tags are the same
                StackofHtml.Pop() 'Pop off stack
            Else
                MsgBox("ERROR AT LINE" & Str(currentLineIndex + 1) & " closing tag missing")
                htmlErrorCount += 1 'Increment error count
                StackofHtml.Pop() 'Pop off stack
            End If
        Else
            MsgBox("ERROR AT LINE" & Str(currentLineIndex + 1) & " opening tag not identified")
            htmlErrorCount += 1 'Increment error count
        End If

    End Sub

    Function retrieveOneLineTag(ByVal currentLine)  'Return the opening, closing, and content of a one line tag
        Dim returnList As New List(Of String) 'Return array that contains the opening, closing, and content of a one line tag

        Dim tempOpening = ""
        Dim tempClosing = ""
        Dim contentStart As Integer 'Index of start of content
        Dim contentEnd As Integer 'Index of end of content
        Dim content = ""

        Dim position = 0

        Dim classStart As Boolean = False 'Signals of the class start, if false, keep adding to tempOpening because
        'It is still adding the tag.

        Try
            Do 'Get position of the start of the content (between the tags)
                If classStart = False Then
                    tempOpening += currentLine(position) 'Add to the opening tag string
                End If

                Try 'Might create error if it only utilises one tag.
                    If currentLine((position + 1)) = " " Then 'If space
                        classStart = True 'If there's a space, that means that this position is where the class starts.
                        Exit Do
                    End If
                Catch
                End Try

                position += 1 'Increment position

            Loop Until currentLine(position) = ">" 'Loop until end of opening tag 
        Catch
            MsgBox("Error: '>' is missing from currentline")


        End Try

        contentStart = position + 1 'Set the end of the opening tag, which is the start of the content 
        tempOpening += ">"


        '<p class='Para1'>Test</p>

        position = Len(currentLine) - 1
        Try
            Do 'Get the closing tag
                tempClosing += currentLine(position)
                position -= 1 'Decrement position
            Loop Until currentLine(position) = "<" 'Loop until end of closing tag
            tempClosing += "<"
            tempClosing = StrReverse(tempClosing)
            contentEnd = position - 1
        Catch
            MsgBox("Error: '>' is missing from currentline")
        End Try


        For i = contentStart To contentEnd 'Get the content
            content += currentLine(i)
        Next

        returnList.Add(tempOpening)
        returnList.Add(content)
        returnList.Add(tempClosing)

        Return returnList

    End Function

    Sub fillHtmlValues() 'Add values into the dictionaries
        multiLineopenCloseTags.Add("<html>", "</html>") 'Adding the opening and closing tags
        multiLineopenCloseTags.Add("<head>", "</head>")
        multiLineopenCloseTags.Add("<body>", "</body>")
        multiLineopenCloseTags.Add("<div>", "</div>")

        oneLineOpenCloseTags.Add("<title>", "</title>")
        oneLineOpenCloseTags.Add("<p>", "</p>")
        oneLineOpenCloseTags.Add("<a>", "</a>")

        For x = 1 To 6 'Loop to add in heading tag
            oneLineOpenCloseTags.Add("<h" & x & ">", "</h" & x & ">")

        Next
    End Sub


    Sub readAllHtml()


        While Not pageReader.EndOfStream()
            listOfHtml.Add(pageReader.ReadLine())       'Read line from textfile
        End While


    End Sub

    'START OF CSS SYNTAX ANALYSIS

    Sub parseCss()

        Try 'Try to close css file
            cssWriter.Close()
            cssReader.Close()
        Catch
        End Try

        cssReader = My.Computer.FileSystem.OpenTextFileReader(fileDirectory & "style.css")

        If cssParsed = False Then 'If css not already parse
            fillValues()
        End If


        listOfCss.Clear() 'Clear css list
        StackofCss.Clear()
        readAllCSS() 'Get all css content

        Dim lengthOf = listOfCss.Count() - 1

        Dim tempLine = "" 'Line that is currently being read

        For i = 0 To lengthOf 'Go from css opening tag
            tempLine = listOfCss(i)



            If Len(tempLine) = 0 Then 'If empty string, skip this iteration

            ElseIf cssBodyTags.Contains(tempLine.Substring(0, tempLine.Length - 1)) Then 'If it is a opening and is a multi line tag
                parseCssOpeningBodyTag(tempLine)
            ElseIf tempLine = "}" Then 'Closing tag
                processClosing(tempLine)
            ElseIf tempLine(0) = "." Then 'If its a opening class
                parseClassOpening(tempLine)
            Else 'It's a decleration e.g. left:20px;
                parseDecleration(tempLine)

            End If
        Next

        If cssErrorCount = 0 Then
            MsgBox("No errors detected")
        Else
            MsgBox(Str(cssErrorCount) & " errors detected")
        End If
        cssParsed = True

    End Sub

    Sub parseCssOpeningBodyTag(ByVal tempLine)
        Dim position = Len(tempLine) - 1
        If tempLine(position) <> "{" Then 'If missing a '{'
            cssErrorCount += 1
            MsgBox("Error, " & tempLine & " is missing '{'")
        End If

        If StackofCss.Count > 0 Then 'If stack not empty
            cssErrorCount += 1
            MsgBox("Error, must close of class with '{' before declaring another class.")
            StackofCss.Clear()

        End If

        StackofCss.Push(tempLine.Substring(0, tempLine.Length - 1))
    End Sub

    Sub processClosing(ByVal tempLine)
        Try
            StackofCss.Pop()
        Catch
            cssErrorCount += 1
            MsgBox("Error,  '{' is missing")
        End Try
    End Sub

    Sub parseClassOpening(ByVal tempLine)
        Dim position = Len(tempLine) - 1
        If tempLine(position) <> "{" Then
            cssErrorCount += 1
            MsgBox("Error, " & tempLine & " is missing '{'")
        End If

        If StackofCss.Count > 0 Then 'If stack not empty
            cssErrorCount += 1
            MsgBox("Error, must close of class with '{' before declaring another class.")
            StackofCss.Clear()

        End If

        StackofCss.Push(tempLine.Substring(0, tempLine.Length - 1))
    End Sub

    Sub parseDecleration(ByVal tempLine)
        Dim lengthOf As Integer = Len(tempLine) - 1
        Dim decleration As String = ""
        Dim declerationEnd As Integer = 0 'Index of where decleration ends

        If cssBodyTags.Contains(tempLine) Then
            cssErrorCount += 1
            StackofCss.Push(tempLine)
            MsgBox("Error, missing '{'.")
            Exit Sub
        End If

        For i = 0 To lengthOf 'Get the decleration and the index of where it ends
            If tempLine(i) = ":" Then 'Signals end of decleration
                Exit For
                declerationEnd = i
            End If
            decleration += tempLine(i)
        Next

        If cssDeclerations.Contains(decleration) = False Then 'If decleration not recognised
            cssErrorCount += 1
            MsgBox("Error, decleration not recognised.")
            Exit Sub
        End If

        If tempLine(lengthOf) <> ";" Then
            cssErrorCount += 1
            MsgBox("Error, ';' is missing at the end of line.")
        End If

    End Sub

    Sub readAllCSS() 'Read everyline of HTML and put it into an array

        While Not cssReader.EndOfStream()
            listOfCss.Add(cssReader.ReadLine())     'Read line from textfile
        End While

        cssReader.Close()

    End Sub

    Sub fillValues()

        cssBodyTags.Add("body")
        cssBodyTags.Add("div")
        cssBodyTags.Add("p")
        cssBodyTags.Add("a")
        cssBodyTags.Add("img")

        For x = 1 To 6 'Loop to add in heading tag
            cssBodyTags.Add("h" & x & "")

        Next

        cssDeclerations.Add("color")
        cssDeclerations.Add("left")
        cssDeclerations.Add("top")
        cssDeclerations.Add("width")
        cssDeclerations.Add("height")
        cssDeclerations.Add("position")
        cssDeclerations.Add("font-size")
        cssDeclerations.Add("font-family")
        cssDeclerations.Add("background-color")

    End Sub

End Module

