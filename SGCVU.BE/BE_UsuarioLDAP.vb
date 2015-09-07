Public Class BE_UsuarioLDAP

    Private _Flag As Boolean = False
    Public Property Flag() As Boolean
        Get
            Return _Flag
        End Get
        Set(ByVal value As Boolean)
            _Flag = value
        End Set
    End Property

    Private _sAMAccountName As String = String.Empty
    Public Property sAMAccountName() As String
        Get
            Return _sAMAccountName
        End Get
        Set(ByVal value As String)
            _sAMAccountName = value
        End Set
    End Property

    Private _company As String
    Public Property company() As String
        Get
            Return _company
        End Get
        Set(ByVal value As String)
            _company = value
        End Set
    End Property

    Private _mail As String
    Public Property mail() As String
        Get
            Return _mail
        End Get
        Set(ByVal value As String)
            _mail = value
        End Set
    End Property

    Private _employeeID As String
    Public Property employeeID() As String
        Get
            Return _employeeID
        End Get
        Set(ByVal value As String)
            _employeeID = value
        End Set
    End Property

    Private _givenName As String
    Public Property givenName() As String
        Get
            Return _givenName
        End Get
        Set(ByVal value As String)
            _givenName = value
        End Set
    End Property

    Private _homePostalAddress As String
    Public Property homePostalAddress() As String
        Get
            Return _homePostalAddress
        End Get
        Set(ByVal value As String)
            _homePostalAddress = value
        End Set
    End Property

    Private _homePhone As String
    Public Property homePhone() As String
        Get
            Return _homePhone
        End Get
        Set(ByVal value As String)
            _homePhone = value
        End Set
    End Property

    Private _ipPhone As String
    Public Property ipPhone() As String
        Get
            Return _ipPhone
        End Get
        Set(ByVal value As String)
            _ipPhone = value
        End Set
    End Property

    Private _title As String
    Public Property title() As String
        Get
            Return _title
        End Get
        Set(ByVal value As String)
            _title = value
        End Set
    End Property

    Private _userPrincipalName As String
    Public Property userPrincipalName() As String
        Get
            Return _userPrincipalName
        End Get
        Set(ByVal value As String)
            _userPrincipalName = value
        End Set
    End Property

    Private _userWorkstations As String
    Public Property userWorkstations() As String
        Get
            Return _userWorkstations
        End Get
        Set(ByVal value As String)
            _userWorkstations = value
        End Set
    End Property

    Private _manager As String
    Public Property manager() As String
        Get
            Return _manager
        End Get
        Set(ByVal value As String)
            _manager = value
        End Set
    End Property

    Private _middleName As String
    Public Property middleName() As String
        Get
            Return _middleName
        End Get
        Set(ByVal value As String)
            _middleName = value
        End Set
    End Property

    Private _mobile As String
    Public Property mobile() As String
        Get
            Return _mobile
        End Get
        Set(ByVal value As String)
            _mobile = value
        End Set
    End Property

    Private _cn As String
    Public Property cn() As String
        Get
            Return _cn
        End Get
        Set(ByVal value As String)
            _cn = value
        End Set
    End Property

    Private _networkAddress As String
    Public Property networkAddress() As String
        Get
            Return _networkAddress
        End Get
        Set(ByVal value As String)
            _networkAddress = value
        End Set
    End Property

    Private _sAMAccountType As String
    Public Property sAMAccountType() As String
        Get
            Return _sAMAccountType
        End Get
        Set(ByVal value As String)
            _sAMAccountType = value
        End Set
    End Property

    Private _telephoneNumber As String
    Public Property telephoneNumber() As String
        Get
            Return _telephoneNumber
        End Get
        Set(ByVal value As String)
            _telephoneNumber = value
        End Set
    End Property

    Private _personalTitle As String
    Public Property personalTitle() As String
        Get
            Return _personalTitle
        End Get
        Set(ByVal value As String)
            _personalTitle = value
        End Set
    End Property

    Private _SeguridadNet As DataTable
    Public Property SeguridadNet() As DataTable
        Get
            Return _SeguridadNet
        End Get
        Set(ByVal value As DataTable)
            _SeguridadNet = value
        End Set
    End Property

    Private _be_trabajador_adryan As BE_TrabajadorAdryan
    Public Property be_trabajador_adryan() As BE_TrabajadorAdryan
        Get
            Return _be_trabajador_adryan
        End Get
        Set(ByVal value As BE_TrabajadorAdryan)
            _be_trabajador_adryan = value
        End Set
    End Property

    Private _str_IdCompania As String
    Public Property str_IdCompania() As String
        Get
            Return _str_IdCompania
        End Get
        Set(ByVal value As String)
            _str_IdCompania = value
        End Set
    End Property

    'Private _UsuarioActividad As List(Of BE_UsuarioActividad)
    'Public Property UsuarioActividad() As List(Of BE_UsuarioActividad)
    '   Get
    '      Return _UsuarioActividad
    '   End Get
    '   Set(ByVal value As List(Of BE_UsuarioActividad))
    '      _UsuarioActividad = value
    '   End Set
    'End Property

    'Private _UsuarioFlujo As List(Of BE_UsuarioFlujo)
    'Public Property UsuarioFlujo() As List(Of BE_UsuarioFlujo)
    '    Get
    '        Return _UsuarioFlujo
    '    End Get
    '    Set(ByVal value As List(Of BE_UsuarioFlujo))
    '        _UsuarioFlujo = value
    '    End Set
    'End Property

End Class
