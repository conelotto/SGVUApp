<%@ Page Title="Home Page" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeBehind="Default.aspx.vb" Inherits="SGCVU._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <table border="0" style="width: 100%; height: 650px">
        <tr>
            <td>
                <div>
                    <center>
                        <table id="tableModulos" border="0">
                            <tr>
                                <td style="width: 10px">
                                </td>
                                <td id="tdReservaUnidades" runat="server" visible="false" >
                                    <asp:ImageButton ID="imgbtn_ReservaUnidades" runat="server" ImageUrl="~/Images/mod_ReservaUnidades.png" />
                                </td>
                                <td style="width: 10px">
                                </td>
                                <td id="tdApoyoFabricante" runat="server" visible="false" >
                                    <asp:ImageButton ID="imgbtn_ApoyoFabricante" runat="server" ImageUrl="~/Images/mod_ApoyoFabricante.png" />
                                </td>
                                <td style="width: 10px">
                                </td>
                                <td id="tdBonos" runat="server" visible="false">
                                    <asp:ImageButton ID="imgbtn_Bonos" runat="server" ImageUrl="~/Images/mod_Bonos.png" />
                                </td>
                                <td style="width: 10px">
                                </td>
                                <td id="tdAdministracion" runat="server" visible="false">
                                    <asp:ImageButton ID="imgbtn_Administracion" runat="server" ImageUrl="~/Images/mod_Configuracion.png" />
                                </td>
                                <td style="width: 10px">
                                </td>
                            </tr>
                        </table>
                    </center>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
