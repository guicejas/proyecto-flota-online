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

        ControladoraChoferes()
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
        public bool EliminarChofer(int documento)
        {
            Modelo.Chofer oChofer = Modelo.SingletonSistFlota.ObtenerInstancia().Choferes.Find(documento);
            Modelo.SingletonSistFlota.ObtenerInstancia().Choferes.Remove(oChofer);
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

        public List<Modelo.Chofer> ListarChoferesFiltrados(string documento, string nombre, string localidad)
        {
            List<Modelo.Chofer> Filtrado = Modelo.SingletonSistFlota.ObtenerInstancia().Choferes.ToList();
            if (documento != null)
                Filtrado = Filtrado.Where(oCho => oCho.Documento == Convert.ToInt64(documento)).ToList();
            if (nombre != null)
                Filtrado = Filtrado.Where(oCho => oCho.Nombre.IndexOf(nombre, System.StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            if (localidad != null)
                Filtrado = Filtrado.Where(oCho => oCho.Localidad.IndexOf(localidad, System.StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            return Filtrado;
        }
    }
}
