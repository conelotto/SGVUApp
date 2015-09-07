Imports SGCVU.BE
Imports SGCVU.DA

Public Class clsUsuariosModulos

    Public Shared Function fn_Select_UsuariosModulos_ByLogin(ByVal pi_BEUsuarios As BE_Usuarios_Modulos) As List(Of BE_Usuarios_Modulos)
        Try
            Dim liBEParametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Usuario_Login"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUsuarios.str_UsuarioLogin.GetType)
                .strSourceColumn = pi_BEUsuarios.str_UsuarioLogin
            End With
            liBEParametro.Add(EntParametroSQL)

            Dim liBEUsuarios As New List(Of BE_Usuarios_Modulos)
            clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_UsuariosModulos_ByLogin", True, liBEUsuarios, liBEParametro)
            Return liBEUsuarios

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Insert_UsuariosModulos(ByVal pi_BEUsuarios As BE_Usuarios_Modulos) As String
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@UsuarioId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUsuarios.int_UsuarioId.GetType)
                .strSourceColumn = pi_BEUsuarios.int_UsuarioId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Module_Administracion"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUsuarios.bl_Module_Administracion.GetType)
                .strSourceColumn = pi_BEUsuarios.bl_Module_Administracion
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Module_ApoyoFabricante"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUsuarios.bl_Module_ApoyoFabricante.GetType)
                .strSourceColumn = pi_BEUsuarios.bl_Module_ApoyoFabricante
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Module_Bonos"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUsuarios.bl_Module_Bonos.GetType)
                .strSourceColumn = pi_BEUsuarios.bl_Module_Bonos
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Module_GestionInventario"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUsuarios.bl_Module_GestionInventario.GetType)
                .strSourceColumn = pi_BEUsuarios.bl_Module_GestionInventario
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Usuario"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUsuarios.str_UsuarioCreacion.GetType)
                .strSourceColumn = pi_BEUsuarios.str_UsuarioCreacion
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@TypeTransaction"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUsuarios.int_TypeTransaction.GetType)
                .strSourceColumn = pi_BEUsuarios.int_TypeTransaction
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim strReturn As String = String.Empty
            Dim strParametroSalida As String = String.Empty

            Try
                strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_I_Usuarios_Modulos", True, strReturn, liEnt_Parametro)
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
