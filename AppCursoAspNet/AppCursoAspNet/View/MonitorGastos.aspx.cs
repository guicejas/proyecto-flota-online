using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista.View
{
    public partial class MonitorGastos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ActualizarBarra();
        }


        public IList<Modelo.Gasto> ListMonitorGastos_GetData()
        {
            return Controladora.ControladoraGastos.getINSTANCIA.ListarGastosMonitor();
        }

        public void ActualizarBarra()
        {
            double porcRojo = 0;
            double porcAmarillo = 0;
            double porcVerde = 0;

            double rojo = Controladora.ControladoraGastos.getINSTANCIA.BarraProgresoRojo();
            double amarillo = Controladora.ControladoraGastos.getINSTANCIA.BarraProgresoAmarillo();
            double verde = Controladora.ControladoraGastos.getINSTANCIA.BarraProgresoVerde();
            double total = rojo + amarillo + verde;
            if (rojo > 0)
            {porcRojo = Math.Round((rojo * 100) / total, 2); };
            if (amarillo > 0)
            { porcAmarillo = Math.Round((amarillo * 100) / total, 2); ; };
            if (verde > 0)
            { porcVerde = Math.Round((verde * 100) / total,2); ; };

            barraVerde.Attributes.CssStyle.Clear();
            barraVerde.Attributes.CssStyle.Value = "width: " + porcVerde.ToString().Replace(",",".") + "%";
            barraVerde.InnerText = porcVerde + "%";

            barraAmarilla.Attributes.CssStyle.Clear();
            barraAmarilla.Attributes.CssStyle.Value = "width: " + porcAmarillo.ToString().Replace(",",".") + "%";
            barraAmarilla.InnerText = porcAmarillo + "%";

            barraRoja.Attributes.CssStyle.Clear();
            barraRoja.Attributes.CssStyle.Value = "width: " + porcRojo.ToString().Replace(",",".") + "%";
            barraRoja.InnerText = porcRojo + "%";
        }

        
    }
}