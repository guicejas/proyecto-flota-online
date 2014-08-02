using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controladora;

namespace Vista.View
{
    public partial class EditarVehiculo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string patente = Request.QueryString["Patente"];

                Modelo.Vehiculo oVehiculo = ControladoraVehiculos.getINSTANCIA.ObtenerVehiculo(patente);
                try
                {
                    
                    this.Patente.Text = oVehiculo.Patente;
                    this.PatenteTaxi.Text = oVehiculo.PatenteTaxi.ToString();
                    this.Marca.Text = oVehiculo.Marca;
                    this.Modelo.Text = oVehiculo.Modelo;
                    this.Año.Text = oVehiculo.Año.ToString();
                    this.Color.Text = oVehiculo.Color;
                    this.Kilometraje.Text = oVehiculo.Kilometraje.ToString();

                }
                catch (NullReferenceException ex)
                {
                    Response.Redirect("Error.aspx?error=" + ex.Message);

                }
            }

        }
        protected void aceptar_Click(object sender, EventArgs e)
        {
            Modelo.Vehiculo oVehiculo = ControladoraVehiculos.getINSTANCIA.ObtenerVehiculo(this.Patente.Text);

            int patenteTaxi = oVehiculo.PatenteTaxi.Value;
            oVehiculo.PatenteTaxi = Convert.ToInt32(this.PatenteTaxi.Text);
            oVehiculo.Marca = this.Marca.Text;
            oVehiculo.Modelo = this.Modelo.Text;
            oVehiculo.Año = Convert.ToInt32(this.Año.Text);
            oVehiculo.Color = this.Color.Text;
            oVehiculo.Kilometraje = Convert.ToInt32(this.Kilometraje.Text);

            if (patenteTaxi == oVehiculo.PatenteTaxi)
            {
                ControladoraVehiculos.getINSTANCIA.ModificarVehiculo(oVehiculo);
                Response.Redirect("Vehiculos.aspx");
            }
            else
            {
                if (ControladoraVehiculos.getINSTANCIA.VerificarPatenteTaxi(oVehiculo))
                {
                    ControladoraVehiculos.getINSTANCIA.ModificarVehiculo(oVehiculo);
                    Response.Redirect("Vehiculos.aspx");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('La patente solicitada ya pertenece a otro vehiculo');", true);
                }
            }
        }
    }
}