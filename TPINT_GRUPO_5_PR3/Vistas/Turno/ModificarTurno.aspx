<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificarTurno.aspx.cs" Inherits="TPINT_GRUPO_5_PR3.Vistas.Turno.ModificarTurno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 22px;
        }
        .auto-style3 {
            height: 22px;
            width: 343px;
        }
        .auto-style4 {
            width: 343px;
        }
        .auto-style5 {
            width: 343px;
            height: 23px;
        }
        .auto-style6 {
            height: 23px;
        }
        .auto-style7 {
            height: 22px;
            width: 136px;
        }
        .auto-style8 {
            width: 136px;
        }
        .auto-style9 {
            height: 23px;
            width: 136px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lblModificarTurno" runat="server" Font-Bold="True" Font-Size="Larger" Text="Modificar Turno"></asp:Label>
                </td>
                <td class="auto-style7"></td>
                <td class="auto-style2"></td>
                <td class="auto-style2"></td>
                <td class="auto-style2"></td>
                <td class="auto-style2"></td>
                <td class="auto-style2"></td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style8">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">Buscar por id turno:<asp:TextBox ID="txtIdTurno" runat="server"></asp:TextBox>
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                </td>
                <td class="auto-style8">
                    <asp:RegularExpressionValidator ID="rev_txtIdTurno" runat="server" ControlToValidate="txtIdTurno" ErrorMessage="Solo se admiten numeros" ForeColor="Red" ValidationExpression="^[0-9 ]+$"></asp:RegularExpressionValidator>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfv_txtIdTurno" runat="server" ControlToValidate="txtIdTurno" ErrorMessage="Ingrese un ID" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5"></td>
                <td class="auto-style9"></td>
                <td class="auto-style6"></td>
                <td class="auto-style6"></td>
                <td class="auto-style6"></td>
                <td class="auto-style6"></td>
                <td class="auto-style6"></td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style8">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style8">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:GridView ID="gvTurnos" runat="server" AllowPaging="True" AutoGenerateColumns="False" AutoGenerateEditButton="True" OnPageIndexChanging="gvTurnos_PageIndexChanging" OnRowDataBound="gvTurnos_RowDataBound" OnRowUpdating="gvTurnos_RowUpdating" PageSize="5" OnRowCancelingEdit="gvTurnos_RowCancelingEdit" OnRowEditing="gvTurnos_RowEditing">
                        <Columns>
                            <asp:TemplateField HeaderText="ID">
                                <EditItemTemplate>
                                    <asp:Label ID="lbl_eit_idTurno" runat="server" Text='<%# Eval("IdTurno_Tur") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl_it_idTurno" runat="server" Text='<%# Bind("IdTurno_Tur") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fecha">
                                <EditItemTemplate>
                                    <asp:Calendar ID="cl_eit_fechaTur" runat="server"></asp:Calendar>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl_it_fechaTur" runat="server" Text='<%# Bind("Fecha_Tur") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Legajo Medico">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddl_eit_legajoMedico" runat="server">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl_it_legajoMedico" runat="server" Text='<%# Bind("LegajoMedico_Tur") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DNI Paciente">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_eit_DNIPac" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl_it_DNIPac" runat="server" Text='<%# Bind("DNIPaciente_Tur") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Asistencia">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddl_eit_asistencia" runat="server">
                                        <asp:ListItem Value="1">Confirmado</asp:ListItem>
                                        <asp:ListItem Value="2">Pendiente</asp:ListItem>
                                        <asp:ListItem Value="3">Cancelado</asp:ListItem>
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl_it_asistencia" runat="server" Text='<%# Bind("Asistencia_Tur") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Observaciones">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_eit_observacion" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl_it_observacion" runat="server" Text='<%# Bind("Observacion_Tur") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
                <td class="auto-style8">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <div>
            <asp:Label ID="lblConfirmacion" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
