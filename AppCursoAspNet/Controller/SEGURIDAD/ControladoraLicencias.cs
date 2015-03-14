using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.SEGURIDAD;

namespace Controladora.SEGURIDAD
{
    public class ControladoraLicencias
    {

        public List<Licencia> ListarLicencias()
        {
            return Modelo.SingletonSeguridad.ObtenerInstancia().Licencias.OrderBy(c => c.Id).ToList();
        }


        public void AgregarLicencia(Licencia oLicencia)
        {
            Modelo.SingletonSeguridad.ObtenerInstancia().Licencias.Add(oLicencia);
            Modelo.SingletonSeguridad.ObtenerInstancia().SaveChanges();
        }

        public void EliminarLicencia(string IDLicencia)
        {
            Licencia oLicencia = Modelo.SingletonSeguridad.ObtenerInstancia().Licencias.Find(IDLicencia);
            //oLicencia.Usuario.Clear();

            Modelo.SingletonSeguridad.ObtenerInstancia().Licencias.Remove(oLicencia);
            Modelo.SingletonSeguridad.ObtenerInstancia().SaveChanges();
        }

        public void ModificarLicencia(Licencia oLicencia)
        {
            Modelo.SingletonSeguridad.ObtenerInstancia().Entry(oLicencia).State = System.Data.Entity.EntityState.Modified;
            Modelo.SingletonSeguridad.ObtenerInstancia().SaveChanges();
        }

        public Licencia ObtenerLicencia(string LicenciaId)
        {
            int idLicencia = Convert.ToInt32(LicenciaId);

            Licencia oLicencia = Modelo.SingletonSeguridad.ObtenerInstancia().Licencias.Find(idLicencia);
            return oLicencia;
        }

        public bool VerificarLicencia(Licencia oLicencia)
        {
            List<Licencia> Lista = Modelo.SingletonSeguridad.ObtenerInstancia().Licencias.Where(oFlo => oFlo.Id == oFlo.Id).ToList();
            if (Lista.Count > 0)
            {
                return false;
            }
            return true;
        }

        public List<Licencia> ListarLicenciasFiltrados(string IDLicencia)
        {
            return Modelo.SingletonSeguridad.ObtenerInstancia().Licencias.Where(oFlo => oFlo.Id.ToString().Contains(IDLicencia)).OrderBy(c => c.Id).ToList();
        }

        public Licencia ObtenerLicenciadeUsuario(string idUsuario)
        {
            Usuario oUsuario = Modelo.SingletonSeguridad.ObtenerInstancia().Usuarios.Find(idUsuario);
            return oUsuario.Flota.Licencia.Where(x => x.FechaFin > DateTime.Now).FirstOrDefault();
        }
    }
}
