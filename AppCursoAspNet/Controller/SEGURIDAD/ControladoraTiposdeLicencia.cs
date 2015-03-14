using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.SEGURIDAD;

namespace Controladora.SEGURIDAD
{
    public class ControladoraTiposdeLicencia
    {

        public List<TipoLicencia> ListarTiposdeLicencia()
        {
            return Modelo.SingletonSeguridad.ObtenerInstancia().Tiposdelicencia.Where(c=> c.Activo == 1).OrderBy(c => c.Id).ToList();
        }

        public List<TipoLicencia> ListarFullTiposdeLicencia()
        {
            return Modelo.SingletonSeguridad.ObtenerInstancia().Tiposdelicencia.OrderBy(c => c.Id).ToList();
        }

        public List<TipoLicencia> ListarTiposdeLicenciaDemo()
        {
            List<TipoLicencia> oLista = Modelo.SingletonSeguridad.ObtenerInstancia().Tiposdelicencia.Where(c => c.Activo == 1).Where(c=> c is Demo).OrderBy(c => c.Id).ToList();

            return oLista;
        }

        public List<TipoLicencia> ListarTiposdeLicenciaBasica()
        {
            List<TipoLicencia> oLista = Modelo.SingletonSeguridad.ObtenerInstancia().Tiposdelicencia.Where(c => c.Activo == 1).Where(c => c is Basica).OrderBy(c => c.Duracion).ToList();

            return oLista;
        }

        public List<TipoLicencia> ListarTiposdeLicenciaPremium()
        {
            List<TipoLicencia> oLista = Modelo.SingletonSeguridad.ObtenerInstancia().Tiposdelicencia.Where(c => c.Activo == 1).Where(c => c is Premium).OrderBy(c => c.Duracion).ToList();

            return oLista;
        }

        public void AgregarTipoLicencia(TipoLicencia oTipoLicencia)
        {
            Modelo.SingletonSeguridad.ObtenerInstancia().Tiposdelicencia.Add(oTipoLicencia);
            Modelo.SingletonSeguridad.ObtenerInstancia().SaveChanges();
        }

        public void EliminarTipoLicencia(string IDTipoLicencia)
        {
            TipoLicencia oTipoLicencia = Modelo.SingletonSeguridad.ObtenerInstancia().Tiposdelicencia.Find(Convert.ToInt32(IDTipoLicencia));
            oTipoLicencia.Activo = 0;

            Modelo.SingletonSeguridad.ObtenerInstancia().Entry(oTipoLicencia).State = System.Data.Entity.EntityState.Modified;
            Modelo.SingletonSeguridad.ObtenerInstancia().SaveChanges();

            //Modelo.SingletonSeguridad.ObtenerInstancia().Tiposdelicencia.Remove(oTipoLicencia);
            //Modelo.SingletonSeguridad.ObtenerInstancia().SaveChanges();
        }

        public void ModificarTipoLicencia(TipoLicencia oTipoLicencia)
        {
            Modelo.SingletonSeguridad.ObtenerInstancia().Entry(oTipoLicencia).State = System.Data.Entity.EntityState.Modified;
            Modelo.SingletonSeguridad.ObtenerInstancia().SaveChanges();
        }

        public TipoLicencia ObtenerTipoLicencia(string TipoLicenciaId)
        {
            int idTipoLicencia = Convert.ToInt32(TipoLicenciaId);

            TipoLicencia oTipoLicencia = Modelo.SingletonSeguridad.ObtenerInstancia().Tiposdelicencia.Find(idTipoLicencia);
            return oTipoLicencia;
        }

        public Premium ObtenerTipoLicenciaPremium(string TipoLicenciaId)
        {
            int idTipoLicencia = Convert.ToInt32(TipoLicenciaId);

            Premium oTipoLicencia = Modelo.SingletonSeguridad.ObtenerInstancia().Tiposdelicencia.OfType<Premium>().FirstOrDefault(c=> c.Id == idTipoLicencia);
            return oTipoLicencia;
        }

        public Basica ObtenerTipoLicenciaBasica(string TipoLicenciaId)
        {
            int idTipoLicencia = Convert.ToInt32(TipoLicenciaId);

            Basica oTipoLicencia = Modelo.SingletonSeguridad.ObtenerInstancia().Tiposdelicencia.OfType<Basica>().FirstOrDefault(c => c.Id == idTipoLicencia);
            return oTipoLicencia;
        }

        //public bool VerificarTipoLicencia(TipoLicencia oTipoLicencia)
        //{
        //    List<TipoLicencia> Lista = Modelo.SingletonSeguridad.ObtenerInstancia().Tiposdelicencia.Where(oFlo => oFlo.Id == oFlo.Id).ToList();
        //    if (Lista.Count > 0)
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        //public List<TipoLicencia> ListarTipoLicenciasFiltrados(string IDTipoLicencia)
        //{
        //    return Modelo.SingletonSeguridad.ObtenerInstancia().Tiposdelicencia.Where(oFlo => oFlo.Id.ToString().Contains(IDTipoLicencia)).OrderBy(c => c.Id).ToList();
        //}

        //public TipoLicencia ObtenerTipoLicenciadeUsuario(string idUsuario)
        //{
        //    Usuario oUsuario = Modelo.SingletonSeguridad.ObtenerInstancia().Usuarios.Find(idUsuario);
        //    return oUsuario.TipoLicencia;
        //}
    }
}
