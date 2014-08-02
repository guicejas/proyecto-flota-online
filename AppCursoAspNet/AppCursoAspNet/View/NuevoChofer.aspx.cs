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
        protected void Page_Load(object sender, EventArgs e)
        {

        }


       

        protected void aceptar_Click(object sender, EventArgs e)
        {
            Modelo.Chofer oChofer = new Modelo.Chofer();

            oChofer.Documento = 32448;
            oChofer.Nombre = "nombre";
            oChofer.Apellido = "apellido";
            oChofer.Domicilio ="diew";
            oChofer.Localidad = "localidad";
            oChofer.Licencia = "licencia";
            oChofer.FechaNacimiento = Convert.ToDateTime("11/11/1988");
            oChofer.Correo = "aalfjf.com";
            oChofer.Telefono = "s";
           /* try
            {
                Foto.SaveAs(Server.MapPath("~/Images/") + Foto.FileName);
                lblinformacion.Text = "El archivo " + Foto.FileName + " ha sido subido correctamente";
            }
            catch
            {
                lblinformacion.Text = "Ha ocurrido un error al intentar subir el archivo al servidor";
            }
            */
            oChofer.Foto = "foto";

            /*oChofer.Documento = Convert.ToInt32(this.Documento.Text);
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
                Foto.SaveAs(Server.MapPath("~/Images/") + Foto.FileName);
                lblinformacion.Text = "El archivo " + Foto.FileName + " ha sido subido correctamente";
            }
            catch
            {
                lblinformacion.Text = "Ha ocurrido un error al intentar subir el archivo al servidor";
            }

            oChofer.Foto = "~/Images/";*/
                //+ Foto.FileName;



            if (ControladoraChoferes.getINSTANCIA.VerificarChofer(oChofer))
                {
                    ControladoraChoferes.getINSTANCIA.AgregarChofer(oChofer);
                    Response.Redirect("Vehiculos.aspx");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('El DNI ingresado pertenece a un chofer existente');", true);

                }           

        }

       
    }
}