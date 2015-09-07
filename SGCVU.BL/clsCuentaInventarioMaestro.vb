Imports SGCVU.BE
Imports SGCVU.DA
Imports SGCVU.DTO

Public Class clsCuentaInventarioMaestro

    Public Shared Function fn_Select_CuentaInventario_ByFilter(ByVal Filter As DTO_CuentaInventario) As List(Of BE_CuentaInventarioMaestro)
        Try
            Dim liBEParametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@IdLineaVenta"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(Filter.intLinea.GetType)
                .strSourceColumn = Filter.intLinea
            End With
            liBEParametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@DescCuentaInventario"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(Filter.strDescripcion.GetType)
                .strSourceColumn = Filter.strDescripcion
            End With
            liBEParametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@IdCuenta"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(Filter.strCodigo.GetType)
                .strSourceColumn = Filter.strCodigo
            End With
            liBEParametro.Add(EntParametroSQL)

            Dim liBECuentaInventarioMaestro As New List(Of BE_CuentaInventarioMaestro)

            clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_CuentaInventarioMaestro_ByFilter", True, liBECuentaInventarioMaestro, liBEParametro)

            Return liBECuentaInventarioMaestro
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Update_CuentaInventario_LineaVenta(ByVal pi_BECuentaInventarioMaestro As BE_CuentaInventarioMaestro) As String
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@IdCuentaInventario"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BECuentaInventarioMaestro.int_IdCuentaInventario.GetType)
                .strSourceColumn = pi_BECuentaInventarioMaestro.int_IdCuentaInventario
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@IdLineaVenta"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BECuentaInventarioMaestro.int_IdLineaVenta.GetType)
                .strSourceColumn = pi_BECuentaInventarioMaestro.int_IdLineaVenta
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@UsuarioModificacion"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BECuentaInventarioMaestro.str_UsuarioModificacion.GetType)
                .strSourceColumn = pi_BECuentaInventarioMaestro.str_UsuarioModificacion
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim strReturn As String = String.Empty
            Dim strParametroSalida As String = String.Empty

            Try
                strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_U_CuentaInventarioMaestro", True, strReturn, liEnt_Parametro)

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
