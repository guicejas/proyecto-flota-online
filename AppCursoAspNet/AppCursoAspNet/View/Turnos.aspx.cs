using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controladora;

namespace Vista.View
{
    public partial class Turnos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public List<Modelo.Turno> GetTurnos()
        {
            return ControladoraTurnos.getINSTANCIA.ListarTurnos();
        }
        protected void listaTurnos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string idTurno = this.listaTurnos.Rows[e.NewEditIndex].Cells[0].Text;
            Response.Redirect("EditarTurno?Id=" + idTurno);
        }

        protected void listaTurnos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string idTurno = this.listaTurnos.Rows[e.RowIndex].Cells[0].Text;
            ControladoraTurnos.getINSTANCIA.EliminarTurno(Convert.ToInt32(idTurno));
            e.Cancel = true;
            this.listaTurnos.DataSource = null;
        }
    }
}