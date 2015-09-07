Public Class BE_Expediente_DocumentosAdjuntos

#Region "Atributos"

    Private _int_ApoyoId As Integer = 0
    Private _byte_ArchivoAdjunto As Byte() = Nothing
    Private _str_ArchivoNombre As String = String.Empty
    Private _int_ExpedienteId As Integer = 0
    Private _det_FechaCreacion As New System.Nullable(Of DateTime)()
    Private _det_FechaModificacion As New System.Nullable(Of DateTime)()
    Private _str_UsuarioCreacion As String = String.Empty
    Private _str_UsuarioModificacion As String = String.Empty

#End Region

#Region "Propiedades"

    Public Property int_ApoyoId() As Integer
        Get
            Return _int_ApoyoId
        End Get
        Set(ByVal value As Integer)
            _int_ApoyoId = value
        End Set
    End Property

    Public Property byte_ArchivoAdjunto() As Byte()
        Get
            Return _byte_ArchivoAdjunto
        End Get
        Set(ByVal value As Byte())
            _byte_ArchivoAdjunto = value
        End Set
    End Property

    Public Property str_ArchivoNombre() As String
        Get
            Return _str_ArchivoNombre
        End Get
        Set(ByVal value As String)
            _str_ArchivoNombre = value
        End Set
    End Property

    Public Property int_ExpedienteId() As Integer
        Get
            Return _int_ExpedienteId
        End Get
        Set(ByVal value As Integer)
            _int_ExpedienteId = value
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

#End Region



End Class
