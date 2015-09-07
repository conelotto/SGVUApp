Public Class BE_Master_Table

    Private _det_FechaCreacion As DateTime = Date.Now()
    Private _det_FechaModificacion As DateTime = Date.Now()
    Private _str_MasterTable_Descripcion As String = String.Empty
    Private _bl_MasterTable_Estado As Boolean = False
    Private _int_MasterTable_Id As Integer = 0
    Private _str_MasterTable_Key As String = String.Empty
    Private _int_MasterTable_Orden As Integer = 0
    Private _str_MasterTable_Valor As String = String.Empty
    Private _str_UsuarioCreacion As String = String.Empty
    Private _str_UsuarioModificacion As String = String.Empty


#Region "Propiedades"

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

    Public Property str_MasterTable_Descripcion() As String
        Get
            Return _str_MasterTable_Descripcion
        End Get
        Set(ByVal value As String)
            _str_MasterTable_Descripcion = value
        End Set
    End Property

    Public Property bl_MasterTable_Estado() As Boolean
        Get
            Return _bl_MasterTable_Estado
        End Get
        Set(ByVal value As Boolean)
            _bl_MasterTable_Estado = value
        End Set
    End Property

    Public Property int_MasterTable_Id() As Integer
        Get
            Return _int_MasterTable_Id
        End Get
        Set(ByVal value As Integer)
            _int_MasterTable_Id = value
        End Set
    End Property

    Public Property str_MasterTable_Key() As String
        Get
            Return _str_MasterTable_Key
        End Get
        Set(ByVal value As String)
            _str_MasterTable_Key = value
        End Set
    End Property

    Public Property int_MasterTable_Orden() As Integer
        Get
            Return _int_MasterTable_Orden
        End Get
        Set(ByVal value As Integer)
            _int_MasterTable_Orden = value
        End Set
    End Property

    Public Property str_MasterTable_Valor() As String
        Get
            Return _str_MasterTable_Valor
        End Get
        Set(ByVal value As String)
            _str_MasterTable_Valor = value
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
