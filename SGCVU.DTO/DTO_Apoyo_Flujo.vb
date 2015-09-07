Public Class DTO_Apoyo_Flujo

    Public Property strNumeroOrden As String
    Public Property strNumeroSerie As String
    Public Property strCliente As String
    Public Property strModelo As String
    Public Property strPrograma As String
    Public Property strEstadoFlujo As Integer = 0
    Public Property strEstadoSolicitud As Integer = 0
    Public Property strEstadoFacturacion As String
    Public Property strLineaVenta As Integer = 0
    Public Property strUsuarioCuentaInventario As String

    Public Sub PrepareData()

        If Not strNumeroOrden Is Nothing Then strNumeroOrden = strNumeroOrden.Trim()
        If Not strNumeroSerie Is Nothing Then strNumeroSerie = strNumeroSerie.Trim()
        If Not strCliente Is Nothing Then strCliente = strCliente.Trim()
        If Not strModelo Is Nothing Then strModelo = strModelo.Trim()
        If Not strPrograma Is Nothing Then strPrograma = strPrograma.Trim()
        If strEstadoFlujo <> Nothing Then strEstadoFlujo = strEstadoFlujo
        If strEstadoSolicitud <> Nothing Then strEstadoSolicitud = strEstadoSolicitud
        If Not strEstadoFacturacion Is Nothing Then strEstadoFacturacion = strEstadoFacturacion.Trim()
        If strLineaVenta <> Nothing Then strLineaVenta = strLineaVenta
        If Not strUsuarioCuentaInventario Is Nothing Then strUsuarioCuentaInventario = strUsuarioCuentaInventario.Trim()

    End Sub
End Class
