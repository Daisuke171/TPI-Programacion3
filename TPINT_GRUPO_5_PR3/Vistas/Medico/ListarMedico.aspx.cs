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
        Negocio.NegocioMedico negMedico = new Negocio.NegocioMedico();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarMedicos();
            }
        }

        private void CargarMedicos()
        {
                DataTable tablaMedico = negMedico.listarMedico();
                gvMedico.DataSource = tablaMedico;
                gvMedico.DataBind();
        }
    }
}