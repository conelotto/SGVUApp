Public Class BE_Usuarios_Modulos
#Region "Atributos"

    Private _det_FechaCreacion As New System.Nullable(Of DateTime)()
    Private _det_FechaModificacion As New System.Nullable(Of DateTime)()
    Private _bl_Module_Administracion As Boolean = False
    Private _bl_Module_ApoyoFabricante As Boolean = False
    Private _bl_Module_Bonos As Boolean = False
    Private _bl_Module_GestionInventario As Boolean = False
    Private _str_UsuarioCreacion As String = ""
    Private _int_UsuarioId As Integer = 0
    Private _str_UsuarioModificacion As String = ""
    Private _int_UsuariosModulosId As Integer = 0
    Private _str_UsuarioLogin As String = String.Empty
    Private _int_TypeTransaction As Integer = 0

#End Region

#Region "Propiedades"

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

    Public Property bl_Module_Administracion() As Boolean
        Get
            Return _bl_Module_Administracion
        End Get
        Set(ByVal value As Boolean)
            _bl_Module_Administracion = value
        End Set
    End Property

    Public Property bl_Module_ApoyoFabricante() As Boolean
        Get
            Return _bl_Module_ApoyoFabricante
        End Get
        Set(ByVal value As Boolean)
            _bl_Module_ApoyoFabricante = value
        End Set
    End Property

    Public Property bl_Module_Bonos() As Boolean
        Get
            Return _bl_Module_Bonos
        End Get
        Set(ByVal value As Boolean)
            _bl_Module_Bonos = value
        End Set
    End Property

    Public Property bl_Module_GestionInventario() As Boolean
        Get
            Return _bl_Module_GestionInventario
        End Get
        Set(ByVal value As Boolean)
            _bl_Module_GestionInventario = value
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

    Public Property int_UsuarioId() As Integer
        Get
            Return _int_UsuarioId
        End Get
        Set(ByVal value As Integer)
            _int_UsuarioId = value
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

    Public Property int_UsuariosModulosId() As Integer
        Get
            Return _int_UsuariosModulosId
        End Get
        Set(ByVal value As Integer)
            _int_UsuariosModulosId = value
        End Set
    End Property

    Public Property str_UsuarioLogin() As String
        Get
            Return _str_UsuarioLogin
        End Get
        Set(ByVal value As String)
            _str_UsuarioLogin = value
        End Set
    End Property

    Public Property int_TypeTransaction() As Integer
        Get
            Return _int_TypeTransaction
        End Get
        Set(ByVal value As Integer)
            _int_TypeTransaction = value
        End Set
    End Property

#End Region
End Class
