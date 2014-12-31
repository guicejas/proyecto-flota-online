<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Perfiles.aspx.cs" Inherits="Vista.Seguridad.Perfiles" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <ol class="breadcrumb">
            <li><a href="../View/Index.aspx">Inicio</a></li>
            <li class="active">Perfiles</li>
        </ol>
    </div>
    <h2>Perfiles</h2>
    <p>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="NuevoPerfil.aspx" class="btn"><span class="glyphicon glyphicon-plus"></span>Agregar Perfil</asp:HyperLink>
    </p>
    <form runat="server">
        <asp:ScriptManager ID="ScriptManager1" AllowCustomErrorsRedirect="false" runat="server"></asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

                <asp:GridView ID="listaPerfiles" runat="server" AutoGenerateColumns="False" CellPadding="4" SelectMethod="GetPerfiles" CssClass="table table-striped table-hover" OnRowDeleting="listaPerfiles_RowDeleting" OnRowEditing="listaPerfiles_RowEditing">
                    <EmptyDataTemplate>
                        No hay Perfiles.
                    </EmptyDataTemplate>
                    <AlternatingRowStyle BackColor="White" ForeColor="WhiteSmoke" />
                    <Columns>
                        <asp:BoundField DataField="IDPerfil" HeaderText="ID" />
                        <asp:BoundField DataField="Grupo.IDGrupo" HeaderText="Grupo" />
                        <asp:BoundField DataField="Permiso.IDPermiso" HeaderText="Permiso" />
                        <asp:BoundField DataField="Formulario.IDFormulario" HeaderText="Formulario" />

                        <asp:CommandField ShowEditButton="True" EditImageUrl="~/Images/edit-item.png" EditText="Editar" HeaderImageUrl="~/Images/edit-item.png" />
                        <asp:TemplateField HeaderImageUrl="~/Images/delete-item.png" ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton runat="server" Text="Borrar" CommandName="Delete" CausesValidation="False" ID="LinkButton1" OnClientClick="return confirm('Estas seguro que deseas eliminar este registro?');"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>


                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>


    <asp:ObjectDataSource ID="ObjectPerfiles" runat="server" SelectMethod="PerfilesGrupos" TypeName="Controladora.SEGURIDAD.ControladoraPerfiles" DataObjectTypeName="Modelo.SEGURIDAD.Perfil" DeleteMethod="EliminarPerfil" InsertMethod="AgregaPerfil"></asp:ObjectDataSource>
    &nbsp;&nbsp;&nbsp; 
   
</asp:Content>

