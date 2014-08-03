<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"  CodeBehind="EditarChofer.aspx.cs" Inherits="Vista.View.EditarChofer" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <ol class="breadcrumb">
            <li><a href="Index.aspx">Inicio</a></li>
            <li><a href="Choferes.aspx">Choferes</a></li>
            <li class="active">Nuevo Chofer</li>
        </ol>
    </div>
    <h2>Alta de Choferes</h2>
     <p>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/View/Choferes.aspx">Volver</asp:HyperLink>
    </p>
    <form runat="server">
        <table style="width: 81%;" class="table table-hover">
     
        <tr>
            <td>
                Documento</td>
            <td>
                <asp:TextBox ID="Documento" runat="server" CssClass="form-control"  MaxLength="8" Enabled="False"></asp:TextBox>                  
            </td>
            <td>
                
            </td>            
        </tr>
        <tr>
            <td>
                Nombre
            </td>
            <td>
                <asp:TextBox ID="Nombre" runat="server" CssClass="form-control" ></asp:TextBox>
            </td>
            <td><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Ingrese Nombre" ControlToValidate="Nombre" CssClass="alert-danger" ></asp:RequiredFieldValidator>
             <br/>                
            </td>
        </tr>
        <tr>
            <td>
                Apellido</td>
            <td>
                <asp:TextBox ID="Apellido" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
            <td><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Ingrese Apellido" ControlToValidate="Apellido" CssClass="alert-danger" ></asp:RequiredFieldValidator>
                <br />
                
                </td>
        </tr>
        <tr>
            <td>
                Fecha de Nacimiento</td>
            <td>
                <input id="FechNac" class="form-control" runat="server" type="date" name="fecha"/>
            </td>
                      
            <td>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Ingrese una Fecha de Nacimiento" ControlToValidate="FechNac" CssClass="alert-danger"></asp:RequiredFieldValidator>
                <br />
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
                Licencia
            </td>
            <td>
                <asp:TextBox ID="Licencia" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
              <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Ingrese Licencia" ControlToValidate="Licencia" CssClass="alert-danger"></asp:RequiredFieldValidator>
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
                Foto
            </td>
            <td>
                <asp:FileUpload ID="Foto" runat="server" />
                <br /><br />
                <asp:Label ID="lblinformacion" runat="server" Text=""></asp:Label>
             
            </td>
              <td>
                    
                <br/>
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
