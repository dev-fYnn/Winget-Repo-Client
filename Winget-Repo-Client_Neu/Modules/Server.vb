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
    Public Async Function GetPackagesFromServer(serverUrl As String, authToken As String, Optional gui As Boolean = False) As Task(Of List(Of Paket))
        Using client As New HttpClient()
            Dim content = New FormUrlEncodedContent(New Dictionary(Of String, String) From {
                {"Auth-Token", authToken}, {"Client", 1}
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

    Public Function GetLogoforPackage(imageName As String) As Image
        Try
            Dim request As WebRequest = WebRequest.Create($"{SERVER_URL}/get_logo/{imageName}")
            Using response As WebResponse = request.GetResponse()
                Using stream As Stream = response.GetResponseStream()
                    Dim img As Image = Image.FromStream(stream)

                    Dim resizedImage As New Bitmap(70, 70)

                    Using g As Graphics = Graphics.FromImage(resizedImage)
                        g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                        g.DrawImage(img, 0, 0, 70, 70)
                    End Using

                    Return resizedImage
                End Using
            End Using
        Catch ex As Exception
        End Try
    End Function
End Module
