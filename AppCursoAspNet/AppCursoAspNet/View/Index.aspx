<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Vista.Index" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <p>Bienvenido <%: this.Context.User.Identity.Name %></p>
    <div class="col-lg-8">
        <img src="../Images/TxtPortada.png" /><br />
    </div>
    <div class="col-lg-4">
        <br />
        <br />
        <div id="panelMonitor" runat="server">
            <div class="panel-heading">
                <h3 class="panel-title"><span id="iconMonitor" class="glyphicon glyphicon-warning_sign" runat="server"></span>Monitor de Gastos</h3>
            </div>
            <div class="panel-body">
                <span id="contenidoMonitor" runat="server"></span>
                <br />
                <a runat="server" href="~/View/MonitorGastos">Ir al Monitor de Gastos</a>
            </div>
        </div>
        <br />
        <br />
    </div>

</asp:Content>
