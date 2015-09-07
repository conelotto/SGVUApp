Imports SGCVU.BE
Imports System.Configuration
Imports System.String
Imports SGCVU.DA
Imports System.Dynamic
Imports SGCVU.DTO

Public Class clsMaquina

    'Public Shared Function fn_Select_Maquina_DB2(ByVal pi_pagina As Integer, ByVal pi_CantidadRegistros As Integer, ByVal pi_objFiltro As FiltroConsultaReserva) As List(Of BE_Maquina)
    '   Try
    '      Dim strLibro As String = ConfigurationManager.AppSettings("cnLIBR08").ToString

    '      If ConfigurationManager.AppSettings("EnviaCorreo").ToString = "Test" Then
    '         strLibro = "LIBT99"
    '      ElseIf ConfigurationManager.AppSettings("EnviaCorreo").ToString = "TestQA" Then
    '         strLibro = "LIBT99"
    '      End If

    '      Dim objArrParametros(,) As Object = {{}}

    '      Dim liBEMaquina As New List(Of BE_Maquina)

    '      Dim strConsulta As String = Concat("SELECT   ROW_NUMBER() OVER () AS ROWNUM", _
    '                                                   ",'02' AS CompaniaId", _
    '                                                   ",TRIM(A.IDNO1) AS OrdenAsignada", _
    '                                                   ",'' AS EstadoRDA", _
    '                                                   ",(SELECT CURRENT DATE FROM sysibm.sysdummy1) AS EstadoRDAFecha", _
    '                                                   ",'' AS ModeloRDA", _
    '                                                   ",CASE WHEN A.INVI IN ('S','Y') THEN A.LCUNO ELSE A.CUNO END AS CuentaInventarioDBS", _
    '                                                   ",A.RDMCD AS MarcaId", _
    '                                                   ",TRIM(MAR.DS4) AS MarcaDesc", _
    '                                                   ",A.EQMFM2 AS ModeloProductoId", _
    '                                                   ",TRIM(MO.DS8) AS ModeloProductoDesc", _
    '                                                   ",A.EQMFS2 AS SerieMaquina", _
    '                                                   ",CASE WHEN A.INVI IN ('S','Y') THEN A.CUNO ELSE A.LCUNO END AS ClienteId", _
    '                                                   ",SEG.FECORD AS OrdenFabricaFecha", _
    '                                                   ",SEG.FECPROM AS SalidaFabricaEstimadaFecha", _
    '                                                   ",SEG.EXFAB AS SalidaFabricaFecha", _
    '                                                   ",SEG.RECEFW AS RecepcionForwarderFecha", _
    '                                                   ",SEG.FECFAC AS FacturaFabricaFecha", _
    '                                                   ",SEG.MONFAC AS FacturaImporte", _
    '                                                   ",SEG.PTO AS PuertoSalidaDesc", _
    '                                                   ",'' AS BillOfLanding", _
    '                                                   ",SEG.BUQUE AS BuqueDesc", _
    '                                                   ",SEG.EXPUE AS EmbarqueEstimadaFecha", _
    '                                                   ",SEG.ETAPU AS ArriboPuertoEstimadaFecha", _
    '                                                   ",SEG.LLEGA AS ArriboPuertoFecha", _
    '                                                   ",SEG.DESCA AS FinDescargaFecha", _
    '                                                   ",SEG.LEVAN AS LevanteAduaneroFecha", _
    '                                                   ",SEG.SAMG AS IngresoFisicoFESAFecha", _
    '                                                   ",'' AS Observaciones", _
    '                                                   ",0 AS Semaforo", _
    '                                                   ",A.LOC1 AS UbicacionId", _
    '                                                   ",'' AS StoreId", _
    '                                                   ",0 AS CostoMaquinaUSS", _
    '                                                   ",A.YM AS AnoFabricacionMaquina", _
    '                                                   ",0 AS AntiguamientoMaquina", _
    '                                                   ",'' AS RegimenImportacionMaquina", _
    '                                                   ",'' AS AgenteId", _
    '                                                   ",'' AS AgenteDesc", _
    '                                                   ",A.INVI AS EstadoInventario", _
    '                                                   "", _
    '                                                   ",'' AS CentroCostoId", _
    '                                                   ",'' AS ContratoNum", _
    '                                                   ",'' AS IncotermId", _
    '                                                   ",'' AS PuertoEntradaDesc", _
    '                                                   ",(SELECT CURRENT DATE FROM sysibm.sysdummy1) AS EntregaTallerFecha", _
    '                                                   ",'' AS UbicacionDesc", _
    '                                                   ",'' AS FacturaFabricaNum", _
    '                                                   ",(SELECT CURRENT DATE FROM sysibm.sysdummy1) AS SalidaFecha", _
    '                                                   ",'' AS UbicacionAgrupacionDesc", _
    '                                                   ",'' AS FamiliaDesc", _
    '                                                   ",'' AS MotorSerie", _
    '                                                   ",(SELECT CURRENT DATE FROM sysibm.sysdummy1) AS FacturaClienteFecha", _
    '                                                   ",(SELECT CURRENT DATE FROM sysibm.sysdummy1) AS IngresoFisicoFESAEstimadaFecha", _
    '                                                   ",(SELECT CURRENT DATE FROM sysibm.sysdummy1) AS DisponibilidadEstimadaFecha", _
    '                                                   ",(SELECT CURRENT DATE FROM sysibm.sysdummy1) AS DisponibilidadFecha", _
    '                                                   ",0 AS ValorVentaMaquinaCRM", _
    '                                                   ",'' AS VendedorId", _
    '                                                   ",'' AS ClienteFacturaId", _
    '                                                   ",(SELECT CURRENT DATE FROM sysibm.sysdummy1) AS AsignacionFecha", _
    '                                                   ",'' AS EntidadFinancieraId", _
    '                                                   ",'' AS FinanciamientoId", _
    '                                                   ",'' AS FinanciamientoDesc", _
    '                                                   ",(SELECT CURRENT DATE FROM sysibm.sysdummy1) AS PreEntregaEstimadaFecha", _
    '                                                   ",'' AS PedidoId", _
    '                                                   ",'' AS OficinaVentaFacturaCRMId", _
    '                                                   ",'' AS OficinaVentaFacturaCRMDesc", _
    '                                                   ",'' AS OportunidadNum", _
    '                                                   ",'' AS ApoyoFabricanteIndicador", _
    '                                                   ",'' AS EliminadoRDA", _
    '                                                   ",0 AS PosicionId", _
    '                                                   ",'' AS OrdenAsignadaNumCRM ", _
    '                                          "FROM	   ", strLibro, ".EMPEQPD0 A ", _
    '                                                   "FULL JOIN ", strLibro, ".UMPEMSSEG SEG ON TRIM(SEG.ORDEN) = TRIM(A.IDNO1) ", _
    '                                                   "LEFT OUTER JOIN ", strLibro, ".SCPCODE0 MAR ON MAR.KEYDA1 = A.EQMFCD AND MAR.rcdcd = 'F' ", _
    '                                                   "LEFT OUTER JOIN ", strLibro, ".EMPMDLH0 MO ON MO.EQMFM2 = A.DSPMDL AND MO.EQMFCD = A.EQMFCD ", _
    '                                                   "LEFT OUTER JOIN ", strLibro, ".UFPSC060 C ON SEG.CENCOS = SUBSTR(C.CODIGO, 10, 2) ", _
    '                                                         "AND   C.TABLA = 'DCC' ", _
    '                                                         "AND   C.CODIGO <> '' ", _
    '                                                         "AND   C.CORP = '001' ", _
    '                                                         "AND   C.CIA = '002' ", _
    '                                                         "AND   C.IDIOMA = 'E' ", _
    '                                                         "AND   SUBSTR(C.CODIGO, 1, 4) = CHAR(YEAR(CURRENT_DATE)) ")

    '      Dim str_Filtro = String.Empty

    '      'Filtro de CUENTA
    '      If pi_objFiltro.cuenta <> String.Empty And Not pi_objFiltro.cuenta Is Nothing Then
    '         Dim cuentas = pi_objFiltro.cuenta.Split(",")
    '         Dim str_cuentas = clsUtil.fn_ConvertirArrayAString(cuentas.ToList())
    '         str_Filtro += String.Format("(A.CUNO IN ({0}) OR A.LCUNO IN ({0}))", str_cuentas)
    '      End If

    '      'Filtro de MARCA
    '      If pi_objFiltro.marca <> String.Empty And Not pi_objFiltro.marca Is Nothing Then
    '         If str_Filtro.Length > 0 Then str_Filtro += " AND "
    '         str_Filtro += String.Format("TRIM(MAR.DS4) like '%{0}%'", pi_objFiltro.marca)
    '      End If

    '      'Filtro de MODELO
    '      If pi_objFiltro.modelo <> String.Empty And Not pi_objFiltro.modelo Is Nothing Then
    '         If str_Filtro.Length > 0 Then str_Filtro += " AND "
    '         Dim modelos = pi_objFiltro.modelo.Split(",")
    '         Dim str_modelos = clsUtil.fn_ConvertirArrayAString(modelos.ToList())
    '         str_Filtro += String.Format("A.EQMFM2 IN ({0})", str_modelos)
    '      End If

    '      'Filtro de ORDEN
    '      If pi_objFiltro.orden <> String.Empty And Not pi_objFiltro.orden Is Nothing Then
    '         If str_Filtro.Length > 0 Then str_Filtro += " AND "
    '         str_Filtro += String.Format("TRIM(A.IDNO1) = '{0}'", pi_objFiltro.orden)
    '      End If

    '      'Filtro de FECHA ESTIMADA DE INGRESO
    '      If (pi_objFiltro.fechaEstIngDesde <> String.Empty And Not pi_objFiltro.fechaEstIngDesde Is Nothing) And (pi_objFiltro.fechaEstIngHasta = String.Empty Or pi_objFiltro.fechaEstIngHasta Is Nothing) Then
    '         If str_Filtro.Length > 0 Then str_Filtro += " AND "
    '         str_Filtro += String.Format("DATE(TO_DATE(SEG.EXFAB,'DD-MM-YYYY')) >= DATE('{0}')", clsUtil.fn_strFecha_String_ddMMyyyy_A_String_yyyyMMdd(pi_objFiltro.fechaEstIngDesde, "-")) 'Modificar por el campo correcto
    '      ElseIf (pi_objFiltro.fechaEstIngDesde = String.Empty Or pi_objFiltro.fechaEstIngDesde Is Nothing) And (pi_objFiltro.fechaEstIngHasta <> String.Empty And Not pi_objFiltro.fechaEstIngHasta Is Nothing) Then
    '         If str_Filtro.Length > 0 Then str_Filtro += " AND "
    '         str_Filtro += String.Format("DATE(TO_DATE(SEG.EXFAB,'DD-MM-YYYY')) <= DATE('{0}')", clsUtil.fn_strFecha_String_ddMMyyyy_A_String_yyyyMMdd(pi_objFiltro.fechaEstIngHasta, "-")) 'Modificar por el campo correcto
    '      ElseIf (pi_objFiltro.fechaEstIngDesde <> String.Empty And Not pi_objFiltro.fechaEstIngDesde Is Nothing) And (pi_objFiltro.fechaEstIngHasta <> String.Empty And Not pi_objFiltro.fechaEstIngHasta Is Nothing) Then
    '         If str_Filtro.Length > 0 Then str_Filtro += " AND "
    '         str_Filtro += String.Format("DATE(TO_DATE(SEG.EXFAB,'DD-MM-YYYY')) BETWEEN DATE('{0}') AND DATE('{1}')",
    '                                     clsUtil.fn_strFecha_String_ddMMyyyy_A_String_yyyyMMdd(pi_objFiltro.fechaEstIngDesde, "-"),
    '                                     clsUtil.fn_strFecha_String_ddMMyyyy_A_String_yyyyMMdd(pi_objFiltro.fechaEstIngHasta, "-")) 'Modificar por el campo correcto
    '      End If

    '      'Filtro de ESTADO - LIBRE TRANSITO -> DB2 
    '      If pi_objFiltro.estado.Count > 0 Then
    '         If str_Filtro.Length > 0 Then str_Filtro += " AND "
    '         Dim str_estados = clsUtil.fn_ConvertirArrayAString(pi_objFiltro.estado)
    '         str_Filtro += String.Format("A.INVI IN ({0})", str_estados)
    '      End If

    '      If str_Filtro.Length > 0 Then
    '         strConsulta += String.Format(" WHERE {0}", str_Filtro)
    '      End If

    '      clsAS400.sb_AgregarPaginacion(strConsulta, pi_pagina, pi_CantidadRegistros)

    '      clsAS400.fn_EjecutarSelect(strConsulta, liBEMaquina, objArrParametros)

    '      Return liBEMaquina
    '   Catch ex As Exception
    '      Throw ex
    '   End Try
    'End Function

    Public Shared Function fn_Select_Maquina_Consulta_Inventario(ByRef po_intTotal As Integer, ByVal pi_pagina As Integer, ByVal pi_CantidadRegistros As Integer, ByVal pi_objFiltro As DTO_Filtro_Maquina_Inventario, ByVal pi_strIdUsuario As String) As List(Of DTO_Consulta_Inventario_Maquina)
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            Dim str_cuentas = clsUtil.fn_ConvertirArrayAString(pi_objFiltro.cuenta.Split(",").ToList(), True)
            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@CuentaInventarioDBS"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(str_cuentas.GetType)
                .strSourceColumn = str_cuentas
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@MarcaDesc"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_objFiltro.marca.GetType)
                .strSourceColumn = pi_objFiltro.marca
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim str_modelos = clsUtil.fn_ConvertirArrayAString(pi_objFiltro.modelo.Split(",").ToList(), True)
            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ModeloProductoId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(str_modelos.GetType)
                .strSourceColumn = str_modelos
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@OrdenAsignada"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_objFiltro.orden.GetType)
                .strSourceColumn = pi_objFiltro.orden
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Proyecto"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_objFiltro.proyecto.GetType)
                .strSourceColumn = pi_objFiltro.proyecto
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Cliente"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_objFiltro.cliente.GetType)
                .strSourceColumn = pi_objFiltro.cliente
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Vendedor"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_objFiltro.vendedor.GetType)
                .strSourceColumn = pi_objFiltro.vendedor
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Proceso"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_objFiltro.proceso.GetType)
                .strSourceColumn = pi_objFiltro.proceso
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@IngresoFisicoFESAEstimadaFechaDesde"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_objFiltro.fechaEstIngDesde.GetType)
                .strSourceColumn = clsUtil.fn_strFecha_String_ddMMyyyy_A_String_yyyyMMdd(pi_objFiltro.fechaEstIngDesde, "-")
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@IngresoFisicoFESAEstimadaFechaHasta"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_objFiltro.fechaEstIngHasta.GetType)
                .strSourceColumn = clsUtil.fn_strFecha_String_ddMMyyyy_A_String_yyyyMMdd(pi_objFiltro.fechaEstIngHasta, "-")
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim str_semaforos = clsUtil.fn_ConvertirArrayAString(pi_objFiltro.semaforo, False)
            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@SemaforoAntiguamiento"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(str_semaforos.GetType)
                .strSourceColumn = str_semaforos
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim str_estados = clsUtil.fn_ConvertirArrayAString(pi_objFiltro.estado, True)
            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@EstadoMaquina"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(str_estados.GetType)
                .strSourceColumn = str_estados
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim str_ubicaciones = clsUtil.fn_ConvertirArrayAString(pi_objFiltro.ubicacion.Split(",").ToList(), True)
            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@UbicacionId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(str_ubicaciones.GetType)
                .strSourceColumn = str_ubicaciones
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@IdUsuario"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_strIdUsuario.GetType)
                .strSourceColumn = pi_strIdUsuario
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Pagina"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_pagina.GetType)
                .strSourceColumn = pi_pagina
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@RegistrosPorPagina"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_CantidadRegistros.GetType)
                .strSourceColumn = pi_CantidadRegistros
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL 'Agregar este parámetro al último (Para obtener la cantidad de registros)
            With EntParametroSQL
                .strParameterName = "@ObtenerTotal"
                .typDbType = DbType.String
                .strSourceColumn = "1"
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim liDTOConsultaInventarioMaquina As New List(Of DTO_Consulta_Inventario_Maquina)

            If pi_pagina > 0 Then
                po_intTotal = clsSQLServer.fn_EjecutarSelect_Escalar("cnFSASGCVU", "P_BRR5_S_Maquina_Consulta_Inventario", True, liEnt_Parametro)

                If po_intTotal > 0 Then
                    liEnt_Parametro.RemoveAt(liEnt_Parametro.Count - 1)

                    EntParametroSQL = New clsEntidad_ParametroSQL 'Agregar parámetro para obtener la lista
                    With EntParametroSQL
                        .strParameterName = "@ObtenerTotal"
                        .typDbType = DbType.String
                        .strSourceColumn = "0"
                    End With
                    liEnt_Parametro.Add(EntParametroSQL)

                    liDTOConsultaInventarioMaquina = clsSQLServer.fn_EjecutarSelect(Of DTO_Consulta_Inventario_Maquina)("cnFSASGCVU", "P_BRR5_S_Maquina_Consulta_Inventario", True, liEnt_Parametro)
                End If
            Else
                liDTOConsultaInventarioMaquina = clsSQLServer.fn_EjecutarSelect(Of DTO_Consulta_Inventario_Maquina)("cnFSASGCVU", "P_BRR5_S_Maquina_Consulta_Inventario", True, liEnt_Parametro)
                po_intTotal = liDTOConsultaInventarioMaquina.Count
            End If

            Return liDTOConsultaInventarioMaquina
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Select_Maquina_Modelo_Emparejamiento(ByVal pi_strModelo As String, ByVal pi_strOrdenAsignada As String) As List(Of BE_Maquina)
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ModeloProductoDesc"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_strModelo.GetType)
                .strSourceColumn = pi_strModelo
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@OrdenAsignada"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_strOrdenAsignada.GetType)
                .strSourceColumn = pi_strOrdenAsignada
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim liBEMaquina As New List(Of BE_Maquina)

            clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_Maquina_Modelo_Emparejamiento", True, liBEMaquina, liEnt_Parametro)

            Return liBEMaquina
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Select_Maquina_Relacionadas(ByVal pi_strOrden As String) As List(Of DTO_Consulta_Inventario_Maquina)
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

            Return clsSQLServer.fn_EjecutarSelect(Of DTO_Consulta_Inventario_Maquina)("cnFSASGCVU", "P_BRR5_S_Maquina_Relacionadas", True, liEnt_Parametro)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Select_Maquina_Modificacion_Inventario(ByVal pi_strOrden As String) As BE_Maquina
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@OrdenAsignada"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_strOrden.GetType)
                .strSourceColumn = pi_strOrden
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim BEMaquina As BE_Maquina = Nothing
            Dim liBEMaquina As New List(Of BE_Maquina)

            clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_Maquina_Modificacion_Inventario", True, liBEMaquina, liEnt_Parametro)

            If liBEMaquina.Count > 0 Then
                BEMaquina = liBEMaquina(0)
            End If

            Return BEMaquina
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Select_Maquina_Orden(ByVal pi_strOrden As String) As BE_Maquina
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@OrdenAsignada"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_strOrden.GetType)
                .strSourceColumn = pi_strOrden
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim BEMaquina As BE_Maquina = Nothing
            Dim liBEMaquina As New List(Of BE_Maquina)

            clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_Maquina_Orden", True, liBEMaquina, liEnt_Parametro)

            If liBEMaquina.Count > 0 Then
                BEMaquina = liBEMaquina(0)
            End If

            Return BEMaquina
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Select_InformacionMaquinaCabecera(ByVal pi_strOrden) As DTO_InfoMaquinaCabecera
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@OrdenAsignada"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_strOrden.GetType)
                .strSourceColumn = pi_strOrden
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim lista = clsSQLServer.fn_EjecutarSelect(Of DTO_InfoMaquinaCabecera)("cnFSASGCVU", "P_BRR5_S_Maquina_Informacion_Cabecera", True, liEnt_Parametro)
            If lista.Count > 0 Then
                Return lista(0)
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Select_InformacionMaquinaSeguimientoImportacion(ByVal pi_strOrden) As DTO_InfoMaquinaSeguimientoImportacion
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@OrdenAsignada"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_strOrden.GetType)
                .strSourceColumn = pi_strOrden
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim lista = clsSQLServer.fn_EjecutarSelect(Of DTO_InfoMaquinaSeguimientoImportacion)("cnFSASGCVU", "P_BRR5_S_Maquina_Informacion_SeguimientoImportacion", True, liEnt_Parametro)
            If lista.Count > 0 Then
                Return lista(0)
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Select_InformacionMaquinaInfoInventario(ByVal pi_strOrden) As DTO_InfoMaquinaInventario
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@OrdenAsignada"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_strOrden.GetType)
                .strSourceColumn = pi_strOrden
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim lista = clsSQLServer.fn_EjecutarSelect(Of DTO_InfoMaquinaInventario)("cnFSASGCVU", "P_BRR5_S_Maquina_Informacion_Inventario", True, liEnt_Parametro)
            If lista.Count > 0 Then
                Return lista(0)
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Select_InformacionMaquinaDatosTecnicos(ByVal pi_strOrden) As DTO_InfoMaquinaDatosTecnicos
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@OrdenAsignada"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_strOrden.GetType)
                .strSourceColumn = pi_strOrden
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim lista = clsSQLServer.fn_EjecutarSelect(Of DTO_InfoMaquinaDatosTecnicos)("cnFSASGCVU", "P_BRR5_S_Maquina_Informacion_DatosTecnicos", True, liEnt_Parametro)
            If lista.Count > 0 Then
                Return lista(0)
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Select_InformacionMaquinaConfiguracionUnidad(ByVal pi_strOrden) As List(Of DTO_InfoMaquinaConfiguracionUnidad)
        Try
            Dim strLibro As String = clsAS400.fn_ObtenerNombreLibro()

            Dim objArrParametros(,) As Object = {{}}

            Dim strConsulta As String = Concat("SELECT   A.SQNO4 AS Seq, A.PRDREF AS NroParte, A.ORQY1 AS Cantidad, A.PDRFDS AS Descripcion ", _
                                                "FROM	   ", strLibro, ".EMPORDD0 A ", _
                                                "WHERE   TRIM(A.IDNO1) = '", pi_strOrden, "'")

            Return clsAS400.fn_EjecutarSelect(Of DTO_InfoMaquinaConfiguracionUnidad)(strConsulta, objArrParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Update_Maquina_Inventario(ByVal pi_BEMaquina As BE_Maquina, ByVal pi_liStrMaquinasRelacionadas As List(Of String)) As String
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@OrdenAsignada"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_OrdenAsignada.GetType)
                .strSourceColumn = pi_BEMaquina.str_OrdenAsignada
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Version"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_Version.GetType)
                .strSourceColumn = pi_BEMaquina.str_Version
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Proyecto"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_Proyecto.GetType)
                .strSourceColumn = pi_BEMaquina.str_Proyecto
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Observaciones"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_Observaciones.GetType)
                .strSourceColumn = pi_BEMaquina.str_Observaciones
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim str_maquinasRelacionadas = clsUtil.fn_ConvertirArrayAString(pi_liStrMaquinasRelacionadas, False)
            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Maquina_Emparejamiento"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(str_maquinasRelacionadas.GetType)
                .strSourceColumn = str_maquinasRelacionadas
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim strReturn As String = String.Empty
            Dim strParametroSalida As String = String.Empty

            Try
                strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_U_Maquina_Inventario", True, strReturn, liEnt_Parametro)

                If Not strParametroSalida = String.Empty Then strReturn = strParametroSalida
            Catch ex As Exception
                strReturn = String.Empty
            End Try

            Return strReturn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Update_SolicitoLevante_Maquina(ByVal pi_strOrden As String, ByVal pi_BEAlerta As BE_Alertas) As String
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

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Usuario"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEAlerta.str_UsuarioRegistro.GetType)
                .strSourceColumn = pi_BEAlerta.str_UsuarioRegistro
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim strReturn As String = String.Empty
            Dim strParametroSalida As String = String.Empty

            Try
                strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_U_Maquina_SolicitoLevante", True, strReturn, liEnt_Parametro)

                If Not strParametroSalida = String.Empty Then strReturn = strParametroSalida
            Catch ex As Exception
                strReturn = String.Empty
            End Try

            Return strReturn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Select_Ubicacion_Maquina() As List(Of DTO_Ubicacion_Maquina)
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)

            Return clsSQLServer.fn_EjecutarSelect(Of DTO_Ubicacion_Maquina)("cnFSASGCVU", "P_BRR5_S_Ubicacion_Maquina", True, liEnt_Parametro)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Select_Cuenta_Usuario(ByVal pi_strIdUsuario As String) As List(Of DTO_Cuenta_Usuario)
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@IdUsuario"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_strIdUsuario.GetType)
                .strSourceColumn = pi_strIdUsuario
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Return clsSQLServer.fn_EjecutarSelect(Of DTO_Cuenta_Usuario)("cnFSASGCVU", "P_BRR5_S_Cuenta_Usuario", True, liEnt_Parametro)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Select_Maquina_Estado_LIBRE_TRANSITO(ByVal pi_strOrden As String) As List(Of DTO_Consulta_Inventario_Maquina)
        Try
            Dim strLibro As String = clsAS400.fn_ObtenerNombreLibro()

            Dim objArrParametros(,) As Object = {{}}

            Dim strConsulta As String = Concat("SELECT   COALESCE(TRIM(PDO.IDNO1), TRIM(SEG.ORDEN)) AS OrdenAsignada, COALESCE(PDO.INVI, 'T') AS EstadoMaquina ", _
                                                "FROM	   ", strLibro, ".EMPEQPD0 PDO ", _
                                                         "FULL JOIN ", strLibro, ".UMPEMSSEG SEG ON TRIM(SEG.ORDEN) = TRIM(PDO.IDNO1) ", _
                                                "WHERE   TRIM(PDO.IDNO1) = '", pi_strOrden, "' OR TRIM(SEG.ORDEN) = '", pi_strOrden, "' ")

            Return clsAS400.fn_EjecutarSelect(Of DTO_Consulta_Inventario_Maquina)(strConsulta, objArrParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Select_Maquina_Expediente(ByVal be_Maquina As BE_Maquina) As List(Of BE_Maquina)
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ExpedienteId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(be_Maquina.int_ExpedienteId.GetType)
                .strSourceColumn = be_Maquina.int_ExpedienteId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@EstadoRegistro"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(be_Maquina.str_EstadoMaquina.GetType)
                .strSourceColumn = be_Maquina.str_EstadoMaquina
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim liBEMaquina As New List(Of BE_Maquina)

            clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_Maquina_ExpedienteId", True, liBEMaquina, liEnt_Parametro)

            Return liBEMaquina

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Update_Maquina_Datos(ByVal be_Maquina As BE_Maquina) As String
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL


            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Orden"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(be_Maquina.str_OrdenAsignada.GetType)
                .strSourceColumn = be_Maquina.str_OrdenAsignada
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Observacion"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(be_Maquina.str_Observaciones.GetType)
                .strSourceColumn = be_Maquina.str_Observaciones
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@MontoRpto"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(be_Maquina.dec_BonoRptoMonto.GetType)
                .strSourceColumn = be_Maquina.dec_BonoRptoMonto
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@MontoRitmo5"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(be_Maquina.dec_Ritmo5Monto.GetType)
                .strSourceColumn = be_Maquina.dec_Ritmo5Monto
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Modificacion"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(be_Maquina.int_PosicionId.GetType)
                .strSourceColumn = be_Maquina.int_PosicionId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim strReturn As String = String.Empty
            Dim strParametroSalida As String = String.Empty

            Try
                strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_U_Maquina_Datos", True, strReturn, liEnt_Parametro)

                If Not strParametroSalida = String.Empty Then strReturn = strParametroSalida
            Catch ex As Exception
                strReturn = String.Empty
            End Try

            Return strReturn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Select_Maquina_Bono(ByVal be_Maquina As BE_Maquina) As List(Of BE_Maquina)
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ExpedienteId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(be_Maquina.int_ExpedienteId.GetType)
                .strSourceColumn = be_Maquina.int_ExpedienteId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@EstadoRegistro"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(be_Maquina.str_EstadoMaquina.GetType)
                .strSourceColumn = be_Maquina.str_EstadoMaquina
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Return clsSQLServer.fn_EjecutarSelect(Of DTO_Consulta_Inventario_Maquina)("cnFSASGCVU", "P_BRR5_S_Maquina_ExpedienteId", True, liEnt_Parametro)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Select_Maquina_Resultado(ByRef po_intTotal As Integer, ByVal pi_pagina As Integer, ByVal pi_CantidadRegistros As Integer, ByVal pIdCompania As String, ByVal pOrden As String, ByVal pDesCliente As String, ByVal pSucursal As String, ByVal pCodSucursal As String, ByVal pMarca As String, ByVal pModelo As String, ByVal pVendedor As String, ByVal pEstado As String, ByVal pActividad As Integer, ByVal pSemaforo As String, ByVal pFecIni As String, ByVal pFecFin As String) As List(Of BE_Maquina_ColumnasResultado)
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@IdCompania"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pIdCompania.GetType)
                .strSourceColumn = pIdCompania
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Orden"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pOrden.GetType)
                .strSourceColumn = pOrden
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@DescCliente"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pDesCliente.GetType)
                .strSourceColumn = pDesCliente
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@SucursalReserva"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pSucursal.GetType)
                .strSourceColumn = pSucursal
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@CodSucursal"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pCodSucursal.GetType)
                .strSourceColumn = pCodSucursal
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Marca"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pMarca.GetType)
                .strSourceColumn = pMarca
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ModeloIdGenerico"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pModelo.GetType)
                .strSourceColumn = pModelo
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@VendedorDesc"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pVendedor.GetType)
                .strSourceColumn = pVendedor
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@EstadoRegistro"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pEstado.GetType)
                .strSourceColumn = pEstado
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@IdActividad"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pActividad.GetType)
                .strSourceColumn = pActividad
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@SemaforoLT2"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pSemaforo.GetType)
                .strSourceColumn = pSemaforo
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@FechaFacturaClienteInicio"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pFecIni.GetType)
                .strSourceColumn = pFecIni
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@FechaFacturaClienteFin"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pFecFin.GetType)
                .strSourceColumn = pFecFin
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ObtenerTotal"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(po_intTotal.GetType)
                .strSourceColumn = po_intTotal
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Pagina"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_pagina.GetType)
                .strSourceColumn = pi_pagina
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@RegistrosPorPagina"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_CantidadRegistros.GetType)
                .strSourceColumn = pi_CantidadRegistros
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim liBEMaquina As New List(Of BE_Maquina_ColumnasResultado)

            clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_Maquina_Buscar2", True, liBEMaquina, liEnt_Parametro)

            Return liBEMaquina

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Select_Maquina_CodCliente(ByVal po_intTotal As Integer, ByVal pi_pagina As Integer, ByVal pi_CantidadRegistros As Integer, ByVal be_Maquina As BE_Maquina) As List(Of DTO_Maquina)
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@IdCompania"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(be_Maquina.str_CompaniaId.GetType)
                .strSourceColumn = be_Maquina.str_CompaniaId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@CodCliente"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(be_Maquina.str_ClienteId.GetType)
                .strSourceColumn = be_Maquina.str_ClienteId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@DescCliente"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(be_Maquina.str_ClienteDesc.GetType)
                .strSourceColumn = be_Maquina.str_ClienteDesc
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ObtenerTotal"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(po_intTotal.GetType)
                .strSourceColumn = po_intTotal
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Pagina"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_pagina.GetType)
                .strSourceColumn = pi_pagina
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@RegistrosPorPagina"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_CantidadRegistros.GetType)
                .strSourceColumn = pi_CantidadRegistros
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim liBEMaquina As New List(Of DTO_Maquina)
            'Return clsSQLServer.fn_EjecutarSelect(Of DTO_Maquina)("cnFSASGCVU", "P_BRR5_S_Maquina_CodCliente_SinActividad", True, liEnt_Parametro)
            clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_Maquina_CodCliente_SinActividad", True, liBEMaquina, liEnt_Parametro)
            Return liBEMaquina
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Update_MaquinaBono(ByVal pi_BEMaquina As BE_Maquina) As String
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Orden"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_OrdenAsignada.GetType)
                .strSourceColumn = pi_BEMaquina.str_OrdenAsignada
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@VendedorId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_VendedorId.GetType)
                .strSourceColumn = pi_BEMaquina.str_VendedorId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@VendedorDesc"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_VendedorDesc.GetType)
                .strSourceColumn = pi_BEMaquina.str_VendedorDesc
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ClienteId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_ClienteId.GetType)
                .strSourceColumn = pi_BEMaquina.str_ClienteId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ClienteDesc"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_ClienteDesc.GetType)
                .strSourceColumn = pi_BEMaquina.str_ClienteDesc
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ClienteFacturaId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_ClienteFacturaId.GetType)
                .strSourceColumn = pi_BEMaquina.str_ClienteFacturaId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ClienteFacturaDesc"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_ClienteFacturaDesc.GetType)
                .strSourceColumn = pi_BEMaquina.str_ClienteFacturaDesc
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@EntidadFinancieraId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_EntidadFinancieraId.GetType)
                .strSourceColumn = pi_BEMaquina.str_EntidadFinancieraId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@CuentaInventarioDBS"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_CuentaInventarioDBS.GetType)
                .strSourceColumn = pi_BEMaquina.str_CuentaInventarioDBS
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@DescripcionCuenta"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_DescripcionCuenta.GetType)
                .strSourceColumn = pi_BEMaquina.str_DescripcionCuenta
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Sucursal"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_Sucursal.GetType)
                .strSourceColumn = pi_BEMaquina.str_Sucursal
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@DescripcionSucursal"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_DescripcionSucursal.GetType)
                .strSourceColumn = pi_BEMaquina.str_DescripcionSucursal
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@FinanciamientoId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_FinanciamientoId.GetType)
                .strSourceColumn = pi_BEMaquina.str_FinanciamientoId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@FamiliaDesc"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_FamiliaDesc.GetType)
                .strSourceColumn = pi_BEMaquina.str_FamiliaDesc
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@MarcaDesc"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_MarcaDesc.GetType)
                .strSourceColumn = pi_BEMaquina.str_MarcaDesc
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ModeloProductoDesc"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_ModeloProductoDesc.GetType)
                .strSourceColumn = pi_BEMaquina.str_ModeloProductoDesc
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@SerieMaquina"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_SerieMaquina.GetType)
                .strSourceColumn = pi_BEMaquina.str_SerieMaquina
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Ritmo5"
                .typDbType = DbType.Int32 'clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_SerieMaquina.GetType)
                .strSourceColumn = 0
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@MontoRitmo5"
                .typDbType = DbType.Decimal 'clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_SerieMaquina.GetType)
                .strSourceColumn = 0
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@TipoRitmo5"
                .typDbType = DbType.String 'clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_SerieMaquina.GetType)
                .strSourceColumn = ""
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@IdSapRitmo5"
                .typDbType = DbType.String 'clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_SerieMaquina.GetType)
                .strSourceColumn = ""
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@BonoRpto"
                .typDbType = DbType.Int32 'clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_SerieMaquina.GetType)
                .strSourceColumn = 0
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@MontoBonoRpto"
                .typDbType = DbType.Decimal 'clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_SerieMaquina.GetType)
                .strSourceColumn = 0
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Observacion"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_Observaciones.GetType)
                .strSourceColumn = pi_BEMaquina.str_Observaciones
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@EsFactura"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_EstadoInventario.GetType)
                .strSourceColumn = pi_BEMaquina.str_EstadoInventario
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@SUNTIP"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_SUNTIP.GetType)
                .strSourceColumn = pi_BEMaquina.str_SUNTIP
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@SUNPRE"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.int_SUNPRE.GetType)
                .strSourceColumn = pi_BEMaquina.int_SUNPRE
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@SUNNUM"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.int_SUNNUM.GetType)
                .strSourceColumn = pi_BEMaquina.int_SUNNUM
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@xmlSAP"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_XmlSap.GetType)
                .strSourceColumn = pi_BEMaquina.str_XmlSap
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@EstadoMaquina"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_EstadoMaquina.GetType)
                .strSourceColumn = pi_BEMaquina.str_EstadoMaquina
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@CompaniaId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_CompaniaId.GetType)
                .strSourceColumn = pi_BEMaquina.str_CompaniaId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@FacturaClienteFecha"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_FechaFactura.GetType)
                .strSourceColumn = pi_BEMaquina.str_FechaFactura
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@NoTieneNroorden"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.int_NoTieneNroorden.GetType)
                .strSourceColumn = pi_BEMaquina.int_NoTieneNroorden
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim strReturn As String = String.Empty
            Dim strParametroSalida As String = String.Empty

            Try
                strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_U_MaquinaBono", True, strReturn, liEnt_Parametro)

                If Not strParametroSalida = String.Empty Then strReturn = strParametroSalida
            Catch ex As Exception
                strReturn = String.Empty
            End Try

            Return strReturn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Insert_MaquinaBono(ByVal pi_BEMaquina As BE_Maquina) As String
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Orden"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_OrdenAsignada.GetType)
                .strSourceColumn = pi_BEMaquina.str_OrdenAsignada
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@VendedorId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_VendedorId.GetType)
                .strSourceColumn = pi_BEMaquina.str_VendedorId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@VendedorDesc"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_VendedorDesc.GetType)
                .strSourceColumn = pi_BEMaquina.str_VendedorDesc
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ClienteId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_ClienteId.GetType)
                .strSourceColumn = pi_BEMaquina.str_ClienteId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ClienteDesc"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_ClienteDesc.GetType)
                .strSourceColumn = pi_BEMaquina.str_ClienteDesc
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ClienteFacturaId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_ClienteFacturaId.GetType)
                .strSourceColumn = pi_BEMaquina.str_ClienteFacturaId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ClienteFacturaDesc"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_ClienteFacturaDesc.GetType)
                .strSourceColumn = pi_BEMaquina.str_ClienteFacturaDesc
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@EntidadFinancieraId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_EntidadFinancieraId.GetType)
                .strSourceColumn = pi_BEMaquina.str_EntidadFinancieraId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@CuentaInventarioDBS"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_CuentaInventarioDBS.GetType)
                .strSourceColumn = pi_BEMaquina.str_CuentaInventarioDBS
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@DescripcionCuenta"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_DescripcionCuenta.GetType)
                .strSourceColumn = pi_BEMaquina.str_DescripcionCuenta
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Sucursal"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_Sucursal.GetType)
                .strSourceColumn = pi_BEMaquina.str_Sucursal
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@DescripcionSucursal"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_DescripcionSucursal.GetType)
                .strSourceColumn = pi_BEMaquina.str_DescripcionSucursal
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@FinanciamientoId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_FinanciamientoId.GetType)
                .strSourceColumn = pi_BEMaquina.str_FinanciamientoId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@FamiliaDesc"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_FamiliaDesc.GetType)
                .strSourceColumn = pi_BEMaquina.str_FamiliaDesc
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@MarcaDesc"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_MarcaDesc.GetType)
                .strSourceColumn = pi_BEMaquina.str_MarcaDesc
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ModeloProductoDesc"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_ModeloProductoDesc.GetType)
                .strSourceColumn = pi_BEMaquina.str_ModeloProductoDesc
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@SerieMaquina"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_SerieMaquina.GetType)
                .strSourceColumn = pi_BEMaquina.str_SerieMaquina
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Ritmo5"
                .typDbType = DbType.Int32 'clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_SerieMaquina.GetType)
                .strSourceColumn = 0
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@MontoRitmo5"
                .typDbType = DbType.Decimal 'clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_SerieMaquina.GetType)
                .strSourceColumn = 0
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@TipoRitmo5"
                .typDbType = DbType.String 'clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_SerieMaquina.GetType)
                .strSourceColumn = ""
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@IdSapRitmo5"
                .typDbType = DbType.String 'clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_SerieMaquina.GetType)
                .strSourceColumn = ""
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@BonoRpto"
                .typDbType = DbType.Int32 'clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_SerieMaquina.GetType)
                .strSourceColumn = 0
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@MontoBonoRpto"
                .typDbType = DbType.Decimal 'clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_SerieMaquina.GetType)
                .strSourceColumn = 0
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Observacion"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_Observaciones.GetType)
                .strSourceColumn = pi_BEMaquina.str_Observaciones
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@EsFactura"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_EstadoInventario.GetType)
                .strSourceColumn = pi_BEMaquina.str_EstadoInventario
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@SUNTIP"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_SUNTIP.GetType)
                .strSourceColumn = pi_BEMaquina.str_SUNTIP
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@SUNPRE"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.int_SUNPRE.GetType)
                .strSourceColumn = pi_BEMaquina.int_SUNPRE
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@SUNNUM"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.int_SUNNUM.GetType)
                .strSourceColumn = pi_BEMaquina.int_SUNNUM
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@xmlSAP"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_XmlSap.GetType)
                .strSourceColumn = pi_BEMaquina.str_XmlSap
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@EstadoMaquina"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_EstadoMaquina.GetType)
                .strSourceColumn = pi_BEMaquina.str_EstadoMaquina
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@CompaniaId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_CompaniaId.GetType)
                .strSourceColumn = pi_BEMaquina.str_CompaniaId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@FacturaClienteFecha"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_FechaFactura.GetType)
                .strSourceColumn = pi_BEMaquina.str_FechaFactura
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@NoTieneNroorden"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.int_NoTieneNroorden.GetType)
                .strSourceColumn = pi_BEMaquina.int_NoTieneNroorden
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim strReturn As String = String.Empty
            Dim strParametroSalida As String = String.Empty

            Try
                strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_I_MaquinaBono", True, strReturn, liEnt_Parametro)

                If Not strParametroSalida = String.Empty Then strReturn = strParametroSalida
            Catch ex As Exception
                strReturn = String.Empty
            End Try

            Return strReturn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Insert_MaquinaArchivo(ByVal pi_BEMaquinaArchivo As BE_MaquinaArchivo) As String
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@OrdenAsignada"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquinaArchivo.str_OrdenAsignada.GetType)
                .strSourceColumn = pi_BEMaquinaArchivo.str_OrdenAsignada
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@NombreArchivo"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquinaArchivo.str_NombreArchivo.GetType)
                .strSourceColumn = pi_BEMaquinaArchivo.str_NombreArchivo
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@IdClase"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquinaArchivo.int_IdClase.GetType)
                .strSourceColumn = pi_BEMaquinaArchivo.int_IdClase
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Archivo"
                .typDbType = DbType.Binary
                .byteSourceColumn = pi_BEMaquinaArchivo.bin_Archivo
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@UsuarioCreacion"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquinaArchivo.str_UsuarioCreacion.GetType)
                .strSourceColumn = pi_BEMaquinaArchivo.str_UsuarioCreacion
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@FechaCreacion"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquinaArchivo.dt_FechaCreacion.GetType)
                .strSourceColumn = pi_BEMaquinaArchivo.dt_FechaCreacion
            End With
            liEnt_Parametro.Add(EntParametroSQL)


            Dim strReturn As String = String.Empty
            Dim strParametroSalida As String = String.Empty

            Try
                strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_I_MaquinaArchivo", True, strReturn, liEnt_Parametro)
                If Not strParametroSalida = String.Empty Then strReturn = strParametroSalida
            Catch ex As Exception
                strReturn = String.Empty
            End Try

            Return strReturn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Select_MaquinaBeneficio_Orden(ByVal pi_MaquinaBeneficio As DTO_Maquina_Beneficio) As List(Of DTO_Maquina_Beneficio)
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL
            Dim listMaquina_Beneficio As New List(Of DTO_Maquina_Beneficio)
            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@OrdenAsignada"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_MaquinaBeneficio.OrdenAsignada.GetType)
                .strSourceColumn = pi_MaquinaBeneficio.OrdenAsignada
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ClaseId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_MaquinaBeneficio.ClaseId.GetType)
                .strSourceColumn = pi_MaquinaBeneficio.ClaseId
            End With
            liEnt_Parametro.Add(EntParametroSQL)


            clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_MaquinaBeneficio_Orden", True, listMaquina_Beneficio, liEnt_Parametro)

            Return listMaquina_Beneficio

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Select_MaquinaBeneficio_Expediente(ByVal pi_Maquina As BE_Maquina) As List(Of DTO_Maquina_Beneficio)
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL
            Dim listMaquina_Beneficio As New List(Of DTO_Maquina_Beneficio)
            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ExpedienteId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_Maquina.int_ExpedienteId.GetType)
                .strSourceColumn = pi_Maquina.int_ExpedienteId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@CompaniaId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_Maquina.str_CompaniaId.GetType)
                .strSourceColumn = pi_Maquina.str_CompaniaId
            End With
            liEnt_Parametro.Add(EntParametroSQL)


            clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_MaquinaBeneficio_Expediente", True, listMaquina_Beneficio, liEnt_Parametro)

            Return listMaquina_Beneficio

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Update_FechaFacturaCliente(ByVal pi_BEOrden As BE_Maquina) As String
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            'Condicionales
            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Orden"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEOrden.str_OrdenAsignada.GetType)
                .strSourceColumn = pi_BEOrden.str_OrdenAsignada
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@CompaniaId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEOrden.str_CompaniaId.GetType)
                .strSourceColumn = pi_BEOrden.str_CompaniaId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@FechaFacturaCliente"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEOrden.str_FechaFactura.GetType)
                .strSourceColumn = pi_BEOrden.str_FechaFactura
            End With
            liEnt_Parametro.Add(EntParametroSQL)


            Dim strReturn As String = String.Empty
            Dim strParametroSalida As String = String.Empty

            Try
                strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_U_Maquina_FechaFacturaCliente", True, strReturn, liEnt_Parametro)

                If Not strParametroSalida = String.Empty Then strReturn = strParametroSalida
            Catch ex As Exception
                strReturn = String.Empty
            End Try

            Return strReturn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Update_IdIncidente(ByVal pi_BEOrden As BE_Maquina) As String
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            'Condicionales
            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Orden"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEOrden.str_OrdenAsignada.GetType)
                .strSourceColumn = pi_BEOrden.str_OrdenAsignada
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@CompaniaId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEOrden.str_CompaniaId.GetType)
                .strSourceColumn = pi_BEOrden.str_CompaniaId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@IdIncidente"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEOrden.int_ExpedienteId.GetType)
                .strSourceColumn = pi_BEOrden.int_ExpedienteId
            End With
            liEnt_Parametro.Add(EntParametroSQL)


            Dim strReturn As String = String.Empty
            Dim strParametroSalida As String = String.Empty

            Try
                strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_U_Maquina_ExpedienteId", True, strReturn, liEnt_Parametro)

                If Not strParametroSalida = String.Empty Then strReturn = strParametroSalida
            Catch ex As Exception
                strReturn = String.Empty
            End Try

            Return strReturn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Update_CantidadMontoRitmo5(ByVal pi_BEOrden As BE_Maquina) As String
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Orden"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEOrden.str_OrdenAsignada.GetType)
                .strSourceColumn = pi_BEOrden.str_OrdenAsignada
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@CompaniaId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEOrden.str_CompaniaId.GetType)
                .strSourceColumn = pi_BEOrden.str_CompaniaId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Ritmo5Monto"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEOrden.dec_Ritmo5Monto.GetType)
                .strSourceColumn = pi_BEOrden.dec_Ritmo5Monto
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim strReturn As String = String.Empty
            Dim strParametroSalida As String = String.Empty

            Try
                strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_U_Maquina_CantidadMontoRitmo5", True, strReturn, liEnt_Parametro)

                If Not strParametroSalida = String.Empty Then strReturn = strParametroSalida
            Catch ex As Exception
                strReturn = String.Empty
            End Try

            Return strReturn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Update_Maquina_EstadoRegistro(ByVal pi_BEMaquina As BE_Maquina) As String
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Orden"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_OrdenAsignada.GetType)
                .strSourceColumn = pi_BEMaquina.str_OrdenAsignada
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@CompaniaId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_CompaniaId.GetType)
                .strSourceColumn = pi_BEMaquina.str_CompaniaId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@EstadoRegistro"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_EstadoMaquina.GetType)
                .strSourceColumn = pi_BEMaquina.str_EstadoMaquina
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim strReturn As String = String.Empty
            Dim strParametroSalida As String = String.Empty

            Try
                strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_U_Maquina_EstadoRegistro", True, strReturn, liEnt_Parametro)

                If Not strParametroSalida = String.Empty Then strReturn = strParametroSalida
            Catch ex As Exception
                strReturn = String.Empty
            End Try

            Return strReturn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Update_EstadoRegistro(ByVal pBEMaquina As BE_Maquina) As String
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            'Condicionales
            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Orden"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pBEMaquina.str_OrdenAsignada.GetType)
                .strSourceColumn = pBEMaquina.str_OrdenAsignada
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@EstadoRegistro"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pBEMaquina.str_EstadoMaquina.GetType)
                .strSourceColumn = pBEMaquina.str_EstadoMaquina
            End With
            liEnt_Parametro.Add(EntParametroSQL)


            Dim strReturn As String = String.Empty
            Dim strParametroSalida As String = String.Empty

            Try
                strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_U_Maquina_EstadoRegistro", True, strReturn, liEnt_Parametro)

                If Not strParametroSalida = String.Empty Then strReturn = strParametroSalida
            Catch ex As Exception
                strReturn = String.Empty
            End Try

            Return strReturn
        Catch ex As Exception
            'Dim rethrow As Boolean = ExceptionPolicy.HandleException(ex, "ExHandling")
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Select_MaquinaArchivo(ByVal pi_BEMaquinaArchivo As BE_MaquinaArchivo) As List(Of BE_MaquinaArchivo)
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@OrdenAsignada"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquinaArchivo.str_OrdenAsignada.GetType)
                .strSourceColumn = pi_BEMaquinaArchivo.str_OrdenAsignada
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@IdClase"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquinaArchivo.int_IdClase.GetType)
                .strSourceColumn = pi_BEMaquinaArchivo.int_IdClase
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim BEMaquina As BE_Maquina = Nothing
            Dim liBEMaquina As New List(Of BE_MaquinaArchivo)

            clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_MaquinaArchivo", True, liBEMaquina, liEnt_Parametro)

            Return liBEMaquina
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Update_Maquina_Asignacion(ByVal pi_BEMaquina As BE_Maquina, ByVal pi_strUsuario As String) As String
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@OrdenAsignada"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_OrdenAsignada.GetType)
                .strSourceColumn = pi_BEMaquina.str_OrdenAsignada
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@PedidoId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_PedidoId.GetType)
                .strSourceColumn = pi_BEMaquina.str_PedidoId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ClienteId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_ClienteId.GetType)
                .strSourceColumn = pi_BEMaquina.str_ClienteId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ClienteDesc"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_ClienteDesc.GetType)
                .strSourceColumn = pi_BEMaquina.str_ClienteDesc
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ClienteFacturaId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_ClienteFacturaId.GetType)
                .strSourceColumn = pi_BEMaquina.str_ClienteFacturaId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ClienteFacturaDesc"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_ClienteFacturaDesc.GetType)
                .strSourceColumn = pi_BEMaquina.str_ClienteFacturaDesc
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@UsuarioId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_strUsuario.GetType)
                .strSourceColumn = pi_strUsuario
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@PosicionId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.int_PosicionId.GetType)
                .strSourceColumn = pi_BEMaquina.int_PosicionId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ApoyoFabricante"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_ApoyoFabricanteIndicador.GetType)
                .strSourceColumn = pi_BEMaquina.str_ApoyoFabricanteIndicador
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@VendedorId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_VendedorId.GetType)
                .strSourceColumn = pi_BEMaquina.str_VendedorId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@VendedorDesc"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_VendedorDesc.GetType)
                .strSourceColumn = pi_BEMaquina.str_VendedorDesc
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim strReturn As String = String.Empty
            Dim strParametroSalida As String = String.Empty

            Try
                strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_U_Maquina_Asignacion", True, strReturn, liEnt_Parametro)

                If Not strParametroSalida = String.Empty Then strReturn = strParametroSalida
            Catch ex As Exception
                strReturn = String.Empty
            End Try

            Return strReturn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Update_Maquina_Asignacion_Anular(ByVal pi_BEMaquina As BE_Maquina, ByVal pi_BEAlerta As BE_Alertas, ByVal pi_strUsuario As String) As String
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@OrdenAsignada"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_OrdenAsignada.GetType)
                .strSourceColumn = pi_BEMaquina.str_OrdenAsignada
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@EstadoMaquina"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMaquina.str_EstadoMaquina.GetType)
                .strSourceColumn = pi_BEMaquina.str_EstadoMaquina
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Usuario"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_strUsuario.GetType)
                .strSourceColumn = pi_strUsuario
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
                strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_U_Maquina_Asignacion_Anular", True, strReturn, liEnt_Parametro)

                If Not strParametroSalida = String.Empty Then strReturn = strParametroSalida
            Catch ex As Exception
                strReturn = String.Empty
            End Try

            Return strReturn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Insert_ExpedienteArchivo(ByVal pi_BEExpedienteArchivo As BE_ExpedienteArchivo) As String
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ExpedienteId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEExpedienteArchivo.intExpedienteId.GetType)
                .strSourceColumn = pi_BEExpedienteArchivo.intExpedienteId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@NombreArchivo"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEExpedienteArchivo.str_NombreArchivo.GetType)
                .strSourceColumn = pi_BEExpedienteArchivo.str_NombreArchivo
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ClaseId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEExpedienteArchivo.int_ClaseId.GetType)
                .strSourceColumn = pi_BEExpedienteArchivo.int_ClaseId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@Archivo"
                .typDbType = DbType.Binary
                .byteSourceColumn = pi_BEExpedienteArchivo.bin_Archivo
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@UsuarioCreacion"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEExpedienteArchivo.str_UsuarioCreacion.GetType)
                .strSourceColumn = pi_BEExpedienteArchivo.str_UsuarioCreacion
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim strReturn As String = String.Empty
            Dim strParametroSalida As String = String.Empty

            Try
                strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_I_ExpedienteArchivo", True, strReturn, liEnt_Parametro)
                If Not strParametroSalida = String.Empty Then strReturn = strParametroSalida
            Catch ex As Exception
                strReturn = String.Empty
            End Try

            Return strReturn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Select_Maquina_Asignadas() As List(Of BE_Maquina)
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            Dim liBEMaquina As New List(Of BE_Maquina)

            clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_Maquina_Asignadas", True, liBEMaquina, liEnt_Parametro)

            Return liBEMaquina
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Select_Maquina_ExpedienteBono(ByVal be_Maquina As BE_Maquina) As List(Of BE_Maquina)
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ExpedienteId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(be_Maquina.int_ExpedienteId.GetType)
                .strSourceColumn = be_Maquina.int_ExpedienteId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ClaseId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(be_Maquina.int_ClaseId.GetType)
                .strSourceColumn = be_Maquina.int_ClaseId
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim liBEMaquina As New List(Of BE_Maquina)

            clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_Maquina_ExpedienteBono", True, liBEMaquina, liEnt_Parametro)

            Return liBEMaquina

        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
