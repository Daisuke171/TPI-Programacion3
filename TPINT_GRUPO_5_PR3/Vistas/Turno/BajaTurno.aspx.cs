using Negocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPINT_GRUPO_5_PR3.Vistas.Turno
{
	public partial class BajaTurno : System.Web.UI.Page
	{
        NegocioTurno negTurnos = new NegocioTurno();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblUsuario.Text = Session["usuario"]?.ToString();

                if (Session["TipoUsuario"] == null)
                {
                    Response.Redirect("~/Vistas/Inicio.aspx");
                }
                CargarGridView();
            }
        }

        public void CargarGridView()
        {
            gvTurnos.DataSource = negTurnos.ObtenerTablaTurnos();
            gvTurnos.DataBind();
        }

        protected void gvTurnos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idTurno = Convert.ToInt32(((Label)gvTurnos.Rows[e.RowIndex].FindControl("lbl_it_id")).Text);
            if (negTurnos.borrarTurno(idTurno))
            {
                lblConfirmacion.Text = "Baja de turno confirmada";
                lblConfirmacion.ForeColor = Color.Green;
            }
            else
            {
                lblConfirmacion.Text = "Hubo un  error al dar de baja el turno";
                lblConfirmacion.ForeColor = Color.Red;
            }
            CargarGridView();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            gvTurnos.DataSource = negTurnos.obtenerTurnoPorDni(Convert.ToInt32(txtDni.Text.Trim()));
            lblError.Text = txtDni.Text.ToString();
            gvTurnos.DataBind();
        }

        protected void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            gvTurnos.PageIndex = 0;
            CargarGridView();
        }

        protected void gvTurnos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTurnos.PageIndex = e.NewPageIndex;
            CargarGridView();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();

            Response.Redirect("~/Vistas/Login.aspx");
        }
    }
}