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
        public DataTable getTablaLocalidad(string idProvincia)
        {
            DataTable tablaLocalidad = accesoDatos.obtenerTabla("Localidades", "SELECT * FROM Localidades WHERE IdProvincia_Loc = " + idProvincia);
            return tablaLocalidad;
        }
    }
}
