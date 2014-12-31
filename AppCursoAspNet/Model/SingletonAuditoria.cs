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

        private static Sist_Flota_ModeloAuditoriaContainer Instancia = null;

        private SingletonAuditoria()
        { }

        public static Sist_Flota_ModeloAuditoriaContainer ObtenerInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new Sist_Flota_ModeloAuditoriaContainer();
            }

            return Instancia;
        }


    }
}
