Public Class BE_TrabajadorAdryan

#Region "Atributos"

    Private _str_COMPANIA As String = String.Empty
    Private _str_CODIGO As String = String.Empty
    Private _str_SUCURSAL As String = String.Empty
    Private _str_DESC_SUCURSAL As String = String.Empty
    Private _str_NOMBRE As String = String.Empty
    Private _str_MATRICULA As String = String.Empty

    Property str_CORREO As String = String.Empty

#End Region

#Region "Propiedades"

    Public Property str_COMPANIA() As String
        Get
            Return _str_COMPANIA
        End Get
        Set(ByVal value As String)
            _str_COMPANIA = value
        End Set
    End Property

    Public Property str_CODIGO() As String
        Get
            Return _str_CODIGO
        End Get
        Set(ByVal value As String)
            _str_CODIGO = value
        End Set
    End Property

    Public Property str_SUCURSAL() As String
        Get
            Return _str_SUCURSAL
        End Get
        Set(ByVal value As String)
            _str_SUCURSAL = value
        End Set
    End Property

    Public Property str_DESC_SUCURSAL() As String
        Get
            Return _str_DESC_SUCURSAL
        End Get
        Set(ByVal value As String)
            _str_DESC_SUCURSAL = value
        End Set
    End Property

    Public Property str_NOMBRE() As String
        Get
            Return _str_NOMBRE
        End Get
        Set(ByVal value As String)
            _str_NOMBRE = value
        End Set
    End Property

    Public Property str_MATRICULA() As String
        Get
            Return _str_MATRICULA
        End Get
        Set(ByVal value As String)
            _str_MATRICULA = value
        End Set
    End Property

#End Region

End Class
