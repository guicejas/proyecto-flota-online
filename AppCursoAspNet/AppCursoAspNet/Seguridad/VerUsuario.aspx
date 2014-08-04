<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="VerUsuario.aspx.cs" Inherits="Vista.Seguridad.VerUsuario" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <ol class="breadcrumb">
            <li><a href="../View/Index.aspx">Inicio</a></li>
            <li><a href="Usuarios.aspx">Usuarios</a></li>
            <li class="active">Ver Usuario</li>
        </ol>
    </div>
    <h2>Ver Usuario</h2>
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
               </td>
            </tr>
            <tr>
                <td>Nombre y Apellido
                </td>
                <td>
                    <asp:TextBox ID="nombreyapellido" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </td>
                <td>
                </td>
            </tr>

            <tr>
                <td>E-mail
                </td>
                <td>
                    <input id="email" class="form-control" runat="server" type="email" disabled="disabled"/>
                </td>
                <td>
                </td>
            </tr>

                        <tr>
                <td>Grupos
                </td>
                <td>
                    <asp:CheckBoxList ID="LbGrupos" runat="server" DataTextField="IDGrupo" DataValueField="IDGrupo" AppendDataBoundItems="true" Enabled="false"></asp:CheckBoxList>
                </td>
                <td>
               </td>
            </tr>

                        <tr>
                <td>Habilitado
                </td>
                <td>
                    <asp:CheckBox ID="habilitado" runat="server" Checked="false" Enabled="false"></asp:CheckBox>
                </td>
                <td>
                </td>
            </tr>

        </table>
    </form>
</asp:Content>
