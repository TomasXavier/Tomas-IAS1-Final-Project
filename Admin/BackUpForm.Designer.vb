<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BackUpForm
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
        Me.btnBackUp = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnRestore = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnBackUp
        '
        Me.btnBackUp.Location = New System.Drawing.Point(119, 225)
        Me.btnBackUp.Name = "btnBackUp"
        Me.btnBackUp.Size = New System.Drawing.Size(105, 37)
        Me.btnBackUp.TabIndex = 0
        Me.btnBackUp.Text = "Back Up"
        Me.btnBackUp.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(85, 155)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(345, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "What would you want to do with your database?"
        '
        'btnRestore
        '
        Me.btnRestore.Location = New System.Drawing.Point(252, 225)
        Me.btnRestore.Name = "btnRestore"
        Me.btnRestore.Size = New System.Drawing.Size(105, 37)
        Me.btnRestore.TabIndex = 0
        Me.btnRestore.Text = "Restore"
        Me.btnRestore.UseVisualStyleBackColor = True
        '
        'BackUpForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnRestore)
        Me.Controls.Add(Me.btnBackUp)
        Me.Name = "BackUpForm"
        Me.Text = "BackUpForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnBackUp As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents btnRestore As Button
End Class
