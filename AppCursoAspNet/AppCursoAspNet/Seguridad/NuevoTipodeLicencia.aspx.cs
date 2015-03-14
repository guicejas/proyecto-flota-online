using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista.Seguridad
{
    public partial class NuevoTipodeLicencia : System.Web.UI.Page
    {
        Controladora.SEGURIDAD.ControladoraTiposdeLicencia ctrlTiposdeLicencia = new Controladora.SEGURIDAD.ControladoraTiposdeLicencia();
        Controladora.SEGURIDAD.ControladoraPerfiles ctrlPerfiles = new Controladora.SEGURIDAD.ControladoraPerfiles();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!ctrlPerfiles.ObtenerFormularios(HttpContext.Current.User.Identity.Name).Exists(a => a == "Administracion"))
                Response.Redirect("~/NoAutorizado.aspx");

        }

        protected void aceptar_Click(object sender, EventArgs e)
        {

            if (this.RadButDemo.Checked)
            {
                Modelo.SEGURIDAD.Demo oLicencia = new Modelo.SEGURIDAD.Demo();
                oLicencia.Descripcion = descripcion.Text;
                oLicencia.Duracion = Convert.ToInt32(duracion.Text);
                oLicencia.Activo = Convert.ToInt16(activo.Checked);

                ctrlTiposdeLicencia.AgregarTipoLicencia(oLicencia);
            }

            if (this.RadButBasica.Checked)
            {
                Modelo.SEGURIDAD.Basica oLicencia = new Modelo.SEGURIDAD.Basica();
                oLicencia.Patrocinador = txtPatrocinador.Value;
                oLicencia.Descripcion = descripcion.Text;
                oLicencia.Duracion = Convert.ToInt32(duracion.Text);
                oLicencia.Activo = Convert.ToInt16(activo.Checked);
                oLicencia.Precio = Convert.ToDecimal(txtPrecio.Value);

                ctrlTiposdeLicencia.AgregarTipoLicencia(oLicencia);
            }

            if (this.RadButPremium.Checked)
            {
                Modelo.SEGURIDAD.Premium oLicencia = new Modelo.SEGURIDAD.Premium();
                oLicencia.CantUsuarios = Convert.ToInt32(txtCantUsuarios.Value);
                oLicencia.Descripcion = descripcion.Text;
                oLicencia.Duracion = Convert.ToInt32(duracion.Text);
                oLicencia.Activo = Convert.ToInt16(activo.Checked);
                oLicencia.Precio = Convert.ToDecimal(txtPrecio.Value);

                ctrlTiposdeLicencia.AgregarTipoLicencia(oLicencia);
            }

            Response.Redirect("TiposdeLicencia.aspx");
            

            
        }

        protected void RadButDemo_CheckedChanged(object sender, EventArgs e)
        {
            if (this.RadButDemo.Checked)
            {
                this.boxPatrocinador.Visible = false;
                this.boxCantUsuarios.Visible = false;
                this.boxPrecio.Visible = false;
            }

        }

        protected void RadButBasica_CheckedChanged(object sender, EventArgs e)
        {
            if (this.RadButBasica.Checked)
            {
                this.boxPatrocinador.Visible = true;
                this.boxCantUsuarios.Visible = false;
                this.boxPrecio.Visible = true;
            }

        }

        protected void RadButPremium_CheckedChanged(object sender, EventArgs e)
        {
            if (this.RadButPremium.Checked)
            {
                this.boxPatrocinador.Visible = false;
                this.boxCantUsuarios.Visible = true;
                this.boxPrecio.Visible = true;
            }
        }

    }
}