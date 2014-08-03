<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EditarEmpresa.aspx.cs" Inherits="Vista.View.EditarEmpresa" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <ol class="breadcrumb">
            <li><a href="Index.aspx">Inicio</a></li>
            <li><a href="Empresas.aspx">Empresas</a></li>
            <li class="active">Nueva Empresa</li>
        </ol>
    </div>
    <h2>Alta de Empresas</h2>    
     <p>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/View/Empresas.aspx">Volver</asp:HyperLink>
    </p>

    <form runat="server">
        <table style="width: 81%;" class="table table-hover">
     
        <tr>
            <td>
                Cuit</td>
            <td>
                    <asp:TextBox ID="Cuit" runat="server" CssClass="form-control" MaxLength="11" Enabled="false"></asp:TextBox>

                </td>
            <td>
                <asp:RangeValidator ID="RangeValidatorCuil" ControlToValidate="Cuit" runat="server" ErrorMessage="Error: " SetFocusOnError="True" Type="Double" CssClass="alert-danger" ></asp:RangeValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Cuit" ErrorMessage="El Cuit debe ser Numérico" ValidationExpression="[1-9]\d*" CssClass="alert-danger" ></asp:RegularExpressionValidator>
           </td>            
        </tr>
        <tr>
            <td>
                Razón Social
            </td>
            <td>
                <asp:TextBox ID="razonSocial" runat="server" CssClass="form-control" ></asp:TextBox>
            </td>
            <td><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Ingrese Razón Social" ControlToValidate="razonSocial" CssClass="alert-danger" ></asp:RequiredFieldValidator>
             <br/>                
            </td>
        </tr>
         <tr>
                <td>Domicilio</td>
                <td>
                    <asp:TextBox ID="Domicilio" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Ingrese Domicilio" ControlToValidate="Domicilio" CssClass="alert-danger"></asp:RequiredFieldValidator>
                <br />
                 </td>
                </tr>
        <tr>
            <td>Localidad
                </td>
            <td>                 
                 <asp:TextBox ID="Localidad" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
             <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Ingrese Localidad" ControlToValidate="Localidad" CssClass="alert-danger"></asp:RequiredFieldValidator>
                <br />
             </td>
            </tr>
            <tr>
            <td>
                Teléfono
            </td>
            <td>
                <asp:TextBox ID="Telefono" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
              <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ingrese un Teléfono" ControlToValidate="Telefono" CssClass="alert-danger"></asp:RequiredFieldValidator>
                <br />
             </td>
            </tr>
            <tr>
            <td>
                E-mail
            </td>
            <td>
                <input id="email" class="form-control" runat="server" type="email" name="fecha"/>
            </td>
              <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Ingrese un E-mail" ControlToValidate="email" CssClass="alert-danger"></asp:RequiredFieldValidator>
              <br />

             </td>
            </tr>           
                   
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="aceptar" runat="server" CssClass="btn-success" OnClick="aceptar_Click" Text="Aceptar" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</form>
</asp:Content>