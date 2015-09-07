Imports System.Text

Friend Class dalRepositorioExcepcion
   Inherits dalRepositorioBase

   Public Function Guardar(ByVal excepciones As List(Of DatosExcepcion)) As Integer
      Return Ejecutar(ObtenerSQL(excepciones))
   End Function

   Private Function ObtenerSQL(ByVal excepciones As List(Of DatosExcepcion)) As String
      Dim strSQL As StringBuilder = New StringBuilder()
      Dim mensaje2 = String.Empty
      For Each item As DatosExcepcion In excepciones
         If item.mensaje2 IsNot Nothing Then
            mensaje2 = item.mensaje2.Replace("'", "''")
         End If
         strSQL.AppendLine(String.Format("INSERT INTO LogError(fecha, usuario, ip, mac, modulo, clase, metodo, numeroLinea, pilaLlamada, mensaje1, mensaje2) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', {7}, '{8}', '{9}', '{10}')",
                                         item.fecha.ToString("yyyy-MM-dd HH:mm:ss"), item.usuario.Replace("'", "''"), item.ip, item.mac, item.modulo.Replace("'", "''"), item.clase, item.metodo, item.numeroLinea, item.pilaLlamada.Replace("'", "''"), item.mensaje1.Replace("'", "''"), mensaje2))
      Next item
      Return strSQL.ToString()
   End Function

End Class