using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.SEGURIDAD;

namespace Controladora.SEGURIDAD
{
    public class ControladoraPerfiles
    {


        public List<Perfil> ListarPerfiles()
        {
            return Modelo.SingletonSeguridad.ObtenerInstancia().Perfiles.ToList();
        }


        public void AgregarPerfil(Perfil oPerfil)
        {
            Modelo.SingletonSeguridad.ObtenerInstancia().Perfiles.Add(oPerfil);
            Modelo.SingletonSeguridad.ObtenerInstancia().SaveChanges();

            //modAuPerfiles.Auditar(oPerfil);
        }

        public void EliminarPerfil(int IDperfil)
        {
            Perfil oPerfil = Modelo.SingletonSeguridad.ObtenerInstancia().Perfiles.Find(IDperfil);
            Modelo.SingletonSeguridad.ObtenerInstancia().Perfiles.Remove(oPerfil);
            Modelo.SingletonSeguridad.ObtenerInstancia().SaveChanges();

            //modAuPerfiles.Auditar(oPerfil);
        }

        public void ModificarPerfil(Perfil oPerfil)
        {
            Modelo.SingletonSeguridad.ObtenerInstancia().Entry(oPerfil).State = System.Data.Entity.EntityState.Modified;
            Modelo.SingletonSeguridad.ObtenerInstancia().SaveChanges();
        }

        // ------------------------------------------ //

        //MODELO.Auditoría.AuditoriaPerfiles modAuPerfiles = new MODELO.Auditoría.AuditoriaPerfiles();

        public List<Permiso> ObtenerPermisos(string IDform, Usuario oUsuario)
        {
            //return MODELO.Seguridad.CatálogoPerfiles.Instancia.ObtenerPermisos(IDform, oUsuario.Grupo);

            List<Permiso> permisos = new List<Permiso>();

            foreach (Grupo g in oUsuario.Grupo)
            {
                List<Perfil> ps = g.Perfil.ToList();
                foreach (Perfil p in ps)
                {
                    if (p.Formulario.IDFormulario == IDform)
                    {
                        permisos.Add(p.Permiso);
                    }
                }
            }
            return permisos;
        }

        public List<Formulario> ObtenerPermisos(Usuario oUsuario)
        {
            //return MODELO.Seguridad.CatálogoPerfiles.Instancia.ObtenerPermisos(IDform, oUsuario.Grupo);

            List<Formulario> permisos = new List<Formulario>();

            foreach (Grupo g in oUsuario.Grupo)
            {
                List<Perfil> ps = g.Perfil.ToList();
                foreach (Perfil p in ps)
                {
                    permisos.Add(p.Formulario);
                }
            }
            return permisos;
        }



        public bool VerificarPerfil(Perfil oPerfil)
        {
            List<Perfil> Lista = Modelo.SingletonSeguridad.ObtenerInstancia().Perfiles.Where(oGru => oGru.Permiso.IDPermiso == oPerfil.Permiso.IDPermiso && oGru.Grupo.IDGrupo == oPerfil.Grupo.IDGrupo && oGru.Formulario.IDFormulario == oPerfil.Formulario.IDFormulario).ToList();
            if (Lista.Count > 0)
            {
                return false;
            }
            return true;
        }



        public List<Perfil> FiltrarPerfiles(string GRUPO, string PERMISO, string FORM)
        {
            List<Perfil> Filtrado = Modelo.SingletonSeguridad.ObtenerInstancia().Perfiles.ToList();
            if (GRUPO != null)
                Filtrado = Filtrado.Where(oPer => oPer.Grupo.IDGrupo.Contains(GRUPO)).ToList();
            if (PERMISO != null)
                Filtrado = Filtrado.Where(oPer => oPer.Permiso.IDPermiso.Contains(PERMISO)).ToList();
            if (FORM != null)
                Filtrado = Filtrado.Where(oPer => oPer.Formulario.IDFormulario.Contains(FORM)).ToList();


            return Filtrado;

        }

        //public List<ENTIDADES.Seguridad.Grupo> LlenarComboGrupos2()
        //{
        //    return MODELO.Seguridad.CatálogoGrupos.Instancia.ListarGrupos();
        //}

        //public List<ENTIDADES.Seguridad.Formulario> LlenarComboFormularios2()
        //{
        //    return MODELO.Seguridad.CatálogoFormularios.Instancia.ListarFormularios();

        //}

        //public List<ENTIDADES.Seguridad.Permiso> LlenarComboPermisos2()
        //{
        //    return MODELO.Seguridad.CatálogoPermisos.Instancia.ListarPermisos();
        //}


    }
}
