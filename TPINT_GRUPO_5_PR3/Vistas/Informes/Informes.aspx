<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Informes.aspx.cs" Inherits="TPINT_GRUPO_5_PR3.Vistas.Informes.Informes" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Informes</title>
    <link rel="stylesheet" href="../Estilos/Base.css" />
    <link rel="stylesheet" href="../Estilos/NavBar.css" />
    <link rel="stylesheet" href="../Estilos/Informes.css" />
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
                <asp:Button ID="btnLogout" runat="server" Text="Cerrar Sesion" CssClass="btn-logout" OnClick="btnLogout_Click" />
            </div>
        </nav>
        <main>
            <h1>Informes</h1>
            <section class="selectInforme">

                <%-- <asp:GridView ID="gvInformes" runat="server">
                <Columns>
                    <asp:TemplateField HeaderText="Filtro">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlInformes" runat="server">
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>--%>

                <section class="tablaInformes">
                    <asp:GridView ID="gvInformes" runat="server" AutoGenerateColumns="False" OnRowCommand="gvInformes_RowCommand">
                        <Columns>
                            <asp:ButtonField Text="Ver" CommandName="VerInforme" ButtonType="Button" />
                            <asp:BoundField DataField="Informes" HeaderText="Informes" />
                        </Columns>
                    </asp:GridView>
                </section>

                <h2>Resultado</h2>
                <section class="sectionInformes">
                    <asp:GridView ID="gvResultado" runat="server" AutoGenerateColumns="true"></asp:GridView>
                    <aside>
                        <asp:Chart ID="chInformes" runat="server" Visible="False" Width="500px" Height="350px">
                            <Series>
                                <asp:Series Name="Series1"></asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                            </ChartAreas>
                        </asp:Chart>
                    </aside>
                </section>

            </section>
           
        </main>
    </form>
</body>
</html>
