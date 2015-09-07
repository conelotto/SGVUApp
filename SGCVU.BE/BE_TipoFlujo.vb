Public Class BE_TipoFlujo

#Region "Atributos"

    Private _det_FechaCreacion As DateTime = Date.Now()
    Private _det_FechaModificacion As DateTime = Date.Now()
    Private _str_TipoFlujoDesc As String = String.Empty
    Private _int_TipoFlujoId As Integer = 0
    Private _str_UsuarioCreacion As String = String.Empty
    Private _str_UsuarioModificacion As String = String.Empty

#End Region

#Region "Propiedades"

    Public Property int_TipoFlujoId() As Integer
        Get
            Return _int_TipoFlujoId
        End Get
        Set(ByVal value As Integer)
            _int_TipoFlujoId = value
        End Set
    End Property

    Public Property str_TipoFlujoDesc() As String
        Get
            Return _str_TipoFlujoDesc
        End Get
        Set(ByVal value As String)
            _str_TipoFlujoDesc = value
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

    Public Property str_UsuarioCreacion() As String
        Get
            Return _str_UsuarioCreacion
        End Get
        Set(ByVal value As String)
            _str_UsuarioCreacion = value
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

#End Region
End Class
