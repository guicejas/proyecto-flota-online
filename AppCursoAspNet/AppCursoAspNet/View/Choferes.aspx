<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Choferes.aspx.cs" Inherits="Vista.View.Choferes" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <ol class="breadcrumb">
            <li><a href="Index.aspx">Inicio</a></li>
            <li class="active">Choferes</li>
        </ol>
    </div>
    <h2>Choferes</h2>

        <p>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/View/NuevoChofer.aspx" class="btn"><span class="glyphicon glyphicon-plus"></span>Agregar Chofer</asp:HyperLink>
    </p>
        <form runat="server">
                <asp:ScriptManager ID="ScriptManager1" AllowCustomErrorsRedirect="false" runat="server"></asp:ScriptManager>


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
                                <image src='../Images/<%#:Item.Foto%>'
                                    width="250" height="190" border="1" />
                            </a>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdChofer">
                            <code><%#:Item.NombreCompleto%></code>
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
                                <b>Fecha de Nacimiento: </b><%#:Item.FechaNacimientoCorta%>
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
                            
                            <a href="/View/EliminarChofer.aspx?Documento=<%#:Item.Documento%>" role="button" id="btnEliminar" class="btnEliminar" onclick="return confirm('Estas seguro que deseas eliminar este registro?');">
                                <span class="glyphicon glyphicon-delete yellow-icon"></span>
                                    <b>Eliminar<b/>
                            </a><br/>
                            <a href="/View/EditarChofer.aspx?Documento=<%#:Item.Documento%>" role="button" id="btnEditar" class="btnEditar">
                                <span class="glyphicon glyphicon-edit yellow-icon"></span>
                                    <b>Editar<b/>
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

    <asp:ObjectDataSource ID="ObjectChofer" runat="server" SelectMethod="ListChoferes_GetData" TypeName="Vista.View.Choferes"></asp:ObjectDataSource>
           
            
            
                <!-- Bootstrap Modal Dialog -->
<div class="modal fade" id="myModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title"><asp:Label ID="lblModalTitle" runat="server" Text=""></asp:Label></h4>
                    </div>
                    <div class="modal-body">
                        <asp:Label ID="lblModalBody" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="modal-footer">
                        <button class="btn btn-amarillo" data-dismiss="modal" aria-hidden="true">Close</button>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</div>
            
            
             </form>




</asp:Content>
