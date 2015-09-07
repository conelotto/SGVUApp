gridView = !(navigator.appName == 'Microsoft Internet Explorer');

var idRowMaquina = null;
var idRowIncidente = null;
var idRowTrabajador = null;
var objReserva = null;

var mensajesProceso = {
    solicitarLevanteOK: 'La solicitud de levante se envió correctamente.',
    crearReservaOK: 'La reserva se guardó correctamente.',
    modificarReservaOK: 'La reserva se modificó correctamente.',
    modificarMaquinaOK: 'La máquina se modificó correctamente.',
    anularReservasOK: 'Las reservas se anularon correctamente.',
    RegistrarMaquinaBoboOk: 'Datos registrados satisfactoriamente.'
};

$(document).ready(function () {

    var anchoPantalla = $(window).width();
    var cantDis = 22;

    var urlCarga = window.location.origin + "/Carga/CargaBase.ashx";

    $("#ulBonoRpto").change(function () {
        var files = $(this).prop("files");
        var output = [];
        for (var i = 0, f; f = files[i]; i++) {
            output.push('<li><strong>', escape(f.name), '</strong> - ', f.size, ' bytes', '</li>');
        }
        debugger;
        document.getElementById('listUploadBR').innerHTML = '<ul>' + output.join('') + '</ul>';

        for (i = 0; i < files.length; i++) {
            uploadFile(i, "#ulBonoRpto", "#hdnArchivoBonoFirmado");
        }
    });

    $("#ulBonoCSA").change(function () {
        var files = $(this).prop("files");
        var output = [];
        for (var i = 0, f; f = files[i]; i++) {
            output.push('<li><strong>', escape(f.name), '</strong> - ', f.size, ' bytes', '</li>');
        }
        debugger;
        document.getElementById('listUploadBCSA').innerHTML = '<ul>' + output.join('') + '</ul>';

        for (i = 0; i < files.length; i++) {
            uploadFile(i, "#ulBonoCSA", "#hdnArchivoCSAFirmado");
        }
    });

    $("#upload").change(function () {
        var files = $(this).prop("files");
        var output = [];
        for (var i = 0, f; f = files[i]; i++) {
            output.push('<li><strong>', escape(f.name), '</strong> - ', f.size, ' bytes', '</li>');
        }
        debugger;
        document.getElementById('listUpload').innerHTML = '<ul>' + output.join('') + '</ul>';

        for (i = 0; i < files.length; i++) {
            uploadFile(i, "#upload", "#hdnArchivos");
        }
    });

    function uploadFile(position, control, print) {
        debugger;
        var files = $(control).prop("files");
        var form_data = new FormData();
        form_data.append("file", files[position]);
        $.ajax({
            url: urlCarga,
            cache: false,
            contentType: false,
            processData: false,
            data: form_data,
            type: 'post',
            success: function (response) {
                debugger;
                console.log(response);
                files[position].newName = response.files[0].newName;
                $(print).val(response.Resultado)
            },
            error: function (xhr, ajaxOptions, thrownError) {
                debugger;
                console.log("error");
            },
            complete: function () {
                debugger;
                console.log("completado");
            }
        })
    };

    $("#filtroFechaDesde").datepicker({
        numberOfMonths: 1,
        showButtonPanel: true,
        changeMonth: true,
        changeYear: true,
        onClose: function (selectedDate) {
            $("#filtroFechaHasta").datepicker("option", "minDate", selectedDate);
        }
    });

    $("#filtroFechaHasta").datepicker({
        numberOfMonths: 1,
        showButtonPanel: true,
        changeMonth: true,
        changeYear: true,
        onClose: function (selectedDate) {
            $("#filtroFechaDesde").datepicker("option", "maxDate", selectedDate);
        }
    });

    $("#txtFechaFactura").datepicker({
        numberOfMonths: 1,
        showButtonPanel: true,
        changeMonth: true,
        changeYear: true
    });

    $("#accordion_busqueda").accordion({
        collapsible: true,
        heightStyle: 'content'
    });

    $("#accordion_incidencia").accordion({
        collapsible: true,
        heightStyle: 'content'
    });

    $("#accordion_archivos").accordion({
        collapsible: true,
        active: false,
        heightStyle: 'content'
    });

    $("#accordion_Actividades").accordion({
        collapsible: true,
        active: false,
        heightStyle: 'content'
    });

    $("#jqgMaquinas").jqGrid({
        url: location.pathname + "/ListarGrilla",
        mtype: "POST",
        datatype: "local",

        ajaxGridOptions: {
            contentType: 'application/json; charset=utf-8'
        },
        postData: {
            pSucursal: '',
            pMarca: '',
            pModelo: '',
            pSemaforo: '',
            pFecIni: '',
            pFecFin: '',
            pOrden: '',
            pCliente: '',
            pVendedor: '',
            pActividad: '-1',
            pEstado: '-1'

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
        width: anchoPantalla - cantDis,
        shrinkToFit: false,

        colNames: ['Orden', 'Nro. Expediente', 'Cliente Final', 'Cliente Facturación', 'Cuenta', 'Entidad Financiera',
    'Financiamiento', 'Vendedor', 'Comentario', 'Actividad', 'Estado Registro', 'Familia', 'Fecha Actual', 'Fecha Facturación',
    'Modelo', 'Bono Rpto', 'Monto Bono Repuesto', 'Ritmo 5', 'Monto Ritmo 5',
    'Programa Ritmo 5', 'SAP', 'Sucursal', 'Semáforo', 'TDF', 'TR', 'Tiene Físico Ritmo 5', 'Tiene Fisico Rpto', 'Observaciones',
    'Archivo Sustento', 'Fecha Registro'],
        colModel: [
                  { name: 'str_OrdenAsignada', index: 'str_OrdenAsignada', key: true, width: 58, sortable: false, formatter: formatOrden, unformat: unformatOrden, hidden: false },
                  { name: 'int_ExpedienteId', index: 'int_ExpedienteId', width: 70, align: 'center', sortable: false, hidden: false },
                  { name: 'str_ClienteFinal', index: 'str_ClienteFinal', width: 120, sortable: false, hidden: false },
                  { name: 'str_ClienteFacturacion', index: 'str_ClienteFacturacion', width: 60, sortable: false, hidden: false },
                  { name: 'str_Cuenta', index: 'str_Cuenta', width: 50, sortable: false, hidden: false },
                  { name: 'str_EntidadFinanciera', index: 'str_EntidadFinanciera', width: 130, sortable: false, hidden: false },
                  { name: 'str_Financiamiento', index: 'str_Financiamiento', width: 90, sortable: false, hidden: false },
                  { name: 'str_Vendedor', index: 'str_Vendedor', width: 100, sortable: false, hidden: false },
                  { name: 'str_Comentario', index: 'str_Comentario', width: 120, sortable: false, hidden: false },
                  { name: 'str_Actividad', index: 'str_Actividad', width: 100, sortable: false, hidden: false },
                  { name: 'str_EstadoRegistro', index: 'str_EstadoRegistro', width: 80, sortable: false, hidden: false },
                  { name: 'str_Familia', index: 'str_Familia', width: 120, sortable: false, hidden: false },
                  { name: 'str_FechaActual', index: 'str_FechaActual', width: 120, sortable: false, hidden: false },
                  { name: 'str_FechaFacturacion', index: 'str_FechaFacturacion', width: 70, sortable: false, formatter: 'date', formatoptions: { srcformat: "d/m/Y", newformat: "d/m/Y" }, hidden: false },
                  { name: 'str_Modelo', index: 'str_Modelo', width: 50, sortable: false, align: 'center', hidden: false },
                  { name: 'bl_BonoRpto', width: 60, index: 'bl_BonoRpto', editable: true, edittype: 'checkbox', editoptions: { value: "True:False" }, formatter: "checkbox", formatoptions: { disabled: true }, align: "center" },
                  { name: 'str_MontoBonoRpto', index: 'str_MontoBonoRpto', width: 40, sortable: false, hidden: false },
                  { name: 'bl_Ritmo5', width: 60, index: 'bl_Ritmo5', editable: true, edittype: 'checkbox', editoptions: { value: "True:False" }, formatter: "checkbox", formatoptions: { disabled: true }, align: "center" },
                  { name: 'str_MontoRitmo5', index: 'str_MontoRitmo5', width: 70, sortable: false, align: 'center', hidden: false },
                  { name: 'str_ProgramaRitmo5', index: 'str_ProgramaRitmo5', width: 70, sortable: false, align: 'center', hidden: false },
                  { name: 'str_SAP', index: 'str_SAP', width: 70, sortable: false, align: 'center', hidden: false },
                  { name: 'str_Sucursal', index: 'str_Sucursal', width: 70, sortable: false, align: 'center', hidden: false },
                  { name: 'str_Semaforo', index: 'str_Semaforo', width: 70, sortable: false, align: 'center', formatter: formatSemaforo, unformat: unformatSemaforo, hidden: false },
                  { name: 'str_TDF', index: 'str_TDF', width: 70, sortable: false, align: 'center', hidden: false },
                  { name: 'str_TR', index: 'str_TR', width: 70, sortable: false, align: 'center', hidden: false },
                  { name: 'str_TieneFisicoRitmo5', index: 'str_TieneFisicoRitmo5', width: 100, sortable: false, align: 'center', hidden: false },
                  { name: 'str_TieneFisicoRpto', index: 'str_TieneFisicoRpto', width: 70, sortable: false, hidden: false },
                  { name: 'str_Observaciones', index: 'str_Observaciones', width: 120, sortable: false, hidden: false },
                  { name: 'str_ArchivoSustento', index: 'str_ArchivoSustento', width: 120, sortable: false, hidden: false },
                  { name: 'str_FechaRegistro', index: 'str_FechaRegistro', hidden: true }

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
        //multiselect: true,
        multiboxonly: true,
        gridview: gridView,
        gridComplete: initGrid,
        //subGrid: true,


        onSelectRow: function (rowid) {
            idRowMaquina = $(this).jqGrid("getGridParam", "selrow");
        },

        //        loadComplete: function () {
        //            var grid = $("#jqgMaquinas");
        //            var ids = $("#jqgMaquinas").jqGrid('getDataIDs');
        //            $.each(ids, function (i, item) {
        //                var row = $("#jqgMaquinas").getRowData(item);
        //                if (row.TieneEmparejamiento != "1") $("#" + item + " td.sgcollapsed", grid[0]).unbind('click').html('');
        //            });

        // $("#jqgMaquinas").jqGrid('setSelection', idRowMaquina);
        //       },

        onCellSelect: function (row, col, content, event) {

            var cm = $("#jqgMaquinas").jqGrid("getGridParam", "colModel");
            if (cm[col].name == 'str_OrdenAsignada') {
                var rowData = $("#jqgMaquinas").getRowData(row); //$("#jqgMaquinas").jqGrid("jqgMaquinas", row);
                debugger;
                if (rowData.bl_Ritmo5=='False' && rowData.bl_BonoRpto=='False') {                    
                    custom_alert("La máquina seleccionada no cuenta con bonos.");
                    return;
                }
                mostrarModalIncidente(row, rowData);
            }
        },

        loadError: function (xhr, st, err) {
            console.log("Type: " + st + "; Response: " + xhr.status + " " + xhr.statusText);
        }


    });


    $("#jqgIncidencia").jqGrid({
        datatype: "local",
        data: [],

        height: "auto",
        width: "auto",
        colNames: ['Orden', 'Num. Serie', 'Familia', 'Modelo', 'Bono Rpto', 'Monto Bono Rpto', 'Ritmo 5', 'Monto Ritmo 5', 'Programa Ritmo 5', 'Fecha Facturación', 'Cuenta'],
        colModel: [
                  { name: 'str_OrdenAsignada', index: 'str_OrdenAsignada', key: true, width: 50 },
                  { name: 'str_SerieMaquina', index: 'str_SerieMaquina', width: 70, align: 'center', sortable: false },
                  { name: 'str_FamiliaDesc', index: 'str_FamiliaDesc', width: 70, sortable: false },
                  { name: 'str_ModeloProductoDesc', index: 'str_ModeloProductoDesc', width: 70, sortable: false },
                  { name: 'bl_EsBonoRpto', width: 60, index: 'bl_EsBonoRpto', editable: true, edittype: 'checkbox', editoptions: { value: "True:False" }, formatter: "checkbox", formatoptions: { disabled: true }, align: "center" },
                  { name: 'dec_BonoRptoMonto', index: 'dec_BonoRptoMonto', width: 80, sortable: false },
                  { name: 'bl_EsRitmo5', width: 60, index: 'bl_EsRitmo5', editable: true, edittype: 'checkbox', editoptions: { value: "True:False" }, formatter: "checkbox", formatoptions: { disabled: true }, align: "center" },
                  { name: 'dec_Ritmo5Monto', index: 'dec_Ritmo5Monto', width: 80, sortable: false },
                  { name: 'str_Ritmo5Tipo', index: 'str_Ritmo5Tipo', width: 80, sortable: false },
                  { name: 'str_FechaFactura', index: 'str_FechaFactura', width: 100, sortable: false },
                  { name: 'str_CuentaInventarioDBS', index: 'str_CuentaInventarioDBS', width: 60, sortable: false }
               ],

        regional: 'es',
        rownumbers: true,
        cache: false,
        viewrecords: true,
        gridview: gridView,
        gridComplete: InitII,
        onSelectRow: function (rowid) {
            idRowIncidente = $(this).jqGrid("getGridParam", "selrow");
        }

    });

    $("#jqgVendedores").jqGrid({

        datatype: "local",
        rowNum: -1,
        height: "290px",
        width: "auto",
        colNames: ['Código', 'Vendedor', 'DesSucursal', 'Sucursal'],
        colModel: [
                  { name: 'str_MATRICULA', index: 'str_MATRICULA', key: true, width: 50, formatter: formatOrden, unformat: unformatOrden },
                  { name: 'str_NOMBRE', index: 'str_NOMBRE', width: 290, align: 'center', sortable: false },
                  { name: 'str_DESC_SUCURSAL', index: 'str_DESC_SUCURSAL', hidden: true },
                  { name: 'str_SUCURSAL', index: 'str_SUCURSAL', hidden: true }
               ],

        regional: 'es',
        viewrecords: true,
        gridview: gridView,
        autowidth: false,
        shrinkToFit: true,
        multiboxonly: true,
        onSelectRow: function (rowid) {
            idRowTrabajador = $(this).jqGrid("getGridParam", "selrow");
        },

        onCellSelect: function (row, col, content, event) {
            var cm = $("#jqgVendedores").jqGrid("getGridParam", "colModel");
            if (cm[col].name == 'str_MATRICULA') {
                var rowData = $("#jqgVendedores").getRowData(row);
                mostrarDatosVendedor(row, rowData);
            }
        }
    });

    $("#jqgActividades").jqGrid({
        datatype: "local",
        data: [],

        height: "auto",
        width: "auto",
        colNames: ['Fecha', 'Acividad', 'Usuario'],
        colModel: [
                  { name: 'str_FechaCreacion', index: 'str_FechaCreacion', width: 150 },
                  { name: 'str_Actividad', index: 'str_Actividad', width: 220, sortable: false },
                  { name: 'str_Usuario', index: 'str_Usuario', width: 150, sortable: false }
               ],
        rowNum: 5,
        rownumbers: true,
        cache: false,
        viewrecords: true,
        loadtext: 'Cargando datos...',
        recordtext: "{0} - {1} de {2} elementos",
        emptyrecords: 'No hay resultados',
        pgtext: 'Pág: {0} de {1}',
        caption: "Listado de Historial Expedientes",
        pager: '#pagerActividades',
        regional: 'es',
        viewrecords: true,
        gridview: gridView

    });

    function formatSolicitoLevante(cellValue, options, rowObject) {
        if (rowObject.LevanteAduaneroFecha == null) {
            return cellValue == "1" ? "<img src='../Images/ok-check.png' title='Solicitó Levante' />" : "<img src='../Images/no-check.png' title='No solicitó Levante' />";
        } else {
            return "";
        }
    };

    function unformatSolicitoLevante(cellValue, options, cellObject) {
        return $(cellObject.html()).attr("originalValue");
    };

    function formatOrden(cellValue, options, rowObject) {
        return "<span style='color:blue; border-bottom: 1px solid; cursor:pointer;'>" + cellValue + "</span>";
    };

    function unformatOrden(cellValue, options, cellObject) {
        return $(cellObject.html()).attr("originalValue");
    };

    function formatSemaforo(cellValue, options, cellObject) {
        var classSemaforo = cellValue == "1" ? "semaforoVerde" : ((cellValue == "2") ? "semaforoRojo" : (cellValue == "3" ? "semaforoAmarillo" : ""));
        return "<div style='margin-left:5px;' class='" + classSemaforo + "'></div>"
    };

    function unformatSemaforo(cellValue, options, cellObject) {
        return $(cellObject.html()).attr("originalValue");
    };

    function formatUbicacion(cellValue, options, cellObject) {
        var colorSemaforo = cellObject.DiasUbicacion < 15 ? 'green' : 'red';
        if (cellObject.UbicacionDesc == "DEMO") {
            return "<span align='center' style='width:30px;display:inline-block;background:" + colorSemaforo + ";padding-top:2px;padding-bottom:2px;color:white'>" + cellObject.DiasUbicacion + "</span><span style='margin-left:10px;'>" + cellValue + "</span>";
        } else {
            return "<span style='margin-left:40px;'>" + cellValue + "</span>";
        }
    };

    function unformatUbicacion(cellValue, options, cellObject) {
        return $(cellObject.html()).attr("originalValue");
    };

    function initGrid() {
        $(this).contextMenu('contextMenuMaquinas', {
            bindings: {
                'IngresarComentario': function (t) {
                    if (idRowMaquina != null) {
                        var row = $("#jqgMaquinas").getRowData(idRowMaquina);
                        $("#modalObservacion").dialog('option', 'title', 'Orden: ' + row.str_OrdenAsignada);
                        $('#txtObservacion').val(row.str_Observaciones);
                        $('#modalObservacion').dialog('open');

                    } else {
                        custom_alert("Seleccione un registro.");
                    }
                },
                'ImporteBonos': function (t) {
                    $("#txtImporteRitmo5,#txtImporteRpto").prop('disabled', true);

                    if (idRowMaquina != null) {
                        var row = $("#jqgMaquinas").getRowData(idRowMaquina);
                        if (idRowMaquina != null) {
                            var row = $("#jqgMaquinas").getRowData(idRowMaquina);

                            if (row.bl_Ritmo5 == 'True') {
                                $("#txtImporteRitmo5").prop('disabled', false);
                            }
                            if (row.bl_BonoRpto == 'True') {
                                $("#txtImporteRpto").prop('disabled', false);
                            }

                            if (row.bl_Ritmo5 != 'True' && row.bl_BonoRpto != 'True') {
                                custom_alert("La orden no cuenta con bonos.");
                                return;
                            }

                            $("#txtImporteRpto").val(row.str_MontoBonoRpto);
                            $("#txtImporteRitmo5").val(row.str_MontoRitmo5);

                            $("#modalModificacion").dialog('option', 'title', 'Orden: ' + idRowMaquina);
                            $('#modalModificacion').dialog('open');

                        } else {
                            custom_alert("Seleccione un registro.");
                        }
                        //                        if (row.EstadoMaquina == "RESERVADO") {
                        //                            custom_confirmation(function () {
                        //                                ajaxAnularReservas([idRowMaquina], true);
                        //                            }, function () {
                        //                            });
                        //                        } else {
                        //                            custom_alert("La orden no esta Reservada.");
                        //                        }
                    } else {
                        custom_alert("Seleccione un registro.");
                    }
                },
                'modificarFactura': function (t) {
                    if (idRowMaquina != null) {
                        $("#hdnNuevaFactura").val("0");
                        MostrarDatosMaquina();
                        $("#modalFactura").dialog('option', 'title', 'Máquina');
                        $('#modalFactura').dialog('open');
                    } else {
                        custom_alert("Seleccione un registro.");
                    }
                }
            }
        });

    };




    function BuscarOrdenFactura(Orden) {
        var textoOrden = $("txtNroOrdenF").val();
        var Descripciones;

        $.customAjax({ url: location.pathname + "/ObtenerDatosFactura", parametros: { pOrden: textoOrden} },
         function (respuesta) {
             var IdCuenta;
             var CodCliente;
             if (respuesta.success) {
                 if (respuesta == 0) {
                     return;
                 }
                 var datosOrden = respuesta.data;
                 if (datosOrden != null) {

                     $("#txtMarcaF").val(datosOrden.str_PRCLST);
                     $("#txtModeloIdGenericoF").val(datosOrden.str_DSPMDL);
                     $("#txtNumeroSerieF").val(datosOrden.str_EQMFS2);

                     if (datosOrden.str_INVI == 'S') {
                         IdCuenta = datosOrden.str_LCUNO;
                         CodCliente = datosOrden.str_CUNO;
                     }
                     else if (datosOrden.str_INVI = 'Y') {
                         IdCuenta = datosOrden.str_CUNO;
                         CodCliente = datosOrden.str_LCUNO;
                     }
                     $("#txtClienteF").val(CodCliente);
                     $("#txtCuentaF").val(IdCuenta);

                     Descripciones = respuesta.msg.split('|');

                     $("#txtNombreClienteF").val(Descripciones[0]);
                     $("#CuentaInventarioDBS ").val(Descripciones[1]);
                     //CuentaInventarioDBS

                     //                     $("#txtVendedorF").val(datosOrden.str_VendedorId);
                     //                     $("#txtNombreVendedorF").val(datosOrden.str_VendedorDesc);
                     //                     $("#txtObservacionF").val(datosOrden.str_Observaciones);
                     //                     $("#txtClienteF").val(datosOrden.str_ClienteId);
                     //                     $("#txtNombreClienteF").val(datosOrden.str_ClienteDesc);
                     //                     $("#txtEntidadFinancieraF").val(datosOrden.str_EntidadFinancieraId);
                     //                     $("#txtNombreEntidadFinancieraF").val(datosOrden.str_FinanciamientoDesc);
                     //                     $("#txtTipo").val(datosOrden.str_SUNTIP);
                     //                     $("#txtSerie").val(datosOrden.int_SUNPRE);
                     //                     $("#txtNro").val(datosOrden.int_SUNNUM);
                     //                     $("#lblNroOrdenF").text(idRowMaquina);
                     //                     $("#txtFamilaF").val(datosOrden.str_FamiliaDesc);

                     //                     $("#txtCuentaF").val(datosOrden.str_CuentaInventarioDBS);
                     //CuentaInventarioDBS
                 }
             }
         }, null, null, true
      );
    }

    function InitII() {
        $("#txtImporteRitmo5").prop('disabled', false);
        $("#txtImporteRpto").prop('disabled', false);
        $(this).contextMenu('contextMenuIncidencia', {
            bindings: {
                'RegistroImporteBonos': function (t) {
                    if (idRowIncidente != null) {
                        var row = $("#jqgIncidencia").getRowData(idRowIncidente);

                        if (row.bl_EsBonoRpto == "False" && row.bl_EsRitmo5 == "False") {
                            custom_alert("El N° de orden no cuenta con bonos.");
                            return;
                        }

                        $("#modalModificacion").dialog('option', 'title', 'Orden: ' + row.str_OrdenAsignada);

                        if (row.bl_EsRitmo5 != "False") {
                            $("#txtImporteRitmo5").val(row.dec_Ritmo5Monto);
                        }
                        else {
                            $("#txtImporteRitmo5").val(0);
                            $("#txtImporteRitmo5").prop('disabled', true);
                        }
                        if (row.bl_EsBonoRpto != "False") {
                            $("#txtImporteRpto").val(row.dec_BonoRptoMonto);
                        }
                        else {
                            $("#txtImporteRpto").val(0);
                            $("#txtImporteRpto").prop('disabled', true);
                        }
                        // $('#txtObservacion').val(row.str_Observaciones);
                        $('#modalModificacion').dialog('open');

                    } else {
                        custom_alert("Seleccione un registro.");
                    }
                }
            }
        });
    }


    LlenarCombos();

    function ListarGrilla() {
        var Sucursal = $('#txtSucursal').val();
        var Marca = $('#txtMarca').val();
        var Modelo = $('#txtModelo').val();
        var Orden = $('#txtOrden').val();
        var Cliente = $('#txtCliente').val();
        var Vendedor = $('#txtVendedor').val();
        var FecDesde = $('#filtroFechaDesde').val();
        var FecHasta = $('#filtroFechaHasta').val();
        var Semaforo = $('input[name=rbSemaforo]:checked').val();
        var Actividad = $('#ddlActividad').val();
        var Estado = $('#ddlEstado').val();
        $.customAjax({ url: location.pathname + "/ListarGrilla",
            parametros: { pSucursal: Sucursal,
                pMarca: Marca,
                pModelo: Modelo,
                pSemaforo: Semaforo,
                pFecIni: FecDesde,
                pFecFin: FecHasta,
                pOrden: Orden,
                pCliente: Cliente,
                pVendedor: Vendedor,
                pActividad: Actividad,
                pEstado: Estado
            }
        },
         function (respuesta) {
             $('#jqgMaquinas').jqGrid('clearGridData');
             preload(false);
             if (respuesta.success) {
                 jQuery("#jqgMaquinas").setGridParam({ rowNum: respuesta.data.length });
                 jQuery("#jqgMaquinas").jqGrid('setGridParam', { data: respuesta.data }).trigger("reloadGrid");

                 //                 var arrayModelos = $("#filtroUbicacion").val().split(',');
                 //                 for (var i = 0; i < arrayModelos.length; i++) {
                 //                     if (arrayModelos[i].trim() != "")
                 //                         $("#jqgMaquinas").jqGrid('setSelection', arrayModelos[i]);
                 //                 }

                 //                 $('#modalFiltroUbicacion').dialog('open');
             }
         }, function (error) {
             preload(false);
         }, function () {
             preload(true);
         }
      );
    }

    function LlenarCombos() {
        $.customAjax({ url: location.pathname + "/ObtenerDatosCombos", parametros: {} },
      function (respuesta) {
          preload(false);
          if (respuesta.success) {
              //Llenar los Estados para el filtro
              $.each(respuesta.data.estados, function (i, item) {
                  $('#ddlEstado').append($('<option>', {
                      value: item.id,
                      text: item.desc
                  }));
              });

              $.each(respuesta.data.actividades, function (i, item) {
                  $('#ddlActividad').append($('<option>', {
                      value: item.id,
                      text: item.desc
                  }));
              });
              //ListarGrilla();

              //Configurar las columnas visibles
              $("#jqgMaquinas").jqGrid('setGridParam', { datatype: "json" });
              $("#jqgMaquinas").jqGrid().trigger("reloadGrid");


          } else {
              custom_alert(respuesta.msg);
          }
      }, function (error) {
          preload(false);
      }, function () {
          preload(true);
      }
   );


    };

    $("#modalModificacion").dialog({
        autoOpen: false,
        width: 300,
        resizable: false,
        modal: true,
        close: function () {
            //         $("#frmReserva").validate().resetForm();
            //         $("#lblNroNegReservaModal").text("");
            //         objReserva = null;
        },
        buttons: {
            "Aceptar": function () {
                var ImporteRpto = $('#txtImporteRpto').val();
                var ImporteRitmo5 = $('#txtImporteRitmo5').val();

                var ExpedienteId = $('#lblExpedienteId').text();

                var $this = $(this);
                $.customAjax({ url: location.pathname + "/ModificarDatosMaquina", parametros: { pExpediente: ExpedienteId, pOrden: idRowMaquina, pTipo: 2, pObservacion: '', pMontoRpto: ImporteRpto, pMontoRitmo5: ImporteRitmo5} },
                            function (respuesta) {
                                var listaExpedientes = respuesta.data.listadoIncidencias;
                                preload(false);
                                if (respuesta.success) {
                                    mostrarMensajeProceso({ tipo: 'success', mensaje: respuesta.msg });
                                    jQuery("#jqgIncidencia").setGridParam({ rowNum: listaExpedientes.length });
                                    jQuery("#jqgIncidencia").jqGrid('setGridParam', { data: listaExpedientes }).trigger("reloadGrid");
                                    $this.dialog("close");
                                } else {
                                    custom_alert(respuesta.msg);
                                }
                            }, function (error) {
                                preload(false);
                            }, function () {
                                preload(true);
                            }
                         );

            },
            "Cancelar": function () {
                $(this).dialog("close");
            }
        }
    });

    $("#modalObservacion").dialog({
        autoOpen: false,
        width: 400,
        resizable: false,
        modal: true,
        close: function () {
            //$("#frmReserva").validate().resetForm();
            objReserva = null;
        },
        buttons: {
            "Aceptar": function () {
                var Observacion = $('#txtObservacion').val();
                var $this = $(this);
                $.customAjax({ url: location.pathname + "/ModificarDatosMaquina", parametros: { pOrden: idRowMaquina, pTipo: 1, pObservacion: Observacion, pMontoRpto: 0, pMontoRitmo5: 0} },
                            function (respuesta) {
                                preload(false);
                                if (respuesta.success) {
                                    mostrarMensajeProceso({ tipo: 'success', mensaje: respuesta.msg });
                                    $this.dialog("close");
                                    gridMaquinasReload(true);
                                } else {
                                    custom_alert(respuesta.msg);
                                }
                            }, function (error) {
                                preload(false);
                            }, function () {
                                preload(true);
                            }
                         );
            },
            "Cancelar": function () {
                $(this).dialog("close");
            }
        }
    });

    $("#modalIncidente")
    .dialog({
        autoOpen: false,
        width: 900,
        height: 600,
        resizable: false,
        modal: true,
        close: function () {
            //$("#frmReserva").validate().resetForm();
            objReserva = null;
        }
    });

    $("#modalFactura")
    .dialog({
        autoOpen: false,
        width: 980,
        height: 550,
        resizable: false,
        modal: true,
        buttons: {
            "Guardar": function () {
                var $this = $(this);
                GuardarDatosFactura($this);
            },
            "Cancelar": function () {
                $(this).dialog("close");
            }
        },
        close: function () {
            //$("#frmReserva").validate().resetForm();
            objReserva = null;
            MostrarDatosMaquina(0);
        }
    });

    $("#modalVendedores").dialog({
        autoOpen: false,
        width: 380,
        resizable: false,
        modal: true,
        close: function () {
            //$("#frmReserva").validate().resetForm();
            objReserva = null;
        }
    });

    $("#txtVendedorF").keyup(function (e) {
        if (e.keyCode == 13) {
            //MostrarBusquedaVendedor();
            ListarVendedores();
        }
    });



    $("#txtNroOrdenF").keyup(function (e) {
        if (e.keyCode == 13) {
            MostrarOrden();
        }
    });
});

function gridMaquinasReload(mantenerSeleccion, primeraPagina) {
    debugger;
    var filtro = obtenerObjetoFiltro();
    
    //alert($("input[name='rbSemaforo']:checked").val());
    //var radios = document.getElementsByName('rbSemaforo');
//    for (var i = 0, length = radios.length; i < length; i++) {
//        if (radios[i].checked) {
//            // do whatever you want with the checked radio
//            alert(radios[i].value);

//            // only one radio can be logically checked, don't check the rest
//            break;
//        }
//    }

    $("#jqgMaquinas").jqGrid()[0].p.postData = filtro;

    if (!mantenerSeleccion)
        idRowMaquina = null;

    if (primeraPagina)
        $("#jqgMaquinas").jqGrid('setGridParam', { page: 1 });

    $("#jqgMaquinas").jqGrid().trigger("reloadGrid");
};

function gridVendedorReload(mantenerSeleccion, primeraPagina) {
   
    var Matricula = $('#txtVendedorF').val();

   

    $("#jqgVendedores").jqGrid()[0].p.postData = { pMatricula: Matricula };

    if (!mantenerSeleccion)
        idRowMaquina = null;

    if (primeraPagina)
        $("#jqgVendedores").jqGrid('setGridParam', { page: 1 });

    $("#jqgVendedores").jqGrid().trigger("reloadGrid");

    
};

function obtenerObjetoFiltro() {
    return {
        pSucursal: $('#txtSucursal').val(),
        pMarca: $('#txtMarca').val(),
        pModelo: $('#txtModelo').val(),
        pSemaforo: $('#rbSemaforo').is(':checked') ? $('input[name=rbSemaforo]:checked').val():0,
        pFecIni: $('#filtroFechaDesde').val(),
        pFecFin: $('#filtroFechaHasta').val(),
        pOrden: $('#txtOrden').val(),
        pCliente: $('#txtClienteFiltro').val(),
        pVendedor: $('#txtVendedor').val(),
        pActividad: $('#ddlActividad').val(),
        pEstado: $('#ddlEstado').val()
    };
};

function mostrarModalIncidente(orden, data) {
    
        CargarDatosSeguimiento(data.int_ExpedienteId);
        $('#lblExpedienteId').text(data.int_ExpedienteId);
        $('#lblClienteFacturacion').text(data.str_ClienteFinal);
        $('#lblEntidadFinanciera').text(data.str_ClienteFinal);
        $('#lblVendedor').text(data.str_Vendedor);
        $('#lblFinanciamiento').text(data.str_Financiamiento);
        $('#lblFechaCreacion').text(data.str_FechaRegistro);
        $('#lblTipoFinanciamiento').text(data.str_Financiamiento);        
        $('#lblClienteFinal').text(data.str_ClienteFinal);
        $("#hdnFinanciamiento").val(data.str_Financiamiento);
        $("#modalIncidente").dialog("open");
        
        //$("#modalInformacionUnidad").dialog('option', 'title', titulosModal.informacionUnidad + ' - UNIDAD ' + orden);
        //mostrarInformacionMaquina(respuesta.data.maquina);
        //$('#modalInformacionUnidad').dialog('open');

};

function DesHabilitaTextosFacturas(bool) {       
    $("#txtNombreVendedorF, #txtClienteF, #txtNombreClienteF, #txtEntidadFinancieraF, #txtNombreEntidadFinancieraF, #txtNumeroSerieF").prop('disabled', bool);
    $("#txtNroOrdenF, #txtFamilaF, #txtMarcaF, #txtCuentaF, #txtSucursalF, #txtDescripcionSucursalF, #txtDescripcionCuentaF, #txtFinanciamientoF, #txtCliente, #txtNombreCliente").prop('disabled', bool);
}

    function mostrarDatosVendedor(vendedor, data) {

    $('#txtVendedorF').val(vendedor);
    $('#txtNombreVendedorF').val(data.str_NOMBRE);
    $('#txtSucursalF').val(data.str_SUCURSAL);
    $('#txtDescripcionSucursalF').val(data.str_DESC_SUCURSAL);
    $("#modalVendedores").dialog('close');
};

function MostrarDatosCliente() {

    var TipoFactura = $("#txtTipo").val();
    var Serie = $("#txtSerie").val();
    var Numero = $("#txtNro").val();
    debugger
    if (TipoFactura.trim()=="") {
        custom_alert("Debe ingresar Tipo Factura.");
        $("#txtTipo").focus();
        return;
    }
    if (Serie.trim() == "") {
        custom_alert("Debe ingresar Serie de factura.");
        $("#txtSerie").focus();
        return;
    }
    if (Numero.trim() == "") {
        custom_alert("Debe ingresar el N° de factura.");
        $("#txtNro").focus();
        return;
    }

    var Indicador = 0;
    if ($('#chkFacturaElectronica').is(":checked")) {
        Indicador = 1;
    }

    //ByVal pTipoFactura As String, ByVal pSerie As String, ByVal pNumFactura As String, ByVal pIndicadorFactElectronica As Integer)

    $.customAjax({ url: location.pathname + "/BuscarNumFacturaCliente", parametros: { pTipoFactura: TipoFactura, pSerie: Serie, pNumFactura : Numero,
                                                                                     pIndicadorFactElectronica : Indicador} },
                        function (respuesta) {
                            var Cliente=respuesta.data.Cliente;
                            if (respuesta.success) {
                                //Mostrar Datos facturas
                                $("#txtCliente").val(Cliente.CodCliente);
                                $("#txtNombreCliente").val(Cliente.DescripcionCliente);
                                $("#txtClienteF").val(Cliente.CodClienteFactura);
                                $("#txtNombreClienteF").val(Cliente.DescripcionClienteFactura);
                                $("#txtEntidadFinancieraF").val(Cliente.CodigoEntidadFinanciera);
                                $("#txtNombreEntidadFinancieraF").val(Cliente.DescripcionEntidadFinanciera);
                                $("#txtFechaFactura").val(Cliente.FechaFactura);
                            }
                        }, null, null, true
                     );
}

function MostrarDatosMaquina(pId) {
   
    var Id = 0;
    if (pId == null)
        Id = idRowMaquina;
    else
        Id = 0;

    $("#listUpload").val("");
    $("#upload").val("");
    $("#txtMontoRitmo5F, #txtTipoRitmo5F, #txtIdSapRitmo5F,#txtFechaFactura").prop('disabled', true);
    $("#txtMontoRpto").prop('disabled', true);
    debugger
    if (Id == 0) {
        $('#chkFacturaElectronica')[0].checked = false;
        $('#chkRitmo5F')[0].checked = false;
        $('#chkRepuesto')[0].checked = false;
        $('#chkTieneOrden')[0].checked = false;
        $("#txtVendedorF").val('');
        $("#txtNombreVendedorF,#txtObservacionF,#txtClienteF,#txtNombreClienteF,#txtEntidadFinancieraF,#txtNombreEntidadFinancieraF,#txtTipo").val('');
        $("#txtSerie,#txtNro,#txtNroOrdenF,#txtFamilaF,#txtMarcaF,#txtModeloIdGenericoF,#txtNumeroSerieF,#txtCuentaF,#txtFechaFactura,#txtDescripcionSucursalF").val('');
        $("#txtFinanciamientoF,#txtMontoRitmo5F,#txtTipoRitmo5F,#txtIdSapRitmo5F,#txtMontoRpto,#txtDescripcionCuentaF,#txtSucursalF,#txtCliente,#txtNombreCliente").val('');
        $("#btnArchivo").hide();
        $("#txtFechaFactura").attr('disabled', false);
        return;
    }

    $.customAjax({ url: location.pathname + "/ObtenerDatosOrden", parametros: { pOrden: Id} },
         function (respuesta) {
             if (respuesta.success) {
                 var datosOrden = respuesta.data.maquina;
                 var listaSap = respuesta.data.listasap;
                 var TieneArchivo = respuesta.data.TieneArchivo;
                 debugger;
                 if (datosOrden != null) {
                     $('#chkFacturaElectronica')[0].checked = false;
                     $('#chkTieneOrden')[0].checked = datosOrden.int_NoTieneNroorden == 0 ? false : true;
                     $("#txtVendedorF").val(datosOrden.str_VendedorId.trim());
                     $("#txtNombreVendedorF").val(datosOrden.str_VendedorDesc.trim());
                     $("#txtObservacionF").val(datosOrden.str_Observaciones.trim());
                    

                     $("#txtCliente").val(datosOrden.str_ClienteId.trim());
                     $("#txtNombreCliente").val(datosOrden.str_ClienteDesc.trim());
                     $("#txtClienteF").val(datosOrden.str_ClienteFacturaId.trim());
                     $("#txtNombreClienteF").val(datosOrden.str_ClienteFacturaDesc.trim());

                     $("#txtEntidadFinancieraF").val(datosOrden.str_EntidadFinancieraId.trim());
                     $("#txtNombreEntidadFinancieraF").val(datosOrden.str_FinanciamientoDesc.trim());
                     $("#txtTipo").val(datosOrden.str_SUNTIP.trim());
                     $("#txtSerie").val(datosOrden.int_SUNPRE);
                     $("#txtNro").val(datosOrden.int_SUNNUM);
                     $("#txtNroOrdenF").val(idRowMaquina.trim());
                     $("#txtFamilaF").val(datosOrden.str_FamiliaDesc.trim());
                     $("#txtMarcaF").val(datosOrden.str_MarcaDesc.trim());
                     $("#txtModeloIdGenericoF").val(datosOrden.str_ModeloProductoDesc.trim());
                     $("#txtNumeroSerieF").val(datosOrden.str_SerieMaquina.trim());
                     $("#txtCuentaF").val(datosOrden.str_CuentaInventarioDBS.trim());
                     $("#txtDescripcionCuentaF").val(datosOrden.str_DescripcionCuenta.trim());
                     $("#txtSucursalF").val(datosOrden.str_Sucursal.trim());
                     $("#txtDescripcionSucursalF").val(datosOrden.str_DescripcionSucursal.trim());
                     $("#hdnOrdenAsignada").val(datosOrden.str_OrdenAsignada);
                     $("#hdnTieneArchivo").val(TieneArchivo);
                 
                     if (TieneArchivo == "1" || TieneArchivo == 1)
                         $("#btnArchivo").show();
                     else
                         $("#btnArchivo").hide();

                     DesHabilitaTextosFacturas(true);
//                     if (datosOrden.str_SUNTIP != null && datosOrden.int_SUNPRE != null && datosOrden.int_SUNNUM != null) {
//                         if (datosOrden.str_SUNTIP != '' && datosOrden.int_SUNPRE != '' && datosOrden.int_SUNNUM != '') {
//                             $('#chkFacturaElectronica')[0].checked = true;
//                         }
//                     }
                     if (datosOrden.str_FechaFactura.trim() != '01/01/1900')
                         $("#txtFechaFactura").val(datosOrden.str_FechaFactura.trim());
                     else
                         $("#txtFechaFactura").val('');

                     if (listaSap != null) {
                         var i = 0;

                         for (i = 0; i < listaSap.length; i++) {
                             if (listaSap[i].ClaseId == 2) {
                                 $("#txtMontoRitmo5F").val(listaSap[i].Monto);
                                 $("#txtTipoRitmo5F").val(listaSap[i].Descripcion.trim());
                                 $("#txtIdSapRitmo5F").val(listaSap[i].BeneficioIdSAP.trim());
                                 $('#chkRitmo5F')[0].checked = true;
                                 $("#txtMontoRitmo5F, #txtTipoRitmo5F, #txtIdSapRitmo5F").prop('disabled', false);
                             }
                             if (listaSap[i].ClaseId == 1) {
                                 $("#txtMontoRpto").val(listaSap[i].Monto);
                                 $('#chkRepuesto')[0].checked = true;
                                 $("#txtMontoRpto").prop('disabled', false);
                             }
                         }
                     }

                 }

             }
         }, null, null, true
      );
}

function PintarSap(){
    $.customAjax({ url: location.pathname + "/ObtenerDatosOrden", parametros: { pOrden: Id} },
         function (respuesta) {
             

             
         }, null, null, true
      );
}

function CargarDatosSeguimiento(pExpedienteId) {


    $.customAjax({ url: location.pathname + "/ListarIncidencias", parametros: { pExpediente: pExpedienteId, pEstadoMaquina: 'ACT'} },
      function (respuesta) {
          var EsRitmo5 = respuesta.data.EsRitmo5;
          var EsBonoRpto = respuesta.data.EsBonoRpto;
          var TieneRitmo5 = respuesta.data.TieneRitmo5;
          var TieneBonoRpto = respuesta.data.TieneBonoRpto;
          var Advertencia = respuesta.data.Advertencia;
          var Archivos = respuesta.data.Archivos;
          var ActividadEstados = respuesta.data.ActividadEstados;
          var Actividad = respuesta.data.Actividad;
          var BotonesSigAnt = respuesta.data.ControlesFlujo;
          var listaExpedientes = respuesta.data.ListaExpedientes;
          var listaHistorial = respuesta.data.ListaHistorial;
          var Advertencia = respuesta.data.Advertencia;
          var ArchivosFirmados = respuesta.data.ArchivosFirmados;

          $("#btnAprobar,#btnAprobar,#btnBonoRpto,#btnBonoRitmo5").show();      
              
          //preload(false);         
          if (respuesta.success) {
              debugger;
              if (!Archivos.TieneArchivoBono)
                  $("#btnBonoRpto").hide();
              if (!Archivos.TieneArchivoCSA)
                  $("#btnBonoRitmo5").hide();



              if (Actividad != null) $("#hdnActividadActual").val(Actividad.ActividadId);
              if (ActividadEstados != null) $("#hdnActividadAnterior").val(ActividadEstados.ActividadAnterior);

              $("#hdnEsRitmo5").val(EsRitmo5 == true ? "1" : "0");
              $("#hdnEsRpto").val(EsBonoRpto == true ? "1" : "0");

              $("#btnAprobar").prop("disabled", !(BotonesSigAnt.btnHSiguiente));
              $("#btnDevolver").prop("disabled", !(BotonesSigAnt.btnHAnterior));

              //              if (!BotonesSigAnt.btnVSiguiente)
              //                  $("#btnAprobar").hide();
              //              if (!BotonesSigAnt.btnVAnterior)
              //                  $("#btnDevolver").hide();

              $("#btnBonoRptoFirmada,btnBonoRitmoFirmada").hide();

              if (listaHistorial.length > 0) {
                  $("#lblTituloIncidencia").text("Datos Generales - Actividad: " + listaHistorial[0].str_Actividad);
              }
              else {
                  $("#lblTituloIncidencia").text("Datos Generales - Actividad: SIN ACTIVIDAD");
              }

              $("#btnBonoRptoFirmada").hide();
              $("#btnBonoRitmoFirmada").hide();

              if (Advertencia.MensajeCuentas != '')
                  mostrarMensajePersonalizado({ tipo: 'success', mensaje: Advertencia.MensajeCuentas });

              jQuery("#jqgIncidencia").setGridParam({ rowNum: listaExpedientes.length });
              jQuery("#jqgIncidencia").jqGrid('setGridParam', { data: listaExpedientes }).trigger("reloadGrid");

              //jQuery("#jqgActividades").setGridParam({ rowNum: listaHistorial.length });
              $("#jqgActividades").jqGrid("clearGridData", true).trigger("reloadGrid");
              jQuery("#jqgActividades").jqGrid('setGridParam', { data: listaHistorial }).trigger("reloadGrid");

          } else {
              custom_alert(respuesta.msg);
          }
      }
   );
  }

  function ListarVendedores() {
      $.customAjax({ url: location.pathname + "/ListarTrabajadores", parametros: { pMatricula: $("#txtVendedorF").val()} },
      function (respuesta) {
          
          //preload(false);         
          if (respuesta.success) {
              $('#jqgIncidencia').jqGrid('clearGridData');
              
              //preload(false);


              if (respuesta.success) {
                  if (respuesta.data.length == 1) {
                      $('#txtVendedorF').val(respuesta.data[0].str_MATRICULA);
                      $('#txtNombreVendedorF').val(respuesta.data[0].str_NOMBRE);
                      $('#txtSucursalF').val(respuesta.data[0].str_SUCURSAL);
                      $('#txtDescripcionSucursalF').val(respuesta.data[0].str_DESC_SUCURSAL);             
                      return;
                  }

                  jQuery("#jqgVendedores").setGridParam({ rowNum: respuesta.data.length });
                  jQuery("#jqgVendedores").jqGrid('setGridParam', { data: respuesta.data }).trigger("reloadGrid");
                  MostrarBusquedaVendedor();
              }

              //              $("#jqgMaquinas").jqGrid('setGridParam', { datatype: "json" });
              //              $("#jqgMaquinas").jqGrid().trigger("reloadGrid");

          } else {
              custom_alert(respuesta.msg);
          }
      }
      );
   }

   function GuardarDatosFactura(obj) {
   
       var EsFactura = 0;
       var EsNuevo = true;
       var EsBonoRpto = 0;
       var EsBonoRitmo5 = 0;
       var Id = 0;
       var FechaFactura='01/01/1900'
       var NoTieneNroorden=0;
       FechaFactura = $("#txtFechaFactura").val();
      if ($('#chkFacturaElectronica').is(":checked")) {
          EsFactura = 1;
          
      }

      if ($('#chkRitmo5F').is(":checked")) 
          EsBonoRitmo5 = 1;      

      if ($('#chkRepuesto').is(":checked")) 
          EsBonoRpto = 1;     

      if ($("#hdnNuevaFactura").val() == "0")
          EsNuevo = false;
      
      if (idRowMaquina != null)
          Id = idRowMaquina;
        
      if($('#chkTieneOrden').is(":checked"))
         NoTieneNroorden=1;

     debugger;
     var file = document.getElementById('fileUpload'); //$("#fileUpload").val();
     

   
      var Datos = { Orden: $('#txtNroOrdenF').val(),
          VendedorId: $('#txtVendedorF').val(),
          VendedorDesc: $('#txtNombreVendedorF').val(),
          EntidadFinancieraId: $('#txtEntidadFinancieraF').val(),
          EntidadFinancieraDesc: $('#txtNombreEntidadFinancieraF').val(),
          CuentaInventarioDBS: $('#txtCuentaF').val(),
          DescripcionCuenta: $('#txtDescripcionCuentaF').val(),
          Sucursal: $('#txtSucursalF').val(),
          DescripcionSucursal: $('#txtDescripcionSucursalF').val(),
          FinanciamientoId: $('#txtFinanciamientoF').val(),
          FamiliaDesc: $('#txtFamilaF').val(),
          MarcaDesc: $('#txtMarcaF').val(),
          ModeloProductoDesc: $('#txtModeloIdGenericoF').val(),
          SerieMaquina: $('#txtNumeroSerieF').val(),
          Ritmo5: EsBonoRitmo5,
          MontoRitmo5: $.isNumeric($("#txtMontoRitmo5F").val()) ? $("#txtMontoRitmo5F").val(): 0,
          TipoRitmo5: $('#txtTipoRitmo5F').val(),
          IdSapRitmo5: $('#txtIdSapRitmo5F').val(),
          BonoRpto: EsBonoRpto,
          MontoBonoRpto:$.isNumeric($("#txtMontoRpto").val())?$("#txtMontoRpto").val():0,
          Observacion: $('#txtObservacionF').val(),
          EsFactura: EsFactura,
          SunTip: $('#txtTipo').val(),
          SunPre: $.isNumeric($('#txtSerie').val())?$('#txtSerie').val():0,
          SunNum: $.isNumeric($('#txtNro').val())?$('#txtNro').val():0,
          EsNuevo: EsNuevo,
          EsBonoRpto: EsBonoRpto,
          EsBonoRitmo5: EsBonoRitmo5,
          ClienteId: $('#txtCliente').val(),
          ClienteDesc: $('#txtNombreCliente').val(),
          ClienteFacturaId: $("#txtClienteF").val(),
          ClienteFacturaDesc: $("#txtNombreClienteF").val(),
          FechaFactura: FechaFactura,
          NoTieneNroorden: NoTieneNroorden,
          Archivo: $("#hdnArchivos").val()
      };

      $.customAjax({ url: location.pathname + "/GuardarMaquinaBono", parametros: { maquina: Datos} },
                        function (respuesta) {
                            var Resultado = respuesta.data;
                            if (Resultado == "-1") {
                                custom_alert("El N° de Factura ya ha sido registrado.", "Factura Manual");  
                                return;
                            }
                            if (respuesta.success) {

                                mostrarMensajeProceso({ tipo: 'success', mensaje: mensajesProceso.modificarMaquinaOK });
                                obj.dialog('close');
                                gridMaquinasReload(true);
                            }
                        }, null, null, true
                     );

  }


  function ActivaInactivaDocumento() {
      var Seleccionado = $('#chkFacturaElectronica').is(":checked");
      $('#txtTipo, #txtSerie, #txtNro').val('');
      if (Seleccionado) {
          $('#txtTipo, #txtSerie, #txtNro').prop('disabled', false);          
      }
      else {
          $('#txtTipo, #txtSerie, #txtNro').prop('disabled', true);          
      }
      $('#txtTipo').focus();
  }

  function MostrarBusquedaVendedor() {
      //var row = $("#jqgIncidencia").getRowData(idRowIncidente);
      $("#modalVendedores").dialog('option', 'title', '');
      // $('#txtObservacion').val(row.str_Observaciones);
      $('#modalVendedores').dialog('open');

  }

  function NuevaFacturaManual() {
     
      $("#hdnNuevaFactura").val("1");
      MostrarDatosMaquina(0);
      DesHabilitaTextosFacturas(true);
      $("#txtNroOrdenF,#txtFamilaF").prop('disabled', false);
      $("#txtModeloIdGenericoF").prop('disabled', true);
      
      $("#modalFactura").dialog('option', 'title', 'Máquina');
      $('#modalFactura').dialog('open');
  }

  function MostrarOrden() {
     
      var Orden = $("#txtNroOrdenF").val();
      $("#txtClienteF").val("");
      $("#txtNombreClienteF").val("");
      $("#txtClienteF").val("");
      $("#txtCuentaF").val("");
      $("#txtDescripcionCuentaF").val("");

      $.customAjax({ url: location.pathname + "/BuscarOrden", parametros: { pOrden: Orden} },
      function (respuesta) {
         
          var exito = respuesta.success;
          var item = respuesta.data;
          //preload(false);         
          if (exito) {
              $("#txtClienteF").val(item.codCliente);
              $("#txtNombreClienteF").val(item.desCliente);
              $("#txtEntidadFinancieraF").val(item.codCliente);
              $("#txtNombreEntidadFinancieraF").val(item.desCliente);
              //$("#txtClienteF").val(item.codCleinte);
              $("#txtCuentaF").val(item.IdCuenta);
              $("#txtDescripcionCuentaF").val(item.DesCuenta);
              $("#txtMarcaF").val(item.Marca);
              $("#txtModeloIdGenericoF").val(item.Modelo);
              $("#txtNumeroSerieF").val(item.NumeroSerie);
              
          } else {
              custom_alert(respuesta.msg);
          }
      }, null, null, true
   );
  }

  function ActivaInactivaRitmo5() {
      var SeleccionaRitmo5 = $('#chkRitmo5F').is(":checked");
      $("#txtMontoRitmo5F, #txtTipoRitmo5F, #txtIdSapRitmo5F").prop('disabled', !SeleccionaRitmo5);
      $("#txtMontoRitmo5F, #txtTipoRitmo5F, #txtIdSapRitmo5F").val('');
      $("#txtMontoRitmo5F").focus();
  }

  function ActivaInactivaRpto() {
      var SeleccionaRpto = $('#chkRepuesto').is(":checked");
      $("#txtMontoRpto").prop('disabled', !SeleccionaRpto);
      $("#txtMontoRpto").val('');
      $("#txtMontoRpto").focus();

  }



  function SiguienteActividad() {
      custom_confirmation(function () {
          var ExpedienteId = $("#lblExpedienteId").text();
          var ActividadActual = $("#hdnActividadActual").val();
          var flgRitmo5 = $("#hdnEsRitmo5").val() == "1" ? true : false;
          var flgBonoRpto = $("#hdnEsRpto").val() == "1" ? true : false;
          var BonoFirmado = $("#hdnTieneRitmo5").val() == "1" ? true : false;
          var BonoRitmo5 = $("#hdnTieneRpto").val() == "1" ? true : false;
          var ArchivoFirmadoBono = $("#hdnArchivoBonoFirmado").val();
          var ArchivoFirmadoCSA = $("#hdnArchivoCSAFirmado").val();

          $.customAjax({ url: location.pathname + "/SiguienteActividad", parametros: { pExpedienteId: ExpedienteId, pActividadActual: ActividadActual,
              pflgRitmo5: flgRitmo5, pflgBonoRpto: flgBonoRpto, pBonofirmado: BonoFirmado, pBonoRitmo5: BonoRitmo5
          }
          },
                        function (respuesta) {
                            var MensajeArchivo = "";
                            var GeneraCarta = false;

                            if (respuesta.success) {
                                MensajeArchivo = respuesta.data.MensajeArchivo;
                                GeneraCarta = respuesta.data.GeneraCartaRitmo5;
                                $("#modalIncidente").dialog("close");
                                //Enviar al enlace de generar carta y enviar a a bandeja resultado
                                //if (GeneraCarta)
                                gridMaquinasReload(false, true);
                                //location.href = 'frmResultado.aspx';                              
                            }
                        }, null, null, true
    );


      },
    function () {
    },
        "¿Desea pasar a la siguiente actividad?"
    );
}

function AnteriorActividad() {

    custom_confirmation(function () {

    var ExpedienteId = $("#lblExpedienteId").text();
    var ActividadActual = $("#hdnActividadAnterior").val();
    var flgRitmo5 = $("#hdnEsRitmo5").val() == "1" ? true : false;
    var flgBonoRpto = $("#hdnEsRpto").val() == "1" ? true : false;
    var BonoFirmado = $("#hdnTieneRitmo5").val() == "1" ? true : false;
    var BonoRitmo5 = $("#hdnTieneRpto").val() == "1" ? true : false;

        $.customAjax({ url: location.pathname + "/AnteriorActividad", parametros: { pExpediente: ExpedienteId, pActividadAnterior: ActividadActual}
        },
                            function (respuesta) {
                       
                                if (respuesta.success) {
                                    //location.href = 'frmResultado.aspx';  
                                    $("#modalIncidente").dialog("close");                         
                                    gridMaquinasReload(false, true);
                                    custom_alert("Actividad fue devuelta satisfactoriamente.", "Bonos");                        
                                }
                            }, null, null, true
        );

    },
    function () {
    },
        "¿Desea regresar a la actividad anterior?"
    );
}





function mostrarMensajePersonalizado(parametros) {
    var count = 1000;

    var config = {
        tipo: 'warning',
        mensaje: 'Mensaje...',
        oculto: false
    };
    var objNew = $.extend(config, parametros),

html_base = '<div style="z-index:' + count++ + '" id="alert' + count++ + '" class="hide alert alert-' + objNew.tipo + ' alert-process">' +
	'<i></i>' + objNew.mensaje +
	'<button type="buttom" class="close alert-process-close" title="Cerrar">' +
		'Cerrar' +
	'</button>' +
'</div>';
    var time = '500', timeHide = '60000', msjHTML;
    var closeAlertHTML = function (_html, time) {
        _html.fadeOut(time, function () {
            _html.remove();
        });
    };
    if (!objNew.oculto) {
        jQuery('body>.alert-process').remove();
        jQuery('body').prepend(html_base);
        msjHTML = jQuery('body>.alert-process').eq(0);
        msjHTML.fadeIn(time);
        jQuery('body>.alert-process>.alert-process-close').eq(0).click(function () {
            var _t = jQuery(this).parent();
            closeAlertHTML(_t, time);
        });
        //Cerrado por tiempo
        setTimeout(function () {
            closeAlertHTML(msjHTML, time);
        }, timeHide);
    } else {
        //Cerrado
        msjHTML = jQuery('body>.alert-process').eq(0);
        closeAlertHTML(msjHTML, 1000);
    }
};

function DescargarArchivo() {
    var strOrdenAsignada = { strOrdenAsignada: $('#hdnOrdenAsignada').val()}
    $.customFileDownload("MaquinaArchivo.ashx", strOrdenAsignada);
};

function DescargarBono(claseId) {
    var Datos = { intExpedienteId: $('#lblExpedienteId').text(), intClaseId: claseId }   
    $.customFileDownload("ExpedienteArchivo.ashx", Datos);
};



function LimpiarBandeja() {
    $("#txtSucursal,#txtMarca,#txtModelo,#txtOrden,#txtCliente,#txtVendedor,#filtroFechaDesde,#filtroFechaHasta").val("");
}