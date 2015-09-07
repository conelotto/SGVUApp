<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master"
    CodeBehind="frmUsuarios.aspx.vb" Inherits="SGCVU.frmUsuarios" %>

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
    <script src="Script/frmUsuarios.js" type="text/javascript"></script>
    <script src="../Static/js/utils.js" type="text/javascript"></script>
    <script src="../Static/js/moment.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent1" runat="server">
    <div class="lbl_MainTitle">
        Usuarios
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
                                    Apellidos
                                </td>
                                <td class="lbl_Form">
                                    :
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <input id="txtApellidosCon" type="text" style="width:200px" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="lbl_Form">
                                    Usuario Windows
                                </td>
                                <td class="lbl_Form">
                                    :
                                </td>
                                <td class="lbl_Form">
                                    &nbsp;
                                </td>
                                <td>
                                    <input id="txtUsuarioCon" type="text" style="width:200px" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl_Form">
                                    Nombres
                                </td>
                                <td class="lbl_Form">
                                    :
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <input id="txtNombresCon" type="text" style="width:200px" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="lbl_Form">
                                    Compañia
                                </td>
                                <td class="lbl_Form">
                                    :
                                </td>
                                <td class="lbl_Form">
                                    &nbsp;
                                </td>
                                <td>
                                    <select id="selectCompaniaCon" name="D1">
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
                    <input id="btnNuevoUsuario" type="button" value="Nuevo Usuario" class="bnt_New" style="width:130px" />
                </td>
            </tr>
        </table>
    </div>
    <div style="height: 5px">
    </div>
    <div>
        <div id="divData" style="overflow: auto">
            <table id="jqgMantenimientoUsuarios">
            </table>
            <div id="pagerjqgMantenimientoUsuarios">
            </div>
        </div>
    </div>
    <div id="modalInformacionUsuarios">
        <form id="frmInformacionUsuarios">
        <div>
            <table cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td>
                        <table cellpadding="0" cellspacing="6" border="0">
                            <tr>
                                <td class="lbl_Form" style="width: 120px">
                                    <input id="lblUsuarioId" type="hidden" />
                                    <input id="lblTypeTrans" type="hidden" />
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
                                    N° Personal
                                </td>
                                <td class="lbl_Form" style="width: 20px">
                                    :
                                </td>
                                <td>
                                    <input id="txtNumPersonal" name="txtNumPersonal" type="text" style="height: 16px;
                                        width: 150px" />
                                    &nbsp;<input id="btnCargarDatos" type="button" class="bnt_LoadData" title="Cargar Información de Empleado" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl_Form" style="width: 120px">
                                    Código Adrian
                                </td>
                                <td class="lbl_Form" style="width: 20px">
                                    :
                                </td>
                                <td>
                                    <input id="txtIdAdrian" name="txtIdAdrian" type="text" style="height: 16px; width: 150px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl_Form" style="width: 120px">
                                    Código SAP
                                </td>
                                <td class="lbl_Form" style="width: 20px">
                                    :
                                </td>
                                <td>
                                    <input id="txtIdSAP" name="txtIdSAP" type="text" style="height: 16px; width: 150px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl_Form" style="width: 120px">
                                    Nombres<span class="lbl_Message_Required">*</span>
                                </td>
                                <td class="lbl_Form" style="width: 20px">
                                    :
                                </td>
                                <td>
                                    <input id="txtNombres" name="NombresModal" type="text" style="height: 16px; width: 280px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl_Form">
                                    Apellidos<span class="lbl_Message_Required">*</span>
                                </td>
                                <td class="lbl_Form">
                                    :
                                </td>
                                <td>
                                    <input id="txtApellidos" name="ApellidosModal" type="text" style="height: 16px; width: 280px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl_Form">
                                    Usuario Windows<span class="lbl_Message_Required">*</span>
                                </td>
                                <td class="lbl_Form">
                                    :
                                </td>
                                <td>
                                    <input id="txtUsuarioWindows" name="UsuarioWindowsModal" type="text" style="height: 16px;
                                        width: 250px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl_Form">
                                    Email<span class="lbl_Message_Required">*</span>
                                </td>
                                <td class="lbl_Form">
                                    :
                                </td>
                                <td>
                                    <input id="txtEmail" name="EmailModal" type="text" style="height: 16px; width: 250px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl_Form">
                                    Función
                                </td>
                                <td class="lbl_Form">
                                    :
                                </td>
                                <td>
                                    <input id="txtFuncion" name="txtFuncion" type="text" style="height: 16px; width: 250px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl_Form">
                                    Cargo
                                </td>
                                <td class="lbl_Form">
                                    :
                                </td>
                                <td style="font-weight: 700">
                                    <input id="txtCargo" name="txtCargo" type="text" style="height: 16px; width: 250px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl_Form">
                                    Compañia<span class="lbl_Message_Required">*</span>
                                </td>
                                <td class="lbl_Form">
                                    :
                                </td>
                                <td style="font-weight: 700">
                                    <select id="SelectCompania" name="CompaniaModal">
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
    <div id="modalAsignacionRolesUsuario">
        <form id="frmAsignacionRolesUsuario">
        <div>
            <table cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td>
                        <table cellpadding="0" cellspacing="3" border="0">
                            <tr>
                                <td class="lbl_Form">
                                    <table cellpadding="0" cellspacing="4" border="0">
                                        <tr>
                                            <td class="lbl_Form">
                                                Nombre y Apellidos
                                            </td>
                                            <td class="lbl_Form">
                                                :
                                            </td>
                                            <td>
                                                <label id="lblNombresApellidos" class="lbl_Form" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lbl_Form">
                                                Usuario Windows
                                            </td>
                                            <td class="lbl_Form">
                                                :
                                            </td>
                                            <td>
                                                <label id="lblLogin" class="lbl_Form" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 5px">
                                   <input id="lblUsuarioRolesId" type="hidden" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <fieldset style="width: 1045px; border-color: #F0F0F0">
                                        <legend style="font: Verdana; font-size: 11px; color: Gray">Modulos de Sistema</legend>
                                        <table>
                                            <tr>
                                                <td>
                                                    <table cellspacing="0" cellpadding="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <input id="chkAdministracion" type="checkbox" />
                                                            </td>
                                                            <td>
                                                                <label class="lbl_Form">
                                                                    Administración de Sistema
                                                                </label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>
                                                    <table cellspacing="0" cellpadding="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <input id="chkGestionInventario" type="checkbox" />
                                                            </td>
                                                            <td>
                                                                <label class="lbl_Form">
                                                                    Gestión de Inventario Comercial
                                                                </label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>
                                                    <table cellspacing="0" cellpadding="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <input id="chkApoyoFabricante" type="checkbox" />
                                                            </td>
                                                            <td>
                                                                <label class="lbl_Form">
                                                                    Apoyo de Fabricante
                                                                </label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>
                                                    <table cellspacing="0" cellpadding="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <input id="chkBonos" type="checkbox" />
                                                            </td>
                                                            <td>
                                                                <label class="lbl_Form">
                                                                    Bonos
                                                                </label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 3px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table style="width: 100%; height: auto" border="0" cellpadding="0" cellspacing="3">
                                        <tr>
                                            <td valign="top">
                                                <fieldset style="width: 240px; border-color: #F0F0F0">
                                                    <legend style="font: Verdana; font-size: 11px; color: Gray">Acceso Adminitración de
                                                        Sistema</legend>
                                                    <table id="jqgRolesAdmin">
                                                    </table>
                                                </fieldset>
                                            </td>
                                            <td valign="top">
                                                <fieldset style="width: 240px; border-color: #F0F0F0">
                                                    <legend style="font: Verdana; font-size: 11px; color: Gray">Acceso Gestión de Inventario
                                                        Comercial</legend>
                                                    <table id="jqgRolesInventario">
                                                    </table>
                                                </fieldset>
                                            </td>
                                            <td valign="top">
                                                <fieldset style="width: 240px; border-color: #F0F0F0">
                                                    <legend style="font: Verdana; font-size: 11px; color: Gray">Acceso Apoyo de Fabricante</legend>
                                                    <table id="jqgRolesApoyo">
                                                    </table>
                                                </fieldset>
                                            </td>
                                            <td valign="top">
                                                <fieldset style="width: 240px; border-color: #F0F0F0">
                                                    <legend style="font: Verdana; font-size: 11px; color: Gray">Acceso Bonos</legend>
                                                    <table id="jqgRolesBonos">
                                                    </table>
                                                </fieldset>
                                            </td>
                                        </tr>
                                    </table>
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
    <div id="modalCuentaInventarioUsuario">
        <form id="frmCuentaInventarioUsuario">
        <div>
            <table cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td>
                        <table cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="2" border="0">
                                        <tr>
                                            <td class="lbl_Form">
                                                Nombres y Apellidos
                                            </td>
                                            <td class="lbl_Form">
                                                :
                                            </td>
                                            <td>
                                                <label id="lblNombresApellidosCuentas" class="lbl_Form" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lbl_Form">
                                                Usuario Windows
                                            </td>
                                            <td class="lbl_Form">
                                                :
                                            </td>
                                            <td>
                                                <label id="lblUsuarioCuenta" class="lbl_Form" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 20px; vertical-align: middle">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <fieldset style="width: 500px; border-color: #F0F0F0">
                                        <legend style="font: Verdana; font-size: 11px; color: Gray">Relación de Cuentas de Inventario</legend>
                                        <table id="jqgCuentaInventarioUsuario">
                                        </table>
                                    </fieldset>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        </form>
    </div>
</asp:Content>
