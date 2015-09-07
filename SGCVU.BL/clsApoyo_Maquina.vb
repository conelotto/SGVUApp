Imports SGCVU.BE
Imports SGCVU.DA

Public Class clsApoyo_Maquina

    Public Shared Function fn_Select_ApoyoMaquina_Historial_ByKey(ByVal pi_BEApoyoMaquina As BE_ApoyoMaquina) As List(Of BE_ApoyoMaquina)
        Try
            Dim liBEParametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ApoyoId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEApoyoMaquina.int_ApoyoId.GetType)
                .strSourceColumn = pi_BEApoyoMaquina.int_ApoyoId
            End With
            liBEParametro.Add(EntParametroSQL)

            Dim liBEApoyoMaquina As New List(Of BE_ApoyoMaquina)
            clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_MaquinaApoyo_Historial", True, liBEApoyoMaquina, liBEParametro)
            Return liBEApoyoMaquina

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Update_ApoyoMaquina_SolicitudAceptada(ByVal pi_BEApoyoMaquina As BE_ApoyoMaquina) As String
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@MaquinaApoyoId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEApoyoMaquina.int_MaquinaApoyoId.GetType)
                .strSourceColumn = pi_BEApoyoMaquina.int_MaquinaApoyoId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ApoyoId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEApoyoMaquina.int_ApoyoId.GetType)
                .strSourceColumn = pi_BEApoyoMaquina.int_ApoyoId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Observacion"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEApoyoMaquina.str_Observacion.GetType)
                .strSourceColumn = pi_BEApoyoMaquina.str_Observacion
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Usuario"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEApoyoMaquina.str_UsuarioModificacion.GetType)
                .strSourceColumn = pi_BEApoyoMaquina.str_UsuarioModificacion
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim strReturn As String = String.Empty
            Dim strParametroSalida As String = String.Empty

            Try
                strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_U_MaquinaApoyo_SolicitudAceptada", True, strReturn, liEnt_Parametro)

                If Not strParametroSalida = String.Empty Then strReturn = strParametroSalida
            Catch ex As Exception
                strReturn = String.Empty
            End Try

            Return strReturn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Update_ApoyoMaquina_SolicitudCancelada(ByVal pi_BEApoyoMaquina As BE_ApoyoMaquina) As String
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@MaquinaApoyoId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEApoyoMaquina.int_MaquinaApoyoId.GetType)
                .strSourceColumn = pi_BEApoyoMaquina.int_MaquinaApoyoId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ApoyoId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEApoyoMaquina.int_ApoyoId.GetType)
                .strSourceColumn = pi_BEApoyoMaquina.int_ApoyoId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Observacion"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEApoyoMaquina.str_Observacion.GetType)
                .strSourceColumn = pi_BEApoyoMaquina.str_Observacion
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Usuario"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEApoyoMaquina.str_UsuarioModificacion.GetType)
                .strSourceColumn = pi_BEApoyoMaquina.str_UsuarioModificacion
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@RespuestaTipo"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEApoyoMaquina.str_RespuestaTipo.GetType)
                .strSourceColumn = pi_BEApoyoMaquina.str_RespuestaTipo
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim strReturn As String = String.Empty
            Dim strParametroSalida As String = String.Empty

            Try
                strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_U_MaquinaApoyo_SolicitudCancelada", True, strReturn, liEnt_Parametro)

                If Not strParametroSalida = String.Empty Then strReturn = strParametroSalida
            Catch ex As Exception
                strReturn = String.Empty
            End Try

            Return strReturn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Insert_SolicitudRegistrar(ByVal pi_BEApoyoMaquina As BE_ApoyoMaquina) As String
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ApoyoId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEApoyoMaquina.int_ApoyoId.GetType)
                .strSourceColumn = pi_BEApoyoMaquina.int_ApoyoId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Observacion"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEApoyoMaquina.str_Observacion.GetType)
                .strSourceColumn = pi_BEApoyoMaquina.str_Observacion
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Usuario"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEApoyoMaquina.str_UsuarioCreacion.GetType)
                .strSourceColumn = pi_BEApoyoMaquina.str_UsuarioCreacion
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim strReturn As String = String.Empty
            Dim strParametroSalida As String = String.Empty

            Try
                strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_I_MaquinaApoyo_SolicitudRegistrar", True, strReturn, liEnt_Parametro)
                If Not strParametroSalida = String.Empty Then strReturn = strParametroSalida
            Catch ex As Exception
                strReturn = String.Empty
            End Try

            Return strReturn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Insert_ExpedienteComentario(ByVal pi_BEApoyoMaquina As BE_ApoyoMaquina) As String
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ApoyoId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEApoyoMaquina.int_ApoyoId.GetType)
                .strSourceColumn = pi_BEApoyoMaquina.int_ApoyoId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Comentario"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEApoyoMaquina.str_Observacion.GetType)
                .strSourceColumn = pi_BEApoyoMaquina.str_Observacion
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Usuario"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEApoyoMaquina.str_UsuarioCreacion.GetType)
                .strSourceColumn = pi_BEApoyoMaquina.str_UsuarioCreacion
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim strReturn As String = String.Empty
            Dim strParametroSalida As String = String.Empty

            Try
                strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_I_ExpedienteComentario", True, strReturn, liEnt_Parametro)
                If Not strParametroSalida = String.Empty Then strReturn = strParametroSalida
            Catch ex As Exception
                strReturn = String.Empty
            End Try

            Return strReturn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Select_ExpedienteComentario_ByApoyo(ByVal _Be As BE_Expediente_Comentarios) As List(Of BE_Expediente_Comentarios)
        Try
            Dim liBEParametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ApoyoId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(_Be.int_ApoyoId.GetType)
                .strSourceColumn = _Be.int_ApoyoId
            End With
            liBEParametro.Add(EntParametroSQL)

            Dim _List As New List(Of BE_Expediente_Comentarios)
            clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_ExpedienteComentario_ByApoyo", True, _List, liBEParametro)
            Return _List

        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
