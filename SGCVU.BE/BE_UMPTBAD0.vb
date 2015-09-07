Public Class BE_UMPTBAD0

#Region "Atributos"
    Private _str_CORP As String
    Private _str_CIA As String
    Private _str_CODADI As String
    Private _str_PMODEL As String
    Private _str_PREFIJ As String
    Private _dec_MONTO As Decimal
    Private _int_TipoBusqueda As Integer = 1
#End Region

#Region "Propiedades"

    Public Property str_CORP() As String
        Get
            Return _str_CORP
        End Get
        Set(ByVal value As String)
            _str_CORP = value
        End Set
    End Property

    Public Property str_CIA() As String
        Get
            Return _str_CIA
        End Get
        Set(ByVal value As String)
            _str_CIA = value
        End Set
    End Property

    Public Property str_CODADI() As String
        Get
            Return _str_CODADI
        End Get
        Set(ByVal value As String)
            _str_CODADI = value
        End Set
    End Property

    Public Property str_PMODEL() As String
        Get
            Return _str_PMODEL
        End Get
        Set(ByVal value As String)
            _str_PMODEL = value
        End Set
    End Property

    Public Property str_PREFIJ() As String
        Get
            Return _str_PREFIJ
        End Get
        Set(ByVal value As String)
            _str_PREFIJ = value
        End Set
    End Property

    Public Property dec_MONTO() As Decimal
        Get
            Return _dec_MONTO
        End Get
        Set(ByVal value As Decimal)
            _dec_MONTO = value
        End Set
    End Property

    Public Property int_TipoBusqueda() As Integer
        Get
            Return _int_TipoBusqueda
        End Get
        Set(ByVal value As Integer)
            _int_TipoBusqueda = value
        End Set
    End Property


#End Region


End Class
