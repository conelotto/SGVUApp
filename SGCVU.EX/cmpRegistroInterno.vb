Imports System.IO
Imports System.Text

Public Class cmpRegistroInterno

   Private Shared rutaCarpetaEvent As String = AppDomain.CurrentDomain.BaseDirectory + "Log\Event\"

   Public Shared Sub RegistrarLogInterno(ByVal tipo As String, ByVal mensajeLog As String)
      If Not Directory.Exists(rutaCarpetaEvent) Then
         Directory.CreateDirectory(rutaCarpetaEvent)
      End If
      File.AppendAllText(rutaCarpetaEvent + "\Log" + DateTime.Now.ToString("yyyyMMdd") + ".txt", tipo + " -> " + Date.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + " :: " + mensajeLog + Environment.NewLine, Encoding.UTF8)
   End Sub

End Class