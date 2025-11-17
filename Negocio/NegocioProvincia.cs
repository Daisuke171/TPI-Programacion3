using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioProvincia
    {
        public DataTable getTable()
        {
            DaoProvincia daoProvincia = new DaoProvincia();
            return daoProvincia.getTablaProvincia();
        }

        public int getIdProvinciaPorNombre(string nombreProvincia)
        {
            DaoProvincia daoProvincia = new DaoProvincia();
            return daoProvincia.getIdProvinciaPorNombre(nombreProvincia);
        }
    }
}

