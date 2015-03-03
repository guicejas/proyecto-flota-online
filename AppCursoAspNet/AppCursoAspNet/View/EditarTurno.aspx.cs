using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista.View
{
    public partial class EditarTurno : System.Web.UI.Page
    {
        Controladora.SEGURIDAD.ControladoraFlotas ctrlFlotas = new Controladora.SEGURIDAD.ControladoraFlotas();
        string flotaId;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string turnoId = Request.QueryString["TurnoId"];

                Modelo.Turno oTurno = Controladora.ControladoraTurnos.getINSTANCIA.ObtenerTurno(Convert.ToInt32(turnoId));
                try
                {
                    this.txtTurnoId.Text = oTurno.Id.ToString();
                    this.DlChofer.SelectedValue = oTurno.Chofer.Documento.ToString();
                    this.DlVehiculo.SelectedValue = oTurno.Vehiculo.Patente;
                    this.dateFechaInicio.Value = oTurno.FechaInicio.ToString("yyyy-MM-dd");
                    this.timeHoraInicio.Value = oTurno.HoraInicio.ToString("HH:mm");
                    this.dateFechaFin.Value = oTurno.FechaFin.ToString("yyyy-MM-dd");
                    this.timeHoraFin.Value = oTurno.HoraFin.ToString("HH:mm");
                    this.kmRecorridos.Text = oTurno.KmRecorridos.ToString();
                    this.kmOcupados.Text = oTurno.KmOcupados.ToString();
                    this.cantViajes.Text = oTurno.CantidadViajes.ToString();
                    this.recaudacion.Text = oTurno.RecaudacionEfectivo.ToString();
                    this.comentarios.Text = oTurno.Comentarios;

                    if (oTurno.CuentaCorriente.Count > 0)
                    {
                        this.DlEmpresas.SelectedValue = oTurno.CuentaCorriente.FirstOrDefault().Empresa.Cuit.ToString();
                        this.montoCC.Text = oTurno.CuentaCorriente.FirstOrDefault().Monto.ToString();
                    }



                    foreach (Modelo.Gasto i in Controladora.ControladoraGastos.getINSTANCIA.ListarGastos(ctrlFlotas.ObtenerFlotadeUsuario(this.Context.User.Identity.Name).Id.ToString()))
                    {
                        foreach (Modelo.Gasto miGasto in oTurno.Gasto)
                        {
                            if (miGasto.Id == i.Id)
                            {
                                ListaGastos.SelectedValue= miGasto.Id.ToString();
                            }

                        }
                    }



                }
                catch (NullReferenceException ex)
                {
                    Response.Redirect("../View/Error.aspx?error=" + ex.Message);

                }

            }
        }

        protected void aceptar_Click(object sender, EventArgs e)
        {

            Modelo.Turno oTurno = Controladora.ControladoraTurnos.getINSTANCIA.ObtenerTurno(Convert.ToInt32(txtTurnoId.Text));

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
            //oTurno.fIDFlota = Convert.ToInt32(Server.HtmlEncode(Request.Cookies["userInfoSGOFT"]["flotaId"]));
            //oTurno.Gasto.Clear();

            foreach (ListItem item in ListaGastos.Items)
            {
                //if (item.Selected)
                //{
                //    if (oTurno.Gasto.Where(x => x.Id.ToString() == item.Value).Count > 0)

                //        foreach (Modelo.Gasto miGasto in oTurno.Gasto)
                //        {
                //            if (miGasto.Id == i.Id)
                //            {
                //                ListaGastos.SelectedValue = miGasto.Id.ToString();
                //            }

                //        }
                //}

                //if (item.Selected)
                   // oTurno.Gasto.Add(Controladora.ControladoraGastos.getINSTANCIA.ObtenerGasto(Convert.ToInt32(item.Value)));
            }

            //oTurno.CuentaCorriente.Clear();
            if (DlEmpresas.SelectedValue != "")
            {
                //Modelo.CuentaCorriente oCC = new Modelo.CuentaCorriente();
                //oCC.Empresa = Controladora.ControladoraEmpresas.getINSTANCIA.ObtenerEmpresa(Convert.ToInt64(this.DlEmpresas.SelectedValue));
                //oCC.Estado = "Pendiente";
                //oCC.Fecha = Convert.ToDateTime(this.dateFechaInicio.Value);
                oTurno.CuentaCorriente.FirstOrDefault().Monto = Convert.ToDecimal(this.montoCC.Text);

                //oTurno.CuentaCorriente.Add(oCC);
            }
            Controladora.ControladoraTurnos.getINSTANCIA.ModificarTurno(oTurno);

            Response.Redirect("Turnos.aspx");


        }

        public IList<Modelo.Vehiculo> ListarVehiculos()
        {

            return Controladora.ControladoraVehiculos.getINSTANCIA.ListarVehiculos(ctrlFlotas.ObtenerFlotadeUsuario(this.Context.User.Identity.Name).Id.ToString());
        }

        public IList<Modelo.Gasto> ListarGastos()
        {

            return Controladora.ControladoraGastos.getINSTANCIA.ListarGastos(ctrlFlotas.ObtenerFlotadeUsuario(this.Context.User.Identity.Name).Id.ToString());
        }


        public IList<Modelo.Empresa> ListarEmpresas()
        {

            return Controladora.ControladoraEmpresas.getINSTANCIA.ListarEmpresas(ctrlFlotas.ObtenerFlotadeUsuario(this.Context.User.Identity.Name).Id.ToString());
        }


        public IList<Modelo.Chofer> ListarChoferes()
        {

            return Controladora.ControladoraChoferes.getINSTANCIA.ListarChoferes(ctrlFlotas.ObtenerFlotadeUsuario(this.Context.User.Identity.Name).Id.ToString());
        }
    }
}
