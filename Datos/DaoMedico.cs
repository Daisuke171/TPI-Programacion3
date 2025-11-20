using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
                //consulta = "EXEC SP_MOSTRARMEDICOS";
                consulta = "Select * " +
                    "from Medicos INNER JOIN Localidades ON IdProvincia_Med = IdProvincia_Loc AND IdLocalidad_Med = IdLocalidad_Loc " +
                    "INNER JOIN Provincias ON IdProvincia_Med = IdProvincia_Prov " +
                    "INNER JOIN Nacionalidades ON IdNacionalidad_Med = IdNacionalidad_Nac " +
                    "INNER JOIN Especialidades ON IdEspecialidad_Med = IdEspecialidad_Esp ";
                    //"WHERE Estado_Med = 1 ";
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

        public bool modificarMedico(Medico med)
        {
            SqlConnection cn = datos.obtenerConexion();

            string consulta = @"UPDATE Medicos SET
                        DNI_Med = @DNI,
                        Nombre_Med = @Nombre,
                        Apellido_Med = @Apellido,
                        Sexo_Med = @Sexo,
                        Telefono_Med = @Telefono,
                        IdNacionalidad_Med = @IdNacionalidad,
                        FechaNaciemiento_Med = @FechaNacimiento,
                        Direccion_Med = @Direccion,
                        IDLocalidad_Med = @IdLocalidad,
                        IDProvincia_Med = @IdProvincia,
                        CorreoElectronico_Med = @Correo,
                        IDEspecialidad_Med = @IdEspecialidad,
                        Estado_Med = @Estado
                    WHERE Legajo_Med = @Legajo";

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

        public DataTable getMedicosPorEspecialidad(int idEspecialidad)
        {
            SqlConnection cn = datos.obtenerConexion();

            string consulta = @"
        SELECT Legajo_Med, Nombre_Med + ' ' + Apellido_Med AS NombreCompleto
        FROM Medicos
        WHERE IdEspecialidad_Med = @idEsp AND Estado_Med = 1";

            SqlCommand cmd = new SqlCommand(consulta, cn);
            cmd.Parameters.AddWithValue("@idEsp", idEspecialidad);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            da.Fill(tabla);

            cn.Close();
            return tabla;
        }

        public DataTable getMedicoPorLegajo(int Legajo)
        {
            SqlConnection cn = datos.obtenerConexion();
            string consulta = @"
        SELECT *
        FROM Medicos
        INNER JOIN Nacionalidades ON Medicos.IdNacionalidad_Med = Nacionalidades.IdNacionalidad_Nac
        INNER JOIN Localidades ON Medicos.IdLocalidad_Med = Localidades.IdLocalidad_Loc
        INNER JOIN Provincias ON Medicos.IdProvincia_Med = Provincias.IdProvincia_Prov
        INNER JOIN Especialidades ON Medicos.IdEspecialidad_Med = Especialidades.IdEspecialidad_Esp
        WHERE Legajo_Med = @LegajoMedico AND Estado_Med = 1";

            SqlCommand cmd = new SqlCommand(consulta, cn);
            cmd.Parameters.AddWithValue("@LegajoMedico", Legajo);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            da.Fill(tabla);

            cn.Close();
            return tabla;
        }

        public DataTable getMedicoPorNombre(string nombre)
        {
            SqlConnection cn = datos.obtenerConexion();
            string consulta = @"
        SELECT *
        FROM Medicos
        INNER JOIN Nacionalidades ON Medicos.IdNacionalidad_Med = Nacionalidades.IdNacionalidad_Nac
        INNER JOIN Localidades ON Medicos.IdLocalidad_Med = Localidades.IdLocalidad_Loc
        INNER JOIN Provincias ON Medicos.IdProvincia_Med = Provincias.IdProvincia_Prov
        INNER JOIN Especialidades ON Medicos.IdEspecialidad_Med = Especialidades.IdEspecialidad_Esp
        WHERE Nombre_Med LIKE '%" + nombre + "%' AND Estado_Med = 1";
            

            SqlCommand cmd = new SqlCommand(consulta, cn);
            

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            da.Fill(tabla);

            cn.Close();
            return tabla;
        }


    }
}