Imports System.Net.Http
Imports Newtonsoft.Json
Imports System.Net
Imports System.IO

Public Class Paket
    Public Property PACKAGE_ID As String
    Public Property PACKAGE_NAME As String
    Public Property PACKAGE_PUBLISHER As String
    Public Property PACKAGE_DESCRIPTION As String
    Public Property PACKAGE_LOGO As String
    Public Property VERSIONS As List(Of String)
End Class

Public Module Server
    Public Class VersionCheckResponse
        Public Property Version As String
    End Class

    Public Async Function IsClientUpToDate(currentVersion As Version) As Task(Of Boolean)
        Dim s_url As String = $"{SERVER_URL}/client/api/client_version"
        If CLOUD Then
            s_url = $"{SERVER_URL}/client/api/{REPO_NAME}/client_version"
        End If

        Dim client As New HttpClient()

        Try
            Dim requestBody = New StringContent("{}", System.Text.Encoding.UTF8, "application/json")
            Dim response As HttpResponseMessage = Await client.PostAsync(s_url, requestBody)

            If response.IsSuccessStatusCode Then
                Dim jsonString As String = Await response.Content.ReadAsStringAsync()
                Dim serverResponse As VersionCheckResponse = JsonConvert.DeserializeObject(Of VersionCheckResponse)(jsonString)

                Dim serverVersion As New Version(serverResponse.Version)
                Return currentVersion >= serverVersion
            Else
                Return True
            End If
        Catch ex As Exception
            Return True
        End Try
    End Function


    Public Async Function GetPackagesFromServer(serverUrl As String, authToken As String, Optional gui As Boolean = False) As Task(Of List(Of Paket))
        Using client As New HttpClient()
            Dim content = New FormUrlEncodedContent(New Dictionary(Of String, String) From {
                {"Auth-Token", authToken}, {"Client", 1}
            })

            Dim s_url As String = $"{serverUrl}/client/api/get_packages"
            If CLOUD Then
                s_url = $"{serverUrl}/client/api/{REPO_NAME}/get_packages"
            End If

            Try
                Dim response As HttpResponseMessage = Await client.PostAsync(s_url, content)
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

    Public Function GetLogoforPackage(imageName As String) As Image
        Try
            Dim s_url As String = $"{SERVER_URL}/client/api/get_logo/{imageName}"
            If CLOUD Then
                s_url = $"{SERVER_URL}/client/api/{REPO_NAME}/get_logo/{imageName}"
            End If

            Dim request As WebRequest = WebRequest.Create(s_url)
            Using response As WebResponse = request.GetResponse()
                Using stream As Stream = response.GetResponseStream()
                    Dim img As Image = Image.FromStream(stream)

                    Dim resizedImage As New Bitmap(65, 65)

                    Using g As Graphics = Graphics.FromImage(resizedImage)
                        g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                        g.DrawImage(img, 0, 0, 65, 65)
                    End Using

                    Return resizedImage
                End Using
            End Using
        Catch ex As Exception
        End Try
    End Function
End Module
