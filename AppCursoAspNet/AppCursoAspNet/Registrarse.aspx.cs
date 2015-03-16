using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista
{
    public partial class Registrarse : System.Web.UI.Page
    {
        Controladora.SEGURIDAD.ControladoraGrupos ctrlGrupos = new Controladora.SEGURIDAD.ControladoraGrupos();
        Controladora.SEGURIDAD.ControladoraUsuarios ctrlUsuarios = new Controladora.SEGURIDAD.ControladoraUsuarios();
        Controladora.SEGURIDAD.ControladoraFlotas ctrlFlotas = new Controladora.SEGURIDAD.ControladoraFlotas();
        Controladora.SEGURIDAD.ControladoraTiposdeLicencia ctrlTiposLicencia = new Controladora.SEGURIDAD.ControladoraTiposdeLicencia();
        Controladora.SEGURIDAD.ControladoraLicencias ctrlLicencias = new Controladora.SEGURIDAD.ControladoraLicencias();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void aceptar_Click(object sender, EventArgs e)
        {
            Modelo.SEGURIDAD.Flota oFlota = new Modelo.SEGURIDAD.Flota();
            oFlota.RazonSocial = flota.Text;
                        
            Modelo.SEGURIDAD.Licencia oLicencia = new Modelo.SEGURIDAD.Licencia();
            oLicencia.TipoLicencia = ctrlTiposLicencia.ObtenerTipoLicencia(DlLicencia.SelectedValue);
            oLicencia.FechaInicio = DateTime.Now;
            oLicencia.FechaFin = oLicencia.FechaInicio.AddDays(Convert.ToDouble(oLicencia.TipoLicencia.Duracion));
            oLicencia.Estado = "Aceptada";

            oFlota.Licencia.Add(oLicencia);
            
            Modelo.SEGURIDAD.Usuario oUsuario = new Modelo.SEGURIDAD.Usuario();
            oUsuario.IDUsuario = usuario.Text;
            oUsuario.NombreApellido = nombreyapellido.Text;
            oUsuario.Email = email.Value;
            oUsuario.Habilitado = true;
            oUsuario.Contraseña = "newuser";
            oUsuario.PrimeraVez = true;
            oUsuario.Flota = oFlota;
            oUsuario.Grupo.Add(ctrlGrupos.ObtenerGrupo("Propietario"));


            if (ctrlUsuarios.VerificarUsuario(oUsuario))
            {
                //ctrlFlotas.AgregarFlota(oFlota);
                //ctrlLicencias.AgregarLicencia(oLicencia);
                ctrlUsuarios.AgregarUsuario(oUsuario);
                string mensaje = ctrlUsuarios.CambiarContraseña(oUsuario); // DESCOMENTAR EN PRODUCCION
                Response.Redirect("Login.aspx?msj=" + mensaje);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('El nombre de usuario ingresado ya pertenece a un usuario existente');", true);
                return;

            }

        }

        public IList<Modelo.SEGURIDAD.TipoLicencia> ListarTiposLicenciaDemo()
        {
            return ctrlTiposLicencia.ListarTiposdeLicenciaDemo();
        }

    }
}