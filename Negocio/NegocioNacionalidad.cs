using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioNacionalidad
    {
        public DataTable getTable()
        {
            DaoNacionalidad daoNacionalidad = new DaoNacionalidad();
            return daoNacionalidad.getTablaNacionalidad();
        }
    }
}
