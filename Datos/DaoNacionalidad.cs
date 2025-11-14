using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DaoNacionalidad
    {
        AccesoDatos accesoDatos = new AccesoDatos();
        public DataTable getTablaNacionalidad()
        {
            DataTable tablaNacionalidad = accesoDatos.obtenerTabla("Nacionalidades", "SELECT * FROM Nacionalidades");
            return tablaNacionalidad;
        }
    }
}
