using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace TPINT_GRUPO_5_PR3.Vistas.Informes
{
    public partial class Informes : System.Web.UI.Page
    {

        NegocioInformes negInf = new NegocioInformes();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarInformes();
            }
        }

        private void CargarInformes()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Informes");

            dt.Rows.Add("Cantidad de pacientes por medico");
            dt.Rows.Add("Cantidad de medicos por especialidad");
            dt.Rows.Add("Promedios tipo de sangre");
            dt.Rows.Add("Dia con mas pacientes");

            gvInformes.DataSource = dt;
            gvInformes.DataBind();
        }

        protected void gvInformes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "VerInforme")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                string informe = gvInformes.Rows[index].Cells[1].Text;

                if (informe == "Promedios tipo de sangre")
                {
                    DataTable resultado = negInf.getPromedioTiposSangre();
                    gvResultado.DataSource = resultado;
                    gvResultado.DataBind();
                }

                // Cuando quieras agregar los otros informes, seguís acá:
                // if (informe == "Cantidad de pacientes por medico") { ... }
                // if (informe == "Cantidad de medicos por especialidad") { ... }
                // if (informe == "Dia con mas pacientes") { ... }
            }
        }
    }
}