<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="NuevoTipodeLicencia.aspx.cs" Inherits="Vista.Seguridad.NuevoTipodeLicencia" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <ol class="breadcrumb">
            <li><a href="../View/Index.aspx">Inicio</a></li>
            <li><a href="TiposdeLicencia.aspx">Tipos de Licencia</a></li>
            <li class="active">Nuevo Tipo de Licencia</li>
        </ol>
    </div>
    <h2>Alta de Tipo de Licencia</h2>
    <p>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="TiposdeLicencia.aspx">Volver</asp:HyperLink>
    </p>

    <form runat="server">

        <table style="width: 81%;" class="table table-hover">
            <tr>
                <td>
                    Tipo de Licencia
                </td>
                <td class="radio-inline">
                    <asp:RadioButton ID="RadButDemo" CssClass="btn btn-info btn-sm" runat="server"  GroupName="TipodeLicencia" Text="Licencia Demo" Checked="true"/>
                    <asp:RadioButton ID="RadButBasica" CssClass="btn btn-warning btn-sm" runat="server"  GroupName="TipodeLicencia" Text="Licencia Basica" />
                    <asp:RadioButton ID="RedButPremium" CssClass="btn btn-danger btn-sm" runat="server"  GroupName="TipodeLicencia" Text="Licencia Premium" />
                </td>
            </tr>


            <tr>
                <td>
                    Nombre
                </td>
                <td>
                    <asp:TextBox ID="nombre" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
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

