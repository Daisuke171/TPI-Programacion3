<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrarTurno.aspx.cs" Inherits="TPINT_GRUPO_5_PR3.RegistrarTurno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            height: 258px;
            margin-right: 0px;
            margin-bottom: 78px;
        }
        .auto-style2 {
            width: 132px;
        }
        .auto-style3 {
            height: 36px;
        }
        .auto-style4 {
            width: 132px;
            height: 36px;
        }
        .auto-style5 {
            width: 207px;
        }
        .auto-style6 {
            width: 207px;
            height: 36px;
        }
        .auto-style7 {
            width: 134px;
        }
        .auto-style8 {
            height: 36px;
            width: 134px;
        }
        .auto-style11 {
            height: 35px;
        }
        .auto-style13 {
            width: 134px;
            height: 35px;
        }
        .auto-style14 {
            width: 207px;
            height: 35px;
        }
        .auto-style15 {
            height: 35px;
            width: 132px;
        }
        .auto-style16 {
            width: 205px;
        }
        .auto-style17 {
            height: 36px;
            width: 205px;
        }
        .auto-style18 {
            height: 35px;
            width: 205px;
        }
        .auto-style19 {
            height: 46px;
            width: 205px;
        }
        .auto-style20 {
            height: 46px;
            width: 132px;
        }
        .auto-style21 {
            width: 134px;
            height: 46px;
        }
        .auto-style22 {
            width: 207px;
            height: 46px;
        }
        .auto-style23 {
            height: 46px;
        }
        .auto-style24 {
            height: 28px;
            width: 205px;
        }
        .auto-style25 {
            height: 28px;
        }
        .auto-style26 {
            width: 207px;
            height: 28px;
        }
    </style>
</head>
<body style="height: 269px; margin-bottom: 9px">
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style16">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style16">&nbsp;</td>
                <td class="auto-style2">
                    <asp:Label ID="lblRegistrarTurno" runat="server" Font-Bold="True" Font-Size="Large" Text="Registrar Turno:"></asp:Label>
                </td>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style16">
                    <asp:Label ID="Label2" runat="server" Text="Datos del paciente:"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
                </td>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style5">
                    <asp:Label ID="lblApellido" runat="server" Text="Apellido:"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style16">&nbsp;</td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style5">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style17"></td>
                <td class="auto-style4">
                    <asp:Label ID="lblDni" runat="server" Text="DNI:"></asp:Label>
                </td>
                <td class="auto-style8"></td>
                <td class="auto-style6"></td>
                <td class="auto-style3"></td>
                <td class="auto-style3"></td>
            </tr>
            <tr>
                <td class="auto-style16">&nbsp;</td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtDni" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style24"></td>
                <td class="auto-style25" colspan="2">
                    <asp:Label ID="Label1" runat="server" Text="Sexo:"></asp:Label>
                </td>
                <td class="auto-style26"></td>
                <td class="auto-style25"></td>
                <td class="auto-style25"></td>
            </tr>
            <tr>
                <td class="auto-style19"></td>
                <td class="auto-style20">
                    <asp:RadioButton ID="rdbMasculino" runat="server" Text="Masculino" />
                </td>
                <td class="auto-style21">
                    <asp:RadioButton ID="rdbFemenino" runat="server" Text="Femenino" />
                </td>
                <td class="auto-style22"></td>
                <td class="auto-style23"></td>
                <td class="auto-style23"></td>
            </tr>
            <tr>
                <td class="auto-style18">&nbsp;</td>
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style14">&nbsp;</td>
                <td class="auto-style11">&nbsp;</td>
                <td class="auto-style11">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style18">&nbsp;</td>
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style14">&nbsp;</td>
                <td class="auto-style11">&nbsp;</td>
                <td class="auto-style11">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style18">&nbsp;</td>
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style14">&nbsp;</td>
                <td class="auto-style11">&nbsp;</td>
                <td class="auto-style11">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style18">&nbsp;</td>
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style14">&nbsp;</td>
                <td class="auto-style11">&nbsp;</td>
                <td class="auto-style11">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style18">&nbsp;</td>
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style14">&nbsp;</td>
                <td class="auto-style11">&nbsp;</td>
                <td class="auto-style11">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style18">&nbsp;</td>
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style14">&nbsp;</td>
                <td class="auto-style11">&nbsp;</td>
                <td class="auto-style11">&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
