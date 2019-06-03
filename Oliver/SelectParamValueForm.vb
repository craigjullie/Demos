Public Class SelectParamValueForm

	Private _OkClicked As Boolean = False

	Public Property OkClicked As Boolean
		Get
			Return _OkClicked
		End Get
		Set(value As Boolean)
			_OkClicked = value
		End Set
	End Property

	Private Sub SelectButton_Click(sender As System.Object, e As System.EventArgs) Handles SelectButton.Click
		Me.OkClicked = True
		Me.Hide()
	End Sub

	Private Sub CancelButton_Click(sender As System.Object, e As System.EventArgs) Handles CancelButton.Click
		Me.OkClicked = False
		Me.Hide()
	End Sub
End Class