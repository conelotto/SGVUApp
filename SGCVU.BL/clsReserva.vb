Imports SGCVU.BE
Imports SGCVU.DA
Imports SGCVU.DTO

Public Class clsReserva

    Public Shared Function fn_Insert_Reserva(ByVal pi_BEReserva As BE_Reserva, ByVal pi_BEAlerta As BE_Alertas) As String
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@OrdenAsignada"
                .typDbType = DbType.String
                .strSourceColumn = pi_BEReserva.str_OrdenAsignada
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ReservaClienteId"
                .typDbType = DbType.String
                .strSourceColumn = pi_BEReserva.str_ReservaClienteId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ReservaVendedorId"
                .typDbType = DbType.String
                .strSourceColumn = pi_BEReserva.str_ReservaVendedorId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ReservaSucursal"
                .typDbType = DbType.String
                .strSourceColumn = pi_BEReserva.str_ReservaSucursal
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ReservaFecha"
                .typDbType = DbType.DateTime
                .strSourceColumn = pi_BEReserva.det_ReservaFecha
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ValidezReservaFecha"
                .typDbType = DbType.DateTime
                .strSourceColumn = pi_BEReserva.det_ValidezReservaFecha
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ReservaUsuarioId"
                .typDbType = DbType.String
                .strSourceColumn = pi_BEReserva.str_ReservaUsuarioId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@UsuarioCreacion"
                .typDbType = DbType.String
                .strSourceColumn = pi_BEReserva.str_UsuarioCreacion
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ClienteDesc"
                .typDbType = DbType.String
                .strSourceColumn = pi_BEReserva.str_ClienteDesc
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@VendedorDesc"
                .typDbType = DbType.String
                .strSourceColumn = pi_BEReserva.str_VendedorDesc
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Oportunidad"
                .typDbType = DbType.String
                .strSourceColumn = pi_BEReserva.str_Oportunidad
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Observaciones"
                .typDbType = DbType.String
                .strSourceColumn = pi_BEReserva.str_Observaciones
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Asunto"
                .typDbType = DbType.String
                .strSourceColumn = pi_BEAlerta.str_MensajeAsunto
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Contenido"
                .typDbType = DbType.String
                .strSourceColumn = pi_BEAlerta.str_MensajeContenido
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim strReturn As String = String.Empty
            Dim strParametroSalida As String = String.Empty

            Try
                strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_I_Reserva", True, strReturn, liEnt_Parametro)

                If Not strParametroSalida = String.Empty Then strReturn = strParametroSalida
            Catch ex As Exception
                strReturn = String.Empty
            End Try

            Return strReturn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Update_Anular_Reserva(ByVal pi_strOrden As String, ByVal pi_strEstadoMaquina As String, ByVal pi_BEAlerta As BE_Alertas) As String
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Orden"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_strOrden.GetType)
                .strSourceColumn = pi_strOrden
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@EstadoMaquina"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_strEstadoMaquina.GetType)
                .strSourceColumn = pi_strEstadoMaquina
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Usuario"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEAlerta.str_UsuarioRegistro.GetType)
                .strSourceColumn = pi_BEAlerta.str_UsuarioRegistro
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Asunto"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEAlerta.str_MensajeAsunto.GetType)
                .strSourceColumn = pi_BEAlerta.str_MensajeAsunto
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Contenido"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEAlerta.str_MensajeContenido.GetType)
                .strSourceColumn = pi_BEAlerta.str_MensajeContenido
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim strReturn As String = String.Empty
            Dim strParametroSalida As String = String.Empty

            Try
                strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_U_Reserva_Anular", True, strReturn, liEnt_Parametro)

                If Not strParametroSalida = String.Empty Then strReturn = strParametroSalida
            Catch ex As Exception
                strReturn = String.Empty
            End Try

            Return strReturn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Select_Historial_Reserva(ByVal pi_strOrden As String, ByVal pi_strEstado As String) As List(Of DTO_Reserva)
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Orden"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_strOrden.GetType)
                .strSourceColumn = pi_strOrden
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Estado"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_strEstado.GetType)
                .strSourceColumn = pi_strEstado
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Return clsSQLServer.fn_EjecutarSelect(Of DTO_Reserva)("cnFSASGCVU", "P_BRR5_S_Reserva_Historial", True, liEnt_Parametro)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Select_Reserva(ByVal pi_intReservaId As Integer) As DTO_Reserva
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ReservaId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_intReservaId.GetType)
                .strSourceColumn = pi_intReservaId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim DTOReserva As DTO_Reserva = Nothing
            Dim liDTOReserva As List(Of DTO_Reserva) = clsSQLServer.fn_EjecutarSelect(Of DTO_Reserva)("cnFSASGCVU", "P_BRR5_S_Reserva", True, liEnt_Parametro)

            If liDTOReserva.Count > 0 Then
                DTOReserva = liDTOReserva(0)
            End If

            Return DTOReserva
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Update_Reserva(ByVal pi_BEReserva As BE_Reserva) As String
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ReservaId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEReserva.int_ReservaId.GetType)
                .strSourceColumn = pi_BEReserva.int_ReservaId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ValidezReservaFecha"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEReserva.det_ValidezReservaFecha.GetType)
                .strSourceColumn = pi_BEReserva.det_ValidezReservaFecha
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@UsuarioModificacion"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEReserva.str_UsuarioModificacion.GetType)
                .strSourceColumn = pi_BEReserva.str_UsuarioModificacion
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Observaciones"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEReserva.str_Observaciones.GetType)
                .strSourceColumn = pi_BEReserva.str_Observaciones
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim strReturn As String = String.Empty
            Dim strParametroSalida As String = String.Empty

            Try
                strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_U_Reserva", True, strReturn, liEnt_Parametro)

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