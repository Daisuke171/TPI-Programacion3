using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace TPINT_GRUPO_5_PR3.Vistas
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        NegocioPaciente neg = new NegocioPaciente();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAltaPaciente_Click(object sender, EventArgs e)
        {
            int idNacionalidad = Convert.ToInt32(ddlNacionalidad.SelectedValue.ToString());
            DateTime fechaNacimiento = Convert.ToDateTime(txtBoxFecha.Text);
            int idProvincia = Convert.ToInt32(ddlProvincia.SelectedValue.ToString());
            int idLocalidad = Convert.ToInt32(ddlLocalidad.SelectedValue.ToString());
            bool confirmacion = neg.agregarPaciente(txtBoxDNI.Text, txtBoxNombre.Text, txtBoxApellido.Text, ddlSexo.SelectedValue, idNacionalidad, fechaNacimiento, txtBoxDirecc.Text, idProvincia,
                                                    idLocalidad, (ddlTipoSangre1.SelectedValue + ddlTipoSangre2.SelectedValue), txtBoxCorreo.Text, txtBoxTelefono.Text);
        }
    }
}