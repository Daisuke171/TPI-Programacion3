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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblUsuario.Text = Session["usuario"]?.ToString();

                if (Session["TipoUsuario"] == null)
                {
                    Response.Redirect("../Inicio.aspx");
                    return;
                }

                CargarMedicos();
            }
        }

        private void CargarMedicos()
        {
            bool medActivo = true;
            DataTable tablaMedico = negMedico.listarMedico(medActivo);
            gvMedico.DataSource = tablaMedico;
            gvMedico.DataBind();
        }

        protected void gvMedico_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int legajo = Convert.ToInt32(((Label)gvMedico.Rows[e.RowIndex].FindControl("lbl_it_legajo")).Text);

            ViewState["LegajoAEliminar"] = legajo;

            confirmModal.Visible = true;

            e.Cancel = true;
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            int legajo = Convert.ToInt32(txtBoxLegajo.Text);
            if (negMedico.bajaMedico(legajo))
            {
                lbl_confirmacion.ForeColor = Color.Green;
                lbl_confirmacion.Text = "Medico dado de baja correctamente";
            }
            else
            {
                lbl_confirmacion.ForeColor = Color.Red;
                lbl_confirmacion.Text = "Error al dar de baja al Medico";
            }
            CargarMedicos();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();

            Response.Redirect("Login.aspx");
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (ViewState["LegajoAEliminar"] != null)
            {
                int legajo = Convert.ToInt32(ViewState["LegajoAEliminar"]);

                if (negMedico.bajaMedico(legajo))
                {
                    lbl_confirmacion.ForeColor = Color.Green;
                    lbl_confirmacion.Text = "Médico eliminado exitosamente";
                }
                else
                {
                    lbl_confirmacion.ForeColor = Color.Red;
                    lbl_confirmacion.Text = "Error al eliminar el médico.";
                }

                // limpiar
                ViewState["LegajoAEliminar"] = null;
                confirmModal.Visible = false;

                CargarMedicos();
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            confirmModal.Visible = false;
            ViewState["LegajoAEliminar"] = null;
        }
    }
    
}