<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Select_Version
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Select_Version))
        Me.cmbVersions = New System.Windows.Forms.ComboBox()
        Me.Install_btn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmbVersions
        '
        Me.cmbVersions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbVersions.FormattingEnabled = True
        Me.cmbVersions.Location = New System.Drawing.Point(12, 12)
        Me.cmbVersions.Name = "cmbVersions"
        Me.cmbVersions.Size = New System.Drawing.Size(232, 21)
        Me.cmbVersions.TabIndex = 0
        '
        'Install_btn
        '
        Me.Install_btn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Install_btn.Location = New System.Drawing.Point(12, 44)
        Me.Install_btn.Name = "Install_btn"
        Me.Install_btn.Size = New System.Drawing.Size(232, 23)
        Me.Install_btn.TabIndex = 1
        Me.Install_btn.Text = "Install"
        Me.Install_btn.UseVisualStyleBackColor = True
        '
        'Select_Version
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(256, 79)
        Me.Controls.Add(Me.Install_btn)
        Me.Controls.Add(Me.cmbVersions)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Select_Version"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Select Version"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cmbVersions As ComboBox
    Friend WithEvents Install_btn As Button
End Class
