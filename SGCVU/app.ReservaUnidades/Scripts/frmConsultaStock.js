$(document).ready(function () {

   $("#msgBusqueda").hide();
   $("#msgNoResultados").hide();
   $("#resultadoBusqueda").hide();
   $("#modRelacionados").hide();

   $("#frmBusqueda").keypress(function (e) {
      var code = e.keyCode || e.which;
      if (code === 13) {
         e.preventDefault();
         $("#btnBuscar").click();
      };
   });

   $("#txtModelo").focus();

   $("#btnBuscar").click(function () {
      if ($("#frmBusqueda").valid()) {
         var modelo = $("#txtModelo").val(); ;
         $.customAjax({ url: location.pathname + "/ConsultarStock", parametros: { modelo: modelo} },
            function (respuesta) {
               $("#msgBusqueda").hide();
               if (respuesta.success) {
                  respuesta.data.push({});
                  if (respuesta.data.length > 0) {
                     $("#resultadoBusqueda").show();
                     $("#modRelacionados").show();
                     $("#lblModelosRelacionados").text("AAA, BBB, CCC");
                  } else {
                     $("#msgNoResultados").show();
                  }
               } else {
               }
            }, function (error) {
               $("#msgBusqueda").hide();
            }, function () {
               $("#msgNoResultados").hide();
               $("#msgBusqueda").show();
               $("#resultadoBusqueda").hide();
               $("#modRelacionados").hide();
               $("#lblModelosRelacionados").text("");
            }
         );
      }
   });

   $("#frmBusqueda").validate({
      rules: {
         txtModelo: "required"
      },
      messages: {
         txtModelo: "Ingrese el modelo."
      }
   });

});