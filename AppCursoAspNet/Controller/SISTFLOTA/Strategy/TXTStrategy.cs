using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.SISTFLOTA.Strategy
{
    public class TXTStrategy : IStrategy
    {
        public string GenerarReporteGastos()
        {
            string filename = "test.txt";
            System.Diagnostics.Debug.WriteLine("Reporte en formato TXT");

            return filename;
        }

        public void GenerarReporteVehiculosActivos()
        {
            //Console.WriteLine("");
        }
    }
}
