Public Class BE_LineaVentaMaestro

#Region "Atributos"

    Private _str_CargoFirma As String = String.Empty
    Private _str_DescLineaVenta As String = String.Empty
    Private _det_FechaCreacion As New System.Nullable(Of DateTime)()
    Private _det_FechaModificacion As New System.Nullable(Of DateTime)()
    Private _int_IdLineaVenta As Integer = 0
    Private _str_NombreImagenFirma As String = String.Empty
    Private _byte_ImagenFirma As Byte() = Nothing
    Private _str_NombreFirma As String = String.Empty
    Private _str_UsuarioCreacion As String = String.Empty
    Private _str_UsuarioModificacion As String = String.Empty
    Private _str_IdCompania As String = String.Empty
    Private _str_CompaniaDes As String = String.Empty
    Private _int_DiasReserva As Integer = 0
    Private _int_TipoTransaccion As Integer = 0
    Private _bl_Washout As Boolean = False
    Private _bl_StatusLineaVenta As Boolean = False

#End Region

#Region "Propiedades"

    Public Property str_CargoFirma() As String
        Get
            Return _str_CargoFirma
        End Get
        Set(ByVal value As String)
            _str_CargoFirma = value
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

    Public Property int_IdLineaVenta() As Integer
        Get
            Return _int_IdLineaVenta
        End Get
        Set(ByVal value As Integer)
            _int_IdLineaVenta = value
        End Set
    End Property

    Public Property str_NombreImagenFirma() As String
        Get
            Return _str_NombreImagenFirma
        End Get
        Set(ByVal value As String)
            _str_NombreImagenFirma = value
        End Set
    End Property

    Public Property byte_ImagenFirma() As Byte()
        Get
            Return _byte_ImagenFirma
        End Get
        Set(ByVal value As Byte())
            _byte_ImagenFirma = value
        End Set
    End Property


    Public Property str_NombreFirma() As String
        Get
            Return _str_NombreFirma
        End Get
        Set(ByVal value As String)
            _str_NombreFirma = value
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

    Public Property str_IdCompania() As String
        Get
            Return _str_IdCompania
        End Get
        Set(ByVal value As String)
            _str_IdCompania = value
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

    Public Property int_DiasReserva() As Integer
        Get
            Return _int_DiasReserva
        End Get
        Set(ByVal value As Integer)
            _int_DiasReserva = value
        End Set
    End Property

    Public Property int_TipoTransaccion() As Integer
        Get
            Return _int_TipoTransaccion
        End Get
        Set(ByVal value As Integer)
            _int_TipoTransaccion = value
        End Set
    End Property

    Public Property bl_Washout() As Boolean
        Get
            Return _bl_Washout
        End Get
        Set(ByVal value As Boolean)
            _bl_Washout = value
        End Set
    End Property

    Public Property bl_StatusLineaVenta() As Boolean
        Get
            Return _bl_StatusLineaVenta
        End Get
        Set(ByVal value As Boolean)
            _bl_StatusLineaVenta = value
        End Set
    End Property

#End Region

End Class
