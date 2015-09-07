<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="frmWorkflow_Configuracion.aspx.vb" Inherits="SGCVU.frmWorkflow_Configuracion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <%--Archivos Css--%>
    <link href="../Static/css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Static/css/jquery-ui.theme.css" rel="stylesheet" type="text/css" />
    <link href="../Static/css/ui.jqgrid.css" rel="stylesheet" type="text/css" />
    <link href="../Static/css/ui.jqgrid.custom.css" rel="stylesheet" type="text/css" />
    <%--Archivos js--%>
    <script src="../Static/js/jquery-1.11.1.min.js" type="text/javascript"></script>
    <script src="../Static/js/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Static/js/i18n/grid.locale-es.js" type="text/javascript"></script>
    <script src="../Static/js/jquery.validate.min.js" type="text/javascript"></script>
    <script src="../Static/js/jquery.jqGrid.min.js" type="text/javascript"></script>
    <script src="../Static/js/jquery.blockUI.js" type="text/javascript"></script>
    <script src="../Static/js/utils.js" type="text/javascript"></script>
    <script src="Scripts/frmWorkflow_Configuracion.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent1" runat="server">
    <div>
        <div id="tabsConfiguracion">
            <ul>
		        <li><a href="#tabColumnas">Columnas de la Vista</a></li>
	        </ul>
            <div id="tabColumnas">
                <div>
                    <table id="jqgColumnas"></table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>