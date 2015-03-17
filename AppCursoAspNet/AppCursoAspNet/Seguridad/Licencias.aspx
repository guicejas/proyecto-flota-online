<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Licencias.aspx.cs" Inherits="Vista.Seguridad.Licencias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <ol class="breadcrumb">
            <li><a href="../View/Index.aspx">Inicio</a></li>
            <li class="active">Licencias</li>
        </ol>
    </div>
    <br />
    <h2>Panel de Licencias adquiridas</h2>

    <asp:ListView ID="listLicencias" runat="server" GroupItemCount="4" ItemType="Modelo.SEGURIDAD.Licencia" DataSourceID="ObjectLicencias">
        <EmptyDataTemplate>
            <table>
                <tr>
                    <td>No hay licencias adquiridas.</td>
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
                <table class="semaforo-<%#:Item.getColor()%>" style="width: 260px;">
                    <tr>
                        <td>

                            <span>
                                <b>Id: </b><%#:Item.Id.ToString()%>
                            </span>

                            <br />
                            <span>
                                <b>Tipo: </b><%#:Item.tipoLicencia()%>
                            </span>
                            <br />
                            <code>Estado: <%#:Item.Estado%></code>
                            <br />
                            <br />
                            <span>
                                <b>Flota: </b><%#:Item.getFlota()%>
                            </span>
                            <br />
                            <span>
                                <b>Descripcion: </b><%#:Item.getDescipcionTipo()%>
                            </span>
                            <br />
                            <span>
                                <b>Inicio: </b><%#:Item.FechaInicio.ToShortDateString()%>
                            </span>
                            <br />
                            <span>
                                <b>Fin: </b><%#:Item.FechaFin.ToShortDateString()%>
                            </span>
                            <br />
                            <span>
                                <b>Transaccion: </b><%#:Item.NroTransaccion%>
                            </span>
                            <br /><br />
                            <a href="AceptarLicencia.aspx?id=<%#:Item.Id%>" role="button" id="btnAceptar" class="btnEditar btn-success">
                                <b>ACEPTAR<b />
                            </a>
                            <br />
                            <a href="RechazarLicencia.aspx?id=<%#:Item.Id%>" role="button" id="btnRechazar" class="btnEliminar btn-danger" onclick="return confirm('Estas seguro que deseas rechazar esta licencia?');">
                                <b>RECHAZAR<b />
                            </a>
                            <br />

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
    <asp:ObjectDataSource ID="ObjectLicencias" runat="server" SelectMethod="ListLicencias_GetData" TypeName="Vista.Seguridad.Licencias"></asp:ObjectDataSource>
    <b></b>
</asp:Content>
