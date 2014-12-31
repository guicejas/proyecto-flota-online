using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public partial class Turno
    {
        public string FechaIncioCorta
        {
            get
            {
              return FechaInicio.ToShortDateString();
            }
        }

        public string FechaFinCorta
        {
            get
            {
                return FechaFin.ToShortDateString();
            }
        }
    }
}
