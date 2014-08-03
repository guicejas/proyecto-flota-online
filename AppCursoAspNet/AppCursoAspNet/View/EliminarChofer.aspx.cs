using Vista.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controladora;

namespace Vista.View
{
    public partial class EliminarChofer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    int DNI = Convert.ToInt32(Request.QueryString["Documento"]);

                    ControladoraChoferes.getINSTANCIA.EliminarChofer(DNI);
                }
                catch (NullReferenceException ex)
                {
                    Response.Redirect("Error.aspx?error=" + ex.Message);

                }

            Response.Redirect("Choferes.aspx");
            }
        }
    }
}