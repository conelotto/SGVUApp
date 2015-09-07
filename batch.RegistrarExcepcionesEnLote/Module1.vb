Imports SGCVU.EX
Imports System.Configuration

Module Module1

   Sub Main()
      Try
         Dim rutaCarpeta As String = ConfigurationManager.AppSettings("carpetaLogs").ToString()
         Dim registroLoteEx As cmpRegistroLoteExcepcion = New cmpRegistroLoteExcepcion(rutaCarpeta)
         registroLoteEx.Registrar()
      Catch ex As Exception
         cmpRegistroInterno.RegistrarLogInterno("ERROR", ex.Message + " -> " + ex.StackTrace)
      End Try
   End Sub

End Module