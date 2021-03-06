﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista.Seguridad
{
    public partial class Usuarios : System.Web.UI.Page
    {
        Controladora.SEGURIDAD.ControladoraUsuarios ctrlUsuarios = new Controladora.SEGURIDAD.ControladoraUsuarios();
        Controladora.SEGURIDAD.ControladoraPerfiles ctrlPerfiles = new Controladora.SEGURIDAD.ControladoraPerfiles();
        Controladora.SEGURIDAD.ControladoraFlotas ctrlFlotas = new Controladora.SEGURIDAD.ControladoraFlotas();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!ctrlPerfiles.ObtenerFormularios(HttpContext.Current.User.Identity.Name).Exists(a => a == "Administracion"))
                Response.Redirect("~/NoAutorizado.aspx");

            if (Request.QueryString["msj"] != null)
            {
                mensaje.Visible = true;
                mensajeTexto.InnerHtml = Request.QueryString["msj"];
            }
        }

        public List<Modelo.SEGURIDAD.Usuario> GetUsuarios()
        {
            return ctrlUsuarios.ListarUsuarios("0");
        }

        protected void listaUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string usuarioId = this.listaUsuarios.Rows[e.RowIndex].Cells[0].Text;
            if (usuarioId != this.Context.User.Identity.Name)
            {
                ctrlUsuarios.EliminarUsuario(usuarioId);
                e.Cancel = true;
                this.listaUsuarios.DataSource = null;
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('No puede eliminar su propio usuario');", true);
                e.Cancel = true;
            }

        }

        protected void listaUsuarios_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string usuarioId = this.listaUsuarios.Rows[e.NewEditIndex].Cells[0].Text;
            if (usuarioId != this.Context.User.Identity.Name)
            {
                Response.Redirect("EditarUsuario?UsuarioId=" + usuarioId);
            }
            else
            {
                Response.Redirect("../View/MiCuenta");
            }
        }

        protected void listaUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            string usuarioId = this.listaUsuarios.SelectedRow.Cells[0].Text;
            Response.Redirect("VerUsuario?UsuarioId=" + usuarioId);
        }

        
    }
}