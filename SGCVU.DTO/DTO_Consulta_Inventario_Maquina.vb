Public Class DTO_Consulta_Inventario_Maquina

   Public Property TieneEmparejamiento As String = ""
   Public Property SolicitoLevante As String = ""
   Public Property OrdenAsignada As String = ""
   Public Property OrdenPrincipal As String = ""
   Public Property ModeloProductoDesc As String = ""
   Public Property MarcaDesc As String = ""
   Public Property Version As String = ""
   Public Property FamiliaDesc As String = ""
   Public Property AnoFabricacionMaquina As String = ""
   Public Property CuentaInventarioDBS As String = ""
   Public Property EstadoMaquina As String = ""
   Public Property Proyecto As String = ""
   Public Property Procedencia As String = ""
   Public Property IngresoFisicoFESAEstimadaFecha As Nullable(Of DateTime) = Nothing
   Public Property LTFchEstIngresoToday As Nullable(Of Integer) = Nothing
   Public Property DisponibilidadEstimadaFecha As Nullable(Of DateTime) = Nothing
   Public Property OfrecidaClienteFecha As Nullable(Of DateTime) = Nothing
   Public Property LTFchEstDispFchOfrec As Nullable(Of Integer) = Nothing
   Public Property Semaforo As Nullable(Of Integer) = Nothing
   Public Property AsignacionFecha As Nullable(Of DateTime) = Nothing
   Public Property LimiteReservaFecha As Nullable(Of DateTime) = Nothing
   Public Property PreEntregaEstimadaFecha As Nullable(Of DateTime) = Nothing
   Public Property EnvioDesaduanarFecha As Nullable(Of DateTime) = Nothing
   Public Property LevanteAduaneroFecha As Nullable(Of DateTime) = Nothing
   Public Property FacturacionFecha As Nullable(Of DateTime) = Nothing
   Public Property UbicacionDesc As String = ""
   Public Property Proceso As String = ""
   Public Property ClienteDesc As String = ""
   Public Property VendedorDesc As String = ""
   Public Property Sucursal As String = ""
   Public Property Gerencia As String = ""
   Public Property Observaciones As String = ""
   Public Property CostoMaquinaUSS As Nullable(Of Decimal) = Nothing

   Public Property DiasUbicacion As Nullable(Of Integer) = Nothing

End Class