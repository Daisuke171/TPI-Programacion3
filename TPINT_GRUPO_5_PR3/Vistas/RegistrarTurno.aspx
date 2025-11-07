<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrarTurno.aspx.cs" Inherits="TPINT_GRUPO_5_PR3.RegistrarTurno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 1117px;
            height: 258px;
            margin-right: 0px;
            margin-bottom: 78px;
        }
        .auto-style25 {
            height: 30px;
        }
        .auto-style37 {
            height: 24px;
        }
        .auto-style73 {
            width: 185px;
            height: 35px;
        }
        .auto-style74 {
            height: 35px;
            width: 186px;
        }
        .auto-style76 {
            width: 183px;
            height: 30px;
        }
        .auto-style79 {
            width: 183px;
            height: 35px;
        }
        .auto-style81 {
            width: 87px;
            height: 30px;
        }
        .auto-style84 {
            width: 87px;
            height: 35px;
        }
        .auto-style85 {
            height: 35px;
        }
        .auto-style95 {
            width: 185px;
            height: 30px;
        }
        .auto-style96 {
            width: 186px;
            height: 30px;
        }
        .auto-style97 {
            text-decoration: underline;
            text-align: left;
            width: 255px;
        }
    </style>
</head>
<body style="height: 997px; margin-bottom: 9px">
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td>
                    <h1 class="auto-style97">Registrar Turno</h1>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:HyperLink ID="hlnk_Inicio" runat="server">[hlnk_Inicio]</asp:HyperLink>
                </td>
                <td>
                    <asp:Label ID="lbl_Usuario" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style37" colspan="6">
                    <h3>Datos del Paciente</h3>
                </td>
            </tr>
            <tr>
                <td class="auto-style95">DNI:</td>
                <td class="auto-style76">
                    <asp:TextBox ID="txt_Dni" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style81">
                    <asp:Button ID="btn_buscarPaciente" runat="server" Text="Buscar paciente" />
                </td>
                <td class="auto-style96">
                    &nbsp;</td>
                <td class="auto-style96"></td>
                <td class="auto-style96"></td>
            </tr>
            <tr>
                <td class="auto-style95">Nombre:</td>
                <td class="auto-style76">
                    <asp:Label ID="lbl_Nombre" runat="server"></asp:Label>
                </td>
                <td class="auto-style81"></td>
                <td class="auto-style96"></td>
                <td class="auto-style96"></td>
                <td class="auto-style96"></td>
            </tr>
            <tr>
                <td class="auto-style95">Apellido:</td>
                <td class="auto-style76">
                    <asp:Label ID="lbl_Apellido" runat="server"></asp:Label>
                </td>
                <td class="auto-style81"></td>
                <td class="auto-style96"></td>
                <td class="auto-style96"></td>
                <td class="auto-style96"></td>
            </tr>
            <tr>
                <td class="auto-style95">Sexo:</td>
                <td class="auto-style25">
                    <asp:Label ID="lbl_Sexo" runat="server"></asp:Label>
                </td>
                <td class="auto-style25">
                </td>
                <td class="auto-style96"></td>
                <td class="auto-style96"></td>
                <td class="auto-style96"></td>
            </tr>
            <tr>
                <td class="auto-style95">Telefono</td>
                <td class="auto-style76">
                    <asp:Label ID="lbl_Telefono" runat="server"></asp:Label>
                </td>
                <td class="auto-style81"></td>
                <td class="auto-style96"></td>
                <td class="auto-style96"></td>
                <td class="auto-style96"></td>
            </tr>
            <tr>
                <td class="auto-style95">Correo electrónico</td>
                <td class="auto-style76">
                    <asp:Label ID="lbl_Correo" runat="server"></asp:Label>
                </td>
                <td class="auto-style81"></td>
                <td class="auto-style96"></td>
                <td class="auto-style96"></td>
                <td class="auto-style96"></td>
            </tr>
            <tr>
                <td class="auto-style95"></td>
                <td class="auto-style76"></td>
                <td class="auto-style81"></td>
                <td class="auto-style96"></td>
                <td class="auto-style96"></td>
                <td class="auto-style96"></td>
            </tr>
            <tr>
                <td class="auto-style85" colspan="6">
                    <h3>Datos del Turno</h3>
                </td>
            </tr>
            <tr>
                <td class="auto-style73">Especialidad:</td>
                <td class="auto-style79">
                    <asp:DropDownList ID="ddl_Especialidades" runat="server">
                    </asp:DropDownList>
                </td>
                <td class="auto-style84"></td>
                <td class="auto-style74"></td>
                <td class="auto-style74"></td>
                <td class="auto-style74"></td>
            </tr>
            <tr>
                <td class="auto-style73">Medico:</td>
                <td class="auto-style79">
                    <asp:DropDownList ID="ddl_Medicos" runat="server">
                    </asp:DropDownList>
                </td>
                <td class="auto-style84">&nbsp;</td>
                <td class="auto-style74"></td>
                <td class="auto-style74"></td>
                <td class="auto-style74"></td>
            </tr>
            <tr>
                <td class="auto-style73">Fecha:</td>
                <td class="auto-style79">&nbsp;</td>
                <td class="auto-style84">&nbsp;</td>
                <td class="auto-style74">&nbsp;</td>
                <td class="auto-style74">&nbsp;</td>
                <td class="auto-style74">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style73">
                    <asp:Calendar ID="cal_Fechas" runat="server"></asp:Calendar>
                </td>
                <td class="auto-style79">&nbsp;</td>
                <td class="auto-style84">&nbsp;</td>
                <td class="auto-style74">&nbsp;</td>
                <td class="auto-style74">&nbsp;</td>
                <td class="auto-style74">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style73">
                    <asp:RadioButtonList ID="rbtnl_Horarios" runat="server">
                    </asp:RadioButtonList>
                </td>
                <td class="auto-style79">&nbsp;</td>
                <td class="auto-style84">&nbsp;</td>
                <td class="auto-style74">&nbsp;</td>
                <td class="auto-style74">&nbsp;</td>
                <td class="auto-style74">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style73">&nbsp;</td>
                <td class="auto-style79">&nbsp;</td>
                <td class="auto-style84">&nbsp;</td>
                <td class="auto-style74">&nbsp;</td>
                <td class="auto-style74">&nbsp;</td>
                <td class="auto-style74">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style73">
                    <asp:Button ID="btn_Confirmar" runat="server" Text="Confirmar turno" />
                </td>
                <td class="auto-style79">&nbsp;</td>
                <td class="auto-style84">&nbsp;</td>
                <td class="auto-style74">&nbsp;</td>
                <td class="auto-style74">&nbsp;</td>
                <td class="auto-style74">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style73">
                    <asp:Label ID="lbl_Mensaje" runat="server"></asp:Label>
                </td>
                <td class="auto-style79">&nbsp;</td>
                <td class="auto-style84">&nbsp;</td>
                <td class="auto-style74">&nbsp;</td>
                <td class="auto-style74">&nbsp;</td>
                <td class="auto-style74">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style73">&nbsp;</td>
                <td class="auto-style79">&nbsp;</td>
                <td class="auto-style84">&nbsp;</td>
                <td class="auto-style74">&nbsp;</td>
                <td class="auto-style74">&nbsp;</td>
                <td class="auto-style74">&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
