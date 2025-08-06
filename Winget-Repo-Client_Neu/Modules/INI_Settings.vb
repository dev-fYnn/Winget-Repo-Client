Imports System.Runtime.InteropServices
Imports System.Text
Imports System.IO

Module INI_Settings
    <DllImport("kernel32", CharSet:=CharSet.Auto)>
    Private Function GetPrivateProfileString(
            ByVal lpAppName As String,
            ByVal lpKeyName As String,
            ByVal lpDefault As String,
            ByVal lpReturnedString As StringBuilder,
            ByVal nSize As Integer,
            ByVal lpFileName As String) As Integer
    End Function

    Function IniLesen(sektion As String, schluessel As String, standardwert As String, dateipfad As String) As String
        Dim buffer As New StringBuilder(255)
        GetPrivateProfileString(sektion, schluessel, standardwert, buffer, buffer.Capacity, dateipfad)
        Return buffer.ToString()
    End Function


    Sub IniSave(server As String, token As String, repo As String)
        If server.EndsWith("/") Then
            server = server.ToLower.TrimEnd("/")
        End If

        SERVER_URL = server
        AUTH_TOKEN = token
        REPO_NAME = repo

        Dim iniInhalt As String =
            "[Settings]" & Environment.NewLine &
            $"URL={server}" & Environment.NewLine &
            $"Token={token}" & Environment.NewLine &
            $"Repo={repo}"

        File.WriteAllText(INI_PATH, iniInhalt)
    End Sub
End Module
