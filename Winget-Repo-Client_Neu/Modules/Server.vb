Imports System.Net.Http
Imports Newtonsoft.Json
Imports System.Net
Imports System.IO

Public Class Paket
    Public Property PACKAGE_ID As String
    Public Property PACKAGE_NAME As String
    Public Property PACKAGE_PUBLISHER As String
    Public Property PACKAGE_DESCRIPTION As String
    Public Property PACKAGE_LOGO
    Public Property VERSIONS As List(Of String)
End Class

Public Module Server
    Public Class VersionCheckResponse
        Public Property Version As String
    End Class

    Public Async Function IsClientUpToDate(currentVersion As Version, authToken As String) As Task(Of Boolean)
        Dim content = New FormUrlEncodedContent(New Dictionary(Of String, String) From {
            {"Auth-Token", authToken}, {"Client", 1}
        })

        Dim s_url As String = $"{SERVER_URL}/client/api/client_version"
        If CLOUD Then
            s_url = $"{SERVER_URL}/client/api/{REPO_NAME}/client_version"
        End If

        Dim client As New HttpClient()

        Try
            Dim response As HttpResponseMessage = Await client.PostAsync(s_url, content)

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

                For Each p As Paket In pakete
                    Try
                        Dim base64Data As String = p.PACKAGE_LOGO
                        If base64Data.StartsWith("data:image") Then
                            Dim commaIndex As Integer = base64Data.IndexOf(","c)
                            If commaIndex >= 0 Then
                                base64Data = base64Data.Substring(commaIndex + 1)
                            End If
                        End If

                        Dim imageBytes As Byte() = Convert.FromBase64String(base64Data)
                        Using ms As New MemoryStream(imageBytes)
                            Dim originalImage As Image = Image.FromStream(ms)
                            Dim resizedImage As New Bitmap(65, 65)
                            Using g As Graphics = Graphics.FromImage(resizedImage)
                                g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                                g.DrawImage(originalImage, 0, 0, 65, 65)
                            End Using

                            p.PACKAGE_LOGO = resizedImage
                        End Using
                    Catch ex As Exception
                        p.PACKAGE_LOGO = Nothing
                    End Try
                Next

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
