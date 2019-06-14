Imports System.Configuration.ConfigurationManager
Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.Net.Security
Imports System.Security.Cryptography.X509Certificates

Module MainMod

  Dim _ConnString As String = ConnectionStrings("TestDB").ConnectionString

  Sub Main()
    Dim UserAgentData As DataTable = GetUserAgentData()
    Dim JSONList As List(Of String) = BuildJSONList(UserAgentData)
    Dim PostData As String = BuildJSONPost(JSONList)
    SubmitJSONRequest(PostData)
    Console.ReadKey()
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

  Private Function BuildJSONList(ByVal userAgentData As DataTable) As List(Of String)
    Dim JSONList As New List(Of String)
    Dim JSONLine As String
    For Each Row As DataRow In userAgentData.Rows
      JSONLine = "  """ & Row("ID").ToString & """: """ & Row("UserAgent").ToString & """"
      JSONList.Add(JSONLine)
    Next
    Return JSONList
  End Function

  Private Function BuildJSONPost(ByVal jsonList As List(Of String)) As String
    Dim PostData As String = "{""user_agents"": {"
    For Each Line As String In jsonList
      PostData &= vbCrLf & Line
    Next
    PostData &= vbCrLf & "}}"
    Return PostData
  End Function

  Private Sub SubmitJSONRequest(ByVal postData As String)
    Dim Request As HttpWebRequest
    Dim Response As HttpWebResponse
    Dim Reader As StreamReader
    Dim RawResponse As String

    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
    'https://api.whatismybrowser.com/api/v2/user_agent_parse_batch
    Request = DirectCast(WebRequest.Create("https://api.whatismybrowser.com/api/v2/user_agent_parse_batch"), HttpWebRequest)
    Request.Headers.Add("X-API-KEY", "91b8b3483b699ccadd3cfff06a742d03")
    Request.ContentType = "application/json"
    Request.Method = "POST"
    Request.ContentLength = postData.Length

    Dim RequestWriter As New StreamWriter(Request.GetRequestStream())
    RequestWriter.Write(postData)
    RequestWriter.Close()

    Response = DirectCast(Request.GetResponse(), HttpWebResponse)
    Reader = New StreamReader(Response.GetResponseStream())
    RawResponse = Reader.ReadToEnd()
    Console.ReadKey()
  End Sub

  Private Sub SubmitJSONRequestV2(ByVal postData As String)
    ServicePointManager.ServerCertificateValidationCallback = New Security.RemoteCertificateValidationCallback(AddressOf ValidateRemoteCertificate)
    Dim Resp As HttpWebResponse
    Dim DataStream As Stream
    Dim Request As HttpWebRequest = HttpWebRequest.Create("https://api.whatismybrowser.com/api/v2/user_agent_parse_batch")

    Request.Headers.Add("X-API-KEY", "91b8b3483b699ccadd3cfff06a742d03")
    Request.Accept = "*/*"
    Request.Method = "POST"
    Dim ByteArray As Byte() = System.Text.Encoding.[Default].GetBytes(postData)
    Request.ContentType = "application/json"
    Request.ContentLength = ByteArray.Length
    DataStream = Request.GetRequestStream()
    DataStream.Write(ByteArray, 0, ByteArray.Length)
    DataStream.Close()

    Resp = Request.GetResponse()
    Dim DataStreamReturn As Stream = Resp.GetResponseStream()
    Dim Reader As New StreamReader(DataStreamReturn)
    Dim ResponseFromServer As String = Reader.ReadToEnd()
    Console.ReadKey()
  End Sub

  Private Function ValidateRemoteCertificate(ByVal sender As Object, ByVal certificate As X509Certificate, ByVal chain As X509Chain, ByVal policyErrors As SslPolicyErrors) As Boolean
    If policyErrors = System.Net.Security.SslPolicyErrors.None Then
      Return True
    End If
    Console.WriteLine("X509Certificate [{0}] Policy Error: '{1}'", certificate.Subject, policyErrors.ToString)
    Return False
  End Function

End Module
