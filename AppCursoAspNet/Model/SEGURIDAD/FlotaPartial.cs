using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.SEGURIDAD
{
    public partial class Flota
    {

        public Modelo.SEGURIDAD.Licencia ultimaLicencia
        {
            get
            {
                return this.Licencia.OrderByDescending(c => c.FechaInicio).FirstOrDefault();
            }
        }

    }
}
