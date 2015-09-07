Imports SGCVU.BE
Imports SGCVU.DA

Public Class clsRolFlujos

    Public Shared Function fn_Select_RolFlujo_ByIdRolFlujo(ByVal pi_BERolFlujo As BE_RolFlujos) As List(Of BE_RolFlujos)
        Try
            Dim liBEParametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@RolFlujoId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BERolFlujo.int_RolFlujoId.GetType)
                .strSourceColumn = pi_BERolFlujo.int_RolFlujoId
            End With
            liBEParametro.Add(EntParametroSQL)

            Dim liBERolFlujo As New List(Of BE_RolFlujos)

            clsSQLServer.sb_EjecutarSelect("cnBonos", "P_BRR5_S_Rol_Flujos_RolFlujoId", True, liBERolFlujo, liBEParametro)

            Return liBERolFlujo
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Select_RolFlujo(ByVal pi_BERolFlujo As BE_RolFlujos) As List(Of BE_RolFlujos)
        Try
            Dim liBEParametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@RolFlujoDesc"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BERolFlujo.str_RolFlujoDesc.GetType)
                .strSourceColumn = pi_BERolFlujo.str_RolFlujoDesc
            End With
            liBEParametro.Add(EntParametroSQL)

            Dim liBERolFlujo As New List(Of BE_RolFlujos)

            clsSQLServer.sb_EjecutarSelect("cnBonos", "P_BRR5_S_Rol_Flujos", True, liBERolFlujo, liBEParametro)

            Return liBERolFlujo
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Update_RolFlujo(ByVal pi_BERolFlujo As BE_RolFlujos) As String
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@RolFlujoId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BERolFlujo.int_RolFlujoId.GetType)
                .strSourceColumn = pi_BERolFlujo.int_RolFlujoId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@RolFlujoDesc"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BERolFlujo.str_RolFlujoDesc.GetType)
                .strSourceColumn = pi_BERolFlujo.str_RolFlujoDesc
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@UsuarioModificacion"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BERolFlujo.str_UsuarioModificacion.GetType)
                .strSourceColumn = pi_BERolFlujo.str_UsuarioModificacion
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim strReturn As String = String.Empty
            Dim strParametroSalida As String = String.Empty

            Try
                strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnBonos", "P_BRR5_U_Rol_Flujos", True, strReturn, liEnt_Parametro)

                If Not strParametroSalida = String.Empty Then strReturn = strParametroSalida
            Catch ex As Exception
                strReturn = String.Empty
            End Try

            Return strReturn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Insert_RolFlujo(ByVal pi_BERolFlujo As BE_RolFlujos) As String
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@RolFlujoDesc"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BERolFlujo.str_RolFlujoDesc.GetType)
                .strSourceColumn = pi_BERolFlujo.str_RolFlujoDesc
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@UsuarioCreacion"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BERolFlujo.str_UsuarioCreacion.GetType)
                .strSourceColumn = pi_BERolFlujo.str_UsuarioCreacion
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim strReturn As String = String.Empty
            Dim strParametroSalida As String = String.Empty

            Try
                strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnBonos", "P_BRR5_I_Rol_Flujos", True, strReturn, liEnt_Parametro)
                If Not strParametroSalida = String.Empty Then strReturn = strParametroSalida
            Catch ex As Exception
                strReturn = String.Empty
            End Try

            Return strReturn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Delete_RolFlujo(ByVal pi_BERolFlujo As BE_RolFlujos) As String
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@RolFlujoId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BERolFlujo.int_RolFlujoId.GetType)
                .strSourceColumn = pi_BERolFlujo.int_RolFlujoId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim strReturn As String = String.Empty
            Dim strParametroSalida As String = String.Empty

            Try
                strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnBonos", "P_BRR5_D_Rol_Flujos", True, strReturn, liEnt_Parametro)

                If Not strParametroSalida = String.Empty Then strReturn = strParametroSalida
            Catch ex As Exception
                strReturn = String.Empty
            End Try

            Return strReturn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Select_RolFlujo_ByIdTipoFlujo(ByVal pi_BERolFlujo As BE_RolFlujos) As List(Of BE_RolFlujos)
        Try
            Dim liBEParametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@TipoFlujoId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BERolFlujo.int_TipoFlujoId.GetType)
                .strSourceColumn = pi_BERolFlujo.int_TipoFlujoId
            End With
            liBEParametro.Add(EntParametroSQL)

            Dim liBERolFlujo As New List(Of BE_RolFlujos)

            clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_Flujo_ByTipoFlujo", True, liBERolFlujo, liBEParametro)

            Return liBERolFlujo
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
