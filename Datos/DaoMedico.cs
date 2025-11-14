using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DaoMedico
    {
        AccesoDatos accesoDatos = new AccesoDatos();
        public DataTable getTableMedicos()
        {
            DataTable tablaMedicos = accesoDatos.obtenerTabla("Medicos", "SELECT * FROM Medicos");
            return tablaMedicos;
        }
    }
}