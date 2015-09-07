Public Class DTO_InfoMaquinaSeguimientoImportacion

   Public Property FacturaFabricaNum As String
   Public Property IncotermId As String
   Public Property TipoEmbarque As String
   Public Property UnidadFreightForwarder As String
   Public Property PuertoSalidaDesc As String
   Public Property NroDocEmbarque As String
   Public Property BuqueDesc As String
   Public Property AgenteId As String
   Public Property AgenteDesc As String
   Public Property TipoDespacho As String
   Public Property PolizaImportacion As String
   Public Property RegimenImportacionMaquina As String
   Public Property Endose As String
   Public Property TransportistaId As String
   Public Property TransportistaDesc As String
   Public Property PaisOrigenId As String
   Public Property PaisOrigenDesc As String
   Public Property MetrosCubicos As String
   Public Property Prestamo As String
   Public Property ClienteId As String
   Public Property ClienteDesc As String

   Public Property OrdenFabricaFecha As Nullable(Of DateTime) = Nothing
   Public Property SalidaFabricaEstimadaFecha As Nullable(Of DateTime) = Nothing
   Public Property SalidaFabricaFecha As Nullable(Of DateTime) = Nothing
   Public Property FacturaFabricaFecha As Nullable(Of DateTime) = Nothing
   Public Property RecepcionForwarderFecha As Nullable(Of DateTime) = Nothing
   Public Property EmbarqueEstimadaFecha As Nullable(Of DateTime) = Nothing
   Public Property ArriboPuertoEstimadaFecha As Nullable(Of DateTime) = Nothing
   Public Property ArriboPuertoFecha As Nullable(Of DateTime) = Nothing
   Public Property FinDescargaFecha As Nullable(Of DateTime) = Nothing
   Public Property LevanteAduaneroFecha As Nullable(Of DateTime) = Nothing
   Public Property IngresoFisicoFESAEstimadaFecha As Nullable(Of DateTime) = Nothing
   Public Property IngresoFisicoFESAFecha As Nullable(Of DateTime) = Nothing
   Public Property EntregaTallerFecha As Nullable(Of DateTime) = Nothing
   Public Property SalidaTallerFecha As Nullable(Of DateTime) = Nothing

End Class