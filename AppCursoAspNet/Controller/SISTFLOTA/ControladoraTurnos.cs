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

        public ControladoraTurnos()
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
        public void EliminarTurno(int idTurno)
        {
            Modelo.Turno oTurno = Modelo.SingletonSistFlota.ObtenerInstancia().Turnos.Find(idTurno);
            Modelo.SingletonSistFlota.ObtenerInstancia().Turnos.Remove(oTurno);
            Modelo.SingletonSistFlota.ObtenerInstancia().SaveChanges();
        }
        public void ModificarTurno(Modelo.Turno oTurno)
        {
            Modelo.SingletonSistFlota.ObtenerInstancia().Entry(oTurno).State = System.Data.Entity.EntityState.Modified;
            Modelo.SingletonSistFlota.ObtenerInstancia().SaveChanges();
        }
        public List<Modelo.Turno> ListarTurnos()
        {
            return Modelo.SingletonSistFlota.ObtenerInstancia().Turnos.ToList();
        }

        public Modelo.Turno ObtenerTurno(int idTurno)
        {
            Modelo.Turno oTurno = Modelo.SingletonSistFlota.ObtenerInstancia().Turnos.Find(idTurno);
            return oTurno;
        }
    }
}
