<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificarPaciente.aspx.cs" Inherits="TPINT_GRUPO_5_PR3.Vistas.WebForm5" %>

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
            width: 255px;
        }
        .auto-style4 {
            width: 177px;
        }
        .auto-style5 {
            width: 10px;
        }
        .auto-style6 {
            width: 5px;
        }
        .auto-style7 {
            width: 4px;
        }
        .auto-style8 {
            width: 10px;
            height: 10px;
        }
        .auto-style9 {
            height: 10px;
        }
        .auto-style10 {
            width: 4px;
            height: 10px;
        }
        .auto-style11 {
            width: 5px;
            height: 10px;
        }
        .auto-style12 {
            width: 255px;
            height: 10px;
        }
        .auto-style13 {
            width: 177px;
            height: 10px;
        }
        .auto-style26 {
            width: 10px;
            height: 40px;
        }
        .auto-style27 {
            height: 40px;
        }
        .auto-style28 {
            width: 4px;
            height: 40px;
        }
        .auto-style29 {
            width: 5px;
            height: 40px;
        }
        .auto-style30 {
            width: 255px;
            height: 40px;
        }
        .auto-style31 {
            width: 177px;
            height: 40px;
        }
        .auto-style32 {
            width: 69px;
        }
        .auto-style33 {
            height: 10px;
            width: 69px;
        }
        .auto-style34 {
            height: 40px;
            width: 69px;
        }
        .auto-style35 {
            margin-left: 0px;
        }
        .auto-style36 {
            width: 133px;
        }
        .auto-style37 {
            height: 10px;
            width: 133px;
        }
        .auto-style38 {
            height: 40px;
            width: 133px;
        }
        .auto-style39 {
            width: 28px;
        }
        .auto-style40 {
            height: 10px;
            width: 28px;
        }
        .auto-style41 {
            height: 40px;
            width: 28px;
        }
        .auto-style42 {
            width: 10px;
            height: 23px;
        }
        .auto-style43 {
            height: 23px;
        }
        .auto-style44 {
            width: 4px;
            height: 23px;
        }
        .auto-style45 {
            width: 5px;
            height: 23px;
        }
        .auto-style46 {
            width: 255px;
            height: 23px;
        }
        .auto-style47 {
            width: 133px;
            height: 23px;
        }
        .auto-style48 {
            width: 28px;
            height: 23px;
        }
        .auto-style49 {
            width: 177px;
            height: 23px;
        }
        .auto-style50 {
            width: 69px;
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style36">&nbsp;</td>
                    <td class="auto-style39">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style32">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>
                    <asp:Label ID="lbl_Usuario" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style36">&nbsp;</td>
                    <td class="auto-style39">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td class="auto-style4">
                        <asp:Label ID="labelAltaPaciente" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="X-Large" Text="Modificar Paciente"></asp:Label>
                    </td>
                    <td class="auto-style32">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>
                    <asp:HyperLink ID="hlnk_Inicio" runat="server" NavigateUrl="~/Vistas/Inicio.aspx">Inicio</asp:HyperLink>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style2">Usuario:
                        <asp:Label ID="labelUsuarioRegistrado" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style36">&nbsp;</td>
                    <td class="auto-style39">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style32">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style8"></td>
                    <td class="auto-style9"></td>
                    <td class="auto-style10"></td>
                    <td class="auto-style11"></td>
                    <td class="auto-style12"></td>
                    <td class="auto-style37"></td>
                    <td class="auto-style40"></td>
                    <td class="auto-style9"></td>
                    <td class="auto-style13"></td>
                    <td class="auto-style33"></td>
                    <td class="auto-style9"></td>
                    <td class="auto-style9"></td>
                    <td class="auto-style9"></td>
                    <td class="auto-style9"></td>
                    <td class="auto-style9"></td>
                    <td class="auto-style9"></td>
                    <td class="auto-style9"></td>
                    <td class="auto-style9"></td>
                    <td class="auto-style9"></td>
                    <td class="auto-style9"></td>
                </tr>
                <tr>
                    <td class="auto-style26"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style28"></td>
                    <td class="auto-style29"></td>
                    <td class="auto-style30">DNI: </td>
                    <td class="auto-style38">
                        <asp:Label ID="lblDNIActual" runat="server" Text="DNI actual"></asp:Label>
                    </td>
                    <td class="auto-style41"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style31">
                        <asp:TextBox ID="txtBoxDNI" runat="server" BorderStyle="Solid" Width="163px"></asp:TextBox>
                    </td>
                    <td class="auto-style34"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                </tr>
                <tr>
                    <td class="auto-style26"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style28"></td>
                    <td class="auto-style29"></td>
                    <td class="auto-style30">Nombre:</td>
                    <td class="auto-style38">
                        <asp:Label ID="lblNombreActual" runat="server" Text="Nombre Actual"></asp:Label>
                    </td>
                    <td class="auto-style41"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style31">
                        <asp:TextBox ID="txtBoxNombre" runat="server" BorderStyle="Solid" Width="161px"></asp:TextBox>
                    </td>
                    <td class="auto-style34"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                </tr>
                <tr>
                    <td class="auto-style26"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style28"></td>
                    <td class="auto-style29"></td>
                    <td class="auto-style30">Apellido:</td>
                    <td class="auto-style38">
                        <asp:Label ID="lblApellidoActual" runat="server" Text="Apellido Actual"></asp:Label>
                    </td>
                    <td class="auto-style41"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style31">
                        <asp:TextBox ID="txtBoxApellido" runat="server" BorderStyle="Solid" Width="164px"></asp:TextBox>
                    </td>
                    <td class="auto-style34"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                </tr>
                <tr>
                    <td class="auto-style26"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style28"></td>
                    <td class="auto-style29"></td>
                    <td class="auto-style30">Sexo:</td>
                    <td class="auto-style38">
                        <asp:Label ID="lblSexoActual" runat="server" Text="Sexo Actual"></asp:Label>
                    </td>
                    <td class="auto-style41"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style31">
                        <asp:DropDownList ID="ddlSexo" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style34"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                </tr>
                <tr>
                    <td class="auto-style26"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style28"></td>
                    <td class="auto-style29"></td>
                    <td class="auto-style30">Nacionalidad:</td>
                    <td class="auto-style38">
                        <asp:Label ID="lblNacionalidadActual" runat="server" Text="Nacionalidad Actual"></asp:Label>
                    </td>
                    <td class="auto-style41"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style31">
                        <asp:DropDownList ID="ddlNacionalidad" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style34"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                </tr>
                <tr>
                    <td class="auto-style26"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style28"></td>
                    <td class="auto-style29"></td>
                    <td class="auto-style30">Fecha de Nacimiento (DD-MM-AAAA)</td>
                    <td class="auto-style38">
                        <asp:Label ID="lblFechaNacimientoActual" runat="server" Text="Fecha de Nacimiento Actual"></asp:Label>
                    </td>
                    <td class="auto-style41"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style31">
                        <asp:TextBox ID="txtBoxFecha" runat="server" BorderStyle="Solid" Width="162px"></asp:TextBox>
                    </td>
                    <td class="auto-style34"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                </tr>
                <tr>
                    <td class="auto-style26"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style28"></td>
                    <td class="auto-style29"></td>
                    <td class="auto-style30">Dirección:</td>
                    <td class="auto-style38">
                        <asp:Label ID="lblDireccionActual" runat="server" Text="Direccion Actual"></asp:Label>
                    </td>
                    <td class="auto-style41"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style31">
                        <asp:TextBox ID="txtBoxDirecc" runat="server" BorderStyle="Solid" Width="162px"></asp:TextBox>
                    </td>
                    <td class="auto-style34"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                </tr>
                <tr>
                    <td class="auto-style26"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style28"></td>
                    <td class="auto-style29"></td>
                    <td class="auto-style30">Localidad:</td>
                    <td class="auto-style38">
                        <asp:Label ID="lblLocalidadActual" runat="server" Text="Localidad Actual"></asp:Label>
                    </td>
                    <td class="auto-style41"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style31">
                        <asp:DropDownList ID="ddlLocalidad" runat="server" Height="20px">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style34"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                </tr>
                <tr>
                    <td class="auto-style26"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style28"></td>
                    <td class="auto-style29"></td>
                    <td class="auto-style30">Provincia:</td>
                    <td class="auto-style38">
                        <asp:Label ID="lblProvinciaActual" runat="server" Text="Provincia Actual"></asp:Label>
                    </td>
                    <td class="auto-style41"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style31">
                        <asp:DropDownList ID="ddlProvincia" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style34"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                </tr>
                <tr>
                    <td class="auto-style26"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style28"></td>
                    <td class="auto-style29"></td>
                    <td class="auto-style30">Tipo de Sangre: </td>
                    <td class="auto-style38">
                        <asp:Label ID="lblTipoSangreActual" runat="server" Text="Tipo de Sangre Actual"></asp:Label>
                    </td>
                    <td class="auto-style41"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style31">
                        <asp:DropDownList ID="ddlTipoSangre1" runat="server" Width="85px">
                        </asp:DropDownList>
&nbsp;
                        <asp:DropDownList ID="ddlTipoSangre2" runat="server" CssClass="auto-style35" Width="75px">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style34">&nbsp;</td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                </tr>
                <tr>
                    <td class="auto-style26"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style28"></td>
                    <td class="auto-style29"></td>
                    <td class="auto-style30">Correo Electrónico:</td>
                    <td class="auto-style38">
                        <asp:Label ID="lblCorreoElectronicoActual" runat="server" Text="Correo Actual"></asp:Label>
                    </td>
                    <td class="auto-style41"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style31">
                        <asp:TextBox ID="txtBoxCorreo" runat="server" BorderStyle="Solid" Width="165px"></asp:TextBox>
                    </td>
                    <td class="auto-style34"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                </tr>
                <tr>
                    <td class="auto-style26"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style28"></td>
                    <td class="auto-style29"></td>
                    <td class="auto-style30">Teléfono:</td>
                    <td class="auto-style38">
                        <asp:Label ID="lblNumeroActual" runat="server" Text="Numero Actual"></asp:Label>
                    </td>
                    <td class="auto-style41"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style31">
                        <asp:TextBox ID="txtBoxTelefono" runat="server" BorderStyle="Solid" Width="165px"></asp:TextBox>
                    </td>
                    <td class="auto-style34"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style36">&nbsp;</td>
                    <td class="auto-style39">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style32">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style2">
                        <asp:Button ID="btnGuardarCambios" runat="server" Text="Guardar Cambios" />
                    </td>
                    <td class="auto-style36">&nbsp;</td>
                    <td class="auto-style39">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style32">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style42"></td>
                    <td class="auto-style43"></td>
                    <td class="auto-style44"></td>
                    <td class="auto-style45"></td>
                    <td class="auto-style46"></td>
                    <td class="auto-style47"></td>
                    <td class="auto-style48"></td>
                    <td class="auto-style43"></td>
                    <td class="auto-style49"></td>
                    <td class="auto-style50"></td>
                    <td class="auto-style43"></td>
                    <td class="auto-style43"></td>
                    <td class="auto-style43"></td>
                    <td class="auto-style43"></td>
                    <td class="auto-style43"></td>
                    <td class="auto-style43"></td>
                    <td class="auto-style43"></td>
                    <td class="auto-style43"></td>
                    <td class="auto-style43"></td>
                    <td class="auto-style43"></td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style36">&nbsp;</td>
                    <td class="auto-style39">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style32">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
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
