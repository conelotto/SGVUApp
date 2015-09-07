Imports System.Data.SqlClient
Imports System.Configuration

Friend Class dalConexion

   Private conexion As IDbConnection

   Public Function ObtenerConexion() As IDbConnection
      Dim stringConexion As String = ConfigurationManager.ConnectionStrings("cnFSASGCVU").ConnectionString
      Return New SqlConnection(stringConexion)
   End Function

End Class