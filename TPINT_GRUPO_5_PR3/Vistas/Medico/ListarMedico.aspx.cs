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
    public partial class ListarMedico : System.Web.UI.Page
    {

        NegocioMedico neg = new NegocioMedico();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblUsuario.Text = Session["usuario"]?.ToString();
                CargarMedicos();
            }
        }

        private void CargarMedicos()
        {
                bool MedActivo = false;
                DataTable tablaMedico = neg.listarMedico(MedActivo);
                gvMedico.DataSource = tablaMedico;
                gvMedico.DataBind();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();

            Response.Redirect("Login.aspx");
        }
    }
}