Imports System.IO

Public Class Form_Settings
    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Settings_Token.Text = AUTH_TOKEN
        Settings_Repo_Name.Text = REPO_NAME
        Settings_Server.Text = SERVER_URL
    End Sub

    Private Sub Form_Settings_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Form1.Show()
    End Sub

    Private Sub Settings_Save_Click(sender As Object, e As EventArgs) Handles Settings_Save.Click
        If Settings_Server.Text.EndsWith("/") Then
            Settings_Server.Text = Settings_Server.Text.ToLower.Replace("/api/", "/api")
        End If

        SERVER_URL = Settings_Server.Text
        AUTH_TOKEN = Settings_Token.Text
        REPO_NAME = Settings_Repo_Name.Text

        Dim iniInhalt As String =
            "[Settings]" & Environment.NewLine &
            $"URL={Settings_Server.Text}" & Environment.NewLine &
            $"Token={Settings_Token.Text}" & Environment.NewLine &
            $"Repo={Settings_Repo_Name.Text}"

        File.WriteAllText(INI_PATH, iniInhalt)
        Me.Close()
    End Sub

    Private Sub set_repository_Click(sender As Object, e As EventArgs) Handles set_repository.Click
        Cursor.Current = Cursors.WaitCursor
        UseWaitCursor = True

        Dim name As String = "Winget-Repo"
        Dim type As String = "Microsoft.Rest"
        Dim apiUrl As String = $"{SERVER_URL.Replace("/client/api", "")}/api/"
        Dim header As String = "{'Token': '" & AUTH_TOKEN & "'}"
        Dim arguments As String = $"source add -n {name} -t ""{type}"" -a {apiUrl} --header ""{header}"""

        Try
            Dim psi As New ProcessStartInfo()
            psi.FileName = "winget"
            psi.Arguments = arguments
            psi.RedirectStandardOutput = True
            psi.RedirectStandardError = True
            psi.UseShellExecute = False
            psi.CreateNoWindow = True

            Dim proc As New Process()
            proc.StartInfo = psi
            proc.Start()

            Dim output As String = proc.StandardOutput.ReadToEnd()
            Dim errorOutput As String = proc.StandardError.ReadToEnd()
            proc.WaitForExit()

            MsgBox("Winget output: " & output)

            If Not String.IsNullOrWhiteSpace(errorOutput) Then
                MsgBox("Winget error: " & errorOutput)
            End If
        Catch ex As Exception
            MsgBox("Error while adding the winget repository: " & ex.Message)
        End Try

        Cursor.Current = Cursors.Default
        UseWaitCursor = False
    End Sub
End Class