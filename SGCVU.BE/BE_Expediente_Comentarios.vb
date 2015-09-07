Public Class BE_Expediente_Comentarios

#Region "Atributos"

    Private _int_ApoyoId As Integer = 0
    Private _str_Observacion As String = String.Empty
    Private _str_UsuarioCreacion As String = ""
    Private _det_FechaCreacion As DateTime = Date.Now()
    Private _str_UsuarioModificacion As String = ""
    Private _det_FechaModificacion As DateTime = Date.Now()

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

    Public Property str_Observacion() As String
        Get
            Return _str_Observacion
        End Get
        Set(ByVal value As String)
            _str_Observacion = value
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


