Public Class BE_RolFlujo

#Region "Atributos"

   Private _int_IdRolFlujo As Integer = 0
   Private _str_RolFlujoDesc As String = String.Empty

#End Region

#Region "Propiedades"

   Public Property int_IdRolFlujo() As Integer
      Get
         Return _int_IdRolFlujo
      End Get
      Set(ByVal value As Integer)
         _int_IdRolFlujo = value
      End Set
   End Property

   Public Property str_RolFlujoDesc() As String
      Get
         Return _str_RolFlujoDesc
      End Get
      Set(ByVal value As String)
         _str_RolFlujoDesc = value
      End Set
   End Property

#End Region

End Class
