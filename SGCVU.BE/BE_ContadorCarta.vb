Public Class BE_ContadorCarta
#Region "Atributos"

    Private _int_NumeroCarta As Integer = 0
    Private _int_IdIncidente As Integer = 0
    Private _str_FlagEliminado As String = String.Empty

#End Region

#Region "Propiedades"

    Public Property int_NumeroCarta() As Integer
        Get
            Return _int_NumeroCarta
        End Get
        Set(ByVal value As Integer)
            _int_NumeroCarta = value
        End Set
    End Property

    Public Property int_IdIncidente() As Integer
        Get
            Return _int_IdIncidente
        End Get
        Set(ByVal value As Integer)
            _int_IdIncidente = value
        End Set
    End Property

    Public Property str_FlagEliminado() As String
        Get
            Return _str_FlagEliminado
        End Get
        Set(ByVal value As String)
            _str_FlagEliminado = value
        End Set
    End Property

#End Region
End Class
