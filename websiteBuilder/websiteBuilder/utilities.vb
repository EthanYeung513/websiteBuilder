Imports System.Data.OleDb
Imports System.Security.Cryptography
Imports System.Text
Imports System.IO
Module utilities
    Public provider As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="
    Public dataFile As String = "myDb.accdb"
    Public connectString As String = provider & dataFile
    Public myConnection As OleDbConnection = New OleDbConnection



    Public userID As String
    Public username As String

    Public websiteName As String
    Public websiteID As String
    Public htmlID As String
    Public pageName As String


    Public pageWriter As StreamWriter
    Public pageReader As StreamReader

    Public cssWriter As StreamWriter
    Public cssReader As StreamReader

    Public folderName As String
    Public fileDirectory As String



    'GIVING VALUES BECAUSE OF TESTING, DELETE AFTER AND UNCOMMENT ABOVE
    'Public userID As String = 4
    'Public username As String = "test"

    'Public websiteName As String = "newTest"
    'Public websiteID As Integer = 31
    'Public htmlID As Integer
    'Public pageName As String = "index.html"


    'Public folderName As String = username & "_" & websiteName  'Make folder name using their username and website name
    'Public fileDirectory As String = My.Application.Info.DirectoryPath & "\" & folderName & "\" 'Get the path

    'Public pageWriter As StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(fileDirectory & pageName, False) 'Setup writers of the new page
    'Public pageReader As StreamReader

    'Public cssWriter As StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(fileDirectory & "style.css", False)
    'Public cssReader As StreamReader

    'DELETE ABOVE BECAUSE ITS A TEST 



    Public Function GenerateSHA256(ByVal inputString) As String  'Generates a hash string
        Dim sha256 As SHA256 = SHA256Managed.Create()
        Dim bytes As Byte() = Encoding.UTF8.GetBytes(inputString)
        Dim hash As Byte() = sha256.ComputeHash(bytes)
        Dim stringBuilder As New StringBuilder()



        For i As Integer = 0 To hash.Length - 1
            stringBuilder.Append(hash(i).ToString("X2"))
        Next

        Return stringBuilder.ToString()

    End Function


    Public Function GenerateSalt() 'Generate a 5 character long salt
        Dim rand As New Random
        Dim tempSalt As String = ""
        Dim tempChar As String

        For x = 0 To 4
            tempChar = rand.Next(65, 91).ToString  'Generate ascii values from A to Z
            tempChar = Chr(tempChar) 'Turn ascii value into charactert
            tempSalt += tempChar 'Append to salt
        Next

        Return tempSalt
    End Function
End Module
