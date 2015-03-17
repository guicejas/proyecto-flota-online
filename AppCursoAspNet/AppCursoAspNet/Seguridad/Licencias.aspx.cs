using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista.Seguridad
{
    public partial class Licencias : System.Web.UI.Page
    {
       
        
        Controladora.SEGURIDAD.ControladoraLicencias ctrlLicencias = new Controladora.SEGURIDAD.ControladoraLicencias();
        Controladora.SEGURIDAD.ControladoraPerfiles ctrlPerfiles = new Controladora.SEGURIDAD.ControladoraPerfiles();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!ctrlPerfiles.ObtenerFormularios(HttpContext.Current.User.Identity.Name).Exists(a => a == "Administracion"))
                Response.Redirect("~/NoAutorizado.aspx");
            
        }


        public IList<Modelo.SEGURIDAD.Licencia> ListLicencias_GetData()
        {
            return ctrlLicencias.ListarLicencias();
        }



        
    }
}