using System;
using Negocio;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPINT_GRUPO_5_PR3.Vistas
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        NegocioMedico neg = new NegocioMedico();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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

        protected void gvMedico_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvMedico.EditIndex = e.NewEditIndex;
            CargarMedicos();
        }
    }
}