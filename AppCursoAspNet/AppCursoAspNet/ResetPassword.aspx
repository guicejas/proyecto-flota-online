<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="Vista.ResetPassword" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

            <div>
        <ol class="breadcrumb">
            <li class="active">Resetear Contraseña</li>
        </ol>
    </div>

    <div class="well bs-component" style="margin: 0 auto; width: 400px;">

        <form class="form-horizontal" id="formLogin" runat="server">
            <div id="mensaje" runat="server" visible="false">
                <button type="button" class="close" data-dismiss="alert">×</button>
                <span id="mensajeTexto" runat="server"></span>
            </div>
            <fieldset>
                <legend class="text-center">Resetear Contraseña</legend>

                <div class="form-group">
                    <label for="inputUsuario" class="col-lg-2 control-label">Email</label><br />
                    <div class="col-lg-10">
                        <input type="text" class="form-control" id="inputEmail" placeholder="Email" required="required" runat="server" />
                    </div>
                </div>

                <div class="form-group">
                    <div style="float: right; margin-right: 30px;">
                        <asp:Button UseSubmitBehavior="true" CssClass="btn btn-primary" runat="server" ID="btnReset" OnClick="Reset_Password" Text="Resetear" />
                    </div>
                </div>
            </fieldset>

        </form>

    </div>


</asp:Content>
