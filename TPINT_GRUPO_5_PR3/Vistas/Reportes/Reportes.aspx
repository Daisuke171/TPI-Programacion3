<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="TPINT_GRUPO_5_PR3.Vistas.Reportes.Reportes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 225px;
        }
        .auto-style3 {
            width: 225px;
            height: 26px;
        }
        .auto-style4 {
            height: 26px;
        }
        .auto-style5 {
            width: 183px;
        }
        .auto-style6 {
            height: 26px;
            width: 183px;
        }
        .auto-style7 {
            width: 225px;
            height: 11px;
        }
        .auto-style8 {
            width: 183px;
            height: 11px;
        }
        .auto-style9 {
            height: 11px;
        }
        .auto-style10 {
            width: 574px;
        }
        .auto-style11 {
            height: 26px;
            width: 574px;
        }
        .auto-style12 {
            height: 11px;
            width: 574px;
        }
        .auto-style13 {
            width: 34px;
        }
        .auto-style14 {
            height: 26px;
            width: 34px;
        }
        .auto-style15 {
            height: 11px;
            width: 34px;
        }
        .auto-style16 {
            width: 80px;
        }
        .auto-style17 {
            height: 26px;
            width: 80px;
        }
        .auto-style18 {
            height: 11px;
            width: 80px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">
                    &nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style10">&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style16">
                    <asp:Label ID="lblUsuario" runat="server" Text="Username"></asp:Label>
                </td>
                <td>
                    <asp:Button ID="btnLogout" runat="server" Text="Cerrar Sesion" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblReportes" runat="server" Font-Bold="True" Font-Size="Larger" Text="Reportes"></asp:Label>
                </td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style10">&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style16">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style10">&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style16">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">Cantidad de turnos por medico:</td>
                <td class="auto-style6">
                    <asp:DropDownList ID="ddlMedicos" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMedicos_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td class="auto-style14"></td>
                <td class="auto-style11">
                    <asp:Label ID="lblCantTurnosPorMedico" runat="server"></asp:Label>
                </td>
                <td class="auto-style4"></td>
                <td class="auto-style17"></td>
                <td class="auto-style4"></td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style10">&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style16">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">Turnos en los dias seleccionados:</td>
                <td class="auto-style8">
                    <asp:Calendar ID="clTurnos" runat="server" AutoPostBack="True" OnSelectionChanged="clTurnos_SelectionChanged"></asp:Calendar>
                </td>
                <td class="auto-style15"></td>
                <td class="auto-style12">
                    <asp:GridView ID="gvTurnos" runat="server" AutoGenerateColumns="False" style="margin-top: 0px">
                        <Columns>
                            <asp:TemplateField HeaderText="Fecha">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_it_fecha" runat="server" Text='<%# Bind("Fecha_Tur") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Paciente">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_it_paciente" runat="server" Text='<%# Eval("Nombre_Pac") + " " + Eval("Apellido_Pac") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Medico">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_it_medico" runat="server" Text='<%# Eval("Nombre_Med") + " " + Eval("Apellido_Med") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
                <td class="auto-style9"></td>
                <td class="auto-style18"></td>
                <td class="auto-style9"></td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style10">&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style16">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
