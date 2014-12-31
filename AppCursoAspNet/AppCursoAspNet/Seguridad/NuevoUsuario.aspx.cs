using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista.Seguridad
{
    public partial class NuevoUsuario : System.Web.UI.Page
    {
        Controladora.SEGURIDAD.ControladoraGrupos ctrlGrupos = new Controladora.SEGURIDAD.ControladoraGrupos();
        Controladora.SEGURIDAD.ControladoraUsuarios ctrlUsuarios = new Controladora.SEGURIDAD.ControladoraUsuarios();

        Controladora.SEGURIDAD.ControladoraPerfiles ctrlPerfiles = new Controladora.SEGURIDAD.ControladoraPerfiles();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ctrlPerfiles.ObtenerFormularios(HttpContext.Current.User.Identity.Name).Exists(a => a == "Administracion"))
            {
                return;
            }
            else
                Response.Redirect("~/NoAutorizado.aspx");


        }

        protected void aceptar_Click(object sender, EventArgs e)
        {

            if (!ValidarCheckboxListGrupos())
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Debe seleccionar al menos un Grupo');", true);
                LbGrupos.Focus();
                return;
            }


            Modelo.SEGURIDAD.Usuario oUsuario = new Modelo.SEGURIDAD.Usuario();

            oUsuario.IDUsuario = usuario.Text;
            oUsuario.NombreApellido = nombreyapellido.Text;
            oUsuario.Email = email.Value;
            oUsuario.Habilitado = habilitado.Checked;
            oUsuario.Contraseña = "newuser";
            oUsuario.PrimeraVez = true;

            foreach (ListItem item in LbGrupos.Items)
            {
                if (item.Selected)
                    oUsuario.Grupo.Add(ctrlGrupos.ObtenerGrupo(item.Value));
            }

            if (ctrlUsuarios.VerificarUsuario(oUsuario))
            {
                ctrlUsuarios.AgregarUsuario(oUsuario);
                string mensaje = ctrlUsuarios.CambiarContraseña(oUsuario); // DESCOMENTAR EN PRODUCCION
                Response.Redirect("Usuarios.aspx?msj=" + mensaje);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('El nombre de usuario ingresado ya pertenece a un usuario existente');", true);
                return;

            }

        }

        protected bool ValidarCheckboxListGrupos()
        {
            bool tieneGrupo = false;
            foreach (ListItem item in LbGrupos.Items)
            {
                if (item.Selected)
                    tieneGrupo = true;
            }
            return tieneGrupo;
        }

    }
}