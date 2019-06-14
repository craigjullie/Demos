Imports System.Configuration.ConfigurationManager
Imports System.Data.SqlClient
Imports UAParser

Module MainMod

  Dim _ConnString As String = ConnectionStrings("TestDB").ConnectionString

  Sub Main()
    Dim UserAgentData As DataTable = GetUserAgentData()
    For Each Row As DataRow In UserAgentData.Rows
      UpdateRecord(Row)
    Next
    Using Conn As New SqlConnection(_ConnString)
      Conn.Open()
      Using BulkCopy As New SqlBulkCopy(Conn)
        BulkCopy.DestinationTableName = "UserAgentDataRerun"
        BulkCopy.WriteToServer(UserAgentData)
      End Using
      Conn.Close()
    End Using
  End Sub

  Private Function GetUserAgentData() As DataTable
    Dim Conn As New SqlConnection(_ConnString)
    Dim Cmd As New SqlCommand("select * from UserAgentData order by ID ASC")
    Dim Adapter As New SqlDataAdapter
    Dim UserAgentData As New DataTable
    Conn.Open()
    Cmd.Connection = Conn
    Adapter.SelectCommand = Cmd
    Adapter.Fill(UserAgentData)
    Conn.Close()
    Return UserAgentData
  End Function

  Private Sub UpdateRecord(ByRef row As DataRow)
    Dim UAParser As Parser = Parser.GetDefault()
    Dim ParsedInfo As ClientInfo = UAParser.Parse(row("UserAgent"))
    Dim BrowserVersion As String = String.Empty
    Dim OperatingSystemVersion As String = String.Empty
    Dim Device As String = GetDevice(ParsedInfo)
    Dim Browser As String = GetBrowser(ParsedInfo, BrowserVersion)
    Dim OperatingSystem As String = GetOperatingSystem(ParsedInfo, OperatingSystemVersion)
    row("Device") = Device
    row("OperatingSystem") = OperatingSystem
    row("OperatingSystemVersion") = OperatingSystemVersion
    row("Browser") = Browser
    row("BrowserVersion") = BrowserVersion
    row("LastModified") = Now
  End Sub

  Private Function GetDevice(ByVal parsedInfo As ClientInfo) As String
    Dim Device As String = parsedInfo.Device.Family
    Dim OperatingSystem As String = parsedInfo.OS.Family
    If Device = "Other" Then
      If OperatingSystem = "Linux" OrElse OperatingSystem = "Ubuntu" OrElse OperatingSystem.Contains("Windows") OrElse OperatingSystem.Contains("Mac") OrElse OperatingSystem = "Chrome OS" Then
        Device = "Computer"
      End If
    End If
    Return Device
  End Function

  Private Function GetBrowser(ByVal parsedInfo As ClientInfo, ByRef browserVersion As String) As String
    Dim Browser As String = parsedInfo.UserAgent.Family
    If IsNothing(parsedInfo.UserAgent.Major) = False Then
      browserVersion = String.Concat(parsedInfo.UserAgent.Major, ".", parsedInfo.UserAgent.Minor)
    Else
      browserVersion = String.Empty
    End If
    If parsedInfo.ToString.Contains("AOL") Then
      Browser = "AOL Browser"
      If parsedInfo.ToString.Contains("AOL/") Then
        Dim BrowserSplit As String() = parsedInfo.String.Split(New String() {"AOL/"}, StringSplitOptions.RemoveEmptyEntries)
        Dim BrowserSplit2 As String = BrowserSplit(1)
        Dim BrowserSplit3 As String() = BrowserSplit2.Split(" ")
        browserVersion = BrowserSplit3(0)
      Else
        browserVersion = String.Empty
      End If
    End If
    Return Browser
  End Function

  Private Function GetOperatingSystem(ByVal parsedInfo As ClientInfo, ByRef operatingSystemVersion As String) As String
    Dim OperatingSystem As String = parsedInfo.OS.Family
    If IsNothing(parsedInfo.OS.Major) = False Then
      operatingSystemVersion = parsedInfo.OS.Major
      If IsNothing(parsedInfo.OS.Minor) = False Then
        operatingSystemVersion &= "." & parsedInfo.OS.Minor
      End If
    Else
      operatingSystemVersion = String.Empty
    End If
    If OperatingSystem.Contains("Windows Phone") = False Then
      Dim Split As String() = OperatingSystem.Split(" ")
      If Split.Length > 1 Then
        OperatingSystem = Split(0)
        operatingSystemVersion = Split(1)
      End If
    End If
    Return OperatingSystem
  End Function

End Module
