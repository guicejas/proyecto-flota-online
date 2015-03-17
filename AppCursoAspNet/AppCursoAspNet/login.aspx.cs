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
        Controladora.SEGURIDAD.ControladoraFlotas ctrlFlotas = new Controladora.SEGURIDAD.ControladoraFlotas();


        protected void Page_Load(object sender, EventArgs e)
        {

            mensaje.Visible = false;
            if (Request.QueryString["msj"] != null)
            {
                mensaje.Visible = true;
                mensaje.Attributes.Add("class", "alert alert-dismissable alert-success");
                mensajeTexto.InnerHtml = Request.QueryString["msj"];
            }

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
                Modelo.SEGURIDAD.Usuario oUsuario = ctrlUsuarios.BuscarUsuario(inputUsuario.Value);

                if ((ctrlGrupos.ObtenerGrupodeUsuario(inputUsuario.Value).IDGrupo == "Administrador"))
                {

                    //FormsAuthentication.RedirectFromLoginPage(inputUsuario.Value, recordarme.Checked);
                    //Response.Redirect("View/Index.aspx");
                    Modelo.SEGURIDAD.Grupo grupolUsuario = ctrlGrupos.ObtenerGrupodeUsuario(inputUsuario.Value);

                    Modelo.SEGURIDAD.Flota flotaUsuario = ctrlFlotas.ObtenerFlotadeUsuario(inputUsuario.Value);

                    //Invoca a componente que se encarga del Cache de los datos
                    //en este caso de las páginas a las que el perfil tiene acceso
                    Modelo.SEGURIDAD.UserCache.AddPaginasToCache(grupolUsuario.IDGrupo, ctrlPerfiles.ObtenerFormularios(inputUsuario.Value), System.Web.HttpContext.Current);

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
                    Session["flotaId"] = flotaUsuario.Id.ToString();
                    //Response.Cookies.


                    // Cookies con informacion del usuario
                    HttpCookie userInfoCookie = new HttpCookie("userInfoSGOFT");
                    userInfoCookie.Values["userName"] = inputUsuario.Value;
                    userInfoCookie.Values["grupoId"] = grupolUsuario.IDGrupo;
                    userInfoCookie.Values["flotaId"] = flotaUsuario.Id.ToString();
                    // userInfoCookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(userInfoCookie);



                    // Redirecciono al Usuario - Importante!! no usar el RedirectFromLoginPage
                    // Para que se puedan usar las Cookies de los HttpModules
                    //Response.Redirect(FormsAuthentication.GetRedirectUrl(inputUsuario.Value, false));
                    if (ctrlUsuarios.BuscarUsuario(inputUsuario.Value).PrimeraVez == true)
                        Response.Redirect("View/PasswordTemporal.aspx");
                    else
                        Response.Redirect("View/Index.aspx");
                }


                if (oUsuario.Flota.ultimaLicencia.FechaFin >= DateTime.Now && oUsuario.Flota.ultimaLicencia.Estado == "Aceptada")
                {

                    //FormsAuthentication.RedirectFromLoginPage(inputUsuario.Value, recordarme.Checked);
                    //Response.Redirect("View/Index.aspx");
                    Modelo.SEGURIDAD.Grupo grupolUsuario = ctrlGrupos.ObtenerGrupodeUsuario(inputUsuario.Value);

                    Modelo.SEGURIDAD.Flota flotaUsuario = ctrlFlotas.ObtenerFlotadeUsuario(inputUsuario.Value);

                    //Invoca a componente que se encarga del Cache de los datos
                    //en este caso de las páginas a las que el perfil tiene acceso
                    Modelo.SEGURIDAD.UserCache.AddPaginasToCache(grupolUsuario.IDGrupo, ctrlPerfiles.ObtenerFormularios(inputUsuario.Value), System.Web.HttpContext.Current);

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
                    Session["flotaId"] = flotaUsuario.Id.ToString();
                    //Response.Cookies.


                    // Cookies con informacion del usuario
                    HttpCookie userInfoCookie = new HttpCookie("userInfoSGOFT");
                    userInfoCookie.Values["userName"] = inputUsuario.Value;
                    userInfoCookie.Values["grupoId"] = grupolUsuario.IDGrupo;
                    userInfoCookie.Values["flotaId"] = flotaUsuario.Id.ToString();
                    // userInfoCookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(userInfoCookie);



                    // Redirecciono al Usuario - Importante!! no usar el RedirectFromLoginPage
                    // Para que se puedan usar las Cookies de los HttpModules
                    //Response.Redirect(FormsAuthentication.GetRedirectUrl(inputUsuario.Value, false));
                    if (ctrlUsuarios.BuscarUsuario(inputUsuario.Value).PrimeraVez == true)
                        Response.Redirect("View/PasswordTemporal.aspx");
                    else
                        Response.Redirect("View/Index.aspx");
                }

                if (oUsuario.Flota.ultimaLicencia.FechaFin >= DateTime.Now && (oUsuario.Flota.ultimaLicencia.Estado == "Pendiente Confirmacion" && oUsuario.Flota.ultimaLicencia.FechaInicio.AddDays(2) > DateTime.Now))
                {
                    //FormsAuthentication.RedirectFromLoginPage(inputUsuario.Value, recordarme.Checked);
                    //Response.Redirect("View/Index.aspx");
                    Modelo.SEGURIDAD.Grupo grupolUsuario = ctrlGrupos.ObtenerGrupodeUsuario(inputUsuario.Value);

                    Modelo.SEGURIDAD.Flota flotaUsuario = ctrlFlotas.ObtenerFlotadeUsuario(inputUsuario.Value);

                    //Invoca a componente que se encarga del Cache de los datos
                    //en este caso de las páginas a las que el perfil tiene acceso
                    Modelo.SEGURIDAD.UserCache.AddPaginasToCache(grupolUsuario.IDGrupo, ctrlPerfiles.ObtenerFormularios(inputUsuario.Value), System.Web.HttpContext.Current);

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
                    Session["flotaId"] = flotaUsuario.Id.ToString();
                    //Response.Cookies.


                    // Cookies con informacion del usuario
                    HttpCookie userInfoCookie = new HttpCookie("userInfoSGOFT");
                    userInfoCookie.Values["userName"] = inputUsuario.Value;
                    userInfoCookie.Values["grupoId"] = grupolUsuario.IDGrupo;
                    userInfoCookie.Values["flotaId"] = flotaUsuario.Id.ToString();
                    // userInfoCookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(userInfoCookie);



                    // Redirecciono al Usuario - Importante!! no usar el RedirectFromLoginPage
                    // Para que se puedan usar las Cookies de los HttpModules
                    //Response.Redirect(FormsAuthentication.GetRedirectUrl(inputUsuario.Value, false));

                    if (ctrlUsuarios.BuscarUsuario(inputUsuario.Value).PrimeraVez == true)
                        Response.Redirect("View/PasswordTemporal.aspx");
                    else
                        Response.Redirect("View/Index.aspx");
                }

                if (oUsuario.Flota.ultimaLicencia.FechaFin < DateTime.Now)
                {
                    //FormsAuthentication.RedirectFromLoginPage(inputUsuario.Value, recordarme.Checked);
                    //Response.Redirect("View/Index.aspx");
                    Modelo.SEGURIDAD.Grupo grupolUsuario = ctrlGrupos.ObtenerGrupodeUsuario(inputUsuario.Value);

                    Modelo.SEGURIDAD.Flota flotaUsuario = ctrlFlotas.ObtenerFlotadeUsuario(inputUsuario.Value);

                    //Invoca a componente que se encarga del Cache de los datos
                    //en este caso de las páginas a las que el perfil tiene acceso
                    Modelo.SEGURIDAD.UserCache.AddPaginasToCache(grupolUsuario.IDGrupo, ctrlPerfiles.ObtenerFormularios(inputUsuario.Value), System.Web.HttpContext.Current);

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
                    Session["flotaId"] = flotaUsuario.Id.ToString();
                    //Response.Cookies.


                    // Cookies con informacion del usuario
                    HttpCookie userInfoCookie = new HttpCookie("userInfoSGOFT");
                    userInfoCookie.Values["userName"] = inputUsuario.Value;
                    userInfoCookie.Values["grupoId"] = grupolUsuario.IDGrupo;
                    userInfoCookie.Values["flotaId"] = flotaUsuario.Id.ToString();
                    // userInfoCookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(userInfoCookie);



                    // Redirecciono al Usuario - Importante!! no usar el RedirectFromLoginPage
                    // Para que se puedan usar las Cookies de los HttpModules
                    //Response.Redirect(FormsAuthentication.GetRedirectUrl(inputUsuario.Value, false));

                    oUsuario.Flota.ultimaLicencia.Estado = "Expirada";
                    ctrlUsuarios.ModificarUsuario(oUsuario);

                    Response.Redirect("View/LicenciaExpirada.aspx");

                }
                else
                {

                    //if (oUsuario.Flota.ultimaLicencia.FechaFin < DateTime.Now || (oUsuario.Flota.ultimaLicencia.Estado == "Pendiente Confirmacion" && oUsuario.Flota.ultimaLicencia.FechaInicio.AddDays(2) < DateTime.Now) || oUsuario.Flota.ultimaLicencia.Estado == "Rechazada")

                    //FormsAuthentication.RedirectFromLoginPage(inputUsuario.Value, recordarme.Checked);
                    //Response.Redirect("View/Index.aspx");
                    Modelo.SEGURIDAD.Grupo grupolUsuario = ctrlGrupos.ObtenerGrupodeUsuario(inputUsuario.Value);

                    Modelo.SEGURIDAD.Flota flotaUsuario = ctrlFlotas.ObtenerFlotadeUsuario(inputUsuario.Value);

                    //Invoca a componente que se encarga del Cache de los datos
                    //en este caso de las páginas a las que el perfil tiene acceso
                    Modelo.SEGURIDAD.UserCache.AddPaginasToCache(grupolUsuario.IDGrupo, ctrlPerfiles.ObtenerFormularios(inputUsuario.Value), System.Web.HttpContext.Current);

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
                    Session["flotaId"] = flotaUsuario.Id.ToString();
                    //Response.Cookies.


                    // Cookies con informacion del usuario
                    HttpCookie userInfoCookie = new HttpCookie("userInfoSGOFT");
                    userInfoCookie.Values["userName"] = inputUsuario.Value;
                    userInfoCookie.Values["grupoId"] = grupolUsuario.IDGrupo;
                    userInfoCookie.Values["flotaId"] = flotaUsuario.Id.ToString();
                    // userInfoCookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(userInfoCookie);



                    // Redirecciono al Usuario - Importante!! no usar el RedirectFromLoginPage
                    // Para que se puedan usar las Cookies de los HttpModules
                    //Response.Redirect(FormsAuthentication.GetRedirectUrl(inputUsuario.Value, false));

                    Response.Redirect("View/LicenciaExpirada.aspx");
                }


            }
            else
            {
                mensaje.Visible = true;
                mensaje.Attributes.Add("class", "alert alert-dismissable alert-danger");
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