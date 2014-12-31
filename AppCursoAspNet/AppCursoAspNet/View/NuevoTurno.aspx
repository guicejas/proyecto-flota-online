<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="NuevoTurno.aspx.cs" Inherits="Vista.View.NuevoTurno" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <ol class="breadcrumb">
            <li><a href="Index.aspx">Inicio</a></li>
            <li><a href="Turnos.aspx">Turnos</a></li>
            <li class="active">Nuevo Turno</li>
        </ol>
    </div>
    <h2>Alta de Turno</h2>
    <p>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/View/Turnos.aspx">Volver</asp:HyperLink>
    </p>

    <form runat="server">

        <table style="width: 81%;" class="table table-hover">


            <tr>
                <td>Vehículo</td>
                <td>
                    <asp:DropDownList ID="DlVehiculo" CssClass="form-control" runat="server" DataSourceID="ObjectVehiculo" DataTextField="Patente" DataValueField="Patente" AppendDataBoundItems="true">

                        <asp:ListItem Value="">Seleccionar vehículo</asp:ListItem>
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjectVehiculo" runat="server" SelectMethod="ListarVehiculos" TypeName="Vista.View.NuevoTurno"></asp:ObjectDataSource>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Debe seleccionar un Vehículo" ControlToValidate="DlVehiculo" CssClass="alert-danger"></asp:RequiredFieldValidator></td>
                <td style="width: 37px">
                    <br />
                </td>
            </tr>


            <tr>
                <td>Chofer</td>
                <td>
                    <asp:DropDownList ID="DlChofer" CssClass="form-control" runat="server" DataSourceID="ObjectChofer" DataTextField="NombreCompleto" DataValueField="Documento" AppendDataBoundItems="true">

                        <asp:ListItem Value="">Seleccionar Chofer</asp:ListItem>
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjectChofer" runat="server" SelectMethod="ListarChoferes" TypeName="Vista.View.NuevoTurno"></asp:ObjectDataSource>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Debe seleccionar un Chofer" ControlToValidate="DlChofer" CssClass="alert-danger"></asp:RequiredFieldValidator></td>
                <td style="width: 37px">
                    <br />
                </td>
            </tr>



             <tr id="fechaInicio" runat="server">
                <td>Fecha Inicio de turno
                </td>
                <td>
                    <input id="dateFechaInicio" class="form-control" runat="server" type="date" name="fecha0" />
                </td>
                <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Ingrese una Fecha de Inicio" ControlToValidate="dateFechaInicio" CssClass="alert-danger"></asp:RequiredFieldValidator>
                <br />
                </td>
            </tr>
            <tr id="horaInicio" runat="server">
                <td>Hora Inicio de turno
                </td>
                <td>
                    <input id="timeHoraInicio" class="form-control" runat="server" type="time" name="fecha0" />
                </td>
                <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Ingrese una Hora de Inicio" ControlToValidate="timeHoraInicio" CssClass="alert-danger"></asp:RequiredFieldValidator>
                <br />
                </td>
            </tr>

                         <tr id="fechaFin" runat="server">
                <td>Fecha Fin de turno
                </td>
                <td>
                    <input id="dateFechaFin" class="form-control" runat="server" type="date" name="fecha0" />
                </td>
                <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Ingrese una Fecha de Inicio" ControlToValidate="dateFechaInicio" CssClass="alert-danger"></asp:RequiredFieldValidator>
                <br />
                </td>
            </tr>
            <tr id="horaFin" runat="server">
                <td>Hora Fin de turno
                </td>
                <td>
                    <input id="timeHoraFin" class="form-control" runat="server" type="time" name="fecha0" />
                </td>
                <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Ingrese una Hora de Inicio" ControlToValidate="timeHoraInicio" CssClass="alert-danger"></asp:RequiredFieldValidator>
                <br />
                </td>
            </tr>



           <tr>
                <td>Kilometros Recorridos</td>
                <td>
                    <asp:TextBox ID="kmRecorridos" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Ingrese Kilomtros Recorridos" ControlToValidate="kmRecorridos" CssClass="alert-danger"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RangeValidator ID="RangeValidator1" Type="Double" ControlToValidate="kmRecorridos" runat="server" ErrorMessage="El Kilometraje ser numérico" CssClass="alert-danger"></asp:RangeValidator>
                </td>
            </tr>

            <tr>
                <td>Kilometros Ocupados</td>
                <td>
                    <asp:TextBox ID="kmOcupados" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Ingrese Kilomtros Recorridos" ControlToValidate="kmOcupados" CssClass="alert-danger"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RangeValidator ID="RangeValidator2" Type="Double" ControlToValidate="kmOcupados" runat="server" ErrorMessage="El Kilometraje ser numérico" CssClass="alert-danger"></asp:RangeValidator>
                </td>
            </tr>

            <tr>
                <td>Cantidad de Viajes</td>
                <td>
                    <asp:TextBox ID="cantViajes" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Ingrese la cantidad de viajes" ControlToValidate="cantViajes" CssClass="alert-danger"></asp:RequiredFieldValidator>
                    <br />
                   
                </td>
            </tr>

                       <tr>
                <td>Recaudacion Efectivo</td>
                <td>
                    <asp:TextBox ID="recaudacion" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Ingrese un monto" ControlToValidate="recaudacion" CssClass="alert-danger"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RangeValidator ID="RangeValidator4" Type="Double" ControlToValidate="recaudacion" runat="server" ErrorMessage="El monto debe ser numérico" CssClass="alert-danger"></asp:RangeValidator>
                </td>
            </tr>

             <tr>
                <td>
                    Gastos
                </td>
                <td>
                    <asp:ListBox ID="ListaGastos" runat="server" CssClass="form-control" DataSourceID="ObjectGasto" DataTextField="id_desc" DataValueField="Id" AppendDataBoundItems="true" SelectionMode="Multiple" >
                    </asp:ListBox>
                    <asp:ObjectDataSource ID="ObjectGasto" runat="server" SelectMethod="ListarGastos" TypeName="Vista.View.NuevoTurno"></asp:ObjectDataSource>
                </td>
                <td>
                  </td>
            </tr>

                         <tr>
                <td>
                    Cuentas Corrientes
                </td>
                <td>
                    <asp:DropDownList ID="DlEmpresas" CssClass="form-control" runat="server" DataSourceID="ObjectEmpresa" DataTextField="RazonSocial" DataValueField="Cuit" AppendDataBoundItems="true">
                        <asp:ListItem Value="">Seleccionar Empresa</asp:ListItem>
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjectEmpresa" runat="server" SelectMethod="ListarEmpresas" TypeName="Vista.View.NuevoTurno"></asp:ObjectDataSource>
                    <br />
                    <asp:TextBox ID="montoCC" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>

                </td>
                <td>
                    
                  </td>
            </tr>


            <tr>
                <td>
                    Comentarios
                </td>
                <td>
                    <asp:TextBox ID="comentarios" runat="server" CssClass="form-control" TextMode="MultiLine" MaxLength="50"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="Ingrese comentarios" ControlToValidate="comentarios" CssClass="alert-danger"></asp:RequiredFieldValidator>
                </td>
            </tr>

                        <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="aceptar" runat="server" CssClass="btn-success" OnClick="aceptar_Click" Text="Aceptar" />
                </td>
                <td>&nbsp;</td>
            </tr>


        </table>
    </form>
</asp:Content>
