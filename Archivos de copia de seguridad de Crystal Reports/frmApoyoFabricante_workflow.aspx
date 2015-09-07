<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master"
    CodeBehind="frmApoyoFabricante_workflow.aspx.vb" Inherits="SGCVU.frmApoyoFabricante_workflow" %>

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
    <script src="../Static/js/jquery.fileDownload.js" type="text/javascript"></script>
    <script src="../Static/js/i18n/grid.locale-es.js" type="text/javascript"></script>
    <script src="../Static/js/jquery.jqGrid.min.js" type="text/javascript"></script>
    <script src="../Static/js/jquery.contextmenu.js" type="text/javascript"></script>
    <script src="../Static/js/jquery.blockUI.js" type="text/javascript"></script>
    <script src="Script/frmApoyoFabricante_workflow.js" type="text/javascript"></script>
    <script src="../Static/js/utils.js" type="text/javascript"></script>
    <script src="../Static/js/moment.min.js" type="text/javascript"></script>
    <style type="text/css">
        p.MsoNormal
        {
            margin-top: 0cm;
            margin-right: 0cm;
            margin-bottom: 10.0pt;
            margin-left: 0cm;
            line-height: 115%;
            font-size: 11.0pt;
            font-family: "Calibri" , "sans-serif";
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
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
                                    Orden N°
                                </td>
                                <td class="lbl_Form">
                                    :
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <input id="txtNroOrdenCon" type="text" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="lbl_Form">
                                    Serie N°
                                </td>
                                <td class="lbl_Form">
                                    :
                                </td>
                                <td class="lbl_Form">
                                    &nbsp;
                                </td>
                                <td>
                                    <input id="txtNroSerieCon" type="text" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="lbl_Form">
                                    Programa
                                </td>
                                <td class="lbl_Form">
                                    :
                                </td>
                                <td class="lbl_Form">
                                    &nbsp;
                                </td>
                                <td>
                                    <select id="selectProgramaCon">
                                    </select>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="lbl_Form">
                                    Estado de Solicitud
                                </td>
                                <td class="lbl_Form">
                                    :
                                </td>
                                <td class="lbl_Form">
                                    &nbsp;
                                </td>
                                <td>
                                    <select id="selectEstadoSolicitud">
                                    </select>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl_Form">
                                    Modelo
                                </td>
                                <td class="lbl_Form">
                                    :
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <input id="txtModeloCon" type="text" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="lbl_Form">
                                    Cliente
                                </td>
                                <td class="lbl_Form">
                                    :
                                </td>
                                <td class="lbl_Form">
                                    &nbsp;
                                </td>
                                <td>
                                    <input id="txtClienteCon" type="text" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="lbl_Form">
                                    Linea de Venta
                                </td>
                                <td class="lbl_Form">
                                    :
                                </td>
                                <td class="lbl_Form">
                                    &nbsp;
                                </td>
                                <td>
                                    <select id="selectLineaVenta" name="D1">
                                    </select>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="lbl_Form">
                                    Estado de Flujo
                                </td>
                                <td class="lbl_Form">
                                    :
                                </td>
                                <td class="lbl_Form">
                                    &nbsp;
                                </td>
                                <td>
                                    <select id="selectEstadoFlujo">
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
                        <input id="txthdValStatus" type="hidden" value="" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <table width="0" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <input id="btnSearch" class="bnt_SearchRecord" type="button" title="Buscar" onclick="gridReload()" />
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
                                    <input id="btnReload" class="bnt_Undo" type="button" title="Deshacer Busqueda" onclick="gridReloadAll()" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <input id="btnExcelExport" type="button" onclick="DownloadExcel()" class="bnt_ExportExcel" />
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
            <table id="jqgFlujo">
            </table>
            <div id="pagerFlujo">
            </div>
            <div class="contextMenu" id="contextMenuFlujo" style="display: none">
                <ul style="width: 150px; font-size: 65%;">
                    <li id="RegistrarComentario"><span style="float: left">
                        <img src="../Images/Comentario.png" alt="" /></span> <span style="font-size: 100%;
                            font-family: Verdana">Registrar Comentario</span> </li>
                </ul>
            </div>
        </div>
    </div>
    <div>
        <table id="tblSolicitud" style="width: 100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td id="tdlSolicitud1" style="width: 60%; height: 40px" align="left" valign="middle">
                    <label id="lblOrdenNumero" class="lbl_Message_Blue">
                    </label>
                    <input id="lblFechaSolicitudHide" type="hidden" />
                    <input id="lblFechaRespuestaCATHide" type="hidden" />
                    <input id="lblFechaSRCHide" type="hidden" />
                    <input id="lblMaquinaApoyoIdHide" type="hidden" />
                    <input id="lblEstadoFlujoHide" type="hidden" />
                    <input id="lblEstadoSolicitudHide" type="hidden" />
                    <input id="lblHaveWashout" type="hidden" />
                    <input id="lblAttachedFilePrimaryKey" type="hidden" runat="server" />
                </td>
                <td id="tdlSolicitud3" style="width: 30%; height: 40px" align="right" valign="middle">
                    <input id="btnPreviusActivity" type="button" class="bnt_Back" value="Regresar actividad anterior" />
                </td>
            </tr>
        </table>
    </div>
    <div id="Accordion_WorkFlow">
        <div class="lbl_TitleAccordion">
            Datos de Solicitud CAT
        </div>
        <div id="tab_Solicitud">
            <ul>
                <li><a href="#tabs_Registro">Registro de Solicitud</a></li>
                <li><a href="#tabs_Historial">Historial</a></li>
            </ul>
            <div id="tabs_Registro" style="border: 1px dotted  #AAAAAA">
                <table width="100%" border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <td>
                            <table id="tblDatosSolicitud" runat="server" width="0" border="0" cellpadding="0"
                                cellspacing="4">
                                <tr>
                                    <td class="lbl_Form_Top">
                                        Relación de Programas
                                    </td>
                                    <td class="lbl_Form_Top" style="width: 10px">
                                        :
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <div id="divRelacionProgramasByApoyo" style="overflow: auto">
                                            <table id="jqgRelacionProgramasByApoyo">
                                            </table>
                                            <div id="pageRelacionProgramasByApoyo">
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lbl_Form">
                                        &nbsp;
                                    </td>
                                    <td class="lbl_Form" style="width: 10px">
                                        <input id="hidePrimaryKey" type="hidden" />
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="right">
                                        <input id="btnRelacionProgramas" type="button" class="bnt_ShowPopup" value="Relación de Programas"
                                            title="Ver Relación de Programas" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lbl_Form">
                                        Fecha Sales Record Card
                                    </td>
                                    <td class="lbl_Form" style="width: 10px">
                                        :
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <label id="txtFechaSRC" class="lbl_Form">
                                        </label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lbl_Form">
                                        Estado de Solicitud
                                    </td>
                                    <td class="lbl_Form">
                                        :
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <label id="txtEstadoSolicitud" class="lbl_Form">
                                        </label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lbl_Form_Top">
                                        Observaciones
                                    </td>
                                    <td class="lbl_Form_Top">
                                        :
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <textarea id="txtObservaciones" cols="65" rows="3"></textarea>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <div id="DivButtonSolicitud">
                                <input id="btnValidatedSolicitud" type="button" class="bnt_Validated" title="Validar Solicitud" />
                                <input id="btnCancelSolicitud" type="button" class="bnt_UnValidated" title="Cancelar Solicitud" />
                                <input id="btnSaveSolicitud" type="button" class="bnt_Save" title="Grabar Solicitud" />
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="tabs_Historial" style="border: 1px dotted  #AAAAAA">
                <div id="divHistorial" style="overflow: auto">
                    <table id="jqgHistorialMaquinaApoyo">
                    </table>
                    <div id="pagerHistorialMaquinaApoyo">
                    </div>
                </div>
            </div>
        </div>
        <div class="lbl_TitleAccordion">
            Datos Claim
        </div>
        <div>
            <table width="100%" border="0" cellpadding="0" cellspacing="1">
                <tr>
                    <td>
                        <table width="0" border="0">
                            <tr>
                                <td class="lbl_Form">
                                    Fecha Claim
                                </td>
                                <td class="lbl_Form" style="height: 10px">
                                    :
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <input id="txtFechaClaim" type="text" class="txt_input" style="height: 17px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl_Form_Top">
                                    Relación de Programas
                                </td>
                                <td class="lbl_Form_Top" style="height: 10px">
                                    :
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <div style="height: 5px">
                                    </div>
                                    <div id="divRelacionProgramasClaimByApoyo" style="overflow: auto">
                                        <table id="jqgRelacionProgramasClaimByApoyo">
                                        </table>
                                        <div id="pageRelacionProgramasClaimByApoyo">
                                        </div>
                                    </div>
                                    <div style="height: 5px">
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <div id="DivButtonClaim">
                            <input id="btnSaveClaim" type="button" class="bnt_Save" title="Grabar Claim" />
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <div id="divDatosWashout" class="lbl_TitleAccordion">
            Datos Washout:
        </div>
        <div>
            <table width="100%" border="0" cellpadding="0" cellspacing="1">
                <tr>
                    <td class="lbl_Form" style="height: 20px">
                        Para adjuntar Washout a la solicitud N°<b>
                            <label id="lblSolicitudNro">
                            </label>
                        </b>, seleccione el archivo deseado luego el estado y para finalizar presione <b>&lt;&lt;Guardar
                            Washout&gt;&gt;</b>.
                    </td>
                </tr>
                <tr>
                    <td class="lbl_Form">
                        <table border="0" cellpadding="0" cellspacing="4">
                            <tr>
                                <td style="width: 110px" class="lbl_Form">
                                    Archivo Adjunto
                                </td>
                                <td class="lbl_Form">
                                    :
                                </td>
                                <td>
                                </td>
                                <td>
                                    <label id="lblArchivoAdjunto" class="lbl_Message_Blue">
                                    </label>
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl_Form">
                                    Seleccione Estado
                                </td>
                                <td class="lbl_Form">
                                    :
                                </td>
                                <td>
                                </td>
                                <td>
                                    <table border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <asp:RadioButton ID="rbtnProvisional" runat="server" CssClass="lbl_Form" GroupName="EsadoWashout"
                                                    Text="Provisional" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rbtnDefinitivo" runat="server" CssClass="lbl_Form" GroupName="EsadoWashout"
                                                    Text="Definitivo" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl_Form">
                                    Seleccione Archivo
                                </td>
                                <td class="lbl_Form">
                                    :
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:FileUpload ID="flUplWashout" runat="server" Font-Names="Tahoma" Font-Size="11px"
                                        BorderStyle="Solid" BorderColor="#CCCCCC" BorderWidth="1px" ForeColor="#000099"
                                        BackColor="#CCE0FF" Width="400px" />
                                    <br />
                                    <label class="txt_Help">
                                        Solo se admiten los siguientes formatos pdf, doc, docx, xls, xlsx</label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <table>
                            <tr>
                                <td id="tdDownloadWashout">
                                    <input id="btnWashoutDownload" type="button" onclick="DownloadWashout()" class="bnt_Export"
                                        title="Descargar Washout" />
                                </td>
                                <td id="tdSaveWashout">
                                    <asp:Button ID="bntSaveWashout" runat="server" ToolTip="Grabar Washout" CssClass="bnt_Save" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <div class="lbl_TitleAccordion">
            Credit Memo:
        </div>
        <div>
            <table width="100%" border="0" cellpadding="0" cellspacing="1">
                <tr>
                    <td>
                        <table width="0" border="0">
                            <tr>
                                <td class="lbl_Form_Top">
                                    Relación de Programas
                                </td>
                                <td class="lbl_Form_Top" style="height: 10px">
                                    :
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <div style="height: 5px">
                                    </div>
                                    <div id="divRelacionProgramasCreditMemoByApoyo" style="overflow: auto">
                                        <table id="jqgRelacionProgramasCreditMemoByApoyo">
                                        </table>
                                        <div id="pagerRelacionProgramasCreditMemoByApoyo">
                                        </div>
                                    </div>
                                    <div style="height: 5px">
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <div id="DivButtonCreditMemo">
                            <input id="btnSaveCreditMemo" type="button" class="bnt_Save" title="Grabar Credit Memo" />
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <div class="lbl_TitleAccordion">
            Documentos Adjuntos:</div>
        <div id="tab_DocumentosAdjuntos">
            <ul>
                <li><a href="#tabs_Relacion">Relación</a></li>
                <li><a href="#tabs_Adjuntar">Adjuntar</a></li>
            </ul>
            <div id="tabs_Adjuntar" style="border: 1px dotted  #AAAAAA">
                <iframe id="frmUploadFiles" src="frmApoyoFabricante_UploadFiles.aspx" frameborder="0"
                    height="125px" width="100%"></iframe>
            </div>
            <div id="tabs_Relacion" style="border: 1px dotted  #AAAAAA">
                <table width="100%" border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <td class="lbl_Form" style="height: 25px">
                            Para descargar un archivo adjunto a la solicitud N°<b>
                                <label id="lblSolicitudDocAdjList">
                                </label>
                            </b>, seleccione el archivo deseado y presione <b>&#34;Descargar Documento&#34;</b>.
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div id="divDocumentosAdjuntos" style="overflow: auto">
                                <table id="jqgDocumentosAdjuntos">
                                </table>
                                <div id="pageDocumentosAdjuntos">
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="lbl_TitleAccordion">
            Historial de Flujo:
        </div>
        <div>
            <div id="divExpedienteHistorial" style="overflow: auto">
                <table id="jqgHistorialExpediente">
                </table>
                <div id="pagerHistorialExpediente">
                </div>
            </div>
        </div>
        <div class="lbl_TitleAccordion">
            Comentarios:
        </div>
        <div>
             <textarea id="txtApoyoComentario" cols="80" rows="10" readonly="readonly" ></textarea>
        </div>
    </div>
    <div id="modalRelacionProgramas" title="Selección de Programas">
        <div style="height: 10px">
        </div>
        <div>
            <table id="jqgRelacionProgramas">
            </table>
        </div>
        <div id="pageRelacionProgramas">
        </div>
    </div>
    <div id="modalComentarios">
        <table cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td style="height: 10px">
                    <input id="lblApoyoId" type="hidden" />
                    <input id="lblTypeTrans" type="hidden" />
                </td>
            </tr>
            <tr>
                <td>
                    <textarea id="txtComentarios" cols="68" rows="15"></textarea>
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
