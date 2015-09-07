Imports System.Configuration
Imports System.Data.Common
Imports System.IO
Imports Microsoft.Practices.EnterpriseLibrary.Common.Configuration
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports SGCVU.BE
Imports SGCVU.DTO

Public Class clsSQLServer

    Public Shared Sub sb_EjecutarSelect(ByVal pi_BD As String, ByVal pi_strProcedure As String, ByVal pi_bolProcedimiento As Boolean, _
                                         ByRef po_liEntidad As Object, ByVal pi_liEnt_Parametro As List(Of clsEntidad_ParametroSQL))
        Try
            Dim insDB As Database = fn_Obtener_Database(pi_BD)

            Dim dts As New DataSet

            If pi_bolProcedimiento Then
                Using cmmFactory As Common.DbCommand = insDB.GetStoredProcCommand(pi_strProcedure)
                    With insDB
                        If Not pi_liEnt_Parametro Is Nothing Then
                            For Each it As clsEntidad_ParametroSQL In pi_liEnt_Parametro
                                .AddInParameter(cmmFactory, it.strParameterName, it.typDbType, it.strSourceColumn)
                            Next it
                        End If

                        dts = .ExecuteDataSet(cmmFactory)
                    End With

                End Using
            Else
                Using cmmFactory As Common.DbCommand = insDB.GetSqlStringCommand(pi_strProcedure)
                    dts = insDB.ExecuteDataSet(cmmFactory)
                End Using
            End If

            fn_MapeoEntidad(dts.Tables(0), po_liEntidad)
        Catch ex As Exception
            'Dim rethrow As Boolean = ExceptionPolicy.HandleException(ex, "ExHandling")
            Throw ex
        End Try
    End Sub

    Public Shared Function fn_EjecutarUpdate_Insert_Delete(ByVal pi_BD As String, ByVal pi_strProcedure As String, ByVal pi_bolProcedimiento As Boolean, _
                                                           ByRef po_strReturn As String, ByVal pi_liEnt_Parametro As List(Of clsEntidad_ParametroSQL)) As String
        Try
            Dim strValorOutPut As String = String.Empty

            Dim insDB As Database = fn_Obtener_Database(pi_BD)

            Using cmmFactory As Common.DbCommand = insDB.GetStoredProcCommand(pi_strProcedure)
                With insDB
                    If Not pi_liEnt_Parametro Is Nothing Then
                        For Each it As clsEntidad_ParametroSQL In pi_liEnt_Parametro
                            If it.intDirection = ParameterDirection.Input Then
                                If it.typDbType = DbType.Binary Then
                                    .AddInParameter(cmmFactory, it.strParameterName, it.typDbType, it.byteSourceColumn)
                                Else
                                    .AddInParameter(cmmFactory, it.strParameterName, it.typDbType, it.strSourceColumn)
                                End If

                            ElseIf it.intDirection = ParameterDirection.Output Then
                                .AddOutParameter(cmmFactory, it.strParameterName, it.typDbType, it.intSize)
                            End If
                        Next it
                    End If

                    po_strReturn = .ExecuteScalar(cmmFactory)

                    For Each it As clsEntidad_ParametroSQL In pi_liEnt_Parametro
                        If it.intDirection = ParameterDirection.Output Then
                            strValorOutPut = .GetParameterValue(cmmFactory, it.strParameterName)
                        End If
                    Next it
                End With
            End Using

            Return strValorOutPut
        Catch ex As Exception
            'Dim rethrow As Boolean = ExceptionPolicy.HandleException(ex, "ExHandling")
            Throw ex
        End Try
    End Function

    Public Shared Function fn_EjecutarSelect(Of T)(ByVal pi_BD As String, ByVal pi_strProcedure As String, ByVal pi_bolProcedimiento As Boolean, _
                                         ByVal pi_liEnt_Parametro As List(Of clsEntidad_ParametroSQL))
        Try
            Dim insDB As Database = fn_Obtener_Database(pi_BD)

            Dim dts As New DataSet

            If pi_bolProcedimiento Then
                Using cmmFactory As Common.DbCommand = insDB.GetStoredProcCommand(pi_strProcedure)
                    With insDB
                        If Not pi_liEnt_Parametro Is Nothing Then
                            For Each it As clsEntidad_ParametroSQL In pi_liEnt_Parametro
                                .AddInParameter(cmmFactory, it.strParameterName, it.typDbType, it.strSourceColumn)
                            Next it
                        End If

                        dts = .ExecuteDataSet(cmmFactory)
                    End With

                End Using
            Else
                Using cmmFactory As Common.DbCommand = insDB.GetSqlStringCommand(pi_strProcedure)
                    dts = insDB.ExecuteDataSet(cmmFactory)
                End Using
            End If

            Return clsConvertDatatableToList.fn_ConvertToList(Of T)(dts.Tables(0))
        Catch ex As Exception
            'Dim rethrow As Boolean = ExceptionPolicy.HandleException(ex, "ExHandling")
            Throw ex
        End Try
    End Function

    Public Shared Function fn_EjecutarSelect_Escalar(ByVal pi_BD As String, ByVal pi_strProcedure As String, ByVal pi_bolProcedimiento As Boolean, _
                                         ByVal pi_liEnt_Parametro As List(Of clsEntidad_ParametroSQL))
        Try
            Dim insDB As Database = fn_Obtener_Database(pi_BD)

            Dim valorConsulta As Object

            If pi_bolProcedimiento Then
                Using cmmFactory As Common.DbCommand = insDB.GetStoredProcCommand(pi_strProcedure)
                    With insDB
                        If Not pi_liEnt_Parametro Is Nothing Then
                            For Each it As clsEntidad_ParametroSQL In pi_liEnt_Parametro
                                .AddInParameter(cmmFactory, it.strParameterName, it.typDbType, it.strSourceColumn)
                            Next it
                        End If

                        valorConsulta = .ExecuteScalar(cmmFactory)
                    End With

                End Using
            Else
                Using cmmFactory As Common.DbCommand = insDB.GetSqlStringCommand(pi_strProcedure)
                    valorConsulta = insDB.ExecuteScalar(cmmFactory)
                End Using
            End If

            Return valorConsulta
        Catch ex As Exception
            'Dim rethrow As Boolean = ExceptionPolicy.HandleException(ex, "ExHandling")
            Throw ex
        End Try
    End Function

    Private Shared Function fn_Obtener_Database(ByVal pi_BD As String)
        Dim insDB As Database = Nothing
        Select Case pi_BD
            Case "cnFSASGCVU"
                insDB = EnterpriseLibraryContainer.Current.GetInstance(Of Database)("cnFSASGCVU")
            Case "cnBIComercial"
                insDB = EnterpriseLibraryContainer.Current.GetInstance(Of Database)("cnBIComercial")
            Case "cnBIComStage"
                insDB = EnterpriseLibraryContainer.Current.GetInstance(Of Database)("cnBIComStage")
            Case "cnAdryan"
                insDB = EnterpriseLibraryContainer.Current.GetInstance(Of Database)("cnAdryan")
        End Select
        Return insDB
    End Function

#Region "Mapeo de Entidades"

    'Entidad Expediente Documentos Adjuntos
    Public Shared Sub fn_MapeoEntidad(ByVal pi_dtb As DataTable, ByRef po_liBeExpedienteDocAdjuntos As List(Of BE_Expediente_DocumentosAdjuntos))
        Try
            Dim liBeExpedienteDocAdjuntos As New List(Of BE_Expediente_DocumentosAdjuntos)
            Dim BeExpedienteDocAdjuntos As New BE_Expediente_DocumentosAdjuntos

            For Each drw As DataRow In pi_dtb.Rows
                BeExpedienteDocAdjuntos = New BE_Expediente_DocumentosAdjuntos
                With BeExpedienteDocAdjuntos

                    If IsDBNull(drw.Item("ExpedienteId")) Then .int_ExpedienteId = .int_ExpedienteId Else .int_ExpedienteId = drw.Item("ExpedienteId")
                    If IsDBNull(drw.Item("ApoyoId")) Then .int_ApoyoId = .int_ApoyoId Else .int_ApoyoId = drw.Item("ApoyoId")
                    If IsDBNull(drw.Item("ArchivoNombre")) Then .str_ArchivoNombre = .str_ArchivoNombre Else .str_ArchivoNombre = drw.Item("ArchivoNombre")
                    If IsDBNull(drw.Item("ArchivoAdjunto")) Then .byte_ArchivoAdjunto = .byte_ArchivoAdjunto Else .byte_ArchivoAdjunto = drw.Item("ArchivoAdjunto")
                    If IsDBNull(drw.Item("UsuarioCreacion")) Then .str_UsuarioCreacion = .str_UsuarioCreacion Else .str_UsuarioCreacion = drw.Item("UsuarioCreacion")
                    If IsDBNull(drw.Item("FechaCreacion")) Then .det_FechaCreacion = .det_FechaCreacion Else .det_FechaCreacion = drw.Item("FechaCreacion")

                End With

                liBeExpedienteDocAdjuntos.Add(BeExpedienteDocAdjuntos)
            Next drw

            po_liBeExpedienteDocAdjuntos = liBeExpedienteDocAdjuntos
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Entidad Expediente Programas
    Public Shared Sub fn_MapeoEntidad(ByVal pi_dtb As DataTable, ByRef po_liBeExpedienteProgramas As List(Of BE_Expediente_Programas))
        Try
            Dim liBeExpedienteProgramas As New List(Of BE_Expediente_Programas)
            Dim BeExpedienteProgramas As New BE_Expediente_Programas

            For Each drw As DataRow In pi_dtb.Rows
                BeExpedienteProgramas = New BE_Expediente_Programas
                With BeExpedienteProgramas

                    If IsDBNull(drw.Item("ExpPrograma_Id")) Then .int_ExpPrograma_Id = .int_ExpPrograma_Id Else .int_ExpPrograma_Id = drw.Item("ExpPrograma_Id")
                    If IsDBNull(drw.Item("ApoyoId")) Then .int_ApoyoId = .int_ApoyoId Else .int_ApoyoId = drw.Item("ApoyoId")
                    If IsDBNull(drw.Item("CompaniaId")) Then .str_CompaniaId = .str_CompaniaId Else .str_CompaniaId = drw.Item("CompaniaId")
                    If IsDBNull(drw.Item("OrdenAsignada")) Then .str_OrdenAsignada = .str_OrdenAsignada Else .str_OrdenAsignada = drw.Item("OrdenAsignada")
                    If IsDBNull(drw.Item("PedidoId")) Then .str_PedidoId = .str_PedidoId Else .str_PedidoId = drw.Item("PedidoId")
                    If IsDBNull(drw.Item("PosicionId")) Then .int_PosicionId = .int_PosicionId Else .int_PosicionId = drw.Item("PosicionId")
                    If IsDBNull(drw.Item("ProgramasId")) Then .int_ProgramasId = .int_ProgramasId Else .int_ProgramasId = drw.Item("ProgramasId")
                    If IsDBNull(drw.Item("ExpPrograma_NumeroClaim")) Then .str_ExpPrograma_NumeroClaim = .str_ExpPrograma_NumeroClaim Else .str_ExpPrograma_NumeroClaim = drw.Item("ExpPrograma_NumeroClaim")
                    If IsDBNull(drw.Item("ExpPrograma_FechaClaim")) Then .det_ExpPrograma_FechaClaim = .det_ExpPrograma_FechaClaim Else .det_ExpPrograma_FechaClaim = drw.Item("ExpPrograma_FechaClaim")
                    If IsDBNull(drw.Item("ExpPrograma_NumeroCreditMemo")) Then .str_ExpPrograma_NumeroCreditMemo = .str_ExpPrograma_NumeroCreditMemo Else .str_ExpPrograma_NumeroCreditMemo = drw.Item("ExpPrograma_NumeroCreditMemo")
                    If IsDBNull(drw.Item("ExpPrograma_FechaCreditMemo")) Then .det_ExpPrograma_FechaCreditMemo = .det_ExpPrograma_FechaCreditMemo Else .det_ExpPrograma_FechaCreditMemo = drw.Item("ExpPrograma_FechaCreditMemo")
                    If IsDBNull(drw.Item("ExpPrograma_MontoSolicitado")) Then .dec_ExpPrograma_MontoSolicitado = .dec_ExpPrograma_MontoSolicitado Else .dec_ExpPrograma_MontoSolicitado = drw.Item("ExpPrograma_MontoSolicitado")
                    If IsDBNull(drw.Item("ExpPrograma_MontoPagado")) Then .dec_ExpPrograma_MontoPagado = .dec_ExpPrograma_MontoPagado Else .dec_ExpPrograma_MontoPagado = drw.Item("ExpPrograma_MontoPagado")
                    If IsDBNull(drw.Item("ExpPrograma_Estado")) Then .bl_ExpPrograma_Estado = .bl_ExpPrograma_Estado Else .bl_ExpPrograma_Estado = drw.Item("ExpPrograma_Estado")
                    If IsDBNull(drw.Item("Estado_Solicitud")) Then .bl_Estado_Solicitud = .bl_Estado_Solicitud Else .bl_Estado_Solicitud = drw.Item("Estado_Solicitud")
                    If IsDBNull(drw.Item("UsuarioCreacion")) Then .str_UsuarioCreacion = .str_UsuarioCreacion Else .str_UsuarioCreacion = drw.Item("UsuarioCreacion")
                    If IsDBNull(drw.Item("FechaCreacion")) Then .det_FechaCreacion = .det_FechaCreacion Else .det_FechaCreacion = drw.Item("FechaCreacion")
                    If IsDBNull(drw.Item("UsuarioModificacion")) Then .str_UsuarioModificacion = .str_UsuarioModificacion Else .str_UsuarioModificacion = drw.Item("UsuarioModificacion")
                    If IsDBNull(drw.Item("FechaModificacion")) Then .det_FechaModificacion = .det_FechaModificacion Else .det_FechaModificacion = drw.Item("FechaModificacion")
                    If IsDBNull(drw.Item("IdProgramaCAT")) Then .str_IdProgramaCAT = .str_IdProgramaCAT Else .str_IdProgramaCAT = drw.Item("IdProgramaCAT")
                    If IsDBNull(drw.Item("DescPrograma")) Then .str_DescPrograma = .str_DescPrograma Else .str_DescPrograma = drw.Item("DescPrograma")

                End With

                liBeExpedienteProgramas.Add(BeExpedienteProgramas)
            Next drw

            po_liBeExpedienteProgramas = liBeExpedienteProgramas
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Entidad Tabla Maestra
    Public Shared Sub fn_MapeoEntidad(ByVal pi_dtb As DataTable, ByRef po_liBeMasterTable As List(Of BE_Master_Table))
        Try
            Dim liBeMasterTable As New List(Of BE_Master_Table)
            Dim BeMasterTable As New BE_Master_Table

            For Each drw As DataRow In pi_dtb.Rows
                BeMasterTable = New BE_Master_Table
                With BeMasterTable

                    If IsDBNull(drw.Item("MasterTable_Id")) Then .int_MasterTable_Id = .int_MasterTable_Id Else .int_MasterTable_Id = drw.Item("MasterTable_Id")
                    If IsDBNull(drw.Item("MasterTable_Valor")) Then .str_MasterTable_Valor = .str_MasterTable_Valor Else .str_MasterTable_Valor = drw.Item("MasterTable_Valor")
                    If IsDBNull(drw.Item("MasterTable_Descripcion")) Then .str_MasterTable_Descripcion = .str_MasterTable_Descripcion Else .str_MasterTable_Descripcion = drw.Item("MasterTable_Descripcion")

                End With

                liBeMasterTable.Add(BeMasterTable)
            Next drw

            po_liBeMasterTable = liBeMasterTable
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Entidad Expediente Historial
    Public Shared Sub fn_MapeoEntidad(ByVal pi_dtb As DataTable, ByRef po_liBEExpedienteHistorial As List(Of BE_ExpedienteHistorial))
        Try
            Dim liBeExpedienteHistorial As New List(Of BE_ExpedienteHistorial)
            Dim BeExpedienteHistorial As New BE_ExpedienteHistorial

            For Each drw As DataRow In pi_dtb.Rows
                BeExpedienteHistorial = New BE_ExpedienteHistorial
                With BeExpedienteHistorial

                    If pi_dtb.Columns.Contains("ExpedienteHistorialId") Then If IsDBNull(drw.Item("ExpedienteHistorialId")) Then .int_ExpedienteHistorialId = .int_ExpedienteHistorialId Else .int_ExpedienteHistorialId = drw.Item("ExpedienteHistorialId")
                    If pi_dtb.Columns.Contains("ExpedienteId") Then If IsDBNull(drw.Item("ExpedienteId")) Then .int_ExpedienteId = .int_ExpedienteId Else .int_ExpedienteId = drw.Item("ExpedienteId")
                    If pi_dtb.Columns.Contains("ApoyoId") Then If IsDBNull(drw.Item("ApoyoId")) Then .int_ApoyoId = .int_ApoyoId Else .int_ApoyoId = drw.Item("ApoyoId")
                    If pi_dtb.Columns.Contains("UsuarioId") Then If IsDBNull(drw.Item("UsuarioId")) Then .int_UsuarioId = .int_UsuarioId Else .int_UsuarioId = drw.Item("UsuarioId")
                    If pi_dtb.Columns.Contains("Usuario_Login") Then If IsDBNull(drw.Item("Usuario_Login")) Then .str_Usuario = .str_Usuario Else .str_Usuario = drw.Item("Usuario_Login")
                    If pi_dtb.Columns.Contains("ActividadId") Then If IsDBNull(drw.Item("ActividadId")) Then .int_ActividadId = .int_ActividadId Else .int_ActividadId = drw.Item("ActividadId")
                    If pi_dtb.Columns.Contains("ActividadDesc") Then If IsDBNull(drw.Item("ActividadDesc")) Then .str_Actividad = .str_Actividad Else .str_Actividad = drw.Item("ActividadDesc")
                    If pi_dtb.Columns.Contains("RolFlujoId") Then If IsDBNull(drw.Item("RolFlujoId")) Then .int_RolFlujoId = .int_RolFlujoId Else .int_RolFlujoId = drw.Item("RolFlujoId")
                    If pi_dtb.Columns.Contains("RolFlujoDesc") Then If IsDBNull(drw.Item("RolFlujoDesc")) Then .str_RolFlujo = .str_RolFlujo Else .str_RolFlujo = drw.Item("RolFlujoDesc")
                    If pi_dtb.Columns.Contains("FechaCreacion") Then If IsDBNull(drw.Item("FechaCreacion")) Then .det_FechaCreacion = .det_FechaCreacion Else .det_FechaCreacion = drw.Item("FechaCreacion")
                    If pi_dtb.Columns.Contains("FechaCreacionFormateado") Then If IsDBNull(drw.Item("FechaCreacionFormateado")) Then .str_FechaCreacion = .str_FechaCreacion Else .str_FechaCreacion = drw.Item("FechaCreacionFormateado")
                    If pi_dtb.Columns.Contains("Usuario") Then If IsDBNull(drw.Item("Usuario")) Then .str_Usuario = .str_Usuario Else .str_Usuario = drw.Item("Usuario")
                End With

                liBeExpedienteHistorial.Add(BeExpedienteHistorial)
            Next drw

            po_liBEExpedienteHistorial = liBeExpedienteHistorial
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Entidad Programas
    Public Shared Sub fn_MapeoEntidad(ByVal pi_dtb As DataTable, ByRef po_LiBeProgramas As List(Of BE_Programas))
        Try
            Dim liBeProgramas As New List(Of BE_Programas)
            Dim BeProgramas As New BE_Programas

            For Each drw As DataRow In pi_dtb.Rows
                BeProgramas = New BE_Programas
                With BeProgramas
                    If IsDBNull(drw.Item("ProgramasId")) Then .int_ProgramasId = .int_ProgramasId Else .int_ProgramasId = drw.Item("ProgramasId")
                    If IsDBNull(drw.Item("IdProgramaCAT")) Then .str_IdProgramaCAT = .str_IdProgramaCAT Else .str_IdProgramaCAT = drw.Item("IdProgramaCAT")
                    If IsDBNull(drw.Item("DescPrograma")) Then .str_DescPrograma = .str_DescPrograma Else .str_DescPrograma = drw.Item("DescPrograma")
                    If IsDBNull(drw.Item("FechaInicio")) Then .det_FechaInicio = .det_FechaInicio Else .det_FechaInicio = drw.Item("FechaInicio")
                    If IsDBNull(drw.Item("FechaFin")) Then .det_FechaFin = .det_FechaFin Else .det_FechaFin = drw.Item("FechaFin")
                    If IsDBNull(drw.Item("FechaCreacion")) Then .det_FechaCreacion = .det_FechaCreacion Else .det_FechaCreacion = drw.Item("FechaCreacion")
                    If IsDBNull(drw.Item("FechaModificacion")) Then .det_FechaModificacion = .det_FechaModificacion Else .det_FechaModificacion = drw.Item("FechaModificacion")
                    If IsDBNull(drw.Item("UsuarioCreacion")) Then .str_UsuarioCreacion = .str_UsuarioCreacion Else .str_UsuarioCreacion = drw.Item("UsuarioCreacion")
                    If IsDBNull(drw.Item("UsuarioModificacion")) Then .str_UsuarioModificacion = .str_UsuarioModificacion Else .str_UsuarioModificacion = drw.Item("UsuarioModificacion")
                    If IsDBNull(drw.Item("RolFlujoDesc")) Then .str_RolFlujoDesc = .str_RolFlujoDesc Else .str_RolFlujoDesc = drw.Item("RolFlujoDesc")
                    If IsDBNull(drw.Item("ProgramaStatus")) Then .bl_ProgramaStatus = .bl_ProgramaStatus Else .bl_ProgramaStatus = drw.Item("ProgramaStatus")
                    If IsDBNull(drw.Item("RolFlujoId")) Then .int_RolFlujoId = .int_RolFlujoId Else .int_RolFlujoId = drw.Item("RolFlujoId")


                End With

                liBeProgramas.Add(BeProgramas)
            Next drw

            po_LiBeProgramas = liBeProgramas
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Entidad Apoyo Maquina
    Public Shared Sub fn_MapeoEntidad(ByVal pi_dtb As DataTable, ByRef po_liBEApoyoMaquina As List(Of BE_ApoyoMaquina))
        Try
            Dim liBEApoyoMaquina As New List(Of BE_ApoyoMaquina)
            Dim BEApoyoMaquina As New BE_ApoyoMaquina

            For Each drw As DataRow In pi_dtb.Rows
                BEApoyoMaquina = New BE_ApoyoMaquina
                With BEApoyoMaquina

                    If IsDBNull(drw.Item("MaquinaApoyoId")) Then .int_MaquinaApoyoId = .int_MaquinaApoyoId Else .int_MaquinaApoyoId = drw.Item("MaquinaApoyoId")
                    If IsDBNull(drw.Item("ApoyoId")) Then .int_ApoyoId = .int_ApoyoId Else .int_ApoyoId = drw.Item("ApoyoId")
                    If IsDBNull(drw.Item("EstadoSolicitudId")) Then .int_EstadoSolicitudId = .int_EstadoSolicitudId Else .int_EstadoSolicitudId = drw.Item("EstadoSolicitudId")
                    If IsDBNull(drw.Item("CompaniaId")) Then .str_CompaniaId = .str_CompaniaId Else .str_CompaniaId = drw.Item("CompaniaId")
                    If IsDBNull(drw.Item("OrdenAsignada")) Then .str_OrdenAsignada = .str_OrdenAsignada Else .str_OrdenAsignada = drw.Item("OrdenAsignada")
                    If IsDBNull(drw.Item("PedidoId")) Then .str_PedidoId = .str_PedidoId Else .str_PedidoId = drw.Item("PedidoId")
                    If IsDBNull(drw.Item("PosicionId")) Then .int_PosicionId = .int_PosicionId Else .int_PosicionId = drw.Item("PosicionId")
                    If IsDBNull(drw.Item("IdProgramaCAT")) Then .str_IdProgramaCAT = .str_IdProgramaCAT Else .str_IdProgramaCAT = drw.Item("IdProgramaCAT")
                    If IsDBNull(drw.Item("ImporteApoyoCAT")) Then .dec_ImporteApoyoCAT = .dec_ImporteApoyoCAT Else .dec_ImporteApoyoCAT = drw.Item("ImporteApoyoCAT")
                    If IsDBNull(drw.Item("FechaSolicitudCAT")) Then .det_FechaSolicitudCAT = .det_FechaSolicitudCAT Else .det_FechaSolicitudCAT = drw.Item("FechaSolicitudCAT")
                    If IsDBNull(drw.Item("FechaRespuestaCAT")) Then .det_FechaRespuestaCAT = .det_FechaRespuestaCAT Else .det_FechaRespuestaCAT = drw.Item("FechaRespuestaCAT")
                    If IsDBNull(drw.Item("Observacion")) Then .str_Observacion = .str_Observacion Else .str_Observacion = drw.Item("Observacion")
                    If IsDBNull(drw.Item("UsuarioCreacion")) Then .str_UsuarioCreacion = .str_UsuarioCreacion Else .str_UsuarioCreacion = drw.Item("UsuarioCreacion")
                    If IsDBNull(drw.Item("FechaCreacion")) Then .det_FechaCreacion = .det_FechaCreacion Else .det_FechaCreacion = drw.Item("FechaCreacion")
                    If IsDBNull(drw.Item("UsuarioModificacion")) Then .str_UsuarioModificacion = .str_UsuarioModificacion Else .str_UsuarioModificacion = drw.Item("UsuarioModificacion")
                    If IsDBNull(drw.Item("FehcaModificacion")) Then .det_FechaModificacion = .det_FechaModificacion Else .det_FechaModificacion = drw.Item("FehcaModificacion")
                    If IsDBNull(drw.Item("UsuarioModificacion")) Then .str_UsuarioModificacion = .str_UsuarioModificacion Else .str_UsuarioModificacion = drw.Item("UsuarioModificacion")
                    If IsDBNull(drw.Item("SolicitudEstado")) Then .bl_SolicitudEstado = .bl_SolicitudEstado Else .bl_SolicitudEstado = drw.Item("SolicitudEstado")
                    If IsDBNull(drw.Item("EstadoSolicitud")) Then .str_EstadoSolicitud = .str_EstadoSolicitud Else .str_EstadoSolicitud = drw.Item("EstadoSolicitud")


                End With

                liBEApoyoMaquina.Add(BEApoyoMaquina)
            Next drw

            po_liBEApoyoMaquina = liBEApoyoMaquina
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Entidad Apoyo Flujo
    Public Shared Sub fn_MapeoEntidad(ByVal pi_dtb As DataTable, ByRef po_liBEApoyoFlujo As List(Of BE_Apoyo_Flujo))
        Try
            Dim liBEApoyoFlujo As New List(Of BE_Apoyo_Flujo)
            Dim BEApoyoFlujo As New BE_Apoyo_Flujo

            For Each drw As DataRow In pi_dtb.Rows
                BEApoyoFlujo = New BE_Apoyo_Flujo
                With BEApoyoFlujo
                    If IsDBNull(drw.Item("ApoyoId")) Then .int_ApoyoId = .int_ApoyoId Else .int_ApoyoId = drw.Item("ApoyoId")
                    If IsDBNull(drw.Item("CompaniaId")) Then .str_CompaniaId = .str_CompaniaId Else .str_CompaniaId = drw.Item("CompaniaId")
                    If IsDBNull(drw.Item("OrdenAsignada")) Then .str_OrdenAsignada = .str_OrdenAsignada Else .str_OrdenAsignada = drw.Item("OrdenAsignada")
                    If IsDBNull(drw.Item("PedidoId")) Then .str_PedidoId = .str_PedidoId Else .str_PedidoId = drw.Item("PedidoId")
                    If IsDBNull(drw.Item("PosicionId")) Then .int_PosicionId = .int_PosicionId Else .int_PosicionId = drw.Item("PosicionId")
                    If IsDBNull(drw.Item("ModeloRDA")) Then .str_ModeloRDA = .str_ModeloRDA Else .str_ModeloRDA = drw.Item("ModeloRDA")
                    If IsDBNull(drw.Item("ModeloProductoId")) Then .str_ModeloProductoId = .str_ModeloProductoId Else .str_ModeloProductoId = drw.Item("ModeloProductoId")
                    If IsDBNull(drw.Item("ModeloProductoDesc")) Then .str_ModeloProductoDesc = .str_ModeloProductoDesc Else .str_ModeloProductoDesc = drw.Item("ModeloProductoDesc")
                    If IsDBNull(drw.Item("SerieMaquina")) Then .str_SerieMaquina = .str_SerieMaquina Else .str_SerieMaquina = drw.Item("SerieMaquina")
                    If IsDBNull(drw.Item("EstadoInventario")) Then .str_EstadoInventario = .str_EstadoInventario Else .str_EstadoInventario = drw.Item("EstadoInventario")
                    If IsDBNull(drw.Item("FacturaNumero")) Then .str_FacturaNumero = .str_FacturaNumero Else .str_FacturaNumero = drw.Item("FacturaNumero")
                    If IsDBNull(drw.Item("EstructuraCostos")) Then .bl_EstructuraCostos = .bl_EstructuraCostos Else .bl_EstructuraCostos = drw.Item("EstructuraCostos")
                    If IsDBNull(drw.Item("ClienteId")) Then .str_ClienteId = .str_ClienteId Else .str_ClienteId = drw.Item("ClienteId")
                    If IsDBNull(drw.Item("DESC_CLIENTE")) Then .str_DESC_CLIENTE = .str_DESC_CLIENTE Else .str_DESC_CLIENTE = drw.Item("DESC_CLIENTE")
                    If IsDBNull(drw.Item("ApoyoTipoId")) Then .str_ApoyoTipoId = .str_ApoyoTipoId Else .str_ApoyoTipoId = drw.Item("ApoyoTipoId")
                    If IsDBNull(drw.Item("ApoyoTipoDesc")) Then .str_ApoyoTipoDesc = .str_ApoyoTipoDesc Else .str_ApoyoTipoDesc = drw.Item("ApoyoTipoDesc")
                    If IsDBNull(drw.Item("ApoyoImporteCRM")) Then .dec_ApoyoImporteCRM = .dec_ApoyoImporteCRM Else .dec_ApoyoImporteCRM = drw.Item("ApoyoImporteCRM")
                    If IsDBNull(drw.Item("ValorVentaMaquinaCRM")) Then .dec_ValorVentaMaquinaCRM = .dec_ValorVentaMaquinaCRM Else .dec_ValorVentaMaquinaCRM = drw.Item("ValorVentaMaquinaCRM")
                    If IsDBNull(drw.Item("ExpedienteId")) Then .int_ExpedienteId = .int_ExpedienteId Else .int_ExpedienteId = drw.Item("ExpedienteId")
                    If IsDBNull(drw.Item("FlujoId")) Then .int_FlujoId = .int_FlujoId Else .int_FlujoId = drw.Item("FlujoId")
                    If IsDBNull(drw.Item("FlujoEstado")) Then .str_FlujoEstado = .str_FlujoEstado Else .str_FlujoEstado = drw.Item("FlujoEstado")
                    If IsDBNull(drw.Item("MaquinaApoyoId")) Then .int_MaquinaApoyoId = .int_MaquinaApoyoId Else .int_MaquinaApoyoId = drw.Item("MaquinaApoyoId")
                    If IsDBNull(drw.Item("IdProgramaCAT")) Then .str_IdProgramaCAT = .str_IdProgramaCAT Else .str_IdProgramaCAT = drw.Item("IdProgramaCAT")
                    If IsDBNull(drw.Item("FechaSolicitudCAT")) Then .det_FechaSolicitudCAT = New Nullable(Of DateTime)() Else .det_FechaSolicitudCAT = drw.Item("FechaSolicitudCAT")
                    If IsDBNull(drw.Item("DiasSolicitud")) Then .int_DiasSolicitud = .int_DiasSolicitud Else .int_DiasSolicitud = drw.Item("DiasSolicitud")
                    If IsDBNull(drw.Item("SolicitudId")) Then .int_SolicitudId = .int_SolicitudId Else .int_SolicitudId = drw.Item("SolicitudId")
                    If IsDBNull(drw.Item("SolicitudEstado")) Then .str_SolicitudEstado = .str_SolicitudEstado Else .str_SolicitudEstado = drw.Item("SolicitudEstado")
                    If IsDBNull(drw.Item("WashOut")) Then .byte_Washout = .byte_Washout Else .byte_Washout = drw.Item("WashOut")
                    If IsDBNull(drw.Item("WashoutArchivo")) Then .str_WashoutArchivo = .str_WashoutArchivo Else .str_WashoutArchivo = drw.Item("WashoutArchivo")
                    If IsDBNull(drw.Item("WashOutFecha")) Then .det_WashOutFecha = New Nullable(Of DateTime)() Else .det_WashOutFecha = drw.Item("WashOutFecha")
                    If IsDBNull(drw.Item("WashoutId")) Then .int_WashoutId = .int_WashoutId Else .int_WashoutId = drw.Item("WashoutId")
                    If IsDBNull(drw.Item("WashoutEstado")) Then .str_WashoutEstado = .str_WashoutEstado Else .str_WashoutEstado = drw.Item("WashoutEstado")
                    If IsDBNull(drw.Item("HaveWashout")) Then .bl_HaveWashout = .bl_HaveWashout Else .bl_HaveWashout = drw.Item("HaveWashout")
                    If IsDBNull(drw.Item("WashoutFechaRespuesta")) Then .det_WashoutFechaRespuesta = New Nullable(Of DateTime)() Else .det_WashoutFechaRespuesta = drw.Item("WashoutFechaRespuesta")
                    If IsDBNull(drw.Item("DiasWashout")) Then .int_DiasWashout = .int_DiasWashout Else .int_DiasWashout = drw.Item("DiasWashout")
                    If IsDBNull(drw.Item("FechaRespuestaCAT")) Then .det_FechaRespuestaCAT = .det_FechaRespuestaCAT Else .det_FechaRespuestaCAT = drw.Item("FechaRespuestaCAT")
                    If IsDBNull(drw.Item("ImporteApoyoCAT")) Then .dec_ImporteApoyoCAT = .dec_ImporteApoyoCAT Else .dec_ImporteApoyoCAT = drw.Item("ImporteApoyoCAT")
                    If IsDBNull(drw.Item("Observacion")) Then .str_Observacion = .str_Observacion Else .str_Observacion = drw.Item("Observacion")
                    If IsDBNull(drw.Item("FechaSRC")) Then .det_FechaSRC = .det_FechaSRC Else .det_FechaSRC = drw.Item("FechaSRC")
                    If IsDBNull(drw.Item("FechaClaim")) Then .det_FechaClaim = .det_FechaClaim Else .det_FechaClaim = drw.Item("FechaClaim")
                    If IsDBNull(drw.Item("DiasClaim")) Then .int_DiasClaim = .int_DiasClaim Else .int_DiasClaim = drw.Item("DiasClaim")
                    If IsDBNull(drw.Item("SubGridFlag")) Then .int_SubGridFlag = .int_SubGridFlag Else .int_SubGridFlag = drw.Item("SubGridFlag")
                    If IsDBNull(drw.Item("Comentario")) Then .str_Comentarios = .str_Comentarios Else .str_Comentarios = drw.Item("Comentario")
                    If IsDBNull(drw.Item("CuentaInventarioDBS")) Then .str_CuentaInventarioDBS = .str_CuentaInventarioDBS Else .str_CuentaInventarioDBS = drw.Item("CuentaInventarioDBS")

                End With

                liBEApoyoFlujo.Add(BEApoyoFlujo)
            Next drw

            po_liBEApoyoFlujo = liBEApoyoFlujo
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Entidad Usuarios
    Public Shared Sub fn_MapeoEntidad(ByVal pi_dtb As DataTable, ByRef po_liBERolFlujos As List(Of BE_Usuarios))
        Try
            Dim liBERolFlujos As New List(Of BE_Usuarios)
            Dim BERolFlujos As New BE_Usuarios

            For Each drw As DataRow In pi_dtb.Rows
                BERolFlujos = New BE_Usuarios

                With BERolFlujos
                    If IsDBNull(drw.Item("UsuarioId")) Then .int_UsuarioId = .int_UsuarioId Else .int_UsuarioId = drw.Item("UsuarioId")
                    If IsDBNull(drw.Item("CompaniaId")) Then .str_CompaniaId = .str_CompaniaId Else .str_CompaniaId = drw.Item("CompaniaId")
                    If IsDBNull(drw.Item("CompaniaDes")) Then .str_CompaniaDes = .str_CompaniaDes Else .str_CompaniaDes = drw.Item("CompaniaDes")
                    If IsDBNull(drw.Item("Usuario_Apellidos")) Then .str_Usuario_Apellidos = .str_Usuario_Apellidos Else .str_Usuario_Apellidos = drw.Item("Usuario_Apellidos")
                    If IsDBNull(drw.Item("Usuario_Nombres")) Then .str_Usuario_Nombres = .str_Usuario_Nombres Else .str_Usuario_Nombres = drw.Item("Usuario_Nombres")
                    If IsDBNull(drw.Item("Usuario_Login")) Then .str_Usuario_Login = .str_Usuario_Login Else .str_Usuario_Login = drw.Item("Usuario_Login")
                    If IsDBNull(drw.Item("Usuario_Password")) Then .str_Usuario_Password = .str_Usuario_Password Else .str_Usuario_Password = drw.Item("Usuario_Password")
                    If IsDBNull(drw.Item("Usuario_Email")) Then .str_Usuario_Email = .str_Usuario_Email Else .str_Usuario_Email = drw.Item("Usuario_Email")
                    If IsDBNull(drw.Item("NroPersonal")) Then .str_NroPersonal = .str_NroPersonal Else .str_NroPersonal = drw.Item("NroPersonal")
                    If IsDBNull(drw.Item("CodigoAdrian")) Then .str_CodigoAdrian = .str_CodigoAdrian Else .str_CodigoAdrian = drw.Item("CodigoAdrian")
                    If IsDBNull(drw.Item("CodigoSAP")) Then .str_CodigoSAP = .str_CodigoSAP Else .str_CodigoSAP = drw.Item("CodigoSAP")
                    If IsDBNull(drw.Item("Funcion")) Then .str_Funcion = .str_Funcion Else .str_Funcion = drw.Item("Funcion")
                    If IsDBNull(drw.Item("Cargo")) Then .str_Cargo = .str_Cargo Else .str_Cargo = drw.Item("Cargo")
                    If IsDBNull(drw.Item("FechaCreacion")) Then .det_FechaCreacion = .det_FechaCreacion Else .det_FechaCreacion = drw.Item("FechaCreacion")
                    If IsDBNull(drw.Item("FechaModificacion")) Then .det_FechaModificacion = .det_FechaModificacion Else .det_FechaModificacion = drw.Item("FechaModificacion")
                    If IsDBNull(drw.Item("UsuarioCreacion")) Then .str_UsuarioCreacion = .str_UsuarioCreacion Else .str_UsuarioCreacion = drw.Item("UsuarioCreacion")
                    If IsDBNull(drw.Item("UsuarioModificacion")) Then .str_UsuarioModificacion = .str_UsuarioModificacion Else .str_UsuarioModificacion = drw.Item("UsuarioModificacion")
                    If IsDBNull(drw.Item("Usuario_Status")) Then .bl_Usuario_Status = .bl_Usuario_Status Else .bl_Usuario_Status = drw.Item("Usuario_Status")
                    If IsDBNull(drw.Item("Module_GestionInventario")) Then .bl_Module_GestionInventario = .bl_Module_GestionInventario Else .bl_Module_GestionInventario = drw.Item("Module_GestionInventario")
                    If IsDBNull(drw.Item("Module_ApoyoFabricante")) Then .bl_Module_ApoyoFabricante = .bl_Module_ApoyoFabricante Else .bl_Module_ApoyoFabricante = drw.Item("Module_ApoyoFabricante")
                    If IsDBNull(drw.Item("Module_Bonos")) Then .bl_Module_Bonos = .bl_Module_Bonos Else .bl_Module_Bonos = drw.Item("Module_Bonos")
                    If IsDBNull(drw.Item("Module_Administracion")) Then .bl_Module_Administracion = .bl_Module_Administracion Else .bl_Module_Administracion = drw.Item("Module_Administracion")
                End With

                liBERolFlujos.Add(BERolFlujos)
            Next drw

            po_liBERolFlujos = liBERolFlujos
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Entidad Rol Flujo
    Public Shared Sub fn_MapeoEntidad(ByVal pi_dtb As DataTable, ByRef po_liBERolFlujos As List(Of BE_RolFlujos))
        Try
            Dim liBERolFlujos As New List(Of BE_RolFlujos)
            Dim BERolFlujos As New BE_RolFlujos

            For Each drw As DataRow In pi_dtb.Rows
                BERolFlujos = New BE_RolFlujos
                With BERolFlujos
                    If IsDBNull(drw.Item("RolFlujoId")) Then .int_RolFlujoId = .int_RolFlujoId Else .int_RolFlujoId = drw.Item("RolFlujoId")
                    If IsDBNull(drw.Item("RolFlujoDesc")) Then .str_RolFlujoDesc = .str_RolFlujoDesc Else .str_RolFlujoDesc = drw.Item("RolFlujoDesc")
                    If IsDBNull(drw.Item("FechaCreacion")) Then .det_FechaCreacion = .det_FechaCreacion Else .det_FechaCreacion = drw.Item("FechaCreacion")
                    If IsDBNull(drw.Item("FechaModificacion")) Then .det_FechaModificacion = .det_FechaModificacion Else .det_FechaModificacion = drw.Item("FechaModificacion")
                    If IsDBNull(drw.Item("UsuarioCreacion")) Then .str_UsuarioCreacion = .str_UsuarioCreacion Else .str_UsuarioCreacion = drw.Item("UsuarioCreacion")
                    If IsDBNull(drw.Item("UsuarioModificacion")) Then .str_UsuarioModificacion = .str_UsuarioModificacion Else .str_UsuarioModificacion = drw.Item("UsuarioModificacion")
                End With

                liBERolFlujos.Add(BERolFlujos)
            Next drw

            po_liBERolFlujos = liBERolFlujos
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Entidad Tipo Flujo 
    Public Shared Sub fn_MapeoEntidad(ByVal pi_dtb As DataTable, ByRef po_liBETipoFlujo As List(Of BE_TipoFlujo))
        Try
            Dim liBETipoFlujo As New List(Of BE_TipoFlujo)
            Dim BETipoFlujo As New BE_TipoFlujo

            For Each drw As DataRow In pi_dtb.Rows
                BETipoFlujo = New BE_TipoFlujo
                With BETipoFlujo
                    If IsDBNull(drw.Item("TipoFlujoId")) Then .int_TipoFlujoId = .int_TipoFlujoId Else .int_TipoFlujoId = drw.Item("TipoFlujoId")
                    If IsDBNull(drw.Item("TipoFlujoDesc")) Then .str_TipoFlujoDesc = .str_TipoFlujoDesc Else .str_TipoFlujoDesc = drw.Item("TipoFlujoDesc")
                    If IsDBNull(drw.Item("FechaCreacion")) Then .det_FechaCreacion = .det_FechaCreacion Else .det_FechaCreacion = drw.Item("FechaCreacion")
                    If IsDBNull(drw.Item("FechaModificacion")) Then .det_FechaModificacion = .det_FechaModificacion Else .det_FechaModificacion = drw.Item("FechaModificacion")
                    If IsDBNull(drw.Item("UsuarioCreacion")) Then .str_UsuarioCreacion = .str_UsuarioCreacion Else .str_UsuarioCreacion = drw.Item("UsuarioCreacion")
                    If IsDBNull(drw.Item("UsuarioModificacion")) Then .str_UsuarioModificacion = .str_UsuarioModificacion Else .str_UsuarioModificacion = drw.Item("UsuarioModificacion")
                End With

                liBETipoFlujo.Add(BETipoFlujo)
            Next drw

            po_liBETipoFlujo = liBETipoFlujo
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Entidad Cuenta Inventario Maestro
    Public Shared Sub fn_MapeoEntidad(ByVal pi_dtb As DataTable, ByRef po_liBECuentaInventarioMaestro As List(Of BE_CuentaInventarioMaestro))
        Try
            Dim liBECuentaInventarioMaestro As New List(Of BE_CuentaInventarioMaestro)
            Dim BECuentaInventarioMaestro As New BE_CuentaInventarioMaestro

            For Each drw As DataRow In pi_dtb.Rows
                BECuentaInventarioMaestro = New BE_CuentaInventarioMaestro
                With BECuentaInventarioMaestro
                    If IsDBNull(drw.Item("IdCuentaInventario")) Then .int_IdCuentaInventario = .int_IdCuentaInventario Else .int_IdCuentaInventario = drw.Item("IdCuentaInventario")
                    If IsDBNull(drw.Item("IdLineaVenta")) Then .int_IdLineaVenta = .int_IdLineaVenta Else .int_IdLineaVenta = drw.Item("IdLineaVenta")
                    If IsDBNull(drw.Item("IdCuenta")) Then .str_IdCuenta = .str_IdCuenta Else .str_IdCuenta = drw.Item("IdCuenta")
                    If IsDBNull(drw.Item("DescCuentaInventario")) Then .str_DescCuentaInventario = .str_DescCuentaInventario Else .str_DescCuentaInventario = drw.Item("DescCuentaInventario")
                    If IsDBNull(drw.Item("DescLineaVenta")) Then .str_DescLineaVenta = .str_DescLineaVenta Else .str_DescLineaVenta = drw.Item("DescLineaVenta")
                    If drw.Table.Columns.Contains("UsuarioModificacion") Then If Not IsDBNull(drw.Item("UsuarioModificacion")) Then .str_UsuarioModificacion = drw.Item("UsuarioModificacion")
                    If drw.Table.Columns.Contains("FechaModificacion") Then If Not IsDBNull(drw.Item("FechaModificacion")) Then .det_FechaModificacion = drw.Item("FechaModificacion")
                End With

                liBECuentaInventarioMaestro.Add(BECuentaInventarioMaestro)
            Next drw

            po_liBECuentaInventarioMaestro = liBECuentaInventarioMaestro
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Entidad Compañia
    Public Shared Sub fn_MapeoEntidad(ByVal pi_dtb As DataTable, ByRef po_liBECompania As List(Of BE_Compania))
        Try
            Dim liBECompania As New List(Of BE_Compania)
            Dim BECompania As New BE_Compania

            For Each drw As DataRow In pi_dtb.Rows
                BECompania = New BE_Compania
                With BECompania
                    If IsDBNull(drw.Item("CompaniaID")) Then .int_CompaniaID = .int_CompaniaID Else .int_CompaniaID = drw.Item("CompaniaID")
                    If IsDBNull(drw.Item("CompaniaCod")) Then .str_CompaniaCod = .str_CompaniaCod Else .str_CompaniaCod = drw.Item("CompaniaCod")
                    If IsDBNull(drw.Item("CompaniaDes")) Then .str_CompaniaDes = .str_CompaniaDes Else .str_CompaniaDes = drw.Item("CompaniaDes")
                End With

                liBECompania.Add(BECompania)
            Next drw

            po_liBECompania = liBECompania
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Entidad LineaVentaMaestro
    Public Shared Sub fn_MapeoEntidad(ByVal pi_dtb As DataTable, ByRef po_liBELineaVentaMaestro As List(Of BE_LineaVentaMaestro))
        Try
            Dim liBELineaVentaMaestro As New List(Of BE_LineaVentaMaestro)
            Dim BELineaVentaMaestro As New BE_LineaVentaMaestro

            For Each drw As DataRow In pi_dtb.Rows
                BELineaVentaMaestro = New BE_LineaVentaMaestro
                With BELineaVentaMaestro
                    If IsDBNull(drw.Item("IdLineaVenta")) Then .int_IdLineaVenta = .int_IdLineaVenta Else .int_IdLineaVenta = drw.Item("IdLineaVenta")
                    If IsDBNull(drw.Item("IdCompania")) Then .str_IdCompania = .str_IdCompania Else .str_IdCompania = drw.Item("IdCompania")
                    If IsDBNull(drw.Item("CompaniaDes")) Then .str_CompaniaDes = .str_CompaniaDes Else .str_CompaniaDes = drw.Item("CompaniaDes")
                    If IsDBNull(drw.Item("CargoFirma")) Then .str_CargoFirma = .str_CargoFirma Else .str_CargoFirma = drw.Item("CargoFirma")
                    If IsDBNull(drw.Item("DescLineaVenta")) Then .str_DescLineaVenta = .str_DescLineaVenta Else .str_DescLineaVenta = drw.Item("DescLineaVenta")
                    If IsDBNull(drw.Item("FechaCreacion")) Then .det_FechaCreacion = .det_FechaCreacion Else .det_FechaCreacion = drw.Item("FechaCreacion")
                    If IsDBNull(drw.Item("FechaModificacion")) Then .det_FechaModificacion = .det_FechaModificacion Else .det_FechaModificacion = drw.Item("FechaModificacion")
                    If IsDBNull(drw.Item("NombreImagenFirma")) Then .str_NombreImagenFirma = .str_NombreImagenFirma Else .str_NombreImagenFirma = drw.Item("NombreImagenFirma")
                    'If IsDBNull(drw.Item("ImagenFirma")) Then .byte_ImagenFirma = .byte_ImagenFirma Else .byte_ImagenFirma = drw.Item("ImagenFirma")
                    If IsDBNull(drw.Item("NombreFirma")) Then .str_NombreFirma = .str_NombreFirma Else .str_NombreFirma = drw.Item("NombreFirma")
                    If IsDBNull(drw.Item("DiasReserva")) Then .int_DiasReserva = .int_DiasReserva Else .int_DiasReserva = drw.Item("DiasReserva")
                    If IsDBNull(drw.Item("UsuarioCreacion")) Then .str_UsuarioCreacion = .str_UsuarioCreacion Else .str_UsuarioCreacion = drw.Item("UsuarioCreacion")
                    If IsDBNull(drw.Item("UsuarioModificacion")) Then .str_UsuarioModificacion = .str_UsuarioModificacion Else .str_UsuarioModificacion = drw.Item("UsuarioModificacion")
                    If IsDBNull(drw.Item("Washout")) Then .bl_Washout = .bl_Washout Else .bl_Washout = drw.Item("Washout")
                    If IsDBNull(drw.Item("StatusLineaVenta")) Then .bl_StatusLineaVenta = .bl_StatusLineaVenta Else .bl_StatusLineaVenta = drw.Item("StatusLineaVenta")
                End With

                liBELineaVentaMaestro.Add(BELineaVentaMaestro)
            Next drw

            po_liBELineaVentaMaestro = liBELineaVentaMaestro
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Entidad Menu
    Public Shared Sub fn_MapeoEntidad(ByVal pi_dtb As DataTable, ByRef po_liBEMenu As List(Of BE_Menu))
        Try
            Dim liBEMenu As New List(Of BE_Menu)
            Dim BEMenu As New BE_Menu

            For Each drw As DataRow In pi_dtb.Rows
                BEMenu = New BE_Menu
                With BEMenu
                    If IsDBNull(drw.Item("MenuId")) Then .int_MenuId = .int_MenuId Else .int_MenuId = drw.Item("MenuId")
                    If IsDBNull(drw.Item("ModuloId")) Then .int_ModuloId = .int_ModuloId Else .int_ModuloId = drw.Item("ModuloId")
                    If IsDBNull(drw.Item("Menu")) Then .str_Menu = .str_Menu Else .str_Menu = drw.Item("Menu")
                    If IsDBNull(drw.Item("Menu_URL")) Then .str_Menu_URL = .str_Menu_URL Else .str_Menu_URL = drw.Item("Menu_URL")
                    If IsDBNull(drw.Item("Menu_Status")) Then .int_Menu_Status = .int_Menu_Status Else .int_Menu_Status = drw.Item("Menu_Status")
                    If IsDBNull(drw.Item("FechaCreacion")) Then .det_FechaCreacion = .det_FechaCreacion Else .det_FechaCreacion = drw.Item("FechaCreacion")
                    If IsDBNull(drw.Item("UsuarioCreacion")) Then .str_UsuarioCreacion = .str_UsuarioCreacion Else .str_UsuarioCreacion = drw.Item("UsuarioCreacion")
                    If IsDBNull(drw.Item("FechaModificacion")) Then .det_FechaModificacion = .det_FechaModificacion Else .det_FechaModificacion = drw.Item("FechaModificacion")
                    If IsDBNull(drw.Item("UsuarioModificacion")) Then .str_UsuarioModificacion = .str_UsuarioModificacion Else .str_UsuarioModificacion = drw.Item("UsuarioModificacion")

                End With

                liBEMenu.Add(BEMenu)
            Next drw

            po_liBEMenu = liBEMenu
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Actividad
    ''' Modificado por JVL
    ''' </summary>
    ''' <param name="pi_dtb"></param>
    ''' <param name="po_liBEActividad">Entidad Actividad</param>
    ''' <remarks></remarks>
    Public Shared Sub fn_MapeoEntidad(ByVal pi_dtb As DataTable, ByRef po_liBEActividad As List(Of BE_Actividad))
        Try
            Dim liBEActividad As New List(Of BE_Actividad)
            Dim BEActividad As New BE_Actividad

            For Each drw As DataRow In pi_dtb.Rows
                BEActividad = New BE_Actividad
                With BEActividad
                    If IsDBNull(drw.Item("ActividadId")) Then .int_ActividadId = .int_ActividadId Else .int_ActividadId = drw.Item("ActividadId")
                    If IsDBNull(drw.Item("ActividadDesc")) Then .str_ActividadDesc = .str_ActividadDesc Else .str_ActividadDesc = drw.Item("ActividadDesc")
                End With

                liBEActividad.Add(BEActividad)
            Next drw

            po_liBEActividad = liBEActividad
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Entidad Flujo
    Public Shared Sub fn_MapeoEntidad(ByVal pi_dtb As DataTable, ByRef po_liBEFlujo As List(Of BE_Flujo))
        Try
            Dim liBEFlujo As New List(Of BE_Flujo)
            Dim BEFlujo As New BE_Flujo

            For Each drw As DataRow In pi_dtb.Rows
                BEFlujo = New BE_Flujo
                With BEFlujo
                    If IsDBNull(drw.Item("ActividadId")) Then .int_IdActividad = .int_IdActividad Else .int_IdActividad = drw.Item("ActividadId")
                    If IsDBNull(drw.Item("ActividadIdSiguiente")) Then .int_IdActividadSiguiente = .int_IdActividadSiguiente Else .int_IdActividadSiguiente = drw.Item("ActividadIdSiguiente")
                End With

                liBEFlujo.Add(BEFlujo)
            Next drw

            po_liBEFlujo = liBEFlujo
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Entidad Maquina
    Public Shared Sub fn_MapeoEntidad(ByVal pi_dtb As DataTable, ByRef po_liBEMaquina As List(Of BE_Maquina))
        Try
            Dim liBEMaquina As New List(Of BE_Maquina)
            Dim BEMaquina As New BE_Maquina

            For Each drw As DataRow In pi_dtb.Rows
                BEMaquina = New BE_Maquina
                With BEMaquina
                    If drw.Table.Columns.Contains("AgenteDesc") Then If IsDBNull(drw.Item("AgenteDesc")) Then .str_AgenteDesc = .str_AgenteDesc Else .str_AgenteDesc = drw.Item("AgenteDesc")
                    If drw.Table.Columns.Contains("AgenteId") Then If IsDBNull(drw.Item("AgenteId")) Then .str_AgenteId = .str_AgenteId Else .str_AgenteId = drw.Item("AgenteId")
                    If drw.Table.Columns.Contains("AnoFabricacionMaquina") Then If IsDBNull(drw.Item("AnoFabricacionMaquina")) Then .str_AnoFabricacionMaquina = .str_AnoFabricacionMaquina Else .str_AnoFabricacionMaquina = drw.Item("AnoFabricacionMaquina")
                    If drw.Table.Columns.Contains("AntiguamientoMaquina") Then If IsDBNull(drw.Item("AntiguamientoMaquina")) Then .int_AntiguamientoMaquina = .int_AntiguamientoMaquina Else .int_AntiguamientoMaquina = drw.Item("AntiguamientoMaquina")
                    If drw.Table.Columns.Contains("ApoyoFabricanteIndicador") Then If IsDBNull(drw.Item("ApoyoFabricanteIndicador")) Then .str_ApoyoFabricanteIndicador = .str_ApoyoFabricanteIndicador Else .str_ApoyoFabricanteIndicador = drw.Item("ApoyoFabricanteIndicador")
                    If drw.Table.Columns.Contains("ArriboPuertoEstimadaFecha") Then If Not IsDBNull(drw.Item("ArriboPuertoEstimadaFecha")) Then .det_ArriboPuertoEstimadaFecha = drw.Item("ArriboPuertoEstimadaFecha")
                    If drw.Table.Columns.Contains("ArriboPuertoFecha") Then If Not IsDBNull(drw.Item("ArriboPuertoFecha")) Then .det_ArriboPuertoFecha = drw.Item("ArriboPuertoFecha")
                    If drw.Table.Columns.Contains("AsignacionFecha") Then If Not IsDBNull(drw.Item("AsignacionFecha")) Then .det_AsignacionFecha = drw.Item("AsignacionFecha")
                    If drw.Table.Columns.Contains("BillOfLanding") Then If IsDBNull(drw.Item("BillOfLanding")) Then .str_BillOfLanding = .str_BillOfLanding Else .str_BillOfLanding = drw.Item("BillOfLanding")
                    If drw.Table.Columns.Contains("BuqueDesc") Then If IsDBNull(drw.Item("BuqueDesc")) Then .str_BuqueDesc = .str_BuqueDesc Else .str_BuqueDesc = drw.Item("BuqueDesc")
                    If drw.Table.Columns.Contains("CentroCostoId") Then If IsDBNull(drw.Item("CentroCostoId")) Then .str_CentroCostoId = .str_CentroCostoId Else .str_CentroCostoId = drw.Item("CentroCostoId")
                    If drw.Table.Columns.Contains("ClienteFacturaId") Then If IsDBNull(drw.Item("ClienteFacturaId")) Then .str_ClienteFacturaId = .str_ClienteFacturaId Else .str_ClienteFacturaId = drw.Item("ClienteFacturaId")
                    If drw.Table.Columns.Contains("ClienteId") Then If IsDBNull(drw.Item("ClienteId")) Then .str_ClienteId = .str_ClienteId Else .str_ClienteId = drw.Item("ClienteId")
                    If drw.Table.Columns.Contains("ContratoNum") Then If IsDBNull(drw.Item("ContratoNum")) Then .str_ContratoNum = .str_ContratoNum Else .str_ContratoNum = drw.Item("ContratoNum")
                    If drw.Table.Columns.Contains("CostoMaquinaUSS") Then If IsDBNull(drw.Item("CostoMaquinaUSS")) Then .dec_CostoMaquinaUSS = .dec_CostoMaquinaUSS Else .dec_CostoMaquinaUSS = drw.Item("CostoMaquinaUSS")
                    If drw.Table.Columns.Contains("CompaniaId") Then If IsDBNull(drw.Item("CompaniaId")) Then .str_CompaniaId = .str_CompaniaId Else .str_CompaniaId = drw.Item("CompaniaId")
                    If drw.Table.Columns.Contains("CuentaInventarioDBS") Then If IsDBNull(drw.Item("CuentaInventarioDBS")) Then .str_CuentaInventarioDBS = .str_CuentaInventarioDBS Else .str_CuentaInventarioDBS = drw.Item("CuentaInventarioDBS")
                    If drw.Table.Columns.Contains("DisponibilidadEstimadaFecha") Then If Not IsDBNull(drw.Item("DisponibilidadEstimadaFecha")) Then .det_DisponibilidadEstimadaFecha = drw.Item("DisponibilidadEstimadaFecha")
                    If drw.Table.Columns.Contains("DisponibilidadFecha") Then If Not IsDBNull(drw.Item("DisponibilidadFecha")) Then .det_DisponibilidadFecha = drw.Item("DisponibilidadFecha")
                    If drw.Table.Columns.Contains("EliminadoRDA") Then If IsDBNull(drw.Item("EliminadoRDA")) Then .str_EliminadoRDA = .str_EliminadoRDA Else .str_EliminadoRDA = drw.Item("EliminadoRDA")
                    If drw.Table.Columns.Contains("EmbarqueEstimadaFecha") Then If Not IsDBNull(drw.Item("EmbarqueEstimadaFecha")) Then .det_EmbarqueEstimadaFecha = drw.Item("EmbarqueEstimadaFecha")
                    If drw.Table.Columns.Contains("EntidadFinancieraId") Then If IsDBNull(drw.Item("EntidadFinancieraId")) Then .str_EntidadFinancieraId = .str_EntidadFinancieraId Else .str_EntidadFinancieraId = drw.Item("EntidadFinancieraId")
                    If drw.Table.Columns.Contains("EntregaTallerFecha") Then If Not IsDBNull(drw.Item("EntregaTallerFecha")) Then .det_EntregaTallerFecha = drw.Item("EntregaTallerFecha")
                    If drw.Table.Columns.Contains("EstadoInventario") Then If IsDBNull(drw.Item("EstadoInventario")) Then .str_EstadoInventario = .str_EstadoInventario Else .str_EstadoInventario = drw.Item("EstadoInventario")
                    If drw.Table.Columns.Contains("EstadoRDA") Then If IsDBNull(drw.Item("EstadoRDA")) Then .str_EstadoRDA = .str_EstadoRDA Else .str_EstadoRDA = drw.Item("EstadoRDA")
                    If drw.Table.Columns.Contains("EstadoRDAFecha") Then If Not IsDBNull(drw.Item("EstadoRDAFecha")) Then .det_EstadoRDAFecha = drw.Item("EstadoRDAFecha")
                    If drw.Table.Columns.Contains("FacturaClienteFecha") Then If Not IsDBNull(drw.Item("FacturaClienteFecha")) Then .det_FacturaClienteFecha = drw.Item("FacturaClienteFecha")
                    If drw.Table.Columns.Contains("FacturaFabricaFecha") Then If Not IsDBNull(drw.Item("FacturaFabricaFecha")) Then .det_FacturaFabricaFecha = drw.Item("FacturaFabricaFecha")
                    If drw.Table.Columns.Contains("FacturaFabricaNum") Then If IsDBNull(drw.Item("FacturaFabricaNum")) Then .str_FacturaFabricaNum = .str_FacturaFabricaNum Else .str_FacturaFabricaNum = drw.Item("FacturaFabricaNum")
                    If drw.Table.Columns.Contains("FacturaImporte") Then If IsDBNull(drw.Item("FacturaImporte")) Then .dec_FacturaImporte = .dec_FacturaImporte Else .dec_FacturaImporte = drw.Item("FacturaImporte")
                    If drw.Table.Columns.Contains("FamiliaDesc") Then If IsDBNull(drw.Item("FamiliaDesc")) Then .str_FamiliaDesc = .str_FamiliaDesc Else .str_FamiliaDesc = drw.Item("FamiliaDesc")
                    If drw.Table.Columns.Contains("FinanciamientoDesc") Then If IsDBNull(drw.Item("FinanciamientoDesc")) Then .str_FinanciamientoDesc = .str_FinanciamientoDesc Else .str_FinanciamientoDesc = drw.Item("FinanciamientoDesc")
                    If drw.Table.Columns.Contains("FinanciamientoId") Then If IsDBNull(drw.Item("FinanciamientoId")) Then .str_FinanciamientoId = .str_FinanciamientoId Else .str_FinanciamientoId = drw.Item("FinanciamientoId")
                    If drw.Table.Columns.Contains("FinDescargaFecha") Then If Not IsDBNull(drw.Item("FinDescargaFecha")) Then .det_FinDescargaFecha = drw.Item("FinDescargaFecha")
                    If drw.Table.Columns.Contains("IncotermId") Then If IsDBNull(drw.Item("IncotermId")) Then .str_IncotermId = .str_IncotermId Else .str_IncotermId = drw.Item("IncotermId")
                    If drw.Table.Columns.Contains("IngresoFisicoFESAEstimadaFecha") Then If Not IsDBNull(drw.Item("IngresoFisicoFESAEstimadaFecha")) Then .det_IngresoFisicoFESAEstimadaFecha = drw.Item("IngresoFisicoFESAEstimadaFecha")
                    If drw.Table.Columns.Contains("IngresoFisicoFESAFecha") Then If Not IsDBNull(drw.Item("IngresoFisicoFESAFecha")) Then .det_IngresoFisicoFESAFecha = drw.Item("IngresoFisicoFESAFecha")
                    If drw.Table.Columns.Contains("LevanteAduaneroFecha") Then If Not IsDBNull(drw.Item("LevanteAduaneroFecha")) Then .det_LevanteAduaneroFecha = drw.Item("LevanteAduaneroFecha")
                    If drw.Table.Columns.Contains("MarcaDesc") Then If IsDBNull(drw.Item("MarcaDesc")) Then .str_MarcaDesc = .str_MarcaDesc Else .str_MarcaDesc = drw.Item("MarcaDesc")
                    If drw.Table.Columns.Contains("MarcaId") Then If IsDBNull(drw.Item("MarcaId")) Then .str_MarcaId = .str_MarcaId Else .str_MarcaId = drw.Item("MarcaId")
                    If drw.Table.Columns.Contains("ModeloProductoDesc") Then If IsDBNull(drw.Item("ModeloProductoDesc")) Then .str_ModeloProductoDesc = .str_ModeloProductoDesc Else .str_ModeloProductoDesc = drw.Item("ModeloProductoDesc")
                    If drw.Table.Columns.Contains("ModeloProductoId") Then If IsDBNull(drw.Item("ModeloProductoId")) Then .str_ModeloProductoId = .str_ModeloProductoId Else .str_ModeloProductoId = drw.Item("ModeloProductoId")
                    If drw.Table.Columns.Contains("ModeloRDA") Then If IsDBNull(drw.Item("ModeloRDA")) Then .str_ModeloRDA = .str_ModeloRDA Else .str_ModeloRDA = drw.Item("ModeloRDA")
                    If drw.Table.Columns.Contains("MotorSerie") Then If IsDBNull(drw.Item("MotorSerie")) Then .str_MotorSerie = .str_MotorSerie Else .str_MotorSerie = drw.Item("MotorSerie")
                    If drw.Table.Columns.Contains("Observaciones") Then If IsDBNull(drw.Item("Observaciones")) Then .str_Observaciones = .str_Observaciones Else .str_Observaciones = drw.Item("Observaciones")
                    If drw.Table.Columns.Contains("OficinaVentaFacturaCRMDesc") Then If IsDBNull(drw.Item("OficinaVentaFacturaCRMDesc")) Then .str_OficinaVentaFacturaCRMDesc = .str_OficinaVentaFacturaCRMDesc Else .str_OficinaVentaFacturaCRMDesc = drw.Item("OficinaVentaFacturaCRMDesc")
                    If drw.Table.Columns.Contains("OficinaVentaFacturaCRMId") Then If IsDBNull(drw.Item("OficinaVentaFacturaCRMId")) Then .str_OficinaVentaFacturaCRMId = .str_OficinaVentaFacturaCRMId Else .str_OficinaVentaFacturaCRMId = drw.Item("OficinaVentaFacturaCRMId")
                    If drw.Table.Columns.Contains("OportunidadNum") Then If IsDBNull(drw.Item("OportunidadNum")) Then .str_OportunidadNum = .str_OportunidadNum Else .str_OportunidadNum = drw.Item("OportunidadNum")
                    If drw.Table.Columns.Contains("OrdenAsignada") Then If IsDBNull(drw.Item("OrdenAsignada")) Then .str_OrdenAsignada = .str_OrdenAsignada Else .str_OrdenAsignada = drw.Item("OrdenAsignada")
                    If drw.Table.Columns.Contains("OrdenAsignadaNumCRM") Then If IsDBNull(drw.Item("OrdenAsignadaNumCRM")) Then .str_OrdenAsignadaNumCRM = .str_OrdenAsignadaNumCRM Else .str_OrdenAsignadaNumCRM = drw.Item("OrdenAsignadaNumCRM")
                    If drw.Table.Columns.Contains("OrdenFabricaFecha") Then If Not IsDBNull(drw.Item("OrdenFabricaFecha")) Then .det_OrdenFabricaFecha = drw.Item("OrdenFabricaFecha")
                    If drw.Table.Columns.Contains("PedidoId") Then If IsDBNull(drw.Item("PedidoId")) Then .str_PedidoId = .str_PedidoId Else .str_PedidoId = drw.Item("PedidoId")
                    If drw.Table.Columns.Contains("PosicionId") Then If IsDBNull(drw.Item("PosicionId")) Then .int_PosicionId = .int_PosicionId Else .int_PosicionId = drw.Item("PosicionId")
                    If drw.Table.Columns.Contains("PreEntregaEstimadaFecha") Then If Not IsDBNull(drw.Item("PreEntregaEstimadaFecha")) Then .det_PreEntregaEstimadaFecha = drw.Item("PreEntregaEstimadaFecha")
                    If drw.Table.Columns.Contains("PuertoEntradaDesc") Then If IsDBNull(drw.Item("PuertoEntradaDesc")) Then .str_PuertoEntradaDesc = .str_PuertoEntradaDesc Else .str_PuertoEntradaDesc = drw.Item("PuertoEntradaDesc")
                    If drw.Table.Columns.Contains("PuertoSalidaDesc") Then If IsDBNull(drw.Item("PuertoSalidaDesc")) Then .str_PuertoSalidaDesc = .str_PuertoSalidaDesc Else .str_PuertoSalidaDesc = drw.Item("PuertoSalidaDesc")
                    If drw.Table.Columns.Contains("RecepcionForwarderFecha") Then If Not IsDBNull(drw.Item("RecepcionForwarderFecha")) Then .det_RecepcionForwarderFecha = drw.Item("RecepcionForwarderFecha")
                    If drw.Table.Columns.Contains("RegimenImportacionMaquina") Then If IsDBNull(drw.Item("RegimenImportacionMaquina")) Then .str_RegimenImportacionMaquina = .str_RegimenImportacionMaquina Else .str_RegimenImportacionMaquina = drw.Item("RegimenImportacionMaquina")
                    If drw.Table.Columns.Contains("SalidaFabricaEstimadaFecha") Then If Not IsDBNull(drw.Item("SalidaFabricaEstimadaFecha")) Then .det_SalidaFabricaEstimadaFecha = drw.Item("SalidaFabricaEstimadaFecha")
                    If drw.Table.Columns.Contains("SalidaFabricaFecha") Then If Not IsDBNull(drw.Item("SalidaFabricaFecha")) Then .det_SalidaFabricaFecha = drw.Item("SalidaFabricaFecha")
                    If drw.Table.Columns.Contains("SalidaFecha") Then If Not IsDBNull(drw.Item("SalidaFecha")) Then .det_SalidaFecha = drw.Item("SalidaFecha")
                    If drw.Table.Columns.Contains("Semaforo") Then If IsDBNull(drw.Item("Semaforo")) Then .int_Semaforo = .int_Semaforo Else .int_Semaforo = drw.Item("Semaforo")
                    If drw.Table.Columns.Contains("SerieMaquina") Then If IsDBNull(drw.Item("SerieMaquina")) Then .str_SerieMaquina = .str_SerieMaquina Else .str_SerieMaquina = drw.Item("SerieMaquina")
                    If drw.Table.Columns.Contains("StoreId") Then If IsDBNull(drw.Item("StoreId")) Then .str_StoreId = .str_StoreId Else .str_StoreId = drw.Item("StoreId")
                    If drw.Table.Columns.Contains("UbicacionAgrupacionDesc") Then If IsDBNull(drw.Item("UbicacionAgrupacionDesc")) Then .str_UbicacionAgrupacionDesc = .str_UbicacionAgrupacionDesc Else .str_UbicacionAgrupacionDesc = drw.Item("UbicacionAgrupacionDesc")
                    If drw.Table.Columns.Contains("UbicacionDesc") Then If IsDBNull(drw.Item("UbicacionDesc")) Then .str_UbicacionDesc = .str_UbicacionDesc Else .str_UbicacionDesc = drw.Item("UbicacionDesc")
                    If drw.Table.Columns.Contains("UbicacionId") Then If IsDBNull(drw.Item("UbicacionId")) Then .str_UbicacionId = .str_UbicacionId Else .str_UbicacionId = drw.Item("UbicacionId")
                    If drw.Table.Columns.Contains("ValorVentaMaquinaCRM") Then If IsDBNull(drw.Item("ValorVentaMaquinaCRM")) Then .dec_ValorVentaMaquinaCRM = .dec_ValorVentaMaquinaCRM Else .dec_ValorVentaMaquinaCRM = drw.Item("ValorVentaMaquinaCRM")
                    If drw.Table.Columns.Contains("VendedorId") Then If IsDBNull(drw.Item("VendedorId")) Then .str_VendedorId = .str_VendedorId Else .str_VendedorId = drw.Item("VendedorId")
                    If drw.Table.Columns.Contains("CLPR") Then If IsDBNull(drw.Item("CLPR")) Then .str_CLPR = .str_CLPR Else .str_CLPR = drw.Item("CLPR")
                    If drw.Table.Columns.Contains("SUNTIP") Then If IsDBNull(drw.Item("SUNTIP")) Then .str_SUNTIP = .str_SUNTIP Else .str_SUNTIP = drw.Item("SUNTIP")
                    If drw.Table.Columns.Contains("SUNPRE") Then If IsDBNull(drw.Item("SUNPRE")) Then .int_SUNPRE = .int_SUNPRE Else .int_SUNPRE = drw.Item("SUNPRE")
                    If drw.Table.Columns.Contains("SUNNUM") Then If IsDBNull(drw.Item("SUNNUM")) Then .int_SUNNUM = .int_SUNNUM Else .int_SUNNUM = drw.Item("SUNNUM")
                    If drw.Table.Columns.Contains("Version") Then If IsDBNull(drw.Item("Version")) Then .str_Version = .str_Version Else .str_Version = drw.Item("Version")
                    If drw.Table.Columns.Contains("Proyecto") Then If IsDBNull(drw.Item("Proyecto")) Then .str_Proyecto = .str_Proyecto Else .str_Proyecto = drw.Item("Proyecto")
                    If drw.Table.Columns.Contains("Proceso") Then If IsDBNull(drw.Item("Proceso")) Then .str_Proceso = .str_Proceso Else .str_Proceso = drw.Item("Proceso")
                    If drw.Table.Columns.Contains("ClienteDesc") Then If IsDBNull(drw.Item("ClienteDesc")) Then .str_ClienteDesc = .str_ClienteDesc Else .str_ClienteDesc = drw.Item("ClienteDesc")
                    If drw.Table.Columns.Contains("SolicitoLevante") Then If IsDBNull(drw.Item("SolicitoLevante")) Then .str_SolicitoLevante = .str_SolicitoLevante Else .str_SolicitoLevante = drw.Item("SolicitoLevante")
                    If drw.Table.Columns.Contains("TieneEmparejamiento") Then If IsDBNull(drw.Item("TieneEmparejamiento")) Then .str_TieneEmparejamiento = .str_TieneEmparejamiento Else .str_TieneEmparejamiento = drw.Item("TieneEmparejamiento")
                    If drw.Table.Columns.Contains("VendedorDesc") Then If Not IsDBNull(drw.Item("VendedorDesc")) Then .str_VendedorDesc = drw.Item("VendedorDesc")
                    If drw.Table.Columns.Contains("EstadoMaquina") Then If Not IsDBNull(drw.Item("EstadoMaquina")) Then .str_EstadoMaquina = drw.Item("EstadoMaquina")
                    If drw.Table.Columns.Contains("Procedencia") Then If Not IsDBNull(drw.Item("Procedencia")) Then .str_Procedencia = drw.Item("Procedencia")
                    If drw.Table.Columns.Contains("EntradaUbicacionFecha") Then If Not IsDBNull(drw.Item("EntradaUbicacionFecha")) Then .det_EntradaUbicacionFecha = drw.Item("EntradaUbicacionFecha")
                    If drw.Table.Columns.Contains("EnvioDesaduanarFecha") Then If Not IsDBNull(drw.Item("EnvioDesaduanarFecha")) Then .det_EnvioDesaduanarFecha = drw.Item("EnvioDesaduanarFecha")
                    If drw.Table.Columns.Contains("OfrecidaClienteFecha") Then If Not IsDBNull(drw.Item("OfrecidaClienteFecha")) Then .det_OfrecidaClienteFecha = drw.Item("OfrecidaClienteFecha")
                    If drw.Table.Columns.Contains("Sucursal") Then If Not IsDBNull(drw.Item("Sucursal")) Then .str_DescripcionSucursal = drw.Item("Sucursal")
                    If drw.Table.Columns.Contains("SucursalId") Then If Not IsDBNull(drw.Item("SucursalId")) Then .str_Sucursal = drw.Item("SucursalId")
                    If drw.Table.Columns.Contains("Gerencia") Then If Not IsDBNull(drw.Item("Gerencia")) Then .str_Gerencia = drw.Item("Gerencia")
                    If drw.Table.Columns.Contains("OrdenPrincipal") Then If Not IsDBNull(drw.Item("OrdenPrincipal")) Then .str_OrdenPrincipal = drw.Item("OrdenPrincipal")
                    If drw.Table.Columns.Contains("TipoProducto") Then If Not IsDBNull(drw.Item("TipoProducto")) Then .str_TipoProducto = drw.Item("TipoProducto")
                    If drw.Table.Columns.Contains("NroCAT") Then If Not IsDBNull(drw.Item("NroCAT")) Then .str_NroCAT = drw.Item("NroCAT")
                    If drw.Table.Columns.Contains("Division") Then If Not IsDBNull(drw.Item("Division")) Then .str_Division = drw.Item("Division")
                    If drw.Table.Columns.Contains("DivisionDesc") Then If Not IsDBNull(drw.Item("DivisionDesc")) Then .str_DivisionDesc = drw.Item("DivisionDesc")
                    If drw.Table.Columns.Contains("Ritmo5Tipo") Then If Not IsDBNull(drw.Item("Ritmo5Tipo")) Then .str_Ritmo5Tipo = drw.Item("Ritmo5Tipo")
                    If drw.Table.Columns.Contains("Ritmo5Monto") Then If Not IsDBNull(drw.Item("Ritmo5Monto")) Then .dec_Ritmo5Monto = drw.Item("Ritmo5Monto")
                    If drw.Table.Columns.Contains("BonoRptoMonto") Then If Not IsDBNull(drw.Item("BonoRptoMonto")) Then .dec_BonoRptoMonto = drw.Item("BonoRptoMonto")
                    If drw.Table.Columns.Contains("Ritmo5Indicador") Then If Not IsDBNull(drw.Item("Ritmo5Indicador")) Then .bl_EsRitmo5 = IIf(drw.Item("Ritmo5Indicador") = "N", False, True)
                    If drw.Table.Columns.Contains("BonoRptoIndicador") Then If Not IsDBNull(drw.Item("BonoRptoIndicador")) Then .bl_EsBonoRpto = IIf(drw.Item("BonoRptoIndicador") = "N", False, True)
                    If drw.Table.Columns.Contains("FechaFactura") Then If Not IsDBNull(drw.Item("FechaFactura")) Then .str_FechaFactura = drw.Item("FechaFactura")
                    If drw.Table.Columns.Contains("ClienteFacturaDesc") Then If Not IsDBNull(drw.Item("ClienteFacturaDesc")) Then .str_ClienteFacturaDesc = drw.Item("ClienteFacturaDesc")
                    If drw.Table.Columns.Contains("NoTieneNroorden") Then If Not IsDBNull(drw.Item("NoTieneNroorden")) Then .int_NoTieneNroorden = drw.Item("NoTieneNroorden")
                    If drw.Table.Columns.Contains("CargoFirma") Then If Not IsDBNull(drw.Item("CargoFirma")) Then .str_CargoFirma = drw.Item("CargoFirma")
                    If drw.Table.Columns.Contains("NombreFirma") Then If Not IsDBNull(drw.Item("NombreFirma")) Then .str_NombreFirma = drw.Item("NombreFirma")
                    If drw.Table.Columns.Contains("ImagenFirma") Then If Not IsDBNull(drw.Item("ImagenFirma")) Then .byte_ImagenFirma = drw.Item("ImagenFirma")
                    If drw.Table.Columns.Contains("BeneficioId") Then If Not IsDBNull(drw.Item("BeneficioId")) Then .int_BeneficioId = drw.Item("BeneficioId")
                End With

                liBEMaquina.Add(BEMaquina)
            Next drw

            po_liBEMaquina = liBEMaquina
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    'Entidad MaquinaEmparejamiento
    Public Shared Sub fn_MapeoEntidad(ByVal pi_dtb As DataTable, ByRef po_liBEMaquinaEmparejamiento As List(Of BE_Maquina_Emparejamiento))
        Try
            Dim liBEMaquinaEmparejamiento As New List(Of BE_Maquina_Emparejamiento)
            Dim BEMaquinaEmparejamiento As New BE_Maquina_Emparejamiento

            For Each drw As DataRow In pi_dtb.Rows
                BEMaquinaEmparejamiento = New BE_Maquina_Emparejamiento
                With BEMaquinaEmparejamiento
                    If drw.Table.Columns.Contains("Orden") Then If Not IsDBNull(drw.Item("Orden")) Then .str_Orden = drw.Item("Orden")
                    If drw.Table.Columns.Contains("OrdenEmparejamiento") Then If Not IsDBNull(drw.Item("OrdenEmparejamiento")) Then .str_OrdenEmparejamiento = drw.Item("OrdenEmparejamiento")
                End With

                liBEMaquinaEmparejamiento.Add(BEMaquinaEmparejamiento)
            Next drw

            po_liBEMaquinaEmparejamiento = liBEMaquinaEmparejamiento
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Consulta Maquina
    Public Shared Sub fn_MapeoEntidad(ByVal pi_dtb As DataTable, ByRef po_liColumnasResultado As List(Of BE_Maquina_ColumnasResultado))
        Try
            Dim liMaquinaResultado As New List(Of BE_Maquina_ColumnasResultado)
            Dim be As BE_Maquina_ColumnasResultado

            For Each drw As DataRow In pi_dtb.Rows
                be = New BE_Maquina_ColumnasResultado
                With be
                    If drw.Table.Columns.Contains("Orden") Then If Not IsDBNull(drw.Item("Orden")) Then .str_OrdenAsignada = drw.Item("Orden")
                    If drw.Table.Columns.Contains("NroExpediente") Then If Not IsDBNull(drw.Item("NroExpediente")) Then .int_ExpedienteId = drw.Item("NroExpediente")
                    If drw.Table.Columns.Contains("ClienteFinal") Then If Not IsDBNull(drw.Item("ClienteFinal")) Then .str_ClienteFinal = drw.Item("ClienteFinal")
                    If drw.Table.Columns.Contains("ClienteFacturacion") Then If Not IsDBNull(drw.Item("ClienteFacturacion")) Then .str_ClienteFacturacion = drw.Item("ClienteFacturacion")
                    If drw.Table.Columns.Contains("Cuenta") Then If Not IsDBNull(drw.Item("Cuenta")) Then .str_Cuenta = drw.Item("Cuenta")
                    If drw.Table.Columns.Contains("EntidadFinanciera") Then If Not IsDBNull(drw.Item("EntidadFinanciera")) Then .str_EntidadFinanciera = drw.Item("EntidadFinanciera")
                    If drw.Table.Columns.Contains("Financiamiento") Then If Not IsDBNull(drw.Item("Financiamiento")) Then .str_Financiamiento = drw.Item("Financiamiento")
                    If drw.Table.Columns.Contains("Vendedor") Then If Not IsDBNull(drw.Item("Vendedor")) Then .str_Vendedor = drw.Item("Vendedor")
                    If drw.Table.Columns.Contains("Actividad") Then If Not IsDBNull(drw.Item("Actividad")) Then .str_Actividad = drw.Item("Actividad")
                    If drw.Table.Columns.Contains("Familia") Then If Not IsDBNull(drw.Item("Familia")) Then .str_Familia = drw.Item("Familia")
                    If drw.Table.Columns.Contains("FechaFacturacion") Then If Not IsDBNull(drw.Item("FechaFacturacion")) Then .str_FechaFacturacion = drw.Item("FechaFacturacion")
                    If drw.Table.Columns.Contains("Modelo") Then If Not IsDBNull(drw.Item("Modelo")) Then .str_Modelo = drw.Item("Modelo")
                    If drw.Table.Columns.Contains("BonoRpto") Then If Not IsDBNull(drw.Item("BonoRpto")) Then .str_BonoRpto = drw.Item("BonoRpto")
                    If drw.Table.Columns.Contains("MontoBonoRpto") Then If Not IsDBNull(drw.Item("MontoBonoRpto")) Then .str_MontoBonoRpto = drw.Item("MontoBonoRpto")
                    If drw.Table.Columns.Contains("Ritmo5") Then If Not IsDBNull(drw.Item("Ritmo5")) Then .str_Ritmo5 = drw.Item("Ritmo5")
                    If drw.Table.Columns.Contains("MontoRitmo5") Then If Not IsDBNull(drw.Item("MontoRitmo5")) Then .str_MontoRitmo5 = drw.Item("MontoRitmo5")
                    If drw.Table.Columns.Contains("ProgramaRitmo5") Then If Not IsDBNull(drw.Item("ProgramaRitmo5")) Then .str_ProgramaRitmo5 = drw.Item("ProgramaRitmo5")
                    If drw.Table.Columns.Contains("SAP") Then If Not IsDBNull(drw.Item("SAP")) Then .str_SAP = drw.Item("SAP")
                    If drw.Table.Columns.Contains("Sucursal") Then If Not IsDBNull(drw.Item("Sucursal")) Then .str_Sucursal = drw.Item("Sucursal")
                    If drw.Table.Columns.Contains("Semaforo") Then If Not IsDBNull(drw.Item("Semaforo")) Then .str_Semaforo = drw.Item("Semaforo")
                    If drw.Table.Columns.Contains("TDF") Then If Not IsDBNull(drw.Item("TDF")) Then .str_TDF = drw.Item("TDF")
                    If drw.Table.Columns.Contains("TR") Then If Not IsDBNull(drw.Item("TR")) Then .str_TR = drw.Item("TR")
                    If drw.Table.Columns.Contains("TieneFisicoRitmo5") Then If Not IsDBNull(drw.Item("TieneFisicoRitmo5")) Then .str_TieneFisicoRitmo5 = drw.Item("TieneFisicoRitmo5")
                    If drw.Table.Columns.Contains("TieneFisicoRpto") Then If Not IsDBNull(drw.Item("TieneFisicoRpto")) Then .str_TieneFisicoRpto = drw.Item("TieneFisicoRpto")
                    If drw.Table.Columns.Contains("Observaciones") Then If Not IsDBNull(drw.Item("Observaciones")) Then .str_Observaciones = drw.Item("Observaciones")
                    If drw.Table.Columns.Contains("ArchivoSustento") Then If Not IsDBNull(drw.Item("ArchivoSustento")) Then .str_ArchivoSustento = drw.Item("ArchivoSustento")
                    If drw.Table.Columns.Contains("Total") Then If Not IsDBNull(drw.Item("Total")) Then .int_Total = drw.Item("Total")
                    If drw.Table.Columns.Contains("Ritmo5") Then If drw.Item("Ritmo5") = 1 Then .bl_Ritmo5 = True ' If Not IsDBNull(drw.Item("Ritmo5")) Then .int_Total = drw.Item("Ritmo5")
                    If drw.Table.Columns.Contains("BonoRpto") Then If drw.Item("BonoRpto") = 1 Then .bl_BonoRpto = True ' If Not IsDBNull(drw.Item("Ritmo5")) Then .int_Total = drw.Item("Ritmo5")

                End With

                liMaquinaResultado.Add(be)
            Next drw

            po_liColumnasResultado = liMaquinaResultado
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    'Entidad Trabajador Adryan
    Public Shared Sub fn_MapeoEntidad(ByVal pi_dtb As DataTable, ByRef po_liBETrabajadorAdryan As List(Of BE_TrabajadorAdryan))
        Try
            Dim liBETrabajadorAdryan As New List(Of BE_TrabajadorAdryan)
            Dim BETrabajadorAdryan As New BE_TrabajadorAdryan

            For Each drw As DataRow In pi_dtb.Rows
                BETrabajadorAdryan = New BE_TrabajadorAdryan
                With BETrabajadorAdryan
                    If IsDBNull(drw.Item("COMPANIA")) Then .str_COMPANIA = .str_COMPANIA Else .str_COMPANIA = drw.Item("COMPANIA")
                    If IsDBNull(drw.Item("CODIGO")) Then .str_CODIGO = .str_CODIGO Else .str_CODIGO = drw.Item("CODIGO")
                    If IsDBNull(drw.Item("SUCURSAL")) Then .str_SUCURSAL = .str_SUCURSAL Else .str_SUCURSAL = drw.Item("SUCURSAL")
                    If IsDBNull(drw.Item("DESC_SUCURSAL")) Then .str_DESC_SUCURSAL = .str_DESC_SUCURSAL Else .str_DESC_SUCURSAL = drw.Item("DESC_SUCURSAL")
                    If IsDBNull(drw.Item("NOMBRE")) Then .str_NOMBRE = .str_NOMBRE Else .str_NOMBRE = drw.Item("NOMBRE")
                    If IsDBNull(drw.Item("MATRICULA")) Then .str_MATRICULA = .str_MATRICULA Else .str_MATRICULA = drw.Item("MATRICULA")
                    If IsDBNull(drw.Item("CORREO")) Then .str_CORREO = .str_CORREO Else .str_CORREO = drw.Item("CORREO")
                End With

                liBETrabajadorAdryan.Add(BETrabajadorAdryan)
            Next drw

            po_liBETrabajadorAdryan = liBETrabajadorAdryan
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Sub fn_MapeoEntidad(ByVal pi_dtb As DataTable, ByRef po_liBEDimCliente As List(Of BE_DimCliente2))
        Try
            Dim liBEDimCliente As New List(Of BE_DimCliente2)
            Dim BEDimCliente As New BE_DimCliente2

            For Each drw As DataRow In pi_dtb.Rows
                BEDimCliente = New BE_DimCliente2
                With BEDimCliente
                    If IsDBNull(drw.Item("SK_CLIENTE")) Then .int_SK_CLIENTE = .int_SK_CLIENTE Else .int_SK_CLIENTE = drw.Item("SK_CLIENTE")
                    If IsDBNull(drw.Item("COD_AGRUPACION")) Then .str_COD_AGRUPACION = .str_COD_AGRUPACION Else .str_COD_AGRUPACION = drw.Item("COD_AGRUPACION")
                    If IsDBNull(drw.Item("COD_CIC")) Then .str_COD_CIC = .str_COD_CIC Else .str_COD_CIC = drw.Item("COD_CIC")
                    If IsDBNull(drw.Item("COD_CLIENTE")) Then .str_COD_CLIENTE = .str_COD_CLIENTE Else .str_COD_CLIENTE = drw.Item("COD_CLIENTE")
                    If IsDBNull(drw.Item("COD_GIRO_NEGOCIO")) Then .str_COD_GIRO_NEGOCIO = .str_COD_GIRO_NEGOCIO Else .str_COD_GIRO_NEGOCIO = drw.Item("COD_GIRO_NEGOCIO")
                    If IsDBNull(drw.Item("COD_MERCADO")) Then .str_COD_MERCADO = .str_COD_MERCADO Else .str_COD_MERCADO = drw.Item("COD_MERCADO")
                    If IsDBNull(drw.Item("COD_RESP_CLIENTE")) Then .str_COD_RESP_CLIENTE = .str_COD_RESP_CLIENTE Else .str_COD_RESP_CLIENTE = drw.Item("COD_RESP_CLIENTE")
                    If IsDBNull(drw.Item("COD_SERVICIO_PREMIUM")) Then .str_COD_SERVICIO_PREMIUM = .str_COD_SERVICIO_PREMIUM Else .str_COD_SERVICIO_PREMIUM = drw.Item("COD_SERVICIO_PREMIUM")
                    If IsDBNull(drw.Item("DESC_AGRUPACION")) Then .str_DESC_AGRUPACION = .str_DESC_AGRUPACION Else .str_DESC_AGRUPACION = drw.Item("DESC_AGRUPACION")
                    If IsDBNull(drw.Item("DESC_CIC")) Then .str_DESC_CIC = .str_DESC_CIC Else .str_DESC_CIC = drw.Item("DESC_CIC")
                    If IsDBNull(drw.Item("DESC_CLIENTE")) Then .str_DESC_CLIENTE = .str_DESC_CLIENTE Else .str_DESC_CLIENTE = drw.Item("DESC_CLIENTE")
                    If IsDBNull(drw.Item("DESC_DEPARTAMENTO_CLIENTE")) Then .str_DESC_DEPARTAMENTO_CLIENTE = .str_DESC_DEPARTAMENTO_CLIENTE Else .str_DESC_DEPARTAMENTO_CLIENTE = drw.Item("DESC_DEPARTAMENTO_CLIENTE")
                    If IsDBNull(drw.Item("DESC_ESTADO_CLIENTE")) Then .str_DESC_ESTADO_CLIENTE = .str_DESC_ESTADO_CLIENTE Else .str_DESC_ESTADO_CLIENTE = drw.Item("DESC_ESTADO_CLIENTE")
                    If IsDBNull(drw.Item("DESC_GIRO_NEGOCIO")) Then .str_DESC_GIRO_NEGOCIO = .str_DESC_GIRO_NEGOCIO Else .str_DESC_GIRO_NEGOCIO = drw.Item("DESC_GIRO_NEGOCIO")
                    If IsDBNull(drw.Item("DESC_MERCADO")) Then .str_DESC_MERCADO = .str_DESC_MERCADO Else .str_DESC_MERCADO = drw.Item("DESC_MERCADO")
                    If IsDBNull(drw.Item("DESC_MOTIVO_DESACTIVACION")) Then .str_DESC_MOTIVO_DESACTIVACION = .str_DESC_MOTIVO_DESACTIVACION Else .str_DESC_MOTIVO_DESACTIVACION = drw.Item("DESC_MOTIVO_DESACTIVACION")
                    If IsDBNull(drw.Item("DESC_RESP_CLIENTE")) Then .str_DESC_RESP_CLIENTE = .str_DESC_RESP_CLIENTE Else .str_DESC_RESP_CLIENTE = drw.Item("DESC_RESP_CLIENTE")
                    If IsDBNull(drw.Item("DESC_TIPO_CLIENTE")) Then .str_DESC_TIPO_CLIENTE = .str_DESC_TIPO_CLIENTE Else .str_DESC_TIPO_CLIENTE = drw.Item("DESC_TIPO_CLIENTE")
                    If IsDBNull(drw.Item("DESC_TIPO_PERSONA")) Then .str_DESC_TIPO_PERSONA = .str_DESC_TIPO_PERSONA Else .str_DESC_TIPO_PERSONA = drw.Item("DESC_TIPO_PERSONA")
                    If IsDBNull(drw.Item("FEC_ACTUALIZACION")) Then .det_FEC_ACTUALIZACION = .det_FEC_ACTUALIZACION Else .det_FEC_ACTUALIZACION = drw.Item("FEC_ACTUALIZACION")
                    If IsDBNull(drw.Item("FEC_CREACION")) Then .det_FEC_CREACION = .det_FEC_CREACION Else .det_FEC_CREACION = drw.Item("FEC_CREACION")
                    If IsDBNull(drw.Item("FEC_REGISTRO_CLIENTE")) Then .det_FEC_REGISTRO_CLIENTE = .det_FEC_REGISTRO_CLIENTE Else .det_FEC_REGISTRO_CLIENTE = drw.Item("FEC_REGISTRO_CLIENTE")
                    If IsDBNull(drw.Item("ID_CLIENTE")) Then .str_ID_CLIENTE = .str_ID_CLIENTE Else .str_ID_CLIENTE = drw.Item("ID_CLIENTE")
                    If IsDBNull(drw.Item("NUM_IDENTIFICACION")) Then .str_NUM_IDENTIFICACION = .str_NUM_IDENTIFICACION Else .str_NUM_IDENTIFICACION = drw.Item("NUM_IDENTIFICACION")
                    If IsDBNull(drw.Item("NUM_LIMITE_CREDITO_REP")) Then .int_NUM_LIMITE_CREDITO_REP = .int_NUM_LIMITE_CREDITO_REP Else .int_NUM_LIMITE_CREDITO_REP = drw.Item("NUM_LIMITE_CREDITO_REP")
                    If IsDBNull(drw.Item("NUM_LIMITE_CREDITO_SER")) Then .int_NUM_LIMITE_CREDITO_SER = .int_NUM_LIMITE_CREDITO_SER Else .int_NUM_LIMITE_CREDITO_SER = drw.Item("NUM_LIMITE_CREDITO_SER")
                End With

                liBEDimCliente.Add(BEDimCliente)
            Next drw

            po_liBEDimCliente = liBEDimCliente
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Sub fn_MapeoEntidad(ByVal pi_dtb As DataTable, ByRef po_liBECuentaUsuario As List(Of BE_CuentaUsuario2))
        Try
            Dim liBECuentaUsuario As New List(Of BE_CuentaUsuario2)
            Dim BECuentaUsuario As New BE_CuentaUsuario2

            For Each drw As DataRow In pi_dtb.Rows
                BECuentaUsuario = New BE_CuentaUsuario2
                With BECuentaUsuario
                    If IsDBNull(drw.Item("IdUsuario")) Then .str_IdUsuario = .str_IdUsuario Else .str_IdUsuario = drw.Item("IdUsuario")
                    If IsDBNull(drw.Item("IdCuenta")) Then .str_IdCuenta = .str_IdCuenta Else .str_IdCuenta = drw.Item("IdCuenta")
                    If IsDBNull(drw.Item("CuentaDesc")) Then .str_CuentaDesc = .str_CuentaDesc Else .str_CuentaDesc = drw.Item("CuentaDesc")
                End With

                liBECuentaUsuario.Add(BECuentaUsuario)
            Next drw

            po_liBECuentaUsuario = liBECuentaUsuario
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'DTO_Maquina_Beneficio
    Public Shared Sub fn_MapeoEntidad(ByVal pi_dtb As DataTable, ByRef po_liBEMaquinaBeneficio As List(Of DTO_Maquina_Beneficio))
        Try
            Dim liBEMaquinaBeneficio As New List(Of DTO_Maquina_Beneficio)
            Dim BEMaquinaBeneficio As DTO_Maquina_Beneficio

            For Each drw As DataRow In pi_dtb.Rows
                BEMaquinaBeneficio = New DTO_Maquina_Beneficio
                With BEMaquinaBeneficio
                    If drw.Table.Columns.Contains("CompaniaId") Then If Not IsDBNull(drw.Item("CompaniaId")) Then .ComapaniaId = drw.Item("CompaniaId")
                    If drw.Table.Columns.Contains("OrdenAsignada") Then If Not IsDBNull(drw.Item("OrdenAsignada")) Then .OrdenAsignada = drw.Item("OrdenAsignada")
                    If drw.Table.Columns.Contains("BeneficioId") Then If Not IsDBNull(drw.Item("BeneficioId")) Then .BeneficioId = drw.Item("BeneficioId")
                    If drw.Table.Columns.Contains("BeneficioIdSAPDEV") Then If Not IsDBNull(drw.Item("BeneficioIdSAPDEV")) Then .BeneficioIdSAPDEV = drw.Item("BeneficioIdSAPDEV")
                    If drw.Table.Columns.Contains("BeneficioIdSAPQAS") Then If Not IsDBNull(drw.Item("BeneficioIdSAPQAS")) Then .BeneficioIdSAPDEV = drw.Item("BeneficioIdSAPQAS")
                    If drw.Table.Columns.Contains("BeneficioIdSAPPRD") Then If Not IsDBNull(drw.Item("BeneficioIdSAPPRD")) Then .BeneficioIdSAPDEV = drw.Item("BeneficioIdSAPPRD")

                    Select Case ConfigurationManager.AppSettings("EnviaCorreo").ToString
                        Case "Test"
                            If Not IsDBNull(drw.Item("BeneficioIdSAPDEV")) Then .BeneficioIdSAPCalculado = drw.Item("BeneficioIdSAPDEV")
                        Case "TestQA"
                            If Not IsDBNull(drw.Item("BeneficioIdSAPQAS")) Then .BeneficioIdSAPCalculado = drw.Item("BeneficioIdSAPQAS")
                        Case ""
                            If Not IsDBNull(drw.Item("BeneficioIdSAPQAS")) Then .BeneficioIdSAPCalculado = drw.Item("BeneficioIdSAPPRD")
                    End Select

                    If drw.Table.Columns.Contains("Descripcion") Then If Not IsDBNull(drw.Item("Descripcion")) Then .Descripcion = drw.Item("Descripcion")
                    If drw.Table.Columns.Contains("Monto") Then If Not IsDBNull(drw.Item("Monto")) Then .Monto = drw.Item("Monto")
                    If drw.Table.Columns.Contains("ClaseId") Then If Not IsDBNull(drw.Item("ClaseId")) Then .ClaseId = drw.Item("ClaseId")
                    If drw.Table.Columns.Contains("HojaInformativa") Then If Not IsDBNull(drw.Item("HojaInformativa")) Then .HojaInformativa = drw.Item("HojaInformativa")
                End With

                liBEMaquinaBeneficio.Add(BEMaquinaBeneficio)
            Next drw

            po_liBEMaquinaBeneficio = liBEMaquinaBeneficio
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'DTO_Maquina
    Public Shared Sub fn_MapeoEntidad(ByVal pi_dtb As DataTable, ByRef po_liBEMaquina As List(Of DTO_Maquina))
        Try
            Dim liBEMaquina As New List(Of DTO_Maquina)
            Dim BEMaquina As DTO_Maquina

            For Each drw As DataRow In pi_dtb.Rows
                BEMaquina = New DTO_Maquina
                With BEMaquina
                    If drw.Table.Columns.Contains("Orden") Then If Not IsDBNull(drw.Item("Orden")) Then .Orden = drw.Item("Orden")
                    If drw.Table.Columns.Contains("ExpedienteId") Then If Not IsDBNull(drw.Item("ExpedienteId")) Then .ExpedienteId = drw.Item("ExpedienteId")
                    If drw.Table.Columns.Contains("VendedorId") Then If Not IsDBNull(drw.Item("VendedorId")) Then .VendedorId = drw.Item("VendedorId")
                    If drw.Table.Columns.Contains("VendedorDesc") Then If Not IsDBNull(drw.Item("VendedorDesc")) Then .VendedorDesc = drw.Item("VendedorDesc")
                    If drw.Table.Columns.Contains("EntidadFinancieraId") Then If Not IsDBNull(drw.Item("EntidadFinancieraId")) Then .EntidadFinancieraId = drw.Item("EntidadFinancieraId")
                    If drw.Table.Columns.Contains("CuentaInventarioDBS") Then If Not IsDBNull(drw.Item("CuentaInventarioDBS")) Then .CuentaInventarioDBS = drw.Item("CuentaInventarioDBS")
                    If drw.Table.Columns.Contains("DescripcionCuenta") Then If Not IsDBNull(drw.Item("DescripcionCuenta")) Then .DescripcionCuenta = drw.Item("DescripcionCuenta")
                    If drw.Table.Columns.Contains("Sucursal") Then If Not IsDBNull(drw.Item("Sucursal")) Then .Sucursal = drw.Item("Sucursal")
                    If drw.Table.Columns.Contains("DescripcionSucursal") Then If Not IsDBNull(drw.Item("DescripcionSucursal")) Then .DescripcionSucursal = drw.Item("DescripcionSucursal")
                    If drw.Table.Columns.Contains("FinanciamientoId") Then If Not IsDBNull(drw.Item("FinanciamientoId")) Then .FinanciamientoId = drw.Item("FinanciamientoId")
                    If drw.Table.Columns.Contains("FamiliaDesc") Then If Not IsDBNull(drw.Item("FamiliaDesc")) Then .FamiliaDesc = drw.Item("FamiliaDesc")
                    If drw.Table.Columns.Contains("MarcaDesc") Then If Not IsDBNull(drw.Item("MarcaDesc")) Then .MarcaDesc = drw.Item("MarcaDesc")
                    If drw.Table.Columns.Contains("ModeloProductoDesc") Then If Not IsDBNull(drw.Item("ModeloProductoDesc")) Then .ModeloProductoDesc = drw.Item("ModeloProductoDesc")
                    If drw.Table.Columns.Contains("SerieMaquina") Then If Not IsDBNull(drw.Item("SerieMaquina")) Then .SerieMaquina = drw.Item("SerieMaquina")
                    If drw.Table.Columns.Contains("SerieMaquina") Then If Not IsDBNull(drw.Item("SerieMaquina")) Then .SerieMaquina = drw.Item("SerieMaquina")
                    If drw.Table.Columns.Contains("Ritmo5") Then If Not IsDBNull(drw.Item("Ritmo5")) Then .Ritmo5 = drw.Item("Ritmo5")
                    If drw.Table.Columns.Contains("MontoRitmo5") Then If Not IsDBNull(drw.Item("MontoRitmo5")) Then .MontoRitmo5 = drw.Item("MontoRitmo5")
                    If drw.Table.Columns.Contains("TipoRitmo5") Then If Not IsDBNull(drw.Item("TipoRitmo5")) Then .TipoRitmo5 = drw.Item("TipoRitmo5")
                    If drw.Table.Columns.Contains("BonoRpto") Then If Not IsDBNull(drw.Item("BonoRpto")) Then .BonoRpto = drw.Item("BonoRpto")
                    If drw.Table.Columns.Contains("MontoBonoRpto") Then If Not IsDBNull(drw.Item("MontoBonoRpto")) Then .MontoBonoRpto = drw.Item("MontoBonoRpto")
                    If drw.Table.Columns.Contains("Observacion") Then If Not IsDBNull(drw.Item("Observacion")) Then .Observacion = drw.Item("Observacion")
                    If drw.Table.Columns.Contains("EsFactura") Then If Not IsDBNull(drw.Item("EsFactura")) Then .EsFactura = drw.Item("EsFactura")
                    If drw.Table.Columns.Contains("SUNTIP") Then If Not IsDBNull(drw.Item("SUNTIP")) Then .SunTip = drw.Item("SUNTIP")
                    If drw.Table.Columns.Contains("SUNPRE") Then If Not IsDBNull(drw.Item("SUNPRE")) Then .SunPre = drw.Item("SUNPRE")
                    If drw.Table.Columns.Contains("SUNNUM") Then If Not IsDBNull(drw.Item("SUNNUM")) Then .SunNum = drw.Item("SUNNUM")
                    If drw.Table.Columns.Contains("IdSap") Then If Not IsDBNull(drw.Item("IdSap")) Then .IdSAP = drw.Item("IdSap")
                    'If drw.Table.Columns.Contains("EsNuevo") Then If Not IsDBNull(drw.Item("EsNuevo")) Then .EsNuevo = drw.Item("EsNuevo")
                    If drw.Table.Columns.Contains("EsBonoRpto") Then If Not IsDBNull(drw.Item("EsBonoRpto")) Then .EsBonoRpto = drw.Item("EsBonoRpto")
                    If drw.Table.Columns.Contains("EsBonoRitmo5") Then If Not IsDBNull(drw.Item("EsBonoRitmo5")) Then .EsBonoRitmo5 = drw.Item("EsBonoRitmo5")
                    If drw.Table.Columns.Contains("ClienteId") Then If Not IsDBNull(drw.Item("ClienteId")) Then .ClienteId = drw.Item("ClienteId")
                    If drw.Table.Columns.Contains("ClienteDesc") Then If Not IsDBNull(drw.Item("ClienteDesc")) Then .ClienteDesc = drw.Item("ClienteDesc")
                    If drw.Table.Columns.Contains("FechaFactura") Then If Not IsDBNull(drw.Item("FechaFactura")) Then .FechaFactura = drw.Item("FechaFactura")
                    If drw.Table.Columns.Contains("NoTieneNroOrden") Then If Not IsDBNull(drw.Item("NoTieneNroOrden")) Then .FechaFactura = drw.Item("NoTieneNroOrden")
                    If drw.Table.Columns.Contains("Total") Then If Not IsDBNull(drw.Item("Total")) Then .TotalRegistros = drw.Item("Total")
                End With

                liBEMaquina.Add(BEMaquina)
            Next drw

            po_liBEMaquina = liBEMaquina
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Entidad Incidente
    Public Shared Sub fn_MapeoEntidad(ByVal pi_dtb As DataTable, ByRef po_liBEIncidente As List(Of BE_Incidente))
        Try
            Dim liBEIncidente As New List(Of BE_Incidente)
            Dim BEIncidente As New BE_Incidente

            For Each drw As DataRow In pi_dtb.Rows
                BEIncidente = New BE_Incidente
                With BEIncidente
                    If IsDBNull(drw.Item("IdIncidente")) Then .int_IdIncidente = .int_IdIncidente Else .int_IdIncidente = drw.Item("IdIncidente")
                    If IsDBNull(drw.Item("IdUsuario")) Then .str_IdUsuario = .str_IdUsuario Else .str_IdUsuario = drw.Item("IdUsuario")
                    If IsDBNull(drw.Item("IdActividad")) Then .int_IdActividad = .int_IdActividad Else .int_IdActividad = drw.Item("IdActividad")
                    If IsDBNull(drw.Item("Flag")) Then .str_Flag = .str_Flag Else .str_Flag = drw.Item("Flag")
                    If IsDBNull(drw.Item("Fecha")) Then .det_Fecha = .det_Fecha Else .det_Fecha = drw.Item("Fecha")
                    If IsDBNull(drw.Item("ArchivoBonoRpto")) Then .str_ArchivoBonoRpto = .str_ArchivoBonoRpto Else .str_ArchivoBonoRpto = drw.Item("ArchivoBonoRpto")
                    If IsDBNull(drw.Item("ArchivoBonoCSA")) Then .str_ArchivoBonoCSA = .str_ArchivoBonoCSA Else .str_ArchivoBonoCSA = drw.Item("ArchivoBonoCSA")
                    If IsDBNull(drw.Item("ArchivoBonoRptoFirmado")) Then .str_ArchivoBonoRptoFirmado = .str_ArchivoBonoRptoFirmado Else .str_ArchivoBonoRptoFirmado = drw.Item("ArchivoBonoRptoFirmado")
                    If IsDBNull(drw.Item("ArchivoBonoCSAFirmado")) Then .str_ArchivoBonoCSAFirmado = .str_ArchivoBonoCSAFirmado Else .str_ArchivoBonoCSAFirmado = drw.Item("ArchivoBonoCSAFirmado")
                    If IsDBNull(drw.Item("ArchivoBonoRptoFisico")) Then .str_ArchivoBonoRptoFisico = .str_ArchivoBonoRptoFisico Else .str_ArchivoBonoRptoFisico = drw.Item("ArchivoBonoRptoFisico")
                    If IsDBNull(drw.Item("ArchivoBonoCSAFisico")) Then .str_ArchivoBonoCSAFisico = .str_ArchivoBonoCSAFisico Else .str_ArchivoBonoCSAFisico = drw.Item("ArchivoBonoCSAFisico")
                End With

                liBEIncidente.Add(BEIncidente)
            Next drw

            po_liBEIncidente = liBEIncidente
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Sub fn_MapeoEntidad(ByVal pi_dtb As DataTable, ByRef po_liBEExpediente As List(Of BE_Expediente))
        Try
            Dim liBEExpediente As New List(Of BE_Expediente)
            Dim BEExpediente As New BE_Expediente

            For Each drw As DataRow In pi_dtb.Rows
                BEExpediente = New BE_Expediente
                With BEExpediente
                    If drw.Table.Columns.Contains("ActividadId") Then If Not IsDBNull(drw.Item("ActividadId")) Then .int_ActividadId = drw.Item("ActividadId")
                    If drw.Table.Columns.Contains("ExpedienteId") Then If Not IsDBNull(drw.Item("ExpedienteId")) Then .int_ExpedienteId = drw.Item("ExpedienteId")
                    If drw.Table.Columns.Contains("RolFlujoId") Then If Not IsDBNull(drw.Item("RolFlujoId")) Then .int_RolFlujoId = drw.Item("RolFlujoId")
                    If drw.Table.Columns.Contains("UsuarioId") Then If Not IsDBNull(drw.Item("UsuarioId")) Then .int_UsuarioId = drw.Item("UsuarioId")
                End With

                liBEExpediente.Add(BEExpediente)
            Next drw

            po_liBEExpediente = liBEExpediente
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Entidad Tabla Maestra
    Public Shared Sub fn_MapeoEntidad(ByVal pi_dtb As DataTable, ByRef po_liBeMasterTable As List(Of BE_Roles))
        Try
            Dim liBeRoles As New List(Of BE_Roles)
            Dim BeRoles As New BE_Roles

            For Each drw As DataRow In pi_dtb.Rows
                BeRoles = New BE_Roles
                With BeRoles
                    If IsDBNull(drw.Item("RolId")) Then .int_RolId = .int_RolId Else .int_RolId = drw.Item("RolId")
                    If IsDBNull(drw.Item("ModuloId")) Then .int_ModuloId = .int_ModuloId Else .int_ModuloId = drw.Item("ModuloId")
                    If IsDBNull(drw.Item("RolesDes")) Then .str_RolesDes = .str_RolesDes Else .str_RolesDes = drw.Item("RolesDes")
                    If IsDBNull(drw.Item("UsuariosRolesStatus")) Then .bl_UsuariosRolesStatus = .bl_UsuariosRolesStatus Else .bl_UsuariosRolesStatus = drw.Item("UsuariosRolesStatus")
                End With

                liBeRoles.Add(BeRoles)
            Next drw

            po_liBeMasterTable = liBeRoles
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Sub fn_MapeoEntidad(ByVal pi_dtb As DataTable, ByRef po_liBEMaquinaArchivo As List(Of BE_MaquinaArchivo))
        Try
            Dim liBEMaquinaArchivo As New List(Of BE_MaquinaArchivo)
            Dim BEMaquinaArchivo As New BE_MaquinaArchivo

            For Each drw As DataRow In pi_dtb.Rows
                BEMaquinaArchivo = New BE_MaquinaArchivo
                With BEMaquinaArchivo
                    If drw.Table.Columns.Contains("OrdenAsignada") Then If Not IsDBNull(drw.Item("OrdenAsignada")) Then .str_OrdenAsignada = drw.Item("OrdenAsignada")
                    If drw.Table.Columns.Contains("NombreArchivo") Then If Not IsDBNull(drw.Item("NombreArchivo")) Then .str_NombreArchivo = drw.Item("NombreArchivo")
                    If drw.Table.Columns.Contains("IdClase") Then If Not IsDBNull(drw.Item("IdClase")) Then .int_IdClase = drw.Item("IdClase")
                    If drw.Table.Columns.Contains("Archivo") Then If Not IsDBNull(drw.Item("Archivo")) Then .bin_Archivo = drw.Item("Archivo")
                    If drw.Table.Columns.Contains("UsuarioCreacion") Then If Not IsDBNull(drw.Item("UsuarioCreacion")) Then .str_UsuarioCreacion = drw.Item("UsuarioCreacion")
                    If drw.Table.Columns.Contains("FechaCreacion") Then If Not IsDBNull(drw.Item("FechaCreacion")) Then .dt_FechaCreacion = drw.Item("FechaCreacion")
                    If drw.Table.Columns.Contains("UsuarioModificacion") Then If Not IsDBNull(drw.Item("UsuarioModificacion")) Then .str_UsuarioModificacion = drw.Item("UsuarioModificacion")
                    If drw.Table.Columns.Contains("FechaModificacion") Then If Not IsDBNull(drw.Item("FechaModificacion")) Then .dt_FechaModificacion = drw.Item("FechaModificacion")
                End With


                liBEMaquinaArchivo.Add(BEMaquinaArchivo)
            Next drw

            po_liBEMaquinaArchivo = liBEMaquinaArchivo
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Entidad BE_Temp_ZRda
    Public Shared Sub fn_MapeoEntidad(ByVal pi_dtb As DataTable, ByRef po_liBETemp_ZRda As List(Of BE_Temp_ZRda))
        Try
            Dim liBETemp_ZRda As New List(Of BE_Temp_ZRda)
            Dim BETemp_ZRda As New BE_Temp_ZRda

            For Each drw As DataRow In pi_dtb.Rows
                BETemp_ZRda = New BE_Temp_ZRda
                With BETemp_ZRda
                    If drw.Table.Columns.Contains("IdTemp_ZRda") Then If Not IsDBNull(drw.Item("IdTemp_ZRda")) Then .int_IdTemp_ZRda = drw.Item("IdTemp_ZRda")
                    If drw.Table.Columns.Contains("OrgFact") Then If Not IsDBNull(drw.Item("OrgFact")) Then .str_OrgFact = drw.Item("OrgFact")
                    If drw.Table.Columns.Contains("OrdAsignada") Then If Not IsDBNull(drw.Item("OrdAsignada")) Then .str_OrdAsignada = drw.Item("OrdAsignada")
                    If drw.Table.Columns.Contains("IdPosicion") Then If Not IsDBNull(drw.Item("IdPosicion")) Then .int_IdPosicion = drw.Item("IdPosicion")
                    If drw.Table.Columns.Contains("Status") Then If Not IsDBNull(drw.Item("Status")) Then .str_Status = drw.Item("Status")
                    If drw.Table.Columns.Contains("Fecha") Then If Not IsDBNull(drw.Item("Fecha")) Then .det_Fecha = drw.Item("Fecha")
                    If drw.Table.Columns.Contains("NroMotor") Then If Not IsDBNull(drw.Item("NroMotor")) Then .str_NroMotor = drw.Item("NroMotor")
                    If drw.Table.Columns.Contains("IdPedido") Then If Not IsDBNull(drw.Item("IdPedido")) Then .str_IdPedido = drw.Item("IdPedido")
                    If drw.Table.Columns.Contains("OfiVentasFac") Then If Not IsDBNull(drw.Item("OfiVentasFac")) Then .str_OfiVentasFac = drw.Item("OfiVentasFac")
                    If drw.Table.Columns.Contains("OfiVentasFacTxt") Then If Not IsDBNull(drw.Item("OfiVentasFacTxt")) Then .str_OfiVentasFacTxt = drw.Item("OfiVentasFacTxt")
                    If drw.Table.Columns.Contains("Oportunidad") Then If Not IsDBNull(drw.Item("Oportunidad")) Then .str_Oportunidad = drw.Item("Oportunidad")
                    If drw.Table.Columns.Contains("ApoyoFab") Then If Not IsDBNull(drw.Item("ApoyoFab")) Then .str_ApoyoFab = drw.Item("ApoyoFab")
                    If drw.Table.Columns.Contains("Eliminado") Then If Not IsDBNull(drw.Item("Eliminado")) Then .str_Eliminado = drw.Item("Eliminado")
                    If drw.Table.Columns.Contains("FormaPago") Then If Not IsDBNull(drw.Item("FormaPago")) Then .str_FormaPago = drw.Item("FormaPago")
                    If drw.Table.Columns.Contains("FormaPagoTxt") Then If Not IsDBNull(drw.Item("FormaPagoTxt")) Then .str_FormaPagoTxt = drw.Item("FormaPagoTxt")
                    If drw.Table.Columns.Contains("CodDbs") Then If Not IsDBNull(drw.Item("CodDbs")) Then .str_CodDbs = drw.Item("CodDbs")
                    If drw.Table.Columns.Contains("CtaInventario") Then If Not IsDBNull(drw.Item("CtaInventario")) Then .str_CtaInventario = drw.Item("CtaInventario")
                    If drw.Table.Columns.Contains("Serie") Then If Not IsDBNull(drw.Item("Serie")) Then .str_Serie = drw.Item("Serie")
                    If drw.Table.Columns.Contains("AFabricacion") Then If Not IsDBNull(drw.Item("AFabricacion")) Then .str_AFabricacion = drw.Item("AFabricacion")
                    If drw.Table.Columns.Contains("Numero") Then If Not IsDBNull(drw.Item("Numero")) Then .str_Numero = drw.Item("Numero")
                    If drw.Table.Columns.Contains("IdExtSocNegResponsable") Then If Not IsDBNull(drw.Item("IdExtSocNegResponsable")) Then .str_IdExtSocNegResponsable = drw.Item("IdExtSocNegResponsable")
                    If drw.Table.Columns.Contains("IdSapSocNegResponsable") Then If Not IsDBNull(drw.Item("IdSapSocNegResponsable")) Then .str_IdSapSocNegResponsable = drw.Item("IdSapSocNegResponsable")
                    If drw.Table.Columns.Contains("NombreResponsable") Then If Not IsDBNull(drw.Item("NombreResponsable")) Then .str_NombreResponsable = drw.Item("NombreResponsable")
                    If drw.Table.Columns.Contains("IdExtSocNegCliente") Then If Not IsDBNull(drw.Item("IdExtSocNegCliente")) Then .str_IdExtSocNegCliente = drw.Item("IdExtSocNegCliente")
                    If drw.Table.Columns.Contains("IdSapSocNegCliente") Then If Not IsDBNull(drw.Item("IdSapSocNegCliente")) Then .str_IdSapSocNegCliente = drw.Item("IdSapSocNegCliente")
                    If drw.Table.Columns.Contains("NombreCliente") Then If Not IsDBNull(drw.Item("NombreCliente")) Then .str_NombreCliente = drw.Item("NombreCliente")
                    If drw.Table.Columns.Contains("IdExtSocNegEntidadFinanciera") Then If Not IsDBNull(drw.Item("IdExtSocNegEntidadFinanciera")) Then .str_IdExtSocNegEntidadFinanciera = drw.Item("IdExtSocNegEntidadFinanciera")
                    If drw.Table.Columns.Contains("IdSapSocNegEntidadFinanciera") Then If Not IsDBNull(drw.Item("IdSapSocNegEntidadFinanciera")) Then .str_IdSapSocNegEntidadFinanciera = drw.Item("IdSapSocNegEntidadFinanciera")
                    If drw.Table.Columns.Contains("NombreEntidadFinanciera") Then If Not IsDBNull(drw.Item("NombreEntidadFinanciera")) Then .str_NombreEntidadFinanciera = drw.Item("NombreEntidadFinanciera")
                    If drw.Table.Columns.Contains("FechaCre") Then If Not IsDBNull(drw.Item("FechaCre")) Then .str_FechaCre = drw.Item("FechaCre")
                    If drw.Table.Columns.Contains("HoraCre") Then If Not IsDBNull(drw.Item("HoraCre")) Then .str_HoraCre = drw.Item("HoraCre")
                    If drw.Table.Columns.Contains("FechaMod") Then If Not IsDBNull(drw.Item("FechaMod")) Then .str_FechaMod = drw.Item("FechaMod")
                    If drw.Table.Columns.Contains("HoraMod") Then If Not IsDBNull(drw.Item("HoraMod")) Then .str_HoraMod = drw.Item("HoraMod")
                    If drw.Table.Columns.Contains("Estado") Then If Not IsDBNull(drw.Item("Estado")) Then .str_Estado = drw.Item("Estado")
                    If drw.Table.Columns.Contains("FechaCreacionTemp") Then If Not IsDBNull(drw.Item("FechaCreacionTemp")) Then .det_FechaCreacionTemp = drw.Item("FechaCreacionTemp")
                    If drw.Table.Columns.Contains("FechaModificacionTemp") Then If Not IsDBNull(drw.Item("FechaModificacionTemp")) Then .det_FechaModificacionTemp = drw.Item("FechaModificacionTemp")
                End With

                liBETemp_ZRda.Add(BETemp_ZRda)
            Next drw

            po_liBETemp_ZRda = liBETemp_ZRda
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Entidad Usuarios Modulos
    Public Shared Sub fn_MapeoEntidad(ByVal pi_dtb As DataTable, ByRef po_liBEUsuriosModulos As List(Of BE_Usuarios_Modulos))
        Try
            Dim liBEUsuariosModulos As New List(Of BE_Usuarios_Modulos)
            Dim BEUsuariosModulos As New BE_Usuarios_Modulos

            For Each drw As DataRow In pi_dtb.Rows
                BEUsuariosModulos = New BE_Usuarios_Modulos
                With BEUsuariosModulos
                    If drw.Table.Columns.Contains("FechaCreacion") Then If Not IsDBNull(drw.Item("FechaCreacion")) Then .det_FechaCreacion = drw.Item("FechaCreacion")
                    If drw.Table.Columns.Contains("FechaModificacion") Then If Not IsDBNull(drw.Item("FechaModificacion")) Then .det_FechaModificacion = drw.Item("FechaModificacion")
                    If drw.Table.Columns.Contains("Module_Administracion") Then If Not IsDBNull(drw.Item("Module_Administracion")) Then .bl_Module_Administracion = drw.Item("Module_Administracion")
                    If drw.Table.Columns.Contains("Module_ApoyoFabricante") Then If Not IsDBNull(drw.Item("Module_ApoyoFabricante")) Then .bl_Module_ApoyoFabricante = drw.Item("Module_ApoyoFabricante")
                    If drw.Table.Columns.Contains("Module_Bonos") Then If Not IsDBNull(drw.Item("Module_Bonos")) Then .bl_Module_Bonos = drw.Item("Module_Bonos")
                    If drw.Table.Columns.Contains("Module_GestionInventario") Then If Not IsDBNull(drw.Item("Module_GestionInventario")) Then .bl_Module_GestionInventario = drw.Item("Module_GestionInventario")
                    If drw.Table.Columns.Contains("UsuarioCreacion") Then If Not IsDBNull(drw.Item("UsuarioCreacion")) Then .str_UsuarioCreacion = drw.Item("UsuarioCreacion")
                    If drw.Table.Columns.Contains("UsuarioId") Then If Not IsDBNull(drw.Item("UsuarioId")) Then .int_UsuarioId = drw.Item("UsuarioId")
                    If drw.Table.Columns.Contains("UsuarioModificacion") Then If Not IsDBNull(drw.Item("UsuarioModificacion")) Then .str_UsuarioModificacion = drw.Item("UsuarioModificacion")
                    If drw.Table.Columns.Contains("UsuariosModulosId") Then If Not IsDBNull(drw.Item("UsuariosModulosId")) Then .int_UsuariosModulosId = drw.Item("UsuariosModulosId")
                End With

                liBEUsuariosModulos.Add(BEUsuariosModulos)
            Next drw

            po_liBEUsuriosModulos = liBEUsuariosModulos
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Entidad BE_Temp_ZBeneficio
    Public Shared Sub fn_MapeoEntidad(ByVal pi_dtb As DataTable, ByRef po_liBETemp_ZBeneficio As List(Of BE_Temp_ZBeneficio))
        Try
            Dim liBETemp_ZBeneficio As New List(Of BE_Temp_ZBeneficio)
            Dim BETemp_ZBeneficio As New BE_Temp_ZBeneficio

            For Each drw As DataRow In pi_dtb.Rows
                BETemp_ZBeneficio = New BE_Temp_ZBeneficio
                With BETemp_ZBeneficio
                    If drw.Table.Columns.Contains("IdTemp_ZRda") Then If Not IsDBNull(drw.Item("IdTemp_ZRda")) Then .int_IdTemp_ZRda = drw.Item("IdTemp_ZRda")
                    If drw.Table.Columns.Contains("Codigo") Then If Not IsDBNull(drw.Item("Codigo")) Then .str_Codigo = drw.Item("Codigo")
                    If drw.Table.Columns.Contains("Descripcion") Then If Not IsDBNull(drw.Item("Descripcion")) Then .str_Descripcion = drw.Item("Descripcion")
                    If drw.Table.Columns.Contains("Cantidad") Then If Not IsDBNull(drw.Item("Cantidad")) Then .int_Cantidad = drw.Item("Cantidad")
                End With

                liBETemp_ZBeneficio.Add(BETemp_ZBeneficio)
            Next drw

            po_liBETemp_ZBeneficio = liBETemp_ZBeneficio
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Entidad BE_Maquina_Beneficio
    Public Shared Sub fn_MapeoEntidad(ByVal pi_dtb As DataTable, ByRef po_liBEMaquinaBeneficio As List(Of BE_Maquina_Beneficio))
        Try
            Dim liBEMaquinaBeneficio As New List(Of BE_Maquina_Beneficio)
            Dim BEMaquinaBeneficio As New BE_Maquina_Beneficio

            For Each drw As DataRow In pi_dtb.Rows
                BEMaquinaBeneficio = New BE_Maquina_Beneficio
                With BEMaquinaBeneficio
                    If drw.Table.Columns.Contains("OrdenAsignada") Then If Not IsDBNull(drw.Item("OrdenAsignada")) Then .str_OrdenAsignada = drw.Item("OrdenAsignada")
                    If drw.Table.Columns.Contains("PedidoId") Then If Not IsDBNull(drw.Item("PedidoId")) Then .str_PedidoId = drw.Item("PedidoId")
                    If drw.Table.Columns.Contains("BeneficioId") Then If Not IsDBNull(drw.Item("BeneficioId")) Then .int_BeneficioId = drw.Item("BeneficioId")
                    If drw.Table.Columns.Contains("Descripcion") Then If Not IsDBNull(drw.Item("Descripcion")) Then .str_Descripcion = drw.Item("Descripcion")
                    If drw.Table.Columns.Contains("Monto") Then If Not IsDBNull(drw.Item("Monto")) Then .dec_Monto = drw.Item("Monto")
                End With

                liBEMaquinaBeneficio.Add(BEMaquinaBeneficio)
            Next drw

            po_liBEMaquinaBeneficio = liBEMaquinaBeneficio
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Entidad BE_Beneficio
    Public Shared Sub fn_MapeoEntidad(ByVal pi_dtb As DataTable, ByRef po_liBEBeneficio As List(Of BE_Beneficio))
        Try
            Dim liBEBeneficio As New List(Of BE_Beneficio)
            Dim BEBeneficio As New BE_Beneficio

            For Each drw As DataRow In pi_dtb.Rows
                BEBeneficio = New BE_Beneficio
                With BEBeneficio
                    If drw.Table.Columns.Contains("BeneficioId") Then If Not IsDBNull(drw.Item("BeneficioId")) Then .str_Ordenasignada = drw.Item("BeneficioId")
                    If drw.Table.Columns.Contains("BeneficioDesc") Then If Not IsDBNull(drw.Item("BeneficioDesc")) Then .str_BeneficioDesc = drw.Item("BeneficioDesc")
                    If drw.Table.Columns.Contains("ClaseId") Then If Not IsDBNull(drw.Item("ClaseId")) Then .int_ClaseId = drw.Item("ClaseId")
                    If drw.Table.Columns.Contains("NomClase") Then If Not IsDBNull(drw.Item("NomClase")) Then .str_ClaseDesc = drw.Item("NomClase")
                    If drw.Table.Columns.Contains("BeneficioIdSAPDEV") Then If Not IsDBNull(drw.Item("BeneficioIdSAPDEV")) Then .str_BeneficioIdSapDEV = drw.Item("BeneficioIdSAPDEV")
                    If drw.Table.Columns.Contains("BeneficioIdSAPQAS") Then If Not IsDBNull(drw.Item("BeneficioIdSAPQAS")) Then .str_BeneficioIdSapQAS = drw.Item("BeneficioIdSAPQAS")
                    If drw.Table.Columns.Contains("BeneficioIdSAPPRD") Then If Not IsDBNull(drw.Item("BeneficioIdSAPPRD")) Then .str_BeneficioIdSapPRD = drw.Item("BeneficioIdSAPPRD")
                    If drw.Table.Columns.Contains("NombreArchivo") Then If Not IsDBNull(drw.Item("NombreArchivo")) Then .str_NombreArchivo = drw.Item("NombreArchivo")
                    If drw.Table.Columns.Contains("TipoBusqueda") Then If Not IsDBNull(drw.Item("TipoBusqueda")) Then .int_TipoBusqueda = drw.Item("TipoBusqueda")
                    If drw.Table.Columns.Contains("HojaInformativa") Then If Not IsDBNull(drw.Item("HojaInformativa")) Then .int_HojaInformativa = drw.Item("HojaInformativa")
                    If drw.Table.Columns.Contains("DescripcionTipoBusqueda") Then If Not IsDBNull(drw.Item("DescripcionTipoBusqueda")) Then .str_DescripcionTipoBusqueda = drw.Item("DescripcionTipoBusqueda")
                End With

                liBEBeneficio.Add(BEBeneficio)
            Next drw

            po_liBEBeneficio = liBEBeneficio
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Entidad Contador Carta
    Public Shared Sub fn_MapeoEntidad(ByVal pi_dtb As DataTable, ByRef po_liBEContadorCarta As List(Of BE_ContadorCarta))
        Try
            Dim liBEContadorCarta As New List(Of BE_ContadorCarta)
            Dim BEContadorCarta As New BE_ContadorCarta

            For Each drw As DataRow In pi_dtb.Rows
                BEContadorCarta = New BE_ContadorCarta
                With BEContadorCarta
                    If pi_dtb.Columns.Contains("NumeroCarta") Then If IsDBNull(drw.Item("NumeroCarta")) Then .int_NumeroCarta = .int_NumeroCarta Else .int_NumeroCarta = drw.Item("NumeroCarta")
                End With

                liBEContadorCarta.Add(BEContadorCarta)
            Next drw

            po_liBEContadorCarta = liBEContadorCarta
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Sub fn_MapeoEntidad(ByVal pi_dtb As DataTable, ByRef po_liBEBeneficioArchivo As List(Of BE_BeneficioArchivo))
        Try
            Dim liBEBeneficioArchivo As New List(Of BE_BeneficioArchivo)
            Dim BeneficioArchivo As New BE_BeneficioArchivo

            For Each drw As DataRow In pi_dtb.Rows
                BeneficioArchivo = New BE_BeneficioArchivo
                With BeneficioArchivo
                    If pi_dtb.Columns.Contains("BeneficioId") Then If Not IsDBNull(drw.Item("BeneficioId")) Then .int_BeneficioId = drw.Item("BeneficioId")
                    If pi_dtb.Columns.Contains("NombreArchivo") Then If Not IsDBNull(drw.Item("NombreArchivo")) Then .str_NombreArchivo = drw.Item("NombreArchivo")
                    If pi_dtb.Columns.Contains("ClaseId") Then If Not IsDBNull(drw.Item("ClaseId")) Then .int_ClaseId = drw.Item("ClaseId")
                    If pi_dtb.Columns.Contains("Archivo") Then If Not IsDBNull(drw.Item("Archivo")) Then .bin_Archivo = drw.Item("Archivo")
                    If pi_dtb.Columns.Contains("UsuarioCreacion") Then If Not IsDBNull(drw.Item("UsuarioCreacion")) Then .str_UsuarioCreacion = drw.Item("UsuarioCreacion")
                End With

                liBEBeneficioArchivo.Add(BeneficioArchivo)
            Next drw

            po_liBEBeneficioArchivo = liBEBeneficioArchivo
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Sub fn_MapeoEntidad(ByVal pi_dtb As DataTable, ByRef po_liBEExpedienteArchivo As List(Of BE_ExpedienteArchivo))
        Try
            Dim liBEExpedienteArchivo As New List(Of BE_ExpedienteArchivo)
            Dim ExpedienteArchivo As New BE_ExpedienteArchivo

            For Each drw As DataRow In pi_dtb.Rows
                ExpedienteArchivo = New BE_ExpedienteArchivo
                With ExpedienteArchivo
                    If pi_dtb.Columns.Contains("ExpedienteId") Then If Not IsDBNull(drw.Item("ExpedienteId")) Then .intExpedienteId = drw.Item("ExpedienteId")
                    If pi_dtb.Columns.Contains("NombreArchivo") Then If Not IsDBNull(drw.Item("NombreArchivo")) Then .str_NombreArchivo = drw.Item("NombreArchivo")
                    If pi_dtb.Columns.Contains("ClaseId") Then If Not IsDBNull(drw.Item("ClaseId")) Then .int_ClaseId = drw.Item("ClaseId")
                    If pi_dtb.Columns.Contains("Archivo") Then If Not IsDBNull(drw.Item("Archivo")) Then .bin_Archivo = drw.Item("Archivo")
                    If pi_dtb.Columns.Contains("UsuarioCreacion") Then If Not IsDBNull(drw.Item("UsuarioCreacion")) Then .str_UsuarioCreacion = drw.Item("UsuarioCreacion")
                End With

                liBEExpedienteArchivo.Add(ExpedienteArchivo)
            Next drw

            po_liBEExpedienteArchivo = liBEExpedienteArchivo
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Entidad Expediente Comentarios
    Public Shared Sub fn_MapeoEntidad(ByVal pi_dtb As DataTable, ByRef po_liBEApoyoMaquina As List(Of BE_Expediente_Comentarios))
        Try
            Dim liBEApoyoMaquina As New List(Of BE_Expediente_Comentarios)
            Dim BEApoyoMaquina As New BE_Expediente_Comentarios

            For Each drw As DataRow In pi_dtb.Rows
                BEApoyoMaquina = New BE_Expediente_Comentarios
                With BEApoyoMaquina

                    If IsDBNull(drw.Item("ApoyoId")) Then .int_ApoyoId = .int_ApoyoId Else .int_ApoyoId = drw.Item("ApoyoId")
                    If IsDBNull(drw.Item("Comentario")) Then .str_Observacion = .str_Observacion Else .str_Observacion = drw.Item("Comentario")
                    If IsDBNull(drw.Item("UsuarioCreacion")) Then .str_UsuarioCreacion = .str_UsuarioCreacion Else .str_UsuarioCreacion = drw.Item("UsuarioCreacion")
                    If IsDBNull(drw.Item("FechaCreacion")) Then .det_FechaCreacion = .det_FechaCreacion Else .det_FechaCreacion = drw.Item("FechaCreacion")
                    If IsDBNull(drw.Item("UsuarioModificacion")) Then .str_UsuarioModificacion = .str_UsuarioModificacion Else .str_UsuarioModificacion = drw.Item("UsuarioModificacion")
                    If IsDBNull(drw.Item("FechaModificacion")) Then .det_FechaModificacion = .det_FechaModificacion Else .det_FechaModificacion = drw.Item("FechaModificacion")
                    If IsDBNull(drw.Item("UsuarioModificacion")) Then .str_UsuarioModificacion = .str_UsuarioModificacion Else .str_UsuarioModificacion = drw.Item("UsuarioModificacion")

                End With

                liBEApoyoMaquina.Add(BEApoyoMaquina)
            Next drw

            po_liBEApoyoMaquina = liBEApoyoMaquina
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Entidad Expediente Cuenta Usuario
    Public Shared Sub fn_MapeoEntidad(ByVal pi_dtb As DataTable, ByRef po_liBEApoyoMaquina As List(Of BE_CuentaUsuario))
        Try
            Dim liBEApoyoMaquina As New List(Of BE_CuentaUsuario)
            Dim BEApoyoMaquina As New BE_CuentaUsuario

            For Each drw As DataRow In pi_dtb.Rows
                BEApoyoMaquina = New BE_CuentaUsuario
                With BEApoyoMaquina

                    If IsDBNull(drw.Item("IdCuenta")) Then .str_IdCuenta = .str_IdCuenta Else .str_IdCuenta = drw.Item("IdCuenta")
                    If IsDBNull(drw.Item("DescCuentaInventario")) Then .str_DescCuentaInventario = .str_DescCuentaInventario Else .str_DescCuentaInventario = drw.Item("DescCuentaInventario")
                    If IsDBNull(drw.Item("CuentaUsuarioStatus")) Then .bl_CuentaUsuarioStatus = .bl_CuentaUsuarioStatus Else .bl_CuentaUsuarioStatus = drw.Item("CuentaUsuarioStatus")
                    If IsDBNull(drw.Item("IdUsuario")) Then .str_IdUsuario = .str_IdUsuario Else .str_IdUsuario = drw.Item("IdUsuario")

                End With

                liBEApoyoMaquina.Add(BEApoyoMaquina)
            Next drw

            po_liBEApoyoMaquina = liBEApoyoMaquina
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Fecha SRC
    Public Shared Sub fn_MapeoEntidad(ByVal pi_dtb As DataTable, ByRef po_liBEApoyoMaquina As List(Of DTO_Consulta_FechasSalesRecordCard))
        Try
            Dim liBE As New List(Of DTO_Consulta_FechasSalesRecordCard)
            Dim BE As New DTO_Consulta_FechasSalesRecordCard

            For Each drw As DataRow In pi_dtb.Rows
                BE = New DTO_Consulta_FechasSalesRecordCard
                With BE
                    If IsDBNull(drw.Item("OrdenAsignada")) Then .OrdenAsignada = .OrdenAsignada Else .OrdenAsignada = drw.Item("OrdenAsignada")
                    If IsDBNull(drw.Item("ClienteFacturaId")) Then .ClienteFacturacion = .ClienteFacturacion Else .ClienteFacturacion = drw.Item("ClienteFacturaId")
                    If IsDBNull(drw.Item("FechaSRC")) Then .FechaSRC_SQL = .FechaSRC_SQL Else .FechaSRC_SQL = drw.Item("FechaSRC")
                End With

                liBE.Add(BE)
            Next drw

            po_liBEApoyoMaquina = liBE
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


#End Region

End Class
