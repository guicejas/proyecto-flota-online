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
        

        protected void Page_Load(object sender, EventArgs e)
        {
            MP mp = new MP("919996648151981", "GjTCamDdthf23kl2F5MZrUUVL7hMfV6K");

            String accessToken = mp.getAccessToken();

            Response.Write(accessToken);

            Hashtable preference = mp.createPreference("{\"items\":[{\"title\":\"DEMO\",\"quantity\":1,\"currency_id\":\"ARS\",\"unit_price\":3900}]}");

            Response.Write(preference);


            // Sets the filters you want
            Dictionary<String, String> filters = new Dictionary<String, String>();
            filters.Add("site_id", "MLA"); // Argentina: MLA; Brasil: MLB; Mexico: MLM; Venezuela: MLV; Colombia: MCO
            filters.Add("external_reference", "Bill001");

            // Search payment data according to filters
            Hashtable searchResult = mp.searchPayment(filters);

        //    foreach (Hashtable payment in searchResult. .SelectToken("response.results"))
        //    {
        //        Response.Write(payment["collection"]["id"]);
        //        Response.Write(payment["collection"]["status"]);
        //    }
        }
    }
}