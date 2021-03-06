﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista.Seguridad
{
    public partial class Perfiles : System.Web.UI.Page
    {
        Controladora.SEGURIDAD.ControladoraPerfiles ctrlPerfiles = new Controladora.SEGURIDAD.ControladoraPerfiles();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ctrlPerfiles.ObtenerFormularios(HttpContext.Current.User.Identity.Name).Exists(a => a == "Administracion"))
            {
                return;
            }
            //else
            //    Response.Redirect("~/NoAutorizado.aspx");


        }

        public List<Modelo.SEGURIDAD.Perfil> GetPerfiles()
        {
            return ctrlPerfiles.ListarPerfiles();
        }

        protected void listaPerfiles_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int perfilId = Convert.ToInt32(this.listaPerfiles.Rows[e.RowIndex].Cells[0].Text);
            ctrlPerfiles.EliminarPerfil(perfilId);
            e.Cancel = true;
            this.listaPerfiles.DataSource = null;
        }

        protected void listaPerfiles_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int perfilId = Convert.ToInt32(this.listaPerfiles.Rows[e.NewEditIndex].Cells[0].Text);
            Response.Redirect("EditarPerfil?PerfilId=" + perfilId);
        }
    }
}