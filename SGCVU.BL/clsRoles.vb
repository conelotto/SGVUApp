Imports SGCVU.BE
Imports SGCVU.DA
Imports SGCVU.DTO

Public Class clsRoles

    Public Shared Function fn_Select_RolesByModulo(ByVal pi_BeRoles) As List(Of BE_Roles)
        Try

            Dim liBEParametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ModuloId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BeRoles.int_ModuloId.GetType)
                .strSourceColumn = pi_BeRoles.int_ModuloId
            End With
            liBEParametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@UsuarioId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BeRoles.int_UsuarioId.GetType)
                .strSourceColumn = pi_BeRoles.int_UsuarioId
            End With
            liBEParametro.Add(EntParametroSQL)

            Dim liBeRoles As New List(Of BE_Roles)
            clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_Roles_ByModuloId", True, liBeRoles, liBEParametro)
            Return liBeRoles

        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
