Friend Class dalRepositorioBase

   Private conexion As IDbConnection
   Private dalConexion As dalConexion

   Private Sub CrearConexion()
      If dalConexion Is Nothing Then
         dalConexion = New dalConexion()
      End If
      conexion = dalConexion.ObtenerConexion()
   End Sub

   Public Function Ejecutar(ByVal sql As String) As Integer
      CrearConexion()
      Dim resultado As Integer = 0
      Try
         Using comando As IDbCommand = conexion.CreateCommand()
            comando.CommandText = sql
            conexion.Open()
            resultado = comando.ExecuteNonQuery()
         End Using
      Catch ex As Exception
         Throw ex
      Finally
         conexion.Close()
      End Try
      Return resultado
   End Function

End Class