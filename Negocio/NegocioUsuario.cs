using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioUsuario
    {
        Datos.DaoUsuario daoUsuario = new Datos.DaoUsuario();
        public bool validarUsuario(string usuario, string contrasenia)
        {
            return daoUsuario.validarUsuario(usuario, contrasenia);
        }

        public string validarTipoUsuario(string usuario)
        {
            if (daoUsuario.tipoUsuario(usuario) == 1)
            {
                return "Admin";
            }
            else if (daoUsuario.tipoUsuario(usuario) == 2)
            {
                return "Medico";
            }
            else if (daoUsuario.tipoUsuario(usuario) == 3)
            {
                return "Paciente";
            }
            else
            {
                return null;
            }
        }

        public bool agregarUsuarioMedico(Medico med, string user, string password)
        {
            return daoUsuario.insertarUsuarioMedico(med, user, password);
        }

        public bool borrarUsuarioMedico(int legajo)
        {
            return daoUsuario.borrarUsuarioMedico(legajo);
        }

        public string ObtenerLegajoConUsuario(string usuario)
        {
            return daoUsuario.getLegajoConUsuario(usuario);
        }

    }
}
