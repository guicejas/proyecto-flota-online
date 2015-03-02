<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Vehiculos.aspx.cs" Inherits="Vista.View.Vehiculos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <ol class="breadcrumb">
            <li><a href="Index.aspx">Inicio</a></li>
            <li class="active">Vehiculos</li>
        </ol>
    </div>
    <h2>Vehiculos</h2>
    <p>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/View/NuevoVehiculo.aspx" class="btn btn-success"><span class="glyphicon glyphicon-plus"></span>Agregar Vehiculo</asp:HyperLink>
    </p>

    <form runat="server">

        <asp:ScriptManager ID="ScriptManager1" AllowCustomErrorsRedirect="false" runat="server"></asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table class="table table-hover">
                    <tr>
                        <td>Patente: </td>
                        <td><asp:TextBox runat="server" ID="txtFiltroPatente" CssClass="form-control"></asp:TextBox></td>
                        <td>Patente Taxi: </td>
                        <td><asp:TextBox runat="server" ID="txtFiltroPatenteTaxi" CssClass="form-control"></asp:TextBox></td>
                        <td>Año: </td>
                        <td><asp:TextBox runat="server" ID="txtFiltroAño" CssClass="form-control"></asp:TextBox></td>
                        <td><asp:Button runat="server" ID="btnFiltrar" Text="Filtrar" OnClick="btnFiltrar_Click" CssClass="btn" /></td>
                        <td><asp:Button runat="server" ID="Button1" Text="Reestablecer" OnClick="btnReestablecer_Click" CssClass="btn" /></td>
                    </tr>
                </table>

                <asp:GridView ID="listaVehiculos" runat="server" AutoGenerateColumns="False" CellPadding="4" SelectMethod="GetVehiculos" CssClass="table table-striped table-hover" OnRowDeleting="listaVehiculos_RowDeleting" OnRowEditing="listaVehiculos_RowEditing">
                    <EmptyDataTemplate>
                        No hay Vehiculos.
                    </EmptyDataTemplate>
                    <AlternatingRowStyle BackColor="White" ForeColor="WhiteSmoke" />
                    <Columns>
                        <asp:BoundField DataField="Patente" HeaderText="Patente" />
                        <asp:BoundField DataField="PatenteTaxi" HeaderText="PatenteTaxi" />
                        <asp:BoundField DataField="Marca" HeaderText="Marca" />
                        <asp:BoundField DataField="Modelo" HeaderText="Modelo" />
                        <asp:BoundField DataField="Año" HeaderText="Año" />
                        <asp:BoundField DataField="Color" HeaderText="Color" />
                        <asp:BoundField DataField="Kilometraje" HeaderText="Kilometraje" />
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
