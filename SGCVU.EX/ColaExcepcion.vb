Public Class ColaExcepcion

   Public rutaArchivos As String()
   Public contenidoArchivos As String()

   Public Sub New(ByVal cantidadArchivos As Integer)
      Me.rutaArchivos = New String(cantidadArchivos - 1) {}
      Me.contenidoArchivos = New String(cantidadArchivos - 1) {}
   End Sub

End Class