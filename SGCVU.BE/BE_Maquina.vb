Public Class BE_Maquina

#Region "Atributos"

   Private _str_AgenteDesc As String = ""
   Private _str_AgenteId As String = ""
   Private _str_AnoFabricacionMaquina As String = ""
   Private _int_AntiguamientoMaquina As Integer = 0
   Private _str_ApoyoFabricanteIndicador As String = ""
   Public Property det_ArriboPuertoEstimadaFecha As Nullable(Of DateTime) = Nothing
   Public Property det_ArriboPuertoFecha As Nullable(Of DateTime) = Nothing
   Public Property det_AsignacionFecha As Nullable(Of DateTime) = Nothing
   Private _str_BillOfLanding As String = ""
   Private _str_BuqueDesc As String = ""
   Private _str_CentroCostoId As String = ""
   Private _str_ClienteFacturaId As String = ""
   Private _str_ClienteId As String = ""
   Private _str_CLPR As String = ""
   Private _str_CompaniaId As String = ""
   Private _str_ContratoNum As String = ""
   Private _dec_CostoMaquinaUSS As Decimal = 0
   Private _str_CuentaInventarioDBS As String = ""
   Public Property det_DisponibilidadEstimadaFecha As Nullable(Of DateTime) = Nothing
   Public Property det_DisponibilidadFecha As Nullable(Of DateTime) = Nothing
   Private _str_EliminadoRDA As String = ""
   Public det_EmbarqueEstimadaFecha As Nullable(Of DateTime) = Nothing
   Private _str_EntidadFinancieraId As String = ""
   Public Property det_EntregaTallerFecha As Nullable(Of DateTime) = Nothing
   Private _str_EstadoInventario As String = ""
   Private _str_EstadoRDA As String = ""
   Public Property det_EstadoRDAFecha As Nullable(Of DateTime) = Nothing
   Public Property det_FacturaClienteFecha As Nullable(Of DateTime) = Nothing
   Public Property det_FacturaFabricaFecha As Nullable(Of DateTime) = Nothing
   Private _str_FacturaFabricaNum As String = ""
   Private _dec_FacturaImporte As Decimal = 0
   Private _str_FamiliaDesc As String = ""
   Private _str_FinanciamientoDesc As String = ""
   Private _str_FinanciamientoId As String = ""
   Public Property det_FinDescargaFecha As Nullable(Of DateTime) = Nothing
   Private _str_IncotermId As String = ""
   Public Property det_IngresoFisicoFESAEstimadaFecha As Nullable(Of DateTime) = Nothing
   Public Property det_IngresoFisicoFESAFecha As Nullable(Of DateTime) = Nothing
   Public Property det_LevanteAduaneroFecha As Nullable(Of DateTime) = Nothing
   Private _str_MarcaDesc As String = ""
   Private _str_MarcaId As String = ""
   Private _str_ModeloProductoDesc As String = ""
   Private _str_ModeloProductoId As String = ""
   Private _str_ModeloRDA As String = ""
   Private _str_MotorSerie As String = ""
   Private _str_Observaciones As String = ""
   Private _str_OficinaVentaFacturaCRMDesc As String = ""
   Private _str_OficinaVentaFacturaCRMId As String = ""
   Private _str_OportunidadNum As String = ""
   Private _str_OrdenAsignada As String = ""
   Private _str_OrdenAsignadaNumCRM As String = ""
   Public Property det_OrdenFabricaFecha As Nullable(Of DateTime) = Nothing
   Private _str_PedidoId As String = ""
   Private _int_PosicionId As Integer = 0
   Public Property det_PreEntregaEstimadaFecha As Nullable(Of DateTime) = Nothing
   Private _str_PuertoEntradaDesc As String = ""
   Private _str_PuertoSalidaDesc As String = ""
   Public Property det_RecepcionForwarderFecha As Nullable(Of DateTime) = Nothing
   Private _str_RegimenImportacionMaquina As String = ""
   Public Property det_SalidaFabricaEstimadaFecha As Nullable(Of DateTime) = Nothing
   Public Property det_SalidaFabricaFecha As Nullable(Of DateTime) = Nothing
   Public Property det_SalidaFecha As Nullable(Of DateTime) = Nothing
   Private _int_Semaforo As Integer = 0
   Private _str_SerieMaquina As String = ""
   Private _str_StoreId As String = ""
   Private _int_SUNNUM As Integer = 0
   Private _int_SUNPRE As Integer = 0
   Private _str_SUNTIP As String = ""
   Private _str_UbicacionAgrupacionDesc As String = ""
   Private _str_UbicacionDesc As String = ""
   Private _str_UbicacionId As String = ""
   Private _dec_ValorVentaMaquinaCRM As Decimal = 0
   Private _str_VendedorId As String = ""

   Public Property str_Version As String = ""
   Public Property str_Proyecto As String = ""
   Public Property str_Proceso As String = ""
   Public Property str_ClienteDesc As String = ""
   Public Property str_SolicitoLevante As String = ""
   Public Property str_TieneEmparejamiento As String = ""
   Public Property str_VendedorDesc As String = ""
   Public Property str_EstadoMaquina As String = ""
   Public Property str_Procedencia As String = ""
   Public Property det_EntradaUbicacionFecha As Nullable(Of DateTime) = Nothing
   Public Property det_EnvioDesaduanarFecha As Nullable(Of DateTime) = Nothing
   Public Property det_OfrecidaClienteFecha As Nullable(Of DateTime) = Nothing
   Public Property str_Sucursal As String = ""
   Public Property str_DescripcionSucursal As String = ""
   Public Property str_Gerencia As String = ""
   Public Property str_OrdenPrincipal As String = ""
    Public Property int_ExpedienteId As Integer = 0

   Public Property str_DescripcionCuenta As String = String.Empty
   Public Property int_NoTieneNroorden As Integer = 0
   Public Property str_Ritmo5Indicador As String = String.Empty
   Public Property str_BonoRptoIndicador As String = String.Empty
   Public Property int_Ritmo5Cant As Integer = 0
   Public Property dec_Ritmo5Monto As Decimal = 0
   Public Property dec_BonoRptoMonto As Decimal = 0

   Public Property str_Ritmo5Tipo As String = String.Empty
   Public Property int_IdLineaVenta As Integer = 0
   Public Property str_CargoFirma As String = String.Empty
   Public Property str_IdCuenta As String = String.Empty
   Public Property str_NombreFirma As String = String.Empty
   Public Property str_TipoProducto As String = ""
    Public Property str_NroCAT As String = ""
   Public Property str_Division As String = ""
   Public Property str_DivisionDesc As String = ""
   Public Property str_TipoEmbarque As String = ""
   Public Property str_UnidadFreightForwarder As String = ""
   Public Property str_NroDocEmbarque As String = ""
   Public Property str_TipoDespacho As String = ""
   Public Property str_PolizaImportacion As String = ""
   Public Property str_Endose As String = ""
   Public Property str_TransportistaId As String = ""
   Public Property str_TransportistaDesc As String = ""
   Public Property str_PaisOrigenId As String = ""
   Public Property str_PaisOrigenDesc As String = ""
   Public Property str_MetrosCubicos As String = ""
   Public Property str_Prestamo As String = ""
   Public Property det_SalidaTallerFecha As Nullable(Of DateTime) = Nothing
   Public Property str_Bahia As String = ""
   Public Property det_FechaActualCambio As Nullable(Of DateTime) = Nothing
   Public Property str_ClienteFacturaDesc As String = ""
   Public Property dec_Horometro As Nullable(Of Decimal) = Nothing
   Public Property det_HorometroUltimaLecturaFecha As Nullable(Of DateTime) = Nothing
   Public Property str_IndicadorNPI As String = ""
   Public Property str_UbicacionDT As String = ""
   Public Property str_MotorArreglo As String = ""
   Public Property str_MotorMarca As String = ""
   Public Property str_MotorModelo As String = ""
    Public Property str_ClienteFacturaDescas As String
    Public Property byte_ImagenFirma As Byte()
    Public Property int_ClaseId As Integer
    Public Property int_BeneficioId As Integer = 0
#End Region

#Region "Propiedades"

   Public Property str_AgenteDesc() As String
      Get
         Return _str_AgenteDesc
      End Get
      Set(ByVal value As String)
         _str_AgenteDesc = value
      End Set
   End Property

   Public Property str_AgenteId() As String
      Get
         Return _str_AgenteId
      End Get
      Set(ByVal value As String)
         _str_AgenteId = value
      End Set
   End Property

   Public Property str_AnoFabricacionMaquina() As String
      Get
         Return _str_AnoFabricacionMaquina
      End Get
      Set(ByVal value As String)
         _str_AnoFabricacionMaquina = value
      End Set
   End Property

   Public Property int_AntiguamientoMaquina() As Integer
      Get
         Return _int_AntiguamientoMaquina
      End Get
      Set(ByVal value As Integer)
         _int_AntiguamientoMaquina = value
      End Set
   End Property

   Public Property str_ApoyoFabricanteIndicador() As String
      Get
         Return _str_ApoyoFabricanteIndicador
      End Get
      Set(ByVal value As String)
         _str_ApoyoFabricanteIndicador = value
      End Set
   End Property

   Public Property str_BillOfLanding() As String
      Get
         Return _str_BillOfLanding
      End Get
      Set(ByVal value As String)
         _str_BillOfLanding = value
      End Set
   End Property

   Public Property str_BuqueDesc() As String
      Get
         Return _str_BuqueDesc
      End Get
      Set(ByVal value As String)
         _str_BuqueDesc = value
      End Set
   End Property

   Public Property str_CentroCostoId() As String
      Get
         Return _str_CentroCostoId
      End Get
      Set(ByVal value As String)
         _str_CentroCostoId = value
      End Set
   End Property

   Public Property str_ClienteFacturaId() As String
      Get
         Return _str_ClienteFacturaId
      End Get
      Set(ByVal value As String)
         _str_ClienteFacturaId = value
      End Set
   End Property

   Public Property str_ClienteId() As String
      Get
         Return _str_ClienteId
      End Get
      Set(ByVal value As String)
         _str_ClienteId = value
      End Set
   End Property

   Public Property str_CLPR() As String
      Get
         Return _str_CLPR
      End Get
      Set(ByVal value As String)
         _str_CLPR = value
      End Set
   End Property

   Public Property str_CompaniaId() As String
      Get
         Return _str_CompaniaId
      End Get
      Set(ByVal value As String)
         _str_CompaniaId = value
      End Set
   End Property

   Public Property str_ContratoNum() As String
      Get
         Return _str_ContratoNum
      End Get
      Set(ByVal value As String)
         _str_ContratoNum = value
      End Set
   End Property

   Public Property dec_CostoMaquinaUSS() As Decimal
      Get
         Return _dec_CostoMaquinaUSS
      End Get
      Set(ByVal value As Decimal)
         _dec_CostoMaquinaUSS = value
      End Set
   End Property

   Public Property str_CuentaInventarioDBS() As String
      Get
         Return _str_CuentaInventarioDBS
      End Get
      Set(ByVal value As String)
         _str_CuentaInventarioDBS = value
      End Set
   End Property

   Public Property str_EliminadoRDA() As String
      Get
         Return _str_EliminadoRDA
      End Get
      Set(ByVal value As String)
         _str_EliminadoRDA = value
      End Set
   End Property

   Public Property str_EntidadFinancieraId() As String
      Get
         Return _str_EntidadFinancieraId
      End Get
      Set(ByVal value As String)
         _str_EntidadFinancieraId = value
      End Set
   End Property

   Public Property str_EstadoInventario() As String
      Get
         Return _str_EstadoInventario
      End Get
      Set(ByVal value As String)
         _str_EstadoInventario = value
      End Set
   End Property

   Public Property str_EstadoRDA() As String
      Get
         Return _str_EstadoRDA
      End Get
      Set(ByVal value As String)
         _str_EstadoRDA = value
      End Set
   End Property

   Public Property str_FacturaFabricaNum() As String
      Get
         Return _str_FacturaFabricaNum
      End Get
      Set(ByVal value As String)
         _str_FacturaFabricaNum = value
      End Set
   End Property

   Public Property dec_FacturaImporte() As Decimal
      Get
         Return _dec_FacturaImporte
      End Get
      Set(ByVal value As Decimal)
         _dec_FacturaImporte = value
      End Set
   End Property

   Public Property str_FamiliaDesc() As String
      Get
         Return _str_FamiliaDesc
      End Get
      Set(ByVal value As String)
         _str_FamiliaDesc = value
      End Set
   End Property

   Public Property str_FinanciamientoDesc() As String
      Get
         Return _str_FinanciamientoDesc
      End Get
      Set(ByVal value As String)
         _str_FinanciamientoDesc = value
      End Set
   End Property

   Public Property str_FinanciamientoId() As String
      Get
         Return _str_FinanciamientoId
      End Get
      Set(ByVal value As String)
         _str_FinanciamientoId = value
      End Set
   End Property

   Public Property str_IncotermId() As String
      Get
         Return _str_IncotermId
      End Get
      Set(ByVal value As String)
         _str_IncotermId = value
      End Set
   End Property

   Public Property str_MarcaDesc() As String
      Get
         Return _str_MarcaDesc
      End Get
      Set(ByVal value As String)
         _str_MarcaDesc = value
      End Set
   End Property

   Public Property str_MarcaId() As String
      Get
         Return _str_MarcaId
      End Get
      Set(ByVal value As String)
         _str_MarcaId = value
      End Set
   End Property

   Public Property str_ModeloProductoDesc() As String
      Get
         Return _str_ModeloProductoDesc
      End Get
      Set(ByVal value As String)
         _str_ModeloProductoDesc = value
      End Set
   End Property

   Public Property str_ModeloProductoId() As String
      Get
         Return _str_ModeloProductoId
      End Get
      Set(ByVal value As String)
         _str_ModeloProductoId = value
      End Set
   End Property

   Public Property str_ModeloRDA() As String
      Get
         Return _str_ModeloRDA
      End Get
      Set(ByVal value As String)
         _str_ModeloRDA = value
      End Set
   End Property

   Public Property str_MotorSerie() As String
      Get
         Return _str_MotorSerie
      End Get
      Set(ByVal value As String)
         _str_MotorSerie = value
      End Set
   End Property

   Public Property str_Observaciones() As String
      Get
         Return _str_Observaciones
      End Get
      Set(ByVal value As String)
         _str_Observaciones = value
      End Set
   End Property

   Public Property str_OficinaVentaFacturaCRMDesc() As String
      Get
         Return _str_OficinaVentaFacturaCRMDesc
      End Get
      Set(ByVal value As String)
         _str_OficinaVentaFacturaCRMDesc = value
      End Set
   End Property

   Public Property str_OficinaVentaFacturaCRMId() As String
      Get
         Return _str_OficinaVentaFacturaCRMId
      End Get
      Set(ByVal value As String)
         _str_OficinaVentaFacturaCRMId = value
      End Set
   End Property

   Public Property str_OportunidadNum() As String
      Get
         Return _str_OportunidadNum
      End Get
      Set(ByVal value As String)
         _str_OportunidadNum = value
      End Set
   End Property

   Public Property str_OrdenAsignada() As String
      Get
         Return _str_OrdenAsignada
      End Get
      Set(ByVal value As String)
         _str_OrdenAsignada = value
      End Set
   End Property

   Public Property str_OrdenAsignadaNumCRM() As String
      Get
         Return _str_OrdenAsignadaNumCRM
      End Get
      Set(ByVal value As String)
         _str_OrdenAsignadaNumCRM = value
      End Set
   End Property

   Public Property str_PedidoId() As String
      Get
         Return _str_PedidoId
      End Get
      Set(ByVal value As String)
         _str_PedidoId = value
      End Set
   End Property

   Public Property int_PosicionId() As Integer
      Get
         Return _int_PosicionId
      End Get
      Set(ByVal value As Integer)
         _int_PosicionId = value
      End Set
   End Property

   Public Property str_PuertoEntradaDesc() As String
      Get
         Return _str_PuertoEntradaDesc
      End Get
      Set(ByVal value As String)
         _str_PuertoEntradaDesc = value
      End Set
   End Property

   Public Property str_PuertoSalidaDesc() As String
      Get
         Return _str_PuertoSalidaDesc
      End Get
      Set(ByVal value As String)
         _str_PuertoSalidaDesc = value
      End Set
   End Property

   Public Property str_RegimenImportacionMaquina() As String
      Get
         Return _str_RegimenImportacionMaquina
      End Get
      Set(ByVal value As String)
         _str_RegimenImportacionMaquina = value
      End Set
   End Property

   Public Property int_Semaforo() As Integer
      Get
         Return _int_Semaforo
      End Get
      Set(ByVal value As Integer)
         _int_Semaforo = value
      End Set
   End Property

   Public Property str_SerieMaquina() As String
      Get
         Return _str_SerieMaquina
      End Get
      Set(ByVal value As String)
         _str_SerieMaquina = value
      End Set
   End Property

   Public Property str_StoreId() As String
      Get
         Return _str_StoreId
      End Get
      Set(ByVal value As String)
         _str_StoreId = value
      End Set
   End Property

   Public Property int_SUNNUM() As Integer
      Get
         Return _int_SUNNUM
      End Get
      Set(ByVal value As Integer)
         _int_SUNNUM = value
      End Set
   End Property

   Public Property int_SUNPRE() As Integer
      Get
         Return _int_SUNPRE
      End Get
      Set(ByVal value As Integer)
         _int_SUNPRE = value
      End Set
   End Property

   Public Property str_SUNTIP() As String
      Get
         Return _str_SUNTIP
      End Get
      Set(ByVal value As String)
         _str_SUNTIP = value
      End Set
   End Property

   Public Property str_UbicacionAgrupacionDesc() As String
      Get
         Return _str_UbicacionAgrupacionDesc
      End Get
      Set(ByVal value As String)
         _str_UbicacionAgrupacionDesc = value
      End Set
   End Property

   Public Property str_UbicacionDesc() As String
      Get
         Return _str_UbicacionDesc
      End Get
      Set(ByVal value As String)
         _str_UbicacionDesc = value
      End Set
   End Property

   Public Property str_UbicacionId() As String
      Get
         Return _str_UbicacionId
      End Get
      Set(ByVal value As String)
         _str_UbicacionId = value
      End Set
   End Property

   Public Property dec_ValorVentaMaquinaCRM() As Decimal
      Get
         Return _dec_ValorVentaMaquinaCRM
      End Get
      Set(ByVal value As Decimal)
         _dec_ValorVentaMaquinaCRM = value
      End Set
   End Property

   Public Property str_VendedorId() As String
      Get
         Return _str_VendedorId
      End Get
      Set(ByVal value As String)
         _str_VendedorId = value
      End Set
   End Property

#End Region

#Region "Campos Auxiliares"
    Public Property bl_EsRitmo5 As Boolean = False
    Public Property bl_EsBonoRpto As Boolean = False
    Public Property str_FechaFactura As String = String.Empty
    Public Property str_XmlSap As String = ""
#End Region
End Class
