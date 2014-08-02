<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="NuevoGasto.aspx.cs" Inherits="Vista.NuevoGasto" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <ol class="breadcrumb">
            <li><a href="Index.aspx">Inicio</a></li>
            <li><a href="Gastos.aspx">Gastos</a></li>
            <li class="active">Nuevo Gasto</li>
        </ol>
    </div>
    <h2>Alta de Gasto</h2>
    <p>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/View/Gasto.aspx">Volver</asp:HyperLink>
    </p>

    <form runat="server">

        <table style="width: 81%;" class="table table-hover">

            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Descripcion"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="descripcion" runat="server" CssClass="form-control" TextMode="MultiLine" MaxLength="50"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Ingrese una descripción" ControlToValidate="descripcion" CssClass="alert-danger"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Monto</td>
                <td>
                    <asp:TextBox ID="monto" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Ingrese un monto" ControlToValidate="monto" CssClass="alert-danger"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RangeValidator ID="RangeValidator1" Type="Double" ControlToValidate="monto" runat="server" ErrorMessage="El monto debe ser numérico" CssClass="alert-danger"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td style="height: 39px">Estado</td>
                <td style="height: 39px">
                    <asp:DropDownList ID="DlEstado" runat="server" CssClass="form-control">
                        <asp:ListItem Value="PENDIENTE"></asp:ListItem>
                        <asp:ListItem Value="PAGADO"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="height: 39px"></td>
            </tr>
            <tr>
                <td>Tipo de Gasto</td>
                <td>
                    <asp:DropDownList ID="dlTipoDeGasto" CssClass="form-control" runat="server" DataSourceID="ObjectTipoGasto" DataTextField="Descripcion" DataValueField="Id" AppendDataBoundItems="true" OnSelectedIndexChanged="dlTipoDeGasto_SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem Value="">Seleccionar Tipo de Gasto</asp:ListItem>
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjectTipoGasto" runat="server" SelectMethod="ListarTiposdeGasto" TypeName="Controladora.ControladoraTiposdeGasto"></asp:ObjectDataSource>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Debe seleccionar un Tipo de Gasto" ControlToValidate="dlTipoDeGasto" CssClass="alert-danger"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr visible="false" id="boxFechaInfraccion" runat="server">
                <td>Fecha Infracción
                </td>
                <td>
                    <input id="txtFechaInfraccion" runat="server" type="date" name="fecha0" />
                </td>
                <td></td>
            </tr>
            <tr visible="false" id="boxHoraInfraccion" runat="server">
                <td>Hora Infracción
                </td>
                <td>
                    <input id="HoraInfraccion" runat="server" type="time" name="fecha0" />
                </td>
                <td></td>
            </tr>
            <tr>
                <td>Vehículo</td>
                <td>
                    <asp:DropDownList ID="DlVehiculo" CssClass="form-control" runat="server" DataSourceID="ObjectVehiculo" DataTextField="Patente" DataValueField="Patente" AppendDataBoundItems="true">

                        <asp:ListItem Value="">Seleccionar vehículo</asp:ListItem>
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjectVehiculo" runat="server" SelectMethod="ListarVehiculos" TypeName="Controladora.ControladoraVehiculos"></asp:ObjectDataSource>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Debe seleccionar un Vehículo" ControlToValidate="DlVehiculo" CssClass="alert-danger"></asp:RequiredFieldValidator></td>
                <td style="width: 37px">
                    <br />
                </td>
            </tr>
            <tr>
                <td>Fecha de Vencimiento</td>
                <td>
                    <input id="txtFecha" class="form-control" runat="server" type="date" name="fecha" />
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Debe ingresar la fecha de Vencimiento" ControlToValidate="txtFecha" CssClass="alert-danger"></asp:RequiredFieldValidator>
                    <br />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="aceptar" runat="server" CssClass="btn-success" OnClick="aceptar_Click" Text="Aceptar" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</asp:Content>
