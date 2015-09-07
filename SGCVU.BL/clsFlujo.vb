Imports SGCVU.BE
Imports SGCVU.DA

Public Class clsFlujo

   Public Shared Function fn_Select_ListaFlujoSiguiente(ByVal pi_BEFlujo As BE_Flujo) As List(Of BE_Flujo)
      Try
         Dim liBEParametro As New List(Of clsEntidad_ParametroSQL)
         Dim EntParametroSQL As New clsEntidad_ParametroSQL

         'Filtros
         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
                .strParameterName = "@ActividadId"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEFlujo.int_IdActividad.GetType)
            .strSourceColumn = pi_BEFlujo.int_IdActividad
         End With
         liBEParametro.Add(EntParametroSQL)


            Dim liBEFlujo As New List(Of BE_Flujo)

            clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_FLUJO_SIGUIENTE", True, liBEFlujo, liBEParametro)

         Return liBEFlujo
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Shared Function fn_Select_ListaFlujoAnterior(ByVal pi_BEFlujo As BE_Flujo) As List(Of BE_Flujo)
      Try
         Dim liBEParametro As New List(Of clsEntidad_ParametroSQL)
         Dim EntParametroSQL As New clsEntidad_ParametroSQL

         'Filtros
         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
                .strParameterName = "@ActividadId"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEFlujo.int_IdActividad.GetType)
            .strSourceColumn = pi_BEFlujo.int_IdActividad
         End With
         liBEParametro.Add(EntParametroSQL)


         Dim liBEFlujo As New List(Of BE_Flujo)

            clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_FLUJO_ANTERIOR", True, liBEFlujo, liBEParametro)

         Return liBEFlujo
      Catch ex As Exception
         Throw ex
      End Try
   End Function

End Class
