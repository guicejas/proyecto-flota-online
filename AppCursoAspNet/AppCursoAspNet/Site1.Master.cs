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
                nombreUsuario.InnerHtml = this.Context.User.Identity.Name;
            }
            
        }
    }
}