using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPINT_GRUPO_5_PR3.Vistas
{
    public partial class ListarPaciente : System.Web.UI.Page
    {
        NegocioPaciente neg = new NegocioPaciente();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblUsuario.Text = Session["usuario"]?.ToString();

                Session["DNIABuscar"] = "";
                Session["apellidoABuscar"] = "";
                Session["tipoSangreABuscar"] = "Todos";
                Session["ordenABuscar"] = "DNI_Pac";

                if (Session["TipoUsuario"] == null)
                {
                    Response.Redirect("~/Vistas/Inicio.aspx");
                    return;
                }

                CargarPacientes();
            }
        }
        private void CargarPacientes()
        {
            string dni = Session["DNIABuscar"].ToString();
            string apellido = Session["apellidoABuscar"].ToString();
            string tipoSangre = Session["tipoSangreABuscar"].ToString();
            string orden = Session["ordenABuscar"].ToString();

            DataTable tablaPaciente = neg.BuscarPacientes(dni, apellido, tipoSangre, orden);
            gvPacientes.DataSource = tablaPaciente;
            gvPacientes.DataBind();
        }

        protected void lbl_it_nacimiento_DataBinding(object sender, EventArgs e)
        {
            DateTime fecha = DateTime.Parse(((Label)sender).Text);
            ((Label)sender).Text = fecha.ToShortDateString();
        }

        protected void gvPacientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPacientes.PageIndex = e.NewPageIndex;
            CargarPacientes();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            gvPacientes.PageIndex = 0;

            Session["DNIABuscar"] = txtboxDNI.Text;
            Session["apellidoABuscar"] = txtboxApellido.Text;
            Session["tipoSangreABuscar"] = ddlTipoSangre.SelectedValue;
            Session["ordenABuscar"] = ddlOrdenDeListado.SelectedValue;

            CargarPacientes();
        }
        protected void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            limpiarCampos();
            gvPacientes.PageIndex = 0;
            CargarPacientes();
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();

            Response.Redirect("~/Vistas/Login.aspx");
        }

        protected void limpiarCampos()
        {
            Session["DNIABuscar"] = "";
            Session["apellidoABuscar"] = "";
            Session["tipoSangreABuscar"] = "Todos";
            Session["ordenABuscar"] = "DNI_Pac";

            txtboxDNI.Text = string.Empty;
            txtboxApellido.Text = string.Empty;
            ddlTipoSangre.SelectedIndex = 0;
            ddlOrdenDeListado.SelectedIndex = 0;
        }

    }
}