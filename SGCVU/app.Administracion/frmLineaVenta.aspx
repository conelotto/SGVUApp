<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master"
    CodeBehind="frmLineaVenta.aspx.vb" Inherits="SGCVU.frmLineaVenta" %>

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
    <script src="Script/frmLineaVenta.js" type="text/javascript"></script>
    <script src="../Static/js/utils.js" type="text/javascript"></script>
    <script src="../Static/js/moment.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent1" runat="server">
    <div class="lbl_MainTitle">
        Linea de Venta
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
                                    Linea de Venta
                                </td>
                                <td class="lbl_Form">
                                    :
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <input id="txtLineaCon" type="text" style="width: 200px" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="lbl_Form">
                                    Nombres y Apellidos&nbsp;<span class="txt_Help">(Firma Digital)</span></td>
                                <td class="lbl_Form">
                                    :
                                </td>
                                <td class="lbl_Form">
                                    &nbsp;
                                </td>
                                <td>
                                    <input id="txtFirmaNombreCon" type="text" style="width: 180px" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl_Form">
                                    Compañia</td>
                                <td class="lbl_Form">
                                    :</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <select id="selectCompaniaCon" name="D1">
                                    </select></td>
                                <td>
                                    &nbsp;</td>
                                <td class="lbl_Form">
                                    Cargo&nbsp;<span class="txt_Help">(Firma Digital)</span></td>
                                <td class="lbl_Form">
                                    :</td>
                                <td class="lbl_Form">
                                    &nbsp;</td>
                                <td>
                                    <input id="txtFirmaCargoCon" type="text" style="width: 180px" /></td>
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
    <div style="height: 5px">
    </div>
    <div>
        <table width="100%" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td align="left" valign="middle">
                    <input id="btnNuevoLinea" type="button" value="Nuevo Linea de Venta" class="bnt_New"
                        style="width: 170px" />
                </td>
            </tr>
        </table>
    </div>
    <div style="height: 5px">
    </div>
    <div>
        <div id="divData" style="overflow: auto">
            <table id="jqgMantenimientoLinea">
            </table>
            <div id="pagerjqgMantenimientoLinea">
            </div>
        </div>
    </div>
    <div id="modalInformacionLinea">
        <form id="frmInformacionLinea">
        <div>
            <table cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td>
                        <table cellpadding="0" cellspacing="6" border="0">
                            <tr>
                                <td>
                                    <input id="lblLineaVentaId" type="hidden" />
                                    <input id="lblTypeTrans" type="hidden" />
                                    <input id="lblFileSignature" type="hidden" value="" />
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
                                <td class="lbl_Form" style="width: 150px">
                                    Linea de Venta<span class="lbl_Message_Required">*</span>
                                </td>
                                <td class="lbl_Form" style="width: 20px">
                                    :
                                </td>
                                <td>
                                    <input id="txtLinea" name="txtLinea" type="text" style="height: 16px; width: 280px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl_Form">
                                    Dias de Reserva<span class="lbl_Message_Required">*</span>
                                </td>
                                <td class="lbl_Form" style="width: 20px">
                                    :
                                </td>
                                <td>
                                    <input id="txtDias" name="txtDias" type="text" style="height: 16px; width: 70px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl_Form">
                                    Washout
                                </td>
                                <td class="lbl_Form" style="width: 20px">
                                    :
                                </td>
                                <td>
                                    <input id="chkWashout" type="checkbox" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl_Form">
                                    Compañia<span class="lbl_Message_Required">*</span>  
                                    
                                    </td>
                                <td class="lbl_Form" style="width: 20px">
                                    :</td>
                                <td>
                                    <select id="SelectCompania" name="SelectCompania">
                                        <option></option>
                                    </select></td>
                            </tr>
                            <tr>
                                <td class="lbl_Form">
                                    Nombres y Apellidos<span class="lbl_Message_Required">*</span>
                                    <br />
                                    <asp:Label ID="Label2" runat="server" Text="(Firma Digital)" CssClass="txtHelp"></asp:Label>
                                </td>
                                <td class="lbl_Form" style="width: 20px">
                                    :
                                </td>
                                <td>
                                    <input id="txtNombreFirma" name="txtNombreFirma" type="text" style="height: 16px;
                                        width: 250px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl_Form">
                                    Cargo<span class="lbl_Message_Required">*</span>
                                    <br />
                                    <asp:Label ID="Label3" runat="server" Text="(Firma Digital)" CssClass="txtHelp"></asp:Label>
                                </td>
                                <td class="lbl_Form" style="width: 20px">
                                    :
                                </td>
                                <td>
                                    <input id="txtCargoFirma" name="txtCargoFirma" type="text" style="height: 16px; width: 250px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl_Form">
                                    Firma Digital<span class="lbl_Message_Required">*</span>
                                    <br />
                                    <asp:Label ID="Label1" runat="server" Text="Dimensiones: 200 x 200 " CssClass="txtHelp"></asp:Label>
                                </td>
                                <td class="lbl_Form" style="width: 20px">
                                    :
                                </td>
                                <td>
                                    <input id="fileSignature" type="file" name="files[]" class="FileUpload" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl_Form">
                                    Nombre de Archivo
                                </td>
                                <td class="lbl_Form" style="width: 20px">
                                    :
                                </td>
                                <td>
                                    <label id="lblFileName" class="lbl_Message_Blue">
                                    </label>
                                    <br />
                                    &nbsp;<output id="outListFiles"></output>
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
