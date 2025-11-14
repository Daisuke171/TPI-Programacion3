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
        // Data Source=db-clinica.c6zog6amkgs7.us-east-1.rds.amazonaws.com;Initial Catalog=Clinica;User ID=admin;Password=***********;Trust Server Certificate=True
        private string cadenaConexion = "";
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

        
    }
}