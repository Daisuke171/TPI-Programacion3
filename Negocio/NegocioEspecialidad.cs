using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;

namespace Negocio
{
    public class NegocioEspecialidad
    {
        public DataTable getTabla()
        {
            DaoEspecialidad dao = new DaoEspecialidad();
            return dao.getTablaEspecialidades();
        }

        public int getId(string nombreEspecialidad)
        {
            DaoEspecialidad dao = new DaoEspecialidad();
            return dao.getIdEspecialidadPorNombre(nombreEspecialidad);
        }
    }
}
