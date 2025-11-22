using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
            comando.Parameters.AddWithValue("@nombreUsuario", med._apellido + "." + med._dni);
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

        public int getIdUsuarioMedico(int legajo)
        {
            string consulta = "SELECT IDUsuario_Med FROM Medicos " +
                              "INNER JOIN Usuarios ON Medicos.IDUsuario_Med = Usuarios.IDUsuario_U " +
                              "WHERE Medicos.IDUsuario_Med = " + legajo;
            object resultado = accesoDatos.EjecutarScalar(consulta);
            if (resultado != null)
                return Convert.ToInt32(resultado);
            return -1;
        }

        public bool borrarUsuarioMedico(int legajo)
        {
            SqlConnection conexion = accesoDatos.obtenerConexion();
            int idUsuario = getIdUsuarioMedico(legajo);
            string consulta = "UPDATE Usuarios SET EstadoUsuario_U = 0 WHERE IDUsuario_U = @idUsuario";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("@idUsuario", idUsuario);

            int filas = comando.ExecuteNonQuery();
            conexion.Close();
            if (filas > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int getCantidadUsuarios()
        {
            string consulta = "SELECT MAX(IDUsuario_U) FROM Usuarios";
            object resultado = accesoDatos.EjecutarScalar(consulta);
            if (resultado != null)
                return Convert.ToInt32(resultado);
            return -1;
        }
    }
}
