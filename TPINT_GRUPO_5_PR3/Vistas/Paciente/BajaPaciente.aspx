<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BajaPaciente.aspx.cs" Inherits="TPINT_GRUPO_5_PR3.Vistas.WebForm4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style5 {
            width: 195px;
        }
        .auto-style8 {
            width: 195px;
            height: 40px;
        }
        .auto-style11 {
            width: 195px;
            height: 32px;
        }
        .auto-style13 {
            width: 115px;
        }
        .auto-style14 {
            width: 115px;
            height: 32px;
        }
        .auto-style15 {
            width: 115px;
            height: 40px;
        }
        .auto-style16 {
            margin-left: 23px;
        }
        .auto-style17 {
            width: 541px;
        }
        .auto-style18 {
            width: 541px;
            height: 32px;
        }
        .auto-style19 {
            width: 541px;
            height: 40px;
        }
        .auto-style20 {
            width: 115px;
            height: 46px;
        }
        .auto-style21 {
            width: 195px;
            height: 46px;
        }
        .auto-style22 {
            width: 541px;
            height: 46px;
        }
        .auto-style23 {
            width: 115px;
            height: 37px;
        }
        .auto-style24 {
            width: 195px;
            height: 37px;
        }
        .auto-style25 {
            width: 541px;
            height: 37px;
        }
        .auto-style26 {
            width: 115px;
            height: 31px;
        }
        .auto-style27 {
            width: 195px;
            height: 31px;
        }
        .auto-style28 {
            width: 541px;
            height: 31px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style20"></td>
                    <td class="auto-style21">
                        <asp:Label ID="labelBaja" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Baja Paciente"></asp:Label>
                    </td>
                    <td class="auto-style22"></td>
                </tr>
                <tr>
                    <td class="auto-style14"></td>
                    <td class="auto-style11"></td>
                    <td class="auto-style18"></td>
                </tr>
                <tr>
                    <td class="auto-style15"></td>
                    <td class="auto-style8">Usuario:
                        <asp:Label ID="labelNombreUsuario" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style19"></td>
                </tr>
                <tr>
                    <td class="auto-style13">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style17">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style15">
                        <asp:Label ID="labelDNI" runat="server" Text="Ingrese DNI:"></asp:Label>
                    </td>
                    <td class="auto-style8">
                        <asp:TextBox ID="txtBoxDNI" runat="server" Width="181px"></asp:TextBox>
                    </td>
                    <td class="auto-style19"></td>
                </tr>
                <tr>
                    <td class="auto-style26"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style28"></td>
                </tr>
                <tr>
                    <td class="auto-style20"></td>
                    <td class="auto-style21">
                        <asp:Button ID="btnBorrar" runat="server" CssClass="auto-style16" Text="Borrar" Width="108px" />
                    </td>
                    <td class="auto-style22"></td>
                </tr>
                <tr>
                    <td class="auto-style23">
                        <asp:Label ID="labelMensaje" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style24"></td>
                    <td class="auto-style25"></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

