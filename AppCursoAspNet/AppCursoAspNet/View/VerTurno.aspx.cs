using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista.View
{
    public partial class VerTurno : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string turnoId = Request.QueryString["TurnoId"];
                decimal gastosacum = 0;
                decimal ccacum = 0;

                Modelo.Turno oTurno = Controladora.ControladoraTurnos.getINSTANCIA.ObtenerTurno(Convert.ToInt32(turnoId));
                try
                {
                    this.txtTurnoId.Text = oTurno.Id.ToString();
                    this.txtChofer.Text = oTurno.Chofer.NombreCompleto;
                    this.txtVehiculo.Text = oTurno.Vehiculo.Patente;
                    this.txtFechaInicioTurno.Text = oTurno.FechaIncioCorta.ToString();
                    this.txtHoraInicioTurno.Text = oTurno.HoraInicio.ToShortTimeString();
                    this.txtFechaFinTurno.Text = oTurno.FechaFinCorta.ToString();
                    this.txtHoraFinTurno.Text = oTurno.HoraFin.ToShortTimeString();
                    this.txtKmRecorridos.Text = oTurno.KmRecorridos.ToString();
                    this.txtKmOcupados.Text = oTurno.KmOcupados.ToString();
                    this.txtCantViajes.Text = oTurno.CantidadViajes.ToString();
                    this.txtRecaudacion.Text = "$"+oTurno.RecaudacionEfectivo.ToString();
                    this.txtComentarios.Text = oTurno.Comentarios;
                   

                        foreach (Modelo.Gasto miGasto in oTurno.Gasto)
                        {
                            bulletGastos.Items.Add(miGasto.Id + " - " + miGasto.Descripcion + " - " + "$" + miGasto.Monto.ToString());
                                gastosacum = gastosacum + miGasto.Monto;
                                //TextBox newTextGasto = new TextBox();
                                //newTextGasto.ID = "txtGasto" + i.Id;
                                //newTextGasto.Text = i.Id + " - " + i.Descripcion + " - " + "$" + i.Monto.ToString();
                                //newTextGasto.Enabled = false;
                                //newTextGasto.CssClass = "form-control";
                                //panelGastos.Controls.Add(newTextGasto);
                                //panelGastos.Controls.Add(new LiteralControl("<br />"));
                        }

                        foreach (Modelo.CuentaCorriente miCC in oTurno.CuentaCorriente)
                        {
                            bulletCC.Items.Add(miCC.Empresa.Cuit + " - " + miCC.Empresa.RazonSocial + " - " + "$" + miCC.Monto.ToString());
                            ccacum = ccacum + miCC.Monto;
                        }

                        this.txtRecaudacionTotal.Text = "$" + (oTurno.RecaudacionEfectivo+ccacum).ToString();
                        this.txtRecaudacionNeta.Text = "$" + (oTurno.RecaudacionEfectivo + ccacum - gastosacum).ToString();


                        //foreach (Modelo.CuentaCorriente miCC in oTurno.CuentaCorriente)
                        //{
                        //        TextBox newTextCC = new TextBox();
                        //        newTextCC.ID = "txtCC" + miCC.Id;
                        //        newTextCC.Text = miCC.Empresa.Cuit + " - " + miCC.Empresa.RazonSocial + " - " + "$" + miCC.Monto.ToString();
                        //        newTextCC.Enabled = false;
                        //        newTextCC.CssClass = "form-control";
                        //        panelGastos.Controls.Add(newTextCC);
                        //        panelGastos.Controls.Add(new LiteralControl("<br />"));
                        //}


                }
                catch (NullReferenceException ex)
                {
                    Response.Redirect("../View/Error.aspx?error=" + ex.Message);

                }

            }
        }
    }
}
