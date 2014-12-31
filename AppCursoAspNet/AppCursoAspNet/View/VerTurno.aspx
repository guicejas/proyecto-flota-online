<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="VerTurno.aspx.cs" Inherits="Vista.View.VerTurno" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <ol class="breadcrumb">
            <li><a href="Index.aspx">Inicio</a></li>
            <li><a href="Turnos.aspx">Turnos</a></li>
            <li class="active">Ver Turno</li>
        </ol>
    </div>
    <h2>Turno</h2>
    <p>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/View/Turnos.aspx">Volver</asp:HyperLink>
    </p>

    <form runat="server">

        <table style="width: 81%;" class="table table-hover">

            <tr>
                <td>Turno ID                </td>
                <td>
                    <asp:TextBox ID="txtTurnoId" runat="server" CssClass="form-control input-sm" Enabled="false"></asp:TextBox>
                </td>
                <td></td>
            </tr>

            <tr>
                <td>Vehículo                </td>
                <td>
                    <asp:TextBox ID="txtVehiculo" runat="server" CssClass="form-control input-sm" Enabled="false"></asp:TextBox>
                </td>
                <td></td>
            </tr>


            <tr>
                <td>Chofer                </td>
                <td>
                    <asp:TextBox ID="txtChofer" runat="server" CssClass="form-control input-sm" Enabled="false"></asp:TextBox>
                </td>
                <td></td>
            </tr>



            <tr id="fechaInicio" runat="server">
                <td>Fecha Inicio de turno
                </td>
                <td>
                    <asp:TextBox ID="txtFechaInicioTurno" runat="server" CssClass="form-control input-sm" Enabled="false"></asp:TextBox>
                </td>
                <td></td>
            </tr>


            <tr id="horaInicio" runat="server">
                <td>Hora Inicio de turno
                </td>
                <td>
                    <asp:TextBox ID="txtHoraInicioTurno" runat="server" CssClass="form-control input-sm" Enabled="false"></asp:TextBox>
                </td>
                <td></td>
            </tr>

            <tr id="fechaFin" runat="server">
                <td>Fecha Fin de turno
                </td>
                <td>
                    <asp:TextBox ID="txtFechaFinTurno" runat="server" CssClass="form-control input-sm" Enabled="false"></asp:TextBox>
                </td>
                <td></td>
            </tr>

            <tr id="horaFin" runat="server">
                <td>Hora Fin de turno
                </td>
                <td>
                    <asp:TextBox ID="txtHoraFinTurno" runat="server" CssClass="form-control input-sm" Enabled="false"></asp:TextBox>
                </td>
                <td></td>
            </tr>



            <tr>
                <td>Kilometros Recorridos                </td>
                <td>
                    <asp:TextBox ID="txtKmRecorridos" runat="server" CssClass="form-control input-sm" Enabled="false"></asp:TextBox>
                </td>
                <td></td>
            </tr>

            <tr>
                <td>Kilometros Ocupados                </td>
                <td>
                    <asp:TextBox ID="txtKmOcupados" runat="server" CssClass="form-control input-sm" Enabled="false"></asp:TextBox>
                </td>
                <td></td>
            </tr>

            <tr>
                <td>Cantidad de Viajes                </td>
                <td>
                    <asp:TextBox ID="txtCantViajes" runat="server" CssClass="form-control input-sm" Enabled="false"></asp:TextBox>
                </td>
                <td></td>
            </tr>

            <tr>
                <td>Gastos
                </td>
                <td>
                    <asp:BulletedList ID="bulletGastos" runat="server" BulletStyle="Square" CssClass="list-group-item-warning"></asp:BulletedList>
                    <asp:Panel ID="panelGastos" runat="server"></asp:Panel>
                </td>
                <td></td>
            </tr>

            <tr>
                <td>Cuentas Corrientes
                </td>
                <td>
                    <asp:BulletedList ID="bulletCC" runat="server" BulletStyle="Square" CssClass="list-group-item-success"></asp:BulletedList>
                </td>
                <td></td>
            </tr>

            <tr>
                <td></td>
                <td></td>
                <td></td>
            </tr>

            <tr class="form-group has-success">
                <td>Recaudacion Efectivo</td>
                <td>
                    <asp:TextBox ID="txtRecaudacion" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </td>
                <td></td>
            </tr>

            <tr class="form-group has-warning">
                <td>Recaudacion TOTAL</td>
                <td>
                    <asp:TextBox ID="txtRecaudacionTotal" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </td>
                <td></td>
            </tr>

            <tr class="form-group has-error">
                <td>Recaudacion NETA</td>
                <td>
                    <asp:TextBox ID="txtRecaudacionNeta" runat="server" CssClass="form-control label-success" Enabled="false"></asp:TextBox>
                </td>
                <td></td>
            </tr>

            <tr>
                <td></td>
                <td></td>
                <td></td>
            </tr>


            <tr>
                <td>Comentarios
                </td>
                <td>
                    <asp:TextBox ID="txtComentarios" runat="server" CssClass="form-control input-sm" TextMode="MultiLine" Enabled="false"></asp:TextBox>
                </td>
                <td></td>
            </tr>


        </table>
    </form>
</asp:Content>
