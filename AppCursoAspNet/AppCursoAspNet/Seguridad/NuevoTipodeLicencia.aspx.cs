using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista.Seguridad
{
    public partial class NuevoTipodeLicencia : System.Web.UI.Page
    {
        Controladora.SEGURIDAD.ControladoraTiposdeLicencia ctrlTiposdeLicencia = new Controladora.SEGURIDAD.ControladoraTiposdeLicencia();
        Controladora.SEGURIDAD.ControladoraPerfiles ctrlPerfiles = new Controladora.SEGURIDAD.ControladoraPerfiles();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!ctrlPerfiles.ObtenerFormularios(HttpContext.Current.User.Identity.Name).Exists(a => a == "Administracion"))
                Response.Redirect("~/NoAutorizado.aspx");

        }

        protected void aceptar_Click(object sender, EventArgs e)
        {



            Modelo.SEGURIDAD.Grupo oGrupo = new Modelo.SEGURIDAD.Grupo();

            oGrupo.IDGrupo = nombre.Text;
            oGrupo.Descripcion = descripcion.Text;


            
        }

    }
}