<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="LicenciaFlota.aspx.cs" Inherits="Vista.Seguridad.LicenciaFlota" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <ol class="breadcrumb">
            <li><a href="Index.aspx">Inicio</a></li>
            <li class="active">Mi Licencia</li>
        </ol>
    </div>
    <h2>Mi Licencia</h2>

    <form runat="server">
        <asp:ScriptManager ID="ScriptManager1" AllowCustomErrorsRedirect="false" runat="server"></asp:ScriptManager>

        <div id="divMiLicencia" style="background-color: transparent; padding: 5px 5px 10px 15px">
            <blockquote>

                <span style="font-size: x-large;">Su <span id="spanDescripcion" runat="server" class="text-info">Licencia Demo 30</span> expira en <span id="spanDiasRestantes" runat="server" class="text-warning">10</span> dias.
                </span>
                <br />

                <ul class="list-group" style="width: 400px;">
                    <li class="list-group-item">
                        <span class="badge" id="spanTipo" runat="server"></span>
                        Tipo
                    </li>
                    <li class="list-group-item">
                        <span class="badge" id="spanEstado" runat="server"></span>
                        Estado
                    </li>
                    <li class="list-group-item">
                        <span class="badge" id="spanUsuariosAdicionales" runat="server">0</span>
                        Usuarios Adicionales
                    </li>
                    <li class="list-group-item">
                        <span class="badge" id="spanFechaCompra" runat="server"></span>
                        Fecha de compra
                    </li>
                    <li class="list-group-item">
                        <span class="badge" id="spanFechaFin" runat="server"></span>
                        Fecha de caducidad
                    </li>
                </ul>

            </blockquote>

        </div>
        <br />

        <asp:ListView ID="listaTiposdeLicenciaBasica" runat="server" GroupItemCount="3" ItemType="Modelo.SEGURIDAD.Basica" DataSourceID="ObjectTiposdeLicenciaBasica">
            <GroupTemplate>
                <tr id="itemPlaceholderContainer" runat="server">
                    <td id="itemPlaceholder" runat="server"></td>
                </tr>
            </GroupTemplate>
            <ItemTemplate>
                <td runat="server">
                    <table style="background-color: white; margin: 15px; width: 240px">
                        <tbody style="border: 5px  solid rgb(221, 196, 196);">
                            <tr>
                                <td style="padding-left: 15px; padding-right: 25px;">
                                    <h4 style="color: black;"><%#:Item.tipo%></h4>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-left: 15px; padding-right: 25px; color: darkslateblue;">

                                    <span style="font-size: x-large; font-weight: 700;">
                                        <%#:String.Format("{0:c}", (Item.Precio/(Item.Duracion/30)))%> 
                                    </span>
                                    / mes
                                    <br />

                                    <span><%#:Item.Descripcion.ToUpper()%></span>
                                    <br />
                                    <br />
                                    <span style="font-size: x-large; font-weight: 700;">
                                        <%#:Item.Duracion.ToString()%>
                                    </span>
                                    dias de vigencia
                                    <br />
                                    <span style="font-size: x-large; font-weight: 700;">1
                                    </span>
                                    usuario
                                    <br />
                                    <span style="font-size: x-large; font-weight: 700;">CON 
                                    </span>
                                    publicidades
                                    <br />
                                    <br />
                                    <span>
                                        <b>Precio Final: </b><%#:String.Format("{0:c}", Item.Precio)%> ARS
                                    </span>
                                    <br />

                                    <a href="/View/EditarChofer.aspx?Documento=<%#:Item.Id%>" role="button" id="btnEditar" class="btnEditar">
                                        <span class="glyphicon glyphicon-edit yellow-icon"></span>
                                        <b>Editar<b />
                                    </a>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                        </tbody>
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

        <asp:ObjectDataSource ID="ObjectTiposdeLicenciaBasica" runat="server" SelectMethod="ListarTiposdeLicenciaBasica" TypeName="Controladora.SEGURIDAD.ControladoraTiposdeLicencia"></asp:ObjectDataSource>

        <asp:ListView ID="listaTiposdeLicenciaPremium" runat="server" GroupItemCount="3" ItemType="Modelo.SEGURIDAD.Premium" DataSourceID="ObjectTiposdeLicenciaPremium">
            <GroupTemplate>
                <tr id="itemPlaceholderContainer" runat="server">
                    <td id="itemPlaceholder" runat="server"></td>
                </tr>
            </GroupTemplate>
            <ItemTemplate>
                <td runat="server">
                    <table style="background-color: white; margin: 15px; width: 240px">
                        <tbody style="border: 5px  solid rgb(221, 196, 196);">
                            <tr>
                                <td style="padding-left: 15px; padding-right: 25px;">
                                    <h4 style="color: black;"><%#:Item.tipo%></h4>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-left: 15px; padding-right: 25px; color: darkslateblue;">

                                    <span style="font-size: x-large; font-weight: 700;">
                                        <%#:String.Format("{0:c}", (Item.Precio/(Item.Duracion/30)))%> 
                                    </span>
                                    / mes
                                    <br />

                                    <span><%#:Item.Descripcion.ToUpper()%></span>
                                    <br />
                                    <br />
                                    <span style="font-size: x-large; font-weight: 700;">
                                        <%#:Item.Duracion.ToString()%>
                                    </span>
                                    dias de vigencia
                                    <br />
                                    <span style="font-size: x-large; font-weight: 700;">
                                        <%#:Item.CantUsuarios.ToString()%>
                                    </span>
                                    usuarios
                                    <br />
                                    <span style="font-size: x-large; font-weight: 700;">0 
                                    </span>
                                    publicidades
                                    <br />
                                    <br />
                                    <span>
                                        <b>Precio Final: </b><%#:String.Format("{0:c}", Item.Precio)%> ARS
                                    </span>
                                    <br />

                                    <a href="/View/EditarChofer.aspx?Documento=<%#:Item.Id%>" role="button" id="btnEditar" class="btnEditar">
                                        <span class="glyphicon glyphicon-edit yellow-icon"></span>
                                        <b>Editar<b />
                                    </a>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                        </tbody>
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

        <asp:ObjectDataSource ID="ObjectTiposdeLicenciaPremium" runat="server" SelectMethod="ListarTiposdeLicenciaPremium" TypeName="Controladora.SEGURIDAD.ControladoraTiposdeLicencia"></asp:ObjectDataSource>

        <!-- Bootstrap Modal Dialog -->
        <div class="modal fade" id="myModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                <h4 class="modal-title">
                                    <asp:Label ID="lblModalTitle" runat="server" Text=""></asp:Label></h4>
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
