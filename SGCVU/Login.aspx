<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="SGCVU.Login1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>.:Sistema de Gestión Comercial de Venta de Unidades:.</title>
    <link href="~/Images/f_ico.ico" rel="SHORTCUT ICON" type="image/x-icon" />
    <link href="~/Styles/Frame.css" rel="stylesheet" type="text/css" />
    <link href="~/Styles/Style.css" rel="stylesheet" type="text/css" />
</head>
<body class="Body_Back">
    <form id="form1" runat="server">
    <div style="top: 50%; left: 50%;">
        <center>
            <table width="0" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="height: 100px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 710px">
                        <div id="login_div" style="height: 470px; vertical-align: middle">
                            <table width="0" border="0">
                                <tr>
                                    <td colspan="5" style="height: 80px">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                        &nbsp;
                                    </td>
                                    <td>
                                        <img src="Images/login_panel.png" />
                                    </td>
                                    <td style="width:10px">
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:Login ID="Log" runat="server" EnableViewState="false" RenderOuterTable="false"
                                            OnAuthenticate="LoginUser_Authenticate" FailureText="Nombre de usuario y/o contraseña inconrrecta. Inténtelo nuevamente." FailureTextStyle-CssClass="lbl_Message_Warranty">
                                            <LayoutTemplate>
                                                <table cellpadding="0" cellspacing="1">
                                                    <tr>
                                                        <td align="left" colspan="2" style="height: 30px">
                                                            <asp:Label ID="Label4" runat="server" CssClass="lbl_Authentic" Text="Por favor ingrese su usuario y contraseña, gracias."></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="2" style="height: 30px">
                                                            <asp:Label ID="Label1" runat="server" AssociatedControlID="UserName" CssClass="lbl_TitleAuthentic"
                                                                Text="Autentificación de Usuario:"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" CssClass="lbl_Authentic"
                                                                Text="Usuario:" />
                                                        </td>
                                                        <td style="height: 25px">
                                                            <asp:TextBox ID="UserName" runat="server" Width="180px" Height="15px" CssClass="txt_Authenticate"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                                                ErrorMessage="Usuario es requerido." ValidationGroup="Log" CssClass="lbl_Message_Error">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" CssClass="lbl_Authentic"
                                                                Text="Contraseña:" />
                                                        </td>
                                                        <td style="height: 25px">
                                                            <asp:TextBox ID="Password" runat="server" TextMode="Password" Width="180px" Height="15px"  CssClass="txt_Authenticate"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                                                ErrorMessage="Contraseña es requerido." ValidationGroup="Log" CssClass="lbl_Message_Error">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="2" class="lbl_Message_Error" style="height: 10px">
                                                            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" colspan="2">
                                                            <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Ingresar" ValidationGroup="Log"
                                                                CssClass="btn" />&nbsp;&nbsp;&nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </LayoutTemplate>
                                        </asp:Login>
                                    </td>
                                    <td style="width: 50px">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5" style="height: 50px">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </center>
    </div>
    </form>
</body>
</html>
