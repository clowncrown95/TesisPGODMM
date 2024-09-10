<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearOT.aspx.cs" Inherits="WebAppPGODMM.CrearOT" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-3">
            <div class="form-group">
                <label class="control-label" for="focusedInput">Usuario</label>
                <asp:RequiredFieldValidator
                    ID="rfvIdUsuario"
                    runat="server"
                    ControlToValidate="ddlUsuario"
                    ErrorMessage="Campo Requerido."
                    ForeColor="Red"
                    Font-Size="Small" />
                <asp:DropDownList runat="server" ID="ddlUsuario" CssClass="form-control">
                </asp:DropDownList>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-3">
            <div class="form-group">
                <label class="control-label" for="focusedInput">Local</label>
                <asp:RequiredFieldValidator
                    ID="rfvLocal"
                    runat="server"
                    ControlToValidate="ddlLocal"
                    ErrorMessage=" Campo Requerido."
                    ForeColor="Red"
                    Font-Size="Small" />
                <asp:DropDownList runat="server" ID="ddlLocal" CssClass="form-control">
                </asp:DropDownList>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-3">
            <div class="form-group">
                <label class="control-label" for="focusedInput">Estado</label>
                <asp:RequiredFieldValidator
                    ID="rfvIdEstado"
                    runat="server"
                    ControlToValidate="ddlEstado"
                    ErrorMessage=" Campo Requerido."
                    ForeColor="Red"
                    Font-Size="Small" />
                <asp:DropDownList runat="server" ID="ddlEstado" CssClass="form-control">
                </asp:DropDownList>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-3">
            <div class="form-group">
                <label class="control-label" for="focusedInput">Fecha Inicio</label>
                <asp:TextBox runat="server" TextMode="Date" ID="Fini" CssClass="form-control" placeholder="" />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-3">
            <div class="form-group">
                <label class="control-label" for="focusedInput">Fecha Fin</label>
                <asp:TextBox runat="server" TextMode="Date" ID="Ffin" CssClass="form-control" placeholder="" />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-3">
            <div class="form-group">
                <label class="control-label" for="focusedInput"># Orden</label>
                <asp:RequiredFieldValidator
                    ID="rfvNumOrd"
                    runat="server"
                    ControlToValidate="txtNumOrd"
                    ErrorMessage=" Campo Requerido."
                    ForeColor="Red"
                    Font-Size="Small" />
                <asp:TextBox runat="server" ID="txtNumOrd" CssClass="form-control" placeholder="514236" />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-3">
            <div class="form-group">
                <label class="control-label" for="focusedInput">Equipo</label>
                <asp:RequiredFieldValidator
                    ID="rfvIdEquipo"
                    runat="server"
                    ControlToValidate="ddlEquipo"
                    ErrorMessage=" Campo Requerido."
                    ForeColor="Red"
                    Font-Size="Small" />
                <asp:DropDownList runat="server" ID="ddlEquipo" CssClass="form-control">
                </asp:DropDownList>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-3">
            <div class="form-group">
                <label class="control-label" for="focusedInput">Detalle</label>
                <asp:RequiredFieldValidator
                    ID="rfvDetalle"
                    runat="server"
                    ControlToValidate="txtDetalle"
                    ErrorMessage=" Campo Requerido."
                    ForeColor="Red"
                    Font-Size="Small" />
                <asp:TextBox runat="server" ID="txtDetalle" CssClass="form-control" placeholder=" " />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-3">
            <div class="form-group">
                <label class="control-label" for="focusedInput">Descripion Tecnico</label>
                <asp:RequiredFieldValidator
                    ID="rfvdesTec"
                    runat="server"
                    ControlToValidate="txtdesTec"
                    ErrorMessage=" Campo Requerido."
                    ForeColor="Red"
                    Font-Size="Small" />
                <asp:TextBox runat="server" ID="txtdesTec" CssClass="form-control" placeholder=" " />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-3">
            <div class="form-group">
                <label class="control-label" for="focusedInput">Respaldo Tecnico</label>
                <asp:RequiredFieldValidator
                    ID="rfvresTec"
                    runat="server"
                    ControlToValidate="txtresTec"
                    ErrorMessage=" Campo Requerido."
                    ForeColor="Red"
                    Font-Size="Small" />
                <asp:TextBox runat="server" ID="txtresTec" CssClass="form-control" placeholder=" " />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-3">
            <div class="form-group">
                <label class="control-label" for="focusedInput">Tecnico Costo</label>
                <asp:RequiredFieldValidator
                    ID="rfvcosTec"
                    runat="server"
                    ControlToValidate="txtcosTec"
                    ErrorMessage=" Campo Requerido."
                    ForeColor="Red"
                    Font-Size="Small" />
                <asp:TextBox runat="server" type="number" ID="txtcosTec" CssClass="form-control" placeholder=" " />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-3">
            <div class="form-group">
                <label class="control-label" for="focusedInput">Firma Tecnico</label>
                <asp:RequiredFieldValidator
                    ID="rfvfirTec"
                    runat="server"
                    ControlToValidate="txtfirTec"
                    ErrorMessage=" Campo Requerido."
                    ForeColor="Red"
                    Font-Size="Small" />
                <asp:TextBox runat="server" ID="txtfirTec" CssClass="form-control" placeholder=" " />
            </div>
        </div>
    </div>
<hr />
<asp:Button runat="server" ID="btnGrabar" Text="Grabar" OnClick="btnGrabar_Click" />
<asp:Button runat="server" ID="btnCancelar" Text="Cancelar" OnClick="btnCancelar_Click" CausesValidation="false" />
<hr />
<asp:Label runat="server" ID="lblResultado" />
</asp:Content>
