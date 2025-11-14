using Entidades;
using System;
using System.Collections.Generic;
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
            ///PONER EL NOMBRE DEL PROCEDIMIENTO ALMACENADO
            String nombreSp = "nombbre procedimiento para insertar pacientes";
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.AddWithValue("@ID", paciente._id);
            sqlCommand.Parameters.AddWithValue("@DNI", paciente._dni);
            sqlCommand.Parameters.AddWithValue("@Nombre_Pac", paciente._nombre);
            sqlCommand.Parameters.AddWithValue("@Apellido_Pac", paciente._apellido);
            sqlCommand.Parameters.AddWithValue("@Sexo_Pac", paciente._sexo);
            sqlCommand.Parameters.AddWithValue("@IdNacionalidad_Pac", paciente._idNacionalidad);
            sqlCommand.Parameters.AddWithValue("@FechaNacimiento_Pac", paciente._fechaNacimiento);
            sqlCommand.Parameters.AddWithValue("@Direccion_Pac", paciente._direccion);
            sqlCommand.Parameters.AddWithValue("@IdProvincia_Pac", paciente._idProvincia);
            sqlCommand.Parameters.AddWithValue("@IdLocalidad_Pac", paciente._idLocalidad);
            sqlCommand.Parameters.AddWithValue("@TipoSangre_Pac", paciente._tipoSangre);
            sqlCommand.Parameters.AddWithValue("@CorreoElectronico_Pac", paciente._correoElectronico);
            sqlCommand.Parameters.AddWithValue("@Telefono_Pac", paciente._telefono);
            sqlCommand.Parameters.AddWithValue("@Estado_Pac", paciente._estadoPaciente);


            resultado = accesoDatos.EjecutarProcedimientoAlmacenado(sqlCommand, nombreSp);

            return resultado;
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

        public bool eliminarPaciente(Paciente paciente)
        {
            string consulta = "DELETE FROM Sucursal WHERE DNI_Pac = " + paciente._dni;
            AccesoDatos datos = new AccesoDatos();
            int filasAfectadas = datos.EjecutarTransaccion(consulta);
            return filasAfectadas > 0;
        }


    }
}
