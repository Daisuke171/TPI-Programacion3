using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
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

        public bool insertarUsuarioMedico(Medico med, string user, string password)
        {
            SqlConnection conexion = accesoDatos.obtenerConexion();
            string consulta = "INSERT INTO Usuarios(NombreUsuario_U, ContraseniaUsuario_U, IdTipoUsuario_U) " +
                               "VALUES (@nombreUsuario, @contraseniaUsuario, @idTipoUsuario)";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("@nombreUsuario", user);
            comando.Parameters.AddWithValue("@contraseniaUsuario", password);
            comando.Parameters.AddWithValue("@idTipoUsuario", 2);
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

        public int getIdUsuarioMedico(int legajo)
        {
            string consulta = "SELECT IDUsuario_Med FROM Medicos " +
                              "INNER JOIN Usuarios ON Medicos.IDUsuario_Med = Usuarios.IDUsuario_U " +
                              "WHERE Medicos.Legajo_Med = " + "'" + legajo + "'";
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

        public string getLegajoConUsuario(string usuario)
        {
            string resultado = "";

            using (SqlConnection conexion = accesoDatos.obtenerConexion())
            {
                string consulta = "SELECT IDUsuario_U, Legajo_Med FROM Usuarios " +
                                  "INNER JOIN Medicos ON Medicos.IDUsuario_Med = Usuarios.IDUsuario_U " +
                                  "WHERE NombreUsuario_U = @nombreUsuario";

                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@nombreUsuario", usuario);

                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        resultado = reader["Legajo_Med"].ToString();

                    }
                }
            }
            return resultado;
        }
        
    }
    }
