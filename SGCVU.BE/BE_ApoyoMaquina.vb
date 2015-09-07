Public Class BE_ApoyoMaquina
#Region "Atributos"

    Private _int_ApoyoId As Integer = 0
    Private _str_CompaniaId As String = ""
    Private _int_EstadoSolicitudId As Integer = 0
    Private _det_FechaRespuestaCAT As DateTime = Date.Now()
    Private _det_FechaSolicitudCAT As DateTime = Date.Now()
    Private _str_IdProgramaCAT As String = ""
    Private _dec_ImporteApoyoCAT As Decimal = 0
    Private _int_MaquinaApoyoId As Integer = 0
    Private _str_Observacion As String = String.Empty
    Private _str_OrdenAsignada As String = ""
    Private _str_PedidoId As String = ""
    Private _int_PosicionId As Integer = 0
    Private _str_UsuarioCreacion As String = ""
    Private _det_FechaCreacion As DateTime = Date.Now()
    Private _str_UsuarioModificacion As String = ""
    Private _det_FechaModificacion As DateTime = Date.Now()
    Private _str_RespuestaTipo As String = String.Empty
    Private _bl_SolicitudEstado As Boolean = False
    Private _str_EstadoSolicitud As String = String.Empty

#End Region

#Region "Propiedades"

    Public Property int_ApoyoId() As Integer
        Get
            Return _int_ApoyoId
        End Get
        Set(ByVal value As Integer)
            _int_ApoyoId = value
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

    Public Property int_EstadoSolicitudId() As Integer
        Get
            Return _int_EstadoSolicitudId
        End Get
        Set(ByVal value As Integer)
            _int_EstadoSolicitudId = value
        End Set
    End Property

    Public Property det_FechaRespuestaCAT() As DateTime
        Get
            Return _det_FechaRespuestaCAT
        End Get
        Set(ByVal value As DateTime)
            _det_FechaRespuestaCAT = value
        End Set
    End Property

    Public Property det_FechaSolicitudCAT() As DateTime
        Get
            Return _det_FechaSolicitudCAT
        End Get
        Set(ByVal value As DateTime)
            _det_FechaSolicitudCAT = value
        End Set
    End Property

    Public Property str_IdProgramaCAT() As String
        Get
            Return _str_IdProgramaCAT
        End Get
        Set(ByVal value As String)
            _str_IdProgramaCAT = value
        End Set
    End Property

    Public Property dec_ImporteApoyoCAT() As Decimal
        Get
            Return _dec_ImporteApoyoCAT
        End Get
        Set(ByVal value As Decimal)
            _dec_ImporteApoyoCAT = value
        End Set
    End Property

    Public Property int_MaquinaApoyoId() As Integer
        Get
            Return _int_MaquinaApoyoId
        End Get
        Set(ByVal value As Integer)
            _int_MaquinaApoyoId = value
        End Set
    End Property

    Public Property str_Observacion() As String
        Get
            Return _str_Observacion
        End Get
        Set(ByVal value As String)
            _str_Observacion = value
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

    Public Property str_UsuarioCreacion() As String
        Get
            Return _str_UsuarioCreacion
        End Get
        Set(ByVal value As String)
            _str_UsuarioCreacion = value
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

    Public Property str_UsuarioModificacion() As String
        Get
            Return _str_UsuarioModificacion
        End Get
        Set(ByVal value As String)
            _str_UsuarioModificacion = value
        End Set
    End Property

    Public Property str_RespuestaTipo() As String
        Get
            Return _str_RespuestaTipo
        End Get
        Set(ByVal value As String)
            _str_RespuestaTipo = value
        End Set
    End Property

    Public Property str_EstadoSolicitud() As String
        Get
            Return _str_EstadoSolicitud
        End Get
        Set(ByVal value As String)
            _str_EstadoSolicitud = value
        End Set
    End Property

    Public Property bl_SolicitudEstado() As Boolean
        Get
            Return _bl_SolicitudEstado
        End Get
        Set(ByVal value As Boolean)
            _bl_SolicitudEstado = value
        End Set
    End Property

#End Region

End Class
