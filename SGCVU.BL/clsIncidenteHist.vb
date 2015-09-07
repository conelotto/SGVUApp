Imports SGCVU.BE
Imports SGCVU.DA

Public Class clsIncidenteHist


    Public Shared Function fn_Insert_ListaExpedienteHist(ByVal pi_BEExpedienteHist As BE_ExpedienteHistorial) As String
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ActividadId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEExpedienteHist.int_ActividadId.GetType)
                .strSourceColumn = pi_BEExpedienteHist.int_ActividadId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@UsuarioId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEExpedienteHist.int_UsuarioId.GetType)
                .strSourceColumn = pi_BEExpedienteHist.int_UsuarioId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ExpedienteId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEExpedienteHist.int_ExpedienteId.GetType)
                .strSourceColumn = pi_BEExpedienteHist.int_ExpedienteId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@RolFlujoId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEExpedienteHist.int_RolFlujoId.GetType)
                .strSourceColumn = pi_BEExpedienteHist.int_RolFlujoId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim strReturn As String = String.Empty
            Dim strParametroSalida As String = String.Empty

            Try
                strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_I_ExpedienteHistorial", True, strReturn, liEnt_Parametro)

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
