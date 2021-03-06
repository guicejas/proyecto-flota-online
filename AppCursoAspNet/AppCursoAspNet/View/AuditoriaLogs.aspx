﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AuditoriaLogs.aspx.cs" Inherits="Vista.View.AuditoriaLogs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <ol class="breadcrumb">
            <li><a href="Index.aspx">Inicio</a></li>
            <li class="active">Auditoría</li>
        </ol>
    </div>

    <h2>Auditoría Login/Logout</h2>

    <form runat="server">
        <br />

        <asp:ScriptManager ID="ScriptManager1" AllowCustomErrorsRedirect="false" runat="server"></asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table class="table table-hover">
                    <tr>
                        <td>Usuario: </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtFiltroUsuario" CssClass="form-control"></asp:TextBox></td>
                        <td>Fecha: </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtFiltroFecha" TextMode="Date" CssClass="form-control"></asp:TextBox></td>
                        <td>Operación: </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtFiltroOperacion" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:Button runat="server" ID="btnFiltrar" Text="Filtrar" OnClick="btnFiltrar_Click" CssClass="btn" /></td>
                        <td>
                            <asp:Button runat="server" ID="Button1" Text="Reestablecer" OnClick="btnReestablecer_Click" CssClass="btn" /></td>
                    </tr>
                </table>
                <asp:GridView ID="GridAuditoria" runat="server" AutoGenerateColumns="False" CellPadding="4" SelectMethod="GetAuditoria" CssClass="table table-striped table-hover" AllowSorting="true">
                    <AlternatingRowStyle BackColor="White" ForeColor="WhiteSmoke" />

                    <EmptyDataTemplate>
                        No hay registros.
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" />
                        <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
                        <asp:BoundField DataField="FechayHora" HeaderText="Fecha y Hora" />
                        <asp:BoundField DataField="Operacion" HeaderText="Operacion" />
                    </Columns>

                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</asp:Content>


