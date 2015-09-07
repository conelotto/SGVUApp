Public Class DTO_Maquina
    Public Property Orden As String = String.Empty
    Public Property ExpedienteId As Integer = 0
    Public Property VendedorId As String = String.Empty
    Public Property VendedorDesc As String = String.Empty
    Public Property EntidadFinancieraId As String = String.Empty
    Public Property EntidadFinancieraDesc As String = String.Empty
    Public Property CuentaInventarioDBS As String = String.Empty
    Public Property DescripcionCuenta As String = String.Empty
    Public Property Sucursal As String = String.Empty
    Public Property DescripcionSucursal As String = String.Empty
    Public Property FinanciamientoId As String = String.Empty
    Public Property FamiliaDesc As String = String.Empty
    Public Property MarcaDesc As String = String.Empty
    Public Property ModeloProductoDesc As String = String.Empty
    Public Property SerieMaquina As String = String.Empty
    Public Property Ritmo5 As Integer = 0
    Public Property MontoRitmo5 As Decimal = 0
    Public Property TipoRitmo5 As String = String.Empty
    Public Property IdSapRitmo5 As String = String.Empty
    Public Property BonoRpto As String = String.Empty
    Public Property MontoBonoRpto As Decimal = 0
    Public Property Observacion As String = String.Empty
    Public Property EsFactura As Integer = 0
    Public Property SunTip As String = String.Empty
    Public Property SunPre As Integer = 0
    Public Property SunNum As Integer = 0
    Public Property IdSAP As String = String.Empty
    Public Property EsNuevo As Boolean = False
    Public Property EsBonoRpto As Integer = 0
    Public Property EsBonoRitmo5 As Integer = 0
    Public Property ClienteId As String = String.Empty
    Public Property ClienteDesc As String = String.Empty
    Public Property ClienteFacturaId As String = String.Empty
    Public Property ClienteFacturaDesc As String = String.Empty
    Public Property FechaFactura As String = String.Empty
    Public Property NoTieneNroOrden As Integer = 0
    Public Property Archivo As Object
    Public Property TotalRegistros As Integer = 0

End Class
