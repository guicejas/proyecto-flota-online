using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public partial class Gasto
    {
        public string PatVehiculo
        {
            get
            {
                return Vehiculo.Patente;
            }
        }

        public string TipoGasto
        {
            get
            {
                return TipodeGasto.Descripcion;
            }
        }

        public string Semaforo
        {
            get
            {
                return ObtenerSemaforo();
            }
        }

        public string FechaVencimientoCorta
        {
            get
            {
                return FechaVencimiento.ToShortDateString();
            }
        }

        public void Pagar(/*Modelo.SEGURIDAD.Usuario oUsuario*/)
        {
            Estado = "PAGADO";
            FechaVencimiento = DateTime.Now;
            Operacion = "MODIFICACION";
            //Usuario = oUsuario.IDusuario;
            FechayHora = DateTime.Now;
        }

        public string ObtenerSemaforo()
        {
            string color = "";
            if (this.FechaVencimiento.Date <= DateTime.Today.Date.AddDays(15))
            {
                color = "verde";
            }
            if (this.FechaVencimiento.Date <= DateTime.Today.Date.AddDays(7))
            {
                color = "amarillo";
            }
            if (this.FechaVencimiento.Date <= DateTime.Today.Date.AddDays(2))
            {
                color = "rojo";
            }
            return color;
        }
        public string id_desc
        {
            get
            {
                return Id + " " + Descripcion;
            }
        }
    }
}
