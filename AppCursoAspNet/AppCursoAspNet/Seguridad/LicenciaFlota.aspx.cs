using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Controladora;

namespace Vista.Seguridad
{
    public partial class LicenciaFlota : System.Web.UI.Page
    {
        Controladora.SEGURIDAD.ControladoraPerfiles ctrlPerfiles = new Controladora.SEGURIDAD.ControladoraPerfiles();
        Controladora.SEGURIDAD.ControladoraFlotas ctrlFlotas = new Controladora.SEGURIDAD.ControladoraFlotas();
        Controladora.SEGURIDAD.ControladoraTiposdeLicencia ctrlTiposdeLicencia = new Controladora.SEGURIDAD.ControladoraTiposdeLicencia();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!ctrlPerfiles.ObtenerFormularios(HttpContext.Current.User.Identity.Name).Exists(a => a == "Sistema"))
                Response.Redirect("~/NoAutorizado.aspx");


        }
        public IList<Modelo.SEGURIDAD.TipoLicencia> ListarTiposdeLicenciaBasica()
        {
            return ctrlTiposdeLicencia.ListarTiposdeLicenciaBasica();
        }

        public IList<Modelo.SEGURIDAD.TipoLicencia> ListarTiposdeLicenciaPremium()
        {
            return ctrlTiposdeLicencia.ListarTiposdeLicenciaPremium();
        }


        //protected void btnFiltrar_Click(object sender, EventArgs e)
        //{
        //    if (txtFiltroDocumento.Text != "" || txtFiltroNombre.Text != "" || txtFiltroLocalidad.Text != "")
        //    { ObjectChofer.SelectMethod = "GetChoferesFilter"; }

        //}
        //protected void btnReestablecer_Click(object sender, EventArgs e)
        //{
        //    txtFiltroDocumento.Text = "";
        //    txtFiltroNombre.Text = "";
        //    txtFiltroLocalidad.Text = "";
        //    ObjectChofer.SelectMethod = "GetChoferesFilter";
        //}

        //public List<Modelo.Chofer> GetChoferesFilter()
        //{
        //    string documento = null;
        //    string nombre = null;
        //    string localidad = null;

        //    if (txtFiltroDocumento.Text != "")
        //    {
        //        documento = txtFiltroDocumento.Text;
        //    }

        //    if (txtFiltroNombre.Text != "")
        //    {
        //        nombre = txtFiltroNombre.Text;
        //    }

        //    if (txtFiltroLocalidad.Text != "")
        //    {
        //        localidad = txtFiltroLocalidad.Text;
        //    }

        //    return ControladoraChoferes.getINSTANCIA.ListarChoferesFiltrados(documento, nombre, localidad);
        //}

    }
}