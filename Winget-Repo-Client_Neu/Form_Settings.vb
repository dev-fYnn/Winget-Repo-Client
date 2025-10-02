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

    Private Sub import_config_Click(sender As Object, e As EventArgs) Handles import_config.Click
        Dim ofd As New OpenFileDialog()
        ofd.Filter = "INI-File (*.ini)|*.ini"
        ofd.Title = "Select Winget-Repo Client config"

        If ofd.ShowDialog() = DialogResult.OK Then
            Dim iniPfad As String = ofd.FileName
            Dim s_u As String = IniLesen("Settings", "URL", "", iniPfad)
            Dim a_t As String = IniLesen("Settings", "Token", "", iniPfad)
            Dim r_n As String = IniLesen("Settings", "Repo", "", iniPfad)
            IniSave(s_u, a_t, r_n)
            Me.Close()
        End If
    End Sub
End Class