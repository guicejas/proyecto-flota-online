<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MiCuenta.aspx.cs" Inherits="Vista.View.MiCuenta" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <ol class="breadcrumb">
            <li><a href="../View/Index.aspx">Inicio</a></li>
            <li class="active">Mi cuenta</li>
        </ol>
    </div>
    <h2>Editar Usuario</h2>
    <p>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="Usuarios.aspx">Volver</asp:HyperLink>
    </p>

    <form runat="server">

        <table style="width: 81%;" class="table table-hover">

            <tr>
                <td>Usuario
                </td>
                <td>
                    <asp:TextBox ID="usuario" runat="server" CssClass="form-control" MaxLength="25" Enabled="false"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Ingrese un usuario" ControlToValidate="usuario" CssClass="alert-danger"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Nombre y Apellido
                </td>
                <td>
                    <asp:TextBox ID="nombreyapellido" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Ingrese nombre y apellido" ControlToValidate="nombreyapellido" CssClass="alert-danger"></asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td>E-mail
                </td>
                <td>
                    <input id="email" class="form-control" runat="server" type="email" />
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Ingrese un E-mail" ControlToValidate="email" CssClass="alert-danger"></asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td>Grupo
                </td>
                <td>
                    <asp:TextBox ID="grupo" runat="server" CssClass="form-control" MaxLength="35" Enabled="false"></asp:TextBox>
                </td>
                <td>
                </td>
            </tr>


            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="aceptar" runat="server" OnClick="aceptar_Click" CssClass="btn-success" Text="Aceptar" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</asp:Content>

