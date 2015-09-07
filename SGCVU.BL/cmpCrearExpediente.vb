Imports System.Configuration
Imports SGCVU.BE
Public Class cmpCrearExpediente
    Public Shared Function fn_CrearExpedienteNew(ByVal pi_strIdUsuario As String, ByVal pi_liBEOrden As List(Of BE_Maquina), ByVal pi_bolFlagFacturaManual As Boolean) As Integer
        Try
            Dim intExpedienteId As Integer = 0

            Dim strResult As String = String.Empty

            Dim liBEOrden As New List(Of BE_Maquina)

            For Each it As BE_Maquina In pi_liBEOrden
                liBEOrden.Add(it)
            Next it
            'liBEOrden = pi_liBEOrden

            Dim strINVI As String = String.Empty
            Dim decIMPDOL As Decimal = CDec(0)

            Dim bolINVI As Boolean = False
            Dim bolIMPDOL As Boolean = False

            Dim liBEOrdenDel As New List(Of BE_Maquina)
            Dim BEOrdenDel As New BE_Maquina

            For Each it As BE_Maquina In liBEOrden
                'Obtener el resultado de las validaciones
                bolINVI = fn_ValidarINVI(it.str_OrdenAsignada) 'Valida que INVI sea 'S'
                bolIMPDOL = fn_ValidarIMPDOL(it) 'Valida que IMPDOL sea > 0

                'Validar que se cumplan las validaciones
                If bolINVI Or bolIMPDOL Then
                    BEOrdenDel = it
                    liBEOrdenDel.Add(BEOrdenDel)
                End If
            Next it

            Dim liBEOrdenNew As New List(Of BE_Maquina)
            For Each it As BE_Maquina In liBEOrden
                liBEOrdenNew.Add(it)
            Next it
            'liBEOrdenNew = liBEOrden

            'Eliminar de la lista principal las ordenes que no pasan la validación
            For Each itDel As BE_Maquina In liBEOrdenDel
                For Each it As BE_Maquina In liBEOrdenNew
                    If itDel.str_OrdenAsignada = it.str_OrdenAsignada Then liBEOrden.Remove(it)
                Next it
            Next itDel

            ''Reemplazar la lista original con la lista nueva
            'liBEOrden = liBEOrdenNew

            'Con la lista resultante se crea el incidente
            If liBEOrden.Count > 0 Then
                For Each it As BE_Maquina In liBEOrden
                    'buscar la Fecha de Factura Cliente
                    Dim liBEUFPRV010 As New List(Of BE_UFPRV010)
                    Dim BEUFPRV010 As New BE_UFPRV010
                    BEUFPRV010.str_REFEREN = it.str_OrdenAsignada
                    BEUFPRV010.str_SUNTIP = it.str_SUNTIP
                    BEUFPRV010.str_SUNPRE = it.int_SUNPRE
                    BEUFPRV010.str_SUNNUM = it.int_SUNNUM

                    If it.int_NoTieneNroorden = "1" Then
                        liBEUFPRV010 = clsUFPRV010.fn_Select_ListaUFPRV010_x_NroSunat(BEUFPRV010, "N")
                    Else
                        liBEUFPRV010 = clsUFPRV010.fn_Select_ListaUFPRV010(BEUFPRV010) 'esta viniendo solo un registro con la fecha mas actual del contrato vigente
                    End If

                    For Each it3 As BE_UFPRV010 In liBEUFPRV010
                        Select Case pi_bolFlagFacturaManual
                            Case True  'Factura manual
                                'actualiza la fecha de facturación de la unidad con la fecha de la factura manual
                                Dim BEOrden As New BE_Maquina
                                BEOrden.str_OrdenAsignada = it.str_OrdenAsignada
                                BEOrden.str_FechaFactura = clsUtil.fn_detFecha_String_A_Date(it3.str_FECDOC)
                                clsMaquina.fn_Update_FechaFacturaCliente(BEOrden)

                            Case False 'Factura automática
                                If it3.str_CNTRD8 <> "0" Then 'fecha del contrato vigente de facturación automática
                                    'OK
                                    'actualiza la fecha de facturación de la unidad con la fecha del contrato actual
                                    Dim BEOrden As New BE_Maquina
                                    BEOrden.str_OrdenAsignada = it.str_OrdenAsignada
                                    BEOrden.str_FechaFactura = clsUtil.fn_detFecha_String_A_Date(it3.str_CNTRD8)
                                    clsMaquina.fn_Update_FechaFacturaCliente(BEOrden)
                                ElseIf it3.str_CNTRD8 = "0" Then
                                    'OK
                                    'actualiza la fecha de facturación de la unidad con la fecha del contrato actual
                                    Dim BEOrden As New BE_Maquina
                                    BEOrden.str_OrdenAsignada = it.str_OrdenAsignada
                                    BEOrden.str_FechaFactura = clsUtil.fn_detFecha_String_A_Date(it3.str_FECDOC)
                                    clsMaquina.fn_Update_FechaFacturaCliente(BEOrden)
                                End If
                        End Select
                    Next it3
                Next it

                'crear el incidente
                Dim BEExpediente As New BE_Expediente
                BEExpediente.int_UsuarioId = pi_strIdUsuario
                BEExpediente.int_ActividadId = ConfigurationManager.AppSettings("InicioFlujo").ToString
                BEExpediente.int_RolFlujoId = "1" 'Habilitado

                strResult = clsExpediente.fn_Insert_ListaIncidente(BEExpediente)

                If strResult.Substring(0, 1) = "0" Then
                    'error
                ElseIf strResult.Substring(0, 1) = "1" Then
                    'ok
                    intExpedienteId = strResult.Replace("1_", "")
                End If

                'Inserta a incidente historico
                Dim BEExpedienteHist As New BE_ExpedienteHistorial
                With BEExpedienteHist
                    .int_ExpedienteId = intExpedienteId
                    .int_ActividadId = BEExpediente.int_ActividadId
                    .int_RolFlujoId = "1"
                    .int_UsuarioId = "1"
                End With

                clsIncidenteHist.fn_Insert_ListaExpedienteHist(BEExpedienteHist)

                'actualizar las ordenes con el número de incidente generado
                For Each it4 As BE_Maquina In liBEOrden 'sobre la lista de ordenes que quedaron despues de la limpieza
                    it4.int_ExpedienteId = intExpedienteId

                    clsMaquina.fn_Update_IdIncidente(it4)

                    'If it4.str_BonoRptoIndicador = "S" Then
                    '   cmpAsignarBonoRepuesto.fn_AsignarBonoRepuesto(it4, pi_strIdUsuario) 'calcula bono repuesto
                    'End If

                    If it4.str_Ritmo5Indicador = "S" Then
                        cmpAsignarBonoRitmo5.fn_AsignarBonoRitmo5(it4) 'calcula bono ritmo 5
                    End If

                Next it4
            End If

            Return intExpedienteId
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Shared Function fn_ValidarINVI(ByVal pi_strOrden As String) As Boolean
        Try
            Dim bolINVI As Boolean = False

            Dim liBEEMPEQPD0 As New List(Of BE_EMPEQPD2)
            liBEEMPEQPD0 = clsEMPEQPD0_2.fn_Select_ListaEMPEQPD0(pi_strOrden)

            If liBEEMPEQPD0.Count > 0 Then
                For Each it As BE_EMPEQPD2 In liBEEMPEQPD0
                    If it.str_INVI.ToUpper <> "S" And it.str_INVI <> "Y" Then
                        bolINVI = True
                    End If
                Next it
            Else
                bolINVI = True
            End If

            Return bolINVI
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Shared Function fn_ValidarIMPDOL(ByVal pi_BEOrden As BE_Maquina) As Boolean
        Try
            Dim bolIMPDOL As Boolean = False

            Dim liBEUFPRV010_UFPRV110 As New List(Of BE_UFPRV010_UFPRV110)
            Dim BEUFPRV010_UFPRV110 As New BE_UFPRV010_UFPRV110

            BEUFPRV010_UFPRV110.str_REFEREN = pi_BEOrden.str_OrdenAsignada
            BEUFPRV010_UFPRV110.strCLPR = pi_BEOrden.str_CLPR
            BEUFPRV010_UFPRV110.strSUNTIP = pi_BEOrden.str_SUNTIP
            BEUFPRV010_UFPRV110.strSUNPRE = pi_BEOrden.int_SUNPRE
            BEUFPRV010_UFPRV110.strSUNNUM = pi_BEOrden.int_SUNNUM

            If pi_BEOrden.int_NoTieneNroorden = "1" Then
                liBEUFPRV010_UFPRV110 = clsUFPRV010_UFPRV110.fn_Select_ListaUFPRV010_UFPRV110_NumFactura(BEUFPRV010_UFPRV110)
            Else
                liBEUFPRV010_UFPRV110 = clsUFPRV010_UFPRV110.fn_Select_ListaUFPRV010_UFPRV110(BEUFPRV010_UFPRV110)
            End If

            If liBEUFPRV010_UFPRV110.Count > 0 Then
                For Each it As BE_UFPRV010_UFPRV110 In liBEUFPRV010_UFPRV110
                    If it.dec_IMPDOL <= 0 Then
                        bolIMPDOL = True
                    End If
                Next it
            Else
                bolIMPDOL = True
            End If

            Return bolIMPDOL
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
