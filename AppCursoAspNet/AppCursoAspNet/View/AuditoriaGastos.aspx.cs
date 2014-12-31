using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controladora.AUDITORIA;

namespace Vista.View
{
    public partial class AuditoriaGastos : System.Web.UI.Page
    {
        Controladora.SEGURIDAD.ControladoraPerfiles ctrlPerfiles = new Controladora.SEGURIDAD.ControladoraPerfiles();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ctrlPerfiles.ObtenerFormularios(HttpContext.Current.User.Identity.Name).Exists(a => a == "Administracion"))
            {
                return;
            }
            else
                Response.Redirect("~/NoAutorizado.aspx");

        }

        public List<Modelo.AUDITORIA.AudGasto> GetAuditoria()
        {
            return ControladoraAudGastos.getINSTANCIA.ListarGastos();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (txtFiltroUsuario.Text != "" || txtFiltroFecha.Text != "" || txtFiltroOperacion.Text != "" || txtFiltroGasto.Text != "")
            { GridAuditoria.SelectMethod = "GetAuditoriaFilter"; }
        }

        protected void btnReestablecer_Click(object sender, EventArgs e)
        {
            txtFiltroUsuario.Text = "";
            txtFiltroFecha.Text = "";
            txtFiltroOperacion.Text = "";
            txtFiltroGasto.Text = "";
            GridAuditoria.SelectMethod = "GetAuditoriaFilter";
        }


        public List<Modelo.AUDITORIA.AudGasto> GetAuditoriaFilter()
        {
            string usuario = null;
            Nullable<System.DateTime> fecha = null;
            string operacion = null;
            string gasto = null;

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

            if (txtFiltroGasto.Text != "")
            {
                gasto = txtFiltroGasto.Text;
            }

            return ControladoraAudGastos.getINSTANCIA.FiltrarAudGastos(usuario, fecha, operacion, gasto);
        }
    }
}