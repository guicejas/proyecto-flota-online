using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public partial class SingletonSistFlota
    {
        private static SistFlota_ModeloDatosContainer Instancia = null;

        private SingletonSistFlota()
        {

        }

        public static SistFlota_ModeloDatosContainer ObtenerInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new SistFlota_ModeloDatosContainer();
            }
            return Instancia;
        }


    }
}
