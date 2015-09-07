Imports SGCVU.BE
Imports SGCVU.DA

Public Class clsExpediente_Historial

    Public Shared Function fn_Select_ExpedienteHistorial_ByKey(ByVal pi_BeExpedienteHistorial As BE_ExpedienteHistorial) As List(Of BE_ExpedienteHistorial)
        Try
            Dim liBEParametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ApoyoId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BeExpedienteHistorial.int_ApoyoId.GetType)
                .strSourceColumn = pi_BeExpedienteHistorial.int_ApoyoId
            End With
            liBEParametro.Add(EntParametroSQL)

            Dim liBeExpedienteHistorial As New List(Of BE_ExpedienteHistorial)
            clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_ExpedienteHistorial_ApoyoId", True, liBeExpedienteHistorial, liBEParametro)
            Return liBeExpedienteHistorial

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Select_ListaExpedienteHist(ByVal pi_BEExpediente As BE_ExpedienteHistorial) As List(Of BE_ExpedienteHistorial)
        Try
            Dim liBEParametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ExpedienteId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEExpediente.int_ExpedienteId.GetType)
                .strSourceColumn = pi_BEExpediente.int_ExpedienteId
            End With
            liBEParametro.Add(EntParametroSQL)


            Dim liBEExpedienteHist As New List(Of BE_ExpedienteHistorial)

            clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_EXPEDIENTE_HIST", True, liBEExpedienteHist, liBEParametro)

            Return liBEExpedienteHist
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Insert_ListaExpedienteHist(ByVal pBEExpedienteHist As BE_ExpedienteHistorial) As String
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ExpedienteId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pBEExpedienteHist.int_ExpedienteId.GetType)
                .strSourceColumn = pBEExpedienteHist.int_ExpedienteId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@UsuarioId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pBEExpedienteHist.int_UsuarioId.GetType)
                .strSourceColumn = pBEExpedienteHist.int_UsuarioId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ActividadId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pBEExpedienteHist.int_ActividadId.GetType)
                .strSourceColumn = pBEExpedienteHist.int_ActividadId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@RolFlujoId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pBEExpedienteHist.int_RolFlujoId.GetType)
                .strSourceColumn = pBEExpedienteHist.int_RolFlujoId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@FechaCreacion"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pBEExpedienteHist.det_FechaCreacion.GetType)
                .strSourceColumn = pBEExpedienteHist.det_FechaCreacion
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim strReturn As String = String.Empty
            Dim strParametroSalida As String = String.Empty

            Try
                strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_I_EXPEDIENTEHIST", True, strReturn, liEnt_Parametro)

                If Not strParametroSalida = String.Empty Then strReturn = strParametroSalida
            Catch ex As Exception
                strReturn = String.Empty
            End Try

            Return strReturn
        Catch ex As Exception
            'Dim rethrow As Boolean = ExceptionPolicy.HandleException(ex, "ExHandling")
            Throw ex
        End Try
    End Function

End Class
