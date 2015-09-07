$(document).ready(function () {

   var gridView = !(navigator.appName == 'Microsoft Internet Explorer');

   $("#tabsConfiguracion").tabs();

   $("#jqgColumnas").jqGrid({
      datatype: "local",
      data: [],

      height: "auto",
      width: "auto",

      colModel: [
                  { label: '', name: 'ConfiguracionColumnasId', index: 'ConfiguracionColumnasId', key: true, hidden: true },
                  { label: '', name: 'Activo', index: 'Activo', hidden: true },
                  { label: '', name: 'NombreColumna', index: 'NombreColumna', hidden: true },
                  { label: 'Columna', name: 'DescripcionColumna', index: 'DescripcionColumna', sortable: false, width: 400 }
               ],

      caption: "Columnas",
      regional: 'es',
      rowNum: 10,
      viewrecords: true,
      multiselect: true,
      gridview: gridView,
      toolbar: [true, "top"]
   });
   $("#t_jqgColumnas").append("<div style='text-align:right; padding:2px 2px 2px 0px'><input type='button' class='bnt_Save' title='Guardar'/></div>");
   $("#t_jqgColumnas").css("height", "auto");
   $("input", "#t_jqgColumnas").click(function () {
      var selectedIDs = $("#jqgColumnas").getGridParam("selarrrow");
      $.customAjax({ url: location.pathname + "/GuardarColumnasConfiguracionUsuario", parametros: { idsConfiguracionColumnas: selectedIDs } },
         function (respuesta) {
            if (respuesta.success) {
               mostrarMensajeProceso({ tipo: 'success', mensaje: "Su configuración se guardó correctamente." });
            }
         }, null, null, true
      );
   });

   $.customAjax({ url: location.pathname + "/ObtenerColumnasConfiguracion", parametros: {} },
      function (respuesta) {
         if (respuesta.success) {
            $("#jqgColumnas").setGridParam({ rowNum: respuesta.data.length });
            $("#jqgColumnas").jqGrid('setGridParam', { data: respuesta.data }).trigger("reloadGrid");
            $.each(respuesta.data, function (i, item) {
               if (item.Activo == "1")
                  $("#jqgColumnas").jqGrid('setSelection', item.ConfiguracionColumnasId);
            });
         }
      }, null, null, true
   );

});