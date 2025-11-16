using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace Datos
{
    public class AccesoDatos
    {
        private string cadenaConexion = "Data Source=db-clinica.c6zog6amkgs7.us-east-1.rds.amazonaws.com;Initial Catalog=Clinica;User ID=admin;Password=utnpacheco";
        public AccesoDatos() { }

        public SqlConnection obtenerConexion()
        {
            SqlConnection connection = new SqlConnection(cadenaConexion);

            try
            {
                connection.Open();
                return connection;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public SqlDataAdapter obtenerAdaptador(SqlConnection connection, string consultaSql)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(consultaSql, connection);
                return adapter;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public SqlCommand obtenerSqlCommand(SqlConnection connection, string consultaSql)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand(consultaSql, connection);
                return sqlCommand;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable obtenerTabla(string tabla, string consultaSql)
        {
            SqlConnection connection = obtenerConexion();
            SqlDataAdapter adapter = obtenerAdaptador(connection, consultaSql);

            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, tabla);
            connection.Close();
            return dataSet.Tables[tabla];
        }


        public int EjecutarProcedimientoAlmacenado(SqlCommand Comando, String NombreSP)
        {
            int FilasCambiadas;
            SqlConnection Conexion = obtenerConexion();
            SqlCommand cmd = new SqlCommand();
            cmd = Comando;
            cmd.Connection = Conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = NombreSP;
            FilasCambiadas = cmd.ExecuteNonQuery();
            Conexion.Close();
            return FilasCambiadas;
        }
        public object EjecutarScalar(string consultaSql)
        {
            SqlConnection conexion = obtenerConexion();
            SqlCommand cmd = new SqlCommand(consultaSql, conexion);
            object resultado = cmd.ExecuteScalar();
            conexion.Close();
            return resultado;
        }

        public int EjecutarTransaccion(String consultaSql)
        {
            SqlConnection conexion = obtenerConexion();
            SqlCommand cmd = new SqlCommand(consultaSql, conexion);
            int filasAfectadas;
            filasAfectadas = cmd.ExecuteNonQuery();
            conexion.Close();
            return filasAfectadas;
        }

        public bool existe(string consultaSql)
        {
            bool existe = false;
            SqlConnection connection = obtenerConexion();
            SqlCommand cmd = new SqlCommand(consultaSql, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                existe = true;
            }
            connection.Close();
            return existe;
        }

        
    }
}