Public Class DTO_CuentaInventario

    Public Property strCodigo As String
    Public Property strDescripcion As String
    Public Property intLinea As String

    Public Sub PrepareData()

        If Not strCodigo Is Nothing Then strCodigo = strCodigo.Trim()
        If Not strDescripcion Is Nothing Then strDescripcion = strDescripcion.Trim()
        If Not intLinea Is Nothing Then intLinea = intLinea.Trim

    End Sub

End Class
