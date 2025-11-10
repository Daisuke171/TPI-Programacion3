using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPINT_GRUPO_5_PR3.Vistas
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGridMedico();
            }
        }

        private void LlenarGridMedico()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Legajo");
            dt.Columns.Add("DNI");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Apellido");
            dt.Columns.Add("Especialidad");
            dt.Columns.Add("CorreoElectronico");
            dt.Columns.Add("Telefono");

            // Datos de ejemplo
            dt.Rows.Add("M001", "35498765", "Laura", "González", "Cardiología", "laura.gonzalez@hospital.com", "1159876543");
            dt.Rows.Add("M002", "30987654", "Martín", "Pérez", "Pediatría", "martin.perez@hospital.com", "1134567890");
            dt.Rows.Add("M003", "32876543", "Sofía", "Ruiz", "Neurología", "sofia.ruiz@hospital.com", "1147658392");

            gvMedico.DataSource = dt;
            gvMedico.DataBind();
        }
    }
}