using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.AUDITORIA;

namespace Modelo
{
    public partial class SingletonAuditoria
    {

        private static SistFlota_ModeloAuditoriaContainer Instancia = null;

        private SingletonAuditoria()
        { }

        public static SistFlota_ModeloAuditoriaContainer ObtenerInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new SistFlota_ModeloAuditoriaContainer();
            }

            return Instancia;
        }


    }
}
