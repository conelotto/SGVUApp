Imports SGCVU.BE
Imports SGCVU.DA
Imports System.Data.Common
Imports SGCVU.DTO

Public Class clsDimCliente

   Public Shared Function fn_Select_Cliente_Paginado_Total(ByRef po_intTotal As Integer, ByVal pi_pagina As Integer, ByVal pi_CantidadRegistros As Integer, ByVal pi_strCodigo As String, ByVal pi_strDescripcion As String) As List(Of DTO_Cliente_Busqueda)
      Try
         Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
         Dim EntParametroSQL As New clsEntidad_ParametroSQL

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@COD_CLIENTE"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_strCodigo.GetType)
            .strSourceColumn = pi_strCodigo
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@DESC_CLIENTE"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_strDescripcion.GetType)
            .strSourceColumn = pi_strDescripcion
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@Pagina"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_pagina.GetType)
            .strSourceColumn = pi_pagina
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@RegistrosPorPagina"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_CantidadRegistros.GetType)
            .strSourceColumn = pi_CantidadRegistros
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         EntParametroSQL = New clsEntidad_ParametroSQL 'Agregar este parámetro al último (Para obtener la cantidad de registros)
         With EntParametroSQL
            .strParameterName = "@ObtenerTotal"
            .typDbType = DbType.String
            .strSourceColumn = "1"
         End With
         liEnt_Parametro.Add(EntParametroSQL)

         Dim liDTOClienteBusqueda As New List(Of DTO_Cliente_Busqueda)
         po_intTotal = clsSQLServer.fn_EjecutarSelect_Escalar("cnFSASGCVU", "P_BRR5_S_DIM_CLIENTE_PAGINADO_TOTAL", True, liEnt_Parametro)

         If po_intTotal > 0 Then
            liEnt_Parametro.RemoveAt(liEnt_Parametro.Count - 1)

            EntParametroSQL = New clsEntidad_ParametroSQL 'Agregar parámetro para obtener la lista
            With EntParametroSQL
               .strParameterName = "@ObtenerTotal"
               .typDbType = DbType.String
               .strSourceColumn = "0"
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            liDTOClienteBusqueda = clsSQLServer.fn_EjecutarSelect(Of DTO_Cliente_Busqueda)("cnFSASGCVU", "P_BRR5_S_DIM_CLIENTE_PAGINADO_TOTAL", True, liEnt_Parametro)
         End If

         Return liDTOClienteBusqueda
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Shared Function fn_Select_ListaDimCliente(ByVal pi_CodCliente As String) As List(Of BE_DimCliente2)
      Try
         Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
         Dim EntParametroSQL As New clsEntidad_ParametroSQL

         'Filtros
         EntParametroSQL = New clsEntidad_ParametroSQL
         With EntParametroSQL
            .strParameterName = "@COD_CLIENTE"
            .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_CodCliente.GetType)
            .strSourceColumn = pi_CodCliente
         End With
         liEnt_Parametro.Add(EntParametroSQL)


         Dim liBEDimCliente As New List(Of BE_DimCliente2)

         clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_DIM_CLIENTE", True, liBEDimCliente, liEnt_Parametro)

         Return liBEDimCliente
      Catch ex As Exception
         Throw ex
      End Try
   End Function

End Class