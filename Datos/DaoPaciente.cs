using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DaoPaciente
    {
        AccesoDatos accesoDatos = new AccesoDatos();

        public int insertarPaciente(Paciente paciente)
        {   
            int resultado = 0;
            String nombreSp = "insertarPaciente";
            SqlCommand sqlCommand = new SqlCommand();
            armarParametrosInsertarPaciente(ref sqlCommand, paciente);
            resultado = accesoDatos.EjecutarProcedimientoAlmacenado(sqlCommand, nombreSp);
            return resultado;
        }

        public  void armarParametrosInsertarPaciente(ref SqlCommand comando, Paciente paciente)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = comando.Parameters.Add("@DNI", SqlDbType.Int);
            parametros.Value = paciente._dni;
            parametros = comando.Parameters.Add("@NOMBRE", SqlDbType.VarChar);
            parametros.Value = paciente._nombre;
            parametros = comando.Parameters.Add("@APELLIDO", SqlDbType.VarChar);
            parametros.Value = paciente._apellido;
            parametros = comando.Parameters.Add("@SEXO", SqlDbType.VarChar);
            parametros.Value = paciente._sexo;
            parametros = comando.Parameters.Add("@IDNACIONALIDAD", SqlDbType.Int);
            parametros.Value = paciente._idNacionalidad;
            parametros = comando.Parameters.Add("@FECHANACIMIENTO", SqlDbType.Date);
            parametros.Value = paciente._fechaNacimiento;
            parametros = comando.Parameters.Add("@DIRECCION", SqlDbType.VarChar);
            parametros.Value = paciente._direccion;
            parametros = comando.Parameters.Add("@IDPROVINCIA", SqlDbType.Int);
            parametros.Value = paciente._idProvincia;
            parametros = comando.Parameters.Add("@IDLOCALIDAD", SqlDbType.Int);
            parametros.Value = paciente._idLocalidad;
            parametros = comando.Parameters.Add("@TIPOSANGRE", SqlDbType.VarChar);
            parametros.Value = paciente._tipoSangre;
            parametros = comando.Parameters.Add("@CORREOELECTRONICO", SqlDbType.VarChar);
            parametros.Value = paciente._correoElectronico;
            parametros = comando.Parameters.Add("@TELEFONO", SqlDbType.VarChar);
            parametros.Value = paciente._telefono;
        }

        public void armarParametrosBajaPaciente(ref SqlCommand comando, Paciente paciente)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = comando.Parameters.Add("@DNI", SqlDbType.Int);
            parametros.Value = paciente._dni;
        }

        public bool subirPaciente(Paciente paciente)
        {
            bool resultado = false;

            int filasAfectadas = insertarPaciente(paciente);
            
            if(filasAfectadas > 0)
            {
                return true;
            }
            return resultado;
        }

        public int eliminarPaciente(Paciente paciente)
        {
            int resultado = 0;
            String nombreSp = "SP_BAJAPACIENTE";
            SqlCommand sqlCommand = new SqlCommand();
            armarParametrosBajaPaciente(ref sqlCommand, paciente);
            resultado = accesoDatos.EjecutarProcedimientoAlmacenado(sqlCommand, nombreSp);
            return resultado;
        }

        public DataTable getTablaPacientesActivos()
        {
            //string consulta = "EXEC SP_MOSTRARPACIENTES";
            string consulta = "Select * " +
                    "from Pacientes INNER JOIN Localidades ON IdProvincia_Pac = IdProvincia_Loc AND IdLocalidad_Pac = IdLocalidad_Loc " +
                    "INNER JOIN Provincias ON IdProvincia_Pac = IdProvincia_Prov " +
                    "INNER JOIN Nacionalidades ON IdNacionalidad_Pac = IdNacionalidad_Nac " +
                    "WHERE Estado_Pac = 1 ";
            DataTable table = accesoDatos.obtenerTabla("Pacientes", consulta);
            return table;
        }

        public DataTable getTablaPacientesActivos(string nombre, string orden, string filtroTSangre)
        {
            // CONSULTA BASE
            string consulta = "Select DNI_Pac, Nombre_Pac, Apellido_Pac, Sexo_Pac, NombreNacionalidad_Nac, FechaNacimiento_Pac, Direccion_Pac, NombreProvincia_Prov, NombreLocalidad_Loc, TipoSangre_Pac, CorreoElectronico_Pac, Telefono_Pac " +
                    "from Pacientes INNER JOIN Localidades ON IdProvincia_Pac = IdProvincia_Loc AND IdLocalidad_Pac = IdLocalidad_Loc " +
                    "INNER JOIN Provincias ON IdProvincia_Pac = IdProvincia_Prov " +
                    "INNER JOIN Nacionalidades ON IdNacionalidad_Pac = IdNacionalidad_Nac " +
                    "WHERE Estado_Pac = 1 ";

            // AGREGADOS PARA FILTRAR - ORDENAR
            if (!string.IsNullOrEmpty(nombre.Trim()))
            {
                consulta += "AND Nombre_Pac LIKE '%" + nombre + "%' ";
            }
            if (filtroTSangre != "0")
            {
                consulta += "AND TipoSangre_Pac = '" + filtroTSangre + "' ";
            }
            if (orden != "0")
            {
                consulta += "ORDER BY " + orden;
            }

            DataTable table = accesoDatos.obtenerTabla("Pacientes", consulta);
            return table;
        }

        public bool existeDniPaciente(string dni)
        {
            string consultaSql = "SELECT * FROM Pacientes WHERE Dni_Pac = " + dni;
            return accesoDatos.existe(consultaSql);
        }

        public bool existeNombrePaciente(string nombre)
        {
            string consultaSql = "SELECT * FROM Pacientes WHERE Nombre_Pac LIKE '%" + nombre + "%'";
            return accesoDatos.existe(consultaSql);
        }

        public bool modificarPaciente(Paciente pac)
        {
            SqlConnection cn = accesoDatos.obtenerConexion();

            string consulta = @"UPDATE Pacientes SET
                        Nombre_Pac = @Nombre,
                        Apellido_Pac = @Apellido,
                        Sexo_Pac = @Sexo,
                        Telefono_Pac = @Telefono,
                        IdNacionalidad_Pac = @IdNacionalidad,
                        FechaNacimiento_Pac = @FechaNacimiento,
                        Direccion_Pac = @Direccion,
                        IDLocalidad_Pac = @IdLocalidad,
                        IDProvincia_Pac = @IdProvincia,
                        CorreoElectronico_Pac = @Correo,
                        TipoSangre_Pac = @TipoSangre,
                        Estado_Pac = @Estado
                    WHERE DNI_Pac = @DNI";

            SqlCommand cmd = new SqlCommand(consulta, cn);

            cmd.Parameters.AddWithValue("@DNI", pac._dni);
            cmd.Parameters.AddWithValue("@Nombre", pac._nombre);
            cmd.Parameters.AddWithValue("@Apellido", pac._apellido);
            cmd.Parameters.AddWithValue("@Sexo", pac._sexo);
            cmd.Parameters.AddWithValue("@Telefono", pac._telefono);
            cmd.Parameters.AddWithValue("@IdNacionalidad", pac._idNacionalidad);
            cmd.Parameters.AddWithValue("@FechaNacimiento", pac._fechaNacimiento);
            cmd.Parameters.AddWithValue("@Direccion", pac._direccion);
            cmd.Parameters.AddWithValue("@IdLocalidad", pac._idLocalidad);
            cmd.Parameters.AddWithValue("@IdProvincia", pac._idProvincia);
            cmd.Parameters.AddWithValue("@Correo", pac._correoElectronico);
            cmd.Parameters.AddWithValue("@TipoSangre", pac._tipoSangre);
            cmd.Parameters.AddWithValue("@Estado", pac._estadoPaciente);

            int filas = cmd.ExecuteNonQuery();
            cn.Close();

            return filas > 0;
        }

    }
}
