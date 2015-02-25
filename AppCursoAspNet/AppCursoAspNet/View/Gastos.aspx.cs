using Controladora;
using Controladora.AUDITORIA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista
{
    public partial class Gastos : System.Web.UI.Page
    {
        Controladora.SEGURIDAD.ControladoraPerfiles ctrlPerfiles = new Controladora.SEGURIDAD.ControladoraPerfiles();
        Controladora.SEGURIDAD.ControladoraFlotas ctrlFlotas = new Controladora.SEGURIDAD.ControladoraFlotas();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (ctrlPerfiles.ObtenerFormularios(HttpContext.Current.User.Identity.Name).Exists(a => a == "Gastos"))
            {
                
            if (!IsPostBack)
            {
                List<string> permisos = ctrlPerfiles.ObtenerPermisos(HttpContext.Current.User.Identity.Name, "Gastos");

                if (permisos.Exists(a => a == "TOTAL"))
                { return; }
                else
                {
                    if (!permisos.Exists(a => a == "ALTA"))
                        HyperLink1.Visible = false;
                    if (!permisos.Exists(a => a == "BAJA"))
                        listaGastos.Columns.RemoveAt(6);
                    if (!permisos.Exists(a => a == "MODIFICACION"))
                        listaGastos.Columns.RemoveAt(5);
                }
            }
            }
            else
                Response.Redirect("~/NoAutorizado.aspx");
           
        }

        public List<Modelo.Gasto> GetGastos()
        {
            return ControladoraGastos.getINSTANCIA.ListarGastos((ctrlFlotas.ObtenerFlotadeUsuario(this.Context.User.Identity.Name).Id.ToString()));
        }


        protected void listaGastos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int gastoId = Convert.ToInt32(this.listaGastos.Rows[e.RowIndex].Cells[0].Text);
            ControladoraAudGastos.getINSTANCIA.AuditarGastosBAJA(ControladoraGastos.getINSTANCIA.ObtenerGasto(gastoId), HttpContext.Current.User.Identity.Name);
            
            if (ControladoraGastos.getINSTANCIA.EliminarGasto(gastoId))
            {
                lblModalTitle.Text = "CUIDADO";
                lblModalBody.Text = "el registro no puede ser eliminado ya que contiene datos asociados.";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                upModal.Update();
            }


            e.Cancel = true;
            this.listaGastos.DataSource = null;
        }

        protected void listaGastos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string gastoId = this.listaGastos.Rows[e.NewEditIndex].Cells[0].Text;
            Response.Redirect("EditarGasto?GastoId=" + gastoId);
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (txtFiltroDescripcion.Text != "" || txtFiltroEstado.Text != "" || txtFiltroFechaVencimiento.Text != "" || txtFiltroVehiculo.Text != "")
            { listaGastos.SelectMethod = "GetGastosFilter"; }            
                
        }
        

        protected void btnReestablecer_Click(object sender, EventArgs e)
        {
            txtFiltroDescripcion.Text = "";
            txtFiltroEstado.Text = "";
            txtFiltroFechaVencimiento.Text = "";
            txtFiltroVehiculo.Text = "";
            listaGastos.SelectMethod = "GetGastosFilter";
        }


        public List<Modelo.Gasto> GetGastosFilter()
        {
            string descripcion = null;
            Nullable<System.DateTime> fecha = null;
            string estado = null;
            string vehiculo = null;

            if (txtFiltroDescripcion.Text != "")
            {
                descripcion = txtFiltroDescripcion.Text;
            }

            if (txtFiltroFechaVencimiento.Text != "")
            {
                fecha = Convert.ToDateTime(txtFiltroFechaVencimiento.Text);
            }

            if (txtFiltroEstado.Text != "")
            {
                estado = txtFiltroEstado.Text;
            }

            if (txtFiltroVehiculo.Text != "")
            {
                vehiculo = txtFiltroVehiculo.Text;
            }
            return ControladoraGastos.getINSTANCIA.ListarGastosFiltrados((ctrlFlotas.ObtenerFlotadeUsuario(this.Context.User.Identity.Name).Id.ToString()),descripcion, fecha, estado, vehiculo);
        }

    }
}