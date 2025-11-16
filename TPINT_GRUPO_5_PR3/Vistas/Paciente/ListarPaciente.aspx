<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListarPaciente.aspx.cs" Inherits="TPINT_GRUPO_5_PR3.Vistas.ListarPaciente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Listar Paciente</title>
    <link rel="stylesheet" href="../Estilos/ListarPaciente.css" />
    <link rel="stylesheet" href="../Estilos/NavBar.css" />
    <link rel="stylesheet" href="../Estilos/Base.css" />
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
            <asp:Label ID="lblTitulo" runat="server" Text="Listado de pacientes"></asp:Label>  

            <section class="separador">
                <p>Buscar Paciente:</p>
                <asp:TextBox ID="txtboxNombrePaciente" runat="server" ValidationGroup="1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvTxtboxNombrePaciente" runat="server" ControlToValidate="txtboxNombrePaciente">* Ingrese el nombre de un paciente</asp:RequiredFieldValidator>
            </section>

            <section class="separador">
                <p>Filtrar por:</p>
                <asp:DropDownList ID="ddlFiltros" runat="server">
                    <asp:ListItem>Seleccione un filtro</asp:ListItem>
                </asp:DropDownList>
            </section>

            <asp:Button ID="btnBuscar" runat="server" Text="Buscar Paciente" ValidationGroup="1" OnClick="btnBuscar_Click" />

            <section id="tablaPaciente">
                <asp:GridView ID="gvPacientes" runat="server" EmptyDataText="asd" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="gvPacientes_PageIndexChanging" PageSize="8">
                    <Columns>
                         <asp:TemplateField HeaderText="DNI">
                            <ItemTemplate>
                                 <asp:Label ID="lbl_it_dni" runat="server" Text='<%# Bind("DNI_Pac") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>

                         <asp:TemplateField HeaderText="Nombre">
                             <ItemTemplate>
                                 <asp:Label ID="lbl_it_nombre" runat="server" Text='<%# Bind("Nombre_Pac") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>

                         <asp:TemplateField HeaderText="Apellido">
                             <ItemTemplate>
                                 <asp:Label ID="lbl_it_apellido" runat="server" Text='<%# Bind("Apellido_Pac") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>

                         <asp:TemplateField HeaderText="Sexo">
                             <ItemTemplate>
                                 <asp:Label ID="lbl_it_sexo" runat="server" Text='<%# Bind("Sexo_Pac") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>

                         <asp:TemplateField HeaderText="Nacionalidad">
                             <ItemTemplate>
                                 <asp:Label ID="lbl_it_nacion" runat="server" Text='<%# Bind("NombreNacionalidad_Nac") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>

                         <asp:TemplateField HeaderText="Fecha de Nacimiento">                        
                             <ItemTemplate>
                                 <asp:Label ID="lbl_it_nacimiento" runat="server" Text='<%# Bind("FechaNacimiento_Pac") %>' OnDataBinding="lbl_it_nacimiento_DataBinding"></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>

                         <asp:TemplateField HeaderText="Dirección">
                             <ItemTemplate>
                                 <asp:Label ID="lbl_it_direccion" runat="server" Text='<%# Bind("Direccion_Pac") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>

                         <asp:TemplateField HeaderText="Localidad">
                             <ItemTemplate>
                                 <asp:Label ID="lbl_it_localidad" runat="server" Text='<%# Bind("NombreLocalidad_Loc") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>

                         <asp:TemplateField HeaderText="Provincia">
                             <ItemTemplate>
                                 <asp:Label ID="lbl_it_provincia" runat="server" Text='<%# Bind("NombreProvincia_Prov") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>

                         <asp:TemplateField HeaderText="Tipo de Sangre">
                             <ItemTemplate>
                                 <asp:Label ID="lbl_it_sangre" runat="server" Text='<%# Bind("TipoSangre_Pac") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>

                         <asp:TemplateField HeaderText="Correo Electrónico">
                             <ItemTemplate>
                                 <asp:Label ID="lbl_it_email" runat="server" Text='<%# Bind("CorreoElectronico_Pac") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>

                         <asp:TemplateField HeaderText="Teléfono">
                             <ItemTemplate>
                                 <asp:Label ID="lbl_it_celu" runat="server" Text='<%# Bind("Telefono_Pac") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </section>

        </main>
                
    </form>
</body>
</html>
