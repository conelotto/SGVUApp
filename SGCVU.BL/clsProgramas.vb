Imports SGCVU.BE
Imports SGCVU.DA
Imports SGCVU.DTO

Public Class clsProgramas

    Public Shared Function fn_Select_Programas_All() As List(Of BE_Programas)
        Try
            Dim liBEParametro As New List(Of clsEntidad_ParametroSQL)
            Dim liBeProgramas As New List(Of BE_Programas)

            clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_Programas", True, liBeProgramas, liBEParametro)

            Return liBeProgramas
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Select_Programas_ByFilter(ByVal Filter As DTO_Programas) As List(Of BE_Programas)
        Try
            Dim liBEParametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@IdProgramaCAT"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(Filter.strCodigo.GetType)
                .strSourceColumn = Filter.strCodigo
            End With
            liBEParametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@DescPrograma"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(Filter.strDescripcion.GetType)
                .strSourceColumn = Filter.strDescripcion
            End With
            liBEParametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@RolFlujoId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(Filter.intFlujo.GetType)
                .strSourceColumn = Filter.intFlujo
            End With
            liBEParametro.Add(EntParametroSQL)

            'EntParametroSQL = New clsEntidad_ParametroSQL
            'With EntParametroSQL
            '    .strParameterName = "@ProgramaStatus"
            '    .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(Filter.intEstado.GetType)
            '    .strSourceColumn = Filter.intEstado
            'End With
            'liBEParametro.Add(EntParametroSQL)

            Dim liBeProgramas As New List(Of BE_Programas)
            clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_Programas_ByFilter", True, liBeProgramas, liBEParametro)
            Return liBeProgramas

        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Shared Function fn_Select_Programas_Solicitud(ByVal pi_BeProgramas) As List(Of BE_Programas)
        Try

            Dim liBEParametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ApoyoId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BeProgramas.int_ApoyoId.GetType)
                .strSourceColumn = pi_BeProgramas.int_ApoyoId
            End With
            liBEParametro.Add(EntParametroSQL)

            Dim liBeProgramas As New List(Of BE_Programas)
            clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_Programas_Solicitud", True, liBeProgramas, liBEParametro)
            Return liBeProgramas

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Select_Programas_ById(ByVal pi_BeProgramas As BE_Programas) As List(Of BE_Programas)
        Try

            Dim liBEParametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ProgramasId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BeProgramas.int_ProgramasId.GetType)
                .strSourceColumn = pi_BeProgramas.int_ProgramasId
            End With
            liBEParametro.Add(EntParametroSQL)

            Dim liBeProgramas As New List(Of BE_Programas)
            clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_Programas_Solicitud", True, liBeProgramas, liBEParametro)
            Return liBeProgramas

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Insert_Programas(ByVal pi_BEProgramas As BE_Programas) As String
        Try

            Dim liBEParametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@IdProgramaCAT"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEProgramas.str_IdProgramaCAT.GetType)
                .strSourceColumn = pi_BEProgramas.str_IdProgramaCAT
            End With
            liBEParametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@RolFlujoId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEProgramas.int_RolFlujoId.GetType)
                .strSourceColumn = pi_BEProgramas.int_RolFlujoId
            End With
            liBEParametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@DescPrograma"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEProgramas.str_DescPrograma.GetType)
                .strSourceColumn = pi_BEProgramas.str_DescPrograma
            End With
            liBEParametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@FechaInicio"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEProgramas.det_FechaInicio.GetType)
                .strSourceColumn = pi_BEProgramas.det_FechaInicio
            End With
            liBEParametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@FechaFin"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEProgramas.det_FechaFin.GetType)
                .strSourceColumn = pi_BEProgramas.det_FechaFin
            End With
            liBEParametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@UsuarioCreacion"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEProgramas.str_UsuarioCreacion.GetType)
                .strSourceColumn = pi_BEProgramas.str_UsuarioCreacion
            End With
            liBEParametro.Add(EntParametroSQL)

            Dim strReturn As String = String.Empty
            Dim strParametroSalida As String = String.Empty

            Try
                strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_I_Programas", True, strReturn, liBEParametro)

                If Not strParametroSalida = String.Empty Then strReturn = strParametroSalida
            Catch ex As Exception
                strReturn = String.Empty
            End Try

            Return strReturn

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Update_Programas(ByVal pi_BEProgramas As BE_Programas) As String
        Try

            Dim liBEParametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ProgramasId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEProgramas.int_ProgramasId.GetType)
                .strSourceColumn = pi_BEProgramas.int_ProgramasId
            End With
            liBEParametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@IdProgramaCAT"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEProgramas.str_IdProgramaCAT.GetType)
                .strSourceColumn = pi_BEProgramas.str_IdProgramaCAT
            End With
            liBEParametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@RolFlujoId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEProgramas.int_RolFlujoId.GetType)
                .strSourceColumn = pi_BEProgramas.int_RolFlujoId
            End With
            liBEParametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@DescPrograma"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEProgramas.str_DescPrograma.GetType)
                .strSourceColumn = pi_BEProgramas.str_DescPrograma
            End With
            liBEParametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@FechaInicio"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEProgramas.det_FechaInicio.GetType)
                .strSourceColumn = pi_BEProgramas.det_FechaInicio
            End With
            liBEParametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@FechaFin"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEProgramas.det_FechaFin.GetType)
                .strSourceColumn = pi_BEProgramas.det_FechaFin
            End With
            liBEParametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@UsuarioModificacion"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEProgramas.str_UsuarioModificacion.GetType)
                .strSourceColumn = pi_BEProgramas.str_UsuarioModificacion
            End With
            liBEParametro.Add(EntParametroSQL)

            Dim strReturn As String = String.Empty
            Dim strParametroSalida As String = String.Empty

            Try
                strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_U_Programas", True, strReturn, liBEParametro)

                If Not strParametroSalida = String.Empty Then strReturn = strParametroSalida
            Catch ex As Exception
                strReturn = String.Empty
            End Try

            Return strReturn

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Delete_Programas(ByVal pi_BEProgramas As BE_Programas) As String
        Try

            Dim liBEParametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ProgramasId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEProgramas.int_ProgramasId.GetType)
                .strSourceColumn = pi_BEProgramas.int_ProgramasId
            End With
            liBEParametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Usuario"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEProgramas.str_UsuarioModificacion.GetType)
                .strSourceColumn = pi_BEProgramas.str_UsuarioModificacion
            End With
            liBEParametro.Add(EntParametroSQL)

            Dim strReturn As String = String.Empty
            Dim strParametroSalida As String = String.Empty

            Try
                strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_D_Programas", True, strReturn, liBEParametro)

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
