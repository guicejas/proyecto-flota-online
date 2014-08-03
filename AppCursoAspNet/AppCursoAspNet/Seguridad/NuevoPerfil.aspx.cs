using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista.Seguridad
{
    public partial class NuevoPerfil : System.Web.UI.Page
    {
        Controladora.SEGURIDAD.ControladoraGrupos ctrlGrupos = new Controladora.SEGURIDAD.ControladoraGrupos();
        Controladora.SEGURIDAD.ControladoraPerfiles ctrlPerfiles = new Controladora.SEGURIDAD.ControladoraPerfiles();
        Controladora.SEGURIDAD.ControladoraPermisos ctrlPermisos = new Controladora.SEGURIDAD.ControladoraPermisos();
        Controladora.SEGURIDAD.ControladoraFormularios ctrlFormularios = new Controladora.SEGURIDAD.ControladoraFormularios();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void aceptar_Click(object sender, EventArgs e)
        {


            Modelo.SEGURIDAD.Perfil oPerfil = new Modelo.SEGURIDAD.Perfil();

            oPerfil.Grupo = ctrlGrupos.ObtenerGrupo(this.DlGrupo.SelectedValue);
            oPerfil.Formulario = ctrlFormularios.ObtenerFormulario(this.DlFormulario.SelectedValue);
            oPerfil.Permiso = ctrlPermisos.ObtenerPermiso(this.DlPermiso.SelectedValue);

            ctrlPerfiles.AgregarPerfil(oPerfil);
            Response.Redirect("Perfiles.aspx");

        }

    }
}