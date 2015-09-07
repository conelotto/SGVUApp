$(function () {
    $(document).tooltip();
});

var mensajesProceso = {
    RegistrarProgramaOK: 'Programa se registró correctamente.',
    ActualizarProgramaOK: 'Programa se actualizo correctamente.',
    EliminarProgramaOK: 'Se deshabilito el programa correctamente.'
}

var gridView = !(navigator.appName == 'Microsoft Internet Explorer');
var idRow = null;
var selectRow = null;
var valCellSolicitud = null;

$(document).ready(function () {

    var CurrentDate = new Date();

    GetData_FlujoPopup();
    GetData_FlujoSearch();
    GetData_StatusSearch();


    //Accordion
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~        
    $("#Accordion_CriteriosBusqueda").accordion({
        collapsible: true,
        heightStyle: 'content'
    });

    $("#dtFechaInicio").datepicker({
        numberOfMonths: 1,
        showButtonPanel: true,
        changeMonth: true,
        changeYear: true
    });

    $("#dtFechaInicio").datepicker("setDate", CurrentDate);

    $("#dtFechaFin").datepicker({
        numberOfMonths: 1,
        showButtonPanel: true,
        changeMonth: true,
        changeYear: true
    });

    $("#dtFechaFin").datepicker("setDate", CurrentDate);

    //Grilla - Principal
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ 

    $("#jqgMantenimientoProgramas").jqGrid({

        url: location.pathname + "/GetData_Programas",
        mtype: "POST",
        datatype: "json",

        ajaxGridOptions: {
            contentType: 'application/json; charset=utf-8'
        },

        postData: {
            Filter: {
                strCodigo: '',
                strDescripcion: '',
                intFlujo: 0
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
                { label: ' ', name: 'accionUpd', index: 'accion', width: 25, align: "center" },
                { label: ' ', name: 'accionDel', index: 'accion', width: 25, align: "center" },
                { label: 'int_ProgramasId', name: 'int_ProgramasId', index: 'int_ProgramasId', width: 25, align: "center", hidden: true },
                { label: 'Código', name: 'str_IdProgramaCAT', index: 'str_IdProgramaCAT', width: 170 },
                { label: 'Descripción', name: 'str_DescPrograma', index: 'str_DescPrograma', width: 220 },
                { label: 'Fecha de Inicio', name: 'det_FechaInicio', index: 'det_FechaInicio', align: "center", width: 120, align: "center", formatter: 'date', formatoptions: { srcformat: 'd/m/Y', newformat: 'd/m/Y'} },
                { label: 'Fecha de Fin', name: 'det_FechaFin', index: 'det_FechaFin', align: "center", width: 120, align: "center", formatter: 'date', formatoptions: { srcformat: 'd/m/Y', newformat: 'd/m/Y'} },
                { label: 'Flujo', name: 'str_RolFlujoDesc', index: 'str_RolFlujoDesc', width: 200 },
                { label: 'F. Creación', name: 'det_FechaCreacion', index: 'det_FechaCreacion', align: "center", width: 100, align: "center", formatter: 'date', formatoptions: { srcformat: 'd/m/Y', newformat: 'd/m/Y'} },
                { label: 'Usuario', name: 'str_UsuarioCreacion', index: 'str_UsuarioCreacion', width: 120 },
                { label: 'F. Modificación', name: 'det_FechaModificacion', index: 'det_FechaModificacion', align: "center", width: 100, align: "center", formatter: 'date', formatoptions: { srcformat: 'd/m/Y', newformat: 'd/m/Y'} },
                { label: 'Usuario', name: 'str_UsuarioModificacion', index: 'str_UsuarioModificacion', width: 120 },
                { label: 'Estado', name: 'bl_ProgramaStatus', index: 'bl_ProgramaStatus', width: 50, editable: true, edittype: 'checkbox', editoptions: { value: "True:False" }, formatter: "checkbox", formatoptions: { disabled: true }, align: "center" },
                { label: 'int_RolFlujoId', name: 'int_RolFlujoId', index: 'int_RolFlujoId', width: 25, align: "center", hidden: true }
          ],

        rowNum: 1000,
        rownumbers: true,
        rowList: [20, 50, 80],
        viewrecords: true,
        loadtext: 'Cargando datos...',
        recordtext: "<b>{2} registros encontrados</b>",
        emptyrecords: 'No se encontraron registros',
        pgtext: 'Pág: {0} de {1}',
        caption: "Relación de Programas",
        pager: '#pagerjqgMantenimientoProgramas',
        regional: 'es',
        gridview: gridView,
        cmTemplate: { title: false },

        gridComplete: function () {
            var ids = $("#jqgMantenimientoProgramas").jqGrid('getDataIDs'); 
            for (var i = 0; i < ids.length; i++) {
                upd = "<img src='../Images/edit.png' style='cursor:pointer;' title='Editar Programa' onclick=\"EditPrograms('" + ids[i] + "');\" />";
                del = "<img src='../Images/btnUnvalidated.png' style='cursor:pointer;' title='Deshabilitar Programa' onclick=\"DisabledProgramas('" + ids[i] + "');\" />";
                $("#jqgMantenimientoProgramas").jqGrid('setRowData', ids[i], { accionUpd: upd, accionDel: del });
            }
        }
    });

    $("#frmInformacionUsuarios").validate({
        rules: {
            txtCodigo: "required",
            txtDescripcion: "required",
            selectFlujo: "required",
            dtFechaInicio: "required",
            dtFechaFin: "required"
        },
        messages: {
            txtCodigo: "<br> Ingrese código.",
            txtDescripcion: "<br> Ingrese descripción.",
            selectFlujo: "<br> Seleccione flujo.",
            dtFechaInicio: "<br> Seleccione Fecha Inicio.",
            dtFechaFin: "<br> Seleccione Fecha Fin"
        }
    });

    $("#modalInformacionProgramas").dialog({
        autoOpen: false,
        width: 450,
        height: 320,
        resizable: false,
        modal: true,
        close: function () {
            $('#frmInformacionProgramas').validate().resetForm();
            $('#txtCodigo').val("");
            $('#txtDescripcion').val("");
            $('#selectFlujo').val("");
            $('#dtFechaInicio').val("");
            $('#dtFechaFin').val("");
            $('#lblTypeTrans').val("");
            $('#lblProgramasId').val("");
        },
        buttons: {
            "Grabar": function () {
                var $this = $(this);
                if ($("#frmInformacionProgramas").valid()) {
                    var parametros = {
                        Codigo: $('#txtCodigo').val(),
                        Descripcion: $('#txtDescripcion').val(),
                        Flujo: $('#selectFlujo').val(),
                        FechaInicio: $("#dtFechaInicio").datepicker({ dateFormat: 'dd-mm-yyyy' }).val(),
                        FechaFin: $("#dtFechaFin").datepicker({ dateFormat: 'dd-mm-yyyy' }).val(),
                        TypeTrans: $('#lblTypeTrans').val(),
                        ProgramaId: $('#lblProgramasId').val()
                    };

                    $.customAjax({ url: location.pathname + "/RegistrarProgramas", parametros: parametros },
                        function (respuesta) {
                            if (respuesta.success) {
                                mostrarMensajeProceso({ tipo: 'success', mensaje: mensajesProceso.RegistrarProgramaOK });
                                $("#jqgMantenimientoProgramas").jqGrid().trigger("reloadGrid");
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

    $("#btnNuevoPrograma").click(function () {
        GetData_FlujoPopup();
        $('#lblTypeTrans').val("1");
        $("#modalInformacionProgramas").dialog('option', 'title', 'Mantenimiento de Programas');
        $('#modalInformacionProgramas').dialog('open');
    });

    function GetData_FlujoPopup() {
        $.ajax({
            type: "POST",
            url: location.pathname + "/GetData_Flujo",
            data: '',
            contentType: "application/json; charset=utf-8",
            dataType: "json",

            success: function (msg) {
                $("#selectFlujo").empty().append($("<option></option>").val("0").html("Seleccione Flujo..."));
                $.each(msg.d, function (i, item) {
                    $('#selectFlujo').append($('<option>', {
                        value: item.int_RolFlujoId,
                        text: item.str_RolFlujoDesc
                    }));
                });
            },
            error: function () {
                alert("Error al cargar flujo.");
            }
        });
    }

});

function EditPrograms(id) {
    $.ajax({
        type: "POST",
        url: location.pathname + "/GetData_Flujo",
        data: '',
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        success: function (msg) {
            $("#selectFlujo").empty().append($("<option></option>").val("0").html("Seleccione Flujo..."));
            $.each(msg.d, function (i, item) {
                $('#selectFlujo').append($('<option>', {
                    value: item.int_RolFlujoId,
                    text: item.str_RolFlujoDesc
                }));
            });

            var row = $("#jqgMantenimientoProgramas").jqGrid('getRowData', id);
            $('#lblTypeTrans').val("2");
            $('#lblProgramasId').val(id);
            $('#txtCodigo').val(row.str_IdProgramaCAT);
            $('#txtDescripcion').val(row.str_DescPrograma);
            $('#selectFlujo').val(row.int_RolFlujoId);
            $("#dtFechaInicio").datepicker({ dateFormat: 'dd-mm-yyyy' }).val(row.det_FechaInicio);
            $("#dtFechaFin").datepicker({ dateFormat: 'dd-mm-yyyy' }).val(row.det_FechaFin);
            $("#modalInformacionProgramas").dialog('option', 'title', 'Mantenimiento de Programas');
            $('#modalInformacionProgramas').dialog('open');
        },
        error: function () {
            alert("Error al cargar datos.");
        }
    });
}

function GetData_FlujoSearch() {
    $.ajax({
        type: "POST",
        url: location.pathname + "/GetData_Flujo",
        data: '',
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        success: function (msg) {
            $("#selectFlujoCon").empty().append($("<option></option>").val("0").html("Seleccione..."));
            $.each(msg.d, function (i, item) {
                $('#selectFlujoCon').append($('<option>', {
                    value: item.int_RolFlujoId,
                    text: item.str_RolFlujoDesc
                }));
            });
        },
        error: function () {
            alert("Error al cargar flujo.");
        }
    });
}

function GetData_StatusSearch() {
    $.ajax({
        type: "POST",
        url: location.pathname + "/GetData_Status",
        data: '',
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        success: function (msg) {
            $("#selectEstadoCon").empty().append($("<option></option>").val("0").html("Seleccione..."));
            $.each(msg.d, function (i, item) {
                $('#selectEstadoCon').append($('<option>', {
                    value: item.str_MasterTable_Valor,
                    text: item.str_MasterTable_Descripcion
                }));
            });
        },
        error: function () {
            alert("Error al cargar estado.");
        }
    });
}

function DisabledProgramas(id) {
    var row = $("#jqgMantenimientoProgramas").jqGrid('getRowData', id);
    var ProgramId = null;
    var ProgramaCode = null;
    var ProgramaName = null;
    ProgramId = row.int_ProgramasId;
    ProgramaCode = row.str_IdProgramaCAT;
    ProgramaName = row.str_DescPrograma;

    if (ProgramId != null) {
        custom_confirmation(function () {
            var parametros = {
                ProgramaId: ProgramId
            }
            $.customAjax({ url: location.pathname + "/EliminarProgramas", parametros: parametros },
            function (respuesta) {
                if (respuesta.success) {
                    $("#jqgMantenimientoProgramas").jqGrid().trigger("reloadGrid");
                    mostrarMensajeProceso({ tipo: 'success', mensaje: mensajesProceso.EliminarProgramaOK });
                }
            }, null, null, true
            );
        },
            function () {
            },
            "<b>Ud. está seguro de deshabilitar el siguiente programa?</b>" + "<br> &nbsp; &#8226 Código: " + ProgramaCode + "<br> &nbsp; &#8226 Descripción: " + ProgramaName,
            420
        );
    }
}

function CleanFilter() {
    $('#txtCodigoCon').val("");
    $('#txtDescripcionCon').val("");
    $('#selectFlujoCon').val("");
    GetData_FlujoSearch();
};

function UndoSearch() {
    var Filter = {
        strCodigo: '',
        strDescripcion: '',
        intFlujo: 0
    };
    $("#jqgMantenimientoProgramas").jqGrid()[0].p.postData.Filter = Filter;
    $("#jqgMantenimientoProgramas").jqGrid().trigger("reloadGrid");
    CleanFilter();
};

function DoSearch() {
    var Filter = {
        strCodigo: $('#txtCodigoCon').val(),
        strDescripcion: $('#txtDescripcionCon').val(),
        intFlujo: $('#selectFlujoCon').val()
    };

    $("#jqgMantenimientoProgramas").jqGrid()[0].p.postData.Filter = Filter;
    $("#jqgMantenimientoProgramas").jqGrid().trigger("reloadGrid");
};

