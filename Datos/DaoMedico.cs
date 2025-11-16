using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Datos
{
    public class DaoMedico
    {
        AccesoDatos datos = new AccesoDatos();

        public bool insertarMedico(Medico med)
        {
            SqlConnection cn = datos.obtenerConexion();

            string consulta = @"INSERT INTO Medicos 
        (Legajo_Med, DNI_Med, Nombre_Med, Apellido_Med, Sexo_Med, 
         Telefono_Med, IdNacionalidad_Med, FechaNaciemiento_Med, 
         Direccion_Med, IDLocalidad_Med, IDProvincia_Med, 
         CorreoElectronico_Med, IDEspecialidad_Med, Estado_Med)
        VALUES
        (@Legajo, @DNI, @Nombre, @Apellido, @Sexo, 
         @Telefono, @IdNacionalidad, @FechaNacimiento, 
         @Direccion, @IdLocalidad, @IdProvincia, 
         @Correo, @IdEspecialidad, @Estado);";

            SqlCommand cmd = new SqlCommand(consulta, cn);
            cmd.Parameters.AddWithValue("@Legajo", med._legajoMedico);
            cmd.Parameters.AddWithValue("@DNI", med._dni);
            cmd.Parameters.AddWithValue("@Nombre", med._nombre);
            cmd.Parameters.AddWithValue("@Apellido", med._apellido);
            cmd.Parameters.AddWithValue("@Sexo", med._sexo);
            cmd.Parameters.AddWithValue("@Telefono", med._telefono);
            cmd.Parameters.AddWithValue("@IdNacionalidad", med._idNacionalidad);
            cmd.Parameters.AddWithValue("@FechaNacimiento", med._fechaNacimiento);
            cmd.Parameters.AddWithValue("@Direccion", med._direccion);
            cmd.Parameters.AddWithValue("@IdLocalidad", med._idLocalidad);
            cmd.Parameters.AddWithValue("@IdProvincia", med._idProvincia);
            cmd.Parameters.AddWithValue("@Correo", med._correoElectronico);
            cmd.Parameters.AddWithValue("@IdEspecialidad", med._idEspecialidad);
            cmd.Parameters.AddWithValue("@Estado", med._estadoMedico);

            int filas = cmd.ExecuteNonQuery();
            cn.Close();

            return filas > 0;
        }

        public DataTable getTableMedico(bool medActivos)
        {
            string consulta = "";
            if (medActivos)
            {
                consulta = "EXEC SP_MOSTRARMEDICOS";
            }
            else
            {
                consulta = "EXEC SP_MOSTRARMEDICOS";
            }
            DataTable table = datos.obtenerTabla("Medicos", consulta);
            return table;
        }

        public bool existeDniMedico(string dni)
        {
            string consulta = $"SELECT * FROM Medicos WHERE DNI_Med = '{dni}'";
            return datos.existe(consulta);
        }

        public int generarLegajoMedico()
        {
            string consulta = "SELECT ISNULL(MAX(Legajo_Med), 0) + 1 AS NuevoLegajo FROM Medicos WITH (TABLOCKX)";
            DataTable table = datos.obtenerTabla("Medicos", consulta);
            return Convert.ToInt32(table.Rows[0]["NuevoLegajo"]);
        }

        public void armarParametrosBajaMedico(ref SqlCommand comando, Medico medico)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = comando.Parameters.Add("@LEGAJO", SqlDbType.Int);
            parametros.Value = medico._legajoMedico;
        }

        public int eliminarMedico(Medico medico)
        {
            int resultado = 0;
            string nombreSp = "SP_BAJAMEDICO";
            SqlCommand sqlCommand = new SqlCommand();
            armarParametrosBajaMedico(ref sqlCommand, medico);
            resultado = datos.EjecutarProcedimientoAlmacenado(sqlCommand, nombreSp);
            return resultado;
        }
    }
}