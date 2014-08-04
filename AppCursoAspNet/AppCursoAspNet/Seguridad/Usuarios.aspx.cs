using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista.Seguridad
{
    public partial class Usuarios : System.Web.UI.Page
    {
        Controladora.SEGURIDAD.ControladoraUsuarios ctrlUsuarios = new Controladora.SEGURIDAD.ControladoraUsuarios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["msj"] != null)
            {
                mensaje.Visible = true;
                mensajeTexto.InnerHtml = Request.QueryString["msj"];
            }
        }

        public List<Modelo.SEGURIDAD.Usuario> GetUsuarios()
        {
            return ctrlUsuarios.ListarUsuarios();
        }

        protected void listaUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string usuarioId = this.listaUsuarios.Rows[e.RowIndex].Cells[0].Text;
            ctrlUsuarios.EliminarUsuario(usuarioId);
            e.Cancel = true;
            this.listaUsuarios.DataSource = null;
        }

        protected void listaUsuarios_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string grupoId = this.listaUsuarios.Rows[e.NewEditIndex].Cells[0].Text;
            Response.Redirect("EditarUsuario?UsuarioId=" + grupoId);
        }

        protected void listaUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            string grupoId = this.listaUsuarios.SelectedRow.Cells[0].Text;
            Response.Redirect("VerUsuario?UsuarioId=" + grupoId);
        }

        
    }
}