using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista.Seguridad
{
    public partial class TiposdeLicencia : System.Web.UI.Page
    {
        Controladora.SEGURIDAD.ControladoraTiposdeLicencia ctrlTiposdeLicencia = new Controladora.SEGURIDAD.ControladoraTiposdeLicencia();
        Controladora.SEGURIDAD.ControladoraPerfiles ctrlPerfiles = new Controladora.SEGURIDAD.ControladoraPerfiles();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!ctrlPerfiles.ObtenerFormularios(HttpContext.Current.User.Identity.Name).Exists(a => a == "Administracion"))
                Response.Redirect("~/NoAutorizado.aspx");

        }

        public List<Modelo.SEGURIDAD.TipoLicencia> GetTiposdeLicencia()
        {
            return ctrlTiposdeLicencia.ListarTiposdeLicencia();
        }

        protected void listaTiposLicencia_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string tipolicenciaId = this.listaTiposLicencia.Rows[e.RowIndex].Cells[0].Text;
            ctrlTiposdeLicencia.EliminarTipoLicencia(tipolicenciaId);
            e.Cancel = true;
            this.listaTiposLicencia.DataSource = null;
        }

        protected void listaTiposLicencia_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string tipolicenciaId = this.listaTiposLicencia.Rows[e.NewEditIndex].Cells[0].Text;
            Response.Redirect("EditarTipodeLicencia?TipoLicenciaId=" + tipolicenciaId);
        }


    }
}