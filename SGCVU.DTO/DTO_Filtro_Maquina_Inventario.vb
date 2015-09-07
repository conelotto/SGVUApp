Public Class DTO_Filtro_Maquina_Inventario

   Public Property cuenta As String
   Public Property marca As String
   Public Property modelo As String
   Public Property orden As String
   Public Property proyecto As String
   Public Property cliente As String
   Public Property vendedor As String
   Public Property proceso As String
   Public Property fechaEstIngDesde As String
   Public Property fechaEstIngHasta As String
   Public Property semaforo As List(Of String) = New List(Of String)
   Public Property estado As List(Of String) = New List(Of String)
   Public Property ubicacion As String

   Public Sub sb_prepararDatos()
      If Not cuenta Is Nothing Then cuenta = cuenta.Trim()
      If Not marca Is Nothing Then marca = marca.Trim()
      If Not modelo Is Nothing Then modelo = modelo.Trim()
      If Not orden Is Nothing Then orden = orden.Trim()
      If Not proyecto Is Nothing Then proyecto = proyecto.Trim()
      If Not cliente Is Nothing Then cliente = cliente.Trim()
      If Not vendedor Is Nothing Then vendedor = vendedor.Trim()
      If Not proceso Is Nothing Then proceso = proceso.Trim()
      If Not fechaEstIngDesde Is Nothing Then fechaEstIngDesde = fechaEstIngDesde.Trim()
      If Not fechaEstIngHasta Is Nothing Then fechaEstIngHasta = fechaEstIngHasta.Trim()
      If Not ubicacion Is Nothing Then ubicacion = ubicacion.Trim()
   End Sub

End Class