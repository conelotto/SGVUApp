var titulosModal = {
   reserva: 'Reserva de Unidades',
   modificacion: 'Modificación',
   informacionUnidad: 'Información'
};

var mensajesProceso = {
   solicitarLevanteOK: 'La solicitud de levante se envió correctamente.',
   crearReservaOK: 'La reserva se guardó correctamente.',
   modificarReservaOK: 'La reserva se modificó correctamente.',
   modificarMaquinaOK: 'La máquina se modificó correctamente.',
   anularReservasOK: 'Las reservas se anularon correctamente.'
};

var informacionUnidad = {
   seguimientoImportacion: null,
   informacionInventario: null,
   datosTecnicos: null,
   configuracionUnidad: null
};

var gridView = !(navigator.appName == 'Microsoft Internet Explorer');

var idRowMaquina = null;
var objReserva = null;
var formatoFecha = "DD/MM/YYYY";
var uploadObj = null;

$(document).ready(function () {

   var anchoPantalla = $(window).width();
   var cantDis = 2;

   $(window).bind('resize', function () {
      anchoPantalla = $("#accordion_busqueda").width();
      $("#jqgMaquinas").setGridWidth(anchoPantalla - cantDis);
   }).trigger('resize');

   $("#gridMaqWrapper").hide();
   $("#gridMaqRelWrapper").hide();
   $("#rowEmparejamiento").hide();
   $("#ContentBtnAnularReservaModal").hide();

   $("#accordion_busqueda").accordion({
      collapsible: true,
      heightStyle: 'content'
   });

   $("#accordionSegImpModalInfo").accordion({
      collapsible: true,
      active: false,
      heightStyle: "content",
      activate: function (event, ui) {
         if ($(this).find('.ui-state-active').length == 1 && informacionUnidad.seguimientoImportacion == null) {
            $.customAjax({ url: location.pathname + "/ObtenerDatosMaquinaSeguimientoImportacion", parametros: { orden: idRowMaquina} },
               function (respuesta) {
                  if (respuesta.success) {
                     if (respuesta.data != null){
                        informacionUnidad.seguimientoImportacion = respuesta.data
                        mostrarInformacionMaquinaSeguimientoImportacion(respuesta.data);
                     }
                  }
               }, null, null, true
            );
         }
      }
   });

   $("#accordionInfInvModalInfo").accordion({
      collapsible: true,
      active: false,
      heightStyle: "content",
      activate: function (event, ui) {
         if ($(this).find('.ui-state-active').length == 1 && informacionUnidad.informacionInventario == null) {
            $.customAjax({ url: location.pathname + "/ObtenerDatosMaquinaInformacionInventario", parametros: { orden: idRowMaquina} },
               function (respuesta) {
                  if (respuesta.success) {
                     if (respuesta.data != null){
                        informacionUnidad.informacionInventario = respuesta.data
                        mostrarInformacionMaquinaInfoInventario(respuesta.data);
                     }
                  }
               }, null, null, true
            );
         }
      }
   });

   $("#accordionDatTecModalInfo").accordion({
      collapsible: true,
      active: false,
      heightStyle: "content",
      activate: function (event, ui) {
         if ($(this).find('.ui-state-active').length == 1 && informacionUnidad.datosTecnicos == null) {
            $.customAjax({ url: location.pathname + "/ObtenerDatosMaquinaDatosTecnicos", parametros: { orden: idRowMaquina} },
               function (respuesta) {
                  if (respuesta.success) {
                     if (respuesta.data != null){
                        informacionUnidad.datosTecnicos = respuesta.data
                        mostrarInformacionMaquinaDatosTecnicos(respuesta.data);
                     }
                  }
               }, null, null, true
            );
         }
      }
   });

   $("#accordionConUniModalInfo").accordion({
      collapsible: true,
      active: false,
      heightStyle: "content",
      activate: function (event, ui) {
         if ($(this).find('.ui-state-active').length == 2 && informacionUnidad.configuracionUnidad == null) {
            $.customAjax({ url: location.pathname + "/ObtenerDatosMaquinaConfiguracionUnidad", parametros: { orden: idRowMaquina} },
               function (respuesta) {
                  if (respuesta.success) {
                     informacionUnidad.configuracionUnidad = respuesta.data
                     mostrarInformacionMaquinaConfiguracionUnidad(respuesta.data);
                  }
               }, null, null, true
            );
         }
      }
   });

   $("#btnFiltroCuenta").click(function () {
      $.customAjax({ url: location.pathname + "/ObtenerCuentasFiltro", parametros: {} },
         function (respuesta) {
            if (respuesta.success) {
               jQuery("#jqgCuentasFiltro").setGridParam({ rowNum: respuesta.data.length });
               jQuery("#jqgCuentasFiltro").jqGrid('setGridParam', { data: respuesta.data }).trigger("reloadGrid");

               var arrayCuentas = $("#filtroCuenta").val().split(',');
               for (var i = 0; i < arrayCuentas.length; i++) {
                  if (arrayCuentas[i].trim() != "")
                     $("#jqgCuentasFiltro").jqGrid('setSelection', arrayCuentas[i]);
               }

               $('#modalFiltroCuenta').dialog('open');
            }
         }, null, null, true
      );
   });

   $("#btnFiltroModelo").click(function () {
      $.customAjax({ url: location.pathname + "/ObtenerModelosFiltro", parametros: {} },
         function (respuesta) {
            if (respuesta.success) {
               jQuery("#jqgModelosFiltro").setGridParam({ rowNum: respuesta.data.length });
               jQuery("#jqgModelosFiltro").jqGrid('setGridParam', { data: respuesta.data }).trigger("reloadGrid");

               var arrayModelos = $("#filtroModelo").val().split(',');
               for (var i = 0; i < arrayModelos.length; i++) {
                  if (arrayModelos[i].trim() != "")
                     $("#jqgModelosFiltro").jqGrid('setSelection', arrayModelos[i]);
               }

               $('#modalFiltroModelo').dialog('open');
            }
         }, null, null, true
      );
   });

   $("#btnFiltroUbicacion").click(function () {
      $.customAjax({ url: location.pathname + "/ObtenerUbicacionesFiltro", parametros: {} },
         function (respuesta) {
            if (respuesta.success) {
               jQuery("#jqgUbicacionesFiltro").setGridParam({ rowNum: respuesta.data.length });
               jQuery("#jqgUbicacionesFiltro").jqGrid('setGridParam', { data: respuesta.data }).trigger("reloadGrid");

               var arrayModelos = $("#filtroUbicacion").val().split(',');
               for (var i = 0; i < arrayModelos.length; i++) {
                  if (arrayModelos[i].trim() != "")
                     $("#jqgUbicacionesFiltro").jqGrid('setSelection', arrayModelos[i]);
               }

               $('#modalFiltroUbicacion').dialog('open');
            }
         }, null, null, true
      );
   });

   $("#btnBuscarMaquinaEmp").click(function () {
      var modelo = $('#txtModeloMaqEmp').val();
      var idsMaqRel = $("#jqgMaquinasRelacionadas").jqGrid('getDataIDs');
      $.customAjax({ url: location.pathname + "/ObtenerMaquinasPorModelo", parametros: { modelo: modelo, orden: idRowMaquina} },
         function (respuesta) {
            if (respuesta.success) {
               $("#jqgMaquinasEmparejamiento").setGridParam({ rowNum: respuesta.data.length });
               $("#jqgMaquinasEmparejamiento").jqGrid('setGridParam', { data: respuesta.data }).trigger("reloadGrid");

               $.each(idsMaqRel, function (i, item) {
                  $("#jqgMaquinasEmparejamiento").jqGrid('setSelection', item);
               });

               $('#modalMaquinasEmparejamiento').dialog('open');
            }
         }, null, null, true
      );
   });

   $("#btnBuscarOportunidadReserva").click(function () {
      var oportunidad = $("#txtOportunidadReservaModal").val();
      $.customAjax({ url: location.pathname + "/ObtenerDatosOportunidad", parametros: { oportunidad: oportunidad} },
         function (respuesta) {
            if (respuesta.success) {
               var datosOportunidad = respuesta.data;
               if (datosOportunidad != null) {
                  $("#txtClienteReservaModal").val(datosOportunidad.clienteId);
                  $("#lblClienteDescReservaModal").text(datosOportunidad.clienteDesc);
                  $("#txtVendedorReservaModal").val(datosOportunidad.vendedorId);
                  $("#lblVendedorDescReservaModal").text(datosOportunidad.vendedorDesc);
               }
            }
         }, null, null, true
      );
   });

   $("#btnBuscarClienteReserva").click(function () {
      preload(true);

      var idCliente = $("#txtClienteReservaModal").val();

      $("#jqgClientes").jqGrid('setGridParam', { datatype: "json" });
      $("#jqgClientes").jqGrid()[0].p.postData = { codigo: idCliente, descripcion: '' };
      $("#jqgClientes").jqGrid().trigger("reloadGrid");
   });

   $("#btnBuscarClienteModalBuscar").click(function () {
      var idCliente = $("#txtClienteIdModalBusCli").val();
      var descCliente = $("#txtVendedorDescModalBusCli").val();
      $("#jqgClientes").jqGrid()[0].p.postData = { codigo: idCliente, descripcion: descCliente };
      $("#jqgClientes").jqGrid('setGridParam',{page:1}).trigger("reloadGrid");
   });

   $("#btnBuscarVendedorReserva").click(function () {
      preload(true);

      var idVendedor = $("#txtVendedorReservaModal").val();

      $("#jqgVendedores").jqGrid('setGridParam', { datatype: "json" });
      $("#jqgVendedores").jqGrid()[0].p.postData = { codigo: idVendedor, descripcion: '' };
      $("#jqgVendedores").jqGrid().trigger("reloadGrid");
   });

   $("#btnBuscarVendedorModalBuscar").click(function () {
      var idVendedor = $("#txtVendedorIdModalBusven").val();
      var descVendedor = $("#txtVendedorDescModalBusVen").val();
      $("#jqgVendedores").jqGrid()[0].p.postData = { codigo: idVendedor, descripcion: descVendedor };
      $("#jqgVendedores").jqGrid('setGridParam',{page:1}).trigger("reloadGrid");
   });

   $("#btnAnularReservaModal").click(function () {
      custom_confirmation(function () {
         ajaxAnularReservas([objReserva.ordenAsignada], true);
      }, function () {
      });
   });

   $("input[id=btnAnularReservaMasiva]").click(function (index) {
      if (!seleccionadoAlMenosUno())
         custom_alert("Seleccione al menos una Unidad.", "Anular Reserva Masiva");
      else {
         var selectedIDs = $("#jqgMaquinas").getGridParam("selarrrow");
         var ordenes = [];
         for (var i = 0; i < selectedIDs.length; i++) {
            var selectRow = $("#jqgMaquinas").getRowData(selectedIDs[i]);
            if (selectRow.EstadoMaquina == "RESERVADO") {
               ordenes.push(selectedIDs[i]);
            }
         }
         if (ordenes.length > 0) {
            custom_confirmation(function () {
               ajaxAnularReservas(ordenes, ordenes.length == 1);
            }, function () {
            });
         } else {
            custom_alert("Seleccione al menos una Unidad RESERVADA.", "Anular Reserva Masiva");
         }
      }
   });

   $("input[id=btnSolicitarLevante]").click(function (index) {
      if (!seleccionadoAlMenosUno())
         custom_alert("Seleccione al menos una Unidad.", "Solicitar Levante");
      else {
         custom_confirmation(function () {
            var selectedIDs = $("#jqgMaquinas").getGridParam("selarrrow");
            $.customAjax({ url: location.pathname + "/SolicitarLevante", parametros: { maquinas: selectedIDs} },
               function (respuesta) {
                  if (respuesta.success) {
                     mostrarMensajeProceso({ tipo: 'success', mensaje: mensajesProceso.solicitarLevanteOK });
                     gridMaquinasReload(selectedIDs.length == 1);
                  }
               }, null, null, true
            );
         }, function () {
         });
      }
   });

   $('input[type=radio][name=rdEstadoNegociacion]').change(function () {
      filtrarNegociaciones(this.value);
   });

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

   $("#fechaLimiteReservaModal").datepicker({
      numberOfMonths: 1,
      showButtonPanel: true,
      changeMonth: true,
      changeYear: true
   });

   $("#tabsModalInfo").tabs();

   $("#modalFiltroCuenta").dialog({
      autoOpen: false,
      width: 400,
      resizable: false,
      modal: true,
      close: function () {
         $('#jqgCuentasFiltro').jqGrid('clearGridData');
      },
      buttons: {
         "Aceptar": function () {
            var ids = $("#jqgCuentasFiltro").getGridParam("selarrrow");
            var result = "";
            for (var i = 0; i < ids.length; i++) {
               //var row = $("#jqgCuentasFiltro").getRowData(ids[i]);
               result += ids[i] + (i == ids.length - 1 ? "" : ",");
            }
            $("#filtroCuenta").val(result);
            $(this).dialog("close");
         },
         "Cancelar": function () {
            $(this).dialog("close");
         }
      }
   });

   $("#modalFiltroModelo").dialog({
      autoOpen: false,
      width: 400,
      resizable: false,
      modal: true,
      close: function () {
         $('#jqgModelosFiltro').jqGrid('clearGridData');
      },
      buttons: {
         "Aceptar": function () {
            var ids = $("#jqgModelosFiltro").getGridParam("selarrrow");
            var result = "";
            for (var i = 0; i < ids.length; i++) {
               result += ids[i] + (i == ids.length - 1 ? "" : ",");
            }
            $("#filtroModelo").val(result);
            $(this).dialog("close");
         },
         "Cancelar": function () {
            $(this).dialog("close");
         }
      }
   });

   $("#modalFiltroUbicacion").dialog({
      autoOpen: false,
      width: 400,
      resizable: false,
      modal: true,
      close: function () {
         $('#jqgUbicacionesFiltro').jqGrid('clearGridData');
      },
      buttons: {
         "Aceptar": function () {
            var ids = $("#jqgUbicacionesFiltro").getGridParam("selarrrow");
            var result = "";
            for (var i = 0; i < ids.length; i++) {
               result += ids[i] + (i == ids.length - 1 ? "" : ",");
            }
            $("#filtroUbicacion").val(result);
            $(this).dialog("close");
         },
         "Cancelar": function () {
            $(this).dialog("close");
         }
      }
   });

   $("#modalReserva").dialog({
      autoOpen: false,
      width: 700,
      resizable: false,
      modal: true,
      close: function () {
         $("#frmReserva").validate().resetForm();

         $("#lblNroNegReservaModal").text("");
         $("#EstNegReservaModal").removeClass();
         $("#lblFchNegReservaModal").text("");
         $("#fechaLimiteReservaModal").datepicker('setDate', "");
         $("#txtOportunidadReservaModal").val("");
         $("#txtClienteReservaModal").val("");
         $("#lblClienteDescReservaModal").text("");
         $("#txtVendedorReservaModal").val("");
         $("#lblVendedorDescReservaModal").text("");
         $("#txtObsReservaModal").val("");
         $("#lblFchEstIngReservaModal").text("");
         $("#lblFchOfreCliReservaModal").text("");

         $("#ContentBtnAnularReservaModal").hide();

         $("#txtOportunidadReservaModal").prop('disabled', false);
         $("#txtClienteReservaModal").prop('disabled', false);
         $("#txtVendedorReservaModal").prop('disabled', false);
         $("#btnBuscarClienteReserva").prop('disabled', false);
         $("#btnBuscarVendedorReserva").prop('disabled', false);

         objReserva = null;
      },
      buttons: {
         "Aceptar": function () {
            if (objReserva != null) {
               var $this = $(this);
               if ($("#frmReserva").valid()){
                  if (objReserva.nroNegociacion == 0) {
                     var reserva = {
                        ordenAsignada: idRowMaquina,
                        nroNegociacion: $("#lblNroNegReservaModal").text(),
                        fechaNegociacion: convertirFormatoYYYYMMDD($("#lblFchNegReservaModal").text(), "/", "-"),
                        fechaLimiteReserva: convertirFormatoYYYYMMDD($("#fechaLimiteReservaModal").val(), "/", "-"),
                        oportunidad: $("#txtOportunidadReservaModal").val(),
                        clienteId: $("#txtClienteReservaModal").val(),
                        clienteDesc: $("#lblClienteDescReservaModal").text(),
                        vendedorId: $("#txtVendedorReservaModal").val(),
                        vendedorDesc: $("#lblVendedorDescReservaModal").text(),
                        observaciones: $("#txtObsReservaModal").val(),
                        fechaOfrecidaCliente: convertirFormatoYYYYMMDD($("#lblFchOfreCliReservaModal").text(), "/", "-")
                     };
                     $.customAjax({ url: location.pathname + "/GuardarReserva", parametros: { reserva: reserva} },
                        function (respuesta) {
                           if (respuesta.success) {
                              if (respuesta.data.asignada) {
                                 custom_alert_type("error", "La máquina con orden " + reserva.ordenAsignada + " ya se encuentra ASIGNADA.", "Error");
                              } else {
                                 mostrarMensajeProceso({ tipo: 'success', mensaje: mensajesProceso.crearReservaOK });
                                 $this.dialog('close');
                              }
                              gridMaquinasReload(true);
                           }
                        }, null, null, true
                     );
                  } 
                  else {
                     var reserva = {
                        nroNegociacion: objReserva.nroNegociacion,
                        fechaLimiteReserva: convertirFormatoYYYYMMDD($("#fechaLimiteReservaModal").val(), "/", "-"),
                        observaciones: $("#txtObsReservaModal").val(),
                     };
                     $.customAjax({ url: location.pathname + "/ModificarReserva", parametros: { reserva: reserva} },
                        function (respuesta) {
                           if (respuesta.success) {
                              mostrarMensajeProceso({ tipo: 'success', mensaje: mensajesProceso.modificarReservaOK });
                              var orden = objReserva.ordenAsignada;
                              $this.dialog('close');
                              gridMaquinasReload(true);
                              gridNegociacionesReload(orden);
                           }
                        }, null, null, true
                     );
                  }
               }
            }
         },
         "Cancelar": function () {
            $(this).dialog("close");
         }
      }
   });

   $("#modalBuscarCliente").dialog({
      autoOpen: false,
      width: 550,
      resizable: false,
      modal: true,
      close: function () {
         $("#txtClienteIdModalBusCli").val("");
         $("#txtVendedorDescModalBusCli").val("");
         $("#jqgClientes").jqGrid('setGridParam', { datatype: "local" });
         $('#jqgClientes').jqGrid('clearGridData');
      },
      buttons: {
         "Aceptar": function () {
            var id = $("#jqgClientes").getGridParam("selrow");
            var row = $("#jqgClientes").getRowData(id);

            $("#txtClienteReservaModal").val(row.COD_CLIENTE);
            $("#lblClienteDescReservaModal").text(row.DESC_CLIENTE);

            $(this).dialog("close");
         },
         "Cancelar": function () {
            $(this).dialog("close");
         }
      }
   });

   $("#modalBuscarVendedor").dialog({
      autoOpen: false,
      width: 550,
      resizable: false,
      modal: true,
      close: function () {
         $("#txtVendedorIdModalBusven").val("");
         $("#txtVendedorDescModalBusVen").val("");
         $("#jqgVendedores").jqGrid('setGridParam', { datatype: "local" });
         $('#jqgVendedores').jqGrid('clearGridData');
      },
      buttons: {
         "Aceptar": function () {
            var id = $("#jqgVendedores").getGridParam("selrow");
            var row = $("#jqgVendedores").getRowData(id);

            $("#txtVendedorReservaModal").val(row.Codigo);
            $("#lblVendedorDescReservaModal").text(row.NombreCompleto);

            $(this).dialog("close");
         },
         "Cancelar": function () {
            $(this).dialog("close");
         }
      }
   });

   $("#modalModificacion").dialog({
      autoOpen: false,
      width: 450,
      resizable: false,
      modal: true,
      close: function () {
         asignarValoresModalModificacion(true);
         $("#rowEmparejamiento").hide();
         $("#gridMaqRelWrapper").hide();
      },
      buttons: {
         "Modificar": function () {
            var $this = $(this);
            var maquinasEmp = [];
            var idsMaqRel = $("#jqgMaquinasRelacionadas").jqGrid('getDataIDs');

            $.each(idsMaqRel, function (i, item) {
               maquinasEmp.push(item);
            });

            var parametros = {
               orden: idRowMaquina,
               version: $("#txtVersionModif").val(),
               proyecto: $("#txtProyectoModif").val(),
               observaciones: $("#txtObservacionesModif").val(),
               maquinasEmparejamiento: maquinasEmp
            };
            $.customAjax({ url: location.pathname + "/ModificarMaquina", parametros: parametros },
               function (respuesta) {
                  if (respuesta.success) {
                     mostrarMensajeProceso({tipo: 'success', mensaje: mensajesProceso.modificarMaquinaOK});
                     $this.dialog('close');
                     gridMaquinasReload(true);
                  }
               }, null, null, true
            );
         },
         "Cancelar": function () {
            $(this).dialog("close");
         }
      }
   });

   $("#modalInformacionUnidad").dialog({
      autoOpen: false,
      width: 1000,
      resizable: false,
      modal: true,
      close: function () {
         $("#accordionSegImpModalInfo").accordion("option", "active", false);
         $("#accordionInfInvModalInfo").accordion("option", "active", false);
         $("#accordionDatTecModalInfo").accordion("option", "active", false);
         $("#accordionConUniModalInfo").accordion("option", "active", false);

         $("#tabsModalInfo").tabs("option", "active", 0);

         limpiarObjInformacionUnidad();
         limpiarInformacionMaquinaCabecera();
         limpiarInformacionMaquinaSeguimientoImportacion();
         limpiarInformacionMaquinaInfoInventario();
         limpiarInformacionMaquinaDatosTecnicos();
         limpiarInformacionMaquinaConfiguracionUnidad();
         limpiarInformacionNegociaciones();
      }
   });

   $("#modalMaquinasEmparejamiento").dialog({
      autoOpen: false,
      width: 400,
      resizable: false,
      modal: true,
      close: function () {
         $('#jqgMaquinasEmparejamiento').jqGrid('clearGridData');
      },
      buttons: {
         "Aceptar": function () {
            var idsMaqRel = $("#jqgMaquinasRelacionadas").jqGrid('getDataIDs');

            var ids = $("#jqgMaquinasEmparejamiento").getGridParam("selarrrow");
            if (ids.length > 0) $("#gridMaqRelWrapper").show();

            for (var i = 0; i < ids.length; i++) {
               if (idsMaqRel.indexOf(ids[i]) == -1) {
                  var row = $("#jqgMaquinasEmparejamiento").getRowData(ids[i]);
                  $("#jqgMaquinasRelacionadas").addRowData(ids[i], { orden: ids[i], modelo: row.modelo });
               }
            }
            $(this).dialog("close");
         },
         "Cancelar": function () {
            $(this).dialog("close");
         }
      }
   });

   $("#jqgCuentasFiltro").jqGrid({
      datatype: "local",
      data: [],

      height: "auto",
      width: "auto",

      colModel: [
                  { label: 'ID', name: 'IdCuenta', index: 'IdCuenta', key: true, hidden: true },
                  { label: 'Descripción', name: 'DescCuentaInventario', index: 'DescCuentaInventario', formatter: formatDescCuenta, unformat: unformatDescCuenta, width: 340 },
               ],

      caption: "Cuentas",
      regional: 'es',
      viewrecords: true,
      multiselect: true,
      gridview: gridView
   });

   $("#jqgModelosFiltro").jqGrid({
      datatype: "local",
      data: [],

      height: "auto",
      width: "auto",

      colModel: [
                  { label: 'ID', name: 'id', index: 'id', key: true, hidden: true },
                  { label: 'Descripción', name: 'desc', index: 'desc', width: 340 },
               ],

      caption: "Modelos",
      regional: 'es',
      viewrecords: true,
      multiselect: true,
      gridview: gridView
   });

   $("#jqgUbicacionesFiltro").jqGrid({
      datatype: "local",
      data: [],

      height: "auto",
      width: "auto",

      colModel: [
                  { label: 'ID', name: 'UbicacionId', index: 'UbicacionId', key: true, hidden: true },
                  { label: 'Descripción', name: 'UbicacionDesc', index: 'UbicacionDesc', width: 340 },
               ],

      caption: "Ubicaciones",
      regional: 'es',
      viewrecords: true,
      multiselect: true,
      gridview: gridView
   });

   $("#jqgMaquinas").jqGrid({
      url: location.pathname + "/ObtenerMaquinas",
      mtype: "POST",
      datatype: "local",

      ajaxGridOptions: {
         contentType: 'application/json; charset=utf-8'
      },
      postData: {
         filtro: {
            cuenta: '',
            marca: '',
            modelo: '',
            orden: '',
            proyecto: '',
            cliente: '',
            vendedor: '',
            proceso: '',
            fechaEstIngDesde: '',
            fechaEstIngHasta: '',
            semaforo: [],
            estado: [],
            ubicacion: ''
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

      height: "auto",
      width: anchoPantalla - cantDis,
      shrinkToFit: false,

      colNames: ['&nbsp;', 'Sol Lev', 'Orden', 'Orden Principal', 'Modelo', 'Marca', 'Versión', 'Familia', 'Año', 'Cuenta', 'Estado', 'Proyecto', 'Procedencia', 'Fch Est Ing', 'LT Fch Est Ingreso Today', 'Fch Est Disponib', 'Fch Ofrec. Cliente', 'LT Fch Est Disponib Fch Ofrec', 'Sem. Antig', 'Fch Asignación', 'Fch Límite Reserva', 'Fch Est Pre Entrega', 'Fch Env Desaduanar', 'Fch Levante', 'Fch Facturación', 'Ubicación', 'Proceso', 'Cliente', 'Vendedor', 'Sucursal', 'Gerencia', 'Observaciones', 'Costo US$'],
      colModel: [
                  { name: 'TieneEmparejamiento', index: 'TieneEmparejamiento', width: 10, sortable: false, hidden: true },
                  { name: 'SolicitoLevante', index: 'SolicitoLevante', width: 21, sortable: false, align: 'center', formatter: formatSolicitoLevante, unformat: unformatSolicitoLevante, hidden: true },
                  { name: 'OrdenAsignada', index: 'OrdenAsignada', key: true, width: 60, sortable: false, formatter: formatOrden, unformat: unformatOrden, hidden: true },
                  { name: 'OrdenPrincipal', index: 'OrdenPrincipal', width: 60, sortable: false, hidden: true },
                  { name: 'ModeloProductoDesc', index: 'ModeloProductoDesc', width: 150, sortable: false, hidden: true },
                  { name: 'MarcaDesc', index: 'MarcaDesc', width: 130, sortable: false, hidden: true },
                  { name: 'Version', index: 'Version', width: 90, sortable: false, hidden: true },
                  { name: 'FamiliaDesc', index: 'FamiliaDesc', width: 100, sortable: false, hidden: true },
                  { name: 'AnoFabricacionMaquina', index: 'AnoFabricacionMaquina', width: 40, sortable: false, hidden: true },
                  { name: 'CuentaInventarioDBS', index: 'CuentaInventarioDBS', width: 100, sortable: false, hidden: true },
                  { name: 'EstadoMaquina', index: 'EstadoMaquina', width: 80, sortable: false, hidden: true },
                  { name: 'Proyecto', index: 'Proyecto', width: 120, sortable: false, hidden: true },
                  { name: 'Procedencia', index: 'Procedencia', width: 120, sortable: false, hidden: true },
                  { name: 'IngresoFisicoFESAEstimadaFecha', index: 'IngresoFisicoFESAEstimadaFecha', width: 70, sortable: false, formatter: 'date', formatoptions: { srcformat: "d/m/Y", newformat: "d/m/Y" }, hidden: true },
                  { name: 'LTFchEstIngresoToday', index: 'LTFchEstIngresoToday', width: 40, sortable: false, align: 'center', hidden: true },
                  { name: 'DisponibilidadEstimadaFecha', index: 'DisponibilidadEstimadaFecha', width: 70, sortable: false, formatter: 'date', formatoptions: { srcformat: "d/m/Y", newformat: "d/m/Y" }, hidden: true },
                  { name: 'OfrecidaClienteFecha', index: 'OfrecidaClienteFecha', width: 70, sortable: false, formatter: 'date', formatoptions: { srcformat: "d/m/Y", newformat: "d/m/Y" }, hidden: true },
                  { name: 'LTFchEstDispFchOfrec', index: 'LTFchEstDispFchOfrec', width: 40, sortable: false, hidden: true },
                  { name: 'Semaforo', index: 'Semaforo', width: 30, sortable: false, align: 'center', formatter: formatSemaforo, unformat: unformatSemaforo, hidden: true },
                  { name: 'AsignacionFecha', index: 'AsignacionFecha', width: 70, sortable: false, formatter: 'date', formatoptions: { srcformat: "d/m/Y", newformat: "d/m/Y" }, hidden: true },
                  { name: 'LimiteReservaFecha', index: 'LimiteReservaFecha', width: 70, sortable: false, formatter: 'date', formatoptions: { srcformat: "d/m/Y", newformat: "d/m/Y" }, hidden: true },
                  { name: 'PreEntregaEstimadaFecha', index: 'PreEntregaEstimadaFecha', width: 70, sortable: false, formatter: 'date', formatoptions: { srcformat: "d/m/Y", newformat: "d/m/Y" }, hidden: true },
                  { name: 'EnvioDesaduanarFecha', index: 'EnvioDesaduanarFecha', width: 70, sortable: false, formatter: 'date', formatoptions: { srcformat: "d/m/Y", newformat: "d/m/Y" }, hidden: true },
                  { name: 'LevanteAduaneroFecha', index: 'LevanteAduaneroFecha', width: 70, sortable: false, formatter: 'date', formatoptions: { srcformat: "d/m/Y", newformat: "d/m/Y" }, hidden: true },
                  { name: 'FacturacionFecha', index: 'FacturacionFecha', width: 70, sortable: false, formatter: 'date', formatoptions: { srcformat: "d/m/Y", newformat: "d/m/Y" }, hidden: true },
                  { name: 'UbicacionDesc', index: 'UbicacionDesc', width: 150, sortable: false, formatter: formatUbicacion, unformat: unformatUbicacion, hidden: true },
                  { name: 'Proceso', index: 'Proceso', width: 100, sortable: false, hidden: true },
                  { name: 'ClienteDesc', index: 'ClienteDesc', width: 180, sortable: false, hidden: true },
                  { name: 'VendedorDesc', index: 'VendedorDesc', width: 120, sortable: false, hidden: true },
                  { name: 'Sucursal', index: 'Sucursal', width: 80, sortable: false, hidden: true },
                  { name: 'Gerencia', index: 'Gerencia', width: 150, sortable: false, hidden: true },
                  { name: 'Observaciones', index: 'Observaciones', width: 160, sortable: false, hidden: true },
                  { name: 'CostoMaquinaUSS', index: 'CostoMaquinaUSS', width: 60, sortable: false, hidden: true }
               ],

      rowNum: 20,
      rownumbers: true,
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
      gridComplete: initGrid,
      subGrid: true,

      subGridRowExpanded: function (subgrid_id, row_id) {
         var subgrid_table_id = subgrid_id + "_table";

         $("#" + subgrid_id).html("<table id='" + subgrid_table_id + "' class='scroll'></table>");

         $("#" + subgrid_table_id).jqGrid({
            url: location.pathname + "/ObtenerMaquinasRelacionadasGridPrincipal",
            mtype: "POST",
            datatype: "json",

            ajaxGridOptions: {
               contentType: 'application/json; charset=utf-8'
            },
            postData: {
               orden: row_id
            },
            serializeGridData: function (postData) {
               return JSON.stringify(postData);
            },
            jsonReader: {
               root: "d.rows"
            },

            colModel: [
                        { label: 'Orden', name: 'str_OrdenAsignada', index: 'str_OrdenAsignada', key: true, formatter: formatOrden, unformat: unformatOrden, width: 83 },
                        { label: 'Modelo', name: 'str_ModeloProductoDesc', index: 'str_ModeloProductoDesc', width: 150 },
                        { label: 'Antig', name: 'int_Semaforo', index: 'int_Semaforo', width: 30 },
                        { label: 'Ubicación', name: 'str_UbicacionDesc', index: 'str_UbicacionDesc', width: 100 }
                     ],

            height: "auto",
            width: "auto",
            regional: 'es',
            gridview: gridView,
            loadonce: true,

            onCellSelect: function (row, col, content, event) {
               var cm = $("#" + subgrid_table_id).jqGrid("getGridParam", "colModel");
               if (cm[col].name == 'str_OrdenAsignada') {
                  mostrarModalInformacionMaquina(row);
               }
            },

            loadError: function (xhr, st, err) {
               if (xhr.responseJSON) {
                  custom_alert_type("error", xhr.responseJSON.Message, "Error");
               } else {
                  mostrarAlertaErrorPeticion(xhr, st);
               }
            }
         });
      },
      subGridOptions: {
         reloadOnExpand: false,
         selectOnExpand: false
      },

      onSelectRow: function (rowid) {
         idRowMaquina = $(this).jqGrid("getGridParam", "selrow");
      },

      loadComplete: function () {
         var grid = $("#jqgMaquinas");
         var ids = $("#jqgMaquinas").jqGrid('getDataIDs');
         $.each(ids, function (i, item) {
            var row = $("#jqgMaquinas").getRowData(item);
            if (row.TieneEmparejamiento != "1") $("#" + item + " td.sgcollapsed", grid[0]).unbind('click').html('');
         });

         $("#jqgMaquinas").jqGrid('setSelection', idRowMaquina);
      },

      onCellSelect: function (row, col, content, event) {
         var cm = $("#jqgMaquinas").jqGrid("getGridParam", "colModel");
         if (cm[col].name == 'OrdenAsignada') {
            mostrarModalInformacionMaquina(row);
         }
      },

      loadError: function (xhr, st, err) {
         if (xhr.responseJSON) {
            custom_alert_type("error", xhr.responseJSON.Message, "Error");
         } else {
            mostrarAlertaErrorPeticion(xhr, st);
         }
      }
   });
   $("#jqgMaquinas").parents('div.ui-jqgrid-bdiv').css("max-height", "350px");

   $("#jqgConfiguracionUnidad").jqGrid({
      datatype: "local",
      data: [],

      height: "auto",
      width: "auto",

      colNames: ['Seq', 'N° Parte', 'Cantidad', 'Descripción'],
      colModel: [
                  { name: 'Seq', index: 'Seq', width: 30 },
                  { name: 'NroParte', index: 'NroParte', width: 100 },
                  { name: 'Cantidad', index: 'Cantidad', width: 60 },
                  { name: 'Descripcion', index: 'Descripcion', width: 250 }
               ],

      regional: 'es',
      viewrecords: true,
      gridview: gridView
   });

   $("#jqgNegociaciones").jqGrid({
      datatype: "local",
      data: [],

      height: "auto",
      width: "auto",

      colNames: ['&nbsp;', 'Nro', 'F. Negoc', 'F. Límite', '%Prob', 'Oportunidad', 'Cliente', 'Vendedor', 'Estado', 'Observaciones'],
      colModel: [
                  { name: 'accion', index: 'accion', width: 15 },
                  { name: 'nroNegociacion', index: 'nroNegociacion', key: true, width: 30, align: 'center', sortable: false },
                  { name: 'fechaNegociacion', index: 'fechaNegociacion', width: 70, sortable: false, formatter: 'date', formatoptions: { srcformat: "d/m/Y", newformat: "d/m/Y"} },
                  { name: 'fechaLimiteReserva', index: 'fechaLimiteReserva', width: 70, sortable: false, formatter: 'date', formatoptions: { srcformat: "d/m/Y", newformat: "d/m/Y"} },
                  { name: 'probabilidad', index: 'probabilidad', width: 50, sortable: false },
                  { name: 'oportunidad', index: 'oportunidad', width: 80, sortable: false },
                  { name: 'clienteDesc', index: 'clienteDesc', width: 185, sortable: false },
                  { name: 'vendedorDesc', index: 'vendedorDesc', width: 185, sortable: false },
                  { name: 'estadoNegociacion', index: 'estadoNegociacion', width: 40, formatter: formatEstadoNeg, unformat: unformatEstadoNeg, sortable: false },
                  { name: 'observaciones', index: 'observaciones', width: 175, sortable: false }
               ],

      regional: 'es',
      viewrecords: true,
      gridview: gridView,

      gridComplete: function () {
         var ids = $("#jqgNegociaciones").jqGrid('getDataIDs');
         var edit = "<img src='../Images/editar.png' style='cursor:pointer;' title='Modificar Negociación' onclick=\"mostrarModalModificacionReserva('" + ids[0] + "');\" />";
         $("#jqgNegociaciones").jqGrid('setRowData', ids[0], { accion: edit });
      }
   });

   $("#jqgMaquinasEmparejamiento").jqGrid({
      datatype: "local",
      data: [],

      height: "auto",
      width: "auto",

      colModel: [
                  { label: 'Anti. Maq.', name: 'antiguamientoMaquina', index: 'antiguamientoMaquina', align: 'center', width: 30 },
                  { label: 'Orden', name: 'orden', index: 'orden', key: true, width: 80 },
                  { label: 'Modelo', name: 'modelo', index: 'modelo', width: 220 },
               ],

      regional: 'es',
      viewrecords: true,
      multiselect: true,
      gridview: gridView
   });
   $("#jqgMaquinasEmparejamiento").parents('div.ui-jqgrid-bdiv').css("max-height", "300px");

   $("#jqgMaquinasRelacionadas").jqGrid({
      datatype: "local",
      data: [],

      height: "auto",
      width: "auto",

      colModel: [
                  { label: '&nbsp;', name: 'accion', index: 'accion', width: 15 },
                  { label: 'Orden', name: 'orden', index: 'orden', key: true, width: 100 },
                  { label: 'Modelo', name: 'modelo', index: 'modelo', width: 290 },
               ],

      regional: 'es',
      viewrecords: true,
      gridview: gridView,

      gridComplete: function () {
         var ids = $("#jqgMaquinasRelacionadas").jqGrid('getDataIDs');
         for (var i = 0; i < ids.length; i++) {
            del = "<img src='../Images/delete.png' style='cursor:pointer;' title='Eliminar' onclick=\"eliminarFilaGridMaqRelacionadas('" + ids[i] + "');\" />";
            $("#jqgMaquinasRelacionadas").jqGrid('setRowData', ids[i], { accion: del });
         }
      }
   });

   $("#jqgClientes").jqGrid({
      url: location.pathname + "/ObtenerClientes",
      mtype: "POST",
      datatype: "local",

      ajaxGridOptions: {
         contentType: 'application/json; charset=utf-8'
      },
      postData: {
         codigo: '',
         descripcion: ''
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

      colModel: [
                  { label: 'Código', name: 'COD_CLIENTE', index: 'COD_CLIENTE', key: true, sortable: false, width: 80 },
                  { label: 'Cliente', name: 'DESC_CLIENTE', index: 'DESC_CLIENTE', sortable: false, width: 400 },
               ],

      rowNum: 10,
      rownumbers: true,
      rowList: [5, 10, 20],
      viewrecords: true,
      loadtext: 'Cargando datos...',
      recordtext: "{0} - {1} de {2}",
      emptyrecords: 'No hay resultados',
      pgtext: 'Pág: {0} de {1}',
      pager: '#pagerClientes',
      regional: 'es',
      gridview: gridView,

      loadComplete: function () {
         preload(false);

         if (!$("#modalBuscarCliente").dialog("isOpen") && $('#jqgClientes').jqGrid('getGridParam','datatype') == "json") {
            var ids = $("#jqgClientes").jqGrid('getDataIDs');
            
            if (ids.length == 1) {
               var row = $("#jqgClientes").getRowData(ids[0]);
               $("#txtClienteReservaModal").val(row.COD_CLIENTE);
               $("#lblClienteDescReservaModal").text(row.DESC_CLIENTE);
            } else {
               var idCliente = $("#txtClienteReservaModal").val();
               if (ids.length == 0) $("#lblClienteDescReservaModal").text("");
               $("#txtClienteIdModalBusCli").val(idCliente);
               $('#modalBuscarCliente').dialog('open');
            }
         }
      },

      loadError: function (xhr, st, err) {
         preload(false);
         if (xhr.responseJSON) {
            custom_alert_type("error", xhr.responseJSON.Message, "Error");
         } else {
            mostrarAlertaErrorPeticion(xhr, st);
         }
      }
   });

   $("#jqgVendedores").jqGrid({
      url: location.pathname + "/ObtenerVendedores",
      mtype: "POST",
      datatype: "local",

      ajaxGridOptions: {
         contentType: 'application/json; charset=utf-8'
      },
      postData: {
         codigo: '',
         descripcion: ''
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

      colModel: [
                  { label: 'Código', name: 'Codigo', index: 'Codigo', key: true, sortable: false, width: 80 },
                  { label: 'Nombre', name: 'NombreCompleto', index: 'NombreCompleto', sortable: false, width: 400 },
               ],

      rowNum: 10,
      rownumbers: true,
      rowList: [5, 10, 20],
      viewrecords: true,
      loadtext: 'Cargando datos...',
      recordtext: "{0} - {1} de {2}",
      emptyrecords: 'No hay resultados',
      pgtext: 'Pág: {0} de {1}',
      pager: '#pagerVendedores',
      regional: 'es',
      gridview: gridView,

      loadComplete: function () {
         preload(false);

         if (!$("#modalBuscarVendedor").dialog("isOpen") && $('#jqgVendedores').jqGrid('getGridParam','datatype') == "json") {
            var ids = $("#jqgVendedores").jqGrid('getDataIDs');
            
            if (ids.length == 1) {
               var row = $("#jqgVendedores").getRowData(ids[0]);
               $("#txtVendedorReservaModal").val(row.Codigo);
               $("#lblVendedorDescReservaModal").text(row.NombreCompleto);
            } else {
               var idCliente = $("#txtVendedorReservaModal").val();
               if (ids.length == 0) $("#lblVendedorDescReservaModal").text("");
               $("#txtVendedorIdModalBusven").val(idCliente);
               $('#modalBuscarVendedor').dialog('open');
            }
         }
      },

      loadError: function (xhr, st, err) {
         preload(false);
         if (xhr.responseJSON) {
            custom_alert_type("error", xhr.responseJSON.Message, "Error");
         } else {
            mostrarAlertaErrorPeticion(xhr, st);
         }
      }
   });

   $("#frmReserva").validate({
      rules: {
         clienteReservaModal: "required",
         vendedorReservaModal: "required",
         fechaLimiteReservaModal: {
            required: true,
            date: true
         }
      },
      messages: {
         clienteReservaModal: "Ingrese el cliente.",
         vendedorReservaModal: "Ingrese el vendedor.",
         fechaLimiteReservaModal: {
            required: "Ingrese la fecha límite de la reserva."
         }
      }
   });

   /*uploadObj = $("#fileuploader").uploadFile({
	   url: ObtenerRutaCargaFinal("CargaBase.ashx"),
	   fileName: "myfile",
      returnType: "json",
      showDone: false,
      dragDrop: false,
      showDelete: true,
      deletelStr: "Eliminar",
      uploadStr: "Subir archivo",
      showFileCounter: false,
      deleteCallback: function (data, pd) {
         $.post(ObtenerRutaEliminarArchivo(), {nombre: data[0].nuevoNombre},
            function (resp,textStatus, jqXHR) { }
         );
         pd.statusbar.hide();
      },
	});*/

   obtenerDatosIniciales();
});

function obtenerDatosIniciales() {
   $.customAjax({ url: location.pathname + "/ObtenerDatosIniciales", parametros: {} },
      function (respuesta) {
         if (respuesta.success) {
            //Llenar los Estados para el filtro
            $.each(respuesta.data.estados, function (i, item) {
               $('#filtroEstado').append($('<option>', {
                  value: item.id,
                  text: item.desc
               }));
            });
            //Configurar las columnas visibles
            $("#jqgMaquinas").jqGrid('setGridParam', { datatype: "json" });
            $.each(respuesta.data.columnas, function (i, item) {
               $("#jqgMaquinas").showCol(item.NombreColumna);
            });
            $("#gridMaqWrapper").show();
            $("#jqgMaquinas").jqGrid().trigger("reloadGrid");
         }
      }, null, null, true
   );
};

function limpiarFiltros() {
   $("#filtroCuenta").val("");
   $("#filtroMarca").val("");
   $("#filtroModelo").val("");
   $("#filtroOrden").val("");

   $("#filtroProyecto").val("");
   $("#filtroCliente").val("");
   $("#filtroVendedor").val("");
   $("#filtroProceso").val("");

   $("#filtroFechaDesde").val("");
   $("#filtroFechaHasta").val("");
   $("#filtroSemaforo").val([""]);
   $("#filtroEstado").val([""]);
   $("#filtroUbicacion").val("");

   $("#filtroFechaHasta").datepicker("option", "minDate", "");
   $("#filtroFechaDesde").datepicker("option", "maxDate", "");
};

function gridMaquinasReload(mantenerSeleccion, primeraPagina) {
   var filtro = obtenerObjetoFiltro();

   $("#jqgMaquinas").jqGrid()[0].p.postData.filtro = filtro;

   if (!mantenerSeleccion)
      idRowMaquina = null;

   if (primeraPagina)
      $("#jqgMaquinas").jqGrid('setGridParam',{page:1});

   $("#jqgMaquinas").jqGrid().trigger("reloadGrid");
};

function initGrid() {
   $(this).contextMenu('contextMenuMaquinas', {
      bindings: {
         'crearReserva': function (t) {
            if (idRowMaquina != null) {
               var row = $("#jqgMaquinas").getRowData(idRowMaquina);
               if (row.EstadoMaquina == "TRANSITO" || row.EstadoMaquina == "LIBRE") {
                  $.customAjax({ url: location.pathname + "/ObtenerDatosNuevaReserva", parametros: { orden: idRowMaquina} },
                     function (respuesta) {
                        if (respuesta.success) {
                           objReserva = respuesta.data;
                           $("#modalReserva").dialog('option', 'title', titulosModal.reserva + ' - UNIDAD ' + idRowMaquina);
                           mostrarInformacionReserva(objReserva);
                           $('#modalReserva').dialog('open');
                           $("#frmReserva").validate().resetForm();
                           $("#txtOportunidadReservaModal").focus();
                        }
                     }, null, null, true
                  );
               } else {
                  custom_alert("La Máquina debe estar Libre o en Tránsito");
               }
            } else {
               custom_alert("Seleccione un registro.");
            }
         },
         'anularReserva': function (t) {
            if (idRowMaquina != null) {
               var row = $("#jqgMaquinas").getRowData(idRowMaquina);
               if (row.EstadoMaquina == "RESERVADO") {
                  custom_confirmation(function () {
                     ajaxAnularReservas([idRowMaquina], true);
                  }, function () {
                  });
               } else {
                  custom_alert("La Máquina no está Reservada.");
               }
            } else {
               custom_alert("Seleccione un registro.");
            }
         },
         'modificarUnidad': function (t) {
            if (idRowMaquina != null) {
               $.customAjax({ url: location.pathname + "/ObtenerDatosMaquinaModificacion", parametros: { orden: idRowMaquina} },
                  function (respuesta) {
                     if (respuesta.success) {
                        asignarValoresModalModificacion(false, respuesta.data);

                        if (respuesta.data.estadoMaquina == "L" || respuesta.data.estadoMaquina == "T" || respuesta.data.estadoMaquina == "R") {
                           $("#rowEmparejamiento").show();
                           if (respuesta.data.liMaquinas.length > 0)
                              $("#gridMaqRelWrapper").show();
                        }

                        //Mostrar Modal de modificación con las ordenes relacionadas.
                        $("#modalModificacion").dialog('option', 'title', titulosModal.modificacion + ' - UNIDAD ' + idRowMaquina);
                        $('#modalModificacion').dialog('open');
                     }
                  }, null, null, true
               );
            } else {
               custom_alert("Seleccione un registro.");
            }
         }
      }
   });
};

function formatOrden(cellValue, options, rowObject) {
   return "<span style='color:blue; border-bottom: 1px solid; cursor:pointer;'>" + cellValue + "</span>";
};

function unformatOrden(cellValue, options, cellObject) {
   return $(cellObject.html()).attr("originalValue");
};

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

function formatUbicacion(cellValue, options, cellObject) {
   var colorSemaforo = cellObject.DiasUbicacion < 15 ? 'green' : 'red';
   if (cellObject.UbicacionDesc == "DEMO") {
      return "<span align='center' style='width:30px;display:inline-block;background:" + colorSemaforo + ";padding-top:2px;padding-bottom:2px;color:white'>" + cellObject.DiasUbicacion + "</span><span style='margin-left:10px;'>" + cellValue + "</span>";
   } else {
      return "<span style='margin-left:40px;'>" + (cellValue == null ? '&nbsp' : cellValue) + "</span>";
   }
};

function unformatUbicacion(cellValue, options, cellObject) {
   return $(cellObject.html()).attr("originalValue");
};

function formatSemaforo(cellValue, options, cellObject) {
   if (cellValue == null) {
      return "";
   } else {
      var classSemaforo = cellValue <= 6 ? "semaforoVerde" : ((cellValue >= 7 && cellValue <= 12) ? "semaforoAmarillo" : (cellValue >= 13 ? "semaforoRojo" : ""));
      return "<div style='margin-left:5px;' class='" + classSemaforo + "'></div>"
   }
};

function unformatSemaforo(cellValue, options, cellObject) {
   return $(cellObject.html()).attr("originalValue");
};

function formatDescCuenta(cellValue, options, rowObject) {
   return rowObject.IdCuenta + " " + cellValue
};

function unformatDescCuenta(cellValue, options, cellObject) {
   return $(cellObject.html()).attr("originalValue");
};

function formatEstadoNeg(cellValue, options, rowObject) {
   var classSemaforo = cellValue == "1" ? "semaforoVerde" : "semaforoRojo";
   return "<div style='margin-left:10px;' class='" + classSemaforo + "'></div>"
};

function unformatEstadoNeg(cellValue, options, cellObject) {
   return $(cellObject.html()).attr("originalValue");
};

function mostrarModalInformacionMaquina(orden) {
   $.customAjax({ url: location.pathname + "/ObtenerDatosMaquinaCabecera", parametros: { orden: orden} },
      function (respuesta) {
         if (respuesta.success) {
            if (respuesta.data.infoMaquinaCabecera != null){
               $("#modalInformacionUnidad").dialog('option', 'title', titulosModal.informacionUnidad + ' - UNIDAD ' + orden);
               mostrarInformacionMaquinaCabecera(respuesta.data.infoMaquinaCabecera);
               mostrarInformacionNegociaciones(respuesta.data.infoMaquinaCabecera, respuesta.data.liNegociaciones);
               $('#modalInformacionUnidad').dialog('open');
            } else {
               custom_alert_type("error", "No existe información de la máquina " + orden + ".", "Error");
            }
         }
      }, null, null, true
   );
};

function mostrarInformacionMaquinaCabecera(data) {
   $("#lblOrdenModalInfo").html(data.OrdenAsignada);
   $("#lblMarcaModalInfo").html(getValueEmpty(data.MarcaId) + " - " + getValueEmpty(data.MarcaDesc));
   $("#lblModeloModalInfo").html(data.ModeloProductoId);
   $("#lblDescripcionModalInfo").html(data.ModeloProductoDesc);
   $("#lblFamiliaProdModalInfo").html(data.FamiliaDesc);
   $("#lblTipoProdModalInfo").html(data.TipoProducto);
   $("#lblNroCatModalInfo").html(data.NroCAT);
   $("#lblSerieUnidadModalInfo").html(data.SerieMaquina);
   $("#lblAnioFabModalInfo").html(data.AnoFabricacionMaquina);
   $("#lblSerieMotorModalInfo").html(data.MotorSerie);
   $("#lblCuentaModalInfo").html(getValueEmpty(data.CuentaInventarioDBS) + " - " + getValueEmpty(data.CuentaDesc));
   $("#lblDivisionModalInfo").html(getValueEmpty(data.Division) + " - " + getValueEmpty(data.DivisionDesc));
   $("#lblCondicionModalInfo").html(data.EstadoInventario);
};

function limpiarInformacionMaquinaCabecera() {
   $("#lblOrdenModalInfo").text("");
   $("#lblMarcaModalInfo").text("");
   $("#lblModeloModalInfo").text("");
   $("#lblDescripcionModalInfo").text("");
   $("#lblFamiliaProdModalInfo").text("");
   $("#lblTipoProdModalInfo").text("");
   $("#lblNroCatModalInfo").text("");
   $("#lblSerieUnidadModalInfo").text("");
   $("#lblAnioFabModalInfo").text("");
   $("#lblSerieMotorModalInfo").text("");
   $("#lblCuentaModalInfo").text("");
   $("#lblDivisionModalInfo").text("");
   $("#lblCondicionModalInfo").text("");
};

function mostrarInformacionMaquinaSeguimientoImportacion(data) {
   $("#lblNroFacFabModalInfo").html(data.FacturaFabricaNum);
   $("#lblIncotermModalInfo").html(data.IncotermId);
   $("#lblTipoEmbModalInfo").html(data.TipoEmbarque);
   $("#lblFreightForModalInfo").html(data.UnidadFreightForwarder);
   $("#lblPuertoSalModalInfo").html(data.PuertoSalidaDesc);
   $("#lblNroDocEmbModalInfo").html(data.NroDocEmbarque);
   $("#lblBuqueModalInfo").html(data.BuqueDesc);
   $("#lblAgenteAduModalInfo").html(getValueEmpty(data.AgenteId) + " - " + getValueEmpty(data.AgenteDesc));
   $("#lblTipoDes").html(data.TipoDespacho);
   $("#lblPolizaImpModalInfo").html(data.PolizaImportacion);
   $("#lblRegimenImpModalInfo").html(data.RegimenImportacionMaquina);
   $("#lblVentaEndDocModalInfo").html(data.Endose);
   $("#lblTransportistaAsiModalInfo").html(getValueEmpty(data.TransportistaId) + " - " + getValueEmpty(data.TransportistaDesc));
   $("#lblPaisOriModalInfo").html(getValueEmpty(data.PaisOrigenId) + " - " + getValueEmpty(data.PaisOrigenDesc));
   $("#lblCubicMetModalInfo").html(data.MetrosCubicos);
   $("#lblPrestamoModalInfo").html(data.Prestamo);
   $("#lblObservacionesModalInfo").html(data.Observaciones);
   $("#lblClienteModalInfo").html(getValueEmpty(data.ClienteId) + " - " + getValueEmpty(data.ClienteDesc));

   $("#lblfechaColFabModalInfo").html(convertirDateTime(data.OrdenFabricaFecha, formatoFecha));
   $("#lblFechaEstSalFabModalInfo").html(convertirDateTime(data.SalidaFabricaEstimadaFecha, formatoFecha));
   $("#lblFechaSalFabModalInfo").html(convertirDateTime(data.SalidaFabricaFecha, formatoFecha));
   $("#lblFechaFacFabModalInfo").html(convertirDateTime(data.FacturaFabricaFecha, formatoFecha));
   $("#lblFechaRecForModalInfo").html(convertirDateTime(data.RecepcionForwarderFecha, formatoFecha));
   $("#lblFechaEstEmbModalInfo").html(convertirDateTime(data.EmbarqueEstimadaFecha, formatoFecha));
   $("#lblFechaEstArrPueModalInfo").html(convertirDateTime(data.ArriboPuertoEstimadaFecha, formatoFecha));
   $("#lblFechaArrPueModalInfo").html(convertirDateTime(data.ArriboPuertoFecha, formatoFecha));
   $("#lblFechaFinDesModalInfo").html(convertirDateTime(data.FinDescargaFecha, formatoFecha));
   $("#lblFechaLevAduModalInfo").html(convertirDateTime(data.LevanteAduaneroFecha, formatoFecha));
   $("#lblFechaEstIngFisModalInfo").html(convertirDateTime(data.IngresoFisicoFESAEstimadaFecha, formatoFecha));
   $("#lblFechaIngFisModalInfo").html(convertirDateTime(data.IngresoFisicoFESAFecha, formatoFecha));
   $("#lblUnidadFecEntTalModalInfo").html(convertirDateTime(data.EntregaTallerFecha, formatoFecha));
   $("#lblUnidadFecSalTalModalInfo").html(convertirDateTime(data.SalidaTallerFecha, formatoFecha));

   $("#lblTimeFechaEstSalFabModalInfo").html(diferenciaDiasFechas(data.SalidaFabricaEstimadaFecha, data.OrdenFabricaFecha, formatoFecha));
   $("#lblTimeFechaSalFabModalInfo").html(diferenciaDiasFechas(data.SalidaFabricaFecha, data.OrdenFabricaFecha, formatoFecha));
   $("#lblTimeFechaFacFabModalInfo").html(diferenciaDiasFechas(data.FacturaFabricaFecha, data.OrdenFabricaFecha, formatoFecha));
   $("#lblTimeFechaRecForModalInfo").html(diferenciaDiasFechas(data.RecepcionForwarderFecha, data.OrdenFabricaFecha, formatoFecha));
   $("#lblTimeFechaEstEmbModalInfo").html(diferenciaDiasFechas(data.EmbarqueEstimadaFecha, data.OrdenFabricaFecha, formatoFecha));
   $("#lblTimeFechaEstArrPueModalInfo").html(diferenciaDiasFechas(data.ArriboPuertoEstimadaFecha, data.OrdenFabricaFecha, formatoFecha));
   $("#lblTimeFechaArrPueModalInfo").html(diferenciaDiasFechas(data.ArriboPuertoFecha, data.OrdenFabricaFecha, formatoFecha));
   $("#lblTimeFechaFinDesModalInfo").html(diferenciaDiasFechas(data.FinDescargaFecha, data.OrdenFabricaFecha, formatoFecha));
   $("#lblTimeFechaLevAduModalInfo").html(diferenciaDiasFechas(data.LevanteAduaneroFecha, data.OrdenFabricaFecha, formatoFecha));
   $("#lblTimeFechaEstIngFisModalInfo").html(diferenciaDiasFechas(data.IngresoFisicoFESAEstimadaFecha, data.OrdenFabricaFecha, formatoFecha));
   $("#lblTimeFechaIngFisModalInfo").html(diferenciaDiasFechas(data.IngresoFisicoFESAFecha, data.OrdenFabricaFecha, formatoFecha));
   $("#lblTimeUnidadFecEntTalModalInfo").html(diferenciaDiasFechas(data.EntregaTallerFecha, data.OrdenFabricaFecha, formatoFecha));
   $("#lblTimeUnidadFecSalTalModalInfo").html(diferenciaDiasFechas(data.SalidaTallerFecha, data.OrdenFabricaFecha, formatoFecha));
};

function limpiarInformacionMaquinaSeguimientoImportacion() {
   $("#lblNroFacFabModalInfo").text("");
   $("#lblIncotermModalInfo").text("");
   $("#lblTipoEmbModalInfo").text("");
   $("#lblFreightForModalInfo").text("");
   $("#lblPuertoSalModalInfo").text("");
   $("#lblNroDocEmbModalInfo").text("");
   $("#lblBuqueModalInfo").text("");
   $("#lblAgenteAduModalInfo").text("");
   $("#lblTipoDes").text("");
   $("#lblPolizaImpModalInfo").text("");
   $("#lblRegimenImpModalInfo").text("");
   $("#lblVentaEndDocModalInfo").text("");
   $("#lblTransportistaAsiModalInfo").text("");
   $("#lblPaisOriModalInfo").text("");
   $("#lblCubicMetModalInfo").text("");
   $("#lblPrestamoModalInfo").text("");
   $("#lblObservacionesModalInfo").text("");
   $("#lblClienteModalInfo").text("");

   $("#lblfechaColFabModalInfo").text("");
   $("#lblFechaEstSalFabModalInfo").text("");
   $("#lblFechaSalFabModalInfo").text("");
   $("#lblFechaFacFabModalInfo").text("");
   $("#lblFechaRecForModalInfo").text("");
   $("#lblFechaEstEmbModalInfo").text("");
   $("#lblFechaEstArrPueModalInfo").text("");
   $("#lblFechaArrPueModalInfo").text("");
   $("#lblFechaFinDesModalInfo").text("");
   $("#lblFechaLevAduModalInfo").text("");
   $("#lblFechaEstIngFisModalInfo").text("");
   $("#lblFechaIngFisModalInfo").text("");
   $("#lblUnidadFecEntTalModalInfo").text("");
   $("#lblUnidadFecSalTalModalInfo").text("");

   $("#lblTimeFechaEstSalFabModalInfo").text("");
   $("#lblTimeFechaSalFabModalInfo").text("");
   $("#lblTimeFechaFacFabModalInfo").text("");
   $("#lblTimeFechaRecForModalInfo").text("");
   $("#lblTimeFechaEstEmbModalInfo").text("");
   $("#lblTimeFechaEstArrPueModalInfo").text("");
   $("#lblTimeFechaArrPueModalInfo").text("");
   $("#lblTimeFechaFinDesModalInfo").text("");
   $("#lblTimeFechaLevAduModalInfo").text("");
   $("#lblTimeFechaEstIngFisModalInfo").text("");
   $("#lblTimeFechaIngFisModalInfo").text("");
   $("#lblTimeUnidadFecEntTalModalInfo").text("");
   $("#lblTimeUnidadFecSalTalModalInfo").text("");
};

function mostrarInformacionMaquinaInfoInventario(data) {
   $("#lblAntiguamientoModalInfo").html(data.AntiguamientoMaquina);
   $("#lblUbicacionModalInfo").html(getValueEmpty(data.UbicacionId) + " - " + getValueEmpty(data.UbicacionDesc));
   $("#lblDiasInvSalFabModalInfo").html(data.DiasInvDesdeSalidaFabrica);
   $("#lblBahia").html(data.Bahia);
   $("#lblDiasInvLevModalInfo").html(data.DiasInvDesdeLevante);
   $("#lblStore").html(data.StoreId);
   $("#lblDiasColFab").html(data.DiasInvDesdeOCFabrica);
};

function limpiarInformacionMaquinaInfoInventario() {
   $("#lblAntiguamientoModalInfo").text("");
   $("#lblUbicacionModalInfo").text("");
   $("#lblDiasInvSalFabModalInfo").text("");
   $("#lblBahia").text("");
   $("#lblDiasInvLevModalInfo").text("");
   $("#lblStore").text("");
   $("#lblDiasColFab").text("");
};

function mostrarInformacionMaquinaDatosTecnicos(data) {
   $("#lblHorometroModalInfo").html(data.Horometro);
   $("#lblFechaUltLecHorModalInfo").html(convertirDateTime(data.HorometroUltimaLecturaFecha, formatoFecha));
   if (data.IndicadorNPI == 'S')
      $("#chkIndicadorNPIModalInfo").prop('checked', true);
   $("#lblUnicacionEquModalInfo").html(data.UbicacionDT);
   $("#lblNroSerMotModalInfo").html(data.MotorSerie);
   $("#lblArregloMotModalInfo").html(data.MotorArreglo);
   $("#lblMarcaMotModalInfo").html(data.MotorMarca);
   $("#lblModeloMotModalInfo").html(data.MotorModelo);
};

function limpiarInformacionMaquinaDatosTecnicos() {
   $("#lblHorometroModalInfo").text("");
   $("#lblFechaUltLecHorModalInfo").text("");
   $("#chkIndicadorNPIModalInfo").prop('checked', false);
   $("#lblUnicacionEquModalInfo").text("");
   $("#lblNroSerMotModalInfo").text("");
   $("#lblArregloMotModalInfo").text("");
   $("#lblMarcaMotModalInfo").text("");
   $("#lblModeloMotModalInfo").text("");
};

function mostrarInformacionMaquinaConfiguracionUnidad(liConfiguraciones) {
   $("#jqgConfiguracionUnidad").setGridParam({ rowNum: liConfiguraciones.length });
   $("#jqgConfiguracionUnidad").jqGrid('setGridParam', { data: liConfiguraciones }).trigger("reloadGrid");
};

function limpiarInformacionMaquinaConfiguracionUnidad() {
   $("#jqgConfiguracionUnidad").setGridParam({sortname: ""});
   $('#gbox_jqgConfiguracionUnidad .s-ico').css('display','none');
   $('#jqgConfiguracionUnidad').jqGrid('clearGridData');
};

function mostrarInformacionNegociaciones(data, liNegociaciones) {
   $("#lblDescripcionModalNeg").html(data.ModeloProductoDesc);
   $("#lblSerieUnidadModalNeg").html(data.SerieMaquina);
   $("#lblNroCatModalNeg").html(data.NroCAT);
   $("#lblDivisionModalNeg").html(data.DivisionDesc);
   $("#lblCuentaModalNeg").html(data.CuentaDesc);
   $("#lblAnioFabModalNeg").html(data.AnoFabricacionMaquina);
   $("#lblProveedorModalNeg").html(data.MarcaDesc);
   $("#lblUbicacionModalNeg").html(data.UbicacionDesc);

   $("#jqgNegociaciones").setGridParam({ rowNum: liNegociaciones.length });
   $("#jqgNegociaciones").jqGrid('setGridParam', { data: liNegociaciones }).trigger("reloadGrid");
   $("input:radio[name=rdEstadoNegociacion][value ='1']").prop('checked', true);
   filtrarNegociaciones("1");
};

function limpiarInformacionNegociaciones() {
   $("#lblDescripcionModalNeg").text("");
   $("#lblSerieUnidadModalNeg").text("");
   $("#lblNroCatModalNeg").text("");
   $("#lblDivisionModalNeg").text("");
   $("#lblCuentaModalNeg").text("");
   $("#lblAnioFabModalNeg").text("");
   $("#lblProveedorModalNeg").text("");
   $("#lblUbicacionModalNeg").text("");

   $('#jqgNegociaciones').jqGrid('clearGridData');
};

function filtrarNegociaciones(estado) {
   var f = {};
   if (estado == "1") {
      f = { groupOp: "AND", rules: [] };
      f.rules.push({ field: "estadoNegociacion", op: "eq", data: "1" });
      $("#jqgNegociaciones")[0].p.search = f.rules.length > 0;
   }
   $.extend($("#jqgNegociaciones")[0].p.postData, { filters: JSON.stringify(f) });
   $("#jqgNegociaciones").trigger("reloadGrid");
};

function mostrarModalModificacionReserva(reservaId) {
   $.customAjax({ url: location.pathname + "/ObtenerDatosReserva", parametros: { reservaId: reservaId } },
      function (respuesta) {
         if (respuesta.success) {
            if (respuesta.data != null) {
               objReserva = respuesta.data;
               $("#modalReserva").dialog('option', 'title', titulosModal.reserva + ' - UNIDAD ' + objReserva.ordenAsignada);
               mostrarInformacionReserva(objReserva);
               $('#modalReserva').dialog('open');
               $("#frmReserva").validate().resetForm();
               $("#txtOportunidadReservaModal").focus();
            }
         }
      }, null, null, true
   );
};

function mostrarInformacionReserva(reserva) {
   $("#lblNroNegReservaModal").text(reserva.nroNegociacion);
   $("#EstNegReservaModal").addClass(reserva.estadoNegociacion == "1" ? "semaforoVerde" : "semaforoRojo");
   $("#lblFchNegReservaModal").text(convertirDateTime(reserva.fechaNegociacion, "DD/MM/YYYY"));
   $("#fechaLimiteReservaModal").datepicker('setDate', convertirDateTime(reserva.fechaLimiteReserva, "DD/MM/YYYY"));
   $("#txtOportunidadReservaModal").val(reserva.oportunidad);
   $("#txtClienteReservaModal").val(reserva.clienteId);
   $("#lblClienteDescReservaModal").text(getValueEmpty(reserva.clienteDesc));
   $("#txtVendedorReservaModal").val(reserva.vendedorId);
   $("#lblVendedorDescReservaModal").text(getValueEmpty(reserva.vendedorDesc));
   $("#txtObsReservaModal").val(reserva.observaciones);
   $("#lblFchEstIngReservaModal").text(convertirDateTime(reserva.fechaEstimadaIngreso, "DD/MM/YYYY"));
   $("#lblFchOfreCliReservaModal").text(convertirDateTime(reserva.fechaOfrecidaCliente, "DD/MM/YYYY"));

   if (reserva.nroNegociacion != 0) {
      if (reserva.estadoNegociacion == "1") {
         $("#ContentBtnAnularReservaModal").show();
      }
      $("#txtOportunidadReservaModal").prop('disabled', true);
      $("#txtClienteReservaModal").prop('disabled', true);
      $("#txtVendedorReservaModal").prop('disabled', true);
      $("#btnBuscarClienteReserva").prop('disabled', true);
      $("#btnBuscarVendedorReserva").prop('disabled', true);
   }
};

function ajaxAnularReservas(ordenes, mantenerFilaSeleccionada) {
   $.customAjax({ url: location.pathname + "/AnularReservas", parametros: { ordenes: ordenes} },
      function (respuesta) {
         if (respuesta.success) {
            mostrarMensajeProceso({ tipo: 'success', mensaje: mensajesProceso.anularReservasOK });
            gridMaquinasReload(mantenerFilaSeleccionada);

            //Si se anula desde el modal de reserva
            if ($("#modalReserva").dialog("isOpen")) {
               var orden = objReserva.ordenAsignada;
               $("#modalReserva").dialog("close");
               gridNegociacionesReload(orden);
            }
         }
      }, null, null, true
   );
};

function gridNegociacionesReload(orden) {
   $.customAjax({ url: location.pathname + "/ObtenerNegociacionesMaquina", parametros: { orden: orden} },
      function (respuesta) {
         if (respuesta.success) {
            $('#jqgNegociaciones').jqGrid('clearGridData');
            $("#jqgNegociaciones").setGridParam({ rowNum: respuesta.data.length });
            $("#jqgNegociaciones").jqGrid('setGridParam', { data: respuesta.data }).trigger("reloadGrid");
            var valueRadioNeg = $('input[type=radio][name=rdEstadoNegociacion]:checked').val();
            filtrarNegociaciones(valueRadioNeg);
         }
      }, function (error) {
         $("#load_jqgNegociaciones").hide()
      }, function () {
         $("#load_jqgNegociaciones").show()
      }
   );
};

function seleccionadoAlMenosUno() {
   var grid = $("#jqgMaquinas");
   var rowKey = grid.getGridParam("selrow");

   return rowKey;
};

function eliminarFilaGridMaqRelacionadas(id) {
   $("#jqgMaquinasRelacionadas").delRowData(id);
   var ids = $("#jqgMaquinasRelacionadas").jqGrid('getDataIDs');
   if (ids.length == 0) $("#gridMaqRelWrapper").hide();
};

function asignarValoresModalModificacion(limpiar, datos) {
   if (limpiar) {
      $("#txtVersionModif").val("");
      $("#txtProyectoModif").val("");
      $("#txtObservacionesModif").val("");
      $('#jqgMaquinasRelacionadas').jqGrid('clearGridData');
   } else {
      $("#txtVersionModif").val(datos.version);
      $("#txtProyectoModif").val(datos.proyecto);
      $("#txtObservacionesModif").val(datos.observaciones);
      jQuery("#jqgMaquinasRelacionadas").setGridParam({ rowNum: datos.liMaquinas.length });
      jQuery("#jqgMaquinasRelacionadas").jqGrid('setGridParam', { data: datos.liMaquinas }).trigger("reloadGrid");
   }
};

function descargar() {
   var parametros = obtenerObjetoFiltro();
   $.customFileDownload("MaquinasInventario.ashx", parametros);
};

function obtenerObjetoFiltro() {
   return { 
      cuenta: $('#filtroCuenta').val(),
      marca: $('#filtroMarca').val(),
      modelo: $('#filtroModelo').val(),
      orden: $('#filtroOrden').val(),

      proyecto: $('#filtroProyecto').val(),
      cliente: $('#filtroCliente').val(),
      vendedor: $('#filtroVendedor').val(),
      proceso: $('#filtroProceso').val(),

      fechaEstIngDesde: $('#filtroFechaDesde').val(),
      fechaEstIngHasta: $('#filtroFechaHasta').val(),
      semaforo: $('#filtroSemaforo').val() || [],
      estado: $('#filtroEstado').val() || [],
      ubicacion: $('#filtroUbicacion').val()
   };
};

function limpiarObjInformacionUnidad() {
   informacionUnidad.seguimientoImportacion = null;
   informacionUnidad.informacionInventario = null;
   informacionUnidad.datosTecnicos = null;
   informacionUnidad.configuracionUnidad = null;
};