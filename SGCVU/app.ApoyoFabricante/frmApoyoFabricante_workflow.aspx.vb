Imports SGCVU.BE
Imports SGCVU.BL
Imports SGCVU.DTO
Imports System.Reflection
Imports System.Globalization
Imports System.Data.SqlClient
Imports System.IO
Imports System.Web.UI.HtmlControls
Imports Microsoft.Reporting.WebForms

Public Class frmApoyoFabricante_workflow
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

        End If

    End Sub

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function GetData_Workflow(ByVal page As Integer, ByVal rows As Integer, ByVal sidx As String, ByVal sord As String, ByVal Filter As DTO_Apoyo_Flujo)
        Try

            Dim _ListBeApoyoFlujo As New List(Of BE_Apoyo_Flujo)
            Dim _ListApoyoFlujo = New List(Of Object)
            Dim _BeApoyoFlujo As New BE_Apoyo_Flujo
            Dim _sgResult = New s_GridResult
            Dim _intCantReg As Integer = rows

            Filter.strUsuarioCuentaInventario = HttpContext.Current.Session("LoginAuthentications")

            Filter.PrepareData()
            _ListBeApoyoFlujo = clsApoyo_Flujo.fn_Select_ApoyoFlujo_ByFilter(Filter)

            If _ListBeApoyoFlujo IsNot Nothing AndAlso _ListBeApoyoFlujo.Count > 0 Then

                For Each item In _ListBeApoyoFlujo
                    _ListApoyoFlujo.Add(New With {
                                   Key .int_ApoyoId = item.int_ApoyoId,
                                        .str_CompaniaId = item.str_CompaniaId,
                                        .str_OrdenAsignadaHide = item.str_OrdenAsignada,
                                        .str_OrdenAsignada = item.str_OrdenAsignada,
                                        .str_PedidoId = item.str_PedidoId,
                                        .int_PosicionId = item.int_PosicionId,
                                        .str_ModeloRDA = item.str_ModeloRDA,
                                        .str_ModeloProductoId = item.str_ModeloProductoId,
                                        .str_ModeloProductoDesc = item.str_ModeloProductoDesc,
                                        .str_SerieMaquina = item.str_SerieMaquina,
                                        .str_EstadoInventario = item.str_EstadoInventario,
                                        .bl_EstructuraCostos = item.bl_EstructuraCostos,
                                        .str_ClienteId = item.str_ClienteId,
                                        .str_DESC_CLIENTE = item.str_DESC_CLIENTE,
                                        .str_ApoyoTipoId = item.str_ApoyoTipoId,
                                        .str_ApoyoTipoDesc = item.str_ApoyoTipoDesc,
                                        .dec_ImporteApoyoCAT = item.dec_ImporteApoyoCAT,
                                        .dec_ValorVentaMaquinaCRM = item.dec_ValorVentaMaquinaCRM,
                                        .int_FlujoId = item.int_FlujoId,
                                        .str_FlujoEstado = item.str_FlujoEstado,
                                        .str_IdProgramaCAT = item.str_IdProgramaCAT,
                                        .det_FechaSolicitudCAT = item.det_FechaSolicitudCAT,
                                        .int_DiasSolicitud = item.int_DiasSolicitud,
                                        .int_SolicitudId = item.int_SolicitudId,
                                        .str_SolicitudEstado = item.str_SolicitudEstado,
                                        .det_FechaClaim = item.det_FechaClaim,
                                        .det_FechaSRC = item.det_FechaSRC,
                                       .int_DiasClaim = item.int_DiasClaim,
                                       .det_WashOutFecha = item.det_WashOutFecha,
                                       .int_DiasWashout = item.int_DiasWashout,
                                       .str_WashoutEstado = item.str_WashoutEstado,
                                       .int_SubGridFlag = item.int_SubGridFlag,
                                       .str_CuentaInventarioDBS = item.str_CuentaInventarioDBS
                                    })
                Next item

                _sgResult.rows = _ListApoyoFlujo
                _sgResult.page = page
                _sgResult.total = Math.Ceiling(10D / Convert.ToDecimal(rows))
                _sgResult.records = _ListApoyoFlujo.Count

            End If


            Return _sgResult

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function GetData_WorkflowChild(ByVal ApoyoId As Integer)
        Try

            Dim _ListBeExpedienteProgramas As New List(Of BE_Expediente_Programas)
            Dim _ListExpedienteProgramas As New List(Of Object)
            Dim _BeExpedienteProgramas As New BE_Expediente_Programas
            Dim _sgResult = New s_GridResult

            _BeExpedienteProgramas.int_ApoyoId = ApoyoId

            _ListBeExpedienteProgramas = clsExpediente_Programas.fn_Select_ExpedienteProgramas_ByApoyo(_BeExpedienteProgramas)

            If _ListBeExpedienteProgramas IsNot Nothing AndAlso _ListBeExpedienteProgramas.Count > 0 Then

                For Each item In _ListBeExpedienteProgramas
                    _ListExpedienteProgramas.Add(New With {
                                   Key .int_ExpPrograma_Id = item.int_ExpPrograma_Id,
                                    .int_ApoyoId = item.int_ApoyoId,
                                    .int_ProgramasId = item.int_ProgramasId,
                                    .str_IdProgramaCAT = item.str_IdProgramaCAT,
                                    .str_DescPrograma = item.str_DescPrograma,
                                    .str_ExpPrograma_NumeroClaim = item.str_ExpPrograma_NumeroClaim,
                                    .det_ExpPrograma_FechaClaim = item.det_ExpPrograma_FechaClaim,
                                    .str_ExpPrograma_NumeroCreditMemo = item.str_ExpPrograma_NumeroCreditMemo,
                                    .det_ExpPrograma_FechaCreditMemo = item.det_ExpPrograma_FechaCreditMemo,
                                    .dec_ExpPrograma_MontoSolicitado = item.dec_ExpPrograma_MontoSolicitado,
                                    .dec_ExpPrograma_MontoPagado = item.dec_ExpPrograma_MontoPagado,
                                    .bl_ExpPrograma_Estado = item.bl_ExpPrograma_Estado,
                                    .str_OrdenAsignada = item.str_OrdenAsignada
                                })
                Next item

                _sgResult.rows = _ListExpedienteProgramas

            End If

            Return _sgResult

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function GetData_Workflow_ByKey(ByVal ApoyoId As Integer)

        Dim rpta As DTO_RptaPeticion = New DTO_RptaPeticion()

        Try

            If HttpContext.Current.Session("LoginAuthentications") Is Nothing Then
                rpta.sesionValida = False
                Return rpta
            End If

            Dim _ListBeApoyoFlujo As New List(Of BE_Apoyo_Flujo)
            Dim _ListApoyoFlujo = New List(Of Object)
            Dim _BeApoyoFlujo As New BE_Apoyo_Flujo

            _BeApoyoFlujo.int_ApoyoId = ApoyoId

            _ListBeApoyoFlujo = clsApoyo_Flujo.fn_Select_ApoyoFlujo_ByKey(_BeApoyoFlujo)

            If _ListBeApoyoFlujo IsNot Nothing AndAlso _ListBeApoyoFlujo.Count > 0 Then

                For Each item In _ListBeApoyoFlujo
                    _ListApoyoFlujo.Add(New With {
                                   Key .int_ApoyoId = item.int_ApoyoId,
                                        .str_CompaniaId = item.str_CompaniaId,
                                        .str_OrdenAsignada = item.str_OrdenAsignada,
                                        .str_PedidoId = item.str_PedidoId,
                                        .int_PosicionId = item.int_PosicionId,
                                        .str_ModeloRDA = item.str_ModeloRDA,
                                        .str_ModeloProductoId = item.str_ModeloProductoId,
                                        .str_ModeloProductoDesc = item.str_ModeloProductoDesc,
                                        .str_SerieMaquina = item.str_SerieMaquina,
                                        .str_EstadoInventario = item.str_EstadoInventario,
                                        .bl_EstructuraCostos = item.bl_EstructuraCostos,
                                        .str_ClienteId = item.str_ClienteId,
                                        .str_DESC_CLIENTE = item.str_DESC_CLIENTE,
                                        .str_ApoyoTipoId = item.str_ApoyoTipoId,
                                        .str_ApoyoTipoDesc = item.str_ApoyoTipoDesc,
                                        .dec_ApoyoImporteCRM = item.dec_ApoyoImporteCRM,
                                        .dec_ValorVentaMaquinaCRM = item.dec_ValorVentaMaquinaCRM,
                                        .int_FlujoId = item.int_FlujoId,
                                        .str_FlujoEstado = item.str_FlujoEstado,
                                        .str_IdProgramaCAT = item.str_IdProgramaCAT,
                                        .det_FechaSolicitudCAT = item.det_FechaSolicitudCAT,
                                        .int_DiasSolicitud = item.int_DiasSolicitud,
                                        .int_SolicitudId = item.int_SolicitudId,
                                        .str_SolicitudEstado = item.str_SolicitudEstado,
                                        .det_FechaClaim = item.det_FechaClaim,
                                        .det_FechaSRC = item.det_FechaSRC,
                                       .int_DiasClaim = item.int_DiasClaim,
                                       .det_WashOutFecha = item.det_WashOutFecha,
                                       .int_DiasWashout = item.int_DiasWashout,
                                       .str_WashoutEstado = item.str_WashoutEstado,
                                       .str_Observacion = item.str_Observacion,
                                       .int_MaquinaApoyoId = item.int_MaquinaApoyoId,
                                       .det_FechaRespuestaCAT = item.det_FechaRespuestaCAT,
                                       .int_WashoutId = item.int_WashoutId,
                                       .str_WashoutArchivo = item.str_WashoutArchivo,
                                       .bl_HaveWashout = item.bl_HaveWashout,
                                       .str_Comentarios = item.str_Comentarios
                                    })
                Next item

            End If

            rpta.data = _ListApoyoFlujo
            HttpContext.Current.Session("ListApoyoFlujoSession") = _ListBeApoyoFlujo

            If _ListApoyoFlujo.Count < 0 Then
                Throw New Exception("Error para obtener datos de solicitud.")
            End If

        Catch ex As Exception
            rpta.success = False
            rpta.msg = String.Format("Message: {0} - StackTrace: {1}", ex.Message, ex.StackTrace)
        End Try

        Return rpta
    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function GetData_HistorialApoyoMaquina(ByVal ApoyoId As Integer, ByVal page As Integer, ByVal rows As Integer, ByVal sidx As String, ByVal sord As String)

        Dim _ListBeApoyoMaquina As New List(Of BE_ApoyoMaquina)
        Dim _ListApoyoMaquina As New List(Of Object)
        Dim _BeApoyoMaquina As New BE_ApoyoMaquina
        Dim _sResult = New s_GridResult

        _BeApoyoMaquina.int_ApoyoId = ApoyoId
        _ListBeApoyoMaquina = clsApoyo_Maquina.fn_Select_ApoyoMaquina_Historial_ByKey(_BeApoyoMaquina)

        If _ListBeApoyoMaquina IsNot Nothing AndAlso _ListBeApoyoMaquina.Count > 0 Then

            For Each item In _ListBeApoyoMaquina
                _ListApoyoMaquina.Add(New With {
                               Key .int_ApoyoId = item.int_ApoyoId,
                                .str_CompaniaId = item.str_CompaniaId,
                                .int_MaquinaApoyoId = item.int_MaquinaApoyoId,
                                .str_PedidoId = item.str_PedidoId,
                                .int_PosicionId = item.int_PosicionId,
                                .str_OrdenAsignada = item.str_OrdenAsignada,
                                .str_IdProgramaCAT = item.str_IdProgramaCAT,
                                .dec_ImporteApoyoCAT = item.dec_ImporteApoyoCAT,
                                .det_FechaSolicitudCAT = item.det_FechaSolicitudCAT,
                                .det_FechaRespuestaCAT = item.det_FechaRespuestaCAT,
                                .int_EstadoSolicitudId = item.int_EstadoSolicitudId,
                                .str_EstadoSolicitud = item.str_EstadoSolicitud,
                                .str_Observacion = item.str_Observacion,
                                .bl_SolicitudEstado = item.bl_SolicitudEstado,
                                .det_FechaCreacion = item.det_FechaCreacion,
                                .str_UsuarioCreacion = item.str_UsuarioCreacion,
                                .str_UsuarioModificacion = item.str_UsuarioModificacion,
                                .det_FechaModificacion = item.det_FechaModificacion
                            })

            Next item

            _sResult.rows = _ListApoyoMaquina
            _sResult.page = page
            _sResult.total = Math.Ceiling(10D / Convert.ToDecimal(rows))
            _sResult.records = _ListApoyoMaquina.Count

        End If

        Return _sResult

    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function GetData_HistorialExpediente(ByVal ApoyoId As Integer, ByVal page As Integer, ByVal rows As Integer, ByVal sidx As String, ByVal sord As String)
        Try
            Dim _ListBeExpedienteHistorial As New List(Of BE_ExpedienteHistorial)
            Dim _ListExpedienteHistorial As New List(Of Object)
            Dim _BeExpedienteHistorial As New BE_ExpedienteHistorial
            Dim _sResult = New s_GridResult

            If ApoyoId <> 0 Then _BeExpedienteHistorial.int_ApoyoId = ApoyoId

            _ListBeExpedienteHistorial = clsExpediente_Historial.fn_Select_ExpedienteHistorial_ByKey(_BeExpedienteHistorial)

            If _ListBeExpedienteHistorial IsNot Nothing AndAlso _ListBeExpedienteHistorial.Count > 0 Then

                For Each item In _ListBeExpedienteHistorial
                    _ListExpedienteHistorial.Add(New With {
                                   Key .int_RolFlujoId = item.int_RolFlujoId,
                                    .str_RolFlujo = item.str_RolFlujo,
                                    .int_ExpedienteHistorialId = item.int_ExpedienteHistorialId,
                                    .int_ExpedienteId = item.int_ExpedienteId,
                                    .int_ApoyoId = item.int_ApoyoId,
                                    .int_ActividadId = item.int_ActividadId,
                                    .str_Actividad = item.str_Actividad,
                                    .det_FechaCreacion = item.det_FechaCreacion,
                                    .int_UsuarioId = item.int_UsuarioId,
                                    .str_Usuario = item.str_Usuario
                                })
                Next item

                _sResult.rows = _ListExpedienteHistorial
                _sResult.page = page
                _sResult.total = Math.Ceiling(10D / Convert.ToDecimal(rows))
                _sResult.records = _ListExpedienteHistorial.Count

            End If

            Return _sResult

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function GetData_Programas_Solicitud(ByVal ApoyoId As Integer)
        Try

            Dim _ListBeExpedienteProgramas As New List(Of BE_Expediente_Programas)
            Dim _ListExpedienteProgramas As New List(Of Object)
            Dim _BeExpedienteProgramas As New BE_Expediente_Programas
            Dim _sgResult = New s_GridResult

            _BeExpedienteProgramas.int_ApoyoId = ApoyoId

            _ListBeExpedienteProgramas = clsExpediente_Programas.fn_Select_ExpedienteProgramas_ByApoyo(_BeExpedienteProgramas)

            If _ListBeExpedienteProgramas IsNot Nothing AndAlso _ListBeExpedienteProgramas.Count > 0 Then

                For Each item In _ListBeExpedienteProgramas
                    _ListExpedienteProgramas.Add(New With {
                                   Key .int_ExpPrograma_Id = item.int_ExpPrograma_Id,
                                    .int_ApoyoId = item.int_ApoyoId,
                                    .int_ProgramasId = item.int_ProgramasId,
                                    .str_IdProgramaCAT = item.str_IdProgramaCAT,
                                    .str_DescPrograma = item.str_DescPrograma,
                                    .str_ExpPrograma_NumeroClaim = item.str_ExpPrograma_NumeroClaim,
                                    .det_ExpPrograma_FechaClaim = item.det_ExpPrograma_FechaClaim,
                                    .str_ExpPrograma_NumeroCreditMemo = item.str_ExpPrograma_NumeroCreditMemo,
                                    .det_ExpPrograma_FechaCreditMemo = item.det_ExpPrograma_FechaCreditMemo,
                                    .dec_ExpPrograma_MontoSolicitado = item.dec_ExpPrograma_MontoSolicitado,
                                    .dec_ExpPrograma_MontoPagado = item.dec_ExpPrograma_MontoPagado,
                                    .bl_ExpPrograma_Estado = item.bl_ExpPrograma_Estado,
                                    .bl_Estado_Solicitud = item.bl_Estado_Solicitud,
                                    .str_OrdenAsignada = item.str_OrdenAsignada
                                })
                Next item

                _sgResult.rows = _ListExpedienteProgramas

            End If

            Return _sgResult

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function GetData_RelacionProgramas(ByVal ApoyoId As Integer)

        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()
        Try
            Dim _ListProgramas As New List(Of Object)
            Dim _ListBeProgramas As New List(Of BE_Programas)
            Dim _BeProgramas As New BE_ApoyoMaquina

            _BeProgramas.int_ApoyoId = ApoyoId

            _ListBeProgramas = clsProgramas.fn_Select_Programas_Solicitud(_BeProgramas)
            For Each item In _ListBeProgramas
                _ListProgramas.Add(New With {
                                  Key .int_ProgramasId = item.int_ProgramasId,
                                        .str_IdProgramaCAT = item.str_IdProgramaCAT,
                                        .str_DescPrograma = item.str_DescPrograma,
                                        .det_FechaInicio = item.det_FechaInicio,
                                        .det_FechaFin = item.det_FechaFin,
                                        .det_FechaCreacion = item.det_FechaCreacion,
                                        .det_FechaModificacion = item.det_FechaModificacion,
                                        .str_UsuarioCreacion = item.str_UsuarioCreacion,
                                        .str_UsuarioModificacion = item.str_UsuarioModificacion,
                                        .str_RolFlujoDesc = item.str_RolFlujoDesc,
                                        .bl_ProgramaStatus = item.bl_ProgramaStatus
                                    })
            Next item

            objRpta.data = _ListProgramas


        Catch ex As Exception
            objRpta.success = False
            objRpta.msg = String.Format("Message: {0} - StackTrace: {1}", ex.Message, ex.StackTrace)
        End Try
        Return objRpta

    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function GetData_DocumentosAdjuntos(ByVal ApoyoId As Integer, ByVal page As Integer, ByVal rows As Integer, ByVal sidx As String, ByVal sord As String)
        Try
            Dim _ListBeExpedienteDocAdjunto As New List(Of BE_Expediente_DocumentosAdjuntos)
            Dim _ListExpedienteDocAdjuntos As New List(Of Object)
            Dim _BeExpedienteDocAdjuntos As New BE_Expediente_DocumentosAdjuntos
            Dim _sResult = New s_GridResult

            If ApoyoId <> 0 Then _BeExpedienteDocAdjuntos.int_ApoyoId = ApoyoId

            _ListBeExpedienteDocAdjunto = clsExpediente_DocumentosAdjuntos.fn_Select_ExpedienteDocumentosAdjuntos_ByApoyoId(_BeExpedienteDocAdjuntos)

            If _ListBeExpedienteDocAdjunto IsNot Nothing AndAlso _ListBeExpedienteDocAdjunto.Count > 0 Then

                For Each item In _ListBeExpedienteDocAdjunto
                    _ListExpedienteDocAdjuntos.Add(New With {
                                   Key .int_ExpedienteId = item.int_ExpedienteId,
                                     .int_ApoyoId = item.int_ApoyoId,
                                     .str_ArchivoNombre = item.str_ArchivoNombre,
                                     .str_UsuarioCreacion = item.str_UsuarioCreacion,
                                     .det_FechaCreacion = item.det_FechaCreacion})
                Next item

                _sResult.rows = _ListExpedienteDocAdjuntos
                _sResult.page = page
                _sResult.total = Math.Ceiling(10D / Convert.ToDecimal(rows))
                _sResult.records = _ListExpedienteDocAdjuntos.Count

            End If

            Return _sResult

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function GetData_RowNumber()
        Try

            Dim _ListMasterTable As New List(Of BE_Master_Table)
            Dim _BeMasterTable As New BE_Master_Table

            _BeMasterTable.str_MasterTable_Key = "RowNumbers"
            _ListMasterTable = clsMaster_Table.fn_Select_MasterTable_ByKey(_BeMasterTable)
            Return _ListMasterTable

        Catch ex As Exception
            ' Dim rethrow As Boolean = ExceptionPolicy.HandleException(ex, "ExHandling")
            Throw ex
        End Try

    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function GetData_Billing()
        Try

            Dim _ListMasterTable As New List(Of BE_Master_Table)
            Dim _BeMasterTable As New BE_Master_Table

            _BeMasterTable.str_MasterTable_Key = "Billing"
            _ListMasterTable = clsMaster_Table.fn_Select_MasterTable_ByKey(_BeMasterTable)
            Return _ListMasterTable

        Catch ex As Exception
            ' Dim rethrow As Boolean = ExceptionPolicy.HandleException(ex, "ExHandling")
            Throw ex
        End Try

    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function GetData_EstadoFlujo()
        Try
            Dim _ListBeActividad As New List(Of BE_Actividad)
            Dim _BeActividad As New BE_Actividad
            _ListBeActividad = clsActividad.fn_ListaActividad_EstadoFlujo()

            Return _ListBeActividad

        Catch ex As Exception
            ' Dim rethrow As Boolean = ExceptionPolicy.HandleException(ex, "ExHandling")
            Throw ex
        End Try

    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function GetData_EstadoSolicitud()
        Try
            Dim _ListBeActividad As New List(Of BE_Actividad)
            Dim _BeActividad As New BE_Actividad
            _ListBeActividad = clsActividad.fn_ListaActividad_EstadoSolicitud()

            Return _ListBeActividad

        Catch ex As Exception
            ' Dim rethrow As Boolean = ExceptionPolicy.HandleException(ex, "ExHandling")
            Throw ex
        End Try

    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function GetData_LineaVenta()
        Try
            Dim _ListBeLineaVenta As New List(Of BE_LineaVentaMaestro)
            Dim _BeLineaVenta As New BE_LineaVentaMaestro
            _ListBeLineaVenta = clsLineaVentaMaestro.fn_Select_LineaVenta_All()


            Return _ListBeLineaVenta

        Catch ex As Exception
            ' Dim rethrow As Boolean = ExceptionPolicy.HandleException(ex, "ExHandling")
            Throw ex
        End Try

    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function GetData_Programas()
        Try
            Dim _ListBeProgramas As New List(Of BE_Programas)
            Dim _BeProgramas As New BE_Programas
            _ListBeProgramas = clsProgramas.fn_Select_Programas_All()

            Return _ListBeProgramas

        Catch ex As Exception
            ' Dim rethrow As Boolean = ExceptionPolicy.HandleException(ex, "ExHandling")
            Throw ex
        End Try

    End Function

    Public Structure s_GridResult
        Dim page As Integer
        Dim total As Integer
        Dim records As Integer
        Dim rows As List(Of Object)
    End Structure

    ''' <summary>
    ''' Registro de Solicitud
    ''' </summary>
    ''' <param name="ApoyoId">ID de Apoyo</param>
    ''' <param name="Observaciones">Observaciones</param>
    ''' <param name="ListTempSolicitud">Lista multidimensional de solicitudes</param>
    ''' <returns>Retorna OKEY si el proceso fue exitos, sino FAIL si existe algun error.</returns>
    ''' <remarks></remarks>
    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function SolicitudRegistrar(ByVal ApoyoId As Integer, ByVal Observaciones As String, ByVal ListTempSolicitud As List(Of String()))

        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()
        Try

            If HttpContext.Current.Session("LoginAuthentications") Is Nothing Then
                objRpta.sesionValida = False
                Return objRpta
            End If

            If ListTempSolicitud IsNot Nothing AndAlso ListTempSolicitud.Count > 0 Then

                Dim dtDataSolicitud As New DataTable()

                Dim colsClaim As Integer = 0
                For Each array In ListTempSolicitud
                    If array.Length > colsClaim Then
                        colsClaim = array.Length
                    End If
                Next

                For i As Integer = 0 To colsClaim - 1
                    dtDataSolicitud.Columns.Add()
                Next

                For Each array In ListTempSolicitud
                    dtDataSolicitud.Rows.Add(array)
                Next

                If dtDataSolicitud IsNot Nothing Then

                    Using _Conec As New SqlConnection(ConfigurationManager.ConnectionStrings("cnFSASGCVU").ToString())

                        Dim Column1 As New DataColumn("Column5", System.Type.[GetType]("System.String"))
                        Column1.AllowDBNull = True
                        Column1.DefaultValue = HttpContext.Current.Session("LoginAuthentications")
                        dtDataSolicitud.Columns.Add(Column1)

                        Dim mapping0 As New SqlBulkCopyColumnMapping("Column1", "ApoyoId")
                        Dim mapping1 As New SqlBulkCopyColumnMapping("Column2", "ProgramasId")
                        Dim mapping2 As New SqlBulkCopyColumnMapping("Column3", "ExpPrograma_MontoSolicitado")
                        Dim mapping3 As New SqlBulkCopyColumnMapping("Column5", "UsuarioCreacion")

                        _Conec.Open()

                        Dim bulkCopy As New SqlBulkCopy(_Conec)

                        bulkCopy.ColumnMappings.Add(mapping0)
                        bulkCopy.ColumnMappings.Add(mapping1)
                        bulkCopy.ColumnMappings.Add(mapping2)
                        bulkCopy.ColumnMappings.Add(mapping3)
                        bulkCopy.DestinationTableName = "Expediente_Programas_TempSolicitud"
                        bulkCopy.WriteToServer(dtDataSolicitud)

                    End Using

                    Dim _BeApoyoMaquina As New BE_ApoyoMaquina

                    With _BeApoyoMaquina
                        .int_ApoyoId = ApoyoId
                        .str_Observacion = Observaciones
                        .str_UsuarioCreacion = HttpContext.Current.Session("LoginAuthentications")
                    End With

                    Dim rpta As String = clsApoyo_Maquina.fn_Insert_SolicitudRegistrar(_BeApoyoMaquina)

                    If rpta <> "OKEY" Then
                        Throw New Exception("Error al registrar solicitud.")
                    End If

                    objRpta.data = rpta

                End If

            End If

        Catch ex As Exception
            objRpta.success = False
            objRpta.msg = String.Format("Message: {0} - StackTrace: {1}", ex.Message, ex.StackTrace)
        End Try

        Return objRpta

    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function AceptarSolicitud(ByVal ApoyoId As Integer, ByVal MaquinaApoyoId As Integer, ByVal Observaciones As String)

        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()
        Try

            If HttpContext.Current.Session("LoginAuthentications") Is Nothing Then
                objRpta.sesionValida = False
                Return objRpta
            End If

            Dim _BeApoyoMaquina As New BE_ApoyoMaquina

            With _BeApoyoMaquina
                .int_ApoyoId = ApoyoId
                .int_MaquinaApoyoId = MaquinaApoyoId
                .str_Observacion = Observaciones
                .str_UsuarioModificacion = HttpContext.Current.Session("LoginAuthentications")
            End With

            Dim rpta As String = clsApoyo_Maquina.fn_Update_ApoyoMaquina_SolicitudAceptada(_BeApoyoMaquina)

            If rpta <> "OKEY" Then
                Throw New Exception("Error al validar solicitud.")
            End If

            objRpta.data = rpta

        Catch ex As Exception
            objRpta.success = False
            objRpta.msg = String.Format("Message: {0} - StackTrace: {1}", ex.Message, ex.StackTrace)
        End Try
        Return objRpta

    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function CancelarSolicitud(ByVal ApoyoId As Integer, ByVal MaquinaApoyoId As Integer, ByVal Observaciones As String, ByVal TipoRespuesta As String)

        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()
        Try

            If HttpContext.Current.Session("LoginAuthentications") Is Nothing Then
                objRpta.sesionValida = False
                Return objRpta
            End If

            Dim _BeApoyoMaquina As New BE_ApoyoMaquina

            With _BeApoyoMaquina
                .int_ApoyoId = ApoyoId
                .int_MaquinaApoyoId = MaquinaApoyoId
                .str_Observacion = Observaciones
                .str_UsuarioModificacion = HttpContext.Current.Session("LoginAuthentications")
                .str_RespuestaTipo = TipoRespuesta
            End With

            Dim rpta As String = clsApoyo_Maquina.fn_Update_ApoyoMaquina_SolicitudCancelada(_BeApoyoMaquina)

            If rpta <> "OKEY" Then
                Throw New Exception("Error al cancelar solicitud.")
            End If

            objRpta.data = rpta

        Catch ex As Exception
            objRpta.success = False
            objRpta.msg = String.Format("Message: {0} - StackTrace: {1}", ex.Message, ex.StackTrace)
        End Try
        Return objRpta

    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function RegistrarClaim(ByVal ApoyoId As Integer, ByVal ListTempClaim As List(Of String()))

        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()
        Try

            If HttpContext.Current.Session("LoginAuthentications") Is Nothing Then
                objRpta.sesionValida = False
                Return objRpta
            End If

            If ListTempClaim IsNot Nothing AndAlso ListTempClaim.Count > 0 Then

                Dim dtDataClaim As New DataTable()

                Dim colsClaim As Integer = 0
                For Each array In ListTempClaim
                    If array.Length > colsClaim Then
                        colsClaim = array.Length
                    End If
                Next

                For i As Integer = 0 To colsClaim - 1
                    dtDataClaim.Columns.Add()
                Next

                For Each array In ListTempClaim
                    dtDataClaim.Rows.Add(array)
                Next

                If dtDataClaim IsNot Nothing Then

                    Using _Conec As New SqlConnection(ConfigurationManager.ConnectionStrings("cnFSASGCVU").ToString())

                        Dim Column1 As New DataColumn("Column5", System.Type.[GetType]("System.String"))
                        Column1.AllowDBNull = True
                        Column1.DefaultValue = HttpContext.Current.Session("LoginAuthentications")
                        dtDataClaim.Columns.Add(Column1)

                        Dim mapping0 As New SqlBulkCopyColumnMapping("Column1", "ApoyoId")
                        Dim mapping1 As New SqlBulkCopyColumnMapping("Column2", "ProgramasId")
                        Dim mapping2 As New SqlBulkCopyColumnMapping("Column3", "ExpPrograma_NumeroClaim")
                        Dim mapping3 As New SqlBulkCopyColumnMapping("Column4", "ExpPrograma_FechaClaim")
                        Dim mapping4 As New SqlBulkCopyColumnMapping("Column5", "UsuarioCreacion")

                        _Conec.Open()

                        Dim bulkCopy As New SqlBulkCopy(_Conec)

                        bulkCopy.ColumnMappings.Add(mapping0)
                        bulkCopy.ColumnMappings.Add(mapping1)
                        bulkCopy.ColumnMappings.Add(mapping2)
                        bulkCopy.ColumnMappings.Add(mapping3)
                        bulkCopy.ColumnMappings.Add(mapping4)
                        bulkCopy.DestinationTableName = "Expediente_Programas_TempClaim"
                        bulkCopy.WriteToServer(dtDataClaim)

                    End Using

                    Dim _beApoyoFlujo As New BE_Apoyo_Flujo

                    With _beApoyoFlujo
                        .int_ApoyoId = ApoyoId
                        .str_UserName = HttpContext.Current.Session("LoginAuthentications")
                    End With

                    Dim rpta As String = clsApoyo_Flujo.fn_Update_ApoyoFlujo_Claim(_beApoyoFlujo)

                    If rpta <> "OKEY" Then
                        Throw New Exception("Error al registrar claim.")
                    End If

                    objRpta.data = rpta

                End If

            End If

        Catch ex As Exception
            objRpta.success = False
            objRpta.msg = String.Format("Message: {0} - StackTrace: {1}", ex.Message, ex.StackTrace)
        End Try

        Return objRpta

    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function RegistrarCreditMemo(ByVal ApoyoId As Integer, ByVal ListTempCreditMemo As List(Of String()))

        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()
        Try

            If HttpContext.Current.Session("LoginAuthentications") Is Nothing Then
                objRpta.sesionValida = False
                Return objRpta
            End If

            If ListTempCreditMemo IsNot Nothing AndAlso ListTempCreditMemo.Count > 0 Then

                Dim dtDataCreditMemo As New DataTable()

                Dim colsClaim As Integer = 0
                For Each array In ListTempCreditMemo
                    If array.Length > colsClaim Then
                        colsClaim = array.Length
                    End If
                Next

                For i As Integer = 0 To colsClaim - 1
                    dtDataCreditMemo.Columns.Add()
                Next

                For Each array In ListTempCreditMemo
                    dtDataCreditMemo.Rows.Add(array)
                Next

                If dtDataCreditMemo IsNot Nothing Then

                    Using _Conec As New SqlConnection(ConfigurationManager.ConnectionStrings("cnFSASGCVU").ToString())

                        Dim Column1 As New DataColumn("Column6", System.Type.[GetType]("System.String"))
                        Column1.AllowDBNull = True
                        Column1.DefaultValue = HttpContext.Current.Session("LoginAuthentications")
                        dtDataCreditMemo.Columns.Add(Column1)

                        Dim mapping0 As New SqlBulkCopyColumnMapping("Column1", "ApoyoId")
                        Dim mapping1 As New SqlBulkCopyColumnMapping("Column2", "ProgramasId")
                        Dim mapping2 As New SqlBulkCopyColumnMapping("Column3", "ExpPrograma_NumeroCreditMemo")
                        Dim mapping3 As New SqlBulkCopyColumnMapping("Column4", "ExpPrograma_FechaCreditMemo")
                        Dim mapping4 As New SqlBulkCopyColumnMapping("Column5", "ExpPrograma_MontoPagado")
                        Dim mapping5 As New SqlBulkCopyColumnMapping("Column6", "UsuarioCreacion")

                        _Conec.Open()

                        Dim bulkCopy As New SqlBulkCopy(_Conec)

                        bulkCopy.ColumnMappings.Add(mapping0)
                        bulkCopy.ColumnMappings.Add(mapping1)
                        bulkCopy.ColumnMappings.Add(mapping2)
                        bulkCopy.ColumnMappings.Add(mapping3)
                        bulkCopy.ColumnMappings.Add(mapping4)
                        bulkCopy.ColumnMappings.Add(mapping5)
                        bulkCopy.DestinationTableName = "Expediente_Programas_TempCreditMemo"
                        bulkCopy.WriteToServer(dtDataCreditMemo)

                    End Using

                    Dim _beApoyoFlujo As New BE_Apoyo_Flujo

                    With _beApoyoFlujo
                        .int_ApoyoId = ApoyoId
                        .str_UserName = HttpContext.Current.Session("LoginAuthentications")
                    End With

                    Dim rpta As String = clsApoyo_Flujo.fn_Update_ApoyoFlujo_CreditMemo(_beApoyoFlujo)

                    If rpta <> "OKEY" Then
                        Throw New Exception("Error al registrar credit memo.")
                    End If

                    objRpta.data = rpta

                End If

            End If

        Catch ex As Exception
            objRpta.success = False
            objRpta.msg = String.Format("Message: {0} - StackTrace: {1}", ex.Message, ex.StackTrace)
        End Try

        Return objRpta

    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function RegresarActividad(ByVal ApoyoId As Integer, ByVal MaquinaApoyoId As Integer)

        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()
        Try

            If HttpContext.Current.Session("LoginAuthentications") Is Nothing Then
                objRpta.sesionValida = False
                Return objRpta
            End If

            Dim _beApoyoFlujo As New BE_Apoyo_Flujo

            With _beApoyoFlujo
                .int_ApoyoId = ApoyoId
                .int_MaquinaApoyoId = MaquinaApoyoId
                .str_UserName = HttpContext.Current.Session("LoginAuthentications")
            End With

            Dim rpta As String = clsApoyo_Flujo.fn_Update_ApoyoFlujo_RegresarActividad(_beApoyoFlujo)

            If rpta <> "OKEY" Then
                Throw New Exception("Error al regresar actividad anterior.")
            End If

            objRpta.data = rpta

        Catch ex As Exception
            objRpta.success = False
            objRpta.msg = String.Format("Message: {0} - StackTrace: {1}", ex.Message, ex.StackTrace)
        End Try

        Return objRpta


    End Function

    Protected Sub bntSaveWashout_Click(ByVal sender As Object, ByVal e As EventArgs) Handles bntSaveWashout.Click

        Dim _strAnswer As String = String.Empty
        Dim _beApoyoFlujo As New BE_Apoyo_Flujo
        Dim flupdWashoutFile As FileUpload = CType(flUplWashout, FileUpload)
        Dim _LiBeApoyoFlujo As List(Of BE_Apoyo_Flujo) = CType(Session.Item("ListApoyoFlujoSession"), List(Of BE_Apoyo_Flujo))

        If _LiBeApoyoFlujo IsNot Nothing AndAlso _LiBeApoyoFlujo.Count > 0 Then

            If flupdWashoutFile.HasFile AndAlso Not flupdWashoutFile.PostedFile Is Nothing Then

                Dim strExtension As String = Path.GetExtension(flUplWashout.PostedFile.FileName)

                If (strExtension = ".doc") OrElse (strExtension = ".docx") OrElse (strExtension = ".xls") OrElse (strExtension = ".xlsx") OrElse (strExtension = ".pdf") Then
                    Dim File As HttpPostedFile = flupdWashoutFile.PostedFile
                    Dim byte_WashoutFileNew As Byte() = Nothing
                    byte_WashoutFileNew = New Byte(File.ContentLength - 1) {}
                    File.InputStream.Read(byte_WashoutFileNew, 0, File.ContentLength)
                    _beApoyoFlujo.str_WashoutArchivo = Path.GetFileName(flupdWashoutFile.PostedFile.FileName)
                    _beApoyoFlujo.byte_Washout = byte_WashoutFileNew
                Else
                    ScriptManager.RegisterStartupScript(Me, [GetType](), "showalert", "alert('Advertencia: Verificar datos ingresados.' + '\n' + 'Extensión de archivo Washout no es valida.');", True)
                End If
            Else
                _beApoyoFlujo.str_WashoutArchivo = _LiBeApoyoFlujo(0).str_WashoutArchivo
                _beApoyoFlujo.byte_Washout = _LiBeApoyoFlujo(0).byte_Washout
            End If

            If _beApoyoFlujo.str_WashoutArchivo <> String.Empty And _beApoyoFlujo.byte_Washout IsNot Nothing Then

                If rbtnProvisional.Checked = True Then
                    _beApoyoFlujo.str_WashoutEstado = 26
                ElseIf rbtnDefinitivo.Checked = True Then
                    _beApoyoFlujo.str_WashoutEstado = 27
                Else
                    _beApoyoFlujo.str_WashoutEstado = 25
                End If

                _beApoyoFlujo.int_ApoyoId = _LiBeApoyoFlujo(0).int_ApoyoId
                _beApoyoFlujo.str_UserName = HttpContext.Current.Session("LoginAuthentications")

                _strAnswer = clsApoyo_Flujo.fn_Update_ApoyoFlujo_Washout(_beApoyoFlujo)

            Else
                ScriptManager.RegisterStartupScript(Me, [GetType](), "showalert", "alert('Advertencia: Verificar datos obligatorios.' + '\n' + 'Debe de adjuntar archivo Washout a la solicitud.');", True)
            End If
        End If

    End Sub

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function RegistrarComentario(ByVal ApoyoId As Integer, ByVal Comentarios As String, ByVal TypeTrans As String)

        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()
        Try

            If HttpContext.Current.Session("LoginAuthentications") Is Nothing Then
                objRpta.sesionValida = False
                Return objRpta
            End If

            Dim strTypeTrans As String = TypeTrans

            Dim _BeApoyoMaquina As New BE_ApoyoMaquina

            With _BeApoyoMaquina
                .int_ApoyoId = ApoyoId
                .str_Observacion = Comentarios
                .str_UsuarioCreacion = HttpContext.Current.Session("LoginAuthentications")
            End With

            Dim rpta As String = clsApoyo_Maquina.fn_Insert_ExpedienteComentario(_BeApoyoMaquina)

            If rpta <> "OKEY" Then
                Throw New Exception("Error al grabar comentarios.")
            End If

            objRpta.data = rpta

        Catch ex As Exception
            objRpta.success = False
            objRpta.msg = String.Format("Message: {0} - StackTrace: {1}", ex.Message, ex.StackTrace)
        End Try
        Return objRpta

    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function GetData_ExpedienteComentarios_ByKey(ByVal ApoyoId As Integer)

        Dim rpta As DTO_RptaPeticion = New DTO_RptaPeticion()

        Try

            Dim _ListBe As New List(Of BE_Expediente_Comentarios)
            Dim _List = New List(Of Object)
            Dim _Be As New BE_Expediente_Comentarios

            _Be.int_ApoyoId = ApoyoId
            _ListBe = clsApoyo_Maquina.fn_Select_ExpedienteComentario_ByApoyo(_Be)

            If _ListBe IsNot Nothing AndAlso _ListBe.Count > 0 Then
                For Each item In _ListBe
                    _List.Add(New With {
                                   Key .int_ApoyoId = item.int_ApoyoId,
                                       .str_Observacion = item.str_Observacion,
                                       .det_FechaCreacion = item.det_FechaCreacion,
                                       .str_UsuarioCreacion = item.str_UsuarioCreacion,
                                       .det_FechaModificacion = item.det_FechaModificacion,
                                       .str_UsuarioModificacion = item.str_UsuarioModificacion
                                    })
                Next item

            End If

            rpta.data = _List

        Catch ex As Exception
            rpta.success = False
            rpta.msg = String.Format("Message: {0} - StackTrace: {1}", ex.Message, ex.StackTrace)
        End Try

        Return rpta
    End Function

End Class

