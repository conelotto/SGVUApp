Public Class BE_Actividad

#Region "Atributos"

    Private _int_ActividadId As Integer = 0
    'Private _int_ActividadParentId As Integer = 0
    Private _str_ActividadDesc As String = String.Empty
    'Private _int_DuracionDias As Integer = 0
    'Private _int_Ordenamiento As Integer = 0
    'Private _det_FechaCreacion As DateTime = Date.Now()
    'Private _det_FechaModificacion As DateTime = Date.Now()
    'Private _str_UsuarioCreacion As String = String.Empty
    'Private _str_UsuarioModificacion As String = String.Empty
    Public Property ActividadId As Integer = 0
    'Private _int_ActividadParentId As Integer = 0
    Public Property ActividadDesc As String = String.Empty
#End Region

#Region "Propiedades"

    Public Property str_ActividadDesc() As String
        Get
            Return _str_ActividadDesc
        End Get
        Set(ByVal value As String)
            _str_ActividadDesc = value
        End Set
    End Property

    Public Property int_ActividadId() As Integer
        Get
            Return _int_ActividadId
        End Get
        Set(ByVal value As Integer)
            _int_ActividadId = value
        End Set
    End Property

    'Public Property int_ActividadParentId() As Integer
    '    Get
    '        Return _int_ActividadParentId
    '    End Get
    '    Set(ByVal value As Integer)
    '        _int_ActividadParentId = value
    '    End Set
    'End Property

    'Public Property int_DuracionDias() As Integer
    '    Get
    '        Return _int_DuracionDias
    '    End Get
    '    Set(ByVal value As Integer)
    '        _int_DuracionDias = value
    '    End Set
    'End Property

    'Public Property det_FechaCreacion() As DateTime
    '    Get
    '        Return _det_FechaCreacion
    '    End Get
    '    Set(ByVal value As DateTime)
    '        _det_FechaCreacion = value
    '    End Set
    'End Property

    'Public Property det_FechaModificacion() As DateTime
    '    Get
    '        Return _det_FechaModificacion
    '    End Get
    '    Set(ByVal value As DateTime)
    '        _det_FechaModificacion = value
    '    End Set
    'End Property

    'Public Property int_Ordenamiento() As Integer
    '    Get
    '        Return _int_Ordenamiento
    '    End Get
    '    Set(ByVal value As Integer)
    '        _int_Ordenamiento = value
    '    End Set
    'End Property

    'Public Property str_UsuarioCreacion() As String
    '    Get
    '        Return _str_UsuarioCreacion
    '    End Get
    '    Set(ByVal value As String)
    '        _str_UsuarioCreacion = value
    '    End Set
    'End Property

    'Public Property str_UsuarioModificacion() As String
    '    Get
    '        Return _str_UsuarioModificacion
    '    End Get
    '    Set(ByVal value As String)
    '        _str_UsuarioModificacion = value
    '    End Set
    'End Property

#End Region

End Class
