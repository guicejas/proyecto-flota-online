<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Vista.View.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

     <div class="well bs-component" style="margin: 0 auto; width:400px;">
   
          <form class="form-horizontal" id="formLogin" runat="server">
       
        <fieldset>
            <legend class="text-center">Login</legend>
            <div class="form-group">
                <label for="inputEmail" class="col-lg-2 control-label">Email</label>
                <div class="col-lg-10">
                    <input type="text" class="form-control" id="inputEmail" placeholder="Email" />
                </div>
            </div>
            <div class="form-group">
                <label for="inputPassword" class="col-lg-2 control-label">Password</label>
                <div class="col-lg-10">
                    <input type="password" class="form-control" id="inputPassword" placeholder="Password" />
                    <div class="checkbox">
                        <label>
                            <input type="checkbox" />
                            Recordarme
                        </label>
                    </div>
                </div>
            </div>
            <div class="form-group"><a href="#" style="float:right; margin-right:30px;">Resetear Contraseña</a></div>
            <div class="form-group">
                <div style="float:right; margin-right:30px;">
                    <button type="submit" class="btn btn-primary">Entrar</button>
                </div>
            </div>
        </fieldset>
       
    </form>
         </div>



    </asp:Content>