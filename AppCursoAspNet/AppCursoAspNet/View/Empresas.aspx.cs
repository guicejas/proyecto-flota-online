using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controladora;

namespace Vista
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
        protected void listaEmpresas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int empresaId = Convert.ToInt32(this.listaEmpresas.Rows[e.RowIndex].Cells[0].Text);
            ControladoraGastos.getINSTANCIA.EliminarGasto(empresaId);
            e.Cancel = true;
            this.listaEmpresas.DataSource = null;
        }
    }
}