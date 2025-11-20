<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListarMedico.aspx.cs" Inherits="TPINT_GRUPO_5_PR3.Vistas.ListarMedico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Listar Medico</title>
    <link rel="stylesheet" href="../Estilos/NavBar.css" />
    <link rel="stylesheet" href="../Estilos/Base.css" />
    <link rel="stylesheet" href="../Estilos/ListarMedico.css" />
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
            <asp:Label ID="lblTitulo" runat="server" Text="Listado de medicos"></asp:Label>

            <section class="separador">
                <p>Buscar Medico:</p>
                <asp:TextBox ID="txtboxNombreMedico" runat="server" ValidationGroup="1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvTxtboxNombrePaciente" runat="server" ErrorMessage="* Ingrese el nombre de un paciente" ControlToValidate="txtboxNombrePaciente" Visible="False"></asp:RequiredFieldValidator>
            </section>

            <section class="separador">
                <p>Filtrar por:</p>
                <asp:DropDownList ID="ddlFiltros" runat="server">
                    <asp:ListItem>Seleccione un filtro</asp:ListItem>
                    <asp:ListItem>Legajo</asp:ListItem>
                    <asp:ListItem>Nombre</asp:ListItem>
                </asp:DropDownList>
            </section>

            <asp:Button ID="btnBuscar" runat="server" Text="Buscar Medico" ValidationGroup="1" OnClick="btnBuscar_Click" />

            <section id="tablaMedico">
                <asp:GridView ID="gvMedico" runat="server" EmptyDataText="asd" AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField HeaderText="Legajo">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_Legajo" runat="server" Text='<%# Bind("Legajo_Med") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="DNI">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_DNI" runat="server" Text='<%# Bind("DNI_Med") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nombre">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_Nombre" runat="server" Text='<%# Bind("Nombre_Med") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Apellido">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_Apellido" runat="server" Text='<%# Bind("Apellido_Med") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sexo">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_Sexo" runat="server" Text='<%# Bind("Sexo_Med") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Teléfono">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_telefono" runat="server" Text='<%# Bind("Telefono_Med") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nacionalidad">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_Nacionalidad" runat="server" Text='<%# Bind("NombreNacionalidad_Nac") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fecha Nacimiento">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_FechaNacimiento" runat="server" Text='<%# Bind("FechaNaciemiento_Med") %>' OnDataBinding="lbl_it_nacimiento_DataBinding"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Dirección">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_Direccion" runat="server" Text='<%# Bind("Direccion_Med") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Localidad">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_Localidad" runat="server" Text='<%# Bind("NombreLocalidad_Loc") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Provincia">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_Provincia" runat="server" Text='<%# Bind("NombreProvincia_Prov") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Correo Electrónico">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_CorreoElectronico" runat="server" Text='<%# Bind("CorreoElectronico_Med") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Especialidad">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_Especialidad" runat="server" Text='<%# Bind("NombreEspecialidad_Esp") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Estado">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_Estado" runat="server" Text='<%# Bind("Estado_Med") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                    </Columns>
                </asp:GridView>
            </section>
        </main>
    </form>
</body>
</html>
