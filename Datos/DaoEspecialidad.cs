using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DaoEspecialidad
    {
        AccesoDatos ad = new AccesoDatos();

        public DataTable getTablaEspecialidades()
        {
            string consulta = "SELECT IdEspecialidad_Esp, NombreEspecialidad_Esp FROM Especialidades";
            return ad.obtenerTabla("Especialidades", consulta);
        }
    }
}
