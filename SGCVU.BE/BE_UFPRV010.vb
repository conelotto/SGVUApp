Public Class BE_UFPRV010

#Region "Atributos"

    Private _str_REFEREN As String = String.Empty
    Private _str_INDSIT As String = String.Empty
    Private _str_CLIE As String = String.Empty
    Private _str_CLIAD As String = String.Empty
    Private _str_FECDOC As String = String.Empty
    Private _str_SUNTIP As String = String.Empty
    Private _str_SUNPRE As String = String.Empty
    Private _str_SUNNUM As String = String.Empty
    Private _str_NUMDOC As String = String.Empty
    Private _str_CTTNO1 As String = String.Empty
    Private _str_CNTRD8 As String = String.Empty
    Property str_IMPDOL As Decimal = CDec(0)

#End Region

#Region "Propiedades"

    Public Property str_REFEREN() As String
        Get
            Return _str_REFEREN
        End Get
        Set(ByVal value As String)
            _str_REFEREN = value
        End Set
    End Property

    Public Property str_INDSIT() As String
        Get
            Return _str_INDSIT
        End Get
        Set(ByVal value As String)
            _str_INDSIT = value
        End Set
    End Property

    Public Property str_CLIE() As String
        Get
            Return _str_CLIE
        End Get
        Set(ByVal value As String)
            _str_CLIE = value
        End Set
    End Property

    Public Property str_CLIAD() As String
        Get
            Return _str_CLIAD
        End Get
        Set(ByVal value As String)
            _str_CLIAD = value
        End Set
    End Property

    Public Property str_FECDOC() As String
        Get
            Return _str_FECDOC
        End Get
        Set(ByVal value As String)
            _str_FECDOC = value
        End Set
    End Property

    Public Property str_SUNTIP() As String
        Get
            Return _str_SUNTIP
        End Get
        Set(ByVal value As String)
            _str_SUNTIP = value
        End Set
    End Property

    Public Property str_SUNPRE() As String
        Get
            Return _str_SUNPRE
        End Get
        Set(ByVal value As String)
            _str_SUNPRE = value
        End Set
    End Property

    Public Property str_SUNNUM() As String
        Get
            Return _str_SUNNUM
        End Get
        Set(ByVal value As String)
            _str_SUNNUM = value
        End Set
    End Property

    Public Property str_NUMDOC() As String
        Get
            Return _str_NUMDOC
        End Get
        Set(ByVal value As String)
            _str_NUMDOC = value
        End Set
    End Property

    Public Property str_CTTNO1() As String
        Get
            Return _str_CTTNO1
        End Get
        Set(ByVal value As String)
            _str_CTTNO1 = value
        End Set
    End Property

    Public Property str_CNTRD8() As String
        Get
            Return _str_CNTRD8
        End Get
        Set(ByVal value As String)
            _str_CNTRD8 = value
        End Set
    End Property

#End Region
End Class
