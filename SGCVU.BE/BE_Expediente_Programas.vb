Public Class BE_Expediente_Programas

#Region "Atributos"

    Private _int_ApoyoId As Integer = 0
    Private _str_CompaniaId As String = String.Empty
    Private _bl_ExpPrograma_Estado As Boolean = False
    Private _det_ExpPrograma_FechaClaim As New System.Nullable(Of DateTime)()
    Private _det_ExpPrograma_FechaCreditMemo As New System.Nullable(Of DateTime)()
    Private _int_ExpPrograma_Id As Integer = 0
    Private _dec_ExpPrograma_MontoPagado As Decimal = 0
    Private _dec_ExpPrograma_MontoSolicitado As Decimal = 0
    Private _str_ExpPrograma_NumeroClaim As String = String.Empty
    Private _str_ExpPrograma_NumeroCreditMemo As String = String.Empty
    Private _bl_Estado_Solicitud As Boolean = False
    Private _det_FechaCreacion As New System.Nullable(Of DateTime)()
    Private _det_FechaModificacion As New System.Nullable(Of DateTime)()
    Private _str_OrdenAsignada As String = String.Empty
    Private _str_PedidoId As String = String.Empty
    Private _int_PosicionId As Integer = 0
    Private _int_ProgramasId As Integer = 0
    Private _str_UsuarioCreacion As String = String.Empty
    Private _str_UsuarioModificacion As String = String.Empty
    Private _str_IdProgramaCAT As String = String.Empty
    Private _str_DescPrograma As String = String.Empty



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

    Public Property bl_ExpPrograma_Estado() As Boolean
        Get
            Return _bl_ExpPrograma_Estado
        End Get
        Set(ByVal value As Boolean)
            _bl_ExpPrograma_Estado = value
        End Set
    End Property

    Public Property det_ExpPrograma_FechaClaim() As System.Nullable(Of DateTime)
        Get
            Return _det_ExpPrograma_FechaClaim
        End Get
        Set(ByVal value As System.Nullable(Of DateTime))
            _det_ExpPrograma_FechaClaim = value
        End Set
    End Property

    Public Property det_ExpPrograma_FechaCreditMemo() As System.Nullable(Of DateTime)
        Get
            Return _det_ExpPrograma_FechaCreditMemo
        End Get
        Set(ByVal value As System.Nullable(Of DateTime))
            _det_ExpPrograma_FechaCreditMemo = value
        End Set
    End Property

    Public Property int_ExpPrograma_Id() As Integer
        Get
            Return _int_ExpPrograma_Id
        End Get
        Set(ByVal value As Integer)
            _int_ExpPrograma_Id = value
        End Set
    End Property

    Public Property dec_ExpPrograma_MontoPagado() As Decimal
        Get
            Return _dec_ExpPrograma_MontoPagado
        End Get
        Set(ByVal value As Decimal)
            _dec_ExpPrograma_MontoPagado = value
        End Set
    End Property

    Public Property dec_ExpPrograma_MontoSolicitado() As Decimal
        Get
            Return _dec_ExpPrograma_MontoSolicitado
        End Get
        Set(ByVal value As Decimal)
            _dec_ExpPrograma_MontoSolicitado = value
        End Set
    End Property

    Public Property str_ExpPrograma_NumeroClaim() As String
        Get
            Return _str_ExpPrograma_NumeroClaim
        End Get
        Set(ByVal value As String)
            _str_ExpPrograma_NumeroClaim = value
        End Set
    End Property

    Public Property str_ExpPrograma_NumeroCreditMemo() As String
        Get
            Return _str_ExpPrograma_NumeroCreditMemo
        End Get
        Set(ByVal value As String)
            _str_ExpPrograma_NumeroCreditMemo = value
        End Set
    End Property

    Public Property det_FechaCreacion() As System.Nullable(Of DateTime)
        Get
            Return _det_FechaCreacion
        End Get
        Set(ByVal value As System.Nullable(Of DateTime))
            _det_FechaCreacion = value
        End Set
    End Property

    Public Property det_FechaModificacion() As System.Nullable(Of DateTime)
        Get
            Return _det_FechaModificacion
        End Get
        Set(ByVal value As System.Nullable(Of DateTime))
            _det_FechaModificacion = value
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

    Public Property int_ProgramasId() As Integer
        Get
            Return _int_ProgramasId
        End Get
        Set(ByVal value As Integer)
            _int_ProgramasId = value
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

    Public Property str_IdProgramaCAT() As String
        Get
            Return _str_IdProgramaCAT
        End Get
        Set(ByVal value As String)
            _str_IdProgramaCAT = value
        End Set
    End Property

    Public Property str_DescPrograma() As String
        Get
            Return _str_DescPrograma
        End Get
        Set(ByVal value As String)
            _str_DescPrograma = value
        End Set
    End Property

    Public Property bl_Estado_Solicitud() As Boolean
        Get
            Return _bl_Estado_Solicitud
        End Get
        Set(ByVal value As Boolean)
            _bl_Estado_Solicitud = value
        End Set
    End Property

#End Region



End Class
