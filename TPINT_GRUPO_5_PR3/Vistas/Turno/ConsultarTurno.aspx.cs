using Entidades;
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

    
    public partial class ConsultarTurno : System.Web.UI.Page
    {
        NegocioTurno negocioTurno = new NegocioTurno();
        NegocioUsuario negocioUsuario = new NegocioUsuario();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblUsuario.Text = Session["usuario"]?.ToString();

                if (Session["TipoUsuario"] == null)
                {
                    Response.Redirect("~/Vistas/Inicio.aspx");
                }

                Session["pacienteABuscar"] = "";
                Session["fechaIABuscar"] = "";
                Session["fechaFABuscar"] = "";
                Session["asistenciaABuscar"] = "Todos";

                cargarTurnos();
            }
        }

        private void cargarTurnos()
        {

            string paciente = Session["pacienteABuscar"].ToString();
            string fechaI = Session["fechaIABuscar"].ToString();
            string fechaF = Session["fechaFABuscar"].ToString();
            string asistencia = Session["asistenciaABuscar"].ToString();
            if (Session["TipoUsuario"].ToString() == "Admin")
            {
                gvConsultarTurnos.DataSource = negocioTurno.ObtenerTablaTurnosAdmin(paciente, "Todos", asistencia, fechaI, fechaF);
                gvConsultarTurnos.DataBind();
            }
            else 
            { 
                string legajo = Session["LegajoMedico"].ToString();
                gvConsultarTurnos.DataSource = negocioTurno.ObtenerTablaTurnos(legajo, paciente, "Todos", asistencia, fechaI, fechaF);
                gvConsultarTurnos.DataBind();
            }

            
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();

            Response.Redirect("~/Vistas/Login.aspx");
        }

        protected void gvConsultarTurnos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvConsultarTurnos.PageIndex = e.NewPageIndex;
            cargarTurnos();
        }

        protected void btnFiltrarPaciente_Click(object sender, EventArgs e)
        {
            Session["pacienteABuscar"] = txtPaciente.Text;
            gvConsultarTurnos.PageIndex = 0;
            cargarTurnos();
        }

        protected void btnFiltrarLegajo_Click(object sender, EventArgs e)
        {
            Session["fechaIABuscar"] = txtFechaInicial.Text;
            Session["fechaFABuscar"] = txtFechaFinal.Text;
            gvConsultarTurnos.PageIndex = 0;
            cargarTurnos();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["asistenciaABuscar"] = ddl_asistencia.SelectedValue;
            gvConsultarTurnos.PageIndex = 0;
            cargarTurnos();
        }

        private void limpiarCampos()
        {
            Session["pacienteABuscar"] = "";
            Session["fechaIABuscar"] = "";
            Session["fechaFABuscar"] = "";
            Session["asistenciaABuscar"] = "Todos";

            txtPaciente.Text = string.Empty;
            txtFechaInicial.Text = string.Empty;
            txtFechaFinal.Text = string.Empty;
            ddl_asistencia.SelectedIndex = 0;
        }

        protected void btnLimpiarBusqueda_Click(object sender, EventArgs e)
        {
            limpiarCampos();
            gvConsultarTurnos.PageIndex = 0;
            cargarTurnos();
        }

        protected void lbl_it_fecha_DataBinding(object sender, EventArgs e)
        {
            DateTime fecha = DateTime.Parse(((Label)sender).Text);
            ((Label)sender).Text = fecha.ToShortDateString();
        }
    }
}