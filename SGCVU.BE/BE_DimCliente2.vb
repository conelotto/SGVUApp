Public Class BE_DimCliente2

#Region "Atributos"

    Private _str_COD_AGRUPACION As String = String.Empty
    Private _str_COD_CIC As String = String.Empty
    Private _str_COD_CLIENTE As String = String.Empty
    Private _str_COD_GIRO_NEGOCIO As String = String.Empty
    Private _str_COD_MERCADO As String = String.Empty
    Private _str_COD_RESP_CLIENTE As String = String.Empty
    Private _str_COD_SERVICIO_PREMIUM As String = String.Empty
    Private _str_DESC_AGRUPACION As String = String.Empty
    Private _str_DESC_CIC As String = String.Empty
    Private _str_DESC_CLIENTE As String = String.Empty
    Private _str_DESC_DEPARTAMENTO_CLIENTE As String = String.Empty
    Private _str_DESC_ESTADO_CLIENTE As String = String.Empty
    Private _str_DESC_GIRO_NEGOCIO As String = String.Empty
    Private _str_DESC_MERCADO As String = String.Empty
    Private _str_DESC_MOTIVO_DESACTIVACION As String = String.Empty
    Private _str_DESC_RESP_CLIENTE As String = String.Empty
    Private _str_DESC_TIPO_CLIENTE As String = String.Empty
    Private _str_DESC_TIPO_PERSONA As String = String.Empty
    Private _det_FEC_ACTUALIZACION As DateTime = Date.Now()
    Private _det_FEC_CREACION As DateTime = Date.Now()
    Private _det_FEC_REGISTRO_CLIENTE As DateTime = Date.Now()
    Private _str_ID_CLIENTE As String = String.Empty
    Private _str_NUM_IDENTIFICACION As String = String.Empty
    Private _int_NUM_LIMITE_CREDITO_REP As Integer = 0
    Private _int_NUM_LIMITE_CREDITO_SER As Integer = 0
    Private _int_SK_CLIENTE As Integer = 0

#End Region

#Region "Propiedades"

    Public Property str_COD_AGRUPACION() As String
        Get
            Return _str_COD_AGRUPACION
        End Get
        Set(ByVal value As String)
            _str_COD_AGRUPACION = value
        End Set
    End Property

    Public Property str_COD_CIC() As String
        Get
            Return _str_COD_CIC
        End Get
        Set(ByVal value As String)
            _str_COD_CIC = value
        End Set
    End Property

    Public Property str_COD_CLIENTE() As String
        Get
            Return _str_COD_CLIENTE
        End Get
        Set(ByVal value As String)
            _str_COD_CLIENTE = value
        End Set
    End Property

    Public Property str_COD_GIRO_NEGOCIO() As String
        Get
            Return _str_COD_GIRO_NEGOCIO
        End Get
        Set(ByVal value As String)
            _str_COD_GIRO_NEGOCIO = value
        End Set
    End Property

    Public Property str_COD_MERCADO() As String
        Get
            Return _str_COD_MERCADO
        End Get
        Set(ByVal value As String)
            _str_COD_MERCADO = value
        End Set
    End Property

    Public Property str_COD_RESP_CLIENTE() As String
        Get
            Return _str_COD_RESP_CLIENTE
        End Get
        Set(ByVal value As String)
            _str_COD_RESP_CLIENTE = value
        End Set
    End Property

    Public Property str_COD_SERVICIO_PREMIUM() As String
        Get
            Return _str_COD_SERVICIO_PREMIUM
        End Get
        Set(ByVal value As String)
            _str_COD_SERVICIO_PREMIUM = value
        End Set
    End Property

    Public Property str_DESC_AGRUPACION() As String
        Get
            Return _str_DESC_AGRUPACION
        End Get
        Set(ByVal value As String)
            _str_DESC_AGRUPACION = value
        End Set
    End Property

    Public Property str_DESC_CIC() As String
        Get
            Return _str_DESC_CIC
        End Get
        Set(ByVal value As String)
            _str_DESC_CIC = value
        End Set
    End Property

    Public Property str_DESC_CLIENTE() As String
        Get
            Return _str_DESC_CLIENTE
        End Get
        Set(ByVal value As String)
            _str_DESC_CLIENTE = value
        End Set
    End Property

    Public Property str_DESC_DEPARTAMENTO_CLIENTE() As String
        Get
            Return _str_DESC_DEPARTAMENTO_CLIENTE
        End Get
        Set(ByVal value As String)
            _str_DESC_DEPARTAMENTO_CLIENTE = value
        End Set
    End Property

    Public Property str_DESC_ESTADO_CLIENTE() As String
        Get
            Return _str_DESC_ESTADO_CLIENTE
        End Get
        Set(ByVal value As String)
            _str_DESC_ESTADO_CLIENTE = value
        End Set
    End Property

    Public Property str_DESC_GIRO_NEGOCIO() As String
        Get
            Return _str_DESC_GIRO_NEGOCIO
        End Get
        Set(ByVal value As String)
            _str_DESC_GIRO_NEGOCIO = value
        End Set
    End Property

    Public Property str_DESC_MERCADO() As String
        Get
            Return _str_DESC_MERCADO
        End Get
        Set(ByVal value As String)
            _str_DESC_MERCADO = value
        End Set
    End Property

    Public Property str_DESC_MOTIVO_DESACTIVACION() As String
        Get
            Return _str_DESC_MOTIVO_DESACTIVACION
        End Get
        Set(ByVal value As String)
            _str_DESC_MOTIVO_DESACTIVACION = value
        End Set
    End Property

    Public Property str_DESC_RESP_CLIENTE() As String
        Get
            Return _str_DESC_RESP_CLIENTE
        End Get
        Set(ByVal value As String)
            _str_DESC_RESP_CLIENTE = value
        End Set
    End Property

    Public Property str_DESC_TIPO_CLIENTE() As String
        Get
            Return _str_DESC_TIPO_CLIENTE
        End Get
        Set(ByVal value As String)
            _str_DESC_TIPO_CLIENTE = value
        End Set
    End Property

    Public Property str_DESC_TIPO_PERSONA() As String
        Get
            Return _str_DESC_TIPO_PERSONA
        End Get
        Set(ByVal value As String)
            _str_DESC_TIPO_PERSONA = value
        End Set
    End Property

    Public Property det_FEC_ACTUALIZACION() As DateTime
        Get
            Return _det_FEC_ACTUALIZACION
        End Get
        Set(ByVal value As DateTime)
            _det_FEC_ACTUALIZACION = value
        End Set
    End Property

    Public Property det_FEC_CREACION() As DateTime
        Get
            Return _det_FEC_CREACION
        End Get
        Set(ByVal value As DateTime)
            _det_FEC_CREACION = value
        End Set
    End Property

    Public Property det_FEC_REGISTRO_CLIENTE() As DateTime
        Get
            Return _det_FEC_REGISTRO_CLIENTE
        End Get
        Set(ByVal value As DateTime)
            _det_FEC_REGISTRO_CLIENTE = value
        End Set
    End Property

    Public Property str_ID_CLIENTE() As String
        Get
            Return _str_ID_CLIENTE
        End Get
        Set(ByVal value As String)
            _str_ID_CLIENTE = value
        End Set
    End Property

    Public Property str_NUM_IDENTIFICACION() As String
        Get
            Return _str_NUM_IDENTIFICACION
        End Get
        Set(ByVal value As String)
            _str_NUM_IDENTIFICACION = value
        End Set
    End Property

    Public Property int_NUM_LIMITE_CREDITO_REP() As Integer
        Get
            Return _int_NUM_LIMITE_CREDITO_REP
        End Get
        Set(ByVal value As Integer)
            _int_NUM_LIMITE_CREDITO_REP = value
        End Set
    End Property

    Public Property int_NUM_LIMITE_CREDITO_SER() As Integer
        Get
            Return _int_NUM_LIMITE_CREDITO_SER
        End Get
        Set(ByVal value As Integer)
            _int_NUM_LIMITE_CREDITO_SER = value
        End Set
    End Property

    Public Property int_SK_CLIENTE() As Integer
        Get
            Return _int_SK_CLIENTE
        End Get
        Set(ByVal value As Integer)
            _int_SK_CLIENTE = value
        End Set
    End Property

#End Region

End Class
