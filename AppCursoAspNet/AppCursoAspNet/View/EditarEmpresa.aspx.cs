using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controladora;

namespace Vista.View
{
    public partial class EditarEmpresa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            long cuit = Convert.ToInt64(Request.QueryString["empresaId"]);

            Modelo.Empresa oEmpresa = ControladoraEmpresas.getINSTANCIA.ObtenerEmpresa(cuit);
            try
            {
                this.Cuit.Text = oEmpresa.Cuit.ToString();
                this.razonSocial.Text = oEmpresa.RazonSocial;
                this.Domicilio.Text = oEmpresa.Domicilio;
                this.Localidad.Text = oEmpresa.Localidad;
                this.email.Value = oEmpresa.Correo.ToString();
                this.Telefono.Text = oEmpresa.Telefono;

            }
            catch (NullReferenceException ex)
            {
                Response.Redirect("Error.aspx?error=" + ex.Message);

            }
        }

        protected void aceptar_Click(object sender, EventArgs e)
        {
            Modelo.Empresa oEmpresa = ControladoraEmpresas.getINSTANCIA.ObtenerEmpresa(Convert.ToInt64(this.Cuit.Text));

            oEmpresa.RazonSocial = this.razonSocial.Text;
            oEmpresa.Localidad = this.Localidad.Text;
            oEmpresa.Domicilio = this.Domicilio.Text;
            oEmpresa.Correo = Convert.ToString(this.email.Value);
            oEmpresa.Telefono = this.Telefono.Text;


            ControladoraEmpresas.getINSTANCIA.ModificarEmpresa(oEmpresa);
            Response.Redirect("Empresas.aspx");
        }
    }
}