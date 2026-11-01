Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Net.Http

Public Class Winget

    Public Shared Async Function RunWingetCommandAsync(mode As String, package_id As String, Optional package_version As String = "") As Task(Of (ExitCode As Integer, Output As String))
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

        Return Await RunWingetRawAsync(command)
    End Function

    Public Shared Async Function ApplyConfigurationAsync(p As Paket, version As String) As Task(Of (Applied As Boolean, ExitCode As Integer, Output As String))
        Dim config_url As String = Nothing
        If p.WINGET_CONFIGS Is Nothing OrElse Not p.WINGET_CONFIGS.TryGetValue(version, config_url) OrElse String.IsNullOrEmpty(config_url) Then
            Return (False, 0, "No Config available")
        End If

        Try
            Dim r = Await RunWingetRawAsync($"configure -f ""{config_url}"" --accept-configuration-agreements --disable-interactivity")
            Return (True, r.ExitCode, r.Output)
        Catch ex As Exception
            Return (False, -1, "Error applying configuration: " & ex.Message)
        End Try
    End Function


    Private Shared Async Function RunWingetRawAsync(arguments As String) As Task(Of (ExitCode As Integer, Output As String))
        Dim outputBuilder As New StringBuilder()

        Try
            Dim psi As New ProcessStartInfo()
            psi.FileName = "cmd.exe"
            psi.Arguments = "/c winget " & arguments
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
