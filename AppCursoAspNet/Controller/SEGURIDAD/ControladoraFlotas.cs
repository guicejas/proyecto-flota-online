using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.SEGURIDAD;

namespace Controladora.SEGURIDAD
{
    public class ControladoraFlotas
    {

        public List<Flota> ListarFlotas()
        {
            return Modelo.SingletonSeguridad.ObtenerInstancia().Flotas.OrderBy(c => c.Id).ToList();
        }


        public void AgregarFlota(Flota oFlota)
        {
            Modelo.SingletonSeguridad.ObtenerInstancia().Flotas.Add(oFlota);
            Modelo.SingletonSeguridad.ObtenerInstancia().SaveChanges();
        }

        public void EliminarFlota(string IDFlota)
        {
            Flota oFlota = Modelo.SingletonSeguridad.ObtenerInstancia().Flotas.Find(IDFlota);
            oFlota.Usuario.Clear();

            Modelo.SingletonSeguridad.ObtenerInstancia().Flotas.Remove(oFlota);
            Modelo.SingletonSeguridad.ObtenerInstancia().SaveChanges();
        }

        public void ModificarFlota(Flota oFlota)
        {
            Modelo.SingletonSeguridad.ObtenerInstancia().Entry(oFlota).State = System.Data.Entity.EntityState.Modified;
            Modelo.SingletonSeguridad.ObtenerInstancia().SaveChanges();
        }

        public Flota ObtenerFlota(string flotaId)
        {
            Flota oFlota = Modelo.SingletonSeguridad.ObtenerInstancia().Flotas.Find(flotaId);
            return oFlota;
        }

        public bool VerificarFlota(Flota oFlota)
        {
            List<Flota> Lista = Modelo.SingletonSeguridad.ObtenerInstancia().Flotas.Where(oFlo => oFlo.Id == oFlo.Id).ToList();
            if (Lista.Count > 0)
            {
                return false;
            }
            return true;
        }

        public List<Flota> ListarFlotasFiltrados(string IDFlota)
        {
            return Modelo.SingletonSeguridad.ObtenerInstancia().Flotas.Where(oFlo => oFlo.Id.ToString().Contains(IDFlota)).OrderBy(c => c.Id).ToList();
        }

        public Flota ObtenerFlotadeUsuario(string idUsuario)
        {
            Usuario oUsuario = Modelo.SingletonSeguridad.ObtenerInstancia().Usuarios.Find(idUsuario);
            return oUsuario.Flota;
        }
    }
}
