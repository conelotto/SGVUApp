Public Class BE_Apoyo

#Region "Atributos"

    Private _int_ApoyoId As Integer = 0
    Private _str_CompaniaId As String = String.Empty
    Private _str_OrdenAsignada As String = String.Empty
    Private _str_PedidoId As String = String.Empty
    Private _int_PosicionId As Integer = 0
    Private _str_ApoyoTipoId As String = String.Empty
    Private _str_ApoyoTipoDesc As String = String.Empty
    Private _str_ApoyoFinanze As String = String.Empty
    Private _str_ApoyoWorktools As String = String.Empty
    Private _str_ApoyoEPP As String = String.Empty
    Private _str_ApoyoCSA As String = String.Empty
    Private _str_ApoyoParts As String = String.Empty
    Private _str_ApoyoPrice As String = String.Empty
    Private _str_ApoyoRental As String = String.Empty
    Private _str_ApoyoOtro As String = String.Empty
    Private _dec_ApoyoImporteCRM As Decimal = 0
    Private _str_ApoyoImporteMoneda As String = String.Empty
    Private _dec_ApoyoImporteAjustado As Decimal = 0
    Private _dec_ApoyoImporteCAT As Decimal = 0
    Private _str_ApoyoProgramaNum As String = String.Empty
    Private _str_EstadoCarga As String = String.Empty
    Private _str_CLPR As String = String.Empty
    Private _str_SUNTIP As String = String.Empty
    Private _int_SUNPRE As Integer = 0
    Private _int_SUNNUM As Integer = 0
    Private _str_FechaSRC As String = String.Empty
    Private _bl_EstructuraCostos As Boolean = False
    Private _det_FechaClaim As DateTime = Date.Now()
    Private _str_NumeroClaim As String = String.Empty
    Private _bl_Washout As Boolean = False
    Private _det_WashoutFecha As DateTime = Date.Now()
    Private _str_WashoutEstado As String = String.Empty
    Private _str_EstadoRegistro As String = String.Empty
    Private _str_UsuarioCreacion As String = String.Empty
    Private _det_FechaCreacion As DateTime = Date.Now()
    Private _str_UsuarioModificacion As String = String.Empty
    Private _det_FechaModificacion As DateTime = Date.Now()

#End Region

#Region "Propiedades"

    Public Property str_ApoyoCSA() As String
        Get
            Return _str_ApoyoCSA
        End Get
        Set(ByVal value As String)
            _str_ApoyoCSA = value
        End Set
    End Property

    Public Property str_ApoyoEPP() As String
        Get
            Return _str_ApoyoEPP
        End Get
        Set(ByVal value As String)
            _str_ApoyoEPP = value
        End Set
    End Property

    Public Property str_ApoyoFinanze() As String
        Get
            Return _str_ApoyoFinanze
        End Get
        Set(ByVal value As String)
            _str_ApoyoFinanze = value
        End Set
    End Property

    Public Property int_ApoyoId() As Integer
        Get
            Return _int_ApoyoId
        End Get
        Set(ByVal value As Integer)
            _int_ApoyoId = value
        End Set
    End Property

    Public Property dec_ApoyoImporteAjustado() As Decimal
        Get
            Return _dec_ApoyoImporteAjustado
        End Get
        Set(ByVal value As Decimal)
            _dec_ApoyoImporteAjustado = value
        End Set
    End Property

    Public Property dec_ApoyoImporteCAT() As Decimal
        Get
            Return _dec_ApoyoImporteCAT
        End Get
        Set(ByVal value As Decimal)
            _dec_ApoyoImporteCAT = value
        End Set
    End Property

    Public Property dec_ApoyoImporteCRM() As Decimal
        Get
            Return _dec_ApoyoImporteCRM
        End Get
        Set(ByVal value As Decimal)
            _dec_ApoyoImporteCRM = value
        End Set
    End Property

    Public Property str_ApoyoImporteMoneda() As String
        Get
            Return _str_ApoyoImporteMoneda
        End Get
        Set(ByVal value As String)
            _str_ApoyoImporteMoneda = value
        End Set
    End Property

    Public Property str_ApoyoOtro() As String
        Get
            Return _str_ApoyoOtro
        End Get
        Set(ByVal value As String)
            _str_ApoyoOtro = value
        End Set
    End Property

    Public Property str_ApoyoParts() As String
        Get
            Return _str_ApoyoParts
        End Get
        Set(ByVal value As String)
            _str_ApoyoParts = value
        End Set
    End Property

    Public Property str_ApoyoPrice() As String
        Get
            Return _str_ApoyoPrice
        End Get
        Set(ByVal value As String)
            _str_ApoyoPrice = value
        End Set
    End Property

    Public Property str_ApoyoProgramaNum() As String
        Get
            Return _str_ApoyoProgramaNum
        End Get
        Set(ByVal value As String)
            _str_ApoyoProgramaNum = value
        End Set
    End Property

    Public Property str_ApoyoRental() As String
        Get
            Return _str_ApoyoRental
        End Get
        Set(ByVal value As String)
            _str_ApoyoRental = value
        End Set
    End Property

    Public Property str_ApoyoTipoDesc() As String
        Get
            Return _str_ApoyoTipoDesc
        End Get
        Set(ByVal value As String)
            _str_ApoyoTipoDesc = value
        End Set
    End Property

    Public Property str_ApoyoTipoId() As String
        Get
            Return _str_ApoyoTipoId
        End Get
        Set(ByVal value As String)
            _str_ApoyoTipoId = value
        End Set
    End Property

    Public Property str_ApoyoWorktools() As String
        Get
            Return _str_ApoyoWorktools
        End Get
        Set(ByVal value As String)
            _str_ApoyoWorktools = value
        End Set
    End Property

    Public Property str_CLPR() As String
        Get
            Return _str_CLPR
        End Get
        Set(ByVal value As String)
            _str_CLPR = value
        End Set
    End Property

    Public Property str_CompaniaId() As String
        Get
            Return _str_CompaniaId
        End Get
        Set(ByVal value As String)
            _str_CompaniaId = value
        End Set
    End Property

    Public Property str_EstadoCarga() As String
        Get
            Return _str_EstadoCarga
        End Get
        Set(ByVal value As String)
            _str_EstadoCarga = value
        End Set
    End Property

    Public Property str_EstadoRegistro() As String
        Get
            Return _str_EstadoRegistro
        End Get
        Set(ByVal value As String)
            _str_EstadoRegistro = value
        End Set
    End Property

    Public Property bl_EstructuraCostos() As Boolean
        Get
            Return _bl_EstructuraCostos
        End Get
        Set(ByVal value As Boolean)
            _bl_EstructuraCostos = value
        End Set
    End Property

    Public Property det_FechaClaim() As DateTime
        Get
            Return _det_FechaClaim
        End Get
        Set(ByVal value As DateTime)
            _det_FechaClaim = value
        End Set
    End Property

    Public Property det_FechaCreacion() As DateTime
        Get
            Return _det_FechaCreacion
        End Get
        Set(ByVal value As DateTime)
            _det_FechaCreacion = value
        End Set
    End Property

    Public Property det_FechaModificacion() As DateTime
        Get
            Return _det_FechaModificacion
        End Get
        Set(ByVal value As DateTime)
            _det_FechaModificacion = value
        End Set
    End Property

    Public Property str_FechaSRC() As String
        Get
            Return _str_FechaSRC
        End Get
        Set(ByVal value As String)
            _str_FechaSRC = value
        End Set
    End Property

    Public Property str_NumeroClaim() As String
        Get
            Return _str_NumeroClaim
        End Get
        Set(ByVal value As String)
            _str_NumeroClaim = value
        End Set
    End Property

    Public Property str_OrdenAsignada() As String
        Get
            Return _str_OrdenAsignada
        End Get
        Set(ByVal value As String)
            _str_OrdenAsignada = value
        End Set
    End Property

    Public Property str_PedidoId() As String
        Get
            Return _str_PedidoId
        End Get
        Set(ByVal value As String)
            _str_PedidoId = value
        End Set
    End Property

    Public Property int_PosicionId() As Integer
        Get
            Return _int_PosicionId
        End Get
        Set(ByVal value As Integer)
            _int_PosicionId = value
        End Set
    End Property

    Public Property int_SUNNUM() As Integer
        Get
            Return _int_SUNNUM
        End Get
        Set(ByVal value As Integer)
            _int_SUNNUM = value
        End Set
    End Property

    Public Property int_SUNPRE() As Integer
        Get
            Return _int_SUNPRE
        End Get
        Set(ByVal value As Integer)
            _int_SUNPRE = value
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

    Public Property str_UsuarioCreacion() As String
        Get
            Return _str_UsuarioCreacion
        End Get
        Set(ByVal value As String)
            _str_UsuarioCreacion = value
        End Set
    End Property

    Public Property str_UsuarioModificacion() As String
        Get
            Return _str_UsuarioModificacion
        End Get
        Set(ByVal value As String)
            _str_UsuarioModificacion = value
        End Set
    End Property

    Public Property bl_Washout() As Boolean
        Get
            Return _bl_Washout
        End Get
        Set(ByVal value As Boolean)
            _bl_Washout = value
        End Set
    End Property

    Public Property str_WashoutEstado() As String
        Get
            Return _str_WashoutEstado
        End Get
        Set(ByVal value As String)
            _str_WashoutEstado = value
        End Set
    End Property

    Public Property det_WashoutFecha() As DateTime
        Get
            Return _det_WashoutFecha
        End Get
        Set(ByVal value As DateTime)
            _det_WashoutFecha = value
        End Set
    End Property

#End Region


End Class
