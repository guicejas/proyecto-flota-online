using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Vista
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Controladora.SEGURIDAD.ControladoraLogin ctrlLogin = new Controladora.SEGURIDAD.ControladoraLogin();
            ctrlLogin.CerrarSesion(this.Context.User.Identity.Name);
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }
    }
}