Imports SGCVU.BE
Imports SGCVU.BL
Imports System.Reflection
Imports System.Globalization
Imports SGCVU.DTO
Imports System.Web.Security
Imports System.String
Imports SGCVU.WS
Imports SGCVU.EX

Public Class frmWorkflow_ReservaUnidades
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function ObtenerDatosIniciales()
        'Threading.Thread.Sleep(2000)
        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()
        Try
            Dim liBEMasterTable As New List(Of BE_Master_Table)
            Dim BeMasterTable As New BE_Master_Table With {.str_MasterTable_Key = "StateMachine"}
            liBEMasterTable = clsMaster_Table.fn_Select_MasterTable_ByKey(BeMasterTable)
            liBEMasterTable.RemoveAll(Function(x) x.str_MasterTable_Valor = "N")

            Dim liEstados = New List(Of Object)
            For Each item In liBEMasterTable
                liEstados.Add(New With {Key .id = item.str_MasterTable_Valor, .desc = item.str_MasterTable_Descripcion})
            Next item

            Dim loginUsuario As String = HttpContext.Current.Session("LoginAuthentications")
            Dim liDTOConfiguracionColumnasUsuario = clsConfiguracion_Columnas_Usuario.fn_Select_Configuracion_Columnas_Usuario_Activas("InventarioMaquina", loginUsuario)

            objRpta.data = New With {Key .estados = liEstados, .columnas = liDTOConfiguracionColumnasUsuario}
        Catch ex As Exception
            objRpta.success = False
            objRpta.msg = String.Format("Message: {0} - StackTrace: {1}", ex.Message, ex.StackTrace)
        End Try
        Return objRpta
    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function ObtenerCuentasFiltro()
        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()
        Try
            If HttpContext.Current.Session("LoginAuthentications") Is Nothing Then
                objRpta.sesionValida = False
                Return objRpta
            End If

            Dim loginUsuario As String = HttpContext.Current.Session("LoginAuthentications")
            Dim liCuentas = clsMaquina.fn_Select_Cuenta_Usuario(loginUsuario)

            objRpta.data = liCuentas
        Catch ex As Exception
            objRpta.success = False
            objRpta.msg = String.Format("Message: {0} - StackTrace: {1}", ex.Message, ex.StackTrace)
        End Try
        Return objRpta
    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function ObtenerModelosFiltro()
        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()
        Try
            If HttpContext.Current.Session("LoginAuthentications") Is Nothing Then
                objRpta.sesionValida = False
                Return objRpta
            End If

            Dim liModelos = New List(Of Object)
            liModelos.Add(New With {Key .id = "12.5CV", .desc = "12.5CV"})
            liModelos.Add(New With {Key .id = "120K", .desc = "120K"})
            liModelos.Add(New With {Key .id = "12K", .desc = "12K"})
            liModelos.Add(New With {Key .id = "140K", .desc = "140K"})
            liModelos.Add(New With {Key .id = "140M", .desc = "140M"})
            liModelos.Add(New With {Key .id = "160K", .desc = "160K"})
            liModelos.Add(New With {Key .id = "160M", .desc = "160M"})
            liModelos.Add(New With {Key .id = "18DB", .desc = "18DB"})
            liModelos.Add(New With {Key .id = "246D", .desc = "246D"})
            liModelos.Add(New With {Key .id = "24M", .desc = "24M"})
            liModelos.Add(New With {Key .id = "2615/4", .desc = "2615/4"})
            liModelos.Add(New With {Key .id = "2625/2", .desc = "2625/2"})
            liModelos.Add(New With {Key .id = "2635/4", .desc = "2635/4"})
            liModelos.Add(New With {Key .id = "2640/4", .desc = "2640/4"})
            liModelos.Add(New With {Key .id = "290/4S", .desc = "290/4S"})
            liModelos.Add(New With {Key .id = "291/4 BR", .desc = "291/4 BR"})
            liModelos.Add(New With {Key .id = "292/4RM", .desc = "292/4RM"})

            objRpta.data = liModelos
        Catch ex As Exception
            objRpta.success = False
            objRpta.msg = String.Format("Message: {0} - StackTrace: {1}", ex.Message, ex.StackTrace)
        End Try
        Return objRpta
    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function ObtenerUbicacionesFiltro()
        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()
        Try
            If HttpContext.Current.Session("LoginAuthentications") Is Nothing Then
                objRpta.sesionValida = False
                Return objRpta
            End If

            Dim liUbicaciones = clsMaquina.fn_Select_Ubicacion_Maquina()

            objRpta.data = liUbicaciones
        Catch ex As Exception
            objRpta.success = False
            objRpta.msg = String.Format("Message: {0} - StackTrace: {1}", ex.Message, ex.StackTrace)
        End Try
        Return objRpta
    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function ObtenerMaquinas(ByVal page As Integer, ByVal rows As Integer, ByVal sidx As String, ByVal sord As String, ByVal filtro As DTO_Filtro_Maquina_Inventario)
        Dim sesionValida = True
        Try
            If HttpContext.Current.Session("LoginAuthentications") Is Nothing Then
                sesionValida = False
                Throw New Exception("La sesion ha expirado. Presione <b>F5</b> para volver a iniciar sesión.")
            End If

            Dim liDTOConsultaInventarioMaquina As New List(Of DTO_Consulta_Inventario_Maquina)
            Dim loginUsuario As String = HttpContext.Current.Session("LoginAuthentications")

            filtro.sb_prepararDatos()

            Dim total As Integer = 0

            liDTOConsultaInventarioMaquina = clsMaquina.fn_Select_Maquina_Consulta_Inventario(total, page, rows, filtro, loginUsuario)

            Dim sgResult As Object = New With {Key .rows = liDTOConsultaInventarioMaquina,
                                               .page = page,
                                               .total = Math.Ceiling(total / Convert.ToDecimal(rows)),
                                               .records = total
                                              }

            Return sgResult
        Catch ex As Exception
            If sesionValida Then
                Throw New Exception(String.Format("Message: {0} - StackTrace: {1}", ex.Message, ex.StackTrace))
            Else
                Throw ex
            End If
        End Try
    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function ObtenerMaquinasRelacionadasGridPrincipal(ByVal orden As String)
        Dim sesionValida = True
        Try
            If HttpContext.Current.Session("LoginAuthentications") Is Nothing Then
                sesionValida = False
                Throw New Exception("La sesion ha expirado. Presione <b>F5</b> para volver a iniciar sesión.")
            End If

            Dim liDTOConsultaInventarioMaquina As New List(Of DTO_Consulta_Inventario_Maquina)
            Dim liMaquinas = New List(Of Object)

            liDTOConsultaInventarioMaquina = clsMaquina.fn_Select_Maquina_Relacionadas(orden)

            For Each item In liDTOConsultaInventarioMaquina
                liMaquinas.Add(New With {
                               Key .str_OrdenAsignada = item.OrdenAsignada,
                                   .str_ModeloProductoDesc = item.ModeloProductoDesc,
                                   .int_Semaforo = item.Semaforo,
                                   .str_UbicacionDesc = item.UbicacionDesc
                                })
            Next item

            Dim sgResult As Object = New With {Key .rows = liMaquinas,
                                               .page = 0,
                                               .total = 0,
                                               .records = 0
                                              }

            Return sgResult
        Catch ex As Exception
            If sesionValida Then
                Throw New Exception(String.Format("Message: {0} - StackTrace: {1}", ex.Message, ex.StackTrace))
            Else
                Throw ex
            End If
        End Try
    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function ObtenerMaquinasPorModelo(ByVal modelo As String, ByVal orden As String)
        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()
        Try
            If HttpContext.Current.Session("LoginAuthentications") Is Nothing Then
                objRpta.sesionValida = False
                Return objRpta
            End If

            Dim liMaquinas = New List(Of Object)
            Dim liBEMaquinas = New List(Of BE_Maquina)

            liBEMaquinas = clsMaquina.fn_Select_Maquina_Modelo_Emparejamiento(modelo, orden)
            For Each item In liBEMaquinas
                liMaquinas.Add(New With {Key .orden = item.str_OrdenAsignada, .modelo = item.str_ModeloProductoDesc, .antiguamientoMaquina = item.int_AntiguamientoMaquina})
            Next item

            objRpta.data = liMaquinas
        Catch ex As Exception
            objRpta.success = False
            objRpta.msg = String.Format("Message: {0} - StackTrace: {1}", ex.Message, ex.StackTrace)
        End Try
        Return objRpta
    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function ObtenerDatosMaquinaModificacion(ByVal orden As String)
        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()
        Try
            If HttpContext.Current.Session("LoginAuthentications") Is Nothing Then
                objRpta.sesionValida = False
                Return objRpta
            End If

            Dim liMaquinas = New List(Of Object)
            Dim liDTOConsultaInventarioMaquina As New List(Of DTO_Consulta_Inventario_Maquina)

            Dim BEMaquina As BE_Maquina = Nothing
            Dim objDatos = New With {Key .version = "", .proyecto = "", .observaciones = "", .estadoMaquina = "", .liMaquinas = liMaquinas}

            BEMaquina = clsMaquina.fn_Select_Maquina_Modificacion_Inventario(orden)
            If BEMaquina IsNot Nothing Then
                liDTOConsultaInventarioMaquina = clsMaquina.fn_Select_Maquina_Relacionadas(orden)
                For Each item In liDTOConsultaInventarioMaquina
                    liMaquinas.Add(New With {Key .orden = item.OrdenAsignada, .modelo = item.ModeloProductoDesc})
                Next item

                objDatos = New With {Key .version = BEMaquina.str_Version, .proyecto = BEMaquina.str_Proyecto, .observaciones = BEMaquina.str_Observaciones, .estadoMaquina = BEMaquina.str_EstadoMaquina, .liMaquinas = liMaquinas}
            End If

            objRpta.data = objDatos
        Catch ex As Exception
            objRpta.success = False
            objRpta.msg = String.Format("Message: {0} - StackTrace: {1}", ex.Message, ex.StackTrace)
        End Try
        Return objRpta
    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function ObtenerDatosMaquinaCabecera(ByVal orden As String)
        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()
        Try
            If HttpContext.Current.Session("LoginAuthentications") Is Nothing Then
                objRpta.sesionValida = False
                Return objRpta
            End If

            Dim infoMaquinaCabecera As DTO_InfoMaquinaCabecera = Nothing
            Dim liNegociaciones = New List(Of DTO_Reserva)

            infoMaquinaCabecera = clsMaquina.fn_Select_InformacionMaquinaCabecera(orden)

            If infoMaquinaCabecera IsNot Nothing Then
                liNegociaciones = clsReserva.fn_Select_Historial_Reserva(orden, "")
            End If

            objRpta.data = New With {Key .infoMaquinaCabecera = infoMaquinaCabecera, .liNegociaciones = liNegociaciones}
        Catch ex As Exception
            objRpta.success = False
            objRpta.msg = String.Format("Message: {0} - StackTrace: {1}", ex.Message, ex.StackTrace)
        End Try
        Return objRpta
    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function ObtenerDatosMaquinaSeguimientoImportacion(ByVal orden As String)
        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()
        Try
            If HttpContext.Current.Session("LoginAuthentications") Is Nothing Then
                objRpta.sesionValida = False
                Return objRpta
            End If

            Dim infoSeguimientoImportacion As DTO_InfoMaquinaSeguimientoImportacion = clsMaquina.fn_Select_InformacionMaquinaSeguimientoImportacion(orden)

            objRpta.data = infoSeguimientoImportacion
        Catch ex As Exception
            objRpta.success = False
            objRpta.msg = String.Format("Message: {0} - StackTrace: {1}", ex.Message, ex.StackTrace)
        End Try
        Return objRpta
    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function ObtenerDatosMaquinaInformacionInventario(ByVal orden As String)
        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()
        Try
            If HttpContext.Current.Session("LoginAuthentications") Is Nothing Then
                objRpta.sesionValida = False
                Return objRpta
            End If

            Dim infoInventario As DTO_InfoMaquinaInventario = clsMaquina.fn_Select_InformacionMaquinaInfoInventario(orden)

            objRpta.data = infoInventario
        Catch ex As Exception
            objRpta.success = False
            objRpta.msg = String.Format("Message: {0} - StackTrace: {1}", ex.Message, ex.StackTrace)
        End Try
        Return objRpta
    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function ObtenerDatosMaquinaDatosTecnicos(ByVal orden As String)
        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()
        Try
            If HttpContext.Current.Session("LoginAuthentications") Is Nothing Then
                objRpta.sesionValida = False
                Return objRpta
            End If

            Dim datosTecnicos As DTO_InfoMaquinaDatosTecnicos = clsMaquina.fn_Select_InformacionMaquinaDatosTecnicos(orden)

            objRpta.data = datosTecnicos
        Catch ex As Exception
            objRpta.success = False
            objRpta.msg = String.Format("Message: {0} - StackTrace: {1}", ex.Message, ex.StackTrace)
        End Try
        Return objRpta
    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function ObtenerDatosMaquinaConfiguracionUnidad(ByVal orden As String)
        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()
        Try
            If HttpContext.Current.Session("LoginAuthentications") Is Nothing Then
                objRpta.sesionValida = False
                Return objRpta
            End If

            Dim configuracionUnidad = clsMaquina.fn_Select_InformacionMaquinaConfiguracionUnidad(orden)

            objRpta.data = configuracionUnidad
        Catch ex As Exception
            objRpta.success = False
            objRpta.msg = String.Format("Message: {0} - StackTrace: {1}", ex.Message, ex.StackTrace)
        End Try
        Return objRpta
    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function ObtenerNegociacionesMaquina(ByVal orden As String)
        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()
        Try
            Dim liNegociaciones = New List(Of DTO_Reserva)

            liNegociaciones = clsReserva.fn_Select_Historial_Reserva(orden, "")

            objRpta.data = liNegociaciones
        Catch ex As Exception
            objRpta.success = False
            objRpta.msg = String.Format("Message: {0} - StackTrace: {1}", ex.Message, ex.StackTrace)
        End Try
        Return objRpta
    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function ModificarMaquina(ByVal orden As String, ByVal version As String, ByVal proyecto As String, ByVal observaciones As String, ByVal maquinasEmparejamiento As List(Of String))
        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()
        Try
            If HttpContext.Current.Session("LoginAuthentications") Is Nothing Then
                objRpta.sesionValida = False
                Return objRpta
            End If

            Dim BEMaquina As BE_Maquina = New BE_Maquina()

            With BEMaquina
                .str_OrdenAsignada = orden
                .str_Version = version
                .str_Proyecto = proyecto
                .str_Observaciones = observaciones
            End With

            Dim rpta As String = clsMaquina.fn_Update_Maquina_Inventario(BEMaquina, maquinasEmparejamiento)

            If rpta <> "1" Then
                Throw New Exception("Error al ejecutar el procedimiento.")
            End If

            objRpta.data = rpta
        Catch ex As Exception
            objRpta.success = False
            objRpta.msg = cmpExcepcion.AdministrarExcepcion(ex, Modulo.InventarioComercial, HttpContext.Current.Session("LoginAuthentications"), HttpContext.Current.Session("IPAuthentications"), HttpContext.Current.Session("MacAuthentications"))
        End Try
        Return objRpta
    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function SolicitarLevante(ByVal maquinas As List(Of String))
        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()
        Try
            Dim loginUsuario As String = HttpContext.Current.Session("LoginAuthentications")
            If loginUsuario Is Nothing Then
                objRpta.sesionValida = False
                Return objRpta
            End If

            Dim cmpMaquinaInventario As cmpMaquinaInventario = New cmpMaquinaInventario(loginUsuario, maquinas)
            cmpMaquinaInventario.SolicitarLevante()

            objRpta.data = "1"
        Catch ex As Exception
            objRpta.success = False
            objRpta.msg = String.Format("Message: {0} - StackTrace: {1}", ex.Message, ex.StackTrace)
        End Try
        Return objRpta
    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function ObtenerDatosNuevaReserva(ByVal orden As String)
        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()
        Try
            If HttpContext.Current.Session("LoginAuthentications") Is Nothing Then
                objRpta.sesionValida = False
                Return objRpta
            End If

            Dim objReserva = New DTO_Reserva()

            Dim diasReserva = clsLineaVentaMaestro.fn_Select_DiasReserva_LineaVenta_Maquina(orden)

            Dim BEMaquina = clsMaquina.fn_Select_Maquina_Orden(orden)

            With objReserva
                .nroNegociacion = 0
                .estadoNegociacion = "1"
                .fechaNegociacion = Date.Now
                .fechaLimiteReserva = Date.Now.AddDays(diasReserva)
                .fechaEstimadaIngreso = BEMaquina.det_IngresoFisicoFESAEstimadaFecha
                .fechaOfrecidaCliente = BEMaquina.det_OfrecidaClienteFecha
            End With

            objRpta.data = objReserva
        Catch ex As Exception
            objRpta.success = False
            objRpta.msg = String.Format("Message: {0} - StackTrace: {1}", ex.Message, ex.StackTrace)
        End Try
        Return objRpta
    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function GuardarReserva(ByVal reserva As DTO_Reserva)
        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()
        Try
            Dim loginUsuario As String = HttpContext.Current.Session("LoginAuthentications")
            If loginUsuario Is Nothing Then
                objRpta.sesionValida = False
                Return objRpta
            End If

            Dim BEMaquina As BE_Maquina = clsMaquina.fn_Select_Maquina_Orden(reserva.ordenAsignada)
            Dim maquinaAsignada As Boolean = False

            If BEMaquina IsNot Nothing Then
                If BEMaquina.str_EstadoMaquina = "A" Then
                    maquinaAsignada = True
                Else
                    Dim cmpConsultarRda As cmpConsultarRDA = New cmpConsultarRDA()
                    Dim rda As ZRda = cmpConsultarRda.ObtenerRDAAsignadoOrden(reserva.ordenAsignada)

                    If rda IsNot Nothing Then
                        maquinaAsignada = True

                        Dim cmpAdmZRDA As cmpAdministradorZRDA = New cmpAdministradorZRDA(rda)
                        Dim idTemp As Integer = cmpAdmZRDA.RegistrarRDAEnTemporal()

                        If idTemp <> 0 Then
                            Dim cmpAdmZRDATemp As cmpAdministradorZRDATemp = New cmpAdministradorZRDATemp(idTemp)
                            cmpAdmZRDATemp.ActualizarDatosTempRDA_Maquina()
                        End If
                    Else
                        Dim cmpReserva As cmpReserva = New cmpReserva(reserva, loginUsuario)
                        cmpReserva.IngresarReserva()
                    End If
                End If
            Else
                Throw New Exception(String.Format("No existe una Máquina con el número de Orden: {0}", reserva.ordenAsignada))
            End If

            objRpta.data = New With {Key .asignada = maquinaAsignada}
        Catch ex As Exception
            objRpta.success = False
            objRpta.msg = String.Format("Message: {0} - StackTrace: {1}", ex.Message, ex.StackTrace)
        End Try
        Return objRpta
    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function ObtenerDatosReserva(ByVal reservaId As Integer)
        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()
        Try
            If HttpContext.Current.Session("LoginAuthentications") Is Nothing Then
                objRpta.sesionValida = False
                Return objRpta
            End If

            Dim DTOReserva = clsReserva.fn_Select_Reserva(reservaId)

            If DTOReserva IsNot Nothing Then
                Dim BEMaquina = clsMaquina.fn_Select_Maquina_Orden(DTOReserva.ordenAsignada)

                With DTOReserva
                    .fechaEstimadaIngreso = BEMaquina.det_IngresoFisicoFESAEstimadaFecha
                    .fechaOfrecidaCliente = BEMaquina.det_OfrecidaClienteFecha
                End With
            End If

            objRpta.data = DTOReserva
        Catch ex As Exception
            objRpta.success = False
            objRpta.msg = String.Format("Message: {0} - StackTrace: {1}", ex.Message, ex.StackTrace)
        End Try
        Return objRpta
    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function ModificarReserva(ByVal reserva As DTO_Reserva)
        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()
        Try
            If HttpContext.Current.Session("LoginAuthentications") Is Nothing Then
                objRpta.sesionValida = False
                Return objRpta
            End If

            Dim BEReserva = New BE_Reserva()

            Dim loginUsuario As String = HttpContext.Current.Session("LoginAuthentications")

            With BEReserva
                .int_ReservaId = reserva.nroNegociacion
                .det_ValidezReservaFecha = reserva.fechaLimiteReserva
                .str_Observaciones = reserva.observaciones
                .str_UsuarioModificacion = loginUsuario
            End With

            Dim rpta = clsReserva.fn_Update_Reserva(BEReserva)

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
    Public Shared Function AnularReservas(ByVal ordenes As List(Of String))
        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()
        Try
            Dim loginUsuario As String = HttpContext.Current.Session("LoginAuthentications")
            If loginUsuario Is Nothing Then
                objRpta.sesionValida = False
                Return objRpta
            End If

            Dim cmpReserva As cmpReserva = New cmpReserva(ordenes, loginUsuario)
            cmpReserva.AnularReservas()

            objRpta.data = "1"
        Catch ex As Exception
            objRpta.success = False
            objRpta.msg = String.Format("Message: {0} - StackTrace: {1}", ex.Message, ex.StackTrace)
        End Try
        Return objRpta
    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function ObtenerClientes(ByVal codigo As String, ByVal descripcion As String, ByVal page As Integer, ByVal rows As Integer)
        Dim sesionValida = True
        Try
            If HttpContext.Current.Session("LoginAuthentications") Is Nothing Then
                sesionValida = False
                Throw New Exception("La sesion ha expirado. Presione <b>F5</b> para volver a iniciar sesión.")
            End If

            Dim total = 0
            Dim liClientes As List(Of DTO_Cliente_Busqueda) = clsDimCliente.fn_Select_Cliente_Paginado_Total(total, page, rows, codigo, descripcion)

            Dim sgResult As Object = New With {Key .rows = liClientes,
                                               .page = page,
                                               .total = Math.Ceiling(total / Convert.ToDecimal(rows)),
                                               .records = total
                                              }
            Return sgResult
        Catch ex As Exception
            If sesionValida Then
                Throw New Exception(String.Format("Message: {0} - StackTrace: {1}", ex.Message, ex.StackTrace))
            Else
                Throw ex
            End If
        End Try
    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function ObtenerVendedores(ByVal codigo As String, ByVal descripcion As String, ByVal page As Integer, ByVal rows As Integer)
        Dim sesionValida = True
        Try
            If HttpContext.Current.Session("LoginAuthentications") Is Nothing Then
                sesionValida = False
                Throw New Exception("La sesion ha expirado. Presione <b>F5</b> para volver a iniciar sesión.")
            End If

            Dim liVendedores As List(Of DTO_Vendedor) = cmpUsuario.fn_Buscar_Usuario(codigo, descripcion, 0, 0)
            Dim liVendedoresFinal = liVendedores.Skip((page - 1) * rows).Take(rows)

            Dim sgResult As Object = New With {Key .rows = liVendedoresFinal,
                                               .page = page,
                                               .total = Math.Ceiling(liVendedores.Count / Convert.ToDecimal(rows)),
                                               .records = liVendedores.Count
                                              }
            Return sgResult
        Catch ex As Exception
            If sesionValida Then
                Throw New Exception(String.Format("Message: {0} - StackTrace: {1}", ex.Message, ex.StackTrace))
            Else
                Throw ex
            End If
        End Try
    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function ObtenerDatosOportunidad(ByVal oportunidad As String)
        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()
        Try
            If HttpContext.Current.Session("LoginAuthentications") Is Nothing Then
                objRpta.sesionValida = False
                Return objRpta
            End If

            Dim consultarCRM = New cmpConsultarCRM()
            Dim dataOportunidad = consultarCRM.ObtenerDatosOportunidad(oportunidad)

            objRpta.data = dataOportunidad
        Catch ex As Exception
            objRpta.success = False
            objRpta.msg = cmpExcepcion.AdministrarExcepcion(ex, Modulo.InventarioComercial, HttpContext.Current.Session("LoginAuthentications"), HttpContext.Current.Session("IPAuthentications"), HttpContext.Current.Session("MacAuthentications"))
        End Try
        Return objRpta
    End Function

End Class