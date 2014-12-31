<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ReporteQlikView.aspx.cs" Inherits="Vista.ReporteQlikView" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <ol class="breadcrumb">
            <li><a href="Index.aspx">Inicio</a></li>
            <li class="active">QlikView</li>
        </ol>
    </div>
    <h2>Reportes Qlikview</h2>
        <br />
    <form runat="server">
    
    <div class="text-center">
            <a href="http://www.qlik.com/" ><img src="../Images/logoqlikview.png" /></a>
    <br />

           <asp:LinkButton ID="hl_download" runat="server" OnClick="hl_download_Click" CssClass="btn">
            <span class="glyphicon glyphicon-disk_export yellow-icon"></span>
            <b>Descargar tablero de indicadores</b>
        </asp:LinkButton>
        <br />
    <br />
    <img src="../Images/QlikViewPartner.jpg" width="180" height='250'/>
    <br />

    </div>

        </form>



</asp:Content>
