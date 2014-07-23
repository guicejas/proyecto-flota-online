using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class ControladoraVehiculos
    {
        private static volatile ControladoraVehiculos instancia;

        public ControladoraVehiculos()
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
        public void EliminarVehiculo(string patente)
        {
            Modelo.Vehiculo oVehiculo = Modelo.SingletonSistFlota.ObtenerInstancia().Vehiculos.Find(patente);
            Modelo.SingletonSistFlota.ObtenerInstancia().Vehiculos.Remove(oVehiculo);
            Modelo.SingletonSistFlota.ObtenerInstancia().SaveChanges();
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

        public List<Modelo.Vehiculo> ListarVehiculosFiltrados(string Patente, string PatenteTaxi, string Marca, string Año)
        {
            List<Modelo.Vehiculo> Filtrado = Modelo.SingletonSistFlota.ObtenerInstancia().Vehiculos.OrderBy(c => c.Patente).ToList();
            if (Patente != "")
                Filtrado = Filtrado.Where(oVeh => oVeh.Patente == Patente).ToList();
            if (PatenteTaxi != "")
                Filtrado = Filtrado.Where(oVeh => oVeh.PatenteTaxi == Convert.ToInt32(PatenteTaxi)).ToList();
            if (Marca != "")
                Filtrado = Filtrado.Where(oVeh => oVeh.Marca.Contains(Marca)).ToList();
            if (Año != "")
                Filtrado = Filtrado.Where(oVeh => oVeh.Año == Convert.ToInt32(Año)).ToList();


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
