Public Class ExtendedProperty

	Private _Name As String
	Private _Value As Object

	Public Sub New()
	End Sub

	Public Property Name As String
		Get
			Return _Name
		End Get
		Set(value As String)
			_Name = value
		End Set
	End Property

	Public Property Value As String
		Get
			Return _Value
		End Get
		Set(value As String)
			_Value = value
		End Set
	End Property


End Class
