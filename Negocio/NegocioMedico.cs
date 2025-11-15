using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioMedico
    {
        public DataTable listarMedico(bool medActivos)
        {
            DaoMedico daoMedico = new DaoMedico();
            return daoMedico.getTableMedicos(medActivos);
        }
    }
}
