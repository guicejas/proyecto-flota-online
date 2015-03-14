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
                <td>Tipo de Licencia
                </td>
                <td class="segmented-button">
                    <asp:RadioButton ID="RadButDemo" CssClass="first" runat="server" GroupName="TipodeLicencia" Text="Demo" Checked="true" OnCheckedChanged="RadButDemo_CheckedChanged" AutoPostBack="True" />
                    <asp:RadioButton ID="RadButBasica" runat="server" GroupName="TipodeLicencia" Text="Basica" OnCheckedChanged="RadButBasica_CheckedChanged" AutoPostBack="True" />
                    <asp:RadioButton ID="RadButPremium" CssClass="last" runat="server" GroupName="TipodeLicencia" Text="Premium" OnCheckedChanged="RadButPremium_CheckedChanged" AutoPostBack="True" />
                </td>
            </tr>

            <tr>
                <td>Descripción
                </td>
                <td>
                    <asp:TextBox ID="descripcion" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Ingrese una descripcion" ControlToValidate="descripcion" CssClass="alert-danger"></asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td>Dias de duracion
                </td>
                <td>
                    <asp:TextBox ID="duracion" runat="server" CssClass="form-control" MaxLength="5" TextMode="Number"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Ingrese la duracion de la Licencia" ControlToValidate="duracion" CssClass="alert-danger"></asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td>Activo
                </td>
                <td>
                    <asp:CheckBox ID="activo" runat="server" Checked="true"></asp:CheckBox>
                </td>
                <td></td>
            </tr>

            <tr visible="false" id="boxPatrocinador" runat="server">
                <td>Patrocinador
                </td>
                <td>
                    <input id="txtPatrocinador" runat="server" type="text" class="form-control" />
                </td>
                <td></td>
            </tr>

            <tr visible="false" id="boxCantUsuarios" runat="server">
                <td>Cantidad de Usuarios
                </td>
                <td>
                    <input id="txtCantUsuarios" runat="server" type="number" class="form-control" />
                </td>
                <td></td>
            </tr>

            <tr visible="false" id="boxPrecio" runat="server">
                <td>Precio
                </td>
                <td>
                    <input id="txtPrecio" runat="server" type="text" class="form-control" />
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ingrese un precio" ControlToValidate="txtPrecio" CssClass="alert-danger"></asp:RequiredFieldValidator>
                <br />
                    <asp:RangeValidator ID="RangeValidator1" Type="Double" ControlToValidate="txtPrecio" runat="server" ErrorMessage="El precio debe ser numérico" CssClass="alert-danger"></asp:RangeValidator>
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

