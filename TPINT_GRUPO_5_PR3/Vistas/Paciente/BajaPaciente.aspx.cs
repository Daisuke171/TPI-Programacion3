using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPINT_GRUPO_5_PR3.Vistas
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarPacientes();
            }
        }

        private void CargarPacientes()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("DNI");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Apellido");
            dt.Columns.Add("Sexo");
            dt.Columns.Add("Nacionalidad");
            dt.Columns.Add("FechaNacimiento");
            dt.Columns.Add("Direccion");
            dt.Columns.Add("Localidad");
            dt.Columns.Add("Provincia");
            dt.Columns.Add("TipoSangre");
            dt.Columns.Add("CorreoElectronico");
            dt.Columns.Add("Telefono");

            // Agregar filas de ejemplo
            dt.Rows.Add("40123456", "Juan", "Pérez", "M", "Argentina", "10/04/1995", "Av. Siempre Viva 123", "Buenos Aires", "Buenos Aires", "O+", "juanperez@mail.com", "1123456789");
            dt.Rows.Add("39222444", "María", "López", "F", "Argentina", "22/11/1998", "Calle Falsa 456", "Rosario", "Santa Fe", "A-", "marialopez@mail.com", "1133344455");
            dt.Rows.Add("38555444", "Carlos", "Gómez", "M", "Uruguay", "05/06/1990", "Ruta 8 km 15", "La Plata", "Buenos Aires", "B+", "cgomez@mail.com", "1145566778");

            gvPaciente.DataSource = dt;
            gvPaciente.DataBind();
        }
    }
}