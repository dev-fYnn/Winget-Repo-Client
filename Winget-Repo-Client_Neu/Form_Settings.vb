
Public Class Form_Settings
    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Settings_Token.Text = AUTH_TOKEN
        Settings_Repo_Name.Text = REPO_NAME
        Settings_Server.Text = SERVER_URL
    End Sub

    Private Sub Settings_Save_Click(sender As Object, e As EventArgs) Handles Settings_Save.Click
        IniSave(Settings_Server.Text, Settings_Token.Text, Settings_Repo_Name.Text)
        Me.Close()
    End Sub

    Private Sub set_repository_Click(sender As Object, e As EventArgs) Handles set_repository.Click
        Cursor.Current = Cursors.WaitCursor
        UseWaitCursor = True

        Dim name As String = REPO_NAME
        Dim type As String = "Microsoft.Rest"

        Dim apiUrl As String = $"{SERVER_URL}/api/"
        If CLOUD Then
            apiUrl = $"{SERVER_URL}/api/{REPO_NAME}/"
        End If

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

    Private Sub import_config_Click(sender As Object, e As EventArgs) Handles import_config.Click
        Dim ofd As New OpenFileDialog()
        ofd.Filter = "INI-File (*.ini)|*.ini"
        ofd.Title = "Select Winget-Repo Client config"

        If ofd.ShowDialog() = DialogResult.OK Then
            Dim iniPfad As String = ofd.FileName
            Dim s_u As String = IniLesen("Settings", "URL", "", iniPfad)
            Dim a_t As String = IniLesen("Settings", "Token", "", iniPfad)
            Dim r_n As String = IniLesen("Settings", "Repo", "Winget-Repo", iniPfad)
            IniSave(s_u, a_t, r_n)
            Me.Close()
        End If
    End Sub
End Class