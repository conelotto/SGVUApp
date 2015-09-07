<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master"
    CodeBehind="frmResultado.aspx.vb" Inherits="SGCVU.frmResultado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../Static/css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Static/css/jquery-ui.theme.css" rel="stylesheet" type="text/css" />
    <link href="../Static/css/ui.jqgrid.css" rel="stylesheet" type="text/css" />
    <link href="../Static/css/ui.jqgrid.custom.css" rel="stylesheet" type="text/css" />
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
    <script src="../Static/js/utils.js" type="text/javascript"></script>
    <script src="Scripts/frmResultado.js" type="text/javascript"></script>
    <style type="text/css">
        .style14
        {
            font-family: Verdana;
            font-size: 11px;
            color: #333333;
            font-style: normal;
            font-weight: normal;
            text-align: left;
            padding-top: 0px;
            padding-bottom: 0px;
            padding-right: 0px;
            padding-left: 1px;
            vertical-align: middle;
            width: 115px;
        }
        .style15
        {
            font-family: Verdana;
            font-size: 11px;
            color: #333333;
            font-style: normal;
            font-weight: normal;
            text-align: left;
            padding-top: 0px;
            padding-bottom: 0px;
            padding-right: 0px;
            padding-left: 1px;
            vertical-align: middle;
            width: 114px;
        }
        .style16
        {
            font-family: Verdana;
            font-size: 11px;
            color: #333333;
            font-style: normal;
            font-weight: normal;
            text-align: left;
            padding-top: 0px;
            padding-bottom: 0px;
            padding-right: 0px;
            padding-left: 1px;
            vertical-align: middle;
            width: 113px;
        }
        .style18
        {
            width: 46px;
        }
        .style19
        {
            width: 211px;
        }
        .style21
        {
            width: 224px;
        }
        .style22
        {
            width: 352px;
        }
        .style23
        {
            width: 198px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent1" runat="server">
    <br />
    <div id="accordion_busqueda">
        <div class="lbl_TitleAccordion">
            Criterios de Busqueda
        </div>
        <div>
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="lbl_Form">
                        Sucursal
                    </td>
                    <td class="lbl_Form">
                        :
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td >
                        <input type="text" id="txtSucursal" value="" style="height: 17px;" />
                    </td>
                    <td class="lbl_Form">
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
                    <td class="lbl_Form">
                        <input type="text" id="txtMarca" value="" style="height: 17px;" />
                    </td>
                    <td class="lbl_Form">
                        &nbsp;
                    </td>
                    <td class="lbl_Form">
                        Modelo
                    </td>
                    <td class="lbl_Form">
                        :
                    </td>
                    <td class="lbl_Form">
                        &nbsp;
                    </td>
                    <td class="lbl_Form">
                        <input type="text" id="txtModelo" value="" style="height: 17px;" />
                    </td>
                    <td class="lbl_Form">
                        &nbsp;
                    </td>
                    <td class="lbl_Form">
                        Semáforo
                    </td>
                    <td class="lbl_Form">
                        :
                    </td>
                    <td class="lbl_Form">
                        &nbsp;
                    </td>
                    <td class="lbl_Form">
                        <input name="rbSemaforo" type="radio" value="1" /><label for="rbBien">Bien</label><br />
                        <input  name="rbSemaforo" type="radio" value="2" /><label for="rbRegular">Regular</label>
                        <br />
                        <input name="rbSemaforo" type="radio" value="3" /><label for="rbMal">Mal</label>
                    </td>
                    <td class="lbl_Form">
                        &nbsp;
                    </td>
                    <td class="lbl_Form">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="lbl_Form">
                        Orden
                    </td>
                    <td class="lbl_Form">
                        :
                    </td>
                    <td class="lbl_Form">
                        &nbsp;
                    </td>
                    <td class="style18">
                        <input type="text" id="txtOrden" value="" style="height: 17px;" />
                    </td>
                    <td class="lbl_Form">
                        &nbsp;
                    </td>
                    <td class="lbl_Form">
                        Cliente
                    </td>
                    <td class="lbl_Form">
                        :
                    </td>
                    <td class="lbl_Form">
                        &nbsp;
                    </td>
                    <td class="lbl_Form">
                        <input type="text" id="txtClienteFiltro" value="" style="height: 17px;" />
                    </td>
                    <td class="lbl_Form">
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
                    <td class="lbl_Form">
                        <input type="text" id="txtVendedor" value="" style="height: 17px;" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td class="lbl_Form">
                        Actividad
                    </td>
                    <td>
                        :
                    </td>
                    <td class="lbl_Form">
                        &nbsp;
                    </td>
                    <td class="lbl_Form">
                        <select id="ddlActividad" style="width: 150px" name="D1">
                        </select>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>               
                <tr>
                    <td class="lbl_Form">
                        Estado</td>
                    <td class="lbl_Form">
                        :</td>
                    <td class="lbl_Form">
                        &nbsp;</td>
                    <td class="style18">
                        <select id="ddlEstado" style="width: 150px" name="D2">
                        </select></td>
                    <td class="lbl_Form">
                        &nbsp;</td>
                    <td class="lbl_Form" colspan="8">
                        <fieldset>
                            <legend>Fecha Estimada de Ingreso</legend>
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        Desde
                                    </td>
                                    <td>
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
                                    <td>
                                        Hasta
                                    </td>
                                    <td>
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
                        </fieldset></td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>               
                <tr>
                    <td class="lbl_Form">
                        &nbsp;</td>
                    <td class="lbl_Form">&nbsp;</td>
                    <td class="lbl_Form">
                        &nbsp;</td>
                    <td class="lbl_Form">&nbsp;</td>
                    <td class="lbl_Form">
                        &nbsp;</td>
                    <td class="lbl_Form">
                        &nbsp;</td>
                    <td class="lbl_Form" >
                        </td>
                   
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <input type="button" class="bnt_SearchRecord" onclick="gridMaquinasReload(false, true)"
                            title="Consultar" id="btnConsultar" />
                    </td>
                    <td>
                        <input type="button" onclick="LimpiarBandeja()" class="bnt_CleanSearch" title="Limpiar Filtros" />
                    </td>
                </tr>
           <%-- </table><tr>
            &nbsp;</td>
            <td>
                &nbsp;
            </td>
            <td class="style13">
                &nbsp;
            </td>
            <td class="style11">
                &nbsp;
            </td>
            <td class="style12">
                &nbsp;
            </td>
            <td class="style7">
                &nbsp;
            </td>
            <td class="style8">
                &nbsp;
            </td>
            <td class="style18">
                &nbsp;
            </td>
            <td align="right" class="style22">
                &nbsp;
            </td>
            <td align="right" class="style24">
                &nbsp;
            </td>
            <td align="right">
                &nbsp;
            </td>
            <td align="right">
                &nbsp;
            </td>
            </tr>--%>
            <%--  <tr>
              <td class="style3" colspan="3">
                  <label class="lbl_TitleGrid">
                            Detalle:</label>&nbsp;
                        <asp:Label ID="lblCountRecords" runat="server" Text="CountRecord" Visible="false"
                            CssClass="lbl_CountRecords"></asp:Label></td>
              <td class="style11">
                  &nbsp;</td>
              <td class="style12">
                  &nbsp;</td>
              <td class="style7">
                  &nbsp;</td>
              <td class="style8">
                  &nbsp;</td>
              <td class="style18">
                  &nbsp;</td>
              <td align="right" class="style22">
                  &nbsp;</td>
              <td align="right" class="style24">
                  &nbsp;</td>
              <td align="right">
                  &nbsp;</td>
              <td align="right">
                  &nbsp;</td>
          </tr>--%>
            </table>
        </div>
    </div>

    
    <div>
        <br />
        <table width="100%">
            <tr>
                <td>
                    <input id="_btnNuevaFactura" type="button" class="btn" value="Nueva Factura" onclick="NuevaFacturaManual();" />                    
                </td>                
            </tr>
        </table>
        <br />
    </div>   
    <div id="grid" style="overflow: auto">
        <table id="jqgMaquinas">
        </table>
        <div id="pagerMaquinas">
        </div>
        <div class="contextMenu" id="contextMenuMaquinas" style="display: none">
            <ul style="width: 150px; font-size: 65%;">
                <li id="IngresarComentario"><span style="float: left">
                    <img src="../Images/calendar.png" alt="" /></span> <span style="font-size: 100%;
                        font-family: Verdana">Observaciones</span> </li>
                <li id="ImporteBonos"><span style="float: left">
                    <img src="../Images/anular.png" alt="" /></span> <span style="font-size: 100%; font-family: Verdana">
                        Ingresar Importes Bonos</span> </li>
                <li id="modificarFactura"><span style="float: left">
                    <img src="../Images/editar.png" alt="" /></span> <span style="font-size: 100%; font-family: Verdana">
                        Modificar</span> </li>
            </ul>
        </div>
    </div>
    <br />
    <div id="modalObservacion">
        <table class="lbl_Form">
            <tr>
                <td class="style14" colspan="2">
                    Observaciones
                </td>
            </tr>
            <tr>
                <td width="300px">
                    <textarea id="txtObservacion" style="width: 360px; height: 50px;"></textarea>
                </td>
            </tr>
        </table>
    </div>
    <div id="modalModificacion" style="display: none">
        <table class="lbl_Form">
            <tr>
                <td class="style14" colspan="2">
                    Bono de repuesto
                </td>
            </tr>
            <tr>
                <td class="style15">
                    Importe
                </td>
                <td class="style16">
                    <input type="text" id="txtImporteRpto" value="" style="height: 17px;" />
                </td>
            </tr>
            <tr>
                <td class="style15">
                    Bono Ritmo5
                </td>
                <td class="style16">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style15">
                    Tipo
                </td>
                <td class="style16">
                    <label for="lblTipo" id="lblTipo">
                    </label>
                </td>
            </tr>
            <tr>
                <td class="style15">
                    Importe
                </td>
                <td class="style16">
                    <input type="text" id="txtImporteRitmo5" value="" style="height: 17px;" />
                </td>
            </tr>
        </table>
    </div>
    <div id="modalIncidente">
        <div>
            <div id="accordion_incidencia">
                <div class="lbl_TitleAccordion">                   
                    <label id="lblTituloIncidencia"></label>
                </div>
                <div>
                    <table border="0" cellpadding="0" cellspacing="2">
                        <tr>
                            <td>
                                N° Expediente
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <label id="lblExpedienteId">
                                </label>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                Fecha Creación
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <label id="lblFechaCreacion">
                                </label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Cliente Facturación
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <label id="lblClienteFacturacion">
                                </label>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                Cliente Final
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <label id="lblClienteFinal">
                                </label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Entidad Financiera
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <label id="lblEntidadFinanciera">
                                </label>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                Tipo Financiamiento
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <label id="lblTipoFinanciamiento">
                                </label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Vendedor
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <label id="lblVendedor">
                                </label>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                Financiamiento
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <label id="lblFinanciamiento">
                                </label>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <br />
            <div>
                <table id="jqgIncidencia">
                </table>
                <div class="contextMenu" id="contextMenuIncidencia" style="display: none">
                    <ul style="width: 150px; font-size: 65%;">
                        <li id="RegistroImporteBonos"><span style="float: left">
                            <img src="../Images/calendar.png" alt="" /></span> <span style="font-size: 100%;
                                font-family: Verdana">Registrar Importe Bonos</span> </li>
                    </ul>
                </div>
            </div>
        </div>
        <br />
        <div id="accordion_archivos">
            <div class="lbl_TitleAccordion">
                Archivos Adjuntos
            </div>
            <div>
                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="lbl_Form">
                    <tr>
                        <td class="style19">
                            &nbsp;&nbsp;
                            <input id="btnBonoRpto" type="button" class="btn" value="Ver Carta Bono Rpto." onclick="DescargarBono(1)"        />&nbsp;
                        </td>
                        <td class="style23">
                            <input id="btnBonoRptoFirmada" type="button" class="btn" value="Ver Carta Bono Rpto. Firmada"
                                    onclick="IrBandeja()" href="" /></td>
                        <td class="style21">
                            &nbsp;<input id="ulBonoRpto" type="file" name="files[]0" multiple /><output id="listUploadBR"></output></td>
                        <td class="style22">
                            ¿Tiene archivo Físico?<br />
                           <label id="lblBonoRpto"><input id="chkBonoRpto" type="checkbox"/>Bono Rpto.</label></td> 
                    </tr>
                    <tr>
                        <td class="style19">
                            &nbsp;
                            <input id="btnBonoRitmo5" type="button" class="btn" value="Ver Carta Bono CSA"
                                onclick="DescargarBono(2)"  /></td>
                        <td class="style23">
                            <input id="btnBonoRitmoFirmada" type="button" class="btn"
                                    value="Ver Carta Bono CSA Firmada" onclick="IrBandeja()" href="" /></td>
                        <td class="style21">
                            &nbsp;<input id="ulBonoCSA" type="file" name="files[]1" multiple /><output id="listUploadBCSA"></output></td>
                        <td class="style22">
                            <label id="lblBonoCSA"><input id="chkBonoCSA" type="checkbox"/>Bono CSA.</label>&nbsp;</td>
                    </tr>
                </table>
            </div>
        </div>
        <br />
        <div id="accordion_Actividades">
            <div class="lbl_TitleAccordion">
                Actividades realizadas
            </div>
            <div>
                <table id="jqgActividades">
                </table>
            </div>
            <div id="pagerActividades">
            </div>
        </div>
        <br />
        
                <input type="button" class="bnt_Devolver" title="Devolver actividad" id="btnDevolver"
            name="btnDevolver" onclick="AnteriorActividad();" />
        <input type="button" class="bnt_Aprobar" title="Aprobar actividad" id="btnAprobar"
            name="btnAprobar" onclick="SiguienteActividad();" />
       

    </div>
    <div id="modalVendedores">
        <div>
            <div id="accordion_vendedores">
                <div class="lbl_TitleAccordion">
                    Vendedores
                </div>
                <div>
                    <table id="jqgVendedores">
                    </table>
                </div>
            </div>
        </div>
    </div>
    <div id="modalFactura">
        <div>
            <div id="accordion_factura">
                <div class="lbl_TitleAccordion">
                    Registro de Orden Manual
                </div>
                <div>
                    <br />
                    <table border="0" cellpadding="2" cellspacing="0" class="lbl_Form">
                        <tr>
                            <td>
                                Orden:
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <input type="text" id="txtNroOrdenF" value="" style="height: 17px" />
                            </td>
                            <td>
                                Factura Sunat Electrónica
                            </td>
                            <td>
                                :
                            </td>
                            <td colspan="7">
                                <input type="checkbox" name="chkFacturaElectronica" value="1" id="chkFacturaElectronica">Tipo:
                                <input type="text" id="txtTipo" value="" style="height: 17px; width: 35px" />
                                Serie:
                                <input type="text" id="txtSerie" value="" style="height: 17px; width: 35px" 
                                    maxlength="3" onkeypress="return SoloNumeros(event)" />
                                Nro.:
                                <input type="text" id="txtNro" value="" style="height: 17px; width: 35px" 
                                    onChange="MostrarDatosCliente()" maxlength="4" onkeypress="return SoloNumeros(event)" />
                                Fecha Factura:
                                <input type="text" id="txtFechaFactura" value="" style="height: 17px; width: 90px"  />
                                No tiene Nro. Orden:<input type="checkbox" name="chkTieneOrden" value="1" id="chkTieneOrden">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Vendedor
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <input type="text" id="txtVendedorF" value="" style="height: 17px" />
                            </td>
                            <td>
                                Nombre
                            </td>
                            <td>
                                :
                            </td>
                            <td colspan="4">
                                <input type="text" id="txtNombreVendedorF" value="" style="height: 17px; width: 400px;" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Cliente
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <input type="text" id="txtCliente" value="" style="height: 17px" /></td>
                            <td>
                                Nombre
                            </td>
                            <td>
                                :
                            </td>
                            <td colspan="4">
                                <input type="text" id="txtNombreCliente" value="" style="height: 17px; width: 400px;" /></td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Cliente Facturación</td>
                            <td>
                                :</td>
                            <td>
                                <input type="text" id="txtClienteF" value="" style="height: 17px" /></td>
                            <td>
                                Nombre</td>
                            <td>
                                :</td>
                            <td colspan="4">
                                <input type="text" id="txtNombreClienteF" value="" style="height: 17px; width: 400px;" /></td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                Entidad
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <input type="text" id="txtEntidadFinancieraF" value="" style="height: 17px" />
                            </td>
                            <td>
                                Nombre
                            </td>
                            <td>
                                :
                            </td>
                            <td colspan="4">
                                <input type="text" id="txtNombreEntidadFinancieraF" value="" style="height: 17px;
                                    width: 400px;" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Cuenta
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <input type="text" id="txtCuentaF" value="" style="height: 17px" />
                            </td>
                            <td>
                                Nombre
                            </td>
                            <td>
                                :
                            </td>
                            <td colspan="4">
                                <input type="text" id="txtDescripcionCuentaF" value="" style="height: 17px; width: 400px;" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Sucursal
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <input type="text" id="txtSucursalF" value="" style="height: 17px" />
                            </td>
                            <td>
                                Descripción
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <input type="text" id="txtDescripcionSucursalF" value="" style="height: 17px" />
                            </td>
                            <td>
                                Financiamiento
                                <td>
                                    :
                                </td>
                                <td>
                                    <input type="text" id="txtFinanciamientoF" value="" style="height: 17px" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                        </tr>
                        <tr>
                            <td>
                                Familia
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <input type="text" id="txtFamilaF" value="" style="height: 17px" />
                            </td>
                            <td>
                                Marca
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <input type="text" id="txtMarcaF" value="" style="height: 17px" />
                            </td>
                            <td>
                                Modelo Id Generico
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <input type="text" id="txtModeloIdGenericoF" value="" style="height: 17px" />
                            </td>
                            <td>
                                Número Serie
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <input type="text" id="txtNumeroSerieF" value="" style="height: 17px" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Ritmo 5
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <input type="checkbox" id="chkRitmo5F" name="chkRitmo5F" value="Milk" onclick="ActivaInactivaRitmo5();">
                            </td>
                            <td>
                                Monto Ritmo 5
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <input id="txtMontoRitmo5F" style="height: 17px" type="text" value="" />
                            </td>
                            <td>
                                Tipo Ritmo 5
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <input type="text" id="txtTipoRitmo5F" value="" style="height: 17px" />
                            </td>
                            <td>
                                Id Sap Ritmo 5
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <input type="text" id="txtIdSapRitmo5F" value="" style="height: 17px" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Bono Repuesto
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <input type="checkbox" id="chkRepuesto" name="chkRepuesto" value="Milk" onclick="ActivaInactivaRpto();" />
                            </td>
                            <td>
                                Monto Bono Repuesto
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <input type="text" id="txtMontoRpto" value="" style="height: 17px" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td colspan="4">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Comentario
                            </td>
                            <td>
                                :
                            </td>
                            <td colspan="4">
                                <textarea id="txtObservacionF" style="width: 400px; height: 50px;" cols="20" name="S1"
                                    rows="1"></textarea>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td colspan="4">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Archivo Sustento
                            </td>
                            <td>
                                :
                            </td>
                            <td colspan="4">
<%--                                <input id="fileUpload" type="file" />--%>
                                <input id="upload" type="file" name="files[]" multiple />
                                <output id="listUpload"></output>
                                <td><input id="btnArchivo" type="button" onclick="DescargarArchivo()" class="bnt_Export"
                                        title="Descargar" /></td>
                                 
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td colspan="3">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
    &nbsp;
    <input id="hdnIdOrden" type="hidden" />
    <input id="hdnIdIncidente" type="hidden" />
    <input id="hdnExpedienteId" type="hidden" />
    <input id="hdnClienteFacturacion" type="hidden" />
    <input id="hdnClienteFinal" type="hidden" />
    <input id="hdnEntidadFinanciera" type="hidden" />
    <input id="hdnTipoFinanciamiento" type="hidden" />
    <input id="hdnVendedor" type="hidden" />
    <input id="hdnFinanciamiento" type="hidden" />
    <input id="hdnNuevaFactura" value="0" type="hidden" />
    <input id="hdnActividadActual" value="0" type="hidden" />
    <input id="hdnActividadAnterior" value="0" type="hidden" />
    <input id="hdnEsRitmo5" value="0" type="hidden" />
    <input id="hdnEsRpto" value="0" type="hidden" />
    <input id="hdnTieneRitmo5" value="0" type="hidden" />
    <input id="hdnTieneRpto" value="0" type="hidden" />
    <input id="hdnArchivos" value="" type="hidden" />
    <input id="hdnArchivoBonoFirmado" value="" type="hidden" />
    <input id="hdnArchivoCSAFirmado" value="" type="hidden" />
    <input id="hdnOrdenAsignada" type="hidden" value="" />
    <input id="hdnTieneArchivo" type="hidden" value="0" />
    </asp:Content>
