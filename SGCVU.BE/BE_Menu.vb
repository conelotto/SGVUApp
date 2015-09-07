Public Class BE_Menu

    '#Region "Atributos"

    '   Private _int_Id_Menu As Integer = 0
    '   Private _str_Nombre_para_mostrar As String = String.Empty
    '   Private _str_Nombre_dll As String = String.Empty
    '   Private _str_Nombre_formulario As String = String.Empty
    '   Private _str_Visible As String = String.Empty
    '   Private _int_Id_Menu_Padre As Integer = 0
    '   Private _str_Admin As String = String.Empty

    '#End Region

    '#Region "Propiedades"

    '   Public Property int_Id_Menu() As Integer
    '      Get
    '         Return _int_Id_Menu
    '      End Get
    '      Set(ByVal value As Integer)
    '         _int_Id_Menu = value
    '      End Set
    '   End Property

    '   Public Property str_Nombre_para_mostrar() As String
    '      Get
    '         Return _str_Nombre_para_mostrar
    '      End Get
    '      Set(ByVal value As String)
    '         _str_Nombre_para_mostrar = value
    '      End Set
    '   End Property

    '   Public Property str_Nombre_dll() As String
    '      Get
    '         Return _str_Nombre_dll
    '      End Get
    '      Set(ByVal value As String)
    '         _str_Nombre_dll = value
    '      End Set
    '   End Property

    '   Public Property str_Nombre_formulario() As String
    '      Get
    '         Return _str_Nombre_formulario
    '      End Get
    '      Set(ByVal value As String)
    '         _str_Nombre_formulario = value
    '      End Set
    '   End Property

    '   Public Property str_Visible() As String
    '      Get
    '         Return _str_Visible
    '      End Get
    '      Set(ByVal value As String)
    '         _str_Visible = value
    '      End Set
    '   End Property

    '   Public Property int_Id_Menu_Padre() As Integer
    '      Get
    '         Return _int_Id_Menu_Padre
    '      End Get
    '      Set(ByVal value As Integer)
    '         _int_Id_Menu_Padre = value
    '      End Set
    '   End Property

    '   Public Property str_Admin() As String
    '      Get
    '         Return _str_Admin
    '      End Get
    '      Set(ByVal value As String)
    '         _str_Admin = value
    '      End Set
    '   End Property

    '#End Region

#Region "Atributos"

    Private _int_MenuId As Integer = 0
    Private _int_ModuloId As Integer = 0
    Private _str_Menu As String = String.Empty
    Private _str_Menu_URL As String = String.Empty
    Private _int_MenuParentId As Integer = 0
    Private _int_Menu_Status As Integer = 0
    Private _det_FechaCreacion As DateTime = Date.Now()
    Private _str_UsuarioCreacion As String = String.Empty
    Private _det_FechaModificacion As DateTime = Date.Now()
    Private _str_UsuarioModificacion As String = String.Empty

#End Region

#Region "Propiedades"

    Public Property int_MenuId() As Integer
        Get
            Return _int_MenuId
        End Get
        Set(ByVal value As Integer)
            _int_MenuId = value
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

    Public Property str_Menu() As String
        Get
            Return _str_Menu
        End Get
        Set(ByVal value As String)
            _str_Menu = value
        End Set
    End Property

    Public Property str_Menu_URL() As String
        Get
            Return _str_Menu_URL
        End Get
        Set(ByVal value As String)
            _str_Menu_URL = value
        End Set
    End Property

    Public Property int_MenuParentId() As Integer
        Get
            Return _int_MenuParentId
        End Get
        Set(ByVal value As Integer)
            _int_MenuParentId = value
        End Set
    End Property

    Public Property int_Menu_Status() As Integer
        Get
            Return _int_Menu_Status
        End Get
        Set(ByVal value As Integer)
            _int_Menu_Status = value
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
