<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Empresas.aspx.cs" Inherits="Vista.View.Empresas" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <ol class="breadcrumb">
            <li><a href="Index.aspx">Inicio</a></li>
            <li class="active">Empresas</li>
        </ol>
    </div>
    <h2>Empresas</h2>
    <p>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/View/NuevoEmpresa.aspx" class="btn"><span class="glyphicon glyphicon-plus"></span>Agregar Empresa</asp:HyperLink>
    </p>
    <form runat="server">
    <asp:ScriptManager ID="ScriptManager1" AllowCustomErrorsRedirect="false" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="table table-hover">
                <tr>
                    <td>Cuit: </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtFiltroCuit" CssClass="form-control"></asp:TextBox></td>
                    <td>Razon Social: </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtFiltroRazonSocial" CssClass="form-control"></asp:TextBox></td>
                    <td>Localidad: </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtFiltroLocalidad" CssClass="form-control"></asp:TextBox></td>
                    <td>
                    <td>Correo: </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtFiltroCorreo" CssClass="form-control"></asp:TextBox></td>
                    <td>
                        <asp:Button runat="server" ID="btnFiltrar" Text="Filtrar" OnClick="btnFiltrar_Click" CssClass="btn" /></td>
                    <td>
                        <asp:Button runat="server" ID="Button1" Text="Reestablecer" OnClick="btnReestablecer_Click" CssClass="btn" /></td>
                </tr>
            </table>

            <asp:GridView ID="listaEmpresas" runat="server" AutoGenerateColumns="False" CellPadding="4" SelectMethod="GetEmpresas" CssClass="table table-striped table-hover" OnRowDeleting="listaEmprsas_RowDeleting" OnRowEditing="listaEmpresas_RowEditing">
                <EmptyDataTemplate>
                    No hay Empresas cargadas.
                </EmptyDataTemplate>
                <AlternatingRowStyle BackColor="White" ForeColor="WhiteSmoke" />
                <Columns>
                    <asp:BoundField DataField="Cuit" HeaderText="Cuit" />
                    <asp:BoundField DataField="RazonSocial" HeaderText="Razon Social" />
                    <asp:BoundField DataField="Domicilio" HeaderText="Domicilio" />
                    <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                    <asp:BoundField DataField="Localidad" HeaderText="Localidad" />
                    <asp:BoundField DataField="Correo" HeaderText="Correo" />
                    <asp:CommandField ShowEditButton="True" EditImageUrl="~/Images/edit-item.png" EditText="Editar" HeaderImageUrl="~/Images/edit-item.png" />
                    <asp:CommandField ShowDeleteButton="True" DeleteImageUrl="~/Images/delete-item.png" DeleteText="Borrar" HeaderImageUrl="~/Images/delete-item.png" />
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
        </form>


    <asp:ObjectDataSource ID="ObjectEmpresa" runat="server" SelectMethod="ListarEmpresas" TypeName="Controladora.ControladoraEmpresas" DataObjectTypeName="Modelo.Empresa" DeleteMethod="EliminarEmpresa" InsertMethod="AgregarEmpresa"></asp:ObjectDataSource>
    &nbsp;&nbsp;&nbsp; 
   
</asp:Content>

