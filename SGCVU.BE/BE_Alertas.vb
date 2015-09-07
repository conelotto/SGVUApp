Public Class BE_Alertas

   Public Property int_AlertaId As Integer
   Public Property str_MensajeFrom As String
   Public Property str_MensajeTo As String
   Public Property str_MensajeCC As String
   Public Property str_MensajeAsunto As String
   Public Property str_MensajeContenido As String
   Public Property det_FechaRegistro As Nullable(Of DateTime) = Nothing
   Public Property str_UsuarioRegistro As String
   Public Property det_FechaEnvio As Nullable(Of DateTime) = Nothing
   Public Property bool_EstadoEnvio As Boolean

End Class