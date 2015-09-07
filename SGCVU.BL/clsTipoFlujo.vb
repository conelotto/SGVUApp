Imports SGCVU.BE
Imports SGCVU.DA

Public Class clsTipoFlujo

    Public Shared Function fn_Select_TipoFlujo_ByIdTipoFlujo(ByVal pi_BETipoFlujo As BE_TipoFlujo) As List(Of BE_TipoFlujo)
        Try
            Dim liBEParametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@TipoFlujoId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BETipoFlujo.int_TipoFlujoId.GetType)
                .strSourceColumn = pi_BETipoFlujo.int_TipoFlujoId
            End With
            liBEParametro.Add(EntParametroSQL)

            Dim liBETipoFlujo As New List(Of BE_TipoFlujo)

            clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_Tipo_Flujo_TipoFlujoId", True, liBETipoFlujo, liBEParametro)

            Return liBETipoFlujo
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Select_TipoFlujo(ByVal pi_BETipoFlujo As BE_TipoFlujo) As List(Of BE_TipoFlujo)
        Try
            Dim liBEParametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@TipoFlujoDesc"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BETipoFlujo.str_TipoFlujoDesc.GetType)
                .strSourceColumn = pi_BETipoFlujo.str_TipoFlujoDesc
            End With
            liBEParametro.Add(EntParametroSQL)

            Dim liBETipoFlujo As New List(Of BE_TipoFlujo)

            clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_Tipo_Flujo", True, liBETipoFlujo, liBEParametro)

            Return liBETipoFlujo
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Update_TipoFlujo(ByVal pi_BETipoFlujo As BE_TipoFlujo) As String
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@TipoFlujoId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BETipoFlujo.int_TipoFlujoId.GetType)
                .strSourceColumn = pi_BETipoFlujo.int_TipoFlujoId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@TipoFlujoDesc"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BETipoFlujo.str_TipoFlujoDesc.GetType)
                .strSourceColumn = pi_BETipoFlujo.str_TipoFlujoDesc
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@UsuarioModificacion"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BETipoFlujo.str_UsuarioModificacion.GetType)
                .strSourceColumn = pi_BETipoFlujo.str_UsuarioModificacion
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim strReturn As String = String.Empty
            Dim strParametroSalida As String = String.Empty

            Try
                strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_U_Tipo_Flujo", True, strReturn, liEnt_Parametro)

                If Not strParametroSalida = String.Empty Then strReturn = strParametroSalida
            Catch ex As Exception
                strReturn = String.Empty
            End Try

            Return strReturn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Insert_TipoFlujo(ByVal pi_BETipoFlujo As BE_TipoFlujo) As String
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@TipoFlujoDesc"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BETipoFlujo.str_TipoFlujoDesc.GetType)
                .strSourceColumn = pi_BETipoFlujo.str_TipoFlujoDesc
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@UsuarioCreacion"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BETipoFlujo.str_UsuarioCreacion.GetType)
                .strSourceColumn = pi_BETipoFlujo.str_UsuarioCreacion
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim strReturn As String = String.Empty
            Dim strParametroSalida As String = String.Empty

            Try
                strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_I_Tipo_Flujo", True, strReturn, liEnt_Parametro)
                If Not strParametroSalida = String.Empty Then strReturn = strParametroSalida
            Catch ex As Exception
                strReturn = String.Empty
            End Try

            Return strReturn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Delete_TipoFlujo(ByVal pi_BETipoFlujo As BE_TipoFlujo) As String
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@TipoFlujoId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BETipoFlujo.int_TipoFlujoId.GetType)
                .strSourceColumn = pi_BETipoFlujo.int_TipoFlujoId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim strReturn As String = String.Empty
            Dim strParametroSalida As String = String.Empty

            Try
                strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_D_Tipo_Flujo", True, strReturn, liEnt_Parametro)

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
