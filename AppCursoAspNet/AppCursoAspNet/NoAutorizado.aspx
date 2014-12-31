<%@ Page Title="ERROR" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup ="true" CodeBehind="NoAutorizado.aspx.cs" Inherits="Vista.View.NoAutorizado" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div>
        <ol class="breadcrumb">
            <li><a href="View/Index.aspx">Inicio</a></li>
        </ol>
    </div>
        <h2>Pagina no autorizada</h2>
     <p />
         <asp:Label ID="errorMessage" runat="server" Text="Usted no tiene los permisos para visualizar la pagina solicitada. Contacte al administrador."></asp:Label>

</asp:Content>
