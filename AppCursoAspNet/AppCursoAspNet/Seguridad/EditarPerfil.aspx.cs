using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista.Seguridad
{
    public partial class EditarPerfil : System.Web.UI.Page
    {
        Controladora.SEGURIDAD.ControladoraGrupos ctrlGrupos = new Controladora.SEGURIDAD.ControladoraGrupos();
        Controladora.SEGURIDAD.ControladoraPerfiles ctrlPerfil = new Controladora.SEGURIDAD.ControladoraPerfiles();
        Controladora.SEGURIDAD.ControladoraPermisos ctrlPermisos = new Controladora.SEGURIDAD.ControladoraPermisos();
        Controladora.SEGURIDAD.ControladoraFormularios ctrlFormularios = new Controladora.SEGURIDAD.ControladoraFormularios();
        Controladora.SEGURIDAD.ControladoraPerfiles ctrlPerfiles = new Controladora.SEGURIDAD.ControladoraPerfiles();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!ctrlPerfiles.ObtenerFormularios(HttpContext.Current.User.Identity.Name).Exists(a => a == "Administracion"))
                Response.Redirect("~/NoAutorizado.aspx");

            if (!IsPostBack)
            {
                int perfilId = Convert.ToInt32(Request.QueryString["PerfilId"]);

                Modelo.SEGURIDAD.Perfil oPerfil = ctrlPerfil.ObtenerPerfil(perfilId);
                try
                {
                    this.DlGrupo.SelectedValue = oPerfil.IDgrupo;
                    this.DlFormulario.SelectedValue = oPerfil.IDformulario;
                    this.DlPermiso.SelectedValue = oPerfil.IDpermiso;
                    this.IDperfil.Value = oPerfil.IDPerfil.ToString();

                }
                catch (NullReferenceException ex)
                {
                    Response.Redirect("../View/Error.aspx?error=" + ex.Message);

                }
            }

        }

        protected void aceptar_Click(object sender, EventArgs e)
        {

            Modelo.SEGURIDAD.Perfil oPerfil = ctrlPerfil.ObtenerPerfil(Convert.ToInt32(this.IDperfil.Value));

            oPerfil.Grupo = ctrlGrupos.ObtenerGrupo(this.DlGrupo.SelectedValue);
            oPerfil.Formulario = ctrlFormularios.ObtenerFormulario(this.DlFormulario.SelectedValue);
            oPerfil.Permiso = ctrlPermisos.ObtenerPermiso(this.DlPermiso.SelectedValue);

             ctrlPerfil.ModificarPerfil(oPerfil);

            Response.Redirect("Perfiles.aspx");
        }

    }
}