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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPacientesDePrueba();
            }
        }

        private void CargarPacientesDePrueba()
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("ID");
            tabla.Columns.Add("Nombre");
            tabla.Columns.Add("Apellido");
            tabla.Columns.Add("DNI");
            tabla.Columns.Add("Edad");
            tabla.Columns.Add("Obra Social");

            tabla.Rows.Add(1, "Juan", "Pérez", "12345678", 35, "OSDE");
            tabla.Rows.Add(2, "María", "Gómez", "23456789", 28, "Swiss Medical");
            tabla.Rows.Add(3, "Carlos", "López", "34567890", 42, "IOMA");
            tabla.Rows.Add(4, "Ana", "Martínez", "45678901", 50, "PAMI");
            tabla.Rows.Add(5, "Luis", "Fernández", "56789012", 31, "Galeno");
            tabla.Rows.Add(6, "Laura", "Ramírez", "67890123", 26, "Medicus");

            gvPacientes.DataSource = tabla;
            gvPacientes.DataBind();
        }
    }
}