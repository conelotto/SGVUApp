Public Class BE_CuentaInventarioMaestro

#Region "Atributos"

    Private _str_DescCuentaInventario As String = String.Empty
    Private _str_IdCuenta As String = String.Empty
    Private _int_IdCuentaInventario As Integer = 0
    Private _int_IdLineaVenta As Integer = 0
    Private _str_DescLineaVenta = String.Empty
    Private _det_FechaModificacion As New System.Nullable(Of DateTime)()
    Private _str_UsuarioModificacion As String = String.Empty

#End Region

#Region "Propiedades"

    Public Property str_DescCuentaInventario() As String
        Get
            Return _str_DescCuentaInventario
        End Get
        Set(ByVal value As String)
            _str_DescCuentaInventario = value
        End Set
    End Property

    Public Property str_IdCuenta() As String
        Get
            Return _str_IdCuenta
        End Get
        Set(ByVal value As String)
            _str_IdCuenta = value
        End Set
    End Property

    Public Property int_IdCuentaInventario() As Integer
        Get
            Return _int_IdCuentaInventario
        End Get
        Set(ByVal value As Integer)
            _int_IdCuentaInventario = value
        End Set
    End Property

    Public Property int_IdLineaVenta() As Integer
        Get
            Return _int_IdLineaVenta
        End Get
        Set(ByVal value As Integer)
            _int_IdLineaVenta = value
        End Set
    End Property

    Public Property str_DescLineaVenta() As String
        Get
            Return _str_DescLineaVenta
        End Get
        Set(ByVal value As String)
            _str_DescLineaVenta = value
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

#End Region
End Class
