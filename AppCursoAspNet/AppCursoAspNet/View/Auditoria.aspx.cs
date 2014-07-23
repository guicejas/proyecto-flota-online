using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controladora.AUDITORIA;

namespace Vista.View
{
    public partial class Auditoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public List<Modelo.AUDITORIA.AudGasto> GetAuditoria()
        {
            return ControladoraAudGastos.getINSTANCIA.ListarGastos();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (txtFiltroOperacion.Text != "" || txtFiltroFecha.Text != "" || txtFiltroOperacion.Text != "")
            { GridAuditoria.SelectMethod = "GetAuditoriaFilter"; }
        }

        protected void btnReestablecer_Click(object sender, EventArgs e)
        {
            txtFiltroUsuario.Text = "";
            txtFiltroFecha.Text = "";
            txtFiltroOperacion.Text = "";
            GridAuditoria.SelectMethod = "GetAuditoriaFilter";
        }


        public List<Modelo.AUDITORIA.AudGasto> GetAuditoriaFilter()
        {
            string usuario = null;
            Nullable<System.DateTime> fecha = null;
            string operacion = null;

            if (txtFiltroUsuario.Text != "")
            {
                usuario = txtFiltroUsuario.Text;
            }

            if (txtFiltroFecha.Text != "")
            {
                fecha = Convert.ToDateTime(txtFiltroFecha.Text);
            }

            if (txtFiltroOperacion.Text != "")
            {
                operacion = txtFiltroOperacion.Text;
            }

            return ControladoraAudGastos.getINSTANCIA.FiltrarAudGastos(usuario, fecha, operacion);
        }
    }
}