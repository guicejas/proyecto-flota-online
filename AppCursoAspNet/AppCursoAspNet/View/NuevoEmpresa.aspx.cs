using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controladora;

namespace Vista.View
{
    public partial class NuevoEmpresa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void CuitValidate(object source, ServerValidateEventArgs args)
        {
            this.RangeValidatorCuil.MaximumValue = Int64.MaxValue.ToString();
        }
        protected void aceptar_Click(object sender, EventArgs e)
        {


            Modelo.Empresa oEmpresa = new Modelo.Empresa();

            oEmpresa.Cuit = Convert.ToInt64(this.Cuit.Text);
            oEmpresa.RazonSocial = this.razonSocial.Text;
            oEmpresa.Domicilio = this.Domicilio.Text;
            oEmpresa.Localidad = this.Localidad.Text;
            oEmpresa.Correo = Convert.ToString(this.email.Value);
            oEmpresa.Telefono = this.Telefono.Text;

            if (ControladoraEmpresas.getINSTANCIA.VerificarEmpresa(oEmpresa))
            {
                ControladoraEmpresas.getINSTANCIA.AgregarEmpresa(oEmpresa);
                Response.Redirect("Empresas.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('El Cuit ingresado pertenece a una empresa existente');", true);
            }

            Response.Redirect("Gastos.aspx");
        }
    }
}