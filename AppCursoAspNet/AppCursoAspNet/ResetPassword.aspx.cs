using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        Controladora.SEGURIDAD.ControladoraLogin ctrlLogin = new Controladora.SEGURIDAD.ControladoraLogin();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Reset_Password(object sender, EventArgs e)
        {
            object result = ctrlLogin.ResetearContraseña(inputEmail.Value);
            if ((int)result == 1)
            {
                mensaje.Visible = true;
                mensaje.Attributes.Add("class", "alert alert-dismissable alert-danger");
                    mensajeTexto.InnerHtml = "Error: El email ingresado no pertenece a un usuario del sistema.";
            }
            else
            {
                mensaje.Visible = true;
                mensaje.Attributes.Add("class", "alert alert-dismissable alert-success");
                mensajeTexto.InnerHtml = "La nueva contraseña fue enviada.";
            }

        }
    }
}