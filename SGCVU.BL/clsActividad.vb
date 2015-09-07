Imports SGCVU.BE
Imports SGCVU.DA
Imports System.Data.Common

Public Class clsActividad

    Public Shared Function fn_ListaActividad_EstadoFlujo() As List(Of BE_Actividad)
        Try

            Dim _liBeParametro As New List(Of clsEntidad_ParametroSQL)
            Dim _liBeActividad As New List(Of BE_Actividad)

            clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_Actividad_EstadoFlujo", True, _liBeActividad, _liBeParametro)

            Return _liBeActividad

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Shared Function fn_ListaActividad_EstadoSolicitud() As List(Of BE_Actividad)
        Try

            Dim _liBeParametro As New List(Of clsEntidad_ParametroSQL)
            Dim _liBeActividad As New List(Of BE_Actividad)

            clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_Actividad_EstadoSolicitud", True, _liBeActividad, _liBeParametro)

            Return _liBeActividad

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    'fn_ListaActividad_BonoFlujo
    Public Shared Function fn_Select_Actividad_BonoFlujo() As List(Of BE_Actividad)
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)

            Return clsSQLServer.fn_EjecutarSelect(Of BE_Actividad)("cnFSASGCVU", "P_BRR5_S_Actividad_BonoFlujo", True, liEnt_Parametro)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Shared Function fn_Select_ListaActividad(ByVal pi_BE_Actividad As BE_Actividad) As List(Of BE_Actividad)
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            'Filtros
            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ActividadId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BE_Actividad.ActividadId.GetType)
                .strSourceColumn = pi_BE_Actividad.ActividadId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ActividadDesc"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BE_Actividad.str_ActividadDesc.GetType)
                .strSourceColumn = pi_BE_Actividad.str_ActividadDesc
            End With
            liEnt_Parametro.Add(EntParametroSQL)


            Dim liBEActividad As New List(Of BE_Actividad)

            clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_ACTIVIDAD", True, liBEActividad, liEnt_Parametro)

            Return liBEActividad
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
