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
        public DataTable getTableMedicos(bool medActivos)
        {
            string consulta = "";
            consulta = "exec SP_MOSTRARMEDICOS";
            //if (medActivos)
            //{
                
            //}
            //else
            //{
            //    consulta = "Select * from Medicos";
            //}
            DataTable table = accesoDatos.obtenerTabla("Medicos", consulta);
            return table;
        }
    }
}