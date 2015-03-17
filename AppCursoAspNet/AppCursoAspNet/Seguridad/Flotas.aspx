<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Flotas.aspx.cs" Inherits="Vista.View.Flotas" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <ol class="breadcrumb">
            <li><a href="Index.aspx">Inicio</a></li>
            <li class="active">Flotas</li>
        </ol>
    </div>
    <h2>Flotas</h2>
    <p>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/View/NuevoEmpresa.aspx" class="btn btn-success"><span class="glyphicon glyphicon-plus"></span>Agregar Flotas</asp:HyperLink>
    </p>
    <form runat="server">
    <asp:ScriptManager ID="ScriptManager1" AllowCustomErrorsRedirect="false" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="table table-hover">
                <tr>
                    <td>Razon Social: </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtFiltroRazonSocial" CssClass="form-control"></asp:TextBox></td>
                    <td>
                        <asp:Button runat="server" ID="btnFiltrar" Text="Filtrar" OnClick="btnFiltrar_Click" CssClass="btn" /></td>
                    <td>
                        <asp:Button runat="server" ID="Button1" Text="Reestablecer" OnClick="btnReestablecer_Click" CssClass="btn" /></td>
                </tr>
            </table>

            <asp:GridView ID="listaFlotas" runat="server" AutoGenerateColumns="False" CellPadding="4" SelectMethod="GetFlotas" CssClass="table table-striped table-hover" OnRowEditing="listaFlotas_RowEditing">
                <EmptyDataTemplate>
                    No hay Flotas cargadas.
                </EmptyDataTemplate>
                <AlternatingRowStyle BackColor="White" ForeColor="WhiteSmoke" />
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" />
                    <asp:BoundField DataField="RazonSocial" HeaderText="Razon Social" />
                    <asp:CommandField ShowEditButton="true" EditImageUrl="~/Images/edit-item.png" EditText="Ver" HeaderImageUrl="~/Images/edit-item.png" />
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>


    <!-- Bootstrap Modal Dialog -->
<div class="modal fade" id="myModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title"><asp:Label ID="lblModalTitle" runat="server" Text=""></asp:Label></h4>
                    </div>
                    <div class="modal-body">
                        <asp:Label ID="lblModalBody" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="modal-footer">
                        <button class="btn btn-amarillo" data-dismiss="modal" aria-hidden="true">Close</button>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</div>

                </form>
 
   
</asp:Content>

