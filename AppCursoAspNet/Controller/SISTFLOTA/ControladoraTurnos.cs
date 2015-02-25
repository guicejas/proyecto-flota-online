using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora
{
    public class ControladoraTurnos
    {
        private static volatile ControladoraTurnos instancia;

        ControladoraTurnos()
        {
        }
        public static ControladoraTurnos getINSTANCIA
        {
            get
            {
                if (instancia == null) instancia = new ControladoraTurnos();
                return instancia;
            }
        }

        public void AgregarTurno(Modelo.Turno oTurno)
        {
            Modelo.SingletonSistFlota.ObtenerInstancia().Turnos.Add(oTurno);
            Modelo.SingletonSistFlota.ObtenerInstancia().SaveChanges();
        }
        public bool EliminarTurno(int idTurno)
        {
            Modelo.Turno oTurno = Modelo.SingletonSistFlota.ObtenerInstancia().Turnos.Find(idTurno);
            Modelo.SingletonSistFlota.ObtenerInstancia().Turnos.Remove(oTurno);
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
        public void ModificarTurno(Modelo.Turno oTurno)
        {
            Modelo.SingletonSistFlota.ObtenerInstancia().Entry(oTurno).State = System.Data.Entity.EntityState.Modified;
            Modelo.SingletonSistFlota.ObtenerInstancia().SaveChanges();
        }
        public List<Modelo.Turno> ListarTurnos(string flotaId)
        {
            int flota = Convert.ToInt32(flotaId);

            if (flota == 0)
                return Modelo.SingletonSistFlota.ObtenerInstancia().Turnos.ToList();
            else
                return Modelo.SingletonSistFlota.ObtenerInstancia().Turnos.Where(oTur => oTur.fIDFlota == flota).ToList();
        }

        public Modelo.Turno ObtenerTurno(int idTurno)
        {
            Modelo.Turno oTurno = Modelo.SingletonSistFlota.ObtenerInstancia().Turnos.Find(idTurno);
            return oTurno;
        }


        public List<Modelo.Turno> ListarTurnosFiltrados(string flotaId, string chofer, Nullable<System.DateTime> fecha, string vehiculo)
        {
            int flota = Convert.ToInt32(flotaId);
            List<Modelo.Turno> Filtrado;

            if (flota == 0)
                Filtrado = Modelo.SingletonSistFlota.ObtenerInstancia().Turnos.ToList();
            else
                Filtrado = Modelo.SingletonSistFlota.ObtenerInstancia().Turnos.Where(oTur => oTur.fIDFlota == flota).ToList();


            if (vehiculo != null)
                Filtrado = Filtrado.Where(oTur => oTur.Vehiculo.Patente.IndexOf(vehiculo, System.StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            if (fecha != null)
                Filtrado = Filtrado.Where(oTur => oTur.FechaInicio == Convert.ToDateTime(fecha).Date).ToList();
            if (chofer != null)
                Filtrado = Filtrado.Where(oTur => oTur.Chofer.NombreCompleto.IndexOf(chofer, System.StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            return Filtrado;
        }
    }
}
