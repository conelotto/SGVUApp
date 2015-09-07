
        $(function () {
            $(document).tooltip();
        }); 
       
        var mensajesProceso = {
          RegistrarSolicitudOk: 'Solicitud se registró correctamente.',
          AceptarSolicitudOK: 'Solicitud aprobada por CAT.',
          CancelarSolicitudSi: 'Solicitud fue rechazada por CAT, se solicitará apoyo con otro programa.',
          CancelarSolicitudNo: 'Solicitud rechazada por CAT.',
          RegistrarClaimOk: 'Claim se registró correctamente.',
          RegistrarCreditMemoOK: 'Credit Memo se registró correctamente.',
          RegresarActividadOK: 'Solicitud retornó a la actividad anterior.',
          RegistrarComentario: 'Se registro comentario correctamente.'
        }      

        var gridView = !(navigator.appName == 'Microsoft Internet Explorer');

        var dataInfoUnidad = [];
        var dataCuentasFiltro = [];
        var dataModelosFiltro = [];

        var idRow = null;
        var selectRow = null;
        var valCellSolicitud = null;
        var idRowFlujo= null;

        $(document).ready(function () {

        var CurrentDate = new Date();

        GetData_Billing();
        GetData_Workflow();
        GetData_Request();
        GetData_Programs();
        GetData_LineaVenta();
        ClearFileUploadControl();

        $("#DivButtonSolicitud").hide();
        $("#DivButtonClaim").hide();
        $("#btnPreviusActivity").hide(); 
        $("#tdDownloadWashout").hide();
        $("#tdSaveWashout").hide(); 
        $("#DivButtonCreditMemo").hide();
        $("#divDatosWashout").hide(); 
                      
        //Begin Tabs
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~    
        $("#tab_Solicitud").tabs({
            collapsible: true              
        });

        $("#tab_DocumentosAdjuntos").tabs({
            collapsible: true
        });

        $("#tab_Washout").tabs({
            collapsible: true
        });
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ 

        //Begin accordion
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~        
        $("#Accordion_CriteriosBusqueda").accordion({
            collapsible: true,
            heightStyle: 'content'
        });

        $("#Accordion_WorkFlow").accordion({
            collapsible: true,
            active: 'none',
            heightStyle: 'content' 
        });
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ 

        //DatePicker
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~           
        $("#txtFechaSolicitudCat").datepicker({
            numberOfMonths: 1,
            showButtonPanel: true,
            changeMonth: true,
            changeYear: true
        });

        $("#txtFechaSolicitudCat").datepicker("setDate", CurrentDate);

        $("#txtFechaRespuestaCAT").datepicker({
            numberOfMonths: 1,
            showButtonPanel: true,
            changeMonth: true,
            changeYear: true
        });

        $("#txtFechaCreditMemo").datepicker({
            numberOfMonths: 1,
            showButtonPanel: true,
            changeMonth: true,
            changeYear: true
        });

        $("#txtFechaClaim").datepicker({
            numberOfMonths: 1,
            showButtonPanel: true,
            changeMonth: true,
            changeYear: true,
            onClose: function (selectedDate) {
            $("#txtFechaClaim").datepicker("option", "minDate", selectedDate);
            }
        });

        $("#txtFechaSRC").datepicker({
            numberOfMonths: 1,
            showButtonPanel: true,
            changeMonth: true,
            changeYear: true
        });
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ 

        //Grilla - Flujo Principal
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ 
        $("#jqgFlujo").jqGrid({
               
            url: location.pathname + "/GetData_Workflow",
            mtype: "POST",
            datatype: "json",

            ajaxGridOptions: {
                contentType: 'application/json; charset=utf-8'
            },

            postData: {            
                Filter: {
                    strNumeroOrden: '',
                    strNumeroSerie: '',
                    strCliente: '',
                    strModelo: '',
                    strPrograma: '',
                    strEstadoFlujo: 0,
                    strEstadoSolicitud: 0,
                    strEstadoFacturacion: '',
                    strLineaVenta: 0
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
                //Datos
                {label: 'int_ApoyoId', name: 'int_ApoyoId', index: 'int_ApoyoId', width: 100, hidden: true, key: true },
                {label: 'str_CompaniaId', name: 'str_CompaniaId', index: 'str_CompaniaId', width: 100, hidden: true },
                {label: 'Orden N°', name: 'str_OrdenAsignada', index: 'str_OrdenAsignada', width: 75, formatter: formatOrden, unformat: unformatOrden },
                {label: 'str_OrdenAsignadaHide', name: 'str_OrdenAsignadaHide', index: 'str_OrdenAsignadaHide', width: 75,hidden: true },   
                {label: 'str_PedidoId', name: 'str_PedidoId', index: 'str_PedidoId', width: 100, hidden: true },
                {label: 'int_PosicionId', name: 'int_PosicionId', index: 'int_PosicionId', width: 100, hidden: true },
                {label: 'str_ModeloRDA', name: 'str_ModeloRDA', index: 'str_ModeloRDA', width: 100, hidden: true },
                {label: 'str_ModeloProductoId', name: 'str_ModeloProductoId', index: 'str_ModeloProductoId', width: 100, hidden: true },
                {label: 'Modelo', name: 'str_ModeloProductoDesc', index: 'str_ModeloProductoDesc', width: 80, hidden: false },
                {label: 'Serie N°', name: 'str_SerieMaquina', index: 'str_SerieMaquina', width: 80, hidden: false },
                {label: 'Cta. Inventario', name: 'str_CuentaInventarioDBS', index: 'str_CuentaInventarioDBS', width: 80, hidden: false },                   
                {label: 'str_EstadoInventario', name: 'str_EstadoInventario', index: 'str_EstadoInventario', width: 100, hidden: true },
                {label: 'Estructura de Costos', name: 'bl_EstructuraCostos', width: 60, index: 'bl_EstructuraCostos', editable: true, edittype: 'checkbox', editoptions: { value: "True:False" }, formatter: "checkbox", formatoptions: { disabled: true }, align: "center" },
                {label: 'str_ClienteId', name: 'str_ClienteId', index: 'str_ClienteId', width: 100, hidden: true },
                {label: 'Cliente', name: 'str_DESC_CLIENTE', index: 'str_DESC_CLIENTE', width: 130, hidden: false },
                {label: 'str_ApoyoTipoId', name: 'str_ApoyoTipoId', index: 'str_ApoyoTipoId', width: 100, hidden: true },
                {label: 'Programa', name: 'str_ApoyoTipoDesc', index: 'str_ApoyoTipoDesc', width: 80, hidden: false, align: "center" },                        
                {label: 'Apoyo $',  name: 'dec_ImporteApoyoCAT', index: 'dec_ImporteApoyoCAT', width: 85, align: "right", formatter: 'number',
                    formatoptions: { decimalSeparator: ".", thousandsSeparator: ",", decimalPlaces: 2, defaultValue: '0.00' }
                },
                {label: 'Valor Venta $', name: 'dec_ValorVentaMaquinaCRM', index: 'dec_ValorVentaMaquinaCRM', width: 85, align: "right", formatter: 'number',
                    formatoptions: { decimalSeparator: ".", thousandsSeparator: ",", decimalPlaces: 2, defaultValue: '0.00' }
                },
                {label: 'int_FlujoId', name: 'int_FlujoId', index: 'int_FlujoId', width: 100, hidden: true },
                {label: 'Estado de Flujo', name: 'str_FlujoEstado', index: 'str_FlujoEstado', width: 130, hidden: false, formatter: formatEstados },
                //Solicitud
                {label: 'ID Programa', name: 'str_IdProgramaCAT', index: 'str_IdProgramaCAT', width: 90, hidden: true },
                {label: 'Fecha', name: 'det_FechaSolicitudCAT', index: 'det_FechaSolicitudCAT', width: 70, align: "center", formatter: 'date', formatoptions: { srcformat: 'd/m/Y', newformat: 'd/m/Y'} },           
                {label: 'Días', name: 'int_DiasSolicitud', index: 'int_DiasSolicitud', width: 40, sortable: false, formatter: SemaforoDiasSolicitud, unformat: SemaforoVacio },                                    
                {label: 'int_SolicitudId', name: 'int_SolicitudId', index: 'int_SolicitudId', width: 100, hidden: true },
                {label: 'Estado', name: 'str_SolicitudEstado', index: 'str_SolicitudEstado', width: 100, hidden: false, formatter: formatEstados },
                //Claim
                {label: 'Fecha Claim',name: 'det_FechaClaim', index: 'det_FechaClaim', width: 70, align: "center", formatter: 'date', formatoptions: { srcformat: 'd/m/Y', newformat: 'd/m/Y'} },
                {label: 'Fecha SRC', name: 'det_FechaSRC', index: 'det_FechaSRC', width: 70, align: "center", formatter: 'date', formatoptions: { srcformat: 'd/m/Y', newformat: 'd/m/Y'} },                             
                {label: 'Días', name: 'int_DiasClaim', index: 'int_DiasClaim', width: 40, sortable: false, formatter: SemaforoDiasClaim, unformat: SemaforoVacio },
                //Whasout
                {label: 'Fecha', name: 'det_WashOutFecha', index: 'det_WashOutFecha', width: 80, align: "center", formatter: 'date', formatoptions: { srcformat: 'd/m/Y', newformat: 'd/m/Y'} },
                {label: 'Días', name: 'int_DiasWashout', index: 'int_DiasWashout', width: 35,  align: "center" },
                {label: 'Estado', name: 'str_WashoutEstado', index: 'str_WashoutEstado', width: 100, formatter: formatEstados},
                //Otros  
                {label: '&nbsp;', name: 'int_SubGridFlag', index: 'int_SubGridFlag', width: 35, hidden: true, align: "center" }
            ],

            rowNum: 1000,
            rownumbers: true,
            rowList: [20, 50, 80],
            viewrecords: true,
            loadtext: 'Cargando datos...',
            recordtext: "<b>{2} registros encontrados</b>",
            emptyrecords: 'No se encontraron registros',
            pgtext: 'Pág: {0} de {1}',
            caption: "Detalle de Carpeta de Trabajo",
            pager: '#pagerFlujo',
            regional: 'es',
            gridview: gridView,  
            gridComplete: initGrid,
            cmTemplate: { title: false },  
                                  
            //Selecciona Orden Asignada y se carga la informacion complementaria en el resto de grillas (Historial Expediente, Historial Maquina Apoyo, etc)
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            onCellSelect: function (row, col, content, event) {
                var cm = $("#jqgFlujo").jqGrid("getGridParam","colModel");
                if (cm[col].name == 'str_OrdenAsignada') {  
                    $("#jqgHistorialExpediente").jqGrid('setGridParam', { datatype: "json" });
                    $("#jqgHistorialExpediente").jqGrid()[0].p.postData.ApoyoId = row;
                    $("#jqgHistorialExpediente").jqGrid().trigger("reloadGrid");

                    $("#jqgHistorialMaquinaApoyo").jqGrid('setGridParam', { datatype: "json" });
                    $("#jqgHistorialMaquinaApoyo").jqGrid()[0].p.postData.ApoyoId = row;
                    $("#jqgHistorialMaquinaApoyo").jqGrid().trigger("reloadGrid"); 
                        
                    $("#jqgRelacionProgramasByApoyo").jqGrid('setGridParam', { datatype: "json" });
                    $("#jqgRelacionProgramasByApoyo").jqGrid()[0].p.postData.ApoyoId = row;
                    $("#jqgRelacionProgramasByApoyo").jqGrid().trigger("reloadGrid"); 

                    $("#jqgRelacionProgramasClaimByApoyo").jqGrid('setGridParam', { datatype: "json" });
                    $("#jqgRelacionProgramasClaimByApoyo").jqGrid()[0].p.postData.ApoyoId = row;
                    $("#jqgRelacionProgramasClaimByApoyo").jqGrid().trigger("reloadGrid");  
                        
                    $("#jqgRelacionProgramasCreditMemoByApoyo").jqGrid('setGridParam', { datatype: "json" });
                    $("#jqgRelacionProgramasCreditMemoByApoyo").jqGrid()[0].p.postData.ApoyoId = row;
                    $("#jqgRelacionProgramasCreditMemoByApoyo").jqGrid().trigger("reloadGrid");
                        
                    $("#jqgDocumentosAdjuntos").jqGrid('setGridParam', { datatype: "json" });
                    $("#jqgDocumentosAdjuntos").jqGrid()[0].p.postData.ApoyoId = row;
                    $("#jqgDocumentosAdjuntos").jqGrid().trigger("reloadGrid");                         
                }
            },
                
            //Oculta icon de subgrid si Orden Asignada no tiene Programas asociados
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            loadComplete: function () {
                var grid = $("#jqgFlujo");
                var ids = $("#jqgFlujo").jqGrid('getDataIDs');
                $.each(ids, function (i, item) {
                var row = $("#jqgFlujo").getRowData(item);
                if (row.int_SubGridFlag != "1") $("#" + item + " td.sgcollapsed", grid[0]).unbind('click').html('');
                });
            },

            //SubGrid
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            subGrid: true,
            subGridRowExpanded: function (subgrid_id, row_id) {
                var subgrid_table_id = subgrid_id + "_table";

                $("#" + subgrid_id).html("<table id='" + subgrid_table_id + "' class='scroll'></table>");

                $("#" + subgrid_table_id).jqGrid({
                    url: location.pathname + "/GetData_WorkflowChild",
                    mtype: "POST",
                    datatype: "json",

                    ajaxGridOptions: {
                        contentType: 'application/json; charset=utf-8'
                    },
                    postData: {
                        ApoyoId: row_id
                    },
                    serializeGridData: function (postData) {
                        return JSON.stringify(postData);
                    },
                    jsonReader: {
                        root: "d.rows",
                        records: "d.records"
                    },

                    colModel: [
                        { label: 'int_ExpPrograma_Id', name: 'int_ExpPrograma_Id', index: 'int_ExpPrograma_Id', width: 58, hidden: true },
                        { label: 'int_ApoyoId', name: 'int_ApoyoId', index: 'int_ApoyoId', width: 58, hidden: true },
                        { label: 'int_ProgramasId', name: 'int_ProgramasId', index: 'int_ProgramasId', width: 58, hidden: true },
                        { label: 'ID Programa', name: 'str_IdProgramaCAT', index: 'str_IdProgramaCAT', width: 130 },
                        { label: 'Descripcíon de Programa', name: 'str_DescPrograma', index: 'str_DescPrograma', width: 220 },
                        { label: 'Claim N°', name: 'str_ExpPrograma_NumeroClaim', index: 'str_ExpPrograma_NumeroClaim', width: 120 },
                        { label: 'Fecha Claim', name: 'det_ExpPrograma_FechaClaim', index: 'det_ExpPrograma_FechaClaim', width: 120, align: "center", formatter: 'date', formatoptions: { srcformat: 'd/m/Y', newformat: 'd/m/Y'} },
                        { label: 'Credit Memo N°', name: 'str_ExpPrograma_NumeroCreditMemo', index: 'str_ExpPrograma_NumeroCreditMemo', width: 120 },
                        { label: 'Fecha Credit Memo', name: 'det_ExpPrograma_FechaCreditMemo', index: 'det_ExpPrograma_FechaCreditMemo', width: 120, align: "center", formatter: 'date', formatoptions: { srcformat: 'd/m/Y', newformat: 'd/m/Y'} },
                        { label: 'Monto Solicitado $', name: 'dec_ExpPrograma_MontoSolicitado', index: 'dec_ExpPrograma_MontoSolicitado', width: 120, align: "right", formatter: 'currency', summaryType: 'sum', formatoptions: { decimalSeparator: ",", thousandsSeparator: ",", decimalPlaces: 2, prefix: "$ "} },
                        { label: 'Monto Reclamado $', name: 'dec_ExpPrograma_MontoPagado', index: 'dec_ExpPrograma_MontoPagado', width: 120, align: "right", formatter: 'currency', summaryType: 'sum', formatoptions: { decimalSeparator: ",", thousandsSeparator: ",", decimalPlaces: 2, prefix: "$ "} },
                        { label: 'Estado', name: 'bl_ExpPrograma_Estado', index: 'bl_ExpPrograma_Estado', width: 50, editable: true, edittype: 'checkbox', editoptions: { value: "True:False" }, formatter: "checkbox", formatoptions: { disabled: true }, align: "center", hidden: true  },
                        { label: 'str_OrdenAsignada', name: 'str_OrdenAsignada', index: 'str_OrdenAsignada', width: 58, hidden: true }
                    ],

                    height: "auto",
                    width: "auto",
                    regional: 'es',
                    gridview: gridView,
                    cmTemplate: { title: false },
                    loadonce: true,
                    grouping: true,
                    groupingView: {
                        groupField: ['str_OrdenAsignada'],
                        groupSummary: [true],
                        groupColumnShow: [false],
                        groupSummaryPos: ['footer'],
                        groupText: ['<span style="color:#0033FF;font-family:Verdana;font-size:11px">Orden N° {0}</span>']
                    }
                });
            },
            onSelectRow: function (rowid) {
                 idRowFlujo = $(this).jqGrid("getGridParam", "selrow");
            },
            subGridOptions: {
                reloadOnExpand: false,
                selectOnExpand: false
            }

        });
                
        //Cargar datos de flujo en controles
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~             
        jQuery("#jqgFlujo").click(function(){
                 
            var vPrimaryKey = jQuery('#jqgFlujo').jqGrid('getGridParam','selrow') 
            $.customAjax({ url: location.pathname + "/GetData_Workflow_ByKey", parametros: {ApoyoId:vPrimaryKey} },  
                                          
            function (respuesta) {
                    preload(false);
                    if (respuesta.success) {
                        var lista = respuesta.data;                        

                           for (var i = 0; i < lista.length; i++) { 

                            $('#lblOrdenNumero').text("Orden N°: " + lista[i].str_OrdenAsignada + " | Cliente: " + lista[i].str_DESC_CLIENTE + " | Modelo: " + lista[i].str_ModeloProductoDesc + " | Serie: " + lista[i].str_SerieMaquina );
                            $('#txtEstadoSolicitud').text(lista[i].str_SolicitudEstado);
                            $('#txtObservaciones').val(lista[i].str_Observacion);
                            $('#txtFechaSRC').text(convertirDateTime(lista[i].det_FechaSRC,"DD/MM/YYYY"));

                            if(lista[i].det_FechaClaim == null){
                               $("#txtFechaClaim").datepicker("setDate", CurrentDate);                            
                            } else{
                               $('#txtFechaClaim').val(convertirDateTime(lista[i].det_FechaClaim,"DD/MM/YYYY"));
                            } 

                            $('#hidePrimaryKey').val(lista[i].int_ApoyoId);                                          
                            $('#lblFechaSolicitudHide').val(convertirDateTime(lista[i].det_FechaSolicitudCAT,"DD/MM/YYYY"));
                            $('#lblFechaRespuestaCATHide').val(convertirDateTime(lista[i].det_FechaRespuestaCAT,"DD/MM/YYYY"));
                            $('#lblFechaSRCHide').val(convertirDateTime(lista[i].det_FechaSRC,"DD/MM/YYYY"));
                            $('#lblMaquinaApoyoIdHide').val(lista[i].int_MaquinaApoyoId); 
                            $('#lblEstadoFlujoHide').val(lista[i].str_FlujoEstado);
                            $('#lblEstadoSolicitudHide').val(lista[i].str_SolicitudEstado);
                            $('#lblHaveWashout').val(lista[i].bl_HaveWashout); 
                            $('#lblSolicitudNro').text("");
                            $('#lblSolicitudNro').text(" " + lista[i].str_OrdenAsignada);  //Nro de Orden de Washout
                            $('#lblSolicitudDocAdjList').text("");
                            $('#lblSolicitudDocAdjList').text(" " + lista[i].str_OrdenAsignada);  //Nro de Orden para descargar adjuntos
                            $('#lblArchivoAdjunto').text("");  
                            $('#txtApoyoComentario').val(lista[i].str_Comentarios);

                            var vOrdenAsignada = lista[i].str_OrdenAsignada;
                            var vApoyoId = lista[i].int_ApoyoId;

                            //Carga y pasa valores a iFrame "frmApoyoFabricante_UploadFiles.aspx"
                            $('#frmUploadFiles').attr('src','frmApoyoFabricante_UploadFiles.aspx?vApoyoId='+ vApoyoId + '&vOrdenAsignada=' + vOrdenAsignada);
                               
                            if(lista[i].int_WashoutId == 25 || lista[i].int_WashoutId == 0) //PENDIENTE
                            {
                                $('#lblArchivoAdjunto').text("No tiene archivo adjunto."); 
                                document.getElementById("MainContent_rbtnDefinitivo").checked = false;
                                document.getElementById("MainContent_rbtnProvisional").checked = false;
                            }
                            else if(lista[i].int_WashoutId == 26) //PROVISIONAL
                            {
                                 $('#lblArchivoAdjunto').text(lista[i].str_WashoutArchivo);
                                 document.getElementById("MainContent_rbtnDefinitivo").checked = false;
                                 document.getElementById("MainContent_rbtnProvisional").checked = true; 
                            }
                            else if(lista[i].int_WashoutId == 27) //DEFINITIVO
                            {
                              $('#lblArchivoAdjunto').text(lista[i].str_WashoutArchivo);
                              document.getElementById("MainContent_rbtnDefinitivo").checked = true;
                              document.getElementById("MainContent_rbtnProvisional").checked = false;
                            }                               
                                                                                   
                            $("#DivButtonSolicitud").hide(); //Acordion - Registro de Solicitud                              
                            $("#DivButtonClaim").hide();  //Acordion - Claim
                            $("#btnPreviusActivity").hide();  //Regresar Actividad                                                                                               
                            $("#tdDownloadWashout").hide(); //Descargar Washout
                            $("#tdSaveWashout").hide(); //Boton Mantenimiento Washout                            
                            $("#DivButtonCreditMemo").hide(); //Boton Mantenimiento Credit Memo 

                        //Valida si Maquina tiene Washout para mostrar acordion, caso contrario lo oculta.
                        if( $('#lblHaveWashout').val() == "true"){
                             $("#divDatosWashout").show();
                        }else if($('#lblHaveWashout').val() == "false"){
                             $("#divDatosWashout").hide();                            
                        } 
                 
                        if ( $('#lblFechaSolicitudHide').val() == ""  && $('#lblFechaRespuestaCATHide').val() == ""){                           
                            $("#DivButtonSolicitud").show();                           
                            $("#btnRelacionProgramas").prop( "disabled", false );
                            $("#btnSaveSolicitud").show();
                            $("#btnValidatedSolicitud").hide();
                            $("#btnCancelSolicitud").hide();
                            $("#btnPreviusActivity").hide();  
                            $("#txtObservaciones").prop('disabled', false); 
                            $("#txtFechaClaim").prop('disabled', true);                                                                      
                        }
                        else if( $('#lblFechaSolicitudHide').val() != "" && $('#lblFechaRespuestaCATHide').val() == ""){
                            $("#DivButtonSolicitud").show();
                            $("#btnValidatedSolicitud").show();
                            $("#btnCancelSolicitud").show();
                            $("#btnSaveSolicitud").hide();
                            $("#btnRelacionProgramas").prop( "disabled", true );                                                                                   
                            $("#btnPreviusActivity").show(); 
                            $("#txtObservaciones").prop('disabled', false); 
                            $("#txtFechaClaim").prop('disabled', true);                         
                        }                      
                        else if( $('#lblFechaSolicitudHide').val() != "" && $('#lblFechaRespuestaCATHide').val() != ""){
                            if($('#lblEstadoSolicitudHide').val() == "ACEPTADO POR CAT"){
                                    if( $('#lblFechaSRCHide').val() == "" &&  $('#lblEstadoFlujoHide').val() == "PENDIENTE REQUISITOS"){                                  
                                        $("#btnPreviusActivity").show();
                                        $("#txtObservaciones").prop('disabled', true); 
                                        $("#txtFechaClaim").prop('disabled', true);                                                    
                                    }
                                    else if( $('#lblFechaSRCHide').val() != "" &&  $('#lblEstadoFlujoHide').val() == "PENDIENTE INGRESO CLAIM"){                                   
                                        $("#DivButtonClaim").show(); 
                                        $("#btnSaveClaim").show();  
                                        $("#btnPreviusActivity").show();
                                        $("#txtObservaciones").prop('disabled', true); 
                                        $("#txtFechaClaim").prop('disabled', false);   
                                    }  
                                    else if( $('#lblFechaSRCHide').val() != "" &&  $('#lblEstadoFlujoHide').val() == "INGRESAR WASH OUT"){    
                                        if(lista[i].int_WashoutId == 25){
                                            $("#tdDownloadWashout").hide(); 
                                            $("#tdSaveWashout").show();   
                                        }
                                        else if (lista[i].int_WashoutId == 26){
                                            $("#tdDownloadWashout").show(); 
                                            $("#tdSaveWashout").show();  
                                        }
                                        else if (lista[i].int_WashoutId == 27){
                                            $("#tdDownloadWashout").show(); 
                                            $("#tdSaveWashout").hide();
                                        }                                        
                                        $("#btnPreviusActivity").show();
                                        $("#txtObservaciones").prop('disabled', true); 
                                        $("#txtFechaClaim").prop('disabled', true);                                       
                                    } 
                                    else if( $('#lblFechaSRCHide').val() != "" &&  $('#lblEstadoFlujoHide').val() == "PENDIENTE PAGO DE CAT"){                                    
                                        $("#tdDownloadWashout").show();
                                        $("#btnPreviusActivity").show();    
                                        $("#DivButtonCreditMemo").show(); 
                                        $("#btnSaveCreditMemo").show(); 
                                        $("#txtObservaciones").prop('disabled', true); 
                                        $("#txtFechaClaim").prop('disabled', true);                                        
                                    } 
                                    else if( $('#lblFechaSRCHide').val() != "" &&  $('#lblEstadoFlujoHide').val() == "FINALIZADO"){
                                        $("#DivButtonSolicitud").hide(); //Acordion - Registro de Solicitud                              
                                        $("#DivButtonClaim").hide();  //Acordion - Claim
                                        $("#btnPreviusActivity").hide();  //Regresar Actividad                                                                                               
                                        $("#tdDownloadWashout").show(); //Descargar Washout
                                        $("#tdSaveWashout").hide(); //Boton Mantenimiento Washout                            
                                        $("#DivButtonCreditMemo").hide(); //Boton Mantenimiento Credit Memo
                                        $("#txtObservaciones").prop('disabled', true); 
                                        $("#txtFechaClaim").prop('disabled', true);                                      
                                    }                               
                            }
                            else if($('#lblEstadoSolicitudHide').val() == "ENVIADO"){
                                $("#DivButtonSolicitud").show();
                                $("#btnValidatedSolicitud").show();
                                $("#btnCancelSolicitud").show();
                                $("#btnSaveSolicitud").hide();
                                $("#btnRelacionProgramas").prop( "disabled", true );                                                                                   
                                $("#btnPreviusActivity").show(); 
                                $("#txtObservaciones").prop('disabled', false); 
                                $("#txtFechaClaim").prop('disabled', true);    
                            }
                            else if($('#lblEstadoSolicitudHide').val() == "RECHAZO POR CAT"){
                                if($('#lblEstadoFlujoHide').val() == "PENDIENTE REGISTRO DE LINEA"){
                                    $("#DivButtonSolicitud").show();
                                    $("#btnSaveSolicitud").show();
                                    $("#btnValidatedSolicitud").hide();
                                    $("#btnCancelSolicitud").hide();                                     
                                    $("#btnRelacionProgramas").prop( "disabled", false );
                                    $("#DivButtonClaim").hide();                                    
                                    $("#btnSaveClaim").hide();                     
                                    $("#tdDownloadWashout").hide();                                    
                                    $("#tdSaveWashout").hide();         
                                    $("#btnPreviusActivity").hide();
                                    $("#DivButtonCreditMemo").hide();  
                                }
                                else if($('#lblEstadoFlujoHide').val() == "FINALIZADO"){
                                        $("#DivButtonSolicitud").hide(); //Acordion - Registro de Solicitud                              
                                        $("#DivButtonClaim").hide();  //Acordion - Claim
                                        $("#btnPreviusActivity").hide();  //Regresar Actividad                                                                                               
                                        $("#tdDownloadWashout").show(); //Descargar Washout
                                        $("#tdSaveWashout").hide(); //Boton Mantenimiento Washout                            
                                        $("#DivButtonCreditMemo").hide(); //Boton Mantenimiento Credit Memo
                                }
                            }
                        }
                                           
                        }
                    } else {
                    custom_alert(respuesta.msg);
                    } 
                }, 
                function (error) {
                    preload(false);
                }, 
                function () {
                    preload(true);
                }
            );
        });           

        //Creación de Cabeceras: Merge entre columnas
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~             
        jQuery("#jqgFlujo").jqGrid('setGroupHeaders', {
            useColSpanStyle: false,
            groupHeaders: [
	        { startColumnName: 'str_OrdenAsignada', numberOfColumns: 17, titleText: ' ' },
	        { startColumnName: 'str_IdProgramaCAT', numberOfColumns: 5, titleText: 'Solicitud' },
    	    { startColumnName: 'det_FechaClaim', numberOfColumns: 3, titleText: 'Claim' },
            { startColumnName: 'det_WashOutFecha', numberOfColumns: 3, titleText: 'Washout' }
            ]
        });          

        //Grilla - Historial de Expediente
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~             
        $("#jqgHistorialExpediente").jqGrid({
            url: location.pathname + "/GetData_HistorialExpediente",
            mtype: "POST",
            datatype: "local",

            ajaxGridOptions: {
                contentType: 'application/json; charset=utf-8'
            },
            postData: {
                ApoyoId: ''
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
                        {label: 'int_RolFlujoId', name: 'int_RolFlujoId', index: 'int_RolFlujoId', width: 100, hidden: true },
                        {label: 'Tipo de Flujo', name: 'str_RolFlujo', index: 'str_RolFlujo', width: 130, align: "left", },
                        {label: 'int_ExpedienteHistorialId', name: 'int_ExpedienteHistorialId', index: 'int_ExpedienteHistorialId', width: 100, hidden: true },
                        {label: 'int_ExpedienteId', name: 'int_ExpedienteId', index: 'int_ExpedienteId', width: 100, hidden: true },
                        {label: 'int_ApoyoId', name: 'int_ApoyoId', index: 'int_ApoyoId', width: 100, hidden: true, key: true },
                        {label: 'int_ActividadId', name: 'int_ActividadId', index: 'int_ActividadId', width: 100, hidden: true },
                        {label: 'Actividad', name: 'str_Actividad', index: 'str_Actividad', width: 220, hidden: false, align: "left", },
                        {label: 'Fecha de Creación', name: 'det_FechaCreacion', index: 'det_FechaCreacion', width: 130,  align: "center", formatter: 'date', formatoptions: { srcformat: 'd/m/Y', newformat: 'd/m/Y'} },
                        {label: 'int_UsuarioId', name: 'int_UsuarioId', index: 'int_UsuarioId', width: 100, hidden: true },
                        {label: 'Usuario', name: 'str_Usuario', index: 'str_Usuario', width: 150, align: "left", }
                        ],
            rowNum: 5,
            rownumbers: true,
            pager: '#pagerHistorialExpediente',
            regional: 'es',
            viewrecords: true,
            gridview: gridView
        });
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~             

        //Grilla - Historial de Maquina de Apoyo
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~             
        $("#jqgHistorialMaquinaApoyo").jqGrid({
        url: location.pathname + "/GetData_HistorialApoyoMaquina",
        mtype: "POST",
        datatype: "local",

        ajaxGridOptions: {
            contentType: 'application/json; charset=utf-8'
        },
        postData: {
            ApoyoId: ''
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
                    { label: 'int_ApoyoId', name: 'int_ApoyoId', index: 'int_ApoyoId', width: 100, hidden: true, key: true},
                    { label: 'str_CompaniaId', name: 'str_CompaniaId', index: 'str_CompaniaId', width: 100, hidden: true},
                    { label: 'int_MaquinaApoyoId', name: 'int_MaquinaApoyoId', index: 'int_MaquinaApoyoId', width: 100, hidden: true},
                    { label: 'str_PedidoId', name: 'str_PedidoId', index: 'str_PedidoId', width: 100, hidden: true},
                    { label: 'int_PosicionId', name: 'int_PosicionId', index: 'int_PosicionId', width: 100, hidden: true},
                    { label: 'Orden N°', name: 'str_OrdenAsignada', index: 'str_OrdenAsignada', width: 120, hidden: false},
                    { label: 'Cant. Programas', name: 'str_IdProgramaCAT', index: 'str_IdProgramaCAT', width: 120, hidden: false, align: "right"}, 
                    { label: 'Monto Solicitado $', name: 'dec_ImporteApoyoCAT', index: 'dec_ImporteApoyoCAT', width: 130, align: "right", formatter: 'number',
                        formatoptions: { decimalSeparator: ".", thousandsSeparator: ",", decimalPlaces: 2, defaultValue: '0.00' }
                    },
                    { label: 'F. Solicitud a CAT', name: 'det_FechaSolicitudCAT', index: 'det_FechaSolicitudCAT', width: 135, hidden: false, align: "center", formatter: 'date', formatoptions: { srcformat: 'd/m/Y', newformat: 'd/m/Y'}},
                    { label: 'F. Respuesta de CAT', name: 'det_FechaRespuestaCAT', index: 'det_FechaRespuestaCAT', width: 135, hidden: false, align: "center", formatter: 'date', formatoptions: { srcformat: 'd/m/Y', newformat: 'd/m/Y'}},
                    { label: 'int_EstadoSolicitudId', name: 'int_EstadoSolicitudId', index: 'int_EstadoSolicitudId', width: 100, hidden: true},
                    { label: 'Estado Solicitud', name: 'str_EstadoSolicitud', index: 'str_EstadoSolicitud', width: 150, hidden: false},
                    { label: 'Observaciones', name: 'str_Observacion', index: 'str_Observacion', width: 200, hidden: false},
                    { label: 'Activo', name: 'bl_SolicitudEstado', index: 'bl_SolicitudEstado', width: 70, hidden: true , editable: true, edittype: 'checkbox', editoptions: { value: "True:False" }, formatter: "checkbox", formatoptions: { disabled: true }, align: "center"},
                    { label: 'F. Creación', name: 'det_FechaCreacion', index: 'det_FechaCreacion', width: 100, hidden: false, align: "center", formatter: 'date', formatoptions: { srcformat: 'd/m/Y', newformat: 'd/m/Y'} },
                    { label: 'Usuario', name: 'str_UsuarioCreacion', index: 'str_UsuarioCreacion', width: 100, hidden: false},
                    { label: 'Usuario', name: 'str_UsuarioModificacion', index: 'str_UsuarioModificacion', width: 100, hidden: true},
                    { label: 'F. Modificación', name: 'det_FechaModificacion', index: 'det_FechaModificacion', width: 100, hidden: true, align: "center", formatter: 'date', formatoptions: { srcformat: 'd/m/Y', newformat: 'd/m/Y'}}
                    ],

        regional: 'es',
        viewrecords: true,
        cmTemplate: { title: false },  
        gridview: gridView
    });

        //Grilla - Documentos Adjuntos
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~             
        $("#jqgDocumentosAdjuntos").jqGrid({
        url: location.pathname + "/GetData_DocumentosAdjuntos",
        mtype: "POST",
        datatype: "local",

        ajaxGridOptions: {
            contentType: 'application/json; charset=utf-8'
        },
        postData: {
            ApoyoId: ''
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
            {label: ' ',  name: 'accion', index: 'accion', width: 30, align: "center" },
            {label: 'int_ExpedienteId',  name: 'int_ExpedienteId', index: 'int_ExpedienteId', width: 58, hidden: true, key: true },
            {label: 'int_ApoyoId',  name: 'int_ApoyoId', index: 'int_ApoyoId', width: 58, hidden: true },
            {label: 'Nombre de Archivo',  name: 'str_ArchivoNombre', index: 'str_ArchivoNombre', width: 270},
            {label: 'Usuario',  name: 'str_UsuarioCreacion', index: 'str_UsuarioCreacion', width: 180 },
            {label: 'Fecha de Registro',  name: 'det_FechaCreacion', index: 'det_FechaCreacion', width: 150, align: "center", formatter: 'date', formatoptions: { srcformat: 'd/m/Y', newformat: 'd/m/Y'}  }
        ],

        rowNum: 5,
        pager: '#pageDocumentosAdjuntos', 
        regional: 'es',
        viewrecords: true,
        cmTemplate: { title: false }, 
        'cellEdit': true,
        'cellsubmit': 'clientArray',
        editurl: 'clientArray', 
        gridview: gridView,

        gridComplete: function () {
            var ids = $("#jqgDocumentosAdjuntos").jqGrid('getDataIDs');
                for (var i = 0; i < ids.length; i++) {
                    del = "<img src='../Images/btnDownloadFile.png' style='cursor:pointer;' title='Descargar Archivo' onclick=\"DownloadAttachedFile('" + ids[i] + "');\" />";
                    $("#jqgDocumentosAdjuntos").jqGrid('setRowData', ids[i], { accion: del });
                }
        }

        });
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~             

        //Grilla - Programas por Solicitud
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~             
        $("#jqgRelacionProgramasByApoyo").jqGrid({
        url: location.pathname + "/GetData_Programas_Solicitud",
        mtype: "POST",
        datatype: "local",

        ajaxGridOptions: {
            contentType: 'application/json; charset=utf-8'
        },
        postData: {
            ApoyoId: ''
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
            {label: ' ',  name: 'accion', index: 'accion', width: 30, align: "center" },
            {label: 'int_ExpPrograma_Id',  name: 'int_ExpPrograma_Id', index: 'int_ExpPrograma_Id', width: 58, hidden: true },
            {label: 'int_ApoyoId',  name: 'int_ApoyoId', index: 'int_ApoyoId', width: 58, hidden: true },
            {label: 'int_ProgramasId',  name: 'int_ProgramasId', index: 'int_ProgramasId', width: 58, hidden: true },
            {label: 'ID Programa',  name: 'str_IdProgramaCAT', index: 'str_IdProgramaCAT', width: 120, key: true },
            {label: 'Descripción de Programa',  name: 'str_DescPrograma', index: 'str_DescPrograma', width: 240 },
            {label: 'str_ExpPrograma_NumeroClaim',  name: 'str_ExpPrograma_NumeroClaim', index: 'str_ExpPrograma_NumeroClaim', width: 90, hidden: true  },
            {label: 'det_ExpPrograma_FechaClaim',  name: 'det_ExpPrograma_FechaClaim', index: 'det_ExpPrograma_FechaClaim', width: 120, align: "center", formatter: 'date', formatoptions: { srcformat: 'd/m/Y', newformat: 'd/m/Y'}, hidden: true  },
            {label: 'str_ExpPrograma_NumeroCreditMemo',  name: 'str_ExpPrograma_NumeroCreditMemo', index: 'str_ExpPrograma_NumeroCreditMemo', width: 90, hidden: true  },
            {label: 'det_ExpPrograma_FechaCreditMemo',  name: 'det_ExpPrograma_FechaCreditMemo', index: 'det_ExpPrograma_FechaCreditMemo', width: 120, align: "center", formatter: 'date', formatoptions: { srcformat: 'd/m/Y', newformat: 'd/m/Y'}, hidden: true  },      
            {label: 'Monto Solicitado $',  name: 'dec_ExpPrograma_MontoSolicitado', index: 'dec_ExpPrograma_MontoSolicitado', width: 120, align: "right", formatter: 'number', editable: true,  editrules:{required:true, number:true},
             formatoptions: { decimalSeparator: ".", thousandsSeparator: ",", decimalPlaces: 2, defaultValue: '0.00' }
            },            
            {label: 'dec_ExpPrograma_MontoPagado',  name: 'dec_ExpPrograma_MontoPagado', index: 'dec_ExpPrograma_MontoPagado', width: 120, align: "right", formatter: 'number', hidden: true,
             formatoptions: { decimalSeparator: ".", thousandsSeparator: ",", decimalPlaces: 2, defaultValue: '0.00' }
            },
            {label: 'bl_ExpPrograma_Estado',  name: 'bl_ExpPrograma_Estado', index: 'bl_ExpPrograma_Estado', width: 50, editable: true, edittype: 'checkbox', editoptions: { value: "True:False" }, formatter: "checkbox", formatoptions: { disabled: true }, align: "center", hidden: true },
            {label: 'bl_Estado_Solicitud',  name: 'bl_Estado_Solicitud', index: 'bl_Estado_Solicitud', width: 58, hidden: true },
            {label: 'str_OrdenAsignada',  name: 'str_OrdenAsignada', index: 'str_OrdenAsignada', width: 58, hidden: true }
        ],

        regional: 'es',
        viewrecords: true,
        pager: '#pageRelacionProgramasByApoyo',
        'cellEdit': true,
        'cellsubmit': 'clientArray',
        editurl: 'clientArray',
        cmTemplate: { title: false },  
        gridview: gridView,

        gridComplete: function () {

            var ids = $("#jqgRelacionProgramasByApoyo").jqGrid('getDataIDs');
            $.each(ids, function (i, item) {
                var row = $("#jqgRelacionProgramasByApoyo").getRowData(item); 
                if (row.bl_Estado_Solicitud == "false" || row.bl_Estado_Solicitud == ""){
                    del = "<img src='../Images/delete.png' style='cursor:pointer;' title='Eliminar Programa' onclick=\"DeleteProgramasLista('" + ids[i] + "');\" />";
                    $("#jqgRelacionProgramasByApoyo").jqGrid('setRowData', ids[i], { accion: del });
                }
            });
        }

        }); 
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~             

        //Grilla - Claim
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~             
        $("#jqgRelacionProgramasClaimByApoyo").jqGrid({
        url: location.pathname + "/GetData_Programas_Solicitud",
        mtype: "POST",
        datatype: "local",

        ajaxGridOptions: {
            contentType: 'application/json; charset=utf-8'
        },
        postData: {
            ApoyoId: ''
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
                { label: 'int_ExpPrograma_Id', name: 'int_ExpPrograma_Id', index: 'int_ExpPrograma_Id', width: 58, hidden: true },
                { label: 'int_ApoyoId', name: 'int_ApoyoId', index: 'int_ApoyoId', width: 58, hidden: true },
                { label: 'int_ProgramasId', name: 'int_ProgramasId', index: 'int_ProgramasId', width: 58, hidden: true },
                { label: 'ID Programa', name: 'str_IdProgramaCAT', index: 'str_IdProgramaCAT', width: 120 },
                { label: 'Descripción de Programa', name: 'str_DescPrograma', index: 'str_DescPrograma', width: 220 },
                { label: 'Claim N°', name: 'str_ExpPrograma_NumeroClaim', index: 'str_ExpPrograma_NumeroClaim', width: 130, editable: true, editrules:{required:true, number:true} },
                { label: 'Fecha Claim', name: 'det_ExpPrograma_FechaClaim', index: 'det_ExpPrograma_FechaClaim', width: 120, align: "center", formatter: 'date', formatoptions: { srcformat: 'd/m/Y', newformat: 'd/m/Y'}, hidden: true  },
                { label: 'str_ExpPrograma_NumeroCreditMemo', name: 'str_ExpPrograma_NumeroCreditMemo', index: 'str_ExpPrograma_NumeroCreditMemo', width: 90, hidden: true  },
                { label: 'det_ExpPrograma_FechaCreditMemo', name: 'det_ExpPrograma_FechaCreditMemo', index: 'det_ExpPrograma_FechaCreditMemo', width: 120, align: "center", formatter: 'date', formatoptions: { srcformat: 'd/m/Y', newformat: 'd/m/Y'}, hidden: true  },
                { label: 'Monto Solicitado $', name: 'dec_ExpPrograma_MontoSolicitado', index: 'dec_ExpPrograma_MontoSolicitado', width: 130, align: "right", formatter: 'number',
                 formatoptions: { decimalSeparator: ".", thousandsSeparator: ",", decimalPlaces: 2, defaultValue: '0.00' }
                }, 
                { label: 'dec_ExpPrograma_MontoPagado', name: 'dec_ExpPrograma_MontoPagado', index: 'dec_ExpPrograma_MontoPagado', width: 130, align: "right", formatter: 'number', hidden: true ,
                 formatoptions: { decimalSeparator: ".", thousandsSeparator: ",", decimalPlaces: 2, defaultValue: '0.00'  }
                },          
                { label: 'bl_ExpPrograma_Estado', name: 'bl_ExpPrograma_Estado', index: 'bl_ExpPrograma_Estado', width: 50, editable: false, edittype: 'checkbox', editoptions: { value: "True:False" }, formatter: "checkbox", formatoptions: { disabled: true }, align: "center", hidden: true },
                { label: 'str_OrdenAsignada', name: 'str_OrdenAsignada', index: 'str_OrdenAsignada', width: 58, hidden: true }
            ],

            rowNum: 10,
            rownumbers: true,
            regional: 'es',
            viewrecords: true,
            pager: '#pageRelacionProgramasClaimByApoyo',
            'cellEdit': true,
            'cellsubmit': 'clientArray',
            editurl: 'clientArray',
            cmTemplate: { title: false },  
            gridview: gridView
        });
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~             
                                          
        //Grilla - Credit Memo
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~             
        $("#jqgRelacionProgramasCreditMemoByApoyo").jqGrid({
        url: location.pathname + "/GetData_Programas_Solicitud",
        mtype: "POST",
        datatype: "local",

        ajaxGridOptions: {
            contentType: 'application/json; charset=utf-8'
        },
        postData: {
            ApoyoId: ''
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
            {  label: 'int_ExpPrograma_Id', name: 'int_ExpPrograma_Id', index: 'int_ExpPrograma_Id', width: 58, hidden: true, key: true },
            {  label: 'int_ApoyoId', name: 'int_ApoyoId', index: 'int_ApoyoId', width: 58, hidden: true },
            {  label: 'int_ProgramasId', name: 'int_ProgramasId', index: 'int_ProgramasId', width: 58, hidden: true },
            {  label: 'ID Programa', name: 'str_IdProgramaCAT', index: 'str_IdProgramaCAT', width: 120 },
            {  label: 'Descripcíon de Programa', name: 'str_DescPrograma', index: 'str_DescPrograma', width: 220 },
            {  label: 'Claim N°', name: 'str_ExpPrograma_NumeroClaim', index: 'str_ExpPrograma_NumeroClaim', width: 120, hidden: true  },
            {  label: 'Fecha Claim', name: 'det_ExpPrograma_FechaClaim', index: 'det_ExpPrograma_FechaClaim', width: 120, align: "center", formatter: 'date', formatoptions: { srcformat: 'd/m/Y', newformat: 'd/m/Y'}, hidden: true  },
            {  label: 'Credit Memo N°', name: 'str_ExpPrograma_NumeroCreditMemo', index: 'str_ExpPrograma_NumeroCreditMemo', width: 130, editable: true, editrules:{required:true, number:true}, },
            {  label: 'Fecha Credit Memo', name: 'det_ExpPrograma_FechaCreditMemo', index: 'det_ExpPrograma_FechaCreditMemo', width: 140, align: "center", formatter: 'date', formatoptions: { srcformat: 'd/m/Y', newformat: 'd/m/Y'}, editable: true, editrules:{required:true}, 
                edittype: 'text', editoptions: { dataInit: function(el) { setTimeout(function() { $(el).datepicker(); }, 0); } }
            },
            {  label: 'Monto Solicitado $', name: 'dec_ExpPrograma_MontoSolicitado', index: 'dec_ExpPrograma_MontoSolicitado', width: 120, align: "right", formatter: 'number',
             formatoptions: { decimalSeparator: ".", thousandsSeparator: ",", decimalPlaces: 2, defaultValue: '0.00' }
            }, 
            {  label: 'Monto Reclamado $', name: 'dec_ExpPrograma_MontoPagado', index: 'dec_ExpPrograma_MontoPagado', width: 120, align: "right", formatter: 'number', editable: true , editrules:{required:true, number:true},
             formatoptions: { decimalSeparator: ".", thousandsSeparator: ",", decimalPlaces: 2, defaultValue: '0.00' }
            },
            {  label: 'Estado', name: 'bl_ExpPrograma_Estado', index: 'bl_ExpPrograma_Estado', width: 58, hidden: true }, 
            {  label: 'str_OrdenAsignada', name: 'str_OrdenAsignada', index: 'str_OrdenAsignada', width: 58, hidden: true }
        ],

        regional: 'es',
        viewrecords: true,
        cmTemplate: { title: false }, 
        pager: '#pagerRelacionProgramasCreditMemoByApoyo',
        'cellEdit': true,
        'cellsubmit': 'clientArray',
        editurl: 'clientArray', 
        gridview: gridView
        });
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~             
                     
        //Proceso - Registro de Solicitud 
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~             
        $("#btnSaveSolicitud").click(function ()  {
            var _ListTempSolicitud = []; 
            var _vEmptyPrograms = "";
            var getDataSolicitud = $("#jqgRelacionProgramasByApoyo").jqGrid('getRowData');

            for (i = 0; i < getDataSolicitud.length; i++) {
                _SolicitudApoyoId = $("#hidePrimaryKey").val();                
                _SolicitudProgramasId = getDataSolicitud[i].int_ProgramasId; 
                _SolicitudMontoSolicitado = getDataSolicitud[i].dec_ExpPrograma_MontoSolicitado;
                _ProgramaDescripcion = getDataSolicitud[i].str_DescPrograma;
                _ProgramaCATId = getDataSolicitud[i].str_IdProgramaCAT;

                if (_SolicitudMontoSolicitado <= 0) {
                    _vEmptyPrograms += "&nbsp; &#8226 &nbsp;" + _ProgramaCATId + "&nbsp; &#47; &nbsp;" + _ProgramaDescripcion + "<br>";
                }
                else {
                     _ListTempSolicitud.push([_SolicitudApoyoId, _SolicitudProgramasId, _SolicitudMontoSolicitado]);
                }
            };

            if (_vEmptyPrograms == ""){
                var parametros = {
                   ApoyoId: $("#hidePrimaryKey").val(),
                   Observaciones: $("#txtObservaciones").val(),
                   ListTempSolicitud: _ListTempSolicitud
                }; 
                $.customAjax({ url: location.pathname + "/SolicitudRegistrar", parametros: parametros },
                function (respuesta) {
                    if (respuesta.success) {
                        mostrarMensajeProceso({ tipo: 'success', mensaje: mensajesProceso.RegistrarSolicitudOk });
                        location.reload();                                                                    
                    }
                }, null, null, true
                );     
            }
            else{
               custom_alert_type("exclamation", "<b>Verificar datos obligatorios</b>" + "<br> Monto Solicitado no puede ser negativo, por favor verifique los siguientes programas: <br>" + _vEmptyPrograms, "Advertencia",460);
            }
        });     
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~        
                      
        //Proceso - Aceptar Solicitud
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ 
        $("#btnValidatedSolicitud").click(function ()  {

            var $this = $(this);
            var parametros = {
               ApoyoId: $("#hidePrimaryKey").val(),
               MaquinaApoyoId: $('#lblMaquinaApoyoIdHide').val(),
               Observaciones: $("#txtObservaciones").val()               
            };
            $.customAjax({ url: location.pathname + "/AceptarSolicitud", parametros: parametros },
            function (respuesta) {
                if (respuesta.success) {
                    mostrarMensajeProceso({ tipo: 'success', mensaje: mensajesProceso.AceptarSolicitudOK });
                    //gridReload();
                    location.reload();                                                
                }
            }, null, null, true
            );
        });
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~        
              
        //Proceso - Cancelar Solicitud
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~        
        $("#btnCancelSolicitud").click(function ()  {
            custom_confirmation(function () {
                var parametros = {
                    ApoyoId: $("#hidePrimaryKey").val(),
                    MaquinaApoyoId: $('#lblMaquinaApoyoIdHide').val(),
                    Observaciones: $("#txtObservaciones").val(),
                    TipoRespuesta: "Y"      
                };
                    $.customAjax({ url: location.pathname + "/CancelarSolicitud", parametros: parametros },
                    function (respuesta) {
                        if (respuesta.success) {
                            mostrarMensajeProceso({ tipo: 'info', mensaje: mensajesProceso.CancelarSolicitudSi });
                            //gridReload();
                            location.reload();                                                
                    }
                    }, null, null, true
                    );  
           },
                function () {
                    var parametros = {
                    ApoyoId: $("#hidePrimaryKey").val(),
                    MaquinaApoyoId: $('#lblMaquinaApoyoIdHide').val(),
                    Observaciones: $("#txtObservaciones").val(),
                    TipoRespuesta: "N"      
                };
                    $.customAjax({ url: location.pathname + "/CancelarSolicitud", parametros: parametros },
                    function (respuesta) {
                        if (respuesta.success) {
                            mostrarMensajeProceso({ tipo: 'info', mensaje: mensajesProceso.CancelarSolicitudNo });
                            //gridReload(); 
                            location.reload();                                               
                        }
                    }, null, null, true
                    ); 
                },
                "Desea presentar una nueva solicitud de apoyo a CAT?"
            );
        });
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~        

        //Proceso - Registrar Claim
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~+        
         $("#btnSaveClaim").click(function ()  {
            
            var $this = $(this);

            debugger;

            var _ListTempClaim = [];
            var _vEmptyPrograms = "";
            var _vEmptyClaimDate = "";
            var _vMessage = "";
            var _vClaimFecha =  $("#txtFechaClaim").datepicker({dateFormat: 'dd-mm-yyyy'}).val();
            var _vSRCFecha = $('#lblFechaSRCHide').val();
            var getDataClaim = $("#jqgRelacionProgramasClaimByApoyo").jqGrid('getRowData');

            var vClaimFechaCompare = new Date(_vClaimFecha.substring(6,10),(_vClaimFecha.substring(3, 5) -1),_vClaimFecha.substring(0, 2));
            var vSRCFechaCompare = new Date(_vSRCFecha.substring(6,10),(_vSRCFecha.substring(3, 5) -1),_vSRCFecha.substring(0, 2));
                               
            if(_vClaimFecha == ""){
            _vEmptyClaimDate = "&raquo;" + "Fecha de Claim es requerido.";
            }else if(_vClaimFecha != ""){
                if (vClaimFechaCompare < vSRCFechaCompare){
                    _vEmptyClaimDate = "&raquo;" + "Fecha de Claim no puede ser menor a la Fecha Sales Record Card ";
                }
            }

            for (i = 0; i < getDataClaim.length; i++) {
                _ClaimApoyoId = $("#hidePrimaryKey").val();                
                _ClaimProgramasId = getDataClaim[i].int_ProgramasId; 
                _ClaimNumero = getDataClaim[i].str_ExpPrograma_NumeroClaim;
                _ClaimFecha = $("#txtFechaClaim").datepicker({dateFormat: 'dd-mm-yyyy'}).val();
                _ProgramaDescripcion = getDataClaim[i].str_DescPrograma;
                _ProgramaCATId = getDataClaim[i].str_IdProgramaCAT;

                if(_ClaimNumero != ""){
                    _ListTempClaim.push([_ClaimApoyoId,_ClaimProgramasId,_ClaimNumero,_ClaimFecha]);
                }
                else{
                    _vEmptyPrograms += "&#8226" + "&nbsp;" + _ProgramaCATId + "&nbsp;" +"&#47;" + "&nbsp;" + _ProgramaDescripcion + "<br>"; 
                }                
            };

            if (_vEmptyClaimDate != "" && _vEmptyPrograms != ""){
              _vMessage = "<b>Verificar datos obligatorios</b>" + "<br>" + _vEmptyClaimDate + "<br>" + "&raquo;" + "Número de Claim es requerido, por favor verifique los siguientes programas:" + "<br>" + _vEmptyPrograms;  
            }
            else if (_vEmptyClaimDate != "" && _vEmptyPrograms == ""){
                _vMessage =   "<b>Verificar datos obligatorios</b>" + "<br>" + _vEmptyClaimDate; 
            }
            else if (_vEmptyClaimDate == "" && _vEmptyPrograms != ""){
                _vMessage =  "<b>Verificar datos obligatorios</b>" + "<br>" + "&raquo;" + "Número de Claim es requerido, por favor verifique los siguientes programas:" + "<br>" + _vEmptyPrograms;  
            }

            if (_vMessage == ""){

               var parametros = {
                ApoyoId: $("#hidePrimaryKey").val(),
                ListTempClaim: _ListTempClaim
                };

                $.customAjax({ url: location.pathname + "/RegistrarClaim", parametros: parametros },
                function (respuesta) {
                    if (respuesta.success) {
                        mostrarMensajeProceso({ tipo: 'success', mensaje: mensajesProceso.RegistrarClaimOk });
                        //gridReload(); 
                        location.reload();                                               
                    }
                }, null, null, true
                );

            }
            else{
                custom_alert_type("exclamation",_vMessage, "Advertencia",500);
            }
        });
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~+        
             
        //Proceso - Credit Memo
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~+        
        $("#btnSaveCreditMemo").click(function ()   {

            var $this = $(this);
            var _ListCreditMemo = [];
            var _vEmptyPrograms = "";
            var _vEmptyProgramsItems = "";
            var _vEmptyCeditMemomDate = "";
            var _vMessage = "";
            var _vSRCFecha = $('#lblFechaSRCHide').val();
            var vSRCFechaCompare = new Date(_vSRCFecha.substring(6,10),(_vSRCFecha.substring(3, 5) -1),_vSRCFecha.substring(0, 2));
            var vCMFechaCompare = null;

            var getDataCreditMemo = $("#jqgRelacionProgramasCreditMemoByApoyo").jqGrid('getRowData');
                               
            for (i = 0; i < getDataCreditMemo.length; i++) {
                _CMApoyoId = $("#hidePrimaryKey").val();                
                _CMProgramasId = getDataCreditMemo[i].int_ProgramasId; 
                _CMNumero = getDataCreditMemo[i].str_ExpPrograma_NumeroCreditMemo.replace(/\s+/g, '');
                _CMFecha = getDataCreditMemo[i].det_ExpPrograma_FechaCreditMemo.replace(/\s+/g, '');
                _CMMonto = getDataCreditMemo[i].dec_ExpPrograma_MontoPagado.replace(/\s+/g, '');
                _ProgramaDescripcion = getDataCreditMemo[i].str_DescPrograma;
                _ProgramaCATId = getDataCreditMemo[i].str_IdProgramaCAT;

                if (_CMNumero != "" && _CMFecha != "" && _CMMonto > 0) {
                    _ListCreditMemo.push([_CMApoyoId,_CMProgramasId,_CMNumero,_CMFecha,_CMMonto]);                                   
                }
                else if  (_CMNumero == "" || _CMFecha == "" || _CMMonto < 0) {
                    _vEmptyPrograms += "&#8226 &nbsp;" + _ProgramaCATId + "&nbsp; &#47; &nbsp;" + _ProgramaDescripcion + "&nbsp; datos requeridos: <br>";                   
                }                                       
                if(_CMNumero == ""){
                    _vEmptyPrograms += "&nbsp; &#187; N° Credit Memo <br>";                                     
                } 
                if(_CMFecha == ""){
                    _vEmptyPrograms += "&nbsp; &#187; Fecha Credit Memo <br>";
                }
                else if (_CMFecha != ""){
                    vCMFechaCompare = new Date(_CMFecha.substring(6,10),(_CMFecha.substring(3, 5) -1),_CMFecha.substring(0, 2));

                    if (vCMFechaCompare < vSRCFechaCompare){
                        _vEmptyPrograms += "&#8226 &nbsp; Fecha de Credit Memo no puede ser menor a la Fecha Sales Record Card <br>";
                    }
                }
                if(_CMMonto <= 0){
                    _vEmptyPrograms += "&nbsp; &#187; Monto Pagado $ <br>";
                }
            }; 
            
            if (_vEmptyPrograms == ""){
                var parametros = {
                ApoyoId: $("#hidePrimaryKey").val(),
                ListTempCreditMemo: _ListCreditMemo
                };
                    $.customAjax({ url: location.pathname + "/RegistrarCreditMemo", parametros: parametros },
                    function (respuesta) {
                        if (respuesta.success) {
                            mostrarMensajeProceso({ tipo: 'success', mensaje: mensajesProceso.RegistrarCreditMemoOK });
                            //gridReload();
                            location.reload();                                                
                        }
                    }, null, null, true
                );             
            }
            else{
                custom_alert_type("exclamation","<b>Verificar datos obligatorios</b>" + "<br> Por favor verifique los siguientes programas: <br>" + _vEmptyPrograms , "Advertencia",600);
            }
        });
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~+        
            
        //Proceso - Regresar actividad anterior
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~+        
        $("#btnPreviusActivity").click(function ()  {
            custom_confirmation(function () {
                var parametros = {
                    ApoyoId: $("#hidePrimar yKey").val(),
                    MaquinaApoyoId: $("#lblMaquinaApoyoIdHide").val()    
                };
                $.customAjax({ url: location.pathname + "/RegresarActividad", parametros: parametros },
                function (respuesta) {
                    if (respuesta.success) {
                        mostrarMensajeProceso({ tipo: 'success', mensaje: mensajesProceso.RegistrarCreditMemoOK });
                        //gridReload(); 
                        location.reload();                                               
                    }
                }, null, null, true
                );
                },
                function () {
                },
                "Desea regresar a la actividad anterior?"
            );
        });
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~        
                  
        //Modal Relacion de Programas
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ 
        //Modal - Creacion de Programas
        $("#modalRelacionProgramas").dialog({         
            autoOpen: false,
            width: 700,
            height: "auto",
            resizable: false,
            modal: true,             
            close: function () {
            },
            buttons: {            
                "Aceptar": function () {
                var idsMaqRel = $("#jqgRelacionProgramasByApoyo").jqGrid('getDataIDs');
                var ids = $("#jqgRelacionProgramas").getGridParam("selarrrow");
                for (var i = 0; i < ids.length; i++) {
                  if (idsMaqRel.indexOf(ids[i]) == -1) {
                  var row = $("#jqgRelacionProgramas").getRowData(ids[i]);
                  $("#jqgRelacionProgramasByApoyo").addRowData(ids[i], {int_ProgramasId: row.int_ProgramasId , str_IdProgramaCAT: row.str_IdProgramaCAT ,str_DescPrograma: row.str_DescPrograma  });
                 }
                } 
                $(this).dialog("close");
                }, 
                "Cancelar": function () {
                $(this).dialog("close");
                }
            }
        }); 
        
        //Boton - Pasar Programas de Popup a Grilla de Programas        
        $("#btnRelacionProgramas").click(function () {
            $.customAjax({ url: location.pathname + "/GetData_RelacionProgramas", parametros: {ApoyoId:$("#hidePrimaryKey").val()} },
            function (respuesta) {
                preload(false);
                    if (respuesta.success) {
                        dataCuentasFiltro = respuesta.data;                    
                        jQuery("#jqgRelacionProgramas").setGridParam({ rowNum: respuesta.data.length });
                        jQuery("#jqgRelacionProgramas").jqGrid('setGridParam', { data: dataCuentasFiltro }).trigger("reloadGrid");
                        $('#modalRelacionProgramas').dialog('open');
                    } else {
                    }
                }, function (error) {
                preload(false);
                }, function () {
                preload(true);
                }
            );
        }); 
        
        //Grilla - Relacion de Programas (Popup)
        $("#jqgRelacionProgramas").jqGrid({         
            datatype: "local",
            data: dataCuentasFiltro,
            height: "auto",
            width: "auto",

            colModel: [
                        { label: 'ID', name: 'int_ProgramasId', index: 'int_ProgramasId',  hidden: true },
                        { label: 'ID Programa', name: 'str_IdProgramaCAT', index: 'str_IdProgramaCAT', width: 120, key: true},
                        { label: 'Descripción', name: 'str_DescPrograma', index: 'str_DescPrograma', width: 230 },
                        { label: 'Fecha Inicio', name: 'det_FechaInicio', index: 'det_FechaInicio', width: 80, align: "center", formatter: 'date', formatoptions: { srcformat: 'd/m/Y', newformat: 'd/m/Y'} },
                        { label: 'Fecha Fin', name: 'det_FechaFin', index: 'det_FechaFin', width: 80 , align: "center", formatter: 'date', formatoptions: { srcformat: 'd/m/Y', newformat: 'd/m/Y'}},
                        { label: 'Flujo', name: 'str_RolFlujoDesc', index: 'str_RolFlujoDesc', width: 120}, 
                        { label: 'det_FechaCreacion', name: 'det_FechaCreacion', index: 'det_FechaCreacion', width: 340, hidden: true  },
                        { label: 'det_FechaModificacion', name: 'det_FechaModificacion', index: 'det_FechaModificacion', width: 340, hidden: true  },
                        { label: 'str_UsuarioCreacion', name: 'str_UsuarioCreacion', index: 'str_UsuarioCreacion', width: 340, hidden: true  },
                        { label: 'str_UsuarioModificacion', name: 'str_UsuarioModificacion', index: 'str_UsuarioModificacion', width: 340, hidden: true  },
                        { label: 'bl_ProgramaStatus', name: 'bl_ProgramaStatus', index: 'bl_ProgramaStatus', width: 340, hidden: true  }
                    ],
            regional: 'es',
            viewrecords: true,
            multiselect: true,
            gridview: gridView            
        });
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                  
        $("#modalComentarios").dialog({
        autoOpen: false,
        width: 454,
        height: 290,
        resizable: false,
        modal: true,
        close: function () {
            $('#lblApoyoId').val("");
            $('#lblTypeTrans').val("");
            $('#txtComentarios').val("");
        }, 
        buttons: {
            "Grabar": function () {
                var $this = $(this);

                       var parametros = {
                        ApoyoId: $('#lblApoyoId').val(),
                        TypeTrans: $('#lblTypeTrans').val(),
                        Comentarios: $('#txtComentarios').val()
                    };

                $.customAjax({ url: location.pathname + "/RegistrarComentario", parametros: parametros },
                    function (respuesta) {
                        if (respuesta.success) {
                            mostrarMensajeProceso({ tipo: 'success', mensaje: mensajesProceso.RegistrarComentario });
                            $("#jqgFlujo").jqGrid().trigger("reloadGrid");
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
        });
    
        //Combobox
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ 
        //Estado de Facturación
        function GetData_Billing() {
            $.ajax({
                type: "POST",
                url: location.pathname + "/GetData_Billing",
                data: '',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    $("#selectEstadoFacturaCon").empty().append($("<option></option>").val("").html("Seleccione..."));
                    $.each(msg.d, function (i, item) {
                        $('#selectEstadoFacturaCon').append($('<option>', {
                            value: item.str_MasterTable_Valor,
                            text: item.str_MasterTable_Descripcion

                        }));
                    });
                },
                error: function () {
                    alert("Error al cargar estados de facturación.");
                }
            });
        }

        //Estado de Flujo
        function GetData_Workflow() {
            $.ajax({
                type: "POST",
                url: location.pathname + "/GetData_EstadoFlujo",
                data: '',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    $("#selectEstadoFlujo").empty().append($("<option></option>").val("0").html("Seleccione..."));
                    $.each(msg.d, function (i, item) {
                        $('#selectEstadoFlujo').append($('<option>', {
                            value: item.int_ActividadId,
                            text: item.str_ActividadDesc 
                        }));
                    });
                },
                error: function () {
                    alert("Error al cargar estados de flujo.");
                }
            });
        }

        //Estado de Solicitud
        function GetData_Request() {
            $.ajax({
                type: "POST",
                url: location.pathname + "/GetData_EstadoSolicitud",
                data: '',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    $("#selectEstadoSolicitud").empty().append($("<option></option>").val("0").html("Seleccione..."));
                    $.each(msg.d, function (i, item) {
                        $('#selectEstadoSolicitud').append($('<option>', {
                            value: item.int_ActividadId,
                            text: item.str_ActividadDesc
                        }));
                    });
                },
                error: function () {
                    alert("Error al cargar estados de solicitud.");
                }
            });
        }

        //Programas
        function GetData_Programs() {
            $.ajax({
                type: "POST",
                url: location.pathname + "/GetData_Programas",
                data: '',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    $("#selectProgramaCon").empty().append($("<option></option>").val("").html("Seleccione..."));
                    $.each(msg.d, function (i, item) {
                        $('#selectProgramaCon').append($('<option>', {
                            value: item.str_DescPrograma,
                            text: item.str_DescPrograma 
                        }));
                    });

                },
                error: function () {
                    alert("Error al cargar programas.");
                }
            });
        } 

        //Linea de Venta
        function GetData_LineaVenta() {
            $.ajax({            
                type: "POST",
                url: location.pathname + "/GetData_LineaVenta",
                data: '',
                contentType: "application/json; charset=utf-8",
                dataType: "json",                                 
                    
                success: function (msg) {
                    $("#selectLineaVenta").empty().append($("<option></option>").val("0").html("Seleccione..."));
                    $.each(msg.d, function (i, item) {
                        $('#selectLineaVenta').append($('<option>', {
                            value: item.int_IdLineaVenta,
                            text: item.str_DescLineaVenta 
                        }));
                    });
                },
                error: function () {
                    alert("Error al cargar programas.");
                }
            });
        }               
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ 
                  
        function formatOrden(cellValue, options, rowObject) {
            return "<span style='color:#212121; text-decoration: underline; cursor:pointer;'>" + cellValue + "</span>";
        };

        function formatEstados(cellValue, options, rowObject) {
            return "<span style='color:#0000FF; '>" + cellValue + "</span>";
        };

        function unformatOrden(cellValue, options, cellObject) {
            return $(cellObject.html()).attr("originalValue");
        };

        function gridReload() {
           var Filter = {
            strNumeroOrden: $('#txtNroOrdenCon').val(),
            strNumeroSerie: $('#txtNroSerieCon').val(),
            strCliente: $('#txtClienteCon').val(),
            strModelo: $('#txtModeloCon').val(),
            strPrograma: $('#selectProgramaCon').val(),
            strEstadoFlujo: $('#selectEstadoFlujo').val(),
            strEstadoSolicitud: $('#selectEstadoSolicitud').val(),
            strEstadoFacturacion: $('#selectEstadoFacturaCon').val(),
            strLineaVenta: $('#selectLineaVenta').val()
           };

           $("#jqgFlujo").jqGrid()[0].p.postData.Filter = Filter;
           $("#jqgFlujo").jqGrid().trigger("reloadGrid");
        };

        function CleanFilter(){
            $('#txtNroOrdenCon').val("");
            $('#txtNroSerieCon').val("");
            $('#txtClienteCon').val("");
            $('#txtModeloCon').val("");    
            $('#selectProgramaCon').val("");
            $('#selectEstadoFlujo').val("");
            GetData_Workflow();
            $('#selectEstadoSolicitud').val("");
            GetData_Request();
            $('#selectEstadoFacturaCon').val("");
            $('#selectLineaVenta').val("");
            GetData_LineaVenta();
        };

        function gridReloadAll() {
           var Filter = {
                strNumeroOrden: '',
                strNumeroSerie: '',
                strCliente: '',
                strModelo: '',
                strPrograma: '',
                strEstadoFlujo: 0,
                strEstadoSolicitud: 0,
                strEstadoFacturacion: '',
                strLineaVenta: 0
           };
           $("#jqgFlujo").jqGrid()[0].p.postData.Filter = Filter;
           $("#jqgFlujo").jqGrid().trigger("reloadGrid");
           CleanFilter();
        };

        function ClearFileUploadControl() {
        var fu = document.getElementById("flUplAttachedFile");
        if (fu != null)
        {
              fu.setAttribute("type", "input");
              fu.setAttribute("type", "file");
              $("#flUplAttachedFile").replaceWith($("#flUplAttachedFile").clone(true));
              $("#flUplAttachedFile").val(""); 
        }
    }

        function gridMaquinasReload(mantenerSeleccion, primeraPagina) {
        var filtro = obtenerObjetoFiltro();

        $("#jqgFlujo").jqGrid()[0].p.postData.filtro = filtro;

        if (!mantenerSeleccion)
            idRowMaquina = null;

        if (primeraPagina)
            $("#jqgFlujo").jqGrid('setGridParam',{page:1});

        $("#jqgFlujo").jqGrid().trigger("reloadGrid");  
        
        };

        function DownloadExcel(){
            var varParameters = GetFilters();
            $.customFileDownload("ApoyoFabricante.ashx", varParameters);        
        };

        function DownloadWashout(){
            var intApoyoId = GetIdApoyo();
            $.customFileDownload("WashoutFile.ashx", intApoyoId);
        };

        function DownloadAttachedFile(Id){
            $.customFileDownload("AttachedFiles.ashx",{intAttachedFieldId: Id});
        };        

        function GetFilters() {
           return {
            strNumeroOrden: $('#txtNroOrdenCon').val(),
            strNumeroSerie: $('#txtNroSerieCon').val(),
            strCliente: $('#txtClienteCon').val(),
            strModelo: $('#txtModeloCon').val(),
            strPrograma: $('#selectProgramaCon').val(),
            strEstadoFlujo: $('#selectEstadoFlujo').val(),
            strEstadoSolicitud: $('#selectEstadoSolicitud').val(),
            strEstadoFacturacion: $('#selectEstadoFacturaCon').val(),
            strLineaVenta: $('#selectLineaVenta').val()
           };
        };

        function GetIdApoyo(){
            return {
                intApoyoId: $('#hidePrimaryKey').val()
            };
        };

        function DeleteProgramasLista(id) {
           $("#jqgRelacionProgramasByApoyo").delRowData(id);
           var ids = $("#jqgRelacionProgramasByApoyo").jqGrid('getDataIDs');
        };

        //Semaforos
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~        
        function SemaforoDiasClaim(cellValue, options, cellObject) {
           if (cellValue == null) {
              return "";
           } else {
              var classSemaforo = cellValue >= 100000 ? "semaforoVacio" : ((cellValue >= 30) ? "semaforoColorLetrasVerde" : (cellValue <= 30 ? "semaforoColorLetrasRojo" : ""));
              return "<div style='margin-left:5px;' class='" + classSemaforo + "'>" + cellValue  + "</div>";
           }
        };

        function SemaforoDiasSolicitud(cellValue, options, cellObject) {
           if (cellValue == null) {
              return "";
           } else {
              var classSemaforo = cellValue <= 0 ? "semaforoVacio" : ((cellValue >= 1 && cellValue <= 3) ? "semaforoColorLetrasVerde" : (cellValue >= 4 ? "semaforoColorLetrasRojo" : ""));
              return "<div style='margin-left:5px;' class='" + classSemaforo + "'>" + cellValue  + "</div>";
           }
        };

        function SemaforoVacio(cellValue, options, cellObject) {
           return $(cellObject.html()).attr("originalValue");
        };  
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~  

        function initGrid() {
            $(this).contextMenu('contextMenuFlujo', {
            bindings: {
                'RegistrarComentario': function (t) {           
                    var OrdenAsignada = null;

                     if (idRowFlujo != null) {
                        var row = $("#jqgFlujo").getRowData(idRowFlujo);
                        OrdenAsignada = row.str_OrdenAsignadaHide;

                        if (OrdenAsignada != null){
                            $('#lblApoyoId').val(row.int_ApoyoId);
                            $('#lblTypeTrans').val("1");

                            $.customAjax({ url: location.pathname + "/GetData_ExpedienteComentarios_ByKey", parametros: {ApoyoId:idRowFlujo} },
                                function (respuesta) { 
                                    if (respuesta.success) {
                                        var lista = respuesta.data;
                                        for (var i = 0; i < lista.length; i++) {
                                            $('#txtComentarios').val(lista[i].str_Observacion); 
                                        }
                                            $("#modalComentarios").dialog('option', 'title', 'Orden N° ' + OrdenAsignada +  ' - Comentarios');
                                            $('#modalComentarios').dialog('open');
                                            $("#txtComentarios").focus()
                                    }
                                }, null, null, true
                            );
                        }
                        else{
                            custom_alert("Seleccione un N° de Orden.");               
                        }              
                    } 
                }
            }
        });
       };       


        
                                   