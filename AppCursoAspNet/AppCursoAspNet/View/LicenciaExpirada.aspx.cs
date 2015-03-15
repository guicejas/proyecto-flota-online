using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista.View
{
    public partial class LicenciaExpirada : System.Web.UI.Page
    {
          Controladora.SEGURIDAD.ControladoraPerfiles ctrlPerfiles = new Controladora.SEGURIDAD.ControladoraPerfiles();
        Controladora.SEGURIDAD.ControladoraFlotas ctrlFlotas = new Controladora.SEGURIDAD.ControladoraFlotas();
        Controladora.SEGURIDAD.ControladoraTiposdeLicencia ctrlTiposdeLicencia = new Controladora.SEGURIDAD.ControladoraTiposdeLicencia();
        Controladora.SEGURIDAD.ControladoraLicencias ctrlLicencias = new Controladora.SEGURIDAD.ControladoraLicencias();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.Context.User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");

            }

            flotaUser.Text = ctrlFlotas.ObtenerFlotadeUsuario(HttpContext.Current.User.Identity.Name).RazonSocial;

            mensaje.Visible = false;
            if (Request.QueryString["msj"] != null)
            {
                mensaje.Visible = true;
                mensaje.Attributes.Add("class", "alert alert-dismissable alert-info");
                mensajeTexto.InnerHtml = Request.QueryString["msj"];
            }
            
            Modelo.SEGURIDAD.Licencia oLicencia = ctrlLicencias.ObtenerLicenciadeUsuario(HttpContext.Current.User.Identity.Name);

            spanTipo.InnerText = oLicencia.TipoLicencia.tipo;
            spanDescripcion.InnerText = oLicencia.TipoLicencia.Descripcion;
            spanFechaCompra.InnerText = oLicencia.FechaInicio.ToShortDateString();
            spanFechaFin.InnerText = oLicencia.FechaFin.ToShortDateString();
            spanEstado.InnerText = oLicencia.Estado;

                listaTiposdeLicenciaBasica.Visible = true;
                listaTiposdeLicenciaPremium.Visible = true;

            if (oLicencia.TipoLicencia.tipo == "Premium")
            {
                Modelo.SEGURIDAD.Premium oTipoLicenciaPremium = ctrlTiposdeLicencia.ObtenerTipoLicenciaPremium(oLicencia.TipoLicencia.Id.ToString());

                spanUsuariosAdicionales.InnerText = oTipoLicenciaPremium.CantUsuarios.ToString();
            }



        }
        public IList<Modelo.SEGURIDAD.TipoLicencia> ListarTiposdeLicenciaBasica()
        {
            return ctrlTiposdeLicencia.ListarTiposdeLicenciaBasica();
        }

        public IList<Modelo.SEGURIDAD.TipoLicencia> ListarTiposdeLicenciaPremium()
        {
            return ctrlTiposdeLicencia.ListarTiposdeLicenciaPremium();
        }

        }
    }
