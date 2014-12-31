<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="Vista.Seguridad.Usuarios" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <ol class="breadcrumb">
            <li><a href="../View/Index.aspx">Inicio</a></li>
            <li class="active">Usuarios</li>
        </ol>
    </div>
    <h2>Usuarios</h2>
    <p>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="NuevoUsuario.aspx" class="btn"><span class="glyphicon glyphicon-plus"></span>Agregar Usuario</asp:HyperLink>
    </p>
    <form runat="server">

        <div class="alert alert-dismissable alert-success" id="mensaje" runat="server" visible="false">
                <button type="button" class="close" data-dismiss="alert">×</button>
                <span id="mensajeTexto" runat="server"></span>
            </div>

    <asp:ScriptManager ID="ScriptManager1" AllowCustomErrorsRedirect="false" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <asp:GridView ID="listaUsuarios" runat="server" AutoGenerateColumns="False" CellPadding="4" SelectMethod="GetUsuarios" CssClass="table table-striped table-hover" OnRowDeleting="listaUsuarios_RowDeleting" OnRowEditing="listaUsuarios_RowEditing" OnSelectedIndexChanged="listaUsuarios_SelectedIndexChanged">
                <EmptyDataTemplate>
                    No hay usuarios.
                </EmptyDataTemplate>
                <AlternatingRowStyle BackColor="White" ForeColor="WhiteSmoke" />
                <Columns>
                    <asp:BoundField DataField="IDUsuario" HeaderText="Usuario" />
                    <asp:BoundField DataField="NombreApellido" HeaderText="Nombre y Apellido" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="estaHabilitado" HeaderText="Habilitado" />
                    <asp:CommandField ShowSelectButton="true" SelectText="Ver" HeaderImageUrl="~/Images/copy-item.png"/>   
                    <asp:CommandField ShowEditButton="True" EditImageUrl="~/Images/edit-item.png" EditText="Editar" HeaderImageUrl="~/Images/edit-item.png" />
                    <asp:TemplateField HeaderImageUrl="~/Images/delete-item.png" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" Text="Borrar" CommandName="Delete" CausesValidation="False" ID="deleteButton" OnClientClick="return confirm('Estas seguro que deseas eliminar este registro?');"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>


                </Columns>


            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
        </form>


    <asp:ObjectDataSource ID="ObjectUsuarios" runat="server" SelectMethod="ListarUsuarios" TypeName="Controladora.SEGURIDAD.ControladoraUsuarios" DataObjectTypeName="Modelo.SEGURIDAD.Usuario" DeleteMethod="EliminarUsuario" InsertMethod="AgregarUsuario"></asp:ObjectDataSource>
    &nbsp;&nbsp;&nbsp; 
   
</asp:Content>