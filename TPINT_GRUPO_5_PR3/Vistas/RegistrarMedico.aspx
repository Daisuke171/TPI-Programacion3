<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrarMedico.aspx.cs" Inherits="TPINT_GRUPO_5_PR3.Vistas.WebForm1" %>

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
            width: 756px;
        }
        .auto-style3 {
            width: 151px;
        }
        .auto-style4 {
            width: 170px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2" colspan="2">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>
                        <asp:Label ID="lblNombreUsuarioActual" runat="server" Text="Username"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2" colspan="2">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2" colspan="2">
                        <asp:Label ID="lblRegistrarMedico" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Registrar Medico"></asp:Label>
                    </td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2" colspan="2">
                        <asp:Label ID="lblTxtDatos" runat="server" Text="Ingresar Los siguientes Datos"></asp:Label>
                    </td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2" colspan="2">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2" colspan="2">
                        <asp:Label ID="lblDNI" runat="server" Text="DNI: "></asp:Label>
                    </td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2" colspan="2">
                        <asp:Label ID="lblNombre" runat="server" Text="Nombre: "></asp:Label>
                    </td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2" colspan="2">
                        <asp:Label ID="lblApellido" runat="server" Text="Apellido: "></asp:Label>
                    </td>
                    <td class="auto-style4" rowspan="2">&nbsp;</td>
                    <td rowspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2" colspan="2">
                        <asp:Label ID="lblCorreoElectronico" runat="server" Text="Correo Electronico: "></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="lblSexo" runat="server" Text="Sexo:  "></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:DropDownList ID="DropDownList1" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="lblNacionalidad" runat="server" Text="Nacionalidad: "></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:DropDownList ID="DropDownList2" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha de Nacimiento: "></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
                    </td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2" colspan="2">
                        <asp:Label ID="lblDireccion" runat="server" Text="Direccion: "></asp:Label>
                    </td>
                    <td class="auto-style4" rowspan="3">&nbsp;</td>
                    <td rowspan="3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="lblEspecialidad" runat="server" Text="Especialidad: "></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:DropDownList ID="DropDownList4" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2" colspan="2">
                        <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
