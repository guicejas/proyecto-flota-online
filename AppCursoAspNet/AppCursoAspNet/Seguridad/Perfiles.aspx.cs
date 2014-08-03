using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista.Seguridad
{
    public partial class Perfiles : System.Web.UI.Page
    {
        Controladora.SEGURIDAD.ControladoraPerfiles ctrlPerfiles = new Controladora.SEGURIDAD.ControladoraPerfiles();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public List<Modelo.SEGURIDAD.Perfil> GetPerfiles()
        {
            return ctrlPerfiles.ListarPerfiles();
        }

        protected void listaGrupos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int perfilId = Convert.ToInt32(this.listaPerfiles.Rows[e.RowIndex].Cells[0].Text);
            ctrlPerfiles.EliminarPerfil(perfilId);
            e.Cancel = true;
            this.listaPerfiles.DataSource = null;
        }

        protected void listaGrupos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int perfilId = Convert.ToInt32(this.listaPerfiles.Rows[e.NewEditIndex].Cells[0].Text);
            Response.Redirect("EditarPerfil?PerfilId=" + perfilId);
        }
    }
}