﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista.View
{
    public partial class NuevoTurno : System.Web.UI.Page
    {
     

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void aceptar_Click(object sender, EventArgs e)
        {
            Modelo.Turno oTurno = new Modelo.Turno();

            oTurno.Vehiculo = Controladora.ControladoraVehiculos.getINSTANCIA.ObtenerVehiculo(this.DlVehiculo.SelectedValue);
            oTurno.Chofer = Controladora.ControladoraChoferes.getINSTANCIA.ObtenerChofer(Convert.ToInt32(this.DlChofer.SelectedValue));
            oTurno.FechaInicio = Convert.ToDateTime(this.dateFechaInicio.Value);
            oTurno.FechaFin = Convert.ToDateTime(this.dateFechaFin.Value);
            oTurno.HoraInicio = Convert.ToDateTime(this.timeHoraInicio.Value);
            oTurno.HoraFin = Convert.ToDateTime(this.timeHoraFin.Value);
            oTurno.KmRecorridos = Convert.ToDecimal(this.kmRecorridos.Text);
            oTurno.Vehiculo.Kilometraje = oTurno.Vehiculo.Kilometraje + Convert.ToInt32(oTurno.KmRecorridos);
            oTurno.KmOcupados = Convert.ToDecimal(this.kmOcupados.Text);
            oTurno.CantidadViajes = Convert.ToInt16(this.cantViajes.Text);
            oTurno.RecaudacionEfectivo = Convert.ToDecimal(this.recaudacion.Text);
            oTurno.Comentarios = this.comentarios.Text;

            foreach (ListItem item in ListaGastos.Items)
            {
                if (item.Selected)
                    oTurno.Gasto.Add(Controladora.ControladoraGastos.getINSTANCIA.ObtenerGasto(Convert.ToInt32(item.Value)));
            }

            Modelo.CuentaCorriente oCC = new Modelo.CuentaCorriente();
            oCC.Empresa = Controladora.ControladoraEmpresas.getINSTANCIA.ObtenerEmpresa(Convert.ToInt32(this.DlEmpresas.SelectedValue));
            oCC.Estado = "Pendiente";
            oCC.Fecha = Convert.ToDateTime(this.dateFechaInicio.Value);
            oCC.Monto = Convert.ToDecimal(this.montoCC.Text);

            oTurno.CuentaCorriente.Add(oCC);

            Controladora.ControladoraTurnos.getINSTANCIA.AgregarTurno(oTurno);

            Response.Redirect("Turnos.aspx");
            
           
        }

        public IList<Modelo.Vehiculo> ListarVehiculos()
        {

            return Controladora.ControladoraVehiculos.getINSTANCIA.ListarVehiculos();
        }

        public IList<Modelo.Gasto> ListarGastos()
        {

            return Controladora.ControladoraGastos.getINSTANCIA.ListarGastos();
        }


        public IList<Modelo.Empresa> ListarEmpresas()
        {

            return Controladora.ControladoraEmpresas.getINSTANCIA.ListarEmpresas();
        }


        public IList<Modelo.Chofer> ListarChoferes()
        {

            return Controladora.ControladoraChoferes.getINSTANCIA.ListarChoferes();
        }



        }
}
