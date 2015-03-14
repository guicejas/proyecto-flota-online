<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="Vista.Registrarse" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

            <div>
        <ol class="breadcrumb">
            <li class="active">Registrarse</li>
        </ol>
    </div>

    <div class="well bs-component" style="margin: 0 auto; width: 800px;">

 <form runat="server">

        <table class="table table-hover">
                        <tr>
                <td>Nombre de Flota
                </td>
                <td>
                    <asp:TextBox ID="flota" runat="server" CssClass="form-control" MaxLength="25"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Ingrese un nombre de flota" ControlToValidate="flota" CssClass="alert-danger"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Usuario
                </td>
                <td>
                    <asp:TextBox ID="usuario" runat="server" CssClass="form-control" MaxLength="25"></asp:TextBox>
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
                <td>Licencia</td>
                <td>

                    <asp:DropDownList ID="DlLicencia" CssClass="form-control" runat="server" DataSourceID="ObjectTipoLicencia" DataTextField="Descripcion" DataValueField="Id" AppendDataBoundItems="true">

                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjectTipoLicencia" runat="server" SelectMethod="ListarTiposLicenciaDemo" TypeName="Vista.Registrarse"></asp:ObjectDataSource>

                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Debe seleccionar una licencia" ControlToValidate="DlLicencia" CssClass="alert-danger"></asp:RequiredFieldValidator></td>
                <td style="width: 37px">
                    <br />
                </td>
            </tr>

            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="aceptar" runat="server" OnClick="aceptar_Click" CssClass="btn btn-success" Text="Aceptar" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>

    </div>


</asp:Content>
