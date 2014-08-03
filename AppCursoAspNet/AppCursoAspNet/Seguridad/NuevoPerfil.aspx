<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="NuevoPerfil.aspx.cs" Inherits="Vista.Seguridad.NuevoPerfil" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <ol class="breadcrumb">
            <li><a href="../View/Index.aspx">Inicio</a></li>
            <li><a href="Perfiles.aspx">Perfiles</a></li>
            <li class="active">Nuevo Perfil</li>
        </ol>
    </div>
    <h2>Alta de Perfil</h2>
    <p>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Perfiles.aspx">Volver</asp:HyperLink>
    </p>

    <form runat="server">

        <table style="width: 81%;" class="table table-hover">

<tr>
                <td>Grupo</td>
                <td>
                    <asp:DropDownList ID="DlGrupo" CssClass="form-control" runat="server" DataSourceID="ObjectGrupo" DataTextField="IDGrupo" DataValueField="IDGrupo" AppendDataBoundItems="true">
                        <asp:ListItem Value="">Seleccionar grupo</asp:ListItem>
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjectGrupo" runat="server" SelectMethod="ListarGrupos" TypeName="Controladora.SEGURIDAD.ControladoraGrupos"></asp:ObjectDataSource>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Debe seleccionar un Grupo" ControlToValidate="DlGrupo" CssClass="alert-danger"></asp:RequiredFieldValidator></td>
                <td style="width: 37px">
                    <br />
                </td>
            </tr>

            <tr>
                <td>Formulario</td>
                <td>
                    <asp:DropDownList ID="DlFormulario" CssClass="form-control" runat="server" DataSourceID="ObjectFormulario" DataTextField="IDFormulario" DataValueField="IDFormulario" AppendDataBoundItems="true">
                        <asp:ListItem Value="">Seleccionar formulario</asp:ListItem>
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjectFormulario" runat="server" SelectMethod="ListarFormularios" TypeName="Controladora.SEGURIDAD.ControladoraFormularios"></asp:ObjectDataSource>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Debe seleccionar un Formulario" ControlToValidate="DlFormulario" CssClass="alert-danger"></asp:RequiredFieldValidator></td>
                <td style="width: 37px">
                    <br />
                </td>
            </tr>

            <tr>
                <td>Permiso</td>
                <td>
                    <asp:DropDownList ID="DlPermiso" CssClass="form-control" runat="server" DataSourceID="ObjectPermiso" DataTextField="IDPermiso" DataValueField="IDPermiso" AppendDataBoundItems="true">
                        <asp:ListItem Value="">Seleccionar permiso</asp:ListItem>
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjectPermiso" runat="server" SelectMethod="ListarPermisos" TypeName="Controladora.SEGURIDAD.ControladoraPermisos"></asp:ObjectDataSource>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Debe seleccionar un Permiso" ControlToValidate="DlPermiso" CssClass="alert-danger"></asp:RequiredFieldValidator></td>
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

