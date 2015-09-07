Public Class DTO_Reserva

   Public Property ordenAsignada As String
   Public Property nroNegociacion As Nullable(Of Integer)
   Public Property estadoNegociacion As String
   Public Property fechaNegociacion As Nullable(Of DateTime) = Nothing
   Public Property fechaLimiteReserva As Nullable(Of DateTime) = Nothing
   Public Property clienteId As String
   Public Property clienteDesc As String
   Public Property vendedorId As String
   Public Property vendedorDesc As String
   Public Property observaciones As String
   Public Property fechaEstimadaIngreso As Nullable(Of DateTime) = Nothing
   Public Property fechaOfrecidaCliente As Nullable(Of DateTime) = Nothing
   Public Property probabilidad As Nullable(Of Integer)
   Public Property oportunidad As String

End Class