Public Class BE_Apoyo_Flujo

    Private _int_ApoyoId As Integer = 0
    Private _str_CompaniaId As String = String.Empty
    Private _str_OrdenAsignada As String = String.Empty
    Private _str_PedidoId As String = String.Empty
    Private _int_PosicionId As Integer = 0
    Private _str_ModeloRDA As String = String.Empty
    Private _str_ModeloProductoId As String = String.Empty
    Private _str_ModeloProductoDesc As String = String.Empty
    Private _str_SerieMaquina As String = String.Empty
    Private _str_EstadoInventario As String = String.Empty
    Private _str_FacturaNumero As String = String.Empty
    Private _bl_EstructuraCostos As Boolean = False
    Private _str_ClienteId As String = String.Empty
    Private _str_DESC_CLIENTE As String = String.Empty
    Private _str_ApoyoTipoId As String = String.Empty
    Private _str_ApoyoTipoDesc As String = String.Empty
    Private _dec_ApoyoImporteCRM As Decimal = 0
    Private _dec_ValorVentaMaquinaCRM As Decimal = 0
    Private _int_ExpedienteId As Integer = 0
    Private _int_FlujoId As Integer = 0
    Private _str_FlujoEstado As String = String.Empty
    Private _int_MaquinaApoyoId As Integer = 0
    Private _str_IdProgramaCAT As String = String.Empty
    Private _det_FechaSolicitudCAT As New System.Nullable(Of DateTime)()
    Private _det_FechaRespuestaCAT As New System.Nullable(Of DateTime)()
    Private _dec_ImporteApoyoCAT As Decimal = 0
    Private _int_DiasSolicitud As Integer = 0
    Private _str_Observacion As String = String.Empty
    Private _int_SolicitudId As Integer = 0
    Private _str_SolicitudEstado As String = String.Empty
    Private _byte_Washout As Byte() = Nothing
    Private _str_WashoutArchivo As String = String.Empty
    Private _det_WashOutFecha As New System.Nullable(Of DateTime)()
    Private _int_WashoutId As Integer = 0
    Private _str_WashoutEstado As String = String.Empty
    Private _bl_HaveWashout As Boolean = False
    Private _int_DiasWashout As Integer = 0
    Private _det_WashoutFechaRespuesta As New System.Nullable(Of DateTime)()
    Private _det_FechaSRC As New System.Nullable(Of DateTime)()
    Private _det_FechaClaim As New System.Nullable(Of DateTime)()
    Private _str_RespuestaTipo As String = String.Empty
    Private _int_DiasClaim As Integer = 0
    Private _str_UserName As String = String.Empty
    Private _int_SubGridFlag As Integer = 0
    Private _str_Comentarios As String = String.Empty
    Private _str_CuentaInventarioDBS As String = String.Empty

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

    Public Property str_ModeloRDA() As String
        Get
            Return _str_ModeloRDA
        End Get
        Set(ByVal value As String)
            _str_ModeloRDA = value
        End Set
    End Property

    Public Property str_ModeloProductoId() As String
        Get
            Return _str_ModeloProductoId
        End Get
        Set(ByVal value As String)
            _str_ModeloProductoId = value
        End Set
    End Property

    Public Property str_ModeloProductoDesc() As String
        Get
            Return _str_ModeloProductoDesc
        End Get
        Set(ByVal value As String)
            _str_ModeloProductoDesc = value
        End Set
    End Property

    Public Property str_SerieMaquina() As String
        Get
            Return _str_SerieMaquina
        End Get
        Set(ByVal value As String)
            _str_SerieMaquina = value
        End Set
    End Property

    Public Property str_EstadoInventario() As String
        Get
            Return _str_EstadoInventario
        End Get
        Set(ByVal value As String)
            _str_EstadoInventario = value
        End Set
    End Property

    Public Property str_FacturaNumero() As String
        Get
            Return _str_FacturaNumero
        End Get
        Set(ByVal value As String)
            _str_FacturaNumero = value
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

    Public Property str_ClienteId() As String
        Get
            Return _str_ClienteId
        End Get
        Set(ByVal value As String)
            _str_ClienteId = value
        End Set
    End Property

    Public Property str_DESC_CLIENTE() As String
        Get
            Return _str_DESC_CLIENTE
        End Get
        Set(ByVal value As String)
            _str_DESC_CLIENTE = value
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

    Public Property str_ApoyoTipoDesc() As String
        Get
            Return _str_ApoyoTipoDesc
        End Get
        Set(ByVal value As String)
            _str_ApoyoTipoDesc = value
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

    Public Property dec_ValorVentaMaquinaCRM() As Decimal
        Get
            Return _dec_ValorVentaMaquinaCRM
        End Get
        Set(ByVal value As Decimal)
            _dec_ValorVentaMaquinaCRM = value
        End Set
    End Property

    Public Property int_ExpedienteId() As Integer
        Get
            Return _int_ExpedienteId
        End Get
        Set(ByVal value As Integer)
            _int_ExpedienteId = value
        End Set
    End Property

    Public Property int_FlujoId() As Integer
        Get
            Return _int_FlujoId
        End Get
        Set(ByVal value As Integer)
            _int_FlujoId = value
        End Set
    End Property

    Public Property str_FlujoEstado() As String
        Get
            Return _str_FlujoEstado
        End Get
        Set(ByVal value As String)
            _str_FlujoEstado = value
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

    Public Property str_IdProgramaCAT() As String
        Get
            Return _str_IdProgramaCAT
        End Get
        Set(ByVal value As String)
            _str_IdProgramaCAT = value
        End Set
    End Property

    Public Property det_FechaSolicitudCAT() As System.Nullable(Of DateTime)
        Get
            Return _det_FechaSolicitudCAT
        End Get
        Set(ByVal value As System.Nullable(Of DateTime))
            _det_FechaSolicitudCAT = value
        End Set
    End Property

    Public Property int_DiasSolicitud() As Integer
        Get
            Return _int_DiasSolicitud
        End Get
        Set(ByVal value As Integer)
            _int_DiasSolicitud = value
        End Set
    End Property

    Public Property int_SolicitudId() As Integer
        Get
            Return _int_SolicitudId
        End Get
        Set(ByVal value As Integer)
            _int_SolicitudId = value
        End Set
    End Property

    Public Property str_SolicitudEstado() As String
        Get
            Return _str_SolicitudEstado
        End Get
        Set(ByVal value As String)
            _str_SolicitudEstado = value
        End Set
    End Property

    Public Property det_WashOutFecha() As System.Nullable(Of DateTime)
        Get
            Return _det_WashOutFecha
        End Get
        Set(ByVal value As System.Nullable(Of DateTime))
            _det_WashOutFecha = value
        End Set
    End Property

    Public Property byte_Washout() As Byte()
        Get
            Return _byte_Washout
        End Get
        Set(ByVal value As Byte())
            _byte_Washout = value
        End Set
    End Property

    Public Property str_WashoutArchivo() As String
        Get
            Return _str_WashoutArchivo
        End Get
        Set(ByVal value As String)
            _str_WashoutArchivo = value
        End Set
    End Property

    Public Property int_WashoutId() As Integer
        Get
            Return _int_WashoutId
        End Get
        Set(ByVal value As Integer)
            _int_WashoutId = value
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

    Public Property bl_HaveWashout() As Boolean
        Get
            Return _bl_HaveWashout
        End Get
        Set(ByVal value As Boolean)
            _bl_HaveWashout = value
        End Set
    End Property

    Public Property det_WashoutFechaRespuesta() As System.Nullable(Of DateTime)
        Get
            Return _det_WashoutFechaRespuesta
        End Get
        Set(ByVal value As System.Nullable(Of DateTime))
            _det_WashoutFechaRespuesta = value
        End Set
    End Property

    Public Property int_DiasWashout() As Integer
        Get
            Return _int_DiasWashout
        End Get
        Set(ByVal value As Integer)
            _int_DiasWashout = value
        End Set
    End Property

    Public Property det_FechaRespuestaCAT() As System.Nullable(Of DateTime)
        Get
            Return _det_FechaRespuestaCAT
        End Get
        Set(ByVal value As System.Nullable(Of DateTime))
            _det_FechaRespuestaCAT = value
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

    Public Property str_Observacion() As String
        Get
            Return _str_Observacion
        End Get
        Set(ByVal value As String)
            _str_Observacion = value
        End Set
    End Property

    Public Property det_FechaSRC() As System.Nullable(Of DateTime)
        Get
            Return _det_FechaSRC
        End Get
        Set(ByVal value As System.Nullable(Of DateTime))
            _det_FechaSRC = value
        End Set
    End Property

    Public Property det_FechaClaim() As System.Nullable(Of DateTime)
        Get
            Return _det_FechaClaim
        End Get
        Set(ByVal value As System.Nullable(Of DateTime))
            _det_FechaClaim = value
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

    Public Property int_DiasClaim() As Integer
        Get
            Return _int_DiasClaim
        End Get
        Set(ByVal value As Integer)
            _int_DiasClaim = value
        End Set
    End Property

    Public Property str_UserName() As String
        Get
            Return _str_UserName
        End Get
        Set(ByVal value As String)
            _str_UserName = value
        End Set
    End Property

    Public Property int_SubGridFlag() As Integer
        Get
            Return _int_SubGridFlag
        End Get
        Set(ByVal value As Integer)
            _int_SubGridFlag = value
        End Set
    End Property

    Public Property str_Comentarios() As String
        Get
            Return _str_Comentarios
        End Get
        Set(ByVal value As String)
            _str_Comentarios = value
        End Set
    End Property

    Public Property str_CuentaInventarioDBS() As String
        Get
            Return _str_CuentaInventarioDBS
        End Get
        Set(ByVal value As String)
            _str_CuentaInventarioDBS = value
        End Set
    End Property

End Class

