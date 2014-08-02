using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controladora;
using Controladora.AUDITORIA;

namespace Vista.View
{
    public partial class Vehiculos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        public List<Modelo.Vehiculo> GetVehiculos()
        {
            return ControladoraVehiculos.getINSTANCIA.ListarVehiculos();
        }

        protected void listaVehiculos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String nroPatente = this.listaVehiculos.Rows[e.RowIndex].Cells[0].Text;
            //ControladoraAudGastos.getINSTANCIA.AuditarGastosBAJA(ControladoraGastos.getINSTANCIA.ObtenerGasto(gastoId));
            ControladoraVehiculos.getINSTANCIA.EliminarVehiculo(nroPatente);
            e.Cancel = true;
            this.listaVehiculos.DataSource = null;
        }

        protected void listaVehiculos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string nroPatente = this.listaVehiculos.Rows[e.NewEditIndex].Cells[0].Text;
            Response.Redirect("EditarVehiculo?Patente=" + nroPatente);
        }
    }
}