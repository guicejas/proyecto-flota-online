<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Choferes.aspx.cs" Inherits="Vista.View.Choferes" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <ol class="breadcrumb">
            <li><a href="Index.aspx">Inicio</a></li>
            <li class="active">Choferes</li>
        </ol>
    </div>
    <h2>Choferes</h2>
    <form runat="server">
        <asp:ListView ID="listChoferes" runat="server" GroupItemCount="3" ItemType="Modelo.Chofer" DataSourceID="ObjectChofer">
            <EmptyDataTemplate>
                <table>
                    <tr>
                        <td>No hay choferes cargados</td>
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
                    <table>
                        <tr>
                            <td>
                                <a>
                                    <image src='../Images/<%#:Item.Foto%>.png'
                                        width="250" height="190" border="1" />
                                </a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <code><%#:Item.Nombre%> <%#:Item.Apellido%></code>
                                <br />
                                <span>
                                    <b>DNI: </b><%#Item.Documento.ToString()%>
                                </span>
                                <br />
                                <span>
                                    <b>Domicilio: </b><%#:Item.Domicilio%>
                                </span>
                                <br />
                                <span>
                                    <b>Fecha de Nacimiento: </b><%#:Item.FechaNacimiento%>
                                </span>
                                <br />
                                <span>
                                    <b>Localidad: </b><%#:Item.Localidad%>
                                </span>
                                <br />
                                <span>
                                    <b>Licencia: </b><%#:Item.Licencia%>
                                </span>
                                <br />
                                <span>
                                    <b>Teléfono: </b><%#:Item.Telefono%>
                                </span>
                                <br />
                                <span>
                                    <b>Email: </b><%#:Item.Correo%>
                                </span>
                                <br />

                                <a href="/View/EliminarChofer.aspx?Documento=<%#:Item.Documento%>" role="button">
                                    <span class="glyphicon glyphicon-delete"></span>
                                    <b>Eliminar<b />
                                </a>
                                <br />
                                <a href="/View/EditarChofer.aspx?Documento=<%#:Item.Documento%>" role="button">
                                    <span class="glyphicon "></span>
                                    <b>Editar<b />
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
    </form>
    <asp:ObjectDataSource ID="ObjectChofer" runat="server" SelectMethod="ListarChoferes" TypeName="Controladora.ControladoraChoferes"></asp:ObjectDataSource>







</asp:Content>
