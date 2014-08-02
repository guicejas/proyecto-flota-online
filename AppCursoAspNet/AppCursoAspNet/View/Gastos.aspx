<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Gastos.aspx.cs" Inherits="Vista.Gastos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <ol class="breadcrumb">
            <li><a href="Index.aspx">Inicio</a></li>
            <li class="active">Gastos</li>
        </ol>
    </div>
    <h2>Gastos</h2>
    <p>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/View/NuevoGasto.aspx" class="btn"><span class="glyphicon glyphicon-plus"></span>Agregar Gasto</asp:HyperLink>
    </p>
    <form runat="server">
    <asp:ScriptManager ID="ScriptManager1" AllowCustomErrorsRedirect="false" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="table table-hover">
                <tr>
                    <td>Descripcion: </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtFiltroDescripcion" CssClass="form-control"></asp:TextBox></td>
                    <td>Fecha Vencimiento: </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtFiltroFechaVencimiento" TextMode="Date" CssClass="form-control"></asp:TextBox></td>
                    <td>Estado: </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtFiltroEstado" CssClass="form-control"></asp:TextBox></td>
                    <td>
                    <td>Vehículo: </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtFiltroVehiculo" CssClass="form-control"></asp:TextBox></td>
                    <td>
                        <asp:Button runat="server" ID="btnFiltrar" Text="Filtrar" OnClick="btnFiltrar_Click" CssClass="btn" /></td>
                    <td>
                        <asp:Button runat="server" ID="Button1" Text="Reestablecer" OnClick="btnReestablecer_Click" CssClass="btn" /></td>
                </tr>
            </table>

            <asp:GridView ID="listaGastos" runat="server" AutoGenerateColumns="False" CellPadding="4" SelectMethod="GetGastos" CssClass="table table-striped table-hover" OnRowDeleting="listaGastos_RowDeleting" OnRowEditing="listaGastos_RowEditing">
                <EmptyDataTemplate>
                    No hay gastos.
                </EmptyDataTemplate>
                <AlternatingRowStyle BackColor="White" ForeColor="WhiteSmoke" />
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Gasto Id" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                    <asp:BoundField DataField="Monto" HeaderText="Monto" />
                    <asp:BoundField DataField="Estado" HeaderText="Estado" />
                    <asp:BoundField DataField="FechaVencimientoCorta" HeaderText="Vencimiento" />
                    <asp:CommandField ShowEditButton="True" EditImageUrl="~/Images/edit-item.png" EditText="Editar" HeaderImageUrl="~/Images/edit-item.png" />
                    <asp:CommandField ShowDeleteButton="True" DeleteImageUrl="~/Images/delete-item.png" DeleteText="Borrar" HeaderImageUrl="~/Images/delete-item.png" />
                </Columns>


            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
        </form>


    <asp:ObjectDataSource ID="ObjectGastos" runat="server" SelectMethod="ListarGastos" TypeName="Controladora.ControladoraGastos" DataObjectTypeName="Modelo.Gasto" DeleteMethod="EliminarGasto" InsertMethod="AgregarGasto"></asp:ObjectDataSource>
    &nbsp;&nbsp;&nbsp; 
   
</asp:Content>
