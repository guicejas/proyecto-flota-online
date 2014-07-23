<%@ Page Title="ERROR" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup ="true" CodeBehind="Error.aspx.cs" Inherits="Vista.View.Error" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div>
        <ol class="breadcrumb">
            <li><a href="Index.aspx">Inicio</a></li>
        </ol>
    </div>
        <h2>ERROR</h2>
     <p />
         <asp:Label ID="errorMessage" runat="server" Text="Error"></asp:Label>

</asp:Content>
