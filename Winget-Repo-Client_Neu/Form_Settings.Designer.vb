<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Settings
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Settings))
        Me.Settings_Server = New System.Windows.Forms.TextBox()
        Me.Settings_Token = New System.Windows.Forms.TextBox()
        Me.Settings_Repo_Name = New System.Windows.Forms.TextBox()
        Me.Settings_Save = New System.Windows.Forms.Button()
        Me.Settings_Repo_Name_Label = New System.Windows.Forms.Label()
        Me.Settings_Server_Token = New System.Windows.Forms.Label()
        Me.Settings_Server_Label = New System.Windows.Forms.Label()
        Me.import_config = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SuspendLayout()
        '
        'Settings_Server
        '
        Me.Settings_Server.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Settings_Server.Location = New System.Drawing.Point(16, 31)
        Me.Settings_Server.Margin = New System.Windows.Forms.Padding(4)
        Me.Settings_Server.Name = "Settings_Server"
        Me.Settings_Server.Size = New System.Drawing.Size(441, 22)
        Me.Settings_Server.TabIndex = 0
        '
        'Settings_Token
        '
        Me.Settings_Token.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Settings_Token.Location = New System.Drawing.Point(16, 81)
        Me.Settings_Token.Margin = New System.Windows.Forms.Padding(4)
        Me.Settings_Token.Name = "Settings_Token"
        Me.Settings_Token.Size = New System.Drawing.Size(441, 22)
        Me.Settings_Token.TabIndex = 1
        '
        'Settings_Repo_Name
        '
        Me.Settings_Repo_Name.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Settings_Repo_Name.Location = New System.Drawing.Point(16, 130)
        Me.Settings_Repo_Name.Margin = New System.Windows.Forms.Padding(4)
        Me.Settings_Repo_Name.Name = "Settings_Repo_Name"
        Me.Settings_Repo_Name.Size = New System.Drawing.Size(441, 22)
        Me.Settings_Repo_Name.TabIndex = 2
        '
        'Settings_Save
        '
        Me.Settings_Save.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Settings_Save.Location = New System.Drawing.Point(16, 165)
        Me.Settings_Save.Margin = New System.Windows.Forms.Padding(4)
        Me.Settings_Save.Name = "Settings_Save"
        Me.Settings_Save.Size = New System.Drawing.Size(443, 28)
        Me.Settings_Save.TabIndex = 3
        Me.Settings_Save.Text = "Save"
        Me.Settings_Save.UseVisualStyleBackColor = True
        '
        'Settings_Repo_Name_Label
        '
        Me.Settings_Repo_Name_Label.AutoSize = True
        Me.Settings_Repo_Name_Label.Location = New System.Drawing.Point(16, 111)
        Me.Settings_Repo_Name_Label.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Settings_Repo_Name_Label.Name = "Settings_Repo_Name_Label"
        Me.Settings_Repo_Name_Label.Size = New System.Drawing.Size(135, 16)
        Me.Settings_Repo_Name_Label.TabIndex = 4
        Me.Settings_Repo_Name_Label.Text = "Winget Source Name"
        '
        'Settings_Server_Token
        '
        Me.Settings_Server_Token.AutoSize = True
        Me.Settings_Server_Token.Location = New System.Drawing.Point(16, 62)
        Me.Settings_Server_Token.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Settings_Server_Token.Name = "Settings_Server_Token"
        Me.Settings_Server_Token.Size = New System.Drawing.Size(76, 16)
        Me.Settings_Server_Token.TabIndex = 5
        Me.Settings_Server_Token.Text = "Auth-Token"
        '
        'Settings_Server_Label
        '
        Me.Settings_Server_Label.AutoSize = True
        Me.Settings_Server_Label.Location = New System.Drawing.Point(16, 11)
        Me.Settings_Server_Label.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Settings_Server_Label.Name = "Settings_Server_Label"
        Me.Settings_Server_Label.Size = New System.Drawing.Size(78, 16)
        Me.Settings_Server_Label.TabIndex = 6
        Me.Settings_Server_Label.Text = "Server-URL"
        '
        'import_config
        '
        Me.import_config.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.import_config.Location = New System.Drawing.Point(16, 201)
        Me.import_config.Margin = New System.Windows.Forms.Padding(4)
        Me.import_config.Name = "import_config"
        Me.import_config.Size = New System.Drawing.Size(443, 28)
        Me.import_config.TabIndex = 8
        Me.import_config.Text = "Import config.ini"
        Me.import_config.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Form_Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(475, 242)
        Me.Controls.Add(Me.import_config)
        Me.Controls.Add(Me.Settings_Server_Label)
        Me.Controls.Add(Me.Settings_Server_Token)
        Me.Controls.Add(Me.Settings_Repo_Name_Label)
        Me.Controls.Add(Me.Settings_Save)
        Me.Controls.Add(Me.Settings_Repo_Name)
        Me.Controls.Add(Me.Settings_Token)
        Me.Controls.Add(Me.Settings_Server)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Form_Settings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Settings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Settings_Server As TextBox
    Friend WithEvents Settings_Token As TextBox
    Friend WithEvents Settings_Repo_Name As TextBox
    Friend WithEvents Settings_Save As Button
    Friend WithEvents Settings_Repo_Name_Label As Label
    Friend WithEvents Settings_Server_Token As Label
    Friend WithEvents Settings_Server_Label As Label
    Friend WithEvents import_config As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
End Class
