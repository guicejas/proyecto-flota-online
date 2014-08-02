<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EditarVehiculo.aspx.cs" Inherits="Vista.View.EditarVehiculo" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <ol class="breadcrumb">
            <li><a href="Index.aspx">Inicio</a></li>
            <li><a href="Vehiculos.aspx">Vehiculo</a></li>
            <li class="active">Editar Vehiculo</li>
        </ol>
    </div>
    <h2>Editar Vehiculos</h2>
    <form runat="server">
        <p>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/View/Vehiculos.aspx">Volver</asp:HyperLink>
        </p>
        <table style="width: 81%;" class="table table-hover">

            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Patente"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Patente" runat="server" CssClass="form-control" MaxLength="7" Enabled="False"></asp:TextBox>

                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Ingrese una Patente" ControlToValidate="Patente" CssClass="alert-danger"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Patente Taxi
                </td>
                <td>
                    <asp:TextBox ID="PatenteTaxi" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Ingrese una Patente de Taxi" ControlToValidate="PatenteTaxi" CssClass="alert-danger"></asp:RequiredFieldValidator>
                    <br />

                </td>
            </tr>
            <tr>
                <td>Marca</td>
                <td>
                    <asp:TextBox ID="Marca" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Ingrese una Marca" ControlToValidate="Marca" CssClass="alert-danger"></asp:RequiredFieldValidator>
                    <br />

                </td>
            </tr>
            <tr>
                <td>Modelo
                </td>
                <td>
                    <asp:TextBox ID="Modelo" runat="server" CssClass="form-control"></asp:TextBox>
                </td>

                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Ingrese un Modelo" ControlToValidate="Modelo" CssClass="alert-danger"></asp:RequiredFieldValidator>
                    <br />
                </td>
            </tr>
            <tr>
                <td>Año</td>
                <td>
                    <asp:TextBox ID="Año" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Ingrese un Año" ControlToValidate="Modelo" CssClass="alert-danger"></asp:RequiredFieldValidator>
                    <br />
                </td>
            </tr>
            <tr>
                <td>Color
                </td>
                <td>
                    <asp:TextBox ID="Color" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Ingrese un Color" ControlToValidate="Color" CssClass="alert-danger"></asp:RequiredFieldValidator>
                    <br />
                </td>
            </tr>
            <tr>
                <td>Kilometraje
                </td>
                <td>
                    <asp:TextBox ID="Kilometraje" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Ingrese un Kilometraje" ControlToValidate="Color" CssClass="alert-danger"></asp:RequiredFieldValidator>

                    <br />
                </td>
                <td style="width: 37px">
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
