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

        public DataTable getTablePaciente(bool pacActivos)
        {
            string consulta = "";
            if (pacActivos)
            {
                consulta = "Select DNI_Pac, Nombre_Pac, Apellido_Pac, Sexo_Pac, NombreNacionalidad_Nac, FechaNacimiento_Pac, Direccion_Pac, NombreProvincia_Prov, NombreLocalidad_Loc, TipoSangre_Pac, CorreoElectronico_Pac, Telefono_Pac " +
                    "from Pacientes INNER JOIN Localidades ON IdProvincia_Pac = IdProvincia_Loc AND IdLocalidad_Pac = IdLocalidad_Loc " +
                    "INNER JOIN Provincias ON IdProvincia_Pac = IdProvincia_Prov " +
                    "INNER JOIN Nacionalidades ON IdNacionalidad_Pac = IdNacionalidad_Nac " +
                    "WHERE Estado_Pac = 1";
            }
            else
            {
                consulta = "Select * from Pacientes";
            }
                DataTable table = accesoDatos.obtenerTabla("Pacientes", consulta);
                return table;
        }

        public bool existePaciente(Paciente paciente)
        {
            string consultaSql = "SELECT * FROM Pacientes WHERE Dni_Pac = " + paciente._dni;
            return accesoDatos.existe(consultaSql);
        }
        
    }
}
