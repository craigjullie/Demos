Public Class SelectYesNoParamForm

  Private _OkClicked As Boolean = False
  Private _Selection As String = String.Empty

  Public Property OkClicked As Boolean
    Get
      Return _OkClicked
    End Get
    Set(value As Boolean)
      _OkClicked = value
    End Set
  End Property

  Private Sub CancelButton_Click(sender As System.Object, e As System.EventArgs) Handles CancelButton.Click
    Me.OkClicked = False
    Me.Hide()
  End Sub

  Private Sub YesButton_Click(sender As System.Object, e As System.EventArgs) Handles YesButton.Click
    _Selection = "1"
    Me.OkClicked = True
    Me.Hide()
  End Sub

  Private Sub NoButton_Click(sender As System.Object, e As System.EventArgs) Handles NoButton.Click
    _Selection = "0"
    Me.OkClicked = True
    Me.Hide()
  End Sub

  Public ReadOnly Property SelectionValueMade As String
    Get
      Return _Selection
    End Get
  End Property

  Public ReadOnly Property SelectionDisplayText As String
    Get
      If _Selection = "1" Then Return "Yes/True (1)"
      Return "No/False (0)"
    End Get
  End Property

End Class