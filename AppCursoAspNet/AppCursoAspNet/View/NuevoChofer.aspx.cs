using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controladora;

namespace Vista.View
{
    public partial class NuevoChofer : System.Web.UI.Page
    {
        Controladora.SEGURIDAD.ControladoraPerfiles ctrlPerfiles = new Controladora.SEGURIDAD.ControladoraPerfiles();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ctrlPerfiles.ObtenerFormularios(HttpContext.Current.User.Identity.Name).Exists(a => a == "Choferes"))
            {
                List<string> permisos = ctrlPerfiles.ObtenerPermisos(HttpContext.Current.User.Identity.Name, "Choferes");

                if (permisos.Exists(a => a == "TOTAL"))
                { return; }
                else
                {
                    if (!permisos.Exists(a => a == "ALTA"))
                        Response.Redirect("~/NoAutorizado.aspx"); ;
                }
            }
            else
                Response.Redirect("~/NoAutorizado.aspx");


        }

        protected void aceptar_Click(object sender, EventArgs e)
        {
            Modelo.Chofer oChofer = new Modelo.Chofer();

            //Usuario de prueba
            /*oChofer.Documento = 32448;
           oChofer.Nombre = "nombre";
           oChofer.Apellido = "apellido";
           oChofer.Domicilio ="diew";
           oChofer.Localidad = "localidad";
           oChofer.Licencia = "licencia";
           oChofer.FechaNacimiento = Convert.ToDateTime("11/11/1988");
           oChofer.Correo = "aalfjf.com";
           oChofer.Telefono = "s";
             oChofer.Foto = "~/Images/avatar_anonimo.jpg"*/

            oChofer.Documento = Convert.ToInt32(this.Documento.Text);
            oChofer.Nombre = this.Nombre.Text;
            oChofer.Apellido = this.Apellido.Text;
            oChofer.Domicilio = this.Domicilio.Text;
            oChofer.Localidad = this.Localidad.Text;
            oChofer.Licencia = this.Licencia.Text;
            oChofer.FechaNacimiento = Convert.ToDateTime(this.FechNac.Value);
            oChofer.Correo = Convert.ToString(this.email.Value);
            oChofer.Telefono = this.Telefono.Text;
            try
            {
                Foto.SaveAs(Server.MapPath("~/Images/") + oChofer.Documento.ToString() + (Foto.FileName.Substring(Foto.FileName.Length - 4)));
                lblinformacion.Text = "El archivo " + Foto.FileName + " ha sido subido correctamente";
            }
            catch
            {
                lblinformacion.Text = "Ha ocurrido un error al intentar subir el archivo al servidor";
            }

            if (Foto.HasFile)
            {
                oChofer.Foto = oChofer.Documento.ToString() + (Foto.FileName.Substring(Foto.FileName.Length - 4));
            }



            if (ControladoraChoferes.getINSTANCIA.VerificarChofer(oChofer))
            {
                ControladoraChoferes.getINSTANCIA.AgregarChofer(oChofer);
                Response.Redirect("Choferes.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('El DNI ingresado pertenece a un chofer existente');", true);
            }

        }

       
    }
}