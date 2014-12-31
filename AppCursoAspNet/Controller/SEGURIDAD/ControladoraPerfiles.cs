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
        ControladoraUsuarios ctrlUsuarios = new ControladoraUsuarios();

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

        public Perfil ObtenerPerfil(int perfilId)
        {
            Perfil oPerfil = Modelo.SingletonSeguridad.ObtenerInstancia().Perfiles.Find(perfilId);
            return oPerfil;
        }

        // ------------------------------------------ //

        //MODELO.Auditoría.AuditoriaPerfiles modAuPerfiles = new MODELO.Auditoría.AuditoriaPerfiles();

        public List<string> ObtenerPermisos(string oUsuario, string IDform)
        {

            List<string> permisos = new List<string>();
            Usuario User = ctrlUsuarios.BuscarUsuario(oUsuario);

            foreach (Grupo g in User.Grupo)
            {
                List<Perfil> ps = g.Perfil.ToList();
                foreach (Perfil p in ps)
                {
                    if (p.Formulario.IDFormulario == IDform)
                    {
                        permisos.Add(p.Permiso.IDPermiso);
                    }
                }
            }
            return permisos;
        }

        public List<Permiso> ObtenerPermisos(Usuario oUsuario)
        {
            //return MODELO.Seguridad.CatálogoPerfiles.Instancia.ObtenerPermisos(IDform, oUsuario.Grupo);

            List<Permiso> permisos = new List<Permiso>();

            foreach (Grupo g in oUsuario.Grupo)
            {
                List<Perfil> ps = g.Perfil.ToList();
                foreach (Perfil p in ps)
                {
                    permisos.Add(p.Permiso);
                }
            }
            return permisos;
        }


        //public List<Formulario> ObtenerFormularios(string oUsuario)
        //{
        //    //return MODELO.Seguridad.CatálogoPerfiles.Instancia.ObtenerPermisos(IDform, oUsuario.Grupo);

        //    List<Formulario> formularios = new List<Formulario>();

        //    Usuario User = ctrlUsuarios.BuscarUsuario(oUsuario);

        //    foreach (Grupo g in User.Grupo)
        //    {
        //        List<Perfil> ps = g.Perfil.ToList();
        //        foreach (Perfil p in ps)
        //        {
        //            formularios.Add(p.Formulario);
        //        }
        //    }
        //    return formularios;
        //}


        public List<string> ObtenerFormularios(string oUsuario)
        {
            //return MODELO.Seguridad.CatálogoPerfiles.Instancia.ObtenerPermisos(IDform, oUsuario.Grupo);

            List<string> formularios = new List<string>();

            Usuario User = ctrlUsuarios.BuscarUsuario(oUsuario);

            foreach (Grupo g in User.Grupo)
            {
                List<Perfil> ps = g.Perfil.ToList();
                foreach (Perfil p in ps)
                {
                    formularios.Add(p.Formulario.IDFormulario);
                }
            }
            return formularios;
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
