Imports SGCVU.BE
Imports SGCVU.DA
Imports SGCVU.DTO

Public Class clsApoyo_Flujo

    Public Shared Function fn_Select_ApoyoFlujo_ByFilter(ByVal Filter As DTO_Apoyo_Flujo) As List(Of BE_Apoyo_Flujo)
        Try
            Dim liBEParametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@OrdenAsignada"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(Filter.strNumeroOrden.GetType)
                .strSourceColumn = Filter.strNumeroOrden
            End With
            liBEParametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ModeloProductoDesc"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(Filter.strModelo.GetType)
                .strSourceColumn = Filter.strModelo
            End With
            liBEParametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@SerieMaquina"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(Filter.strNumeroSerie.GetType)
                .strSourceColumn = Filter.strNumeroSerie
            End With
            liBEParametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ClienteDesc"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(Filter.strCliente.GetType)
                .strSourceColumn = Filter.strCliente
            End With
            liBEParametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@IdProgramaCAT"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(Filter.strPrograma.GetType)
                .strSourceColumn = Filter.strPrograma
            End With
            liBEParametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@EstadoInventario"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(Filter.strEstadoFacturacion.GetType)
                .strSourceColumn = Filter.strEstadoFacturacion
            End With
            liBEParametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@FlujoId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(Filter.strEstadoFlujo.GetType)
                .strSourceColumn = Filter.strEstadoFlujo
            End With
            liBEParametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@SolicitudId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(Filter.strEstadoSolicitud.GetType)
                .strSourceColumn = Filter.strEstadoSolicitud
            End With
            liBEParametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@LineaVenta"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(Filter.strLineaVenta.GetType)
                .strSourceColumn = Filter.strLineaVenta
            End With
            liBEParametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@UsuarioCuenta"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(Filter.strUsuarioCuentaInventario.GetType)
                .strSourceColumn = Filter.strUsuarioCuentaInventario
            End With
            liBEParametro.Add(EntParametroSQL)

            Dim liBEApoyoFlujo As New List(Of BE_Apoyo_Flujo)
            clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_ApoyoFlujo_ByFilter", True, liBEApoyoFlujo, liBEParametro)
            Return liBEApoyoFlujo

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Select_ApoyoFlujo_ByKey(ByVal pi_BEApoyoFlujo As BE_Apoyo_Flujo) As List(Of BE_Apoyo_Flujo)
        Try
            Dim liBEParametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ApoyoId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEApoyoFlujo.int_ApoyoId.GetType)
                .strSourceColumn = pi_BEApoyoFlujo.int_ApoyoId
            End With
            liBEParametro.Add(EntParametroSQL)

            Dim liBEApoyoFlujo As New List(Of BE_Apoyo_Flujo)
            clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_ApoyoFlujo_ApoyoId", True, liBEApoyoFlujo, liBEParametro)
            Return liBEApoyoFlujo

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Select_ApoyoFlujo_Washout_ByKey(ByVal Filter As DTO_SearchParameters) As List(Of BE_Apoyo_Flujo)
        Try
            Dim liBEParametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ApoyoId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(Filter.intApoyoId.GetType)
                .strSourceColumn = Filter.intApoyoId
            End With
            liBEParametro.Add(EntParametroSQL)

            Dim liBEApoyoFlujo As New List(Of BE_Apoyo_Flujo)
            clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_ApoyoFlujo_ApoyoId", True, liBEApoyoFlujo, liBEParametro)
            Return liBEApoyoFlujo

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Update_ApoyoFlujo_Claim(ByVal pi_BEApoyoFlujo As BE_Apoyo_Flujo) As String
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ApoyoId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEApoyoFlujo.int_ApoyoId.GetType)
                .strSourceColumn = pi_BEApoyoFlujo.int_ApoyoId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Usuario"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEApoyoFlujo.str_UserName.GetType)
                .strSourceColumn = pi_BEApoyoFlujo.str_UserName
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim strReturn As String = String.Empty
            Dim strParametroSalida As String = String.Empty

            Try
                strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_U_ApoyoFlujo_Claim", True, strReturn, liEnt_Parametro)

                If Not strParametroSalida = String.Empty Then strReturn = strParametroSalida
            Catch ex As Exception
                strReturn = String.Empty
            End Try

            Return strReturn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Update_ApoyoFlujo_CreditMemo(ByVal pi_BEApoyoFlujo As BE_Apoyo_Flujo) As String
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ApoyoId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEApoyoFlujo.int_ApoyoId.GetType)
                .strSourceColumn = pi_BEApoyoFlujo.int_ApoyoId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Usuario"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEApoyoFlujo.str_UserName.GetType)
                .strSourceColumn = pi_BEApoyoFlujo.str_UserName
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim strReturn As String = String.Empty
            Dim strParametroSalida As String = String.Empty

            Try
                strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_U_ApoyoFlujo_CreditMemo", True, strReturn, liEnt_Parametro)

                If Not strParametroSalida = String.Empty Then strReturn = strParametroSalida
            Catch ex As Exception
                strReturn = String.Empty
            End Try

            Return strReturn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Update_ApoyoFlujo_Washout(ByVal pi_BEApoyoFlujo As BE_Apoyo_Flujo) As String
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ApoyoId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEApoyoFlujo.int_ApoyoId.GetType)
                .strSourceColumn = pi_BEApoyoFlujo.int_ApoyoId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@WashoutBinary"
                .typDbType = DbType.Binary
                .byteSourceColumn = pi_BEApoyoFlujo.byte_Washout
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@WashoutFile"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEApoyoFlujo.str_WashoutArchivo.GetType)
                .strSourceColumn = pi_BEApoyoFlujo.str_WashoutArchivo
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@WashoutType"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEApoyoFlujo.str_WashoutEstado.GetType)
                .strSourceColumn = pi_BEApoyoFlujo.str_WashoutEstado
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Usuario"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEApoyoFlujo.str_UserName.GetType)
                .strSourceColumn = pi_BEApoyoFlujo.str_UserName
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim strReturn As String = String.Empty
            Dim strParametroSalida As String = String.Empty

            Try
                strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_U_ApoyoFlujo_Washout", True, strReturn, liEnt_Parametro)

                If Not strParametroSalida = String.Empty Then strReturn = strParametroSalida
            Catch ex As Exception
                strReturn = String.Empty
            End Try

            Return strReturn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Update_ApoyoFlujo_RegresarActividad(ByVal pi_BEApoyoFlujo As BE_Apoyo_Flujo) As String
        Try

            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ApoyoId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEApoyoFlujo.int_ApoyoId.GetType)
                .strSourceColumn = pi_BEApoyoFlujo.int_ApoyoId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@MaquinaApoyoId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEApoyoFlujo.int_MaquinaApoyoId.GetType)
                .strSourceColumn = pi_BEApoyoFlujo.int_MaquinaApoyoId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Usuario"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEApoyoFlujo.str_UserName.GetType)
                .strSourceColumn = pi_BEApoyoFlujo.str_UserName
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim strReturn As String = String.Empty
            Dim strParametroSalida As String = String.Empty

            Try
                strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_U_ApoyoFlujo_RegresarActividad", True, strReturn, liEnt_Parametro)

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
