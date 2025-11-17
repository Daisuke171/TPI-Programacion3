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

        public int getIdProvinciaPorNombre(string nombreProvincia)
        {
            string consulta = "SELECT IdProvincia_Prov FROM Provincias WHERE NombreProvincia_Prov = '" + nombreProvincia + "'";
            return (int)accesoDatos.EjecutarScalar(consulta);
        }
    }
}
