Public Class ZRda
   Property OrgFact As String
   Property Status As String
   Property Fecha As Nullable(Of DateTime)
   Property NroMotor As String
   Property IdPedido As String
   Property OfiVentasFac As String
   Property OfiVentasFacTxt As String
   Property Oportunidad As String
   Property ApoyoFab As String
   Property Eliminado As String
   Property FechaCre As String
   Property HoraCre As String
   Property FechaMod As String
   Property HoraMod As String

   Property Posicion As ZPosicion
   Property AsigEquipo As ZAsigEquipo
   Property Implicados As IList(Of ZImplicado) = New List(Of ZImplicado)
   Property Precios As IList(Of ZDetPrecio) = New List(Of ZDetPrecio)
   Property Beneficios As IList(Of ZBeneficio) = New List(Of ZBeneficio)

End Class

Public Class ZPosicion
   Property IdPosicion As Integer
   Property FormaPago As String
   Property FormaPagoTxt As String
End Class

Public Class ZImplicado
   Property IdExtSocNeg As String
   Property IdSapSocNeg As String
   Property Funcion As String
   Property FuncionTxt As String
   Property Nombre As String
End Class

Public Class ZAsigEquipo
   Property OrdAsignada As String
   Property CodDbs As String
   Property CtaInventario As String
   Property Serie As String
   Property AFabricacion As String
   Property Numero As String
End Class

Public Class ZDetPrecio
   Property Valor As Decimal
End Class

Public Class ZBeneficio
   Property Codigo As String
   Property Descripcion As String
   Property Cantidad As Integer
End Class