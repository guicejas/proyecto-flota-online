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
        protected void Page_Load(object sender, EventArgs e)
        {

            mensaje.Visible = false;
        }

        protected void LoginSistema_Authenticate(object sender, EventArgs e)
        {
            
            bool Autenticado = false;
            Autenticado = LoginCorrecto(inputUsuario.Value, inputPassword.Value);
            if (Autenticado)
            {
                FormsAuthentication.RedirectFromLoginPage(inputUsuario.Value, recordarme.Checked);
                Response.Redirect("View/Index.aspx");
            }
            else
            {
                mensaje.Visible = true;
                mensajeTexto.InnerHtml = "Usuario o password incorrectos.";

            }
        }
            private bool LoginCorrecto(string Usuario, string Contrasena)
            {
                if (Usuario.Equals("admin") && Contrasena.Equals("123"))
            return true; return false;
            }
        
    }
}