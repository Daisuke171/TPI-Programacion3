using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace TPINT_GRUPO_5_PR3.Vistas
{
    public partial class ListarMedico : System.Web.UI.Page
    {

        NegocioMedico neg = new NegocioMedico();
        NegocioEspecialidad negEspecialidad = new NegocioEspecialidad();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblUsuario.Text = Session["usuario"]?.ToString();

                if (Session["TipoUsuario"] == null)
                {
                    Response.Redirect("~/Vistas/Inicio.aspx");
                    return;
                }

                Session["legajoABuscar"] = "";
                Session["apellidoABuscar"] = "";
                Session["especialidadABuscar"] = "Todos";
                Session["ordenABuscar"] = "Legajo_Med";

                cargarMedicos();
                cargarEspecialidades();
            }
        }

        private void cargarMedicos()
        {
            string legajo = Session["legajoABuscar"].ToString();
            string apellido = Session["apellidoABuscar"].ToString();
            string especialidad = Session["especialidadABuscar"].ToString();
            string orden = Session["ordenABuscar"].ToString();

            DataTable tablaMedico = neg.buscarMedicos(legajo, apellido, especialidad, orden);
            gvMedico.DataSource = tablaMedico;
            gvMedico.DataBind();
        }

        private void cargarEspecialidades()
        {
            DataTable dtEspecialidades = negEspecialidad.getTabla();
            
            ddlEspecialidad.DataSource = dtEspecialidades;
            ddlEspecialidad.DataTextField = "NombreEspecialidad_Esp";
            ddlEspecialidad.DataValueField = "IdEspecialidad_Esp";
            ddlEspecialidad.DataBind();

            ddlEspecialidad.Items.Insert(0, new ListItem("Todos", "Todos"));
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            gvMedico.PageIndex = 0;

            Session["legajoABuscar"] = txtLegajo.Text;
            Session["apellidoABuscar"] = txtApellido.Text;

            cargarMedicos();
        }


        protected void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            limpiarCampos();
            gvMedico.PageIndex = 0;
            cargarMedicos();
        }

        protected void gvMedico_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMedico.PageIndex = e.NewPageIndex;
            cargarMedicos();
        }
        protected void lbl_it_nacimiento_DataBinding(object sender, EventArgs e)
        {
            // Conversion de la fecha para que no muestre hora (00:00:00)
            DateTime fecha = DateTime.Parse(((Label)sender).Text);
            ((Label)sender).Text = fecha.ToShortDateString();
        }

        protected void limpiarCampos()
        {
            Session["legajoABuscar"] = "";
            Session["apellidoABuscar"] = "";
            Session["especialidadABuscar"] = "Todos";
            Session["ordenABuscar"] = "Legajo_Med";

            txtLegajo.Text = string.Empty;
            txtApellido.Text = string.Empty;
            ddlEspecialidad.SelectedIndex = 0;
            ddlOrdenListado.SelectedIndex = 0;
        }

        protected void ddlOrdenListado_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvMedico.PageIndex = 0;
            Session["ordenABuscar"] = ddlOrdenListado.SelectedValue;
            cargarMedicos();
        }

        protected void ddlEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvMedico.PageIndex = 0;
            Session["especialidadABuscar"] = ddlEspecialidad.SelectedItem.Text;
            cargarMedicos();
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();

            Response.Redirect("~/Vistas/Login.aspx");
        }
    }
}