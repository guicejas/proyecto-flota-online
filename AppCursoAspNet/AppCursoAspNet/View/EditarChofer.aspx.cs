using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controladora;

namespace Vista.View
{
    public partial class EditarChofer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int DNI = Convert.ToInt32(Request.QueryString["Documento"]);

                Modelo.Chofer oChofer = ControladoraChoferes.getINSTANCIA.ObtenerChofer(DNI);
                try
                {
                    this.Documento.Text = oChofer.Documento.ToString();
                    this.Nombre.Text = oChofer.Nombre;
                    this.Apellido.Text = oChofer.Apellido;
                    this.Domicilio.Text = oChofer.Domicilio;
                    this.Localidad.Text = oChofer.Localidad;
                    this.Licencia.Text = oChofer.Licencia;
                    //hay que pasar la fecha de formato dd/mm/aaa a dd-mm-aaaa para que lo tome el input
                    this.FechNac.Value = (oChofer.FechaNacimiento.ToString("yyyy-MM-dd"));
                    
                    this.email.Value = oChofer.Correo.ToString();
                    this.Telefono.Text = oChofer.Telefono;
                   

                }
                catch (NullReferenceException ex)
                {
                    Response.Redirect("Error.aspx?error=" + ex.Message);

                }
            }
        }
            protected void aceptar_Click(object sender, EventArgs e)
            {
                Modelo.Chofer oChofer = ControladoraChoferes.getINSTANCIA.ObtenerChofer(Convert.ToInt32(this.Documento.Text));
               
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
          
            
            ControladoraChoferes.getINSTANCIA.ModificarChofer(oChofer);
            Response.Redirect("Choferes.aspx");

            }
        }
    }
