<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectYesNoParamForm
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
    Me.CancelButton = New System.Windows.Forms.Button()
    Me.YesButton = New System.Windows.Forms.Button()
    Me.NoButton = New System.Windows.Forms.Button()
    Me.SuspendLayout()
    '
    'CancelButton
    '
    Me.CancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.CancelButton.Location = New System.Drawing.Point(79, 105)
    Me.CancelButton.Name = "CancelButton"
    Me.CancelButton.Size = New System.Drawing.Size(75, 23)
    Me.CancelButton.TabIndex = 2
    Me.CancelButton.Text = "Cancel"
    Me.CancelButton.UseVisualStyleBackColor = True
    '
    'YesButton
    '
    Me.YesButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.YesButton.Location = New System.Drawing.Point(21, 22)
    Me.YesButton.Name = "YesButton"
    Me.YesButton.Size = New System.Drawing.Size(83, 59)
    Me.YesButton.TabIndex = 3
    Me.YesButton.Text = "Yes/True"
    Me.YesButton.UseVisualStyleBackColor = False
    '
    'NoButton
    '
    Me.NoButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.NoButton.Location = New System.Drawing.Point(121, 22)
    Me.NoButton.Name = "NoButton"
    Me.NoButton.Size = New System.Drawing.Size(83, 59)
    Me.NoButton.TabIndex = 4
    Me.NoButton.Text = "No/False"
    Me.NoButton.UseVisualStyleBackColor = False
    '
    'SelectYesNoParamForm
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(245, 140)
    Me.Controls.Add(Me.NoButton)
    Me.Controls.Add(Me.YesButton)
    Me.Controls.Add(Me.CancelButton)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "SelectYesNoParamForm"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Select parameter value"
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents CancelButton As System.Windows.Forms.Button
  Friend WithEvents YesButton As System.Windows.Forms.Button
  Friend WithEvents NoButton As System.Windows.Forms.Button
End Class
