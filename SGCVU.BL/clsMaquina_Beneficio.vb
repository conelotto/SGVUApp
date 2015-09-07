Imports SGCVU.BE
Imports SGCVU.DA

Public Class clsMaquina_Beneficio

   Public Shared Function fn_Select_Maquina_Beneficio_Orden_Pedido(ByVal pi_strOrden As String, ByVal pi_strPedidoId As String) As List(Of BE_Maquina_Beneficio)
      Try
         Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
         Dim EntParametroSQL As New clsEntidad_ParametroSQL

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@OrdenAsignada"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_strOrden.GetType)
            .strSourceColumn = pi_strOrden
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@PedidoId"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_strPedidoId.GetType)
            .strSourceColumn = pi_strPedidoId
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         Dim liBEMaquinaBeneficio As New List(Of BE_Maquina_Beneficio)

         clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_Maquina_Beneficio_Orden_Pedido", True, liBEMaquinaBeneficio, liEnt_Parametro)

         Return liBEMaquinaBeneficio
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Shared Function fn_Insert_Maquina_Beneficio(ByVal pi_BEMaquinaBeneficio As BE_Maquina_Beneficio) As String
      Try
         Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
         Dim EntParametroSQL As New clsEntidad_ParametroSQL

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@OrdenAsignada"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquinaBeneficio.str_OrdenAsignada.GetType)
            .strSourceColumn = pi_BEMaquinaBeneficio.str_OrdenAsignada
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@PedidoId"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquinaBeneficio.str_PedidoId.GetType)
            .strSourceColumn = pi_BEMaquinaBeneficio.str_PedidoId
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@BeneficioId"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquinaBeneficio.int_BeneficioId.GetType)
            .strSourceColumn = pi_BEMaquinaBeneficio.int_BeneficioId
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@Descripcion"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquinaBeneficio.str_Descripcion.GetType)
            .strSourceColumn = pi_BEMaquinaBeneficio.str_Descripcion
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@Monto"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquinaBeneficio.dec_Monto.GetType)
            .strSourceColumn = pi_BEMaquinaBeneficio.dec_Monto
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         Dim strReturn As String = String.Empty
         Dim strParametroSalida As String = String.Empty

         Try
            strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_I_Maquina_Beneficio", True, strReturn, liEnt_Parametro)

            If Not strParametroSalida = String.Empty Then strReturn = strParametroSalida
         Catch ex As Exception
            strReturn = String.Empty
         End Try

         Return strReturn
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Shared Function fn_Delete_Maquina_Beneficio(ByVal pi_BEMaquinaBeneficio As BE_Maquina_Beneficio) As String
      Try
         Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
         Dim EntParametroSQL As New clsEntidad_ParametroSQL

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@OrdenAsignada"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquinaBeneficio.str_OrdenAsignada.GetType)
            .strSourceColumn = pi_BEMaquinaBeneficio.str_OrdenAsignada
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@PedidoId"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquinaBeneficio.str_PedidoId.GetType)
            .strSourceColumn = pi_BEMaquinaBeneficio.str_PedidoId
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@BeneficioId"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquinaBeneficio.int_BeneficioId.GetType)
            .strSourceColumn = pi_BEMaquinaBeneficio.int_BeneficioId
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         Dim strReturn As String = String.Empty
         Dim strParametroSalida As String = String.Empty

         Try
            strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_D_Maquina_Beneficio", True, strReturn, liEnt_Parametro)

            If Not strParametroSalida = String.Empty Then strReturn = strParametroSalida
         Catch ex As Exception
            strReturn = String.Empty
         End Try

         Return strReturn
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Shared Function fn_Update_Maquina_Beneficio(ByVal pi_BEMaquinaBeneficio As BE_Maquina_Beneficio) As String
      Try
         Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
         Dim EntParametroSQL As New clsEntidad_ParametroSQL

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@OrdenAsignada"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquinaBeneficio.str_OrdenAsignada.GetType)
            .strSourceColumn = pi_BEMaquinaBeneficio.str_OrdenAsignada
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@PedidoId"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquinaBeneficio.str_PedidoId.GetType)
            .strSourceColumn = pi_BEMaquinaBeneficio.str_PedidoId
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@BeneficioId"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquinaBeneficio.int_BeneficioId.GetType)
            .strSourceColumn = pi_BEMaquinaBeneficio.int_BeneficioId
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@Descripcion"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquinaBeneficio.str_Descripcion.GetType)
            .strSourceColumn = pi_BEMaquinaBeneficio.str_Descripcion
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@Monto"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquinaBeneficio.dec_Monto.GetType)
            .strSourceColumn = pi_BEMaquinaBeneficio.dec_Monto
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         Dim strReturn As String = String.Empty
         Dim strParametroSalida As String = String.Empty

         Try
            strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_U_Maquina_Beneficio", True, strReturn, liEnt_Parametro)

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