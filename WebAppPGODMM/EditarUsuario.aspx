<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarUsuario.aspx.cs" Inherits="WebAppPGODMM.EditarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField runat="server" ID="lblUsuaId" />
    <div class="row">
        <div class="col-md-3">
            <div class="form-group">
                <label class="control-label" for="focusedInput">Rol</label>
                <asp:RequiredFieldValidator
                    ID="rfvTRol"
                    runat="server"
                    ControlToValidate="ddlTRol"
                    ErrorMessage="Campo Requerido."
                    ForeColor="Red"
                    Font-Size="Small" />
                <asp:DropDownList runat="server" ID="ddlTRol" CssClass="form-control">
                </asp:DropDownList>
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
    <div class="row">
        <div class="col-md-3">
            <div class="form-group">
                <label class="control-label" for="focusedInput">Estado</label>
                <asp:RequiredFieldValidator
                    ID="rfvEstado"
                    runat="server"
                    ControlToValidate="txtEstado"
                    ErrorMessage=" Campo Requerido."
                    ForeColor="Red"
                    Font-Size="Small" />
                <asp:TextBox runat="server" ID="txtEstado" CssClass="form-control" placeholder="ACT" />
            </div>
        </div>
    </div>
    <hr />
    <asp:Button runat="server" ID="btnGrabar" Text="Grabar" OnClick="btnGrabar_Click" />
    <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" OnClick="btnCancelar_Click" CausesValidation="false" />
    <hr />
    <asp:Label ForeColor="Red" ID="lblError" runat="server" />
</asp:Content>
