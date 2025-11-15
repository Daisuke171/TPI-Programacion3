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
    public partial class ListarPaciente : System.Web.UI.Page
    {
        NegocioPaciente neg = new NegocioPaciente();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPacientes();
            }
        }
        private void CargarPacientes()
        {
            bool pacActivo = false;
            DataTable tablaPaciente = neg.listarPaciente(pacActivo);
            gvPacientes.DataSource = tablaPaciente;
            gvPacientes.DataBind();
        }
    }
}