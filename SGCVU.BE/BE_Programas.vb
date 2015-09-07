Public Class BE_Programas

#Region "Atributos"

    Private _int_ProgramasId As Integer = 0
    Private _str_IdProgramaCAT As String = String.Empty
    Private _str_DescPrograma As String = String.Empty
    Private _det_FechaInicio As New System.Nullable(Of DateTime)()
    Private _det_FechaFin As New System.Nullable(Of DateTime)()
    Private _det_FechaCreacion As New System.Nullable(Of DateTime)()
    Private _str_UsuarioCreacion As String = String.Empty
    Private _det_FechaModificacion As New System.Nullable(Of DateTime)()
    Private _str_UsuarioModificacion As String = String.Empty
    Private _str_RolFlujoDesc As String = String.Empty
    Private _bl_ProgramaStatus As Boolean = False
    Private _int_RolFlujoId As Integer = 0

#End Region

#Region "Propiedades"

    Public Property int_ProgramasId() As Integer
        Get
            Return _int_ProgramasId
        End Get
        Set(ByVal value As Integer)
            _int_ProgramasId = value
        End Set
    End Property

    Public Property str_IdProgramaCAT() As String
        Get
            Return _str_IdProgramaCAT
        End Get
        Set(ByVal value As String)
            _str_IdProgramaCAT = value
        End Set
    End Property

    Public Property str_DescPrograma() As String
        Get
            Return _str_DescPrograma
        End Get
        Set(ByVal value As String)
            _str_DescPrograma = value
        End Set
    End Property

    Public Property det_FechaInicio() As System.Nullable(Of DateTime)
        Get
            Return _det_FechaInicio
        End Get
        Set(ByVal value As System.Nullable(Of DateTime))
            _det_FechaInicio = value
        End Set
    End Property

    Public Property det_FechaFin() As System.Nullable(Of DateTime)
        Get
            Return _det_FechaFin
        End Get
        Set(ByVal value As System.Nullable(Of DateTime))
            _det_FechaFin = value
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

    Public Property str_UsuarioCreacion() As String
        Get
            Return _str_UsuarioCreacion
        End Get
        Set(ByVal value As String)
            _str_UsuarioCreacion = value
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

    Public Property str_RolFlujoDesc() As String
        Get
            Return _str_RolFlujoDesc
        End Get
        Set(ByVal value As String)
            _str_RolFlujoDesc = value
        End Set
    End Property

    Public Property bl_ProgramaStatus() As Boolean
        Get
            Return _bl_ProgramaStatus
        End Get
        Set(ByVal value As Boolean)
            _bl_ProgramaStatus = value
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

#End Region

End Class
