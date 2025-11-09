<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="TPINT_GRUPO_5_PR3.Vistas.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            height: 322px;
        }
        .auto-style2 {
            width: 389px;
        }
        .auto-style3 {
            width: 568px;
        }
        .auto-style4 {
            width: 514px;
        }
        .auto-style5 {
            width: 457px;
        }
        .auto-style6 {
            width: 389px;
            height: 53px;
        }
        .auto-style7 {
            width: 457px;
            height: 53px;
        }
        .auto-style8 {
            width: 514px;
            height: 53px;
        }
        .auto-style9 {
            width: 568px;
            height: 53px;
        }
        .auto-style10 {
            height: 53px;
        }
        .auto-style11 {
            width: 389px;
            height: 59px;
        }
        .auto-style12 {
            width: 457px;
            height: 59px;
        }
        .auto-style13 {
            width: 514px;
            height: 59px;
        }
        .auto-style14 {
            width: 568px;
            height: 59px;
        }
        .auto-style15 {
            height: 59px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style11">
                    <asp:Label ID="Label1" runat="server" Font-Size="XX-Large" Text="Clínica Medica"></asp:Label>
                </td>
                <td class="auto-style12"></td>
                <td class="auto-style13"></td>
                <td class="auto-style14"></td>
                <td class="auto-style15">
                    <asp:Label ID="lbl_Usuario" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label2" runat="server" Font-Size="X-Large" Text="TURNOS"></asp:Label>
                </td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:HyperLink ID="hlnkRegistrarTurno" runat="server" NavigateUrl="~/Vistas/RegistrarTurno.aspx">Registrar Turno</asp:HyperLink>
                </td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:HyperLink ID="hlnkConsultarTurno" runat="server" NavigateUrl="~/Vistas/ConsultarTurno.aspx">Consultar Turno</asp:HyperLink>
                </td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <asp:Label ID="Label3" runat="server" Font-Size="X-Large" Text="PACIENTES"></asp:Label>
                </td>
                <td class="auto-style7"></td>
                <td class="auto-style8"></td>
                <td class="auto-style9"></td>
                <td class="auto-style10"></td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:HyperLink ID="hlnkListarPaciente" runat="server" NavigateUrl="~/Vistas/ListarPaciente.aspx">Listar Pacientes</asp:HyperLink>
                </td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label4" runat="server" Font-Size="X-Large" Text="ADMINISTRADORES"></asp:Label>
                </td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:HyperLink ID="hlnkMenuAdministrador" runat="server" NavigateUrl="~/Vistas/MenuAdmin.aspx">Menu Administrador</asp:HyperLink>
                </td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
