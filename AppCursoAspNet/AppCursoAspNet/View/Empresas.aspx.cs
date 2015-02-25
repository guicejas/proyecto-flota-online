using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controladora;

namespace Vista.View
{
    public partial class Empresas : System.Web.UI.Page
    {
        Controladora.SEGURIDAD.ControladoraPerfiles ctrlPerfiles = new Controladora.SEGURIDAD.ControladoraPerfiles();
        Controladora.SEGURIDAD.ControladoraFlotas ctrlFlotas = new Controladora.SEGURIDAD.ControladoraFlotas();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ctrlPerfiles.ObtenerFormularios(HttpContext.Current.User.Identity.Name).Exists(a => a == "Empresas"))
            {
                List<string> permisos = ctrlPerfiles.ObtenerPermisos(HttpContext.Current.User.Identity.Name, "Empresas");

                if (permisos.Exists(a => a == "TOTAL"))
                { return; }
                else
                {
                    if (!permisos.Exists(a => a == "ALTA"))
                        HyperLink1.Visible = false;
                    if (!permisos.Exists(a => a == "BAJA"))
                       listaEmpresas.Columns.RemoveAt(7);
                    if (!permisos.Exists(a => a == "MODIFICACION"))
                        listaEmpresas.Columns.RemoveAt(6);
                }
            }
            else
                Response.Redirect("~/NoAutorizado.aspx");
        }
        public List<Modelo.Empresa> GetEmpresas()
        {
            return ControladoraEmpresas.getINSTANCIA.ListarEmpresas(ctrlFlotas.ObtenerFlotadeUsuario(this.Context.User.Identity.Name).Id.ToString());
        }
        protected void listaEmprsas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            long empresaId = Convert.ToInt64(this.listaEmpresas.Rows[e.RowIndex].Cells[0].Text);
            if(ControladoraEmpresas.getINSTANCIA.EliminarEmpresa(empresaId))
            {
                lblModalTitle.Text = "CUIDADO";
                lblModalBody.Text = "La empresa no puede ser eliminada ya que contiene datos asociados.";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                upModal.Update();
            }

            e.Cancel = true;
            this.listaEmpresas.DataSource = null;
        }
        protected void listaEmpresas_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string empresaId = this.listaEmpresas.Rows[e.NewEditIndex].Cells[0].Text;
            Response.Redirect("EditarEmpresa?empresaId=" + empresaId);
        }
        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (txtFiltroCuit.Text != "" || txtFiltroRazonSocial.Text != "" || txtFiltroLocalidad.Text != "" || txtFiltroCorreo.Text != "")
            { listaEmpresas.SelectMethod = "GetEmpresasFilter"; }

        }
        protected void btnReestablecer_Click(object sender, EventArgs e)
        {
            txtFiltroCuit.Text = "";
            txtFiltroRazonSocial.Text = "";
            txtFiltroLocalidad.Text = "";
            txtFiltroCorreo.Text = "";
            listaEmpresas.SelectMethod = "GetEmpresasFilter";
        }

        public List<Modelo.Empresa> GetEmpresasFilter()
        {
            string cuit = null;            
            string razonSocial = null;
            string localidad = null;
            string correo = null;

            if (txtFiltroCuit.Text != "")
            {
                cuit = txtFiltroCuit.Text;
            }

            if (txtFiltroRazonSocial.Text != "")
            {
                razonSocial = txtFiltroRazonSocial.Text;
            }

            if (txtFiltroLocalidad.Text != "")
            {
                localidad = txtFiltroLocalidad.Text;
            }

            if (txtFiltroCorreo.Text != "")
            {
                correo = txtFiltroCorreo.Text;
            }
            return ControladoraEmpresas.getINSTANCIA.ListarEmpresasFiltrados(ctrlFlotas.ObtenerFlotadeUsuario(this.Context.User.Identity.Name).Id.ToString(), cuit, razonSocial, localidad, correo);
        }
    }
}