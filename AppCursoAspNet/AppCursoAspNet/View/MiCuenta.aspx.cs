using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista.View
{
    public partial class MiCuenta : System.Web.UI.Page
    {
        Controladora.SEGURIDAD.ControladoraGrupos ctrlGrupos = new Controladora.SEGURIDAD.ControladoraGrupos();
        Controladora.SEGURIDAD.ControladoraUsuarios ctrlUsuarios = new Controladora.SEGURIDAD.ControladoraUsuarios();
        Controladora.SEGURIDAD.ControladoraPerfiles ctrlPerfiles = new Controladora.SEGURIDAD.ControladoraPerfiles();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                Modelo.SEGURIDAD.Usuario oUsuario = ctrlUsuarios.BuscarUsuario(this.Context.User.Identity.Name);
                try
                {
                    this.usuario.Text = oUsuario.IDUsuario;
                    this.nombreyapellido.Text = oUsuario.NombreApellido;
                    this.email.Value = oUsuario.Email;
                    this.grupo.Text = oUsuario.Grupo.FirstOrDefault().IDGrupo.ToString();

                }
                catch (NullReferenceException ex)
                {
                    Response.Redirect("../View/Error.aspx?error=" + ex.Message);

                }

            }
        }


        protected void aceptar_Click(object sender, EventArgs e)
        {

            Modelo.SEGURIDAD.Usuario oUsuario = ctrlUsuarios.BuscarUsuario(this.Context.User.Identity.Name);

            oUsuario.NombreApellido = nombreyapellido.Text;
            oUsuario.Email = email.Value;
            ctrlUsuarios.ModificarUsuario(oUsuario);
            Response.Redirect("../View/Index.aspx");
 
        }

    }
}