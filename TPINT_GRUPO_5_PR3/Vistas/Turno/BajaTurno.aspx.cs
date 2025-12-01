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

                Session["DNIABuscar"] = "";
                cargarTurnos();
            }
        }

        public void cargarTurnos()
        {
            string dni = Session["DNIABuscar"].ToString();

            gvTurnos.DataSource = negTurnos.ObtenerTurnosPorPaciente("", dni);
            gvTurnos.DataBind();
        }

        protected void gvTurnos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            limpiarConfirmacion();
            int idTurno = Convert.ToInt32(((Label)gvTurnos.Rows[e.RowIndex].FindControl("lbl_it_id")).Text);
            if (negTurnos.borrarTurno(idTurno))
            {
                limpiarCampos();
                gvTurnos.PageIndex = 0;
                lblConfirmacion.Text = "Baja de turno confirmada";
                lblConfirmacion.ForeColor = Color.Green;
            }
            else
            {
                lblConfirmacion.Text = "Hubo un  error al dar de baja el turno";
                lblConfirmacion.ForeColor = Color.Red;
            }

            cargarTurnos();
        }

        protected void btnBuscar_Click1(object sender, EventArgs e)
        {
            limpiarConfirmacion();
            Session["DNIABuscar"] = txtDni.Text;
            cargarTurnos();
        }

        protected void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            limpiarConfirmacion();
            limpiarCampos();
            gvTurnos.PageIndex = 0;
            cargarTurnos();
        }

        protected void gvTurnos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            limpiarConfirmacion();
            gvTurnos.PageIndex = e.NewPageIndex;
            cargarTurnos();
        }

        protected void limpiarCampos()
        {
            txtDni.Text = string.Empty;
            Session["DNIABuscar"] = "";
        }

        protected void limpiarConfirmacion()
        {
            lblConfirmacion.Text = string.Empty;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();

            Response.Redirect("~/Vistas/Login.aspx");
        }

        protected void lbl_it_fecha_DataBinding(object sender, EventArgs e)
        {
            DateTime fecha = DateTime.Parse(((Label)sender).Text);
            ((Label)sender).Text = fecha.ToShortDateString();
        }
    }
}