Imports SGCVU.BE
Imports SGCVU.DA
Imports SGCVU.DTO

Public Class clsLineaVentaMaestro

    Public Shared Function fn_Select_LineaVenta_All() As List(Of BE_LineaVentaMaestro)
        Try
            Dim liBEParametro As New List(Of clsEntidad_ParametroSQL)
            Dim liBeLineaVenta As New List(Of BE_LineaVentaMaestro)

            clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_LineaVenta", True, liBeLineaVenta, liBEParametro)

            Return liBeLineaVenta
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Select_LineaVenta_ByFilter(ByVal Filter As DTO_LineaVenta) As List(Of BE_LineaVentaMaestro)
        Try
            Dim liBEParametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@DescLineaVenta"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(Filter.DescLineaVenta.GetType)
                .strSourceColumn = Filter.DescLineaVenta
            End With
            liBEParametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@NombreFirma"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(Filter.NombreFirma.GetType)
                .strSourceColumn = Filter.NombreFirma
            End With
            liBEParametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@CargoFirma"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(Filter.CargoFirma.GetType)
                .strSourceColumn = Filter.CargoFirma
            End With
            liBEParametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@IdCompania"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(Filter.IdCompania.GetType)
                .strSourceColumn = Filter.IdCompania
            End With
            liBEParametro.Add(EntParametroSQL)

            Dim liBeLinea As New List(Of BE_LineaVentaMaestro)
            clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_LineaVenta_ByFilter", True, liBeLinea, liBEParametro)

            Return liBeLinea
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Select_LineaVentaMaestro_ByIdLineaVenta(ByVal pi_BELineaVentaMaestro As BE_LineaVentaMaestro) As List(Of BE_LineaVentaMaestro)
        Try
            Dim liBEParametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@IdLineaVenta"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BELineaVentaMaestro.int_IdLineaVenta.GetType)
                .strSourceColumn = pi_BELineaVentaMaestro.int_IdLineaVenta
            End With
            liBEParametro.Add(EntParametroSQL)

            Dim liBELineaVentaMaestro As New List(Of BE_LineaVentaMaestro)

            clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_LINEAVENTA_MAESTRO_IdLineaVenta", True, liBELineaVentaMaestro, liBEParametro)

            Return liBELineaVentaMaestro
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Select_LineaVentaMaestro(ByVal pi_BELineaVentaMaestro As BE_LineaVentaMaestro) As List(Of BE_LineaVentaMaestro)
        Try
            Dim liBEParametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@DescLineaVenta"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BELineaVentaMaestro.str_DescLineaVenta.GetType)
                .strSourceColumn = pi_BELineaVentaMaestro.str_DescLineaVenta
            End With
            liBEParametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@NombreFirma"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BELineaVentaMaestro.str_NombreFirma.GetType)
                .strSourceColumn = pi_BELineaVentaMaestro.str_NombreFirma
            End With
            liBEParametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@CargoFirma"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BELineaVentaMaestro.str_CargoFirma.GetType)
                .strSourceColumn = pi_BELineaVentaMaestro.str_CargoFirma
            End With
            liBEParametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@IdCompania"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BELineaVentaMaestro.str_IdCompania.GetType)
                .strSourceColumn = pi_BELineaVentaMaestro.str_IdCompania
            End With
            liBEParametro.Add(EntParametroSQL)

            Dim liBELineaVentaMaestro As New List(Of BE_LineaVentaMaestro)

            clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_LINEAVENTA_MAESTRO", True, liBELineaVentaMaestro, liBEParametro)

            Return liBELineaVentaMaestro
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Update_LineaVentaMaestro(ByVal pi_BELineaVentaMaestro As BE_LineaVentaMaestro) As String
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@IdLineaVenta"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BELineaVentaMaestro.int_IdLineaVenta.GetType)
                .strSourceColumn = pi_BELineaVentaMaestro.int_IdLineaVenta
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@IdCompania"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BELineaVentaMaestro.str_IdCompania.GetType)
                .strSourceColumn = pi_BELineaVentaMaestro.str_IdCompania
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@CargoFirma"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BELineaVentaMaestro.str_CargoFirma.GetType)
                .strSourceColumn = pi_BELineaVentaMaestro.str_CargoFirma
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@DescLineaVenta"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BELineaVentaMaestro.str_DescLineaVenta.GetType)
                .strSourceColumn = pi_BELineaVentaMaestro.str_DescLineaVenta
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@NombreImagenFirma"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BELineaVentaMaestro.str_NombreImagenFirma.GetType)
                .strSourceColumn = pi_BELineaVentaMaestro.str_NombreImagenFirma
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ImagenFirma"
                .typDbType = DbType.Binary
                .byteSourceColumn = pi_BELineaVentaMaestro.byte_ImagenFirma
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@NombreFirma"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BELineaVentaMaestro.str_NombreFirma.GetType)
                .strSourceColumn = pi_BELineaVentaMaestro.str_NombreFirma
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@DiasReserva"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BELineaVentaMaestro.int_DiasReserva.GetType)
                .strSourceColumn = pi_BELineaVentaMaestro.int_DiasReserva
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@UsuarioModificacion"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BELineaVentaMaestro.str_UsuarioModificacion.GetType)
                .strSourceColumn = pi_BELineaVentaMaestro.str_UsuarioModificacion
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Washout"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BELineaVentaMaestro.bl_Washout.GetType)
                .strSourceColumn = pi_BELineaVentaMaestro.bl_Washout
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@TipoTransaccion"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BELineaVentaMaestro.int_TipoTransaccion.GetType)
                .strSourceColumn = pi_BELineaVentaMaestro.int_TipoTransaccion
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim strReturn As String = String.Empty
            Dim strParametroSalida As String = String.Empty

            Try
                strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_U_LineaVenta", True, strReturn, liEnt_Parametro)

                If Not strParametroSalida = String.Empty Then strReturn = strParametroSalida
            Catch ex As Exception
                strReturn = String.Empty
            End Try

            Return strReturn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Insert_LineaVentaMaestro(ByVal pi_BELineaVentaMaestro As BE_LineaVentaMaestro) As String
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@IdCompania"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BELineaVentaMaestro.str_IdCompania.GetType)
                .strSourceColumn = pi_BELineaVentaMaestro.str_IdCompania
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@CargoFirma"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BELineaVentaMaestro.str_CargoFirma.GetType)
                .strSourceColumn = pi_BELineaVentaMaestro.str_CargoFirma
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@DescLineaVenta"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BELineaVentaMaestro.str_DescLineaVenta.GetType)
                .strSourceColumn = pi_BELineaVentaMaestro.str_DescLineaVenta
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@NombreImagenFirma"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BELineaVentaMaestro.str_NombreImagenFirma.GetType)
                .strSourceColumn = pi_BELineaVentaMaestro.str_NombreImagenFirma
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ImagenFirma"
                .typDbType = DbType.Binary
                .byteSourceColumn = pi_BELineaVentaMaestro.byte_ImagenFirma
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@NombreFirma"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BELineaVentaMaestro.str_NombreFirma.GetType)
                .strSourceColumn = pi_BELineaVentaMaestro.str_NombreFirma
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@DiasReserva"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BELineaVentaMaestro.int_DiasReserva.GetType)
                .strSourceColumn = pi_BELineaVentaMaestro.int_DiasReserva
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Washout"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BELineaVentaMaestro.bl_Washout.GetType)
                .strSourceColumn = pi_BELineaVentaMaestro.bl_Washout
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@UsuarioCreacion"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BELineaVentaMaestro.str_UsuarioCreacion.GetType)
                .strSourceColumn = pi_BELineaVentaMaestro.str_UsuarioCreacion
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim strReturn As String = String.Empty
            Dim strParametroSalida As String = String.Empty

            Try
                strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_I_LineaVenta", True, strReturn, liEnt_Parametro)
                If Not strParametroSalida = String.Empty Then strReturn = strParametroSalida
            Catch ex As Exception
                strReturn = String.Empty
            End Try

            Return strReturn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Delete_LineaVentaMaestro(ByVal pi_BELineaVentaMaestro As BE_LineaVentaMaestro) As String
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@IdLineaVenta"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BELineaVentaMaestro.int_IdLineaVenta.GetType)
                .strSourceColumn = pi_BELineaVentaMaestro.int_IdLineaVenta
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@UsuarioModificacion"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BELineaVentaMaestro.str_UsuarioModificacion.GetType)
                .strSourceColumn = pi_BELineaVentaMaestro.str_UsuarioModificacion
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim strReturn As String = String.Empty
            Dim strParametroSalida As String = String.Empty

            Try
                strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_D_LineaVenta", True, strReturn, liEnt_Parametro)

                If Not strParametroSalida = String.Empty Then strReturn = strParametroSalida
            Catch ex As Exception
                strReturn = String.Empty
            End Try

            Return strReturn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Select_DiasReserva_LineaVenta_Maquina(ByVal pi_strOrden) As Integer
        Try
            Dim liBEParametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Orden"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_strOrden.GetType)
                .strSourceColumn = pi_strOrden
            End With
            liBEParametro.Add(EntParametroSQL)

            Return clsSQLServer.fn_EjecutarSelect_Escalar("cnFSASGCVU", "P_BRR5_S_DiasReserva_LineaVenta_Maquina", True, liBEParametro)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class