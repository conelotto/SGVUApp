Imports SGCVU.BE
Imports SGCVU.DA

Public Class clsControlRangoTiempoRDA

   Public Shared Function fn_Insert_ControlRangoTiempoRDA(ByVal pi_BEControlRangoTiempoRDA As BE_ControlRangoTiempoRDA) As String
      Try
         Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
         Dim EntParametroSQL As New clsEntidad_ParametroSQL

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@FechaHoraConsulta"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEControlRangoTiempoRDA.FechaHoraConsulta.GetType)
            .strSourceColumn = pi_BEControlRangoTiempoRDA.FechaHoraConsulta
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@EjecucionCorrecta"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEControlRangoTiempoRDA.EjecucionCorrecta.GetType)
            .strSourceColumn = pi_BEControlRangoTiempoRDA.EjecucionCorrecta
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@RegistrosObtenidos"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEControlRangoTiempoRDA.RegistrosObtenidos.GetType)
            .strSourceColumn = pi_BEControlRangoTiempoRDA.RegistrosObtenidos
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         Dim strReturn As String = String.Empty
         Dim strParametroSalida As String = String.Empty

         Try
            strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_I_ControlRangoTiempoRDA", True, strReturn, liEnt_Parametro)

            If Not strParametroSalida = String.Empty Then strReturn = strParametroSalida
         Catch ex As Exception
            strReturn = String.Empty
         End Try

         Return strReturn
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Shared Function fn_Select_UltimoExito() As List(Of BE_ControlRangoTiempoRDA)
      Try
         Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)

         Return clsSQLServer.fn_EjecutarSelect(Of BE_ControlRangoTiempoRDA)("cnFSASGCVU", "P_BRR5_S_ControlRangoTiempoRDA_UltimoExito", True, liEnt_Parametro)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

End Class