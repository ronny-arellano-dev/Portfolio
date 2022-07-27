Attribute VB_Name = "Module1"
' SaveBlastCSV ver. 2.1.1
' Written by Ronny Arellano

' Description:
'   This script is written to take the data blast info from
'  IPL Blasting email and either make a new file in the
'  correct folder or merge it with a file with the same name

' Version 3.0.0 20171130
'   - Updated for new App version and new export format
'   - Separated functions into different subs
' Version 2.1.1 20160203
'   - Cleaned up code. Forced all files to be save in temp folder for parsing
' Version 2.1.0 20160129
'   - Fixed issue with very first file having all data, regardless of
'     hole pattern number. Forced parse of all files, not just the
'     additional files.
' Version 2.0.0 20160129
'   - Added Parsing code to differentiate info from new files
' Version 1.1.0 20160128
'   - Added feature for appending new info to current files.
' Version 1.0.0 20160127
'   - Basic code for saving blast info attachments


    ' Variables
    Dim savePath As String      ' Save path for attachment
    Dim savePathtemp As String  ' Temporary save for file parse
    Dim saveMaster As String    ' Master File
    Dim saveName As String      ' Name to save attachment as
    Dim saveFolder As String    ' Path of Parent folder
    Dim fileType() As String    ' S is samples and E is explosives
    Dim filename As String      ' Holds the concatenated Filename
    Dim SourceNum As Integer    ' File number of Temp save
    Dim DestNum As Integer      ' File number of Master save
    Dim CorrectNum As Integer   ' File number of Correct save
    Dim Temp As String          ' String to hold parsing info
    Dim fileHeaders As String   ' String to hold Header
    Dim mainEntry As String     ' Holds the main pattern ID, pulled from file name
    Dim patternID As String     ' Holds the pattern ID from line being checked
    Dim wholeID As String       ' Holds whole ID
    Dim tempEntry As String     ' Holds first entry in line to be fixed for comparing
    Dim lineArray() As String   ' Splits the line into an array separated by ","
    Dim headerArray() As String ' Splits the header into an array separated by ","
    Dim correctName As String   ' Holds path and file name of correct file
    
    Dim objAtt As Outlook.Attachment
        
Public Sub saveBlastCSVtoDisk(itm As Outlook.MailItem)
    
    ' Set the Parent Folder
    saveFolder = "\\app02-ipl\acQuire\Test data"
    
    ' Sort through attachments
    For Each objAtt In itm.Attachments
        
        ' Select CSV files
        If InStr(objAtt.filename, ".csv") Then
            
            ' Create array of name and figure out if the file
            ' is for Samples or Explosives
            
            filename = objAtt.filename
            fileType() = Split(filename, "_")
            
            ' If the file has S, Send to Samples
            If fileType(1) = "S" Then
                savePath = saveFolder & "\Samples\"
                savePathtemp = savePath & "Temp\" & filename
                Call SaveFile
                Call MergeFile
            
            ' If the file has E, send to Explosives
            ElseIf fileType(1) = "E" Then
                savePath = saveFolder & "\Explosives\"
                savePathtemp = savePath & "Temp\" & filename
                Call SaveFile
                Call MergeFile
    
            End If
        
        End If

     Next

End Sub
Private Sub SaveFile()
    
' Save every file to temp folder for parsing
objAtt.SaveAsFile savePathtemp
Set objAtt = Nothing
    
End Sub
Private Function CheckExist() As Boolean

If Dir(saveMaster) <> "" Then
    CheckExist = True
Else
    CheckExist = False
End If

End Function

Private Sub MergeFile()

' Open the source text file
SourceNum = FreeFile()
Open savePathtemp For Input As SourceNum

' Skips the first line(headers) and store for later use
Line Input #SourceNum, fileHeaders

' Read each line of the source file and append it to the destination file.
Do While Not EOF(SourceNum)
              
    ' Get pattern number info of each entry of file
    Line Input #SourceNum, Temp
    
    ' Split line into array
    lineArray() = Split(Temp, ",")
    
    ' Get pattern ID from array and remove hole ID
    wholeID = lineArray(0)
    patternID = Mid(wholeID, 1, 7)
    
    ' Create file name and path name strings
    saveName = patternID & "_" & fileType(1) & "_" & fileType(0) & ".csv"
    saveMaster = savePath & saveName
    
    ' Run function to check if it exists
    Call CheckExist
    
    If CheckExist = True Then
        
        DestNum = FreeFile()
        Open saveMaster For Append As DestNum
        Print #DestNum, Temp
        Close #DestNum
        
    Else
       
        DestNum = FreeFile()
        Open saveMaster For Append As DestNum
        Print #DestNum, fileHeaders
        Print #DestNum, Temp
        Close #DestNum
        
    End If
  
Loop

CloseFiles:

    ' Close the destination file and the source file.
    Close #SourceNum
    Kill savePathtemp
    Exit Sub

    
End Sub

