Imports SGCVU.BE
Imports SGCVU.DA

Public Class clsAlertas

    Public Shared Function fn_Insert_Alerta(ByVal pi_BEAlerta As BE_Alertas, ByVal pi_strModuloId As String, ByVal pi_strCompaniaId As String, ByVal pi_intActidad As Integer) As String
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@CorreoEnvio_Subject"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEAlerta.str_MensajeAsunto.GetType)
                .strSourceColumn = pi_BEAlerta.str_MensajeAsunto
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@CorreoEnvio_Boby"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEAlerta.str_MensajeContenido.GetType)
                .strSourceColumn = pi_BEAlerta.str_MensajeContenido
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@UsuarioRegistro"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEAlerta.str_UsuarioRegistro.GetType)
                .strSourceColumn = pi_BEAlerta.str_UsuarioRegistro
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ModuloId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_strModuloId.GetType)
                .strSourceColumn = pi_strModuloId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@CompaniaId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_strCompaniaId.GetType)
                .strSourceColumn = pi_strCompaniaId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Actividad"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_intActidad.GetType)
                .strSourceColumn = pi_intActidad
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@EjecutadaDesdeProcedimiento"
                .typDbType = DbType.String
                .strSourceColumn = "0"
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim strReturn As String = String.Empty
            Dim strParametroSalida As String = String.Empty

            Try
                strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_I_Alertas", True, strReturn, liEnt_Parametro)

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