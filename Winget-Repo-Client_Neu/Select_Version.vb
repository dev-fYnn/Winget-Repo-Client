Public Class Select_Version
    Public Property SelectedVersion As String
    Public Property install_update As String = "Update"


    Public Sub New(package_versions As List(Of String))
        InitializeComponent()
        cmbVersions.DataSource = package_versions
    End Sub

    Private Sub Install_btn_Click(sender As Object, e As EventArgs) Handles Install_btn.Click
        If cmbVersions.SelectedItem IsNot Nothing Then
            install_update = "Install"
            SelectedVersion = cmbVersions.SelectedItem.ToString()
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            MessageBox.Show("Choose a Version!")
        End If
    End Sub

    Private Sub Update_btn_Click(sender As Object, e As EventArgs) Handles Update_btn.Click
        If cmbVersions.SelectedItem IsNot Nothing Then
            install_update = "Update"
            SelectedVersion = cmbVersions.SelectedItem.ToString()
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            MessageBox.Show("Choose a Version!")
        End If
    End Sub
End Class