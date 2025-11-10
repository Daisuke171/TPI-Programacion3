<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultarTurno.aspx.cs" Inherits="TPINT_GRUPO_5_PR3.Vistas.ConsultarTurno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 269px;
        }
        .auto-style3 {
            width: 269px;
            height: 23px;
        }
        .auto-style4 {
            height: 23px;
        }
        .auto-style5 {
            width: 143px;
        }
        .auto-style6 {
            height: 23px;
            width: 143px;
        }
        .auto-style7 {
            width: 129px;
        }
        .auto-style8 {
            height: 23px;
            width: 129px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblConsultarTurno" runat="server" Font-Bold="True" Font-Size="Large" Text="Consultar Turno: "></asp:Label>
                    </td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>
                    <asp:Label ID="lbl_Usuario" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">Consultar por DNI:</td>
                    <td class="auto-style6">
                        <asp:TextBox ID="txtDni" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style8">
                        <asp:Button ID="btnFiltrarDni" runat="server" Text="Filtrar" Width="116px" />
                    </td>
                    <td class="auto-style4"></td>
                    <td class="auto-style4"></td>
                    <td class="auto-style4"></td>
                    <td class="auto-style4">
                    <asp:HyperLink ID="hlnk_Inicio" runat="server" NavigateUrl="~/Vistas/Inicio.aspx">Inicio</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Consultar turnos de medico por LEGAJO:</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="txtLegajo" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style7">
                        <asp:Button ID="btnFiltrarLegajo" runat="server" Text="Filtrar" Width="116px" />
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField HeaderText="Id Turno"></asp:TemplateField>
                                <asp:TemplateField HeaderText="Legajo Medico"></asp:TemplateField>
                                <asp:TemplateField HeaderText="DNI Paciente"></asp:TemplateField>
                                <asp:TemplateField HeaderText="Fecha"></asp:TemplateField>
                                <asp:TemplateField HeaderText="Especialidad"></asp:TemplateField>
                                <asp:TemplateField HeaderText="Asistencia"></asp:TemplateField>
                                <asp:TemplateField HeaderText="Observacion"></asp:TemplateField>
                                <asp:ButtonField ButtonType="Button" CommandName="Select" Text="Seleccionar Turno" />
                            </Columns>
                        </asp:GridView>
                    </td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
