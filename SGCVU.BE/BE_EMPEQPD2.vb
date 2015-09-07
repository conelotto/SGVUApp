Public Class BE_EMPEQPD2
#Region "Atributos"

    Private _str_IDNO1 As String = String.Empty
    Private _str_PRHDT8 As String = String.Empty
    Private _str_INVI As String = String.Empty
    Private _str_RDMSR1 As String = String.Empty
    Private _str_CUNO As String = String.Empty
    Private _str_LCUNO As String = String.Empty
    Private _str_PDRFDS As String = String.Empty
    Private _str_DSPMDL As String = String.Empty
    Private _str_LOC1 As String = String.Empty
    Private _str_CPIDNO As String = String.Empty
    Private _str_EQMFS2 As String = String.Empty
    Private _str_PRCLST As String = String.Empty

#End Region

#Region "Propiedades"


    Public Property str_PRCLST() As String
        'TODO probar
        '20141219 Nivardo
        'Se adiciona esta propiedad para poder traer tambien los datos de la serie de la parte.
        Get
            Return _str_PRCLST
        End Get
        Set(ByVal value As String)
            _str_PRCLST = value
        End Set
    End Property

    Public Property str_EQMFS2() As String
        'TODO probar
        '20141219 Nivardo
        'Se adiciona esta propiedad para poder traer tambien los datos de la serie de la parte.
        Get
            Return _str_EQMFS2
        End Get
        Set(ByVal value As String)
            _str_EQMFS2 = value
        End Set
    End Property

    Public Property str_IDNO1() As String
        Get
            Return _str_IDNO1
        End Get
        Set(ByVal value As String)
            _str_IDNO1 = value
        End Set
    End Property

    Public Property str_PRHDT8() As String
        Get
            Return _str_PRHDT8
        End Get
        Set(ByVal value As String)
            _str_PRHDT8 = value
        End Set
    End Property

    Public Property str_INVI() As String
        Get
            Return _str_INVI
        End Get
        Set(ByVal value As String)
            _str_INVI = value
        End Set
    End Property

    Public Property str_RDMSR1() As String
        Get
            Return _str_RDMSR1
        End Get
        Set(ByVal value As String)
            _str_RDMSR1 = value
        End Set
    End Property

    Public Property str_CUNO() As String
        Get
            Return _str_CUNO
        End Get
        Set(ByVal value As String)
            _str_CUNO = value
        End Set
    End Property

    Public Property str_LCUNO() As String
        Get
            Return _str_LCUNO
        End Get
        Set(ByVal value As String)
            _str_LCUNO = value
        End Set
    End Property

    Public Property str_PDRFDS() As String
        Get
            Return _str_PDRFDS
        End Get
        Set(ByVal value As String)
            _str_PDRFDS = value
        End Set
    End Property

    Public Property str_DSPMDL() As String
        Get
            Return _str_DSPMDL
        End Get
        Set(ByVal value As String)
            _str_DSPMDL = value
        End Set
    End Property

    Public Property str_LOC1() As String
        Get
            Return _str_LOC1
        End Get
        Set(ByVal value As String)
            _str_LOC1 = value
        End Set
    End Property

    Public Property str_CPIDNO() As String
        Get
            Return _str_CPIDNO
        End Get
        Set(ByVal value As String)
            _str_CPIDNO = value
        End Set
    End Property

#End Region


End Class
