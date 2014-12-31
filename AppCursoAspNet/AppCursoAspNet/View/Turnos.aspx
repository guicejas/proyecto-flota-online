<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Turnos.aspx.cs" Inherits="Vista.View.Turnos" %>

<asp:content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div>
        <ol class="breadcrumb">
            <li><a href="Index.aspx">Inicio</a></li>
            <li class="active">Turnos</li>
        </ol>
    </div>
    <h2>Turnos</h2>
    <p>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/View/NuevoTurno.aspx" class="btn"><span class="glyphicon glyphicon-plus"></span>Agregar Turno</asp:HyperLink>
    </p>


    <form runat="server">
        <asp:ScriptManager ID="ScriptManager1" AllowCustomErrorsRedirect="false" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="table table-hover">
                <tr>
                    <td>Chofer: </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtFiltroChofer" CssClass="form-control"></asp:TextBox></td>
                    <td>Vehiculo: </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtFiltroVehiculo" CssClass="form-control"></asp:TextBox></td>
                    <td>Fecha: </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtFiltroFecha" TextMode="Date" CssClass="form-control"></asp:TextBox></td>
                    <td>
                    <td>
                        <asp:Button runat="server" ID="btnFiltrar" Text="Filtrar" OnClick="btnFiltrar_Click" CssClass="btn" /></td>
                    <td>
                        <asp:Button runat="server" ID="Button1" Text="Reestablecer" OnClick="btnReestablecer_Click" CssClass="btn" />
                    </td>
                </tr>
            </table>



    <asp:GridView ID="listaTurnos" runat="server" AutoGenerateColumns="False" CellPadding="4" SelectMethod="GetTurnos" CssClass="table table-striped table-hover" OnRowDeleting="listaTurnos_RowDeleting" OnRowEditing="listaTurnos_RowEditing"  OnSelectedIndexChanged="listaTurnos_SelectedIndexChanged">
        <EmptyDataTemplate>No hay Turnos cargados.</EmptyDataTemplate>
        <AlternatingRowStyle BackColor="White" ForeColor="WhiteSmoke" />
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Turno Id" />
            <asp:BoundField DataField="Chofer.NombreCompleto" HeaderText="Chofer" />
            <asp:BoundField DataField="Vehiculo.Patente" HeaderText="Vehiculo" />
            <asp:BoundField DataField="FechaIncioCorta" HeaderText="Fecha Turno"/>
            <asp:BoundField DataField="RecaudacionEfectivo" HeaderText="Recaudacion Turno"/>
            <asp:CommandField ShowSelectButton="true" SelectText="Ver" HeaderImageUrl="~/Images/copy-item.png"/>   
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

</asp:content>
