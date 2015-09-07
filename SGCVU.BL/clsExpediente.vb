Imports SGCVU.BE
Imports System.Configuration
Imports System.String
Imports SGCVU.DA
Imports System.Dynamic
Imports SGCVU.DTO

Public Class clsExpediente

    Public Shared Function fn_SelectMaquina_ListaExpediente(ByVal pi_BEExpediente As BE_Expediente) As List(Of BE_Expediente)
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

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@IdActividad"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEExpediente.int_ActividadId.GetType)
                .strSourceColumn = pi_BEExpediente.int_ActividadId
            End With
            liBEParametro.Add(EntParametroSQL)

            Dim liBEExpediente As New List(Of BE_Expediente)

            clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_EXPEDIENTE", True, liBEExpediente, liBEParametro)

            Return liBEExpediente
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Shared Function fn_Insert_ListaIncidente(ByVal pi_BEExpediente As BE_Expediente) As String
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@UsuarioId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEExpediente.int_UsuarioId.GetType)
                .strSourceColumn = pi_BEExpediente.int_UsuarioId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ActividadId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEExpediente.int_ActividadId.GetType)
                .strSourceColumn = pi_BEExpediente.int_ActividadId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@RolFlujoId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEExpediente.int_RolFlujoId.GetType)
                .strSourceColumn = pi_BEExpediente.int_RolFlujoId
            End With
            liEnt_Parametro.Add(EntParametroSQL)


            Dim strReturn As String = String.Empty
            Dim strParametroSalida As String = String.Empty

            Try
                strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_I_EXPEDIENTE", True, strReturn, liEnt_Parametro)

                If Not strParametroSalida = String.Empty Then strReturn = strParametroSalida
            Catch ex As Exception
                strReturn = String.Empty
            End Try

            Return strReturn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Update_ListaExpediente(ByVal pBEExpediente As BE_Expediente) As String
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ActividadId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pBEExpediente.int_ActividadId.GetType)
                .strSourceColumn = pBEExpediente.int_ActividadId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@UsuarioId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pBEExpediente.int_UsuarioId.GetType)
                .strSourceColumn = pBEExpediente.int_UsuarioId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ExpedienteId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pBEExpediente.int_ExpedienteId.GetType)
                .strSourceColumn = pBEExpediente.int_ExpedienteId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim strReturn As String = String.Empty
            Dim strParametroSalida As String = String.Empty

            Try
                strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_U_Expediente", True, strReturn, liEnt_Parametro)

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

    Public Shared Function fn_Select_ExpedienteArchivo(ByVal pi_BEExpedienteArchivo As BE_ExpedienteArchivo) As List(Of BE_ExpedienteArchivo)
        Try
            Dim liBEParametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ExpedienteId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEExpedienteArchivo.intExpedienteId.GetType)
                .strSourceColumn = pi_BEExpedienteArchivo.intExpedienteId
            End With
            liBEParametro.Add(EntParametroSQL)

            Dim liBEExpedienteArchivo As New List(Of BE_ExpedienteArchivo)

            clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_ExpedienteArchivo", True, liBEExpedienteArchivo, liBEParametro)

            Return liBEExpedienteArchivo

        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
