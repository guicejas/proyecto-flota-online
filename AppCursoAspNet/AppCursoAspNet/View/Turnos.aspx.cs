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
        Controladora.SEGURIDAD.ControladoraPerfiles ctrlPerfiles = new Controladora.SEGURIDAD.ControladoraPerfiles();
        Controladora.SEGURIDAD.ControladoraFlotas ctrlFlotas = new Controladora.SEGURIDAD.ControladoraFlotas();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ctrlPerfiles.ObtenerFormularios(HttpContext.Current.User.Identity.Name).Exists(a => a == "Turnos"))
            {
                if (!IsPostBack)
                {
                    List<string> permisos = ctrlPerfiles.ObtenerPermisos(HttpContext.Current.User.Identity.Name, "Turnos");

                    if (permisos.Exists(a => a == "TOTAL"))
                    { return; }
                    else
                    {
                        if (!permisos.Exists(a => a == "ALTA"))
                            HyperLink1.Visible = false;
                        if (!permisos.Exists(a => a == "BAJA"))
                            listaTurnos.Columns.RemoveAt(5);
                        if (!permisos.Exists(a => a == "MODIFICACION"))
                            listaTurnos.Columns.RemoveAt(4);
                    }
                }
            }
            else
                Response.Redirect("~/NoAutorizado.aspx");

        }
        public List<Modelo.Turno> GetTurnos()
        {
            return ControladoraTurnos.getINSTANCIA.ListarTurnos(ctrlFlotas.ObtenerFlotadeUsuario(this.Context.User.Identity.Name).Id.ToString());
        }
        protected void listaTurnos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string idTurno = this.listaTurnos.Rows[e.NewEditIndex].Cells[0].Text;
            Response.Redirect("EditarTurno?Id=" + idTurno);
        }

        protected void listaTurnos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string idTurno = this.listaTurnos.Rows[e.RowIndex].Cells[0].Text;

            if (ControladoraTurnos.getINSTANCIA.EliminarTurno(Convert.ToInt32(idTurno)))
            {
                lblModalTitle.Text = "CUIDADO";
                lblModalBody.Text = "el registro no puede ser eliminado ya que contiene datos asociados.";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                upModal.Update();
            }
            //e.Cancel = true;
            //this.listaTurnos.DataSource = null;
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            lblModalTitle.Text = "CUIDADO";
            lblModalBody.Text = "Esta seguro que desea eliminar el registro seleccionado?";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
            upModal.Update();
            return;

        }

        protected void eliminar_registro(object sender, GridViewDeleteEventArgs e)
        {
            string idTurno = this.listaTurnos.Rows[e.RowIndex].Cells[0].Text;
            ControladoraTurnos.getINSTANCIA.EliminarTurno(Convert.ToInt32(idTurno));
            e.Cancel = true;
            this.listaTurnos.DataSource = null;
        }

        protected void listaTurnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string turnoId = this.listaTurnos.SelectedRow.Cells[0].Text;
            Response.Redirect("VerTurno?TurnoId=" + turnoId);
        }
        

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (txtFiltroChofer.Text != "" || txtFiltroVehiculo.Text != "" || txtFiltroFecha.Text != "")
            { listaTurnos.SelectMethod = "GetTurnosFilter"; }

        }


        protected void btnReestablecer_Click(object sender, EventArgs e)
        {
            txtFiltroChofer.Text = "";
            txtFiltroVehiculo.Text = "";
            txtFiltroFecha.Text = "";
            listaTurnos.SelectMethod = "GetTurnosFilter";
        }


        public List<Modelo.Turno> GetTurnosFilter()
        {
            string chofer = null;
            Nullable<System.DateTime> fecha = null;
            string vehiculo = null;

            if (txtFiltroChofer.Text != "")
            {
                chofer = txtFiltroChofer.Text;
            }

            if (txtFiltroFecha.Text != "")
            {
                fecha = Convert.ToDateTime(txtFiltroFecha.Text);
            }

            if (txtFiltroVehiculo.Text != "")
            {
                vehiculo = txtFiltroVehiculo.Text;
            }

            return ControladoraTurnos.getINSTANCIA.ListarTurnosFiltrados(ctrlFlotas.ObtenerFlotadeUsuario(this.Context.User.Identity.Name).Id.ToString(), chofer, fecha, vehiculo);
        }


    }
}