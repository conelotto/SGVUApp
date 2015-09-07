$(function () {
    $(document).tooltip();
});

var mensajesProceso = {
    RegistrarLineaOK: 'Linea de Venta se registró correctamente.',
    ActualizarLineaOK: 'Linea de Venta se actualizo correctamente.',
    EliminarLineaoOK: 'Se deshabilito Linea de Venta correctamente.',
}

var gridView = !(navigator.appName == 'Microsoft Internet Explorer');
var idRow = null;
var selectRow = null;
var valCellSolicitud = null;
var SignatureFileUpload = $("#fileSignature");
var dataLinea = [];
var UrlUpload = window.location.origin + "/Carga/CargaBase.ashx";


$(document).ready(function () {

    GetData_EnterpriceSearch();

    $("#fileSignature").change(function () {

        var files = $(this).prop("files");
        var output = [];        

        for (var i = 0, f; f = files[i]; i++) {
           output.push('<li><strong>', escape(f.name), '</strong> - ', f.size, ' bytes', '</li>');
        }

        document.getElementById('outListFiles').innerHTML = '<ul>' + output.join('') + '</ul>';

        for (i = 0; i < files.length; i++) { 
           uploadFile(i);       
        }
    });

  function uploadFile(position) {


        var files = $("#fileSignature").prop("files");
        var form_data = new FormData();

        form_data.append("file", files[position]);
        $.ajax({
 
            url: UrlUpload,
            cache: false,
            contentType: false,
            processData: false,
            data: form_data,
            type: 'post',
            success: function (response) {
                console.log(response);  
                files[position].newName = response.files[0].newName;
                $('#lblFileSignature').val(response.Resultado) 
            },
            error: function (xhr, ajaxOptions, thrownError) {
                console.log("error");
            },
            complete: function () {
                console.log("completado");
            }
        })
    };

    //Accordion
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~        
    $("#Accordion_CriteriosBusqueda").accordion({
        collapsible: true,
        heightStyle: 'content'
    });

    //Grilla - Principal
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ 
     $("#jqgMantenimientoLinea").jqGrid({

        url: location.pathname + "/GetData_LineaVenta",
        mtype: "POST",
        datatype: "json",

        ajaxGridOptions: {
            contentType: 'application/json; charset=utf-8'
        },

        postData: {
            Filter: {
                DescLineaVenta: '',
                NombreFirma: '',
                CargoFirma: '',
                IdCompania: ''
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
                { label: 'int_IdLineaVenta', name: 'int_IdLineaVenta', index: 'int_IdLineaVenta', width: 100, hidden: true, key: true },
                { label: 'Linea de Venta', name: 'str_DescLineaVenta', index: 'str_DescLineaVenta', width: 250 },
                { label: 'Firma Nombre', name: 'str_NombreFirma', index: 'str_NombreFirma', width: 230 },              
                { label: 'Firma Cargo', name: 'str_CargoFirma', index: 'str_CargoFirma', width: 230 },  
                { label: 'Firma Imagen', name: 'str_NombreImagenFirma', index: 'str_NombreImagenFirma', width: 180, formatter: formatOrden, unformat: unformatOrden },   
                { label: 'Firma Nombre', name: 'str_ImagenFirmaNombre', index: 'str_ImagenFirmaNombre', width: 200, hidden: true },  
                { label: 'str_IdCompania', name: 'str_IdCompania', index: 'str_IdCompania', width: 180, hidden: true },
                { label: 'Compañia', name: 'str_CompaniaDes', index: 'str_CompaniaDes', width: 200 },
                { label: 'Días de Reserva', name: 'int_DiasReserva', index: 'int_DiasReserva', width: 90, align: "center" },
                { label: 'Washout', name: 'bl_Washout', index: 'bl_Washout', width: 90, editable: true, edittype: 'checkbox', editoptions: { value: "True:False" }, formatter: "checkbox", formatoptions: { disabled: true }, align: "center" },
                { label: 'F. Creación', name: 'det_FechaCreacion', index: 'det_FechaCreacion', width: 100, align: "center", formatter: 'date', formatoptions: { srcformat: 'd/m/Y', newformat: 'd/m/Y'}, hidden: true },
                { label: 'U. Creación', name: 'str_UsuarioCreacion', index: 'str_UsuarioCreacion', width: 180, hidden: true },
                { label: 'Estado', name: 'bl_StatusLineaVenta', index: 'bl_StatusLineaVenta', width: 50, editable: true, edittype: 'checkbox', editoptions: { value: "True:False" }, formatter: "checkbox", formatoptions: { disabled: true }, align: "center" }
                ], 
  
        rowNum: 1000,
        rownumbers: true,
        rowList: [20, 50, 80],
        viewrecords: true,
        loadtext: 'Cargando datos...',
        recordtext: "<b>{2} registros encontrados</b>",
        emptyrecords: 'No se encontraron registros',
        pgtext: 'Pág: {0} de {1}',
        caption: "Relación de Lineas de Venta",
        pager: '#pagerjqgMantenimientoLinea',
        regional: 'es',
        gridview: gridView,
        cmTemplate: { title: false },

        gridComplete: function () {
            var ids = $("#jqgMantenimientoLinea").jqGrid('getDataIDs');
            for (var i = 0; i < ids.length; i++) {
                upd = "<img src='../Images/edit.png' style='cursor:pointer;' title='Editar Linea de Venta' onclick=\"EditLineaVenta('" + ids[i] + "');\" />";
                del = "<img src='../Images/btnUnvalidated.png' style='cursor:pointer;' title='Deshabilitar Linea de Venta' onclick=\"EliminarLineaVenta('" + ids[i] + "');\" />";
                $("#jqgMantenimientoLinea").jqGrid('setRowData', ids[i], { accionUpd: upd, accionDel: del });
            }
        }
    });

    $("#frmInformacionLinea").validate({
        rules: {
            txtLinea: "required",
            txtNombreFirma: "required",
            txtCargoFirma: "required",
            txtDias: "required"
        },
        messages: {
//            NombresModal: "<br> Ingrese nombres.",
//            ApellidosModal: "<br> Ingrese apellidos.",
//            UsuarioWindowsModal: "<br> Ingrese usuario windows.",
//            EmailModal: "<br> Ingrese email.",
//            CompaniaModal: "<br> Seleccione Compañia"
        }
    });

    $("#modalInformacionLinea").dialog({
        autoOpen: false,
        width: 480,
        height: 420,
        resizable: false,
        modal: true,
        close: function () {
            $('#frmInformacionLinea').validate().resetForm();
            $('#txtLinea').val("");
            $('#txtNombreFirma').val("");
            $('#txtCargoFirma').val("");
            SignatureFileUpload.replaceWith( SignatureFileUpload = SignatureFileUpload.clone( true ) );
            $('#txtDias').val("");
            $('#SelectCompania').val("");
            document.getElementById("chkWashout").checked = false;
            $('#lblFileName').text(""); 
        },
        buttons: {
            "Grabar": function () {

                var $this = $(this);
                if ($("#frmInformacionLinea").valid()) {
                    var parametros = {
                        TypeTrans: $('#lblTypeTrans').val(),
                        LineaVentaId: $('#lblLineaVentaId').val(),
                        LineaVenta: $('#txtLinea').val(),
                        FirmaNombre: $('#txtNombreFirma').val(),
                        FirmaCargo: $('#txtCargoFirma').val(),
                        Dias: $('#txtDias').val(),                        
                        Washout: document.getElementById("chkWashout").checked,
                        CompaniaId: $('#SelectCompania').val(),
                        Firma: $('#lblFileSignature').val()
                    };

                    $.customAjax({ url: location.pathname + "/RegistrarLineaVenta", parametros: parametros },
                        function (respuesta) {
                            if (respuesta.success) {
                                mostrarMensajeProceso({ tipo: 'success', mensaje: mensajesProceso.RegistrarLineaOK });
                                $("#jqgMantenimientoLinea").jqGrid().trigger("reloadGrid");
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

    $("#btnNuevoLinea").click(function () {
        GetData_EnterpricePopup();
        $('#lblTypeTrans').val("1");
        $('#lblFileName').val(""); 
        $("#modalInformacionLinea").dialog('option', 'title', 'Mantenimiento de Linea de Venta');
        $('#modalInformacionLinea').dialog('open');
    });
});
 
function GetData_EnterpricePopup() {
    $.ajax({
        type: "POST",
        url: location.pathname + "/GetData_Enterprice",
        data: '',
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        success: function (msg) {
            $("#SelectCompania").empty().append($("<option></option>").val("0").html("Seleccione Compañia..."));
            $.each(msg.d, function (i, item) {
                $('#SelectCompania').append($('<option>', {
                    value: item.str_MasterTable_Valor,
                    text: item.str_MasterTable_Descripcion
                }));
            });
        },
        error: function () {
            alert("Error al cargar compañias.");
        }
    });
}

function EditLineaVenta(id) {
    $.ajax({
        type: "POST",
        url: location.pathname + "/GetData_Enterprice",
        data: '',
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        success: function (msg) {
            $("#SelectCompania").empty().append($("<option></option>").val("0").html("Seleccione Linea Compañia..."));
            $.each(msg.d, function (i, item) {
                $('#SelectCompania').append($('<option>', {
                    value: item.str_MasterTable_Valor,
                    text: item.str_MasterTable_Descripcion
                }));
            });

            debugger;

            var row = $("#jqgMantenimientoLinea").jqGrid('getRowData', id);
            $('#lblTypeTrans').val("2");
            $('#lblLineaVentaId').val(id);
            $('#txtLinea').val(row.str_DescLineaVenta);
            $('#txtNombreFirma').val(row.str_NombreFirma);
            $('#txtCargoFirma').val(row.str_CargoFirma);
            $('#txtDias').val(row.int_DiasReserva);
            $('#lblFileName').text(row.str_ImagenFirmaNombre);
                                              
            if (row.bl_Washout == "True"){
             document.getElementById("chkWashout").checked = true
            }else{
                document.getElementById("chkWashout").checked = false 
            };                 
            
            $('#SelectCompania').val(row.str_IdCompania)
            $("#modalInformacionLinea").dialog('option', 'title', 'Mantenimiento de Linea de Venta');
            $('#modalInformacionLinea').dialog('open');
        },
        error: function () {
            alert("Error al cargar datos.");
        }
    });
}
     
function EliminarLineaVenta(id) {
    var row = $("#jqgMantenimientoLinea").jqGrid('getRowData', id);
    var LineaId = null;
    var Linea = null;
    LineaId = row.int_IdLineaVenta;
    Linea = row.str_DescLineaVenta;

    if (LineaId != null) {
        custom_confirmation(function () {
            var parametros = {
               LineaId : LineaId
            }
            $.customAjax({ url: location.pathname + "/EliminarLineaVenta", parametros: parametros },
            function (respuesta) {
                if (respuesta.success) {
                    $("#jqgMantenimientoLinea").jqGrid().trigger("reloadGrid");
                    mostrarMensajeProceso({ tipo: 'success', mensaje: mensajesProceso.EliminarLineaoOK });
                }
            }, null, null, true
            );
        },
            function () {
            },
            "<b>Ud. está seguro de deshabilitar la linea de venta?</b>" + "<br> &nbsp; &#8226 Descripción: " + Linea,420
        );
    }
}

function GetData_EnterpriceSearch() {
    $.ajax({
        type: "POST",
        url: location.pathname + "/GetData_Enterprice",
        data: '',
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        success: function (msg) {
            $("#selectCompaniaCon").empty().append($("<option></option>").val("0").html("Seleccione..."));
            $.each(msg.d, function (i, item) {
                $('#selectCompaniaCon').append($('<option>', {
                    value: item.str_MasterTable_Valor,
                    text: item.str_MasterTable_Descripcion
                }));
            });
        },
        error: function () {
            alert("Error al cargar compañias.");
        }
    });
}

function CleanFilter() {
    $('#txtLineaCon').val("");
    $('#txtFirmaNombreCon').val("");
    $('#txtFirmaCargoCon').val("");
    $('#selectCompaniaCon').val("");
    GetData_EnterpriceSearch(); 
};

function UndoSearch() {
    var Filter = {
        DescLineaVenta: '',
        NombreFirma: '',
        CargoFirma: '',
        IdCompania: ''
    };
    $("#jqgMantenimientoLinea").jqGrid()[0].p.postData.Filter = Filter;
    $("#jqgMantenimientoLinea").jqGrid().trigger("reloadGrid");
    CleanFilter();
};

function DoSearch() {
    var Filter = {
        DescLineaVenta: $('#txtLineaCon').val(),
        NombreFirma: $('#txtFirmaNombreCon').val(),
        CargoFirma: $('#txtFirmaCargoCon').val(),
        IdCompania: $('#selectCompaniaCon').val() == '0' ? "" : $('#selectCompaniaCon').val()
    };

    $("#jqgMantenimientoLinea").jqGrid()[0].p.postData.Filter = Filter;
    $("#jqgMantenimientoLinea").jqGrid().trigger("reloadGrid");
};

function formatOrden(cellValue, options, rowObject) {
return "<span style='color:#0000CC; text-decoration: underline; cursor:pointer;'>" + cellValue + "</span>";
};  

function unformatOrden(cellValue, options, cellObject) {
return $(cellObject.html()).attr("originalValue");
};




