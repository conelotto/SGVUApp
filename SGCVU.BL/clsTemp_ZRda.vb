Imports SGCVU.BE
Imports SGCVU.DA

Public Class clsTemp_ZRda

   Public Shared Function fn_Insert_Update_Temp_ZRda(ByVal pi_BETemp_ZRda As BE_Temp_ZRda) As String
      Try
         Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
         Dim EntParametroSQL As New clsEntidad_ParametroSQL

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@OrgFact"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BETemp_ZRda.str_OrgFact.GetType)
            .strSourceColumn = pi_BETemp_ZRda.str_OrgFact
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@OrdAsignada"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BETemp_ZRda.str_OrdAsignada.GetType)
            .strSourceColumn = pi_BETemp_ZRda.str_OrdAsignada
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@IdPosicion"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BETemp_ZRda.int_IdPosicion.GetType)
            .strSourceColumn = pi_BETemp_ZRda.int_IdPosicion
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@Status"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BETemp_ZRda.str_Status.GetType)
            .strSourceColumn = pi_BETemp_ZRda.str_Status
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@Fecha"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BETemp_ZRda.det_Fecha.GetType)
            .strSourceColumn = pi_BETemp_ZRda.det_Fecha
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@NroMotor"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BETemp_ZRda.str_NroMotor.GetType)
            .strSourceColumn = pi_BETemp_ZRda.str_NroMotor
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@IdPedido"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BETemp_ZRda.str_IdPedido.GetType)
            .strSourceColumn = pi_BETemp_ZRda.str_IdPedido
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@OfiVentasFac"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BETemp_ZRda.str_OfiVentasFac.GetType)
            .strSourceColumn = pi_BETemp_ZRda.str_OfiVentasFac
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@OfiVentasFacTxt"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BETemp_ZRda.str_OfiVentasFacTxt.GetType)
            .strSourceColumn = pi_BETemp_ZRda.str_OfiVentasFacTxt
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@Oportunidad"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BETemp_ZRda.str_Oportunidad.GetType)
            .strSourceColumn = pi_BETemp_ZRda.str_Oportunidad
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@ApoyoFab"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BETemp_ZRda.str_ApoyoFab.GetType)
            .strSourceColumn = pi_BETemp_ZRda.str_ApoyoFab
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@Eliminado"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BETemp_ZRda.str_Eliminado.GetType)
            .strSourceColumn = pi_BETemp_ZRda.str_Eliminado
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@FormaPago"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BETemp_ZRda.str_FormaPago.GetType)
            .strSourceColumn = pi_BETemp_ZRda.str_FormaPago
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@FormaPagoTxt"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BETemp_ZRda.str_FormaPagoTxt.GetType)
            .strSourceColumn = pi_BETemp_ZRda.str_FormaPagoTxt
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@CodDbs"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BETemp_ZRda.str_CodDbs.GetType)
            .strSourceColumn = pi_BETemp_ZRda.str_CodDbs
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@CtaInventario"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BETemp_ZRda.str_CtaInventario.GetType)
            .strSourceColumn = pi_BETemp_ZRda.str_CtaInventario
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@Serie"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BETemp_ZRda.str_Serie.GetType)
            .strSourceColumn = pi_BETemp_ZRda.str_Serie
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@AFabricacion"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BETemp_ZRda.str_AFabricacion.GetType)
            .strSourceColumn = pi_BETemp_ZRda.str_AFabricacion
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@Numero"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BETemp_ZRda.str_Numero.GetType)
            .strSourceColumn = pi_BETemp_ZRda.str_Numero
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@IdExtSocNegResponsable"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BETemp_ZRda.str_IdExtSocNegResponsable.GetType)
            .strSourceColumn = pi_BETemp_ZRda.str_IdExtSocNegResponsable
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@IdSapSocNegResponsable"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BETemp_ZRda.str_IdSapSocNegResponsable.GetType)
            .strSourceColumn = pi_BETemp_ZRda.str_IdSapSocNegResponsable
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@NombreResponsable"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BETemp_ZRda.str_NombreResponsable.GetType)
            .strSourceColumn = pi_BETemp_ZRda.str_NombreResponsable
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@IdExtSocNegCliente"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BETemp_ZRda.str_IdExtSocNegCliente.GetType)
            .strSourceColumn = pi_BETemp_ZRda.str_IdExtSocNegCliente
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@IdSapSocNegCliente"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BETemp_ZRda.str_IdSapSocNegCliente.GetType)
            .strSourceColumn = pi_BETemp_ZRda.str_IdSapSocNegCliente
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@NombreCliente"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BETemp_ZRda.str_NombreCliente.GetType)
            .strSourceColumn = pi_BETemp_ZRda.str_NombreCliente
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@IdExtSocNegEntidadFinanciera"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BETemp_ZRda.str_IdExtSocNegEntidadFinanciera.GetType)
            .strSourceColumn = pi_BETemp_ZRda.str_IdExtSocNegEntidadFinanciera
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@IdSapSocNegEntidadFinanciera"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BETemp_ZRda.str_IdSapSocNegEntidadFinanciera.GetType)
            .strSourceColumn = pi_BETemp_ZRda.str_IdSapSocNegEntidadFinanciera
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@NombreEntidadFinanciera"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BETemp_ZRda.str_NombreEntidadFinanciera.GetType)
            .strSourceColumn = pi_BETemp_ZRda.str_NombreEntidadFinanciera
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@FechaCre"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BETemp_ZRda.str_FechaCre.GetType)
            .strSourceColumn = pi_BETemp_ZRda.str_FechaCre
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@HoraCre"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BETemp_ZRda.str_HoraCre.GetType)
            .strSourceColumn = pi_BETemp_ZRda.str_HoraCre
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@FechaMod"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BETemp_ZRda.str_FechaMod.GetType)
            .strSourceColumn = pi_BETemp_ZRda.str_FechaMod
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@HoraMod"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BETemp_ZRda.str_HoraMod.GetType)
            .strSourceColumn = pi_BETemp_ZRda.str_HoraMod
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         Dim strReturn As String = String.Empty
         Dim strParametroSalida As String = String.Empty

         Try
            strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_I_Temp_ZRda", True, strReturn, liEnt_Parametro)

            If Not strParametroSalida = String.Empty Then strReturn = strParametroSalida
         Catch ex As Exception
            strReturn = String.Empty
         End Try

         Return strReturn
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Shared Function fn_Select_Temp_ZRda_Estado(ByVal pi_strEstado As String) As List(Of BE_Temp_ZRda)
      Try
         Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
         Dim EntParametroSQL As New clsEntidad_ParametroSQL

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@Estado"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_strEstado.GetType)
            .strSourceColumn = pi_strEstado
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         Dim liBETemp_ZRda As New List(Of BE_Temp_ZRda)

         clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_Temp_ZRda_Estado", True, liBETemp_ZRda, liEnt_Parametro)

         Return liBETemp_ZRda
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Shared Function fn_Update_Temp_ZRda_Estado(ByVal pi_intIdTemp_ZRda As Integer, ByVal pi_strEstado As String) As String
      Try
         Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
         Dim EntParametroSQL As New clsEntidad_ParametroSQL

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@IdTemp_ZRda"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_intIdTemp_ZRda.GetType)
            .strSourceColumn = pi_intIdTemp_ZRda
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@Estado"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_strEstado.GetType)
            .strSourceColumn = pi_strEstado
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         Dim strReturn As String = String.Empty
         Dim strParametroSalida As String = String.Empty

         Try
            strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_U_Temp_ZRda_Estado", True, strReturn, liEnt_Parametro)

            If Not strParametroSalida = String.Empty Then strReturn = strParametroSalida
         Catch ex As Exception
            strReturn = String.Empty
         End Try

         Return strReturn
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Shared Function fn_Select_Temp_ZRda_Id(ByVal pi_intIdTempZRda As Integer) As BE_Temp_ZRda
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

         Dim BETempZRda As BE_Temp_ZRda = Nothing
         Dim liBETemp_ZRda As New List(Of BE_Temp_ZRda)

         clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_Temp_ZRda_Id", True, liBETemp_ZRda, liEnt_Parametro)

         If liBETemp_ZRda.Count > 0 Then
            BETempZRda = liBETemp_ZRda(0)
         End If

         Return BETempZRda
      Catch ex As Exception
         Throw ex
      End Try
   End Function

End Class