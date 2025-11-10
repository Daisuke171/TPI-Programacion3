using System;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGridViewMedico();
            }
        }

        private void LlenarGridViewMedico()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Legajo");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Apellido");
            dt.Columns.Add("DNI");
            dt.Columns.Add("Especialidad");
            dt.Columns.Add("CorreoElectronico");
            dt.Columns.Add("Telefono");
            dt.Columns.Add("Direccion");
            dt.Columns.Add("Provincia");

            dt.Rows.Add("M001", "Laura", "Gómez", "32456987", "Cardiología", "laura.gomez@clinica.com", "1123456789", "Av. Siempre Viva 123", "Buenos Aires");
            dt.Rows.Add("M002", "Carlos", "Fernández", "28956321", "Pediatría", "carlos.fernandez@clinica.com", "1134567890", "Calle 45 Nº 256", "Córdoba");
            dt.Rows.Add("M003", "María", "López", "30214569", "Dermatología", "maria.lopez@clinica.com", "1145678901", "Belgrano 789", "Santa Fe");
            dt.Rows.Add("M004", "Andrés", "Pérez", "31897654", "Neurología", "andres.perez@clinica.com", "1156789012", "San Martín 654", "Mendoza");
            dt.Rows.Add("M005", "Sofía", "Martínez", "33124568", "Ginecología", "sofia.martinez@clinica.com", "1167890123", "Mitre 321", "Salta");

            gvMedico.DataSource = dt;
            gvMedico.DataBind();
        }
    }
}