<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TiposdeLicencia.aspx.cs" Inherits="Vista.Seguridad.TiposdeLicencia" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <ol class="breadcrumb">
            <li><a href="../View/Index.aspx">Inicio</a></li>
            <li class="active">Tipos de Licencia</li>
        </ol>
    </div>
    <h2>Tipos de Licencia</h2>
    <p>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="NuevoGrupo.aspx" class="btn btn-success"><span class="glyphicon glyphicon-plus"></span>Agregar Tipo de Licencia</asp:HyperLink>
    </p>
    <form runat="server">
    <asp:ScriptManager ID="ScriptManager1" AllowCustomErrorsRedirect="false" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <asp:GridView ID="listaTiposLicencia" runat="server" AutoGenerateColumns="False" CellPadding="4" SelectMethod="GetTiposdeLicencia" CssClass="table table-striped table-hover" OnRowDeleting="listaTiposLicencia_RowDeleting" OnRowEditing="listaTiposLicencia_RowEditing">
                <EmptyDataTemplate>
                    No hay Tipos de Licencia.
                </EmptyDataTemplate>
                <AlternatingRowStyle BackColor="White" ForeColor="WhiteSmoke" />
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" />
                    <asp:BoundField DataField="Duracion" HeaderText="Duracion" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
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


    <asp:ObjectDataSource ID="ObjectGrupos" runat="server" SelectMethod="ListarGrupos" TypeName="Controladora.SEGURIDAD.ControladoraGrupos" DataObjectTypeName="Modelo.SEGURIDAD.Grupo" DeleteMethod="EliminarGrupo" InsertMethod="AgregarGrupo"></asp:ObjectDataSource>
    &nbsp;&nbsp;&nbsp; 
   
</asp:Content>
