using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;

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

        public bool insertarUsuarioMedico(Medico med)
        {
            SqlConnection conexion = accesoDatos.obtenerConexion();
            string consulta = "INSERT INTO Usuarios(NombreUsuario_U, ContraseniaUsuario_U, IdTipoUsuario_U) " +
                               "VALUES (@nombreUsuario, @contraseniaUsuario, @idTipoUsuario)";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("@nombreUsuario", med._apellido);
            comando.Parameters.AddWithValue("@contraseniaUsuario", med._dni + "." + med._legajoMedico);
            comando.Parameters.AddWithValue("@idTipoUsuario", 2);
            int filas = comando.ExecuteNonQuery();
            conexion.Close();
            if(filas > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
