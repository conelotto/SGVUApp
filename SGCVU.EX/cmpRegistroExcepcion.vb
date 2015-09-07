Imports Newtonsoft.Json
Imports System.IO


Public Class cmpRegistroExcepcion

   Private rutaCarpetaError As String
   Private nombreArchivo As String
   Private datos As DatosExcepcion

   Public Sub New(ByVal pi_datos As DatosExcepcion)
      datos = pi_datos
      rutaCarpetaError = AppDomain.CurrentDomain.BaseDirectory + "Log\Error\"
      nombreArchivo = pi_datos.fecha.Ticks.ToString() + pi_datos.ip.Replace(":", "").Replace(".", "") + ".txt"
   End Sub

   Public Sub GuardarLog()
      Dim liDatosExcepcion = New List(Of DatosExcepcion)
      Dim cantidad As Integer = 0
      Try
         liDatosExcepcion.Add(datos)
         Dim dalExcepcion As dalRepositorioExcepcion = New dalRepositorioExcepcion()
         cantidad = dalExcepcion.Guardar(liDatosExcepcion)
         cmpRegistroInterno.RegistrarLogInterno("INFO", String.Format("Se registró 1 error(log) en la Base de datos"))
      Catch ex As Exception
         If cantidad = 0 Then
            Dim jsonDatos As String = JsonConvert.SerializeObject(datos, Formatting.Indented)
            GuardarEnArchivo(jsonDatos)
         End If
         cmpRegistroInterno.RegistrarLogInterno("ERROR", ex.Message + " -> " + ex.StackTrace)
      End Try
   End Sub

   Private Sub GuardarEnArchivo(ByVal pi_datos As String)
      Dim escritor As StreamWriter = Nothing
      Try
         If Not Directory.Exists(rutaCarpetaError) Then
            Directory.CreateDirectory(rutaCarpetaError)
         End If

         escritor = New StreamWriter(rutaCarpetaError + nombreArchivo)
         escritor.WriteLine(pi_datos)
         escritor.Close()
      Catch ex As Exception
         If escritor IsNot Nothing Then escritor.Close()
      End Try
   End Sub

End Class