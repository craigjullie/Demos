Public Class Parameter

	Private _Name As String
	Private _Type As String
	Private _Value As Object
	Private _Length As Integer
	Private _DisplayValue As String
	Private _PickerButtonText As String

	Public Sub New()
	End Sub

	Public Sub SetFromLookup(value As String, displayValue As String)
		_Value = value
		_DisplayValue = displayValue
	End Sub

	Public Property Name As String
		Get
			Return _Name
		End Get
		Set(value As String)
			_Name = value
		End Set
	End Property

	Public Property Type As String
		Get
			Return _Type
		End Get
		Set(value As String)
			_Type = value
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

	Public Property DisplayValue As String
		Get
			Return _DisplayValue
		End Get
		Set(value As String)
			_DisplayValue = value
			_Value = value
		End Set
	End Property

	Public Property Length As Integer
		Get
			Return _Length
		End Get
		Set(value As Integer)
			_Length = value
		End Set
	End Property

	Public Property PickerButtonText As String
		Get
			Return _PickerButtonText
		End Get
		Set(value As String)
			_PickerButtonText = value
		End Set
	End Property


End Class
