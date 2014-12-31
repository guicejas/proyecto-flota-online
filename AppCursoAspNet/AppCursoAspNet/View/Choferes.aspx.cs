using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Controladora;

namespace Vista.View
{
    public partial class Choferes : System.Web.UI.Page
    {
        Controladora.SEGURIDAD.ControladoraPerfiles ctrlPerfiles = new Controladora.SEGURIDAD.ControladoraPerfiles();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (ctrlPerfiles.ObtenerFormularios(HttpContext.Current.User.Identity.Name).Exists(a => a == "Choferes"))
            {
                if (!IsPostBack)
                {
                    List<string> permisos = ctrlPerfiles.ObtenerPermisos(HttpContext.Current.User.Identity.Name, "Choferes");

                    if (permisos.Exists(a => a == "TOTAL"))
                    { return; }
                    else
                    {
                        if (!permisos.Exists(a => a == "ALTA"))
                            HyperLink1.Visible = false;
                        if (!permisos.Exists(a => a == "BAJA"))
                        {
                            Page.Header.Controls.Add(new System.Web.UI.LiteralControl("<style> .btnEliminar { display: none;} </style>"));
                        }
                        if (!permisos.Exists(a => a == "MODIFICACION"))
                            Page.Header.Controls.Add(new System.Web.UI.LiteralControl("<style> .btnEditar { display: none;} </style>"));
                    }
                }
            }
            else
                Response.Redirect("~/NoAutorizado.aspx");

        }
        public IList<Modelo.Chofer> ListChoferes_GetData()
        {

            return Controladora.ControladoraChoferes.getINSTANCIA.ListarChoferes();
        }



        //protected void btnFiltrar_Click(object sender, EventArgs e)
        //{
        //    if (txtFiltroDocumento.Text != "" || txtFiltroNombre.Text != "" || txtFiltroLocalidad.Text != "")
        //    { ObjectChofer.SelectMethod = "GetChoferesFilter"; }

        //}
        //protected void btnReestablecer_Click(object sender, EventArgs e)
        //{
        //    txtFiltroDocumento.Text = "";
        //    txtFiltroNombre.Text = "";
        //    txtFiltroLocalidad.Text = "";
        //    ObjectChofer.SelectMethod = "GetChoferesFilter";
        //}

        //public List<Modelo.Chofer> GetChoferesFilter()
        //{
        //    string documento = null;
        //    string nombre = null;
        //    string localidad = null;

        //    if (txtFiltroDocumento.Text != "")
        //    {
        //        documento = txtFiltroDocumento.Text;
        //    }

        //    if (txtFiltroNombre.Text != "")
        //    {
        //        nombre = txtFiltroNombre.Text;
        //    }

        //    if (txtFiltroLocalidad.Text != "")
        //    {
        //        localidad = txtFiltroLocalidad.Text;
        //    }

        //    return ControladoraChoferes.getINSTANCIA.ListarChoferesFiltrados(documento, nombre, localidad);
        //}

    }
}