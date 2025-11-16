using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Datos
{
    public class DaoUsuario
    {
        AccesoDatos accesoDatos = new AccesoDatos();
        public DaoUsuario() { }

        public bool validarUsuario(string usuario, string contrasenia)
        {
            string consulta = $"SELECT COUNT(*) FROM Usuarios WHERE NombreUsuario_U = '{usuario}' AND ContraseniaUsuario_U = '{contrasenia}'";
            return accesoDatos.existe(consulta);
        }

        public int tipoUsuario(string usuario)
        {
            string consulta = $"SELECT IdTipoUsuario_U FROM Usuarios WHERE NombreUsuario_U = '{usuario}'";
            object resultado = accesoDatos.EjecutarScalar(consulta);

            if (resultado != null)
                return Convert.ToInt32(resultado);

            return -1;
        }

    }
}
