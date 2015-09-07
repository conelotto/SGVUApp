Friend Interface IConsultarRDA

   Function ObtenerRDAsAsignadosFechaHora(ByVal fechaInicial As Nullable(Of DateTime), ByVal fechaFinal As DateTime) As IList(Of ZRda)
   Function ObtenerRDAAsignadoOrden(ByVal orden As String) As ZRda

End Interface