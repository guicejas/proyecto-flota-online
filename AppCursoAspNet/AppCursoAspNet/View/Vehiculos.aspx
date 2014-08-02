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
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/View/NuevoVehiculo.aspx" class="btn"><span class="glyphicon glyphicon-plus"></span>Agregar Vehiculo</asp:HyperLink>
    </p>


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
                    <asp:CommandField ShowDeleteButton="True" DeleteImageUrl="~/Images/delete-item.png" DeleteText="Borrar" HeaderImageUrl="~/Images/delete-item.png" />
                </Columns>


    </asp:GridView>


<asp:ObjectDataSource ID="ObjectVehiculos" runat="server" SelectMethod="ListarVehiculos" TypeName="Controladora.ControladoraVehiculos" DataObjectTypeName="Modelo.Vehiculo" InsertMethod="AgregarVehiculo"></asp:ObjectDataSource>


</asp:Content>