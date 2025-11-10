using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPINT_GRUPO_5_PR3.Vistas
{
    public partial class ConsultarTurno : System.Web.UI.Page
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

            dt.Columns.Add("IdTurno");
            dt.Columns.Add("LegajoMedico");
            dt.Columns.Add("DNIPaciente");
            dt.Columns.Add("Fecha");
            dt.Columns.Add("Especialidad");
            dt.Columns.Add("Asistencia");
            dt.Columns.Add("Observacion");

            // Agregamos filas de ejemplo
            dt.Rows.Add("T001", "1001", "12345678", "2025-11-12", "Cardiología", "Sí", "Chequeo general");
            dt.Rows.Add("T002", "1002", "87654321", "2025-11-15", "Dermatología", "No", "Consulta pendiente");
            dt.Rows.Add("T003", "1003", "45678912", "2025-11-20", "Neurología", "Sí", "Control de rutina");

            // Enlazamos al GridView
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}