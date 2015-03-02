using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;

namespace Controladora
{
    public class ControladoraGastos
    {
        private static volatile ControladoraGastos instancia;

        ControladoraGastos()
        {
        }
        
        public static ControladoraGastos getINSTANCIA
        {
            get
            {
                if (instancia == null) instancia = new ControladoraGastos();
                return instancia;
            }
        }

        public void AgregarGasto(Modelo.Gasto oGasto)
        {
            Modelo.SingletonSistFlota.ObtenerInstancia().Gastos.Add(oGasto);
            Modelo.SingletonSistFlota.ObtenerInstancia().SaveChanges();
        }
        public bool EliminarGasto(int gastoId)
        {
            Modelo.Gasto oGasto = Modelo.SingletonSistFlota.ObtenerInstancia().Gastos.Find(gastoId);
            Modelo.SingletonSistFlota.ObtenerInstancia().Gastos.Remove(oGasto);
            try
            {
                Modelo.SingletonSistFlota.ObtenerInstancia().SaveChanges();
                return false;
            }
            catch
            {
                return true;
            }
        }
        public void ModificarGasto(Modelo.Gasto oGasto)
        {
            Modelo.SingletonSistFlota.ObtenerInstancia().Entry(oGasto).State = System.Data.Entity.EntityState.Modified;
            Modelo.SingletonSistFlota.ObtenerInstancia().SaveChanges();
        }

        public List<Modelo.Gasto> ListarGastos(string flotaId)
        {
            int flota = Convert.ToInt32(flotaId);

            if (flota == 0)
                return Modelo.SingletonSistFlota.ObtenerInstancia().Gastos.ToList();
            else
                return Modelo.SingletonSistFlota.ObtenerInstancia().Gastos.Where(oGas => oGas.fIDFlota == flota).ToList();
        }

        public Modelo.Gasto ObtenerGasto(int gastoId)
         {
            Modelo.Gasto oGasto = Modelo.SingletonSistFlota.ObtenerInstancia().Gastos.Find(gastoId);
            return oGasto;
         }

        //public List<Modelo.Gasto> ListarGastosFiltrados(string flotaId, string Id, Modelo.Vehiculo oVehiculoF, Modelo.TipodeGasto oTipodeGastoF, string Monto, string Estado, string Descripcion, DateTime VenceDesde, DateTime VenceHasta)
        //{
        //    int flota = Convert.ToInt32(flotaId);
        //    List<Modelo.Gasto> Filtrado;

        //    if (flota == 0)
        //        Filtrado =  Modelo.SingletonSistFlota.ObtenerInstancia().Gastos.ToList();
        //    else
        //        Filtrado =  Modelo.SingletonSistFlota.ObtenerInstancia().Gastos.Where(oGas => oGas.fIDFlota == flota).ToList();

        //    if (Id.ToString() != "")
        //        Filtrado = Filtrado.Where(oGas => oGas.Id == Convert.ToInt32(Id)).ToList();
        //    if (oVehiculoF != null)
        //        Filtrado = Filtrado.Where(oGas => oGas.Vehiculo == oVehiculoF).ToList();
        //    if (oTipodeGastoF != null)
        //        Filtrado = Filtrado.Where(oGas => oGas.TipodeGasto == oTipodeGastoF).ToList();
        //    if (Monto.ToString() != "")
        //        Filtrado = Filtrado.Where(oGas => oGas.Monto == Convert.ToDecimal(Monto)).ToList();
        //    if (Estado != "")
        //        Filtrado = Filtrado.Where(oGas => oGas.Estado == Estado).ToList();
        //    if (Descripcion != "")
        //        Filtrado = Filtrado.Where(oGas => oGas.Descripcion.Contains(Descripcion)).ToList();
        //    if (VenceDesde.ToString() != null)
        //        Filtrado = Filtrado.Where(oGas => oGas.FechaVencimiento > VenceDesde).ToList();
        //    if (VenceHasta.ToString() != null)
        //        Filtrado = Filtrado.Where(oGas => oGas.FechaVencimiento < VenceHasta).ToList();
           
        //    return Filtrado;
        //}

        public List<Modelo.Gasto> ListarGastosFiltrados(string flotaId, string descripcion, Nullable<System.DateTime> fechaVencimiento, string estado, string vehiculo)
        {
            int flota = Convert.ToInt32(flotaId);
            List<Modelo.Gasto> Filtrado;

            if (flota == 0)
                Filtrado = Modelo.SingletonSistFlota.ObtenerInstancia().Gastos.ToList();
            else
                Filtrado = Modelo.SingletonSistFlota.ObtenerInstancia().Gastos.Where(oGas => oGas.fIDFlota == flota).ToList();
            
            if (vehiculo != null)
                Filtrado = Filtrado.Where(oGas => oGas.Vehiculo.Patente.IndexOf(vehiculo, System.StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            if (fechaVencimiento != null)
                Filtrado = Filtrado.Where(oGas => oGas.FechaVencimiento == Convert.ToDateTime(fechaVencimiento).Date).ToList();
            if (estado != null)
                Filtrado = Filtrado.Where(oGas => oGas.Estado.IndexOf(estado, System.StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            if (descripcion != null)
                Filtrado = Filtrado.Where(oGas => oGas.Descripcion.IndexOf(descripcion, System.StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            return Filtrado;
        }

        /* public static void ActualizarGasto(Modelo.Gasto oGasto)
         {
             //Modelo.Datos.ObtenerInstancia() .Socios.MergeOption = System.Data.Objects.MergeOption.OverwriteChanges;
             Modelo.Datos.ObtenerInstancia().Refresh(System.Data.Objects.RefreshMode.StoreWins, Modelo.Datos.ObtenerInstancia().Gasto);
         }*/

        public List<Modelo.Gasto> ListarGastosMonitor(string flotaId)
        {
            int flota = Convert.ToInt32(flotaId);
            List<Modelo.Gasto> Filtrado;

            if (flota == 0)
                Filtrado = Modelo.SingletonSistFlota.ObtenerInstancia().Gastos.OrderBy(x => x.FechaVencimiento).ToList();
            else
                Filtrado = Modelo.SingletonSistFlota.ObtenerInstancia().Gastos.Where(oGas => oGas.fIDFlota == flota).OrderBy(x => x.FechaVencimiento).ToList();

            //Filtrado = Filtrado.Where(oGas => oGas.FechaVencimiento.Date >= DateTime.Today.Date).ToList();
            Filtrado = Filtrado.Where(oGas => oGas.FechaVencimiento.Date < DateTime.Today.Date.AddDays(15)).ToList();
            Filtrado = Filtrado.Where(oGas => oGas.Estado == "PENDIENTE").ToList();

            return Filtrado;

        }

        public List<Modelo.Gasto> ListarGastosVerde(string flotaId)
        {
            int flota = Convert.ToInt32(flotaId);
            List<Modelo.Gasto> Filtrado;

            if (flota == 0)
                Filtrado = Modelo.SingletonSistFlota.ObtenerInstancia().Gastos.OrderBy(x => x.FechaVencimiento).ToList();
            else
                Filtrado = Modelo.SingletonSistFlota.ObtenerInstancia().Gastos.Where(oGas => oGas.fIDFlota == flota).OrderBy(x => x.FechaVencimiento).ToList();


            Filtrado = Filtrado.Where(oGas => oGas.FechaVencimiento.Date <= DateTime.Today.Date.AddDays(15)).ToList();
            Filtrado = Filtrado.Where(oGas => oGas.Estado == "PENDIENTE").ToList();

            return Filtrado;

        }

        public List<Modelo.Gasto> ListarGastosAmarillo(string flotaId)
        {
            int flota = Convert.ToInt32(flotaId);
            List<Modelo.Gasto> Filtrado;

            if (flota == 0)
                Filtrado = Modelo.SingletonSistFlota.ObtenerInstancia().Gastos.OrderBy(x => x.FechaVencimiento).ToList();
            else
                Filtrado = Modelo.SingletonSistFlota.ObtenerInstancia().Gastos.Where(oGas => oGas.fIDFlota == flota).OrderBy(x => x.FechaVencimiento).ToList();

            Filtrado = Filtrado.Where(oGas => oGas.FechaVencimiento.Date <= DateTime.Today.Date.AddDays(7)).ToList();
            Filtrado = Filtrado.Where(oGas => oGas.Estado == "PENDIENTE").ToList();

            return Filtrado;

        }

        public List<Modelo.Gasto> ListarGastosRojo(string flotaId)
        {
            int flota = Convert.ToInt32(flotaId);
            List<Modelo.Gasto> Filtrado;

            if (flota == 0)
                Filtrado = Modelo.SingletonSistFlota.ObtenerInstancia().Gastos.OrderBy(x => x.FechaVencimiento).ToList();
            else
                Filtrado = Modelo.SingletonSistFlota.ObtenerInstancia().Gastos.Where(oGas => oGas.fIDFlota == flota).OrderBy(x => x.FechaVencimiento).ToList();

            Filtrado = Filtrado.Where(oGas => oGas.FechaVencimiento.Date <= DateTime.Today.Date.AddDays(2)).ToList();
            Filtrado = Filtrado.Where(oGas => oGas.Estado == "PENDIENTE").ToList();

            return Filtrado;

        }


        /*
        public static IOrderedQueryable<Modelo.Gasto> ListarGastosMonitor()
        {
            var Filtrado2 = Modelo.Datos.ObtenerInstancia().Gastos.OrderBy(c => c.FechaVencimiento);
            List<Modelo.Gasto> Filtrado3 = Modelo.Datos.ObtenerInstancia().Gastos.OrderByDescending(c => c.FechaVencimiento);
            List<Modelo.Gasto> Filtrado = Modelo.Datos.ObtenerInstancia().Gastos.OrderBy("it.FechaVencimiento ASC").ToList();
            Filtrado = Filtrado.Where(oGas => oGas.FechaVencimiento.Date >= DateTime.Today.Date).ToList();
            Filtrado = Filtrado.Where(oGas => oGas.FechaVencimiento.Date < DateTime.Today.Date.AddDays(15)).ToList();
            Filtrado = Filtrado.Where(oGas => oGas.Estado == "PENDIENTE").ToList();

            return Filtrado2;

        }
         */

        public List<Modelo.Gasto> ListarGastosdeVehiculo(string Patente)
        {
            List<Modelo.Gasto> Filtrado = Modelo.SingletonSistFlota.ObtenerInstancia().Gastos.ToList();

            Filtrado = Filtrado.Where(oGas => oGas.Vehiculo.Patente == Patente).ToList();

                return Filtrado.OrderByDescending(x => x.Monto).ToList();
        }

        public int BarraProgresoRojo(string flotaId)
        {
            int flota = Convert.ToInt32(flotaId);
            List<Modelo.Gasto> Filtrado;

            if (flota == 0)
                Filtrado = Modelo.SingletonSistFlota.ObtenerInstancia().Gastos.OrderBy(x => x.FechaVencimiento).ToList();
            else
                Filtrado = Modelo.SingletonSistFlota.ObtenerInstancia().Gastos.Where(oGas => oGas.fIDFlota == flota).OrderBy(x => x.FechaVencimiento).ToList();

            Filtrado = Filtrado.Where(oGas => oGas.FechaVencimiento.Date <= DateTime.Today.Date.AddDays(2)).ToList();
            Filtrado = Filtrado.Where(oGas => oGas.Estado == "PENDIENTE").ToList();
            return Filtrado.Count();
        }

        public int BarraProgresoAmarillo(string flotaId)
        {
            int flota = Convert.ToInt32(flotaId);
            List<Modelo.Gasto> Filtrado;

            if (flota == 0)
                Filtrado = Modelo.SingletonSistFlota.ObtenerInstancia().Gastos.OrderBy(x => x.FechaVencimiento).ToList();
            else
                Filtrado = Modelo.SingletonSistFlota.ObtenerInstancia().Gastos.Where(oGas => oGas.fIDFlota == flota).OrderBy(x => x.FechaVencimiento).ToList();

            Filtrado = Filtrado.Where(oGas => oGas.FechaVencimiento.Date > DateTime.Today.Date.AddDays(2)).ToList();
            Filtrado = Filtrado.Where(oGas => oGas.FechaVencimiento.Date <= DateTime.Today.Date.AddDays(7)).ToList();
            Filtrado = Filtrado.Where(oGas => oGas.Estado == "PENDIENTE").ToList();
            return Filtrado.Count();
        }

        public int BarraProgresoVerde(string flotaId)
        {
            int flota = Convert.ToInt32(flotaId);
            List<Modelo.Gasto> Filtrado;

            if (flota == 0)
                Filtrado = Modelo.SingletonSistFlota.ObtenerInstancia().Gastos.OrderBy(x => x.FechaVencimiento).ToList();
            else
                Filtrado = Modelo.SingletonSistFlota.ObtenerInstancia().Gastos.Where(oGas => oGas.fIDFlota == flota).OrderBy(x => x.FechaVencimiento).ToList();

            Filtrado = Filtrado.Where(oGas => oGas.FechaVencimiento.Date > DateTime.Today.Date.AddDays(7)).ToList();
            Filtrado = Filtrado.Where(oGas => oGas.FechaVencimiento.Date <= DateTime.Today.Date.AddDays(15)).ToList();
            Filtrado = Filtrado.Where(oGas => oGas.Estado == "PENDIENTE").ToList();
            return Filtrado.Count();
        }



    }
}
