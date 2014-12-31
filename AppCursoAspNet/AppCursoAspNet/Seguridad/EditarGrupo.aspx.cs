using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista.Seguridad
{
    public partial class EditarGrupo : System.Web.UI.Page
    {
        Controladora.SEGURIDAD.ControladoraGrupos ctrlGrupos = new Controladora.SEGURIDAD.ControladoraGrupos();
        Controladora.SEGURIDAD.ControladoraPerfiles ctrlPerfiles = new Controladora.SEGURIDAD.ControladoraPerfiles();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!ctrlPerfiles.ObtenerFormularios(HttpContext.Current.User.Identity.Name).Exists(a => a == "Administracion"))
                Response.Redirect("~/NoAutorizado.aspx");


            if (!IsPostBack)
            {
                string grupoNombre = Request.QueryString["GrupoId"];

                Modelo.SEGURIDAD.Grupo oGrupo = ctrlGrupos.ObtenerGrupo(grupoNombre);
                try
                {
                    this.nombre.Text = oGrupo.IDGrupo;
                    this.descripcion.Text = oGrupo.Descripcion;

                }
                catch (NullReferenceException ex)
                {
                    Response.Redirect("../View/Error.aspx?error=" + ex.Message);

                }
            }

        }

        protected void aceptar_Click(object sender, EventArgs e)
        {
            Modelo.SEGURIDAD.Grupo oGrupo = ctrlGrupos.ObtenerGrupo(nombre.Text);

            oGrupo.IDGrupo = this.nombre.Text;
            oGrupo.Descripcion = this.descripcion.Text;
            ctrlGrupos.ModificarGrupo(oGrupo);

            Response.Redirect("Grupos.aspx");

        }

    }
}