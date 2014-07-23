using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Controladora.ControladoraTiposdeGasto.getINSTANCIA.CargarTiposdeGasto();

            if (Controladora.ControladoraGastos.getINSTANCIA.ListarGastosMonitor().Count() > 0)
            {
                if (Controladora.ControladoraGastos.getINSTANCIA.ListarGastosRojo().Count() > 0)
                {
                    panelMonitor.Attributes.Add("class", "panel panel-danger");
                    contenidoMonitor.InnerText = "Peligro, hay gastos vencidos o muy proximos a vercer.";
                    iconMonitor.Attributes.Add("class", "glyphicon glyphicon-remove");
                }
                else
                {
                    if (Controladora.ControladoraGastos.getINSTANCIA.ListarGastosAmarillo().Count() > 0)
                    {
                        panelMonitor.Attributes.Add("class", "panel panel-warning");
                        contenidoMonitor.InnerText = "Cuidado, hay gastos proximos a vercer.";
                        iconMonitor.Attributes.Add("class", "glyphicon glyphicon-warning_sign");
                    }
                    else
                    {
                        if (Controladora.ControladoraGastos.getINSTANCIA.ListarGastosVerde().Count() > 0)
                        {
                            panelMonitor.Attributes.Add("class", "panel panel-success");
                            contenidoMonitor.InnerText = "Hay gastos con vencimiento dentro de los proximos 15 días.";
                            iconMonitor.Attributes.Add("class", "glyphicon glyphicon-ok");
                        }
                    }
                }
            }
            else
            {
                panelMonitor.Attributes.Add("class", "hide");
            }

        }
    }
}