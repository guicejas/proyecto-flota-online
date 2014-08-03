﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controladora;

namespace Vista.View
{
    public partial class NuevoVehiculo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void aceptar_Click(object sender, EventArgs e)
        {
            Modelo.Vehiculo oVehiculo = new Modelo.Vehiculo();

            oVehiculo.Patente = this.Patente.Text;
            oVehiculo.PatenteTaxi = Convert.ToInt32(this.PatenteTaxi.Text);
            oVehiculo.Marca = this.Marca.Text;
            oVehiculo.Modelo = this.Modelo.Text;
            oVehiculo.Año = Convert.ToInt32(this.Año.Text);
            oVehiculo.Color = this.Color.Text;
            oVehiculo.Kilometraje = Convert.ToInt32(this.Kilometraje.Text);

           if (ControladoraVehiculos.getINSTANCIA.VerificarVehiculo(oVehiculo))
            {
                if (ControladoraVehiculos.getINSTANCIA.VerificarPatenteTaxi(oVehiculo))
                {
                    ControladoraVehiculos.getINSTANCIA.AgregarVehiculo(oVehiculo);
                    Response.Redirect("Vehiculos.aspx");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('La patente de taxi solicitada se encuentra activa en otro vehiculo');", true);
                  
                }

            }
            else
            {
                 ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('La patente solicitada ya pertenece a otro vehiculo');", true);
            }

           
        }

    }
}