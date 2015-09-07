Public Class BE_Roles

#Region "Atributos"

    Private _det_FechaCreacion As DateTime = Date.Now()
    Private _det_FechaModificacion As DateTime = Date.Now()
    Private _int_ModuloId As Integer = 0
    Private _str_RolesDes As String = ""
    Private _int_RolId As Integer = 0
    Private _str_UsuarioCreacion As String = ""
    Private _str_UsuarioModificacion As String = ""
    Private _bl_UsuariosRolesStatus As Boolean = False
    Private _int_UsurioId As Integer = 0

#End Region

#Region "Propiedades"

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

    Public Property int_ModuloId() As Integer
        Get
            Return _int_ModuloId
        End Get
        Set(ByVal value As Integer)
            _int_ModuloId = value
        End Set
    End Property

    Public Property str_RolesDes() As String
        Get
            Return _str_RolesDes
        End Get
        Set(ByVal value As String)
            _str_RolesDes = value
        End Set
    End Property

    Public Property int_RolId() As Integer
        Get
            Return _int_RolId
        End Get
        Set(ByVal value As Integer)
            _int_RolId = value
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

    Public Property bl_UsuariosRolesStatus() As Boolean
        Get
            Return _bl_UsuariosRolesStatus
        End Get
        Set(ByVal value As Boolean)
            _bl_UsuariosRolesStatus = value
        End Set
    End Property

    Public Property int_UsuarioId() As Integer
        Get
            Return _int_UsurioId
        End Get
        Set(ByVal value As Integer)
            _int_UsurioId = value
        End Set
    End Property

#End Region


End Class
