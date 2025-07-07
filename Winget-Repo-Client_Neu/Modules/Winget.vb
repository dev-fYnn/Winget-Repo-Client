Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Windows

Module Winget
    Public Async Function Install_Package(paketName As String, repoName As String, auth_token As String, Optional version As String = "", Optional button As Button = Nothing) As Task
        Dim logPath As String = Path.Combine(Application.StartupPath, "logs.txt")
        Dim dummy As String = ""
        Dim error_text As String = ""

        If button IsNot Nothing Then
            dummy = button.Text
        End If

        Try
            If button IsNot Nothing Then
                Form1.Packages.Enabled = False
                Form1.Refresh.Enabled = False
                Form1.Settings.Enabled = False
                button.Text = "In Progress..."
            Else
                File.AppendAllText(logPath, $"[{DateTime.Now}] Starting installation of {paketName}" & Environment.NewLine)
            End If

            Dim psi As New ProcessStartInfo()
            psi.FileName = "cmd.exe"

            Dim version_text As String = $" -v {version} "

            If version.Length = 0 Then version_text = " "

            If auth_token.Length > 0 Then
                psi.Arguments = $"/c winget install {paketName}{version_text}-s {repoName} --header " & """{'Token': '" & auth_token & "'}"""
            Else
                psi.Arguments = $"/c winget install {paketName}{version_text}-s {repoName}"
            End If

            psi.UseShellExecute = False
            psi.RedirectStandardOutput = True
            psi.RedirectStandardError = True
            psi.CreateNoWindow = True

            Dim process As New Process()
            process.StartInfo = psi

            process.Start()
            process.BeginOutputReadLine()
            process.BeginErrorReadLine()
            Await Task.Run(Sub() process.WaitForExit())

            If process.ExitCode = 0 Then
                If button IsNot Nothing Then
                    error_text = "✔️ Successfull"
                Else
                    File.AppendAllText(logPath, $"[{DateTime.Now}] ✔️ Successfull installation of {paketName}" & Environment.NewLine)
                End If
            Else
                If button IsNot Nothing Then
                    error_text = "❌ Error"
                Else
                    File.AppendAllText(logPath, $"[{DateTime.Now}] ❌ Error installation of {paketName}: ExitCode {process.ExitCode}" & Environment.NewLine)
                End If
            End If

        Catch ex As Exception
            If button IsNot Nothing Then
                error_text = "❗ Error"
            Else
                File.AppendAllText(logPath, $"[{DateTime.Now}] ❗ Error installation of {ex.Message}" & Environment.NewLine)
            End If
        Finally
            If button IsNot Nothing Then
                Form1.Packages.Enabled = True
                Form1.Refresh.Enabled = True
                Form1.Settings.Enabled = True
                button.Text = dummy
                MsgBox(error_text)
            End If
        End Try
    End Function
End Module
