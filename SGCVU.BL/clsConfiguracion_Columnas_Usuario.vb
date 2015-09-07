Imports SGCVU.BE
Imports SGCVU.DA
Imports SGCVU.DTO

Public Class clsConfiguracion_Columnas_Usuario

   Public Shared Function fn_Select_Configuracion_Columnas_Usuario(ByVal pi_strIdentificadorVista As String, ByVal pi_strUsuario_Login As String) As List(Of DTO_Configuracion_Columnas_Usuario)
      Try
         Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
         Dim EntParametroSQL As New clsEntidad_ParametroSQL

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@IdentificadorVista"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_strIdentificadorVista.GetType)
            .strSourceColumn = pi_strIdentificadorVista
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@Usuario_Login"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_strUsuario_Login.GetType)
            .strSourceColumn = pi_strUsuario_Login
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         Return clsSQLServer.fn_EjecutarSelect(Of DTO_Configuracion_Columnas_Usuario)("cnFSASGCVU", "P_BRR5_S_Configuracion_Columnas_Usuario", True, liEnt_Parametro)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Shared Function fn_Select_Configuracion_Columnas_Usuario_Activas(ByVal pi_strIdentificadorVista As String, ByVal pi_strUsuario_Login As String) As List(Of DTO_Configuracion_Columnas_Usuario)
      Try
         Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
         Dim EntParametroSQL As New clsEntidad_ParametroSQL

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@IdentificadorVista"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_strIdentificadorVista.GetType)
            .strSourceColumn = pi_strIdentificadorVista
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@Usuario_Login"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_strUsuario_Login.GetType)
            .strSourceColumn = pi_strUsuario_Login
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         Return clsSQLServer.fn_EjecutarSelect(Of DTO_Configuracion_Columnas_Usuario)("cnFSASGCVU", "P_BRR5_S_Configuracion_Columnas_Usuario_Activas", True, liEnt_Parametro)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Shared Function fn_Update_Configuracion_Columnas_Usuario(ByVal pi_strUsuario_Login As String, ByVal pi_strIdentificadorVista As String, ByVal pi_liStrConfiguracionColumnasId As List(Of String)) As String
      Try
         Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
         Dim EntParametroSQL As New clsEntidad_ParametroSQL

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@Usuario_Login"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_strUsuario_Login.GetType)
            .strSourceColumn = pi_strUsuario_Login
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@IdentificadorVista"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_strIdentificadorVista.GetType)
            .strSourceColumn = pi_strIdentificadorVista
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         Dim str_ConfiguracionColumnasId = clsUtil.fn_ConvertirArrayAString(pi_liStrConfiguracionColumnasId, False)
         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@ConfiguracionColumnasIds"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(str_ConfiguracionColumnasId.GetType)
            .strSourceColumn = str_ConfiguracionColumnasId
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         Dim strReturn As String = String.Empty
         Dim strParametroSalida As String = String.Empty

         Try
            strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_U_Configuracion_Columnas_Usuario", True, strReturn, liEnt_Parametro)

            If Not strParametroSalida = String.Empty Then strReturn = strParametroSalida
         Catch ex As Exception
            strReturn = String.Empty
         End Try

         Return strReturn
      Catch ex As Exception
         Throw ex
      End Try
   End Function

End Class
