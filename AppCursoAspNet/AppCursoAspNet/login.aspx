<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Vista.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="well bs-component" style="margin: 0 auto; width: 400px;">

        <form class="form-horizontal" id="formLogin" runat="server">
            <div id="mensaje" runat="server">
                <button type="button" class="close" data-dismiss="alert">×</button>
                <span id="mensajeTexto" runat="server"></span>
            </div>
            <fieldset>
                <legend class="text-center">Login</legend>

                <div class="form-group">
                    <label for="inputUsuario" class="col-lg-2 control-label">Usuario</label>
                    <div class="col-lg-10">
                        <input type="text" class="form-control" id="inputUsuario" placeholder="Usuario" required="required" runat="server" />
                    </div>
                </div>

                <div class="form-group">
                    <label for="inputPassword" class="col-lg-2 control-label">Password</label>
                    <div class="col-lg-10">
                        <input type="password" class="form-control" id="inputPassword" placeholder="Password" required="required" runat="server" />
                    </div>
                </div>
                <div class="form-group">
                    <div class="checkbox">
                        <label>
                            <input type="checkbox" id="recordarme" runat="server" />
                            Recordarme la proxima vez.
                        </label>
                    </div>
                </div>

                <div class="form-group">
                    <a href="ResetPassword" style="float: right; margin-right: 30px;">Resetear Password</a>
                </div>

                <div class="form-group">
                    <div style="float: right; margin-right: 30px;">
                        <asp:Button UseSubmitBehavior="true" CssClass="btn btn-primary" runat="server" ID="btnIngresar" OnClick="LoginSistema_Authenticate" Text="Ingresar" />
                    </div>
                </div>

                <div class="form-group">
                    <a href="Registrarse" style="float: left; margin-left: 60px;" class="text-warning text-center">REGISTRATE y obtene una demo por 30 dias!</a>
                </div>

            </fieldset>

        </form>

    </div>


</asp:Content>
