<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Turnos.aspx.cs" Inherits="Vista.View.Turnos" %>

<asp:content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <form runat="server">

    <asp:GridView ID="listaTurnos" runat="server" AutoGenerateColumns="False" CellPadding="4" SelectMethod="GetTurnos" CssClass="table table-striped table-hover" OnRowDeleting="listaTurnos_RowDeleting" OnRowEditing="listaTurnos_RowEditing">
        <EmptyDataTemplate>No hay Turnos cargados.</EmptyDataTemplate>
        <AlternatingRowStyle BackColor="White" ForeColor="WhiteSmoke" />
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Turno Id" />
            <asp:BoundField DataField="Chofer.Nombre" HeaderText="Chofer" />
            <asp:BoundField DataField="Vehiculo.Patente" HeaderText="Vehiculo" />
            <asp:BoundField DataField="FechaInicio" HeaderText="Fecha Turno"/>
            <asp:CommandField ShowEditButton="True" EditImageUrl="~/Images/edit-item.png" EditText="Editar" HeaderImageUrl="~/Images/edit-item.png" />
            <asp:CommandField ShowDeleteButton="True" DeleteImageUrl="~/Images/delete-item.png" DeleteText="Borrar" HeaderImageUrl="~/Images/delete-item.png" />
        </Columns>
    </asp:GridView>

    </form>
<asp:ObjectDataSource ID="ObjectTurnos" runat="server" SelectMethod="ListarTurnos" TypeName="Controladora.ControladoraTurnos" DataObjectTypeName="Modelo.Turno" InsertMethod="AgregarTurno"></asp:ObjectDataSource>

</asp:content>
