Public Class BE_Incidente

#Region "Atributos"

    Private _str_Flag As String = String.Empty 'se usara para saber si el inicidente esta habilitado o no /////// 1 -> Habilitado /// 0 -> Deshabilitado
    Private _int_IdActividad As Integer = 0
    Private _int_IdIncidente As Integer = 0
    Private _str_IdUsuario As String = String.Empty
    Private _det_Fecha As DateTime = Now()
    Private _str_ArchivoBonoRpto As String = String.Empty
    Private _str_ArchivoBonoCSA As String = String.Empty
    Private _str_ArchivoBonoRptoFirmado As String = String.Empty
    Private _str_ArchivoBonoCSAFirmado As String = String.Empty
    Private _str_ArchivoBonoRptoFisico As String = String.Empty
    Private _str_ArchivoBonoCSAFisico As String = String.Empty

#End Region

#Region "Propiedades"

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

    Public Property det_Fecha() As DateTime
        Get
            Return _det_Fecha
        End Get
        Set(ByVal value As DateTime)
            _det_Fecha = value
        End Set
    End Property

    Public Property str_ArchivoBonoRpto() As String
        Get
            Return _str_ArchivoBonoRpto
        End Get
        Set(ByVal value As String)
            _str_ArchivoBonoRpto = value
        End Set
    End Property

    Public Property str_ArchivoBonoCSA() As String
        Get
            Return _str_ArchivoBonoCSA
        End Get
        Set(ByVal value As String)
            _str_ArchivoBonoCSA = value
        End Set
    End Property

    Public Property str_ArchivoBonoRptoFirmado() As String
        Get
            Return _str_ArchivoBonoRptoFirmado
        End Get
        Set(ByVal value As String)
            _str_ArchivoBonoRptoFirmado = value
        End Set
    End Property

    Public Property str_ArchivoBonoCSAFirmado() As String
        Get
            Return _str_ArchivoBonoCSAFirmado
        End Get
        Set(ByVal value As String)
            _str_ArchivoBonoCSAFirmado = value
        End Set
    End Property

    Public Property str_ArchivoBonoRptoFisico() As String
        Get
            Return _str_ArchivoBonoRptoFisico
        End Get
        Set(ByVal value As String)
            _str_ArchivoBonoRptoFisico = value
        End Set
    End Property

    Public Property str_ArchivoBonoCSAFisico() As String
        Get
            Return _str_ArchivoBonoCSAFisico
        End Get
        Set(ByVal value As String)
            _str_ArchivoBonoCSAFisico = value
        End Set
    End Property

#End Region

End Class
