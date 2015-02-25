using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controladora;
using Controladora.AUDITORIA;

namespace Vista.View
{
    public partial class Vehiculos : System.Web.UI.Page
    {
        Controladora.SEGURIDAD.ControladoraPerfiles ctrlPerfiles = new Controladora.SEGURIDAD.ControladoraPerfiles();
        Controladora.SEGURIDAD.ControladoraFlotas ctrlFlotas = new Controladora.SEGURIDAD.ControladoraFlotas();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ctrlPerfiles.ObtenerFormularios(HttpContext.Current.User.Identity.Name).Exists(a => a == "Vehiculos"))
            {
                if (!IsPostBack)
                {
                    List<string> permisos = ctrlPerfiles.ObtenerPermisos(HttpContext.Current.User.Identity.Name, "Vehiculos");

                    if (permisos.Exists(a => a == "TOTAL"))
                    { return; }
                    else
                    {
                        if (!permisos.Exists(a => a == "ALTA"))
                            HyperLink1.Visible = false;
                        if (!permisos.Exists(a => a == "BAJA"))
                            listaVehiculos.Columns.RemoveAt(8);
                        if (!permisos.Exists(a => a == "MODIFICACION"))
                            listaVehiculos.Columns.RemoveAt(7);
                    }
                }
            }
            else
                Response.Redirect("~/NoAutorizado.aspx");

        }


        public List<Modelo.Vehiculo> GetVehiculos()
        {
            return ControladoraVehiculos.getINSTANCIA.ListarVehiculos(ctrlFlotas.ObtenerFlotadeUsuario(this.Context.User.Identity.Name).Id.ToString());
        }

        protected void listaVehiculos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String nroPatente = this.listaVehiculos.Rows[e.RowIndex].Cells[0].Text;
            //ControladoraAudGastos.getINSTANCIA.AuditarGastosBAJA(ControladoraGastos.getINSTANCIA.ObtenerGasto(gastoId));
            
            if (ControladoraVehiculos.getINSTANCIA.EliminarVehiculo(nroPatente))
            {
                lblModalTitle.Text = "CUIDADO";
                lblModalBody.Text = "el registro no puede ser eliminado ya que contiene datos asociados.";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                upModal.Update();
            }
            e.Cancel = true;
            this.listaVehiculos.DataSource = null;
        }

        protected void listaVehiculos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string nroPatente = this.listaVehiculos.Rows[e.NewEditIndex].Cells[0].Text;
            Response.Redirect("EditarVehiculo?Patente=" + nroPatente);
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (txtFiltroPatente.Text != "" || txtFiltroPatenteTaxi.Text != "" || txtFiltroAño.Text != "")
            { listaVehiculos.SelectMethod = "GetVehiculosFilter"; }

        }


        protected void btnReestablecer_Click(object sender, EventArgs e)
        {
            txtFiltroPatente.Text = "";
            txtFiltroPatenteTaxi.Text = "";
            txtFiltroAño.Text = "";
            listaVehiculos.SelectMethod = "GetVehiculosFilter";
        }

        public List<Modelo.Vehiculo> GetVehiculosFilter()
        {
            string patente = null;
            string patenteTaxi = null;
            string año = null;

            if (txtFiltroPatente.Text != "")
            {
                patente = txtFiltroPatente.Text;
            }

            if (txtFiltroPatenteTaxi.Text != "")
            {
                patenteTaxi = txtFiltroPatenteTaxi.Text;
            }

            if (txtFiltroAño.Text != "")
            {
                año = txtFiltroAño.Text;
            }

            return ControladoraVehiculos.getINSTANCIA.ListarVehiculosFiltrados(ctrlFlotas.ObtenerFlotadeUsuario(this.Context.User.Identity.Name).Id.ToString(), patente, patenteTaxi, año);
        }
    }
}