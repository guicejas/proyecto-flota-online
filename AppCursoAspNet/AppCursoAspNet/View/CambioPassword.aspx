<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CambioPassword.aspx.cs" Inherits="Vista.View.CambioPassword" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

            <div>
        <ol class="breadcrumb">
            <li><a href="Index.aspx">Inicio</a></li>
            <li class="active">Cambiar Contraseña</li>
        </ol>
    </div>

    <div class="well bs-component" style="margin: 0 auto; width: 400px;">

        <form class="form-horizontal" id="formLogin" runat="server">
            <div id="mensaje" runat="server" visible="false">
                <button type="button" class="close" data-dismiss="alert">×</button>
                <span id="mensajeTexto" runat="server"></span>
            </div>
            <fieldset>
                <legend class="text-center">Cambio de Contraseña</legend>

                <div class="form-group">
                    <label for="txtPassActual" class="col-lg-2 control-label">Actual</label><br />
                    <div class="col-lg-10">
                        <input type="password" class="form-control" id="txtPassActual" required="required" runat="server" />
                    </div>
                </div>

                <div class="form-group">
                    <label for="txtPassNuevo" class="col-lg-2 control-label">Nueva</label><br />
                    <div class="col-lg-10">
                        <input type="password" class="form-control" id="txtPassNuevo" required="required" runat="server" />
                    </div>
                </div>

                 <div class="form-group">
                    <label for="txtPassRepite" class="col-lg-2 control-label">Repita</label><br />
                    <div class="col-lg-10">
                        <input type="password" class="form-control" id="txtPassRepite" required="required" runat="server" />
                    </div>
                </div>


                <div class="form-group">
                    <div style="float: right; margin-right: 30px;">
                        <asp:Button UseSubmitBehavior="true" CssClass="btn btn-primary" runat="server" ID="btnReset" OnClick="Change_Password" Text="Cambiar" />
                    </div>
                </div>
            </fieldset>

        </form>

    </div>


</asp:Content>
