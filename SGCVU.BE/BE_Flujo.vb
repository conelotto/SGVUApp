Public Class BE_Flujo

#Region "Atributos"

   Private _int_IdActividad As Integer = 0
   Private _int_IdActividadSiguiente As Integer = 0

#End Region

#Region "Propiedades"

   Public Property int_IdActividad() As Integer
      Get
         Return _int_IdActividad
      End Get
      Set(ByVal value As Integer)
         _int_IdActividad = value
      End Set
   End Property

   Public Property int_IdActividadSiguiente() As Integer
      Get
         Return _int_IdActividadSiguiente
      End Get
      Set(ByVal value As Integer)
         _int_IdActividadSiguiente = value
      End Set
   End Property

#End Region

End Class
