var gridView = !(navigator.appName == 'Microsoft Internet Explorer');

$(document).ready(function () {

    $("#accordion_generaincidente").accordion({
        collapsible: true,
        heightStyle: 'content'
    });

    $("#jqgGeneraIncidentes").jqGrid({
        url: location.pathname + "/ObtenerIncidentes",
        mtype: "POST",
        datatype: "local",

        ajaxGridOptions: {
            contentType: 'application/json; charset=utf-8'
        },
        postData: {
            pIdCompania: '',
            pCodCliente: '',
            pDesCliente: ''
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

        height: "auto",
        width: "auto",
        colNames: [ 'Nro. Expediente', 'Orden', 'Cliente Final', 'Cliente de Facturación', 'Vendedor', 'Familia', 'Modelo', 'Bono Rpto', 'Monto Bono Repuesto', 'Ritmo 5', 'Monto Ritmo 5', 'Programa Ritmo 5', 'NoTieneNroOrden'],
        colModel: [
                  //{ name: 'se', width: 60, index: 'bl_EstructuraCostos', editable: true, edittype: 'checkbox', editoptions: { value: "True:False" }, formatter: "checkbox", formatoptions: { disabled: true }, align: "center" },
                  { name: 'ExpedienteId', index: 'ExpedienteId', width: 70, align: 'center', sortable: false },
                  { name: 'Orden', index: 'Orden', key: true, width: 70, sortable: false },
                  { name: 'ClienteDesc', index: 'ClienteDesc', width: 150, sortable: false },
                  { name: 'ClienteDesc', index: 'ClienteDesc', width: 150, sortable: false },
                  { name: 'VendedorDesc', index: 'VendedorDesc', width: 120, sortable: false },
                  { name: 'FamiliaDesc', index: 'FamiliaDesc', width: 80, sortable: false },
                  { name: 'ModeloProductoDesc', index: 'ModeloProductoDesc', width: 80, sortable: false },
                  { name: 'BonoRpto', index: 'BonoRpto', width: 60, sortable: false },
                  { name: 'MontoBonoRpto', index: 'MontoBonoRpto', width: 80, sortable: false },
                  { name: 'Ritmo5', index: 'Ritmo5', width: 60, sortable: false },
                  { name: 'MontoRitmo5', index: 'MontoRitmo5', width: 80, sortable: false },
                  { name: 'TipoRitmo5', index: 'TipoRitmo5', width: 100, sortable: false },
                  { name: 'NoTieneNroOrden', index: 'NoTieneNroOrden', width: 110, sortable: false }
               ],
        rowNum: 5,
        rownumbers: true,
        cache: false,
        rowList: [5, 20, 50, 80, 100],
        viewrecords: true,
        loadtext: 'Cargando datos...',
        recordtext: "{0} - {1} de {2} elementos",
        emptyrecords: 'No hay resultados',
        pgtext: 'Pág: {0} de {1}',
        caption: "Listado de Máquinas",
        pager: '#pagerMaquinas',
        regional: 'es',
        multiselect: true,
        multiboxonly: true,
        gridview: gridView,
        onSelectRow: function (rowid) {
            idRowIncidente = $(this).jqGrid("getGridParam", "selrow");
        }
    });

   

    

    $("#jqgGeneraIncidentes").jqGrid('setGridParam', { datatype: "json" });
    //$("#jqgGeneraIncidentes").jqGrid().trigger("reloadGrid");
});

function gridMaquinasReload(mantenerSeleccion, primeraPagina) {

    if ($.trim($('#txtCodCliente').val()) == '' && $.trim($('#txtNombreCliente').val().trim())=="")
    {
        $('#txtCodCliente').focus();
        custom_alert("Debe ingresar un parámetro de búsqueda.", "Generar incidencia");
        return false;
    }
    var filtro = obtenerObjetoFiltro();
    $("#jqgGeneraIncidentes").jqGrid()[0].p.postData = filtro;

    if (!mantenerSeleccion)
        idRowMaquina = null;

    if (primeraPagina)
        $("#jqgGeneraIncidentes").jqGrid('setGridParam', { page: 1 });
        
    $("#jqgGeneraIncidentes").jqGrid().trigger("reloadGrid");
};

function obtenerObjetoFiltro() {
    return {
        pIdCompania: '02',
        pCodCliente: $('#txtCodCliente').val(),
        pDesCliente: $('#txtNombreCliente').val()
    };
};

function seleccionadoAlMenosUno() {
    var grid = $("#jqgGeneraIncidentes");
    var rowKey = grid.getGridParam("selrow");    
    return rowKey;
};


function GenerarIncidente() {
    debugger;
    if (!seleccionadoAlMenosUno()) {
        custom_alert("Seleccione al menos un registro.", "Generar incidencia");
    }
    else {
        var selectedIDs = $("#jqgGeneraIncidentes").getGridParam("selarrrow");
        var Invalidos = 0;
        var ordenes = [];
        for (var i = 0; i < selectedIDs.length; i++) {
            var selectRow = $("#jqgGeneraIncidentes").getRowData(selectedIDs[i]);
            if (selectRow.ExpedienteId == 0 || selectRow.ExpedienteId == '0') {
                ordenes.push(selectedIDs[i]);
            }
            else {
                Invalidos += 0;
            }
        }

        if (Invalidos != 0) {
            custom_alert("Orden selecionada(s) ya cuenta con expediente(s).", "Generar incidencia");
            return;
        }
            if (ordenes.length > 0) {
                ProcesaIncidente(ordenes, false);
//            custom_confirmation(function () {
//                ProcesaIncidente(ordenes, false);
//            }, function () {
//            });
            } else {
                custom_alert("Orden selecionada(s) ya cuenta con expediente(s).", "Generar incidencia");
            }
    }
}


function ProcesaIncidente(ordenes, mantenerFilaSeleccionada) {
    $.customAjax({ url: location.pathname + "/GenerarExpediente", parametros: { pOrdenes: ordenes.toString()} },
      function (respuesta) {
          if (respuesta.success) {

              if (respuesta.data != '' && respuesta.data != null) {
                  custom_alert(respuesta.data);
              }
              else {
                  mostrarMensajeProceso({ tipo: 'success', mensaje: mensajesProceso.anularReservasOK });
              }
              gridMaquinasReload(mantenerFilaSeleccionada);
              gridMaquinasReload(false, true);
              //              //Si se anula desde el modal de reserva
              //              if ($("#modalReserva").dialog("isOpen")) {
              //                  var orden = objReserva.ordenAsignada;
              //                  $("#modalReserva").dialog("close");
              //                  gridNegociacionesReload(orden);
              //              }
          }
      }, null, null, true
   );
};

function IrBandeja() {
    location.href = 'frmResultado.aspx';
}

function Limpiar() {
    $("#txtCodCliente,#txtNombreCliente").val("");
    $("#txtCodCliente").focus();
}