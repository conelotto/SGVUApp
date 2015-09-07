Public Class BE_ExpedienteHistorial

#Region "Atributos"

    Private _int_ActividadId As Integer = 0
    Private _str_Actividad As String = String.Empty
    Private _int_ExpedienteHistorialId As Integer = 0
    Private _int_ExpedienteId As Integer = 0
    Private _det_FechaCreacion As DateTime = Date.Now()
    Private _int_RolFlujoId As Integer = 0
    Private _str_RolFlujo As String = String.Empty
    Private _int_UsuarioId As Integer = 0
    Private _str_Usuario As String = String.Empty
    Private _int_ApoyoId As Integer = 0
    Public Property str_FechaCreacion As String = String.Empty

#End Region

#Region "Propiedades"

    Public Property int_ActividadId() As Integer
        Get
            Return _int_ActividadId
        End Get
        Set(ByVal value As Integer)
            _int_ActividadId = value
        End Set
    End Property

    Public Property str_Actividad() As String
        Get
            Return _str_Actividad
        End Get
        Set(ByVal value As String)
            _str_Actividad = value
        End Set
    End Property

    Public Property int_ExpedienteHistorialId() As Integer
        Get
            Return _int_ExpedienteHistorialId
        End Get
        Set(ByVal value As Integer)
            _int_ExpedienteHistorialId = value
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

    Public Property det_FechaCreacion() As DateTime
        Get
            Return _det_FechaCreacion
        End Get
        Set(ByVal value As DateTime)
            _det_FechaCreacion = value
        End Set
    End Property

    Public Property int_RolFlujoId() As Integer
        Get
            Return _int_RolFlujoId
        End Get
        Set(ByVal value As Integer)
            _int_RolFlujoId = value
        End Set
    End Property

    Public Property str_RolFlujo() As String
        Get
            Return _str_RolFlujo
        End Get
        Set(ByVal value As String)
            _str_RolFlujo = value
        End Set
    End Property

    Public Property int_UsuarioId() As Integer
        Get
            Return _int_UsuarioId
        End Get
        Set(ByVal value As Integer)
            _int_UsuarioId = value
        End Set
    End Property

    Public Property int_ApoyoId() As Integer
        Get
            Return _int_ApoyoId
        End Get
        Set(ByVal value As Integer)
            _int_ApoyoId = value
        End Set
    End Property

    Public Property str_Usuario() As String
        Get
            Return _str_Usuario
        End Get
        Set(ByVal value As String)
            _str_Usuario = value
        End Set
    End Property

#End Region



End Class
