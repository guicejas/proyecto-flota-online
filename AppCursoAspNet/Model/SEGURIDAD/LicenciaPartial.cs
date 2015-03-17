using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.SEGURIDAD
{
    public partial class Licencia
    {
        public string getFlota()
        {

                return this.Flota.RazonSocial;

        }

        public string getDescipcionTipo()
        {

                return this.TipoLicencia.Descripcion;

        }


        public string getColor()
        {
            string color = "";
            if (this.Estado == "Aceptada")
            {
                color = "verde";
            }
            if (this.Estado == "Pendiente Confirmacion")
            {
                color = "amarillo";
            }
            if (this.Estado == "Rechazada")
            {
                color = "rojo";
            }
            if (this.Estado == "Expirada")
            {
                color = "rojo";
            }
            return color;
            
        }

        public string tipoLicencia()
        {
            return this.TipoLicencia.tipo;
        }
    }


}
