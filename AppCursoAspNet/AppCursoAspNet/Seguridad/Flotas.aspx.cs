using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controladora;

namespace Vista.View
{
    public partial class Flotas : System.Web.UI.Page
    {
        Controladora.SEGURIDAD.ControladoraPerfiles ctrlPerfiles = new Controladora.SEGURIDAD.ControladoraPerfiles();
        Controladora.SEGURIDAD.ControladoraFlotas ctrlFlotas = new Controladora.SEGURIDAD.ControladoraFlotas();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!ctrlPerfiles.ObtenerFormularios(HttpContext.Current.User.Identity.Name).Exists(a => a == "Administracion"))
                Response.Redirect("~/NoAutorizado.aspx");
        }
        public List<Modelo.SEGURIDAD.Flota> GetFlotas()
        {
            return ctrlFlotas.ListarFlotas();
        }


        protected void listaFlotas_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string empresaId = this.listaFlotas.Rows[e.NewEditIndex].Cells[0].Text;
            Response.Redirect("EditarFlota?flotaId=" + empresaId);
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (txtFiltroRazonSocial.Text != "")
            { this.listaFlotas.SelectMethod = "GetFlotasFilter"; }

        }
        protected void btnReestablecer_Click(object sender, EventArgs e)
        {
            txtFiltroRazonSocial.Text = "";
            listaFlotas.SelectMethod = "GetFlotasFilter";
        }

        public List<Modelo.SEGURIDAD.Flota> GetFlotasFilter()
        {
          
            string razonSocial = null;

            if (txtFiltroRazonSocial.Text != "")
            {
                razonSocial = txtFiltroRazonSocial.Text;
            }

            return ctrlFlotas.ListarFlotasFiltrados(razonSocial);
        }
    }
}