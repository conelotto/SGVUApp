<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmApoyoFabricante_UploadFiles.aspx.vb"
    Inherits="SGCVU.frmApoyoFabricante_UploadFiles" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/Styles/Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%" border="0" cellpadding="0" cellspacing="1">
            <tr>
                <td class="lbl_Form" style="height: 20px">
                    Para adjuntar archivos a la solicitud N°
                        <asp:Label ID="lblSolicitudNum" runat="server" Text="00000" CssClass="lbl_Form_Bold" Visible="false"></asp:Label>
                    , seleccione el archivo deseado para finalizar presione <b>&#34;Adjuntar Documento&#34;</b>.
                </td>
            </tr>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td class="lbl_Form" style="width: 110px">
                                Seleccione Archivo
                            </td>
                            <td class="lbl_Form">
                                :
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:FileUpload ID="flUplAttachedFile" runat="server" Font-Names="Tahoma" Font-Size="11px" BorderStyle="Solid" BorderColor="#CCCCCC" BorderWidth="1px" ForeColor="#000099" BackColor="#CCE0FF" Width="400px"  />

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
                            <td id="tdUploadAttachedFile1">
                                <asp:Label ID="lblApoyoId" runat="server" Text="ApoyoId" Visible="false" CssClass="lbl_Form" />
                                <asp:Label ID="lblOrdenAsignada" runat="server" Text="OrdenAsignada" Visible="false"
                                    CssClass="lbl_Form" />
                                <asp:Label ID="lblUserName" runat="server" Text="UserName" Visible="false" CssClass="lbl_Form" />
                            </td>
                            <td id="tdUploadAttachedFile2">
                                <asp:Button ID="btnUploadAttachedFile" runat="server" ToolTip="Adjuntar Documento"
                                    UseSubmitBehavior="false" CssClass="bnt_Attached" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
