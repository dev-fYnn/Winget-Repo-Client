Imports Winget_Repo_Client_Neu.Server


Public Class Form1

    Private Async Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If SERVER_URL.ToUpper.StartsWith("HTTPS://") And SERVER_URL.ToUpper.EndsWith("/API") Then
            load_packages_to_view()
        Else
            Status.Text = "Loading not possible! Change the settings und try again!"
        End If
    End Sub

    Private Sub Settings_Click(sender As Object, e As EventArgs) Handles Settings.Click
        Me.Hide()
        Form_Settings.Show()
    End Sub

    Private Async Sub Refresh_Click(sender As Object, e As EventArgs) Handles Refresh.Click
        Packages.Controls.Clear()
        Status.Text = ""

        If SERVER_URL.ToUpper.StartsWith("HTTPS://") And SERVER_URL.ToUpper.EndsWith("/API") Then
            load_packages_to_view()
        Else
            Status.Text = "Loading not possible! Change the settings und try again!"
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
            btn.Text = p.PACKAGE_NAME & vbCrLf & p.PACKAGE_DESCRIPTION
            btn.Width = 120
            btn.Height = 120
            btn.Tag = p.PACKAGE_ID
            AddHandler btn.Click, AddressOf PaketButton_Click
            Packages.Controls.Add(btn)
        Next

        UseWaitCursor = False
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub PaketButton_Click(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        Dim paketId As String = btn.Tag.ToString()

        Install_Package(paketId, REPO_NAME, AUTH_TOKEN, btn)
    End Sub
End Class
