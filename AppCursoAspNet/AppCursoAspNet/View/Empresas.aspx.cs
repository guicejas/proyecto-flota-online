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
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public List<Modelo.Empresa> GetEmpresas()
        {
            return ControladoraEmpresas.getINSTANCIA.ListarEmpresas();
        }
        protected void listaEmprsas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int empresaId = Convert.ToInt32(this.listaEmpresas.Rows[e.RowIndex].Cells[0].Text);
            ControladoraEmpresas.getINSTANCIA.EliminarEmpresa(empresaId);
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
            return ControladoraEmpresas.getINSTANCIA.ListarEmpresasFiltrados(cuit, razonSocial, localidad, correo);
        }
    }
}