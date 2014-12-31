using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class ControladoraTiposdeGasto
    {

        private static volatile ControladoraTiposdeGasto instancia;

        ControladoraTiposdeGasto()
        {
        }

        public static ControladoraTiposdeGasto getINSTANCIA
        {
            get
            {
                if (instancia == null) instancia = new ControladoraTiposdeGasto();
                return instancia;
            }
        }

        public List<Modelo.TipodeGasto> ListarTiposdeGasto()
        {
            return Modelo.SingletonSistFlota.ObtenerInstancia().TiposdeGasto.OrderBy(t => t.Descripcion).ToList();
        }


        public Modelo.TipodeGasto ObtenerTipodeGasto(int tipogastoId)
        {
            Modelo.TipodeGasto oTipoGasto = Modelo.SingletonSistFlota.ObtenerInstancia().TiposdeGasto.Find(tipogastoId);
            return oTipoGasto;
        }

        public string ObtenerDescripcion(int tipogastoID)
        {
            Modelo.TipodeGasto oTipoGasto = Modelo.SingletonSistFlota.ObtenerInstancia().TiposdeGasto.Find(tipogastoID);
            return oTipoGasto.Descripcion;


        }

        public void CargarTiposdeGasto()
        {
            List<Modelo.TipodeGasto> Lista = Modelo.SingletonSistFlota.ObtenerInstancia().TiposdeGasto.ToList();
            if (Lista.Count == 0)
            {
                Modelo.TipodeGasto a = new Modelo.TipodeGasto();
                a.Descripcion = "INFRACCION";
                Modelo.SingletonSistFlota.ObtenerInstancia().TiposdeGasto.Add(a);
                Modelo.TipodeGasto b = new Modelo.TipodeGasto();
                b.Descripcion = "TALLER";
                Modelo.SingletonSistFlota.ObtenerInstancia().TiposdeGasto.Add(b);
                Modelo.TipodeGasto c = new Modelo.TipodeGasto();
                c.Descripcion = "PATENTE";
                Modelo.SingletonSistFlota.ObtenerInstancia().TiposdeGasto.Add(c);
                Modelo.TipodeGasto d = new Modelo.TipodeGasto();
                d.Descripcion = "SEGURO";
                Modelo.SingletonSistFlota.ObtenerInstancia().TiposdeGasto.Add(d);
                Modelo.TipodeGasto e = new Modelo.TipodeGasto();
                e.Descripcion = "CUBIERTAS";
                Modelo.SingletonSistFlota.ObtenerInstancia().TiposdeGasto.Add(e);

                Modelo.SingletonSistFlota.ObtenerInstancia().SaveChanges();

                Modelo.Vehiculo f = new Modelo.Vehiculo();
                f.Patente = "APD-463";
                f.Marca = "FIAT";
                f.Modelo = "DUNA";
                f.PatenteTaxi = 927;
                f.Año = 1996;
                f.Color = "BLANCO";
                f.Kilometraje = 130000;
                Modelo.SingletonSistFlota.ObtenerInstancia().Vehiculos.Add(f);

                Modelo.Gasto g = new Modelo.Gasto();
                g.Descripcion = "Cambio de 4 neumaticos";
                g.Estado = "PENDIENTE";
                g.FechaVencimiento = DateTime.Today;
                g.Monto = 450;
                g.Vehiculo = f; // Modelo.Datos.ObtenerInstancia().Vehiculos.FirstOrDefault();
                g.TipodeGasto = e; // Modelo.Datos.ObtenerInstancia().TiposdeGasto.FirstOrDefault(); = 
                g.Usuario = "Sistema";
                g.FechayHora = DateTime.Now;
                g.Operacion = "ALTA";
                Modelo.SingletonSistFlota.ObtenerInstancia().Gastos.Add(g);

                Modelo.SingletonSistFlota.ObtenerInstancia().SaveChanges();
            }






        }
    }
}
