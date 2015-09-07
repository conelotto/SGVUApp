Public Class BE_IncidenteHist
#Region "Atributos"

    Private _det_FechaFin As DateTime = Date.Now()
    Private _det_FechaInicio As DateTime = Date.Now()
    Private _str_Flag As String = String.Empty
    Private _int_IdActividad As Integer = 0
    Private _int_IdIncidente As Integer = 0
    Private _str_IdUsuario As String = String.Empty
    Private _str_ActividadDesc As String

#End Region

#Region "Propiedades"

    Public Property det_FechaFin() As DateTime
        Get
            Return _det_FechaFin
        End Get
        Set(ByVal value As DateTime)
            _det_FechaFin = value
        End Set
    End Property

    Public Property det_FechaInicio() As DateTime
        Get
            Return _det_FechaInicio
        End Get
        Set(ByVal value As DateTime)
            _det_FechaInicio = value
        End Set
    End Property

    Public Property str_Flag() As String
        Get
            Return _str_Flag
        End Get
        Set(ByVal value As String)
            _str_Flag = value
        End Set
    End Property

    Public Property int_IdActividad() As Integer
        Get
            Return _int_IdActividad
        End Get
        Set(ByVal value As Integer)
            _int_IdActividad = value
        End Set
    End Property

    Public Property int_IdIncidente() As Integer
        Get
            Return _int_IdIncidente
        End Get
        Set(ByVal value As Integer)
            _int_IdIncidente = value
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

    Public Property str_ActividadDesc() As String
        Get
            Return _str_ActividadDesc
        End Get
        Set(ByVal value As String)
            _str_ActividadDesc = value
        End Set
    End Property

#End Region
End Class
