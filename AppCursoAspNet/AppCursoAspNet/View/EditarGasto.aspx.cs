using Controladora;
using Controladora.AUDITORIA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista.View
{
    public partial class EditarGasto : System.Web.UI.Page
    {
        Controladora.SEGURIDAD.ControladoraFlotas ctrlFlotas = new Controladora.SEGURIDAD.ControladoraFlotas();

        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                int gastoId = Convert.ToInt32(Request.QueryString["GastoId"]);

                Modelo.Gasto oGasto = ControladoraGastos.getINSTANCIA.ObtenerGasto(gastoId);
                try
                {
                    this.id.Text = oGasto.Id.ToString();
                    this.descripcion.Text = oGasto.Descripcion;
                    this.monto.Text = oGasto.Monto.ToString();
                    this.IDgasto.Value = oGasto.Id.ToString();
                    this.cbxTipoGasto.SelectedValue = oGasto.TipodeGasto.Id.ToString();
                    //if (oGasto.FechaEmision.HasValue)
                        //this.txtFechaInfraccion.Value = Convert.ToInt16(oGasto.FechaEmision.ToString());
                            //.ToString("yyyy-MM-dd");
                    //if (oGasto.HoraEmision.HasValue)
                        //this.HoraInfraccion.Value = (DateTime)oGasto.HoraEmision.ToString("yyyy-MM-dd");

                    this.DlVehiculo.SelectedValue = oGasto.Vehiculo.Patente.ToString();
                    this.txtFecha.Value = oGasto.FechaVencimiento.ToString("yyyy-MM-dd");

                }
                catch (NullReferenceException ex)
                {
                    Response.Redirect("Error.aspx?error=" + ex.Message);

                }
            }

        }

        protected void aceptar_Click(object sender, EventArgs e)
        {
            Modelo.Gasto oGasto = ControladoraGastos.getINSTANCIA.ObtenerGasto(Convert.ToInt32(this.IDgasto.Value));

            //Modelo.Gasto oGastoAUDI = new Modelo.Gasto();

            //oGastoAUDI.Id = oGasto.Id;
            //oGastoAUDI.Descripcion = oGasto.Descripcion;
            //oGastoAUDI.Monto = oGasto.Monto;
            //oGastoAUDI.Estado = oGasto.Estado;
            //oGastoAUDI.FechaVencimiento = oGasto.FechaVencimiento;
            //oGastoAUDI.HoraEmision = oGasto.HoraEmision;
            //oGastoAUDI.FechaEmision = oGasto.FechaEmision;
            //oGastoAUDI.TipodeGasto = oGasto.TipodeGasto;
            //oGastoAUDI.Vehiculo = oGasto.Vehiculo;
            //oGastoAUDI.Usuario = oGasto.Usuario;
            //oGastoAUDI.FechayHora = oGasto.FechayHora;
            //oGastoAUDI.Operacion = oGasto.Operacion;

            oGasto.Descripcion = this.descripcion.Text;
            oGasto.Monto = Convert.ToDecimal(this.monto.Text);
            oGasto.TipodeGasto = ControladoraTiposdeGasto.getINSTANCIA.ObtenerTipodeGasto(Convert.ToInt32(this.cbxTipoGasto.SelectedValue));
            oGasto.Estado = this.DlEstado.SelectedValue;
            oGasto.FechaVencimiento = Convert.ToDateTime(this.txtFecha.Value);
            oGasto.Vehiculo = ControladoraVehiculos.getINSTANCIA.ObtenerVehiculo(this.DlVehiculo.SelectedValue);
            oGasto.Usuario = HttpContext.Current.User.Identity.Name;
            oGasto.FechayHora = DateTime.Now;

            oGasto.TipodeGasto = ControladoraTiposdeGasto.getINSTANCIA.ObtenerTipodeGasto(Convert.ToInt32(cbxTipoGasto.SelectedValue));

            oGasto.Operacion = "MODIFICACION";

            ControladoraAudGastos.getINSTANCIA.AuditarGastosMOD(oGasto);
            ControladoraGastos.getINSTANCIA.ModificarGasto(oGasto);
            Response.Redirect("Gastos.aspx");
        }

        protected void cbxTipoGasto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public IList<Modelo.Vehiculo> ListarVehiculos()
        {

            return Controladora.ControladoraVehiculos.getINSTANCIA.ListarVehiculos(ctrlFlotas.ObtenerFlotadeUsuario(this.Context.User.Identity.Name).Id.ToString());
        }

        public IList<Modelo.TipodeGasto> ListarTiposdeGasto()
        {

            return Controladora.ControladoraTiposdeGasto.getINSTANCIA.ListarTiposdeGasto();
        }


    }
}