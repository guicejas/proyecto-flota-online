using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista.View
{
    public partial class PasswordTemporal : System.Web.UI.Page
    {
        Controladora.SEGURIDAD.ControladoraUsuarios ctrlUsuarios = new Controladora.SEGURIDAD.ControladoraUsuarios();
        Controladora.SEGURIDAD.Encriptacion ctrlEncriptacion = new Controladora.SEGURIDAD.Encriptacion();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ctrlUsuarios.BuscarUsuario(Context.User.Identity.Name).PrimeraVez != true)
                Response.Redirect("View/Index.aspx");
        }

        protected void Change_Password(object sender, EventArgs e)
        {
            if (ctrlUsuarios.ValidarPassword(Context.User.Identity.Name, txtPassActual.Value))
            {
                mensaje.Visible = true;
                mensaje.Attributes.Add("class", "alert alert-dismissable alert-danger");
                mensajeTexto.InnerHtml = "La contraseña actual ingresada es incorrecta";
                return;
            }

            if (txtPassNuevo.Value!=txtPassRepite.Value)
            {
                mensaje.Visible = true;
                mensaje.Attributes.Add("class", "alert alert-dismissable alert-danger");
                mensajeTexto.InnerHtml = "La nueva contraseña no coincide";
                return;
            }

            ctrlUsuarios.CambiarContraseña(Context.User.Identity.Name, txtPassNuevo.Value);

            Response.Redirect("View/Index.aspx");

        }

        protected void Omitir_Password(object sender, EventArgs e)
        {
            Response.Redirect("View/Index.aspx");
        }
    }
}