using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista.Seguridad
{
    public partial class EditarUsuario : System.Web.UI.Page
    {
        Controladora.SEGURIDAD.ControladoraGrupos ctrlGrupos = new Controladora.SEGURIDAD.ControladoraGrupos();
        Controladora.SEGURIDAD.ControladoraUsuarios ctrlUsuarios = new Controladora.SEGURIDAD.ControladoraUsuarios();


        Controladora.SEGURIDAD.ControladoraPerfiles ctrlPerfiles = new Controladora.SEGURIDAD.ControladoraPerfiles();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!ctrlPerfiles.ObtenerFormularios(HttpContext.Current.User.Identity.Name).Exists(a => a == "Administracion"))
                Response.Redirect("~/NoAutorizado.aspx");

            if (!IsPostBack)
            {
                string usuarioID = Request.QueryString["UsuarioId"];

                Modelo.SEGURIDAD.Usuario oUsuario = ctrlUsuarios.BuscarUsuario(usuarioID);
                try
                {
                    this.usuario.Text = oUsuario.IDUsuario;
                    this.nombreyapellido.Text = oUsuario.NombreApellido;
                    this.email.Value = oUsuario.Email;
                    this.habilitado.Checked = oUsuario.Habilitado;
                    
                    foreach (Modelo.SEGURIDAD.Grupo i in ctrlGrupos.ListarGrupos())
                    {
                        ListItem item = new ListItem();
                        item.Text = i.IDGrupo.ToString();
                        item.Value = i.IDGrupo.ToString();

                        foreach (Modelo.SEGURIDAD.Grupo miGrupo in oUsuario.Grupo)
                        {
                            if (miGrupo.IDGrupo == item.Value)
                                item.Selected = true;

                            this.LbGrupos.Items.Add(item);

                        }
                    }
                    
                    


                }
                catch (NullReferenceException ex)
                {
                    Response.Redirect("../View/Error.aspx?error=" + ex.Message);

                }
            }

        }


        protected void aceptar_Click(object sender, EventArgs e)
        {

            if (!ValidarCheckboxListGrupos())
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Debe seleccionar al menos un Grupo');", true);
                LbGrupos.Focus();
                return;
            }


            Modelo.SEGURIDAD.Usuario oUsuario = ctrlUsuarios.BuscarUsuario(usuario.Text);

            oUsuario.NombreApellido = nombreyapellido.Text;
            oUsuario.Email = email.Value;
            oUsuario.Habilitado = habilitado.Checked;

            oUsuario.Grupo.Clear();

            foreach (ListItem item in LbGrupos.Items)
            {
                if (item.Selected)
                    oUsuario.Grupo.Add(ctrlGrupos.ObtenerGrupo(item.Value));
            }

                ctrlUsuarios.ModificarUsuario(oUsuario);
                Response.Redirect("Usuarios.aspx");
 
        }


        protected bool ValidarCheckboxListGrupos()
        {
            bool tieneGrupo = false;
            foreach (ListItem item in LbGrupos.Items)
            {
                if (item.Selected)
                    tieneGrupo = true;
            }
            return tieneGrupo;
        }
    }
}