using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista.Seguridad
{
    public partial class RechazarLicencia : System.Web.UI.Page
    {
        Controladora.SEGURIDAD.ControladoraLicencias ctrlLicencias = new Controladora.SEGURIDAD.ControladoraLicencias();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string id = Request.QueryString["id"];

                    Modelo.SEGURIDAD.Licencia oLicencia = ctrlLicencias.ObtenerLicencia(id);
                    oLicencia.Estado = "Rechazada";

                    ctrlLicencias.ModificarLicencia(oLicencia);
                }
                catch (NullReferenceException ex)
                {
                    Response.Redirect("Error.aspx?error=" + ex.Message);

                }

                Response.Redirect("Licencias.aspx");
            }
        }
    }
}