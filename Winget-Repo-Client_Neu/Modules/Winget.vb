Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Windows

Public Class Winget

    Public Shared Async Function RunWingetCommandAsync(mode As String, package_id As String, Optional package_version As String = "") As Task(Of (ExitCode As Integer, Output As String))
        Dim outputBuilder As New StringBuilder()

        Dim command As String = ""
        Select Case mode
            Case "Install"
                command = $"install {package_id}"

                If package_version.Length > 0 Then
                    command += $" --version {package_version}"
                End If
            Case "Update"
                command = $"upgrade {package_id}"
            Case "Uninstall"
                command = $"uninstall {package_id}"
        End Select
        command += $" -s {REPO_NAME}"

        If AUTH_TOKEN.Length > 0 Then
            command += $" --header " & """{'Token': '" & AUTH_TOKEN & "'}"""
        End If

        Try
            Dim psi As New ProcessStartInfo()
            psi.FileName = "cmd.exe"
            psi.Arguments = "/c winget " & command
            psi.UseShellExecute = False
            psi.RedirectStandardOutput = True
            psi.RedirectStandardError = True
            psi.CreateNoWindow = True
            psi.StandardOutputEncoding = Encoding.UTF8
            psi.StandardErrorEncoding = Encoding.UTF8

            Using proc As New Process()
                proc.StartInfo = psi

                AddHandler proc.OutputDataReceived, Sub(sender, e)
                                                        If Not String.IsNullOrWhiteSpace(e.Data) AndAlso Not IsSpinnerLine(e.Data) Then
                                                            outputBuilder.AppendLine(e.Data)
                                                        End If
                                                    End Sub

                AddHandler proc.ErrorDataReceived, Sub(sender, e)
                                                       If Not String.IsNullOrWhiteSpace(e.Data) AndAlso Not IsSpinnerLine(e.Data) Then
                                                           outputBuilder.AppendLine(e.Data)
                                                       End If
                                                   End Sub

                proc.Start()
                proc.BeginOutputReadLine()
                proc.BeginErrorReadLine()

                Await Task.Run(Sub() proc.WaitForExit())
                Return (proc.ExitCode, outputBuilder.ToString().Trim())
            End Using
        Catch ex As Exception
            Return (-1, "Error executing Winget-Repo Client: " & ex.Message)
        End Try
    End Function

    Private Shared Function IsSpinnerLine(line As String) As Boolean
        line = line.Trim()
        Return line.Length = 1 AndAlso "-\/|".Contains(line)
    End Function
End Class
