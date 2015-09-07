Public Class BE_CuentaUsuario

    Private _str_IdCuenta As String = String.Empty
    Private _str_DescCuentaInventario As String = String.Empty
    Private _str_IdUsuario As String = String.Empty
    Private _bl_CuentaUsuarioStatus As Boolean = False

    Public Property str_IdCuenta() As String
        Get
            Return _str_IdCuenta
        End Get
        Set(ByVal value As String)
            _str_IdCuenta = value
        End Set
    End Property

    Public Property str_DescCuentaInventario() As String
        Get
            Return _str_DescCuentaInventario
        End Get
        Set(ByVal value As String)
            _str_DescCuentaInventario = value
        End Set
    End Property

    Public Property str_IdUsuario() As String
        Get
            Return _str_IdUsuario
        End Get
        Set(ByVal value As String)
            _str_IdUsuario = value
        End Set
    End Property

    Public Property bl_CuentaUsuarioStatus() As Boolean
        Get
            Return _bl_CuentaUsuarioStatus
        End Get
        Set(ByVal value As Boolean)
            _bl_CuentaUsuarioStatus = value
        End Set
    End Property

End Class
