Imports Winget_Repo_Client_Neu.Server
Imports Winget_Repo_Client.Functions


Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If SERVER_URL.ToUpper.StartsWith("HTTPS://") Then
            load_packages_to_view()
        Else
            Status.Text = "Loading not possible! Change the settings and try again!"
        End If

        Version.Text = My.Application.Info.Version.ToString
    End Sub

    Private Sub Settings_Click(sender As Object, e As EventArgs) Handles Settings.Click
        If Not IsRunningAsAdministrator() Then
            MsgBox("Open Winget-Repo Client with admin privileges to edit the settings.")
            Exit Sub
        End If

        Dim f As New Form_Settings()
        f.ShowDialog()
    End Sub

    Private Sub Refresh_Click(sender As Object, e As EventArgs) Handles Refresh.Click
        Packages.Controls.Clear()
        Status.Text = ""

        If SERVER_URL.ToUpper.StartsWith("HTTPS://") Then
            load_packages_to_view()
        Else
            Status.Text = "Loading not possible! Change the settings and try again!"
        End If
    End Sub

    Private Async Sub load_packages_to_view()
        Status.Text = ""
        Cursor.Current = Cursors.WaitCursor
        UseWaitCursor = True
        Dim pakete = Await GetPackagesFromServer(SERVER_URL, AUTH_TOKEN, True)

        Packages.Controls.Clear()

        If pakete.Count = 0 And Status.Text.Length = 0 Then
            Status.Text = "No packages found!"
        End If

        For Each p As Paket In pakete
            Dim btn As New Button()
            btn.Text = p.PACKAGE_NAME
            btn.TextAlign = ContentAlignment.BottomCenter
            btn.Font = New Font("Microsoft Sans Serif", 7.5)

            btn.Width = 100
            btn.Height = 100
            btn.Tag = p

            Dim logo As Image = GetLogoforPackage(p.PACKAGE_LOGO)
            btn.Image = logo
            btn.ImageAlign = ContentAlignment.TopCenter

            AddHandler btn.Click, AddressOf PaketButton_Click
            Packages.Controls.Add(btn)
        Next

        UseWaitCursor = False
        Cursor.Current = Cursors.Default
    End Sub

    Private Async Sub PaketButton_Click(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        Dim paketId As String = btn.Tag.PACKAGE_ID
        btn.Text = "Processing..."

        Dim versionDialog As New Select_Version(btn.Tag.VERSIONS)

        If btn.Tag.VERSIONS.Count > 0 Then
            If versionDialog.ShowDialog() = DialogResult.OK Then
                Dim selectedVersion As String = versionDialog.SelectedVersion
                Dim result = Await Winget.RunWingetCommandAsync(versionDialog.install_update, paketId, selectedVersion)

                If result.ExitCode = 0 Then
                    MsgBox($"Installation Status: {result.ExitCode},{vbNewLine}{vbNewLine}Successfull!")
                Else
                    MsgBox($"Installation Status: {result.ExitCode},{vbNewLine}{vbNewLine}{result.Output}")
                End If
            End If
        Else
            MsgBox("No Versions available!")
        End If
        btn.Text = btn.Tag.PACKAGE_NAME
    End Sub
End Class
