<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="frmCuentaInventario.aspx.vb" Inherits="SGCVU.frmCuentaInventario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <%--Archivos Css--%>
    <link href="../Static/css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Static/css/jquery-ui.theme.css" rel="stylesheet" type="text/css" />
    <link href="../Static/css/ui.jqgrid.css" rel="stylesheet" type="text/css" />
    <link href="../Static/css/ui.jqgrid.custom.css" rel="stylesheet" type="text/css" />
    <%--Archivos js--%>
    <script src="../Static/js/jquery-1.11.1.min.js" type="text/javascript"></script>
    <script src="../Static/js/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Static/js/jquery.ui.datepicker-es.js" type="text/javascript"></script>
    <script src="../Static/js/jquery.validate.min.js" type="text/javascript"></script>
    <script src="../Static/js/jquery.fileDownload.js" type="text/javascript"></script>
    <script src="../Static/js/i18n/grid.locale-es.js" type="text/javascript"></script>
    <script src="../Static/js/jquery.jqGrid.min.js" type="text/javascript"></script>
    <script src="../Static/js/jquery.contextmenu.js" type="text/javascript"></script>
    <script src="../Static/js/jquery.blockUI.js" type="text/javascript"></script>
    <script src="Script/frmCuentaInventario.js" type="text/javascript"></script>
    <script src="../Static/js/utils.js" type="text/javascript"></script>
    <script src="../Static/js/moment.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent1" runat="server">
    <div class="lbl_MainTitle">
        Cuenta de Inventario
    </div>
    <div id="Accordion_CriteriosBusqueda">
        <div class="lbl_TitleAccordion">
            Criterios de Busqueda</div>
        <div>
            <table width="100%" border="0" cellpadding="0" cellspacing="1">
                <tr>
                    <td>
                        <table width="0" border="0" cellpadding="0" cellspacing="2">
                            <tr>
                                <td class="lbl_Form">
                                    Código
                                    de Cuenta Inventario
                                </td>
                                <td class="lbl_Form">
                                    :
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <input id="txtCodigoCon" type="text" style="width:200px" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="lbl_Form">
                                    Linea de Venta</td>
                                <td class="lbl_Form">
                                    :</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <select id="selectLineaCon" name="D1">
                                    </select></td>
                            </tr>
                            <tr>
                                <td class="lbl_Form">
                                    Descripción de Cuenta Inventario</td>
                                <td class="lbl_Form">
                                    :</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <input id="txtDescripcionCon" type="text" style="width:200px" /></td>
                                <td>
                                    &nbsp;</td>
                                <td class="lbl_Form">
                                    &nbsp;</td>
                                <td class="lbl_Form">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            </table>
                    </td>
                </tr>
                <tr>
                    <td style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <table width="0" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <input id="btnSearch" class="bnt_SearchRecord" type="button" title="Buscar" onclick="DoSearch()" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <input id="btnClean" class="bnt_CleanSearch" type="button" title="Limpiar Filtros"
                                        onclick="CleanFilter()" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <input id="btnReload" class="bnt_Undo" type="button" title="Deshacer Busqueda" onclick="UndoSearch()" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div style="height: 10px">
    </div>
    <div>
        <div id="divData" style="overflow: auto">
            <table id="jqgCuentaInventario">
            </table>
            <div id="pagerCuentaInventario">
            </div>
        </div>
    </div>
    <div id="modalCuentaInventario">
        <form id="frmCuentaInventario">
        <div>
            <table width="100%" cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td>
                        <table width="100%" cellpadding="0" cellspacing="7" border="0">
                            <tr>
                                <td class="lbl_Form" style="width: 120px">
                                    <input id="lblCuentaInventarioId" type="hidden" />
                                </td>
                                <td class="lbl_Form" style="width: 20px">
                                    &nbsp;
                                </td>
                                <td style="height: 25px" valign="middle" align="right">
                                    <label class="lbl_Message_Red">
                                        Datos Obligatorios *</label>
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl_Form" style="width: 120px">
                                    Código</td>
                                <td class="lbl_Form" style="width: 20px">
                                    :
                                </td>
                                <td>
                                <label id="lblCuentaInventarioCodigo" class="lbl_Form"></label>
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl_Form" style="width: 120px">
                                    Descripción</td>
                                <td class="lbl_Form" style="width: 20px">
                                    :
                                </td>
                                <td>
                                <label id="lblCuentaInventarioDescripcion" class="lbl_Form"></label>
                                   
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl_Form">
                                    Linea de Venta<span class="lbl_Message_Required">*</span>
                                </td>
                                <td class="lbl_Form">
                                    :
                                </td>
                                <td style="font-weight: 700">
                                    <select id="SelectLineaVenta" name="SelectLineaVenta">
                                        <option></option>
                                    </select>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
            </table>
        </div>
        </form>
    </div>
</asp:Content>
