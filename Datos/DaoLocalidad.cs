using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DaoLocalidad
    {
        AccesoDatos accesoDatos = new AccesoDatos();
        public DataTable getTablaLocalidad()
        {
            DataTable tablaLocalidad = accesoDatos.obtenerTabla("Localidades", "SELECT * FROM Localidades");
            return tablaLocalidad;
        }
    }
}
