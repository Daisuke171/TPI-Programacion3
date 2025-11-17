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
        DaoNacionalidad daoNacionalidad = new DaoNacionalidad();
        public DataTable getTable()
        {
            return daoNacionalidad.getTablaNacionalidad();
        }

        public int getId(string nombre)
        {
            return daoNacionalidad.getIdNacionalidadPorNombre(nombre);
        }
    }
}
