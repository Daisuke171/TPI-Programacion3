using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DaoProvincia
    {
        AccesoDatos accesoDatos = new AccesoDatos();
        public DataTable getTablaProvincia()
        {
            DataTable tablaProvincia = accesoDatos.obtenerTabla("Provincias", "SELECT * FROM Provincias");
            return tablaProvincia;
        }
    }
}
