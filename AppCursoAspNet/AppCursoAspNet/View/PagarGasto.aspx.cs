using Vista.Logic;
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
    public partial class PagarGasto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    int gastoId = Convert.ToInt32(Request.QueryString["GastoId"]);

                    Modelo.Gasto oGasto = ControladoraGastos.getINSTANCIA.ObtenerGasto(gastoId);
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

                    oGasto.Estado = "PAGADO";
                    oGasto.Operacion = "MODIFICACION";
                    ControladoraAudGastos.getINSTANCIA.AuditarGastosMOD(oGasto);
                    ControladoraGastos.getINSTANCIA.ModificarGasto(oGasto);

                }
                catch (NullReferenceException ex)
                {
                    Response.Redirect("Error.aspx?error=" + ex.Message);

                }
            }

            Response.Redirect("MonitorGastos.aspx");
        }
    }
}