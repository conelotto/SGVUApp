Public Class BE_Beneficio

    Public Property int_BeneficioId As Integer = 0
    Public Property str_CompaniaId As String = String.Empty
    Public Property int_ExpedienteId As Integer
    Public Property str_Ordenasignada As String
    Public Property str_PedidoId As String
    Public Property int_PosicionId As Integer
    Public Property int_ClaseId As Integer
    Public Property str_ClaseDesc As String
    Public Property str_BeneficioIdSapDEV As String = String.Empty
    Public Property str_BeneficioIdSapQAS As String = String.Empty
    Public Property str_BeneficioIdSapPRD As String = String.Empty
    Public Property str_BeneficioDesc As String = String.Empty
    Public Property str_NombreArchivo As String = String.Empty
    Public Property int_BeneficioCantidad As Integer = 0
    Public Property int_BeneficioMes As Integer = 0
    Public Property str_BeneficioCCU As String = String.Empty
    Public Property int_BeneficioHoras As Integer
    Public Property str_BeneficioObservacion As String = String.Empty
    Public Property date_BeneficioCreacionFecha As Date = Date.MinValue
    Public Property str_Sistema As String = String.Empty
    Public Property str_SAPCalculado As String = String.Empty
    Public Property int_TipoBusqueda As Integer = 0
    Public Property int_HojaInformativa As Integer = 0
    Public Property str_DescripcionTipoBusqueda As String = String.Empty
End Class
