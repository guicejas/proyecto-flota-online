using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista.View
{
    public partial class FinCheckout : System.Web.UI.Page
    {
        Controladora.SEGURIDAD.ControladoraTiposdeLicencia ctrlTiposLicencia = new Controladora.SEGURIDAD.ControladoraTiposdeLicencia();
        Controladora.SEGURIDAD.ControladoraUsuarios ctrlUsuarios = new Controladora.SEGURIDAD.ControladoraUsuarios();
        Controladora.SEGURIDAD.ControladoraLicencias ctrlLicencias = new Controladora.SEGURIDAD.ControladoraLicencias();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Modelo.SEGURIDAD.Usuario oUsuario = ctrlUsuarios.BuscarUsuario(HttpContext.Current.User.Identity.Name);

                if (Request.QueryString["collection_status"] == "approved")
                {
                    string item = Request.QueryString["idtipo"];
                    Modelo.SEGURIDAD.TipoLicencia oTipoLicencia = ctrlTiposLicencia.ObtenerTipoLicencia(item);

                    Modelo.SEGURIDAD.Licencia oLicencia = new Modelo.SEGURIDAD.Licencia();
                    oLicencia.TipoLicencia = oTipoLicencia;
                    oLicencia.FechaInicio = DateTime.Now;
                    oLicencia.FechaFin = oLicencia.FechaInicio.AddDays(Convert.ToDouble(oLicencia.TipoLicencia.Duracion));
                    oLicencia.FechaPago = DateTime.Now;
                    oLicencia.Estado = "Aceptada";
                    oLicencia.NroTransaccion = Request.QueryString["collection_id"];

                    oUsuario.Flota.Licencia.Add(oLicencia);

                    ctrlUsuarios.ModificarUsuario(oUsuario);

                    Response.Redirect("~/Seguridad/LicenciaFlota?msj=El pago de su nueva licencia " + oTipoLicencia.Descripcion + " ha sido ingresadoo correctamente. Disfrute de su nueva licencia.");

                }

                if (Request.QueryString["collection_status"] == "pending" || Request.QueryString["collection_status"] == "in_process")
                {
                    string item = Request.QueryString["idtipo"];
                    Modelo.SEGURIDAD.TipoLicencia oTipoLicencia = ctrlTiposLicencia.ObtenerTipoLicencia(item);

                    Modelo.SEGURIDAD.Licencia oLicencia = new Modelo.SEGURIDAD.Licencia();
                    oLicencia.TipoLicencia = oTipoLicencia;
                    oLicencia.FechaInicio = DateTime.Now;
                    oLicencia.FechaFin = oLicencia.FechaInicio.AddDays(Convert.ToDouble(oLicencia.TipoLicencia.Duracion));
                    oLicencia.Estado = "Pendiente Confirmacion";
                    oLicencia.NroTransaccion = Request.QueryString["collection_id"];

                    oUsuario.Flota.Licencia.Add(oLicencia);

                    ctrlUsuarios.ModificarUsuario(oUsuario);

                    Response.Redirect("~/Seguridad/LicenciaFlota?msj=El pago de su nueva licencia "+oTipoLicencia.Descripcion+" esta pendiente, si el pago no se efectua en los proximos 2 dias su licencia sera revocada.");

                }

                if (Request.QueryString["collection_status"] == "null")
                {
                    Response.Redirect("~/Seguridad/LicenciaFlota");

                }

                if (Request.QueryString["collection_status"] == "rejected")
                {
                    string item = Request.QueryString["idtipo"];
                    Modelo.SEGURIDAD.TipoLicencia oTipoLicencia = ctrlTiposLicencia.ObtenerTipoLicencia(item);


                    Response.Redirect("~/Seguridad/LicenciaFlota?msj=El pago de su nueva licencia " + oTipoLicencia.Descripcion + " ha sido rechazado, por favor intente con otro medio de pago.");

                }
            }
                    






        }
    }
}