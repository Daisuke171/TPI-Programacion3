using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPINT_GRUPO_5_PR3.Vistas.Informes
{
    public partial class Informes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTurnos();
            }
        }

        private void CargarTurnos()
        {
            // Creamos una tabla en memoria
            DataTable dt = new DataTable();

            dt.Columns.Add("Informes");


            // Agregamos filas de ejemplo
            dt.Rows.Add("Cantidad de pacientes por medico");
            dt.Rows.Add("Cantidad de medicos por especialidad");
            dt.Rows.Add("Promedios tipo de sangre");
            dt.Rows.Add("Dia con mas pacientes");

            // Enlazamos al GridView
            gvInformes.DataSource = dt;
            gvInformes.DataBind();
        }
    }
}