using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class ControladoraVehiculos
    {
        private static volatile ControladoraVehiculos instancia;

        ControladoraVehiculos()
        {
        }
        public static ControladoraVehiculos getINSTANCIA
        {
            get
            {
                if (instancia == null) instancia = new ControladoraVehiculos();
                return instancia;
            }
        }


        public void AgregarVehiculo(Modelo.Vehiculo oVehiculo)
        {
            Modelo.SingletonSistFlota.ObtenerInstancia().Vehiculos.Add(oVehiculo);
            Modelo.SingletonSistFlota.ObtenerInstancia().SaveChanges();
        }
        public bool EliminarVehiculo(string patente)
        {
            Modelo.Vehiculo oVehiculo = Modelo.SingletonSistFlota.ObtenerInstancia().Vehiculos.Find(patente);
            Modelo.SingletonSistFlota.ObtenerInstancia().Vehiculos.Remove(oVehiculo);
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
        public void ModificarVehiculo(Modelo.Vehiculo oVehiculo)
        {
            Modelo.SingletonSistFlota.ObtenerInstancia().Entry(oVehiculo).State = System.Data.Entity.EntityState.Modified;
            Modelo.SingletonSistFlota.ObtenerInstancia().SaveChanges();
        }

        public Modelo.Vehiculo ObtenerVehiculo(string numPatente)
        {
            Modelo.Vehiculo oVehiculo = Modelo.SingletonSistFlota.ObtenerInstancia().Vehiculos.Find(numPatente);
            return oVehiculo;
        }

        public List<Modelo.Vehiculo> ListarVehiculos()
        {
            return Modelo.SingletonSistFlota.ObtenerInstancia().Vehiculos.OrderBy(c => c.Patente).ToList();


        }

        public List<Modelo.Vehiculo> ListarVehiculosFiltrados(string Patente, string PatenteTaxi, string Año)
        {
            List<Modelo.Vehiculo> Filtrado = Modelo.SingletonSistFlota.ObtenerInstancia().Vehiculos.OrderBy(c => c.Patente).ToList();
            if (Patente != null)
                Filtrado = Filtrado.Where(oVeh => oVeh.Patente.IndexOf(Patente, System.StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            if (PatenteTaxi != null)
                Filtrado = Filtrado.Where(oVeh => oVeh.PatenteTaxi.ToString().IndexOf(PatenteTaxi, System.StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            if (Año != null)
                Filtrado = Filtrado.Where(oVeh => oVeh.Año.ToString().IndexOf(Año, System.StringComparison.OrdinalIgnoreCase) >= 0).ToList();


            return Filtrado;
        }


        public bool VerificarVehiculo(Modelo.Vehiculo oVehiculo)
        {
            List<Modelo.Vehiculo> Lista = Modelo.SingletonSistFlota.ObtenerInstancia().Vehiculos.Where(oVeh => oVeh.Patente == oVehiculo.Patente).ToList();

            if (Lista.Count > 0)
            {
                return false;
            }
            return true;
        }

        public bool VerificarPatenteTaxi(Modelo.Vehiculo oVehiculo)
        {
            List<Modelo.Vehiculo> Lista = Modelo.SingletonSistFlota.ObtenerInstancia().Vehiculos.Where(oVeh => oVeh.PatenteTaxi == oVehiculo.PatenteTaxi).ToList();

            if (Lista.Count > 0)
            {
                return false;
            }
            return true;
        }


        public List<Modelo.Vehiculo> ListarVehiculosGastos()
        {

            List<Modelo.Vehiculo> list = Modelo.SingletonSistFlota.ObtenerInstancia().Vehiculos.ToList();

            list = list.OrderByDescending(c => c.sumaGastos).ToList();

            return list;
        }


        public List<Modelo.Vehiculo> ListarVehiculosActivos()
        {
            List<Modelo.Vehiculo> list = Modelo.SingletonSistFlota.ObtenerInstancia().Vehiculos.Where(c => c.PatenteTaxi != null).ToList();

            return list;
        }
    }
}
