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

namespace TPINT_GRUPO_5_PR3.Vistas
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        NegocioMedico negMedico = new NegocioMedico();  
        NegocioUsuario negUsuario = new NegocioUsuario();
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
                cargarMedicos();
            }
        }

        private void cargarMedicos()
        {
            string legajo = Session["legajoABuscar"].ToString();
            DataTable dt = negMedico.buscarMedicos(legajo);
            gvMedico.DataSource = dt;
            gvMedico.DataBind();
        }

        protected void gvMedico_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int legajo = Convert.ToInt32(((Label)gvMedico.Rows[e.RowIndex].FindControl("lbl_it_legajo")).Text);

            ViewState["LegajoAEliminar"] = legajo;

            confirmModal.Visible = true;

            e.Cancel = true;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();

            Response.Redirect("~/Vistas/Login.aspx");
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            
            if (ViewState["LegajoAEliminar"] != null)
            {
                limpiarConfirmacion();

                int legajo = Convert.ToInt32(ViewState["LegajoAEliminar"]);

                if (negMedico.bajaMedico(legajo))
                {
                    lbl_confirmacion.ForeColor = Color.Green;
                    lbl_confirmacion.Text = "Médico eliminado exitosamente ";
                }
                else
                {
                    lbl_confirmacion.ForeColor = Color.Red;
                    lbl_confirmacion.Text = "Error al eliminar el médico. ";
                }

                if (negUsuario.borrarUsuarioMedico(legajo))
                {
                    lbl_confirmacion.ForeColor = Color.Green;
                    lbl_confirmacion.Text += "Y Usuario asociado eliminado exitosamente.";
                }
                else
                {
                    lbl_confirmacion.ForeColor = Color.Red;
                    lbl_confirmacion.Text += "Pero error al eliminar el usuario asociado.";
                }

                // limpiar
                ViewState["LegajoAEliminar"] = null;
                confirmModal.Visible = false;

                cargarMedicos();
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            confirmModal.Visible = false;
            ViewState["LegajoAEliminar"] = null;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            limpiarConfirmacion();
            Session["legajoABuscar"] = txtBoxLegajo.Text;
            cargarMedicos();
        }

        protected void btnMostarTodos_Click(object sender, EventArgs e)
        {
            limpiarCampos();
            gvMedico.PageIndex = 0;
            cargarMedicos();
        }

        protected void limpiarCampos()
        {
            txtBoxLegajo.Text = string.Empty;
            Session["legajoABuscar"] = "";
        }

        protected void limpiarConfirmacion()
        {
            lbl_confirmacion.Text = string.Empty;
        }

        protected void gvMedico_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            limpiarConfirmacion();
            gvMedico.PageIndex = e.NewPageIndex;
            cargarMedicos();
        }
    }
    
}