<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainViewForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.windowPanel = New System.Windows.Forms.Panel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmployeeManagementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BackupRestoreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AuditTrailingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'windowPanel
        '
        Me.windowPanel.Location = New System.Drawing.Point(12, 36)
        Me.windowPanel.Name = "windowPanel"
        Me.windowPanel.Size = New System.Drawing.Size(1116, 571)
        Me.windowPanel.TabIndex = 0
        '
        'MenuStrip1
        '
        Me.MenuStrip1.GripMargin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.SettingsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1201, 33)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(54, 29)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EmployeeManagementToolStripMenuItem, Me.ToolStripSeparator1, Me.BackupRestoreToolStripMenuItem, Me.ToolStripSeparator2, Me.AuditTrailingToolStripMenuItem})
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(92, 29)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'EmployeeManagementToolStripMenuItem
        '
        Me.EmployeeManagementToolStripMenuItem.Name = "EmployeeManagementToolStripMenuItem"
        Me.EmployeeManagementToolStripMenuItem.Size = New System.Drawing.Size(302, 34)
        Me.EmployeeManagementToolStripMenuItem.Text = "Employee Management"
        '
        'BackupRestoreToolStripMenuItem
        '
        Me.BackupRestoreToolStripMenuItem.Name = "BackupRestoreToolStripMenuItem"
        Me.BackupRestoreToolStripMenuItem.Size = New System.Drawing.Size(302, 34)
        Me.BackupRestoreToolStripMenuItem.Text = "Backup & Restore"
        '
        'AuditTrailingToolStripMenuItem
        '
        Me.AuditTrailingToolStripMenuItem.Name = "AuditTrailingToolStripMenuItem"
        Me.AuditTrailingToolStripMenuItem.Size = New System.Drawing.Size(302, 34)
        Me.AuditTrailingToolStripMenuItem.Text = "Audit Trailing"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(299, 6)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(299, 6)
        '
        'btnLogout
        '
        Me.btnLogout.Location = New System.Drawing.Point(1117, 5)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(71, 47)
        Me.btnLogout.TabIndex = 2
        Me.btnLogout.Text = "Logout"
        Me.btnLogout.UseVisualStyleBackColor = True
        '
        'MainViewForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1201, 619)
        Me.Controls.Add(Me.btnLogout)
        Me.Controls.Add(Me.windowPanel)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "MainViewForm"
        Me.Text = "MainViewForm"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents windowPanel As Panel
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EmployeeManagementToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents BackupRestoreToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents AuditTrailingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnLogout As Button
End Class
