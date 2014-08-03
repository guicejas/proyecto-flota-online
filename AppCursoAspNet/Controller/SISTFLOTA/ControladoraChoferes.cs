using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Controladora
{
    public class ControladoraChoferes
    {
        private static volatile ControladoraChoferes instancia;

        public ControladoraChoferes()
        {
        }
        public static ControladoraChoferes getINSTANCIA
        {
            get
            {
                if (instancia == null) instancia = new ControladoraChoferes();
                return instancia;
            }
        }

        public void AgregarChofer(Modelo.Chofer oChofer)
        {
            Modelo.SingletonSistFlota.ObtenerInstancia().Choferes.Add(oChofer);
            Modelo.SingletonSistFlota.ObtenerInstancia().SaveChanges();
        }
        public void EliminarChofer(int documento)
        {
            Modelo.Chofer oChofer = Modelo.SingletonSistFlota.ObtenerInstancia().Choferes.Find(documento);
            Modelo.SingletonSistFlota.ObtenerInstancia().Choferes.Remove(oChofer);
            Modelo.SingletonSistFlota.ObtenerInstancia().SaveChanges();
        }
        public void ModificarChofer(Modelo.Chofer oChofer)
        {
            Modelo.SingletonSistFlota.ObtenerInstancia().Entry(oChofer).State = System.Data.Entity.EntityState.Modified;
            Modelo.SingletonSistFlota.ObtenerInstancia().SaveChanges();
        }
        public List<Modelo.Chofer> ListarChoferes()
        {
            return Modelo.SingletonSistFlota.ObtenerInstancia().Choferes.ToList();

        }

        public bool VerificarChofer(Modelo.Chofer oChofer)
        {
            List<Modelo.Chofer> Lista = Modelo.SingletonSistFlota.ObtenerInstancia().Choferes.Where(oChof => oChof.Documento == oChofer.Documento).ToList();

            if (Lista.Count > 0)
            {
                return false;
            }
            return true;
        }

        public bool VerificarLicencia(Modelo.Chofer oChofer)
        {
            List<Modelo.Chofer> Lista = Modelo.SingletonSistFlota.ObtenerInstancia().Choferes.Where(oChof => oChof.Licencia == oChofer.Licencia).ToList();

            if (Lista.Count > 0)
            {
                return false;
            }
            return true;
        }
        public Modelo.Chofer ObtenerChofer(int DNI)
        {
            Modelo.Chofer oChofer = Modelo.SingletonSistFlota.ObtenerInstancia().Choferes.Find(DNI);
            return oChofer;
        }
    }
}
