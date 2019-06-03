<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectDateParamForm
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
    Me.ParamCalendar = New System.Windows.Forms.MonthCalendar()
    Me.OkButton = New System.Windows.Forms.Button()
    Me.SuspendLayout()
    '
    'CancelButton
    '
    Me.CancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.CancelButton.Location = New System.Drawing.Point(158, 180)
    Me.CancelButton.Name = "CancelButton"
    Me.CancelButton.Size = New System.Drawing.Size(75, 23)
    Me.CancelButton.TabIndex = 2
    Me.CancelButton.Text = "Cancel"
    Me.CancelButton.UseVisualStyleBackColor = True
    '
    'ParamCalendar
    '
    Me.ParamCalendar.Location = New System.Drawing.Point(6, 9)
    Me.ParamCalendar.Name = "ParamCalendar"
    Me.ParamCalendar.ShowToday = False
    Me.ParamCalendar.TabIndex = 3
    '
    'OkButton
    '
    Me.OkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.OkButton.Location = New System.Drawing.Point(77, 180)
    Me.OkButton.Name = "OkButton"
    Me.OkButton.Size = New System.Drawing.Size(75, 23)
    Me.OkButton.TabIndex = 4
    Me.OkButton.Text = "Ok"
    Me.OkButton.UseVisualStyleBackColor = True
    '
    'SelectDateParamForm
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.CancelButton = Me.CancelButton
    Me.ClientSize = New System.Drawing.Size(247, 215)
    Me.Controls.Add(Me.OkButton)
    Me.Controls.Add(Me.ParamCalendar)
    Me.Controls.Add(Me.CancelButton)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "SelectDateParamForm"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Select parameter value"
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents CancelButton As System.Windows.Forms.Button
  Friend WithEvents ParamCalendar As System.Windows.Forms.MonthCalendar
  Friend WithEvents OkButton As Button
End Class
