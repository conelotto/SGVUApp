Public Class DTO_RptaPeticion

   Public Property success As Boolean
   Public Property data As Object
   Public Property msg As String
   Public Property sesionValida As Boolean

   Public Sub New()
      success = True
      sesionValida = True
   End Sub

End Class