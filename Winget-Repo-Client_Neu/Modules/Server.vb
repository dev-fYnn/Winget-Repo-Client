Imports System.Net.Http
Imports Newtonsoft.Json

Public Class Paket
    Public Property PACKAGE_ID As String
    Public Property PACKAGE_NAME As String
    Public Property PACKAGE_PUBLISHER As String
    Public Property PACKAGE_DESCRIPTION As String
End Class

Public Module Server
    Public Async Function GetPackagesFromServer(serverUrl As String, authToken As String, Optional gui As Boolean = False) As Task(Of List(Of Paket))
        Using client As New HttpClient()
            Dim content = New FormUrlEncodedContent(New Dictionary(Of String, String) From {
                {"Auth-Token", authToken}
            })

            Try
                Dim response As HttpResponseMessage = Await client.PostAsync($"{serverUrl}/get_packages", content)
                response.EnsureSuccessStatusCode()

                Dim jsonString As String = Await response.Content.ReadAsStringAsync()
                Dim pakete = JsonConvert.DeserializeObject(Of List(Of Paket))(jsonString)

                Return If(pakete, New List(Of Paket)())
            Catch ex As Exception
                If gui Then
                    Form1.Status.Text = "Loading not possible! Change the settings und try again!"
                End If
                Return New List(Of Paket)()
            End Try
        End Using
    End Function
End Module
