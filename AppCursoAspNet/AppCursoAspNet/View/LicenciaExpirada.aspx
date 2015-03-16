<%@ Page Title="Licencia Expirada" Language="C#" AutoEventWireup="true" CodeBehind="LicenciaExpirada.aspx.cs" Inherits="Vista.View.LicenciaExpirada" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Sistema Flota de Taxis Online - Trypep sistemas - 2015</title>
    <link rel="shortcut icon" href="Images/taxi.ico" type="image/x-icon" />

    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../Content/glyphicons.css" rel="stylesheet" />
    <link href="../Content/Site.css" rel="stylesheet" />

    <script type="text/javascript" src="../Scripts/jquery-2.1.0.min.js"></script>
    <script type="text/javascript" src="../Scripts/bootstrap.js"></script>
    <script type="text/javascript" src="../Scripts/Site.js"></script>
    <script type="text/javascript" src="../Scripts/bootbox.js"></script>
    <script type="text/javascript" src="../Scripts/bootstrap-confirmation.js"></script>
    <script type="text/javascript">
        !function ($) {

            $(function () {

                $('[data-toggle="confirmation"]').confirmation();
                $('[data-toggle="confirmation-singleton"]').confirmation({ singleton: true });
                $('[data-toggle="confirmation-popout"]').confirmation({ popout: true });

            })

        }(window.jQuery)
        </script>
    
</head>

<body style="margin-left:100px; margin-right:100px; margin-top:25px;">
    <form>
        <div class="navbar navbar-default navbar-fixed-top">
            <div class="container">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-responsive-collapse">
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand" runat="server" href="~/View/Index"><asp:Label ID="flotaUser" runat="server" Text="Flota Online"></asp:Label></a>
                </div>
                <div class="navbar-collapse collapse navbar-responsive-collapse">
                    <div id="menuPrincipal" runat="server">
                        <ul class="nav navbar-nav">

                        </ul>
                    </div>

                    <ul class="nav navbar-nav navbar-right">

                        <li id="menuUsuario" class="dropdown" runat="server">
                            <a runat="server" href="#" class="dropdown-toggle" data-toggle="dropdown"><span class="glyphicon glyphicon-user yellow-icon"></span><span id="nombreUsuario" runat="server"><%: this.Context.User.Identity.Name %></span><b class="caret"></b></a>
                            <ul class="dropdown-menu" role="menu">
                                <li><a href="../Logout.aspx"><span class="glyphicon glyphicon-exit yellow-icon"></span>Salir del sistema</a></li>
                            </ul>
                        </li>
                    </ul>
                </div>
            </div>
            <div class="gradient">
                <div class="taxi-pattern greydout"></div>
            </div>
        </div>
        <br />

        <p />   
        <p />
    </form>

    <form runat="server">
        <asp:ScriptManager ID="ScriptManager1" AllowCustomErrorsRedirect="false" runat="server"></asp:ScriptManager>

                    <div id="mensaje" runat="server">
                <button type="button" class="close" data-dismiss="alert">×</button>
                <span id="mensajeTexto" runat="server"></span>
            </div>

        <div id="divMiLicencia" style="background-color: transparent; padding: 5px 5px 10px 15px;">
            <blockquote>

                <span style="font-size: x-large;">Su <span id="spanDescripcion" runat="server" class="text-info">Licencia Demo 30</span> expiro.
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
                        Fecha de Adquisicion
                    </li>
                    <li class="list-group-item">
                        <span class="badge" id="spanFechaFin" runat="server"></span>
                        Fecha de Caducidad
                    </li>
                </ul>

            </blockquote>

        </div>
        <br />

        <asp:ListView Visible="false" ID="listaTiposdeLicenciaBasica" runat="server" GroupItemCount="3" ItemType="Modelo.SEGURIDAD.Basica" DataSourceID="ObjectTiposdeLicenciaBasica">
            <GroupTemplate>
                <tr id="itemPlaceholderContainer" runat="server">
                    <td id="itemPlaceholder" runat="server"></td>
                </tr>
            </GroupTemplate>
            <ItemTemplate>

                <td runat="server">
                    <table style="border: 1px solid black; border-radius: 7px; background-color: white; margin: 15px; width: 240px; box-shadow:3px 3px 1px black;">
                        <tbody style="">
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
                                    <div class="line-separator"></div>
                                    
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
                                    <div class="line-separator"></div>
                                    <span>
                                        <b>Precio Final: </b><%#:String.Format("{0:c}", Item.Precio)%> ARS
                                    </span>
                                    <br />
                                    <br />

                                     <a href="/View/Checkout.aspx?Item=<%#:Item.Id%>" role="button" id="btnComprar" class="btn btn-success">

                                        <b>COMPRAR<b />
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

        <asp:ListView Visible="false" ID="listaTiposdeLicenciaPremium" runat="server" GroupItemCount="3" ItemType="Modelo.SEGURIDAD.Premium" DataSourceID="ObjectTiposdeLicenciaPremium">
            <GroupTemplate>
                <tr id="itemPlaceholderContainer" runat="server">
                    <td id="itemPlaceholder" runat="server"></td>
                </tr>
            </GroupTemplate>
            <ItemTemplate>
                <td runat="server">
                    <table style="border: 1px solid black; border-radius: 7px; background-color: white; margin: 15px; width: 240px; box-shadow:3px 3px 1px black;">
                        <tbody style="">
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
                                    <div class="line-separator"></div>
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
                                    <div class="line-separator"></div>
                                    <span>
                                        <b>Precio Final: </b><%#:String.Format("{0:c}", Item.Precio)%> ARS
                                    </span>
                                    <br />
                                    <br />

                                     <a href="/View/Checkout.aspx?Item=<%#:Item.Id%>" role="button" id="btnComprar" class="btn btn-success">

                                        <b>COMPRAR<b />
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

        </form>

    </body>

    </html>