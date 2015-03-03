using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.SEGURIDAD;

namespace Controladora.SEGURIDAD
{
    public class ControladoraGrupos
    {

        public List<Grupo> ListarGrupos()
        {
            return Modelo.SingletonSeguridad.ObtenerInstancia().Grupos.OrderBy(c => c.IDGrupo).ToList();
        }


        public List<Grupo> ListarGruposFlota()
        {
            return Modelo.SingletonSeguridad.ObtenerInstancia().Grupos.Where(g => g.IDGrupo != "Administrador").Where(g => g.IDGrupo != "Propietario").OrderBy(c => c.IDGrupo).ToList();
        }


        public void AgregarGrupo(Grupo oGrupo)
        {
            Modelo.SingletonSeguridad.ObtenerInstancia().Grupos.Add(oGrupo);
            Modelo.SingletonSeguridad.ObtenerInstancia().SaveChanges();
        }

        public void EliminarGrupo(string IDgrupo)
        {
            Grupo oGrupo = Modelo.SingletonSeguridad.ObtenerInstancia().Grupos.Find(IDgrupo);
            oGrupo.Usuario.Clear();
            while (oGrupo.Perfil.Count > 0)
            {
                Modelo.SingletonSeguridad.ObtenerInstancia().Perfiles.Remove(oGrupo.Perfil.FirstOrDefault());
            }

            Modelo.SingletonSeguridad.ObtenerInstancia().Grupos.Remove(oGrupo);
            Modelo.SingletonSeguridad.ObtenerInstancia().SaveChanges();
        }

        public void ModificarGrupo(Grupo oGrupo)
        {
            Modelo.SingletonSeguridad.ObtenerInstancia().Entry(oGrupo).State = System.Data.Entity.EntityState.Modified;
            Modelo.SingletonSeguridad.ObtenerInstancia().SaveChanges();
        }

        public Grupo ObtenerGrupo(string grupoId)
        {
            Grupo oGrupo = Modelo.SingletonSeguridad.ObtenerInstancia().Grupos.Find(grupoId);
            return oGrupo;
        }

        public bool VerificarGrupo(Grupo oGrupo)
        {
            List<Grupo> Lista = Modelo.SingletonSeguridad.ObtenerInstancia().Grupos.Where(oGru => oGru.IDGrupo == oGrupo.IDGrupo).ToList();
            if (Lista.Count > 0)
            {
                return false;
            }
            return true;
        }

        public List<Grupo> ListarGruposFiltrados(string IDgrupo)
        {
            return Modelo.SingletonSeguridad.ObtenerInstancia().Grupos.Where(oGru => oGru.IDGrupo.Contains(IDgrupo)).OrderBy(c => c.IDGrupo).ToList();
        }

        public Grupo ObtenerGrupodeUsuario(string idUsuario)
        {
            Usuario oUsuario = Modelo.SingletonSeguridad.ObtenerInstancia().Usuarios.Find(idUsuario);
            Grupo oGrupo = oUsuario.Grupo.FirstOrDefault();
            return oGrupo;
        }
    }
}
