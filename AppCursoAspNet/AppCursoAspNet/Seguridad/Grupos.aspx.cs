using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista.Seguridad
{
    public partial class Grupos : System.Web.UI.Page
    {
        Controladora.SEGURIDAD.ControladoraGrupos ctrlGrupos = new Controladora.SEGURIDAD.ControladoraGrupos();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public List<Modelo.SEGURIDAD.Grupo> GetGrupos()
        {
            return ctrlGrupos.ListarGrupos();
        }

        protected void listaGrupos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string grupoId = this.listaGrupos.Rows[e.RowIndex].Cells[0].Text;
            ctrlGrupos.EliminarGrupo(grupoId);
            e.Cancel = true;
            this.listaGrupos.DataSource = null;
        }

        protected void listaGrupos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string grupoId = this.listaGrupos.Rows[e.NewEditIndex].Cells[0].Text;
            Response.Redirect("EditarGrupo?GrupoId=" + grupoId);
        }


    }
}