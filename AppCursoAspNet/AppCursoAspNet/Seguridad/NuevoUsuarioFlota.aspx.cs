using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista.Seguridad
{
    public partial class NuevoUsuarioFlota : System.Web.UI.Page
    {
        Controladora.SEGURIDAD.ControladoraGrupos ctrlGrupos = new Controladora.SEGURIDAD.ControladoraGrupos();
        Controladora.SEGURIDAD.ControladoraUsuarios ctrlUsuarios = new Controladora.SEGURIDAD.ControladoraUsuarios();
        Controladora.SEGURIDAD.ControladoraPerfiles ctrlPerfiles = new Controladora.SEGURIDAD.ControladoraPerfiles();
        Controladora.SEGURIDAD.ControladoraFlotas ctrlFlotas = new Controladora.SEGURIDAD.ControladoraFlotas();
        Controladora.SEGURIDAD.ControladoraTiposdeLicencia ctrlTipoLicencias = new Controladora.SEGURIDAD.ControladoraTiposdeLicencia();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!ctrlPerfiles.ObtenerFormularios(HttpContext.Current.User.Identity.Name).Exists(a => a == "Sistema"))
                Response.Redirect("~/NoAutorizado.aspx");

            if (ctrlFlotas.ObtenerFlotadeUsuario(this.Context.User.Identity.Name).ultimaLicencia.TipoLicencia.tipo == "Premium")
            {
                if (ctrlUsuarios.ListarUsuarios(ctrlFlotas.ObtenerFlotadeUsuario(this.Context.User.Identity.Name).Id.ToString()).Count > (ctrlTipoLicencias.ObtenerTipoLicenciaPremium(ctrlFlotas.ObtenerFlotadeUsuario(this.Context.User.Identity.Name).ultimaLicencia.TipoLicencia.Id.ToString()).CantUsuarios - 1))
                {
                    Response.Redirect("~/NoAutorizado.aspx");
                }
            }

            if (ctrlFlotas.ObtenerFlotadeUsuario(this.Context.User.Identity.Name).ultimaLicencia.TipoLicencia.tipo != "Premium")
            {
                   Response.Redirect("~/NoAutorizado.aspx");
            }


            DlFlota.SelectedValue = ctrlFlotas.ObtenerFlotadeUsuario(HttpContext.Current.User.Identity.Name).Id.ToString();
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
            oUsuario.Flota = ctrlFlotas.ObtenerFlota(this.DlFlota.SelectedValue.ToString());

            foreach (ListItem item in LbGrupos.Items)
            {
                if (item.Selected)
                    oUsuario.Grupo.Add(ctrlGrupos.ObtenerGrupo(item.Value));
            }

            if (ctrlUsuarios.VerificarUsuario(oUsuario))
            {
                ctrlUsuarios.AgregarUsuario(oUsuario);
                string mensaje = ctrlUsuarios.CambiarContraseña(oUsuario); // DESCOMENTAR EN PRODUCCION
                Response.Redirect("UsuariosFlota.aspx?msj=" + mensaje);
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