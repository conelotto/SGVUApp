<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master"
    CodeBehind="frmTipoFlujo.aspx.vb" Inherits="SGCVU.frmTipoFlujo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <%--Referencia a JQuery Script--%>
    <script src="../Scripts/jQuery-1.8.0/jquery.js" type="text/javascript"></script>
    <script src="../Scripts/jQuery-1.8.0/jquery-ui-1.8.1.custom.min.js" type="text/javascript"></script>
    <script src="../Scripts/jQuery-1.8.0/jquery.layout.js" type="text/javascript"></script>
    <script src="../Scripts/jQuery-1.8.0/ui.multiselect.js" type="text/javascript"></script>
    <script src="../Scripts/jQuery-1.8.0/jquery.jqGrid.js" type="text/javascript"></script>
    <script src="../Scripts/jQuery-1.8.0/grid.common.js" type="text/javascript"></script>
    <script src="../Scripts/jQuery-1.8.0/grid.formedit.js" type="text/javascript"></script>
    <script src="../Scripts/jQuery-1.8.0/jquery.fmatter.js" type="text/javascript"></script>
    <script src="../Scripts/jQuery-1.8.0/jquery.tablednd.js" type="text/javascript"></script>
    <script src="../Scripts/jQuery-1.8.0/jquery.contextmenu.js" type="text/javascript"></script>
    <script src="../Scripts/jQuery-1.8.0/grid.subgrid.js" type="text/javascript"></script>
    <script src="../Scripts/jQuery-1.8.0/jquery.alphaNumeric.js" type="text/javascript"></script>
    <script src="../Scripts/jQuery-1.8.0/i18n/grid.locale-es.js" type="text/javascript"></script>
    <script src="../Scripts/jQuery-1.8.0/json2.js" type="text/javascript"></script>
    <script src="../Scripts/jQuery-1.8.0/jquery.ui.widget.js" type="text/javascript"></script>
    <script src="../Scripts/jQuery-1.8.0/jquery.blockUI.js" type="text/javascript"></script>
    <script src="../Scripts/jQuery-1.8.0/i18n/jquery.ui.datepicker-es.js" type="text/javascript"></script>
    <link href="../Scripts/jQuery-1.8.0/jquery-alert.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jQuery-1.8.0/jquery.alert.js" type="text/javascript"></script>
    <script src="../Scripts/jcomunes.js" type="text/javascript"></script>
    <script src="../Scripts/jQuery-1.8.0/i18n/grid.locale-es.js" type="text/javascript"></script>
    <%--Referencia a JQuery CSS--%>
    <link href="../Scripts/jQuery-1.8.0/jquery-ui-1.8.1.custom.css" rel="stylesheet"
        type="text/css" />
    <link href="../Scripts/jQuery-1.8.0/ui.jqgrid.css" rel="stylesheet" type="text/css" />
    <link href="../Scripts/jQuery-1.8.0/ui.multiselect.css" rel="stylesheet" type="text/css" />
    <link href="../Scripts/jQuery-1.8.0/jquery-alert.css" rel="stylesheet" type="text/css" />




</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script language="javascript" type="text/javascript">

        jQuery(document).ajaxStart(jQuery.blockUI).ajaxStop(jQuery.unblockUI);
        jQuery(document).ready(function () {

            var valwidth = $(window).width();

//            $('#btnAceptar').button();
//            $('#btnCerrar').button();

            $("#jqgLLaves").jqGrid({
                datatype: function () {
                    GetData_TipoFlujo();
                },
                height: 300,
                width: (valwidth * 0.70),

                colNames: ['int_ApoyoId', 'str_CompaniaId', 'Nro Orden', 'str_PedidoId', 'int_PosicionId', 'str_ModeloRDA', 'str_ModeloProductoId', 'Modelo', 'Serie', 'Estado Facturación', 'Estructura de Costos', 'str_ClienteId', 'Cliente', 'str_ApoyoTipoId', 'Programa', 'Apoyo $', 'Valor Venta $', '', '', '', '', ''],

                colModel: [
                            { name: 'int_ApoyoId', index: 'int_ApoyoId', hidden: true },
                            { name: 'str_CompaniaId', index: 'str_CompaniaId', hidden: true },
                            { name: 'str_OrdenAsignada', index: 'str_OrdenAsignada', sorttype: "string", width: 200 },
                            { name: 'str_PedidoId', index: 'str_PedidoId', hidden: true },
                            { name: 'int_PosicionId', index: 'int_PosicionId', hidden: true },
                            { name: 'str_ModeloRDA', index: 'str_ModeloRDA', hidden: true },
                            { name: 'str_ModeloProductoId', index: 'str_ModeloProductoId', hidden: true },
                            { name: 'str_ModeloProductoDesc', index: 'str_ModeloProductoDesc', sorttype: "string", width: 200 },
                            { name: 'str_SerieMaquina', index: 'str_TipoFlujoDesc', sorttype: "string", width: 200 },
                            { name: 'str_EstadoInventario', index: 'str_EstadoInventario', sorttype: "string", width: 200 },
                            { name: 'bl_EstructuraCostos', width: 50, index: 'bl_EstructuraCostos', editable: true, edittype: 'checkbox', editoptions: { value: "True:False" }, formatter: "checkbox", formatoptions: { disabled: true} },
                            { name: 'str_ClienteId', index: 'str_ClienteId', hidden: true },
                            { name: 'str_DESC_CLIENTE', index: 'str_DESC_CLIENTE', sorttype: "string", width: 200 },
                            { name: 'str_ApoyoTipoId', index: 'str_ApoyoTipoId', hidden: true },
                            { name: 'str_ApoyoTipoDesc', index: 'str_ApoyoTipoDesc', width: 90, align: "right", formatter: 'currency', formatoptions: { decimalSeparator: ",", thousandsSeparator: ",", decimalPlaces: 2, prefix: "$ "} },
                            { name: 'dec_ApoyoImporteCRM', index: 'dec_ApoyoImporteCRM', width: 90, align: "right", formatter: 'currency', formatoptions: { decimalSeparator: ",", thousandsSeparator: ",", decimalPlaces: 2, prefix: "$ "} },
                            { name: 'dec_ValorVentaMaquinaCRM', index: 'dec_ValorVentaMaquinaCRM', sorttype: "string", width: 200 },
                            { name: 'str_NroSolicitud', index: 'str_NroSolicitud', sorttype: "string", width: 200 },
                            { name: 'det_FechaSolicitudCAT', index: 'det_FechaSolicitudCAT', width: 90, align: "right", formatter: 'date', formatoptions: { srcformat: 'd/m/Y', newformat: 'd/m/Y'} },
                //   { name: 'bl_EstadoSolicitud', width: 50, index: 'bl_EstadoSolicitud', editable: true, edittype: 'checkbox', editoptions: { value: "True:False" }, formatter: "checkbox", formatoptions: { disabled: true} },
                            {name: 'bl_WashOut', width: 50, index: 'bl_WashOut', editable: true, edittype: 'checkbox', editoptions: { value: "True:False" }, formatter: "checkbox", formatoptions: { disabled: true} },
                            { name: 'det_WashOutFecha', index: 'det_WashOutFecha', width: 90, align: "right", formatter: 'date', formatoptions: { srcformat: 'd/m/Y', newformat: 'd/m/Y'} },
                            { name: 'str_WashOutEstado', index: 'str_WashOutEstado', sorttype: "string", width: 200 },
                         ],
                rowNum: 10,
                rowList: [5, 10, 20],
                pager: '#pagerLLaves',
                sortname: 'int_ApoyoId',
                rownumbers: true,
                viewrecords: true,
                toolbar: [true, "top"],
                sortorder: "desc",
                loadtext: 'Cargando datos...',
                recordtext: "{0} - {1} de {2} elementos",
                emptyrecords: 'No hay resultados',
                pgtext: 'Pág: {0} de {1}',
                caption: "Listado de Tipo de Flujo"
            });


            $('#t_jqgLLaves').append("<table><tr><td style='valign: middle'; height:30px; CellSpacing=1'> <a id='lblNew'>Nuevo</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a id='lblEdit'>Editar</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a id='lblDelete'>Eliminar</a></td></tr></table>");
                   
            $('a', '#t_jqgLLaves').click(function (event) {

                var control = event.target.id;
                switch (control) {
                    case 'lblNew':
                        Open_Popup('NUEVO');
                        break;
                    case 'lblEdit':
                        Open_Popup('EDITAR');
                        break;
                    case 'lblDelete':
                        Delete_Record();
                        break;
                }
            });
            $("#divManTipoFlujo").dialog({
                autoOpen: false,
                height: 150,
                width: 380,
                resizable: false,
                modal: true,
                close: function () {
                }
            });
        });

        function GetData_TipoFlujo() {
            arreglo = parametro = null;
            sortColumn = jQuery('#jgpData').getGridParam("sortname");
            sortOrder = jQuery('#jgpData').getGridParam("sortorder");
            pageSize = jQuery('#jgpData').getGridParam("rowNum");
            currentPage = jQuery('#jgpData').getGridParam("page");

            arreglo = fc_redimencionarArray(4);
            arreglo[0][0] = "sortColumn";
            arreglo[0][1] = sortColumn;
            arreglo[1][0] = "sortOrder";
            arreglo[1][1] = sortOrder;
            arreglo[2][0] = "pageSize";
            arreglo[2][1] = pageSize;
            arreglo[3][0] = "currentPage";
            arreglo[3][1] = currentPage;

            parametro = fc_parametrosData(arreglo);

            $.ajax({
                url: location.pathname + "/GetData_ApoyoFlujo",
                data: parametro,
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                complete: function (jsondata, stat) {
                    if (stat == "success") {
                        $("#jqgLLaves").clearGridData();
                        var thegrid = jQuery("#jqgLLaves")[0];
                        thegrid.addJSONData(JSON.parse(jsondata.responseText).d);
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert(textStatus + ': ' + XMLHttpRequest.responseText);
                }
            });
        }

        function Save_TipoFlujo() {

            var strTipoFlujo = $.trim($('#txtDescripcion').val());

            if (strTipoFlujo == '') {
                alert('Debe de ingresar una descripción.');
                return;
            }

            var arreglo = null;
            var parametros = null;
                        
            arreglo = fc_redimencionarArray(4);
            arreglo[0][0] = 'strOperacion';
            arreglo[0][1] = $('#hdfOperacion').val();
            arreglo[1][0] = 'strPrimaryKey';
            arreglo[1][1] = $('#hdfPrimaryKey').val();
            arreglo[2][0] = 'strTipoFlujo';
            arreglo[2][1] = strTipoFlujo
            arreglo[3][0] = 'strUsuario';
            arreglo[3][1] = $('#hdfLogin').val();

            parametros = fc_parametrosData(arreglo);

            $.ajax({
                type: 'POST',
                url: location.pathname + '/Save_TipoFlujo',
                data: parametros,
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (rpta) {
                    if (rpta.d == "1") {
                        alert('Se guardo registro correctamente.');
                        $('#divManTipoFlujo').dialog('close');
                        jQuery("#jqgLLaves").trigger("reloadGrid");
                    }
                    else {
                        alert(rpta.d);
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert(textStatus + ': ' + XMLHttpRequest.responseText);
                }
            });
        }

        function Open_Popup(Accion) {
            switch (Accion) {
                case 'NUEVO':
                    $('#txtDescripcion').val('');
                    $('#divManTipoFlujo').dialog('open');
                    $('#hdfOperacion').val('N');
                    break;
                case 'EDITAR':
                    $('#hdfOperacion').val('M');
                    Show_TipoFlujo();
                    break;

            }
        }

        function Close_Popup() {
            $('#divManTipoFlujo').dialog('close');
        }

        function Show_TipoFlujo() {
            var indice = $('#jqgLLaves').jqGrid('getGridParam', 'selrow');
            if (!indice) {
                alert("Por favor seleccione un registro.");
                return;
            }
            else {
                var reg = $('#jqgLLaves').jqGrid('getRowData', indice);

                $('#hdfPrimaryKey').val(reg.int_TipoFlujoId);
                $('#txtDescripcion').val(reg.str_TipoFlujoDesc);
                $('#divManTipoFlujo').dialog('open');
            }
        }


        function Delete_Record() {
            var id = $("#jqgLLaves").jqGrid('getGridParam', 'selrow');
            if (!id) {
                alert("Por favor seleccione un registro.");
                return;
            }
            if (confirm('Ud. esta seguro que desea eliminar el registro?')) {
                var parametro = null;
                var arreglo = null;

                var fila = $('#jqgLLaves').jqGrid('getRowData', id);
                var int_TipoFlujoId = fila.int_TipoFlujoId;
                arreglo = fc_redimencionarArray(1);
                arreglo[0][0] = 'int_TipoFlujoId';
                arreglo[0][1] = int_TipoFlujoId;
                parametro = fc_parametrosData(arreglo);
                $.ajax({
                    type: "POST",
                    url: location.pathname + "/Delete_TipoFlujo",
                    data: parametro,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        var result = data.d;
                        jQuery("#jqgLLaves").trigger("reloadGrid");
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert(textStatus + ': ' + XMLHttpRequest.responseText);
                    }
                });
            }
            else {
                return;
            }
        }

        
    </script>


    <div style="padding-left: 5px; padding-top: 10px">
        <asp:Label ID="Label1" runat="server" Text="Mantenimiento de Tipo de Flujo" CssClass="lbl_MainTitle"></asp:Label>
        <input type="hidden" id="hdfPrimaryKey" />
        <input type="hidden" id="hdfOperacion" />
    </div>
    <div style="height: 10px; padding-left: 5px">
    </div>
    <div style="padding-left: 5px">
        <table id="jqgLLaves">
        </table>
        <div id="divManTipoFlujo" title="Registro Tipo de Flujo">
            <div>
                <table border="0">
                    <tr>
                        <td class="lbl_Form">
                            Descripción
                        </td>
                        <td class="lbl_Form">
                            :
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <input type="text" id="txtDescripcion" style="width: 240px;" />
                        </td>
                    </tr>
                </table>
            </div>
            <div style="height: 10px">
            </div>
            <div id="divBotonesMantenimiento">
                <table border="0" cellspacing="1" width="100%">
                    <tr style="text-align: right; vertical-align: bottom">
                        <td align="right">
                            <input id="btnGrabar" type="button" value="Grabar" class="btn" onclick="Save_TipoFlujo(); return false;" />
                        </td>
                        <td align="left">
                            <input id="btnCancelar" type="button" value="Cancelar" class="btn" onclick="Close_Popup(); return false;" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div id="pagerLLaves">
        </div>
    </div>
</asp:Content>
