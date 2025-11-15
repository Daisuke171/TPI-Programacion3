using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioLocalidad
    {
        public DataTable getTable(string idProvincia)
        {
            DaoLocalidad daoLocalidad = new DaoLocalidad();
            return daoLocalidad.getTablaLocalidad(idProvincia);
        }
    }
}
