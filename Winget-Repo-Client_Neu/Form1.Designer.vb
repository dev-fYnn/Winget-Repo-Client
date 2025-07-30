<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Settings = New System.Windows.Forms.Button()
        Me.Packages = New System.Windows.Forms.FlowLayoutPanel()
        Me.Status = New System.Windows.Forms.Label()
        Me.Refresh = New System.Windows.Forms.Button()
        Me.Version = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Settings
        '
        Me.Settings.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Settings.Image = CType(resources.GetObject("Settings.Image"), System.Drawing.Image)
        Me.Settings.Location = New System.Drawing.Point(639, 10)
        Me.Settings.Name = "Settings"
        Me.Settings.Size = New System.Drawing.Size(36, 36)
        Me.Settings.TabIndex = 0
        Me.Settings.UseVisualStyleBackColor = True
        '
        'Packages
        '
        Me.Packages.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Packages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Packages.Location = New System.Drawing.Point(10, 64)
        Me.Packages.Name = "Packages"
        Me.Packages.Size = New System.Drawing.Size(665, 316)
        Me.Packages.TabIndex = 1
        '
        'Status
        '
        Me.Status.AutoSize = True
        Me.Status.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Status.ForeColor = System.Drawing.Color.Red
        Me.Status.Location = New System.Drawing.Point(10, 10)
        Me.Status.Name = "Status"
        Me.Status.Size = New System.Drawing.Size(0, 21)
        Me.Status.TabIndex = 2
        '
        'Refresh
        '
        Me.Refresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Refresh.Image = CType(resources.GetObject("Refresh.Image"), System.Drawing.Image)
        Me.Refresh.Location = New System.Drawing.Point(598, 10)
        Me.Refresh.Name = "Refresh"
        Me.Refresh.Size = New System.Drawing.Size(36, 36)
        Me.Refresh.TabIndex = 3
        Me.Refresh.UseVisualStyleBackColor = True
        '
        'Version
        '
        Me.Version.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Version.AutoSize = True
        Me.Version.Location = New System.Drawing.Point(553, 22)
        Me.Version.Name = "Version"
        Me.Version.Size = New System.Drawing.Size(0, 13)
        Me.Version.TabIndex = 4
        Me.Version.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(686, 390)
        Me.Controls.Add(Me.Version)
        Me.Controls.Add(Me.Refresh)
        Me.Controls.Add(Me.Status)
        Me.Controls.Add(Me.Packages)
        Me.Controls.Add(Me.Settings)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "Winget-Repo Client"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Settings As Button
    Friend WithEvents Packages As FlowLayoutPanel
    Friend WithEvents Status As Label
    Friend WithEvents Refresh As Button
    Friend WithEvents Version As Label
End Class
