$(function () {
    $(document).tooltip();
});

var mensajesProceso = {
    RegistrarUsuarioOK: 'Usuario se registró correctamente.',
    ActualizarUsuarioOK: 'Usuario se actualizo correctamente.',
    DeshabilitarUsuarioOK: 'Se deshabilito usuario correctamente.',
    EliminarUsuarioOK: 'Se eliminino usuario correctamente.',
    AsignarCuentaInventarioOK: 'Se asigno cuentas de inventario correctamente.',
    AsignarRolesOK: 'Se asigno roles y permisos correctamente.'  
}

var gridView = !(navigator.appName == 'Microsoft Internet Explorer');
var idRow = null;
var selectRow = null;
var valCellSolicitud = null;

var dataRoles = [];
var dataCuentasInventario = [];  
var dataModAdmin = [];
var dataModApoyo = [];
var dataModInventario = [];
var dataModBonos = [];

$(document).ready(function () {

    GetData_EnterpriceSearch();

    //Accordion
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~        
    $("#Accordion_CriteriosBusqueda").accordion({
        collapsible: true,
        heightStyle: 'content'
    });

    //Grilla - Principal
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ 

    $("#jqgMantenimientoUsuarios").jqGrid({

        url: location.pathname + "/GetData_Usuarios",
        mtype: "POST",
        datatype: "json",

        ajaxGridOptions: {
            contentType: 'application/json; charset=utf-8'
        },

        postData: {
            Filter: {
                strApellidos: '',
                strNombres: '',
                strUsuarioWindows: '',
                strCompania: ''
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
                { label: ' ', name: 'accionDisa', index: 'accion', width: 25, align: "center" },
                { label: ' ', name: 'accionDel', index: 'accion', width: 25, align: "center" }, 
                { label: ' ', name: 'accionAsign', index: 'accion', width: 25, align: "center" },
                { label: ' ', name: 'accionCuenta', index: 'accion', width: 25, align: "center" },
                { label: 'UsuarioId', name: 'int_UsuarioId', index: 'int_UsuarioId', width: 100, hidden: true, key: true },
                { label: 'Nombres', name: 'str_Usuario_Nombres', index: 'str_Usuario_Nombres', width: 200 },
                { label: 'Apellidos', name: 'str_Usuario_Apellidos', index: 'str_Usuario_Apellidos', width: 200 },
                { label: 'Usuario Windows', name: 'str_Usuario_Login', index: 'str_Usuario_Login', width: 250 },
                { label: 'Email', name: 'str_Usuario_Email', index: 'str_Usuario_Email', width: 250 },
                { label: 'str_NroPersonal', name: 'str_NroPersonal', index: 'str_NroPersonal', width: 250, hidden: true },
                { label: 'str_CodigoAdrian', name: 'str_CodigoAdrian', index: 'str_CodigoAdrian', width: 250, hidden: true },
                { label: 'str_CodigoSAP', name: 'str_CodigoSAP', index: 'str_CodigoSAP', width: 250, hidden: true },
                { label: 'str_Funcion', name: 'str_Funcion', index: 'str_Funcion', width: 250, hidden: true },
                { label: 'str_Cargo', name: 'str_Cargo', index: 'str_Cargo', width: 250, hidden: true },
                { label: 'CompaniaId', name: 'str_CompaniaId', index: 'str_CompaniaId', width: 80, hidden: true },
                { label: 'Compañia', name: 'str_CompaniaDes', index: 'str_CompaniaDes', width: 200 },
                { label: 'F. Registro', name: 'det_FechaCreacion', index: 'det_FechaCreacion', width: 100, align: "center", formatter: 'date', formatoptions: { srcformat: 'd/m/Y', newformat: 'd/m/Y' }, hidden: true },
                { label: 'U. Registro', name: 'str_UsuarioCreacion', index: 'str_UsuarioCreacion', width: 150, hidden: true },
                { label: 'F. Modificación', name: 'det_FechaModificacion', index: 'det_FechaModificacion', width: 100, align: "center", formatter: 'date', formatoptions: { srcformat: 'd/m/Y', newformat: 'd/m/Y' }, hidden: true },
                { label: 'U. Modificación', name: 'str_UsuarioModificacion', index: 'str_UsuarioModificacion', width: 130, hidden: true },
                { label: 'Estado', name: 'bl_Usuario_Status', index: 'bl_Usuario_Status', width: 50, editable: true, edittype: 'checkbox', editoptions: { value: "True:False" }, formatter: "checkbox", formatoptions: { disabled: true }, align: "center" },
                { label: 'bl_Module_Administracion', name: 'bl_Module_Administracion', index: 'bl_Module_Administracion', width: 80, hidden: true },
                { label: 'bl_Module_GestionInventario', name: 'bl_Module_GestionInventario', index: 'bl_Module_GestionInventario', width: 80, hidden: true },
                { label: 'bl_Module_ApoyoFabricante', name: 'bl_Module_ApoyoFabricante', index: 'bl_Module_ApoyoFabricante', width: 80, hidden: true },
                { label: 'bl_Module_Bonos', name: 'bl_Module_Bonos', index: 'bl_Module_Bonos', width: 80, hidden: true }
                ],

        rowNum: 1000,
        rownumbers: true,
        rowList: [20, 50, 80],
        viewrecords: true,
        loadtext: 'Cargando datos...',
        recordtext: "<b>{2} registros encontrados</b>",
        emptyrecords: 'No se encontraron registros',
        pgtext: 'Pág: {0} de {1}',
        caption: "Relación de Usuarios",
        pager: '#pagerjqgMantenimientoUsuarios',
        regional: 'es',
        gridview: gridView,
        cmTemplate: { title: false },

        gridComplete: function () {
            var ids = $("#jqgMantenimientoUsuarios").jqGrid('getDataIDs');
            for (var i = 0; i < ids.length; i++) {
                upd = "<img src='../Images/edit.png' style='cursor:pointer;' title='Editar Usuario' onclick=\"EditUsuario('" + ids[i] + "');\" />";
                dis = "<img src='../Images/btnUnvalidated.png' style='cursor:pointer;' title='Deshabilitar Usuario' onclick=\"DisabledUsuario('" + ids[i] + "');\" />";
                del = "<img src='../Images/delete.png' style='cursor:pointer;' title='Eliminar Usuario' onclick=\"DeleteUsuario('" + ids[i] + "');\" />"; 
                asign = "<img src='../Images/roles.gif' style='cursor:pointer;' title='Asignar Accesos y Roles' onclick=\"AsignacionRolesUsuarios('" + ids[i] + "');\" />";
                account = "<img src='../Images/account.png' style='cursor:pointer;' title='Asignar Cuenta de Inventario' onclick=\"AsignacionCuentaInventario('" + ids[i] + "');\" />";
                $("#jqgMantenimientoUsuarios").jqGrid('setRowData', ids[i], { accionUpd: upd, accionDisa: dis, accionDel: del, accionAsign: asign, accionCuenta: account });
            }
        }
    });

    $("#frmInformacionUsuarios").validate({
        rules: {
            NombresModal: "required",
            ApellidosModal: "required",
            UsuarioWindowsModal: "required",
            EmailModal: "required",
            CompaniaModal: "required"
        },
        messages: {
            NombresModal: "<br> Ingrese nombres.",
            ApellidosModal: "<br> Ingrese apellidos.",
            UsuarioWindowsModal: "<br> Ingrese usuario windows.",
            EmailModal: "<br> Ingrese email.",
            CompaniaModal: "<br> Seleccione Compañia"
        }
    });

    $("#modalInformacionUsuarios").dialog({
        autoOpen: false,
        width: 460,
        height: 440,
        resizable: false,
        modal: true,
        close: function () {
            $('#frmInformacionUsuarios').validate().resetForm();
            $('#txtNombres').val("");
            $('#txtApellidos').val("");
            $('#txtUsuarioWindows').val("");
            $('#txtEmail').val("");
            $('#SelectCompania').val("");
            $('#lblTypeTrans').val("");
            $('#lblUsuarioId').val("");
        },
        buttons: {
            "Grabar": function () {
                var $this = $(this);
                if ($("#frmInformacionUsuarios").valid()) {
                    var parametros = {
                        Nombres: $('#txtNombres').val(),
                        Apellidos: $('#txtApellidos').val(),
                        Login: $('#txtUsuarioWindows').val(),
                        Email: $('#txtEmail').val(),
                        CompaniaId: $('#SelectCompania').val(),
                        TypeTrans: $('#lblTypeTrans').val(),
                        UsuarioId: $('#lblUsuarioId').val(),
                        NroPersonal: $("#txtNumPersonal").val(),
                        CodigoAdrian: $("#txtIdAdrian").val(),
                        CodigoSAP: $("#txtIdSAP").val(),
                        Funcion: $("#txtFuncion").val(),
                        Cargo: $("#txtCargo").val()
                    };

                    $.customAjax({ url: location.pathname + "/RegistrarUsuario", parametros: parametros },
                        function (respuesta) {
                            if (respuesta.success) {
                                mostrarMensajeProceso({ tipo: 'success', mensaje: mensajesProceso.RegistrarUsuarioOK });
                                $("#jqgMantenimientoUsuarios").jqGrid().trigger("reloadGrid");
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

    $("#modalAsignacionRolesUsuario").dialog({
        autoOpen: false,
        width: 1100,
        height: 'auto',
        resizable: false,
        modal: true,
        close: function () {
            document.getElementById("chkAdministracion").checked = false;
            document.getElementById("chkGestionInventario").checked = false;
            document.getElementById("chkApoyoFabricante").checked = false;
            document.getElementById("chkBonos").checked = false
        },
        buttons: {
            "Asignar": function () {
                var $this = $(this);

                var vAdminModulo = null;
                var vGestionModulo = null;
                var vApoyoModulo = null;
                var vBonoModulo = null;
                var _ListRolesAdminModulo = [];
                var _ListRolesGestionModulo = [];
                var _ListRolesApoyoModulo = [];
                var _ListRolesBonoModulo = [];

                vAdminModulo = document.getElementById("chkAdministracion").checked;
                vGestionModulo = document.getElementById("chkGestionInventario").checked;
                vApoyoModulo = document.getElementById("chkApoyoFabricante").checked;
                vBonoModulo = document.getElementById("chkBonos").checked;

                var getDataAdminModulo = $("#jqgRolesAdmin").jqGrid('getRowData');

                for (i = 0; i < getDataAdminModulo.length; i++) {
                    _IdUsuario = $('#lblUsuarioRolesId').val();
                    _IdRol = getDataAdminModulo[i].int_RolId;
                    _Status = getDataAdminModulo[i].bl_UsuariosRolesStatus;

                    if (_Status == "True") {
                        _ListRolesAdminModulo.push([_IdUsuario, _IdRol]);
                    }
                };

                var getDataGestionModulo = $("#jqgRolesInventario").jqGrid('getRowData');

                for (i = 0; i < getDataGestionModulo.length; i++) {
                    _IdUsuario = $('#lblUsuarioRolesId').val();
                    _IdRol = getDataGestionModulo[i].int_RolId;
                    _Status = getDataGestionModulo[i].bl_UsuariosRolesStatus;

                    if (_Status == "True") {
                        _ListRolesGestionModulo.push([_IdUsuario, _IdRol]);
                    }
                };

                var getDataApoyoModulo = $("#jqgRolesApoyo").jqGrid('getRowData');

                for (i = 0; i < getDataApoyoModulo.length; i++) {
                    _IdUsuario = $('#lblUsuarioRolesId').val();
                    _IdRol = getDataApoyoModulo[i].int_RolId;
                    _Status = getDataApoyoModulo[i].bl_UsuariosRolesStatus;

                    if (_Status == "True") {
                        _ListRolesApoyoModulo.push([_IdUsuario, _IdRol]);
                    }
                };

                var getDataBonoModulo = $("#jqgRolesBonos").jqGrid('getRowData');

                for (i = 0; i < getDataBonoModulo.length; i++) {
                    _IdUsuario = $('#lblUsuarioRolesId').val();
                    _IdRol = getDataBonoModulo[i].int_RolId;
                    _Status = getDataBonoModulo[i].bl_UsuariosRolesStatus;

                    if (_Status == "True") {
                        _ListRolesBonoModulo.push([_IdUsuario, _IdRol]);
                    }
                };

                var parametros = {
                    mAdmin: vAdminModulo,
                    mGestion: vGestionModulo,
                    mApoyo: vApoyoModulo,
                    mBonos: vBonoModulo,
                    UsuarioId: $('#lblUsuarioRolesId').val(),
                    ListTempAdmin: _ListRolesAdminModulo,
                    ListTempGestion: _ListRolesGestionModulo,
                    ListTempApoyo: _ListRolesApoyoModulo,
                    ListTempBono: _ListRolesBonoModulo
                };

                $.customAjax({ url: location.pathname + "/Asignar_RolesPermisos", parametros: parametros },
                    function (respuesta) {
                        if (respuesta.success) {
                            mostrarMensajeProceso({ tipo: 'success', mensaje: mensajesProceso.AsignarRolesOK });
                            $("#jqgMantenimientoUsuarios").jqGrid().trigger("reloadGrid");
                            $this.dialog('close');
                        }
                    }, null, null, true
                );
            },
            "Cancelar": function () {
                $(this).dialog("close");
            }
        }
    });

    $("#modalCuentaInventarioUsuario").dialog({
        autoOpen: false,
        width: 630,
        height: 'auto',
        resizable: false,
        modal: true,
        close: function () {
        },
        buttons: {
            "Asignar": function () {
                var $this = $(this);

                var _ListTempCuentasInventario = [];
                var idsMaqRel = $("#jqgCuentaInventarioUsuario").jqGrid('getDataIDs');
                var ids = $("#jqgCuentaInventarioUsuario").getGridParam("selarrrow");                                     
                var _IdUsuario = $('#lblUsuarioCuenta').text(); 
                                          
                for (var i = 0; i < ids.length; i++) {
                        var row = $("#jqgCuentaInventarioUsuario").getRowData(ids[i]);
                        _ListTempCuentasInventario.push([row.str_IdCuenta,_IdUsuario]);
                }

                if (_ListTempCuentasInventario != null) {
                    var parametros = {
                        ListTemp: _ListTempCuentasInventario,
                        Usuario: _IdUsuario
                    };
                    $.customAjax({ url: location.pathname + "/Asignar_CuentaInventario", parametros: parametros },
                                function (respuesta) {
                                    if (respuesta.success) {
                                        mostrarMensajeProceso({ tipo: 'success', mensaje: mensajesProceso.AsignarCuentaInventarioOK });
                                        $("#jqgMantenimientoUsuarios").jqGrid().trigger("reloadGrid");
                                        $this.dialog('close');
                                    }
                                }, null, null, true
                            );
                } else {
                    custom_alert("Debe de seleccionar al menos una cuenta de inventario.", "Cuenta de Inventario");
                }
            },
            "Cancelar": function () {
                $(this).dialog("close");
            }
        }
    });

    $("#btnNuevoUsuario").click(function () {
        GetData_EnterpricePopup();
        $('#lblTypeTrans').val("1");
        $("#modalInformacionUsuarios").dialog('option', 'title', 'Mantenimiento de Usuarios');
        $('#modalInformacionUsuarios').dialog('open');
    });

    $("#btnCargarDatos").click(function () {
        var EmpleadoId = null,
        EmpleadoId = $('#txtNumPersonal').val();
        GetData_Empleados(EmpleadoId);
    });

    $("#jqgCuentaInventarioUsuario").jqGrid({
        datatype: "local",
        data: dataCuentasInventario,
        height: 450,
        width: "auto",
        colModel: [
                    { label: ' ', name: 'bl_CuentaUsuarioStatus', index: 'bl_CuentaUsuarioStatus', width: 40, editable: true, edittype: 'checkbox', editoptions: { value: "True:False" }, formatter: "checkbox", formatoptions: { disabled: false }, align: "center", hidden: true },
                    { label: 'Código', name: 'str_IdCuenta', index: 'str_IdCuenta', width: 130, key: true },
                    { label: 'Cuenta de Inventario', name: 'str_DescCuentaInventario', index: 'str_DescCuentaInventario', width: 400 },
                    { label: 'str_IdUsuario', name: 'str_IdUsuario', index: 'str_IdUsuario', width: 190, align: "left", hidden: true }
                    ],
        regional: 'es',
        viewrecords: true,
        multiselect: true,
        gridview: gridView
    });

    $("#jqgRolesAdmin").jqGrid({
        datatype: "local",
        data: dataModAdmin,
        height: "auto",
        width: "auto",
        colModel: [
                    { label: 'RolId', name: 'int_RolId', index: 'int_RolId', width: 100, hidden: true },
                    { label: 'int_ModuloId', name: 'int_ModuloId', index: 'int_ModuloId', width: 100, hidden: true },
                    { label: ' ', name: 'bl_UsuariosRolesStatus', index: 'bl_UsuariosRolesStatus', width: 30, editable: true, edittype: 'checkbox', editoptions: { value: "True:False" }, formatter: "checkbox", formatoptions: { disabled: false }, align: "center" },
                    { label: 'Roles', name: 'str_RolesDes', index: 'str_RolesDes', width: 190, align: "left" }
                    ],
        regional: 'es',
        viewrecords: true,
        gridview: gridView
    });

    $("#jqgRolesApoyo").jqGrid({
        datatype: "local",
        data: dataModApoyo,
        height: "auto",
        width: "auto",
        colModel: [
                    { label: 'RolId', name: 'int_RolId', index: 'int_RolId', width: 100, hidden: true },
                    { label: 'int_ModuloId', name: 'int_ModuloId', index: 'int_ModuloId', width: 100, hidden: true },
                    { label: ' ', name: 'bl_UsuariosRolesStatus', index: 'bl_UsuariosRolesStatus', width: 30, editable: true, edittype: 'checkbox', editoptions: { value: "True:False" }, formatter: "checkbox", formatoptions: { disabled: false }, align: "center" },
                    { label: 'Roles', name: 'str_RolesDes', index: 'str_RolesDes', width: 190, align: "left" }
                    ],
        regional: 'es',
        viewrecords: true,
        gridview: gridView
    });

    $("#jqgRolesBonos").jqGrid({
        datatype: "local",
        data: dataModBonos,
        height: "auto",
        width: "auto",
        colModel: [
                    { label: 'RolId', name: 'int_RolId', index: 'int_RolId', width: 100, hidden: true },
                    { label: 'int_ModuloId', name: 'int_ModuloId', index: 'int_ModuloId', width: 100, hidden: true },
                    { label: ' ', name: 'bl_UsuariosRolesStatus', index: 'bl_UsuariosRolesStatus', width: 30, editable: true, edittype: 'checkbox', editoptions: { value: "True:False" }, formatter: "checkbox", formatoptions: { disabled: false }, align: "center" },
                    { label: 'Roles', name: 'str_RolesDes', index: 'str_RolesDes', width: 190, align: "left" }
                    ],
        regional: 'es',
        viewrecords: true,
        gridview: gridView
    });

    $("#jqgRolesInventario").jqGrid({
        datatype: "local",
        data: dataModInventario,
        height: "auto",
        width: "auto",
        colModel: [
                    { label: 'RolId', name: 'int_RolId', index: 'int_RolId', width: 100, hidden: true },
                    { label: 'int_ModuloId', name: 'int_ModuloId', index: 'int_ModuloId', width: 100, hidden: true },
                    { label: ' ', name: 'bl_UsuariosRolesStatus', index: 'bl_UsuariosRolesStatus', width: 30, editable: true, edittype: 'checkbox', editoptions: { value: "True:False" }, formatter: "checkbox", formatoptions: { disabled: false }, align: "center" },
                    { label: 'Roles', name: 'str_RolesDes', index: 'str_RolesDes', width: 190, align: "left" }
                    ],
        regional: 'es',
        viewrecords: true,
        gridview: gridView
    });

});

function GetData_ModulePopup() {
    $.ajax({
        type: "POST",
        url: location.pathname + "/GetData_Module",
        data: '',
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        success: function (msg) {
            $("#selectModulo").empty().append($("<option></option>").val("0").html("Seleccione Modulo..."));
            $.each(msg.d, function (i, item) {
                $('#selectModulo').append($('<option>', {
                    value: item.str_MasterTable_Valor,
                    text: item.str_MasterTable_Descripcion
                }));
            });
        },
        error: function () {
            alert("Error al cargar Modulo.");
        }
    });
}

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
 
function EditUsuario(id) {
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

            var row = $("#jqgMantenimientoUsuarios").jqGrid('getRowData', id);
            $('#lblTypeTrans').val("2");
            $('#lblUsuarioId').val(id);
            $('#txtNombres').val(row.str_Usuario_Nombres);
            $('#txtApellidos').val(row.str_Usuario_Apellidos);
            $('#txtUsuarioWindows').val(row.str_Usuario_Login);
            $('#txtEmail').val(row.str_Usuario_Email);
            $('#SelectCompania').val(row.str_CompaniaId);
            $("#txtNumPersonal").val(row.str_NroPersonal);  
            $("#txtIdAdrian").val(row.str_CodigoAdrian);
            $("#txtIdSAP").val(row.str_CodigoSAP);
            $("#txtFuncion").val(row.str_Funcion);
            $("#txtCargo").val(row.str_Cargo);
            $("#modalInformacionUsuarios").dialog('option', 'title', 'Mantenimiento de Usuarios');
            $('#modalInformacionUsuarios').dialog('open');
        },
        error: function () {
            alert("Error al cargar datos.");
        }
    });
}

function DisabledUsuario(id) {
    var row = $("#jqgMantenimientoUsuarios").jqGrid('getRowData', id);
    var UserId = null;
    var UserName = null;
    var UserLogin = null;
    UserId = row.int_UsuarioId;
    UserLogin = row.str_Usuario_Login;
    UserName = row.str_Usuario_Nombres + ' ' + row.str_Usuario_Apellidos;

    if (UserId != null) {
        custom_confirmation(function () {
            var parametros = {
                UsuarioId: UserId
            }
            $.customAjax({ url: location.pathname + "/DeshabilitarUsuario", parametros: parametros },
            function (respuesta) {
                if (respuesta.success) {
                    $("#jqgMantenimientoUsuarios").jqGrid().trigger("reloadGrid");
                    mostrarMensajeProceso({ tipo: 'success', mensaje: mensajesProceso.DeshabilitarUsuarioOK });
                }
            }, null, null, true
            );
        },
            function () {
            },
            "<b>Ud. está seguro de deshabilitar el siguiente usuario?</b>" + "<br> &nbsp; &#8226 Nombres y Apellidos: " + UserName + "<br> &nbsp; &#8226 Usuario Windows: " + UserLogin, 420
        );
    }
}

function DeleteUsuario(id) {
    var row = $("#jqgMantenimientoUsuarios").jqGrid('getRowData', id);
    var UserId = null;
    var UserName = null;
    var UserLogin = null;
    UserId = row.int_UsuarioId;
    UserLogin = row.str_Usuario_Login;
    UserName = row.str_Usuario_Nombres + ' ' + row.str_Usuario_Apellidos;

    if (UserId != null) {
        custom_confirmation(function () {
            var parametros = {
                UsuarioId: UserId,
                UsuarioLogin: UserLogin 
            }
            $.customAjax({ url: location.pathname + "/EliminarUsuario", parametros: parametros },
            function (respuesta) {
                if (respuesta.success) {
                    $("#jqgMantenimientoUsuarios").jqGrid().trigger("reloadGrid");
                    mostrarMensajeProceso({ tipo: 'success', mensaje: mensajesProceso.EliminarUsuarioOK });
                }
            }, null, null, true
            );
        },
            function () {
            },
            "<b>Ud. está seguro de eliminar el siguiente usuario?</b>" + "<br> &nbsp; &#8226 Nombres y Apellidos: " + UserName + "<br> &nbsp; &#8226 Usuario Windows: " + UserLogin + "<br>" + "<br> Toda la información registrada en el sistema relacionada con esta cuenta será borrada (Accesos, Permisos, Cuentas de Inventario,  etc.)", 450
        );
    }
}
 
function AsignacionCuentaInventario(id){
    var row = $("#jqgMantenimientoUsuarios").jqGrid('getRowData', id);
    var UserId = null;
    var UserName = null;
    $('#lblNombresApellidosCuentas').text(row.str_Usuario_Nombres + ' ' + row.str_Usuario_Apellidos);
    $('#lblUsuarioCuenta').text(row.str_Usuario_Login);

    UserId = row.int_UsuarioId;
    UserName = row.str_Usuario_Login;

    if (UserId != null) {
        $.customAjax({ url: location.pathname + "/GetData_CuentaInventario", parametros: { Usuario: UserName} },
            function (respuesta) {
                preload(false);
                if (respuesta.success) {
                    dataCuentasInventario = respuesta.data;
                    jQuery("#jqgCuentaInventarioUsuario").setGridParam({ rowNum: respuesta.data.length });
                    jQuery("#jqgCuentaInventarioUsuario").jqGrid('setGridParam', { data: dataCuentasInventario }).trigger("reloadGrid");

                    $.each(respuesta.data, function (i, item) {
                        if (item.bl_CuentaUsuarioStatus == true)
                            $("#jqgCuentaInventarioUsuario").jqGrid('setSelection', item.str_IdCuenta);
                    });
                    $("#modalCuentaInventarioUsuario").dialog('option', 'title', 'Asignación de Cuentas de Inventario');
                    $('#modalCuentaInventarioUsuario').dialog('open');
                } else {
                }
            }, function (error) {
                preload(false);
            }, function () {
                preload(true);
            }
      );
    }
}

function AsignacionRolesUsuarios(id) {

    var row = $("#jqgMantenimientoUsuarios").jqGrid('getRowData', id);
    var UserId = null;
    $('#lblNombresApellidos').text(row.str_Usuario_Nombres + ' ' + row.str_Usuario_Apellidos);
    $('#lblLogin').text(row.str_Usuario_Login);
    $('#lblUsuarioRolesId').val(row.int_UsuarioId);

    if (row.bl_Module_Administracion == "true") {
        document.getElementById("chkAdministracion").checked = true
    } else if (row.bl_Module_Administracion != "true") {
        document.getElementById("chkAdministracion").checked = false
    }

    if (row.bl_Module_GestionInventario == "true") {
        document.getElementById("chkGestionInventario").checked = true
    } else if (row.bl_Module_GestionInventario != "true") {
        document.getElementById("chkGestionInventario").checked = false
    }

    if (row.bl_Module_ApoyoFabricante == "true") {
        document.getElementById("chkApoyoFabricante").checked = true
    } else if (row.bl_Module_ApoyoFabricante != "true") {
        document.getElementById("chkApoyoFabricante").checked = false
    }

    if (row.bl_Module_Bonos == "true") {
        document.getElementById("chkBonos").checked = true
    } else if (row.bl_Module_Bonos != "true") {
        document.getElementById("chkBonos").checked = false
    } 

    UserId = row.int_UsuarioId;
      
    if (UserId != null) {

        $.customAjax({ url: location.pathname + "/GetData_RolesAdmin", parametros: { UsuarioId: UserId} },
            function (respuesta) {
                preload(false);
                if (respuesta.success) {
                    dataModAdmin = respuesta.data;
                    jQuery("#jqgRolesAdmin").setGridParam({ rowNum: respuesta.data.length });
                    jQuery("#jqgRolesAdmin").jqGrid('setGridParam', { data: dataModAdmin }).trigger("reloadGrid");    
                } else {
                }
            }, function (error) {
                preload(false);
            }, function () {
                preload(true);
            }
        );

            $.customAjax({ url: location.pathname + "/GetData_RolesGestion", parametros: { UsuarioId: UserId} },
            function (respuesta) {
                preload(false);
                if (respuesta.success) {
                    dataModInventario = respuesta.data;
                    jQuery("#jqgRolesInventario").setGridParam({ rowNum: respuesta.data.length });
                    jQuery("#jqgRolesInventario").jqGrid('setGridParam', { data: dataModInventario }).trigger("reloadGrid");
                } else {
                }
            }, function (error) {
                preload(false);
            }, function () {
                preload(true);
            }
        );

            $.customAjax({ url: location.pathname + "/GetData_RolesApoyo", parametros: { UsuarioId: UserId} },
            function (respuesta) {
                preload(false);
                if (respuesta.success) {
                    dataModApoyo = respuesta.data;
                    jQuery("#jqgRolesApoyo").setGridParam({ rowNum: respuesta.data.length });
                    jQuery("#jqgRolesApoyo").jqGrid('setGridParam', { data: dataModApoyo }).trigger("reloadGrid");
                } else {
                }
            }, function (error) {
                preload(false);
            }, function () {
                preload(true);
            }
        );

            $.customAjax({ url: location.pathname + "/GetData_RolesBonos", parametros: { UsuarioId: UserId} },
            function (respuesta) {
                preload(false);
                if (respuesta.success) {
                    dataModBonos = respuesta.data;
                    jQuery("#jqgRolesBonos").setGridParam({ rowNum: respuesta.data.length });
                    jQuery("#jqgRolesBonos").jqGrid('setGridParam', { data: dataModBonos }).trigger("reloadGrid");
                } else {
                }
            }, function (error) {
                preload(false);
            }, function () {
                preload(true);
            }
        );

        $("#modalAsignacionRolesUsuario").dialog('option', 'title', 'Asignación de Accesos y Roles');
        $('#modalAsignacionRolesUsuario').dialog('open');

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

function GetData_Empleados(EmpleadoId) {
if (EmpleadoId != null) {
    var parametros = {
        CodigoEmpleado: EmpleadoId
    }
    $.customAjax({ url: location.pathname + "/ObtenerDatosEmpleados", parametros: parametros },
    function (respuesta) {
        if (respuesta.success) {
            var dataEmpleados = respuesta.data;
            if (dataEmpleados != null) {
                $("#txtNumPersonal").val(dataEmpleados.NroPersonal);
                $("#txtIdAdrian").val(dataEmpleados.CodigoAdrian);
                $("#txtIdSAP").val(dataEmpleados.CodigoSAP);
                $("#txtNombres").val(dataEmpleados.Nombres);
                $("#txtApellidos").val(dataEmpleados.Apellidos);
                $("#txtFuncion").val(dataEmpleados.Funcion);
                $("#txtCargo").val(dataEmpleados.Cargo);
            }
        }
    }, null, null, true
    );
}
else {
}
}

function CleanFilter() {
    $('#txtApellidosCon').val("");
    $('#txtNombresCon').val("");
    $('#txtUsuarioCon').val("");
    $('#selectCompaniaCon').val(""); 
    GetData_EnterpriceSearch();
};

function UndoSearch() {
    var Filter = {
        strApellidos: '',
        strNombres: '',
        strUsuarioWindows: '',
        strCompania: ''
    };
    $("#jqgMantenimientoUsuarios").jqGrid()[0].p.postData.Filter = Filter;
    $("#jqgMantenimientoUsuarios").jqGrid().trigger("reloadGrid");
    CleanFilter();
};

function DoSearch() {
    var Filter = {
        strApellidos: $('#txtApellidosCon').val(),
        strNombres: $('#txtNombresCon').val(),
        strUsuarioWindows: $('#txtUsuarioCon').val(),
        strCompania: $('#selectCompaniaCon').val() == '0' ? "" : $('#selectCompaniaCon').val()
    };

    $("#jqgMantenimientoUsuarios").jqGrid()[0].p.postData.Filter = Filter;
    $("#jqgMantenimientoUsuarios").jqGrid().trigger("reloadGrid");
};



