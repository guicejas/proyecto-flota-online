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
        protected void Page_Load(object sender, EventArgs e)
        {
            
           
        }


        public List<Modelo.Gasto> GetGastos()
        {
            return ControladoraGastos.getINSTANCIA.ListarGastos();
        }


        protected void listaGastos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int gastoId = Convert.ToInt32(this.listaGastos.Rows[e.RowIndex].Cells[0].Text);
            ControladoraAudGastos.getINSTANCIA.AuditarGastosBAJA(ControladoraGastos.getINSTANCIA.ObtenerGasto(gastoId));
            ControladoraGastos.getINSTANCIA.EliminarGasto(gastoId);
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
            return ControladoraGastos.getINSTANCIA.ListarGastosFiltrados(descripcion, fecha, estado, vehiculo);
        }

    }
}