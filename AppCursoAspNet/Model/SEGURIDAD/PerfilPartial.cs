using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.SEGURIDAD
{
    public partial class Perfil
    {
        public string IDgrupo
        {
            get
            {
                return this.Grupo.IDGrupo;
            }
        }

        public string IDpermiso
        {
            get
            {
                return this.Permiso.IDPermiso;
            }
        }

        public string IDformulario
        {
            get
            {
                return this.Formulario.IDFormulario;
            }
        }


        /// <summary>
        /// Devuelve un DataSet con los Paginas de un Perfil por Id
        /// </summary>
        /// <param name="idPerfil"></param>
        /// <returns></returns>
        public static List<string> GetPaginas(int idPerfil)
        {
            //System.Data.DataSet ds = new System.Data.DataSet();
            List<string> ds = new List<string>();
            try
            {
                //ds = _dataWorker.ExecuteDataset(ConfigurationSettings.AppSettings["SqlServerConnectionString"], "PerfilesPaginas_TxIdPerfil", new object[] { idPerfil });
            }
            catch (Exception ex)
            {
                //log.Error(ex);
            }

            return ds;
        }

        /// <summary>
        /// Devuelve un DataSet con los Paginas de un Perfil por el Nombre del Perfil
        /// </summary>
        /// <param name="Perfil"></param>
        /// <returns></returns>
        public static List<string> GetPaginas(string Perfil)
        {
            //System.Data.DataSet ds = new System.Data.DataSet();
            List<string> ds = new List<string>();
            try
            {
                //ds = _dataWorker.ExecuteDataset(ConfigurationSettings.AppSettings["SqlServerConnectionString"], "PerfilesPaginas_TxPerfiles", new object[] { Perfil });
            }
            catch (Exception ex)
            {
                //log.Error(ex);
            }

            return ds;
        }

        /// <summary>
        /// Determina si una pagina está habilitada
        /// </summary>
        /// <param name="page"></param>
        /// <param name="Perfil"></param>
        /// <returns></returns>
        public static bool IsPageEnabled(string pageName, string Perfil)
        {
            CheckCache(Perfil);

            bool result = false;
            try
            {
                System.Data.DataSet ds = (System.Data.DataSet)System.Web.HttpContext.Current.Cache.Get(Perfil);
                System.Data.DataView dv = new System.Data.DataView(ds.Tables[0]);
                dv.RowFilter = "url='" + pageName + "'";
                if (dv.Count > 0)
                    result = true;
            }
            catch (Exception ex)
            {
                //log.Error(ex);
            }

            return result;
        }

        /// <summary>
        /// Determina si una pagina está habilitada
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static bool IsActionEnabled(string actionName, string Perfil)
        {
            //Por las dudas si se invalido el Cache despues de un login
            CheckCache(Perfil);

            bool result = false;
            try
            {
                System.Data.DataSet ds = (System.Data.DataSet)System.Web.HttpContext.Current.Cache.Get(Perfil);
                System.Data.DataView dv = new System.Data.DataView(ds.Tables[0]);
                dv.RowFilter = "url='" + actionName + "' and EsAccion=1";
                if (dv.Count > 0)
                    result = true;
            }
            catch (Exception ex)
            {
                //log.Error(ex);
            }

            return result;
        }

        /// <summary>
        /// Chequea el Cache
        /// </summary>
        /// <param name="Perfil"></param>
        private static void CheckCache(string Perfil)
        {
            try
            {
                if (System.Web.HttpContext.Current.Cache.Get(Perfil) == null)
                    Modelo.SEGURIDAD.UserCache.AddPaginasToCache(Perfil, Modelo.SEGURIDAD.Perfil.GetPaginas(Perfil), System.Web.HttpContext.Current);
            }
            catch (Exception ex)
            {
                //log.Error(ex);
            }
        }
    }
}
