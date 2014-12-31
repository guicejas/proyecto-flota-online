using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Vista
{
    public partial class Login : System.Web.UI.Page
    {

        Controladora.SEGURIDAD.ControladoraLogin ctrlLogin = new Controladora.SEGURIDAD.ControladoraLogin();
        Controladora.SEGURIDAD.ControladoraUsuarios ctrlUsuarios = new Controladora.SEGURIDAD.ControladoraUsuarios();
        Controladora.SEGURIDAD.ControladoraPerfiles ctrlPerfiles = new Controladora.SEGURIDAD.ControladoraPerfiles();
        Controladora.SEGURIDAD.ControladoraGrupos ctrlGrupos = new Controladora.SEGURIDAD.ControladoraGrupos();


        protected void Page_Load(object sender, EventArgs e)
        {

            mensaje.Visible = false;
            ctrlUsuarios.CargaInicialBD();

            if (this.Context.User.Identity.IsAuthenticated)
            {
                Response.Redirect("View/Index.aspx");
            }
        }

        protected void LoginSistema_Authenticate(object sender, EventArgs e)
        {
            
            
            bool Autenticado = false;

            Autenticado = ctrlLogin.IniciarSesion(inputUsuario.Value, inputPassword.Value);
            if (Autenticado)
            {
                //FormsAuthentication.RedirectFromLoginPage(inputUsuario.Value, recordarme.Checked);
                //Response.Redirect("View/Index.aspx");
                Modelo.SEGURIDAD.Grupo grupolUsuario = ctrlGrupos.ObtenerGrupodeUsuario(inputUsuario.Value);

                				//Invoca a componente que se encarga del Cache de los datos
				//en este caso de las páginas a las que el perfil tiene acceso
				Modelo.SEGURIDAD.UserCache.AddPaginasToCache(grupolUsuario.IDGrupo, ctrlPerfiles.ObtenerFormularios(inputUsuario.Value),System.Web.HttpContext.Current); 
				
				// Crea un ticket de Autenticacion de forma manual, 
				// donde guardaremos información que nos interesa
				FormsAuthenticationTicket authTicket = 
						new FormsAuthenticationTicket(2,  // version
						inputUsuario.Value,
						DateTime.Now, 
						DateTime.Now.AddMinutes(60),
						false, 
						grupolUsuario.IDGrupo, // guardo el grupo del usuario
						FormsAuthentication.FormsCookiePath);
				// Encripto el Ticket.
				string crypTicket = FormsAuthentication.Encrypt(authTicket);
					
				// Creo la Cookie
				HttpCookie authCookie = 
						new HttpCookie(FormsAuthentication.FormsCookieName,
						crypTicket);

				Response.Cookies.Add(authCookie); 
 
				// Redirecciono al Usuario - Importante!! no usar el RedirectFromLoginPage
				// Para que se puedan usar las Cookies de los HttpModules
                //Response.Redirect(FormsAuthentication.GetRedirectUrl(inputUsuario.Value, false));
                if (ctrlUsuarios.BuscarUsuario(inputUsuario.Value).PrimeraVez == true)
                    Response.Redirect("View/PasswordTemporal.aspx");
                else
                    Response.Redirect("View/Index.aspx");

            }
            else
            {
                mensaje.Visible = true;
                mensajeTexto.InnerHtml = "El usuario o password son incorrectos. O el usuario no esta activo.";

            }
        }
            private bool LoginCorrecto(string Usuario, string Contrasena)
            {
                if (Usuario.Equals("admin") && Contrasena.Equals("123"))
            return true; return false;
            }
        
    }
}