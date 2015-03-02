<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MonitorGastos.aspx.cs" Inherits="Vista.View.MonitorGastos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div>
        <ol class="breadcrumb">
            <li><a href="Index.aspx">Inicio</a></li>
            <li><a href="Gastos.aspx">Gastos</a></li>
            <li class="active">Monitor de Gastos</li>
        </ol>
    </div>
    <br />
    <h2>Monitor de Gastos</h2>
    <hr />
    <div class="progress progress-striped active">
        <div id="barraVerde" class="progress-bar progress-bar-success" style="" title="Gastos en fecha aceptable" runat="server"></div>
        <div id="barraAmarilla" class="progress-bar progress-bar-warning" style="" title="Gastos en fecha cercana" runat="server"></div>
        <div id="barraRoja" class="progress-bar progress-bar-danger" style="" title="Gastos en fecha límite" runat="server"></div>
    </div>
    <div>
        <span class="glyphicon glyphicon-"></span>
            <b>Generar Informe de Gastos: </b>
        <a href="/View/ReporteGastos.aspx?Formato=PDF" class="btn" role="button" runat="server">
            <span class="glyphicon glyphicon-disk_export yellow-icon"></span>
            <b>PDF</b>
        </a>

        <a href="/View/ReporteGastos.aspx?Formato=EXCEL" class="btn" role="button" runat="server">
            <span class="glyphicon glyphicon-disk_export yellow-icon"></span>
            <b>EXCEL</b>
        </a>

        <br />
    </div>
    <hr />
    <asp:ListView ID="listGastos" runat="server" GroupItemCount="4" ItemType="Modelo.Gasto" DataSourceID="ObjectMonitorGastos">
        <EmptyDataTemplate>
            <table>
                <tr>
                    <td>No hay gastos proximos a vencer.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <EmptyItemTemplate>
            <td />
        </EmptyItemTemplate>
        <GroupTemplate>
            <tr id="itemPlaceholderContainer" runat="server">
                <td id="itemPlaceholder" runat="server"></td>
            </tr>
        </GroupTemplate>
        <ItemTemplate>
            <td runat="server">
                <table class="semaforo-<%#:Item.Semaforo%>">
                    <tr>
                        <td>
                            <a>
                                <image src='../Images/<%#:Item.TipoGasto%>.png'
                                    width="250" height="190" border="1" />
                            </a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <code><%#:Item.Descripcion%></code>
                            <br />
                            <span>
                                <b>Precio: </b><%#:String.Format("{0:c}", Item.Monto)%>
                            </span>
                            <br />
                            <span>
                                <b>Vencimiento: </b><%#:Item.FechaVencimiento.ToShortDateString()%>
                            </span>
                            <br />
                            <a href="/View/PagarGasto.aspx?gastoID=<%#:Item.Id %>" class="btn btn-<%#:Item.Semaforo%>" role="button" >
                                <span class="glyphicon glyphicon-money"></span>
                                    <b>Pagar<b/>
                            </a><br/>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                </table>
                </p>
            </td>
        </ItemTemplate>
        <LayoutTemplate>
            <table style="width: 100%;">
                <tbody>
                    <tr>
                        <td>
                            <table id="groupPlaceholderContainer" runat="server" style="width: 100%">
                                <tr id="groupPlaceholder"></tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                    <tr></tr>
                </tbody>
            </table>
        </LayoutTemplate>
    </asp:ListView>
    <asp:ObjectDataSource ID="ObjectMonitorGastos" runat="server" SelectMethod="ListMonitorGastos_GetData" TypeName="Vista.View.MonitorGastos"></asp:ObjectDataSource>
    <b></b>
</asp:Content>
