Public Class BE_Usuarios


#Region "Atributos"

    Private _int_UsuarioId As Integer = 0
    Private _str_CompaniaId As String = String.Empty
    Private _str_CompaniaDes As String = String.Empty
    Private _str_Usuario_Login As String = String.Empty
    Private _str_Usuario_Nombres As String = String.Empty
    Private _str_Usuario_Apellidos As String = String.Empty
    Private _str_Usuario_Password As String = String.Empty
    Private _str_Usuario_Email As String = String.Empty
    Private _str_NroPersonal As String = String.Empty
    Private _str_CodigoAdrian As String = String.Empty
    Private _str_CodigoSAP As String = String.Empty
    Private _str_Funcion As String = String.Empty
    Private _str_Cargo As String = String.Empty
    Private _det_FechaCreacion As New System.Nullable(Of DateTime)()
    Private _str_UsuarioCreacion As String = String.Empty
    Private _det_FechaModificacion As New System.Nullable(Of DateTime)()
    Private _str_UsuarioModificacion As String = String.Empty
    Private _bl_Usuario_Status As Boolean = False
    Private _bl_Module_GestionInventario As Boolean = False
    Private _bl_Module_ApoyoFabricante As Boolean = False
    Private _bl_Module_Bonos As Boolean = False
    Private _bl_Module_Administracion As Boolean = False

#End Region

#Region "Propiedades"


    Public Property int_UsuarioId() As Integer
        Get
            Return _int_UsuarioId
        End Get
        Set(ByVal value As Integer)
            _int_UsuarioId = value
        End Set
    End Property

    Public Property str_CompaniaDes() As String
        Get
            Return _str_CompaniaDes
        End Get
        Set(ByVal value As String)
            _str_CompaniaDes = value
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

    Public Property str_Usuario_Apellidos() As String
        Get
            Return _str_Usuario_Apellidos
        End Get
        Set(ByVal value As String)
            _str_Usuario_Apellidos = value
        End Set
    End Property

    Public Property str_Usuario_Nombres() As String
        Get
            Return _str_Usuario_Nombres
        End Get
        Set(ByVal value As String)
            _str_Usuario_Nombres = value
        End Set
    End Property

    Public Property str_Usuario_Login() As String
        Get
            Return _str_Usuario_Login
        End Get
        Set(ByVal value As String)
            _str_Usuario_Login = value
        End Set
    End Property

    Public Property str_Usuario_Password() As String
        Get
            Return _str_Usuario_Password
        End Get
        Set(ByVal value As String)
            _str_Usuario_Password = value
        End Set
    End Property

    Public Property str_Usuario_Email() As String
        Get
            Return _str_Usuario_Email
        End Get
        Set(ByVal value As String)
            _str_Usuario_Email = value
        End Set
    End Property

    Public Property str_NroPersonal() As String
        Get
            Return _str_NroPersonal
        End Get
        Set(ByVal value As String)
            _str_NroPersonal = value
        End Set
    End Property

    Public Property str_CodigoAdrian() As String
        Get
            Return _str_CodigoAdrian
        End Get
        Set(ByVal value As String)
            _str_CodigoAdrian = value
        End Set
    End Property

    Public Property str_CodigoSAP() As String
        Get
            Return _str_CodigoSAP
        End Get
        Set(ByVal value As String)
            _str_CodigoSAP = value
        End Set
    End Property

    Public Property str_Funcion() As String
        Get
            Return _str_Funcion
        End Get
        Set(ByVal value As String)
            _str_Funcion = value
        End Set
    End Property

    Public Property str_Cargo() As String
        Get
            Return _str_Cargo
        End Get
        Set(ByVal value As String)
            _str_Cargo = value
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

    Public Property str_UsuarioCreacion() As String
        Get
            Return _str_UsuarioCreacion
        End Get
        Set(ByVal value As String)
            _str_UsuarioCreacion = value
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

    Public Property str_UsuarioModificacion() As String
        Get
            Return _str_UsuarioModificacion
        End Get
        Set(ByVal value As String)
            _str_UsuarioModificacion = value
        End Set
    End Property

    Public Property bl_Usuario_Status() As Boolean
        Get
            Return _bl_Usuario_Status
        End Get
        Set(ByVal value As Boolean)
            _bl_Usuario_Status = value
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


#End Region

End Class
