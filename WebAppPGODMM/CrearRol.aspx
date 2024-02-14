<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearRol.aspx.cs" Inherits="WebAppPGODMM.CrearRol" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-3">
            <div class="form-group">
                <label class="control-label" for="focusedInput">Nombre</label>
                <asp:RequiredFieldValidator
                    ID="rfvRolnombre"
                    runat="server"
                    ControlToValidate="txtRolnombre"
                    ErrorMessage="Campo Requerido."
                    ForeColor="Red"
                    Font-Size="Small" />
                <asp:TextBox runat="server" ID="txtRolnombre" CssClass="form-control" placeholder="Administrador" />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-3">
            <div class="form-group">
                <label class="control-label" for="focusedInput">Descripción</label>
                <asp:RequiredFieldValidator
                    ID="rfvRoldescripcion"
                    runat="server"
                    ControlToValidate="txtRoldescripcion"
                    ErrorMessage=" Campo Requerido."
                    ForeColor="Red"
                    Font-Size="Small" />
                <asp:TextBox runat="server" ID="txtRoldescripcion" CssClass="form-control" placeholder="Maneja el sistema" />
            </div>
        </div>
    </div>
    <hr />
    <asp:Button runat="server" ID="btnGrabar" Text="Grabar" OnClick="btnGrabar_Click" />
    <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" OnClick="btnCancelar_Click" CausesValidation="false" />
    <hr />
    <asp:Label runat="server" ID="lblResultado" />
</asp:Content>
