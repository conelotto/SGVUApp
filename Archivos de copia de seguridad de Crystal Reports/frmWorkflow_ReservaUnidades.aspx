<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master"
    CodeBehind="frmWorkflow_ReservaUnidades.aspx.vb" Inherits="SGCVU.frmWorkflow_ReservaUnidades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <%--Archivos Css--%>
    <link href="../Static/css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Static/css/jquery-ui.theme.css" rel="stylesheet" type="text/css" />
    <link href="../Static/css/ui.jqgrid.css" rel="stylesheet" type="text/css" />
    <link href="../Static/css/ui.jqgrid.custom.css" rel="stylesheet" type="text/css" />
    <link href="../Static/css/uploadfile.css" rel="stylesheet" type="text/css" />
    <%--Archivos js--%>
    <script src="../Static/js/jquery-1.11.1.min.js" type="text/javascript"></script>
    <script src="../Static/js/jquery.fileDownload.js" type="text/javascript"></script>
    <script src="../Static/js/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Static/js/jquery.ui.datepicker-es.js" type="text/javascript"></script>
    <script src="../Static/js/jquery.validate.min.js" type="text/javascript"></script>
    <script src="../Static/js/i18n/grid.locale-es.js" type="text/javascript"></script>
    <script src="../Static/js/jquery.jqGrid.min.js" type="text/javascript"></script>
    <script src="../Static/js/jquery.contextmenu.js" type="text/javascript"></script>
    <script src="../Static/js/jquery.blockUI.js" type="text/javascript"></script>
    <script src="../Static/js/moment.min.js" type="text/javascript"></script>
    <script src="../Static/js/jquery.uploadfile.js" type="text/javascript"></script>
    <script src="../Static/js/utils.js" type="text/javascript"></script>
    <script src="Scripts/frmWorkflow_ReservaUnidades.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent1" runat="server">
    <div id="accordion_busqueda">
        <div class="lbl_TitleAccordion">
            Criterios de Busqueda
        </div>
        <div>
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <table width="0" border="0" cellpadding="5" cellspacing="0">
                            <tr>
                                <td class="lbl_Form">
                                    Cuenta
                                </td>
                                <td class="lbl_Form">
                                    :
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <input type="text" id="filtroCuenta" class="txt_input" value="" style="height: 17px;" />
                                    <input type="button" class="bnt_SearchFilter" id="btnFiltroCuenta"/>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="lbl_Form">
                                    Marca
                                </td>
                                <td class="lbl_Form">
                                    :
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <input type="text" id="filtroMarca" class="txt_input" value="" style="height: 17px;" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="lbl_Form">
                                    Modelo
                                </td>
                                <td class="lbl_Form">
                                    :
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <input type="text" id="filtroModelo" class="txt_input" value="" style="height: 17px;" />
                                    <input type="button" class="bnt_SearchFilter" id="btnFiltroModelo"/>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="lbl_Form">
                                    Orden
                                </td>
                                <td class="lbl_Form">
                                    :
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td colspan="6">
                                    <input type="text" id="filtroOrden" class="txt_input" value="" style="height: 17px;" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl_Form">
                                    Proyecto
                                </td>
                                <td class="lbl_Form">
                                    :
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <input type="text" id="filtroProyecto" class="txt_input" value="" style="height: 17px;" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="lbl_Form">
                                    Cliente
                                </td>
                                <td class="lbl_Form">
                                    :
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <input type="text" id="filtroCliente" class="txt_input" value="" style="height: 17px;" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="lbl_Form">
                                    Vendedor
                                </td>
                                <td class="lbl_Form">
                                    :
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <input type="text" id="filtroVendedor" class="txt_input" value="" style="height: 17px;" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="lbl_Form">
                                    Proceso
                                </td>
                                <td class="lbl_Form">
                                    :
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td colspan="6">
                                    <input type="text" id="filtroProceso" class="txt_input" value="" style="height: 17px;" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="10">
                                    <fieldset>
                                        <legend>Fecha Estimada de Ingreso</legend>
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="lbl_Form">
                                                    Desde
                                                </td>
                                                <td class="lbl_Form">
                                                    :
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <input id="filtroFechaDesde" type="text" class="txt_input" style="height: 17px;" />
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td class="lbl_Form">
                                                    Hasta
                                                </td>
                                                <td class="lbl_Form">
                                                    :
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <input id="filtroFechaHasta" type="text" class="txt_input" style="height: 17px;" />
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                </td>
                                <td class="lbl_Form">
                                    Antiguamiento
                                </td>
                                <td class="lbl_Form">
                                    :
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <select id="filtroSemaforo" multiple="multiple" style="min-width: 120px;">
                                        <option value="B1"> 0-3 meses </option>
                                        <option value="B2"> 4-6 meses </option>
                                        <option value="R"> 7-12 meses </option>
                                        <option value="M"> > 13 meses </option>
                                    </select>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="lbl_Form">
                                    Estado
                                </td>
                                <td class="lbl_Form">
                                    :
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <select id="filtroEstado" multiple="multiple" style="min-width: 150px;"></select>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="lbl_Form">
                                    Ubicación
                                </td>
                                <td class="lbl_Form">
                                    :
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <input type="text" id="filtroUbicacion" class="txt_input" value="" style="height: 17px;" />
                                    <input type="button" class="bnt_SearchFilter" id="btnFiltroUbicacion"/>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <input id="txthdValStatus" type="hidden" value="" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <table width="0" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <input type="button" onclick="gridMaquinasReload(false, true)" class="bnt_SearchRecord" title="Consultar" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <input type="button" onclick="limpiarFiltros()" class="bnt_CleanSearch" title="Limpiar Filtros" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <input type="button" onclick="descargar()" class="bnt_ExportExcel" title="Exportar a Excel" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>

    <%--<div id="fileuploader"></div>--%>

    <div>
        <br />
        <table width="100%">
            <tr>
                <td>
                    <input id="btnAnularReservaMasiva" type="button" class="btn" value="Anular Reserva Masiva" />
                    <input id="btnSolicitarLevante" type="button" class="btn" value="Solicitar Levante" />
                </td>
                <td align="right">
                    <a class="btn" href="frmConsultaStock.aspx">Consultar Stock</a>
                </td>
            </tr>
        </table>
        <br />
    </div>

    <div id="gridMaqWrapper" style="overflow: auto">
        <table id="jqgMaquinas"></table>
        <div id="pagerMaquinas"></div>
        <div class="contextMenu" id="contextMenuMaquinas" style="display:none">
            <ul style="width: 150px; font-size: 65%;">
                <li id="crearReserva">
                    <span style="float:left"><img src="../Images/calendar.png" alt="" /></span>
                    <span style="font-size:100%; font-family:Verdana">Crear Reserva</span>
                </li>
                <li id="anularReserva">
                    <span style="float:left"><img src="../Images/anular.png" alt="" /></span>
                    <span style="font-size:100%; font-family:Verdana">Anular Reserva</span>
                </li>                  
                <li id="modificarUnidad">
                    <span style="float:left"><img src="../Images/editar.png" alt="" /></span>
                    <span style="font-size:100%; font-family:Verdana">Modificar</span>
                </li>           
            </ul>
        </div>
    </div>

    <div id="modalFiltroCuenta" title="Selección de Cuentas">
        <div>
            <table id="jqgCuentasFiltro"></table>
        </div>
    </div>

    <div id="modalFiltroModelo" title="Selección de Modelos">
        <div>
            <table id="jqgModelosFiltro"></table>
        </div>
    </div>

    <div id="modalFiltroUbicacion" title="Selección de Ubicaciones">
        <div>
            <table id="jqgUbicacionesFiltro"></table>
        </div>
    </div>

    <div id="modalReserva">
        <form id="frmReserva">
            <div>
                <table width="100%" border="0" cellpadding="5" cellspacing="0">
                    <tr>
                        <td class="lbl_Form" width="170px">
                            N° de Negociación
                        </td>
                        <td class="lbl_Form" style="width: 10px">
                            :
                        </td>
                        <td width="5px">
                            &nbsp;
                        </td>
                        <td width="150px">
                            <label id="lblNroNegReservaModal"></label>
                        </td>
                        <td width="5px">
                            &nbsp;
                        </td>
                        <td class="lbl_Form"  width="160px">
                            Estado de la Negociación
                        </td>
                        <td class="lbl_Form" style="width: 10px">
                            :
                        </td>
                        <td width="5px">
                            &nbsp;
                        </td>
                        <td align="right">
                            <div id="EstNegReservaModal" style="display:inline-block;margin-right:50px;"></div>
                            <div id="ContentBtnAnularReservaModal" style="display:inline-block;">
                                <input type="button" id="btnAnularReservaModal" class="bnt_UnValidated_small" title="Anular Reserva" />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="lbl_Form">
                            Fecha de Negociación
                        </td>
                        <td class="lbl_Form" style="width: 10px">
                            :
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <label id="lblFchNegReservaModal"></label>
                        </td>
                        <td colspan="5" align="right">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="lbl_Form">
                            Fecha límite de Reserva <span class="state-required"><b>*</b></span>
                        </td>
                        <td class="lbl_Form" style="width: 10px">
                            :
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <input type="hidden" autofocus="autofocus" />
                            <input id="fechaLimiteReservaModal" name="fechaLimiteReservaModal" type="text" class="txt_input" style="height: 17px;" />
                        </td>
                        <td colspan="5">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="lbl_Form">
                            Oportunidad
                        </td>
                        <td class="lbl_Form" style="width: 10px">
                            :
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <input id="txtOportunidadReservaModal" type="text" value="" />
                        </td>
                        <td colspan="5">
                            <input type="button" class="bnt_SearchFilter" id="btnBuscarOportunidadReserva"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="lbl_Form">
                            Cliente <span class="state-required"><b>*</b></span>
                        </td>
                        <td class="lbl_Form" style="width: 10px">
                            :
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <input id="txtClienteReservaModal" name="clienteReservaModal" type="text" value="" />
                        </td>
                        <td colspan="5" style="vertical-align: top;">
                            <input type="button" class="bnt_SearchFilter" id="btnBuscarClienteReserva"/>
                            <label id="lblClienteDescReservaModal" style="padding-left: 5px;"></label>
                        </td>
                    </tr>
                    <tr>
                        <td class="lbl_Form">
                            Vendedor <span class="state-required"><b>*</b></span>
                        </td>
                        <td class="lbl_Form" style="width: 10px">
                            :
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <input id="txtVendedorReservaModal" name="vendedorReservaModal" type="text" value="" />
                        </td>
                        <td colspan="5" style="vertical-align: top;">
                            <input type="button" class="bnt_SearchFilter" id="btnBuscarVendedorReserva"/>
                            <label id="lblVendedorDescReservaModal" style="padding-left: 5px;"></label>
                        </td>
                    </tr>
                    <tr>
                        <td class="lbl_Form">
                            Obervaciones
                        </td>
                        <td class="lbl_Form" style="width: 10px">
                            :
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td colspan="6">
                            <textarea id="txtObsReservaModal" rows="4" cols="75"></textarea>
                        </td>
                    </tr>
                    <tr>
                        <td class="lbl_Form">
                            Fecha Estimada de Ingreso
                        </td>
                        <td class="lbl_Form" style="width: 10px">
                            :
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <label id="lblFchEstIngReservaModal"></label>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td class="lbl_Form">
                            Fecha Ofrecida al Cliente
                        </td>
                        <td class="lbl_Form" style="width: 10px">
                            :
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <label id="lblFchOfreCliReservaModal"></label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            &nbsp;
                        </td>
                        <td colspan="6">
                            <label class="lbl_CountRecords">Nota: Las fechas Límite de Negociación y Estimada de Facturación se trasladan al día Lunes siguiente, si caen un día Sabado o Domingo.</label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="9">
                            <span class="state-required"><b>* Datos Obligatorios</b></span>
                        </td>
                    </tr>
                </table>
            </div>
        </form>
    </div>

    <div id="modalBuscarCliente">
        <div>
            <table border="0" cellpadding="5" cellspacing="0">
                <tr>
                    <td class="lbl_Form">
                        Código
                    </td>
                    <td class="lbl_Form">
                        :
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <input type="text" id="txtClienteIdModalBusCli" class="txt_input" value="" style="height: 17px; width: 70px;" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td class="lbl_Form">
                        Razón Social
                    </td>
                    <td class="lbl_Form">
                        :
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <input type="text" id="txtVendedorDescModalBusCli" class="txt_input" value="" style="height: 17px; width: 200px;" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <input type="button" id="btnBuscarClienteModalBuscar" class="bnt_SearchRecord" title="Buscar" />
                    </td>
                </tr>
            </table>
            <div>
                <table id="jqgClientes"></table>
                <div id="pagerClientes"></div>
            </div>
        </div>
    </div>

    <div id="modalBuscarVendedor">
        <div>
            <table border="0" cellpadding="5" cellspacing="0">
                <tr>
                    <td class="lbl_Form">
                        Código
                    </td>
                    <td class="lbl_Form">
                        :
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <input type="text" id="txtVendedorIdModalBusven" class="txt_input" value="" style="height: 17px; width: 70px;" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td class="lbl_Form">
                        Nombre y/o Apellido
                    </td>
                    <td class="lbl_Form">
                        :
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <input type="text" id="txtVendedorDescModalBusVen" class="txt_input" value="" style="height: 17px; width: 200px;" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <input type="button" id="btnBuscarVendedorModalBuscar" class="bnt_SearchRecord" title="Buscar" />
                    </td>
                </tr>
            </table>
            <div>
                <table id="jqgVendedores"></table>
                <div id="pagerVendedores"></div>
            </div>
        </div>
    </div>

    <div id="modalModificacion">
        <div>
            <table border="0" cellpadding="5" cellspacing="0">
                <tr>
                    <td class="lbl_Form" width="150px">
                        Versión
                    </td>
                    <td class="lbl_Form" style="width: 10px">
                        :
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td width="200px">
                        <input type="text" id="txtVersionModif" />
                    </td>
                </tr>
                <tr>
                    <td class="lbl_Form" width="150px">
                        Proyecto
                    </td>
                    <td class="lbl_Form" style="width: 10px">
                        :
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td width="200px">
                        <input type="text" id="txtProyectoModif" />
                    </td>
                </tr>
                <tr>
                    <td class="lbl_Form" width="150px">
                        Observaciones
                    </td>
                    <td class="lbl_Form" style="width: 10px">
                        :
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td width="200px">
                        <textarea id="txtObservacionesModif" rows="3" cols="40"></textarea>
                    </td>
                </tr>
                <tr id="rowEmparejamiento">
                    <td class="lbl_Form" width="150px">
                        Emparejamiento
                    </td>
                    <td class="lbl_Form" style="width: 10px">
                        :
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td width="200px">
                        <input type="text" id="txtModeloMaqEmp" placeholder="Ingrese el Modelo" />
                        <input type="button" class="bnt_SearchFilter" id="btnBuscarMaquinaEmp"/>
                    </td>
                </tr>
            </table>
            <br />
            <div id="gridMaqRelWrapper">
                <table id="jqgMaquinasRelacionadas"></table>
            </div>
        </div>
    </div>

    <div id="modalMaquinasEmparejamiento" title="Máquinas">
        <div>
            <table id="jqgMaquinasEmparejamiento"></table>
        </div>
    </div>

    <div id="modalInformacionUnidad">
        <div>
            <div id="tabsModalInfo">
                <ul>
		            <li><a href="#tabModalInfoUni">Información de la Unidad</a></li>
		            <li><a href="#tabModalNeg">Negociaciones</a></li>
	            </ul>
                <div id="tabModalInfoUni">
                    <div>
                        <table border="0" cellpadding="5" cellspacing="0">
                            <tr>
                                <td class="lbl_Form" width="200px">
                                    Orden
                                </td>
                                <td class="lbl_Form" style="width: 10px">
                                    :
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td width="200px">
                                    <label id="lblOrdenModalInfo"></label>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="lbl_Form" width="200px">
                                    Marca
                                </td>
                                <td class="lbl_Form" style="width: 10px">
                                    :
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td width="200px">
                                    <label id="lblMarcaModalInfo"></label>
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl_Form" width="200px">
                                    Modelo
                                </td>
                                <td class="lbl_Form" style="width: 10px">
                                    :
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td width="200px">
                                    <label id="lblModeloModalInfo"></label>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="lbl_Form" width="200px">
                                    Descripción de la Unidad
                                </td>
                                <td class="lbl_Form" style="width: 10px">
                                    :
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td width="200px">
                                    <label id="lblDescripcionModalInfo"></label>
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl_Form" width="200px">
                                    Familia de producto
                                </td>
                                <td class="lbl_Form" style="width: 10px">
                                    :
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td width="200px">
                                    <label id="lblFamiliaProdModalInfo"></label>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="lbl_Form" width="200px">
                                    Tipo de producto
                                </td>
                                <td class="lbl_Form" style="width: 10px">
                                    :
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td width="200px">
                                    <label id="lblTipoProdModalInfo"></label>
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl_Form" width="200px">
                                    Nro CAT / MSO / ESO
                                </td>
                                <td class="lbl_Form" style="width: 10px">
                                    :
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td width="200px">
                                    <label id="lblNroCatModalInfo"></label>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="lbl_Form" width="200px">
                                    Nro Serie de la Unidad
                                </td>
                                <td class="lbl_Form" style="width: 10px">
                                    :
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td width="200px">
                                    <label id="lblSerieUnidadModalInfo"></label>
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl_Form" width="200px">
                                    Año de Fabricación
                                </td>
                                <td class="lbl_Form" style="width: 10px">
                                    :
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td width="200px">
                                    <label id="lblAnioFabModalInfo"></label>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="lbl_Form" width="200px">
                                    Nro de Serie del Motor
                                </td>
                                <td class="lbl_Form" style="width: 10px">
                                    :
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td width="200px">
                                    <label id="lblSerieMotorModalInfo"></label>
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl_Form" width="200px">
                                    Cuenta
                                </td>
                                <td class="lbl_Form" style="width: 10px">
                                    :
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td width="200px">
                                    <label id="lblCuentaModalInfo"></label>
                                </td>
                                <td colspan="5">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl_Form" width="200px">
                                    División
                                </td>
                                <td class="lbl_Form" style="width: 10px">
                                    :
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td width="200px">
                                    <label id="lblDivisionModalInfo"></label>
                                </td>
                                <td colspan="5">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl_Form" width="200px">
                                    Condición
                                </td>
                                <td class="lbl_Form" style="width: 10px">
                                    :
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td width="200px">
                                    <label id="lblCondicionModalInfo"></label>
                                </td>
                                <td colspan="5">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                    <br />
                    <div>
                        <div id="accordionSegImpModalInfo">
	                        <h3>Seguimiento de Importación</h3>
	                        <div>
                                <table border="0" cellpadding="3" cellspacing="0">
                                    <tr>
                                        <td colspan="9">
                                            &nbsp;
                                        </td>
                                        <td class="lbl_Form">
                                            On Time
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="lbl_Form" width="200px">
                                            Nro de Factura de Fábrica
                                        </td>
                                        <td class="lbl_Form" style="width: 10px">
                                            :
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td width="200px">
                                            <label id="lblNroFacFabModalInfo"></label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td class="lbl_Form" width="200px">
                                            Fecha Colocación OC a Fábrica
                                        </td>
                                        <td class="lbl_Form" style="width: 10px">
                                            :
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td width="100px">
                                            <label id="lblfechaColFabModalInfo"></label>
                                        </td>
                                        <td class="lbl_Form">
                                            Acum (días)
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="lbl_Form" width="200px">
                                            Incoterm
                                        </td>
                                        <td class="lbl_Form" style="width: 10px">
                                            :
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td width="200px">
                                            <label id="lblIncotermModalInfo"></label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td class="lbl_Form" width="200px">
                                            Fecha Estimada Salida de Fábrica
                                        </td>
                                        <td class="lbl_Form" style="width: 10px">
                                            :
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td width="100px">
                                            <label id="lblFechaEstSalFabModalInfo"></label>
                                        </td>
                                        <td class="lbl_Form">
                                            <label id="lblTimeFechaEstSalFabModalInfo"></label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="lbl_Form" width="200px">
                                            Tipo de Embarque
                                        </td>
                                        <td class="lbl_Form" style="width: 10px">
                                            :
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td width="200px">
                                            <label id="lblTipoEmbModalInfo"></label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td class="lbl_Form" width="200px">
                                            Fecha de Salida de Fábrica (RTS)
                                        </td>
                                        <td class="lbl_Form" style="width: 10px">
                                            :
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td width="100px">
                                            <label id="lblFechaSalFabModalInfo"></label>
                                        </td>
                                        <td class="lbl_Form">
                                            <label id="lblTimeFechaSalFabModalInfo"></label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="lbl_Form" width="200px">
                                            Freight Forwarder
                                        </td>
                                        <td class="lbl_Form" style="width: 10px">
                                            :
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td width="200px">
                                            <label id="lblFreightForModalInfo"></label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td class="lbl_Form" width="200px">
                                            Fecha de Factura de Fábrica
                                        </td>
                                        <td class="lbl_Form" style="width: 10px">
                                            :
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td width="100px">
                                            <label id="lblFechaFacFabModalInfo"></label>
                                        </td>
                                        <td class="lbl_Form">
                                            <label id="lblTimeFechaFacFabModalInfo"></label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="lbl_Form" width="200px">
                                            Puerto de Salida
                                        </td>
                                        <td class="lbl_Form" style="width: 10px">
                                            :
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td width="200px">
                                            <label id="lblPuertoSalModalInfo"></label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td class="lbl_Form" width="200px">
                                            Fecha de Recepción Forwarder
                                        </td>
                                        <td class="lbl_Form" style="width: 10px">
                                            :
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td width="100px">
                                            <label id="lblFechaRecForModalInfo"></label>
                                        </td>
                                        <td class="lbl_Form">
                                            <label id="lblTimeFechaRecForModalInfo"></label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="lbl_Form" width="200px">
                                            Nro Documento de Embarque
                                        </td>
                                        <td class="lbl_Form" style="width: 10px">
                                            :
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td width="200px">
                                            <label id="lblNroDocEmbModalInfo"></label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td class="lbl_Form" width="200px">
                                            Fecha Estimada Embarque (ETD)
                                        </td>
                                        <td class="lbl_Form" style="width: 10px">
                                            :
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td width="100px">
                                            <label id="lblFechaEstEmbModalInfo"></label>
                                        </td>
                                        <td class="lbl_Form">
                                            <label id="lblTimeFechaEstEmbModalInfo"></label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="lbl_Form" width="200px">
                                            Buque
                                        </td>
                                        <td class="lbl_Form" style="width: 10px">
                                            :
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td width="200px">
                                            <label id="lblBuqueModalInfo"></label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td class="lbl_Form" width="200px">
                                            Fecha Estimada Arribo a Puerto
                                        </td>
                                        <td class="lbl_Form" style="width: 10px">
                                            :
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td width="100px">
                                            <label id="lblFechaEstArrPueModalInfo"></label>
                                        </td>
                                        <td class="lbl_Form">
                                            <label id="lblTimeFechaEstArrPueModalInfo"></label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="lbl_Form" width="200px">
                                            Agente de Aduana
                                        </td>
                                        <td class="lbl_Form" style="width: 10px">
                                            :
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td width="200px">
                                            <label id="lblAgenteAduModalInfo"></label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td class="lbl_Form" width="200px">
                                            Fecha de Arribo a Puerto
                                        </td>
                                        <td class="lbl_Form" style="width: 10px">
                                            :
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td width="100px">
                                            <label id="lblFechaArrPueModalInfo"></label>
                                        </td>
                                        <td class="lbl_Form">
                                            <label id="lblTimeFechaArrPueModalInfo"></label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="lbl_Form" width="200px">
                                            Tipo de Despacho
                                        </td>
                                        <td class="lbl_Form" style="width: 10px">
                                            :
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td width="200px">
                                            <label id="lblTipoDes"></label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td class="lbl_Form" width="200px">
                                            Fecha de Fin de Descarga
                                        </td>
                                        <td class="lbl_Form" style="width: 10px">
                                            :
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td width="100px">
                                            <label id="lblFechaFinDesModalInfo"></label>
                                        </td>
                                        <td class="lbl_Form">
                                            <label id="lblTimeFechaFinDesModalInfo"></label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="lbl_Form" width="200px">
                                            Póliza de Importación (DUA)
                                        </td>
                                        <td class="lbl_Form" style="width: 10px">
                                            :
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td width="200px">
                                            <label id="lblPolizaImpModalInfo"></label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td class="lbl_Form" width="200px">
                                            Fecha de Levante Aduanero
                                        </td>
                                        <td class="lbl_Form" style="width: 10px">
                                            :
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td width="100px">
                                            <label id="lblFechaLevAduModalInfo"></label>
                                        </td>
                                        <td class="lbl_Form">
                                            <label id="lblTimeFechaLevAduModalInfo"></label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="lbl_Form" width="200px">
                                            Régimen de Importación
                                        </td>
                                        <td class="lbl_Form" style="width: 10px">
                                            :
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td width="200px">
                                            <label id="lblRegimenImpModalInfo"></label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td class="lbl_Form" width="200px">
                                            Fecha Estimada de Ingreso Fisico
                                        </td>
                                        <td class="lbl_Form" style="width: 10px">
                                            :
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td width="100px">
                                            <label id="lblFechaEstIngFisModalInfo"></label>
                                        </td>
                                        <td class="lbl_Form">
                                            <label id="lblTimeFechaEstIngFisModalInfo"></label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="lbl_Form" width="200px">
                                            Venta con Endose de Documentos
                                        </td>
                                        <td class="lbl_Form" style="width: 10px">
                                            :
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td width="200px">
                                            <label id="lblVentaEndDocModalInfo"></label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td class="lbl_Form" width="200px">
                                            Fecha de Ingreso Fisico
                                        </td>
                                        <td class="lbl_Form" style="width: 10px">
                                            :
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td width="100px">
                                            <label id="lblFechaIngFisModalInfo"></label>
                                        </td>
                                        <td class="lbl_Form">
                                            <label id="lblTimeFechaIngFisModalInfo"></label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="lbl_Form" width="200px">
                                            Transportista Asignado
                                        </td>
                                        <td class="lbl_Form" style="width: 10px">
                                            :
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td width="200px">
                                            <label id="lblTransportistaAsiModalInfo"></label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td class="lbl_Form" width="200px">
                                            Unidad Fecha Entrega a Taller
                                        </td>
                                        <td class="lbl_Form" style="width: 10px">
                                            :
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td width="100px">
                                            <label id="lblUnidadFecEntTalModalInfo"></label>
                                        </td>
                                        <td class="lbl_Form">
                                            <label id="lblTimeUnidadFecEntTalModalInfo"></label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="lbl_Form" width="200px">
                                            País de Origen
                                        </td>
                                        <td class="lbl_Form" style="width: 10px">
                                            :
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td width="200px">
                                            <label id="lblPaisOriModalInfo"></label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td class="lbl_Form" width="200px">
                                            Unidad Fecha Salida de Taller
                                        </td>
                                        <td class="lbl_Form" style="width: 10px">
                                            :
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td width="100px">
                                            <label id="lblUnidadFecSalTalModalInfo"></label>
                                        </td>
                                        <td class="lbl_Form">
                                            <label id="lblTimeUnidadFecSalTalModalInfo"></label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="lbl_Form" width="200px">
                                            Cubic Meters (M3)
                                        </td>
                                        <td class="lbl_Form" style="width: 10px">
                                            :
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td width="200px">
                                            <label id="lblCubicMetModalInfo"></label>
                                        </td>
                                        <td colspan="7">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                                <hr />
                                <table border="0" cellpadding="3" cellspacing="0">
                                    <tr>
                                        <td class="lbl_Form" width="200px">
                                            Préstamo
                                        </td>
                                        <td class="lbl_Form" style="width: 10px">
                                            :
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td width="200px">
                                            <label id="lblPrestamoModalInfo"></label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="lbl_Form" width="200px">
                                            Observaciones
                                        </td>
                                        <td class="lbl_Form" style="width: 10px">
                                            :
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td width="200px">
                                            <label id="lblObservacionesModalInfo"></label>
                                        </td>
                                    </tr>
                                </table>
                                <hr />
                                <table border="0" cellpadding="3" cellspacing="0">
                                    <tr>
                                        <td class="lbl_Form" width="200px">
                                            Cliente
                                        </td>
                                        <td class="lbl_Form" style="width: 10px">
                                            :
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td width="200px">
                                            <label id="lblClienteModalInfo"></label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div id="accordionInfInvModalInfo">
	                        <h3>Información de Inventario</h3>
	                        <div>
                                <table border="0" cellpadding="3" cellspacing="0">
                                    <tr>
                                        <td class="lbl_Form" width="200px">
                                            Antiguamiento
                                        </td>
                                        <td class="lbl_Form" style="width: 10px">
                                            :
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td width="200px">
                                            <label id="lblAntiguamientoModalInfo"></label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td class="lbl_Form" width="200px">
                                            Ubicación
                                        </td>
                                        <td class="lbl_Form" style="width: 10px">
                                            :
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td width="200px">
                                            <label id="lblUbicacionModalInfo"></label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="lbl_Form" width="200px">
                                            Días en Inv. desde Salida Fábrica
                                        </td>
                                        <td class="lbl_Form" style="width: 10px">
                                            :
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td width="200px">
                                            <label id="lblDiasInvSalFabModalInfo"></label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td class="lbl_Form" width="200px">
                                            Bahía
                                        </td>
                                        <td class="lbl_Form" style="width: 10px">
                                            :
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td width="200px">
                                            <label id="lblBahia"></label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="lbl_Form" width="200px">
                                            Días en Inv. desde Levante
                                        </td>
                                        <td class="lbl_Form" style="width: 10px">
                                            :
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td width="200px">
                                            <label id="lblDiasInvLevModalInfo"></label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td class="lbl_Form" width="200px">
                                            Store
                                        </td>
                                        <td class="lbl_Form" style="width: 10px">
                                            :
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td width="200px">
                                            <label id="lblStore"></label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="lbl_Form" width="200px">
                                            Días desde colocada OC a Fábrica
                                        </td>
                                        <td class="lbl_Form" style="width: 10px">
                                            :
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td width="200px">
                                            <label id="lblDiasColFab"></label>
                                        </td>
                                        <td colspan="5">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div id="accordionDatTecModalInfo">
	                        <h3>Datos Técnicos</h3>
	                        <div>
                                <table border="0" cellpadding="3" cellspacing="0">
                                    <tr>
                                        <td class="lbl_Form" width="200px">
                                            Horometro
                                        </td>
                                        <td class="lbl_Form" style="width: 10px">
                                            :
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td width="200px">
                                            <label id="lblHorometroModalInfo"></label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td class="lbl_Form" width="200px">
                                            Fecha Últ. Lectura Horómetro
                                        </td>
                                        <td class="lbl_Form" style="width: 10px">
                                            :
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td width="200px">
                                            <label id="lblFechaUltLecHorModalInfo"></label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="lbl_Form" width="200px">
                                            Indicador NPI
                                        </td>
                                        <td class="lbl_Form" style="width: 10px">
                                            :
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td width="200px">
                                            <input type="checkbox" id="chkIndicadorNPIModalInfo" />
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td class="lbl_Form" width="200px">
                                            Ubicación del Equipo
                                        </td>
                                        <td class="lbl_Form" style="width: 10px">
                                            :
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td width="200px">
                                            <label id="lblUnicacionEquModalInfo"></label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="lbl_Form" colspan="9">
                                            <h4>Arreglo de Máquina</h4>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="lbl_Form" width="200px">
                                            Número de Serie del Motor
                                        </td>
                                        <td class="lbl_Form" style="width: 10px">
                                            :
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td width="200px">
                                            <label id="lblNroSerMotModalInfo"></label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td class="lbl_Form" width="200px">
                                            Arreglo del Motor
                                        </td>
                                        <td class="lbl_Form" style="width: 10px">
                                            :
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td width="200px">
                                            <label id="lblArregloMotModalInfo"></label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="lbl_Form" width="200px">
                                            Marca del Motor
                                        </td>
                                        <td class="lbl_Form" style="width: 10px">
                                            :
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td width="200px">
                                            <label id="lblMarcaMotModalInfo"></label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td class="lbl_Form" width="200px">
                                            Modelo del Motor
                                        </td>
                                        <td class="lbl_Form" style="width: 10px">
                                            :
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td width="200px">
                                            <label id="lblModeloMotModalInfo"></label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div id="accordionConUniModalInfo">
                            <h3>Configuración de la Unidad</h3>
	                        <div>
                                <table id="jqgConfiguracionUnidad"></table>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="tabModalNeg">
                    <h3>Unidad</h3>
                    <div>
                        <table border="0" cellpadding="5" cellspacing="0">
                            <tr>
                                <td class="lbl_Form" width="200px">
                                    Descripción de la Unidad
                                </td>
                                <td class="lbl_Form" style="width: 10px">
                                    :
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td width="200px">
                                    <label id="lblDescripcionModalNeg"></label>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="lbl_Form" width="200px">
                                    Nro Serie de la Unidad
                                </td>
                                <td class="lbl_Form" style="width: 10px">
                                    :
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td width="200px">
                                    <label id="lblSerieUnidadModalNeg"></label>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="lbl_Form" width="200px">
                                    Nro CAT / MSO / ESO
                                </td>
                                <td class="lbl_Form" style="width: 10px">
                                    :
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td width="200px">
                                    <label id="lblNroCatModalNeg"></label>
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl_Form" width="200px">
                                    División
                                </td>
                                <td class="lbl_Form" style="width: 10px">
                                    :
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td width="200px">
                                    <label id="lblDivisionModalNeg"></label>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="lbl_Form" width="200px">
                                    Cuenta
                                </td>
                                <td class="lbl_Form" style="width: 10px">
                                    :
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td width="200px">
                                    <label id="lblCuentaModalNeg"></label>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="lbl_Form" width="200px">
                                    Año de Fabricación
                                </td>
                                <td class="lbl_Form" style="width: 10px">
                                    :
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td width="200px">
                                    <label id="lblAnioFabModalNeg"></label>
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl_Form" width="200px">
                                    Proveedor
                                </td>
                                <td class="lbl_Form" style="width: 10px">
                                    :
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td width="200px">
                                    <label id="lblProveedorModalNeg"></label>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="lbl_Form" width="200px">
                                    Ubicación
                                </td>
                                <td class="lbl_Form" style="width: 10px">
                                    :
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td width="200px">
                                    <label id="lblUbicacionModalNeg"></label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <h3>Negociaciones</h3>
                    <div>
                        <input type="radio" name="rdEstadoNegociacion" value="1" /> Ver sólo Negociaciones activas
                        <input type="radio" name="rdEstadoNegociacion" value="0" /> Ver todas las Negociaciones
                        <br /><br />
                        <table id="jqgNegociaciones"></table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>