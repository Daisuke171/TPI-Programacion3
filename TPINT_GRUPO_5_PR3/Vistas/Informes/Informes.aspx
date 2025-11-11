<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Informes.aspx.cs" Inherits="TPINT_GRUPO_5_PR3.Vistas.Informes.Informes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Informes</title>
    <link rel="stylesheet" href="../Estilos/Base.css" />
    <link rel="stylesheet" href="../Estilos/NavBar.css" />
</head>
<body>
    <form id="form1" runat="server">
        <nav>
            <div class="leftSide">
                <asp:HyperLink CssClass="hlnk_Inicio" runat="server" Text="Inicio" NavigateUrl="~/Vistas/Inicio.aspx"></asp:HyperLink>
                <asp:HyperLink CssClass="hlnk_Inicio" runat="server" Text="Pacientes" NavigateUrl="~/Vistas/HomePacientes.aspx"></asp:HyperLink>
                <asp:HyperLink CssClass="hlnk_Inicio" runat="server" Text="Medicos" NavigateUrl="~/Vistas/HomeMedicos.aspx"></asp:HyperLink>
            </div>
            <div class="rightSide">
                <asp:Label ID="lblUsuario" CssClass="lbl_Usuario" runat="server" Text="Username"></asp:Label>
                <asp:Button ID="btnLogout" runat="server" Text="Cerrar Sesion" CssClass="btn-logout" />
            </div>
        </nav>
        <main>
            <h1>Informes</h1>
            <section class="selectInforme">

            <asp:GridView ID="gvInformes" runat="server">
                <Columns>
                    <asp:TemplateField HeaderText="Filtro">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlInformes" runat="server">
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            </section>
            <aside class="imgGrafico">

            </aside>
        </main>
    </form>
</body>
</html>
