<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="frmGenerarIncidente.aspx.vb" Inherits="SGCVU.frmGenerarIncidente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../Static/css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Static/css/jquery-ui.theme.css" rel="stylesheet" type="text/css" />
    <link href="../Static/css/ui.jqgrid.css" rel="stylesheet" type="text/css" />
    <link href="../Static/css/ui.jqgrid.custom.css" rel="stylesheet" type="text/css" />    
    <script src="../Static/js/jquery-1.11.1.min.js" type="text/javascript"></script>
    <script src="../Static/js/jquery.fileDownload.js" type="text/javascript"></script>
    <script src="../Static/js/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Static/js/jquery.ui.datepicker-es.js" type="text/javascript"></script>
    <script src="../Static/js/jquery.validate.min.js" type="text/javascript"></script>
    <script src="../Static/js/i18n/grid.locale-es.js" type="text/javascript"></script>
    <script src="../Static/js/jquery.jqGrid.min.js" type="text/javascript"></script>
    <script src="../Static/js/jquery.contextmenu.js" type="text/javascript"></script>
    <script src="../Static/js/jquery.blockUI.js" type="text/javascript"></script>
    <script src="../Static/js/moment.min.js" type="text/javascript"></script>
    <script src="../Static/js/utils.js" type="text/javascript"></script>
   <script src="Scripts/frmGenerarIncidente.js" type="text/javascript"></script> 

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent1" runat="server">
    <div id="modalGeneraIncidente">
    <div>
       <div id="accordion_generaincidente">
            <div class="lbl_TitleAccordion">
                    Búsqueda por Cliente
            </div> 
            <div>
             <br />
                <table border="0" cellpadding="2" cellspacing="0" class="lbl_Form">
                <tr>
                <td class="style27">
                Cod. Cliente
                </td>
                
                <td class="style28">:
                </td>
                <td>
                
                            <input type="text" id="txtCodCliente" class="txt_input" 
                      value="" style="height: 17px" /></td>
                <td rowspan="2">
                
                                    <input type="button" class="bnt_SearchRecord" 
                          title="Consultar" onclick="gridMaquinasReload(false, true)" 
                        id="btnBuscarCliente" /></td>
                <td rowspan="2">
                
                                    <input type="button" class="bnt_CleanSearch" 
                          title="Consultar" 
                        id="btnLimpiarCliente" onclick="Limpiar()" /></td>
                </tr>
                <tr>
                <td class="style27">
                    Nombre Cliente</td>
                
                <td class="style28">:</td>
                <td>
                
                            <input type="text" id="txtNombreCliente" class="txt_input" 
                      value="" style="height: 17px" /></td>
                </tr>
                </table>
                
            </div>
        </div>

        <br />
        <table id="jqgGeneraIncidentes"></table>
          <div id="pagerMaquinas"></div>

          <table>
          <tr>
          <td><input id="btnGenerarExpediente" type="button" class="btn" value="Generar Expediente" onclick="GenerarIncidente();" /></td>
          <td><input id="btnRegresar" type="button" class="btn" value="Regresar" onclick="IrBandeja()" href="" /></td>
          </tr>
          </table>
    </div>
    </div>
</asp:Content>
