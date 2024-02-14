<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearUsuario.aspx.cs" Inherits="WebAppPGODMM.CrearUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-3">
            <div class="form-group">
                <label class="control-label" for="focusedInput">ROL</label>
                <asp:RequiredFieldValidator
                    ID="rfvIdRol"
                    runat="server"
                    ControlToValidate="txtIdRol"
                    ErrorMessage="Campo Requerido."
                    ForeColor="Red"
                    Font-Size="Small" />
                <asp:TextBox runat="server" ID="txtIdRol" CssClass="form-control" placeholder="Administrador" />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-3">
            <div class="form-group">
                <label class="control-label" for="focusedInput">Persona</label>
                <asp:RequiredFieldValidator
                    ID="rfvPersona"
                    runat="server"
                    ControlToValidate="txtPersona"
                    ErrorMessage=" Campo Requerido."
                    ForeColor="Red"
                    Font-Size="Small" />
                <asp:TextBox runat="server" ID="txtPersona" CssClass="form-control" placeholder="Jefferson Benites" />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-3">
            <div class="form-group">
                <label class="control-label" for="focusedInput">Usuario</label>
                <asp:RequiredFieldValidator
                    ID="rfvUsuario"
                    runat="server"
                    ControlToValidate="txtUsuario"
                    ErrorMessage=" Campo Requerido."
                    ForeColor="Red"
                    Font-Size="Small" />
                <asp:TextBox runat="server" ID="txtUsuario" CssClass="form-control" placeholder="Usuario" />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-3">
            <div class="form-group">
                <label class="control-label" for="focusedInput">Password</label>
                <asp:RequiredFieldValidator
                    ID="rfvPassword"
                    runat="server"
                    ControlToValidate="txtPassword"
                    ErrorMessage=" Campo Requerido."
                    ForeColor="Red"
                    Font-Size="Small" />
                <asp:TextBox runat="server" type="password" ID="txtPassword" CssClass="form-control" placeholder="Password" />
            </div>
        </div>
    </div>
    <hr />
    <asp:Button runat="server" ID="btnGrabar" Text="Grabar" OnClick="btnGrabar_Click" />
    <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" OnClick="btnCancelar_Click" CausesValidation="false" />
    <hr />
    <asp:Label runat="server" ID="lblResultado" />
</asp:Content>
