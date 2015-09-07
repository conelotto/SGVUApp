Imports System.Net
Imports System.Configuration

Friend Class ConsultarWS_Base

   Protected credenciales As NetworkCredential

   Public Sub New()
      Dim usuario As String = ConfigurationManager.AppSettings("usuSWSap").ToString()
      Dim pass As String = ConfigurationManager.AppSettings("passSWSap").ToString()
      credenciales = New NetworkCredential(usuario, pass)
   End Sub

End Class