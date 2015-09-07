Imports SGCVU.BE
Imports SGCVU.BL
Imports System.Reflection
Imports System.Globalization
Imports SGCVU.DTO
Imports System.Web.Security
Imports System.String
Imports System.Text
Imports System.IO
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Configuration.ConfigurationManager
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports iTextSharp.text.pdf
Imports System.Linq
Public Class frmResultado
    Inherits System.Web.UI.Page

#Region "Atributos"

    Private pr_rptCartaBono As New ReportDocument
    Private pr_rptUnidades As New ReportDocument
    Private pr_rptsubUnidades As SubreportObject = Nothing
    Private pr_rptBonoLeasing As New ReportDocument
    Private pr_rptsubBonoLeasing As SubreportObject = Nothing

    Private pr_strReportPathCartaBono As String = String.Empty
    Private pr_strReportPathUnidades As String = String.Empty
    Private pr_strReportPathBonoLeasing As String = String.Empty
#End Region

#Region "Servicios"

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function ObtenerDatosCombos()
        'Threading.Thread.Sleep(1000)
        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()
        Try

            'LISTADO DE ESTADOS
            Dim liBEMasterTable As New List(Of BE_Master_Table)
            Dim BeMasterTable As New BE_Master_Table With {.str_MasterTable_Key = "StateMachine"}
            liBEMasterTable = clsMaster_Table.fn_Select_MasterTable_ByKey(BeMasterTable)
            liBEMasterTable.RemoveAll(Function(x) x.str_MasterTable_Valor = "N")

            Dim liEstados = New List(Of Object)
            liEstados.Add(New With {Key .id = "-1", .desc = "Seleccione"})
            For item As Integer = 0 To liBEMasterTable.Count - 1
                liEstados.Add(New With {Key .id = liBEMasterTable(item).str_MasterTable_Valor, .desc = liBEMasterTable(item).str_MasterTable_Descripcion})
            Next item
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''        

            'LISTADO DE ACTIVIDADES
            Dim liBEActividadTable As New List(Of BE_Actividad)
            liBEActividadTable = clsActividad.fn_Select_Actividad_BonoFlujo()

            Dim liActividades = New List(Of Object)

            liActividades.Add(New With {Key .id = "-1", .desc = "Seleccione"})
            For item As Integer = 0 To liBEActividadTable.Count - 1
                liActividades.Add(New With {Key .id = liBEActividadTable(item).int_ActividadId, .desc = liBEActividadTable(item).ActividadDesc})
            Next item
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            'Dim loginUsuario As String = HttpContext.Current.Session("LoginAuthentications")
            'Dim liDTOConfiguracionColumnasUsuario = clsConfiguracion_Columnas_Usuario.fn_Select_Configuracion_Columnas_Usuario_Activas("InventarioMaquina", loginUsuario)

            objRpta.data = New With {Key .estados = liEstados, .actividades = liActividades}
        Catch ex As Exception
            objRpta.success = False
            objRpta.msg = String.Format("Message: {0} - StackTrace: {1}", ex.Message, ex.StackTrace)
        End Try
        Return objRpta
    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function ListarGrilla(ByVal page As Integer, ByVal rows As Integer, ByVal sidx As String, ByVal sord As String, ByVal pSucursal As String, ByVal pMarca As String, ByVal pModelo As String, ByVal pSemaforo As String, ByVal pFecIni As String, ByVal pFecFin As String, ByVal pOrden As String, ByVal pCliente As String, ByVal pVendedor As String, ByVal pActividad As String, ByVal pEstado As String)
        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()
        Try
            Dim total As Integer = 0

            'LISTADO DE ESTADOS
            Dim liBEMaquinaResultado As New List(Of BE_Maquina_ColumnasResultado)
            'Dim BeMaquinaResultado As New BE_Maquina_ColumnasResultado With {.str_MasterTable_Key = "StateMachine"}
            liBEMaquinaResultado = clsMaquina.fn_Select_Maquina_Resultado(total, page, rows, "", pOrden, pCliente, pSucursal, pSucursal, pMarca, pModelo, pVendedor, pEstado, pActividad, pSemaforo, pFecIni, pFecFin)

            If liBEMaquinaResultado.Count > 0 Then
                total = liBEMaquinaResultado.Item(0).int_Total
            End If

            Dim sgResult As Object = New With {Key .rows = liBEMaquinaResultado,
                                           .page = page,
                                           .total = Math.Ceiling(total / Convert.ToDecimal(rows)),
                                           .records = total
                                          }
            Return sgResult

        Catch ex As Exception
            objRpta.success = False
            objRpta.msg = String.Format("Message: {0} - StackTrace: {1}", ex.Message, ex.StackTrace)
        End Try
        Return objRpta
    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function ModificarDatosMaquina(ByVal pExpediente As Integer, ByVal pOrden As String, ByVal pTipo As Integer, ByVal pObservacion As String, ByVal pMontoRpto As Decimal, ByVal pMontoRitmo5 As Decimal)

        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()

        Try
            Dim total As Integer = 0
            Dim vBE_Maquina As New BE_Maquina
            With vBE_Maquina
                .str_Observaciones = pObservacion
                .str_OrdenAsignada = pOrden
                .dec_BonoRptoMonto = pMontoRpto
                .dec_Ritmo5Monto = pMontoRitmo5
                .int_PosicionId = pTipo
                .int_ExpedienteId = pExpediente

            End With

            'LISTADO DE ESTADOS
            Dim Resultado As String
            'Dim BeMaquinaResultado As New BE_Maquina_ColumnasResultado With {.str_MasterTable_Key = "StateMachine"}
            Resultado = clsMaquina.fn_Update_Maquina_Datos(vBE_Maquina)

            Dim liBEMaquina As New List(Of BE_Maquina)
            liBEMaquina = clsMaquina.fn_Select_Maquina_Expediente(vBE_Maquina)

            objRpta.data = New With {Key .Resultado = Resultado, .listadoIncidencias = liBEMaquina}

            'objRpta.data = Resultado
            objRpta.success = True
            objRpta.msg = "Datos grabados satisfactoriamente."

            Return objRpta

        Catch ex As Exception
            objRpta.success = False
            objRpta.msg = String.Format("Message: {0} - StackTrace: {1}", ex.Message, ex.StackTrace)
        End Try
    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function ListarIncidencias(ByVal pExpediente As Integer, ByVal pEstadoMaquina As String)
        'Threading.Thread.Sleep(1000)
        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()
        Dim vBE_Maquina As New BE_Maquina
        Dim ActividadActual As Integer = 0
        Dim CompaniaId As Integer = 0
        Dim EsRitmo5 As Boolean = False
        Dim EsBonoRpto As Boolean = False
        Dim TieneRitmo5 As Boolean = False
        Dim TieneBonoRpto As Boolean = False
        Dim Advertencia As Object = Nothing
        Dim Archivos As Object = Nothing
        Dim ActividadEstados As Object = Nothing
        Dim Actividad As Object = Nothing
        Dim ControlesFlujo As Object = Nothing
        Dim ArchivosFirmados As Object = Nothing
        Dim ListaExpedientes As List(Of BE_Maquina) = Nothing

        Try

            vBE_Maquina.int_ExpedienteId = pExpediente
            vBE_Maquina.str_EstadoMaquina = pEstadoMaquina
            Dim total As Integer = 0

            'LISTADO DE ESTADOS
            Dim liBEMaquinaResultado As New List(Of BE_Maquina)
            'Dim BeMaquinaResultado As New BE_Maquina_ColumnasResultado With {.str_MasterTable_Key = "StateMachine"}



            'encontrar la actividad asociada al incidente
            Dim BEExpediente As New BE_Expediente
            Dim liBEExpediente As New List(Of BE_Expediente)
            BEExpediente.int_ExpedienteId = pExpediente
            BEExpediente.int_ActividadId = 0

            liBEExpediente = clsExpediente.fn_SelectMaquina_ListaExpediente(BEExpediente)

            If liBEExpediente.Count = 1 Then
                ActividadActual = liBEExpediente.Item(0).int_ActividadId
                fn_BuscarActividades(pExpediente, ActividadActual, ActividadEstados)
                sb_PintarActividad(ActividadActual, Actividad)
            End If


            'Pintar relación de unidades
            vBE_Maquina = New BE_Maquina


            'BEOrden.str_IdCompania = .str_IdCompania
            'BEOrden.str_Orden = String.Empty
            vBE_Maquina.int_ExpedienteId = pExpediente
            vBE_Maquina.str_EstadoMaquina = "ACT" '.str_EstadoRegistro  '"ACT"


            'Actividades Realizadas
            'sb_PintarGrilla_IncidenteHist(.int_IdIncidente)

            Dim liBEExpedienteHist As New List(Of BE_ExpedienteHistorial)
            Dim BEExpedienteHist As New BE_ExpedienteHistorial

            BEExpedienteHist.int_ExpedienteId = pExpediente

            'devuelve 
            liBEExpedienteHist = clsExpediente_Historial.fn_Select_ListaExpedienteHist(BEExpedienteHist) 'clsIncidenteHist.fn_Select_ListaIncidenteHist(BEIncidenteHist)
            ''''''

            CompaniaId = 1 'liBEOrden.Item(0).str_IdCompania

            'traemos todos los datos de las unidades relacionadas al incidente de la orden seleccionada
            sb_MostrarArchivos_PintarGrillaOrdenes(pExpediente, EsRitmo5, EsBonoRpto, TieneRitmo5, TieneBonoRpto, ListaExpedientes)


            sb_MostrarMensajeAdvertencia(pExpediente, vBE_Maquina, Advertencia)

            'Pintar Check de Archivo físico
            sb_MostrarArchivosFisicos(ActividadActual, liBEExpediente, 1, Archivos)

            sb_MostrarControlesFlujo(ActividadActual, 1, ControlesFlujo)

            sb_MostrarCargarArchivosFirmados(1, ActividadActual, 1, ArchivosFirmados, Archivos)


            'If ActividadActual >= ConfigurationManager.AppSettings("IngresoCarta").ToString Then 'solo se muestra cuando ya esta en la actividad fijada
            '    tdBono.Visible = True
            '    tdRitmo5Firmado.Visible = True

            '    sb_MostrarArchivosFirmados(CInt(Me.lblIdIncidente.Text))
            'Else 'aun no llega a la actividad donde se puede ver archivos firmados
            '    tdBono.Visible = False
            '    tdRitmo5Firmado.Visible = False
            'End If

            objRpta.data = New With {Key .EsRitmo5 = EsRitmo5, .EsBonoRpto = EsBonoRpto, .TieneRitmo5 = TieneRitmo5, _
                                     .TieneBonoRpto = TieneBonoRpto, .Advertencia = Advertencia, _
                                     .Archivos = Archivos, .ActividadEstados = ActividadEstados, .Actividad = Actividad, _
                                     .ControlesFlujo = ControlesFlujo, .liBEExpediente = liBEExpediente, .ListaExpedientes = ListaExpedientes, .ListaHistorial = liBEExpedienteHist, _
                                     .ArchivosFirmados = ArchivosFirmados}

            Return objRpta

        Catch ex As Exception
            objRpta.success = False
            objRpta.msg = String.Format("Message: {0} - StackTrace: {1}", ex.Message, ex.StackTrace)
        End Try
        Return objRpta
    End Function

    Private Shared Sub sb_MostrarCargarArchivosFirmados(ByVal pOrden As Integer, ByVal pActividadActual As Integer, ByVal pIdRolFlujo As Integer, ByRef Objeto As Object, ByVal pArchivos As Object)
        Dim tdfulBonoFirmado As Boolean = False
        Dim tdfulRitmo5Firmado As Boolean = False
        Dim btnAgregarArchivoBono As Boolean = False
        Dim btnAgregarArchivoRitmo5 As Boolean = False
        Dim TieneArchivoBono As Boolean = CType(pArchivos.TieneArchivoBono, Boolean)
        Dim TieneArchivoSCA As Boolean = CType(pArchivos.TieneArchivoCSA, Boolean)
        Try
            Select Case pIdRolFlujo
                Case 8 'Consulta General
                    tdfulBonoFirmado = False
                    tdfulRitmo5Firmado = False
                    btnAgregarArchivoBono = False
                    btnAgregarArchivoRitmo5 = False
                Case Else
                    If pActividadActual = ConfigurationManager.AppSettings("IngresoCarta").ToString Then
                        '''''SE DEBE MODIFICAR ESTA PORCIÓN DE CÓDIGO
                        If TieneArchivoBono Then
                            tdfulBonoFirmado = True
                            btnAgregarArchivoBono = True
                        Else
                            tdfulBonoFirmado = False
                            btnAgregarArchivoBono = False
                        End If

                        If TieneArchivoBono Then
                            tdfulRitmo5Firmado = True
                            btnAgregarArchivoRitmo5 = True
                        Else
                            tdfulRitmo5Firmado = False
                            btnAgregarArchivoRitmo5 = False
                        End If
                    Else
                        tdfulBonoFirmado = False
                        tdfulRitmo5Firmado = False
                        btnAgregarArchivoBono = False
                        btnAgregarArchivoRitmo5 = False
                    End If
            End Select

            Dim objRpta As Object

            objRpta = New With {Key .tdfulBonoFirmado = tdfulBonoFirmado,
            .tdfulRitmo5Firmado = tdfulRitmo5Firmado,
            .btnAgregarArchivoBono = btnAgregarArchivoBono,
            .btnAgregarArchivoRitmo5 = btnAgregarArchivoRitmo5
            }

            Objeto = objRpta

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Shared Sub sb_MostrarControlesFlujo(ByVal pActividadActual As Integer, ByVal pIdRolFlujo As Integer, ByRef Objeto As Object)
        Dim btnHSiguiente As Boolean = False
        Dim btnHAnterior As Boolean = False
        Dim btnVSiguiente As Boolean = False
        Dim btnVAnterior As Boolean = False
        Try
            Select Case pIdRolFlujo
                Case 7 'Administrador
                    Select Case pActividadActual
                        Case 14
                            'Me.btnAnterior.Enabled = False
                            btnHSiguiente = True
                            btnVSiguiente = True
                        Case 20
                            'Me.btnAnterior.Visible = False
                            btnVSiguiente = False
                        Case 16, 17, 18, 19 'ELSE 3
                            btnHAnterior = True
                            btnHSiguiente = True

                            btnVAnterior = True
                            btnVSiguiente = True
                    End Select
                Case 1 'Analista
                    Select Case pActividadActual
                        Case 15, 14, 16, 17 '3
                            btnVAnterior = True
                            btnVSiguiente = True
                            btnHAnterior = True
                            btnHSiguiente = True
                            'Case 2, 6, 7, 8
                            '    Me.btnAnterior.Visible = False
                            '    Me.btnSiguiente.Visible = False
                        Case 18, 19, 20 '6, 7, 8
                            btnVAnterior = False
                            btnVSiguiente = False
                        Case 0, 13 'Pendiente
                            btnHAnterior = False
                            btnHSiguiente = True
                            btnVSiguiente = True


                    End Select
                Case 2 'Aprobador
                    Select Case pActividadActual
                        'Case 2
                        '    Me.btnAnterior.Visible = True
                        '    Me.btnSiguiente.Visible = True
                        Case 14, 16, 17, 18, 19, 20 '1, 3, 4, 5, 6, 7, 8
                            btnVAnterior = False
                            btnVSiguiente = False
                        Case 0, 13 'Pendiente
                            btnHAnterior = False
                            btnHSiguiente = False
                    End Select
                Case 3, 4 'Asistente -> 'Vendedor
                    Select Case pActividadActual
                        Case 16, 17 '3, 4, 5
                            btnVAnterior = True
                            btnVSiguiente = True
                            btnHSiguiente = True
                            btnHAnterior = True
                        Case 14, 18, 19, 20 '1, 6, 7, 8
                            btnVAnterior = False
                            btnVSiguiente = False
                            'Case 1, 2, 6, 7, 8
                            '    Me.btnAnterior.Visible = False
                            '    Me.btnSiguiente.Visible = False
                        Case 0, 13 'Pendiente
                            btnHAnterior = False
                            btnHSiguiente = False
                    End Select
                Case 5, 6 'Aplica Bono Repuesto -> 'Aplica Bono Ritmo5
                    Select Case pActividadActual
                        Case 18, 19 '6, 7
                            btnVAnterior = True
                            btnVSiguiente = True
                            btnHSiguiente = True
                            btnHAnterior = True
                            'Case 1, 2, 3, 4, 5, 8
                            '    Me.btnAnterior.Visible = False
                            '    Me.btnSiguiente.Visible = False
                        Case 14, 16, 17, 20 '1, 3, 4, 5, 8
                            btnVAnterior = False
                            btnVSiguiente = False
                        Case 0, 13 'Pendiente
                            btnHAnterior = False
                            btnHSiguiente = False
                    End Select
                Case 8 'Consulta General
                    btnVAnterior = False
                    btnVSiguiente = False
            End Select

            Dim objRpta As Object

            objRpta = New With {Key .btnHSiguiente = btnHSiguiente,
                                    .btnHAnterior = btnHAnterior,
                                    .btnVSiguiente = btnVSiguiente,
                                    .btnVAnterior = btnVAnterior}
            Objeto = objRpta
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Shared Sub sb_MostrarArchivos_PintarGrillaOrdenes(ByVal pExpediente As Integer, ByRef pEsRitmo5 As Boolean, ByRef pEsBonoRpto As Boolean, ByRef pExisteArchivoRitmo5 As Boolean, ByRef pExisteArchivoBonoRpto As Boolean, ByRef listaExpedientes As List(Of BE_Maquina))
        Try
            Dim strPathCartaBono As String = HttpContext.Current.Server.MapPath(Concat("~\", ConfigurationManager.AppSettings("dirCartas").ToString, "\Bono_", pExpediente.ToString, ".pdf"))
            Dim strPathCartaRitmo5 As String = HttpContext.Current.Server.MapPath(Concat("~\", ConfigurationManager.AppSettings("dirCartas").ToString, "\Ritmo5_", pExpediente.ToString, ".pdf"))

            Dim strRutaCarta As String = ConfigurationManager.AppSettings("dirCartas").ToString
            Dim varArchivo As String = HttpContext.Current.Request.Url.AbsoluteUri
            Dim strArchivo() As String = varArchivo.Split("/")
            '{Length=6}
            '    (0): "http:"
            '    (1): ""
            '    (2): "localhost:2274"
            '    (3): "PROGCRC-Home"
            '    (4): "PublicacionesCRC"
            '    (5): "ContenidoPublicaciones.aspx"
            Dim strUrlCartaBono As String = Concat(strArchivo(0), "//", strArchivo(2), "/", strArchivo(3), "/", strRutaCarta, "/Bono_", pExpediente.ToString, ".pdf")
            Dim strUrlCartaRitmo5 As String = Concat(strArchivo(0), "//", strArchivo(2), "/", strArchivo(3), "/", strRutaCarta, "/Ritmo5_", pExpediente.ToString, ".pdf")

            'sb_PintarGrilla(BEOrden)
            Dim bolTieneRpto As Boolean = False
            Dim bolTieneR5 As Boolean = False
            Dim vMaquina As New be_maquina
            vMaquina.int_ExpedienteId = pExpediente
            vMaquina.str_EstadoMaquina = "ACT"
            sb_PintarOrdenes(vMaquina, listaExpedientes, bolTieneRpto, bolTieneR5)

            pEsRitmo5 = bolTieneR5
            pEsBonoRpto = bolTieneRpto



            'If bolTieneR5 = True Then
            '    Me.hflTieneR5.Value = 1
            'Else
            '    Me.hflTieneR5.Value = 0
            'End If
            pExisteArchivoBonoRpto = False
            If System.IO.File.Exists(strPathCartaBono) Then
                pExisteArchivoBonoRpto = True
                'Me.imgPDFBono.Visible = True
                'Me.lnkBono.Visible = True
                ''Me.lnkBono.NavigateUrl = strUrlCartaBono
                'Me.lnkBono.NavigateUrl = strUrlCartaBono & "?version=" & (Math.Abs(Date.Now.ToBinary)).ToString
                'Me.lnkBono.Target = "_blank"            
            End If

            pExisteArchivoRitmo5 = False
            If System.IO.File.Exists(strPathCartaRitmo5) Then
                pExisteArchivoRitmo5 = True
                'Me.imgPDFRitmo5.Visible = True
                'Me.lnkRitmo5.Visible = True
                ''Me.lnkRitmo5.NavigateUrl = strUrlCartaRitmo5
                'Me.lnkRitmo5.NavigateUrl = strUrlCartaRitmo5 & "?version=" & (Math.Abs(Date.Now.ToBinary)).ToString
                'Me.lnkRitmo5.Target = "_blank"            
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Shared Sub sb_PintarOrdenes(ByVal pBEOrden As BE_Maquina, ByRef pliBEMaquina As List(Of BE_Maquina), _
                                      ByRef pbolTieneRpto As Boolean, ByRef pbolTieneR5 As Boolean)
        Try
            'Select Case pi_str_RolId 'este rol me indica que cosa pueden ver, en relación a las unidades
            '   Case "00000001" 'CONSULTA GENERAL 'USUARIO BONOR5 CONSULTA
            '      Me.btnAnterior.Visible = pi_bolMostrar * (-1)
            '      Me.btnSiguiente.Visible = pi_bolMostrar * (-1)
            '   Case "00000002" 'ADMINISTRADOR 'BONO DE REPUESTOS REGISTRO
            '      Me.btnAnterior.Visible = pi_bolMostrar
            '      Me.btnSiguiente.Visible = pi_bolMostrar

            '      sb_BotonesFlujo(pi_intActividadActual)
            '   Case "00000003" 'CONSULTA VENDEDOR 'USUARIO BONOR5 VENDEDOR
            '      Me.btnAnterior.Visible = pi_bolMostrar * (-1)
            '      Me.btnSiguiente.Visible = pi_bolMostrar * (-1)
            '   Case "00000004" 'CONSULTA SUCURSAL
            '      Me.btnAnterior.Visible = pi_bolMostrar * (-1)
            '      Me.btnSiguiente.Visible = pi_bolMostrar * (-1)
            'End Select

            Dim liBEMaquina As New List(Of be_maquina)
            liBEMaquina = clsMaquina.fn_Select_Maquina_Expediente(pBEOrden) 'clsOrden.fn_Select_ListaOrden_IdIncidente(pi_BEOrden)

            pbolTieneRpto = False
            pbolTieneR5 = False

            If liBEMaquina.Count > 0 Then
                'verificar si tienen Bono de repuesto y/o Ritmo5
                If liBEMaquina.FindAll(Function(x) x.bl_EsBonoRpto = True).Count > 0 Then
                    pbolTieneRpto = True
                End If

                If liBEMaquina.FindAll(Function(x) x.bl_EsRitmo5 = True).Count > 0 Then
                    pbolTieneR5 = True
                End If

                If pliBEMaquina Is Nothing Then
                    pliBEMaquina = liBEMaquina
                End If
            Else
                pliBEMaquina = liBEMaquina
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Shared Sub sb_MostrarMensajeAdvertencia(ByVal pExpediente As Integer, ByVal pBEMaquina As BE_Maquina, ByRef Resultado As Object)
        Dim MensajeCuentas As String = String.Empty
        Dim VisualizaMensajeCuenta As Boolean = False
        Dim VisualizaMensajeLineas As Boolean = False
        Dim HabilitaBtnSiguiente As Boolean = False
        Try
            Dim liBEMaquina As New List(Of BE_Maquina)

            liBEMaquina = clsMaquina.fn_Select_Maquina_Expediente(pBEMaquina)

            If liBEMaquina Is Nothing Then
                Return
            End If

            If liBEMaquina.Count > 0 Then

                Dim intLineaVentaItems As Integer = 0
                Dim strblCodCuenta As StringBuilder = New StringBuilder()
                Dim strListCodCuenta As List(Of String) = New List(Of String)
                Dim strListLineaVenta As List(Of String) = New List(Of String)

                For Each _Field_BEOrden As BE_Maquina In liBEMaquina
                    If _Field_BEOrden.int_IdLineaVenta = 0 Then
                        strListCodCuenta.Add(_Field_BEOrden.str_IdCuenta)
                    ElseIf _Field_BEOrden.int_IdLineaVenta <> 0 Then
                        strListLineaVenta.Add(_Field_BEOrden.int_IdLineaVenta.ToString)
                    End If
                Next

                strListCodCuenta = strListCodCuenta.Distinct().ToList()
                For Each strCodCuenta As String In strListCodCuenta
                    strblCodCuenta.AppendFormat("{0},", strCodCuenta)
                Next

                If strblCodCuenta.Length > 0 Then
                    'lblMensajeCuentas.Visible = True
                    'lblMensajeCuentas.Text = String.Empty
                    VisualizaMensajeCuenta = True
                    MensajeCuentas = String.Format("{0}: {1}", "Los siguientes números de cuenta no tienen asociada una linea de venta en este sistema", strblCodCuenta.ToString().TrimEnd(","))
                    'btnSiguiente.Enabled = False                
                End If

                strListLineaVenta = strListLineaVenta.Distinct().ToList()
                intLineaVentaItems = strListLineaVenta.Count()

                If intLineaVentaItems > 1 Then
                    'lblMensajeLineas.Visible = True
                    'lblMensajeLineas.Text = String.Empty
                    VisualizaMensajeLineas = True
                    MensajeCuentas = "Este expediente tiene más de una linea de venta asociada en este sistema."
                    'btnSiguiente.Enabled = False                
                End If

                If Not (strblCodCuenta.Length > 0 Or intLineaVentaItems > 1) Then
                    HabilitaBtnSiguiente = True
                End If

            End If

            Dim sgResult As Object = New With {Key .VisualizaMensajeCuenta = VisualizaMensajeCuenta,
                                        .VisualizaMensajeLineas = VisualizaMensajeLineas,
                                        .HabilitaBtnSiguiente = HabilitaBtnSiguiente,
                                        .MensajeCuentas = MensajeCuentas
                                       }

            Resultado = sgResult

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Shared Sub sb_MostrarArchivosFisicos(ByVal pActividadActual As Integer, ByVal pliBEExpediente As List(Of BE_Expediente), ByVal pi_intIdRolFlujo As Integer, ByRef Objeto As Object)
        Dim ArchivoFisico As Boolean = False
        Dim TieneArchivoCSA As Boolean = False
        Dim TieneArchivoBono As Boolean = False
        Try
            Select Case pi_intIdRolFlujo
                Case 8 'Consulta General de los roles de flujo
                    ArchivoFisico = False
                Case Else
                    If pActividadActual = ConfigurationManager.AppSettings("FinFlujo").ToString Then
                        ArchivoFisico = True

                        'habilitar solo los checks que se usarán según los tipos de bonos asociados al expediente
                        Dim bolBonoRpto As Boolean = False
                        Dim bolBonoCSA As Boolean = False
                        Dim intExpedienteId As Integer = pliBEExpediente.Item(0).int_ExpedienteId
                        Dim strEstadoRegistro As String = "INA"

                        Dim liBEMaquina As New List(Of BE_Maquina)
                        Dim BEMaquina As New BE_Maquina
                        BEMaquina.int_ExpedienteId = intExpedienteId
                        BEMaquina.str_EstadoMaquina = strEstadoRegistro
                        liBEMaquina = clsMaquina.fn_Select_Maquina_Expediente(BEMaquina) ' clsOrden.fn_Select_ListaOrden_IdIncidente(BEOrden)

                        'vemos si es que al menos uno tiene Bono Ritmo 5
                        For Each it As BE_Maquina In liBEMaquina
                            If it.str_Ritmo5Indicador = "S" Then
                                bolBonoCSA = True
                                Exit For
                            End If
                        Next it

                        'vemos si es que al menos uno tiene Bono CSA
                        For Each it As BE_Maquina In liBEMaquina
                            If it.str_BonoRptoIndicador = "S" Then
                                bolBonoRpto = True
                                Exit For
                            End If
                        Next it

                        If bolBonoCSA = True Then
                            TieneArchivoBono = True
                        End If

                        If bolBonoRpto = True Then
                            TieneArchivoBono = True
                        End If

                        'Llenar si el check tiene un valor
                        'For Each it As BE_Incidente In pi_liBEIncidente
                        '    Me.chkTieneArchivoBono.Checked = it.str_ArchivoBonoRptoFisico
                        '    Me.chkTieneArchivoCSA.Checked = it.str_ArchivoBonoCSAFisico
                        'Next it  

                    End If
            End Select

            'Valida si tiene Archivos
            Dim lExpedienteArchivo As New List(Of BE_ExpedienteArchivo)
            Dim ExpedienteArchivo As New BE_ExpedienteArchivo
            If pliBEExpediente.Count > 0 Then
                ExpedienteArchivo.intExpedienteId = pliBEExpediente(0).int_ExpedienteId
                lExpedienteArchivo = clsExpediente.fn_Select_ExpedienteArchivo(ExpedienteArchivo)

                For Each Item As BE_ExpedienteArchivo In lExpedienteArchivo
                    If Item.int_ClaseId = 1 And Not IsNothing(Item.bin_Archivo) Then
                        TieneArchivoBono = True
                    End If
                    If Item.int_ClaseId = 2 And Not IsNothing(Item.bin_Archivo) Then
                        TieneArchivoCSA = True
                    End If
                Next

            End If
            

            'lExpedienteArchivo=clsMaquina.fn_Select_MaquinaBeneficio_Expediente

            Dim sgResult As Object = New With {Key .ArchivoFisico = ArchivoFisico,
                                           .TieneArchivoCSA = TieneArchivoCSA,
                                           .TieneArchivoBono = TieneArchivoBono
                                          }

            Objeto = sgResult

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Shared Sub sb_PintarActividad(ByVal pActividadActual As Integer, ByRef Objeto As Object)
        Dim ActividadDesc As String = ""
        Dim ActividadId As Integer = 0
        Try
            Dim BEActividad As New BE_Actividad
            Dim liBEActividad As New List(Of BE_Actividad)
            BEActividad.ActividadId = pActividadActual

            liBEActividad = clsActividad.fn_Select_ListaActividad(BEActividad)

            For Each it As BE_Actividad In liBEActividad
                'Pintar la Actividad Actual del dato de Incidente
                'Me.lblActividadDesc.Text = it.str_ActividadDesc
                'Me.hflIdActividadActual.Value = it.int_IdActividad
                ActividadDesc = it.str_ActividadDesc
                ActividadId = it.int_ActividadId
            Next it

            Dim sgResult As Object = New With {Key .ActividadDesc = ActividadDesc,
                                                    .ActividadId = ActividadId
                                                   }

            Objeto = sgResult
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function SiguienteActividad(ByVal pExpedienteId As Integer, ByVal pActividadActual As Integer, ByVal pflgRitmo5 As Boolean, ByVal pflgBonoRpto As Boolean, ByVal pBonofirmado As Boolean, ByVal pBonoRitmo5 As Boolean, ByVal pArchivoRptoFirmado As String, ByVal pArchivoCSAFirmado As String)
        Dim Actividades As Object = Nothing
        Dim MensajeArchivo = String.Empty
        Dim GeneraCartaRitmo5 As Boolean = False
        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()
        Try
            Dim intIdExpediente As Integer = pExpedienteId
            Dim intIdActividadActual As Integer = pActividadActual

            'de acuerdo a la actividad actual busca la actividad anterior y siguiente y las carga a los combos de navegación
            fn_BuscarActividades(intIdExpediente, intIdActividadActual, Actividades) 'dentro se asigna el valor de hflIdActividadSiguiente

            Dim strTieneRpto As String = IIf(pflgBonoRpto, "1", "0")
            Dim strTieneRitmo5 As String = IIf(pflgRitmo5, "1", "0")

            Select Case intIdActividadActual
                Case 13, 14, 16 '9, 1, 3, 4
                    sb_ActualizarActividad_InsertarHistoricoActividad(intIdExpediente, intIdActividadActual, 0, strTieneRpto, strTieneRitmo5)
                Case 15 '2
                    'modificar reporte PDF CSA
                    sb_ActualizarActividad_InsertarHistoricoActividad(intIdExpediente, intIdActividadActual, 0, strTieneRpto, strTieneRitmo5)

                    'verificar si es la actividad de generar carta con firma para crear el reporte pdf
                    'MANDAR A CREAR LA CARTA PDF
                    If pActividadActual = ConfigurationManager.AppSettings("ArtividadCarta").ToString Then
                        'Response.BufferOutput = True
                        GeneraCartaRitmo5 = True

                        Dim ProcesaCarta As New frmResultado
                        If HttpContext.Current.Response.IsClientConnected Then
                            ProcesaCarta.GenerarCarta(pflgRitmo5, pflgBonoRpto, pExpedienteId, "002")
                            Exit Select
                        End If

                        'If Response.IsClientConnected Then
                        '    Response.Redirect(Concat("frmReporte.aspx?rpt=", intIdIncidente.ToString, "&cia=", Me.hflIdCompania.Value, "&rpto=", _
                        '                               strTieneRpto, "&r5=", strTieneRitmo5), True) 'segundo parametro true para que corte la lectura de la pagina
                        '    sb_EscribeLog("paso el redirect de frmReporte")
                        '    Return
                        'Else
                        '    Response.End()
                        'End If

                    End If
                Case 17 '5
                    Dim strTipoAdjunto As String = String.Empty
                    Dim bolEnvioCorreo As Boolean = False
                    Dim intIdActividadSiguiente As Integer = 0

                    'Verificamos que tenga archivo adjunto.
                    If Not pBonofirmado And strTieneRpto = "1" Then
                        MensajeArchivo = "Por favor adjunte archivo..."
                        Exit Select
                    End If

                    If Not pBonoRitmo5 And strTieneRitmo5 = "1" Then
                        MensajeArchivo = "Por favor adjunte archivo..."
                        Exit Select
                    End If

                    If strTieneRpto = "1" Then
                        sb_ActualizarActividad_InsertarHistoricoActividad(intIdExpediente, intIdActividadActual, intIdActividadSiguiente, strTieneRpto, String.Empty)

                        strTipoAdjunto = "1"
                        'sb_PrepararCorreo(intIdIncidente, strTipoAdjunto, bolEnvioCorreo)

                        'Envia la actualización a Gina Gomez

                        'obtener las ordenes de la incidencia
                        Dim liBEMaquina As New List(Of BE_Maquina)
                        Dim BEMaquina As New BE_Maquina
                        BEMaquina.int_ExpedienteId = intIdExpediente
                        BEMaquina.str_EstadoMaquina = "ACT"
                        liBEMaquina = clsMaquina.fn_Select_Maquina_Expediente(BEMaquina) 'clsOrden.fn_Select_ListaOrden_IdIncidente(BEOrden)

                        'Dim liBEUMPBRHD0 As New List(Of BE_UMPBRHD0)
                        'Dim BEUMPBRHD0 As New BE_UMPBRHD0

                        For Each it As BE_Maquina In liBEMaquina
                            'liBEUMPBRHD0 = New List(Of BE_UMPBRHD0)
                            'BEUMPBRHD0 = New BE_UMPBRHD0

                            'BEUMPBRHD0.str_ORDEN = it.str_Orden

                            ''revisa si existe en el archivo de Andres
                            'liBEUMPBRHD0 = clsUMPBRHD0.fn_Select_UMPBRHD0(BEUMPBRHD0)
                            'For Each it2 As BE_UMPBRHD0 In liBEUMPBRHD0
                            '   If (it2.int_BONOFILE <> 999999 Or it2.int_BONOFILE <> 888888) Then
                            '      'actualizar
                            '      clsUMPBRHD0.fn_Update_UMPBRHD0(it2)
                            '   Else
                            '      'no actualiza
                            '   End If
                            'Next it2

                            ''''''COMENTADO PARA MODIFICACION USUARIOS
                            Dim BEUsuarioLDAP As String = String.Empty 'BE_UsuarioLDAP = Session.Item("BE_UsuarioLDAP")
                            cmpAsignarBonoRepuesto.fn_AsignarBonoRepuesto(it, BEUsuarioLDAP) 'Asigna el Bono de repuesto
                        Next it
                    End If
                    If strTieneRitmo5 = 1 Then
                        sb_ActualizarActividad_InsertarHistoricoActividad(intIdExpediente, intIdActividadActual, intIdActividadSiguiente, String.Empty, strTieneRitmo5)

                        strTipoAdjunto = 2
                        'sb_PrepararCorreo(intIdIncidente, strTipoAdjunto, bolEnvioCorreo)
                    End If

                    'ahora se debe mandar a finalización la actividad, para eso se recupera la actividad siguiente que devuelve el método
                    sb_ActualizarActividad_InsertarHistoricoActividad(intIdExpediente, intIdActividadSiguiente, 0, strTieneRpto, strTieneRitmo5)

                    'actualizar las ordenes para cambiarle el estado de registro a inactivo
                    sb_ActualizarOrden_Inactivo(pExpedienteId)
            End Select

            objRpta.data = New With {.GeneraCartaRitmo5 = GeneraCartaRitmo5, .MensajeArchivo = MensajeArchivo}


            'Subir Archivos bonos firmados
            Dim ArchivoBonoRpto() As String = pArchivoRptoFirmado.Split("|")
            Dim ArchivoBonoCSA() As String = pArchivoCSAFirmado.Split("|")
            Dim Carpeta As String = ConfigurationManager.AppSettings("ArchivosTemporales")

            Dim directorioUpload As String = HttpContext.Current.Request.PhysicalApplicationPath + Carpeta

            Dim Ruta As String = String.Empty 'directorioUpload & RegistroArchivo(0)
            Dim bytes As Byte() = Nothing 'File.ReadAllBytes(Ruta)

            Dim ArchivoFirmado As BE_ExpedienteArchivoFirmado = Nothing

            If ArchivoBonoRpto.Length <> 0 Then
                Ruta = directorioUpload & ArchivoBonoRpto(0)
                bytes = File.ReadAllBytes(Ruta)
                ArchivoFirmado = New BE_ExpedienteArchivoFirmado
                With ArchivoFirmado
                    .int_ExpedienteId = pExpedienteId
                    .int_IdClase = 1
                    .str_NombreArchivo = ArchivoBonoRpto(1)
                    .bin_Archivo = bytes
                    .str_UsuarioCreacion = 1
                End With

            End If

            If ArchivoBonoCSA.Length <> 0 Then
                Ruta = directorioUpload & ArchivoBonoCSA(0)
                bytes = File.ReadAllBytes(Ruta)
                ArchivoFirmado = New BE_ExpedienteArchivoFirmado
                With ArchivoFirmado
                    .int_ExpedienteId = pExpedienteId
                    .int_IdClase = 2
                    .str_NombreArchivo = ArchivoBonoCSA(1)
                    .bin_Archivo = bytes
                    .str_UsuarioCreacion = 1
                End With

            End If

            Return objRpta

        Catch te As Threading.ThreadStartException
            'sb_EscribeLog(te.ToString)
            Throw te
        Catch ex As Exception
            'Dim rethrow As Boolean = ExceptionPolicy.HandleException(ex, "ExHandling")
            'Throw ex
        End Try
    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function AnteriorActividad(ByVal pExpediente As Integer, ByVal pActividadAnterior As Integer)
        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()
        Dim NuevaActividad As Integer = 0
        Dim ActividadActual As Integer = 0
        Dim Actividades As Object = Nothing
        Try
            Dim BEexpediente As New BE_Expediente
            Dim liBEExpediente As New List(Of BE_Expediente)

            BEexpediente.int_ExpedienteId = pExpediente 'Me.lblIdIncidente.Text
            BEexpediente.int_ActividadId = pActividadAnterior 'Me.hflIdActividadAnterior.Value


            clsExpediente.fn_Update_ListaExpediente(BEexpediente)

            'Me.hflIdActividadActual.Value = Me.hflIdActividadAnterior.Value
            ActividadActual = pActividadAnterior

            fn_BuscarActividades(pExpediente, ActividadActual, Actividades)

            liBEExpediente = clsExpediente.fn_SelectMaquina_ListaExpediente(BEexpediente) 'clsIncidente.fn_Select_ListaIncidente(BEincidente)

            Dim BEexpedienteHist As New BE_ExpedienteHistorial
            For Each it As BE_Expediente In liBEExpediente
                With BEexpedienteHist
                    .int_ExpedienteId = it.int_ExpedienteId
                    .int_ActividadId = it.int_ActividadId
                    '.str_Flag = "1"
                    .int_UsuarioId = it.int_UsuarioId
                End With
            Next it

            'clsIncidenteHist.fn_Insert_ListaIncidenteHist(BEexpedienteHist)
            clsExpediente_Historial.fn_Insert_ListaExpedienteHist(BEexpedienteHist)

            If ActividadActual = ConfigurationManager.AppSettings("InicioFlujo").ToString Then
                sb_EliminarArchivos(pExpediente)
            End If

            objRpta.data = New With {.IrPagina = "frmResultado.aspx"}

            'Response.BufferOutput = True
            'Response.Redirect("frmResultado.aspx", False)
        Catch ex As Exception
            'Dim rethrow As Boolean = ExceptionPolicy.HandleException(ex, "ExHandling")
            'Throw ex
        End Try
        Return objRpta
    End Function

    Private Shared Sub sb_EliminarArchivos(ByVal pExpediente As Integer)
        Try
            Dim strPathCartaBono As String = HttpContext.Current.Server.MapPath(Concat("~\", ConfigurationManager.AppSettings("dirCartas").ToString, "\Bono_", pExpediente.ToString, ".pdf"))
            Dim strPathCartaRitmo5 As String = HttpContext.Current.Server.MapPath(Concat("~\", ConfigurationManager.AppSettings("dirCartas").ToString, "\Ritmo5_", pExpediente.ToString, ".pdf"))

            If System.IO.File.Exists(strPathCartaBono) Then
                System.IO.File.Delete(strPathCartaBono)
            End If

            If System.IO.File.Exists(strPathCartaRitmo5) Then
                System.IO.File.Delete(strPathCartaRitmo5)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Shared Sub sb_ActualizarOrden_Inactivo(ByVal pExpediente As Integer)
        Try
            Dim liBEMaquina As New List(Of BE_Maquina)
            Dim BEMaquina As New BE_Maquina
            BEMaquina.int_ExpedienteId = pExpediente

            liBEMaquina = clsMaquina.fn_Select_Maquina_Expediente(BEMaquina)

            For Each it As BE_Maquina In liBEMaquina
                BEMaquina = New BE_Maquina
                BEMaquina.str_OrdenAsignada = it.str_OrdenAsignada
                BEMaquina.str_EstadoMaquina = "INA"

                clsMaquina.fn_Update_EstadoRegistro(BEMaquina)
            Next it
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Shared Sub sb_ActualizarActividad_InsertarHistoricoActividad(ByVal pExpediente As Integer, ByVal pActividadActual As Integer, ByRef po_intActividadSiguiente As Integer, _
                                                                ByVal pTieneRpto As String, ByVal pTieneRitmo5 As String)
        Try
            'Buscar cual es la siguiente actividad
            Dim liBEFlujo As New List(Of BE_Flujo)
            Dim BEFlujo As New BE_Flujo
            BEFlujo.int_IdActividad = pActividadActual

            'buscar cual es la actividad siguiente
            liBEFlujo = clsFlujo.fn_Select_ListaFlujoSiguiente(BEFlujo)

            Dim intActividadSiguiente As Integer = 0

            For Each it As BE_Flujo In liBEFlujo
                Select Case pActividadActual
                    Case 13, 14, 15, 16 '9, 1, 2, 3, 4
                        intActividadSiguiente = it.int_IdActividadSiguiente
                    Case 17 '5
                        If pTieneRpto = "1" Then intActividadSiguiente = ConfigurationManager.AppSettings("BonoRpto").ToString
                        If pTieneRitmo5 = "1" Then intActividadSiguiente = ConfigurationManager.AppSettings("BonoRitmo5").ToString
                    Case 20 '8
                        intActividadSiguiente = pActividadActual
                End Select
            Next it

            Dim BEExpediente As New BE_Expediente
            BEExpediente.int_ExpedienteId = pExpediente
            If pActividadActual = 20 Then
                BEExpediente.int_ActividadId = pActividadActual

                'busca todas las ordenes del incidente
                Dim liBEMaquina As New List(Of BE_Maquina)
                Dim BEMaquina As New BE_Maquina
                BEMaquina.int_ExpedienteId = pExpediente
                BEMaquina.str_EstadoMaquina = "ACT"
                liBEMaquina = clsMaquina.fn_Select_Maquina_Expediente(BEMaquina) 'clsOrden.fn_Select_ListaOrden_IdIncidente(BEOrden)

                For Each it As BE_Maquina In liBEMaquina
                    BEMaquina = New BE_Maquina

                    BEMaquina.str_OrdenAsignada = it.str_OrdenAsignada
                    BEMaquina.str_EstadoMaquina = "INA"

                    clsMaquina.fn_Update_Maquina_EstadoRegistro(BEMaquina)
                Next it
            Else
                BEExpediente.int_ActividadId = intActividadSiguiente
            End If

            clsExpediente.fn_Update_ListaExpediente(BEExpediente)

            'Listar en el Incidente actual
            Dim liBEExpediente As New List(Of BE_Expediente)
            liBEExpediente = clsExpediente.fn_SelectMaquina_ListaExpediente(BEExpediente)

            Dim BEExpedienteHist As New BE_ExpedienteHistorial
            For Each it As BE_Expediente In liBEExpediente
                With BEExpedienteHist
                    .int_ExpedienteId = it.int_ExpedienteId
                    .int_ActividadId = it.int_ActividadId
                    '.str_Flag = "1"
                    '.str_IdUsuario = it.str_IdUsuario ' Usuario de la actividad anterior
                    'Dim BEUsuarioLDAP As BE_UsuarioLDAP = Session.Item("BE_UsuarioLDAP")
                    '.str_IdUsuario = BEUsuarioLDAP.sAMAccountName 'Usuario de la sesión
                    '.det_FechaInicio = it.det_Fecha
                    '.det_FechaFin = Now()
                End With
            Next it

            'Insertar en el historico de Incidentes

            clsExpediente_Historial.fn_Insert_ListaExpedienteHist(BEExpedienteHist)

            liBEFlujo = New List(Of BE_Flujo)
            BEFlujo = New BE_Flujo
            BEFlujo.int_IdActividad = intActividadSiguiente

            'buscar cual es la actividad siguiente
            liBEFlujo = clsFlujo.fn_Select_ListaFlujoSiguiente(BEFlujo)

            For Each it As BE_Flujo In liBEFlujo
                po_intActividadSiguiente = it.int_IdActividadSiguiente
            Next it
        Catch ex As Exception
            'Dim rethrow As Boolean = ExceptionPolicy.HandleException(ex, "ExHandling")
            Throw ex
        End Try
    End Sub

    Private Shared Sub fn_BuscarActividades(ByVal pExpedienteId As Integer, ByVal pActividadActual As Integer, ByRef Objeto As Object)
        Dim ActividadSiguiente As Integer = 0
        Dim ActividadAnterior As Integer = 0
        Dim ddlActividadSiguiente As New List(Of BE_Flujo)
        Dim ddlActividadAnterior As New List(Of BE_Flujo)
        Try
            Dim liBEFlujo As New List(Of BE_Flujo)
            Dim BEFlujo As New BE_Flujo
            BEFlujo.int_IdActividad = pActividadActual 'liBEActividad.Item(0).int_IdActividad

            'buscar cual es la actividad siguiente
            liBEFlujo = clsFlujo.fn_Select_ListaFlujoSiguiente(BEFlujo)

            Dim intActividadSiguiente As Integer = 0

            Dim intCantActividadSiguiente As Integer = liBEFlujo.Count

            If intCantActividadSiguiente = 1 Then
                intActividadSiguiente = liBEFlujo.Item(0).int_IdActividadSiguiente

                ActividadSiguiente = intActividadSiguiente
            ElseIf intCantActividadSiguiente = 2 Then
                ddlActividadSiguiente = liBEFlujo
            End If


            'buscar cual es la actividad anterior
            liBEFlujo = clsFlujo.fn_Select_ListaFlujoAnterior(BEFlujo)

            Dim intActividadAnterior As Integer = 0

            If liBEFlujo.Count = 1 Then
                intActividadAnterior = liBEFlujo.Item(0).int_IdActividadSiguiente

                ActividadAnterior = intActividadAnterior
            ElseIf liBEFlujo.Count = 2 Then
                ddlActividadAnterior = liBEFlujo
            End If

            Dim sgResult As Object = New With {Key .ActividadSiguiente = ActividadSiguiente,
                                                   .ActividadAnterior = ActividadAnterior,
                                                   .ddlActividadSiguiente = ddlActividadSiguiente,
                                                   .ddlActividadAnterior = ddlActividadAnterior
                                                  }
            Objeto = sgResult
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function ObtenerDatosOrden(ByVal pOrden As String)
        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()
        Dim vBE_Maquina As New BE_Maquina
        Dim vlst_MaquinaBeneficio As List(Of DTO_Maquina_Beneficio)
        Dim liBEMaquinaArchivo As List(Of BE_MaquinaArchivo) = Nothing
        Dim BEMaquinaArchivo As BE_MaquinaArchivo
        Dim TieneArchivo As Integer = 0
        Dim MaquinaBeneficio As New DTO_Maquina_Beneficio
        'Dim Carpeta As String = ConfigurationManager.AppSettings("ArchivosTemporales")
        'Dim ruta As String = HttpContext.Current.Request.PhysicalApplicationPath + Carpeta
        Try
            vBE_Maquina = clsMaquina.fn_Select_Maquina_Orden(pOrden)
            MaquinaBeneficio.OrdenAsignada = pOrden
            vlst_MaquinaBeneficio = clsMaquina.fn_Select_MaquinaBeneficio_Orden(MaquinaBeneficio)

            'Obtener Archivo para ocultar o mostrar botón
            BEMaquinaArchivo = New BE_MaquinaArchivo
            BEMaquinaArchivo.str_OrdenAsignada = pOrden
            BEMaquinaArchivo.int_IdClase = 2
            liBEMaquinaArchivo = clsMaquina.fn_Select_MaquinaArchivo(BEMaquinaArchivo)

            If liBEMaquinaArchivo.Count = 1 Then
                If Not IsNothing(liBEMaquinaArchivo(0).bin_Archivo) Then
                    TieneArchivo = 1
                End If
            End If

            objRpta.data = New With {Key .maquina = vBE_Maquina, .listasap = vlst_MaquinaBeneficio, .TieneArchivo = TieneArchivo}

        Catch ex As Exception
            objRpta.success = False
            objRpta.msg = String.Format("Message: {0} - StackTrace: {1}", ex.Message, ex.StackTrace)
        End Try
        Return objRpta
    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function ObtenerDatosFactura(ByVal pOrden As String)
        Dim BEEMPEQPD0 As New BE_EMPEQPD2
        Dim liBono As List(Of BE_EMPEQPD2)
        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()
        Dim IdCuenta As String = String.Empty
        Dim CodCliente As String = String.Empty
        Dim DesCliente As String = String.Empty
        Dim DesCuenta As String = String.Empty
        Try
            liBono = clsEMPEQPD0_2.fn_Select_ListaEMPEQPD0(pOrden)

            If liBono.Count <> 1 Then
                objRpta.data = 0
            Else
                objRpta.data = liBono(0)

                If liBono(0).str_INVI = "S" Then
                    IdCuenta = liBono(0).str_LCUNO
                    CodCliente = liBono(0).str_CUNO
                ElseIf liBono(0).str_INVI = "Y" Then
                    IdCuenta = liBono(0).str_CUNO
                    CodCliente = liBono(0).str_LCUNO
                End If

                If Len(CodCliente.Trim) > 0 Then
                    Dim liCuno As List(Of BE_DimCliente2)
                    liCuno = clsDimCliente.fn_Select_ListaDimCliente(CodCliente)
                    If liCuno.Count() = 1 Then
                        DesCliente = liCuno(0).str_DESC_CLIENTE
                    End If
                End If
                If Len(IdCuenta.Trim) > 0 Then
                    Dim liLCuno As List(Of BE_CuentaUsuario2)
                    liLCuno = clsCuentaUsuario.fn_Select_Cuenta(IdCuenta)
                    If liLCuno.Count() > 0 Then
                        DesCuenta = liLCuno(0).str_CuentaDesc
                    End If
                End If

                objRpta.msg = DesCliente & "|" & DesCuenta

            End If

        Catch ex As Exception
            objRpta.success = False
            objRpta.msg = String.Format("Message: {0} - StackTrace: {1}", ex.Message, ex.StackTrace)
        End Try

        Return objRpta

    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function GuardarMaquinaBono(ByVal maquina As DTO_Maquina)
        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()
        Dim EsNuevo As Boolean = maquina.EsNuevo
        Dim Archivos As String = maquina.Archivo
        Dim ListaArchivos() As String = Nothing
        Try
            'If HttpContext.Current.Session("LoginAuthentications") Is Nothing Then
            '    objRpta.sesionValida = False
            '    Return objRpta
            'End If

            Dim BE_Maquina As New BE_Maquina

            Dim loginUsuario As String = HttpContext.Current.Session("LoginAuthentications")
            Dim xmlBonos As New StringBuilder()

            If Archivos.Length > 0 Then
                ListaArchivos = Archivos.Split(",")
            End If

            xmlBonos.Append("<root>")
            If maquina.EsBonoRitmo5 = 1 Then
                xmlBonos.Append("<fila>")
                xmlBonos.Append("<IdClase>2</IdClase>")
                xmlBonos.Append("<sap>" & maquina.IdSapRitmo5 & "</sap>")
                xmlBonos.Append("<monto>" & maquina.MontoRitmo5 & "</monto>")
                xmlBonos.Append("<nombre>" & maquina.TipoRitmo5 & "</nombre>")
                xmlBonos.Append("</fila>")
            End If

            If maquina.EsBonoRpto = 1 Then
                xmlBonos.Append("<fila>")
                xmlBonos.Append("<IdClase>1</IdClase>")
                xmlBonos.Append("<sap>1</sap>")
                xmlBonos.Append("<monto>" & maquina.MontoBonoRpto & "</monto>")
                xmlBonos.Append("<nombre>Bono Rpto</nombre>")
                xmlBonos.Append("</fila>")

            End If
            xmlBonos.Append("</root>")

            With BE_Maquina
                .str_OrdenAsignada = maquina.Orden
                .str_CompaniaId = "002"
                .str_SUNTIP = maquina.SunTip
                .int_SUNNUM = maquina.SunNum
                .int_SUNPRE = maquina.SunPre
                .str_FinanciamientoId = maquina.FinanciamientoId
                .str_FamiliaDesc = maquina.FamiliaDesc
                .str_ModeloProductoId = maquina.ModeloProductoDesc
                .str_Observaciones = maquina.Observacion
                .str_EstadoInventario = maquina.EsFactura
                .str_VendedorId = maquina.VendedorId
                .str_VendedorDesc = maquina.VendedorDesc
                .str_XmlSap = xmlBonos.ToString()
                .str_EntidadFinancieraId = maquina.EntidadFinancieraId
                .str_FinanciamientoDesc = maquina.EntidadFinancieraDesc
                .str_ClienteDesc = maquina.ClienteDesc
                .str_ClienteId = maquina.ClienteId
                .str_ClienteFacturaId = maquina.ClienteFacturaId
                .str_ClienteFacturaDesc = maquina.ClienteFacturaDesc
                .str_CuentaInventarioDBS = maquina.CuentaInventarioDBS
                .str_DescripcionCuenta = maquina.DescripcionCuenta
                .str_Sucursal = maquina.Sucursal
                .str_DescripcionSucursal = maquina.DescripcionSucursal
                .str_FinanciamientoId = maquina.FinanciamientoId
                .str_MarcaDesc = maquina.MarcaDesc
                .str_ModeloProductoDesc = maquina.ModeloProductoDesc
                .str_SerieMaquina = maquina.SerieMaquina
                .str_FechaFactura = maquina.FechaFactura
                .str_EstadoMaquina = "L"
                .int_NoTieneNroorden = maquina.NoTieneNroOrden
            End With

            Dim Carpeta As String = ConfigurationManager.AppSettings("ArchivosTemporales")

            Dim directorioUpload As String = HttpContext.Current.Request.PhysicalApplicationPath + Carpeta


            Dim rpta As String = String.Empty
            Dim BEmaquinaarchivo As BE_MaquinaArchivo = Nothing
            If Not EsNuevo Then
                rpta = clsMaquina.fn_Update_MaquinaBono(BE_Maquina)
            Else
                rpta = clsMaquina.fn_Insert_MaquinaBono(BE_Maquina)
            End If

            If rpta = "-1" Then
                objRpta.data = rpta
                Return objRpta
            End If

            If (Not IsNothing(ListaArchivos)) Then
                For Each item As String In ListaArchivos
                    Dim RegistroArchivo() As String = item.Split("|")

                    Dim Ruta As String = directorioUpload & RegistroArchivo(0)
                    Dim bytes As Byte() = File.ReadAllBytes(Ruta)

                    BEmaquinaarchivo = New BE_MaquinaArchivo
                    BEmaquinaarchivo.str_OrdenAsignada = maquina.Orden
                    BEmaquinaarchivo.str_NombreArchivo = RegistroArchivo(1)
                    BEmaquinaarchivo.bin_Archivo = bytes
                    BEmaquinaarchivo.str_UsuarioCreacion = 1
                    BEmaquinaarchivo.dt_FechaCreacion = DateTime.Now
                    BEmaquinaarchivo.int_IdClase = 2 ' es bonoCSA
                    clsMaquina.fn_Insert_MaquinaArchivo(BEmaquinaarchivo)
                Next
            End If
            If rpta <> "1" Then
                Throw New Exception("Error al ejecutar el procedimiento.")
            End If

            objRpta.data = rpta
        Catch ex As Exception
            objRpta.success = False
            objRpta.msg = String.Format("Message: {0} - StackTrace: {1}", ex.Message, ex.StackTrace)
        End Try
        Return objRpta
    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function ListarTrabajadores(ByVal pMatricula As String)
        'Threading.Thread.Sleep(1000)
        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()
        Try
            Dim BETrabajador As New BE_TrabajadorAdryan

            BETrabajador.str_COMPANIA = "002"
            BETrabajador.str_MATRICULA = pMatricula
            BETrabajador.str_NOMBRE = ""

            Dim liTrabajadores As List(Of BE_TrabajadorAdryan)
            liTrabajadores = cmpUsuario.fn_Select_ListaTrabajadorAdryan3(BETrabajador)

            objRpta.data = liTrabajadores

            'Dim sgResult As Object = New With {Key .rows = liTrabajadores}
            'Return sgResult

        Catch ex As Exception
            objRpta.success = False
            objRpta.msg = String.Format("Message: {0} - StackTrace: {1}", ex.Message, ex.StackTrace)
        End Try
        Return objRpta
    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function BuscarOrden(ByVal pOrden As String)
        Dim liBono As List(Of BE_EMPEQPD2)
        Dim BEEMPEQPD0 As New BE_EMPEQPD2
        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()
        BEEMPEQPD0.str_IDNO1 = pOrden
        Dim CodCliente As String = String.Empty
        Dim DesCliente As String = String.Empty
        Dim CodCuenta As String = String.Empty
        Dim DesCuenta As String = String.Empty
        Try
            liBono = clsEMPEQPD0_2.fn_Select_ListaEMPEQPD0_INVISY(BEEMPEQPD0)

            Dim Lcuno As New BE_CuentaUsuario2
            Dim cuno As New BE_DimCliente2

            If liBono(0).str_INVI = "S" Then
                Lcuno.str_IdCuenta = liBono(0).str_LCUNO
                cuno.str_COD_CLIENTE = liBono(0).str_CUNO
            Else
                If liBono(0).str_INVI = "Y" Then
                    Lcuno.str_IdCuenta = liBono(0).str_CUNO
                    cuno.str_COD_CLIENTE = liBono(0).str_LCUNO
                End If
            End If
            CodCliente = cuno.str_COD_CLIENTE
            CodCuenta = Lcuno.str_IdCuenta
            If Len(cuno.str_COD_CLIENTE) > 0 Then
                Dim liCuno As List(Of BE_DimCliente2)
                liCuno = clsDimCliente.fn_Select_ListaDimCliente(cuno.str_COD_CLIENTE)
                If liCuno.Count() > 0 Then
                    DesCliente = liCuno(0).str_DESC_CLIENTE
                End If
            End If
            If Len(Lcuno.str_IdCuenta) > 0 Then
                Dim liLCuno As List(Of BE_CuentaUsuario2)
                liLCuno = clsCuentaUsuario.fn_Select_Cuenta(Lcuno.str_IdCuenta)
                If liLCuno.Count() > 0 Then
                    DesCuenta = liLCuno(0).str_CuentaDesc
                End If
            End If

            objRpta.data = New With {Key .rows = liBono,
                                               .codCliente = CodCliente,
                                               .desCliente = DesCliente,
                                               .IdCuenta = CodCuenta,
                                               .DesCuenta = DesCuenta,
                                               .Marca = liBono(0).str_PRCLST,
                                               .NumeroSerie = liBono(0).str_EQMFS2,
                                               .Modelo = liBono(0).str_DSPMDL
                                    }
            Return objRpta
        Catch ex As Exception
            objRpta.success = False
            objRpta.msg = String.Format("Message: {0} - StackTrace: {1}", ex.Message, ex.StackTrace)
        End Try
        Return objRpta
    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function BuscarNumFacturaCliente(ByVal pTipoFactura As String, ByVal pSerie As String, ByVal pNumFactura As String, ByVal pIndicadorFactElectronica As Integer)
        Dim BEUFPRV010 As New BE_UFPRV010
        BEUFPRV010.str_SUNTIP = pTipoFactura
        BEUFPRV010.str_SUNPRE = pSerie
        BEUFPRV010.str_SUNNUM = pNumFactura
        Dim DatosCliente As New DTO_ClienteFactura
        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()
        Dim strElectronica As String
        If pIndicadorFactElectronica = 1 Then
            strElectronica = "S"
        Else
            strElectronica = "N"
        End If
        Dim liBEUFPRV010 As List(Of BE_UFPRV010) = clsUFPRV010.fn_Select_ListaUFPRV010_x_NroSunat(BEUFPRV010, strElectronica)
        If liBEUFPRV010.Count > 0 Then
            Dim cuno As New BE_DimCliente2
            Dim liCuno As List(Of BE_DimCliente2)

            'Se obtiene el cliente final
            'cuno.str_COD_CLIENTE = liBEUFPRV010(0).str_CLIAD
            liCuno = clsDimCliente.fn_Select_ListaDimCliente(liBEUFPRV010(0).str_CLIAD)

            DatosCliente.CodCliente = liBEUFPRV010(0).str_CLIAD 'txtCodCliente.Text = liBEUFPRV010(0).str_CLIAD
            'txtDescCliente.Text = ""
            If liCuno.Count() > 0 Then
                DatosCliente.DescripcionCliente = liCuno(0).str_DESC_CLIENTE 'txtDescCliente.Text = liCuno(0).str_DESC_CLIENTE
            End If

            'Se obtiene el cliente de facturación.
            'cuno.str_COD_CLIENTE = liBEUFPRV010(0).str_CLIE
            liCuno = clsDimCliente.fn_Select_ListaDimCliente(liBEUFPRV010(0).str_CLIE)


            DatosCliente.CodClienteFactura = liBEUFPRV010(0).str_CLIE 'txtCodClienteFactura.Text = liBEUFPRV010(0).str_CLIE
            DatosCliente.DescripcionClienteFactura = "" 'txtDescClienteFactura.Text = ""
            DatosCliente.CodigoEntidadFinanciera = liBEUFPRV010(0).str_CLIE 'txtCodEntidadFinanciera.Text = liBEUFPRV010(0).str_CLIE
            'txtDescEntidadFinanciera.Text = ""
            If liCuno.Count() > 0 Then
                DatosCliente.DescripcionClienteFactura = liCuno(0).str_DESC_CLIENTE 'txtDescClienteFactura.Text = liCuno(0).str_DESC_CLIENTE
                DatosCliente.DescripcionEntidadFinanciera = liCuno(0).str_DESC_CLIENTE 'txtDescEntidadFinanciera.Text = liCuno(0).str_DESC_CLIENTE
            End If

            'Se coloca la fecha de la factura.
            DatosCliente.FechaFactura = DateTime.ParseExact(liBEUFPRV010(0).str_FECDOC, "yyyyMMdd", Globalization.CultureInfo.InvariantCulture).ToString("dd/MM/yyyy") 'txtFecha.Text = DateTime.ParseExact(liBEUFPRV010(0).str_FECDOC, "yyyyMMdd", Globalization.CultureInfo.InvariantCulture).ToString("dd/MM/yyyy")

            'Else
            '    txtCodCliente.Text = ""
            '    txtDescCliente.Text = ""
            '    txtTipoFactura.Text = ""
            '    txtSerieFactura.Text = ""
            '    txtNumeroFactura.Text = ""
            '    txtCodClienteFactura.Text = ""
            '    txtDescClienteFactura.Text = ""
            '    txtCodEntidadFinanciera.Text = ""
            '    txtDescEntidadFinanciera.Text = ""
        End If

        objRpta.data = New With {Key .Cliente = DatosCliente
                                    }
        Return objRpta

    End Function

    Public Sub GenerarCarta(ByVal pRpto As Boolean, ByVal pR5 As Boolean, ByVal pExpedienteId As Integer, ByVal pCompaniaId As String)

        'CREACION CARTA RITMO 5
        If pR5 Then
            sb_CreaCartaR5(pExpedienteId, pCompaniaId)
        End If

        'CREACION CARTA REPUESTO
        If pRpto Then
            sb_CreaCartaRpto(pExpedienteId, pCompaniaId)
        End If

    End Sub

    Public Sub sb_CreaCartaR5(ByVal pExpedienteId As Integer, ByVal pCompaniaId As String)
        Try
            Dim dtsCarta As New dtsCarta
            Dim intNumeroUnidades As Integer
            Dim strFlagLeasing As String = String.Empty

            Dim decImporteBonoCSA As Decimal = 0.0

            'crear / actualizar el número de carta
            Dim intNumeroCarta As Integer = cmpCrearNumeroCarta.fn_CrearNumeroCarta()

            Dim ListaOrdenSAP As New List(Of BE_Maquina)
            Dim Parametros As New BE_Maquina
            Parametros.int_ExpedienteId = pExpedienteId
            Parametros.int_ClaseId = 2

            ListaOrdenSAP = clsMaquina.fn_Select_Maquina_ExpedienteBono(Parametros)

            Dim ListaSap = From c In ListaOrdenSAP Select New With {Key c.int_BeneficioId} Distinct.ToList


            'Validar si carpeta tmp existe para la creación de los pdfs temporales

            If Not Directory.Exists(Server.MapPath(Concat("Cartas\Ritmo5\tmp"))) Then
                Directory.CreateDirectory(Server.MapPath(Concat("Cartas\Ritmo5\tmp")))
            End If

            intNumeroUnidades = 0
            decImporteBonoCSA = 0.0
            strFlagLeasing = String.Empty

            For Each Item In ListaSap

                sb_ObtenerOrden(dtsCarta, pExpedienteId, pCompaniaId, intNumeroUnidades, "2", decImporteBonoCSA, ListaOrdenSAP, Item.int_BeneficioId)

                sb_ObtenerDatosCarta(dtsCarta, pExpedienteId, intNumeroUnidades, strFlagLeasing, intNumeroCarta, decImporteBonoCSA)

                pr_rptCartaBono = New CrystalDecisions.CrystalReports.Engine.ReportDocument

                'pr_strReportPathImage = Request.PhysicalApplicationPath
                pr_strReportPathCartaBono = Server.MapPath("~\Reports\CartaRitmo5.rpt")
                pr_strReportPathUnidades = Server.MapPath("~\Reports\UnidadesRitmo5.rpt")
                pr_strReportPathBonoLeasing = Server.MapPath("~\Reports\Ritmo5Leasing.rpt")

                pr_rptCartaBono.Load(pr_strReportPathCartaBono)
                pr_rptCartaBono.Database.Tables("dtbCartaBono").SetDataSource(dtsCarta.Tables("dtbCartaBono"))

                'Obtengo el nombre del Subreporte de Unidades
                pr_rptsubUnidades = CType(pr_rptCartaBono.ReportDefinition.ReportObjects("subUnidades"), SubreportObject)
                pr_rptUnidades = pr_rptCartaBono.OpenSubreport(pr_rptsubUnidades.SubreportName)
                pr_rptUnidades.SetDataSource(dtsCarta.Tables("dtbOrdenCarta"))

                If strFlagLeasing = "1" Then
                    pr_rptsubBonoLeasing = CType(pr_rptCartaBono.ReportDefinition.ReportObjects("Ritmo5Leasing"), SubreportObject)
                    pr_rptBonoLeasing = pr_rptCartaBono.OpenSubreport(pr_rptsubBonoLeasing.SubreportName)
                    pr_rptBonoLeasing.SetDataSource(dtsCarta.Tables("dtbCartaBono"))
                Else
                    pr_rptCartaBono.ReportDefinition.Sections("Leasing").SectionFormat.EnableSuppress = True
                End If

                pr_rptCartaBono.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4

                sb_ExportarADisco(pr_rptCartaBono, Server.MapPath(Concat("~\app.Bonos\Cartas\Ritmo5\tmp\Ritmo5_", pExpedienteId.ToString & Item.int_BeneficioId.ToString, ".pdf")))

                Dim strIdSAP = ""
                Dim HojaInformativa As Integer = 1
                Dim byteBeneficioArchivo As Byte() = Nothing
                Try
                    Dim ArchivoBeneficio As New BE_BeneficioArchivo
                    Dim Beneficio As New BE_BeneficioArchivo

                    Beneficio.int_BeneficioId = Item.int_BeneficioId

                    ArchivoBeneficio = clsBeneficio.fn_Select_BeneficioArchivo(Beneficio).Find(Function(C) C.int_ClaseId = 2)

                    If Not IsNothing(ArchivoBeneficio) Then byteBeneficioArchivo = ArchivoBeneficio.bin_Archivo

                Catch ex1 As Exception
                    byteBeneficioArchivo = Nothing
                End Try

               
                'Adjunta Documento
                If Not IsNothing(byteBeneficioArchivo) And HojaInformativa = 1 Then
                    File.WriteAllBytes(Server.MapPath("Cartas\Ritmo5\tmp") & "\ZOLA.PDF", byteBeneficioArchivo)
                    sb_ProccessFolder(Server.MapPath("Cartas\Ritmo5\tmp"), Concat("Ritmo5_", pExpedienteId.ToString & Item.int_BeneficioId.ToString, ".pdf"), True, "_" & strIdSAP & ".pdf")
                    'RutaArchivo = Server.MapPath("Cartas\Ritmo5_" & pExpedienteId.ToString & ".pdf")

                End If

            Next

            UnirArchivosCSA(Server.MapPath("Cartas\Ritmo5"), Concat("Ritmo5_", pExpedienteId.ToString & ".pdf"))

            Dim RutaArchivo As String = Server.MapPath("Cartas\Ritmo5_" & pExpedienteId.ToString & ".pdf")
            Dim Archivo As New BE_ExpedienteArchivo
            Dim bytes As Byte() = Nothing

            If File.Exists(RutaArchivo) Then
                bytes = File.ReadAllBytes(RutaArchivo)
                'GRABAR ARCHIVO EN BD
                With Archivo
                    .intExpedienteId = pExpedienteId
                    .bin_Archivo = bytes
                    .str_UsuarioCreacion = 1
                    .int_ClaseId = 2
                    .str_NombreArchivo = Concat("Ritmo5_", pExpedienteId.ToString, ".pdf")
                End With

                clsMaquina.fn_Insert_ExpedienteArchivo(Archivo)
                If File.Exists(RutaArchivo) Then
                    File.Delete(RutaArchivo)
                End If
            End If

        Catch ex As Exception
            Dim rethrow As Boolean = ExceptionPolicy.HandleException(ex, "ExHandling")
            Throw ex
        End Try
    End Sub

    Private Sub UnirArchivosCSA(ByVal pi_strFolderPath As String, ByVal pi_strNombreArchivoFinal As String)
        Try
            Dim strDirCartas As String = Server.MapPath(ConfigurationManager.AppSettings("dirCartas")).ToString

            Dim bolOutputfileAlreadyExists As Boolean = False
            Dim oFolderInfo As New System.IO.DirectoryInfo(pi_strFolderPath)
            Dim sOutFilePath As String = Concat(strDirCartas, "\", pi_strNombreArchivoFinal)

            Dim iPageCount As Integer = fn_GetPageCount(pi_strFolderPath)
            If iPageCount > 0 And bolOutputfileAlreadyExists = False Then
                Dim oFiles As String() = Directory.GetFiles(pi_strFolderPath)

                Dim oPdfDoc As New iTextSharp.text.Document()
                Dim oPdfWriter As PdfWriter = PdfWriter.GetInstance(oPdfDoc, New FileStream(sOutFilePath, FileMode.Create))
                oPdfDoc.Open()

                For i As Integer = 0 To oFiles.Length - 1
                    Dim sFromFilePath As String = oFiles(i)
                    Dim oFileInfo As New FileInfo(sFromFilePath)
                    Dim sExt As String = UCase(oFileInfo.Extension).Substring(1, 3)

                    Try
                        If sExt = "PDF" Then
                            sb_AddPdf(sFromFilePath, oPdfDoc, oPdfWriter)
                        End If
                    Catch ex As Exception
                        'MessageBox.Show("Ummm, algo fallo")
                    End Try
                Next i

                Try
                    oPdfDoc.Close()
                    oPdfWriter.Close()
                Catch ex As Exception
                    Try
                        System.IO.File.Delete(sOutFilePath)
                    Catch ex2 As Exception
                    End Try
                End Try
            End If

            'Elimina el contenido del repositorio de cartas Ritmo5
            sb_EliminarArchivosRitmo5(pi_strFolderPath)
        Catch ex As Exception
            'Me.Label1.Text = ex.ToString
            Throw ex
        End Try
    End Sub

    Public Sub sb_CreaCartaRpto(ByVal pExpedienteId As Integer, ByVal pCompaniaId As String)
        Try
            Dim dtsCarta As New dtsCarta
            Dim intNumeroUnidades As Integer
            Dim strFlagLeasing As String = String.Empty

            Dim decImporteBonoRpto As Decimal = 0.0

            'crear / actualizar el número de carta
            Dim intNumeroCarta As Integer = cmpCrearNumeroCarta.fn_CrearNumeroCarta()

            Dim ListaOrdenSAP As New List(Of BE_Maquina)
            Dim Parametros As New BE_Maquina
            Parametros.int_ExpedienteId = pExpedienteId
            Parametros.int_ClaseId = 1

            ListaOrdenSAP = clsMaquina.fn_Select_Maquina_ExpedienteBono(Parametros)

            sb_ObtenerOrden(dtsCarta, pExpedienteId, pCompaniaId, intNumeroUnidades, "1", decImporteBonoRpto, ListaOrdenSAP)
            sb_ObtenerDatosCarta(dtsCarta, pExpedienteId, intNumeroUnidades, strFlagLeasing, intNumeroCarta, decImporteBonoRpto)

            pr_rptCartaBono = New CrystalDecisions.CrystalReports.Engine.ReportDocument

            'pr_strReportPathImage = Request.PhysicalApplicationPath
            pr_strReportPathCartaBono = Server.MapPath("~\Reports\CartaBono.rpt")
            pr_strReportPathUnidades = Server.MapPath("~\Reports\Unidades.rpt")
            pr_strReportPathBonoLeasing = Server.MapPath("~\Reports\BonoLeasing.rpt")

            pr_rptCartaBono.Load(pr_strReportPathCartaBono)
            pr_rptCartaBono.Database.Tables("dtbCartaBono").SetDataSource(dtsCarta.Tables("dtbCartaBono"))

            'Obtengo el nombre del Subreporte de Unidades
            pr_rptsubUnidades = CType(pr_rptCartaBono.ReportDefinition.ReportObjects("subUnidades"), SubreportObject)
            pr_rptUnidades = pr_rptCartaBono.OpenSubreport(pr_rptsubUnidades.SubreportName)
            pr_rptUnidades.SetDataSource(dtsCarta.Tables("dtbOrdenCarta"))

            If strFlagLeasing = "1" Then
                pr_rptsubBonoLeasing = CType(pr_rptCartaBono.ReportDefinition.ReportObjects("BonoLeasing"), SubreportObject)
                pr_rptBonoLeasing = pr_rptCartaBono.OpenSubreport(pr_rptsubBonoLeasing.SubreportName)
                pr_rptBonoLeasing.SetDataSource(dtsCarta.Tables("dtbCartaBono"))
            Else
                pr_rptCartaBono.ReportDefinition.Sections("Leasing").SectionFormat.EnableSuppress = True
                'pr_rptsubBonoLeasing = CType(pr_rptCartaBono.ReportDefinition.ReportObjects("BonoLeasing"), SubreportObject)
                'pr_rptBonoLeasing = pr_rptCartaBono.OpenSubreport(pr_rptsubBonoLeasing.SubreportName)
                'pr_rptCartaBono.Subreports(pr_rptsubBonoLeasing.SubreportName).Close()
            End If

            pr_rptCartaBono.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4

             Dim strIdSAP = ""
            Dim HojaInformativa As Integer = 0
            Dim byteBeneficioArchivo As Byte() = Nothing
            Try
                Dim ArchivoBeneficio As New BE_BeneficioArchivo
                Dim Beneficio As New BE_BeneficioArchivo

                Beneficio.int_BeneficioId = 2

                ArchivoBeneficio = clsBeneficio.fn_Select_BeneficioArchivo(Beneficio).Find(Function(C) C.int_ClaseId = 1)

                If Not IsNothing(ArchivoBeneficio) Then byteBeneficioArchivo = ArchivoBeneficio.bin_Archivo

            Catch ex1 As Exception
                byteBeneficioArchivo = Nothing
            End Try

            Dim RutaArchivo As String = Server.MapPath("Cartas\Bono_" & pExpedienteId.ToString & ".pdf")
            Dim Archivo As New BE_ExpedienteArchivo
            Dim bytes As Byte() = Nothing

            If Not IsNothing(byteBeneficioArchivo) And HojaInformativa = 1 Then
                File.WriteAllBytes(Server.MapPath("Cartas\Ritmo5") & "\ZOLA.PDF", byteBeneficioArchivo)
                sb_ExportarADisco(pr_rptCartaBono, Server.MapPath(Concat("~\app.Bonos\Cartas\Ritmo5\Bono_", pExpedienteId.ToString, ".pdf")))
                sb_ProccessFolder(Server.MapPath("Cartas\Ritmo5"), Concat("Bono_", pExpedienteId.ToString, ".pdf"), "_" & strIdSAP & ".pdf")
            Else
                sb_ExportarADisco(pr_rptCartaBono, Server.MapPath(Concat("~\app.Bonos\Cartas\Bono_", pExpedienteId.ToString, ".pdf")))
            End If

            If (File.Exists(RutaArchivo)) Then
                bytes = File.ReadAllBytes(RutaArchivo)
                'GRABAR ARCHIVO EN BD
                With Archivo
                    .intExpedienteId = pExpedienteId
                    .bin_Archivo = bytes
                    .str_UsuarioCreacion = 1
                    .int_ClaseId = 1
                    .str_NombreArchivo = Concat("Bono_", pExpedienteId.ToString, ".pdf")
                End With

                clsMaquina.fn_Insert_ExpedienteArchivo(Archivo)
                If File.Exists(RutaArchivo) Then
                    File.Delete(RutaArchivo)
                End If

            End If
           
            ''''
        Catch ex As Exception
            Dim rethrow As Boolean = ExceptionPolicy.HandleException(ex, "ExHandling")
            Throw ex
        End Try
    End Sub

    Public Sub sb_ProccessFolder(ByVal pFolderPath As String, ByVal pNombreArchivoFinal As String, ByVal pEsBonoCSA As Boolean, Optional ByVal pActaCSA As String = "_PlanPremiumPrime.pdf")
        Try
            'Dim strPDF_Info As String = Server.MapPath("Descargas\Z" & pActaCSA).ToString
            Dim strDirCartas As String = Server.MapPath(ConfigurationManager.AppSettings("dirCartas")).ToString

            If pEsBonoCSA Then
                strDirCartas = strDirCartas & "\Ritmo5"
            End If

            Dim bolOutputfileAlreadyExists As Boolean = False
            Dim oFolderInfo As New System.IO.DirectoryInfo(pFolderPath)
            Dim sOutFilePath As String = Concat(strDirCartas, "\", pNombreArchivoFinal)

            Dim iPageCount As Integer = fn_GetPageCount(pFolderPath)
            If iPageCount > 0 And bolOutputfileAlreadyExists = False Then
                Dim oFiles As String() = Directory.GetFiles(pFolderPath)

                Dim oPdfDoc As New iTextSharp.text.Document()
                Dim oPdfWriter As PdfWriter = PdfWriter.GetInstance(oPdfDoc, New FileStream(sOutFilePath, FileMode.Create))
                oPdfDoc.Open()

                For i As Integer = 0 To oFiles.Length - 1
                    Dim sFromFilePath As String = oFiles(i)
                    Dim oFileInfo As New FileInfo(sFromFilePath)
                    Dim sExt As String = UCase(oFileInfo.Extension).Substring(1, 3)

                    Try
                        If sExt = "PDF" Then
                            sb_AddPdf(sFromFilePath, oPdfDoc, oPdfWriter)
                        End If
                    Catch ex As Exception
                        'MessageBox.Show("Ummm, algo fallo")
                    End Try
                Next i

                Try
                    oPdfDoc.Close()
                    oPdfWriter.Close()
                Catch ex As Exception
                    Try
                        System.IO.File.Delete(sOutFilePath)
                    Catch ex2 As Exception
                    End Try
                End Try
            End If


            'Elimina el contenido del repositorio de cartas Ritmo5
            sb_EliminarArchivosRitmo5(pFolderPath)


        Catch ex As Exception
            'Me.Label1.Text = ex.ToString
            Throw ex
        End Try
    End Sub

    Public Sub sb_EliminarArchivosRitmo5(ByVal sFolderPath As String)
        Try
            Dim iRet As Integer = 0
            Dim oFiles As String() = Directory.GetFiles(sFolderPath)

            For i As Integer = 0 To oFiles.Length - 1
                Dim sFromFilePath As String = oFiles(i)
                If File.Exists(sFromFilePath) Then File.Delete(sFromFilePath)
            Next i
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub sb_AddPdf(ByVal sInFilePath As String, ByRef oPdfDoc As iTextSharp.text.Document, ByVal oPdfWriter As PdfWriter)
        Try
            Dim oDirectContent As iTextSharp.text.pdf.PdfContentByte = oPdfWriter.DirectContent
            Dim oPdfReader As iTextSharp.text.pdf.PdfReader = New iTextSharp.text.pdf.PdfReader(sInFilePath)
            Dim iNumberOfPages As Integer = oPdfReader.NumberOfPages
            Dim iPage As Integer = 0

            Do While (iPage < iNumberOfPages)
                iPage += 1
                oPdfDoc.SetPageSize(oPdfReader.GetPageSizeWithRotation(iPage))
                oPdfDoc.NewPage()

                Dim oPdfImportedPage As iTextSharp.text.pdf.PdfImportedPage = oPdfWriter.GetImportedPage(oPdfReader, iPage)
                Dim iRotation As Integer = oPdfReader.GetPageRotation(iPage)
                If (iRotation = 90) Or (iRotation = 270) Then
                    oDirectContent.AddTemplate(oPdfImportedPage, 0, -1.0F, 1.0F, 0, 0, oPdfReader.GetPageSizeWithRotation(iPage).Height)
                Else
                    oDirectContent.AddTemplate(oPdfImportedPage, 1.0F, 0, 0, 1.0F, 0, 0)
                End If
            Loop
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function fn_GetPageCount(ByVal sFolderPath As String) As Integer
        Try
            Dim iRet As Integer = 0
            Dim oFiles As String() = Directory.GetFiles(sFolderPath)

            For i As Integer = 0 To oFiles.Length - 1
                Dim sFromFilePath As String = oFiles(i)
                Dim oFileInfo As New FileInfo(sFromFilePath)
                Dim sExt As String = UCase(System.IO.Path.GetExtension(sFromFilePath).Replace(".", "")) 'UCase(oFileInfo.Extension).Substring(1, 3)
                If sExt = "PDF" Then
                    iRet += 1
                End If
            Next i

            Return iRet
        Catch ex As Exception
            Return 0
            Throw ex
        End Try
    End Function

    Public Sub sb_ExportarADisco(ByVal pi_rptDocument As ReportDocument, ByVal pi_strFileName As String)
        Try
            If System.IO.File.Exists(pi_strFileName) Then 'si existe primero borra y luego crea el archivo
                System.IO.File.Delete(pi_strFileName)

                Dim diskOpts As DiskFileDestinationOptions = ExportOptions.CreateDiskFileDestinationOptions()

                Dim exportOpts As ExportOptions = New ExportOptions()
                exportOpts.ExportFormatType = ExportFormatType.PortableDocFormat
                exportOpts.ExportDestinationType = ExportDestinationType.DiskFile

                diskOpts.DiskFileName = pi_strFileName
                exportOpts.ExportDestinationOptions = diskOpts

                pi_rptDocument.Export(exportOpts)
            Else 'si no existe solo crea el archivo
                Dim diskOpts As DiskFileDestinationOptions = ExportOptions.CreateDiskFileDestinationOptions()

                Dim exportOpts As ExportOptions = New ExportOptions()
                exportOpts.ExportFormatType = ExportFormatType.PortableDocFormat
                exportOpts.ExportDestinationType = ExportDestinationType.DiskFile

                diskOpts.DiskFileName = pi_strFileName
                exportOpts.ExportDestinationOptions = diskOpts

                pi_rptDocument.Export(exportOpts)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub sb_ObtenerOrden(ByRef po_dtsCarta As dtsCarta, ByVal pi_intIdIncidente As Integer, ByVal pi_str_IdCompania As String, _
                                ByRef po_intNumeroUnidades As Integer, ByVal pi_strTipoBono As String, ByRef po_decTotalBono As Decimal, ByVal pi_liBEMaquinaBono As List(Of BE_Maquina), Optional ByVal pBeneficioId As Integer = 0)
        Try
            Dim liBEOrden As New List(Of BE_Maquina)
            Dim BEOrden As New BE_Maquina

            liBEOrden = pi_liBEMaquinaBono 'clsMaquina.fn_Select_Maquina_Bono(BEOrden)

            'If pi_strTipoBono = "1" Then
            '    liBEOrden = clsMaquina.fn_Select_Maquina_Expediente(BEOrden) '.fn_Select_ListaOrden_BonoRpto(BEOrden)
            'ElseIf pi_strTipoBono = "2" Then
            '    liBEOrden = clsMaquina.fn_Select_ListaOrden_CSARitmo5(BEOrden)
            'End If

            Dim intNumero As Integer = 1

            Dim dtsCarta As New dtsCarta
            dtsCarta = po_dtsCarta

            Dim drwOrden As DataRow = Nothing

            For Each it As BE_Maquina In liBEOrden
                If pBeneficioId <> 0 Then
                    If it.int_BeneficioId <> pBeneficioId Then
                        Continue For
                    End If
                End If
                drwOrden = dtsCarta.Tables("dtbOrdenCarta").NewRow

                drwOrden.Item("str_Numero") = intNumero.ToString
                drwOrden.Item("str_DescripcionUnidad") = it.str_FamiliaDesc
                drwOrden.Item("str_Orden") = it.str_OrdenAsignada
                drwOrden.Item("str_Modelo") = it.str_ModeloProductoDesc
                drwOrden.Item("str_Marca") = it.str_MarcaDesc
                drwOrden.Item("str_NumeroSerie") = it.str_SerieMaquina

                'drwOrden.Item("str_MontoBono") = (it.dec_Ritmo5Monto + it.dec_BonoRptoMonto).ToString("N2")
                Select Case pi_strTipoBono
                    Case "1" 'Bono de repuesto
                        drwOrden.Item("str_MontoBono") = it.dec_BonoRptoMonto.ToString("N2")
                        drwOrden.Item("str_MontoBonoLetras") = clsUtil.fn_NumeroALetrasBancario(it.dec_BonoRptoMonto.ToString)
                        drwOrden.Item("str_Ritmo5Tipo") = String.Empty

                        po_decTotalBono = po_decTotalBono + it.dec_BonoRptoMonto
                    Case "2" 'Bono de servicio CSA - Ritmo 5
                        drwOrden.Item("str_MontoBono") = it.dec_Ritmo5Monto.ToString("N2")
                        drwOrden.Item("str_MontoBonoLetras") = clsUtil.fn_NumeroALetrasBancario(it.dec_Ritmo5Monto.ToString)
                        drwOrden.Item("str_Ritmo5Tipo") = it.str_Ritmo5Tipo

                        po_decTotalBono = po_decTotalBono + it.dec_Ritmo5Monto
                End Select

                dtsCarta.Tables("dtbOrdenCarta").Rows.Add(drwOrden)
                'sb_EscribeLog(Concat("Orden: ", it.str_Orden))
                intNumero = intNumero + 1
            Next it

            po_dtsCarta = dtsCarta
            po_intNumeroUnidades = liBEOrden.Count
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub sb_ObtenerDatosCarta(ByRef po_dtsCarta As dtsCarta, ByVal pi_intIdIncidente As Integer, ByVal pi_intNumeroUnidades As Integer, ByRef po_strFlagLeasing As String, _
                                     ByVal pi_intNumeroCarta As Integer, ByVal pi_decTotalBono As Decimal)
        Try
            'sb_EscribeLog(Concat("obtener datos carta, número de unidades: ", pi_intNumeroUnidades.ToString, ", TotalBono: ", pi_decTotalBono))
            Dim dtsCarta As New dtsCarta
            dtsCarta = po_dtsCarta

            Dim drwCarta As DataRow = Nothing

            'buscar los datos de la cabecera de la carta por medio de IdIncidente y sacar el codigo del cliente y de la entidad financiera
            Dim liBEOrden As New List(Of BE_Maquina)
            Dim BEOrden As New BE_Maquina
            BEOrden.int_ExpedienteId = pi_intIdIncidente
            BEOrden.str_EstadoMaquina = "ACT"

            liBEOrden = clsMaquina.fn_Select_Maquina_Expediente(BEOrden)

            Dim strCodCliente As String = String.Empty
            Dim strDescCliente As String = String.Empty
            Dim strCodEntidadFinanciera As String = String.Empty
            Dim strDescEntidadFinanciera As String = String.Empty
            Dim strIdIncidente As String = String.Empty
            Dim strNombreFirma As String = String.Empty
            Dim strCargoFirma As String = String.Empty
            Dim byteFirma As Byte() = Nothing

            Dim strOrden As String = String.Empty

            For Each it As BE_Maquina In liBEOrden
                strCodCliente = it.str_ClienteId
                strDescCliente = it.str_ClienteDesc
                strCodEntidadFinanciera = it.str_EntidadFinancieraId
                strDescEntidadFinanciera = it.str_FinanciamientoDesc
                strIdIncidente = pi_intNumeroCarta.ToString.PadLeft(5, "0")

                strNombreFirma = it.str_NombreFirma
                strCargoFirma = it.str_CargoFirma
                byteFirma = it.byte_ImagenFirma

                strOrden = it.str_OrdenAsignada

                'determinar si es Leasing o no
                If it.str_ClienteId <> it.str_ClienteFacturaId Then po_strFlagLeasing = "1" Else po_strFlagLeasing = "0"
            Next it

            'buscar el ruc y la dirección del cliente en la dimensión cliente
            Dim liBEDimCliente As New List(Of BE_DimCliente2)
            Dim BEDimCliente As New BE_DimCliente2
            'BEDimCliente.str_COD_CLIENTE = strCodCliente
            liBEDimCliente = clsDimCliente.fn_Select_ListaDimCliente(strCodCliente)

            Dim strRUCCliente As String = String.Empty
            Dim strDireccionCliente As String = String.Empty

            For Each it As BE_DimCliente2 In liBEDimCliente
                strRUCCliente = it.str_NUM_IDENTIFICACION
            Next it

            ''obtener la dirección de la factura
            'Dim liBEDireccionFactura As New List(Of BE_DireccionFactura)
            'Dim BEDireccionFactura As New BE_DireccionFactura
            'BEDireccionFactura.str_REFEREN = strOrden
            'BEDireccionFactura.str_CLIAD = strCodCliente
            'liBEDireccionFactura = clsDireccionFactura.fn_Select_ListaDireccionFactura(BEDireccionFactura)

            'For Each it As BE_DireccionPrincipalCliente In liBEDireccionPrincipalCliente
            '   strDireccionCliente += Concat(it.str_DIRECCION, ", ")
            'Next it

            'If strDireccionCliente.Length > 2 Then strDireccionCliente = strDireccionCliente.Substring(0, strDireccionCliente.Length - 2) Else strDireccionCliente = String.Empty

            'obtener la dirección principal
            Dim liBEDireccionPrincipalCliente As New List(Of BE_DireccionPrincipalCliente)
            Dim BEDireccionPrincipalCliente As New BE_DireccionPrincipalCliente
            BEDireccionPrincipalCliente.str_CUNO = strCodCliente
            'sb_EscribeLog(Concat("Cliente: ", BEDireccionPrincipalCliente.str_CUNO))
            Try
                liBEDireccionPrincipalCliente = clsDireccionPrincipalCliente.fn_Select_ListaDireccionPrincipalCliente(BEDireccionPrincipalCliente)
                'sb_EscribeLog("obtubo dirección principal cliente")
            Catch ex1 As Exception
                'sb_EscribeLog(Concat("Error: ", ex1.ToString))
            End Try
            For Each it As BE_DireccionPrincipalCliente In liBEDireccionPrincipalCliente
                strDireccionCliente = Concat(it.str_DIRECCION.Trim, ", ", it.str_NOM_DEPARTAMENTO.Trim, ", ", it.str_NOM_PROVINCIA.Trim, ", ", it.str_NOM_DISTRITO.Trim)
                'sb_EscribeLog(strDireccionCliente)
            Next it

            drwCarta = dtsCarta.Tables("dtbCartaBono").NewRow

            drwCarta.Item("str_FechaActual") = clsUtil.fn_FechaLarga(Now())
            drwCarta.Item("str_RazonSocial") = strDescCliente.ToUpper  '"Minera Yanacocha"
            drwCarta.Item("str_RUC") = strRUCCliente '"12345678901"
            drwCarta.Item("str_Direccion") = strDireccionCliente.ToUpper  ' "Lima, San Isidro Perú"
            drwCarta.Item("str_FlagLeasing") = po_strFlagLeasing
            drwCarta.Item("str_EntidadFinanciera") = strDescEntidadFinanciera.ToUpper
            drwCarta.Item("str_NumeroUnidad") = pi_intNumeroUnidades.ToString
            drwCarta.Item("str_NombreNumeroUnidad") = clsUtil.fn_NumeroALetras(pi_intNumeroUnidades.ToString)
            drwCarta.Item("str_IdIncidente") = strIdIncidente
            drwCarta.Item("str_TotalBono") = pi_decTotalBono.ToString("N2")
            drwCarta.Item("str_TotalBonoLetras") = clsUtil.fn_NumeroALetrasBancario(pi_decTotalBono.ToString)

            drwCarta.Item("str_NombreFirma") = strNombreFirma
            drwCarta.Item("str_CargoFirma") = strCargoFirma
            drwCarta.Item("byte_ImagenFirma") = byteFirma



            'sb_EscribeLog("completo la tabla CartaBono")
            dtsCarta.Tables("dtbCartaBono").Rows.Add(drwCarta)

            po_dtsCarta = dtsCarta
            'sb_EscribeLog("termino de obtener datos carta")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub sb_SaveFile(ByVal pi_File As HttpPostedFile, ByVal pi_fulControl As FileUpload, ByVal pi_objLabelError As Label, _
                          ByVal pi_strPrefijoArchivo As String, ByVal pi_intIdIncidente As Integer)
        Try
            Dim strDirCartas As String = ConfigurationManager.AppSettings("dirCartas").ToString
            Dim strSavePath As String = Server.MapPath(Concat("~\", strDirCartas, "\"))
            'Dim strFileName As String = pi_fulControl.FileName
            Dim strFileNameFinal As String = Concat(pi_strPrefijoArchivo, pi_intIdIncidente.ToString, ".pdf")
            Dim strPathToCheck As String = Concat(strSavePath, strFileNameFinal)
            Dim bolFileOK As Boolean = False

            Dim strFileExtension As String = System.IO.Path.GetExtension(pi_fulControl.FileName).ToLower()
            Dim allowedExtensions As String() = {".pdf"}

            For i As Integer = 0 To allowedExtensions.Length - 1
                If strFileExtension = allowedExtensions(i) Then
                    bolFileOK = True
                End If
            Next i

            If bolFileOK Then
                If (System.IO.File.Exists(strPathToCheck)) Then
                    Dim fs As System.IO.FileStream = System.IO.File.Open(strPathToCheck, IO.FileMode.Truncate)
                    fs.Dispose()

                    System.IO.File.Delete(strPathToCheck)
                End If

                strSavePath += strFileNameFinal

                Try
                    pi_fulControl.PostedFile.SaveAs(strSavePath)
                    pi_objLabelError.Text = "Archivo cargado."

                    'sb_MostrarArchivosFirmados(pi_intIdIncidente)

                    'Guardar el nombre del archivo en base de datos

                Catch ex As Exception
                    pi_objLabelError.Text = "Error en la carga."
                End Try
            Else
                pi_objLabelError.Text = "Formato no permitido."
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "Reportes Bonos"

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

End Class