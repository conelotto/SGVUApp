Imports SGCVU.BE
Imports SGCVU.DA

Public Class clsTemp_ZBeneficio

   Public Shared Function fn_Select_Temp_ZBeneficio_IdTempZRda(ByVal pi_intIdTempZRda As Integer) As List(Of BE_Temp_ZBeneficio)
      Try
         Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
         Dim EntParametroSQL As New clsEntidad_ParametroSQL

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@IdTemp_ZRda"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_intIdTempZRda.GetType)
            .strSourceColumn = pi_intIdTempZRda
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         Dim liBETemp_ZBeneficio As New List(Of BE_Temp_ZBeneficio)

         clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_Temp_ZBeneficio_IdTempZRda", True, liBETemp_ZBeneficio, liEnt_Parametro)

         Return liBETemp_ZBeneficio
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Shared Function fn_Insert_Temp_ZBeneficio(ByVal pi_BETempZBeneficio As BE_Temp_ZBeneficio) As String
      Try
         Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
         Dim EntParametroSQL As New clsEntidad_ParametroSQL

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@IdTemp_ZRda"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BETempZBeneficio.int_IdTemp_ZRda.GetType)
            .strSourceColumn = pi_BETempZBeneficio.int_IdTemp_ZRda
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@Codigo"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BETempZBeneficio.str_Codigo.GetType)
            .strSourceColumn = pi_BETempZBeneficio.str_Codigo
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@Descripcion"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BETempZBeneficio.str_Descripcion.GetType)
            .strSourceColumn = pi_BETempZBeneficio.str_Descripcion
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@Cantidad"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BETempZBeneficio.int_Cantidad.GetType)
            .strSourceColumn = pi_BETempZBeneficio.int_Cantidad
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         Dim strReturn As String = String.Empty
         Dim strParametroSalida As String = String.Empty

         Try
            strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_I_Temp_ZBeneficio", True, strReturn, liEnt_Parametro)

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