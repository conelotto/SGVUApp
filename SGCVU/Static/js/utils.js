(function ($) {
   $.extend({

      customAjax: function (Opciones, mySuccess, myError, myBeforeSend, showErrorSuccess) {

         var defaults = {};

         $.extend(defaults, Opciones);

         $.ajax({
            type: 'POST',
            url: defaults.url,
            data: JSON.stringify(defaults.parametros),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            beforeSend: function (jqXHR) {
               if (myBeforeSend != null) {
                  myBeforeSend(jqXHR);
               } else {
                  preload(true);
               }
            },
            success: function (msg) {
               preload(false);
               if (msg.d.sesionValida) {
                  if (!msg.d.success) {
                     if (showErrorSuccess) {
                        custom_alert_type("error", msg.d.msg, "Error");
                     }
                  }
                  mySuccess(msg.d);
               } else {
                  custom_alert_type("error", "La sesion ha expirado. Presione <b>F5</b> para volver a iniciar sesión.", "Credenciales inválidas");
               }
            },
            error: function (error, textStatus) {
               preload(false);
               if (myError != null) {
                  myError(error, textStatus);
               } else {
                  mostrarAlertaErrorPeticion(error, textStatus);
               }
            }
         });
      },

      customFileDownload: function (url, data) {
         var urlFinal = window.location.hostname == 'localhost' ? '/Descarga/' + url : '/' + window.location.pathname.split('/')[1] + '/Descarga/' + url;
         $.fileDownload(urlFinal, {
            httpMethod: "POST",
            data: { jsonFiltro: JSON.stringify(data) },
            preparingMessageHtml: '<img src="../Images/loading.gif" width="30" height="30" class="icon_alerta"><div class="mensaje_alerta">Descargando el documento, espere un momento...</div>',
            failMessageHtml: '<img src="../Images/error.png" width="30" height="30" class="icon_alerta"><div class="mensaje_alerta">Ocurrió un error al momento de la descarga.</div>',
            dialogOptions: {
               modal: true,
               minHeight: 0,
               resizable: false
            }
         });
      }

   })
})(jQuery);

function custom_alert(output_msg, title_msg, width_modal) {
   if (!title_msg)
      title_msg = 'Alerta';

   if (!output_msg)
      output_msg = '...';

   if (!width_modal)
      width_modal = 300;

   $("<div></div>").html(output_msg).dialog({
      title: title_msg,
      resizable: false,
      modal: true,
      minHeight: 0,
      width: width_modal,
      buttons: {
         "Aceptar": function () {
            $(this).dialog("close");
         }
      }
   });
};

function custom_alert_type(type, output_msg, title_msg, width_modal) {
   var content = '';

   if (!title_msg)
      title_msg = 'Alerta';

   if (!output_msg)
      output_msg = '...';

   if (!width_modal)
      width_modal = 300;

   content = '<img src="../Images/' + type + '.png" width="auto" height="auto" class="icon_alerta"><div class="mensaje_alerta">' + output_msg + '</div>';

   $("<div></div>").html(content).dialog({
      title: title_msg,
      resizable: false,
      modal: true,
      minHeight: 0,
      width: width_modal,
      buttons: {
         "Aceptar": function () {
            $(this).dialog("close");
         }
      }
   });
};

function custom_confirmation(myAceptar, myCancelar, output_msg, width_modal) {
   var title_msg = 'Confirmación';

   if (!output_msg)
      output_msg = '¿Desea continuar con el proceso?';

   if (!width_modal)
      width_modal = 300;

   $("<div></div>").html(output_msg).dialog({
      title: title_msg,
      resizable: false,
      modal: true,
      minHeight: 0,
      width: width_modal,
      buttons: {
         "Aceptar": function () {
            $(this).dialog("close");
            myAceptar();
         },
         "Cancelar": function () {
            $(this).dialog("close");
            myCancelar();
         }
      }
   });
};

function preload(show) {
   try {
      if (show) {
         $.blockUI({
            message: '<img src="../Images/loading.gif" />',
            overlayCSS: {
               backgroundColor: 'rgb(214, 214, 221)'
            },
            css: {
               border: 'none',
               padding: '15px',
               backgroundColor: 'transparent',
               '-webkit-border-radius': '10px',
               '-moz-border-radius': '10px',
               //opacity: .5,
               color: '#000'
            }
         });
      } else {
         $.unblockUI();
      }
   }
   catch (error) {
   }
};

function convertirDateTime(datetime, formato) {
   var paramsValid = (datetime == ' ' || datetime == '' || datetime == null);
   try {
      if (paramsValid) {
         return "";
      }
      else {
         moment.locale('es');
         return moment(datetime).format(formato);
      }
   }
   catch (error) {
      return moment().format();
   }
};

function convertirFormatoYYYYMMDD(strDate, separadorInicial, separadorFinal) {
   if (strDate == '' ) {
      return "";
   } else {
      var arrayDate = strDate.split(separadorInicial);
      return arrayDate[2] + separadorFinal + arrayDate[1] + separadorFinal + arrayDate[0];
   }
};

function diferenciaDiasFechas(fechaFin, FechaInicio, formato) {
   var fechaFinInvalido = (fechaFin == ' ' || fechaFin == '' || fechaFin == null);
   var fechaInicioInvalido = (FechaInicio == ' ' || FechaInicio == '' || FechaInicio == null);
   try {
      if (fechaFinInvalido || fechaInicioInvalido) {
         return "";
      }
      else {
         moment.locale('es');
         var a = moment(moment(fechaFin).format(formato), formato);
         var b = moment(moment(FechaInicio).format(formato), formato);
         var diffDays = a.diff(b, 'days');
         return diffDays;
      }
   }
   catch (error) {
      return "";
   }
};

function getValueEmpty(value) {
   return value == null ? "" : value;
};

function mostrarMensajeProceso(parametros) {
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
   var time = '500', timeHide = '7000', msjHTML;
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

function mostrarAlertaErrorPeticion(error, textStatus) {
   if (error.status === 0) {
      custom_alert_type("error", "Error de conexión, verifique si está conectado a la red.", "Error");
   } else if (error.status == 404) {
      custom_alert_type("error", "404 - Recurso no encontrado.", "Error");
   } else if (error.status == 500) {
      custom_alert_type("error", "500 - Error interno de la aplicación.", "Error");
   } else if (textStatus === 'timeout') {
      custom_alert_type("error", "Tiempo de espera agotado.", "Error");
   } else {
      custom_alert_type("error", "Error no detectado: " + error.responseText, "Error");
   }
};

try {
   $.validator.addMethod(
       "date",
       function (value, element) {
          return value.match(/^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$/);
       },
       "Ingrese una fecha con el formato dd/mm/yyyy."
   );
}
catch (error) {
}

function SoloNumeroYPunto(txt) {
    if (event.keyCode > 47 && event.keyCode < 58 || event.keyCode == 46) {
        var txtbx = document.getElementById(txt);
        var amount = document.getElementById(txt).value;
        var present = 0;
        var count = 0;

        if (amount.indexOf(".", present) || amount.indexOf(".", present + 1));
        {
            // alert('0');
        }

        /*if(amount.length==2)
        {
        if(event.keyCode != 46)
        return false;
        }*/
        do {
            present = amount.indexOf(".", present);
            if (present != -1) {
                count++;
                present++;
            }
        }
        while (present != -1);
        if (present == -1 && amount.length == 0 && event.keyCode == 46) {
            event.keyCode = 0;
            //alert("Wrong position of decimal point not  allowed !!");
            return false;
        }

        if (count >= 1 && event.keyCode == 46) {

            event.keyCode = 0;
            //alert("Only one decimal point is allowed !!");
            return false;
        }
        if (count == 1) {
            var lastdigits = amount.substring(amount.indexOf(".") + 1, amount.length);
            if (lastdigits.length >= 2) {
                //alert("Two decimal places only allowed");
                event.keyCode = 0;
                return false;
            }
        }
        return true;
    }
    else {
        event.keyCode = 0;
        //alert("Only Numbers with dot allowed !!");
        return false;
    }

};

function SoloNumeros(evt) {
    evt = (evt) ? evt : window.event;
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        return false;
    }
    return true;
 };

 function ObtenerRutaEliminarArchivo() {
    var urlFinal = window.location.hostname == 'localhost' ? '/Carga/EliminarArchivo.ashx' : '/' + window.location.pathname.split('/')[1] + '/Carga/EliminarArchivo.ashx';
    return urlFinal;
 };

 function ObtenerRutaCargaFinal(url) {
    var urlFinal = window.location.hostname == 'localhost' ? '/Carga/' + url : '/' + window.location.pathname.split('/')[1] + '/Carga/' + url;
    return urlFinal;
 };