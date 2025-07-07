Public Class Select_Version
    Public Property SelectedVersion As String

    Public Sub New(package_versions As List(Of String))
        InitializeComponent()
        cmbVersions.DataSource = package_versions
    End Sub

    Private Sub Install_btn_Click(sender As Object, e As EventArgs) Handles Install_btn.Click
        If cmbVersions.SelectedItem IsNot Nothing Then
            SelectedVersion = cmbVersions.SelectedItem.ToString()
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            MessageBox.Show("Choose a Version!")
        End If
    End Sub
End Class