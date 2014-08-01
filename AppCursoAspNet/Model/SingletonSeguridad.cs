using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.SEGURIDAD;

namespace Modelo
{
    public partial class SingletonSeguridad
    {
        private static SistFlota_Seguridad_ModeloContainer Instancia = null;

        private SingletonSeguridad()
        { }

        public static SistFlota_Seguridad_ModeloContainer ObtenerInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new SistFlota_Seguridad_ModeloContainer();
            }

            return Instancia;
        }

    }
}
