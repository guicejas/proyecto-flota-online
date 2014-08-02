<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Turnos.aspx.cs" Inherits="Vista.View.Turnos" %>

<asp:content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">




    <asp:GridView ID="listaGastos" runat="server" AutoGenerateColumns="False" CellPadding="4" SelectMethod="GetGastos" CssClass="table table-striped table-hover" OnRowDeleting="listaGastos_RowDeleting" OnRowEditing="listaGastos_RowEditing" OnSelectedIndexChanged="listaGastos_SelectedIndexChanged">
        <EmptyDataTemplate>
                    No hay gastos.
                </EmptyDataTemplate>
        <AlternatingRowStyle BackColor="White" ForeColor="WhiteSmoke" />
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Turno Id" />
            <asp:BoundField DataField="Descripcion" HeaderText="Chofer" />
            <asp:BoundField DataField="Monto" HeaderText="Vehiculo" />
            <asp:BoundField DataField="Estado" HeaderText="Fecha Turno" />
            <asp:CommandField ShowEditButton="True" EditImageUrl="~/Images/edit-item.png" EditText="Editar" HeaderImageUrl="~/Images/edit-item.png" />
            <asp:CommandField ShowDeleteButton="True" DeleteImageUrl="~/Images/delete-item.png" DeleteText="Borrar" HeaderImageUrl="~/Images/delete-item.png" />
        </Columns>
    </asp:GridView>




</asp:content>
