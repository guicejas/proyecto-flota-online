<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EditarGrupo.aspx.cs" Inherits="Vista.Seguridad.EditarGrupo" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <ol class="breadcrumb">
            <li><a href="../View/Index.aspx">Inicio</a></li>
            <li><a href="Grupos.aspx">Grupos</a></li>
            <li class="active">Editar Grupo</li>
        </ol>
    </div>
    <h2>Editar Grupo</h2>
    <p>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="Grupos.aspx">Volver</asp:HyperLink>
    </p>

    <form runat="server">

        <table style="width: 81%;" class="table table-hover">

            <tr>
                <td>
                    Nombre
                </td>
                <td>
                    <asp:TextBox ID="nombre" runat="server" CssClass="form-control" MaxLength="50" Enabled="False"></asp:TextBox> 
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Ingrese un nombre" ControlToValidate="nombre" CssClass="alert-danger"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Descripción
                </td>
                <td>
                    <asp:TextBox ID="descripcion" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Ingrese una descripcion" ControlToValidate="descripcion" CssClass="alert-danger"></asp:RequiredFieldValidator>
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