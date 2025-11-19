using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

                if (Session["TipoUsuario"] == null)
                {
                    Response.Redirect("Inicio.aspx");
                    return;
                }

                CargarPacientes();
            }
        }
        private void CargarPacientes()
        {
            DataTable tablaPaciente = neg.listarPacientesActivos();
            gvPacientes.DataSource = tablaPaciente;
            gvPacientes.DataBind();
        }
        private void CargarPacientes(string nombre, string orden, string filtroTSangre)
        {
            DataTable tablaPaciente = neg.listarPacientesActivos(nombre, orden, filtroTSangre);
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
            CargarPacientes(txtboxNombrePaciente.Text, ddlOrdenados.SelectedValue, ddlTipoSangre.SelectedValue);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombre = txtboxNombrePaciente.Text;
            string orden = ddlOrdenados.SelectedValue;
            string filtroTSangre = ddlTipoSangre.SelectedValue;

            bool pacienteExiste = neg.existeNombrePaciente(nombre);
            if (pacienteExiste)
            {
                gvPacientes.DataSource = neg.listarPacientesActivos(nombre, orden, filtroTSangre);
                gvPacientes.DataBind();
            }
            else
            {
                lblMensaje.Text = "No existen pacientes registrados con esos datos";
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();

            Response.Redirect("Login.aspx");
        }
    }
}