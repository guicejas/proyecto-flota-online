using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.SEGURIDAD;

namespace Controladora.SEGURIDAD
{
    public class ControladoraPermisos
    {
        public List<Permiso> ListarPermisos()
        {
            return Modelo.SingletonSeguridad.ObtenerInstancia().Permisos.OrderBy(c => c.IDPermiso).ToList();
        }
    }
}
