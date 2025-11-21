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
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = Session["usuario"]?.ToString();

            if (Session["TipoUsuario"] == null)
            {
                Response.Redirect("Inicio.aspx");
            }
            else
            {
                if(!IsPostBack) CargarDDLMedicos();
            }
        }

        public void CargarDDLMedicos()
        {
            ddlMedicos.DataSource = negMedico.listarMedico(true);
            ddlMedicos.DataTextField = "Apellido_Med";
            ddlMedicos.DataValueField = "Legajo_Med";
            ddlMedicos.DataBind();
            ListItem item = new ListItem();
            item.Text = "Seleccione un Medico";
            item.Value = "0";
            ddlMedicos.Items.Insert(0, item);
        }

        protected void ddlMedicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int legajo = Convert.ToInt32(ddlMedicos.SelectedValue);
            DataTable turnosPorMedico = negReporte.getCantTurnosMedicos(legajo);
            if (turnosPorMedico.Rows.Count == 0)
            {
              lblCantTurnosPorMedico.Text = "Este medico no tiene turnos actualmente";
            }
            else
            {
              lblCantTurnosPorMedico.Text = "Este medico tiene " + turnosPorMedico.Rows[0]["CantidadTurnos"].ToString() + " turnos actualmente";
            }
        }

        protected void clTurnos_SelectionChanged(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Parse(Convert.ToString(clTurnos.SelectedDate));
            DataTable turnos = negReporte.getTurnosPorFecha(dt.ToString("yyyy-M-dd"));
            gvTurnos.DataSource = turnos;
            gvTurnos.DataBind();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();

            Response.Redirect("Login.aspx");

        }
    }
}