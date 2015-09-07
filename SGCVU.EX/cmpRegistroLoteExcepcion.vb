Imports System.IO
Imports Newtonsoft.Json

Public Class cmpRegistroLoteExcepcion

   Private rutaCarpetaError As String

   Public Sub New(ByVal pi_rutaCarpeta As String)
      rutaCarpetaError = pi_rutaCarpeta + "Log\Error\"
   End Sub

   Public Sub Registrar()
      Dim colaEx As ColaExcepcion = ObtenerArchivos()
      'Código para insertar en la base de datos
      Dim liDatosExcepcion = New List(Of DatosExcepcion)
      For fila As Integer = 0 To colaEx.contenidoArchivos.Length - 1
         Try
            liDatosExcepcion.Add(JsonConvert.DeserializeObject(Of DatosExcepcion)(colaEx.contenidoArchivos(fila)))
         Catch ex As Exception
            cmpRegistroInterno.RegistrarLogInterno("ERROR", ex.Message)
         End Try
      Next
      If liDatosExcepcion.Count > 0 Then
         Dim dalExcepcion As dalRepositorioExcepcion = New dalRepositorioExcepcion()
         Dim registros = dalExcepcion.Guardar(liDatosExcepcion)
         EliminarArchivos(colaEx.rutaArchivos)
         cmpRegistroInterno.RegistrarLogInterno("INFO", String.Format("Se registraron {0} errores en la Base de datos", registros))
      End If
   End Sub

   Private Function ObtenerArchivos() As ColaExcepcion
      Dim log As ColaExcepcion = Nothing

      Dim archivos As String() = Directory.GetFiles(rutaCarpetaError)
      If archivos IsNot Nothing AndAlso archivos.Count() > 0 Then
         log = New ColaExcepcion(archivos.Count())

         Dim archivosFinal As String() = New String(archivos.Count() - 1) {}
         Dim datos As String() = New String(archivosFinal.Length - 1) {}

         For fila As Integer = 0 To log.rutaArchivos.Length - 1
            log.rutaArchivos(fila) = archivos(fila)
            log.contenidoArchivos(fila) = File.ReadAllText(archivos(fila))
         Next
      End If

      Return If((log IsNot Nothing), log, New ColaExcepcion(0))
   End Function

   Private Sub EliminarArchivos(ByVal archivos As String())
      For Each archivo As String In archivos
         File.Delete(archivo)
      Next
   End Sub

End Class