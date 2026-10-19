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
    Public Property PACKAGE_LOGO_URL As String
    Public Property VERSIONS As List(Of String)
End Class

Public Module Server
    Private ReadOnly logoHttpClient As New HttpClient()

    Public Class VersionCheckResponse
        Public Property Version As String
    End Class


    Public Async Function GetPackagesFromServer(serverUrl As String, authToken As String, Optional gui As Boolean = False) As Task(Of List(Of Paket))
        ServicePointManager.DefaultConnectionLimit = Math.Max(ServicePointManager.DefaultConnectionLimit, 20)

        Using client As New HttpClient()
            Dim content = New FormUrlEncodedContent(New Dictionary(Of String, String) From {
                {"auth_token", authToken}, {"client", 1}
            })

            Dim s_url As String = $"{serverUrl}/client/api/get_packages"
            If CLOUD Then
                s_url = $"{serverUrl}/get_packages"
            End If

            Try
                Dim response As HttpResponseMessage = Await client.PostAsync(s_url, content)
                response.EnsureSuccessStatusCode()

                Dim jsonString As String = Await response.Content.ReadAsStringAsync()
                Dim pakete = JsonConvert.DeserializeObject(Of List(Of Paket))(jsonString)

                For Each p As Paket In pakete
                    p.PACKAGE_LOGO_URL = Convert.ToString(p.PACKAGE_LOGO)
                    p.PACKAGE_LOGO = GetDummyPackageLogo()
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

    Public Async Function GetPackageLogoAsync(logoUrl As String, serverUrl As String) As Task(Of Image)
        If String.IsNullOrWhiteSpace(logoUrl) Then Return GetDummyPackageLogo()

        Try
            Dim resolvedLogoUrl As Uri = Nothing
            If Not Uri.TryCreate(logoUrl, UriKind.Absolute, resolvedLogoUrl) Then
                Dim serverUri As New Uri(If(serverUrl.EndsWith("/"), serverUrl, serverUrl & "/"))
                resolvedLogoUrl = New Uri(serverUri, logoUrl)
            End If

            Dim imageBytes As Byte() = Await logoHttpClient.GetByteArrayAsync(resolvedLogoUrl)
            Using ms As New MemoryStream(imageBytes)
                Using originalImage As Image = Image.FromStream(ms)
                    Dim resizedImage As New Bitmap(65, 65)
                    Using g As Graphics = Graphics.FromImage(resizedImage)
                        g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                        g.DrawImage(originalImage, 0, 0, 65, 65)
                    End Using

                    Return resizedImage
                End Using
            End Using
        Catch ex As Exception
            Return GetDummyPackageLogo()
        End Try
    End Function

    Private Function GetDummyPackageLogo() As Image
        Return New Bitmap(My.Resources.dummy, 65, 65)
    End Function
End Module
