using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo    
{
    public partial class Chofer
    {

        public string NombreCompleto
        {
            get
            {
                return Apellido +" "+ Nombre; 

            }
        }

        public string FechaNacimientoCorta
        {
            get
            {
                return FechaNacimiento.ToShortDateString();
            }
        }
    }
}
