<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectParamValueForm
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
		Me.ParamValueDataGridView = New System.Windows.Forms.DataGridView()
		Me.SelectButton = New System.Windows.Forms.Button()
		Me.CancelButton = New System.Windows.Forms.Button()
		CType(Me.ParamValueDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'ParamValueDataGridView
		'
		Me.ParamValueDataGridView.AllowUserToAddRows = False
		Me.ParamValueDataGridView.AllowUserToDeleteRows = False
		Me.ParamValueDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
							Or System.Windows.Forms.AnchorStyles.Left) _
							Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.ParamValueDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
		Me.ParamValueDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.ParamValueDataGridView.Location = New System.Drawing.Point(13, 13)
		Me.ParamValueDataGridView.MultiSelect = False
		Me.ParamValueDataGridView.Name = "ParamValueDataGridView"
		Me.ParamValueDataGridView.ReadOnly = True
		Me.ParamValueDataGridView.RowHeadersVisible = False
		Me.ParamValueDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.ParamValueDataGridView.Size = New System.Drawing.Size(407, 366)
		Me.ParamValueDataGridView.TabIndex = 0
		'
		'SelectButton
		'
		Me.SelectButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.SelectButton.Location = New System.Drawing.Point(138, 395)
		Me.SelectButton.Name = "SelectButton"
		Me.SelectButton.Size = New System.Drawing.Size(75, 23)
		Me.SelectButton.TabIndex = 1
		Me.SelectButton.Text = "Select"
		Me.SelectButton.UseVisualStyleBackColor = True
		'
		'CancelButton
		'
		Me.CancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.CancelButton.Location = New System.Drawing.Point(233, 395)
		Me.CancelButton.Name = "CancelButton"
		Me.CancelButton.Size = New System.Drawing.Size(75, 23)
		Me.CancelButton.TabIndex = 2
		Me.CancelButton.Text = "Cancel"
		Me.CancelButton.UseVisualStyleBackColor = True
		'
		'SelectParamValueForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(432, 428)
		Me.Controls.Add(Me.CancelButton)
		Me.Controls.Add(Me.SelectButton)
		Me.Controls.Add(Me.ParamValueDataGridView)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "SelectParamValueForm"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Select parameter value"
		CType(Me.ParamValueDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents ParamValueDataGridView As System.Windows.Forms.DataGridView
	Friend WithEvents SelectButton As System.Windows.Forms.Button
	Friend WithEvents CancelButton As System.Windows.Forms.Button
End Class
