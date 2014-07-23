using Controladora;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista
{
    public partial class NuevoGasto : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void aceptar_Click(object sender, EventArgs e)
        {


            Modelo.Gasto oGasto = new Modelo.Gasto();

            oGasto.Descripcion = this.descripcion.Text;
            oGasto.Monto = Convert.ToDecimal(this.monto.Text);
            oGasto.TipodeGasto = ControladoraTiposdeGasto.getINSTANCIA.ObtenerTipodeGasto(Convert.ToInt32(this.dlTipoDeGasto.SelectedValue));
            oGasto.Estado = this.DlEstado.SelectedValue;
            oGasto.FechaVencimiento = Convert.ToDateTime(this.txtFecha.Value);
            oGasto.Vehiculo = ControladoraVehiculos.getINSTANCIA.ObtenerVehiculo(this.DlVehiculo.SelectedValue);
            oGasto.Usuario = "admin";
            oGasto.FechayHora = DateTime.Now;
            oGasto.Operacion = "ALTA";
            ControladoraGastos.getINSTANCIA.AgregarGasto(oGasto);
            Controladora.AUDITORIA.ControladoraAudGastos.getINSTANCIA.AuditarGastosMOD(oGasto);
            Response.Redirect("Gastos.aspx");
        }

        protected void dlTipoDeGasto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ControladoraTiposdeGasto.getINSTANCIA.ObtenerDescripcion(Convert.ToInt32(this.dlTipoDeGasto.SelectedValue)) == "INFRACCION")
            {
                this.boxFechaInfraccion.Visible = true;
                this.boxHoraInfraccion.Visible = true;
            }
            else
            {
                this.boxFechaInfraccion.Visible = false;
                this.boxHoraInfraccion.Visible = false;
            }
        }







    }
}
