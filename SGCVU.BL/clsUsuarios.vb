Imports SGCVU.BE
Imports SGCVU.DA
Imports SGCVU.DTO

Public Class clsUsuarios

    Public Shared Function fn_Select_Usuarios_ByFilter(ByVal Filter As DTO_Usuario) As List(Of BE_Usuarios)
        Try
            Dim liBEParametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Usuario_Apellidos"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(Filter.strApellidos.GetType)
                .strSourceColumn = Filter.strApellidos
            End With
            liBEParametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Usuario_Nombres"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(Filter.strNombres.GetType)
                .strSourceColumn = Filter.strNombres
            End With
            liBEParametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Usuario_Login"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(Filter.strUsuarioWindows.GetType)
                .strSourceColumn = Filter.strUsuarioWindows
            End With
            liBEParametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@CompaniaId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(Filter.strCompania.GetType)
                .strSourceColumn = Filter.strCompania
            End With
            liBEParametro.Add(EntParametroSQL)

            Dim liBeUsuarios As New List(Of BE_Usuarios)
            clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_Usuarios_ByFilter", True, liBeUsuarios, liBEParametro)

            Return liBeUsuarios
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Insert_Usuarios(ByVal pi_BEUsuarios As BE_Usuarios) As String
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@CompaniaId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUsuarios.str_CompaniaId.GetType)
                .strSourceColumn = pi_BEUsuarios.str_CompaniaId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Usuario_Nombres"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUsuarios.str_Usuario_Nombres.GetType)
                .strSourceColumn = pi_BEUsuarios.str_Usuario_Nombres
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Usuario_Apellidos"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUsuarios.str_Usuario_Apellidos.GetType)
                .strSourceColumn = pi_BEUsuarios.str_Usuario_Apellidos
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Usuario_Login"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUsuarios.str_Usuario_Login.GetType)
                .strSourceColumn = pi_BEUsuarios.str_Usuario_Login
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Usuario_Email"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUsuarios.str_Usuario_Email.GetType)
                .strSourceColumn = pi_BEUsuarios.str_Usuario_Email
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@NroPersonal"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUsuarios.str_NroPersonal.GetType)
                .strSourceColumn = pi_BEUsuarios.str_NroPersonal
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@CodigoAdrian"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUsuarios.str_CodigoAdrian.GetType)
                .strSourceColumn = pi_BEUsuarios.str_CodigoAdrian
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@CodigoSAP"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUsuarios.str_CodigoSAP.GetType)
                .strSourceColumn = pi_BEUsuarios.str_CodigoSAP
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Funcion"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUsuarios.str_Funcion.GetType)
                .strSourceColumn = pi_BEUsuarios.str_Funcion
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Cargo"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUsuarios.str_Cargo.GetType)
                .strSourceColumn = pi_BEUsuarios.str_Cargo
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@UsuarioCreacion"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUsuarios.str_UsuarioCreacion.GetType)
                .strSourceColumn = pi_BEUsuarios.str_UsuarioCreacion
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim strReturn As String = String.Empty
            Dim strParametroSalida As String = String.Empty

            Try
                strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_I_Usuarios", True, strReturn, liEnt_Parametro)
                If Not strParametroSalida = String.Empty Then strReturn = strParametroSalida
            Catch ex As Exception
                strReturn = String.Empty
            End Try

            Return strReturn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Disabled_Usuarios(ByVal pi_BEUsuarios As BE_Usuarios) As String
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
                .strParameterName = "@Usuario"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUsuarios.str_UsuarioModificacion.GetType)
                .strSourceColumn = pi_BEUsuarios.str_UsuarioModificacion
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim strReturn As String = String.Empty
            Dim strParametroSalida As String = String.Empty

            Try
                strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_D_UsuariosDeshabilitar", True, strReturn, liEnt_Parametro)

                If Not strParametroSalida = String.Empty Then strReturn = strParametroSalida
            Catch ex As Exception
                strReturn = String.Empty
            End Try

            Return strReturn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Delete_Usuarios(ByVal pi_BEUsuarios As BE_Usuarios) As String
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
                .strParameterName = "@Usuario"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUsuarios.str_Usuario_Login.GetType)
                .strSourceColumn = pi_BEUsuarios.str_Usuario_Login
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim strReturn As String = String.Empty
            Dim strParametroSalida As String = String.Empty

            Try
                strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_D_Usuarios", True, strReturn, liEnt_Parametro)

                If Not strParametroSalida = String.Empty Then strReturn = strParametroSalida
            Catch ex As Exception
                strReturn = String.Empty
            End Try

            Return strReturn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Update_Usuarios(ByVal pi_BEUsuarios As BE_Usuarios) As String
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
                .strParameterName = "@CompaniaId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUsuarios.str_CompaniaId.GetType)
                .strSourceColumn = pi_BEUsuarios.str_CompaniaId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Usuario_Nombres"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUsuarios.str_Usuario_Nombres.GetType)
                .strSourceColumn = pi_BEUsuarios.str_Usuario_Nombres
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Usuario_Apellidos"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUsuarios.str_Usuario_Apellidos.GetType)
                .strSourceColumn = pi_BEUsuarios.str_Usuario_Apellidos
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Usuario_Login"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUsuarios.str_Usuario_Login.GetType)
                .strSourceColumn = pi_BEUsuarios.str_Usuario_Login
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Usuario_Email"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUsuarios.str_Usuario_Email.GetType)
                .strSourceColumn = pi_BEUsuarios.str_Usuario_Email
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@NroPersonal"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUsuarios.str_NroPersonal.GetType)
                .strSourceColumn = pi_BEUsuarios.str_NroPersonal
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@CodigoAdrian"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUsuarios.str_CodigoAdrian.GetType)
                .strSourceColumn = pi_BEUsuarios.str_CodigoAdrian
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@CodigoSAP"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUsuarios.str_CodigoSAP.GetType)
                .strSourceColumn = pi_BEUsuarios.str_CodigoSAP
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Funcion"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUsuarios.str_Funcion.GetType)
                .strSourceColumn = pi_BEUsuarios.str_Funcion
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Cargo"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUsuarios.str_Cargo.GetType)
                .strSourceColumn = pi_BEUsuarios.str_Cargo
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@UsuarioModificacion"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUsuarios.str_UsuarioModificacion.GetType)
                .strSourceColumn = pi_BEUsuarios.str_UsuarioModificacion
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim strReturn As String = String.Empty
            Dim strParametroSalida As String = String.Empty

            Try
                strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_U_Usuarios", True, strReturn, liEnt_Parametro)

                If Not strParametroSalida = String.Empty Then strReturn = strParametroSalida
            Catch ex As Exception
                strReturn = String.Empty
            End Try

            Return strReturn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Select_Usuarios(ByVal pi_BEUsuarios As BE_Usuarios) As List(Of BE_Usuarios)
        Try
            Dim liBEParametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Usuario_Login"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUsuarios.str_Usuario_Login.GetType)
                .strSourceColumn = pi_BEUsuarios.str_Usuario_Login
            End With
            liBEParametro.Add(EntParametroSQL)

            Dim liBELineaVentaMaestro As New List(Of BE_Usuarios)

            clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_Usuarios", True, liBELineaVentaMaestro, liBEParametro)

            Return liBELineaVentaMaestro
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Select_UsuariosCuentasInventario(ByVal pi_BEUsuarios As BE_CuentaUsuario) As List(Of BE_CuentaUsuario)
        Try
            Dim liBEParametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Usuario_Login"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUsuarios.str_IdUsuario.GetType)
                .strSourceColumn = pi_BEUsuarios.str_IdUsuario
            End With
            liBEParametro.Add(EntParametroSQL)

            Dim liBELineaVentaMaestro As New List(Of BE_CuentaUsuario)

            clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_CuentaUsuario", True, liBELineaVentaMaestro, liBEParametro)

            Return liBELineaVentaMaestro
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Insert_UsuariosCuentasInventario(ByVal pi_BEUsuarios As BE_Usuarios) As String
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@UsuarioCuenta"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUsuarios.str_Usuario_Login.GetType)
                .strSourceColumn = pi_BEUsuarios.str_Usuario_Login
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Usuario"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUsuarios.str_UsuarioCreacion.GetType)
                .strSourceColumn = pi_BEUsuarios.str_UsuarioCreacion
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim strReturn As String = String.Empty
            Dim strParametroSalida As String = String.Empty

            Try
                strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_I_Usuarios_CuentaInventario", True, strReturn, liEnt_Parametro)
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
