using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using mercadopago;
using System.Collections;

namespace Vista.View
{
    public partial class Checkout : System.Web.UI.Page
    {
        Controladora.SEGURIDAD.ControladoraTiposdeLicencia ctrlTipoLicencia = new Controladora.SEGURIDAD.ControladoraTiposdeLicencia();
        Controladora.SEGURIDAD.ControladoraUsuarios ctrlUsuarios = new Controladora.SEGURIDAD.ControladoraUsuarios();
        Controladora.SEGURIDAD.ControladoraLicencias ctrlLicencias = new Controladora.SEGURIDAD.ControladoraLicencias();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string item = Request.QueryString["Item"];

                Modelo.SEGURIDAD.Usuario oUsuario = ctrlUsuarios.BuscarUsuario(HttpContext.Current.User.Identity.Name);
                Modelo.SEGURIDAD.TipoLicencia oTipoLicencia = ctrlTipoLicencia.ObtenerTipoLicencia(item);

                Modelo.SEGURIDAD.Licencia oLicencia = new Modelo.SEGURIDAD.Licencia();

                string precio = "0";
                string url = "";

                if (oTipoLicencia is Modelo.SEGURIDAD.Premium)
                { 
                    Modelo.SEGURIDAD.Premium oPremium = ctrlTipoLicencia.ObtenerTipoLicenciaPremium(item);
                    precio = oPremium.Precio.ToString();

                    Controladora.SEGURIDAD.Fachada.FachadaMercadoPagoPremium oFachadaP = new Controladora.SEGURIDAD.Fachada.FachadaMercadoPagoPremium(oTipoLicencia.Descripcion, precio, oUsuario.NombreApellido, oUsuario.Email, oTipoLicencia.Id.ToString());
                    url = oFachadaP.obtenerURL();
                }

                if (oTipoLicencia is Modelo.SEGURIDAD.Basica)
                {
                    Modelo.SEGURIDAD.Basica oBasica = ctrlTipoLicencia.ObtenerTipoLicenciaBasica(item);
                    precio = oBasica.Precio.ToString();

                    Controladora.SEGURIDAD.Fachada.FachadaMercadoPagoBasica oFachadaB = new Controladora.SEGURIDAD.Fachada.FachadaMercadoPagoBasica(oTipoLicencia.Descripcion, precio, oUsuario.NombreApellido, oUsuario.Email, oTipoLicencia.Id.ToString());
                    url = oFachadaB.obtenerURL();
                }

                //MP mp = new MP("919996648151981", "GjTCamDdthf23kl2F5MZrUUVL7hMfV6K");


                //string seteoItem = "{\"items\": [{\"id\": \"Código\",\"title\": \"" + oTipoLicencia.Descripcion + "\",\"currency_id\": \"ARS\",\"description\": \"" + oTipoLicencia.Descripcion + "\",\"quantity\": 1,\"unit_price\": " + precio + "}],  \"payer\": {\"name\": \"" + oUsuario.NombreApellido + "\",\"email\": \"" + oUsuario.Email + "\",},  \"auto_return\": \"approved\",\"back_urls\": {\"failure\": \"http://localhost:50196/View/FinCheckout?idtipo=" + oTipoLicencia.Id + "\",\"pending\": \"http://localhost:50196/View/FinCheckout?idtipo=" + oTipoLicencia.Id + "\",\"success\": \"http://localhost:50196/View/FinCheckout?idtipo=" + oTipoLicencia.Id + "\"}, \"external_reference\": \"" + oTipoLicencia.Id + "\", }";


                //Hashtable preference2 = mp.createPreference(seteoItem);

             
                //string url = (((Hashtable)preference2["response"])["sandbox_init_point"]).ToString();
                
            
                Response.Redirect(url);


                // Sets the filters you want
                //Dictionary<String, String> filters = new Dictionary<String, String>();
                //filters.Add("site_id", "MLA"); // Argentina: MLA; Brasil: MLB; Mexico: MLM; Venezuela: MLV; Colombia: MCO
                //filters.Add("external_reference", "Bill001");

                // Search payment data according to filters
                //Hashtable searchResult = mp.searchPayment(filters);

                //    foreach (Hashtable payment in searchResult. .SelectToken("response.results"))
                //    {
                //        Response.Write(payment["collection"]["id"]);
                //        Response.Write(payment["collection"]["status"]);

                //    }
            }
        }
    }
}



//                Hashtable preference2 = mp.createPreference(@"{
//
//""items"": [
//		{
//			""id"": ""Código"",
//			""title"": ""Título de lo que estás pagando"",
//			""currency_id"": ""ARS"",
//			""picture_url"": ""https://www.mercadopago.com/org-img/MP3/home/logomp3.gif"",
//			""description"": ""Descripción"",
//			""category_id"": ""Categoría"",
//			""quantity"": 1,
//			""unit_price"": 100
//		}
//	],
//
//	""payer"": {
//		""name"": ""user-name"",
//		""surname"": ""user-surname"",
//		""email"": ""user@email.com"",
//		""date_created"": ""2015-03-15T15:24:04.883-04:00"",
//		""phone"": {
//			""area_code"": ""11"",
//			""number"": ""4444-4444""
//		},
//		""identification"": {
//			""type"": ""DNI"",
//			""number"": ""12345678""
//		},
//		""address"": {
//			""street_name"": ""Street"",
//			""street_number"": 123,
//			""zip_code"": ""1430""
//		} 
//	},
//
// ""auto_return"": ""approved"",
// ""back_urls"": {
// ""failure"": ""https://www.failure.com"",
// ""pending"": ""https://www.pending.com"",
// ""success"": ""https://www.success.com""
//},
//""external_reference"": ""Reference_1234"",
//
//}");