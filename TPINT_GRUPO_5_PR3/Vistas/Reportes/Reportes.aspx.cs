using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPINT_GRUPO_5_PR3.Vistas.Reportes
{
    public partial class Reportes : System.Web.UI.Page
    {
        NegocioMedico negMedico = new NegocioMedico();
        NegocioReporte negReporte = new NegocioReporte();
        NegocioEspecialidad negEspecialidad = new NegocioEspecialidad();
        NegocioTurno negTurno = new NegocioTurno();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = Session["usuario"]?.ToString();

            if (Session["TipoUsuario"] == null)
            {
                Response.Redirect("~/Vistas/Inicio.aspx");
            }

            if (!IsPostBack)
            {
                Session["especialidadABuscar"] = "Todos";
                Session["legajoABuscar"] = "LegajoMedico_Turno";
                Session["fechaIABuscar"] = "";
                Session["fechaFABuscar"] = "";
                Session["asistenciaABuscar"] = "Todos";

                cargarEspecialidades();
                cargarTurnos();
            }

        }

        private void cargarEspecialidades()
        {
            DataTable dataTableEsp = negEspecialidad.getTabla();
            ddlEspecialidad.DataSource = dataTableEsp;
            ddlEspecialidad.DataTextField = "NombreEspecialidad_Esp";
            ddlEspecialidad.DataValueField = "IdEspecialidad_Esp";
            ddlEspecialidad.DataBind();
            ddlEspecialidad.Items.Insert(0, new ListItem("Todos", "Todos"));
        }

        public void cargarMedicos()
        {
            int idEspecialidad = Convert.ToInt32(ddlEspecialidad.SelectedValue);
            ddlMedico.DataSource = negMedico.listarMedicoPorEspecialidad(idEspecialidad);
            ddlMedico.DataTextField = "NombreCompleto";
            ddlMedico.DataValueField = "Legajo_Med";
            ddlMedico.DataBind();
            ListItem item = new ListItem();
            item.Text = "Todos";
            item.Value = "LegajoMedico_Turno";
            ddlMedico.Items.Insert(0, item);
        }

        private void cargarTurnos()
        {
            string especialidad = Session["especialidadABuscar"].ToString();
            string legajo = Session["legajoABuscar"].ToString();
            string fechaI = Session["fechaIABuscar"].ToString();
            string fechaF = Session["fechaFABuscar"].ToString();
            string asistencia = Session["asistenciaABuscar"].ToString();


            string turnosTotales = negTurno.ObtenerCantidadTurnos(legajo, "", especialidad, asistencia, fechaI, fechaF).Rows[0]["Total"].ToString();
            lblTurnosTotal.Text = turnosTotales;

            int porcentajeAsistencia = negTurno.obtenerPorcentajeAsistencia(legajo, "", especialidad, asistencia, fechaI, fechaF);
            
            lblTurnosPres.Text = porcentajeAsistencia.ToString();
            
            if(turnosTotales == "0") 
            {
                lblTurnosAu.Text = "0";
            }
            else lblTurnosAu.Text = (100 - porcentajeAsistencia).ToString();


            gvTurnos.DataSource = negTurno.ObtenerTablaTurnos(legajo, "", especialidad, asistencia, fechaI, fechaF);
            gvTurnos.DataBind();
        }

        protected void ddlMedicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Carga los turnos de 1 medico o la especialidad en gral.
            Session["legajoABuscar"] = ddlMedico.SelectedValue;
            gvTurnos.PageIndex = 0;
            cargarTurnos();
        }


        protected void ddlEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Carga la DDLMedicos o la limpia
            if (ddlEspecialidad.SelectedValue != "Todos")
            {
                cargarMedicos();
            }
            else
            {
                ddlMedico.Items.Clear();
            }

            // Carga los turnos de una especialidad o todas.
            gvTurnos.PageIndex = 0;
            Session["especialidadABuscar"] = ddlEspecialidad.SelectedItem.Text;
            cargarTurnos();
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();

            Response.Redirect("~/Vistas/Login.aspx");
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Session["fechaIABuscar"] = txtFechaI.Text;
            Session["fechaFABuscar"] = txtFechaF.Text;
            gvTurnos.PageIndex = 0;
            cargarTurnos();
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Session["especialidadABuscar"] = "Todos";
            Session["legajoABuscar"] = "LegajoMedico_Turno";
            Session["fechaIABuscar"] = "";
            Session["fechaFABuscar"] = "";
            Session["asistenciaABuscar"] = "Todos";

            ddlEspecialidad.SelectedIndex = 0;
            txtFechaI.Text = string.Empty;
            txtFechaF.Text = string.Empty;

            cargarTurnos();
        }

        protected void lbl_it_fecha_DataBinding(object sender, EventArgs e)
        {
            DateTime fecha = DateTime.Parse(((Label)sender).Text);
            ((Label)sender).Text = fecha.ToShortDateString();
        }

        protected void gvTurnos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTurnos.PageIndex = e.NewPageIndex;
            cargarTurnos();
        }
    }
}