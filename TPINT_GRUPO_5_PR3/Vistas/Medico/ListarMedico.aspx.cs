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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarMedicos();
            }
        }

        private void CargarMedicos()
        {
            // Crear tabla en memoria
            DataTable dt = new DataTable();
            dt.Columns.Add("Legajo", typeof(int));
            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("Apellido", typeof(string));
            dt.Columns.Add("Especialidad", typeof(string));
            dt.Columns.Add("Telefono", typeof(string));
            dt.Columns.Add("Correo", typeof(string));

            // Agregar filas de ejemplo
            dt.Rows.Add(1001, "Laura", "Martínez", "Cardiología", "1122334455", "laura.martinez@clinicamedica.com");
            dt.Rows.Add(1002, "Pablo", "Gómez", "Dermatología", "1166778899", "pablo.gomez@clinicamedica.com");
            dt.Rows.Add(1003, "María", "Fernández", "Pediatría", "1144556677", "maria.fernandez@clinicamedica.com");
            dt.Rows.Add(1004, "Jorge", "Ramírez", "Traumatología", "1133445566", "jorge.ramirez@clinicamedica.com");

            // Asignar la fuente de datos al GridView
            gvMedico.DataSource = dt;
            gvMedico.DataBind();
        }
    }
}