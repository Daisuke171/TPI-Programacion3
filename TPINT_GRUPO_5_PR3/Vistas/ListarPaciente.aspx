<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListarPaciente.aspx.cs" Inherits="TPINT_GRUPO_5_PR3.Vistas.ListarPaciente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 23px;
        }
        .auto-style3 {
            height: 23px;
            width: 199px;
        }
        .auto-style4 {
            width: 199px;
        }
        .auto-style5 {
            height: 23px;
            width: 165px;
        }
        .auto-style6 {
            width: 165px;
        }
        .auto-style7 {
            height: 23px;
            width: 588px;
        }
        .auto-style8 {
            width: 588px;
        }
        .auto-style9 {
            height: 23px;
            width: 83px;
        }
        .auto-style10 {
            width: 83px;
        }
        .auto-style11 {
            height: 66px;
            width: 83px;
        }
        .auto-style12 {
            height: 66px;
            width: 588px;
        }
        .auto-style13 {
            height: 66px;
        }
        .auto-style14 {
            height: 66px;
            width: 199px;
        }
        .auto-style15 {
            height: 66px;
            width: 165px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <main>

        </main>
        <table class="auto-style1">
            <tr>
                <td class="auto-style11"></td>
                <td class="auto-style12">
                    <asp:Label ID="Label1" runat="server" style="font-weight: 700" Text="Listado de pacientes"></asp:Label>
                </td>
                <td class="auto-style13"></td>
                <td class="auto-style14"></td>
                <td class="auto-style15">
                    <asp:Label ID="lblUsuario" runat="server" style="text-decoration: underline" Text="Username"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style9"></td>
                <td class="auto-style7">
                    <asp:Label ID="lblBuscarPaciente" runat="server" Text="Buscar Paciente:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style2"></td>
                <td class="auto-style3"></td>
                <td class="auto-style5"></td>
            </tr>
            <tr>
                <td class="auto-style9"></td>
                <td class="auto-style7">
                    <asp:Label ID="lblFiltrar" runat="server" Text="Filtros:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="DropDownList1" runat="server">
                    </asp:DropDownList>
                </td>
                <td class="auto-style2"></td>
                <td class="auto-style3"></td>
                <td class="auto-style5"></td>
            </tr>
            <tr>
                <td class="auto-style10">&nbsp;</td>
                <td class="auto-style8">
                    <asp:GridView ID="GridView1" runat="server">
                    </asp:GridView>
                </td>
                <td>&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style10">&nbsp;</td>
                <td class="auto-style8">&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
