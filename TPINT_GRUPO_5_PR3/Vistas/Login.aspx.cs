using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace TPINT_GRUPO_5_PR3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        NegocioUsuario negUsuario = new NegocioUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

        private bool ValidarUsuario(string user, string contrasenia)
        {
            return negUsuario.validarUsuario(user, contrasenia);
        }

        protected void buttonIniciarSesion_Click(object sender, EventArgs e)
        {
            bool exito = ValidarUsuario(txtUser.Text, txtContra.Text);

            if (exito)
            {
                Session["usuario"] = txtUser.Text;
                string tipoUsuario = negUsuario.validarTipoUsuario(txtUser.Text);

                if (tipoUsuario == "Admin")
                {
                    Session["TipoUsuario"] = tipoUsuario;

                    Response.Redirect("InicioAdmin.aspx");
                }
                else if (tipoUsuario == "Medico")
                {
                    Session["TipoUsuario"] = tipoUsuario;

                    Response.Redirect("Medico/InicioMedico.aspx");
                }
                else
                {
                    Session["TipoUsuario"] = tipoUsuario;

                    Response.Redirect("Inicio.aspx");
                }
                
            }
            else
            {
                lblError.Text = "Usuario o contraseña incorrectos.";
            }
        }
    }
}