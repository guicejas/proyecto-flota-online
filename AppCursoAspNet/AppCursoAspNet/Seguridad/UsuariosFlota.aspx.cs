using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista.Seguridad
{
    public partial class UsuariosFlota : System.Web.UI.Page
    {
        Controladora.SEGURIDAD.ControladoraUsuarios ctrlUsuarios = new Controladora.SEGURIDAD.ControladoraUsuarios();
        Controladora.SEGURIDAD.ControladoraPerfiles ctrlPerfiles = new Controladora.SEGURIDAD.ControladoraPerfiles();
        Controladora.SEGURIDAD.ControladoraFlotas ctrlFlotas = new Controladora.SEGURIDAD.ControladoraFlotas();
        Controladora.SEGURIDAD.ControladoraTiposdeLicencia ctrlTipoLicencias = new Controladora.SEGURIDAD.ControladoraTiposdeLicencia();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!ctrlPerfiles.ObtenerFormularios(HttpContext.Current.User.Identity.Name).Exists(a => a == "Sistema"))
                Response.Redirect("~/NoAutorizado.aspx");

            if (Request.QueryString["msj"] != null)
            {
                mensaje.Visible = true;
                mensajeTexto.InnerHtml = Request.QueryString["msj"];
            }

            if (ctrlFlotas.ObtenerFlotadeUsuario(this.Context.User.Identity.Name).ultimaLicencia.TipoLicencia.tipo == "Premium")
            { 
                if (ctrlUsuarios.ListarUsuarios(ctrlFlotas.ObtenerFlotadeUsuario(this.Context.User.Identity.Name).Id.ToString()).Count < (ctrlTipoLicencias.ObtenerTipoLicenciaPremium(ctrlFlotas.ObtenerFlotadeUsuario(this.Context.User.Identity.Name).ultimaLicencia.TipoLicencia.Id.ToString()).CantUsuarios))
                {
                    btnAgregarUsuario.Visible = true;
                }
            }

        }

        public List<Modelo.SEGURIDAD.Usuario> GetUsuarios()
        {
            return ctrlUsuarios.ListarUsuarios(ctrlFlotas.ObtenerFlotadeUsuario(this.Context.User.Identity.Name).Id.ToString());
        }

        protected void listaUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string usuarioId = this.listaUsuarios.Rows[e.RowIndex].Cells[0].Text;
            if (usuarioId != this.Context.User.Identity.Name)
            {
                ctrlUsuarios.EliminarUsuario(usuarioId);
                e.Cancel = true;
                this.listaUsuarios.DataSource = null;
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('No puede eliminar su propio usuario');", true);
                e.Cancel = true;
            }
        }

        protected void listaUsuarios_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string usuarioId = this.listaUsuarios.Rows[e.NewEditIndex].Cells[0].Text;
            if (usuarioId != this.Context.User.Identity.Name)
            {
                Response.Redirect("EditarUsuarioFlota?UsuarioId=" + usuarioId);
            }
            else
            {
                Response.Redirect("../View/MiCuenta");
            }
        }

        protected void listaUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            string usuarioId = this.listaUsuarios.SelectedRow.Cells[0].Text;
            Response.Redirect("VerUsuarioFlota?UsuarioId=" + usuarioId);
        }

        
    }
}