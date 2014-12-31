using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista.Seguridad
{
    public partial class NuevoGrupo : System.Web.UI.Page
    {
        Controladora.SEGURIDAD.ControladoraGrupos ctrlGrupos = new Controladora.SEGURIDAD.ControladoraGrupos();

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

            if (ctrlGrupos.VerificarGrupo(oGrupo))
            {
                ctrlGrupos.AgregarGrupo(oGrupo);
                Response.Redirect("Grupos.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('El Nombre ingresado ya pertenece a un grupo existente');", true);
            }

            
        }

    }
}