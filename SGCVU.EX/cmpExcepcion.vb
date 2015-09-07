Public Class cmpExcepcion

   Public Shared Function AdministrarExcepcion(ByVal pi_ex As Exception, ByVal pi_modulo As Modulo, ByVal pi_usuario As String, ByVal pi_IP As String, ByVal pi_mac As String)
      Dim datosEx As DatosExcepcion = ObtenerDatosExcepcion(pi_ex, pi_modulo, pi_usuario, pi_IP, pi_mac)

      Dim registroEx As cmpRegistroExcepcion = New cmpRegistroExcepcion(datosEx)
      registroEx.GuardarLog()

      Return String.Format("Message: {0} - StackTrace: {1}", datosEx.mensaje1, datosEx.pilaLlamada)
   End Function

   Private Shared Function ObtenerDatosExcepcion(ByVal pi_ex As Exception, ByVal pi_modulo As Modulo, ByVal pi_usuario As String, ByVal pi_IP As String, ByVal pi_mac As String)
      Dim datosEx As DatosExcepcion = New DatosExcepcion()
      Dim trace As StackTrace = New StackTrace(pi_ex, True)

      datosEx.clase = pi_ex.TargetSite.DeclaringType.Name
      datosEx.metodo = pi_ex.TargetSite.Name
      datosEx.numeroLinea = trace.GetFrame(0).GetFileLineNumber().ToString()
      datosEx.pilaLlamada = pi_ex.StackTrace.ToString()
      datosEx.mensaje1 = pi_ex.Message
      If pi_ex.InnerException IsNot Nothing Then
         datosEx.mensaje2 = pi_ex.InnerException.Message
      End If
      datosEx.modulo = Modulo.GetName(pi_modulo.GetType, pi_modulo)
      datosEx.fecha = Date.Now
      datosEx.usuario = pi_usuario
      datosEx.ip = pi_IP
      datosEx.mac = pi_mac

      Return datosEx
   End Function

End Class