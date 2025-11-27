<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TurnosDelDia.aspx.cs" Inherits="TPINT_GRUPO_5_PR3.Vistas.Turno.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 20px;
        }
        .auto-style3 {
            height: 122px;
        }
* {
    margin: 0;
    padding: 0;
    box-sizing: border-box;
    font-family: 'Segoe UI', Roboto, Helvetica, Arial, sans-serif;
}

    table th {
        background-color: #1d6fa5;
        color: white;
        padding: 12px;
        font-weight: 600;
        font-size: 1rem;
        border-bottom: 2px solid #155b83;
    }

        .gvTurnos {}
        .auto-style4 {
            width: 10px;
        }
        .auto-style5 {
            height: 122px;
            width: 10px;
        }
        .auto-style6 {
            height: 20px;
            width: 10px;
        }
        .auto-style7 {
            width: 1130px;
        }
        .auto-style8 {
            height: 122px;
            width: 1130px;
        }
        .auto-style9 {
            height: 20px;
            width: 1130px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style7">
                    <asp:Label ID="Label1" runat="server" Text="Turnos del Día"></asp:Label>
                </td>
                <td class="auto-style4">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="lblUsuarioTurnosDelDia" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8">


            <asp:GridView ID="gvListarTurnosDelDia" runat="server" AutoGenerateColumns="False" CssClass="gvTurnos" Width="1021px">
                <Columns>
                    <asp:TemplateField HeaderText="Id Turno">
                        <ItemTemplate>
                            <asp:Label ID="lblIdTurno" runat="server" Text='<%# Bind("IdTurno_Tur") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtIdTurno" runat="server" Text='<%# Bind("IdTurno_Tur") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Legajo Medico">
                        <ItemTemplate>
                            <asp:Label ID="lblLegajoMedico" runat="server" Text='<%# Bind("LegajoMedico_Tur") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtLegajoMedico" runat="server" Text='<%# Bind("LegajoMedico_Tur") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="DNI Paciente">
                        <ItemTemplate>
                            <asp:Label ID="lblDNIPaciente" runat="server" Text='<%# Bind("DNIPaciente_Tur") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtDNIPaciente" runat="server" Text='<%# Bind("DNIPaciente_Tur") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Fecha">
                        <ItemTemplate>
                            <asp:Label ID="lblFecha" runat="server" Text='<%# Bind("Fecha_Tur") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtFecha" runat="server" Text='<%# Bind("Fecha_Tur") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Asistencia">
                        <ItemTemplate>
                            <asp:Label ID="lblAsistencia" runat="server" Text='<%# Bind("Asistencia_Tur") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtAsistencia" runat="server" Text='<%# Bind("Asistencia_Tur") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Observacion">
                        <ItemTemplate>
                            <asp:Label ID="lblObservacion" runat="server" Text='<%# Bind("Observacion_Tur") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtObservacion" runat="server" Text='<%# Bind("Observacion_Tur") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>

                </td>
                <td class="auto-style5"></td>
                <td class="auto-style3"></td>
                <td class="auto-style3"></td>
                <td class="auto-style3"></td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style9"></td>
                <td class="auto-style6"></td>
                <td class="auto-style2"></td>
                <td class="auto-style2"></td>
                <td class="auto-style2"></td>
            </tr>
        </table>
    </form>
</body>
</html>
