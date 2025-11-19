using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace TPINT_GRUPO_5_PR3.Vistas
{
    public partial class Homepage : System.Web.UI.Page
    {
        NegocioUsuario negUsuario = new NegocioUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["TipoUsuario"] != null)
                {
                    lblUsuario.Text = Session["usuario"].ToString();
                    string tipoUsuario = negUsuario.validarTipoUsuario(Session["usuario"].ToString());

                    if (tipoUsuario == "Admin")
                    {
                        hlnkMenuAdmin.Enabled = true;
                        hlnkMenuAdmin.Visible = true;
                        hlnkMenuMedicos.Enabled = true;
                        hlnkMenuMedicos.Visible = true;
                        hlnkMenuPacientes.Enabled = true;
                        hlnkMenuPacientes.Visible = true;
                        hlnkHomeMedico.Enabled = true;
                        hlnkHomeMedico.Visible = true;
                        hlnkHomePaciente.Enabled = true;
                        hlnkHomePaciente.Visible = true;
                    }
                    else if (tipoUsuario == "Medico")
                    {
                        hlnkMenuMedicos.Enabled = true;
                        hlnkMenuMedicos.Visible = true;
                        hlnkHomeMedico.Enabled = true;
                        hlnkHomeMedico.Visible = true;
                        hlnkHomePaciente.Enabled = true;
                        hlnkHomePaciente.Visible = true;
                    }
                    else if (tipoUsuario == "Paciente")
                    {
                        hlnkMenuPacientes.Enabled = true;
                        hlnkMenuPacientes.Visible = true;
                        hlnkHomePaciente.Enabled = true;
                        hlnkHomePaciente.Visible = true;
                    }

                    btnLogout.Visible = true;
                    btnLogin.Visible = false;
                }
                else
                {
                    lblUsuario.Text = "";
                    btnLogout.Visible = false;
                    btnLogin.Visible = true;
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
            
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            
            Response.Redirect("Inicio.aspx");

        }
    }
}