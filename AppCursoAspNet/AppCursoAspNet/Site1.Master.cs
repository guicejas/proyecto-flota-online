using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Vista
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        Controladora.SEGURIDAD.ControladoraPerfiles ctrlPerfiles = new Controladora.SEGURIDAD.ControladoraPerfiles();
        Controladora.SEGURIDAD.ControladoraFlotas ctrlFlotas = new Controladora.SEGURIDAD.ControladoraFlotas();
        Controladora.SEGURIDAD.ControladoraTiposdeLicencia ctrlTiposdeLicencia = new Controladora.SEGURIDAD.ControladoraTiposdeLicencia();
        Controladora.SEGURIDAD.ControladoraGrupos ctrlGrupos = new Controladora.SEGURIDAD.ControladoraGrupos();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Context.User.Identity.IsAuthenticated)
            {
                menuPrincipal.Visible = false;
                menuAyuda.Visible = false;
                menuUsuario.Visible = false;

            }
            else
            {
                flotaUser.Text = ctrlFlotas.ObtenerFlotadeUsuario(HttpContext.Current.User.Identity.Name).RazonSocial;

               List<string> formularios = ctrlPerfiles.ObtenerFormularios(this.Context.User.Identity.Name);

               menuAdministracion.Visible = false;
               menuSistema.Visible = false;
               menuChoferes.Visible = false;
               menuEmpresas.Visible = false;
               menuGastos.Visible = false;
               menuTurnos.Visible = false;
               menuVehiculos.Visible = false;
               menuNuevoChofer.Visible = false;


               if (formularios.Exists(f => f == "Administracion"))
                   menuAdministracion.Visible = true;

               if (formularios.Exists(f => f == "Sistema"))
                   menuSistema.Visible = true;

               if (formularios.Exists(f => f == "Choferes"))
               {
                   menuChoferes.Visible = true;
                   List<string> permisos = ctrlPerfiles.ObtenerPermisos(HttpContext.Current.User.Identity.Name, "Choferes");
                   if (permisos.Exists(a => a == "TOTAL") || permisos.Exists(a => a == "ALTA"))
                    menuNuevoChofer.Visible = true;
               }

               if (formularios.Exists(f => f == "Empresas"))
                   {
                       menuEmpresas.Visible = true;
                       List<string> permisos = ctrlPerfiles.ObtenerPermisos(HttpContext.Current.User.Identity.Name, "Empresas");
                       if (permisos.Exists(a => a == "TOTAL") || permisos.Exists(a => a == "ALTA"))
                        menuNuevaEmpresa.Visible = true;
                   }

               if (formularios.Exists(f => f == "Gastos"))
                   {
                       menuGastos.Visible = true;
                       List<string> permisos = ctrlPerfiles.ObtenerPermisos(HttpContext.Current.User.Identity.Name, "Gastos");
                       if (permisos.Exists(a => a == "TOTAL") || permisos.Exists(a => a == "ALTA"))
                        menuNuevoGasto.Visible = true;
                   }

               if (formularios.Exists(f => f == "Turnos"))
                   {
                       menuTurnos.Visible = true;
                       List<string> permisos = ctrlPerfiles.ObtenerPermisos(HttpContext.Current.User.Identity.Name, "Turnos");
                       if (permisos.Exists(a => a == "TOTAL") || permisos.Exists(a => a == "ALTA"))
                        menuNuevoTurno.Visible = true;
                   }

               if (formularios.Exists(f => f == "Vehiculos"))
                   {
                       menuVehiculos.Visible = true;
                       List<string> permisos = ctrlPerfiles.ObtenerPermisos(HttpContext.Current.User.Identity.Name, "Vehiculos");
                       if (permisos.Exists(a => a == "TOTAL") || permisos.Exists(a => a == "ALTA"))
                        menuNuevoVehiculo.Visible = true;
                   }

               if (!(ctrlGrupos.ObtenerGrupodeUsuario(HttpContext.Current.User.Identity.Name).IDGrupo == "Administrador"))
               {
                   if (ctrlFlotas.ObtenerFlotadeUsuario(HttpContext.Current.User.Identity.Name).ultimaLicencia.TipoLicencia.tipo == "Basica")
                   {
                       divPublicidad.Visible = true;
                       imgPublicidad.ImageUrl = "~/Images/Banner/" + ctrlTiposdeLicencia.ObtenerTipoLicenciaBasica(ctrlFlotas.ObtenerFlotadeUsuario(HttpContext.Current.User.Identity.Name).ultimaLicencia.TipoLicencia.Id.ToString()).Patrocinador + ".jpg";
                   }
               }
             

          
            }
            
        }
    }
}