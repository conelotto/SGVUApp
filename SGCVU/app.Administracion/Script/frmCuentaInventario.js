$(function () {
    $(document).tooltip();
});

var mensajesProceso = {
    AsignarLineaOK: 'Se asigno Linea de Venta correctamente.' 
}

var gridView = !(navigator.appName == 'Microsoft Internet Explorer');
var idRow = null;
var selectRow = null;
var valCellSolicitud = null;

var dataRoles = [];

$(document).ready(function () {

    GetData_LineaVenta();

    //Accordion
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~        
    $("#Accordion_CriteriosBusqueda").accordion({
        collapsible: true,
        heightStyle: 'content'
    });

    //Grilla - Principal
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ 

    $("#jqgCuentaInventario").jqGrid({

        url: location.pathname + "/GetData_CuentaInventario",
        mtype: "POST",
        datatype: "json",

        ajaxGridOptions: {
            contentType: 'application/json; charset=utf-8'
        },

        postData: {
            Filter: {
                strCodigo: '',
                strDescripcion: '',
                intLinea: ''
            }
        },

        serializeGridData: function (postData) {
            return JSON.stringify(postData);
        },

        jsonReader: {
            root: "d.rows",
            page: "d.page",
            total: "d.total",
            records: "d.records"
        },

        height: 300,
        width: "auto",

        colModel: [
             { label: ' ', name: 'accionAsign', index: 'accion', width: 25, align: "center" },
                { label: 'int_IdCuentaInventario', name: 'int_IdCuentaInventario', index: 'int_IdCuentaInventario', width: 100, hidden: true, key: true },
                { label: 'Código de Cuenta', name: 'str_IdCuenta', index: 'str_IdCuenta', width: 200 },
                { label: 'Cuenta de Inventario', name: 'str_DescCuentaInventario', index: 'str_DescCuentaInventario', width: 320 },
                { label: 'int_IdLineaVenta', name: 'int_IdLineaVenta', index: 'int_IdLineaVenta', width: 200, hidden: true },
                { label: 'Linea de Venta', name: 'str_DescLineaVenta', index: 'str_DescLineaVenta', width: 320 },
                { label: 'F. Modificación', name: 'det_FechaModificacion', index: 'det_FechaModificacion', width: 100, align: "center", formatter: 'date', formatoptions: { srcformat: 'd/m/Y', newformat: 'd/m/Y' }, hidden: true },
                { label: 'U. Modificación', name: 'str_UsuarioModificacion', index: 'str_UsuarioModificacion', width: 130, hidden: true }
               ],

        rowNum: 1000,
        rownumbers: true,
        rowList: [20, 50, 80],
        viewrecords: true,
        loadtext: 'Cargando datos...',
        recordtext: "<b>{2} registros encontrados</b>",
        emptyrecords: 'No se encontraron registros',
        pgtext: 'Pág: {0} de {1}',
        caption: "Relación de Cuentas de Inventario",
        pager: '#pagerCuentaInventario',
        regional: 'es',
        gridview: gridView,
        cmTemplate: { title: false },

        gridComplete: function () {
            var ids = $("#jqgCuentaInventario").jqGrid('getDataIDs');
            for (var i = 0; i < ids.length; i++) {
                asign = "<img src='../Images/btnValidate.png' style='cursor:pointer;' title='Asignar Linea de Venta' onclick=\"AsignacionLineaVenta('" + ids[i] + "');\" />";
                $("#jqgCuentaInventario").jqGrid('setRowData', ids[i], { accionAsign: asign });
            }
        }
    });

    $("#frmCuentaInventario").validate({
        rules: {
            SelectLineaVenta: "required"
        },
        messages: {
            SelectLineaVenta: "<br> Seleccione Linea de Venta."
        }
    });

    $("#modalCuentaInventario").dialog({
        autoOpen: false,
        width: 400,
        height: 'auto',
        resizable: false,
        modal: true,
        close: function () {
            $('#frmCuentaInventario').validate().resetForm();
            $('#lblCuentaInventarioId').val("");
            $('#lblCuentaInventarioCodigo').text("");
            $('#lblCuentaInventarioDescripcion').text("");
        },
        buttons: {
            "Asignar": function () {
                var $this = $(this);
                if ($("#frmCuentaInventario").valid()) {
                    var parametros = {
                        CuentaInventarioId: $('#lblCuentaInventarioId').val(),
                        LineaVentaId: $('#SelectLineaVenta').val()
                    };

                    $.customAjax({ url: location.pathname + "/AsignarLineaVenta", parametros: parametros },
                        function (respuesta) {
                            if (respuesta.success) {
                                mostrarMensajeProceso({ tipo: 'success', mensaje: mensajesProceso.AsignarLineaOK });
                                $("#jqgCuentaInventario").jqGrid().trigger("reloadGrid");
                                $this.dialog('close');

                            }
                        }, null, null, true
                    );
                }
            },
            "Cancelar": function () {
                $(this).dialog("close");
            }
        }
    });
 
 });

function AsignacionLineaVenta(id) {
    $.ajax({
        type: "POST",
        url: location.pathname + "/GetData_LineaVenta",
        data: '',
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        success: function (msg) {
            $("#SelectLineaVenta").empty().append($("<option></option>").val("0").html("Seleccione..."));
            $.each(msg.d, function (i, item) {
                $('#SelectLineaVenta').append($('<option>', {
                    value: item.int_IdLineaVenta,
                    text: item.str_DescLineaVenta
                }));
            });

            var row = $("#jqgCuentaInventario").jqGrid('getRowData', id);
            var CuentaId = null;

            $('#lblCuentaInventarioId').val(row.int_IdCuentaInventario);
            $('#lblCuentaInventarioCodigo').text(row.str_IdCuenta);
            $('#lblCuentaInventarioDescripcion').text(row.str_DescCuentaInventario);
            $('#SelectLineaVenta').val(row.int_IdLineaVenta);

            CuentaId = row.int_IdCuentaInventario;
            if (CuentaId != null) {
                $("#modalCuentaInventario").dialog('option', 'title', 'Asignación de Linea de Venta');
                $('#modalCuentaInventario').dialog('open');
            }
        },
        error: function () {
            alert("Error al cargar linea de venta.");
        }
    });
}

function GetData_LineaVenta() {
    $.ajax({
        type: "POST",
        url: location.pathname + "/GetData_LineaVenta",
        data: '',
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        success: function (msg) {
            $("#selectLineaCon").empty().append($("<option></option>").val("0").html("Seleccione de Linea de Venta..."));
            $.each(msg.d, function (i, item) {
                $('#selectLineaCon').append($('<option>', {
                    value: item.int_IdLineaVenta,
                    text: item.str_DescLineaVenta
                }));
            });
        },
        error: function () {
            alert("Error al cargar linea de venta.");
        }
    });
}

function CleanFilter() {
    $('#txtCodigoCon').val("");
    $('#txtDescripcionCon').val("");
    $('#selectLineaCon').val("");
    GetData_LineaVenta();
};

function UndoSearch() {
    var Filter = {
        strCodigo: '',
        strDescripcion: '',
        intLinea: ''
    };
    $("#jqgCuentaInventario").jqGrid()[0].p.postData.Filter = Filter;
    $("#jqgCuentaInventario").jqGrid().trigger("reloadGrid");
    CleanFilter();
};

function DoSearch() {

    debugger;
    var Filter = {
    
        strCodigo: $('#txtCodigoCon').val(),
        strDescripcion: $('#txtDescripcionCon').val(),
        intLinea: $('#selectLineaCon').val() == '0' ? "" : $('#selectLineaCon').val()
    };

    $("#jqgCuentaInventario").jqGrid()[0].p.postData.Filter = Filter;
    $("#jqgCuentaInventario").jqGrid().trigger("reloadGrid");
};
