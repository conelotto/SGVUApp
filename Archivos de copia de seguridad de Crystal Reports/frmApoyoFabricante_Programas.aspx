<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master"
    CodeBehind="frmApoyoFabricante_Programas.aspx.vb" Inherits="SGCVU.frmApoyoFabricante_Programas" %>

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
    <script src="Script/frmApoyoFabricante_Programas.js" type="text/javascript"></script>
    <script src="../Static/js/utils.js" type="text/javascript"></script>
    <script src="../Static/js/moment.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent1" runat="server">
    <div class="lbl_MainTitle">
        Programas con Vigencia
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
                                    Código Programa
                                </td>
                                <td class="lbl_Form">
                                    :
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <input id="txtCodigoCon" type="text" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="lbl_Form">
                                    Descripción
                                </td>
                                <td class="lbl_Form">
                                    :
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <input id="txtDescripcionCon" type="text" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="lbl_Form">
                                    Flujo
                                </td>
                                <td class="lbl_Form">
                                    :
                                </td>
                                <td class="lbl_Form">
                                    &nbsp;
                                </td>
                                <td>
                                    <select id="selectFlujoCon">
                                    </select>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
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
                    <input id="btnNuevoPrograma" type="button" value="Registrar Programa" class="bnt_New"
                        style="width: 160px" />
                </td>
            </tr>
        </table>
    </div>
    <div style="height: 5px">
    </div>
    <div>
        <div id="divData" style="overflow: auto">
            <table id="jqgMantenimientoProgramas">
            </table>
            <div id="pagerjqgMantenimientoProgramas">
            </div>
        </div>
    </div>
    <div id="modalInformacionProgramas">
        <form id="frmInformacionProgramas">
        <div>
            <table cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td>
                        <table cellpadding="0" cellspacing="6" border="0">
                            <tr>
                                <td class="lbl_Form" style="width: 120px">
                                    <input id="lblProgramasId" type="hidden" />
                                    <input id="lblTypeTrans" type="hidden" />
                                </td>
                                <td class="lbl_Form" style="width: 20px">
                                    &nbsp;
                                </td>
                                <td style="height: 20px" valign="middle" align="right">
                                    <label class="lbl_Message_Red">
                                        Datos Obligatorios *</label>
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl_Form" style="width: 120px">
                                    Código<span class="lbl_Message_Required">*</span>
                                </td>
                                <td class="lbl_Form" style="width: 20px">
                                    :
                                </td>
                                <td>
                                    <input id="txtCodigo" name="txtCodigo" type="text" style="height: 16px; width: 260px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl_Form">
                                    Descripción<span class="lbl_Message_Required">*</span>
                                </td>
                                <td class="lbl_Form">
                                    :
                                </td>
                                <td>
                                    <input id="txtDescripcion" name="txtDescripcion" type="text" style="height: 16px;
                                        width: 260px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl_Form">
                                    Flujo<span class="lbl_Message_Required">*</span>
                                </td>
                                <td class="lbl_Form">
                                    :
                                </td>
                                <td>
                                    <select id="selectFlujo" name="selectFlujo">
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl_Form">
                                    Fecha de Inicio<span class="lbl_Message_Required">*</span>
                                </td>
                                <td class="lbl_Form">
                                    :
                                </td>
                                <td>
                                    <input id="dtFechaInicio" name="dtFechaInicio" type="text" style="height: 16px; width: 120px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl_Form">
                                    Fecha de Fin<span class="lbl_Message_Required">*</span>
                                </td>
                                <td class="lbl_Form">
                                    :
                                </td>
                                <td>
                                    <input id="dtFechaFin" name="dtFechaFin" type="text" style="height: 16px; width: 120px" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
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
