using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo    
{
    public partial class Vehiculo
    {
        public decimal sumaGastos
        {
            get
            {
                decimal total = 0;
                try
                {
                    var lista = Gasto.ToList();
                    
                    foreach (Gasto g in lista)
                    {
                        total += g.Monto;
                    }

                    return total;
                }
                catch
                {
                    return total;
                }

            }
        }

        public string Activo
        {
            get
            {
                if (PatenteTaxi == null)
                {
                    return "NO";
                }
                else
                {
                    return "SI";

                }

            }
        }
    }
}
