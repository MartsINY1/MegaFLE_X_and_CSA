Option Explicit On
Friend Class ClsNESAddr
	'NES Memory/ROM Address handler class
	'With support for complex bankswitching.

	Public lo As Integer
	Public hi As Integer
	Private ReadOnly seg_p(7) As Integer

	Public Sub InitSegs89(ByRef bankaddr As Integer)
		seg_p(0) = bankaddr
		seg_p(1) = bankaddr + &H1000S
	End Sub

	Public Sub InitSegsAB(ByRef bankaddr As Integer)
		seg_p(2) = bankaddr
		seg_p(3) = bankaddr + &H1000S
	End Sub

	Public Sub InitSegs89AB(ByRef bankaddr As Integer)
		seg_p(0) = bankaddr
		seg_p(1) = bankaddr + &H1000S
		seg_p(2) = bankaddr + &H2000S
		seg_p(3) = bankaddr + &H3000S
	End Sub

	Public Sub InitSegsCDEF(ByRef bankaddr As Integer)
		seg_p(4) = bankaddr
		seg_p(5) = bankaddr + &H1000S
		seg_p(6) = bankaddr + &H2000S
		seg_p(7) = bankaddr + &H3000S
	End Sub


	Public Property Seg(ByVal Index As Integer) As Integer
		Get
			Seg = seg_p(Index)
		End Get
		Set(ByVal Value As Integer)
			seg_p(Index) = Value
		End Set
	End Property


	Public Property Mem() As Integer
		Get
			Mem = lo Or (hi * &H100S)
		End Get
		Set(ByVal Value As Integer)
			lo = (Value And &HFFS)
			hi = (Value And &HFF00) / &H100S
		End Set
	End Property

	Public Function Rom() As Integer
		Dim a As Integer
		a = Me.Mem
		If a >= &H8000 Then
			Rom = CShort(a And &HFFFS) + Seg(CShort(a And &H7000S) / &H1000S)
		Else
			Rom = 0
		End If
	End Function
End Class